using CarAuctionScrapper.Domain.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CarAuctionScrapper.Domain.Values
{
    public class Feature : ValueObject, IComparable<Feature>
    {
        protected Feature() { }

        public Feature(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Feature name cannot be null nor empty", nameof(name));

            Name = name;
        }

        public string Name { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        public int CompareTo([AllowNull] Feature other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
