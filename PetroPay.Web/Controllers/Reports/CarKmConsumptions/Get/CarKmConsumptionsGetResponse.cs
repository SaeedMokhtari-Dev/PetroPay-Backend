using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CarKmConsumptions.Get
{
    public class CarKmConsumptionGetResponse
    {
        public int TotalCount { get; set; }
        public List<CarKmConsumptionGetResponseItem> Items { get; set; }
    }
    public class CarKmConsumptionGetResponseItem
    {
        public Guid Key { get; set; }
        public int? CarId { get; set; }
        public string CarIdNumber { get; set; }
        public DateTime? DateMin { get; set; }
        public double? OdometerValueMin { get; set; }
        public DateTime? DateMax { get; set; }
        public double? OdometerValueMax { get; set; }
        public double? CarOdometerConsumption { get; set; }
    }
}
