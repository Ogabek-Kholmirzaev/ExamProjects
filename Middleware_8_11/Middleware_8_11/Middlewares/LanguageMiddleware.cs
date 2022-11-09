using RequestCulture = Middleware_8_11.Services.RequestCulture;

namespace Middleware_8_11.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.ContainsKey("Language"))
            {
                throw new Exception("Language header missed!");
            }

            RequestCulture.RequestLanguage = httpContext.Request.Headers["Language"];

            return _next(httpContext);
        }
    }
}
