using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Team1_Web.Models;

namespace Team1_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeModel homeModel = new HomeModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public JsonResult WolfAtackPiggy(int number1, int number2, int id)
        {
               return Json(homeModel.WolfAtackPiggy(id));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}