using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VacinaBtgApi.Exceptions;

namespace VacinaBtgApi.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException de)
            {
                context.Result = new ObjectResult(new { message = de.Message })
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
