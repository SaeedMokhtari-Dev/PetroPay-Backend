#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewAccountBalance
    {
        public int AccountId { get; set; }
        public string AccountTaype { get; set; }
        public string AccountName { get; set; }
        public decimal? SumTransAmount { get; set; }
    }
}
