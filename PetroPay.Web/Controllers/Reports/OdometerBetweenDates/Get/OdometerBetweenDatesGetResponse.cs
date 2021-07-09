using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.OdometerBetweenDates.Get
{
    public class OdometerBetweenDateGetResponse
    {
        public int TotalCount { get; set; }
        public List<OdometerBetweenDateGetResponseItem> Items { get; set; }
    }
    public class OdometerBetweenDateGetResponseItem
    {
        public Guid Key { get; set; }
        public int? CarId { get; set; }
        public string CarIdNumber { get; set; }
        public DateTime? OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
        public int OdometerRecordId { get; set; }
    }
}
