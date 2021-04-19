using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PetroPay.Core.Api.Exceptions;
using PetroPay.Core.Api.Models;
using ActionResult = PetroPay.Core.Api.Models.ActionResult;

namespace PetroPay.Core.Api.Handlers
{
    public abstract class ApiRequestHandler<T>: IApiRequestHandler<T>
    {
        // ReSharper disable once StaticMemberInGenericType
        protected static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        static ApiRequestHandler()
        {
            LogManager.AddHiddenAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<IActionResult> Handle(T request)
        {
            try
            {
                var result = await Execute(request);

                return ApiResponse.Result(result);
            }
            catch (ApiException ex)
            {
                Logger.Error(ex);
                return ApiResponse.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ApiResponse.Error();
            }
        }

        protected abstract Task<ActionResult> Execute(T request);
    }
}
