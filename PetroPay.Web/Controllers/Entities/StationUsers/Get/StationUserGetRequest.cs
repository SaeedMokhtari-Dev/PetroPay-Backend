namespace PetroPay.Web.Controllers.Entities.StationUsers.Get
{
    public class StationUserGetRequest
    {
        public int? StationCompanyId { get; set; }
        public int? StationId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
