using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace ApiExceptions.Middlewares
{
    /// <summary>
    /// Custom exception handler middleware
    /// </summary>
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes class instance of <see cref="CustomExceptionHandlerMiddleware"/>
        /// </summary>
        /// <param name="next">Next middleware in pipeline</param>
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes next request in middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles exception during middleware
        /// </summary>
        /// <param name="context">Request context</param>
        /// <param name="exception">Exception while processing</param>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { message = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}