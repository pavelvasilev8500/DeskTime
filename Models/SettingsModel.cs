using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace DeskTime.Models
{
    public class SettingsModel : INotifyPropertyChanged
    {
        private bool _isAutostart;
        public bool IsAutostart
        {
            get => _isAutostart;
            set
            {
                if (_isAutostart != value)
                {
                    _isAutostart = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _canMove;
        public bool CanMove 
        {
            get => _canMove; 
            set
            {
                if (_canMove != value)
                {
                    _canMove = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _positionChanged;
        public bool PositionCahnged 
        {
            get => _positionChanged; 
            set
            {
                if (_positionChanged != value)
                {
                    _positionChanged = value;
                    OnPropertyChanged();
                }
            }
        }

        private PositionModel _position;
        public PositionModel Position 
        {
            get => _position;
            set
            {
                if(_position != value)
                {
                    if (_position != null)
                        _position.PropertyChanged -= PositionChanged;
                    _position = value;
                    if(_position != null)
                        _position.PropertyChanged += PositionChanged;
                    OnPropertyChanged();
                }
            }
        }

        private Brush _timeColor;
        public Brush TimeColor 
        {
            get => _timeColor; 
            set
            {
                if (_timeColor != value)
                {
                    _timeColor = value;
                    OnPropertyChanged();
                }
            }
        }

        private Brush _dateColor;
        public Brush DateColor 
        { 
            get => _dateColor; 
            set
            {
                if (_dateColor != value)
                {
                    _dateColor = value;
                    OnPropertyChanged();
                }
            }
        }

        private Brush _weatherColor;
        public Brush WeatherColor 
        {
            get => _weatherColor; 
            set
            {
                if (_weatherColor != value)
                {
                    _weatherColor = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _apiKey;
        public string ApiKey 
        {
            get => _apiKey; 
            set
            {
                if (_apiKey != value)
                {
                    _apiKey = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _city;
        public string City 
        {
            get => _city; 
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        private void PositionChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Position) + "." + e.PropertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
