using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.StationUsers.Edit
{
    public class StationUserEditHandler : ApiRequestHandler<StationUserEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public StationUserEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(StationUserEditRequest request)
        {
            StationUser editStationUser = await _context.StationUsers
                .FindAsync(request.StationWorkerId);

            if (editStationUser == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            var isUsernameDuplicate =
                _context.StationUsers.Any(w => w.StationUserName.Trim().ToUpper() == request.StationUserName.Trim().ToUpper()
                                            && w.StationWorkerId != request.StationWorkerId);
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }

            await EditStationUser(editStationUser, request);
            return ActionResult.Ok(ApiMessages.StationUserMessage.EditedSuccessfully);
        }

        private async Task EditStationUser(StationUser editStationUser, StationUserEditRequest request)
        {
            _mapper.Map(request, editStationUser);

            await _context.SaveChangesAsync();
        }
    }
}