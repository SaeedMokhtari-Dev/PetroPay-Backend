using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Detail
{
    public class NewCustomerDetailHandler : ApiRequestHandler<NewCustomerDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public NewCustomerDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(NewCustomerDetailRequest request)
        {
            NewCustomer newCustomer = await _context.NewCustomers
                .FindAsync(request.NewCustomerId);

            if (newCustomer == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            NewCustomerDetailResponse response = _mapper.Map<NewCustomerDetailResponse>(newCustomer);
            
            return ActionResult.Ok(response);
        }
    }
}
