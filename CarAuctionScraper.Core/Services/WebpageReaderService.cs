using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarAuctionScraper.Core.Services
{
    public class WebpageReaderService : IWebpageReaderService
    {
        public async Task<string> ReadWebpage(string url)
        {
            string response = null;
            try
            {
                response = await new HttpClient().GetStringAsync(url);
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }

            return await Task.FromResult(response);
        }
    }
}
