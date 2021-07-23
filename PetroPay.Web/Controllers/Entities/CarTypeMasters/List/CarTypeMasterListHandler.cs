using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.CarTypeMasters.List
{
    public class CarTypeMasterListHandler : ApiRequestHandler<CarTypeMasterListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarTypeMasterListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarTypeMasterListRequest request)
        {
            var query = _context.CarTypeMasters.AsQueryable();

            var result = await query.Select(w => new CarTypeMasterListResponseItem()
                {
                    Key = w.CarTypeId,
                    Title = w.CarTypeName,
                    Balance = w.CarBonusPoint ?? 0
                })
                .ToListAsync();

            return ActionResult.Ok(result);
        }
    }
}