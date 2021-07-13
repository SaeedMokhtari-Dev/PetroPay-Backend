using System;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Entities.Subscriptions.Calculate;
using PetroPay.Web.Identity.Contexts;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Edit
{
    public class SubscriptionEditHandler : ApiRequestHandler<SubscriptionEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly SubscriptionCalculator _subscriptionCalculator;
        private readonly UserContext _userContext;
        private readonly UserService _userService;
        private readonly SubscriptionService _subscriptionService;
        private readonly EmailService _emailService;

        public SubscriptionEditHandler(
            PetroPayContext context, IMapper mapper, SubscriptionCalculator subscriptionCalculator, UserContext userContext, UserService userService, SubscriptionService subscriptionService, EmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _subscriptionCalculator = subscriptionCalculator;
            _userContext = userContext;
            _userService = userService;
            _subscriptionService = subscriptionService;
            _emailService = emailService;
        }

        protected override async Task<ActionResult> Execute(SubscriptionEditRequest request)
        {
            Subscription editSubscription = await _context.Subscriptions
                .FindAsync(request.SubscriptionId);

            if (editSubscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            
            if (editSubscription.SubscriptionActive ?? false)
            {
                return ActionResult.Error(ApiMessages.SubscriptionMessage.ActiveEntityDeleteNotAllowed);
            }
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            
            if (!string.IsNullOrEmpty(request.SubscriptionStartDate))
            {
                startDate = DateTime.ParseExact(request.SubscriptionStartDate, DateTimeConstants.DateFormat, CultureInfo.InvariantCulture);
            }
            SubscriptionCalculateResponse subscriptionCost =
                await _subscriptionCalculator.CalculateSubscriptionCost(request.BundlesId, request.SubscriptionCarNumbers,
                    request.SubscriptionType, startDate, request.NumberOfDateDiff, request.CouponCode);
            
            if(subscriptionCost == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            
            if(subscriptionCost.SubscriptionCost != request.SubscriptionCost)
                return ActionResult.Error(ApiMessages.InvalidRequest);

            if (request.PayFromCompanyBalance && _userContext.Balance < subscriptionCost.SubscriptionCost)
                return ActionResult.Error(ApiMessages.NotEnoughBalance);
            
            if(!request.PayFromCompanyBalance && string.IsNullOrEmpty(request.SubscriptionPaymentMethod))
                return ActionResult.Error(ApiMessages.SubscriptionMessage.SubscriptionPaymentMethodRequired);
            
                        
            switch (request.SubscriptionType)
            {
                case "Monthly":
                    request.SubscriptionEndDate = startDate.AddMonths(request.NumberOfDateDiff).ToString(DateTimeConstants.DateFormat);
                    break;
                case "Yearly":
                    request.SubscriptionEndDate = startDate.AddYears(request.NumberOfDateDiff).ToString(DateTimeConstants.DateFormat);
                    break;
            }
            
            await EditSubscription(editSubscription, request, subscriptionCost);
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.EditedSuccessfully);
        }

        private async Task EditSubscription(Subscription editSubscription, SubscriptionEditRequest request, SubscriptionCalculateResponse subscriptionCost)
        {
            Company company = await _context.Companies.SingleOrDefaultAsync(w => w.CompanyId == _userContext.Id);
            editSubscription = await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editSubscription);
                editSubscription.CouponId = subscriptionCost.CouponId;
                editSubscription.CouponCode = request.CouponCode;
                editSubscription.SubscriptionDiscountValues = subscriptionCost.Discount;
                editSubscription.SubscriptionVatTaxValue = subscriptionCost.Vat;
                editSubscription.SubscriptionTaxValue = subscriptionCost.Tax;
                if (request.PayFromCompanyBalance)
                {
                    var user = await _userService.GetCurrentUserInfo();
                    editSubscription.SubscriptionActive = true;
                    editSubscription.SubscriptionPaymentMethod = "CompanyBalance";
                    editSubscription.SubscriptionInvoiceNumber = await _subscriptionService.GetSubscriptionInvoiceNumber();
                    
                    company.CompanyBalnce -= request.SubscriptionCost;

                    TransAccount deductFromCompany = new TransAccount()
                    {
                        AccountId = company.AccountId,
                        TransAmount = -1 * (request.SubscriptionCost),
                        TransDate = DateTime.Now,
                        TransDocument = "paySubscri",
                        TransReference = company.AccountId.ToString()
                    };
                    
                    if (user.Item1)
                    {
                        deductFromCompany.UserId = user.Item2.Id;
                        deductFromCompany.UserName = user.Item2.Name;
                        deductFromCompany.UserType = user.Item2.Role.GetDisplayName();
                    }
                    deductFromCompany = (await _context.TransAccounts.AddAsync(deductFromCompany)).Entity;
                    PetropayAccount petropayAccount =
                        await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccName == "Subscriptions");
                    if (petropayAccount == null)
                        throw new Exception("PetropayAccount Subscriptions does not found.");
                    
                    petropayAccount.AccBalance += request.SubscriptionCost;
                    
                    TransAccount addToSubscriptionAccount = new TransAccount()
                    {
                        AccountId = petropayAccount.AccountId,
                        TransAmount = request.SubscriptionCost,
                        TransDate = DateTime.Now,
                        TransDocument = "paySubscri",
                        TransReference = company.AccountId.ToString()
                    };
                    
                    if (user.Item1)
                    {
                        addToSubscriptionAccount.UserId = user.Item2.Id;
                        addToSubscriptionAccount.UserName = user.Item2.Name;
                        addToSubscriptionAccount.UserType = user.Item2.Role.GetDisplayName();
                    }
                    addToSubscriptionAccount = (await _context.TransAccounts.AddAsync(addToSubscriptionAccount)).Entity;
                }
                else
                {
                    PetropayAccount petropayAccount =
                        await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccName == request.SubscriptionPaymentMethod);
                    if (petropayAccount == null)
                        throw new Exception("PetropayAccount Subscriptions does not found.");

                    editSubscription.SubscriptionPaymentMethod = petropayAccount.AccName;
                }

                await _context.SaveChangesAsync();
                return editSubscription;
            });

            if (request.PayFromCompanyBalance)
            {
                await _emailService.SendSubscriptionInvoiceMail(company.CompanyAdminEmail, company.CompanyName,
                    Convert.ToInt64(editSubscription.SubscriptionInvoiceNumber).ToString());
            }
        }
    }
}