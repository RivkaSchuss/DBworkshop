using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Moodify.Converters
{
	/// <summary>
	/// Class to convert by object values.
	/// used to convert visibility of objects in Xaml
	/// </summary>
	/// <seealso cref="System.Windows.Data.IValueConverter" />
	public class BoolVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool val = (bool)value;
			return val ? Visibility.Visible : Visibility.Hidden;
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
	public class NotBoolVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool val = (bool)value;
			return val ? Visibility.Hidden : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
