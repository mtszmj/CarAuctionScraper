using CarAuctionScrapper.Domain.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Globalization;
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
                        Values = new ChartValues<DateTimePoint>
                        {
                            new DateTimePoint(DateTime.Today - TimeSpan.FromDays(30), (double)offer.Price.Value),
                            new DateTimePoint(DateTime.Today - TimeSpan.FromDays(10), (double)offer.Price.Value),
                            new DateTimePoint(DateTime.Today - TimeSpan.FromDays(7), (double)offer.Price.Value * 1.1),
                            new DateTimePoint(DateTime.Today - TimeSpan.FromDays(1), (double)offer.Price.Value * 0.9),
                            new DateTimePoint(DateTime.Today - TimeSpan.FromDays(0), (double)offer.Price.Value)
                        },
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
