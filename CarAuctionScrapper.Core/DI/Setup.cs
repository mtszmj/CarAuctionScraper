using CarAuctionScrapper.Core.Services;
using MvvmCross.IoC;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CarAuctionScrapper.Core.UnitTests")]
namespace CarAuctionScrapper.Core.DI
{
    public class Setup
    {
        public void Initialize(IMvxIoCProvider ioc)
        {
            ioc.RegisterType<IWebpageReaderService, WebpageReaderService>();
            ioc.RegisterType<IWebpageConverterService, WebpageConverterService>();
            ioc.RegisterType<IWebpageService, WebpageService>();
            
            ioc.RegisterSingleton<IBrowserService>(new BrowserService());
        }
    }
}
