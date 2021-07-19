using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.OdometerHistories.Get
{
    public class OdometerHistoryGetResponse
    {
        public int TotalCount { get; set; }
        public List<OdometerHistoryGetResponseItem> Items { get; set; }
    }
    public class OdometerHistoryGetResponseItem
    {
        public Guid Key { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public int CarId { get; set; }
        public string CarIdNumber { get; set; }
        public string CarTypeOfFuel { get; set; }
        public string CarDriverName { get; set; }
        public string OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
    }
}
