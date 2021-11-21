using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.TransferBalances.CarBatch
{
    [Route(Endpoints.ApiTransferBalanceCarBatch)]
    [ApiExplorerSettings(GroupName = "TransferBalance")]
    [Authorize]
    public class TransferBalanceCarBatchController : ApiController<TransferBalanceCarBatchRequest>
    {
        public TransferBalanceCarBatchController(IApiRequestHandler<TransferBalanceCarBatchRequest> handler, IValidator<TransferBalanceCarBatchRequest> validator) : base(handler, validator)
        {
        }
    }
}
