using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.PetroStations.List
{
    public class PetroStationListHandler : ApiRequestHandler<PetroStationListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public PetroStationListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(PetroStationListRequest request)
        {
            if (_userContext.Role == RoleType.Customer)
                return ActionResult.Error(ApiMessages.Forbidden);
            
            var query = _context.PetroStations
                .OrderBy(w => w.StationId)
                .AsQueryable();

            var response = await query.Select(w =>
            new PetroStationListResponseItem() {
                Key = w.StationId, 
                Title = w.StationName,
                Balance = w.StationBalance ?? 0,
                Bonus = w.StationBonusBalance ?? 0
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
