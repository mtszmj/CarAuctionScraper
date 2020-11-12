using CarAuctionScraper.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MvvmCross;
using MvvmCross.IoC;
using System.IO;

namespace CarAuctionScraper.Persistence
{
    public class Setup
    {
        private IConfigurationRoot Configuration { get; set; }

        public void Initialize(IMvxIoCProvider ioc)
        {
            PrepareConfiguration();
            var connection = Configuration.GetConnectionString("DataConnection");
            Mvx.IoCProvider.RegisterSingleton(() => new CasDbContext(
                new DbContextOptionsBuilder().UseSqlServer(connection).Options));
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
