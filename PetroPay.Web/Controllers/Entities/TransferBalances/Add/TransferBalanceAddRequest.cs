namespace PetroPay.Web.Controllers.Entities.TransferBalances.Add
{
    public class TransferBalanceAddRequest
    {
        public TransferBalanceType TransferBalanceType { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? CarId { get; set; }
        public int? DestinationCarId { get; set; }
        public decimal Amount { get; set; }
    }

    public enum TransferBalanceType: int
    {
        CompanyToBranch = 100,
        BranchToCar = 200,
        CarToCar = 300,
        CarToBranch = 400,
        BranchToCompany = 500
    }
}
