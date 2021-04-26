using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Cars.Delete
{
    public class CarDeleteHandler : ApiRequestHandler<CarDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public CarDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CarDeleteRequest request)
        {
            Car car = await _context.Cars
                .FindAsync(request.CarId);

            if (car == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.CarMessage.DeletedSuccessfully);
        }
    }
}
