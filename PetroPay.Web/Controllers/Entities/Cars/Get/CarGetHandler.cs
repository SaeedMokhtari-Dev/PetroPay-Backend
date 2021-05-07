using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.Cars.Get
{
    public class CarGetHandler : ApiRequestHandler<CarGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public CarGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CarGetRequest request)
        {
            var query = _context.Cars
                .Where(e => e.CompanyBarnchId.HasValue && e.CompanyBarnchId.Value == request.CompanyBranchId)
                .OrderBy(w => w.CarId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CarGetResponseItem>>(result);

            CarGetResponse response = new CarGetResponse();
            response.TotalCount = await _context.Cars.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
