using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DeskTime.Models._12HoursWeatherModel
{
    public class _12HWeatherModel
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public long EpochDateTime { get; set; }
        public int WeatherIcon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }
        public bool IsDaylight { get; set; }
        public TemperatureModel Temperature { get; set; }
        public RealFeelTemperatureModel RealFeelTemperature { get; set; }
        public RealFeelTemperatureShadeModel RealFeelTemperatureShade { get; set; }
        public WetBulbTemperatureModel WetBulbTemperature { get; set; }
        public WetBulbGlobeTemperatureModel WetBulbGlobeTemperature { get; set; }
        public DewPointModel DewPoint { get; set; }
        public WindModel Wind { get; set; }
        public WindGustModel WindGust { get; set; }
        public int RelativeHumidity { get; set; }
        public int IndoorRelativeHumidity { get; set; }
        public VisibilityModel Visibility { get; set; }
        public CeilingModel Ceiling { get; set; }
        public int UVIndex { get; set; }
        public string UVIndexText { get; set; }
        public int PrecipitationProbability { get; set; }
        public int ThunderstormProbability { get; set; }
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
        public TotalLiquidModel TotalLiquid { get; set; }
        public RainModel Rain { get; set; }
        public SnowModel Snow { get; set; }
        public IceModel Ice { get; set; }
        public int CloudCover { get; set; }
        public EvapotranspirationModel Evapotranspiration { get; set; }
        public SolarIrradianceModel SolarIrradiance { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

}
