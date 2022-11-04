using System.Security.Claims;
using _3_11_2022_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace _3_11_2022_WebAPI.Filters
{
    public class AuthAttribute : IActionFilter
    {
        private readonly UsersService _usersService;
        public string Roles { get; set; }

        public AuthAttribute(UsersService usersService, string roles)
        {
            _usersService = usersService;
            Roles = roles;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey(HeaderNames.Authorization))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var authorization = context.HttpContext.Request.Headers[HeaderNames.Authorization];

            var user = _usersService.UsersStore.FirstOrDefault(u => u.Token == authorization);

            if (user == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!Roles.Contains(user.Role))
            {
                context.Result = new JsonResult(new { Error = "Access denied" });
                return;
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims);

            var principal = new ClaimsPrincipal(identity);

            context.HttpContext.User = principal;

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
