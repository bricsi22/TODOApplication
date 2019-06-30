using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TODOApp.Data;
using TODOApp.Interface.SearchCriteria;
using TODOApp.ViewModels.User;

namespace TODOApp.Interface.Manager
{
    public interface IUserManager
    {
		IndexViewModel GetIndexViewModel(IUrlHelper url);

		UserViewModel GetViewModel(UserSearchCriteria userSearchCriteria = null,
												   IUrlHelper urlHelper = null);

		IQueryable<UserViewModel> GetUserViewModels();

		void UpdateViewModel(UserViewModel viewModel);

		void DeleteViewModel(UserViewModel viewModel);

		UserViewModel GetViewModelById(string id);

		IQueryable<ApplicationUser> GetUsersWithDeadLine();

		void SendEmailNotificationsAboutDeadLines();
	}
}
