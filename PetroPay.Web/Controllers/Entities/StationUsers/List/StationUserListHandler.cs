using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.StationUsers.List
{
    public class StationUserListHandler : ApiRequestHandler<StationUserListRequest>
    {
        private readonly PetroPayContext _context;
        
        public StationUserListHandler(
            PetroPayContext context)
        {
            _context = context;
        }

        protected override async Task<ActionResult> Execute(StationUserListRequest request)
        {
            var result = await _context.StationUsers
                .Select(w => new StationUserListResponseItem()
                {
                    Key = w.StationWorkerId,
                    Title = w.StationWorkerFname,
                    StationId = w.StationId ?? 0
                })
                .ToListAsync();

            return ActionResult.Ok(result);
        }
    }
}
