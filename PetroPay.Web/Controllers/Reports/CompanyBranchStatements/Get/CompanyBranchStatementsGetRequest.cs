using System;

namespace PetroPay.Web.Controllers.Reports.CompanyBranchStatements.Get
{
    public class CompanyBranchStatementGetRequest
    {
        public bool ExportToFile { get; set; }
        public int? CompanyId { get; set; }   
        public int? BranchId { get; set; }   
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
