using CarAuctionScraper.Application.Interfaces.Services;

namespace CarAuctionScraper.Application.Services
{
    public class WebpageService : IWebpageService
    {
        public WebpageService(IWebpageReaderService readerService, IWebpageConverterService converterService)
        {
            ReaderService = readerService;
            ConverterService = converterService;
        }

        public IWebpageReaderService ReaderService { get; }
        public IWebpageConverterService ConverterService { get; }
    }
}
