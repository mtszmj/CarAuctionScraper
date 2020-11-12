using FluentAssertions;
using NUnit.Framework;
using System;

namespace CarAuctionScraper.Application.UnitTests.Services.Converters._OmWebpageConverter
{
    [TestFixture]
    public class ParsePrice : _TestBase
    {
        [Test]
        public void parses_offer_price()
        {
            var doc = LoadHtmlFromFile("offer_price.txt");

            var result = Converter.ParsePrice(doc);

            result.Value.Should().Be(49900);
            result.Date.Should().Be(new DateTimeOffset(2020, 10, 9, 8, 7, 6, TimeSpan.FromHours(1)));
        }

        [Test]
        public void returns_null_when_no_price()
        {
            var doc = LoadHtmlFromText("");

            var result = Converter.ParsePrice(doc);

            result.Should().BeNull();
        }
    }
}
