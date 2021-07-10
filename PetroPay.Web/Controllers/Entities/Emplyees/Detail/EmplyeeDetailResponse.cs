namespace PetroPay.Web.Controllers.Entities.Emplyees.Detail
{
    public class EmplyeeDetailResponse
    {
        public int EmplyeesId { get; set; }
        public int? EmplyeesNumberFrom { get; set; }
        public int? EmplyeesNumberTo { get; set; }
        public decimal? EmplyeesFeesMonthly { get; set; }
        public decimal? EmplyeesFeesYearly { get; set; }
        public decimal? EmplyeesNfcCost { get; set; }
    }
}
