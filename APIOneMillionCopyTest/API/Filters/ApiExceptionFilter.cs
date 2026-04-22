using APIOneMillionCopyTest.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIOneMillionCopyTest.API.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is EmailAlreadyExistsException emailException)
            {
                context.Result = new ConflictObjectResult(new ProblemDetails
                {
                    Title = "Another lead with same Email already exists",
                    Detail = emailException.Message,
                    Status = StatusCodes.Status409Conflict
                });

                context.ExceptionHandled = true;
                return;
            }

            if (context.Exception is FuenteNoValidException fuenteException)
            {
                context.Result = new ConflictObjectResult(new ProblemDetails
                {
                    Title = "Fuente no valid",
                    Detail = fuenteException.Message,
                    Status = StatusCodes.Status409Conflict
                });

                context.ExceptionHandled = true;
                return;
            }
        }
    }
}
