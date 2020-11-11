using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarAuctionScraper.Core.Services
{
    public class WebpageReaderServiceMock : IWebpageReaderService
    {
        private bool select;
        public async Task<string> ReadWebpage(string url)
        {
            select = !select;
            string result;
            if (select) { 
            result = @"
<div class=""offer - description"" id=""description"">
      < h3 class=""offer-description__title"">Opis</h3>
    <div class=""offer-description__description"" data-read-more data-text=""Pokaż pełny opis"" data-hide-text=""Ukryj opis"">
        Opis szczegółowy<br />
        <br />
        linia niżej<br />
        linia niżej 2<br />
    </div>
</div>

<div class=""offer-features"">
	<h4 class=""offer-features__title"">Wyposażenie</h4>
	<div class=""offer-features__row"" data-read-more data-text=""Pokaż więcej"" data-hide-text=""Ukryj wyposażenie"">
		<ul class=""offer-features__list"">
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>ABS
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Elektryczne szyby przednie
            </li>
        </ul>
		<ul class=""offer-features__list"">
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>CD
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Elektrycznie ustawiane lusterka
            </li>
        </ul>
	</div>
</div>

<div class=""om-offer-photos om-offer-photos-slick"">
    <div class=""photo-item"">
        <img
            class=""bigImage""
            data-nr=""0""
            data-tracking=""gallery_open""
            data-lazy=""https://xyz.unit.test.com/v1/files/qwerty11/image;s=148x110""                                        
            alt=""AEIOUY - 1""
        />
    </div>
    <div class=""photo-item"">
        <img
            class=""bigImage""
            data-nr=""1""
            data-tracking=""gallery_open""
            data-lazy=""https://xyz.unit.test.com/v1/files/qwerty22/image;s=148x110""                                        
            alt=""AEIOUY - 2""
        />
    </div>
</div>

<div class=""offer-photos-thumbs slider-nav"">
	<li class=""offer-photos-thumbs__item"">
		<img src = ""https://generative-placeholders.glitch.me/image?width=148&height=110&style=triangles&gap=100"" alt=""aeiouy - 1""/>
	</li>
	<li class=""offer-photos-thumbs__item"">
		<img src = ""https://xyz.unit.test.com/v1/files/qwerty2/image;s=148x110"" alt=""aeiouy - 2""/>
	</li>
</div>

<div class=""map-box"">
    <input type = ""hidden""
        data-map-lat=""50.295578""
        data-map-lon=""19.004663""
    />
</div>

<div class=""parametersArea"">
    <h4 class=""offer-parameters__title"">Szczegóły</h4>
    <div class=""offer-params with-vin"" data-read-more data-text=""Pokaż wszystkie dane techniczne"" data-hide-text=""Ukryj dane techniczne"" id=""parameters"">
        <ul class=""offer-params__list"">
            <li class=""offer-params__item"">
                <span class=""offer-params__label"">Oferta od</span>
                <div class=""offer-params__value"">
                    <a class=""offer-params__link"" href=""https://www.abcdefghijkl.pl"" title=""Firmy"">
                        Firmy
                    </a>
                </div>
            </li>                                                                                                                        
            <li class=""offer-params__item"">
                <span class=""offer-params__label"">Kategoria</span>
                    <div class=""offer-params__value"">
                        <a class=""offer-params__link"" href=""https://www.abcdefghijkl.pl/"" title=""Osobowe"">
                            Osobowe
                        </a>
                    </div>
            </li>
        </ul>
    </div>
</div>

<div class=""offer-price"" data-price=""49 900"">
    <span class=""offer-price__number"">49 900    
    <span class=""offer-price__currency"">PLN
    </span></span>
    <span class=""offer-price__details"">Faktura VAT</span>

</div>
";

                }
            else
            {
                result = @"
<div class=""offer - description"" id=""description"">
      < h3 class=""offer-description__title"">Opis</h3>
    <div class=""offer-description__description"" data-read-more data-text=""Pokaż pełny opis"" data-hide-text=""Ukryj opis"">
        Dynamiczny i bezproblemowy silnik 1,6 Turbo benzyna 170KM,
Samochód kupiony w salonie w Polsce,
1 właściciel od nowości,
NISKI - POTWIERDZONY PRZEBIEG !
Pełna historia serwisowa w bazie Opla oraz książce serwisowej,
Kompletna dokumentacja: 2 kluczyki, instrukcje, książka serwisowa, car pass itp.
<br />
Data 1 rejestracji 22/07/2016r.
<br />
Absolutnie bezwypadkowy - żaden element nie był powtórnie lakierowany.
<br />
Bardzo bogata wersja wyposażenia Cosmo: półskórzana tapicerka z pamięcią ustawień fotela kierowcy, biksenonowe światła AFL,
światła przeciwmgielne, felgi aluminiowe 18 calowe, czujnik martwego pola, czujniki parkowana + kamera cofania, elektryczna klapa bagażnika,
elektryczne szyby x4, elektrycznie regulowane, składane i podgrzewane lusterka boczne, dwustrefowa klimatyzacja automatyczna,
podgrzewane fotele przednie + kierownica, pakiet opc line wewnętrzny (czarna podsufitka, aluminiowe nakładki na pedały,
sportowa kierownica) wyświetlacz kierowcy 8', system multimedialny Intellilink 900 Navi (Android Auto, Apple Carplay), bluetooth, odtwarzacz cd&mp3,
system dźwiękowy BOSE z subwooferem, multifunkcyjna skórzana kierownica, tempomat z ogranicznikiem prędkości,
pakiet flex organizer, ABS, ESP, TC, 6xAirbag, start&stop, OnStar, koło zapasowe dojazdowe, alarm, gniazdko 230V,
rolety tylnych szyb, hamulec ręczny elektryczny z funkcją HSA, czujnik deszczu, czujnik zmierzchu, przyciemnione szyby,
chromowana listwa okienna, czujniki ciśnienia w oponach, fotochromatyczne lusterka boczne oraz wsteczne itp.
<br />
Na bieżąco serwisowany w ASO,
Po przeglądzie przy 37.000km
<br />
Zapraszam na oględziny oraz jazdę próbną.
<br />
Komisom i pośrednikom dziękuje ! 
    </div>
</div>

<div class=""offer-features"">
	<h4 class=""offer-features__title"">Wyposażenie</h4>
	<div class=""offer-features__row"" data-read-more data-text=""Pokaż więcej"" data-hide-text=""Ukryj wyposażenie"">
		<ul class=""offer-features__list"">
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>ABS
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Elektryczne szyby przednie
            </li>

            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Poduszka powietrzna kierowcy
            </li>

         <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Wspomaganie kierownicy
            </li>

         <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>ASR (kontrola trakcji)
            </li>

         <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Czujnik martwego pola
            </li>

         <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Czujniki parkowania tylne
            </li>

         <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Elektryczne szyby tylne
            </li>

         <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Klimatyzacja automatyczna
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Kurtyny powietrzne
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Ogranicznik prędkości
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Poduszki boczne przednie
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>System Start-Stop
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Światła Xenonowe
            </li>

        </ul>
		<ul class=""offer-features__list"">
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>CD
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Elektrycznie ustawiane lusterka
            </li>

            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Poduszka powietrzna pasażera
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Alarm
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Bluetooth
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Czujnik zmierzchu
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Elektrochromatyczne lusterka boczne
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Elektrycznie ustawiane fotele
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Isofix
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Klimatyzacja dwustrefowa
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>MP3
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Podgrzewane lusterka boczne
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Przyciemniane szyby
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Światła do jazdy dziennej
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Tempomat
            </li>
        </ul>
		<ul class=""offer-features__list"">
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Centralny zamek
            </li>
            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Immobilizer
            </li>

            <li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Radio fabryczne
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Alufelgi
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Czujnik deszczu
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Czujniki parkowania przednie
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Elektrochromatyczne lusterko wsteczne
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>ESP (stabilizacja toru jazdy)
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Kamera cofania
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Komputer pokładowy
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Nawigacja GPS
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Podgrzewane przednie siedzenia
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Relingi dachowe
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Światła przeciwmgielne
            </li><li class=""offer-features__item"">
                <span class=""offer-features__icon icon-tick""></span>Wielofunkcyjna kierownica
            </li>
        </ul>
	</div>
</div>









 
<div class=""om-offer-photos om-offer-photos-slick"">
    <div class=""photo-item"">
        <img
            class=""bigImage""
            data-nr=""0""
            data-tracking=""gallery_open""
            data-lazy=""https://xyz.unit.test.com/v1/files/qwerty11/image;s=148x110""                                        
            alt=""AEIOUY - 1""
        />
    </div>
    <div class=""photo-item"">
        <img
            class=""bigImage""
            data-nr=""1""
            data-tracking=""gallery_open""
            data-lazy=""https://xyz.unit.test.com/v1/files/qwerty22/image;s=148x110""                                        
            alt=""AEIOUY - 2""
        />
    </div>
</div>

<div class=""offer-photos-thumbs slider-nav"">
	<li class=""offer-photos-thumbs__item"">
		<img src = ""https://generative-placeholders.glitch.me/image?width=148&height=110&style=triangles&gap=150"" alt=""aeiouy - 1""/>
	</li>
	<li class=""offer-photos-thumbs__item"">
		<img src = ""https://xyz.unit.test.com/v1/files/qwerty2/image;s=148x110"" alt=""aeiouy - 2""/>
	</li>
</div>

<div class=""map-box"">
    <input type = ""hidden""
        data-map-lat=""50.295578""
        data-map-lon=""19.004663""
    />
</div>

<div class=""parametersAreaqwert"">
    <h4 class=""offer-parameters__title"">Szczegóły</h4>
    <div class=""offer-params with-vin"" data-read-more data-text=""Pokaż wszystkie dane techniczne"" data-hide-text=""Ukryj dane techniczne"" id=""parameters"">
        <ul class=""offer-params__list"">
            <li class=""offer-params__item"">
                <span class=""offer-params__label"">Oferta od</span>
                <div class=""offer-params__value"">
                    <a class=""offer-params__link"" href=""https://www.abcdefghijkl.pl"" title=""Firmy"">
                        Firmy
                    </a>
                </div>
            </li>                                                                                                                        
            <li class=""offer-params__item"">
                <span class=""offer-params__label"">Kategoria</span>
                    <div class=""offer-params__value"">
                        <a class=""offer-params__link"" href=""https://www.abcdefghijkl.pl/"" title=""Osobowe"">
                            Osobowe
                        </a>
                    </div>
            </li>
        </ul>
    </div>
</div>

<div class=""offer-price"" data-price=""69 900"">
    <span class=""offer-price__number"">69 900    
    <span class=""offer-price__currency"">PLN
    </span></span>
    <span class=""offer-price__details"">Faktura VAT</span>

</div>

<div class=""parametersArea"">
                                < h4 class=""offer-parameters__title"">Szczegóły</h4>

    <div class=""offer-params with-vin"" data-read-more data-text=""Pokaż wszystkie dane techniczne"" data-hide-text=""Ukryj dane techniczne"" id=""parameters"">
                    <ul class=""offer-params__list"">
                                                                                        <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Oferta od</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/?search%5Bprivate_business%5D=private""
           title=""Osoby prywatnej"">
                Osoby prywatnej</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Kategoria</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/""
           title=""Osobowe"">
                Osobowe</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Marka pojazdu</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/""
           title=""Opel"">
                Opel</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Model pojazdu</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/""
           title=""Osobowe Insignia"">
                Insignia</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Wersja</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/""
           title=""1.6 T Cosmo S&S EU6"">
                1.6 T Cosmo S&S EU6</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Generacja</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_generation%5D%5B0%5D=gen-a-2008-2017""
           title=""A (2008-2017)"">
                A(2008-2017)                </a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Rok produkcji</span>
<div class=""offer-params__value"">
                2016         </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Przebieg</span>
<div class=""offer-params__value"">
                49 000 km</div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Pojemność skokowa</span>
<div class=""offer-params__value"">
                1 598 cm3</div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Rodzaj paliwa</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_fuel_type%5D%5B0%5D=petrol""
           title=""Benzyna"">
                Benzyna</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Moc</span>
<div class=""offer-params__value"">
                170 KM</div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Skrzynia biegów</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_gearbox%5D%5B0%5D=manual""
           title=""Manualna"">
                Manualna</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Napęd</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_transmission%5D%5B0%5D=front-wheel""
           title=""Na przednie koła"">
                Na przednie koła</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Typ</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/seg-combi/""
           title=""Kombi"">
                Kombi</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Liczba drzwi</span>
<div class=""offer-params__value"">
                5         </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Liczba miejsc</span>
<div class=""offer-params__value"">
                5         </div>
                            </li>
                                                            
                                                            <li class=""offer-params__loan-link"">
                            <div id = ""div-gpt-ad-1483354248495-0"" >< script type=""text/javascript"">googletag && googletag.cmd.push(function() { googletag.display('div-gpt-ad-1483354248495-0'); });</script></div><div id = ""div-gpt-ad-1483354248495-0-after"" ></ div >                        </ li >

</ ul >

< ul class=""offer-params__list"">
                                                                                        <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Kolor</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_color%5D%5B0%5D=grey""
           title=""Szary"">
                Szary</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Metalik</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_metallic%5D%5B0%5D=1""
           title=""Tak"">
                Tak</a>
    </div>
                            </li>
                                                                                                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Możliwość finansowania</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_financial_option%5D%5B0%5D=1""
           title=""Tak"">
                Tak</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Faktura VAT</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_vat%5D%5B0%5D=1""
           title=""Tak"">
                Tak</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Leasing</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_leasing_concession%5D%5B0%5D=1""
           title=""Tak"">
                Tak</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Kraj pochodzenia</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_country_origin%5D%5B0%5D=pl""
           title=""Polska"">
                Polska</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Pierwsza rejestracja</span>
<div class=""offer-params__value"">
                22/07/2016        </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Zarejestrowany w Polsce</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_registered%5D%5B0%5D=1""
           title=""Tak"">
                Tak</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Pierwszy właściciel</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_original_owner%5D%5B0%5D=1""
           title=""Tak"">
                Tak</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Bezwypadkowy</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_no_accident%5D%5B0%5D=1""
           title=""Tak"">
                Tak</a>
    </div>
                            </li>
                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Serwisowany w ASO</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/opel/insignia/ver-1-6-t-cosmo-s-s-eu6/?search%5Bfilter_enum_service_record%5D%5B0%5D=1""
           title=""Tak"">
                Tak</a>
    </div>
                            </li>
                                                                                                                                                                                                                    <li class=""offer-params__item"">
                                <span class=""offer-params__label"">Stan</span>
<div class=""offer-params__value"">
            <a class=""offer-params__link"" href=""https://www.otomoto.pl/osobowe/uzywane/warszawa/""
           title=""Używane"">
                Używane</a>
    </div>
                            </li>
                                                            
                                                    <li class=""offer-params__loan-link user-has-ad-block hidden"">
    <small>Finanse</small>
    <a id = ""RanTextLink"" href="""" target=""_blank"" data-urlcompareform=""https://form.comperia.pl/otomoto_kredyt_rna_ab?"">
        <span id = ""rataval"" data-compare=""1196,68""></span>
    </a>
</li>

                                                </ul>
            </div>

                        </ div >

                                                                                   
    
                                </ div >

";

            }


            return await Task.FromResult(result);

        }
    }
}
