using Microsoft.AspNetCore.Builder;

namespace ApiExceptions.Middlewares
{
    /// <summary>
    /// Custom Exception handler middleware extensions
    /// </summary>
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        /// <summary>
        /// Includes custom exception handler middleware to pipline
        /// </summary>
        /// <param name="builder">Application buider</param>
        /// <returns>Application buider</returns>
        public static IApplicationBuilder UseCustomExceptionHandler(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}