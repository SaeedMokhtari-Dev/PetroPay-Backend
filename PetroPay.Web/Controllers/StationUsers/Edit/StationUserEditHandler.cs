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

            /*var isEmailDuplicate =
                _context.StationUsers.Any(w => w.Email.Trim().ToUpper() == request.Email.Trim().ToUpper()
                                       && w.Id != request.StationUserId);
            if (isEmailDuplicate)
            {
                return ActionResult.Error(ApiMessages.StationUser.EmailIsDuplicate);
            }*/

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