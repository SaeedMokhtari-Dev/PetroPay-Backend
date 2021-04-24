using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.PetroStations.Delete
{
    public class PetroStationDeleteHandler : ApiRequestHandler<PetroStationDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetroStationDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetroStationDeleteRequest request)
        {
            PetroStation petroStation = await _context.PetroStations
                .FindAsync(request.StationId);

            if (petroStation == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.PetroStations.Remove(petroStation);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.PetroStationMessage.DeletedSuccessfully);
        }
    }
}
