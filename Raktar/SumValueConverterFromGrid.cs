using Raktar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Raktar.Views
{
    public class SumValueConverterFromGrid:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cvg = value as CollectionViewGroup;
            var field = parameter as string;
            if (cvg == null || field == null)
                return null;


            return cvg.Items.Sum(x => (x as Munkaruha).Osszesen);
            


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
