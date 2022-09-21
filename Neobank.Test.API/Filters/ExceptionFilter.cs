using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Neobank.Test.API.Models.Pesponses.Base;
using Neobank.Test.Domain.Core.Exceptions;

namespace Neobank.Test.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new ErrorResponse<object>()
            {
                Message = context.Exception.Message,
            });

            if (context.Exception is BadRequestException)
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            else if(context.Exception is NotFoundException)
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            
            else context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
