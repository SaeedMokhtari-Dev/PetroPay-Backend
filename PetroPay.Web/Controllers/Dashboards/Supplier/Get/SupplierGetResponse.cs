using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PetroPay.Web.Controllers.Dashboards.Supplier.Get
{
    public class SupplierGetResponse
    {
        public SupplierGetResponse()
        {
            PetroStationItems = new List<PetroStationItem>();
        }
        public int? StationBonusBalance { get; set; }
        public decimal? StationBalance { get; set; }

        public List<PetroStationItem> PetroStationItems { get; set; }
    }
}
