using System.Security.Cryptography.Xml;
using _11._02._2022___WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _11._02._2022___WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[TypeFilter(typeof(AuthenticationFilterAttribute))]
public class SolutionsController : ControllerBase
{
    [HttpGet]
    public IActionResult Calculation(int n, int k)
    {
        return Ok(Solve(n, k));
    }

    private int Solve(int n, int k)
    {
        var count = 0;

        for (var i = 1; i <= n; i++)
        {
            count += CountNumber(i, k);
        }

        return count;
    }

    private int CountNumber(int n, int k)
    {
        var count = 0;

        while (n > 0)
        {
            if (n % 10 == k)
                count++;
            
            n /= 10;
        }

        return count;
    }
}