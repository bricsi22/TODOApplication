using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TODOApp.Interface.HostedServices;
using TODOApp.Interface.Manager;

namespace TODOApp.HostedServices.Email
{
	public class EmailHostedService : IEmailHostedService
	{
		private readonly ILogger logger;
		private Timer timer;
		private IServiceProvider serviceProvider;
		public EmailHostedService(ILogger<EmailHostedService> logger,
								  IServiceProvider serviceProvider)
		{
			this.logger = logger;
			this.serviceProvider = serviceProvider;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			logger.LogInformation("Timed Background Service is starting.");
			timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(24));

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			logger.LogInformation("Timed Background Service is stopping.");

			timer?.Change(Timeout.Infinite, 0);

			return Task.CompletedTask;
		}

		private void DoWork(object state)
		{
			logger.LogInformation("Timed Background Service is working.");
			using (var scope = serviceProvider.CreateScope())
			{
				var userManager = scope.ServiceProvider.GetRequiredService<IUserManager>();
				userManager.SendEmailNotificationsAboutDeadLines();
			}
		}

		public void Dispose()
		{
			timer?.Dispose();
		}
	}
}
