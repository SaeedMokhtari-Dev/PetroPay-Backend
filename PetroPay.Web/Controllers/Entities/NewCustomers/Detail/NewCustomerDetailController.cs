using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Detail
{
    [Route(Endpoints.ApiNewCustomerDetail)]
    [ApiExplorerSettings(GroupName = "NewCustomer")]
    [Authorize]
    public class NewCustomerDetailController : ApiController<NewCustomerDetailRequest>
    {
        public NewCustomerDetailController(IApiRequestHandler<NewCustomerDetailRequest> handler, IValidator<NewCustomerDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
