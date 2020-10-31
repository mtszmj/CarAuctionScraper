namespace CarAuctionScrapper.Domain.Values
{
    public class ThumbnailImageUrl : ImageUrl
    {
        protected ThumbnailImageUrl() { }

        public ThumbnailImageUrl(string src, string alt) : base(src, alt) { }
    }
}
