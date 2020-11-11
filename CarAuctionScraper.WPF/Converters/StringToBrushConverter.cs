using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace CarAuctionScraper.WPF.Converters
{
    public class StringToBrushConverter : IValueConverter
    {
        protected const double Alpha = 0.8;
        protected const double Saturation = 0.25;
        protected const double Brightness = 1.0;
        protected const int NumberOfColors = 47;
        protected const int HueStep = 360 / NumberOfColors;
        protected static List<Brush> Brushes = new List<Brush>();

        protected static Dictionary<string, Brush> AssignedBrush = new Dictionary<string, Brush>();

        static StringToBrushConverter()
        {
            var brushes = new List<Brush>();
            for(var i = 0; i < NumberOfColors; i++)
            {
                var saturation = Saturation + i%5 * 0.15;
                var brightness = Brightness; // - (3 - i%3) * 0.05;
                brushes.Add(new SolidColorBrush(HsvToArgb(Alpha, i * HueStep, saturation, brightness)));
            }
            //var brushes = Enumerable.Range(0, NumberOfColors)
            //                        .Select(i => new SolidColorBrush(HsvToArgb(Alpha, i * HueStep, saturation, brightness)))
            //                        .ToArray();

            // split range into 3 sets and take one brush from each set one by one to have different colors next to each other

            var setRange = NumberOfColors % 3 == 0 ? NumberOfColors / 3 : (NumberOfColors / 3) + 1;
            for(var i = 0; i < setRange; i++)
            {
                var index1 = i;
                var index2 = setRange + i;
                var index3 = setRange * 2 + i;
                
                Brushes.Add(brushes[index1]); // first set
                Brushes.Add(brushes[index2]); // second set
                if(index3 < brushes.Count)
                    Brushes.Add(brushes[index3]); // third set
            }

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string @string)
            {
                if (AssignedBrush.ContainsKey(@string))
                    return AssignedBrush[@string];

                var index = AssignedBrush.Count % NumberOfColors;
                var assignedBrush = Brushes[index];
                AssignedBrush[@string] = assignedBrush;
                return assignedBrush;
            }

            return Brushes[0];
        }


        protected Brush Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return Brushes[Math.Abs(value.GetHashCode()) % NumberOfColors];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        protected static Color HsvToArgb(double a, double h, double s, double v)
        {
            var color = HsvToRgb(h, s, v);
            color.A = (byte)(a * 255);
            return color;
        }
        protected static Color HsvToRgb(double h, double s, double v)
        {
            int hi = (int)Math.Floor(h / 60.0) % 6;
            double f = (h / 60.0) - Math.Floor(h / 60.0);

            double p = v * (1.0 - s);
            double q = v * (1.0 - (f * s));
            double t = v * (1.0 - ((1.0 - f) * s));

            Color ret;

            switch (hi)
            {
                case 0:
                    ret = GetRgb(v, t, p);
                    break;
                case 1:
                    ret = GetRgb(q, v, p);
                    break;
                case 2:
                    ret = GetRgb(p, v, t);
                    break;
                case 3:
                    ret = GetRgb(p, q, v);
                    break;
                case 4:
                    ret = GetRgb(t, p, v);
                    break;
                case 5:
                    ret = GetRgb(v, p, q);
                    break;
                default:
                    ret = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
                    break;
            }
            return ret;
        }

        protected static Color GetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r * 255.0), (byte)(g * 255.0), (byte)(b * 255.0));
        }
    }
}
