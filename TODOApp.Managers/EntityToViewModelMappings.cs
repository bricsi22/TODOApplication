using AutoMapper;
using TODOApp.Data;
using TODOApp.ViewModels.User;

namespace TODOApp.Managers
{
	public class EntityToViewModelMappings : Profile
	{
		public EntityToViewModelMappings()
		{
			// vica
			CreateMap<UserViewModel, ApplicationUser>()
				.ForMember(d => d.Id, option => option.Ignore())
				.ForMember(d => d.Email, option => option.MapFrom(m => m.UserEmail));
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
