using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Add
{
    public class EmployeeMenuAddRequest
    {
        public int EmployeeId { get; set; }
        public List<int> MenuIds { get; set; }
    }
}
