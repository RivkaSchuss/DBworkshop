using System.ComponentModel;

namespace Moodify.ViewModel.WelcomeScreen
{
	/// <summary>
	/// Interface for the welcomeScreen
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public interface IWelcomeScreenVM : INotifyPropertyChanged
	{
		bool TryRegister(string userName, string Email, string Password);
		bool TrySignIn(string userName, string password);
		bool VM_IsConnectionFailed { get; set; }
		string VM_UserName { get; set; }
		string VM_Password { get; set; }
		string VM_Email { get; set; }
		bool VM_IsConnected { get; set; }
	}
}
