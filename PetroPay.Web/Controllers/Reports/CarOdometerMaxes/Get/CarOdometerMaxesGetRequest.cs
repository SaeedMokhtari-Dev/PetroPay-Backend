using System;

namespace PetroPay.Web.Controllers.Reports.CarOdometerMaxes.Get
{
    public class CarOdometerMaxGetRequest
    {
        public int? CarId { get; set; }
        /*public string CarIdNumber { get; set; }*/
        /*public int? CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }*/
        /*public string TransDateFrom { get; set; }
        public string TransDateTo { get; set; }*/
        /*public int? CompanyId { get; set; }*/
        /*public string CompanyName { get; set; }*/   
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
