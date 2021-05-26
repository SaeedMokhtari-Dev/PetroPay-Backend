namespace PetroPay.Web.Controllers.Reports.PetrolStationLists.Get
{
    public class PetrolStationListGetRequest
    {
        public string Region { get; set; }
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
