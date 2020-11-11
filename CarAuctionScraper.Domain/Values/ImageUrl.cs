using CarAuctionScraper.Domain.Base;
using System;
using System.Collections.Generic;

namespace CarAuctionScraper.Domain.Values
{
    public abstract class ImageUrl : ValueObject
    {
        protected ImageUrl() { }

        public ImageUrl(string src, string alt)
        {
            if(string.IsNullOrWhiteSpace(src))
                throw new ArgumentException("Source link cannot be empty");

            Src = src;
            Alt = alt;
        }

        public string Src { get; }
        public string Alt { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Src;
            yield return Alt;
        }
    }
}
