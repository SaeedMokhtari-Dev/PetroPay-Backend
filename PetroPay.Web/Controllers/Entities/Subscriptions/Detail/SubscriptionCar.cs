namespace PetroPay.Web.Controllers.Entities.Subscriptions.Detail
{
    public class SubscriptionCar
    {
        public int Key { get; set; }
        public string CarIdNumber { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public bool Disabled { get; set; }
    }
}