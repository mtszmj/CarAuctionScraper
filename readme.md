# Car Auction Scraper

Application takes data from webpage with car auctions and shows it 
in a table in easy to compare way. The data is stored in order to 
show chart with price change.

![Gif](/docs/CarAuctionScraper.gif)

### Technology used
- WPF with MVVM approach
- MvvmCross framework
- Clean Architecture approach (different projects for domain, application, MvvmCross core and WPF UI)
- First take on DDD - entity aggregate containing value types
- Serilog logging
- Entity Framework Core
- Unit tests with NUnit and NSubstitute, FluentAssertions
