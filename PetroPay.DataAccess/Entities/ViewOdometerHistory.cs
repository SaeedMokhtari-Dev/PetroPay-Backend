using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewOdometerHistory
    {
        public int CompanyId { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyBranchName { get; set; }
        public int CarId { get; set; }
        public string CarIdNumber { get; set; }
        public string CarTypeOfFuel { get; set; }
        public string CarDriverName { get; set; }
        public DateTime? OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
    }
}
