using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PetroPay.Web.Controllers.Dashboards.Supplier.Get
{
    public class SupplierGetResponse
    {
        public int? StationBonusBalance { get; set; }
        public decimal? StationBalance { get; set; }
    }
}
