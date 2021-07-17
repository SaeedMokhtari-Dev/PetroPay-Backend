using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Dashboards.Supplier.Get
{
    [Route(Endpoints.ApiDashboardSupplierGet)]
    [ApiExplorerSettings(GroupName = "Supplier")]
    [Authorize]
    public class SupplierGetController : ApiController<SupplierGetRequest>
    {
        public SupplierGetController(IApiRequestHandler<SupplierGetRequest> handler, IValidator<SupplierGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
