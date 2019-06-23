using AutoMapper;
using TODOApp.DataAccessLayer.Models;
using TODOApp.ViewModels.User;

namespace TODOApp.Managers
{
	public class EntityToViewModelMappings : Profile
	{
		public EntityToViewModelMappings()
		{
			// vica
			CreateMap<UserViewModel, ApplicationUser>().ForMember(d => d.Id, option => option.Ignore());
			// versa, currenty not used
			CreateMap<ApplicationUser, UserViewModel>();

			
			CreateMap<UserTodoItemViewModel, TodoItem>();
			// currently not used
			CreateMap<TodoItem, UserTodoItemViewModel>();
		}

		public override string ProfileName
		{
			get { return "EntityToViewModelMappings"; }
		}
		
	}
}
