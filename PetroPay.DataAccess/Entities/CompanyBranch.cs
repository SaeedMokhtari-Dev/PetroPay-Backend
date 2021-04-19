using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class CompanyBranch
    {
        public CompanyBranch()
        {
            Cars = new HashSet<Car>();
        }

        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public int? CompanyBranchNumberOfcar { get; set; }
        public string CompanyBranchAddress { get; set; }
        public bool? CompanyBranchActiva { get; set; }
        public int? CompanyId { get; set; }
        public decimal? CompanyBranchBalnce { get; set; }
        public string CompanyBranchAdminName { get; set; }
        public string CompanyBranchAdminUserName { get; set; }
        public string CompanyBranchAdminPhone { get; set; }
        public string CompanyBranchAdminUserPassword { get; set; }
        public string CompanyBranchAdminEmail { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
        public int? AccountId { get; set; }

        public virtual AccountMaster Account { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
