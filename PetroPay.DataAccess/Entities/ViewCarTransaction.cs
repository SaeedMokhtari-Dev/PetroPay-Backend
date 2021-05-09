using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewCarTransaction
    {
        public int CarId { get; set; }
        public string CarIdNumber { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int TransId { get; set; }
        public DateTime? TransDate { get; set; }
        public string TransDocument { get; set; }
        public decimal? TransAmount { get; set; }
        public string TransReference { get; set; }
    }
}
