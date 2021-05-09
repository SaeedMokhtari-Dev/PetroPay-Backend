using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewCarBalance
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public string CarIdNumber { get; set; }
        public string CarDriverName { get; set; }
        public decimal? ConsumptionValue { get; set; }
        public decimal? CarBalnce { get; set; }
        public int CarId { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
    }
}
