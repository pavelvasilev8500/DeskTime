using DeskTime.Classes.Database;
using DeskTime.Models.Weather;
using DeskTime.Models.Weather.Forecast;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeskTime.Classes.Data
{
    public static class Weather
    {
        private static readonly string _forecastWeather = "https://api.weatherapi.com/v1/forecast.json?";
        private static HttpClient httpClient = new HttpClient();

        public static async Task<(string, string)> GetForecast(string city, string lang, string key)
        {
            string temp = "";
            string realf_temp = "";
            if (!string.IsNullOrEmpty(city))
            {
                try
                {
                    var req = $"{_forecastWeather}q={city}&days=2&lang={lang}&key={key}";
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, req);
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    string res = await response.Content.ReadAsStringAsync();
                    
                    switch(response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            ForecastWeather jRes = JsonConvert.DeserializeObject<ForecastWeather>(res);
                            temp = jRes.Current.Temp_c.ToString();
                            realf_temp = jRes.Current.Feelslike_c.ToString();
                            DbManager.SetDb(jRes, city);
                            break;
                        default:
                            ErrorModel jERes = JsonConvert.DeserializeObject<ErrorModel>(res);
                            temp = jERes.Error.Code.ToString();
                            realf_temp = jERes.Error.Message.ToString();
                            break;
                    }
                    return (temp, realf_temp);
                }
                catch (Exception)
                {
                    return (temp, realf_temp);
                }
            }
            else
                return (temp, realf_temp);
        }
    }
}
