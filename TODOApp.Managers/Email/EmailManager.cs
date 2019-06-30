using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using TODOApp.Data;
using TODOApp.Interface.Manager;
using TODOApp.Managers.Constants;

namespace TODOApp.Managers.Email
{
	public class EmailManager : IEmailManager
	{
		private readonly IPasswordManager passwordManager;
		public EmailManager(IPasswordManager passwordManager)
		{
			this.passwordManager = passwordManager;
		}
		public void SendEmail(ApplicationUser applicationUser)
		{
			var userName = applicationUser.FirstName + " " + applicationUser.PrimaryName;
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("TODO App - Reminder", EmailConstants.EmailAddress));
			message.To.Add(new MailboxAddress(userName, applicationUser.Email));
			message.Subject = "You have unfinished task(s), deadline is today!!!";

			message.Body = new TextPart(TextFormat.Html)
			{
				Text = "Hey " + userName + ",\n" + 

						"You have unfinished task and the dead line is today, please complete the task."
			};

			using (var client = new SmtpClient())
			{
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;

				client.AuthenticationMechanisms.Remove("XOAUTH2");
				client.Connect("smtp.gmail.com", 465, true);

				// Note: only needed if the SMTP server requires authentication
				var password = passwordManager.Decrypt(EmailConstants.EmailPasswordEncrypted, EmailConstants.EmailPasswordKey);
				client.Authenticate(EmailConstants.EmailAddress, password);

				client.Send(message);
				client.Disconnect(true);
			}
		}
	}
}
