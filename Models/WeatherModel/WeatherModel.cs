using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Models.WeatherModel
{
    internal class WeatherModel
    {
        public HeadlineModel Headline {  get; set; }
        public List<DailyForecastsModel> DailyForecasts { get; set; }
    }
}
