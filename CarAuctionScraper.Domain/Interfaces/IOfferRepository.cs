using CarAuctionScraper.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarAuctionScraper.Domain.Interfaces
{
    public interface IOfferRepository
    {
        int Count();
        Task Add(Offer offer, CancellationToken token = default);
        List<Offer> GetAll();
    }
}
