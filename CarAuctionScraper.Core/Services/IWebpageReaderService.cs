using System.Threading.Tasks;

namespace CarAuctionScraper.Core.Services
{
    public interface IWebpageReaderService
    {
        Task<string> ReadWebpage(string url);
    }
}
