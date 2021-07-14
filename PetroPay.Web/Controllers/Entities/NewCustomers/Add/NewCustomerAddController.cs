using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Add
{
    [Route(Endpoints.ApiNewCustomerAdd)]
    [ApiExplorerSettings(GroupName = "NewCustomer")]
    [Authorize]
    public class NewCustomerAddController : ApiController<NewCustomerAddRequest>
    {
        public NewCustomerAddController(IApiRequestHandler<NewCustomerAddRequest> handler, IValidator<NewCustomerAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
