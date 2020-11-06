using CarAuctionScrapper.Domain.Interfaces;
using System.Linq;

namespace CarAuctionScrapper.Persistence
{
    public class CasRepository : ICasRepository
    {
        private readonly CasDbContext _dbContext;

        public CasRepository(CasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Count()
        {
            return _dbContext.Offers.Count();
        }
    }
}
