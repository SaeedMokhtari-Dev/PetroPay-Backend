using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.TransferBalances.Add
{
    [Route(Endpoints.ApiTransferBalance)]
    [ApiExplorerSettings(GroupName = "TransferBalance")]
    [Authorize]
    public class TransferBalanceAddController : ApiController<TransferBalanceAddRequest>
    {
        public TransferBalanceAddController(IApiRequestHandler<TransferBalanceAddRequest> handler, IValidator<TransferBalanceAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
