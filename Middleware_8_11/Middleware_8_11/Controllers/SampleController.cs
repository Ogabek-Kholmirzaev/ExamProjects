using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Middleware_8_11.Services;

namespace Middleware_8_11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Greeting()
        {
            return RequestCulture.RequestLanguage switch
            {
                "uz" => Ok("Salom!"),
                "en" => Ok("Hello!"),
                _ => throw new InvalidOperationException("We do not support this language yet!")
            };
        }
    }
}
