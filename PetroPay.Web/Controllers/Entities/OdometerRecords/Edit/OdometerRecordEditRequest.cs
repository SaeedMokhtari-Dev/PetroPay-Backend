namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Edit
{
    public class OdometerRecordEditRequest
    {
        public int OdometerRecordId { get; set; }
        public int CarId { get; set; }
        public string OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
    }
}
