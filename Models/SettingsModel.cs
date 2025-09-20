using System.Collections.Generic;
using System.Security.Policy;

namespace DeskTime.Models
{
    public class SettingsModel
    {
        public bool IsAutostart { get; set; }
        public bool CanMove { get; set; }
        public PositionModel Position { get; set; }
        public string TimeColor { get; set; }
        public string DateColor { get; set; }
        public string WeatherColor { get; set; }
        public string ApiKey { get; set; }
    }
}
