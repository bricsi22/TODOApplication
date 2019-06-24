using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TODOApp.Interface.Manager;
using TODOApp.Interface.SearchCriteria;
using TODOApp.Managers;
using TODOApp.ViewModels.Account;

namespace TODOApp.Controllers
{
	// user already authenticated, access denied if not authenticated
    public class AccountController : Controller
    {
		private IProfilePictureManager profilePictureManager;
		private UserManagerExtended userManagerExtended;
		public AccountController(IProfilePictureManager profilePictureManager,
								 UserManagerExtended userManagerExtended)
		{
			this.profilePictureManager = profilePictureManager;
			this.userManagerExtended = userManagerExtended;
		}
        public async Task<IActionResult> ProfilePicture()
        {
			var user = await userManagerExtended.GetUserAsync(this.User);
			var userSearchCriteria = new UserSearchCriteria { Id = user.Id };
			var viewModel = profilePictureManager.GetViewModel(searchCriteria: userSearchCriteria);
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