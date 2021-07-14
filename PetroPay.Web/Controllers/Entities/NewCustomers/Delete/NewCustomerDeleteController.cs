using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Delete
{
    [Route(Endpoints.ApiNewCustomerDelete)]
    [ApiExplorerSettings(GroupName = "NewCustomer")]
    [Authorize]
    public class NewCustomerDeleteController : ApiController<NewCustomerDeleteRequest>
    {
        public NewCustomerDeleteController(IApiRequestHandler<NewCustomerDeleteRequest> handler, IValidator<NewCustomerDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
