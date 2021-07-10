using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Get
{
    public class OdometerRecordGetResponse
    {
        public int TotalCount { get; set; }
        public List<OdometerRecordGetResponseItem> Items { get; set; }
    }
    public class OdometerRecordGetResponseItem
    {
        public int Key { get; set; }
        public int OdometerRecordId { get; set; }
        public int? CarId { get; set; }
        public string CarIdNumber { get; set; }
        public string OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
    }
}
