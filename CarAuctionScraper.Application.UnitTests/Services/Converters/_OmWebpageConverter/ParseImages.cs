using FluentAssertions;
using NUnit.Framework;

namespace CarAuctionScraper.Application.UnitTests.Services.Converters._OmWebpageConverter
{
    [TestFixture]
    public class ParseImages : _TestBase
    {
        [Test]
        public void parses_images_links()
        {
            var doc = LoadHtmlFromFile("offer_image.txt");

            var result = Converter.ParseImages(doc);

            result.Should().SatisfyRespectively(
                first =>
                {
                    first.Src.Should().Be("https://xyz.unit.test.com/v1/files/qwerty11/image;s=148x110");
                    first.Alt.Should().Be("AEIOUY - 1");
                },
                second =>
                {
                    second.Src.Should().Be("https://xyz.unit.test.com/v1/files/qwerty22/image;s=148x110");
                    second.Alt.Should().Be("AEIOUY - 2");
                }
            );
        }

        [Test]
        public void returns_empty_list_when_no_match_of_images()
        {
            var doc = LoadHtmlFromText("");

            var result = Converter.ParseImages(doc);

            result.Should().BeEmpty();
        }
    }
}
