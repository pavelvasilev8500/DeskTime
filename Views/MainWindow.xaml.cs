using DeskTime.Classes.System;
using Prism.Events;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace DeskTime.Views
{
    public partial class MainWindow : Window
    {
        IEventAggregator _ea;
        private NotifyIcon _notifyIcon;
        private ToolStripMenuItem _toolStripMenuItem;
        private readonly string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private double _screenWidth = SystemParameters.PrimaryScreenWidth;
        private double _screenHeight = SystemParameters.PrimaryScreenHeight;
        private bool _canMove { get; set; }
        public MainWindow(IEventAggregator ea)
        {
            InitializeComponent();
            Settings.valueChanged += Settings_valueChanged;
            _ea = ea;
            _canMove = Settings.CanMove;
            ShowDesktop.AddHook(this);
            ShowInTaskbar = false;
            SetupTrayIcon();
            Loaded += MainWindow_Loaded;
        }

        private void Settings_valueChanged(object obj)
        {
            Settings.SaveSettings();
        }

        private void SetupTrayIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = new Icon($"{_path}\\TimeIco.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItem = new ToolStripMenuItem("Add to autostart");
            _toolStripMenuItem.CheckOnClick = true;
            _toolStripMenuItem.Checked = Settings.SettingsApp.IsAutostart;
            _toolStripMenuItem.CheckedChanged += _toolStripMenuItem_CheckedChanged;
            _notifyIcon.ContextMenuStrip.Items.Add("Close", Image.FromFile($"{_path}\\Close.png"), (s, e) => CloseApplication());
            _notifyIcon.ContextMenuStrip.Items.Add("Seetings", null, (s, e) =>
            {
                var mw = new SettingsWindow();
                mw.Show();
            });
            _notifyIcon.ContextMenuStrip.Items.Add(_toolStripMenuItem);

        }

        private void _toolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            AutoRun.SetAutorunValue(_toolStripMenuItem.Checked);
            Settings.IsAutostart = _toolStripMenuItem.Checked;
        }

        private void CloseApplication()
        {
            _notifyIcon.Dispose();
            Settings.SaveSettings();
            var a = Settings.CanMove;
            Environment.Exit(0);
            //System.Windows.Application.Current.Shutdown();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.SettingsApp.PositionCahnged == true)
            {
                Left = Settings.SettingsApp.Position.Left;
                Top = Settings.SettingsApp.Position.Top;
            }
            else
            {
                double windowWidth = this.Width;
                double windowHeight = this.Height;
                Settings.SettingsApp.Position.Left = Left = (_screenWidth / 2) - (windowWidth / 2);
                Settings.SettingsApp.Position.Top = Top = _screenHeight - 5 * (_screenHeight / 6);
            }
        }

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_canMove)
            {
                DragMove();
                Settings.SettingsApp.Position.Left = Left;
                Settings.SettingsApp.Position.Top = Top;
                Settings.SaveSettings();
            }
        }

        private void CanMove(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _canMove = _canMove == true ? false : true;
            Settings.CanMove = _canMove;
        }
    }
}
