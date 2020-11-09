using System.Threading.Tasks;

namespace CarAuctionScrapper.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IOfferRepository OfferRepository { get; }

        public Task<bool> Save();
    }
}
