namespace PetroPay.Web.Identity.Models
{
    public class AccessTokenValidationResult
    {
        public bool IsValid { get; private set; }

        public bool IsExpired { get; private set; }

        public string UniqueId { get; private set; }

        private AccessTokenValidationResult() { }

        public static AccessTokenValidationResult Valid(string uniqueId)
        {
            return new AccessTokenValidationResult
            {
                IsValid = true,
                IsExpired = false,
                UniqueId = uniqueId
            };
        }

        public static AccessTokenValidationResult Invalid()
        {
            return new AccessTokenValidationResult
            {
                IsValid = false
            };
        }

        public static AccessTokenValidationResult Expired(string uniqueId)
        {
            return new AccessTokenValidationResult
            {
                IsValid = true,
                IsExpired = true,
                UniqueId = uniqueId
            };
        }
    }
}
