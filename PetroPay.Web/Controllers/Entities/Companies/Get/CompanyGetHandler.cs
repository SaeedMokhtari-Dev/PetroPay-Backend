using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.Companies.Get
{
    public class CompanyGetHandler : ApiRequestHandler<CompanyGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public CompanyGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CompanyGetRequest request)
        {
            var query = _context.Companies.OrderBy(w => w.CompanyId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CompanyGetResponseItem>>(result);

            CompanyGetResponse response = new CompanyGetResponse();
            response.TotalCount = await _context.Companies.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
