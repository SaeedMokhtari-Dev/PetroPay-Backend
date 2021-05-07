namespace PetroPay.Web.Controllers.Entities.StationUsers.Edit
{
    public class StationUserEditRequest
    {
        public int StationWorkerId { get; set; }
        public string StationWorkerFname { get; set; }
        public string StationWorkerPhone { get; set; }
        public string StationUserName { get; set; }
        public string StationUserPassword { get; set; }
        public int? StationId { get; set; }
    }
}
