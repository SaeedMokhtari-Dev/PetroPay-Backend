using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewStationReport
    {
        public int StationWorkerId { get; set; }
        public string StationWorkerFname { get; set; }
        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceArDescription { get; set; }
        public string CarIdNumber { get; set; }
        public double? InvoiceAmount { get; set; }
        public string PaymentMethodName { get; set; }
        public DateTime? InvoiceDataTime { get; set; }
    }
}
