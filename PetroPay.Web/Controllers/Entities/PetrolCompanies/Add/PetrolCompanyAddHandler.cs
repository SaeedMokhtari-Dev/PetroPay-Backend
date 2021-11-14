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

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Add
{
    public class PetrolCompanyAddHandler : ApiRequestHandler<PetrolCompanyAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public PetrolCompanyAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetrolCompanyAddRequest request)
        {
            var isUsernameDuplicate =
                _context.PetrolCompanies.Any(w => w.PetrolCompanyAdminUserName.Trim().ToUpper() == request.PetrolCompanyAdminUserName.Trim().ToUpper());
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }

            var isEmailDuplicate =
                _context.PetrolCompanies.Any(w => w.PetrolCompanyAdminEmail.Trim().ToUpper() == request.PetrolCompanyAdminEmail.Trim().ToUpper());
            if (isEmailDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateEmail);
            }

            PetrolCompany petrolCompany = await AddPetrolCompany(request);
            
            return ActionResult.Ok(ApiMessages.PetrolCompanyMessage.AddedSuccessfully);
        }
        
        private async Task<PetrolCompany> AddPetrolCompany(PetrolCompanyAddRequest request)
        {
            PetrolCompany petrolCompany = await _context.ExecuteTransactionAsync(async () =>
            {
                PetrolCompany newPetrolCompany = _mapper.Map<PetrolCompany>(request);

                if (!string.IsNullOrEmpty(request.PetrolCompanyCommercialPhoto))
                {
                    request.PetrolCompanyCommercialPhoto =
                        request.PetrolCompanyCommercialPhoto.Remove(0, request.PetrolCompanyCommercialPhoto.IndexOf(',') + 1);
                    newPetrolCompany.PetrolCompanyCommercialPhoto =
                        request.PetrolCompanyCommercialPhoto.ToCharArray().Select(Convert.ToByte).ToArray();
                }

                AccountMaster accountMaster = new AccountMaster();
                accountMaster.AccountName = request.PetrolCompanyName;
                accountMaster.AccountTaype = "petrolCompany";

                newPetrolCompany.Account = accountMaster;
                
                newPetrolCompany = (await _context.PetrolCompanies.AddAsync(newPetrolCompany)).Entity;
                await _context.SaveChangesAsync();

                return newPetrolCompany;
            });
            return petrolCompany;
        }
    }
}