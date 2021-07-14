using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Edit
{
    public class NewCustomerEditHandler : ApiRequestHandler<NewCustomerEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public NewCustomerEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(NewCustomerEditRequest request)
        {
            NewCustomer editNewCustomer = await _context.NewCustomers
                .FindAsync(request.CustReqId);

            if (editNewCustomer == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditAuditingNewCustomerNewCustomerNewCustomer(editNewCustomer, request);
            return ActionResult.Ok(ApiMessages.NewCustomerMessage.EditedSuccessfully);
        }

        private async Task EditAuditingNewCustomerNewCustomerNewCustomer(NewCustomer editNewCustomer, NewCustomerEditRequest request)
        {
            _mapper.Map(request, editNewCustomer);
            await _context.SaveChangesAsync();
        }
    }
}