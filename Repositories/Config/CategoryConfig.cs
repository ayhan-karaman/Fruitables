using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CategoryConfig : BaseEntityConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("category_name");
            builder.Property(x => x.Status).HasColumnName("category_status")
            .HasDefaultValue(true);

            builder.HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Sebze",
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1),
                    Status = true
                },
                new Category()
                {
                    Id = 2,
                    Name = "Meyve",
                    CreatedAt = DateTime.UtcNow.AddDays(-4),
                    UpdatedAt = DateTime.UtcNow.AddDays(-3),
                    Status = true
                },
                new Category()
                {
                    Id = 3,
                    Name = "Yeşillik",
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    UpdatedAt = null,
                    Status = true
                }
            );
        }
    }
}