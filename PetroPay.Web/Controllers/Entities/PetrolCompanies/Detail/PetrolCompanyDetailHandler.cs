using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using TestScaffold.Models;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Detail
{
    public class PetrolCompanyDetailHandler : ApiRequestHandler<PetrolCompanyDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetrolCompanyDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetrolCompanyDetailRequest request)
        {
            PetrolCompany petrolCompany = await _context.PetrolCompanies
                .FindAsync(request.PetrolCompanyId);

            if (petrolCompany == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            PetrolCompanyDetailResponse response = _mapper.Map<PetrolCompanyDetailResponse>(petrolCompany);
            
            if (petrolCompany.PetrolCompanyCommercialPhoto != null)
            {
                response.PetrolCompanyCommercialPhoto = $"data:image/png;base64,{String.Join("", petrolCompany.PetrolCompanyCommercialPhoto.Select(Convert.ToChar))}";
            }
            
            return ActionResult.Ok(response);
        }
    }
}
