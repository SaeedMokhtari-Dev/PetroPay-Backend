using System;

namespace PetroPay.Web.Controllers.Reports.CarConsumptionRates.Get
{
    public class CarConsumptionRateGetRequest
    {
        public string CarIdNumber { get; set; }
        public int? CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int? CompanyId { get; set; }
        /*public string CompanyName { get; set; }*/   
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
