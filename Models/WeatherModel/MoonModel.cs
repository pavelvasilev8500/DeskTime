using System;

namespace Infinity.Models.WeatherModel
{
    public class MoonModel
    {
        public string Rise { get; set; }
        public int EpochRise { get; set; }
        public string Set { get; set; }
        public int EpochSet { get; set; }
        public string Phase { get; set; }
        public int Age { get; set; }
    }
}