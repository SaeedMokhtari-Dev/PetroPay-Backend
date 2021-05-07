using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Branches.Get
{
    public class BranchGetResponse
    {
        public int TotalCount { get; set; }
        public List<BranchGetResponseItem> Items { get; set; }
    }
    public class BranchGetResponseItem
    {
        public int Key { get; set; }
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
    }
}
