using CarAuctionScraper.Core.DI;
using CarAuctionScraper.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace CarAuctionScraper.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var setup = new Setup();
            setup.Initialize(Mvx.IoCProvider);

            var setupPersistence = new Persistence.Setup();
            setupPersistence.Initialize(Mvx.IoCProvider);

            RegisterAppStart<MainOffersViewModel>();
        }
    }
}
