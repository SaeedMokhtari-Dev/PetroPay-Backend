namespace PetroPay.DataAccess.Entities
{
    public partial class EmployeeMenu
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Emplyee Employee { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
