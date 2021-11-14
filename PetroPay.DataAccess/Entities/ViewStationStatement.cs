#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewStationStatement
    {
        public string InvoiceDataTime { get; set; }
        public int? AccountId { get; set; }
        public string StationName { get; set; }
        public string TransDocument { get; set; }
        public decimal? SumTransAmount { get; set; }
        public string AccountName { get; set; }
        public int StationId { get; set; }
        public string TransReference { get; set; }
    }
}
