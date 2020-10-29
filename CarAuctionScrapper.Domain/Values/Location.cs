using CarAuctionScrapper.Domain.Base;
using System;
using System.Collections.Generic;

namespace CarAuctionScrapper.Domain.Values
{
    public class Location : ValueObject
    {
        protected Location() { }
        public Location(double latitude, double longitude) 
        {
            if (latitude > 90 || latitude < -90)
                throw new ArgumentException("Latitude must be in [-90,90]", nameof(latitude));
            if (longitude > 180 || longitude < -180)
                throw new ArgumentException("Latitude must be in [-180,180]", nameof(longitude));

            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }

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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
