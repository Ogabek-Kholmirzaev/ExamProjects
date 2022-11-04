using _3_11_2022_WebAPI.Entities;
using _3_11_2022_WebAPI.Models;
using _3_11_2022_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _3_11_2022_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataService _dataService;
        private readonly UsersService _usersService;

        public UsersController(DataService dataService, UsersService usersService)
        {
            _dataService = dataService;
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult UserRegister(CreateUserModel createUserModel)
        {
            var user = new UserEntity
            {
                Name = createUserModel.Name,
                Role = createUserModel.Role,
                Email = createUserModel.Email,
                Token = Guid.NewGuid().ToString()
            };

            _usersService.UsersStore.Add(user);

            System.IO.File.WriteAllText(
                Path.Combine(Directory.GetCurrentDirectory(), _dataService.GetFileName()),
                JsonConvert.SerializeObject(_usersService.UsersStore));

            return Ok(user.Token);
        }

        [HttpGet("GetJsonFileName")]
        public IActionResult GetFileName() => Ok(_dataService.GetFileName());
    }
}
