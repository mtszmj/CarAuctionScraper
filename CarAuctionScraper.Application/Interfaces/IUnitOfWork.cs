using System.Threading.Tasks;

namespace CarAuctionScraper.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IOfferRepository OfferRepository { get; }

        public Task<bool> Save();
    }
}
