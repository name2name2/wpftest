﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApplication1.Converter 
{
    /// <summary>
    /// Converts a String to a nullable Integer or Decimal.
    /// </summary>
    public class StringToNullableNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value as string;
            if (stringValue!=null)
            {
                if (targetType==typeof(int?))
                {
                    int result;
                    if (int.TryParse(stringValue, out result))
                        return result;

                    return null;
                }

                if (targetType==typeof(decimal?))
                {
                    decimal result;
                    if (decimal.TryParse(stringValue, out result))
                        return result;

                    return null;
                }
            }

            return value;
        }


    }
}
