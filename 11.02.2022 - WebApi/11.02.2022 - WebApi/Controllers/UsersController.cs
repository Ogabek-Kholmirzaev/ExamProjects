using _11._02._2022___WebApi.Data;
using _11._02._2022___WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _11._02._2022___WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult UserSignUp(UserDto userDto)
        {
            var key = Guid.NewGuid().ToString();
            
            var user = new User()
            {
                Key = key,
                Name = userDto.Name,
                Password = userDto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}
