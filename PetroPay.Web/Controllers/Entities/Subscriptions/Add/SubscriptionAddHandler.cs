using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Entities.Subscriptions.Calculate;
using PetroPay.Web.Extensions;
using PetroPay.Web.Identity.Contexts;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Add
{
    public class SubscriptionAddHandler : ApiRequestHandler<SubscriptionAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly SubscriptionCalculator _subscriptionCalculator;
        private readonly UserContext _userContext;
        private readonly UserService _userService;
        private readonly SubscriptionService _subscriptionService;
        private readonly EmailService _emailService;
        
        public SubscriptionAddHandler(
            PetroPayContext context, IMapper mapper, SubscriptionCalculator subscriptionCalculator, UserContext userContext, UserService userService, SubscriptionService subscriptionService, EmailService emailService)
        {
            this._context = context;
            this._mapper = mapper;
            _subscriptionCalculator = subscriptionCalculator;
            _userContext = userContext;
            _userService = userService;
            _subscriptionService = subscriptionService;
            _emailService = emailService;
        }

        protected override async Task<ActionResult> Execute(SubscriptionAddRequest request)
        {
            DateTime startDate = DateTime.Now.GetEgyptDateTime();
            
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
            
            Subscription subscription = await AddSubscription(request, subscriptionCost);

            return ActionResult.Ok(ApiMessages.SubscriptionMessage.AddedSuccessfully);
        }
        
        private async Task<Subscription> AddSubscription(SubscriptionAddRequest request, SubscriptionCalculateResponse subscriptionCost)
        {
            Company company = await _context.Companies.SingleOrDefaultAsync(w => w.CompanyId == _userContext.Id);
            
            Subscription subscription = await _context.ExecuteTransactionAsync(async () =>
            {
                var user = await _userService.GetCurrentUserInfo();
                Subscription newSubscription = _mapper.Map<Subscription>(request);
                newSubscription.SubscriptionDiscountValues = subscriptionCost.Discount;
                newSubscription.CouponId = subscriptionCost.CouponId;
                newSubscription.CouponCode = request.CouponCode;
                newSubscription.SubscriptionTaxValue = subscriptionCost.Tax;
                newSubscription.SubscriptionVatTaxValue = subscriptionCost.Vat;
                if (request.PayFromCompanyBalance)
                {
                    newSubscription.SubscriptionActive = true;
                    newSubscription.SubscriptionPaymentMethod = "CompanyBalance";
                    newSubscription.SubscriptionInvoiceNumber = await _subscriptionService.GetSubscriptionInvoiceNumber();
                    
                    company.CompanyBalnce -= request.SubscriptionCost;

                    TransAccount deductFromCompany = new TransAccount()
                    {
                        AccountId = company.AccountId,
                        TransAmount = -1 * (request.SubscriptionCost),
                        TransDate = DateTime.Now.GetEgyptDateTime(),
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
                        TransDate = DateTime.Now.GetEgyptDateTime(),
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

                    newSubscription.SubscriptionPaymentMethod = petropayAccount.AccName;
                }
                
                newSubscription = (await _context.Subscriptions.AddAsync(newSubscription)).Entity;
                
                /*foreach (var w in request.SubscriptionCarIds)
                {
                    newSubscription.CarSubscriptions.Add(new CarSubscription()
                    {
                        CarId = w,
                        SubscriptionId = newSubscription.SubscriptionId
                    });
                }*/
                
                await _context.SaveChangesAsync();

                return newSubscription;
            });
            if (request.PayFromCompanyBalance)
            {
                await _emailService.SendSubscriptionInvoiceMail(company.CompanyAdminEmail, company.CompanyName,
                    Convert.ToInt64(subscription.SubscriptionInvoiceNumber).ToString());
            }
            return subscription;
        }
    }
}