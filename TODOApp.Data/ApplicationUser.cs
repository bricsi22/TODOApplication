using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TODOApp.Data
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }

		public string PrimaryName { get; set; }

		public byte[] ProfilePicture { get; set; }

		public ICollection<TodoItem> TodoItems { get; set; }
	}
}
