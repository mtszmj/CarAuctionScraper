using System;

namespace CarAuctionScrapper.Core.Services
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
