using System.Collections.Generic;
using System;

namespace Infinity.Models.WeatherModel
{
    public class DailyForecastsModel
    {
        public string Date { get; set; }
        public int EpochDate { get; set; }
        public SunModel Sun { get; set; }
        public MoonModel Moon { get; set; }
        public TemperatureModel Temperature { get; set; }
        public RealFeelTemperatureModel RealFeelTemperature { get; set; }
        public RealFeelTemperatureModel RealFeelTemperatureShade { get; set; }
        public float HoursOfSun { get; set; }
        public DegreeDaySummaryModel DegreeDaySummary { get; set; }
        public List<AirAndPollenModel> AirAndPollen { get; set; }
        public DayNightModel Day { get; set; }
        public DayNightModel Night { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}