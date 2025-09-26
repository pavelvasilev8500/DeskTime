using DeskTime.Models.Weather;
using DeskTime.Models.Weather.Forecast;
using System.Linq;

namespace DeskTime.Classes.Database
{
    internal static class DbManager
    {
        public static void SetDb(ForecastWeather forecastWeather, string city)
        {
            DbWeatherModel weather;
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                foreach (var o in forecastWeather.Forecast.Forecastday)
                {
                    foreach (var w in o.Hour)
                    {
                        weather = new DbWeatherModel
                        {
                            City = city,
                            Date = w.Time,
                            Temperature = w.Temp_c,
                            RealFeealTemperature = w.Feelslike_c,
                            WeatherIcon = w.Condition.Icon
                        };
                        db.Add(weather);
                        db.SaveChanges();
                    }
                }
            }
        }

        public static DbWeatherModel GetDb(string currentDate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var weather = db.Weather.FirstOrDefault(x => x.Date == currentDate);
                if (weather != null)
                    return weather;
                else
                    return null;
            }
        }
    }
}
