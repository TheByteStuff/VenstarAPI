using System;
using System.Collections.Generic;
using System.Text;
using System.Security;

using System.Net;
using System.Net.Http;
using System.Net.Sockets;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using RestSharp;
using RestSharp.Authenticators;

namespace com.thebytestuff.VenstarAPI
{
    public class VenstarAPIHelper
    {
        private string URL;
        private RestClient client;


        private NetworkCredential NetworkCredential;
        private CredentialCache CredentialCache;

        private VenstarAPIHelper(string url)
        {
            URL = url;
            client = new RestClient();
            client.BaseUrl = new Uri(url);
        }

        private VenstarAPIHelper(string url, string user, string password): this(url)
        {
            NetworkCredential = new NetworkCredential(user, password);
        }

        public static VenstarAPIHelper CreateHelper(string url)
        {
            return new VenstarAPIHelper(url);
        }

        /*
         * Reference https://stickler.de/en/information/code-snippets/httpwebrequest-with-digest-authentication-c-csharp
         * for setting up the Digest authentication
         */
        public static VenstarAPIHelper CreateSecureHelper(string url, string user, string password)
        {
            /*/
            throw new Exception("Not yet implemented");
            /*/
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            VenstarAPIHelper me = new VenstarAPIHelper(url, user, password);
            RestClient client = new RestClient(url)
            {
            };
            RestRequest dummy = new RestRequest(Method.GET);
            dummy.Resource = "";
            me.CredentialCache = new CredentialCache();
            me.CredentialCache.Add(client.BuildUri(dummy), "Digest", me.NetworkCredential);
            return me;
            //*/
        }


        public ThermostatBaseInfo GetThermostatBaseInfo()
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "",
                Credentials= CredentialCache
            };

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            ThermostatBaseInfo returnobject = JsonConvert.DeserializeObject<ThermostatBaseInfo>(content);
            return returnobject;
        }

        public Thermostat GetThermostatDetailInfo()
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "query/info",
                Credentials = CredentialCache
            };

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Thermostat returnobject = JsonConvert.DeserializeObject<Thermostat>(content);
            return returnobject;
        }

        public Alerts GetAlerts()
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "query/alerts",
                Credentials = CredentialCache
            };

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Alerts returnobject = JsonConvert.DeserializeObject<Alerts>(content);
            return returnobject;
        }

        public Sensors GetSensors()
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "query/sensors",
                Credentials = CredentialCache
            };

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Sensors returnobject = JsonConvert.DeserializeObject<Sensors>(content);
            return returnobject;
        }

        public Runtimes GetRuntimes()
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "query/runtimes",
                Credentials = CredentialCache
            };

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Runtimes returnobject = JsonConvert.DeserializeObject<Runtimes>(content);
            return returnobject;
        }

        public bool UpdateThermostat(ThermostatUpdate UpdateInfo)
        {
            var update = new RestRequest()
            {
                Method = Method.POST,
                Resource = "control",
                Credentials = CredentialCache
            };
            update.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            if (UpdateInfo.Mode != null)
            {
                update.AddParameter("mode", Convert.ToString((int)UpdateInfo.Mode));
            };

            if (UpdateInfo.FanSetting != null)
            {
                update.AddParameter("fan", Convert.ToString((int)UpdateInfo.FanSetting));
            };
            update.AddParameter("heattemp", UpdateInfo.HeatTemperatureTarget);
            update.AddParameter("cooltemp", UpdateInfo.CoolTemperatureTarget);
            if (UpdateInfo.Pin != null)
            {
                update.AddParameter("pin", UpdateInfo.Pin);
            };

            IRestResponse response = client.Execute(update);
            var content = response.Content;

            return (content.Contains("success"));
        }
    }
}
