namespace PetroPay.Web.Controllers.Entities.TransferBonuses.Get
{
    public class TransferBonusGetRequest
    {
        public int? CompanyId { get; set; }
        public int? StationId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
