using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Get
{
    public class NewCustomerGetHandler : ApiRequestHandler<NewCustomerGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public NewCustomerGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(NewCustomerGetRequest request)
        {
            var query = _context.NewCustomers.OrderByDescending(w => w.CustReqId)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<NewCustomerGetResponseItem>>(result);

            NewCustomerGetResponse response = new NewCustomerGetResponse();
            response.TotalCount = await _context.NewCustomers.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
