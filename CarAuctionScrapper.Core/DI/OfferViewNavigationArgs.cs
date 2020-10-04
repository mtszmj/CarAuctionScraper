using CarAuctionScrapper.Core.ViewModels;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScrapper.Core.DI
{
    public class OfferViewNavigationArgs
    {
        public IMvxViewModel ReturnViewModel { get; set; }
    }
}
