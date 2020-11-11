using CarAuctionScraper.Domain.Base;
using System;
using System.Collections.Generic;

namespace CarAuctionScraper.Domain.Values
{
    public class Price : ValueObject
    {
        protected Price() { }

        public Price(decimal value, DateTimeOffset date)
        {
            if (value < 0)
                throw new ArgumentException("Price value cannot be below 0", nameof(value));

            Value = value;
            Date = date;
        }

        public decimal Value { get; }
        public DateTimeOffset Date { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Date;
        }

        public static IComparer<Price> ByDateComparer() 
            => Comparer<Price>.Create((x, y) => x.Date.CompareTo(y.Date));

        public static IComparer<Price> ByValueComparer() 
            => Comparer<Price>.Create((x, y) => x.Value.CompareTo(y.Value));
    }
}
