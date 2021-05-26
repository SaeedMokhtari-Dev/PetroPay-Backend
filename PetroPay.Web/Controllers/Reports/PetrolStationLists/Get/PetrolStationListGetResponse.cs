using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.PetrolStationLists.Get
{
    public class PetrolStationListGetResponse
    {
        public int TotalCount { get; set; }
        public List<PetrolStationListGetResponseItem> Items { get; set; }
    }
    public class PetrolStationListGetResponseItem
    {
        public Guid Key { get; set; }
        public string StationLucationName { get; set; }
        public string StationName { get; set; }
        public string StationNameAr { get; set; }
        public bool? StationDiesel { get; set; }
        public double? StationLatitude { get; set; }
        public double? StationLongitude { get; set; }
    }
}
