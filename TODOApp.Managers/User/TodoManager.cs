
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TODOApp.Data;
using TODOApp.Interface.Manager;
using TODOApp.Interface.Repository;
using TODOApp.Interface.SearchCriteria;
using TODOApp.Managers.Base;
using TODOApp.ViewModels.User;

namespace TODOApp.Managers.User
{
	public class TodoManager : BaseManager<TodoItem, ITodoItemRepository, UserTodoItemViewModel, TodoItemSearchCriteria, long>,
							   ITodoManager
	{
		public TodoManager(ITodoItemRepository todoItemRepository, 
						   IMapper mapper,
						   TodoItemSearchCriteria searchCriteria) : base(todoItemRepository, mapper, searchCriteria)
		{

		}

		public override UserTodoItemViewModel GetViewModel(TodoItemSearchCriteria searchCriteria = null, IUrlHelper urlHelper = null)
		{
			var userTodoItemViewModel = new UserTodoItemViewModel();
			entity = repository.Get(searchCriteria.Id);
			mapper.Map(entity, userTodoItemViewModel);
			return userTodoItemViewModel;
		}


	}
}
