namespace PetroPay.Web.Controllers.Entities.Emplyees.Add
{
    public class EmplyeeAddRequest
    {
        public int? EmplyeesNumberFrom { get; set; }
        public int? EmplyeesNumberTo { get; set; }
        public decimal? EmplyeesFeesMonthly { get; set; }
        public decimal? EmplyeesFeesYearly { get; set; }
        public decimal? EmplyeesNfcCost { get; set; }
    }
}
