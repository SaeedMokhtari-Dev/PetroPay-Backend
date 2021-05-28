using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PetroPay.Web.Controllers.Dashboards.Customers.Get
{
    public class CustomerGetResponse
    {
        public CustomerGetResponse()
        {
            CompanyBranchItems = new List<CompanyBranchItem>();
            CompanySubscriptionItems = new List<CompanySubscriptionItem>();
        }

        public decimal TotalCustomerBalance { get; set; }
        public decimal TotalCarBalance { get; set; }
        
        public List<CompanyBranchItem> CompanyBranchItems { get; set; }
        public List<CompanySubscriptionItem> CompanySubscriptionItems { get; set; }
    }
    public class CompanyBranchItem
    {
        public int Key { get; set; }
        public string BranchName { get; set; }
        public decimal BranchBalance { get; set; }
    }
    public class CompanySubscriptionItem
    {
        public int Key { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
