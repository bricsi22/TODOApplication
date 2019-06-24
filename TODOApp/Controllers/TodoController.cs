using Microsoft.AspNetCore.Mvc;
using TODOApp.Interface.Manager;

namespace TODOApp.Controllers
{
    public class TodoController : Controller
    {
		private IUserManager userManager;
		public TodoController(IUserManager userManager)
		{
			this.userManager = userManager;
		}
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult UserTodoItems(string id)
		{
			var viewModel = userManager.GetViewModelById(id);
			return PartialView(viewModel);
		}
	}
}