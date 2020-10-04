using FluentAssertions;
using NUnit.Framework;

namespace CarAuctionScrapper.Core.UnitTests.Services.Converters._OmWebpageConverter
{
    [TestFixture]
    public class ParseDetails : _TestBase
    {
        [Test]
        public void parses_offer_parameters()
        {
            var doc = LoadHtmlFromFile("offer_parameters.txt");

            var result = Converter.ParseDetails(doc);

            result.Should().ContainKeys("Oferta od", "Kategoria");
            result["Oferta od"].Should().Be("Firmy");
            result["Kategoria"].Should().Be("Osobowe");
        }

        [Test]
        public void returns_empty_dictionary_when_no_match()
        {
            var doc = LoadHtmlFromText("");

            var result = Converter.ParseDetails(doc);

            result.Should().BeEmpty();
        }
    }
}
