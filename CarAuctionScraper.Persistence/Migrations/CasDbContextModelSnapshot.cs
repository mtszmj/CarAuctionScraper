﻿// <auto-generated />
using System;
using CarAuctionScraper.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarAuctionScraper.Persistence.Migrations
{
    [DbContext(typeof(CasDbContext))]
    partial class CasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("CarAuctionScraper.Domain.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("CarAuctionScraper.Domain.Models.Offer", b =>
                {
                    b.OwnsMany("CarAuctionScraper.Domain.Values.Detail", "Details", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Category")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasMaxLength(100);

                            b1.Property<int>("OfferId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasMaxLength(200);

                            b1.HasKey("Id");

                            b1.HasIndex("OfferId");

                            b1.ToTable("Detail");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");
                        });

                    b.OwnsMany("CarAuctionScraper.Domain.Values.Feature", "Features", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasMaxLength(100);

                            b1.Property<int>("OfferId")
                                .HasColumnType("INTEGER");

                            b1.HasKey("Id");

                            b1.HasIndex("OfferId");

                            b1.ToTable("Feature");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");
                        });

                    b.OwnsMany("CarAuctionScraper.Domain.Values.FullImageUrl", "Images", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Alt")
                                .HasColumnType("TEXT")
                                .HasMaxLength(200);

                            b1.Property<int>("OfferId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Src")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasMaxLength(2000);

                            b1.HasKey("Id");

                            b1.HasIndex("OfferId");

                            b1.ToTable("FullImageUrl");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");
                        });

                    b.OwnsOne("CarAuctionScraper.Domain.Values.Location", "Location", b1 =>
                        {
                            b1.Property<int>("OfferId")
                                .HasColumnType("INTEGER");

                            b1.Property<double>("Latitude")
                                .HasColumnType("REAL");

                            b1.Property<double>("Longitude")
                                .HasColumnType("REAL");

                            b1.HasKey("OfferId");

                            b1.ToTable("Offers");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");
                        });

                    b.OwnsMany("CarAuctionScraper.Domain.Values.Price", "Prices", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<DateTimeOffset>("Date")
                                .HasColumnType("TEXT");

                            b1.Property<int>("OfferId")
                                .HasColumnType("INTEGER");

                            b1.Property<decimal>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("OfferId");

                            b1.ToTable("Price");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");
                        });

                    b.OwnsMany("CarAuctionScraper.Domain.Values.ThumbnailImageUrl", "ImageThumbnails", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Alt")
                                .HasColumnType("TEXT")
                                .HasMaxLength(200);

                            b1.Property<int>("OfferId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Src")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasMaxLength(2000);

                            b1.HasKey("Id");

                            b1.HasIndex("OfferId");

                            b1.ToTable("ThumbnailImageUrl");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}