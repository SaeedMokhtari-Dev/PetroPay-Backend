namespace PetroPay.Web.Controllers.Entities.PetroStations.Payment
{
    public class PetroStationPaymentRequest
    {
        public int StationId { get; set; }
        public int PetroPayAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
    }
}
