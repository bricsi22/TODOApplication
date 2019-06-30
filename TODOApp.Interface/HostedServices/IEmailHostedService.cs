using Microsoft.Extensions.Hosting;
using System;

namespace TODOApp.Interface.HostedServices
{
	public interface IEmailHostedService : IHostedService, IDisposable
	{
	}
}
