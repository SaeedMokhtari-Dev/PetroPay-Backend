using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Reject
{
    public class SubscriptionRejectHandler : ApiRequestHandler<SubscriptionRejectRequest>
    {
        private readonly PetroPayContext _context;
        private readonly EmailService _emailService;
        public SubscriptionRejectHandler(
            PetroPayContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        protected override async Task<ActionResult> Execute(SubscriptionRejectRequest request)
        {
            Subscription subscription = await _context.Subscriptions
                .FindAsync(request.SubscriptionId);

            if (subscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            if (subscription.SubscriptionActive.HasValue && subscription.SubscriptionActive.Value)
            {
                return ActionResult.Error(ApiMessages.SubscriptionMessage.ActiveEntityRejectNotAllowed);
            }

            if (subscription.Rejected.HasValue && subscription.Rejected.Value)
            {
                return ActionResult.Error(ApiMessages.InvalidRequest);
            }

            if (subscription.SubscriptionPaymentMethod == "CompanyBalance")
            {
                return ActionResult.Error(ApiMessages.InvalidRequest);
            }

            Company company = await _context.Companies.FindAsync(subscription.CompanyId);
            
            if(company == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            
            subscription.Rejected = true;
            await _context.SaveChangesAsync();

            if (!string.IsNullOrEmpty(company.CompanyAdminEmail))
                await _emailService.SendMail(company.CompanyAdminEmail, "Your Subscription Request Rejected",
                    $"<p>Your Subscription Request With Id '{subscription.SubscriptionId}' Rejected By Admin</p>", company.CompanyName);
            
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.RejectedSuccessfully);
        }
    }
}
