using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.StationUsers.Add
{
    public class StationUserAddHandler : ApiRequestHandler<StationUserAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public StationUserAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(StationUserAddRequest request)
        {
            var isUsernameDuplicate =
                _context.StationUsers.Any(w => w.StationUserName.Trim().ToUpper() == request.StationUserName.Trim().ToUpper());
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }
            
            StationUser stationUser = await AddStationUser(request);
            
            return ActionResult.Ok(ApiMessages.StationUserMessage.AddedSuccessfully);
        }
        
        private async Task<StationUser> AddStationUser(StationUserAddRequest request)
        {
            StationUser stationUser = await _context.ExecuteTransactionAsync(async () =>
            {
                StationUser newStationUser = _mapper.Map<StationUser>(request);
                newStationUser.WorkerBonusBalance = 0;
                newStationUser = (await _context.StationUsers.AddAsync(newStationUser)).Entity;
                await _context.SaveChangesAsync();

                return newStationUser;
            });
            return stationUser;
        }
    }
}