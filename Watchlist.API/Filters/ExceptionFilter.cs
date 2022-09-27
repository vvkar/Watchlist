using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Watchlist.API.Models.Pesponses.Base;
using Watchlist.Domain.Core.Exceptions;

namespace Watchlist.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        public ExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            //TODO: Consider use environment to fill 500 error
            context.Result = new ObjectResult(new ErrorResponse<object>()
            {
                Message = context.Exception.Message,
            });

            if (context.Exception is BadRequestException || context.Exception is AlreadyAddedException)
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            else if (context.Exception is NotFoundException)
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            else context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
