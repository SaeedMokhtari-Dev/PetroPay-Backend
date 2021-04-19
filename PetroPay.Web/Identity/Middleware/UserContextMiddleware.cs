using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Identity.Middleware
{
    public class UserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public UserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, UserContext userContext, PetroPayContext petroPayContext)
        {
            if (httpContext.User.Identity?.IsAuthenticated ?? false)
            {
                var uniqueId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                try
                {
                    if (!string.IsNullOrEmpty(uniqueId))
                    {
                        var roleType = uniqueId.Split("_")[0];
                        var id = int.Parse(uniqueId.Split("_")[1]);
                        switch (roleType)
                        {
                            case "Customer":
                                var customer = await petroPayContext.Companies.FindAsync(id);
                                if (customer == null)
                                    httpContext.Response.StatusCode = 401;
                                else
                                {
                                    userContext.Id = customer.CompanyId;
                                    userContext.UniqueId = uniqueId;
                                    userContext.Role = RoleType.Customer;
                                    userContext.IsActive = true;
                                    userContext.IsAuthenticated = true;
                                }

                                break;
                            case "Supplier":
                                var supplier = await petroPayContext.PetroStations.FindAsync(id);
                                if (supplier == null)
                                    httpContext.Response.StatusCode = 401;
                                else
                                {
                                    userContext.Id = supplier.StationId;
                                    userContext.UniqueId = uniqueId;
                                    userContext.Role = RoleType.Supplier;
                                    userContext.IsActive = true;
                                    userContext.IsAuthenticated = true;
                                }

                                break;
                            case "Admin":
                                var admin = await petroPayContext.Emplyees.FindAsync(id);
                                if (admin == null)
                                    httpContext.Response.StatusCode = 401;
                                else
                                {
                                    userContext.Id = admin.EmplyeeId;
                                    userContext.UniqueId = uniqueId;
                                    userContext.Role = RoleType.Admin;
                                    userContext.IsActive = true;
                                    userContext.IsAuthenticated = true;
                                }

                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    httpContext.Response.StatusCode = 401;
                }
            }

            await _next(httpContext);
        }
    }
}