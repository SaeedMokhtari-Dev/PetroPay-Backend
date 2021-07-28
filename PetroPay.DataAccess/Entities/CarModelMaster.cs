#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class CarModelMaster
    {
        public int CarModelId { get; set; }
        public string CarModelEnName { get; set; }
        public string CarModelArName { get; set; }
        public int? CarBrandId { get; set; }

        public virtual CarBrandMaster CarBrand { get; set; }
    }
}
