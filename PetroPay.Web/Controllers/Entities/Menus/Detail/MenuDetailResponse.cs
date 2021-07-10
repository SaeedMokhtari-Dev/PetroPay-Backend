namespace PetroPay.Web.Controllers.Entities.Menus.Detail
{
    public class MenuDetailResponse
    {
        public int MenuId { get; set; }
        public string ArTitle { get; set; }
        public string EnTitle { get; set; }
        public string UrlRoute { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
    }
}
