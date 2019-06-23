using Microsoft.AspNetCore.Mvc;
using TODOApp.Managers.User;

namespace TODOApp.Controllers
{
    public class TodoController : Controller
    {
		private UserManager userManager;
		public TodoController(UserManager userManager)
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