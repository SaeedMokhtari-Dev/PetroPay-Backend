using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class PasswordResetToken
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public Guid Token { get; set; }
        public DateTime ResetRequestDate { get; set; }
    }
}
