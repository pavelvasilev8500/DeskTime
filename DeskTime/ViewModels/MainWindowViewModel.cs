using DeskTime.Classes.Data;
using DeskTime.Classes.Database;
using DeskTime.Classes.Events;
using DeskTime.Classes.System;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Globalization;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace DeskTime.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IEventAggregator _ea;
        private SpeechSynthesizer _speechSynthesizer = new SpeechSynthesizer();
        private PromptBuilder _promptBuilder = new PromptBuilder();

        private Brush _timeColor = Settings.SettingsApp.TimeColor;
        private Brush _dateColor = Settings.SettingsApp.DateColor;
        private Brush _weatherColor = Settings.SettingsApp.WeatherColor;
        private Visibility _weatherVisibility = Visibility.Visible;

        private string _time;
        private string _date;
        private string _weatherText;
        private string _realFeelWeatherText;
        private bool _sayTime = true;

        public Brush TimeColor
        {
            get { return _timeColor; }
            set { SetProperty(ref _timeColor, value); }
        }
        public Brush WeatherColor
        {
            get { return _weatherColor; }
            set { SetProperty(ref _weatherColor, value); }
        }
        public Brush DateColor
        {
            get => _dateColor;
            set => SetProperty(ref _dateColor, value);
        }
        public Visibility WeatherVisibility
        {
            get => _weatherVisibility;
            set => SetProperty(ref _weatherVisibility, value);
        }
        public string Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }
        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        public string WeatherText
        {
            get =>_weatherText;
            set => SetProperty(ref _weatherText, value);
        }
        public string RealFeelWeatherText
        {
            get => _realFeelWeatherText;
            set => SetProperty(ref _realFeelWeatherText, value);
        }
        public bool SayTime
        {
            get => _sayTime;
            set => SetProperty(ref _sayTime, value);
        }

        public MainWindowViewModel(IEventAggregator ea)
        {
            _ea = ea;
            Settings.EA = ea;
            ea.GetEvent<ColorEvent>().Subscribe(GetColor);
            GetWeather();
            _speechSynthesizer.Volume = 100;
            var dateTimeThread = new Thread(() =>
            {
                while (true)
                {
                    var dt = DateTime.Now;
                    Time = dt.ToShortTimeString();
                    Date = dt.ToString("dddd, d MMMM");
                    if (dt.Minute == 0 && dt.Second == 0)
                    {
                        var weather = DbManager.GetDb(dt.ToString("yyyy-MM-dd HH:mm"));
                        if (weather == null)
                            GetWeather();
                        else
                            ShowWeather(weather.Temperature.ToString(), weather.RealFeealTemperature.ToString());
                    }
                    if(_sayTime)
                    {
                        if (dt.Minute == 0 && dt.Second == 0)
                        {
                            SayHour(dt.Hour);
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
            dateTimeThread.Name = "UpdateThread";
            dateTimeThread.Start();
        }

        private void GetColor(Boolean update)
        {
            if (update.Equals(true))
                UpdateColor();
        }

        private void UpdateColor()
        {
            TimeColor = Settings.SettingsApp.TimeColor;
            DateColor = Settings.SettingsApp.DateColor;
            WeatherColor = Settings.SettingsApp.WeatherColor;
        }

        private void SayHour(int hour)
        {
            try
            {
                _promptBuilder.StartVoice(new CultureInfo("ru-RU"));
                if (hour == 1 || hour == 21)
                {
                    _promptBuilder.AppendText($"{hour} час");
                }
                else if (hour >= 2 && hour <= 4 || hour >= 22 && hour <= 23)
                {
                    _promptBuilder.AppendText($"{hour} часа");
                }
                else if (hour >= 5 && hour <= 20 || hour == 0)
                {
                    _promptBuilder.AppendText($"{hour} часов");
                }
                _promptBuilder.EndVoice();
                _speechSynthesizer.Speak(_promptBuilder);
                _promptBuilder.ClearContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ShowWeather(string temp, string realf_temp)
        {
            WeatherText = $"{Settings.SettingsApp.City}, {temp}°С";
            RealFeelWeatherText = $"Ощущается как: {realf_temp}°С";
        }

        private async void GetWeather()
        {
            var weather = await Weather.GetForecast(Settings.SettingsApp.City, "", Settings.SettingsApp.ApiKey);
            if(weather.Item1 == "")
            {
                var dt = DateTime.Now;
                var dbWeather = DbManager.GetDb(dt.ToString("yyyy-MM-dd HH:00"));
                if (dbWeather == null)
                    WeatherVisibility = Visibility.Hidden;
                else
                {
                    WeatherVisibility = Visibility.Visible;
                    ShowWeather(dbWeather.Temperature.ToString(), dbWeather.RealFeealTemperature.ToString());
                }
            }
            else
            {
                WeatherVisibility = Visibility.Visible;
                ShowWeather(weather.Item1, weather.Item2);
            }
        }
    }
}