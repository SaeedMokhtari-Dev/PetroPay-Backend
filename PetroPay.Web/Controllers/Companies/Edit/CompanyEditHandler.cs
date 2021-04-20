using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Companies.Edit
{
    public class CompanyEditHandler : ApiRequestHandler<CompanyEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public CompanyEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CompanyEditRequest request)
        {
            Company editCompany = await _context.Companies
                .FindAsync(request.CompanyId);

            if (editCompany == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            /*var isEmailDuplicate =
                _context.Companys.Any(w => w.Email.Trim().ToUpper() == request.Email.Trim().ToUpper()
                                       && w.Id != request.CompanyId);
            if (isEmailDuplicate)
            {
                return ActionResult.Error(ApiMessages.Company.EmailIsDuplicate);
            }*/

            await EditCompany(editCompany, request);
            return ActionResult.Ok(ApiMessages.CompanyMessage.EditedSuccessfully);
        }

        private async Task EditCompany(Company editCompany, CompanyEditRequest request)
        {
            _mapper.Map(request, editCompany);

            if (request.IsCompanyCommercialPhotoChanged)
            {
                editCompany.CompanyCommercialPhoto =
                    request.CompanyCommercialPhoto.ToCharArray().Select(Convert.ToByte).ToArray();
            }

            await _context.SaveChangesAsync();
        }
    }
}