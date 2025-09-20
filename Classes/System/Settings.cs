using DeskTime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace DeskTime.Classes.System
{
    public static class Settings
    {
        public static event Action<object> valueChanged;
        private static readonly string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

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
        public static bool Position { get; set; }
        public static double Left { get; set; }
        public static double Top { get; set; }
        public static string ApiKey { get; private set; }

        public static void LoadSettings()
        {
            try
            {
                FileStream fs = new FileStream($"{_path}\\settings.json", FileMode.Open);
                var buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                var settings = JsonConvert.DeserializeObject<SettingsModel>(Encoding.UTF8.GetString(buffer));
                IsAutostart = settings.IsAutostart;
                CanMove = settings.CanMove;
                Left = settings.Position.Left;
                Top = settings.Position.Top;
                Position = true;
                ApiKey = settings.ApiKey;
            }
            catch (Exception)
            {
                IsAutostart = false;
                CanMove = true;
                Position = false;
            }
        }

        public static void SaveSettings()
        {
            var settings = new SettingsModel
            {
                IsAutostart = IsAutostart,
                CanMove = CanMove,
                Position = new PositionModel
                {
                    Left = Left,
                    Top = Top,
                },
                ApiKey = ApiKey
            };
            try
            {
                using (FileStream fs = new FileStream($"{_path}\\settings.json", FileMode.Truncate))
                {
                    fs.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(settings)));
                }
            }
            catch (Exception)
            {
                using (FileStream fs = new FileStream($"{_path}\\settings.json", FileMode.CreateNew))
                {
                    fs.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(settings)));
                }
            }
        }
    }
}
