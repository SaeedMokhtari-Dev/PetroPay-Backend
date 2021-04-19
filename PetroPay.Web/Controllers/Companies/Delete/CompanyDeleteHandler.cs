using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Companies.Delete
{
    public class CompanyDeleteHandler : ApiRequestHandler<CompanyDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public CompanyDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CompanyDeleteRequest request)
        {
            Company company = await _context.Companies
                .FindAsync(request.CompanyId);

            if (company == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.CompanyMessage.DeletedSuccessfully);
        }
    }
}
