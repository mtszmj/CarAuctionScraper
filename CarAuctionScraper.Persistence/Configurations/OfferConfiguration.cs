﻿using CarAuctionScraper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScraper.Persistence.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.OwnsMany(e => e.Details, details =>
            {
                details.Property(d => d.Category)
                    .IsRequired()
                    .HasMaxLength(100)
                    ;

                details.Property(d => d.Value)
                    .IsRequired()
                    .HasMaxLength(200)
                    ;

                details.HasKey("Id");
            });

            builder.OwnsMany(e => e.Features, feature =>
            {
                feature.Property(f => f.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    ;

                feature.HasKey("Id");
            });

            builder.OwnsMany(e => e.Prices, prices =>
            {
                prices.Property(p => p.Value);
                prices.Property(p => p.Date);

                prices.HasKey("Id");
            });

            builder.OwnsMany(e => e.ImageThumbnails, images =>
            {
                images.Property(e => e.Src)
                    .IsRequired()
                    .HasMaxLength(2000)
                    ;

                images.Property(e => e.Alt)
                    .HasMaxLength(200)
                    ;

                images.HasKey("Id");
            });

            builder.OwnsMany(e => e.Images, images =>
            {
                images.Property(e => e.Src)
                    .IsRequired()
                    .HasMaxLength(2000)
                    ;

                images.Property(e => e.Alt)
                    .HasMaxLength(200)
                    ;

                images.HasKey("Id");
            });

            builder.OwnsOne(e => e.Location, location =>
            {
                location.Property(l => l.Latitude);
                location.Property(l => l.Longitude);
            });
        }
    }
}
