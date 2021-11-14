using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.ServiceMasters.List
{
    public class ServiceMasterListHandler : ApiRequestHandler<ServiceMasterListRequest>
    {
        private readonly PetroPayContext _context;

        public ServiceMasterListHandler(
            PetroPayContext context)
        {
            _context = context;
        }

        protected override async Task<ActionResult> Execute(ServiceMasterListRequest request)
        {
            var result = await _context.ServiceMasters
                .Select(w => new ServiceMasterListResponseItem()
                {
                    Key = w.ServiceId,
                    Title = w.ServiceEnDescription
                })
                .ToListAsync();

            return ActionResult.Ok(result);
        }
    }
}
