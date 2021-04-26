using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.PetroStations.Add
{
    public class PetroStationAddHandler : ApiRequestHandler<PetroStationAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public PetroStationAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetroStationAddRequest request)
        {
            var isUsernameDuplicate =
                _context.PetroStations.Any(w => w.StationUserName.Trim().ToUpper() == request.StationUserName.Trim().ToUpper());
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }
            
            PetroStation petroStation = await AddPetroStation(request);
            
            return ActionResult.Ok(ApiMessages.PetroStationMessage.AddedSuccessfully);
        }
        
        private async Task<PetroStation> AddPetroStation(PetroStationAddRequest request)
        {
            PetroStation petroStation = await _context.ExecuteTransactionAsync(async () =>
            {
                PetroStation newPetroStation = _mapper.Map<PetroStation>(request);

                int maxId = _context.PetroStations.Max(w => w.StationId);
                newPetroStation.StationId = ++maxId;
                
                AccountMaster accountMaster = new AccountMaster();
                accountMaster.AccountName = request.StationName;
                accountMaster.AccountTaype = "station";

                newPetroStation.Account = accountMaster;
                
                newPetroStation = (await _context.PetroStations.AddAsync(newPetroStation)).Entity;
                await _context.SaveChangesAsync();

                return newPetroStation;
            });
            return petroStation;
        }
    }
}