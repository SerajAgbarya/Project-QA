using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Models;

<<<<<<< HEAD

=======
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
namespace WebApplication5.Controllers
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
<<<<<<< HEAD
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Homepage()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }
      


        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Page2()
        {
            return View();
        }
=======

>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
<<<<<<< HEAD
}

   
=======
}
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
