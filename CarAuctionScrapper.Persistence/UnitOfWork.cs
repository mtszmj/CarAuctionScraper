using CarAuctionScrapper.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarAuctionScrapper.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CasDbContext _dbContext;

        public UnitOfWork(CasDbContext dbContext, IOfferRepository repository)
        {
            _dbContext = dbContext;
            OfferRepository = repository;
        }

        public IOfferRepository OfferRepository { get; }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() != 0;
        }
    }
}
