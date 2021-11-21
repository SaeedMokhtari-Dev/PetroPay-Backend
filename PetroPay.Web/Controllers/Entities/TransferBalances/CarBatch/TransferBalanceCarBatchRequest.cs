namespace PetroPay.Web.Controllers.Entities.TransferBalances.CarBatch
{
    public class TransferBalanceCarBatchRequest
    {
        public int BranchId { get; set; }
        public CarAmount[] CarAmounts { get; set; }
    }
    public class CarAmount
    {
        public int CarId { get; set; }
        public decimal Amount { get; set; }
    }
}
