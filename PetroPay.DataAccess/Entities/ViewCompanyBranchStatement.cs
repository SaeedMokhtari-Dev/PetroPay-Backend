#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewCompanyBranchStatement
    {
        public string TransactionDateTime { get; set; }
        public int? AccountId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public decimal? SumTransAmount { get; set; }
        public string TransDocument { get; set; }
    }
}
