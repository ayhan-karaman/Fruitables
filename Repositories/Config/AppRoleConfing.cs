using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class AppRoleConfing : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole(){Id = 1, Name = "Admin", NormalizedName = "ADMIN"},
                new AppRole(){Id = 2, Name = "Editor", NormalizedName = "EDITOR"},
                new AppRole(){Id = 3, Name = "User", NormalizedName = "USER"}
            );
        }
    }
}