namespace PetroPay.Web.Controllers.Entities.Menus.Add
{
    public class MenuAddRequest
    {
        public string ArTitle { get; set; }
        public string UrlRoute { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        public string EnTitle { get; set; }
    }
}
