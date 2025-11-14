using Resources.Classes.Models.DeskTimeApp.Position;
using System.Windows.Media;

namespace Resources.Classes.Models.DeskTimeApp.Settings
{
    public class SettingsModel
    {
        public bool IsAutostart { get; set; }
        public bool CanMove { get; set; }
        public bool PositionCahnged { get; set; }
        public PositionModel Position { get; set; }
        public Brush TimeColor { get; set; }
        public Brush DateColor { get; set; }
        public Brush WeatherColor { get; set; }
        public string ApiKey { get; set; }
        public string City { get; set; }

    }
}

//Hello
