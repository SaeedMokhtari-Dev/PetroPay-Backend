namespace PetroPay.Web.Controllers.Entities.Cars.Get
{
    public class CarGetRequest
    {
        public int? CompanyBranchId { get; set; }
        public int? CompanyId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
