using CarAuctionScraper.Domain.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAuctionScraper.Domain.Values;
using CarAuctionScraper.Application.Interfaces.Services;
using CarAuctionScraper.Core.Args;

namespace CarAuctionScraper.Core.ViewModels
{
    public class OfferViewModel : MvxViewModel<OfferViewNavigationArgs>
    {
        private readonly IBrowserService _browserService;
        private readonly IMvxNavigationService _navigationService;

        private Offer _offer;
        private Uri _uri;
        private Location HomeLocation = new Location(50.2657025, 19.0249066);
        private List<Feature> _commonFeatures;
        
        public OfferViewModel(IBrowserService browserService, IMvxNavigationService navigationService, Offer offer)
        {
            NavigateToUrlCommand = new MvxAsyncCommand(NavigateToUrl);
            GoBackCommand = new MvxAsyncCommand(GoBack);
            _browserService = browserService;
            _navigationService = navigationService;
            _offer = offer;
            _uri = new Uri(offer.ImageThumbnails?.OrderBy(x => x.Src)?.FirstOrDefault().Src ?? string.Empty);
        }

        public string this[string detail]
        {
            get
            {
                string value = default;
                return Offer?.Details.FirstOrDefault(x => x.Category == detail)?.Value ?? value;
            }
        }

        public Offer Offer
        {
            get => _offer;
        }

        public List<Feature> CommonFeatures
        {
            get => _commonFeatures;
            set => SetProperty(ref _commonFeatures, value, async () => await RaisePropertyChanged(nameof(DistinctFeatures)));
        }

        public List<Feature> DistinctFeatures => Offer.Features.Except(CommonFeatures ?? Enumerable.Empty<Feature>()).OrderBy(x => x.Name).ToList();

        public Uri ImageThumbnail => _uri;

        public bool ImageExists => ImageThumbnail != null;

        public string ShortDescription
        {
            get
            {
                string desc;
                if ((Offer.Description?.Length ?? 0) > 200)
                    desc = Offer.Description.Substring(0, 200) + "(...)";
                else desc = Offer.Description;

                return desc?.Replace(Environment.NewLine, "\t");
            }
        }

        public bool IsNotCrashed => this["Bezwypadkowy"]?.ToUpperInvariant()?.Equals("TAK") ?? false;
        public bool IsPolish => this["Kraj pochodzenia"]?.ToUpperInvariant()?.Equals("POLSKA") ?? false;
        public double? Distance => Offer?.Location?.Distance(HomeLocation);

        public IMvxAsyncCommand NavigateToUrlCommand { get; private set; }
        public IMvxAsyncCommand GoBackCommand { get; private set; }
        IMvxViewModel ReturnViewModel { get; set; }

        public override void Prepare(OfferViewNavigationArgs parameter)
        {
            if (parameter is null)
                return;

            ReturnViewModel = parameter.ReturnViewModel;
        }

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

        public double MaxDateTime { get  {
                return (DateTime.Today + TimeSpan.FromDays(1)).Ticks;
            } }

        public bool ShowPriceGraph => Offer.Prices.Count > 1;
    }
}
