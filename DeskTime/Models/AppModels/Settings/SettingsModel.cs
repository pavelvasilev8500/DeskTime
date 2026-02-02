using DeskTime.Models.AppModels.Position;
using System;
using System.Windows;
using System.Windows.Media;

namespace DeskTime.Models.AppModels.Settings
{
    public class SettingsModel
    {
        private Boolean _isAutostart;
        private Boolean _timeSpeech;
        private Visibility _showWeather;
        private Brush _timeColor;
        private Brush _weatherColor;
        private Brush _dateColor;
        private String _apiKey;
        private String _city;
        public Boolean IsAutostart 
        {
            get => _isAutostart; 
            set
            {
                _isAutostart = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
        public PositionModel Position { get; set; }
        public Boolean TimeSpeech 
        { 
            get => _timeSpeech;
            set
            {
                _timeSpeech = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
        public Visibility ShowWeather 
        {
            get => _showWeather;
            set
            {
                _showWeather = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
        public Brush TimeColor 
        {
            get => _timeColor; 
            set
            {
                _timeColor = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
        public Brush DateColor 
        {
            get => _dateColor;
            set
            {
                _dateColor = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
        public Brush WeatherColor 
        {
            get => _weatherColor;
            set
            {
                _weatherColor = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
        public String ApiKey 
        {
            get => _apiKey; 
            set
            {
                _apiKey = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
        public String City 
        {
            get => _city; 
            set
            {
                _city = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
    }
}
