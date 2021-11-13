using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.Models.ViewModels;

namespace WebMvc.Controllers
{
    public class UsersController :Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
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

            return RedirectToAction(nameof(Index));
        }
    }
}
