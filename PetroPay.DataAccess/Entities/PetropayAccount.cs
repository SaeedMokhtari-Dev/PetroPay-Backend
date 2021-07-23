#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class PetropayAccount
    {
        public int AccId { get; set; }
        public string AccName { get; set; }
        public decimal? AccBalance { get; set; }
        public int? AccountId { get; set; }
        public string AccNot { get; set; }
        public string AccRefer { get; set; }
        public bool? AccPaymentMethodShow { get; set; }
        public bool? AccSubscriptionRequst { get; set; }
        public bool? AccPetrolStationBonus { get; set; }

        public virtual AccountMaster Account { get; set; }
    }
}
