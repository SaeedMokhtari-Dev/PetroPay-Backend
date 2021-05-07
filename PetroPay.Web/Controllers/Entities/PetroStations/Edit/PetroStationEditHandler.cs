using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Edit
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
            
            
            var isUsernameDuplicate =
                _context.PetroStations.Any(w => w.StationUserName.Trim().ToUpper() == request.StationUserName.Trim().ToUpper()
                                            && w.StationId != request.StationId);
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
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