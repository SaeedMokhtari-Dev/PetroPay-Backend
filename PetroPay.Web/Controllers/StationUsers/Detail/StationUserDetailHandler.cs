using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.StationUsers.Detail
{
    public class StationUserDetailHandler : ApiRequestHandler<StationUserDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public StationUserDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(StationUserDetailRequest request)
        {
            StationUser stationUser = await _context.StationUsers
                .FindAsync(request.StationWorkerId);

            if (stationUser == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            StationUserDetailResponse response = _mapper.Map<StationUserDetailResponse>(stationUser);
            
            return ActionResult.Ok(response);
        }
    }
}
