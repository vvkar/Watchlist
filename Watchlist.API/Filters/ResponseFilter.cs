using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Watchlist.API.Models.Pesponses.Base;

namespace Watchlist.API.Filters
{
    public class ResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is OkObjectResult result)
                context.Result = new OkObjectResult(new SuccessResponse<object>()
                {
                    Body = result.Value
                });
            else if (context.Result is OkResult)
                context.Result = new OkObjectResult(new SuccessResponse<object>());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
