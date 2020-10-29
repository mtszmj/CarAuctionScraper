using CarAuctionScrapper.Domain.Models;
using CarAuctionScrapper.Domain.Values;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace CarAuctionScrapper.Core.Services.Converters
{
    public class OmWebpageConverter
    {
        private OmWebpageConverterPlain _plainConverter = new OmWebpageConverterPlain();

        public Offer Convert(string html, string url)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return new Offer(
                url,
                _plainConverter.ParseDetails(doc).Select(kv => new Detail(kv.Key, kv.Value)).ToList(),
                _plainConverter.ParseFeatures(doc).Select(f => new Feature(f)).ToList(),
                _plainConverter.ParseDescription(doc),
                _plainConverter.ParsePrice(doc),
                _plainConverter.ParseImageThumbnails(doc),
                _plainConverter.ParseImages(doc),
                _plainConverter.ParseLocation(doc)
            );
        }

        internal Dictionary<string, string> ParseDetails(HtmlDocument doc)
            => _plainConverter.ParseDetails(doc);


        internal List<string> ParseFeatures(HtmlDocument doc)
            => _plainConverter.ParseFeatures(doc);


        internal string ParseDescription(HtmlDocument doc)
            => _plainConverter.ParseDescription(doc);

        internal decimal? ParsePrice(HtmlDocument doc)
            => _plainConverter.ParsePrice(doc);

        internal List<ThumbnailImageUrl> ParseImageThumbnails(HtmlDocument doc)
            => _plainConverter.ParseImageThumbnails(doc);

        internal List<FullImageUrl> ParseImages(HtmlDocument doc)
            => _plainConverter.ParseImages(doc);

        internal Location ParseLocation(HtmlDocument doc)
            => _plainConverter.ParseLocation(doc);
    }
}
