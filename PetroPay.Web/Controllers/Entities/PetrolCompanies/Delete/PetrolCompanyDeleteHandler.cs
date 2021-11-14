using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using TestScaffold.Models;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Delete
{
    public class PetrolCompanyDeleteHandler : ApiRequestHandler<PetrolCompanyDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public PetrolCompanyDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PetrolCompanyDeleteRequest request)
        {
            PetrolCompany petrolCompany = await _context.PetrolCompanies
                .FindAsync(request.PetrolCompanyId);

            if (petrolCompany == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.PetrolCompanies.Remove(petrolCompany);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.PetrolCompanyMessage.DeletedSuccessfully);
        }
    }
}
