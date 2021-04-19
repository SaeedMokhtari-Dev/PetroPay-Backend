using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class Emplyee
    {
        public int EmplyeeId { get; set; }
        public string EmplyeeName { get; set; }
        public string EmplyeePhone { get; set; }
        public string EmplyeeEmail { get; set; }
        public string EmplyeeCode { get; set; }
        public string EmplyeeUserName { get; set; }
        public string EmplyeePassword { get; set; }
        public string EmplyeeStatus { get; set; }
        public byte[] EmplyeePhoto { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
        public Guid UniqueGuid { get; set; }
    }
}
