using System;
using System.Collections.Generic;

#nullable disable

namespace TestScaffold.Models
{
    public partial class ViewOdometerBetweenDateTemp
    {
        public int? CarId { get; set; }
        public DateTime? OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
        public int? OdometerRecordId { get; set; }
    }
}
