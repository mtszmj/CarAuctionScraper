using FluentAssertions;
using NUnit.Framework;
using System;

namespace CarAuctionScrapper.Core.UnitTests.Services.Converters._OmWebpageConverter
{
    [TestFixture]
    public class ParseDescription : _TestBase
    {
        [Test]
        public void parses_offer_description()
        {
            var doc = LoadHtmlFromFile("offer_description.txt");

            var result = Converter.ParseDescription(doc);

            result.Should()
                .Be($"Opis szczegółowy{Environment.NewLine}{Environment.NewLine}linia niżej{Environment.NewLine}linia niżej 2");
        }

        [Test]
        public void returns_null_when_no_description()
        {
            var doc = LoadHtmlFromText("");

            var result = Converter.ParseDescription(doc);

            result.Should().BeNull();
        }
    }
}
