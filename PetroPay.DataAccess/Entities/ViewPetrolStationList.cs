#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewPetrolStationList
    {
        public string StationLucationName { get; set; }
        public string StationName { get; set; }
        public string StationNameAr { get; set; }
        public bool? StationDiesel { get; set; }
        public double? StationLatitude { get; set; }
        public double? StationLongitude { get; set; }
    }
}
