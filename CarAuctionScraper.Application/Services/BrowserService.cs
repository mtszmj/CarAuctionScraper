using CarAuctionScraper.Application.Interfaces.Services;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CarAuctionScraper.Application.Services
{
    public class BrowserService : IBrowserService
    {
        public void OpenWebsite(string url)
        {
            if (!IsUrlHttp(url))
                return;

            StartWebsiteProcess(url);
        }

        private static void StartWebsiteProcess(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task OpenWebsiteAsync(string url)
        {
            await Task.Run(() => OpenWebsite(url));
        }

        private bool IsUrlHttp(string url)
        {
            if (url is null)
                return false;

            if (Uri.TryCreate(url, UriKind.Absolute, out var outUri)
                && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
            {
                return true;
            }

            return false;
        }
    }
}
