using Microsoft.Data.SqlClient.Server;
using PetroPay.Core.Enums;

namespace PetroPay.Web.Controllers.Auth.Login
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public RoleType RoleType { get; set; }
    }

    
}
