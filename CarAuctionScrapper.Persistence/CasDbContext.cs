using CarAuctionScrapper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarAuctionScrapper.Persistence
{
    public class CasDbContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }

        public CasDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CasDbContext).Assembly);
        }
    }
}
