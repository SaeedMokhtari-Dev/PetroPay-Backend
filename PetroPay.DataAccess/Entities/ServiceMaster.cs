using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ServiceMaster
    {
        public ServiceMaster()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int ServiceId { get; set; }
        public string ServiceEnDescription { get; set; }
        public string ServiceArDescription { get; set; }
        public decimal? ServiceTaxRate { get; set; }
        public string ServiceNote { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
