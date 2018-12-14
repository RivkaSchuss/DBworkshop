using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
	class ConnectionStatus
	{
		private static ConnectionStatus connectionInstance;

		public static ConnectionStatus Instance
		{
			get
			{
				if(connectionInstance == null)
				{
					connectionInstance = new ConnectionStatus();
				}
				return connectionInstance;
			}
		}

		public bool IsConnected { get; set; }

		public User UserDetails { get; set; }
	}
}
