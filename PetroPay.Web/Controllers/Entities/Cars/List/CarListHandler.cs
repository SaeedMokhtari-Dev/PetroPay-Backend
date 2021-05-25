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

namespace PetroPay.Web.Controllers.Entities.Cars.List
{
    public class CarListHandler : ApiRequestHandler<CarListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarListRequest request)
        {
            if(_userContext.Role == RoleType.Customer && !request.CompanyId.HasValue)
                request.CompanyId = _userContext.Id;
            
            var query = _context.Cars.Include(w => w.CompanyBarnch)
                .OrderBy(w => w.CarId)
                .AsQueryable();

            if (request.CompanyId.HasValue)
                query = query.Where(w =>
                    w.CompanyBarnchId.HasValue && w.CompanyBarnch.CompanyId == request.CompanyId.Value);
            
            var result = await query.Select(w => new CarListResponse()
            {
                Key = w.CarId,
                CarNumber = w.CarIdNumber,
                BranchName = w.CompanyBarnch.CompanyBranchName
            }).ToListAsync();
            
            return ActionResult.Ok(result);
        }
    }
}
