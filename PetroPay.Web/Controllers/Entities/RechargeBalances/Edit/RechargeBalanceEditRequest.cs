using System;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Edit
{
    public class RechargeBalanceEditRequest
    {
        public int RechargeId { get; set; }
        public decimal? RechargeAmount { get; set; }
        public string RechargePaymentMethod { get; set; }
        public string BankName { get; set; }
        public string BankTransactionDate { get; set; }
        public string TransactionPersonName { get; set; }
        public string RechargeDocumentPhoto { get; set; }
    }
}
