using System;
using Itenso.TimePeriod;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Detail
{
    public class RechargeBalanceDetailResponse
    {
        public int RechargeId { get; set; }
        public DateTime? RechageDate { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal? RechargeAmount { get; set; }
        public string RechargePaymentMethod { get; set; }
        public string BankName { get; set; }
        public string BankTransactionDate { get; set; }
        public string TransactionPersonName { get; set; }
        public string RechargeDocumentPhoto { get; set; }
        public bool? RechargeRequstConfirmed { get; set; }
    }
}
