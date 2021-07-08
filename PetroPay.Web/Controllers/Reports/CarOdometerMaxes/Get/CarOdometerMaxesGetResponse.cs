using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CarOdometerMaxes.Get
{
    public class CarOdometerMaxGetResponse
    {
        public int TotalCount { get; set; }
        public List<CarOdometerMaxGetResponseItem> Items { get; set; }
    }
    public class CarOdometerMaxGetResponseItem
    {
        public Guid Key { get; set; }
        public int? CarId { get; set; }
        public string CarIdNumber { get; set; }
        public DateTime? OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
    }
}
