namespace Infinity.Models
{
    public class DetailsModel
    {
        public string Key { get; set; }
        public string StationCode { get; set; }
        public float StationGmtOffset { get; set; }
        public string BandMap { get; set; }
        public string Climo { get; set; }
        public string LocalRadar { get; set; }
        public string MediaRegion { get; set; }
        public string Metar { get; set; }
        public string NXMetro { get; set; }
        public string NXState { get; set; }
        public float Population { get; set; }
        public string PrimaryWarningCountyCode { get; set; }
        public string PrimaryWarningZoneCode { get; set; }
        public string Satellite { get; set; }
        public string Synoptic { get; set; }
        public string MarineStation { get; set; }
        public string MarineStationGMTOffset { get; set; }
        public string VideoCode { get; set; }
        public float PartnerID { get; set; }
        public DMAModel DMA { get; set; }
        public SourcesModel Sources { get; set; }
        public string CanonicalPostalCode { get; set; }
        public string CanonicalLocationKey { get; set; }
        public string LocationStem { get; set; }

    }
}