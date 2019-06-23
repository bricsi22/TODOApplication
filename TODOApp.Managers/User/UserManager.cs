using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TODOApp.DataAccessLayer.Models;
using TODOApp.DataAccessLayer.Repository;
using TODOApp.Managers.Base;
using TODOApp.ViewModels.User;

namespace TODOApp.Managers.User
{
	public class UserManager : BaseManager<ApplicationUser, IApplicationUserRepository, UserViewModel>
	{
		public UserManager(IApplicationUserRepository applicationUserRepository, IMapper mapper) : base(applicationUserRepository, mapper)
		{
		}

		public override UserViewModel GetViewModel(IUrlHelper urlHelper = null)
		{
			throw new System.NotImplementedException();
		}

		public IQueryable<UserViewModel> GetUserViewModels()
		{
			var result = (from user in repository.GetAll()
						  select new UserViewModel {
							  Id = user.Id,
							  FirstName = user.FirstName,
							  PrimaryName = user.PrimaryName,
							  UserEmail = user.Email
						  });
			return result.AsNoTracking();
		}

		public void UpdateViewModel(UserViewModel viewModel)
		{
			entity = repository.Get(viewModel.Id);
			mapper.Map(viewModel, entity);
			repository.Update(entity);
		}

		public void DeleteViewModel(UserViewModel viewModel)
		{
			repository.Delete(viewModel.Id);
		}
	}
}
