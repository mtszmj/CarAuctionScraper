namespace CarAuctionScrapper.Core.Services
{
    public interface IWebpageService
    {
        IWebpageConverterService ConverterService { get; }
        IWebpageReaderService ReaderService { get; }
    }
}