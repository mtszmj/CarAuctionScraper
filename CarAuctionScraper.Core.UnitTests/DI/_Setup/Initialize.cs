using CarAuctionScraper.Application.Interfaces.Services;
using CarAuctionScraper.Application.Services;
using CarAuctionScraper.Core.DI;
using FluentAssertions;
using MaterialDesignThemes.Wpf;
using MvvmCross.IoC;
using NUnit.Framework;

namespace CarAuctionScraper.Core.UnitTests.DI._Setup
{
    [TestFixture]
    public class Initialize
    {
        [Test]
        public void resolves_correct_types()
        {
            // arrange
            IMvxIoCProvider ioc = MvxIoCProvider.Initialize();
            var setup = new Setup();

            // act
            setup.Initialize(ioc);

            // assert
            ioc.Resolve<IWebpageReaderService>().Should().BeOfType<WebpageReaderService>();
            ioc.Resolve<IWebpageConverterService>().Should().BeOfType<WebpageConverterService>();
            ioc.Resolve<IWebpageService>().Should().BeOfType<WebpageService>();
            ioc.Resolve<IDateTime>().Should().BeOfType<DateTimeService>();

            ioc.Resolve<IBrowserService>().Should().BeOfType<BrowserService>();
        }

        [Test]
        public void browser_service_is_singleton()
        {
            // arrange
            IMvxIoCProvider ioc = MvxIoCProvider.Initialize();
            var setup = new Setup();

            // act
            setup.Initialize(ioc);

            // assert
            var service1 = ioc.Resolve<IBrowserService>();
            var service2 = ioc.Resolve<IBrowserService>();

            service1.Should().Be(service2);

        }
    }
}
