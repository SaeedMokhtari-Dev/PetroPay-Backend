using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Bundles.Add
{
    public class BundleAddHandler : ApiRequestHandler<BundleAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public BundleAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(BundleAddRequest request)
        {
            Bundle bundle = await AddBundle(request);
            
            return ActionResult.Ok(ApiMessages.BundleMessage.AddedSuccessfully);
        }
        
        private async Task<Bundle> AddBundle(BundleAddRequest request)
        {
            Bundle bundle = await _context.ExecuteTransactionAsync(async () =>
            {
                int maxId = await _context.Bundles.MaxAsync(w => w.BundlesId);
                Bundle newBundle = _mapper.Map<Bundle>(request);
                newBundle.BundlesId = ++maxId;
                newBundle = (await _context.Bundles.AddAsync(newBundle)).Entity;
                await _context.SaveChangesAsync();

                return newBundle;
            });
            return bundle;
        }
    }
}