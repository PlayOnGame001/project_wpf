﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace project_wpf.Converters
{
    internal class BackConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object paramenter, CultureInfo culter)
        {
            return new object[] { values[0], values[1], values[2] };
        }
        public object[] ConvertBack(object values, Type[] targetType, object paramenter, CultureInfo culter)
        {
            throw new NotImplementedException();
        }
    }
}
