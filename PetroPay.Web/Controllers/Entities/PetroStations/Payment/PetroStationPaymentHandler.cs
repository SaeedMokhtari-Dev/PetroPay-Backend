using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.OpenApi.Extensions;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Extensions;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Payment
{
    public class PetroStationPaymentHandler : ApiRequestHandler<PetroStationPaymentRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public PetroStationPaymentHandler(
            PetroPayContext context, IMapper mapper, UserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        protected override async Task<ActionResult> Execute(PetroStationPaymentRequest request)
        {
            Tuple<bool, string> result = await TransferPetroStationToPetroPayAccount(request.StationId, request.PetroPayAccountId, request.Amount,
                request.Reference);
            
            if(!result.Item1)
                return ActionResult.Error(result.Item2);

            return ActionResult.Ok(result.Item2);
        }
        private async Task<Tuple<bool, string>> TransferPetroStationToPetroPayAccount(int stationId, int petroPayAccountId, decimal amount, string reference)
        {
            var station = await _context.PetroStations.SingleOrDefaultAsync(w => w.StationId == stationId);
            if (station == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
            
            var petroCompany = await _context.PetrolCompanies.SingleOrDefaultAsync(w => w.PetrolCompanyId == station.PetrolCompanyId);
            
            var petropayAccount = await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccId == petroPayAccountId);
            if (petropayAccount == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            /*if(station.StationBalance < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);*/

            await _context.ExecuteTransactionAsync(async () =>
            {
                var user = await _userService.GetCurrentUserInfo();
                
                station.StationBalance -= amount;
                if (petroCompany != null)
                    petroCompany.PetrolCompanyBalnce -= amount;
                TransAccount deductFromStation = new TransAccount()
                {
                    AccountId = station.AccountId,
                    TransAmount = -1 * (amount),
                    TransDate = DateTime.Now.GetEgyptDateTime(),
                    TransDocument = "Petrol Station Payment",
                    TransReference = reference
                };
                
                if (user.Item1)
                {
                    deductFromStation.UserId = user.Item2.Id;
                    deductFromStation.UserName = user.Item2.Name;
                    deductFromStation.UserType = user.Item2.Role.GetDisplayName();
                }
                deductFromStation = (await _context.TransAccounts.AddAsync(deductFromStation)).Entity;

                petropayAccount.AccBalance += amount;
                TransAccount addToPetropayAccount = new TransAccount()
                {
                    AccountId = petropayAccount.AccountId,
                    TransAmount = amount,
                    TransDate = DateTime.Now.GetEgyptDateTime(),
                    TransDocument = "Petrol Station Payment",
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
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBalanceMessage.AddedSuccessfully);
        }
    }
}
