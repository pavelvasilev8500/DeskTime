using System;

namespace Infinity.Models
{
    public class TimeZoneModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float GmtOffset { get; set; }
        public string IsDaylightSaving { get; set; }
        public object NextOffsetChange { get; set; }

    }
}