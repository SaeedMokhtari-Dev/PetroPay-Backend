using System;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Add
{
    public class NewCustomerAddRequest
    {
        public string CustName { get; set; }
        public string CustCompany { get; set; }
        public string CustEmail { get; set; }
        public string CustPhoneNumber { get; set; }
        public string CustAddress { get; set; }
        public bool? CustReqStatus { get; set; }
    }
}
