using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Bundles.Delete
{
    public class BundleDeleteHandler : ApiRequestHandler<BundleDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public BundleDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BundleDeleteRequest request)
        {
            Bundle bundle = await _context.Bundles
                .FindAsync(request.BundlesId);

            if (bundle == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            _context.Bundles.Remove(bundle);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.BundleMessage.DeletedSuccessfully);
        }
    }
}
