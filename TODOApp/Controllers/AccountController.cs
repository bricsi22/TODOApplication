using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TODOApp.Managers;
using TODOApp.Managers.Account;
using TODOApp.ViewModels.Account;

namespace TODOApp.Controllers
{
	// user already authenticated, access denied if not authenticated
    public class AccountController : Controller
    {
		private ProfilePictureManager profilePictureManager;
		private UserManagerExtended userManagerExtended;
		public AccountController(ProfilePictureManager profilePictureManager,
								 UserManagerExtended userManagerExtended)
		{
			this.profilePictureManager = profilePictureManager;
			this.userManagerExtended = userManagerExtended;
		}
        public async Task<IActionResult> ProfilePicture()
        {
			var user = await userManagerExtended.GetUserAsync(this.User);
			profilePictureManager.SetUser(user);
			var viewModel = profilePictureManager.GetViewModel();
			return PartialView(viewModel);
        }

		[HttpPost]
		public async Task<IActionResult> ProfilePicture(ProfilePictureViewModel viewModel)
		{
			var user = await userManagerExtended.GetUserAsync(this.User);
			profilePictureManager.SaveProfilePicture(viewModel, user);
			return RedirectToAction("Index", "Home");
		}
	}
}