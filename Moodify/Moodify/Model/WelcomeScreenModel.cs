using Moodify.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
	class WelcomeScreenModel : IWelcomeScreenModel
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private IList<User> userList;
		private ConnectionStatus connection = ConnectionStatus.Instance;
		private bool connectionFailed;
		private string userName;

		public string UserName
		{
			get
			{
				return this.userName;
			}
			set
			{
				this.userName = value;
				NotifyPropertyChanged("UserName");
			}
		}


		public bool IsConnected
		{
			get
			{
				return this.connection.IsConnected;
			}
			set
			{
				this.connection.IsConnected = value;
				NotifyPropertyChanged("IsConnected");
			}
		}

		public bool ConnectionFailed
		{
			get
			{
				return this.connectionFailed;
			}
			set
			{
				this.connectionFailed = value;
				NotifyPropertyChanged("ConnectionFailed");
			}
		}


		public WelcomeScreenModel()
		{
			userList = new List<User>();
			AddUsers();
			this.connectionFailed = false;
		}

		private void AddUsers()
		{
			User avihay = new User("arzuan", "avihay@dfg.com", "123456");
			User dan = new User("tepli", "tepli@dfg.com", "123456");
			User barak = new User("talmor", "talmor@dfg.com", "123456");
			User rivka = new User("schuss", "schuss@dfg.com", "123456");
			userList.Add(avihay);
			userList.Add(dan);
			userList.Add(barak);
			userList.Add(rivka);
		}

		public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}

		public bool TryRegister(string userName, string email, string password)
		{
			if(userName == "123")
			{
				return false;
			}
			else
			{
				connection.IsConnected = true;
				this.IsConnected = true;
				return true;
			}
			//foreach(User user in userList)
			//{
			//	if (user.UserName == userName)
			//	{
			//		return false;
			//	}
			//}
			//User u = new User(userName, email, password);
			//return true;
		}

		public bool TrySignIn(string userName, string password)
		{
			if (userName == "123")
			{
				connection.IsConnected = true;
				this.IsConnected = true;
				return true;
			}
            DBHandler handler = DBHandler.Instance;
            string query = $"SELECT user_id from users" +
                $" where binary username = '{userName}' and binary password = '{password}'";
            JArray result = handler.ExecuteWithResults(query);
            return result != null && result.Count == 1; // true if the user exists in the DB.
		}

	}
}
