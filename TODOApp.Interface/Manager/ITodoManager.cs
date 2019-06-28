using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TODOApp.Interface.SearchCriteria;
using TODOApp.ViewModels.User;

namespace TODOApp.Interface.Manager
{
    public interface ITodoManager
    {
		UserTodoItemViewModel GetViewModel(TodoItemSearchCriteria searchCriteria = null, IUrlHelper urlHelper = null);

		IQueryable<UserTodoItemViewModel> GetUserTodoItems(string userId);

		UserTodoItemViewModel Create(UserTodoItemViewModel model);

		bool Update(UserTodoItemViewModel model);

		void Delete(UserTodoItemViewModel model);
	}
}
