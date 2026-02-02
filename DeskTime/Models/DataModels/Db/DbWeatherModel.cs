namespace DeskTime.Models.DataModels.Db
{
    internal class DbWeatherModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public double Temperature {  get; set; }
        public double RealFeealTemperature { get; set; }
        public string WeatherIcon { get; set; }
    }
}
