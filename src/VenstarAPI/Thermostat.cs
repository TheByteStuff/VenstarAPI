using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.thebytestuff.VenstarAPI
{
    public class Thermostat
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mode"), JsonConverter(typeof(StringEnumConverter))]
        public ThermostatMode Mode { get; set; }

        [JsonProperty("state"), JsonConverter(typeof(StringEnumConverter))]
        public SystemState SystemState { get; set; }

        [JsonProperty("fan"), JsonConverter(typeof(StringEnumConverter))]
        public FanSetting FanSetting { get; set; }

        [JsonProperty("fanstate"), JsonConverter(typeof(StringEnumConverter))]
        public FanState FanState { get; set; }

        [JsonProperty("tempunits"), JsonConverter(typeof(StringEnumConverter))]
        public TemperatureUnits Tempunits { get; set; }

        [JsonProperty("schedule"), JsonConverter(typeof(StringEnumConverter))]
        public ScheduleState Schedule { get; set; }

        [JsonProperty("schedulepart"), JsonConverter(typeof(StringEnumConverter))]
        public SchedulePart SchedulePart { get; set; }

        [JsonProperty("away"), JsonConverter(typeof(StringEnumConverter))]
        public AwayState AwayState { get; set; }

        [JsonProperty("spacetemp")]
        public float SpaceTemperature { get; set; }

        [JsonProperty("heattemp")]
        public float HeatTemperatureTarget { get; set; }

        [JsonProperty("cooltemp")]
        public float CoolTemperatureTarget { get; set; }

        [JsonProperty("cooltempmin")]
        public float CoolTemperatureMin { get; set; }

        [JsonProperty("cooltempmax")]
        public float CoolTemperatureMax { get; set; }

        [JsonProperty("heattempmin")]
        public float HeatTemperatureMin { get; set; }

        [JsonProperty("heattempmax")]
        public float HeatTemperatureMax { get; set; }

        //activestage

        // hum_active

        [JsonProperty("hum")]
        public float HumidityReading { get; set; }

        [JsonProperty("hum_setpoint")]
        public float HumiditySetPoint { get; set; }

        [JsonProperty("dehum_setpoint")]
        public float DeHumidifySetPoint { get; set; }

        [JsonProperty("setpointdelta")]
        public float SetPointDelta { get; set; }

        [JsonProperty("availablemodes"), JsonConverter(typeof(StringEnumConverter))]
        public AvailableModes AvailableModes { get; set; }
    }
}
