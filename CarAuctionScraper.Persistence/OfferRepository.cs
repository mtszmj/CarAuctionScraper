using CarAuctionScraper.Domain.Interfaces;
using CarAuctionScraper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarAuctionScraper.Persistence
{
    public class OfferRepository : IOfferRepository
    {
        private readonly CasDbContext _dbContext;

        public OfferRepository(CasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Offer offer, CancellationToken token = default)
        {
            await _dbContext.AddAsync(offer, token);
        }

        public List<Offer> GetAll()
        {
            return _dbContext.Offers.ToList();
        }

        public int Count()
        {
            return _dbContext.Offers.Count();
        }
    }
}
