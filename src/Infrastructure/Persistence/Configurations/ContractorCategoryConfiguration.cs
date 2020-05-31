using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class ContractorCategoryConfiguration : IEntityTypeConfiguration<ContractorCategory>
    {
        public void Configure(EntityTypeBuilder<ContractorCategory> entity)
        {
            entity.Property(e => e.ContractorCategoryGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.ContractorCategory)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContractorCategory_Category");

            entity.HasOne(d => d.Contractor)
                .WithMany(p => p.ContractorCategory)
                .HasForeignKey(d => d.ContractorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContractorCategory_Contractor");
        }
    }
}
