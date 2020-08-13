using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TODOApp.DataAccessLayer.DatabaseContext;
using TODOApp.Managers;
using AutoMapper;
using System;
using TODOApp.Interface.SearchCriteria;
using TODOApp.DataAccessLayer;
using TODOApp.Data;
using TODOApp.HostedServices;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace TODOApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
				{
					options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), option => option.MigrationsAssembly("TODOApp.DataAccessLayer"));
					
				});
			services.AddDefaultIdentity<ApplicationUser>()
				.AddUserManager<UserManagerExtended>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc(setupAction => 
                            {
                                setupAction.EnableEndpointRouting = false;
                                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                                setupAction.Filters.Add(new AuthorizeFilter(policy));
                            }).AddJsonOptions(jsonOptions =>
                            {   // change camelCase Json results to PascalCase
                                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                            })
                            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            
            services.AddRazorPages();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


			services.AddKendo();

			RepositoryConfiguration.ConfigureServices(services);
			HostedServicesConfiguration.ConfigureServices(services);

			// managers
			ManagerConfiguration.ConfigureServices(services);

			// search criterias
			services.AddTransient<TodoItemSearchCriteria>();
			services.AddTransient<UserSearchCriteria>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

		private static void UpdateDatabase(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
				{
					context.Database.Migrate();
				}
			}
		}
    }
}
