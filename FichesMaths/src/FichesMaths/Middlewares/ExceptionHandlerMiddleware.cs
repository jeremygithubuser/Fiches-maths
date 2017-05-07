using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace FichesMaths.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

                try
                {
                    Trace.WriteLine($"Exception message: {ex.Message}");
                    Trace.WriteLine($"Exception stack Trace: {ex.StackTrace}");
                }
                catch (Exception)
                {
                    // Missing Logger
                }
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync(HttpStatusCode.InternalServerError.ToString()).ConfigureAwait(false);
            }

        }

    }
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
