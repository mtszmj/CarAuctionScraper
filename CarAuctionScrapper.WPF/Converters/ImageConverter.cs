using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CarAuctionScrapper.WPF.Converters
{
    public class ImageConverter : IValueConverter
    {
        public int? DecodePixelHeight { get; set; }
        public int? DecodePixelWidth { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Uri uri;
            if (value is string valueStr)
                uri = new Uri(valueStr);
            else if (value is Uri valueUri)
                uri = valueUri;
            else uri = new Uri("");

            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;

            if (DecodePixelHeight != null)
                image.DecodePixelHeight = DecodePixelHeight.Value;

            if (DecodePixelWidth != null)
                image.DecodePixelWidth = DecodePixelWidth.Value;

            image.CreateOptions = BitmapCreateOptions.None;
            image.UriSource = uri;
            image.EndInit();
            return image;
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
