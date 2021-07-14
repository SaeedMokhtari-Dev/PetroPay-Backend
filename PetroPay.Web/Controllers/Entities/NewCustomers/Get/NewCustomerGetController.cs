using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Get
{
    [Route(Endpoints.ApiNewCustomerGet)]
    [ApiExplorerSettings(GroupName = "NewCustomer")]
    [Authorize]
    public class NewCustomerGetController : ApiController<NewCustomerGetRequest>
    {
        public NewCustomerGetController(IApiRequestHandler<NewCustomerGetRequest> handler, IValidator<NewCustomerGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
