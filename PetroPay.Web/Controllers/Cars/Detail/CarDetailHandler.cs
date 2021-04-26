using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Cars.Detail
{
    public class CarDetailHandler : ApiRequestHandler<CarDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public CarDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CarDetailRequest request)
        {
            Car car = await _context.Cars
                .FindAsync(request.CarId);

            if (car == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            CarDetailResponse response = _mapper.Map<CarDetailResponse>(car);
            
            return ActionResult.Ok(response);
        }
    }
}
