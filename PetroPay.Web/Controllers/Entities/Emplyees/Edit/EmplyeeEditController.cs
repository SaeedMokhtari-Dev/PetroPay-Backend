using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Edit
{
    [Route(Endpoints.ApiEmplyeeEdit)]
    [ApiExplorerSettings(GroupName = "Emplyee")]
    [Authorize]
    public class EmplyeeEditController : ApiController<EmplyeeEditRequest>
    {
        public EmplyeeEditController(IApiRequestHandler<EmplyeeEditRequest> handler, IValidator<EmplyeeEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
