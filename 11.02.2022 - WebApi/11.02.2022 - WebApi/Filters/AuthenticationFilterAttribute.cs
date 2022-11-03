using _11._02._2022___WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _11._02._2022___WebApi.Filters
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        private readonly AppDbContext _context;

        public AuthenticationFilterAttribute(AppDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Key"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var key = context.HttpContext.Request.Headers["Key"];

            if (!_context.Users.ToList().Exists(user=>user.Key == key))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
