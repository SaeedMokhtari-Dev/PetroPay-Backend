using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CustomerStatements.Get
{
    public class CustomerStatementGetResponse
    {
        public int TotalCount { get; set; }
        
        public decimal SumCustomerStatement { get; set; }
        public List<CustomerStatementGetResponseItem> Items { get; set; }
    }
    public class CustomerStatementGetResponseItem
    {
        public Guid Key { get; set; }
        public string TransactionDataTime { get; set; }
        public int? AccountId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string TransDocument { get; set; }
        public decimal? SumTransAmount { get; set; }
        public string AccountName { get; set; }
    }
}
