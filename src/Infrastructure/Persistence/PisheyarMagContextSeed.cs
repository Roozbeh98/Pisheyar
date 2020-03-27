using Microsoft.EntityFrameworkCore;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence
{
    public static class PisheyarMagContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblSmsproviderConfiguration>().HasData(
                    new TblSmsproviderConfiguration
                    {
                        SpcId = 1,
                        SpcGuid = Guid.NewGuid(),
                        SpcUsername = "ptmgroupco@gmail.com",
                        SpcPassword = "ptcoptco",
                        SpcApiKey = "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D",
                        SpcCreateDate = DateTime.Now,
                        SpcModifyDate = DateTime.Now,
                        SpcIsDelete = false
                    }
                );

            modelBuilder.Entity<TblSmssetting>().HasData(
                    new TblSmssetting
                    {
                        SsId = 1,
                        SsGuid = Guid.NewGuid(),
                        SsSpcid = 1,
                        SsName = "Kavenegar",
                        SsCreateDate = DateTime.Now,
                        SsModifyDate = DateTime.Now,
                        SsIsDelete = false
                    }
                );

            modelBuilder.Entity<TblSmstemplate>().HasData(
                    new TblSmstemplate
                    {
                        StId = 1,
                        StGuid = Guid.NewGuid(),
                        StSsid = 1,
                        StName = "VerifyAccount",
                        StCreateDate = DateTime.Now,
                        StModifyDate = DateTime.Now,
                        StIsDelete = false
                    }
                );

            modelBuilder.Entity<TblRole>().HasData(
                    new TblRole
                    {
                        RoleId = 1,
                        RoleGuid = Guid.NewGuid(),
                        RoleName = "User",
                        RoleDisplay = "کاربر عادی",
                        RoleCreateDate = DateTime.Now,
                        RoleModifyDate = DateTime.Now,
                        RoleIsDelete = false
                    },
                    new TblRole
                    {
                        RoleId = 2,
                        RoleGuid = Guid.NewGuid(),
                        RoleName = "Admin",
                        RoleDisplay = "ادمین",
                        RoleCreateDate = DateTime.Now,
                        RoleModifyDate = DateTime.Now,
                        RoleIsDelete = false
                    }
                );

            modelBuilder.Entity<TblUser>().HasData(
                    new TblUser
                    {
                        UserId = 1,
                        UserGuid = Guid.NewGuid(),
                        UserRoleId = 1,
                        UserName = "Mahdi",
                        UserFamily = "Roudaki",
                        UserEmail = "mahdiroudaki@hotmail.com",
                        UserMobile = "09227204305",
                        UserCreateDate = DateTime.Now,
                        UserModifyDate = DateTime.Now,
                        UserIsActive = true,
                        UserIsDelete = false
                    }
                );

            modelBuilder.Entity<TblCategory>().HasData(
                    new TblCategory
                    {
                        CategoryGuid = Guid.NewGuid(),
                        CategoryCategoryGuid = null,
                        CategoryDisplay = "سایت اصلی",
                        CategoryOrder = 1,
                        CategoryCreateDate = DateTime.Now,
                        CategoryModifyDate = DateTime.Now,
                        CategoryIsDelete = false
                    },
                    new TblCategory
                    {
                        CategoryGuid = Guid.NewGuid(),
                        CategoryCategoryGuid = null,
                        CategoryDisplay = "وبلاگ",
                        CategoryOrder = 2,
                        CategoryCreateDate = DateTime.Now,
                        CategoryModifyDate = DateTime.Now,
                        CategoryIsDelete = false
                    }
                );
        }
    }
}
