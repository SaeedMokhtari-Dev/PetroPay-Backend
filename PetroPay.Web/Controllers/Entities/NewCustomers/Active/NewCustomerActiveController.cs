using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Active
{
    [Route(Endpoints.ApiNewCustomerActive)]
    [ApiExplorerSettings(GroupName = "NewCustomer")]
    [Authorize]
    public class NewCustomerActiveController : ApiController<NewCustomerActiveRequest>
    {
        public NewCustomerActiveController(IApiRequestHandler<NewCustomerActiveRequest> handler, IValidator<NewCustomerActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
