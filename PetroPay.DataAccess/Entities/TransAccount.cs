using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class TransAccount
    {
        public int TransId { get; set; }
        public DateTime? TransDate { get; set; }
        public int? AccountId { get; set; }
        public string TransDocument { get; set; }
        public decimal? TransAmount { get; set; }
        public string TransReference { get; set; }

        public virtual AccountMaster Account { get; set; }
    }
}
