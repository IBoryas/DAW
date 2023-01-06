using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DAW.Common.Exceptions
{
    public class MyExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException notFound)
            {
                context.Result = new ObjectResult(notFound.Message) { StatusCode = (int)notFound.Code };
            }
        }
    }
}
