using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.Classes.Models.Weather.Current
{
    internal class CurrentWeather
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }
}
