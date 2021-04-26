using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Companies.Add
{
    public class CompanyAddHandler : ApiRequestHandler<CompanyAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public CompanyAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CompanyAddRequest request)
        {
            var isUsernameDuplicate =
                _context.Companies.Any(w => w.CompanyAdminUserName.Trim().ToUpper() == request.CompanyAdminUserName.Trim().ToUpper());
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }

            Company company = await AddCompany(request);
            
            return ActionResult.Ok(ApiMessages.CompanyMessage.AddedSuccessfully);
        }
        
        private async Task<Company> AddCompany(CompanyAddRequest request)
        {
            Company company = await _context.ExecuteTransactionAsync(async () =>
            {
                Company newCompany = _mapper.Map<Company>(request);
                
                if(!string.IsNullOrEmpty(request.CompanyCommercialPhoto))
                    newCompany.CompanyCommercialPhoto = request.CompanyCommercialPhoto.ToCharArray().Select(Convert.ToByte).ToArray();

                AccountMaster accountMaster = new AccountMaster();
                accountMaster.AccountName = request.CompanyName;
                accountMaster.AccountTaype = "company";

                newCompany.Account = accountMaster;
                
                newCompany = (await _context.Companies.AddAsync(newCompany)).Entity;
                await _context.SaveChangesAsync();

                return newCompany;
            });
            return company;
        }
    }
}