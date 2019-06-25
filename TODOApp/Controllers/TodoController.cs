using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using TODOApp.Interface.Manager;
using TODOApp.ViewModels.User;

namespace TODOApp.Controllers
{
    public class TodoController : Controller
    {
		private IUserManager userManager;
		private ITodoManager todoManager;
		public TodoController(IUserManager userManager,
							  ITodoManager todoManager)
		{
			this.userManager = userManager;
			this.todoManager = todoManager;
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

		#region Grid related methods 

		public IActionResult GetTodos([DataSourceRequest]DataSourceRequest request, string userId)
		{
			var result = todoManager.GetUserTodoItems(userId);
			return Json(result.ToDataSourceResult(request));
		}

		public IActionResult CreateTodo([DataSourceRequest]DataSourceRequest request, 
										UserTodoItemViewModel model)
		{
			if (model != null && ModelState.IsValid)
			{
				model = todoManager.Create(model);
			}

			return Json(new[] { model }.ToDataSourceResult(request, ModelState));
		}

		public IActionResult UpdateTodo([DataSourceRequest]DataSourceRequest request, UserTodoItemViewModel model)
		{
			if (model != null && ModelState.IsValid)
			{
				todoManager.Update(model);
			}

			return Json(new[] { model }.ToDataSourceResult(request, ModelState));
		}

		public IActionResult DeleteTodo([DataSourceRequest]DataSourceRequest request, UserTodoItemViewModel model, string userId)
		{
			todoManager.Delete(model);

			return Json(new[] { model }.ToDataSourceResult(request, ModelState));
		}

		#endregion
	}
}