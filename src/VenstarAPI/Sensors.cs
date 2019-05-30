using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.thebytestuff.VenstarAPI
{
    public class Sensors
    {
        [JsonProperty("sensors")]
        public List<SensorDetail> SensorDetails { get; set; }
    }

    public class SensorDetail
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("hum")]
        public float HumidityReading { get; set; }
    }
}
