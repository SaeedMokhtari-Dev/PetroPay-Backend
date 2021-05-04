using System.Threading.Tasks;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Auth.GetUserInfo
{
    public class GetUserInfoHandler : ApiRequestHandler<GetUserInfoRequest>
    {
        private readonly PetroPayContext _context;
        private readonly UserContext _userContext;

        public GetUserInfoHandler(PetroPayContext context, UserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(GetUserInfoRequest request)
        {
            switch (_userContext.Role)
            {
                case  RoleType.Customer:
                    var customer = await _context.Companies.FindAsync(_userContext.Id);
                    if(customer != null)
                        return ActionResult.Ok(new GetUserInfoResponse()
                        {
                            Id = customer.CompanyId,
                            Name = customer.CompanyName,
                            Role = RoleType.Customer,
                            Balance =  customer.CompanyBalnce ?? 0
                        });
                    break;
                case RoleType.Supplier:
                    var supplier = await _context.PetroStations.FindAsync(_userContext.Id);
                    if(supplier != null)
                        return ActionResult.Ok(new GetUserInfoResponse(supplier.StationId, RoleType.Supplier, supplier.StationName, supplier.StationBalance ?? 0));
                    break;
                case RoleType.Admin:
                    var admin = await _context.Emplyees.FindAsync(_userContext.Id);
                    if(admin != null)
                        return ActionResult.Ok(new GetUserInfoResponse(admin.EmplyeeId, RoleType.Admin, admin.EmplyeeName, 0));
                    break;
            }
            return ActionResult.Error(ApiMessages.ResourceNotFound);
        }
    }
}
