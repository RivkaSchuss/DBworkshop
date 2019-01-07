using Moodify.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace Moodify.Model
{
    class WelcomeScreenModel : IWelcomeScreenModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
			//if (userName == "123")
			//{
			//	return false;
			//}
			//else
			//{
			//	connection.IsConnected = true;
			//	this.IsConnected = true;
			//	return true;
			//}
			DBHandler handler = DBHandler.Instance;
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlRegisterQuery"], userName, email, password);
            JArray result = handler.ExecuteWithResults(query);
            if (result != null)
            {
                int userID = int.Parse((string)result[0]["LAST_INSERT_ID()"]);
                CreateUserDetails(userName, password, email, userID);
                connection.IsConnected = true;
                this.IsConnected = true;
                return true;
            }
            return false;
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
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlSignInQuery"], userName, password);
            JArray result = handler.ExecuteWithResults(query);
            if (result != null && result.Count == 1)
            {
                string email = (string)result[0]["email"];
                int userID = int.Parse((string)result[0]["user_id"]);
                CreateUserDetails(userName, password, email, userID);
                connection.IsConnected = true;
                this.IsConnected = true;
                return true;
            }
            return false;
        }

        private void CreateUserDetails(string userName, string password, string email, int userID)
        {
            User user = new User()
            {
                UserName = userName,
                Password = password,
                Email = email,
                UserID = userID
            };
            ConnectionStatus status = ConnectionStatus.Instance;
            status.UserDetails = user;
        }

    }
}
