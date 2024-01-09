﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repositories;

#nullable disable

namespace MvcUIApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240109131023_SeedDataUpdated")]
    partial class SeedDataUpdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category_name");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("category_status");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 1, 7, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1600),
                            Name = "Sebze",
                            Status = true,
                            UpdatedAt = new DateTime(2024, 1, 8, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1610)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 1, 5, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1610),
                            Name = "Meyve",
                            Status = true,
                            UpdatedAt = new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1610)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(1610),
                            Name = "Yeşillik",
                            Status = true
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("ImageUrl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("img/default.png")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_name");

                    b.Property<bool>("ShowCase")
                        .HasColumnType("boolean")
                        .HasColumnName("show_case");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("unit_price");

                    b.Property<decimal>("UnitsInStock")
                        .HasColumnType("numeric")
                        .HasColumnName("units_in_stock");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 1, 4, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670),
                            ImageUrl = "img/default.png",
                            Name = "Elma",
                            ShowCase = true,
                            UnitPrice = 29m,
                            UnitsInStock = 40m,
                            UpdatedAt = new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 1, 2, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670),
                            ImageUrl = "img/default.png",
                            Name = "Portakal",
                            ShowCase = true,
                            UnitPrice = 19m,
                            UnitsInStock = 50m,
                            UpdatedAt = new DateTime(2024, 1, 5, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2023, 12, 30, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2670),
                            ImageUrl = "img/default.png",
                            Name = "Mandalina",
                            ShowCase = true,
                            UnitPrice = 19m,
                            UnitsInStock = 37m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2023, 12, 30, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680),
                            ImageUrl = "img/default.png",
                            Name = "Patlıcan",
                            ShowCase = true,
                            UnitPrice = 39m,
                            UnitsInStock = 107m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680),
                            ImageUrl = "img/default.png",
                            Name = "Dolma biber",
                            ShowCase = true,
                            UnitPrice = 49m,
                            UnitsInStock = 87m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680),
                            ImageUrl = "img/default.png",
                            Name = "Patates",
                            ShowCase = true,
                            UnitPrice = 43m,
                            UnitsInStock = 17m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680),
                            ImageUrl = "img/default.png",
                            Name = "Brokoli",
                            ShowCase = true,
                            UnitPrice = 73m,
                            UnitsInStock = 57m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 1, 6, 13, 10, 23, 160, DateTimeKind.Utc).AddTicks(2680),
                            ImageUrl = "img/default.png",
                            Name = "Muz",
                            ShowCase = true,
                            UnitPrice = 13m,
                            UnitsInStock = 87m
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
