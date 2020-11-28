using CarAuctionScraper.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using System;
using System.IO;

namespace CarAuctionScraper.Persistence
{
    public class Setup
    {
        private IConfigurationRoot Configuration { get; set; }

        public void Initialize(IMvxIoCProvider ioc)
        {
            PrepareConfiguration();
            var sqlServerConnection = Configuration.GetConnectionString("SqlServerDataConnection");
            var sqliteConnection = Configuration.GetConnectionString("SqliteDataConnection");
            Mvx.IoCProvider.RegisterSingleton(() => new CasDbContext(
                new DbContextOptionsBuilder()
                    //.UseSqlServer(sqlServerConnection).Options
                    .UseSqlite(sqliteConnection)
                    .Options
                    )
            );
            Mvx.IoCProvider.RegisterType<IOfferRepository, OfferRepository>();
            Mvx.IoCProvider.RegisterType<IUnitOfWork, UnitOfWork>();
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
