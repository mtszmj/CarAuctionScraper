﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CarAuctionScraper.Persistence
{
    public class CasDbContextFactory : IDesignTimeDbContextFactory<CasDbContext>
    {
        private IConfigurationRoot Configuration { get; set; }

        public CasDbContext CreateDbContext(string[] args)
        {
            PrepareConfiguration();
            var connection = Configuration.GetConnectionString("SqliteDataConnection");
            return new CasDbContext(
                new DbContextOptionsBuilder().UseSqlite(connection).Options);
        }

        public void PrepareConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
