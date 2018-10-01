using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace BookMyRoom
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
      

        public override void OnException(HttpActionExecutedContext actionExecutedContext)

        {

            HttpStatusCode status = HttpStatusCode.InternalServerError;

        String message = String.Empty;

        var exceptionType = actionExecutedContext.Exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))

            {

                message = "Access to the Web API is not authorized.";

                status = HttpStatusCode.Unauthorized;

            }

            else if (exceptionType == typeof(DivideByZeroException))

            {

                message = "Internal Server Error.";

                status = HttpStatusCode.InternalServerError;

            }
            else if(exceptionType==typeof(ArgumentNullException))
            {
                message = "Null values are passed";
                status = HttpStatusCode.Conflict;
            }
            else 

            {

                message = "Not found.";

                status = HttpStatusCode.NotFound;

            }

            actionExecutedContext.Response = new HttpResponseMessage()

            {

                // Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                // Content = new StringContent(string.Format(message)),
                Content = new StringContent(actionExecutedContext.Exception.Message),
                ReasonPhrase = message,
               

                StatusCode = status

            };

            base.OnException(actionExecutedContext);

        }
    }
}