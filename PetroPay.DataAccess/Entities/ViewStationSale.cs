#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewStationSale
    {
        public int StationWorkerId { get; set; }
        public string StationWorkerFname { get; set; }
        public double? SumInvoiceAmount { get; set; }
        public double? SumInvoiceFuelConsumptionLiter { get; set; }
        public string InvoiceFuelType { get; set; }
        public string SumInvoiceDataTime { get; set; }
        public int? StationId { get; set; }
        public int? SumInvoiceBonusPoints { get; set; }
    }
}
