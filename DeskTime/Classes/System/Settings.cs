using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Threading.Tasks;
using DeskTime.Models.AppModels.Settings;
using Prism.Events;

namespace DeskTime.Classes.System
{
    public static class Settings
    {
        private static readonly string _path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "settings.json");

        public static IEventAggregator EA {  get; set; }
        public static SettingsModel SettingsApp { get; set; }

        public static void LoadSettings()
        {
            try
            {
                using(FileStream fs = new FileStream(_path, FileMode.Open))
                {
                    var buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    SettingsApp = JsonConvert.DeserializeObject<SettingsModel>(Encoding.UTF8.GetString(buffer));
                }
            }
            catch (Exception)
            {
                LoadDefaultSettings();
            }
        }

        private static void LoadDefaultSettings()
        {
            SettingsApp = new SettingsModel
            {
                IsAutostart = false,
                Position = null,
                TimeSpeech = true,
                ShowWeather = Visibility.Visible,
                TimeColor = Brushes.White,
                DateColor = Brushes.White,
                WeatherColor = Brushes.White,
                ApiKey = "",
                City = ""
            };
            SaveSettings().GetAwaiter().GetResult();
        }

        public static async Task SaveSettings()
        {
            try
            {

                using (FileStream fs = new FileStream(_path, FileMode.Truncate))
                    await fs.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(SettingsApp)));
            }
            catch (FileNotFoundException)
            {
                using (FileStream fs = new FileStream(_path, FileMode.CreateNew))
                   await fs.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(SettingsApp)));
            }
            catch (IOException) 
            {
            }
        }
    }
}
