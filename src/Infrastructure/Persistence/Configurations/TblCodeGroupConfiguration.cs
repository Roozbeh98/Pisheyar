using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblCodeGroupConfiguration : IEntityTypeConfiguration<TblCodeGroup>
    {
        public void Configure(EntityTypeBuilder<TblCodeGroup> entity)
        {
            entity.HasKey(e => e.CgId);

            entity.ToTable("Tbl_CodeGroup");

            entity.HasIndex(e => e.CgCodeId);

            entity.Property(e => e.CgId)
                .HasColumnName("CG_ID");

            entity.Property(e => e.CgCodeId)
                .HasColumnName("CG_CodeID");

            entity.Property(e => e.CgDisplay)
                .IsRequired()
                .HasColumnName("CG_Display")
                .HasMaxLength(128);

            entity.Property(e => e.CgGuid)
                .HasColumnName("CG_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CgName)
                .IsRequired()
                .HasColumnName("CG_Name")
                .HasMaxLength(128);

            entity.HasOne(d => d.CgCode)
                .WithMany(p => p.TblCodeGroup)
                .HasForeignKey(d => d.CgCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_CodeGroup_Tbl_Code");
        }
    }
}
