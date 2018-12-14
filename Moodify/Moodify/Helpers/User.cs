using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
	class User
	{
		private string userName;
		private string password;
		private string email;

		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				this.userName = value;
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				this.password = value;
			}
		}

		public User(string userName,  string email, string password)
		{
			this.userName = userName;
			this.password = password;
			this.email = email;
		}

	}
}
