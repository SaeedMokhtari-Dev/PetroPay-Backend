using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.CarConsumptionRates.Get
{
    public class CarConsumptionRateGetResponse
    {
        public int TotalCount { get; set; }
        public List<CarConsumptionRateGetResponseItem> Items { get; set; }
    }
    public class CarConsumptionRateGetResponseItem
    {
        public Guid Key { get; set; }
        public int? CompanyId { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public int? CarId { get; set; }
        public string CarIdNumber { get; set; }
        public string CarDriverName { get; set; }
        public DateTime? DateMin { get; set; }
        public DateTime? DateMax { get; set; }
        public double? LiterConsumption { get; set; }
        public double? AmountConsumption { get; set; }
        public double? KmConsumption { get; set; }
        public double? CunsumptionRate { get; set; }
    }
}
