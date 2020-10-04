using CarAuctionScrapper.Core.Services.Converters;
using HtmlAgilityPack;
using System.IO;
using System.Reflection;

namespace CarAuctionScrapper.Core.UnitTests.Services.Converters._OmWebpageConverter
{
    public class _TestBase
    {
        protected OmWebpageConverter Converter { get; } = new OmWebpageConverter();

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
