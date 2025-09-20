using DeskTime.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DeskTime.Classes.Database;
using DeskTime.Models.Weather.Current;

namespace DeskTime.Classes.Data
{
    public static class Weather
    {
        private static readonly string _currentWeather = "https://api.weatherapi.com/v1/current.json?";
        //q=Gomel&lang=ru&key=e454373f51804440af5205401251809

        private static HttpClient httpClient = new HttpClient();
        private static ApplicationContext _dbContext = new ApplicationContext();

        public static async Task<(string, string)> GetWeather(string City, string lang, string key)
        {
            if (!string.IsNullOrEmpty(City))
            {
                try
                {
                    string req = "";
                    if (string.IsNullOrEmpty(lang))
                        req = $"{_currentWeather}q={City}&key={key}";
                    else
                        req = $"{_currentWeather}q={City}lang={lang}&key={key}";
                    //throw new Exception("No Network");
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, req);
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    string res = await response.Content.ReadAsStringAsync();
                    var jRes = JsonConvert.DeserializeObject<CurrentWeather>(res);
                    string weatherText = "";// Math.Round(a[0].Temperature.Value) + $" °{a[0].Temperature.Unit}";
                    string realFeelWeatherText = "";// $"Ощущается как {Math.Round(a[0].RealFeelTemperature.Value) + $" °{a[0].RealFeelTemperature.Unit}"}";
                    //using (ApplicationContext dbContext = new ApplicationContext())
                    //{
                    //    _dbContext.Database.EnsureDeleted();
                    //    _dbContext.Database.EnsureCreated();
                    //    for (int i = 0; i < a.Count; i++)
                    //    {
                    //        var item = new _12HWDBModel
                    //        {
                    //            WeatherModel = a[i]
                    //        };
                    //        _dbContext.Add(item);
                    //        _dbContext.SaveChanges();
                    //    }
                    //}
                    return (weatherText, realFeelWeatherText);
                    //if (DateTime.Now.Hour < 18 && DateTime.Now.Hour > 6)
                    //    WeatherText += Math.Round(a.DailyForecasts[0].Temperature.Maximum.Value).ToString() + $" °{a.DailyForecasts[0].Temperature.Maximum.Unit}";
                    //else
                    //    WeatherText += Math.Round(a.DailyForecasts[0].Temperature.Minimum.Value).ToString() + $" °{a.DailyForecasts[0].Temperature.Minimum.Unit}";
                }
                catch (Exception ex)
                {
                    ////httpClient.Dispose();
                    //_dbContext._12HWeather.Include(t => t.WeatherModel.Temperature).
                    //                       Include(r => r.WeatherModel.RealFeelTemperature).
                    //                       Load();
                    //foreach (var o in _dbContext._12HWeather.Local.ToList())
                    //{
                    //    if (DateTime.Parse(o.WeatherModel.DateTime).Hour == DateTime.Now.Hour || DateTime.Parse(o.WeatherModel.DateTime).Hour == DateTime.Now.AddHours(1).Hour)
                    //    {
                    //        return ($"Offline {Math.Round(o.WeatherModel.Temperature.Value)} °{o.WeatherModel.Temperature.Unit}",
                    //            $"Ощущается как {Math.Round(o.WeatherModel.RealFeelTemperature.Value)} °{o.WeatherModel.RealFeelTemperature.Unit}");
                    //    }
                    //}
                    return ("Oflline", "no data");
                }
            }
            else
                return ("", "");
        }
    }
}
