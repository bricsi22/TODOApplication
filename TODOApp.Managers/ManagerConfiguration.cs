using Microsoft.Extensions.DependencyInjection;
using TODOApp.Interface.Manager;
using TODOApp.Managers.Account;
using TODOApp.Managers.Email;
using TODOApp.Managers.Password;
using TODOApp.Managers.User;

namespace TODOApp.Managers
{
	public static class ManagerConfiguration
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IProfilePictureManager, ProfilePictureManager>();
			services.AddTransient<ITodoManager, TodoManager>();
			services.AddScoped<IUserManager, UserManager>();
			services.AddTransient<IEmailManager, EmailManager>();
			services.AddTransient<IPasswordManager, PasswordManager>();
			
		}
	}
}
