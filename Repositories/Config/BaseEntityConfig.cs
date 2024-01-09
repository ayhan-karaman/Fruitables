using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class BaseEntityConfig<T> : IEntityTypeConfiguration<T>
    where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.CreatedAt).HasColumnName("created_at");
           builder.Property(x => x.UpdatedAt).HasColumnName("update_at");
        }
    }
}