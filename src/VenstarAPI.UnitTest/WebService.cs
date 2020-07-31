using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace VenstarAPI.UnitTest
{
    /*
     * Utilized code from this post as a base
     * http://www.gabescode.com/dotnet/2018/11/01/basic-HttpListener-web-service.html
     * 
     */
    internal static class WebService
    {
        private static HttpListener Listener; // = new HttpListener { Prefixes = { $"http://127.0.0.1:{Port}/" } };
        private static bool _keepGoing = true;
        private static Task _mainLoop;

        private static Dictionary<string, string> ApiTestReplies = new Dictionary<string, string>();

        public static void StartWebServer()
        {
            StartWebServer(@"TestData/ApiReplies.txt", "http://127.0.0.1:8080/");
        }


        public static void StartWebServer(string ApiRepliesFileName, string BaseURL)
        {
            if (_mainLoop != null && !_mainLoop.IsCompleted) return; //Already started

            Listener = new HttpListener { Prefixes = { BaseURL } };

            using (StreamReader InputFileStream = new StreamReader(ApiRepliesFileName))
            {
                string InFileLine = InputFileStream.ReadLine();
                while (InFileLine != null)
                {
                    string[] Param = InFileLine.Split(';');
                    if (Param.Length == 2)
                    {
                        ApiTestReplies.Add(Param[0], Param[1]);
                    }
                    else
                    {
                        //if input doesn't split on ";" into two parms, discard
                    }
                    InFileLine = InputFileStream.ReadLine();
                }
            }
            _mainLoop = MainLoop();
        }

        public static void StopWebServer()
        {
            _keepGoing = false;
            lock (Listener)
            {
                Listener.Stop();
            }
            try
            {
                _mainLoop.Wait();
            }
            catch {  }
        }


        private static async Task MainLoop()
        {
            Listener.Start();
            while (_keepGoing)
            {
                try
                {
                    var context = await Listener.GetContextAsync();
                    lock (Listener)
                    {
                        if (_keepGoing) ProcessRequest(context);
                    }
                }
                catch (Exception e)
                {
                    if (e is HttpListenerException) return; 
                }
            }
        }

        private static void ProcessRequest(HttpListenerContext context)
        {
            using (var response = context.Response)
            {
                try
                {
                    var handled = false;

                    string ReplyText = "Unknown Request";
                    if (ApiTestReplies.TryGetValue(context.Request.Url.AbsolutePath, out ReplyText))
                    {
                        response.ContentType = "application/json";
                        var buffer = Encoding.UTF8.GetBytes(ReplyText);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                        handled = true;
                    }
                    else
                    {
                        response.StatusCode = 400;
                    }

                    if (!handled)
                    {
                        response.StatusCode = 404;
                    }
                }
                catch (Exception e)
                {
                    response.StatusCode = 500;
                    response.ContentType = "application/json";
                    var buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(e));
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}