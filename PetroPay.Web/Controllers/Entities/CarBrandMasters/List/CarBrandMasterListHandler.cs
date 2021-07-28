using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.CarBrandMasters.List
{
    public class CarBrandMasterListHandler : ApiRequestHandler<CarBrandMasterListRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public CarBrandMasterListHandler(
            PetroPayContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(CarBrandMasterListRequest request)
        {
            var query = _context.CarBrandMasters.AsQueryable();

            var result = await query.Select(w => new CarBrandMasterListResponseItem()
                {
                    Key = w.CarBrandId,
                    TitleAr = w.CarBrandArName,
                    TitleEn = w.CarBrandEnName
                })
                .ToListAsync();

            return ActionResult.Ok(result);
        }
    }
}