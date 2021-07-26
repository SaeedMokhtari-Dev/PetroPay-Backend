using System;

namespace PetroPay.Web.Controllers.Reports.CustomerStatements.Get
{
    public class CustomerStatementGetRequest
    {
        public bool ExportToFile { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }   
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
