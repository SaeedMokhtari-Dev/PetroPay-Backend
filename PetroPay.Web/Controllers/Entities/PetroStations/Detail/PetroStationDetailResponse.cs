namespace PetroPay.Web.Controllers.Entities.PetroStations.Detail
{
    public class PetroStationDetailResponse
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string StationAddress { get; set; }
        public string StationLucationName { get; set; }
        public string StationOwnerName { get; set; }
        public string StationPhone { get; set; }
        public string StationBanckAccount { get; set; }
        public double? StationLatitude { get; set; }
        public double? StationLongitude { get; set; }
        public string StationUserName { get; set; }
        public string StationPassword { get; set; }
        public string StationNameAr { get; set; }
        public bool? StationDiesel { get; set; }
        public decimal? StationBalance { get; set; }
        public string StationEmail { get; set; }
    }
}
