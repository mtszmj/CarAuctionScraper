using CarAuctionScrapper.Domain.Models;
using CarAuctionScrapper.Core.Services.Converters;
using HtmlAgilityPack;
using CarAuctionScrapper.Domain.Values;
using System;

namespace CarAuctionScrapper.Core.Services
{
    public class WebpageConverterService : IWebpageConverterService
    {
        public WebpageConverterService(IDateTime dateTimeService)
        {
            OmConverter = new OmWebpageConverter(dateTimeService);
        }

        OmWebpageConverter OmConverter { get; } 

        public Offer Convert(string html, string url)
        {
            if (html is null)
                return null;

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return OmConverter.Convert(html, url);
        }

        public Price ConvertPrice(string html)
        {
            if (html is null)
                return null;

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return OmConverter.ParsePrice(doc);
        }
    }
}
