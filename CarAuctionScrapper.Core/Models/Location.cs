using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScrapper.Core.Models
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double Distance(Location other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            const double R = 6371e3;
            double latitude1InRadians = ToRadians(Latitude);
            double latitude2InRadians = ToRadians(other.Latitude);
            double latitudeDelta = ToRadians(Latitude - other.Latitude);
            double longitudeDelta = ToRadians(Longitude - other.Longitude);

            double a = Math.Sin(latitudeDelta / 2.0) * Math.Sin(latitudeDelta / 2.0)
                + Math.Cos(latitude1InRadians) * Math.Cos(latitude2InRadians)
                * Math.Sin(longitudeDelta / 2.0) * Math.Sin(longitudeDelta / 2.0)
                ;

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return Math.Round(R * c / 1000.0, 2);

            double ToRadians(double degrees)
            {
                return degrees * Math.PI / 180.0;
            }
        }
    }
}
