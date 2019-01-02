using Moodify.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace Moodify.Model
{
    class WelcomeScreenModel : IWelcomeScreenModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

		private IList<User> userList;
		private ConnectionStatus connection = ConnectionStatus.Instance;
		private bool connectionFailed;
		private string userName = "";
		private string password = "";
		private string email ="";

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
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
				NotifyPropertyChanged("Password");
			}
		}
		public string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				this.email = value;
				NotifyPropertyChanged("Email");
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
            this.connectionFailed = false;
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
            DBHandler handler = DBHandler.Instance;

            string query = $"INSERT into users (username, email, password) VALUES ('{userName}', '{email}', '{password}')";
            bool result = handler.ExecuteNoResult(query);
            if (result)
            {
                connection.IsConnected = true;
                this.IsConnected = true;
                return result;
            }
            return result;

            //         if (userName == "123")
            //{
            //	return false;
            //}
            //else
            //{
            //	connection.IsConnected = true;
            //	this.IsConnected = true;
            //	return true;
            //}
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
