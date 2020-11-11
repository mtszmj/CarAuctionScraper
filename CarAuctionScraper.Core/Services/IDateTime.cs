using System;

namespace CarAuctionScraper.Core.Services
{
    public interface IDateTime
    {
        DateTimeOffset Now();
        DateTime Today();
    }
}
