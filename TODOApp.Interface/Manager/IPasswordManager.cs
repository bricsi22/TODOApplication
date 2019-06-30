
namespace TODOApp.Interface.Manager
{
	public interface IPasswordManager
	{
		string Encrypt(string text, string key); //not used, just for the sake of completness

		string Decrypt(string encrypted, string key);
	}
}
