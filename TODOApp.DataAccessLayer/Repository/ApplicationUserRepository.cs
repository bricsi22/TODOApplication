using System.Linq;
using TODOApp.Data;
using TODOApp.DataAccessLayer.DatabaseContext;
using TODOApp.Interface.Repository;

namespace TODOApp.DataAccessLayer.Repository
{
	public class ApplicationUserRepository : IApplicationUserRepository
	{
		private ApplicationDbContext applicationDbContext;
		public ApplicationUserRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public ApplicationUser Get(string pId)
		{
			return applicationDbContext.Users.FirstOrDefault(x => x.Id == pId);
		}

		public bool Update(ApplicationUser pEntity)
		{
			var success = false;
			var user = applicationDbContext.Users.FirstOrDefault(x => x.Id == pEntity.Id);
			if (user != null)
			{
				user.FirstName = pEntity.FirstName;
				user.PrimaryName = pEntity.PrimaryName;
				user.Email = pEntity.Email;
				user.ProfilePicture = pEntity.ProfilePicture;
				applicationDbContext.SaveChanges();
				success = true;
			}
			return success;
		}
		public bool Delete(string pId)
		{
			var success = false;
			var user = applicationDbContext.Users.FirstOrDefault(x => x.Id == pId);
			if (user != null)
			{
				applicationDbContext.Users.Remove(user);
				applicationDbContext.SaveChanges();
				success = true;
			}
			return success;
		}

		public IQueryable<ApplicationUser> GetAll()
		{
			return applicationDbContext.Users;
		}

		#region Not Implemented on purpose

		public string Create(ApplicationUser pEntity)
		{
			throw new System.NotImplementedException();
		}
		#endregion
	}
}
