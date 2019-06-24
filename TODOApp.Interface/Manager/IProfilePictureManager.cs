using Microsoft.AspNetCore.Mvc;
using TODOApp.Data;
using TODOApp.Interface.SearchCriteria;
using TODOApp.ViewModels.Account;

namespace TODOApp.Interface.Manager
{
    public interface IProfilePictureManager
    {
		void SaveProfilePicture(ProfilePictureViewModel viewModel, ApplicationUser applicationUser);

		ProfilePictureViewModel GetViewModel(UserSearchCriteria searchCriteria = null, IUrlHelper urlHelper = null);
	}
}
