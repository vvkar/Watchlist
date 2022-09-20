using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Neobank.Test.API.Models.Pesponses.Base;

namespace Neobank.Test.API.Filters
{
    public class ResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Result is OkObjectResult result)
                context.Result = new OkObjectResult(new SuccessResponse(result.Value));
            
            else if (context.Result is OkResult)
                context.Result = new OkObjectResult(new SuccessResponse());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
