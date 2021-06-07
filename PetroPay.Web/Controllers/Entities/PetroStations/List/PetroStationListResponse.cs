using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.PetroStations.List
{
    public class PetroStationListResponseItem
    {
        public int Key { get; set; }
        public string Title { get; set; }
        public decimal Balance { get; set; }
    }
}
