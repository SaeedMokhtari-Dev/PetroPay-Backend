#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ViewCustomerBalance
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal? CompanyBalnce { get; set; }
        public decimal? SumCarBalnce { get; set; }
        public decimal? SumCompanyBranchBalnce { get; set; }
        public int? NumberOfCars { get; set; }
    }
}
