using CarAuctionScrapper.Domain.Models;

namespace CarAuctionScrapper.Core.Services
{
    public interface IWebpageConverterService
    {
        Offer Convert(string html, string url);
    }
}