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

		public WelcomeScreenModel()
		{
			userList = new List<User>();
			AddUsers();
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

		public bool TryAddUser(string userName, string email, string password)
		{
			foreach(User user in userList)
			{
				if (user.UserName == userName)
				{
					return false;
				}
			}
			User u = new User(userName, email, password);
			return true;
		}

		public bool TrySignIn(string userName, string password)
		{
            DBHandler handler = DBHandler.Instance;
            string query = $"SELECT user_id from users" +
                $" where binary username = '{userName}' and binary password = '{password}'";
            JArray result = handler.ExecuteWithResults(query);
            return result != null && result.Count == 1; // true if the user exists in the DB.
		}

	}
}
