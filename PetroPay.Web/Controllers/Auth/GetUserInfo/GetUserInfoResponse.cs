using System.Collections.Generic;
using PetroPay.Core.Enums;

namespace PetroPay.Web.Controllers.Auth.GetUserInfo
{
    public class GetUserInfoResponse
    {
        public GetUserInfoResponse()
        {
            
        }
        public GetUserInfoResponse(int id, RoleType role, string name, decimal balance)
        {
            Id = id;
            Role = role;
            Name = name;
            Balance = balance;
        }

        public int Id { get; set; }

        public RoleType Role { get; set; }
        public decimal Balance { get; set; }

        public string Name { get; set; }
    }
}
