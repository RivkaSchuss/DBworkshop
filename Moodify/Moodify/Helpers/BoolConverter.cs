﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Moodify.Helpers
{
	/// <summary>
	/// Class to convert by object values.
	/// used to convert visibility of objects in Xaml
	/// </summary>
	/// <seealso cref="System.Windows.Data.IValueConverter" />
	public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string type = value.ToString();
                if (type.Equals("SUCCESS"))
                {
                    return "Playlist added succesfully!";
                }
                else if (type.Equals("FAIL"))
                {
                    return "There was an error adding this playlist.";
                }
            }
           
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
