using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Delete
{
    public class NewCustomerDeleteHandler : ApiRequestHandler<NewCustomerDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public NewCustomerDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(NewCustomerDeleteRequest request)
        {
            NewCustomer newCustomer = await _context.NewCustomers
                .FindAsync(request.NewCustomerId);

            if (newCustomer == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.NewCustomers.Remove(newCustomer);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.NewCustomerMessage.DeletedSuccessfully);
        }
    }
}
