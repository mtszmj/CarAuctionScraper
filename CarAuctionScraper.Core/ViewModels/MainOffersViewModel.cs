using CarAuctionScraper.Application.Interfaces;
using CarAuctionScraper.Domain.Values;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAuctionScraper.Application.Interfaces.Services;
using CarAuctionScraper.Core.Args;
using MaterialDesignThemes.Wpf;
using MvvmCross.Logging;

namespace CarAuctionScraper.Core.ViewModels
{
    public class MainOffersViewModel : MvxViewModel
    {
        private readonly IWebpageService _webpageService;
        private readonly IBrowserService _browserService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMvxLog _logger;
        private MvxObservableCollection<OfferViewModel> _offers;
        private OfferViewModel _selectedOffer;
        private string _url;
        private string _infoText;
        private bool _isInitialized;

        public MainOffersViewModel(
            IWebpageService webpageService, 
            IBrowserService browserService, 
            IMvxNavigationService navigationService, 
            IUnitOfWork unitOfWork,
            ISnackbarMessageQueue snackbarMessageQueue,
            IMvxLog logger
            )
        {
            _webpageService = webpageService;
            _browserService = browserService;
            _navigationService = navigationService;
            _unitOfWork = unitOfWork;
            SnackbarMessageQueue = snackbarMessageQueue;
            _logger = logger;
            Offers = new MvxObservableCollection<OfferViewModel>();

            GetDataFromWebpageCommand = new MvxAsyncCommand(GetDataFromWebpage, CanGetDataFromWebpage);
            NavigateToOfferViewCommand = new MvxAsyncCommand(NavigateToOfferView);
            UpdatePricesCommand = new MvxAsyncCommand(UpdatePrices, CanUpdatePrices);
            DeleteCommand = new MvxAsyncCommand(DeleteOffer, CanDeleteOffer);

            InfoText = "Uruchomiono";
            _logger.Debug("test uruchomiono MainOffersViewModel");
        }

        public ISnackbarMessageQueue SnackbarMessageQueue { get; }

        public MvxObservableCollection<OfferViewModel> Offers
        {
            get => _offers;
            set => SetProperty(ref _offers, value);
        }

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

        public string InfoText
        {
            get => _infoText;
            set
            {
                SetProperty(ref _infoText, value);
                SnackbarMessageQueue.Enqueue(value);
            }
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

        public IMvxAsyncCommand GetDataFromWebpageCommand { get; private set; }
        public IMvxAsyncCommand UpdatePricesCommand { get; private set; }
        public IMvxAsyncCommand DeleteCommand { get; private set; }
        public IMvxAsyncCommand NavigateToOfferViewCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();
            if (!_isInitialized)
            {
                var offers = _unitOfWork.OfferRepository.GetAll();
                Offers.AddRange(offers.Select(x => new OfferViewModel(_webpageService, _browserService, _navigationService, _unitOfWork, x) ));
                await UpdateCommonFeatures();
                _isInitialized = true;

                if (offers.Count > 0)
                    InfoText = "Wczytano oferty";
            }
            //else
            //    await UpdateCommonFeatures();
        }

        private async Task GetDataFromWebpage()
        {
            var url = Url;
            var html = await _webpageService.ReaderService.ReadWebpage(url);
            if (html is null)
                return;

            var offer = _webpageService.ConverterService.Convert(html, url);
            if (offer is null)
                return;

            var offerVm = new OfferViewModel(_webpageService, _browserService, _navigationService, _unitOfWork, offer);
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
                    if (html == null)
                        offerVm.Offer.CloseOffer();
                    else
                    {
                        var price = _webpageService.ConverterService.ConvertPrice(html);
                        offerVm.Offer.AddPrice(price);
                    }
                }
                catch (Exception ex)
                {
                    InfoText = ex.Message;
                }
            }

            await RaisePropertyChanged("");
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

        public override void ViewAppeared()
        {
            RaiseAllPropertiesChanged().ConfigureAwait(true).GetAwaiter().GetResult();
        }
    }
}
