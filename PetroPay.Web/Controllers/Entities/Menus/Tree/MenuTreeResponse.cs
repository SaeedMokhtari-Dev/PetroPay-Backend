using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Menus.Tree
{
    public class MenuTreeResponse
    {
        public int Key { get; set; }
        public string ArTitle { get; set; }
        public string EnTitle { get; set; }
        
        public List<MenuTreeResponseItem> Items { get; set; }
    }
    public class MenuTreeResponseItem
    {
        public int Key { get; set; }
        public string ArTitle { get; set; }
        public string EnTitle { get; set; }   
    }
}
