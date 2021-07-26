using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.CustomerStatements.Get
{
    [Route(Endpoints.ApiCustomerStatementGet)]
    [ApiExplorerSettings(GroupName = "CustomerStatement")]
    [Authorize]
    public class CustomerStatementGetController : ApiController<CustomerStatementGetRequest>
    {
        public CustomerStatementGetController(IApiRequestHandler<CustomerStatementGetRequest> handler, IValidator<CustomerStatementGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
