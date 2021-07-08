using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewOdometerBetweenDate
    {
        public int? CarId { get; set; }
        public DateTime? OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
        public int OdometerRecordId { get; set; }
    }
}
