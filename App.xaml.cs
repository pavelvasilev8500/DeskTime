using DeskTime.Classes.System;
using DeskTime.Views;
using Prism.Ioc;
using System;
using System.Windows;

namespace DeskTime
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            Settings.LoadSettings();
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
