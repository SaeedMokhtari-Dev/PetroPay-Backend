using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewInvoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyNameEn { get; set; }
        public string CompanyNameAr { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTaxRecordNumber { get; set; }
        public string CompanyCommercialRecordNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTaxNumber { get; set; }
        public string UnitCost { get; set; }
        public int? Quantity { get; set; }
        public string Amount { get; set; }
        public DateTime? ServiceStartDate { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public string SubTotal { get; set; }
        public string Discount { get; set; }
        public string TaxRate { get; set; }
        public string Tax { get; set; }
        public string VatRate { get; set; }
        public string Vat { get; set; }
        public string Total { get; set; }
    }
}
