using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.ServiceMasters.List
{
    [Route(Endpoints.ApiServiceMasterList)]
    [ApiExplorerSettings(GroupName = "ServiceMaster")]
    public class ServiceMasterListController : ApiController<ServiceMasterListRequest>
    {
        public ServiceMasterListController(IApiRequestHandler<ServiceMasterListRequest> handler, IValidator<ServiceMasterListRequest> validator) : base(handler, validator)
        {
        }
    }
}
