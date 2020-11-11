using CarAuctionScraper.Core.Services;
using CarAuctionScraper.Core.Services.Converters;
using HtmlAgilityPack;
using NSubstitute;
using System;
using System.IO;
using System.Reflection;

namespace CarAuctionScraper.Core.UnitTests.Services.Converters._OmWebpageConverter
{
    public class _TestBase
    {
        public _TestBase()
        {
            var dateTimeService = Substitute.For<IDateTime>();
            dateTimeService.Now().Returns(new System.DateTimeOffset(2020, 10, 9, 8, 7, 6, TimeSpan.FromHours(1)));
            Converter = new OmWebpageConverter(dateTimeService);
        }

        protected OmWebpageConverter Converter { get; }

        protected string ReadTestFile(string filename) => File.ReadAllText(GetPathToTestFile(filename));

        protected string GetPathToTestFile(string filename)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
                @"Services\Converters\_OmWebpageConverter\TestFiles\", filename);
        }

        protected HtmlDocument LoadHtmlFromFile(string filename)
        {
            var htmlPart = ReadTestFile(filename);
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlPart);

            return doc;
        }

        protected HtmlDocument LoadHtmlFromText(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc;
        }


    }
}
