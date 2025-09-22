namespace DeskTime.Models
{
    public class SettingsModel
    {
        public bool IsAutostart { get; set; }
        public bool CanMove { get; set; }
        public bool PositionCahnged { get; set; } = false;
        public PositionModel Position { get; set; }
        public string TimeColor { get; set; }
        public string DateColor { get; set; }
        public string WeatherColor { get; set; }
        public string ApiKey { get; set; }
        public string City { get; set; }
    }
}
