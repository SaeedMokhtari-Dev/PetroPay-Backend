using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewInvoicesSummary
    {
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public DateTime? InvoiceDataTime { get; set; }
        public int InvoiceId { get; set; }
        public string ServiceEnDescription { get; set; }
        public string ServiceArDescription { get; set; }
        public string CarIdNumber { get; set; }
        public double? InvoiceFuelConsumptionLiter { get; set; }
        public double? InvoiceAmount { get; set; }
        public string PaymentMethodName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CarId { get; set; }
    }
}
