using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Auth.ChangeUserPassword
{
    public class ChangeUserPasswordHandler : ApiRequestHandler<ChangeUserPasswordRequest>
    {
        private readonly PetroPayContext _context;
        private readonly UserContext _userContext;

        public ChangeUserPasswordHandler(
            PetroPayContext context, UserContext userContext)
        {
            this._context = context;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(ChangeUserPasswordRequest request)
        {
            if (request.NewPassword != request.ConfirmPassword)
            {
                return ActionResult.Error(ApiMessages.Auth.ChangePasswordNotEqualsPasswords);
            }
            
            switch (_userContext.Role)
            {
                case RoleType.Customer:
                {
                    var customer = await _context.Companies.SingleOrDefaultAsync(w => w.CompanyId == _userContext.Id);
             
                    if (customer == null)
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                
                    if(customer.CompanyAdminUserPassword != request.CurrentPassword)
                        return ActionResult.Error(ApiMessages.Auth.ChangePasswordCurrentPasswordIsNotCorrect);
                
                    customer.CompanyAdminUserPassword = request.NewPassword;
                    await _context.SaveChangesAsync();
                
                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                case RoleType.CustomerBranch:
                {
                    var companyBranch = await _context.CompanyBranches.SingleOrDefaultAsync(w => w.CompanyBranchId == _userContext.Id);
             
                    if (companyBranch == null)
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                
                    if(companyBranch.CompanyBranchAdminUserPassword != request.CurrentPassword)
                        return ActionResult.Error(ApiMessages.Auth.ChangePasswordCurrentPasswordIsNotCorrect);
                
                    companyBranch.CompanyBranchAdminUserPassword = request.NewPassword;
                    await _context.SaveChangesAsync();
                
                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                case RoleType.Supplier:
                {
                    var petrolCompany = await _context.PetrolCompanies.SingleOrDefaultAsync(w => w.PetrolCompanyId == _userContext.Id);
             
                    if (petrolCompany == null)
                    {
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                    }
                    if(petrolCompany.PetrolCompanyAdminUserPassword != request.CurrentPassword)
                        return ActionResult.Error(ApiMessages.Auth.ChangePasswordCurrentPasswordIsNotCorrect);
                
                    petrolCompany.PetrolCompanyAdminUserPassword = request.NewPassword;
                    await _context.SaveChangesAsync();

                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                case RoleType.SupplierBranch:
                {
                    var supplier = await _context.PetroStations.SingleOrDefaultAsync(w => w.StationId == _userContext.Id);
             
                    if (supplier == null)
                    {
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                    }
                    if(supplier.StationPassword != request.CurrentPassword)
                        return ActionResult.Error(ApiMessages.Auth.ChangePasswordCurrentPasswordIsNotCorrect);
                
                    supplier.StationPassword = request.NewPassword;
                    await _context.SaveChangesAsync();

                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                case RoleType.Admin:
                {
                    var admin = await _context.Emplyees.SingleOrDefaultAsync(w => w.EmplyeeId == _userContext.Id);
             
                    if (admin == null)
                    {
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                    }
                    if(admin.EmplyeePassword != request.CurrentPassword)
                        return ActionResult.Error(ApiMessages.Auth.ChangePasswordCurrentPasswordIsNotCorrect);

                    admin.EmplyeePassword = request.NewPassword;
                    await _context.SaveChangesAsync();

                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                default:
                    return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
        }
    }
}
