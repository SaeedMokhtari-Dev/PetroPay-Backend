using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.List
{
    public class PetrolCompanyListResponseItem
    {
        public int Key { get; set; }
        public string Title { get; set; }
        public decimal Balance { get; set; }
    }
}
