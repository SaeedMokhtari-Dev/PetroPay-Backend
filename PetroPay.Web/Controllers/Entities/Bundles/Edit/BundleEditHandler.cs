using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Bundles.Edit
{
    public class BundleEditHandler : ApiRequestHandler<BundleEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public BundleEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BundleEditRequest request)
        {
            Bundle editBundle = await _context.Bundles
                .FindAsync(request.BundlesId);

            if (editBundle == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditAuditingBundleBundleBundle(editBundle, request);
            return ActionResult.Ok(ApiMessages.BundleMessage.EditedSuccessfully);
        }

        private async Task EditAuditingBundleBundleBundle(Bundle editBundle, BundleEditRequest request)
        {
            _mapper.Map(request, editBundle);
            await _context.SaveChangesAsync();
        }
    }
}