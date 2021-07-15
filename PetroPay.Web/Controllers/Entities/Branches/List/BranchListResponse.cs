using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Branches.List
{
    public class BranchListResponseItem
    {
        public int Key { get; set; }
        public string Title { get; set; }
        public decimal Balance { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
