using DeskTime.Classes.System;
using DeskTime.Views;
using Prism.Ioc;
using System.Windows;

namespace DeskTime
{
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
