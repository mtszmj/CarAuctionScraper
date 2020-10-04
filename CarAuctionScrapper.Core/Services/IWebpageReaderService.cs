using System.Threading.Tasks;

namespace CarAuctionScrapper.Core.Services
{
    public interface IWebpageReaderService
    {
        Task<string> ReadWebpage(string url);
    }
}
