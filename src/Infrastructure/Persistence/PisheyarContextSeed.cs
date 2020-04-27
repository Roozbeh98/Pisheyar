using Microsoft.EntityFrameworkCore;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence
{
    public static class PisheyarContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TblSmsproviderConfiguration>().HasData(
            //        new TblSmsproviderConfiguration
            //        {
            //            SpcId = 1,
            //            SpcGuid = Guid.NewGuid(),
            //            SpcUsername = "ptmgroupco@gmail.com",
            //            SpcPassword = "ptcoptco",
            //            SpcApiKey = "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D",
            //            SpcCreateDate = DateTime.Now,
            //            SpcModifyDate = DateTime.Now,
            //            SpcIsDelete = false
            //        }
            //    );

            //modelBuilder.Entity<TblSmssetting>().HasData(
            //        new TblSmssetting
            //        {
            //            SsId = 1,
            //            SsGuid = Guid.NewGuid(),
            //            SsSpcid = 1,
            //            SsName = "Kavenegar",
            //            SsCreateDate = DateTime.Now,
            //            SsModifyDate = DateTime.Now,
            //            SsIsDelete = false
            //        }
            //    );

            //modelBuilder.Entity<TblSmstemplate>().HasData(
            //        new TblSmstemplate
            //        {
            //            StId = 1,
            //            StGuid = Guid.NewGuid(),
            //            StSsid = 1,
            //            StName = "VerifyAccount",
            //            StCreateDate = DateTime.Now,
            //            StModifyDate = DateTime.Now,
            //            StIsDelete = false
            //        }
            //    );

            //modelBuilder.Entity<TblRole>().HasData(
            //        new TblRole
            //        {
            //            RoleId = 1,
            //            RoleGuid = Guid.NewGuid(),
            //            RoleName = "User",
            //            RoleDisplay = "کاربر عادی",
            //            RoleCreateDate = DateTime.Now,
            //            RoleModifyDate = DateTime.Now,
            //            RoleIsDelete = false
            //        },
            //        new TblRole
            //        {
            //            RoleId = 2,
            //            RoleGuid = Guid.NewGuid(),
            //            RoleName = "Admin",
            //            RoleDisplay = "ادمین",
            //            RoleCreateDate = DateTime.Now,
            //            RoleModifyDate = DateTime.Now,
            //            RoleIsDelete = false
            //        }
            //    );

            //modelBuilder.Entity<TblUser>().HasData(
            //        new TblUser
            //        {
            //            UserGuid = Guid.NewGuid(),
            //            UserRoleId = 1,
            //            UserName = "سید مهدی",
            //            UserFamily = "رودکی",
            //            UserEmail = "mahdiroudaki@hotmail.com",
            //            UserMobile = "09227204305",
            //            UserCreateDate = DateTime.Now,
            //            UserModifyDate = DateTime.Now,
            //            UserIsActive = true,
            //            UserIsDelete = false
            //        },
            //        new TblUser
            //        {
            //            UserGuid = Guid.NewGuid(),
            //            UserRoleId = 1,
            //            UserName = "مهدی",
            //            UserFamily = "حکمی زاده",
            //            UserEmail = "mahdiih@ymail.com",
            //            UserMobile = "09199390494",
            //            UserCreateDate = DateTime.Now,
            //            UserModifyDate = DateTime.Now,
            //            UserIsActive = true,
            //            UserIsDelete = false
            //        },
            //        new TblUser
            //        {
            //            UserGuid = Guid.NewGuid(),
            //            UserRoleId = 1,
            //            UserName = "ارشیا",
            //            UserFamily = "اموری سرابی",
            //            UserEmail = "arshiasarabi@gmail.com",
            //            UserMobile = "09120509234",
            //            UserCreateDate = DateTime.Now,
            //            UserModifyDate = DateTime.Now,
            //            UserIsActive = true,
            //            UserIsDelete = false
            //        },
            //        new TblUser
            //        {
            //            UserGuid = Guid.NewGuid(),
            //            UserRoleId = 1,
            //            UserName = "روزبه",
            //            UserFamily = "شامخی",
            //            UserEmail = "roozbehshamekhi@hotmail.com",
            //            UserMobile = "09128277075",
            //            UserCreateDate = DateTime.Now,
            //            UserModifyDate = DateTime.Now,
            //            UserIsActive = true,
            //            UserIsDelete = false
            //        }
            //    );

            //modelBuilder.Entity<TblCategory>().HasData(
            //        new TblCategory
            //        {
            //            CategoryGuid = Guid.NewGuid(),
            //            CategoryCategoryGuid = null,
            //            CategoryDisplay = "سایت اصلی",
            //            CategoryOrder = 1,
            //            CategoryCreateDate = DateTime.Now,
            //            CategoryModifyDate = DateTime.Now,
            //            CategoryIsDelete = false
            //        },
            //        new TblCategory
            //        {
            //            CategoryGuid = Guid.NewGuid(),
            //            CategoryCategoryGuid = null,
            //            CategoryDisplay = "وبلاگ",
            //            CategoryOrder = 2,
            //            CategoryCreateDate = DateTime.Now,
            //            CategoryModifyDate = DateTime.Now,
            //            CategoryIsDelete = false
            //        }
            //    );

            //modelBuilder.Entity<TblCodeGroup>().HasData(
            //        new TblCodeGroup
            //        {
            //            CgId = 1,
            //            CgGuid = Guid.NewGuid(),
            //            CgName = "FilepondType",
            //            CgDisplay = "نوع فایل"
            //        }
            //    );

            //modelBuilder.Entity<TblCode>().HasData(
            //        new TblCode
            //        {
            //            CodeId = 1,
            //            CodeGuid = Guid.NewGuid(),
            //            CodeCgid = 1,
            //            CodeName = "image/png",
            //            CodeDisplay = "png",
            //            CodeIsDelete = false
            //        },
            //        new TblCode
            //        {
            //            CodeId = 2,
            //            CodeGuid = Guid.NewGuid(),
            //            CodeCgid = 1,
            //            CodeName = "image/jpg",
            //            CodeDisplay = "jpg",
            //            CodeIsDelete = false
            //        },
            //        new TblCode
            //        {
            //            CodeId = 3,
            //            CodeGuid = Guid.NewGuid(),
            //            CodeCgid = 1,
            //            CodeName = "image/jpeg",
            //            CodeDisplay = "jpeg",
            //            CodeIsDelete = false
            //        }
            //    );
        }
    }
}
