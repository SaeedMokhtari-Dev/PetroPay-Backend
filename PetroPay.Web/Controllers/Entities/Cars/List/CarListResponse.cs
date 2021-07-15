namespace PetroPay.Web.Controllers.Entities.Cars.List
{
    public class CarListResponse
    {
        public int Key { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string CarNumber { get; set; }
        public decimal Balance { get; set; }
        public bool CarOdometerRecordRequired { get; set; }
    }
}
