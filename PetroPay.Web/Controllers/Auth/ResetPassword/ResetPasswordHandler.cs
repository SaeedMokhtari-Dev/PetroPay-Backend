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
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Auth.ResetPassword
{
    public class ResetPasswordHandler : ApiRequestHandler<ResetPasswordRequest>
    {
        private readonly PetroPayContext _context;
        private readonly EmailService _emailService;

        public ResetPasswordHandler(
            PetroPayContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        protected override async Task<ActionResult> Execute(ResetPasswordRequest request)
        {
            switch (request.RoleType)
            {
                case RoleType.Customer:
                {
                    var customer = await _context.Companies.FirstOrDefaultAsync(x =>
                        x.CompanyAdminEmail.ToLower() == request.Email.ToLower());
             
                    if (customer == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }
                
                    Guid token = await GenerateANewTokenAndSave($"Customer_{customer.CompanyId}");
            
                    await _emailService.SendResetPasswordEmail(customer.CompanyAdminEmail, customer.CompanyAdminName ,token);

                    return ActionResult.Ok(ApiMessages.Auth.ResetPasswordResponse);
                }
                case RoleType.CustomerBranch:
                {
                    var companyBranch = await _context.CompanyBranches.FirstOrDefaultAsync(x =>
                        x.CompanyBranchAdminEmail.ToLower() == request.Email.ToLower());
             
                    if (companyBranch == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }
                
                    Guid token = await GenerateANewTokenAndSave($"CustomerBranch_{companyBranch.CompanyBranchId}");
            
                    await _emailService.SendResetPasswordEmail(companyBranch.CompanyBranchAdminEmail, companyBranch.CompanyBranchAdminName ,token);

                    return ActionResult.Ok(ApiMessages.Auth.ResetPasswordResponse);
                }
                case RoleType.Supplier:
                {
                    var petrolCompany = await _context.PetrolCompanies.FirstOrDefaultAsync(x =>
                        x.PetrolCompanyAdminEmail.ToLower() == request.Email.ToLower());
             
                    if (petrolCompany == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }
                    Guid token = await GenerateANewTokenAndSave($"Supplier_{petrolCompany.PetrolCompanyId}");
            
                    await _emailService.SendResetPasswordEmail(petrolCompany.PetrolCompanyAdminEmail, petrolCompany.PetrolCompanyAdminName ,token);

                    return ActionResult.Ok(ApiMessages.Auth.ResetPasswordResponse);
                }
                case RoleType.SupplierBranch:
                {
                    var supplier = await _context.PetroStations.FirstOrDefaultAsync(x =>
                        x.StationEmail.ToLower() == request.Email.ToLower());
             
                    if (supplier == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }
                    Guid token = await GenerateANewTokenAndSave($"SupplierBranch_{supplier.StationId}");
            
                    await _emailService.SendResetPasswordEmail(supplier.StationEmail, supplier.StationOwnerName ,token);

                    return ActionResult.Ok(ApiMessages.Auth.ResetPasswordResponse);
                }
                case RoleType.Admin:
                {
                    var admin = await _context.Emplyees.FirstOrDefaultAsync(x =>
                        x.EmplyeeEmail.ToLower() == request.Email.ToLower());
             
                    if (admin == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }
                    Guid token = await GenerateANewTokenAndSave($"Admin_{admin.EmplyeeId}");
            
                    await _emailService.SendResetPasswordEmail(admin.EmplyeeEmail, admin.EmplyeeName ,token);

                    return ActionResult.Ok(ApiMessages.Auth.ResetPasswordResponse);
                }
                default:
                    return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
        }

        

        private async Task<Guid> GenerateANewTokenAndSave(string uniqueId)
        {
            PasswordResetToken passwordResetToken = 
                await _context.PasswordResetTokens.SingleOrDefaultAsync(w => w.UniqueId == uniqueId);

            if (passwordResetToken != null)
            {
                passwordResetToken.Token = Guid.NewGuid();
                passwordResetToken.ResetRequestDate = DateTime.UtcNow;
            }
            else
            {
                passwordResetToken = new PasswordResetToken()
                {
                    Token = Guid.NewGuid(),
                    UniqueId = uniqueId,
                    ResetRequestDate = DateTime.UtcNow
                };
                await _context.PasswordResetTokens.AddAsync(passwordResetToken);
            }

            await _context.SaveChangesAsync();

            return passwordResetToken.Token;
        }

        /*private async Task SetLastResetPassword(User user)
        {
            user.LastResetPasswordAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }*/
    }
}
