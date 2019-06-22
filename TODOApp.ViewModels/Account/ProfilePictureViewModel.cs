using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TODOApp.ViewModels.Account
{
	public class ProfilePictureViewModel
	{
		public string UserName { get; set; }

		public string Base64ProfilePicture { get; set; }

		[Required(ErrorMessage = "Please Upload File")]
		[Display(Name = "Upload File")]
		public IFormFile ProfilePicture { get; set; }
	}
}
