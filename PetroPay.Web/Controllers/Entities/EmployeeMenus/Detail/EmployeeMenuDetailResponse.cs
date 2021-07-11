using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Detail
{
    public class EmployeeMenuDetailResponse
    {
        public int EmployeeId { get; set; }
        public List<int> MenuIds { get; set; }
    }
}
