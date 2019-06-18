using Microsoft.AspNetCore.Identity;

namespace TODOApp.Data
{
  public class ApplicationUser : IdentityUser
  {
    public string FirstName { get; set; }

    public string PrimaryName { get; set; }
  }
}
