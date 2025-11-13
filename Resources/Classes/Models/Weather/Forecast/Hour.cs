using Resources.Classes.Models.Weather.Current;

namespace Resources.Classes.Models.Weather.Forecast
{
    internal class Hour
    {
        public int Time_epoch { get; set; }
        public string Time { get; set; }
        public double Temp_c { get; set; }
        public double Temp_f { get; set; }
        public int Is_day { get; set; }
        public Condition Condition { get; set; }
        public double Wind_mph { get; set; }
        public double Wind_kph { get; set; }
        public double Wind_degree { get; set; }
        public string Wind_dir { get; set; }
        public double Pressure_mb { get; set; }
        public double Pressure_in { get; set; }
        public double Precip_mm { get; set; }
        public double Precip_in { get; set; }
        public double Snow_cm { get; set; }
        public double Humidity { get; set; }
        public double Cloud { get; set; }
        public double Feelslike_c { get; set; }
        public double Feelslike_f { get; set; }
        public double Windchill_c { get; set; }
        public double Windchill_f { get; set; }
        public double Heatindex_c { get; set; }
        public double Heatindex_f { get; set; }
        public double Dewpoint_c { get; set; }
        public double Dewpoint_f { get; set; }
        public double Will_it_rain { get; set; }
        public double Chance_of_rain { get; set; }
        public double Will_it_snow { get; set; }
        public double Chance_of_snow { get; set; }
        public double Vis_km { get; set; }
        public double Vis_miles { get; set; }
        public double Gust_mph { get; set; }
        public double Gust_kph { get; set; }
        public double Uv { get; set; }
        public double Short_rad { get; set; }
        public double Diff_rad { get; set; }
        public double Dni { get; set; }
        public double Gti { get; set; }
    }
}
