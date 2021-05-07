using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Bundles.Get
{
    public class BundleGetResponse
    {
        public int TotalCount { get; set; }
        public List<BundleGetResponseItem> Items { get; set; }
    }
    public class BundleGetResponseItem
    {
        public int Key { get; set; }
        public int BundlesId { get; set; }
        public int? BundlesNumberFrom { get; set; }
        public int? BundlesNumberTo { get; set; }
        public decimal? BundlesFeesMonthly { get; set; }
        public decimal? BundlesFeesYearly { get; set; }
        public decimal? BundlesNfcCost { get; set; }
    }
}
