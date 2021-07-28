using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class CarBrandMaster
    {
        public CarBrandMaster()
        {
            CarModelMasters = new HashSet<CarModelMaster>();
        }

        public int CarBrandId { get; set; }
        public string CarBrandEnName { get; set; }
        public string CarBrandArName { get; set; }

        public virtual ICollection<CarModelMaster> CarModelMasters { get; set; }
    }
}
