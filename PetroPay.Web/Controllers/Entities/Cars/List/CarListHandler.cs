using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.Cars.List
{
    public class CarListHandler : ApiRequestHandler<CarListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public CarListHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CarListRequest request)
        {
            var query = _context.Cars
                .Where(e => e.CompanyBarnchId.HasValue && e.CompanyBarnch.CompanyId.HasValue && e.CompanyBarnch.CompanyId.Value == request.CompanyId)
                .OrderBy(w => w.CarId)
                .AsQueryable();

            var result = await query.Select(w => new CarListResponse()
            {
                Key = w.CarId,
                Title = w.CarIdNumber
            }).ToListAsync();
            
            return ActionResult.Ok(result);
        }
    }
}
