namespace CarAuctionScraper.Domain.Values
{
    public class FullImageUrl : ImageUrl
    {
        protected FullImageUrl() { }

        public FullImageUrl(string src, string alt) : base(src, alt) { }
    }
}
