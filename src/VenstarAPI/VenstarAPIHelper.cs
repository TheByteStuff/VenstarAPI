using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
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
        private string UserId;
        private string Password;
        private RestClient client;

        private VenstarAPIHelper(string url)
        {
            URL = url;
            client = new RestClient();
            client.BaseUrl = new Uri(url);
        }

        private VenstarAPIHelper(string url, string user, string password): this(url)
        {
            UserId = user;
            Password = password;
        }

        public static VenstarAPIHelper CreateHelper(string url)
        {
            VenstarAPIHelper me = new VenstarAPIHelper(url);
            return me;
        }

        public static VenstarAPIHelper CreateSecureHelper(string url, string user, string password)
        {
            throw new Exception("Not yet implemented");
            
            //VenstarAPIHelper me = new VenstarAPIHelper(url, user, password);
            //return me;
        }


        public ThermostatBaseInfo GetThermostatBaseInfo()
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = ""
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
                Resource = "query/info"
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
                Resource = "query/alerts"
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
                Resource = "query/sensors"
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
                Resource = "query/runtimes"
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
                Resource = "control"
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

        /*
         * 
         * "Digest username=\"ADMIN\", realm=\"thermostat\", nonce=\"1558545171\", uri=\"/control\", algorithm=MD5, response=\"066772cead98b5867bd550930315dec5\", opaque=\"\", qop=auth, nc=00000005, cnonce=\"9757159\""
         * 
         * "Digest 
         *      username=\"ADMIN\", 
         *      realm=\"thermostat\", 
         *      nonce=\"1558545171\", 
         *      uri=\"/control\", 
         *      algorithm=MD5, 
         *      response=\"066772cead98b5867bd550930315dec5\", 
         *      opaque=\"\", 
         *      qop=auth, 
         *      nc=00000005, 
         *      cnonce=\"9757159\""
         */

    }
}
