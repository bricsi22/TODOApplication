
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

		public IQueryable<UserTodoItemViewModel> GetUserTodoItems(string userId)
		{
			var result = (from todo in repository.GetAll()
						  where todo.UserId == userId
						  select new UserTodoItemViewModel
						  {
							  DeadLine = todo.DeadLine,
							  Name = todo.Name,
							  Id = todo.Id,
							  Description = todo.Description,
							  UserId = todo.UserId
						  });
			return result.AsNoTracking();
		}

		public UserTodoItemViewModel Create(UserTodoItemViewModel model)
		{
			var todoItem = new TodoItem();
			mapper.Map(model, todoItem);
			model.Id = repository.Create(todoItem);
			return model;
		}

		public bool Update(UserTodoItemViewModel model)
		{
			var todoItem = repository.Get(model.Id);
			mapper.Map(model, todoItem);
			return repository.Update(todoItem);
		}

		public void Delete(UserTodoItemViewModel model)
		{
			repository.Delete(model.Id);
		}
	}
}
