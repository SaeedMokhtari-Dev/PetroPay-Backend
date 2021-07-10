using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Get
{
    [Route(Endpoints.ApiEmplyeeGet)]
    [ApiExplorerSettings(GroupName = "Emplyee")]
    [Authorize]
    public class EmplyeeGetController : ApiController<EmplyeeGetRequest>
    {
        public EmplyeeGetController(IApiRequestHandler<EmplyeeGetRequest> handler, IValidator<EmplyeeGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
