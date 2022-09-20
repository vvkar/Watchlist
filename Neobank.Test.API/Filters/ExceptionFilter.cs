using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Neobank.Test.API.Models.Pesponses.Base;

namespace Neobank.Test.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;

            context.Result = new ObjectResult(new ErrorResponse(message));
        }
    }
}
