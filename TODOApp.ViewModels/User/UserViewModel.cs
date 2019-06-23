
using System.ComponentModel.DataAnnotations;

namespace TODOApp.ViewModels.User
{
	public class UserViewModel
	{
		public string Id { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} is max {1} characters long.")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} is max {1} characters long.")]
		public string PrimaryName { get; set; }

		[Required]
		[EmailAddress]
		public string UserEmail { get; set; }
	}
}
