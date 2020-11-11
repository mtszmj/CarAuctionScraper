using CarAuctionScraper.Core.ViewModels;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScraper.Core.DI
{
    public class OfferViewNavigationArgs
    {
        public IMvxViewModel ReturnViewModel { get; set; }
    }
}
