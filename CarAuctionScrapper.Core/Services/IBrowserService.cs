using System.Threading.Tasks;

namespace CarAuctionScrapper.Core.Services
{
    public interface IBrowserService
    {
        void OpenWebsite(string url);
        Task OpenWebsiteAsync(string url);
    }
}