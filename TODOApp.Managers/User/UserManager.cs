using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TODOApp.DataAccessLayer.Models;
using TODOApp.DataAccessLayer.Repository;
using TODOApp.Interface.SearchCriteria;
using TODOApp.Managers.Base;
using TODOApp.ViewModels.User;

namespace TODOApp.Managers.User
{
	public class UserManager : BaseManager<ApplicationUser, IApplicationUserRepository, UserViewModel, UserSearchCriteria, string>
	{
		public UserManager(IApplicationUserRepository applicationUserRepository, 
						   IMapper mapper,
						   UserSearchCriteria searchCriteria) : base(applicationUserRepository, mapper, searchCriteria)
		{
		}
		#region User related methods
		public IndexViewModel GetIndexViewModel(IUrlHelper url)
		{
			var indexViewModel = new IndexViewModel();
			indexViewModel.UserTodoItemsUrl = url.Action("UserTodoItems", "Todo", new { Id = "0" });
			
			return indexViewModel;
		}

		public override UserViewModel GetViewModel(UserSearchCriteria userSearchCriteria = null,
												   IUrlHelper urlHelper = null)
		{
			viewModel = new UserViewModel();
			entity = repository.Get(userSearchCriteria.Id);
			mapper.Map(entity, viewModel);
			return viewModel;
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

		public UserViewModel GetViewModelById(string id)
		{
			viewModel = new UserViewModel();
			entity = repository.Get(id);
			mapper.Map(entity, viewModel);
			return viewModel;
		}

		#endregion

		#region User Todo Items related methods



		#endregion
	}
}
