using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Logging;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarAuctionScraper.WPF
{
    public class CustomSetup<TApplication> : MvxWpfSetup<TApplication> where TApplication : class, IMvxApplication, new()
    {
        public override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.Serilog;
        private IConfigurationRoot Configuration { get; set; }

        protected override IMvxLogProvider CreateLogProvider()
        {
            PrepareConfiguration();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(Configuration)
                .CreateLogger();

            return base.CreateLogProvider();
        }

        private void PrepareConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
