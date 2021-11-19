namespace PetroPay.Web.Controllers.Entities.TransferBonuses.Add
{
    public class TransferBonusAddRequest
    {
        public int? StationId { get; set; }
        public int? StationWorkerId { get; set; }
        public int Amount { get; set; }
    }
}
