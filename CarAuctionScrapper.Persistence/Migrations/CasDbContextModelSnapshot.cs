﻿// <auto-generated />
using System;
using CarAuctionScrapper.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarAuctionScrapper.Persistence.Migrations
{
    [DbContext(typeof(CasDbContext))]
    partial class CasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarAuctionScrapper.Domain.Models.Offer", b =>
                {
                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Url");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("CarAuctionScrapper.Domain.Models.Offer", b =>
                {
                    b.OwnsMany("CarAuctionScrapper.Domain.Values.Detail", "Details", b1 =>
                        {
                            b1.Property<string>("OfferUrl")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Category")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("OfferUrl", "Id");

                            b1.ToTable("Detail");

                            b1.WithOwner()
                                .HasForeignKey("OfferUrl");
                        });

                    b.OwnsMany("CarAuctionScrapper.Domain.Values.Feature", "Features", b1 =>
                        {
                            b1.Property<string>("OfferUrl")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.HasKey("OfferUrl", "Id");

                            b1.ToTable("Feature");

                            b1.WithOwner()
                                .HasForeignKey("OfferUrl");
                        });

                    b.OwnsMany("CarAuctionScrapper.Domain.Values.FullImageUrl", "Images", b1 =>
                        {
                            b1.Property<string>("OfferUrl")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Alt")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("Src")
                                .IsRequired()
                                .HasColumnType("nvarchar(2000)")
                                .HasMaxLength(2000);

                            b1.HasKey("OfferUrl", "Id");

                            b1.ToTable("FullImageUrl");

                            b1.WithOwner()
                                .HasForeignKey("OfferUrl");
                        });

                    b.OwnsOne("CarAuctionScrapper.Domain.Values.Location", "Location", b1 =>
                        {
                            b1.Property<string>("OfferUrl")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.HasKey("OfferUrl");

                            b1.ToTable("Offers");

                            b1.WithOwner()
                                .HasForeignKey("OfferUrl");
                        });

                    b.OwnsMany("CarAuctionScrapper.Domain.Values.Price", "Prices", b1 =>
                        {
                            b1.Property<string>("OfferUrl")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTimeOffset>("Date")
                                .HasColumnType("datetimeoffset");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("OfferUrl", "Id");

                            b1.ToTable("Price");

                            b1.WithOwner()
                                .HasForeignKey("OfferUrl");
                        });

                    b.OwnsMany("CarAuctionScrapper.Domain.Values.ThumbnailImageUrl", "ImageThumbnails", b1 =>
                        {
                            b1.Property<string>("OfferUrl")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Alt")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("Src")
                                .IsRequired()
                                .HasColumnType("nvarchar(2000)")
                                .HasMaxLength(2000);

                            b1.HasKey("OfferUrl", "Id");

                            b1.ToTable("ThumbnailImageUrl");

                            b1.WithOwner()
                                .HasForeignKey("OfferUrl");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}