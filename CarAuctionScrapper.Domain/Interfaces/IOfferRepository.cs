using CarAuctionScrapper.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarAuctionScrapper.Domain.Interfaces
{
    public interface IOfferRepository
    {
        int Count();
        Task Add(Offer offer, CancellationToken token = default);
        List<Offer> GetAll();
    }
}
