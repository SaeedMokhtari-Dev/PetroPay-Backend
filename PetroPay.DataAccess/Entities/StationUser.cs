using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class StationUser
    {
        public StationUser()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int StationWorkerId { get; set; }
        public string StationWorkerFname { get; set; }
        public string StationWorkerPhone { get; set; }
        public string StationUserName { get; set; }
        public string StationUserPassword { get; set; }
        public int? StationId { get; set; }

        public virtual PetroStation Station { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
