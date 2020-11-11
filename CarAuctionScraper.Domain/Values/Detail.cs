using CarAuctionScraper.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScraper.Domain.Values
{
    public class Detail : ValueObject
    {
        protected Detail() { }

        public Detail(string category, string value) 
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be null nor whitespace", nameof(category));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Category cannot be null nor whitespace", nameof(value));

            Category = category;
            Value = value;
        }

        public string Category { get; }
        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Category;
            yield return Value;
        }
    }
}
