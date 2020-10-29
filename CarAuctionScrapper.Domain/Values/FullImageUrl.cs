namespace CarAuctionScrapper.Domain.Values
{
    public class FullImageUrl : ImageUrl
    {
        public FullImageUrl() { }
        public FullImageUrl(string src, string alt) : base(src, alt) { }
    }
}
