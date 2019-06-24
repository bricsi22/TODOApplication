using TODOApp.Data;
using TODOApp.Interface.Repository.Base;

namespace TODOApp.Interface.Repository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser, string>
    {
    }
}
