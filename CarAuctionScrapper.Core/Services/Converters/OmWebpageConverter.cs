using CarAuctionScrapper.Domain.Models;
using CarAuctionScrapper.Domain.Values;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAuctionScrapper.Core.Services.Converters
{
    public class OmWebpageConverter
    {
        public Offer Convert(string html, string url)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return new Offer(
                url,
                ParseDetails(doc).Select(kv => new Detail(kv.Key, kv.Value)).ToList(),
                ParseFeatures(doc).Select(f => new Feature(f)).ToList(),
                ParseDescription(doc),
                ParsePrice(doc),
                ParseImageThumbnails(doc),
                ParseImages(doc),
                ParseLocation(doc)
            );
        }

        internal Dictionary<string, string> ParseDetails(HtmlDocument doc)
        {
            var details = new List<Detail>();

            var parameters = doc.DocumentNode.QuerySelector(".parametersArea");
            if (parameters is null)
                return details
                    .ToDictionary(x => x.Category, x => x.Value)
                    ;

            var listItems = parameters.QuerySelectorAll("li.offer-params__item");
            foreach (var item in listItems)
            {
                var labelNode = item.QuerySelector(".offer-params__label");
                var valueNode = item.QuerySelector(".offer-params__value");

                var label = labelNode.InnerText.Trim();
                var value = valueNode.InnerText.Trim();

                if (string.IsNullOrWhiteSpace(label) || string.IsNullOrWhiteSpace(value))
                    continue;
                
                details.Add(new Detail(label, value));
            }

            return details
                .ToDictionary(x => x.Category, x => x.Value)
                ;
        }


        internal List<string> ParseFeatures(HtmlDocument doc)
        {
            var features = doc.DocumentNode.QuerySelectorAll(".offer-features .offer-features__row ul li");
            return features.Select(x => x.InnerText.Trim())
                           .Where(x => !string.IsNullOrWhiteSpace(x))
                           .Distinct()
                           .OrderBy(x => x)
                           .Select(x => new Feature(x))
                           .ToList()

                           .Select(test => test.Name).ToList()
                           ;


        }


        internal string ParseDescription(HtmlDocument doc)
        {
            var description = doc.DocumentNode.QuerySelector(".offer-description__description");
            if (description is null) return null;

            var descriptionTextArray = description.InnerText.Trim().Split('\n');
            return string.Join(Environment.NewLine, descriptionTextArray.Select(x => x.Trim()));
        }

        internal decimal? ParsePrice(HtmlDocument doc)
        {
            var price = doc.DocumentNode.QuerySelector(".offer-price");
            var priceValue = price?.Attributes["data-price"]?.Value;
            if (decimal.TryParse(priceValue, out var res))
                return res;

            return null;
        }

        internal List<ThumbnailImageUrl> ParseImageThumbnails(HtmlDocument doc)
        {
            var links = doc.DocumentNode.QuerySelectorAll(".offer-photos-thumbs img");

            var images = new List<ThumbnailImageUrl>();
            foreach (var link in links)
            {
                var src = link.Attributes["src"]?.Value;
                var alt = link.Attributes["alt"]?.Value;
                if (src is null || alt is null)
                    continue;

                images.Add(new ThumbnailImageUrl(src, alt));
            }

            return images;
        }

        internal List<FullImageUrl> ParseImages(HtmlDocument doc)
        {
            var links = doc.DocumentNode.QuerySelectorAll(".om-offer-photos img");

            var images = new List<FullImageUrl>();
            foreach (var link in links)
            {
                var src = link.Attributes["data-lazy"]?.Value;
                var alt = link.Attributes["alt"]?.Value;
                if (src is null || alt is null)
                    continue;

                images.Add(new FullImageUrl(src, alt));
            }

            return images;
        }

        internal Location ParseLocation(HtmlDocument doc)
        {
            var latlng = doc.DocumentNode.QuerySelector(".map-box input");
            if (latlng is null)
                return null;

            var lat = latlng.Attributes["data-map-lat"].Value;
            var lng = latlng.Attributes["data-map-lon"].Value;

            var latOk = double.TryParse(lat, out var latitude);
            var lngOk = double.TryParse(lng, out var longitude);

            if (latOk && lngOk)
                return new Location(latitude, longitude);

            return null;
        }
    }
}
