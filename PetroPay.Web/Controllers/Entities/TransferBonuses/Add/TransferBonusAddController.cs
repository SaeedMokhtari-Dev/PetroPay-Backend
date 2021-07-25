using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.TransferBonuses.Add
{
    [Route(Endpoints.ApiTransferBonusAdd)]
    [ApiExplorerSettings(GroupName = "TransferBonus")]
    [Authorize]
    public class TransferBonusAddController : ApiController<TransferBonusAddRequest>
    {
        public TransferBonusAddController(IApiRequestHandler<TransferBonusAddRequest> handler, IValidator<TransferBonusAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
