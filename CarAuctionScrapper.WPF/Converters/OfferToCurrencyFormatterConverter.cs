using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CarAuctionScrapper.WPF.Converters
{
    public class OfferToCurrencyFormatterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Func<double,string>)XFormat;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public string XFormat(double value)
        {
            return value.ToString("C", CultureInfo.CreateSpecificCulture("pl-PL"));
        }
    }
}
