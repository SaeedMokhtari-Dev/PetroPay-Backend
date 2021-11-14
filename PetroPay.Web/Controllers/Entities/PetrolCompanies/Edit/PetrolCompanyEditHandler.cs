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

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Edit
{
    public class PetrolCompanyEditHandler : ApiRequestHandler<PetrolCompanyEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public PetrolCompanyEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetrolCompanyEditRequest request)
        {
            PetrolCompany editPetrolCompany = await _context.PetrolCompanies
                .FindAsync(request.PetrolCompanyId);

            if (editPetrolCompany == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            var isUsernameDuplicate =
                _context.PetrolCompanies.Any(w => w.PetrolCompanyAdminUserName.Trim().ToUpper() == request.PetrolCompanyAdminUserName.Trim().ToUpper()
                                       && w.PetrolCompanyId != request.PetrolCompanyId);
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }

            var isEmailDuplicate =
                _context.PetrolCompanies.Any(w => w.PetrolCompanyAdminEmail.Trim().ToUpper() == request.PetrolCompanyAdminEmail.Trim().ToUpper()
                                       && w.PetrolCompanyId != request.PetrolCompanyId);
            if (isEmailDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateEmail);
            }

            await EditPetrolCompany(editPetrolCompany, request);
            return ActionResult.Ok(ApiMessages.PetrolCompanyMessage.EditedSuccessfully);
        }

        private async Task EditPetrolCompany(PetrolCompany editPetrolCompany, PetrolCompanyEditRequest request)
        {
            _mapper.Map(request, editPetrolCompany);

            request.PetrolCompanyCommercialPhoto =
                request.PetrolCompanyCommercialPhoto.Remove(0, request.PetrolCompanyCommercialPhoto.IndexOf(',') + 1);
            editPetrolCompany.PetrolCompanyCommercialPhoto =
                request.PetrolCompanyCommercialPhoto.ToCharArray().Select(Convert.ToByte).ToArray();

            await _context.SaveChangesAsync();
        }
    }
}