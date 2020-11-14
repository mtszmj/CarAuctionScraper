using CarAuctionScraper.Application.Interfaces.Services;
using CarAuctionScraper.Application.Services;
using MaterialDesignThemes.Wpf;
using MvvmCross.IoC;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CarAuctionScraper.Core.UnitTests")]
namespace CarAuctionScraper.Core.DI
{
    public class Setup
    {
        public void Initialize(IMvxIoCProvider ioc)
        {
            ioc.RegisterType<IWebpageReaderService, WebpageReaderService>();
            ioc.RegisterType<IWebpageConverterService, WebpageConverterService>();
            ioc.RegisterType<IWebpageService, WebpageService>();
            ioc.RegisterType<IDateTime, DateTimeService>();

            ioc.RegisterSingleton<IBrowserService>(new BrowserService());
            
        }
    }
}
