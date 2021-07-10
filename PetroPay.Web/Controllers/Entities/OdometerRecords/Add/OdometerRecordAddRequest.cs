namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Add
{
    public class OdometerRecordAddRequest
    {
        public int CarId { get; set; }
        public string OdometerRecordDate { get; set; }
        public double? OdometerValue { get; set; }
    }
}
