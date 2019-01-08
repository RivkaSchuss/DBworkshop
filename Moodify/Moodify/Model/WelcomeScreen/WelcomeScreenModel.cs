using Moodify.Containers;
using Moodify.DB;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Moodify.Model.WelcomeScreen
{
    class WelcomeScreenModel : IWelcomeScreenModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ConnectionStatus connection = ConnectionStatus.Instance;
        private bool connectionFailed;
        private string userName = "";
        private string password = "";
        private string email = "";

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

        /// <summary>
        /// The function try to register the submit user details.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>true - if there is no user with the same username, otherwise false</returns>
        public bool TryRegister(string userName, string email, string password)
        {
            DBHandler handler = DBHandler.Instance;
            // Checks if the username already exists
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlCheckIfUsernameExists"], userName);
            if (handler.ExecuteWithResults(query).Count != 0)
            {
                // there is a user with this username
                return false;
            }

            // Registers the user after checked if the username is not found.
            query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlRegisterQuery"], userName, email, password);
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

        /// <summary>
        /// The function try to sign in with sql query by given username and password
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>true - if the credentials are correct, otherwise false</returns>
        public bool TrySignIn(string userName, string password)
        {
            DBHandler handler = DBHandler.Instance;
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlSignInQuery"], userName, password);
            JArray result = handler.ExecuteWithResults(query);
            // Checks if the query returns the user_id and the email when the credentials are correct.
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

        /// <summary>
        /// Creates the user details when try to sign in or register and store it into the ConnectionStatus singleton.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The email.</param>
        /// <param name="userID">The user identifier.</param>
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
