using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.StationUsers.Delete
{
    public class StationUserDeleteHandler : ApiRequestHandler<StationUserDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public StationUserDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(StationUserDeleteRequest request)
        {
            StationUser stationUser = await _context.StationUsers
                .FindAsync(request.StationWorkerId);

            if (stationUser == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.StationUsers.Remove(stationUser);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.StationUserMessage.DeletedSuccessfully);
        }
    }
}
