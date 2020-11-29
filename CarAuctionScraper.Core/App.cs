using CarAuctionScraper.Core.DI;
using CarAuctionScraper.Core.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.ViewModels;
using Serilog;
using System.IO;

namespace CarAuctionScraper.Core
{
    public class App : MvxApplication
    {
        private IConfigurationRoot Configuration { get; set; }

        public override void Initialize()
        {
            PrepareConfiguration();

            var setup = new Setup();
            setup.Initialize(Mvx.IoCProvider);

            var setupPersistence = new Persistence.Setup();
            setupPersistence.Initialize(Mvx.IoCProvider);

            RegisterAppStart<MainOffersViewModel>();
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
