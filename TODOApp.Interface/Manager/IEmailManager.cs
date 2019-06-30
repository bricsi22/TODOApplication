using TODOApp.Data;

namespace TODOApp.Interface.Manager
{
	public interface IEmailManager
	{
		void SendEmail(ApplicationUser applicationUser);
	}
}
