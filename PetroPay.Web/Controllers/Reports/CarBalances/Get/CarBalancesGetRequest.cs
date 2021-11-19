using System;

namespace PetroPay.Web.Controllers.Reports.CarBalances.Get
{
    public class CarBalanceGetRequest
    {
        public bool ExportToFile { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? CompanyBranchId { get; set; }   
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
