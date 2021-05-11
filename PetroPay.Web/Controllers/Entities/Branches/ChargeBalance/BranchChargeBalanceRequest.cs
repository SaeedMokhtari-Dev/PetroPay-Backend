namespace PetroPay.Web.Controllers.Entities.Branches.ChargeBalance
{
    public class BranchChargeBalanceRequest
    {
        public int BranchId { get; set; }
        public decimal IncreaseAmount { get; set; }
    }
}
