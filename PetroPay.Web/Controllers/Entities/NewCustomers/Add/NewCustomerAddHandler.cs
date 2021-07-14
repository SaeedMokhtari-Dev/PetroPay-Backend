using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Add
{
    public class NewCustomerAddHandler : ApiRequestHandler<NewCustomerAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public NewCustomerAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(NewCustomerAddRequest request)
        {
            NewCustomer newCustomer = await AddNewCustomer(request);
            
            return ActionResult.Ok(ApiMessages.NewCustomerMessage.AddedSuccessfully);
        }
        
        private async Task<NewCustomer> AddNewCustomer(NewCustomerAddRequest request)
        {
            NewCustomer newCustomer = await _context.ExecuteTransactionAsync(async () =>
            {
                NewCustomer newNewCustomer = _mapper.Map<NewCustomer>(request);
                newNewCustomer = (await _context.NewCustomers.AddAsync(newNewCustomer)).Entity;
                await _context.SaveChangesAsync();

                return newNewCustomer;
            });
            return newCustomer;
        }
    }
}