using DeskTime.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace DeskTime.Classes.System
{
    public static class Settings
    {

        private static readonly string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static SettingsModel SettingsApp { get; set; }

        public static event Action<object> valueChanged;

        private static bool _isAutostart;
        private static bool _canMove;
        public static bool IsAutostart 
        {
            get => _isAutostart;
            set
            {
                if(_isAutostart != value)
                {
                    _isAutostart = value;
                    valueChanged?.Invoke(_isAutostart);
                }
            } 
        }
        public static bool CanMove 
        {
            get => _canMove;
            set
            {
                if (_canMove != value)
                {
                    _canMove = value;
                    valueChanged?.Invoke(_canMove);
                }
            }
        }

        public static void LoadSettings()
        {
            SettingsApp = new SettingsModel();
            SettingsApp.Position = new PositionModel();
            try
            {
                FileStream fs = new FileStream($"{_path}\\settings.json", FileMode.Open);
                var buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                SettingsApp = JsonConvert.DeserializeObject<SettingsModel>(Encoding.UTF8.GetString(buffer));
            }
            catch (Exception)
            {
                SettingsApp.IsAutostart = false;
                SettingsApp.CanMove = true;
                SettingsApp.PositionCahnged = false;
                SaveSettings();
            }
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
