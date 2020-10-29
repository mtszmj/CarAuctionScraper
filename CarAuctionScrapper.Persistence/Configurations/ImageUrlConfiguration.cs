using CarAuctionScrapper.Domain.Values;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarAuctionScrapper.Persistence.Configurations
{
    public class ImageUrlConfiguration : IEntityTypeConfiguration<ImageUrl>
    {
        public void Configure(EntityTypeBuilder<ImageUrl> builder)
        {
            builder.Property(e => e.Src)
                .IsRequired()
                .HasMaxLength(300)
                ;

            builder.Property(e => e.Alt).HasMaxLength(300);
        }
    }
}
