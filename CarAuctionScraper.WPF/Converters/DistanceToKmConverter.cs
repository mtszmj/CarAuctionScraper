using System;
using System.Globalization;
using System.Windows.Data;

namespace CarAuctionScraper.WPF.Converters
{
    public class DistanceToKmConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var distance = value as double?;
            if (distance is null)
                return value;

            return $"{distance} km";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
