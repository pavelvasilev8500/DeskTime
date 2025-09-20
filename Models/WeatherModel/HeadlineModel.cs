namespace Infinity.Models.WeatherModel
{
    public class HeadlineModel
    {
        public string EffectiveDate { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text {  get; set; }
        public string Category { get; set; }
        public string EndDate { get; set; }
        public int EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}