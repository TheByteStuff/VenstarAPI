using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.thebytestuff.VenstarAPI
{
    public class Runtimes
    {
        [JsonProperty("runtimes")]
        public List<RuntimeDetail> RuntimeDetails { get; set; }
    }

    public class RuntimeDetail
    {
        [JsonProperty("ts")]
        public string Timestamp { get; set; }

        [JsonProperty("heat1")]
        public int HeatStage1Minutes { get; set; }

        [JsonProperty("heat2")]
        public int HeatStage2Minutes { get; set; }

        [JsonProperty("cool1")]
        public int CoolStage1Minutes { get; set; }

        [JsonProperty("cool2")]
        public int CoolStage2Minutes { get; set; }

        [JsonProperty("aux1")]
        public int AuxiliaryStage1Minutes { get; set; }

        [JsonProperty("aux2")]
        public int AuxiliaryStage2Minutes { get; set; }

        [JsonProperty("fc")]
        public int FreeCoolingMinutes { get; set; }

        [JsonProperty("ov")]
        public int OverrideMinutes { get; set; }
    }
}
