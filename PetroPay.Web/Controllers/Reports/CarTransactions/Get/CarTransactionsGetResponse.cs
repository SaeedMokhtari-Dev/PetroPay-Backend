using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CarTransactions.Get
{
    public class CarTransactionGetResponse
    {
        public int TotalCount { get; set; }
        public List<CarTransactionGetResponseItem> Items { get; set; }
    }
    public class CarTransactionGetResponseItem
    {
        public string Key { get; set; }
        public int CarId { get; set; }
        public string CarIdNumber { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int TransId { get; set; }
        public DateTime? TransDate { get; set; }
        public string TransDocument { get; set; }
        public decimal? TransAmount { get; set; }
        public string TransReference { get; set; }
    }
}
