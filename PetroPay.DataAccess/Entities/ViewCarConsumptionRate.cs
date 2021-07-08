using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewCarConsumptionRate
    {
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
