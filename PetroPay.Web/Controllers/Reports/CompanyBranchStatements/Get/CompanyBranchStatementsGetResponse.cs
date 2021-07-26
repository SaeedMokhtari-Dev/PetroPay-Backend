using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CompanyBranchStatements.Get
{
    public class CompanyBranchStatementGetResponse
    {
        public int TotalCount { get; set; }
        
        public decimal SumCompanyBranchStatement { get; set; }
        public List<CompanyBranchStatementGetResponseItem> Items { get; set; }
    }
    public class CompanyBranchStatementGetResponseItem
    {
        public Guid Key { get; set; }
        public string TransactionDateTime { get; set; }
        public int? AccountId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public decimal? SumTransAmount { get; set; }
        public string TransDocument { get; set; }
    }
}
