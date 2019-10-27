using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

/// <summary>
/// This is only separate .cs file, there is no real Convertors class.
/// </summary>
namespace WPF_basics.ViewModels
{
    public class BooleanToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) // Always check value (and parameter if used)
            {
                bool val = (bool)value;
                if (val) return "Yes";
                else return "No";
            }
            return "IDK"; // Fallback
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
