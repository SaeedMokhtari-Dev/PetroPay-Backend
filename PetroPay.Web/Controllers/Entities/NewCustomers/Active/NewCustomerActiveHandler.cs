using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Active
{
    public class NewCustomerActiveHandler : ApiRequestHandler<NewCustomerActiveRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public NewCustomerActiveHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(NewCustomerActiveRequest request)
        {
            NewCustomer newCustomer = await _context.NewCustomers
                .FindAsync(request.NewCustomerId);

            if (newCustomer == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            newCustomer.CustReqStatus = true;

            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.NewCustomerMessage.ActivatedSuccessfully);
        }
    }
}
