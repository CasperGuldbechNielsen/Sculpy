using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Sculpy.Converter
{
    class MaterialTypeIdToMaterialTypeName:IValueConverter
    {
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
