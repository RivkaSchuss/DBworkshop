using System;
using System.Collections.Generic;
using System.ComponentModel;
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
				if (connectionInstance == null)
				{
					connectionInstance = new ConnectionStatus();
				}
				return connectionInstance;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}

		private bool isConnected;

		public bool IsConnected
		{
			get
			{
				return this.isConnected;
			}
			set
			{
				this.isConnected = value;
				this.NotifyPropertyChanged("IsConnected");
			}
		}

		public User UserDetails { get; set; }
	}
}
