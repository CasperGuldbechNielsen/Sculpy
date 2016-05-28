using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Sculpy.Converter
{
    /// <summary>
    /// This class converts the Material Category number of a material to the name of that category.
    /// </summary>
    class MaterialTypeIdToMaterialTypeName:IValueConverter
    {
        /// <summary>
        /// This method contains a switch which has all three categories of the material types. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (int.Parse(value.ToString()))
            {
                case 1:
                    return "Stone:";
                case 2:
                    return "Metal:";
                case 3:
                    return "Other:";
                default:
                    throw new Exception();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
