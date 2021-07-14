using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Get
{
    public class NewCustomerGetResponse
    {
        public int TotalCount { get; set; }
        public List<NewCustomerGetResponseItem> Items { get; set; }
    }
    public class NewCustomerGetResponseItem
    {
        public int Key { get; set; }
        public int CustReqId { get; set; }
        public string CustName { get; set; }
        public string CustCompany { get; set; }
        public string CustEmail { get; set; }
        public string CustPhoneNumber { get; set; }
        public string CustAddress { get; set; }
        public bool? CustReqStatus { get; set; }
        public DateTime? CutReqDatetime { get; set; }
    }
}
