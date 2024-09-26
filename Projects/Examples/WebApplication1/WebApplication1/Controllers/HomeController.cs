using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(int index = 1)
		{
			var homeModel = new HomeModel()
			{
				Message = "Hello world",
				ListOfDrinks = new List<string>()
				{
					"Coffee",
					"Tea",
					"Juice"
				},
				MyFavoriteDrink = index
			};
			return View(homeModel);
		}

		public IActionResult Insert()
		{
			var homeModel = new HomeModel()
			{
				Message = "Hello world",
				ListOfDrinks = new List<string>()
				{
					"Coffee",
					"Tea",
					"Juice"
				},
				MyFavoriteDrink = 1
			};
			return View("Index", homeModel);
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
	}
}