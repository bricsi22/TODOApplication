using CsvHelper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.IO;
using TODOApp.Interface.Manager;
using TODOApp.ViewModels.User;

namespace TODOApp.Controllers
{
    public class UserController : Controller
    {
		private IUserManager userManager;
		public UserController(IUserManager userManager)
		{
			this.userManager = userManager;
		}

		#region User related methods
		public IActionResult Index()
		{
			var viewModel = userManager.GetIndexViewModel(Url);
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult GetUsers([DataSourceRequest]DataSourceRequest request)
        {
			var result = userManager.GetUserViewModels();
			using(var streamWriter = new StreamWriter(@"C:\temp\csvfile.csv"))
			{
				using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
				{
					csvWriter.WriteRecords(result);
				}
			}
			return Json(result.ToDataSourceResult(request));
        }

		[HttpPost]
		public IActionResult UpdateUser([DataSourceRequest] DataSourceRequest request, UserViewModel userViewModel)
		{
			if (userViewModel != null && ModelState.IsValid)
			{
				userManager.UpdateViewModel(userViewModel);
			}

			return Json(new[] { userViewModel }.ToDataSourceResult(request, ModelState));
		}

		[HttpPost]
		public IActionResult DeleteUser([DataSourceRequest] DataSourceRequest request, UserViewModel userViewModel)
		{
			userManager.DeleteViewModel(userViewModel);
			return Json(new[] { userViewModel }.ToDataSourceResult(request));
		}

		#endregion

	}
}