using Newtonsoft.Json;
using Resources.Classes.Models.DeskTimeApp.Position;
using Resources.Classes.Models.DeskTimeApp.Settings;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Media;

namespace DeskTime.Classes.System
{
    public static class Settings
    {
        private static readonly string _path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "settings.json");
        public static SettingsModel SettingsApp { get; set; }

        public static void LoadSettings()
        {
            try
            {
                FileStream fs = new FileStream(_path, FileMode.Open);
                var buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                SettingsApp = JsonConvert.DeserializeObject<SettingsModel>(Encoding.UTF8.GetString(buffer));
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
                CanMove = false,
                PositionCahnged = false,
                Position = new PositionModel(),
                TimeColor = Brushes.White,
                DateColor = Brushes.White,
                WeatherColor = Brushes.White,
                ApiKey = "",
                City = ""
            };
        }

        public static void SaveSettings()
        {
            try
            {
                using (FileStream fs = new FileStream($"{_path}\\settings.json", FileMode.Truncate))
                {
                    fs.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(SettingsApp)));
                }
            }
            catch (Exception)
            {
                using (FileStream fs = new FileStream($"{_path}\\settings.json", FileMode.CreateNew))
                {
                    fs.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(SettingsApp)));
                }
            }
        }
    }
}
