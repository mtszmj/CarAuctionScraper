using System;

namespace CarAuctionScrapper.Core.Services
{
    public interface IDateTime
    {
        DateTimeOffset Now();
        DateTime Today();
    }
}
