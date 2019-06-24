using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using TODOApp.Data;
using TODOApp.Interface.Manager;
using TODOApp.Interface.Repository;
using TODOApp.Interface.SearchCriteria;
using TODOApp.Managers.Base;
using TODOApp.Managers.HelperExtensions;
using TODOApp.ViewModels.Account;

namespace TODOApp.Managers.Account
{
	public class ProfilePictureManager : BaseManager<ApplicationUser, IApplicationUserRepository, ProfilePictureViewModel, UserSearchCriteria, string>,
										 IProfilePictureManager
	{
		public ProfilePictureManager(IApplicationUserRepository repository, 
									 IMapper mapper, 
									 UserSearchCriteria searchCriteria) : base(repository, mapper, searchCriteria)
		{
		}

		public void SaveProfilePicture(ProfilePictureViewModel viewModel, ApplicationUser applicationUser)
		{
			using (var ms = new MemoryStream())
			{
				viewModel.ProfilePicture.CopyTo(ms);
				applicationUser.ProfilePicture = ms.ToArray();
			}
			repository.Update(applicationUser);
		}

		public override ProfilePictureViewModel GetViewModel(UserSearchCriteria searchCriteria = null, IUrlHelper urlHelper = null)
		{
			var viewModel = new ProfilePictureViewModel();
			entity = repository.Get(searchCriteria.Id);
			viewModel.UserName = entity.FirstName + " " + entity.PrimaryName;
			viewModel.Base64ProfilePicture = ProfilePictureExtension.GetBase64EncodedProfilePictureFromByteArray(entity.ProfilePicture);
			return viewModel;
		}
	}
}
