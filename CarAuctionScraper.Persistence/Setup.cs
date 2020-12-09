using CarAuctionScraper.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Logging;
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

            ioc.RegisterSingleton(() => new CasDbContext(
                new DbContextOptionsBuilder()
                    //.UseSqlServer(sqlServerConnection).Options
                    .UseSqlite(sqliteConnection)
                    .EnableSensitiveDataLogging()
                    .LogTo(msg => Mvx.IoCProvider.Resolve<IMvxLog>().Info(msg))
                    .Options
                    )
            );
            ioc.RegisterType<IOfferRepository, OfferRepository>();
            ioc.RegisterType<IUnitOfWork, UnitOfWork>();
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
