namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Payment
{
    public class PetropayAccountPaymentRequest
    {
        public int FromPetroPayAccountId { get; set; }
        public int ToPetroPayAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
    }
}
