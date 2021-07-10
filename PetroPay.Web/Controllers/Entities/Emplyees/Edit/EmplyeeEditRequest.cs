namespace PetroPay.Web.Controllers.Entities.Emplyees.Edit
{
    public class EmplyeeEditRequest
    {
        public int EmplyeesId { get; set; }
        public int? EmplyeesNumberFrom { get; set; }
        public int? EmplyeesNumberTo { get; set; }
        public decimal? EmplyeesFeesMonthly { get; set; }
        public decimal? EmplyeesFeesYearly { get; set; }
        public decimal? EmplyeesNfcCost { get; set; }
    }
}
