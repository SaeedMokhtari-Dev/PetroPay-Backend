using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetroPay.DataAccess.Entities
{
    public class RefreshToken
    {
        public long Id { get; set; }

        public string UniqueId { get; set; }

        //public User User { get; set; }

        public string Token { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public bool IsActive { get; set; }
    }
}
