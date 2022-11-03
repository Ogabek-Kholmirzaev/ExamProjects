using Masala2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Masala2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Result : ControllerBase
    {
        [HttpGet]
        public IActionResult Calculation(int input1, int input2)
        {
            if (input1 > input2)
            {
                return NotFound("Input error!");
            }

            var sum = 0;
            for (var i = input1; i <= input2; i++)
                sum += i;

            var log = new Log()
            {
                Input1 = input1.ToString(),
                Input2 = input2.ToString(),
                Output = sum.ToString(),
                Date = DateTime.Now
            };

            var path = Path.Combine(Directory.GetCurrentDirectory(), @"json.txt");
            var msg = System.IO.File.ReadAllText(path);

            System.IO.File.WriteAllText(path, msg + JsonConvert.SerializeObject(log));

            return Ok(sum);
        }

    }
}
