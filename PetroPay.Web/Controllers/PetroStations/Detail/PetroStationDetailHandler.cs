using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.PetroStations.Detail
{
    public class PetroStationDetailHandler : ApiRequestHandler<PetroStationDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetroStationDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetroStationDetailRequest request)
        {
            PetroStation petroStation = await _context.PetroStations
                .FindAsync(request.StationId);

            if (petroStation == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            PetroStationDetailResponse response = _mapper.Map<PetroStationDetailResponse>(petroStation);
            
            return ActionResult.Ok(response);
        }
    }
}
