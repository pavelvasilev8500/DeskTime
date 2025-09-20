namespace Infinity.Models.WeatherModel
{
    public class DayNightModel
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public int PrecipitationProbability { get; set; }
        public int ThunderstormProbability { get; set; }
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
        public WindModel Wind { get; set; }
        public WindModel WindGust { get; set; }
        public TemperatureDetail TotalLiquid { get; set; }
        public TemperatureDetail Rain { get; set; }
        public TemperatureDetail Snow { get; set; }
        public TemperatureDetail Ice { get; set; }
        public float HoursOfPrecipitation { get; set; }
        public float HoursOfRain { get; set; }
        public float HoursOfSnow { get; set; }
        public float HoursOfIce { get; set; }
        public int CloudCover { get; set; }
        public TemperatureDetail Evapotranspiration { get; set; }
        public TemperatureDetail SolarIrradiance { get; set; }
        public RelativeHumidityModel RelativeHumidity { get; set; }
        public WetBulbTemperatureModel WetBulbTemperature { get; set; }
        public WetBulbTemperatureModel WetBulbGlobeTemperature { get; set; }
    }
}