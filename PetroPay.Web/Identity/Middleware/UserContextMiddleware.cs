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
                                    userContext.Balance = customer.CompanyBalnce ?? 0;
                                }

                                break;
                            case "CustomerBranch":
                                var companyBranch = await petroPayContext.CompanyBranches.FindAsync(id);
                                if (companyBranch == null)
                                    httpContext.Response.StatusCode = 401;
                                else
                                {
                                    userContext.Id = companyBranch.CompanyBranchId;
                                    userContext.UniqueId = uniqueId;
                                    userContext.Role = RoleType.CustomerBranch;
                                    userContext.IsActive = true;
                                    userContext.IsAuthenticated = true;
                                    userContext.Balance = companyBranch.CompanyBranchBalnce ?? 0;
                                }

                                break;
                            case "Supplier":
                                var petrolCompany = await petroPayContext.PetrolCompanies.FindAsync(id);
                                if (petrolCompany == null)
                                    httpContext.Response.StatusCode = 401;
                                else
                                {
                                    userContext.Id = petrolCompany.PetrolCompanyId;
                                    userContext.UniqueId = uniqueId;
                                    userContext.Role = RoleType.Supplier;
                                    userContext.IsActive = true;
                                    userContext.IsAuthenticated = true;
                                    userContext.Balance = petrolCompany.PetrolCompanyBalnce ?? 0;
                                }

                                break;
                            case "SupplierBranch":
                                var supplier = await petroPayContext.PetroStations.FindAsync(id);
                                if (supplier == null)
                                    httpContext.Response.StatusCode = 401;
                                else
                                {
                                    userContext.Id = supplier.StationId;
                                    userContext.UniqueId = uniqueId;
                                    userContext.Role = RoleType.SupplierBranch;
                                    userContext.IsActive = true;
                                    userContext.IsAuthenticated = true;
                                    userContext.Balance = supplier.StationBalance ?? 0;
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
                                    userContext.Balance = 0;
                                }

                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    httpContext.Response.StatusCode = 401;
                }
            }

            await _next(httpContext);
        }
    }
}