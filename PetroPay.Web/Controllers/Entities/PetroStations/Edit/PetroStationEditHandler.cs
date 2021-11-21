using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Edit
{
    public class PetroStationEditHandler : ApiRequestHandler<PetroStationEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;
        
        public PetroStationEditHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(PetroStationEditRequest request)
        {
            if (_userContext.Role == RoleType.Supplier && !request.PetrolCompanyId.HasValue)
                request.PetrolCompanyId = _userContext.Id;
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

            var isEmailDuplicate =
                _context.PetroStations.Any(w => w.StationEmail.Trim().ToUpper() == request.StationEmail.Trim().ToUpper()
                                            && w.StationId != request.StationId);
            if (isEmailDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateEmail);
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