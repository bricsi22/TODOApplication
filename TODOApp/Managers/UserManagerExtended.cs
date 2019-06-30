using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TODOApp.Data;
using TODOApp.Managers.HelperExtensions;

namespace TODOApp.Managers
{
	//TODO: Move this to a separate manager project
	public class UserManagerExtended : UserManager<ApplicationUser>
	{
		public UserManagerExtended(IUserStore<ApplicationUser> store, 
									IOptions<IdentityOptions> optionsAccessor, 
									IPasswordHasher<ApplicationUser> passwordHasher, 
									IEnumerable<IUserValidator<ApplicationUser>> userValidators, 
									IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, 
									ILookupNormalizer keyNormalizer, 
									IdentityErrorDescriber errors, 
									IServiceProvider services, 
									ILogger<UserManager<ApplicationUser>> logger) : base(store, 
																						 optionsAccessor, 
																						 passwordHasher, 
																						 userValidators, 
																						 passwordValidators, 
																						 keyNormalizer, 
																						 errors, 
																						 services, 
																						 logger)
		{

		}

		public async Task<bool> CurrentUserHasProfilePicture(ClaimsPrincipal claimsPrincipal)
		{
			var user = await GetUserAsync(claimsPrincipal);
			return user != null && user.ProfilePicture != null;
		}

		public async Task<string> GetBase64EncodedProfilePicture(ClaimsPrincipal claimsPrincipal) {
			var user = await GetUserAsync(claimsPrincipal);
			var stringSrc = user.ProfilePicture.GetBase64EncodedProfilePictureFromByteArray();
			return stringSrc;
		}
	}
}
