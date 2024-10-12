﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheMaxieInn.Data;

#nullable disable

namespace TheMaxieInn.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241011232217_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheMaxieInn.Models.DogInformation", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DogId"));

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SpayedOrNeutered")
                        .HasColumnType("bit");

                    b.Property<bool>("SpecialAccommodation")
                        .HasColumnType("bit");

                    b.Property<bool>("Vaccinated")
                        .HasColumnType("bit");

                    b.HasKey("DogId");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.ToTable("DogInformation");
                });

            modelBuilder.Entity("TheMaxieInn.Models.DogOwner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.ToTable("DogOwner");
                });

            modelBuilder.Entity("TheMaxieInn.Models.DogReservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.ToTable("DogReservation");
                });

            modelBuilder.Entity("TheMaxieInn.Models.DogInformation", b =>
                {
                    b.HasOne("TheMaxieInn.Models.DogReservation", "DogReservation")
                        .WithOne("DogInformation")
                        .HasForeignKey("TheMaxieInn.Models.DogInformation", "ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DogReservation");
                });

            modelBuilder.Entity("TheMaxieInn.Models.DogOwner", b =>
                {
                    b.HasOne("TheMaxieInn.Models.DogReservation", "DogReservation")
                        .WithOne("DogOwner")
                        .HasForeignKey("TheMaxieInn.Models.DogOwner", "ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DogReservation");
                });

            modelBuilder.Entity("TheMaxieInn.Models.DogReservation", b =>
                {
                    b.Navigation("DogInformation")
                        .IsRequired();

                    b.Navigation("DogOwner")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}