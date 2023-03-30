using Microsoft.AspNetCore.Http;
using System.Net;

namespace InfrastructureLayer.InfrastructureOrMiddleWare
{
    public class MiddlewareException
    {
        //TODO: Add Logging
        private readonly RequestDelegate _next;

        public MiddlewareException(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            //If New Exception
                 /*catch (exceptionClass randomName)
                 *  await HandleExceptionAsync(httpContext, randomName);
                 */
            catch(ArgumentException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = exception switch
            {
                // exceptionclass => "the message"
                ArgumentException => new ErrorDetails { StatusCode = 422, Message = exception.Message },
                _ => new ErrorDetails { StatusCode = 418, Message = "The teapot code + " + $"{exception.Message}" }
            };

            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
