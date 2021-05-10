using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CarBalances.Get
{
    public class CarBalanceGetResponse
    {
        public int TotalCount { get; set; }
        
        public decimal SumCarBalance { get; set; }
        public List<CarBalanceGetResponseItem> Items { get; set; }
    }
    public class CarBalanceGetResponseItem
    {
        public int Key { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public string CarIdNumber { get; set; }
        public string CarDriverName { get; set; }
        public decimal? ConsumptionValue { get; set; }
        public decimal? CarBalnce { get; set; }
        public int CarId { get; set; }
        public string SubscriptionStartDate { get; set; }
        public string SubscriptionEndDate { get; set; }
    }
}
