using System.Collections.Generic;

namespace Infinity.Models
{
    internal class SearchModel
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public RegionModel Region { get; set; }
        public CountryModel Country { get; set; }
        public AdministrativeAreaModel AdministrativeArea { get; set; }
        public TimeZoneModel TimeZone { get; set; }
        public GeoPositionModel GeoPosition { get; set; }
        public bool IsAlias { get; set; }
        public string ParentCityStr { get; set; }
        public ParentCityModel ParentCity { get; set; }
        public List<SupplementalAdminAreasModel> SupplementalAdminAreas { get; set; }
        public List<string> DataSets { get; set; }
        public DetailsModel Details { get; set; }
    }
}
