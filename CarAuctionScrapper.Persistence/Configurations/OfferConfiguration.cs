using CarAuctionScrapper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScrapper.Persistence.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(e => e.Url);
            builder.OwnsMany(e => e.Details);
            builder.OwnsMany(e => e.Features);
            builder.OwnsMany(e => e.Prices);
            builder.OwnsMany(e => e.ImageThumbnails);
            builder.OwnsMany(e => e.Images);
            builder.OwnsOne(e => e.Location);
        }
    }
}
