using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Companies.Detail
{
    public class CompanyDetailHandler : ApiRequestHandler<CompanyDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public CompanyDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CompanyDetailRequest request)
        {
            Company company = await _context.Companies
                .FindAsync(request.CompanyId);

            if (company == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            CompanyDetailResponse response = _mapper.Map<CompanyDetailResponse>(company);
            
            if (company.CompanyCommercialPhoto != null)
            {
                response.CompanyCommercialPhoto = String.Join("", company.CompanyCommercialPhoto.Select(Convert.ToChar));
            }
            
            return ActionResult.Ok(response);
        }
    }
}
