using CarAuctionScraper.Domain.Models;
using CarAuctionScraper.Application.Services.Converters;
using HtmlAgilityPack;
using CarAuctionScraper.Domain.Values;
using System;
using CarAuctionScraper.Application.Interfaces.Services;

namespace CarAuctionScraper.Application.Services
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
