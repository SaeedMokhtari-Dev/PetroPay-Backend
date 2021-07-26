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
using PetroPay.Web.Extensions;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Payment
{
    public class PetropayAccountPaymentHandler : ApiRequestHandler<PetropayAccountPaymentRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public PetropayAccountPaymentHandler(
            PetroPayContext context, IMapper mapper, UserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        protected override async Task<ActionResult> Execute(PetropayAccountPaymentRequest request)
        {
            Tuple<bool, string> result = await TransferPetropayAccountToPetroPayAccount(request.FromPetroPayAccountId, request.ToPetroPayAccountId, request.Amount,
                request.Reference);
            
            if(!result.Item1)
                return ActionResult.Error(result.Item2);

            return ActionResult.Ok(result.Item2);
        }
        private async Task<Tuple<bool, string>> TransferPetropayAccountToPetroPayAccount(int fromPetroPayAccountId, int toPetroPayAccountId, decimal amount, string reference)
        {
            var fromPetroPayAccount = await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccId == fromPetroPayAccountId);
            if (fromPetroPayAccount == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            var toPetropayAccount = await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccId == toPetroPayAccountId);
            if (toPetropayAccount == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            /*if(fromPetroPayAccount.AccBalance < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);*/

            await _context.ExecuteTransactionAsync(async () =>
            {
                var user = await _userService.GetCurrentUserInfo();
                
                fromPetroPayAccount.AccBalance -= amount;
                TransAccount deductFromStation = new TransAccount()
                {
                    AccountId = fromPetroPayAccount.AccountId,
                    TransAmount = -1 * (amount),
                    TransDate = DateTime.Now.GetEgyptDateTime(),
                    TransDocument = "PetroPay Transfer balance",
                    TransReference = reference
                };
                if (user.Item1)
                {
                    deductFromStation.UserId = user.Item2.Id;
                    deductFromStation.UserName = user.Item2.Name;
                    deductFromStation.UserType = user.Item2.Role.GetDisplayName();
                }
                deductFromStation = (await _context.TransAccounts.AddAsync(deductFromStation)).Entity;

                toPetropayAccount.AccBalance += amount;
                TransAccount addToPetropayAccount = new TransAccount()
                {
                    AccountId = toPetropayAccount.AccountId,
                    TransAmount = amount,
                    TransDate = DateTime.Now.GetEgyptDateTime(),
                    TransDocument = "PetroPay Transfer balance",
                    TransReference = reference
                };
                if (user.Item1)
                {
                    addToPetropayAccount.UserId = user.Item2.Id;
                    addToPetropayAccount.UserName = user.Item2.Name;
                    addToPetropayAccount.UserType = user.Item2.Role.GetDisplayName();
                }
                addToPetropayAccount = (await _context.TransAccounts.AddAsync(addToPetropayAccount)).Entity;
                
                await _context.SaveChangesAsync();
            });
            
            return new Tuple<bool, string>(true, ApiMessages.PetropayAccountMessage.AddedSuccessfully);
        }
    }
}
