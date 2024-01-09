using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig:BaseEntityConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("product_name");
            builder.Property(x => x.UnitPrice).HasColumnName("unit_price");
            builder.Property(x => x.UnitsInStock).HasColumnName("units_in_stock");
            builder.Property(x => x.ShowCase).HasColumnName("show_case");
            builder.Property(x => x.ImageUrl).HasColumnName("image_url").HasDefaultValue("img/default.png");
            builder.Property(x => x.CategoryId).HasColumnName("category_id");
            
            builder.HasOne(x => x.Category);

            builder.HasData(
                new Product()
                {
                    Id = 1,
                    Name  = "Elma",
                    CategoryId = 2,
                    UnitPrice = 29,
                    UnitsInStock = 40,
                    ShowCase = true,
                    ImageUrl = "img/default.png",
                    CreatedAt =  DateTime.UtcNow.AddDays(-5),
                    UpdatedAt =  DateTime.UtcNow.AddDays(-3), 
                },
                new Product()
                {
                    Id = 2,
                    Name  = "Portakal",
                    CategoryId = 2,
                    UnitPrice = 19,
                    UnitsInStock = 50,
                    ShowCase = true,
                    ImageUrl = "img/default.png",
                    CreatedAt =  DateTime.UtcNow.AddDays(-7),
                    UpdatedAt =  DateTime.UtcNow.AddDays(-4), 
                },
                new Product()
                {
                    Id = 3,
                    Name  = "Mandalina",
                    CategoryId = 2,
                    UnitPrice = 19,
                    UnitsInStock = 37,
                    ShowCase = true,
                    ImageUrl = "img/default.png",
                    CreatedAt =  DateTime.UtcNow.AddDays(-10),
                    UpdatedAt =  null, 
                },
                new Product()
                {
                    Id = 4,
                    Name  = "Patlıcan",
                    CategoryId = 1,
                    UnitPrice = 39,
                    UnitsInStock = 107,
                    ShowCase = true,
                    ImageUrl = "img/default.png",
                    CreatedAt =  DateTime.UtcNow.AddDays(-10),
                    UpdatedAt =  null, 
                
                },
                new Product()
                {
                    Id = 5,
                    Name  = "Dolma biber",
                    CategoryId = 1,
                    UnitPrice = 49,
                    UnitsInStock = 87,
                    ShowCase = true,
                    ImageUrl = "img/default.png",
                    CreatedAt =  DateTime.UtcNow.AddDays(-3),
                    UpdatedAt =  null, 
                },
                new Product()
                {
                    Id = 6,
                    Name  = "Patates",
                    CategoryId = 1,
                    UnitPrice = 43,
                    UnitsInStock = 17,
                    ShowCase = true,
                    ImageUrl = "img/default.png",
                    CreatedAt =  DateTime.UtcNow.AddDays(-3),
                    UpdatedAt =  null, 
                },
                new Product()
                {
                    Id = 7,
                    Name  = "Brokoli",
                    CategoryId = 1,
                    UnitPrice = 73,
                    UnitsInStock = 57,
                    ShowCase = true,
                    ImageUrl = "img/default.png",
                    CreatedAt =  DateTime.UtcNow.AddDays(-3),
                    UpdatedAt =  null, 
                },
                new Product()
                {
                    Id = 8,
                    Name  = "Muz",
                    CategoryId = 2,
                    UnitPrice = 13,
                    UnitsInStock = 87,
                    ShowCase = true,
                    ImageUrl = "img/default.png",
                    CreatedAt =  DateTime.UtcNow.AddDays(-3),
                    UpdatedAt =  null, 
                }
            );
        }
    }
}