using System;
using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TODOApp.Areas.Identity.IdentityHostingStartup))]
namespace TODOApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}