#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewStationBalance
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string StationLucationName { get; set; }
        public string StationAddress { get; set; }
        public string StationOwnerName { get; set; }
        public string StationBanckAccount { get; set; }
        public decimal? StationBalance { get; set; }
    }
}
