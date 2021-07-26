#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewCustomerStatement
    {
        public string TransactionDataTime { get; set; }
        public int? AccountId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string TransDocument { get; set; }
        public decimal? SumTransAmount { get; set; }
        public string AccountName { get; set; }
    }
}
