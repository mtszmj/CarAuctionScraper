﻿using CarAuctionScrapper.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MvvmCross;
using MvvmCross.IoC;
using System.IO;

namespace CarAuctionScrapper.Persistence
{
    public class Setup
    {
        private IConfigurationRoot Configuration { get; set; }

        public void Initialize(IMvxIoCProvider ioc)
        {
            PrepareConfiguration();
            var connection = Configuration.GetConnectionString("DataConnection");
            Mvx.IoCProvider.RegisterSingleton(() => new CasDbContext(
                new DbContextOptionsBuilder().UseSqlServer(connection).Options));
            Mvx.IoCProvider.RegisterType<ICasRepository, CasRepository>();
        }

        public void PrepareConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}