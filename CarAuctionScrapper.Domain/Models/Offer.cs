using CarAuctionScrapper.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScrapper.Domain.Models
{
    public class Offer
    {
        public string Url { get; set; }
        public Dictionary<string, string> Details { get; set; }
        public List<string> Features { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public List<ThumbnailImageUrl> ImageThumbnails { get; set; }
        public List<FullImageUrl> Images { get; set; }
        public Location Location { get; set; }
    }
}
