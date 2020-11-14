using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace CarAuctionScraper.WPF.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        Visibility NotVisible { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inversed = false;
            if (bool.TryParse(parameter as string, out var p) && p == true)
                inversed = true;

            var v = value is bool;

            if (!v)
                throw new ArgumentException("Value is not bool");

            if (v && !inversed)
                return Visibility.Visible;
            else if (v && inversed)
                return NotVisible;
            else if (!v && !inversed)
                return NotVisible;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
