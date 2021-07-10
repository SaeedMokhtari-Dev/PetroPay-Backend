using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Add
{
    [Route(Endpoints.ApiEmplyeeAdd)]
    [ApiExplorerSettings(GroupName = "Emplyee")]
    [Authorize]
    public class EmplyeeAddController : ApiController<EmplyeeAddRequest>
    {
        public EmplyeeAddController(IApiRequestHandler<EmplyeeAddRequest> handler, IValidator<EmplyeeAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
