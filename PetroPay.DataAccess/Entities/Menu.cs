using System;
using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            EmployeeMenus = new HashSet<EmployeeMenu>();
            InverseParent = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string ArTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UrlRoute { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        public string EnTitle { get; set; }

        public virtual Menu Parent { get; set; }
        public virtual ICollection<EmployeeMenu> EmployeeMenus { get; set; }
        public virtual ICollection<Menu> InverseParent { get; set; }
    }
}
