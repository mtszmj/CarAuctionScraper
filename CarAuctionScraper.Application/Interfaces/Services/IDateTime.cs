using System;

namespace CarAuctionScraper.Application.Interfaces.Services
{
    public interface IDateTime
    {
        DateTimeOffset Now();
        DateTime Today();
    }
}
