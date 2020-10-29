using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CarAuctionScrapper.WPF.Converters
{
    public class OfferToDateTimeFormatterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Func<double,string>)YFormat;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public string YFormat(double value)
        {
            var longval = (long)value;
            var datetimeval = new DateTime(longval);
            var stringval = $"{datetimeval:dd-MM-yyyy}";

            return stringval;
        }
    }
}
