using System.Collections.Generic;

namespace PetroPay.Web.Controllers.StationUsers.Get
{
    public class StationUserGetResponse
    {
        public int TotalCount { get; set; }
        public List<StationUserGetResponseItem> Items { get; set; }
    }
    public class StationUserGetResponseItem
    {
        public int Key { get; set; }
        public int StationWorkerId { get; set; }
        public string StationWorkerFname { get; set; }
        public string StationWorkerPhone { get; set; }
        public string StationUserName { get; set; }
        public string StationUserPassword { get; set; }
        public int? StationId { get; set; }
    }
}
