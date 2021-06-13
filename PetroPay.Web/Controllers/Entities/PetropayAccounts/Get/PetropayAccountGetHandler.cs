using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Get
{
    public class PetropayAccountGetHandler : ApiRequestHandler<PetropayAccountGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetropayAccountGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetropayAccountGetRequest request)
        {
            var petropayAccounts = await _context.PetropayAccounts
                .Select(w => w.AccountId).ToListAsync();
            var query = _context.TransAccounts.Include(w => w.Account)
                .Where(w => petropayAccounts.Contains(w.AccountId)).OrderByDescending(w => w.TransId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<PetropayAccountGetResponseItem>>(result);

            PetropayAccountGetResponse response = new PetropayAccountGetResponse();
            response.TotalCount = await _context.PetropayAccounts.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
