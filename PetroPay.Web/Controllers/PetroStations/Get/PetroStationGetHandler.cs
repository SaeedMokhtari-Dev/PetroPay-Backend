using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.PetroStations.Get
{
    public class PetroStationGetHandler : ApiRequestHandler<PetroStationGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetroStationGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetroStationGetRequest request)
        {
            var query = _context.PetroStations
                .OrderBy(w => w.StationId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<PetroStationGetResponseItem>>(result);

            PetroStationGetResponse response = new PetroStationGetResponse();
            response.TotalCount = await _context.PetroStations.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
