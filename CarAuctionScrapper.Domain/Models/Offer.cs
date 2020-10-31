using CarAuctionScrapper.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarAuctionScrapper.Domain.Models
{
    public class Offer
    {
        public Offer() { }

        public Offer(string url, IList<Detail> details, 
            IList<Feature> features, string description, decimal? price, 
            IList<ThumbnailImageUrl> thumbnails, IList<FullImageUrl> images, 
            Location location)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Url cannor be empty", nameof(url));
            if (details is null)
                throw new ArgumentException("Details cannot be null", nameof(details));
            if (features is null)
                throw new ArgumentException("Features cannot be null", nameof(features));
            if (description is null)
                throw new ArgumentException("Description cannot be null", nameof(details));
            if (thumbnails is null)
                throw new ArgumentException("Thumbnails cannot be null", nameof(thumbnails));
            if (images is null)
                throw new ArgumentException("Images cannot be null", nameof(images));
            if (location is null)
                throw new ArgumentException("Location cannot be null", nameof(location));

            Url = url;
            Details = details;
            Features = features;
            Description = description;
            Price = price;
            ImageThumbnails = thumbnails;
            Images = images;
            Location = location;
        }


        public string Url { get; set; }
        public IList<Detail> Details { get; set; }
        public IList<Feature> Features { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public IList<ThumbnailImageUrl> ImageThumbnails { get; set; }
        public IList<FullImageUrl> Images { get; set; }
        public Location Location { get; set; }
    }
}
