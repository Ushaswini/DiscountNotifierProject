﻿// <auto-generated />
using DiscountNotifierAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiscountNotifierAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220319045536_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DiscountNotifierAPI.Models.Beacon", b =>
                {
                    b.Property<int>("BeaconId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BeaconId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Beacons");
                });

            modelBuilder.Entity("DiscountNotifierAPI.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiscountPercentage")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("OfferText")
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("DiscountNotifierAPI.Models.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("DiscountNotifierAPI.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeaconId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegionName")
                        .HasColumnType("TEXT");

                    b.HasKey("RegionId");

                    b.HasIndex("BeaconId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("DiscountNotifierAPI.Models.Beacon", b =>
                {
                    b.HasOne("DiscountNotifierAPI.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("DiscountNotifierAPI.Models.Discount", b =>
                {
                    b.HasOne("DiscountNotifierAPI.Models.Region", "AssociatedRegion")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedRegion");
                });

            modelBuilder.Entity("DiscountNotifierAPI.Models.Region", b =>
                {
                    b.HasOne("DiscountNotifierAPI.Models.Beacon", "Beacon")
                        .WithMany()
                        .HasForeignKey("BeaconId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beacon");
                });
#pragma warning restore 612, 618
        }
    }
}
