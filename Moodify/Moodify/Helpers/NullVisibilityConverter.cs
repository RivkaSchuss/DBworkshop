using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Moodify.Helpers
{
	/// <summary>
	/// Class to convert by object values.
	/// used to convert visibility of objects in Xaml
	/// </summary>
	/// <seealso cref="System.Windows.Data.IValueConverter" />
	public class NullVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

	/// <summary>
	/// Class to convert by object values.
	/// used to convert visibility of objects in Xaml
	/// </summary>
	/// <seealso cref="System.Windows.Data.IValueConverter" />
	public class NotNullVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == null ? Visibility.Visible : Visibility.Hidden;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
