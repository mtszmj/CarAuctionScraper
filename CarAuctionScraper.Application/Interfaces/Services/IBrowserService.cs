using System.Threading.Tasks;

namespace CarAuctionScraper.Application.Interfaces.Services
{
    public interface IBrowserService
    {
        void OpenWebsite(string url);
        Task OpenWebsiteAsync(string url);
    }
}