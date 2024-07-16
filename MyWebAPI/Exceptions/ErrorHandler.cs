using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyWebAPI.Exceptions.Model;
using System.Net;

namespace MyWebAPI.Exceptions
{
    public class ErrorHandler : ExceptionFilterAttribute
    {
        private readonly Dictionary<Type, (HttpStatusCode StatusCode, ErrorResponse ErrorResponse)> _exceptionHandlers;

        public ErrorHandler()
        {
            _exceptionHandlers = new Dictionary<Type, (HttpStatusCode, ErrorResponse)>
        {
            { typeof(Exception.PersonIdInvalid), (HttpStatusCode.NotFound, new ErrorResponse(100, "PERSON_ID_INVALID", "Please verify the ID, it does not meet the requirements")) },
            { typeof(Exception.PersonNotFound), (HttpStatusCode.NotFound, new ErrorResponse(150, "PERSON_NOT_FOUND", "Person not found, check if their ID is correct")) }
        };
        }
        public override void OnException(ExceptionContext context)
        {
            if (_exceptionHandlers.TryGetValue(context.Exception.GetType(), out var handler))
            {
                handler.ErrorResponse.Message = context.Exception.Message;
                context.HttpContext.Response.StatusCode = (int)handler.StatusCode;
                context.Result = new JsonResult(handler.ErrorResponse);
            }
            else
            {
                var genericErrorResponse = new ErrorResponse(500, "INTERNAL_SERVER_ERROR", "An unexpected error occurred.");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(genericErrorResponse);
            }

            base.OnException(context);
        }
    }
}
