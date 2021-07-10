using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Delete
{
    public class EmplyeeDeleteHandler : ApiRequestHandler<EmplyeeDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public EmplyeeDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(EmplyeeDeleteRequest request)
        {
            Emplyee emplyee = await _context.Emplyees
                .FindAsync(request.EmplyeesId);

            if (emplyee == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.Emplyees.Remove(emplyee);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.EmplyeeMessage.DeletedSuccessfully);
        }
    }
}
