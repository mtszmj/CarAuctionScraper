using FluentAssertions;
using NUnit.Framework;
using System.Linq;

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

            result.Select(x => x.Category).Should().Contain("Oferta od", "Kategoria");
            result.First(x => x.Category == "Oferta od").Value.Should().Be("Firmy");
            result.First(x => x.Category == "Kategoria").Value.Should().Be("Osobowe");
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
