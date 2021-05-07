using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime? InvoiceDataTime { get; set; }
        /// <summary>
        /// cash&amp;customer balnce
        /// </summary>
        public string InvoicePayType { get; set; }
        public string InvoicePayStatus { get; set; }
        /// <summary>
        /// 90&amp;92&amp;kirosin
        /// </summary>
        public string InvoiceFuelType { get; set; }
        public double? InvoiceFuelConsumptionLiter { get; set; }
        public decimal? InvoiceFuelLterPrice { get; set; }
        public double? InvoiceAmount { get; set; }
        public string InvoiceConfirmedCode { get; set; }
        public int? CarId { get; set; }
        public int? StationUserId { get; set; }
        public int? StationId { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
        public string InvoicePumpPhoto { get; set; }
        public string InvoicePlatePhoto { get; set; }
        public int? InvoicePayTypeId { get; set; }
        public string InvoiceNot { get; set; }
        public int? ServiceId { get; set; }
        public double? InvoiceCarOdometer { get; set; }

        public virtual Car Car { get; set; }
        public virtual PaymentMethod InvoicePayTypeNavigation { get; set; }
        public virtual ServiceMaster Service { get; set; }
        public virtual PetroStation Station { get; set; }
        public virtual StationUser StationUser { get; set; }
    }
}
