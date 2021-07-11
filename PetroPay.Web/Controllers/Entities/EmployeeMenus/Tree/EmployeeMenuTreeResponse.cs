using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Tree
{
    public class EmployeeMenuTreeResponse
    {
        public int Key { get; set; }
        public string ArTitle { get; set; }
        public string EnTitle { get; set; }
        public string UrlRoute { get; set; }
        
        public List<EmployeeMenuTreeResponseItem> Items { get; set; }
    }
    public class EmployeeMenuTreeResponseItem
    {
        public int Key { get; set; }
        public string ArTitle { get; set; }
        public string EnTitle { get; set; }   
        public string UrlRoute { get; set; }
    }
}
