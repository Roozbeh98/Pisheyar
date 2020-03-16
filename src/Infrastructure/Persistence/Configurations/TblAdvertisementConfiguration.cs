using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblAdvertisementConfiguration : IEntityTypeConfiguration<TblAdvertisement>
    {
        public void Configure(EntityTypeBuilder<TblAdvertisement> entity)
        {
            entity.HasKey(e => e.AdvertisementId);

            entity.ToTable("Tbl_Advertisement");

            entity.HasIndex(e => e.AdvertisementDocumentId);

            entity.Property(e => e.AdvertisementId)
                .HasColumnName("Advertisement_ID");

            entity.Property(e => e.AdvertisementAbstract)
                .IsRequired()
                .HasColumnName("Advertisement_Abstract");

            entity.Property(e => e.AdvertisementCreateDate)
                .HasColumnName("Advertisement_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.AdvertisementDocumentId)
                .HasColumnName("Advertisement_DocumentID");

            entity.Property(e => e.AdvertisementGuid)
                .HasColumnName("Advertisement_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.AdvertisementIsDelete)
                .HasColumnName("Advertisement_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.AdvertisementIsShow)
                .HasColumnName("Advertisement_IsShow")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.AdvertisementModifyDate)
                .HasColumnName("Advertisement_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.AdvertisementTitle)
                .IsRequired()
                .HasColumnName("Advertisement_Title")
                .HasMaxLength(256);

            entity.Property(e => e.AvertisementPicture)
                .IsRequired()
                .HasColumnName("Avertisement_Picture")
                .HasMaxLength(512);

            entity.HasOne(d => d.AdvertisementDocument)
                .WithMany(p => p.TblAdvertisement)
                .HasForeignKey(d => d.AdvertisementDocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Advertisement_Tbl_Document");
        }
    }
}
