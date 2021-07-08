using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CarOdometerMins.Get
{
    public class CarOdometerMinGetResponse
    {
        public int TotalCount { get; set; }
        public List<CarOdometerMinGetResponseItem> Items { get; set; }
    }
    public class CarOdometerMinGetResponseItem
    {
        public Guid Key { get; set; }
        public int? CarId { get; set; }
        public string CarIdNumber { get; set; }
        public DateTime? OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
    }
}
