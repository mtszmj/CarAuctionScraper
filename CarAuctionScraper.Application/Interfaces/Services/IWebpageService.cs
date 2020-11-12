namespace CarAuctionScraper.Application.Interfaces.Services
{
    public interface IWebpageService
    {
        IWebpageConverterService ConverterService { get; }
        IWebpageReaderService ReaderService { get; }
    }
}