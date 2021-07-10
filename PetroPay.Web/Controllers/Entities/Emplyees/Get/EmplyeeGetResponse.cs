using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Get
{
    public class EmplyeeGetResponse
    {
        public int TotalCount { get; set; }
        public List<EmplyeeGetResponseItem> Items { get; set; }
    }
    public class EmplyeeGetResponseItem
    {
        public int Key { get; set; }
        public int EmplyeeId { get; set; }
        public string EmplyeeName { get; set; }
        public string EmplyeePhone { get; set; }
        public string EmplyeeEmail { get; set; }
        public string EmplyeeCode { get; set; }
        public string EmplyeeUserName { get; set; }
        public string EmplyeeStatus { get; set; }
    }
}
