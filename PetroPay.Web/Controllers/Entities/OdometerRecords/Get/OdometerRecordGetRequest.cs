namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Get
{
    public class OdometerRecordGetRequest
    {
        public bool? ExportToFile { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
