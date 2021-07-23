using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PetroPay.Web.Controllers.Dashboards.Admin.Get
{
    public class AdminGetResponse
    {
        public AdminGetResponse()
        {
            PetrolStationItems = new List<PetrolStationItem>();
            CompanyListItems = new List<CompanyListItem>();
        }

        public int SubscriptionRequests { get; set; }
        public int RechargeRequests { get; set; }
        public int CarRequests { get; set; }
        
        public List<CompanyListItem> CompanyListItems { get; set; }
        public List<PetrolStationItem> PetrolStationItems { get; set; }
    }
    public class CompanyListItem
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
    public class PetrolStationItem
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bonus { get; set; }
    }
}
