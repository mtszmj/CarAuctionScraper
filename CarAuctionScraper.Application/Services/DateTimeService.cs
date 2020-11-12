using CarAuctionScraper.Application.Interfaces.Services;
using System;

namespace CarAuctionScraper.Application.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTimeOffset Now()
        {
            return DateTimeOffset.Now;
        }

        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}
