﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TODOApp.ViewModels;

namespace TODOApp.Controllers
{
    public class HomeController : Controller
    {
		public HomeController()
		{
		}
        public IActionResult Index()
        {
            return RedirectToAction("Index","User");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "TODO App description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

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
    }
}
