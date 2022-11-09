using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware_8_11.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
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
                await _next(httpContext);
            }
            catch (Exception e)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new { Error = e.Message });
            }
        }
    }
}
