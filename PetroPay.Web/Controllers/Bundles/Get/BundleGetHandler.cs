using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Bundles.Get
{
    public class BundleGetHandler : ApiRequestHandler<BundleGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public BundleGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BundleGetRequest request)
        {
            var query = _context.Bundles.OrderBy(w => w.BundlesId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<BundleGetResponseItem>>(result);

            BundleGetResponse response = new BundleGetResponse();
            response.TotalCount = await _context.Bundles.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
