using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewInvoiceDetail
    {
        public int InvoiceId { get; set; }
        public DateTime? InvoiceDataTime { get; set; }
        public string InvoicePayType { get; set; }
        public string InvoicePayStatus { get; set; }
        public string ServiceEnDescription { get; set; }
        public string ServiceArDescription { get; set; }
        public string StationName { get; set; }
        public string StationNameAr { get; set; }
        public string InvoicePumpPhoto { get; set; }
        public string InvoicePlatePhoto { get; set; }
        public double? StationLatitude { get; set; }
        public double? StationLongitude { get; set; }
    }
}
