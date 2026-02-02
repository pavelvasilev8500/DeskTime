using DeskTime.Classes.Events;
using DeskTime.Classes.System;
using DeskTime.Models.AppModels.Position;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using WPF.ColorPicker;

namespace DeskTime.Views
{
    public partial class MainWindow : Window
    {
        private Boolean _canMove = false;
        private NotifyIcon _notifyIcon;
        private ToolStripMenuItem _autostart;
        private ToolStripMenuItem _timepspeech;
        private ToolStripMenuItem _weatherUpdate;
        private ToolStripMenuItem _clearPosition;
        private ToolStripMenuItem _timeColor;
        private ToolStripMenuItem _dateColor;
        private ToolStripMenuItem _weatherColor;
        private ToolStripMenuItem _showWeather;
        private readonly string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private double _screenWidth = SystemParameters.PrimaryScreenWidth;
        private double _screenHeight = SystemParameters.PrimaryScreenHeight;

        public MainWindow()
        {
            InitializeComponent();
            //ShowDesktop.AddHook(this);
            //ShowInTaskbar = false;
            SetupTrayIcon();
            Loaded += MainWindow_Loaded;
        }

        private void SetupTrayIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = new Icon($"{_path}\\TimeIco.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.ContextMenuStrip = new ContextMenuStrip();

            _autostart = new ToolStripMenuItem("Add to autostart");
            _timepspeech = new ToolStripMenuItem("Time speech");
            _weatherUpdate = new ToolStripMenuItem("Weather Update");
            _clearPosition = new ToolStripMenuItem("Reset Position");
            _timeColor = new ToolStripMenuItem("Change time color");
            _dateColor = new ToolStripMenuItem("Change date color");
            _weatherColor = new ToolStripMenuItem("Change weather color");


            _autostart.CheckOnClick = true;
            _timepspeech.CheckOnClick = true;
            _autostart.Checked = Settings.SettingsApp.IsAutostart;
            _timepspeech.Checked = Settings.SettingsApp.TimeSpeech;
            _autostart.CheckedChanged += _toolStripMenuItem_CheckedChanged;
            _timepspeech.CheckedChanged += _timepspeech_CheckedChanged;

            _weatherUpdate.Click += _weatherUpdate_Click;
            _clearPosition.Click += _clearPosition_Click;
            _timeColor.Click += _timeColor_Click;
            _dateColor.Click += _dateColor_Click;
            _weatherColor.Click += _weatherColor_Click;

            _notifyIcon.ContextMenuStrip.Items.Add(_autostart);
            _notifyIcon.ContextMenuStrip.Items.Add(_timepspeech);
            _notifyIcon.ContextMenuStrip.Items.Add(_weatherUpdate);
            _notifyIcon.ContextMenuStrip.Items.Add( _clearPosition);
            _notifyIcon.ContextMenuStrip.Items.Add(_timeColor);
            _notifyIcon.ContextMenuStrip.Items.Add(_dateColor);
            _notifyIcon.ContextMenuStrip.Items.Add(_weatherColor);
            _notifyIcon.ContextMenuStrip.Items.Add("Close", Image.FromFile($"{_path}\\Close.png"), (s, e) => CloseApplication());

        }

        private void _weatherColor_Click(object sender, EventArgs e)
        {
            Settings.SettingsApp.WeatherColor = UpdateColor();
            UpdateColorEvent();
        }

        private void _dateColor_Click(object sender, EventArgs e)
        {
            Settings.SettingsApp.DateColor = UpdateColor();
            UpdateColorEvent();
        }
        private void _timeColor_Click(object sender, EventArgs e)
        {
            Settings.SettingsApp.TimeColor = UpdateColor();
            UpdateColorEvent();
        }

        private System.Windows.Media.Brush UpdateColor()
        {
            System.Windows.Media.Color color;
            ColorPickerWindow.ShowDialog(out color);
            System.Windows.Media.BrushConverter cv = new BrushConverter();
            System.Windows.Media.Brush elemntColor = (System.Windows.Media.Brush)cv.ConvertFromString(color.ToString());
            return elemntColor;
        }

        private void UpdateColorEvent()
        {
            if (Settings.EA != null)
                Settings.EA.GetEvent<ColorEvent>().Publish(true);
        }

        private void _clearPosition_Click(object sender, EventArgs e)
        {
            Settings.SettingsApp.Position.Left = Left = (_screenWidth / 2) - (this.Width / 2);
            Settings.SettingsApp.Position.Top = Top = 0;
            _canMove = false;
        }

        private void _weatherUpdate_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Wather Update");
        }

        private void _timepspeech_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SettingsApp.TimeSpeech = !Settings.SettingsApp.TimeSpeech;
        }

        private void _toolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            AutoRun.SetAutorunValue(_autostart.Checked);
            Settings.SettingsApp.IsAutostart = _autostart.Checked;
        }

        private void CloseApplication()
        {
            _notifyIcon.Dispose();
            Settings.SaveSettings().GetAwaiter().GetResult();
            Environment.Exit(0);
            //System.Windows.Application.Current.Shutdown();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(Settings.SettingsApp.Position == null)
            {
                Settings.SettingsApp.Position = new PositionModel();
                Settings.SettingsApp.Position.Left = Left = (_screenWidth / 2) - (this.Width / 2);
                Settings.SettingsApp.Position.Top = Top = 0;
            }
            else
            {
                Left = Settings.SettingsApp.Position.Left;
                Top = Settings.SettingsApp.Position.Top;
            }
        }

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_canMove.Equals(true))
            {
                DragMove();
                Settings.SettingsApp.Position.Left = Left;
                Settings.SettingsApp.Position.Top = Top;
            }
        }

        private void CanMove(object sender, System.Windows.Input.MouseButtonEventArgs e) => _canMove = !_canMove;
    }
}
