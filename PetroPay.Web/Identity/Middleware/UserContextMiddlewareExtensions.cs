using Microsoft.AspNetCore.Builder;

namespace PetroPay.Web.Identity.Middleware
{
    public static class UserContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserContextMiddleware>();
        }
    }
}
