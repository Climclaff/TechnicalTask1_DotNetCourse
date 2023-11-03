using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnicalTask1_DotNetCourse.Models;

namespace TechnicalTask1_DotNetCourse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}