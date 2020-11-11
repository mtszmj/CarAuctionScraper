using FluentAssertions;
using NUnit.Framework;

namespace CarAuctionScraper.Core.UnitTests.Services.Converters._OmWebpageConverter
{
    [TestFixture]
    public class ParseLocation : _TestBase
    {
        [Test]
        public void parses_location()
        {
            var doc = LoadHtmlFromFile("offer_location.txt");

            var result = Converter.ParseLocation(doc);

            result.Latitude.Should().Be(1.23456789);
            result.Longitude.Should().Be(9.10111213);
        }

        [Test]
        public void returns_null_when_no_location()
        {
            var doc = LoadHtmlFromText("");

            var result = Converter.ParseLocation(doc);

            result.Should().BeNull();
        }

        [Test]
        public void returns_null_when_no_correct_latitude()
        {
            var doc = LoadHtmlFromText(@"<div class=""map-box"">
                                <input type=""hidden""
                                    data-map-lat=""abc""
                                    data-map-lon=""9.10111213""
                                />
                            </div>");

            var result = Converter.ParseLocation(doc);

            result.Should().BeNull();
        }

        [Test]
        public void returns_null_when_no_correct_longitude()
        {
            var doc = LoadHtmlFromText(@"<div class=""map-box"">
                                <input type=""hidden""
                                    data-map-lat=""1.23456789""
                                    data-map-lon=""abc""
                                />
                            </div>");

            var result = Converter.ParseLocation(doc);

            result.Should().BeNull();
        }
    }
}
