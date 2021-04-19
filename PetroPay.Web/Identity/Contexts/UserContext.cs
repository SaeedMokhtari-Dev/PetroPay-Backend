using System.Collections.Generic;
using PetroPay.Core.Enums;
using PetroPay.Core.Interfaces;

namespace PetroPay.Web.Identity.Contexts
{
    public class UserContext: IScoped
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }

        public bool IsAuthenticated { get; set; }

        public RoleType Role { get; set; }

        public bool IsActive { get; set; }
    }
}
