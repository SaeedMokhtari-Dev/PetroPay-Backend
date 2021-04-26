using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class RechargeBalance
    {
        public int RechargeId { get; set; }
        public DateTime? RechageDate { get; set; }
        public int? CompanyId { get; set; }
        public decimal? RechargeAmount { get; set; }
        public string RechargePaymentMethod { get; set; }
        public string BankName { get; set; }
        public DateTime? BankTransactionDate { get; set; }
        public string TransactionPersonName { get; set; }
        public string RechargeDocumentPhoto { get; set; }
        public bool? RechargeRequstConfirmed { get; set; }

        public virtual Company Company { get; set; }
    }
}
