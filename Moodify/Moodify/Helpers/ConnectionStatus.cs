using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
	/// <summary>
	/// Singleton to provide access for all classes to the Connection Status
	/// </summary>
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

		/// <summary>
		/// Gets or sets a value indicating whether this the user is connected.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
		/// </value>
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
