using CarAuctionScrapper.Domain.Models;
using CarAuctionScrapper.Domain.Values;

namespace CarAuctionScrapper.Core.Services
{
    public interface IWebpageConverterService
    {
        Offer Convert(string html, string url);
        Price ConvertPrice(string html);
    }
}