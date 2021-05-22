namespace PetroPay.Web.Controllers.Entities.Branches.List
{
    public class BranchListRequest
    {
        public int? CompanyId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
