using System.Threading.Tasks;

namespace CarAuctionScraper.Application.Interfaces.Services
{
    public interface IWebpageReaderService
    {
        Task<string> ReadWebpage(string url);
    }
}
