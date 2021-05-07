using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Cars.Active
{
    public class CarActiveHandler : ApiRequestHandler<CarActiveRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public CarActiveHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CarActiveRequest request)
        {
            Car car = await _context.Cars
                .FindAsync(request.CarId);

            if (car == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            car.CarWorkWithApproval = true;
            car.CarApprovedOneTime = true;
            car.CarNfcCode = request.CarNfcCode;

            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.CarMessage.ActivatedSuccessfully);
        }
    }
}
