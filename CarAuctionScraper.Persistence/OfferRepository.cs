﻿using CarAuctionScraper.Application.Interfaces;
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

        public Task<List<Offer>> GetAll()
        {
            return _dbContext.Offers
                .Include(x => x.Details)
                .Include(x => x.Features)
                .Include(x => x.Prices)
                .Include(x => x.ImageThumbnails)
                .Include(x => x.Images)
                .Include(x => x.Location)
                .AsSplitQuery()
                .ToListAsync();
        }

        public int Count()
        {
            return _dbContext.Offers.Count();
        }

        public void Remove(Offer offer)
        {
            _dbContext.Remove(offer);
        }
    }
}
