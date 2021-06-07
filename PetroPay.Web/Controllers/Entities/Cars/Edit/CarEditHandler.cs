using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Cars.Edit
{
    public class CarEditHandler : ApiRequestHandler<CarEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public CarEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CarEditRequest request)
        {
            Car editCar = await _context.Cars
                .FindAsync(request.CarId);

            if (editCar == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            var isUsernameDuplicate =
                _context.Cars.Any(w => w.CarDriverUserName.Trim().ToUpper() == request.CarDriverUserName.Trim().ToUpper()
                                            && w.CarId != request.CarId);
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }

            var isEmailDuplicate =
                _context.Cars.Any(w => w.CarDriverEmail.Trim().ToUpper() == request.CarDriverEmail.Trim().ToUpper()
                                            && w.CarId != request.CarId);
            if (isEmailDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateEmail);
            }

            await EditCar(editCar, request);
            return ActionResult.Ok(ApiMessages.CarMessage.EditedSuccessfully);
        }

        private async Task EditCar(Car editCar, CarEditRequest request)
        {
            _mapper.Map(request, editCar);

            await _context.SaveChangesAsync();
        }
    }
}