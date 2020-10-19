using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace AutoDbdFlexerEx.ViewModel
{
    public class EnumDescriptionConverter : IValueConverter
    {
        private static string GetEnumDescription(Enum value)
        {
            try
            {
                return value.GetType().GetField(value.ToString()).
                    GetCustomAttribute<DescriptionAttribute>().Description;
            }
            catch
            {
                throw new ArgumentException($"{value.ToString()} of {value.GetType()} doesn't have DescriptionAttribute.");
            }
        }
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetEnumDescription((Enum)value);
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
