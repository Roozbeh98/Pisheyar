using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class PermissionGroupConfiguration : IEntityTypeConfiguration<PermissionGroup>
    {
        public void Configure(EntityTypeBuilder<PermissionGroup> entity)
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PermissionGroupGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");
        }
    }
}
