using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.thebytestuff.VenstarAPI
{
    public class ThermostatUpdate
    {
        [JsonProperty("mode"), JsonConverter(typeof(StringEnumConverter))]
        public Nullable<ThermostatMode> Mode { get; set; } = null;

        [JsonProperty("fan"), JsonConverter(typeof(StringEnumConverter))]
        public Nullable<FanSetting> FanSetting { get; set; } = null;

        [JsonProperty("heattemp")]
        public float HeatTemperatureTarget { get; set; }

        [JsonProperty("cooltemp")]
        public float CoolTemperatureTarget { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; } = null;
    }
}
