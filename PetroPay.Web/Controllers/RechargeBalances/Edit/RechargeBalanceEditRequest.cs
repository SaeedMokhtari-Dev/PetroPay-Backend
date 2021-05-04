using System;

namespace PetroPay.Web.Controllers.RechargeBalances.Edit
{
    public class RechargeBalanceEditRequest
    {
        public int RechargeId { get; set; }
        public DateTime? RechageDate { get; set; }
        public decimal? RechargeAmount { get; set; }
        public string RechargePaymentMethod { get; set; }
        public string BankName { get; set; }
        public DateTime? BankTransactionDate { get; set; }
        public string TransactionPersonName { get; set; }
        public string RechargeDocumentPhoto { get; set; }
    }
}
