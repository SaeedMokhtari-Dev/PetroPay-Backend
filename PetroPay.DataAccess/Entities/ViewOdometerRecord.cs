using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewOdometerRecord
    {
        public int OdometerRecordId { get; set; }
        public int? CarId { get; set; }
        public DateTime? OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public long? Seqnum { get; set; }
        public string CarIdNumber { get; set; }
        public string CompanyBranchName { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
    }
}
