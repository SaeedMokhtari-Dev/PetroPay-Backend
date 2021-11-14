using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Get
{
    public class PetrolCompanyGetHandler : ApiRequestHandler<PetrolCompanyGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetrolCompanyGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetrolCompanyGetRequest request)
        {
            var query = _context.PetrolCompanies.OrderBy(w => w.PetrolCompanyId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<PetrolCompanyGetResponseItem>>(result);

            PetrolCompanyGetResponse response = new PetrolCompanyGetResponse();
            response.TotalCount = await _context.PetrolCompanies.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
