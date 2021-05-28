using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Payment
{
    public class PetroStationPaymentHandler : ApiRequestHandler<PetroStationPaymentRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetroStationPaymentHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                
            var petropayAccount = await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccId == petroPayAccountId);
            if (petropayAccount == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            if(station.StationBalance < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);

            await _context.ExecuteTransactionAsync(async () =>
            {
                station.StationBalance -= amount;
                TransAccount deductFromStation = new TransAccount()
                {
                    AccountId = station.AccountId,
                    TransAmount = -1 * (amount),
                    TransDate = DateTime.Now,
                    TransDocument = "Petrol Station Payment",
                    TransReference = reference
                };
                deductFromStation = (await _context.TransAccounts.AddAsync(deductFromStation)).Entity;

                petropayAccount.AccBalance += amount;
                TransAccount addToPetropayAccount = new TransAccount()
                {
                    AccountId = petropayAccount.AccountId,
                    TransAmount = amount,
                    TransDate = DateTime.Now,
                    TransDocument = "Petrol Station Payment",
                    TransReference = reference
                };
                addToPetropayAccount = (await _context.TransAccounts.AddAsync(addToPetropayAccount)).Entity;
                
                await _context.SaveChangesAsync();
            });
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBalanceMessage.AddedSuccessfully);
        }
    }
}
