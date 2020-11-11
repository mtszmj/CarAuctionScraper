using CarAuctionScraper.Domain.Models;
using CarAuctionScraper.Domain.Values;

namespace CarAuctionScraper.Core.Services
{
    public interface IWebpageConverterService
    {
        Offer Convert(string html, string url);
        Price ConvertPrice(string html);
    }
}