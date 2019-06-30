
using System;

namespace TODOApp.Managers.HelperExtensions
{
	public static class ProfilePictureExtension
	{
		public static string GetBase64EncodedProfilePictureFromByteArray(this byte[] profilePicutre)
		{
			var stringSrc = "";
			if (profilePicutre != null)
			{
				var base64EncodedProfilePicture = Convert.ToBase64String(profilePicutre);
				stringSrc = String.Format("data:image/gif;base64,{0}", base64EncodedProfilePicture);
			}
			return stringSrc;
		}
	}
}
