using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.OdometerRecords.Get
{
    public class OdometerRecordGetHandler : ApiRequestHandler<OdometerRecordGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public OdometerRecordGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(OdometerRecordGetRequest request)
        {
            var query = _context.OdometerRecords
                .Include(w => w.Car)
                .OrderBy(w => w.OdometerRecordId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<OdometerRecordGetResponseItem>>(result);

            OdometerRecordGetResponse response = new OdometerRecordGetResponse();
            response.TotalCount = await _context.OdometerRecords.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
