using CarAuctionScrapper.Domain.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CarAuctionScrapper.WPF.Converters
{
    public class OfferToChartSeriesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Offer offer)
            {
                return new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Cena",
                        Values = new ChartValues<DateTimePoint>(
                            offer.Prices.Select(x => new DateTimePoint(x.Date.LocalDateTime, (double)x.Value))
                        ),
                        LineSmoothness=0
                    }
                };
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
