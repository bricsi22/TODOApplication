using Microsoft.AspNetCore.Mvc;
using TODOApp.Interface.SearchCriteria;
using TODOApp.ViewModels.User;

namespace TODOApp.Interface.Manager
{
    public interface ITodoManager
    {
		UserTodoItemViewModel GetViewModel(TodoItemSearchCriteria searchCriteria = null, IUrlHelper urlHelper = null);

	}
}
