using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PolicyCors1011.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Policy = "GetDataByPolicy")]
        public Task<IActionResult> GetDataByPolicy() => Task.FromResult<IActionResult>(Ok("Congratulations!"));

        [HttpPost("signup")]
        public async Task<IActionResult> RegisterUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
                return BadRequest("Invalid input!");

            var user = new IdentityUser()
            {
                UserName = name,
            };

            await _userManager.CreateAsync(user, password);

            await _userManager.AddClaimsAsync(user, new List<Claim>()
            {
                new Claim("UserAge", "18"),
                new Claim(ClaimTypes.Role, "User")
            });

            return Ok(User);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Login(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Invalid input!");

            var user = await _userManager.FindByNameAsync(name);

            if (user is null)
                return NotFound("User is not found!");

            await _signInManager.PasswordSignInAsync(user, password, true, false);

            return Ok(user);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok("Succcessfully signout!");
        }
    }
}
