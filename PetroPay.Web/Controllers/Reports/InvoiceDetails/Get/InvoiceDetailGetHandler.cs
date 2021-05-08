using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Reports.InvoiceDetails.Get
{
    public class InvoiceDetailGetHandler : ApiRequestHandler<InvoiceDetailGetRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public InvoiceDetailGetHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(InvoiceDetailGetRequest request)
        {
            ViewInvoiceDetail invoiceSummary = await _context.ViewInvoiceDetails
                .FirstOrDefaultAsync(w => w.InvoiceId == request.InvoiceId);

            if (invoiceSummary == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            InvoiceDetailGetResponse response = _mapper.Map<InvoiceDetailGetResponse>(invoiceSummary);
            
            return ActionResult.Ok(response);
        }
    }
}
