using System;

namespace PetroPay.Web.Controllers.RechargeBalances.Add
{
    public class RechargeBalanceAddRequest
    {
        
        public DateTime? RechageDate { get; set; }
        public int? CompanyId { get; set; }
        public decimal? RechargeAmount { get; set; }
        public string RechargePaymentMethod { get; set; }
        public string BankName { get; set; }
        public DateTime? BankTransactionDate { get; set; }
        public string TransactionPersonName { get; set; }
        public string RechargeDocumentPhoto { get; set; }
        public bool? RechargeRequstConfirmed { get; set; }
    }
}
