using Masala3.AppDbContext;
using Masala3.Entities;
using Masala3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Masala3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExamDbContext _context;

        public HomeController(ILogger<HomeController> logger, ExamDbContext examDbContext)
        {
            _logger = logger;
            _context = examDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(NumberDto numberDto)
        {
            if (!ModelState.IsValid)
            {
                return View(numberDto);
            }

            var number = int.Parse(numberDto.NumberFromInput);
            var dbNumber = _context.Numbers.FirstOrDefault(n => n.NumberInInteger == number);

            if (dbNumber == null)
            {
                _context.Numbers.Add(new Number() { NumberInInteger = number, NumberInString = NumberToWords(number) });
                _context.SaveChanges();
            }

            return RedirectToAction("ShowResult", "Home", _context.Numbers.First(n => n.NumberInInteger == number));
        }

        public IActionResult ShowResult(Number numberModel)
        {
            return View(numberModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Nol";
            }
            return ConvertNum(num);
        }

        public string ConvertNum(int num) => num switch
        {
            1 => "Bir",
            2 => "Ikki",
            3 => "Uch",
            4 => "To\'rt",
            5 => "Besh",
            6 => "Olti",
            7 => "Yetti",
            8 => "Sakkiz",
            9 => "To\'qqiz",
            10 => "O\'n",
            11 => "O\'n bir",
            12 => "O\'n ikki",
            13 => "O\'n uch",
            14 => "O\'n to\'rt",
            15 => "O\'n besh",
            16 => "O\'n olti",
            17 => "O\'n yetti",
            18 => "O\'n sakkiz",
            19 => "O\'n to\'qqiz",
            >= 20 and <= 29 => "Yigirma" + ((num % 10 == 0) ? "" : " " + ConvertNum(num % 10)),
            >= 30 and <= 39 => "O\'ttiz" + ((num % 10 == 0) ? "" : " " + ConvertNum(num % 10)),
            >= 40 and <= 49 => "Qirq" + ((num % 10 == 0) ? "" : " " + ConvertNum(num % 10)),
            >= 50 and <= 59 => "Ellik" + ((num % 10 == 0) ? "" : " " + ConvertNum(num % 10)),
            >= 60 and <= 69 => "Oltmish" + ((num % 10 == 0) ? "" : " " + ConvertNum(num % 10)),
            >= 70 and <= 79 => "Yetmish" + ((num % 10 == 0) ? "" : " " + ConvertNum(num % 10)),
            >= 80 and <= 89 => "Sakson" + ((num % 10 == 0) ? "" : " " + ConvertNum(num % 10)),
            >= 90 and <= 99 => "To'qson" + ((num % 10 == 0) ? "" : " " + ConvertNum(num % 10)),
            >= 100 and <= 999 => ConvertNum(num / 100) + " Yuz" + ((num % 100 == 0) ? "" : " " + ConvertNum(num % 100)),
            >= 1000 and <= 999999 => ConvertNum(num / 1000) + " Ming" + ((num % 1000 == 0) ? "" : " " + ConvertNum(num % 1000)),
            >= 1000000 and <= 999999999 => ConvertNum(num / 1000000) + " Million" + ((num % 1000000 == 0) ? "" : " " + ConvertNum(num % 1000000)),
            >= 1000000000 => ConvertNum(num / 1000000000) + " Milliard" + ((num % 1000000000 == 0) ? "" : " " + ConvertNum(num % 1000000000))
        };
    }
}