using DeskTime.Models._12HoursWeatherModel;
using DeskTime.Models;
using Infinity.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DeskTime.Classes.Database;

namespace DeskTime.Classes.Data
{
    public static class Weather
    {
        private static readonly string weather = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/28573?apikey=cOmhLMyrgrBc2wrVG50ajf7PE0VhGVWP&language=ru-RU&details=true&metric=true";
        private static readonly string _12hourWeather = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/28573?apikey=cOmhLMyrgrBc2wrVG50ajf7PE0VhGVWP&language=ru-RU&details=true&metric=true";

        private static HttpClient httpClient = new HttpClient();
        private static ApplicationContext _dbContext = new ApplicationContext();

        public static async Task<(string, string)> GetCity(string key, string city, string language)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={key}&q={city}&language={language}");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                var a = JsonConvert.DeserializeObject<List<SearchModel>>(content);
                string name = a[0].LocalizedName + ", ";
                string cityKey = a[0].Key;
                return(name, cityKey);
            }
            catch (Exception)
            {
                return ("No ethernet connection", "");
            }
        }

        public static async Task<(string, string)> GetWeather(string cityKey, string key, string language, bool details, bool metric)
        {
            try
            {
                //throw new Exception("No Network");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/{cityKey}?apikey={key}&language={language}&details={details}&metric={metric}");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                var a = JsonConvert.DeserializeObject<List<_12HWeatherModel>>(content);
                string weatherText = Math.Round(a[0].Temperature.Value) + $" °{a[0].Temperature.Unit}";
                string realFeelWeatherText = $"Ощущается как {Math.Round(a[0].RealFeelTemperature.Value) + $" °{a[0].RealFeelTemperature.Unit}"}";
                using (ApplicationContext dbContext = new ApplicationContext())
                {
                    _dbContext.Database.EnsureDeleted();
                    _dbContext.Database.EnsureCreated();
                    for (int i = 0; i < a.Count; i++)
                    {
                        var item = new _12HWDBModel
                        {
                            WeatherModel = a[i]
                        };
                        _dbContext.Add(item);
                        _dbContext.SaveChanges();
                    }
                }
                return (weatherText, realFeelWeatherText);
                //if (DateTime.Now.Hour < 18 && DateTime.Now.Hour > 6)
                //    WeatherText += Math.Round(a.DailyForecasts[0].Temperature.Maximum.Value).ToString() + $" °{a.DailyForecasts[0].Temperature.Maximum.Unit}";
                //else
                //    WeatherText += Math.Round(a.DailyForecasts[0].Temperature.Minimum.Value).ToString() + $" °{a.DailyForecasts[0].Temperature.Minimum.Unit}";
            }
            catch (Exception ex)
            {
                //httpClient.Dispose();
                _dbContext._12HWeather.Include(t => t.WeatherModel.Temperature).
                                       Include(r => r.WeatherModel.RealFeelTemperature).
                                       Load();
                foreach (var o in _dbContext._12HWeather.Local.ToList())
                {
                    if (DateTime.Parse(o.WeatherModel.DateTime).Hour == DateTime.Now.Hour || DateTime.Parse(o.WeatherModel.DateTime).Hour == DateTime.Now.AddHours(1).Hour)
                    {
                        return ($"Offline {Math.Round(o.WeatherModel.Temperature.Value)} °{o.WeatherModel.Temperature.Unit}", 
                            $"Ощущается как {Math.Round(o.WeatherModel.RealFeelTemperature.Value)} °{o.WeatherModel.RealFeelTemperature.Unit}");
                    }
                }
                return ("Oflline", "no data");
            }
        }
    }
}
