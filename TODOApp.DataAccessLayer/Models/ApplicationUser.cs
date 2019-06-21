using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TODOApp.DataAccessLayer.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }

		public string PrimaryName { get; set; }

		public List<TodoItem> TodoItems { get; set; }
	}
}
