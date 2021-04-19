using System.Collections.Generic;
using PetroPay.Core.Enums;

namespace PetroPay.Web.Controllers.Auth.GetUserInfo
{
    public class GetUserInfoResponse
    {
        public GetUserInfoResponse()
        {
            
        }
        public GetUserInfoResponse(long id, RoleType role, string name)
        {
            Id = id;
            Role = role;
            Name = name;
        }

        public long Id { get; set; }

        public RoleType Role { get; set; }

        public string Name { get; set; }
    }
}
