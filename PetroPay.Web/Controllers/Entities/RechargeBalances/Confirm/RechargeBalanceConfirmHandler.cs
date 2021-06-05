using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Confirm
{
    public class RechargeBalanceConfirmHandler : ApiRequestHandler<RechargeBalanceConfirmRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public RechargeBalanceConfirmHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            if(petroPayAccount.AccBalance < rechargeBalance.RechargeAmount)
                return ActionResult.Error(ApiMessages.NotEnoughBalance);
            
            await _context.ExecuteTransactionAsync(async () =>
            {
                company.CompanyBalnce += rechargeBalance.RechargeAmount ?? 0;
                petroPayAccount.AccBalance -= rechargeBalance.RechargeAmount ?? 0;

                rechargeBalance.RechargeRequstConfirmed = true;
                
                await _context.TransAccounts.AddAsync(new TransAccount()
                {
                    AccountId = petroPayAccount.AccountId,
                    TransAmount = -1 * (rechargeBalance.RechargeAmount),
                    TransDocument = "Company Recharge Balance",
                    TransDate = DateTime.Now,
                    TransReference = (company.AccountId ?? 0).ToString()
                });
                
                await _context.TransAccounts.AddAsync(new TransAccount()
                {
                    AccountId = company.AccountId,
                    TransAmount = rechargeBalance.RechargeAmount,
                    TransDocument = "Company Recharge Balance",
                    TransDate = DateTime.Now,
                    TransReference = (petroPayAccount.AccountId ?? 0).ToString()
                });
                
                await _context.SaveChangesAsync();
            });
            return ActionResult.Ok(ApiMessages.RechargeBalanceMessage.ConfirmedSuccessfully);
        }
    }
}
