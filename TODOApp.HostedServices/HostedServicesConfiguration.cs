using Microsoft.Extensions.DependencyInjection;
using TODOApp.HostedServices.Email;

namespace TODOApp.HostedServices
{
	public static class HostedServicesConfiguration
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddHostedService<EmailHostedService>();
		}
	}
}
