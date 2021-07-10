using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Menus.Get
{
    public class MenuGetResponse
    {
        public int TotalCount { get; set; }
        public List<MenuGetResponseItem> Items { get; set; }
    }
    public class MenuGetResponseItem
    {
        public int Key { get; set; }
        public int MenuId { get; set; }
        public string ArTitle { get; set; }
        public string CreatedAt { get; set; }
        public string UrlRoute { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        public string ParentTitleAr { get; set; }
        public string ParentTitleEn { get; set; }
        public string EnTitle { get; set; }
    }
}
