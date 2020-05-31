using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.Property(e => e.CategoryGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ActiveIconDocument)
                    .WithMany(p => p.CategoryActiveIconDocument)
                    .HasForeignKey(d => d.ActiveIconDocumentId)
                    .HasConstraintName("FK_Category_Document1");

            entity.HasOne(d => d.CoverDocument)
                .WithMany(p => p.CategoryCoverDocument)
                .HasForeignKey(d => d.CoverDocumentId)
                .HasConstraintName("FK_Category_Document");

            entity.HasOne(d => d.InactiveIconDocument)
                .WithMany(p => p.CategoryInactiveIconDocument)
                .HasForeignKey(d => d.InactiveIconDocumentId)
                .HasConstraintName("FK_Category_Document2");

            entity.HasOne(d => d.ParentCategory)
                .WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK_Category_Category");

            entity.HasOne(d => d.QuadMenuDocument)
                .WithMany(p => p.CategoryQuadMenuDocument)
                .HasForeignKey(d => d.QuadMenuDocumentId)
                .HasConstraintName("FK_Category_Document3");
        }
    }
}
