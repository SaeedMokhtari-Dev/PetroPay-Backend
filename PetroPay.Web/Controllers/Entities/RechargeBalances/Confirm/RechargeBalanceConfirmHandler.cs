using System;
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
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Confirm
{
    public class RechargeBalanceConfirmHandler : ApiRequestHandler<RechargeBalanceConfirmRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public RechargeBalanceConfirmHandler(
            PetroPayContext context, IMapper mapper, UserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        protected override async Task<ActionResult> Execute(RechargeBalanceConfirmRequest request)
        {
            RechargeBalance rechargeBalance = await _context.RechargeBalances
                .FindAsync(request.RechargeId);

            if (rechargeBalance == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            if (rechargeBalance.RechargeRequstConfirmed.HasValue && rechargeBalance.RechargeRequstConfirmed.Value)
            {
                return ActionResult.Error(ApiMessages.InvalidRequest);
            }

            Company company = await _context.Companies.FindAsync(rechargeBalance.CompanyId);
            
            if(company == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            
            var petroPayAccount = await
                _context.PetropayAccounts.FirstOrDefaultAsync(w =>
                    w.AccName == rechargeBalance.RechargePaymentMethod);
                
            if(petroPayAccount == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);

            /*if(petroPayAccount.AccBalance < rechargeBalance.RechargeAmount)
                return ActionResult.Error(ApiMessages.NotEnoughBalance);*/
            
            await _context.ExecuteTransactionAsync(async () =>
            {
                var user = await _userService.GetCurrentUserInfo();
                company.CompanyBalnce += rechargeBalance.RechargeAmount ?? 0;
                petroPayAccount.AccBalance -= rechargeBalance.RechargeAmount ?? 0;

                rechargeBalance.RechargeRequstConfirmed = true;
                var decreaseAccount = new TransAccount()
                {
                    AccountId = petroPayAccount.AccountId,
                    TransAmount = -1 * (rechargeBalance.RechargeAmount),
                    TransDocument = "Company Recharge Balance",
                    TransDate = DateTime.Now,
                    TransReference = (company.AccountId ?? 0).ToString()
                };
                
                if (user.Item1)
                {
                    decreaseAccount.UserId = user.Item2.Id;
                    decreaseAccount.UserName = user.Item2.Name;
                    decreaseAccount.UserType = user.Item2.Role.GetDisplayName();
                }
                await _context.TransAccounts.AddAsync(decreaseAccount);
                
                var increaseAccount = new TransAccount()
                {
                    AccountId = company.AccountId,
                    TransAmount = rechargeBalance.RechargeAmount,
                    TransDocument = "Company Recharge Balance",
                    TransDate = DateTime.Now,
                    TransReference = (petroPayAccount.AccountId ?? 0).ToString()
                };
                
                if (user.Item1)
                {
                    increaseAccount.UserId = user.Item2.Id;
                    increaseAccount.UserName = user.Item2.Name;
                    increaseAccount.UserType = user.Item2.Role.GetDisplayName();
                }
                await _context.TransAccounts.AddAsync(increaseAccount);
                
                await _context.SaveChangesAsync();
            });
            return ActionResult.Ok(ApiMessages.RechargeBalanceMessage.ConfirmedSuccessfully);
        }
    }
}
