using System.Collections.Generic;
using PetroPay.Core.Enums;

namespace PetroPay.Web.Controllers.Auth.GetUserInfo
{
    public class GetUserInfoResponse
    {
        public GetUserInfoResponse()
        {
            
        }
        public GetUserInfoResponse(long id, RoleType role, string name, decimal balance)
        {
            Id = id;
            Role = role;
            Name = name;
            Balance = balance;
        }

        public long Id { get; set; }

        public RoleType Role { get; set; }
        public decimal Balance { get; set; }

        public string Name { get; set; }
    }
}
