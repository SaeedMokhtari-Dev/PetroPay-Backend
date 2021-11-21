using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Extensions;
using PetroPay.Web.Identity.Contexts;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.TransferBalances.CarBatch
{
    public class TransferBalanceCarBatchHandler : ApiRequestHandler<TransferBalanceCarBatchRequest>
    {
        private readonly PetroPayContext _context;
        private readonly UserContext _userContext;
        private readonly UserService _userService;

        public TransferBalanceCarBatchHandler(
            PetroPayContext context, UserContext userContext, UserService userService)
        {
            _context = context;
            _userContext = userContext;
            _userService = userService;
        }

        protected override async Task<ActionResult> Execute(TransferBalanceCarBatchRequest request)
        {
            if(_userContext.Role != RoleType.Customer && _userContext.Role != RoleType.CustomerBranch)
                return ActionResult.Error(ApiMessages.Forbidden);

            
            Tuple<bool, string> result;
            
            result = await TransferBranchToCars(request);
            
            if(!result.Item1)
                return ActionResult.Error(result.Item2);
            
            return ActionResult.Ok(result.Item2);
        }
        private async Task<Tuple<bool, string>> TransferBranchToCars(TransferBalanceCarBatchRequest request)
        {
            var branch = await _context.CompanyBranches.SingleOrDefaultAsync(w => w.CompanyBranchId == request.BranchId);
            if (branch == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                    
            if(branch.CompanyBranchBalnce < request.CarAmounts.Sum(w => w.Amount))
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);
            
            foreach (var carAmount in request.CarAmounts)
            {
                var car = await _context.Cars.SingleOrDefaultAsync(w => w.CarId == carAmount.CarId);
                if (car == null)
                    return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);

                await _context.ExecuteTransactionAsync(async () =>
                {
                    var user = await _userService.GetCurrentUserInfo();
                    branch.CompanyBranchBalnce -= carAmount.Amount;
                    TransAccount deductFromBranchAccount = new TransAccount()
                    {
                        AccountId = branch.AccountId,
                        TransAmount = -1 * carAmount.Amount,
                        TransDate = DateTime.Now.GetEgyptDateTime(),
                        TransDocument = "Recharge Car Balance",
                        TransReference = car.AccountId.ToString()
                    };
                    
                    if (user.Item1)
                    {
                        deductFromBranchAccount.UserId = user.Item2.Id;
                        deductFromBranchAccount.UserName = user.Item2.Name;
                        deductFromBranchAccount.UserType = user.Item2.Role.GetDisplayName();
                    }
                    deductFromBranchAccount = (await _context.TransAccounts.AddAsync(deductFromBranchAccount)).Entity;
                    
                    car.CarBalnce += carAmount.Amount;
                    TransAccount addToCar = new TransAccount()
                    {
                        AccountId = car.AccountId,
                        TransAmount = carAmount.Amount,
                        TransDate = DateTime.Now.GetEgyptDateTime(),
                        TransDocument = "Recharge Car Balance",
                        TransReference = branch.AccountId.ToString()
                    };
                    
                    if (user.Item1)
                    {
                        addToCar.UserId = user.Item2.Id;
                        addToCar.UserName = user.Item2.Name;
                        addToCar.UserType = user.Item2.Role.GetDisplayName();
                    }
                    addToCar = (await _context.TransAccounts.AddAsync(addToCar)).Entity;
                    
                    await _context.SaveChangesAsync();
                });   
            }
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBalanceMessage.CarBatchedSuccessfully);
        }
    }
}
