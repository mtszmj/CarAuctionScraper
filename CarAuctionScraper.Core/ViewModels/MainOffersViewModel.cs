using CarAuctionScraper.Core.DI;
using CarAuctionScraper.Core.Services;
using CarAuctionScraper.Domain.Interfaces;
using CarAuctionScraper.Domain.Values;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAuctionScraper.Core.ViewModels
{
    public class MainOffersViewModel : MvxViewModel
    {
        private readonly IWebpageService _webpageService;
        private readonly IBrowserService _browserService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IUnitOfWork _unitOfWork;

        public MainOffersViewModel(IWebpageService webpageService, IBrowserService browserService, IMvxNavigationService navigationService, IUnitOfWork unitOfWork)
        {
            _webpageService = webpageService;
            _browserService = browserService;
            _navigationService = navigationService;
            _unitOfWork = unitOfWork;
            Offers = new MvxObservableCollection<OfferViewModel>();

            GetDataFromWebpageCommand = new MvxAsyncCommand(GetDataFromWebpage, CanGetDataFromWebpage);
            NavigateToOfferViewCommand = new MvxAsyncCommand(NavigateToOfferView);
            UpdatePricesCommand = new MvxAsyncCommand(UpdatePrices, CanUpdatePrices);
            DeleteCommand = new MvxAsyncCommand(DeleteOffer, CanDeleteOffer);
        }

        private MvxObservableCollection<OfferViewModel> _offers;
        private string _url;
        private bool IsInitialized { get; set; }

        public MvxObservableCollection<OfferViewModel> Offers
        {
            get => _offers;
            set => SetProperty(ref _offers, value);
        }

        private OfferViewModel _selectedOffer;
        private string _infoText;

        public OfferViewModel SelectedOffer
        {
            get => _selectedOffer;
            set => SetProperty(ref _selectedOffer, value);
        }

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value, () => GetDataFromWebpageCommand?.RaiseCanExecuteChanged());
        }

        public List<Feature> CommonFeatures
        {
            get
            {
                if (Offers.Count > 1)
                    return Offers[0].CommonFeatures;
                else return Enumerable.Empty<Feature>().ToList();
            }
        }

        public string InfoText
        {
            get => _infoText;
            set => SetProperty(ref _infoText, value);
        }

        public IMvxAsyncCommand GetDataFromWebpageCommand { get; private set; }
        public IMvxAsyncCommand UpdatePricesCommand { get; private set; }
        public IMvxAsyncCommand NavigateToOfferViewCommand { get; private set; }
        public IMvxAsyncCommand DeleteCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();
            if (!IsInitialized)
            {
                var offers = _unitOfWork.OfferRepository.GetAll();
                Offers.AddRange(offers.Select(x => new OfferViewModel(_browserService, _navigationService, x) ));
                await UpdateCommonFeatures();
                IsInitialized = true;

                if (offers.Count > 0)
                    InfoText = "Wczytano oferty";
            }
        }

        private async Task GetDataFromWebpage()
        {
            var url = Url;
            var html = await _webpageService.ReaderService.ReadWebpage(url);
            var offer = _webpageService.ConverterService.Convert(html, url);
            if (offer is null)
                return;

            var offerVm = new OfferViewModel(_browserService, _navigationService, offer);
            if (Offers.Any(x => x?.Offer?.Url == url))
                return;

            Offers.Add(offerVm);
            Url = null;

            await UpdateCommonFeatures();
            await _unitOfWork.OfferRepository.Add(offer);
            await _unitOfWork.Save();

            InfoText = "Pobrano ofertę ze strony www";
        }

        private async Task UpdateCommonFeatures()
        {
            if (Offers.Count > 1)
            {
                var featuresCounters = new Dictionary<Feature, int>();
                foreach (var vm in Offers)
                {
                    foreach (var feature in vm.Offer.Features)
                    {
                        if (featuresCounters.ContainsKey(feature))
                            featuresCounters[feature]++;
                        else featuresCounters[feature] = 1;
                    }
                }

                var featuresContainedByAll = featuresCounters.Where(x => x.Value == Offers.Count)
                                                             .Select(x => x.Key)
                                                             .OrderBy(x => x)
                                                             .ToList();
                foreach (var vm in Offers)
                {
                    vm.CommonFeatures = featuresContainedByAll;
                }

                await RaisePropertyChanged(() => CommonFeatures);
                UpdatePricesCommand?.RaiseCanExecuteChanged();
            }
        }

        private bool CanGetDataFromWebpage()
        {
            return Uri.TryCreate(Url, UriKind.Absolute, out var uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        private async Task UpdatePrices()
        {
            foreach (var offerVm in Offers)
            {
                try
                {
                    var html = await _webpageService.ReaderService.ReadWebpage(offerVm.Offer.Url);
                    var price = _webpageService.ConverterService.ConvertPrice(html);
                    offerVm.Offer.AddPrice(price);
                }
                catch (Exception ex)
                {
                    continue; //TODO
                }
            }

            await _unitOfWork.Save();
            InfoText = "Zaktualizowano ceny";
        }

        private bool CanUpdatePrices()
        {
            return Offers.Count > 0;
        }

        private async Task DeleteOffer()
        {
            var selected = SelectedOffer;
            SelectedOffer = null;
            Offers.Remove(selected);
            _unitOfWork.OfferRepository.Remove(selected.Offer);
            await _unitOfWork.Save();
        }

        private bool CanDeleteOffer()
        {
            return SelectedOffer != null;
        }

        private async Task NavigateToOfferView()
        {
            await _navigationService.Navigate(SelectedOffer, new OfferViewNavigationArgs { ReturnViewModel = this });
        }
    }
}
