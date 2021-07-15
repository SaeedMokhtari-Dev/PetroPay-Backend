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
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly SubscriptionService _subscriptionService;
        private readonly EmailService _emailService;
        public SubscriptionRejectHandler(
            PetroPayContext context, IMapper mapper, UserService userService, SubscriptionService subscriptionService, EmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _subscriptionService = subscriptionService;
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
            
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.RejectedSuccessfully);
        }
    }
}
