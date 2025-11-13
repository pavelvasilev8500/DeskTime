namespace Resources.Classes.Models.Weather.Forecast
{
    internal class ForecastWeather
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast Forecast { get; set; }
    }
}
