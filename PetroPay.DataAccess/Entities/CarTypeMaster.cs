#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class CarTypeMaster
    {
        public int CarTypeId { get; set; }
        public string CarTypeName { get; set; }
        public int? CarBonusPoint { get; set; }
    }
}
