using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.CarModelMasters.List
{
    public class CarModelMasterListHandler : ApiRequestHandler<CarModelMasterListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarModelMasterListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarModelMasterListRequest request)
        {
            var query = _context.CarModelMasters.AsQueryable();

            var result = await query.Select(w => new CarModelMasterListResponseItem()
                {
                    Key = w.CarModelId,
                    TitleAr = w.CarModelArName,
                    TitleEn = w.CarModelEnName,
                    BrandId = w.CarBrandId ?? 0
                })
                .ToListAsync();

            return ActionResult.Ok(result);
        }
    }
}