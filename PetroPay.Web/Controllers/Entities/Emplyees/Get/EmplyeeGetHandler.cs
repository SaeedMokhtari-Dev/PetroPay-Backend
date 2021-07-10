using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Get
{
    public class EmplyeeGetHandler : ApiRequestHandler<EmplyeeGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public EmplyeeGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(EmplyeeGetRequest request)
        {
            var query = _context.Emplyees.OrderBy(w => w.EmplyeeId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<EmplyeeGetResponseItem>>(result);

            EmplyeeGetResponse response = new EmplyeeGetResponse();
            response.TotalCount = await _context.Emplyees.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
