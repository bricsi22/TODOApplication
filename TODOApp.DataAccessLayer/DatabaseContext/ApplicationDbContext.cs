using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TODOApp.DataAccessLayer.Models;

namespace TODOApp.DataAccessLayer.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		public DbSet<TodoItem> TodoItem { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<TodoItem>().HasOne(p => p.ApplicationUser).WithMany(m => m.TodoItems).HasForeignKey(f => f.UserId);
		}
	}
}
