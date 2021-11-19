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

namespace PetroPay.Web.Controllers.Entities.TransferBonuses.Add
{
    public class TransferBonusAddHandler : ApiRequestHandler<TransferBonusAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;
        private readonly UserService _userService;

        public TransferBonusAddHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext, UserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
            _userService = userService;
        }

        protected override async Task<ActionResult> Execute(TransferBonusAddRequest request)
        {
            if(_userContext.Role == RoleType.Customer)
                return ActionResult.Error(ApiMessages.Forbidden);

            if (_userContext.Role == RoleType.Supplier && !request.StationId.HasValue)
                request.StationId = _userContext.Id;

            if(!request.StationId.HasValue)
                return ActionResult.Error(ApiMessages.InvalidRequest);
            
            if (request.Amount <= 0)
                return ActionResult.Error(ApiMessages.TransferBonusMessage.AmountRequired);

            Tuple<bool, string> result = await TransferBonusToBalance(request.StationId.Value,
                request.StationWorkerId ?? 0, request.Amount);
            
            if(!result.Item1)
                return ActionResult.Error(result.Item2);
            
            return ActionResult.Ok(result.Item2);
        }

        private async Task<Tuple<bool, string>> TransferBonusToBalance(int stationId, int stationWorkerId, int amount)
        {
            var station = await _context.PetroStations.SingleOrDefaultAsync(w => w.StationId == stationId);
            if (station == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
                
            if(!station.StationBonusBalance.HasValue || station.StationBonusBalance < amount)
                return new Tuple<bool, string>(false, ApiMessages.NotEnoughBalance);

            var appSetting = await _context.AppSettings.FirstOrDefaultAsync();
            if(appSetting == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
            if(!appSetting.BonusMoneyRate.HasValue)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);

            decimal balance = (amount / (decimal) appSetting.BonusMoneyRate.Value);

            var petroPayAccount =
                await _context.PetropayAccounts.FirstOrDefaultAsync(
                    w => w.AccPetrolStationBonus.HasValue && w.AccPetrolStationBonus.Value);
            if(petroPayAccount == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);

            var stationUser =
                await _context.StationUsers.FirstOrDefaultAsync(w => w.StationWorkerId == stationWorkerId);
            if(stationUser == null)
                return new Tuple<bool, string>(false, ApiMessages.ResourceNotFound);
            
            await _context.ExecuteTransactionAsync(async () =>
            {
                var user = await _userService.GetCurrentUserInfo();
                petroPayAccount.AccBalance -= balance;
                station.StationBonusBalance -= amount;
                TransAccount deductFromPetroPayAccount = new TransAccount()
                {
                    AccountId = petroPayAccount.AccountId,
                    TransAmount = -1 * (balance),
                    TransDate = DateTime.Now.GetEgyptDateTime(),
                    TransDocument = "petrol station bonus transfer",
                    TransReference = $"transfer bonus {amount} point"
                };
                
                if (user.Item1)
                {
                    deductFromPetroPayAccount.UserId = user.Item2.Id;
                    deductFromPetroPayAccount.UserName = user.Item2.Name;
                    deductFromPetroPayAccount.UserType = user.Item2.Role.GetDisplayName();
                }
                deductFromPetroPayAccount = (await _context.TransAccounts.AddAsync(deductFromPetroPayAccount)).Entity;

                station.StationBalance += balance;
                TransAccount addToStationAccount = new TransAccount()
                {
                    AccountId = station.AccountId,
                    TransAmount = balance,
                    TransDate = DateTime.Now.GetEgyptDateTime(),
                    TransDocument = "petrol station bonus transfer",
                    TransReference = $"transfer bonus {amount} point"
                };
                
                if (user.Item1)
                {
                    addToStationAccount.UserId = user.Item2.Id;
                    addToStationAccount.UserName = user.Item2.Name;
                    addToStationAccount.UserType = user.Item2.Role.GetDisplayName();
                }
                addToStationAccount = (await _context.TransAccounts.AddAsync(addToStationAccount)).Entity;
                

                stationUser.WorkerBonusBalance += Convert.ToInt32(balance);
                
                await _context.SaveChangesAsync();
            });
            
            return new Tuple<bool, string>(true, ApiMessages.TransferBonusMessage.AddedSuccessfully);
        }
    }
}
