using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Dashboards.Customers.Get
{
    [Route(Endpoints.ApiDashboardCustomerGet)]
    [ApiExplorerSettings(GroupName = "Customer")]
    [Authorize]
    public class CustomerGetController : ApiController<CustomerGetRequest>
    {
        public CustomerGetController(IApiRequestHandler<CustomerGetRequest> handler, IValidator<CustomerGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
