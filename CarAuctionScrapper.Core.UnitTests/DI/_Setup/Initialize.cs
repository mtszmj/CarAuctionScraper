using CarAuctionScrapper.Core.DI;
using CarAuctionScrapper.Core.Services;
using FluentAssertions;
using MvvmCross.IoC;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScrapper.Core.UnitTests.DI._Setup
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
