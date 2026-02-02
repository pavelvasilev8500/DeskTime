namespace DeskTime.Models.DataModels.Weather.Forecast
{
    internal class Forecastday
    {
        public string Date { get; set; }
        public int Date_epoch { get; set; }
        public Day Day { get; set; }
        public Astro Astro { get; set; }
        public Hour[] Hour { get; set; }
    }
}
