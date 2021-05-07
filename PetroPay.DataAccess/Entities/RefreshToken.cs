using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class RefreshToken
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
