namespace PetroPay.Web.Controllers.Entities.Branches.Edit
{
    public class BranchEditRequest
    {
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
