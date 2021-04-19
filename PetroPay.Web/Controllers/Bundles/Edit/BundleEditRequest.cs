namespace PetroPay.Web.Controllers.Bundles.Edit
{
    public class BundleEditRequest
    {
        public int BundlesId { get; set; }
        public int? BundlesNumberFrom { get; set; }
        public int? BundlesNumberTo { get; set; }
        public decimal? BundlesFeesMonthly { get; set; }
        public decimal? BundlesFeesYearly { get; set; }
        public decimal? BundlesNfcCost { get; set; }
    }
}
