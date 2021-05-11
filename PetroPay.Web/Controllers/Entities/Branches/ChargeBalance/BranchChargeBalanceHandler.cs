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

namespace PetroPay.Web.Controllers.Entities.Branches.ChargeBalance
{
    public class BranchChargeBalanceHandler : ApiRequestHandler<BranchChargeBalanceRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public BranchChargeBalanceHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BranchChargeBalanceRequest request)
        {
            CompanyBranch branch = await _context.CompanyBranches.Include(w => w.Account)
                .SingleOrDefaultAsync(w => w.CompanyBranchId == request.BranchId);

            if (branch == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            Company company = await _context.Companies.Include(w => w.Account)
                .SingleOrDefaultAsync(w => w.CompanyId == branch.CompanyId);
            if (company == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            if(request.IncreaseAmount > company.CompanyBalnce)
                return ActionResult.Error(ApiMessages.BranchMessage.IncreaseAmountCannotBeMoreThanBalance);

            await _context.ExecuteTransactionAsync(async () =>
            {
                company.CompanyBalnce -= request.IncreaseAmount;
                branch.CompanyBranchBalnce += request.IncreaseAmount;

                await _context.TransAccounts.AddAsync(new TransAccount()
                {
                    AccountId = company.AccountId,
                    TransAmount = -(request.IncreaseAmount),
                    TransDocument = "Transfer",
                    TransDate = DateTime.Now,
                    TransReference = branch.CompanyBranchId.ToString()
                });

                await _context.TransAccounts.AddAsync(new TransAccount()
                {
                    AccountId = branch.AccountId,
                    TransAmount = request.IncreaseAmount,
                    TransDocument = "Recharge",
                    TransDate = DateTime.Now,
                    TransReference = company.CompanyId.ToString()
                });

                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.BranchMessage.BalanceIncreasedSuccessfully);
        }
    }
}
