using System.Linq;
using TODOApp.DataAccessLayer.DatabaseContext;
using TODOApp.DataAccessLayer.Models;

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

		#region Not Implemented on purpose
		public bool Delete(string pOId)
		{
			throw new System.NotImplementedException();
		}

		public IQueryable<ApplicationUser> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public bool Update(ApplicationUser pEntity)
		{
			throw new System.NotImplementedException();
		}

		public string Create(ApplicationUser pEntity)
		{
			throw new System.NotImplementedException();
		}
		#endregion
	}
}
