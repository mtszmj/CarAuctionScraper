using System.Threading.Tasks;

namespace CarAuctionScraper.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IOfferRepository OfferRepository { get; }

        public Task<bool> Save();
    }
}
