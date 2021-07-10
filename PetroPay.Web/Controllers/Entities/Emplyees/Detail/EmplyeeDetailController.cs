using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Detail
{
    [Route(Endpoints.ApiEmplyeeDetail)]
    [ApiExplorerSettings(GroupName = "Emplyee")]
    [Authorize]
    public class EmplyeeDetailController : ApiController<EmplyeeDetailRequest>
    {
        public EmplyeeDetailController(IApiRequestHandler<EmplyeeDetailRequest> handler, IValidator<EmplyeeDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
