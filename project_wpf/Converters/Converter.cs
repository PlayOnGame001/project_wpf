using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;


namespace project_wpf.Converters
{
    abstract class Converter : IValueConverter
    {
        public abstract object Convert(object v, Type T, object p,  CultureInfo c);
        public virtual object ConvertBack(object v, Type t, object p, CultureInfo c) =>
            throw new NotSupportedException("Обратное преобразование не поддерживаеться");
    }
}
