using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Companies.List
{
    public class CompanyListResponseItem
    {
        public int Key { get; set; }
        public string Title { get; set; }
        public decimal Balance { get; set; }
    }
}
