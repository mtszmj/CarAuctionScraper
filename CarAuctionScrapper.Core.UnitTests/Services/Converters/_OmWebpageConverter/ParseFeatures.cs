using FluentAssertions;
using NUnit.Framework;

namespace CarAuctionScrapper.Core.UnitTests.Services.Converters._OmWebpageConverter
{
    [TestFixture]
    public class ParseFeatures : _TestBase
    {
        [Test]
        public void parses_offer_features()
        {
            var doc = LoadHtmlFromFile("offer_features.txt");

            var result = Converter.ParseFeatures(doc);

            result.Should().HaveCount(4);
            result.Should().Contain("ABS");
            result.Should().Contain("Elektryczne szyby przednie");
            result.Should().Contain("CD");
            result.Should().Contain("Elektrycznie ustawiane lusterka");
        }

        [Test]
        public void returns_empty_list_when_no_match()
        {
            var doc = LoadHtmlFromText("");

            var result = Converter.ParseFeatures(doc);

            result.Should().BeEmpty();
        }
    }
}
