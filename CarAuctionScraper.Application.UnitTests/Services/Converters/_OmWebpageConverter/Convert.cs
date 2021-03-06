﻿using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace CarAuctionScraper.Application.UnitTests.Services.Converters._OmWebpageConverter
{
    [TestFixture]
    public class Convert : _TestBase
    {
        //[Test]
        //public void test()
        //{
        //    var result = new WebpageReaderService()
        //        .ReadWebpage("https://allegro.pl/ogloszenie/ford-mondeo-2-0-tdci-150km-powershift-serwisowany-9673392520")
        //        .ReadWebpage("https://allegro.pl/ogloszenie/opel-astra-astra-v-1-6-cdti-enjoy-salon-pl-1wl-gw-9680541458")
        //        .GetAwaiter()
        //        .GetResult()
        //        ;

        //    File.WriteAllText("D:\\temp3___.txt", result);
        //}

        [Test]
        public void ConvertData()
        {
            var htmlPart = ReadTestFile("offer_combined.txt");

            var result = Converter.Convert(htmlPart, "url");

            result.Should().NotBeNull();
            result.Description.Should().Be("Opis szczegółowy\r\n\r\nlinia niżej\r\nlinia niżej 2");

            result.Details.Select(x => x.Category).Should().Contain("Oferta od", "Kategoria");
            result.Details.FirstOrDefault(x => x.Category == "Oferta od")?.Value.Should().Be("Firmy");
            result.Details.FirstOrDefault(x => x.Category == "Kategoria")?.Value.Should().Be("Osobowe");

            result.Features.Should().HaveCount(4);
            result.Features.Select(x => x.Name).Should().Contain("ABS");
            result.Features.Select(x => x.Name).Should().Contain("Elektryczne szyby przednie");
            result.Features.Select(x => x.Name).Should().Contain("CD");
            result.Features.Select(x => x.Name).Should().Contain("Elektrycznie ustawiane lusterka");

            result.Images.Should().SatisfyRespectively(
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

            result.ImageThumbnails.Should().SatisfyRespectively(
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

            result.Location.Latitude.Should().Be(1.23456789);
            result.Location.Longitude.Should().Be(9.10111213);

            result.CurrentPrice.Value.Should().Be(49900);
        }
    }
}
