using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CarTransactions.Get
{
    public class CarTransactionGetResponse
    {
        public int TotalCount { get; set; }
        
        public decimal SumCarTransaction { get; set; }
        public List<CarTransactionGetResponseItem> Items { get; set; }
    }
    public class CarTransactionGetResponseItem
    {
        public int Key { get; set; }
        public int TransId { get; set; }
        public DateTime? TransDate { get; set; }
        public int? AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountTaype { get; set; }
        public string TransDocument { get; set; }
        public decimal? TransAmount { get; set; }
    }
}
