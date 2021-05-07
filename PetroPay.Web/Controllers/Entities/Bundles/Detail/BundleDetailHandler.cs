using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Bundles.Detail
{
    public class BundleDetailHandler : ApiRequestHandler<BundleDetailRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public BundleDetailHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BundleDetailRequest request)
        {
            Bundle bundle = await _context.Bundles
                .FindAsync(request.BundlesId);

            if (bundle == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            BundleDetailResponse response = _mapper.Map<BundleDetailResponse>(bundle);
            
            return ActionResult.Ok(response);
        }
    }
}
