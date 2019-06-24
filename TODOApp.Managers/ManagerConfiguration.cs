using Microsoft.Extensions.DependencyInjection;
using TODOApp.Interface.Manager;
using TODOApp.Managers.Account;
using TODOApp.Managers.User;

namespace TODOApp.Managers
{
	public static class ManagerConfiguration
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IProfilePictureManager, ProfilePictureManager>();
			services.AddTransient<ITodoManager, TodoManager>();
			services.AddTransient<IUserManager, UserManager>();
		}
	}
}
