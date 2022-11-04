using _3_11_2022_WebAPI.Filters;
using _3_11_2022_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3_11_2022_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        //[Role("user")]
        [HttpGet]
        public IActionResult LCM1ToNumber(int number)
        {
            return Ok(CalculationsService.LCM1ToNumber(number));
        }
    }
}
