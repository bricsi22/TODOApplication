using Microsoft.Extensions.DependencyInjection;
using TODOApp.Managers.Base;
using TODOApp.Managers.User;

namespace TODOApp.Managers
{
	public static class ManagerConfiguration
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			//services.AddTransient<BaseManager, TodoManager>();
		}
	}
}
