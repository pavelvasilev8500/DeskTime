using DeskTime.Classes.Data;
using DeskTime.Classes.Database;
using DeskTime.Classes.System;
using DeskTime.Events;
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
        IEventAggregator _ea;

        const string cityReq = "Гомель";

        private SpeechSynthesizer _speechSynthesizer = new SpeechSynthesizer();
        private PromptBuilder _promptBuilder = new PromptBuilder();

        private Brush _timeColor = Brushes.White;
        private Brush _dateColor = Brushes.White;
        private Brush _weatherColor = Brushes.White;
        private Visibility _visibility = Visibility.Visible;

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
        public Visibility Visibility
        {
            get => _visibility;
            set => SetProperty(ref _visibility, value);
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
            _ea.GetEvent<ObjectEvent>().Subscribe(ChangeSettings);
            TimeColor = new BrushConverter().ConvertFromString($"{Settings.SettingsApp.TimeColor.ToString()}") as Brush;
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
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            var weather = DbManager.GetDb(dt.ToString("yyyy-MM-dd HH:mm"));
                            if (weather == null)
                                GetWeather();
                            else
                                ShowWeather(weather.Temperature.ToString(), weather.RealFeealTemperature.ToString());
                        }
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

        private void ChangeSettings(object obj)
        {

            TimeColor = new BrushConverter().ConvertFromString($"{Settings.SettingsApp.TimeColor.ToString()}") as Brush;
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
            catch (Exception ex)
            {}
        }

        private void ShowWeather(string temp, string realf_temp)
        {
            WeatherText = $"{cityReq}, {temp}°С";
            RealFeelWeatherText = $"Ощущается как: {realf_temp}°С";
        }

        private async void GetWeather()
        {
            var weather = await Weather.GetForecast("Gomel", "", "e454373f51804440af5205401251809");
            ShowWeather(weather.Item1, weather.Item2);
        }
    }
}