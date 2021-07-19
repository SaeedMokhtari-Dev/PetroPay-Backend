namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Get
{
    public class OdometerRecordGetRequest
    {
        public int? CompanyId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
