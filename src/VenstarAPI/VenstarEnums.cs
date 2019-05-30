using System;
using System.Collections.Generic;
using System.Text;

namespace com.thebytestuff.VenstarAPI
{
    public enum SystemState
    {
        Idle = 0,
        Heating = 1,
        Cooling = 2,
        Lockout = 3,
        Error = 4
    }

    public enum ThermostatMode
    {
        Off = 0,
        Heat = 1,
        Cool = 2,
        Auto = 3
    }

    public enum FanSetting
    {
        Auto = 0,
        On = 1
    }

    public enum FanState
    {
        Off = 0,
        On = 1,
    }

    public enum TemperatureUnits
    {
        Fahrenheit = 0,
        Celsius = 1
    }

    public enum ScheduleState
    {
        Fahrenheit = 0,
        Celsius = 1
    }

    public enum AvailableModes
    {
        AllModes = 0,
        HeatCoolOnly = 1,
        HeatOnly = 2,
        CoolOnly = 3
    }


    public enum SchedulePart
    {
        Occupied1OrMorning = 0,
        Occupied2OrDay = 1,
        Occupied3OrEvening = 2,
        OccupiedOrNight = 3,
        Inactive = 255
    }

    public enum AwayState
    {
        Home = 0,
        Away = 1
    }

}

