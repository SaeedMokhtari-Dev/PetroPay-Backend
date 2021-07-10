namespace PetroPay.Web.Controllers.Entities.Menus.Get
{
    public class MenuGetRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool ExportToFile { get; set; } = false;
    }
}
