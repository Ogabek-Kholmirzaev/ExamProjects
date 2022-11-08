using _4._11._2022___WebApi.Data;
using _4._11._2022___WebApi.Entities;
using _4._11._2022___WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace _4._11._2022___WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly Jwt _jwt;
        private readonly AppDbContext _appDbContext;

        public UsersController(IOptions<Jwt> options, AppDbContext appDbContext)
        {
            _jwt = options.Value;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_appDbContext.Users.ToList());
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public IActionResult SignIn(SignInUserModel signInUserModel)
        {
            var usersDb = _appDbContext.Users.ToList();

            if(!usersDb.Any(user=>user.Email == signInUserModel.Email && user.Password == signInUserModel.Email))
            {
                return Unauthorized();
            }

            var keyByte = System.Text.Encoding.UTF8.GetBytes(_jwt.Key);
            var securityKey = new SigningCredentials(new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256);

            var security = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                new Claim[]
                {
                    new Claim(ClaimTypes.Email, signInUserModel.Email)
                },
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: securityKey);

            var token = new JwtSecurityTokenHandler().WriteToken(security);

            return Ok(token);
        }


        [HttpPost("SignUp")]
        [AllowAnonymous]
        public IActionResult SignUp(SignUpUserModel signUpUserModel)
        {
            var userDb = _appDbContext.Users.ToList();

            if(userDb.Any(u=>u.Email == signUpUserModel.Email))
            {
                return Conflict("Email has already registered!");
            }

            _appDbContext.Users.Add(new UserEntity
            {
                Name = signUpUserModel.Name,
                Email = signUpUserModel.Email,
                Password = signUpUserModel.Password
            });
            _appDbContext.SaveChanges();

            return Ok("Successfully registered.");
        }
    }
}
