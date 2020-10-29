using CarAuctionScrapper.Core.DI;
using CarAuctionScrapper.Domain.Models;
using CarAuctionScrapper.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAuctionScrapper.Domain.Values;

namespace CarAuctionScrapper.Core.ViewModels
{
    public class OfferViewModel : MvxViewModel<OfferViewNavigationArgs>
    {
        private readonly IBrowserService _browserService;
        private readonly IMvxNavigationService _navigationService;

        public OfferViewModel(IBrowserService browserService, IMvxNavigationService navigationService)
        {
            NavigateToUrlCommand = new MvxAsyncCommand(NavigateToUrl);
            GoBackCommand = new MvxAsyncCommand(GoBack);
            _browserService = browserService;
            _navigationService = navigationService;
        }

        private Offer _offer;

        public Offer Offer
        {
            get => _offer;
            set => SetProperty(ref _offer, value, async () => await RaiseAllPropertiesChanged());
        }

        public string this[string detail]
        {
            get
            {
                string value = default;
                return Offer?.Details.TryGetValue(detail, out value) == true ? value : default;
            }
        }

        public List<string> CommonFeatures
        {
            get => _commonFeatures;
            set => SetProperty(ref _commonFeatures, value, async () => await RaisePropertyChanged(nameof(DistinctFeatures)));
        }

        public List<string> DistinctFeatures => Offer.Features.Except(CommonFeatures ?? Enumerable.Empty<string>()).ToList();

        public Uri ImageThumbnail => Offer?.ImageThumbnails?.FirstOrDefault()?.Src is null
            ? null : new Uri(Offer?.ImageThumbnails?.FirstOrDefault()?.Src);

        public string ShortDescription
        {
            get
            {
                string desc;
                if ((Offer.Description?.Length ?? 0) > 200)
                    desc = Offer.Description.Substring(0, 200) + "(...)";
                else desc = Offer.Description;

                return desc?.Replace(Environment.NewLine, "\t");
                //return Offer?.Description.Substring(0, (Offer.Description?.Length ?? 0) > 200 ? 200 : Offer.Description.Length).Replace(Environment.NewLine, "\t");
            }
        }

        private Location HomeLocation = new Location { Latitude = 50.297552, Longitude = 18.954473 };
        private List<string> _commonFeatures;

        public double? Distance => Offer?.Location?.Distance(HomeLocation);

        public IMvxAsyncCommand NavigateToUrlCommand { get; private set; }
        public IMvxAsyncCommand GoBackCommand { get; private set; }


        public async Task NavigateToUrl()
        {
            if (Offer?.Url is null)
                return;

            await _browserService.OpenWebsiteAsync(Offer.Url);
        }

        public async Task GoBack()
        {
            if(ReturnViewModel is null)
                await _navigationService.Navigate<MainOffersViewModel>();

            await _navigationService.Navigate(ReturnViewModel);
        }

        public override void Prepare(OfferViewNavigationArgs parameter)
        {
            if (parameter is null)
                return;

            ReturnViewModel = parameter.ReturnViewModel;
        }

        IMvxViewModel ReturnViewModel { get; set; }
    }
}
