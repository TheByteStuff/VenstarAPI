using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using com.thebytestuff.VenstarAPI;

namespace com.thebytestuff.VenstarAPIReferenceCalls
{
    public class VenstarAPIReferenceCalls
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("start");

            VenstarAPIReferenceCalls me = new VenstarAPIReferenceCalls();
            //*/
            me.ReferenceCallsSecure();
            /*/
            me.ReferenceCallsUnsecure();
            //*/

            Console.WriteLine("end");
        }

        private void ReferenceCallsUnsecure()
        {
            VenstarAPIHelper helper = VenstarAPIHelper.CreateHelper("http://192.168.21.130");
            ReferenceCallsBase(helper);
        }

        private void ReferenceCallsSecure()
        {
            VenstarAPIHelper helper = VenstarAPIHelper.CreateSecureHelper("https://192.168.21.130", "ADMIN", "ADMIN");
            ReferenceCallsBase(helper);
        }

        private void ReferenceCallsBase(VenstarAPIHelper helper)
        {
            ThermostatBaseInfo baseinfo = helper.GetThermostatBaseInfo();
            Thermostat stat = helper.GetThermostatDetailInfo();
            Alerts alerts = helper.GetAlerts();
            Runtimes runtimes = helper.GetRuntimes();
            Sensors sensors = helper.GetSensors();

            ThermostatUpdate Update = new ThermostatUpdate
            {
                HeatTemperatureTarget = stat.HeatTemperatureTarget + 2
                ,
                CoolTemperatureTarget = stat.CoolTemperatureTarget - 2
                ,
                Mode = ThermostatMode.Heat
                //,Pin = "" //Required if Pin set on thermostat
            };
            bool Update1Result = helper.UpdateThermostat(Update);

            Thermostat stat2 = helper.GetThermostatDetailInfo();

            ThermostatUpdate Update2 = new ThermostatUpdate
            {
                HeatTemperatureTarget = stat.HeatTemperatureTarget + 2
                ,
                CoolTemperatureTarget = stat.CoolTemperatureTarget - 2
                ,
                Mode = ThermostatMode.Cool
                ,
                FanSetting = FanSetting.Auto
                //,Pin = "" //Required if Pin set on thermostat
            };
            bool Update2Result = helper.UpdateThermostat(Update2);

            ThermostatUpdate Update3 = new ThermostatUpdate
            {
                HeatTemperatureTarget = stat.HeatTemperatureTarget
                ,
                CoolTemperatureTarget = stat.CoolTemperatureTarget
                ,
                Pin = "BadPin"
            };
            bool Update3Result = helper.UpdateThermostat(Update3);

        }
    }
}
