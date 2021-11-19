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
            var query = _context.StationUsers.AsQueryable();
            if (request.PetrolStationId.HasValue && request.PetrolStationId.Value > 0)
            {
                query = query.Where(w => w.StationId.HasValue && w.StationId.Value == request.PetrolStationId);
            }

            var result = await query
                .Select(w => new StationUserListResponseItem()
                {
                    Key = w.StationWorkerId,
                    Title = w.StationWorkerFname,
                    StationId = w.StationId ?? 0,
                    WorkerBonusBalance = w.WorkerBonusBalance ?? 0
                })
                .ToListAsync();

            return ActionResult.Ok(result);
        }
    }
}
