using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.thebytestuff.VenstarAPI
{
    public class ThermostatBaseInfo
    {
        [JsonProperty("api_ver")]
        public string APIVersion { get; set; }

        // Make Type an enum?
        //[JsonProperty("fanstate"), JsonConverter(typeof(StringEnumConverter))]
        //public FanState FanState { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("firmware")]
        public string FirmwareVersion { get; set; }
    }
}
