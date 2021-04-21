namespace PetroPay.Web.Controllers.Branches.Get
{
    public class BranchGetRequest
    {
        public int CompanyId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
