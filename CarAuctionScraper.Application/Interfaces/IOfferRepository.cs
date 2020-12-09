using CarAuctionScraper.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarAuctionScraper.Application.Interfaces
{
    public interface IOfferRepository
    {
        int Count();
        Task Add(Offer offer, CancellationToken token = default);
        void Remove(Offer offer);
        Task<List<Offer>> GetAll();
    }
}
