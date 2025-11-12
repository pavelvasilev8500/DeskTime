using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeskTime.Models
{
    public class PositionModel : INotifyPropertyChanged
    {
        private double _left;
        public double Left 
        { 
            get => _left; 
            set
            {
                if (_left != value)
                {
                    _left = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _top;
        public double Top 
        {
            get => _top;
            set
            {
                if (_top != value)
                {
                    _top = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
