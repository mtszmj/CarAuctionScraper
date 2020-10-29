namespace CarAuctionScrapper.Domain.Values
{
    public class ThumbnailImageUrl : ImageUrl
    {
        public ThumbnailImageUrl() { }
        public ThumbnailImageUrl(string src, string alt) : base(src, alt) { }
    }
}
