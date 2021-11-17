using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.Models.ViewModels;
using Refit;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Index(string cep)
        {
            var cepClient = RestService.For<ICepApiService>("https://viacep.com.br/");
            var address = await cepClient.GetAddressAsync(cep);
            return View(address);
        }
    }
}
