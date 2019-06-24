using Microsoft.Extensions.DependencyInjection;
using TODOApp.DataAccessLayer.Repository;
using TODOApp.Interface.Repository;

namespace TODOApp.DataAccessLayer
{
	public static class RepositoryConfiguration
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<ITodoItemRepository, TodoItemRepository>();
			services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
			
		}
	}
}
