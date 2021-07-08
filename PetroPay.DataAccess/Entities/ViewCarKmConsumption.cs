using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewCarKmConsumption
    {
        public int? CarId { get; set; }
        public DateTime? DateMin { get; set; }
        public double? OdometerValueMin { get; set; }
        public DateTime? DateMax { get; set; }
        public double? OdometerValueMax { get; set; }
        public double? CarOdometerConsumption { get; set; }
    }
}
