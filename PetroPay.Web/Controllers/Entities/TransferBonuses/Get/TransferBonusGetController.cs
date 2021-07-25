using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.TransferBonuses.Get
{
    [Route(Endpoints.ApiTransferBonusGet)]
    [ApiExplorerSettings(GroupName = "TransferBonus")]
    [Authorize]
    public class TransferBonusGetController : ApiController<TransferBonusGetRequest>
    {
        public TransferBonusGetController(IApiRequestHandler<TransferBonusGetRequest> handler, IValidator<TransferBonusGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
