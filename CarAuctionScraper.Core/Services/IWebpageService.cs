namespace CarAuctionScraper.Core.Services
{
    public interface IWebpageService
    {
        IWebpageConverterService ConverterService { get; }
        IWebpageReaderService ReaderService { get; }
    }
}