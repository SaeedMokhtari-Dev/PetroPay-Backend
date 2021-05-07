using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewCarTransaction
    {
        public int TransId { get; set; }
        public DateTime? TransDate { get; set; }
        public int? AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountTaype { get; set; }
        public string TransDocument { get; set; }
        public decimal? TransAmount { get; set; }
    }
}
