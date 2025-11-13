using Resources.Classes.Models.Weather.Current;

namespace Resources.Classes.Models.Weather.Forecast
{
    internal class Day
    {
        public double Maxtemp_c {  get; set; }
        public double Maxtemp_f { get; set; }
        public double Mintemp_c { get; set; }
        public double Mintemp_f { get; set; }
        public double Avgtemp_c { get; set; }
        public double Avgtemp_f { get; set; }
        public double Maxwind_mph { get; set; }
        public double Maxwind_kph { get; set; }
        public double Totalprecip_mm { get; set; }
        public double Totalprecip_in { get; set; }
        public double Totalsnow_cm { get; set; }
        public double Avgvis_km { get; set; }
        public double Avgvis_miles { get; set; }
        public double Avghumidity { get; set; }
        public double Daily_will_it_rain { get; set; }
        public double Daily_chance_of_rain { get; set; }
        public double Daily_will_it_snow { get; set; }
        public double Daily_chance_of_snow { get; set; }
        public Condition Condition { get; set; }
        public double Uv { get; set; }
    }
}
