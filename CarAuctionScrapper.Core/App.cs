using CarAuctionScrapper.Core.DI;
using CarAuctionScrapper.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScrapper.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var setup = new Setup();

            setup.Initialize(Mvx.IoCProvider);

            RegisterAppStart<MainOffersViewModel>();
        }
    }
}
