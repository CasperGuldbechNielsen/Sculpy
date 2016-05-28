using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Sculpy.Converter
{
    /// <summary>
    /// This class convertes a DateTimeOffset to a DateTime type in order to create the binding.
    /// </summary>
    class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        /// <summary>
        /// This method converts a DateTime to an DateTimeOffset.
        /// </summary>
        /// <param name="value">This is the value which will be displayed in the DateTimePicker Controller.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTime date = (DateTime)value;
                return new DateTimeOffset(date);
            }
            catch (Exception ex)
            {
                return DateTimeOffset.MinValue;
            }
        }

        /// <summary>
        /// This method converts a DateTimeOffset to a DateTime.
        /// </summary>
        /// <param name="value">This is the value from the DateTimePicker Controller.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTimeOffset date = (DateTimeOffset)value;
                return date.DateTime;
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
    }
}
