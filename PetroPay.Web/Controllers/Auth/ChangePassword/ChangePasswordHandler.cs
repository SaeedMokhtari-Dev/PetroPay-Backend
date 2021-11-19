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

namespace PetroPay.Web.Controllers.Auth.ChangePassword
{
    public class ChangePasswordHandler : ApiRequestHandler<ChangePasswordRequest>
    {
        private readonly PetroPayContext _context;
        /*private readonly PasswordService passwordService;*/

        public ChangePasswordHandler(
            PetroPayContext context)
        {
            this._context = context;
        }

        protected override async Task<ActionResult> Execute(ChangePasswordRequest request)
        {
            if (request.NewPassword != request.ConfirmPassword)
            {
                return ActionResult.Error(ApiMessages.Auth.ChangePasswordNotEqualsPasswords);
            }

            if (!Guid.TryParse(request.Token, out var token))
            {
                return ActionResult.Error(ApiMessages.Auth.ValidateResetPasswordTokenInvalidToken);
            }

            var passwordResetToken = await _context.PasswordResetTokens.SingleOrDefaultAsync(w => w.Token == token);

            if (passwordResetToken == null)
            {
                return ActionResult.Error(ApiMessages.Auth.ValidateResetPasswordTokenInvalidToken);
            }

            string roleType = passwordResetToken.UniqueId.Split("_")[0]; 
            int id = int.Parse(passwordResetToken.UniqueId.Split("_")[1]);
            switch (roleType)
            {
                case "Customer":
                {
                    var customer = await _context.Companies.SingleOrDefaultAsync(w => w.CompanyId == id);
             
                    if (customer == null)
                    {
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                    }
                    customer.CompanyAdminUserPassword = request.NewPassword;
                    await ChangePasswordAndDeletePasswordResetToken(passwordResetToken);
                
                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                case "CustomerBranch":
                {
                    var companyBranch = await _context.CompanyBranches.SingleOrDefaultAsync(w => w.CompanyBranchId == id);
             
                    if (companyBranch == null)
                    {
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                    }
                    companyBranch.CompanyBranchAdminUserPassword = request.NewPassword;
                    await ChangePasswordAndDeletePasswordResetToken(passwordResetToken);
                
                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                case "Supplier":
                {
                    var petrolCompany = await _context.PetrolCompanies.SingleOrDefaultAsync(w => w.PetrolCompanyId == id);
             
                    if (petrolCompany == null)
                    {
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                    }
                
                    petrolCompany.PetrolCompanyAdminUserPassword = request.NewPassword;
                    await ChangePasswordAndDeletePasswordResetToken(passwordResetToken);

                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                case "SupplierBranch":
                {
                    var supplier = await _context.PetroStations.SingleOrDefaultAsync(w => w.StationId == id);
             
                    if (supplier == null)
                    {
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                    }
                
                    supplier.StationPassword = request.NewPassword;
                    await ChangePasswordAndDeletePasswordResetToken(passwordResetToken);

                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                case "Admin":
                {
                    var admin = await _context.Emplyees.SingleOrDefaultAsync(w => w.EmplyeeId == id);
             
                    if (admin == null)
                    {
                        return ActionResult.Error(ApiMessages.ResourceNotFound);
                    }

                    admin.EmplyeePassword = request.NewPassword;
                    await ChangePasswordAndDeletePasswordResetToken(passwordResetToken);

                    return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
                }
                default:
                    return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
        }
        private async Task ChangePasswordAndDeletePasswordResetToken(PasswordResetToken passwordResetToken)
        {
            await _context.ExecuteTransactionAsync( async () =>
            {
                _context.PasswordResetTokens.Remove(passwordResetToken);
                await _context.SaveChangesAsync();
            });
        }
    }
}
