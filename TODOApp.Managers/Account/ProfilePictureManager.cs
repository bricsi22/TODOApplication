﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using TODOApp.DataAccessLayer.Models;
using TODOApp.DataAccessLayer.Repository;
using TODOApp.Managers.Base;
using TODOApp.Managers.HelperExtensions;
using TODOApp.ViewModels.Account;

namespace TODOApp.Managers.Account
{
	public class ProfilePictureManager : BaseManager<ApplicationUser, IApplicationUserRepository, ProfilePictureViewModel>
	{
		public ProfilePictureManager(IApplicationUserRepository repository) : base(repository)
		{
		}
		public void SetUser(ApplicationUser applicationUser)
		{
			this.entity = applicationUser;
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

		public override ProfilePictureViewModel GetViewModel(IUrlHelper urlHelper = null)
		{
			var viewModel = new ProfilePictureViewModel();

			viewModel.UserName = entity.FirstName + " " + entity.PrimaryName;
			viewModel.Base64ProfilePicture = ProfilePictureExtension.GetBase64EncodedProfilePictureFromByteArray(entity.ProfilePicture);
			return viewModel;
		}
	}
}