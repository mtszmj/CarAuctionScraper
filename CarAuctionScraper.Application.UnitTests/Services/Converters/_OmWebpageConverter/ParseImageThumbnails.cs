using FluentAssertions;
using NUnit.Framework;

namespace CarAuctionScraper.Application.UnitTests.Services.Converters._OmWebpageConverter
{
    [TestFixture]
    public class ParseImageThumbnails : _TestBase
    {
        [Test]
        public void parses_image_thumnails_links()
        {
            var doc = LoadHtmlFromFile("offer_image_thumbnails.txt");

            var result = Converter.ParseImageThumbnails(doc);

            result.Should().SatisfyRespectively(
                first =>
                {
                    first.Src.Should().Be("https://xyz.unit.test.com/v1/files/qwerty1/image;s=148x110");
                    first.Alt.Should().Be("aeiouy - 1");
                },
                second =>
                {
                    second.Src.Should().Be("https://xyz.unit.test.com/v1/files/qwerty2/image;s=148x110");
                    second.Alt.Should().Be("aeiouy - 2");
                }
            );
        }

        [Test]
        public void returns_empty_list_when_no_match_of_image_thumbnails()
        {
            var doc = LoadHtmlFromText("");

            var result = Converter.ParseImageThumbnails(doc);

            result.Should().BeEmpty();
        }
    }
}
