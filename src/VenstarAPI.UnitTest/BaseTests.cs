using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using com.thebytestuff.VenstarAPI;

namespace VenstarAPI.UnitTest
{
    public class BaseTests
    {
        public static void Test_GetThermostatBaseInfo(VenstarAPIHelper helper)
        {
            ThermostatBaseInfo baseinfo = helper.GetThermostatBaseInfo();

            Assert.IsNotNull(baseinfo);
            Assert.AreEqual("9", baseinfo.APIVersion);
            Assert.AreEqual("6.87", baseinfo.FirmwareVersion);
            Assert.AreEqual("COLORTOUCH", baseinfo.Model);
            Assert.AreEqual("residential", baseinfo.Type);
        }

        public static void Test_GetThermostatDetailInfo(VenstarAPIHelper helper)
        {
            Thermostat stat = helper.GetThermostatDetailInfo();

            Assert.IsNotNull(stat);
            Assert.AreEqual(AvailableModes.AllModes, stat.AvailableModes);
            Assert.AreEqual(AwayState.Home, stat.AwayState);
            Assert.AreEqual(99, stat.CoolTemperatureMax);
            Assert.AreEqual(65, stat.CoolTemperatureMin);
            Assert.AreEqual(73, stat.CoolTemperatureTarget);
            Assert.AreEqual(99, stat.DeHumidifySetPoint);
            Assert.AreEqual(FanSetting.Auto, stat.FanSetting);
            Assert.AreEqual(FanState.On, stat.FanState);
            Assert.AreEqual(77, stat.HeatTemperatureMax);
            Assert.AreEqual(35, stat.HeatTemperatureMin);
            Assert.AreEqual(69, stat.HeatTemperatureTarget);
            Assert.AreEqual(57, stat.HumidityReading);
            Assert.AreEqual(0, stat.HumiditySetPoint);
            Assert.AreEqual(ThermostatMode.Auto, stat.Mode);
            Assert.AreEqual("Dining Room", stat.Name);
            Assert.AreEqual(ScheduleState.Fahrenheit, stat.Schedule);
            Assert.AreEqual(SchedulePart.Inactive, stat.SchedulePart);
            Assert.AreEqual(1.0, stat.SetPointDelta);
            Assert.AreEqual(77, stat.SpaceTemperature);
            Assert.AreEqual(SystemState.Cooling, stat.SystemState);
            Assert.AreEqual(TemperatureUnits.Fahrenheit, stat.Tempunits);
        }

        public static void Test_GetAlerts(VenstarAPIHelper helper)
        {
            Alerts alerts = helper.GetAlerts();
            Assert.IsNotNull(alerts);
            Assert.IsNotNull(alerts.AlertDetails);

            Assert.AreEqual(3, alerts.AlertDetails.Count);
            Assert.AreEqual("Air Filter", alerts.AlertDetails[0].Name);
            Assert.IsFalse(alerts.AlertDetails[0].Active);

            Assert.AreEqual("UV Lamp", alerts.AlertDetails[1].Name);
            Assert.IsTrue(alerts.AlertDetails[1].Active);

            Assert.AreEqual("Service", alerts.AlertDetails[2].Name);
            Assert.IsFalse(alerts.AlertDetails[2].Active);
        }

        public static void Test_GetRuntimes(VenstarAPIHelper helper)
        {
            Runtimes runtimes = helper.GetRuntimes();
            Assert.IsNotNull(runtimes);
            Assert.IsNotNull(runtimes.RuntimeDetails);

            Assert.AreEqual(7, runtimes.RuntimeDetails.Count);
            Assert.AreEqual("1565827200", runtimes.RuntimeDetails[0].Timestamp);
            Assert.AreEqual(10, runtimes.RuntimeDetails[0].HeatStage1Minutes);
            Assert.AreEqual(20, runtimes.RuntimeDetails[0].HeatStage2Minutes);
            Assert.AreEqual(1035, runtimes.RuntimeDetails[0].CoolStage1Minutes);
            Assert.AreEqual(589, runtimes.RuntimeDetails[0].CoolStage2Minutes);
            Assert.AreEqual(50, runtimes.RuntimeDetails[0].FreeCoolingMinutes);
            Assert.AreEqual(30, runtimes.RuntimeDetails[0].AuxiliaryStage1Minutes);
            Assert.AreEqual(40, runtimes.RuntimeDetails[0].AuxiliaryStage2Minutes);
            Assert.AreEqual(60, runtimes.RuntimeDetails[0].OverrideMinutes);
        }

        public static void Test_GetSensors(VenstarAPIHelper helper)
        {
            Sensors sensors = helper.GetSensors();
            Assert.IsNotNull(sensors);
            Assert.IsNotNull(sensors.SensorDetails);

            Assert.AreEqual(3, sensors.SensorDetails.Count);
            Assert.AreEqual("Thermostat", sensors.SensorDetails[0].Name);
            Assert.AreEqual(74.0, sensors.SensorDetails[0].Temperature);
            Assert.AreEqual(42, sensors.SensorDetails[0].HumidityReading);

            Assert.AreEqual("Space Temp", sensors.SensorDetails[1].Name);
            Assert.AreEqual(74.0, sensors.SensorDetails[1].Temperature);
        }


        public static void Test_Update(VenstarAPIHelper helper)
        {
            Thermostat stat = helper.GetThermostatDetailInfo();
            ThermostatUpdate Update = new ThermostatUpdate
            {
                HeatTemperatureTarget = stat.HeatTemperatureTarget + 2
                ,
                CoolTemperatureTarget = stat.CoolTemperatureTarget - 2
                ,
                Mode = ThermostatMode.Heat
            };
            bool Update1Result = helper.UpdateThermostat(Update);
            Assert.IsTrue(Update1Result);
        }

    }
}
