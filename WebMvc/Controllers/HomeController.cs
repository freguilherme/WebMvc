using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebMvc.Models;
using WebMvc.Services;
using System;
using WebMvc.Models.ViewModels;

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
            //ViewBag.aut = aut;
            //return View();
            //if (HttpContext.Session.GetString("usuarioLogadoID") != null)
            //{
            return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                //var v = _context.User.FirstOrDefault(a => a.Email == u.Email && a.Password == u.Password);
                var v = _userService.Login(email, password);
                if (v != null)
                {
                    //HttpContext.Session.SetString("usuarioLogadoID", v.Email);
                    //HttpContext.Session.SetString("nomeUsuarioLogado", v.Password);
                    return RedirectToAction("Index");
                }
            }
            return View("Login");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UserFormViewModel { User = user };
                return View(viewModel);
            }
            _userService.Insert(user);

            return RedirectToAction(nameof(Login));
        }
    }
}
