﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configurations;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    partial class AuctionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Artworks.AArtwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ARTWORK_ID");

                    b.Property<int>("AestimatedValue")
                        .HasColumnType("int")
                        .HasColumnName("AESTIMATED_VALUE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("NAME");

                    b.Property<string>("WORK_OF_ART_TYPE")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("WORKS_OF_ART_BT");

                    b.HasDiscriminator<string>("WORK_OF_ART_TYPE").HasValue("AArtwork");
                });

            modelBuilder.Entity("Model.Entities.Auctions.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AUCTION_ID");

                    b.Property<DateTime>("AuctionDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATE_OF_AUCTION");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TOPIC");

                    b.HasKey("Id");

                    b.ToTable("AUCTIONS");
                });

            modelBuilder.Entity("Model.Entities.Auctions.AuctionItems", b =>
                {
                    b.Property<int>("ArtworkId")
                        .HasColumnType("int")
                        .HasColumnName("ARTWORK_ID");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CUSTOMER_ID");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int")
                        .HasColumnName("AUCTION_ID");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("PRICE");

                    b.HasKey("ArtworkId", "CustomerId", "AuctionId");

                    b.HasIndex("AuctionId");

                    b.HasIndex("CustomerId");

                    b.ToTable("AUCTION_HAS_ITEMS_JT");
                });

            modelBuilder.Entity("Model.Entities.Auctions.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CUSTOMER_ID");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("LAST_NAME");

                    b.Property<string>("PhoneNr")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("PHONE_NR");

                    b.HasKey("Id");

                    b.ToTable("CUSTOMERS");
                });

            modelBuilder.Entity("Model.Entities.Artworks.Painting", b =>
                {
                    b.HasBaseType("Model.Entities.Artworks.AArtwork");

                    b.Property<int>("Height")
                        .HasColumnType("int")
                        .HasColumnName("HEIGHT");

                    b.Property<int>("Width")
                        .HasColumnType("int")
                        .HasColumnName("WIDTH");

                    b.ToTable("WORKS_OF_ART_BT");

                    b.HasDiscriminator().HasValue("PAINTING");
                });

            modelBuilder.Entity("Model.Entities.Artworks.Sculpture", b =>
                {
                    b.HasBaseType("Model.Entities.Artworks.AArtwork");

                    b.Property<float>("Weight")
                        .HasPrecision(6, 2)
                        .HasColumnType("float")
                        .HasColumnName("WEIGHT");

                    b.ToTable("WORKS_OF_ART_BT");

                    b.HasDiscriminator().HasValue("SCULPTURE");
                });

            modelBuilder.Entity("Model.Entities.Artworks.Setup", b =>
                {
                    b.HasBaseType("Model.Entities.Artworks.AArtwork");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.ToTable("WORKS_OF_ART_BT");

                    b.HasDiscriminator().HasValue("SETUP");
                });

            modelBuilder.Entity("Model.Entities.Auctions.AuctionItems", b =>
                {
                    b.HasOne("Model.Entities.Artworks.AArtwork", "Artwork")
                        .WithMany()
                        .HasForeignKey("ArtworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Auctions.Auction", "Auction")
                        .WithMany("AuctionItems")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Auctions.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artwork");

                    b.Navigation("Auction");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Model.Entities.Auctions.Auction", b =>
                {
                    b.Navigation("AuctionItems");
                });
#pragma warning restore 612, 618
        }
    }
}
