using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Get
{
    public class RechargeBalanceGetResponse
    {
        public int TotalCount { get; set; }
        public List<RechargeBalanceGetResponseItem> Items { get; set; }
    }
    public class RechargeBalanceGetResponseItem
    {
        public int Key { get; set; }
        public int RechargeId { get; set; }
        public string RechageDate { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal? RechargeAmount { get; set; }
        public string RechargePaymentMethod { get; set; }
        public string BankName { get; set; }
        public string BankTransactionDate { get; set; }
        public string TransactionPersonName { get; set; }
        /*public string RechargeDocumentPhoto { get; set; }*/
        public bool? RechargeRequstConfirmed { get; set; }
    }
}
