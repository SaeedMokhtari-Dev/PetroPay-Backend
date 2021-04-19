﻿using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class AccountMaster
    {
        public AccountMaster()
        {
            Cars = new HashSet<Car>();
            Companies = new HashSet<Company>();
            CompanyBranches = new HashSet<CompanyBranch>();
            PetroStations = new HashSet<PetroStation>();
            TransAccounts = new HashSet<TransAccount>();
        }

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountTaype { get; set; }
        public string AccountReference { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<CompanyBranch> CompanyBranches { get; set; }
        public virtual ICollection<PetroStation> PetroStations { get; set; }
        public virtual ICollection<TransAccount> TransAccounts { get; set; }
    }
}
