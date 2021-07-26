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
using PetroPay.Web.Extensions;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.Branches.ChargeBalance
{
    public class BranchChargeBalanceHandler : ApiRequestHandler<BranchChargeBalanceRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public BranchChargeBalanceHandler(
            PetroPayContext context, IMapper mapper, UserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
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
                var user = await _userService.GetCurrentUserInfo();
                company.CompanyBalnce -= request.IncreaseAmount;
                branch.CompanyBranchBalnce += request.IncreaseAmount;

                var decreaseAccount = new TransAccount()
                {
                    AccountId = company.AccountId,
                    TransAmount = -(request.IncreaseAmount),
                    TransDocument = "Transfer",
                    TransDate = DateTime.Now.GetEgyptDateTime(),
                    TransReference = branch.CompanyBranchId.ToString()
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
                    AccountId = branch.AccountId,
                    TransAmount = request.IncreaseAmount,
                    TransDocument = "Recharge",
                    TransDate = DateTime.Now.GetEgyptDateTime(),
                    TransReference = company.CompanyId.ToString()
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
            
            return ActionResult.Ok(ApiMessages.BranchMessage.BalanceIncreasedSuccessfully);
        }
    }
}
