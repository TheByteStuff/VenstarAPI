using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.thebytestuff.VenstarAPI
{
    public class Alerts
    {
        [JsonProperty("alerts")]
        public List<AlertDetail> AlertDetails { get; set; }
    }

    public class AlertDetail
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
