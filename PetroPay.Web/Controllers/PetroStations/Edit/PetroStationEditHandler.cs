using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.PetroStations.Edit
{
    public class PetroStationEditHandler : ApiRequestHandler<PetroStationEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public PetroStationEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetroStationEditRequest request)
        {
            PetroStation editPetroStation = await _context.PetroStations
                .FindAsync(request.StationId);

            if (editPetroStation == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditPetroStation(editPetroStation, request);
            return ActionResult.Ok(ApiMessages.PetroStationMessage.EditedSuccessfully);
        }

        private async Task EditPetroStation(PetroStation editPetroStation, PetroStationEditRequest request)
        {
            _mapper.Map(request, editPetroStation);

            await _context.SaveChangesAsync();
        }
    }
}