using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebMvc.Models;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    public class HomeController :Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Home page";
            ViewData["email"] = "guiaafre@gmail.com";

            return View();
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

        public IActionResult Login()
        {
            return NotFound();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string pwd)
        {
            if (email == null && pwd == null)
            {
                //return RedirectToAction(nameof(Index));
            }

            var obj = _userService.Login(email, pwd);
            if (obj == null)
            {
                //return RedirectToAction(nameof(Index));
            }

            return NotFound(); //RedirectToAction(nameof(Index));
        }
    }
}
