using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Neobank.Test.API.Models.Pesponses;
using Neobank.Test.API.Models.Pesponses.Base;

namespace Neobank.Test.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new ObjectResult(new ErrorResponse<object>()
                {
                    Body = context.ModelState.Select(x => new ValidationErrorResponse()
                    {
                        Field = x.Key,
                        Details = x.Value?.Errors.Select(e => e.ErrorMessage).FirstOrDefault()
                    }),
                    Message = "Validation error"
                });
            }
        }
    }
}
