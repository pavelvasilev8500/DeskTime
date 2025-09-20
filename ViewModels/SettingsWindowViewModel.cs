using DeskTime.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTime.ViewModels
{
    public class SettingsWindowViewModel : BindableBase
    {

        IEventAggregator _ea;

        public DelegateCommand ApplyCommand {  get; private set; }

        private string _rColor;
        public string RColor
        {
            get { return _rColor; }
            set { SetProperty(ref _rColor, value); }
        }

        private string _title = "New Setting Window";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _color = "Time Color";
        public string Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        public SettingsWindowViewModel(IEventAggregator ea)
        {
            _ea = ea;
            ApplyCommand = new DelegateCommand(Apply);

            //_ea.GetEvent<ObjectEvent>().Subscribe();
        }

        private void Apply()
        {
            _ea.GetEvent<ObjectEvent>().Publish(new object[] { "color", $"#{Color}" });
        }
    }
}
