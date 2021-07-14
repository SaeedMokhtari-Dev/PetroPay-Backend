using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Edit
{
    [Route(Endpoints.ApiNewCustomerEdit)]
    [ApiExplorerSettings(GroupName = "NewCustomer")]
    [Authorize]
    public class NewCustomerEditController : ApiController<NewCustomerEditRequest>
    {
        public NewCustomerEditController(IApiRequestHandler<NewCustomerEditRequest> handler, IValidator<NewCustomerEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
