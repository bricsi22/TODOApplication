using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TODOApp.DataAccessLayer.Repository;
using TODOApp.Models;

namespace TODOApp.Controllers
{
    public class HomeController : Controller
    {
		private ITodoItemRepository todoItemRepository;
		public HomeController(ITodoItemRepository todoItemRepository)
		{
			this.todoItemRepository = todoItemRepository;
		}
        public IActionResult Index()
        {
			var todoItem = this.todoItemRepository.GetAll().FirstOrDefault();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
