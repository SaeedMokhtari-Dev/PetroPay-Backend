#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class ApiData
    {
        public string ApiUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public string Mobile { get; set; }
        public string Language { get; set; }
    }
}
