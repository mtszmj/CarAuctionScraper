using System.Threading.Tasks;

namespace CarAuctionScraper.Core.Services
{
    public interface IBrowserService
    {
        void OpenWebsite(string url);
        Task OpenWebsiteAsync(string url);
    }
}