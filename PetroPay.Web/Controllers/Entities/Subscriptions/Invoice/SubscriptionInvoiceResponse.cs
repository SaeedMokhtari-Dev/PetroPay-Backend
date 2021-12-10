using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Invoice
{
    public class SubscriptionInvoiceResponse
    {
        public double InvoiceNumber { get; set; }
        public string DateOfIssue { get; set; }
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
        public string ServiceDescription { get; set; }
        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string ServiceStartDate { get; set; }
        public string ServiceEndDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Tax { get; set; }
        public decimal VatRate { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }
    }
}
