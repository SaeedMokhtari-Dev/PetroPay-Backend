using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class OdometerRecord
    {
        public int OdometerRecordId { get; set; }
        public int? CarId { get; set; }
        public DateTime? OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }

        public virtual Car Car { get; set; }
    }
}
