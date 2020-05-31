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
			#region Province

			modelBuilder.Entity<Province>().HasData(
					new Province
					{
						ProvinceId = 1,
						ProvinceGuid = Guid.NewGuid(),
						Name = "يزد"
					},
					new Province
					{
						ProvinceId = 2,
						ProvinceGuid = Guid.NewGuid(),
						Name = "چهار محال و بختياري"
					},
					new Province
					{
						ProvinceId = 3,
						ProvinceGuid = Guid.NewGuid(),
						Name = "خراسان شمالي"
					},
					new Province
					{
						ProvinceId = 4,
						ProvinceGuid = Guid.NewGuid(),
						Name = "البرز"
					},
					new Province
					{
						ProvinceId = 5,
						ProvinceGuid = Guid.NewGuid(),
						Name = "قم"
					},
					new Province
					{
						ProvinceId = 6,
						ProvinceGuid = Guid.NewGuid(),
						Name = "کردستان"
					},
					new Province
					{
						ProvinceId = 7,
						ProvinceGuid = Guid.NewGuid(),
						Name = "آذربايجان غربي"
					},
					new Province
					{
						ProvinceId = 8,
						ProvinceGuid = Guid.NewGuid(),
						Name = "خراسان رضوي"
					},
					new Province
					{
						ProvinceId = 9,
						ProvinceGuid = Guid.NewGuid(),
						Name = "سيستان و بلوچستان"
					},
					new Province
					{
						ProvinceId = 10,
						ProvinceGuid = Guid.NewGuid(),
						Name = "خراسان جنوبي"
					},
					new Province
					{
						ProvinceId = 11,
						ProvinceGuid = Guid.NewGuid(),
						Name = "خوزستان"
					},
					new Province
					{
						ProvinceId = 12,
						ProvinceGuid = Guid.NewGuid(),
						Name = "بوشهر"
					},
					new Province
					{
						ProvinceId = 13,
						ProvinceGuid = Guid.NewGuid(),
						Name = "زنجان"
					},
					new Province
					{
						ProvinceId = 14,
						ProvinceGuid = Guid.NewGuid(),
						Name = "گلستان"
					},
					new Province
					{
						ProvinceId = 15,
						ProvinceGuid = Guid.NewGuid(),
						Name = "مازندران"
					},
					new Province
					{
						ProvinceId = 16,
						ProvinceGuid = Guid.NewGuid(),
						Name = "قزوين"
					},
					new Province
					{
						ProvinceId = 17,
						ProvinceGuid = Guid.NewGuid(),
						Name = "لرستان"
					},
					new Province
					{
						ProvinceId = 18,
						ProvinceGuid = Guid.NewGuid(),
						Name = "اردبيل"
					},
					new Province
					{
						ProvinceId = 19,
						ProvinceGuid = Guid.NewGuid(),
						Name = "اصفهان"
					},
					new Province
					{
						ProvinceId = 20,
						ProvinceGuid = Guid.NewGuid(),
						Name = "ايلام"
					},
					new Province
					{
						ProvinceId = 21,
						ProvinceGuid = Guid.NewGuid(),
						Name = "تهران"
					},
					new Province
					{
						ProvinceId = 22,
						ProvinceGuid = Guid.NewGuid(),
						Name = "آذربايجان شرقي"
					},
					new Province
					{
						ProvinceId = 23,
						ProvinceGuid = Guid.NewGuid(),
						Name = "فارس"
					},
					new Province
					{
						ProvinceId = 24,
						ProvinceGuid = Guid.NewGuid(),
						Name = "کرمانشاه"
					},
					new Province
					{
						ProvinceId = 25,
						ProvinceGuid = Guid.NewGuid(),
						Name = "هرمزگان"
					},
					new Province
					{
						ProvinceId = 26,
						ProvinceGuid = Guid.NewGuid(),
						Name = "مرکزي"
					},
					new Province
					{
						ProvinceId = 27,
						ProvinceGuid = Guid.NewGuid(),
						Name = "گيلان"
					},
					new Province
					{
						ProvinceId = 28,
						ProvinceGuid = Guid.NewGuid(),
						Name = "همدان"
					},
					new Province
					{
						ProvinceId = 29,
						ProvinceGuid = Guid.NewGuid(),
						Name = "کرمان"
					},
					new Province
					{
						ProvinceId = 30,
						ProvinceGuid = Guid.NewGuid(),
						Name = "سمنان"
					},
					new Province
					{
						ProvinceId = 31,
						ProvinceGuid = Guid.NewGuid(),
						Name = "کهگيلويه و بويراحمد"
					}
				);

			#endregion

			#region City

			modelBuilder.Entity<City>().HasData(
					new City
					{
						CityId = 1,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "ابرکوه"
					},
					new City
					{
						CityId = 2,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "احمد آباد"
					},
					new City
					{
						CityId = 3,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "اردکان"
					},
					new City
					{
						CityId = 4,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "اشکذر"
					},
					new City
					{
						CityId = 5,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "بافق"
					},
					new City
					{
						CityId = 6,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "بفروئيه"
					},
					new City
					{
						CityId = 7,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "بهاباد"
					},
					new City
					{
						CityId = 8,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "تفت"
					},
					new City
					{
						CityId = 9,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "حميديا"
					},
					new City
					{
						CityId = 10,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "خضر آباد"
					},
					new City
					{
						CityId = 11,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "زارچ"
					},
					new City
					{
						CityId = 12,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "شاهديه"
					},
					new City
					{
						CityId = 13,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "عقدا"
					},
					new City
					{
						CityId = 14,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "مروست"
					},
					new City
					{
						CityId = 15,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "مهردشت"
					},
					new City
					{
						CityId = 16,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "مهريز"
					},
					new City
					{
						CityId = 17,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "ميبد"
					},
					new City
					{
						CityId = 18,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "ندوشن"
					},
					new City
					{
						CityId = 19,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "نير"
					},
					new City
					{
						CityId = 20,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "هرات"
					},
					new City
					{
						CityId = 21,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 1,
						Name = "يزد"
					},
					new City
					{
						CityId = 22,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "آلوني"
					},
					new City
					{
						CityId = 23,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "اردل"
					},
					new City
					{
						CityId = 24,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "باباحيدر"
					},
					new City
					{
						CityId = 25,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "بازفت"
					},
					new City
					{
						CityId = 26,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "بروجن"
					},
					new City
					{
						CityId = 27,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "بلداجي"
					},
					new City
					{
						CityId = 28,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "بن"
					},
					new City
					{
						CityId = 29,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "جونقان"
					},
					new City
					{
						CityId = 30,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "دستناء"
					},
					new City
					{
						CityId = 31,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "دشتک"
					},
					new City
					{
						CityId = 32,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "سامان"
					},
					new City
					{
						CityId = 33,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "سرخون"
					},
					new City
					{
						CityId = 34,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "سردشت لردگان"
					},
					new City
					{
						CityId = 35,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "سفيد دشت"
					},
					new City
					{
						CityId = 36,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "سودجان"
					},
					new City
					{
						CityId = 37,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "سورشجان"
					},
					new City
					{
						CityId = 38,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "شلمزار"
					},
					new City
					{
						CityId = 39,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "شهرکرد"
					},
					new City
					{
						CityId = 40,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "صمصامي"
					},
					new City
					{
						CityId = 41,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "طاقانک"
					},
					new City
					{
						CityId = 42,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "فارسان"
					},
					new City
					{
						CityId = 43,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "فرادنبه"
					},
					new City
					{
						CityId = 44,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "فرخ شهر"
					},
					new City
					{
						CityId = 45,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "لردگان"
					},
					new City
					{
						CityId = 46,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "مال خليفه"
					},
					new City
					{
						CityId = 47,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "منج"
					},
					new City
					{
						CityId = 48,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "ناغان"
					},
					new City
					{
						CityId = 49,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "نافچ"
					},
					new City
					{
						CityId = 50,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "نقنه"
					},
					new City
					{
						CityId = 51,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "هاروني"
					},
					new City
					{
						CityId = 52,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "هفشجان"
					},
					new City
					{
						CityId = 53,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "وردنجان"
					},
					new City
					{
						CityId = 54,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "پردنجان"
					},
					new City
					{
						CityId = 55,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "چليچه"
					},
					new City
					{
						CityId = 56,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "چلگرد"
					},
					new City
					{
						CityId = 57,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "کاج"
					},
					new City
					{
						CityId = 58,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "کيان"
					},
					new City
					{
						CityId = 59,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "گندمان"
					},
					new City
					{
						CityId = 60,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "گهرو"
					},
					new City
					{
						CityId = 61,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 2,
						Name = "گوجان"
					},
					new City
					{
						CityId = 62,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "آشخانه"
					},
					new City
					{
						CityId = 63,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "آوا"
					},
					new City
					{
						CityId = 64,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "اسفراين"
					},
					new City
					{
						CityId = 65,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "ايور"
					},
					new City
					{
						CityId = 66,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "بجنورد"
					},
					new City
					{
						CityId = 67,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "تيتکانلو"
					},
					new City
					{
						CityId = 68,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "جاجرم"
					},
					new City
					{
						CityId = 69,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "حصارگرمخان"
					},
					new City
					{
						CityId = 70,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "درق"
					},
					new City
					{
						CityId = 71,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "راز"
					},
					new City
					{
						CityId = 72,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "زيارت"
					},
					new City
					{
						CityId = 73,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "سنخواست"
					},
					new City
					{
						CityId = 74,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "شوقان"
					},
					new City
					{
						CityId = 75,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "شيروان"
					},
					new City
					{
						CityId = 76,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "صفي آباد"
					},
					new City
					{
						CityId = 77,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "فاروج"
					},
					new City
					{
						CityId = 78,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "قاضي"
					},
					new City
					{
						CityId = 79,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "قوشخانه"
					},
					new City
					{
						CityId = 80,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "لوجلي"
					},
					new City
					{
						CityId = 81,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "پيش قلعه"
					},
					new City
					{
						CityId = 82,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "چناران شهر"
					},
					new City
					{
						CityId = 83,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 3,
						Name = "گرمه"
					},
					new City
					{
						CityId = 84,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "آسارا"
					},
					new City
					{
						CityId = 85,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "اشتهارد"
					},
					new City
					{
						CityId = 86,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "تنکمان"
					},
					new City
					{
						CityId = 87,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "شهر جديد هشتگرد"
					},
					new City
					{
						CityId = 88,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "طالقان"
					},
					new City
					{
						CityId = 89,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "فرديس"
					},
					new City
					{
						CityId = 90,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "ماهدشت"
					},
					new City
					{
						CityId = 91,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "محمد شهر"
					},
					new City
					{
						CityId = 92,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "مشکين دشت"
					},
					new City
					{
						CityId = 93,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "نظر آباد"
					},
					new City
					{
						CityId = 94,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "هشتگرد"
					},
					new City
					{
						CityId = 95,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "چهارباغ"
					},
					new City
					{
						CityId = 96,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "کرج"
					},
					new City
					{
						CityId = 97,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "کمال شهر"
					},
					new City
					{
						CityId = 98,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "کوهسار"
					},
					new City
					{
						CityId = 99,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "گرمدره"
					},
					new City
					{
						CityId = 100,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 4,
						Name = "گلسار"
					},
					new City
					{
						CityId = 101,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 5,
						Name = "جعفريه"
					},
					new City
					{
						CityId = 102,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 5,
						Name = "دستجرد"
					},
					new City
					{
						CityId = 103,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 5,
						Name = "سلفچگان"
					},
					new City
					{
						CityId = 104,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 5,
						Name = "قم"
					},
					new City
					{
						CityId = 105,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 5,
						Name = "قنوات"
					},
					new City
					{
						CityId = 106,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 5,
						Name = "کهک"
					},
					new City
					{
						CityId = 107,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "آرمرده"
					},
					new City
					{
						CityId = 108,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "اورامان تخت"
					},
					new City
					{
						CityId = 109,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "بابارشاني"
					},
					new City
					{
						CityId = 110,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "بانه"
					},
					new City
					{
						CityId = 111,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "برده رشه"
					},
					new City
					{
						CityId = 112,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "بلبان آباد"
					},
					new City
					{
						CityId = 113,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "بوئين سفلي"
					},
					new City
					{
						CityId = 114,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "بيجار"
					},
					new City
					{
						CityId = 115,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "توپ آغاج"
					},
					new City
					{
						CityId = 116,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "دزج"
					},
					new City
					{
						CityId = 117,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "دلبران"
					},
					new City
					{
						CityId = 118,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "دهگلان"
					},
					new City
					{
						CityId = 119,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "ديواندره"
					},
					new City
					{
						CityId = 120,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "زرينه"
					},
					new City
					{
						CityId = 121,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "سرو آباد"
					},
					new City
					{
						CityId = 122,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "سريش آباد"
					},
					new City
					{
						CityId = 123,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "سقز"
					},
					new City
					{
						CityId = 124,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "سنندج"
					},
					new City
					{
						CityId = 125,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "شويشه"
					},
					new City
					{
						CityId = 126,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "صاحب"
					},
					new City
					{
						CityId = 127,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "قروه"
					},
					new City
					{
						CityId = 128,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "مريوان"
					},
					new City
					{
						CityId = 129,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "موچش"
					},
					new City
					{
						CityId = 130,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "ياسوکند"
					},
					new City
					{
						CityId = 131,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "پيرتاج"
					},
					new City
					{
						CityId = 132,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "چناره"
					},
					new City
					{
						CityId = 133,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "کامياران"
					},
					new City
					{
						CityId = 134,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "کاني دينار"
					},
					new City
					{
						CityId = 135,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 6,
						Name = "کاني سور"
					},
					new City
					{
						CityId = 136,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "آواجيق"
					},
					new City
					{
						CityId = 137,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "اروميه"
					},
					new City
					{
						CityId = 138,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "اشنويه"
					},
					new City
					{
						CityId = 139,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "ايواوغلي"
					},
					new City
					{
						CityId = 140,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "باروق"
					},
					new City
					{
						CityId = 141,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "بازرگان"
					},
					new City
					{
						CityId = 142,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "بوکان"
					},
					new City
					{
						CityId = 143,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "تازه شهر"
					},
					new City
					{
						CityId = 144,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "تکاب"
					},
					new City
					{
						CityId = 145,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "خليفان"
					},
					new City
					{
						CityId = 146,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "خوي"
					},
					new City
					{
						CityId = 147,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "ديزج ديز"
					},
					new City
					{
						CityId = 148,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "ربط"
					},
					new City
					{
						CityId = 149,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "زرآباد"
					},
					new City
					{
						CityId = 150,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "سردشت"
					},
					new City
					{
						CityId = 151,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "سرو"
					},
					new City
					{
						CityId = 152,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "سلماس"
					},
					new City
					{
						CityId = 153,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "سيلوانه"
					},
					new City
					{
						CityId = 154,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "سيمينه"
					},
					new City
					{
						CityId = 155,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "سيه چشمه"
					},
					new City
					{
						CityId = 156,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "شاهين دژ"
					},
					new City
					{
						CityId = 157,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "شوط"
					},
					new City
					{
						CityId = 158,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "فيرورق"
					},
					new City
					{
						CityId = 159,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "قره ضياء الدين"
					},
					new City
					{
						CityId = 160,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "قطور"
					},
					new City
					{
						CityId = 161,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "قوشچي"
					},
					new City
					{
						CityId = 162,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "ماکو"
					},
					new City
					{
						CityId = 163,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "محمد يار"
					},
					new City
					{
						CityId = 164,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "محمود آباد"
					},
					new City
					{
						CityId = 165,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "مرگنلر"
					},
					new City
					{
						CityId = 166,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "مهاباد"
					},
					new City
					{
						CityId = 167,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "مياندوآب"
					},
					new City
					{
						CityId = 168,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "ميرآباد"
					},
					new City
					{
						CityId = 169,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "نازک عليا"
					},
					new City
					{
						CityId = 170,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "نالوس"
					},
					new City
					{
						CityId = 171,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "نقده"
					},
					new City
					{
						CityId = 172,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "نوشين"
					},
					new City
					{
						CityId = 173,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "پلدشت"
					},
					new City
					{
						CityId = 174,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "پيرانشهر"
					},
					new City
					{
						CityId = 175,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "چهار برج"
					},
					new City
					{
						CityId = 176,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "کشاورز"
					},
					new City
					{
						CityId = 177,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 7,
						Name = "گردکشانه"
					},
					new City
					{
						CityId = 178,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "احمدآباد صولت"
					},
					new City
					{
						CityId = 179,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "انابد"
					},
					new City
					{
						CityId = 180,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "باجگيران"
					},
					new City
					{
						CityId = 181,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "باخرز"
					},
					new City
					{
						CityId = 182,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "بار"
					},
					new City
					{
						CityId = 183,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "بايک"
					},
					new City
					{
						CityId = 184,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "بجستان"
					},
					new City
					{
						CityId = 185,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "بردسکن"
					},
					new City
					{
						CityId = 186,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "بيدخت"
					},
					new City
					{
						CityId = 187,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "تايباد"
					},
					new City
					{
						CityId = 188,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "تربت جام"
					},
					new City
					{
						CityId = 189,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "تربت حيدريه"
					},
					new City
					{
						CityId = 190,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "جغتاي"
					},
					new City
					{
						CityId = 191,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "جنگل"
					},
					new City
					{
						CityId = 192,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "خرو"
					},
					new City
					{
						CityId = 193,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "خليل آباد"
					},
					new City
					{
						CityId = 194,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "خواف"
					},
					new City
					{
						CityId = 195,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "داورزن"
					},
					new City
					{
						CityId = 196,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "درود"
					},
					new City
					{
						CityId = 197,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "درگز"
					},
					new City
					{
						CityId = 198,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "دولت آباد"
					},
					new City
					{
						CityId = 199,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "رباط سنگ"
					},
					new City
					{
						CityId = 200,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "رشتخوار"
					},
					new City
					{
						CityId = 201,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "رضويه"
					},
					new City
					{
						CityId = 202,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "روداب"
					},
					new City
					{
						CityId = 203,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "ريوش"
					},
					new City
					{
						CityId = 204,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "سبزوار"
					},
					new City
					{
						CityId = 205,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "سرخس"
					},
					new City
					{
						CityId = 206,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "سفيد سنگ"
					},
					new City
					{
						CityId = 207,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "سلامي"
					},
					new City
					{
						CityId = 208,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "سلطان آباد"
					},
					new City
					{
						CityId = 209,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "سنگان"
					},
					new City
					{
						CityId = 210,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "شادمهر"
					},
					new City
					{
						CityId = 211,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "شانديز"
					},
					new City
					{
						CityId = 212,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "ششتمد"
					},
					new City
					{
						CityId = 213,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "شهر زو"
					},
					new City
					{
						CityId = 214,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "شهرآباد"
					},
					new City
					{
						CityId = 215,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "صالح آباد"
					},
					new City
					{
						CityId = 216,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "طرقبه"
					},
					new City
					{
						CityId = 217,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "عشق آباد"
					},
					new City
					{
						CityId = 218,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "فرهاد گرد"
					},
					new City
					{
						CityId = 219,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "فريمان"
					},
					new City
					{
						CityId = 220,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "فيروزه"
					},
					new City
					{
						CityId = 221,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "فيض آباد"
					},
					new City
					{
						CityId = 222,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "قاسم آباد"
					},
					new City
					{
						CityId = 223,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "قدمگاه"
					},
					new City
					{
						CityId = 224,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "قلندر آباد"
					},
					new City
					{
						CityId = 225,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "قوچان"
					},
					new City
					{
						CityId = 226,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "لطف آباد"
					},
					new City
					{
						CityId = 227,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "مزدآوند"
					},
					new City
					{
						CityId = 228,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "مشهد"
					},
					new City
					{
						CityId = 229,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "مشهدريزه"
					},
					new City
					{
						CityId = 230,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "ملک آباد"
					},
					new City
					{
						CityId = 231,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "نشتيفان"
					},
					new City
					{
						CityId = 232,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "نصرآباد"
					},
					new City
					{
						CityId = 233,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "نقاب"
					},
					new City
					{
						CityId = 234,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "نوخندان"
					},
					new City
					{
						CityId = 235,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "نيشابور"
					},
					new City
					{
						CityId = 236,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "نيل شهر"
					},
					new City
					{
						CityId = 237,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "همت آباد"
					},
					new City
					{
						CityId = 238,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "يونسي"
					},
					new City
					{
						CityId = 239,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "چاپشلو"
					},
					new City
					{
						CityId = 240,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "چناران"
					},
					new City
					{
						CityId = 241,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "چکنه"
					},
					new City
					{
						CityId = 242,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "کاخک"
					},
					new City
					{
						CityId = 243,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "کاريز"
					},
					new City
					{
						CityId = 244,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "کاشمر"
					},
					new City
					{
						CityId = 245,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "کدکن"
					},
					new City
					{
						CityId = 246,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "کلات"
					},
					new City
					{
						CityId = 247,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "کندر"
					},
					new City
					{
						CityId = 248,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "گلمکان"
					},
					new City
					{
						CityId = 249,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 8,
						Name = "گناباد"
					},
					new City
					{
						CityId = 250,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "اديمي"
					},
					new City
					{
						CityId = 251,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "اسپکه"
					},
					new City
					{
						CityId = 252,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "ايرانشهر"
					},
					new City
					{
						CityId = 253,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "بزمان"
					},
					new City
					{
						CityId = 254,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "بمپور"
					},
					new City
					{
						CityId = 255,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "بنت"
					},
					new City
					{
						CityId = 256,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "بنجار"
					},
					new City
					{
						CityId = 257,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "جالق"
					},
					new City
					{
						CityId = 258,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "خاش"
					},
					new City
					{
						CityId = 259,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "دوست محمد"
					},
					new City
					{
						CityId = 260,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "راسک"
					},
					new City
					{
						CityId = 261,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "زابل"
					},
					new City
					{
						CityId = 262,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "زاهدان"
					},
					new City
					{
						CityId = 263,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "زرآباد"
					},
					new City
					{
						CityId = 264,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "زهک"
					},
					new City
					{
						CityId = 265,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "سراوان"
					},
					new City
					{
						CityId = 266,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "سرباز"
					},
					new City
					{
						CityId = 267,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "سوران"
					},
					new City
					{
						CityId = 268,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "سيرکان"
					},
					new City
					{
						CityId = 269,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "علي اکبر"
					},
					new City
					{
						CityId = 270,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "فنوج"
					},
					new City
					{
						CityId = 271,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "قصر قند"
					},
					new City
					{
						CityId = 272,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "محمد آباد"
					},
					new City
					{
						CityId = 273,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "محمدان"
					},
					new City
					{
						CityId = 274,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "محمدي"
					},
					new City
					{
						CityId = 275,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "مهرستان"
					},
					new City
					{
						CityId = 276,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "ميرجاوه"
					},
					new City
					{
						CityId = 277,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "نصرت آباد"
					},
					new City
					{
						CityId = 278,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "نوک آباد"
					},
					new City
					{
						CityId = 279,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "نيک شهر"
					},
					new City
					{
						CityId = 280,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "نگور"
					},
					new City
					{
						CityId = 281,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "هيدوچ"
					},
					new City
					{
						CityId = 282,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "پيشين"
					},
					new City
					{
						CityId = 283,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "چاه بهار"
					},
					new City
					{
						CityId = 284,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "کنارک"
					},
					new City
					{
						CityId = 285,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "گشت"
					},
					new City
					{
						CityId = 286,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 9,
						Name = "گلمورتي"
					},
					new City
					{
						CityId = 287,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "آرين شهر"
					},
					new City
					{
						CityId = 288,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "آيسک"
					},
					new City
					{
						CityId = 289,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "ارسک"
					},
					new City
					{
						CityId = 290,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "اسديه"
					},
					new City
					{
						CityId = 291,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "اسفدن"
					},
					new City
					{
						CityId = 292,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "اسلاميه"
					},
					new City
					{
						CityId = 293,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "بشرويه"
					},
					new City
					{
						CityId = 294,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "بيرجند"
					},
					new City
					{
						CityId = 295,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "حاجي آباد"
					},
					new City
					{
						CityId = 296,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "خضري دشت بياض"
					},
					new City
					{
						CityId = 297,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "خوسف"
					},
					new City
					{
						CityId = 298,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "ديهوک"
					},
					new City
					{
						CityId = 299,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "زهان"
					},
					new City
					{
						CityId = 300,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "سرايان"
					},
					new City
					{
						CityId = 301,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "سربيشه"
					},
					new City
					{
						CityId = 302,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "سه قلعه"
					},
					new City
					{
						CityId = 303,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "شوسف"
					},
					new City
					{
						CityId = 304,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "طبس"
					},
					new City
					{
						CityId = 305,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "طبس مسينا"
					},
					new City
					{
						CityId = 306,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "عشق آباد"
					},
					new City
					{
						CityId = 307,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "فردوس"
					},
					new City
					{
						CityId = 308,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "قائن"
					},
					new City
					{
						CityId = 309,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "قهستان"
					},
					new City
					{
						CityId = 310,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "محمدشهر"
					},
					new City
					{
						CityId = 311,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "مود"
					},
					new City
					{
						CityId = 312,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "نهبندان"
					},
					new City
					{
						CityId = 313,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "نيمبلوک"
					},
					new City
					{
						CityId = 314,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 10,
						Name = "گزيک"
					},
					new City
					{
						CityId = 315,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "آبادان"
					},
					new City
					{
						CityId = 316,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "آبژدان"
					},
					new City
					{
						CityId = 317,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "آزادي"
					},
					new City
					{
						CityId = 318,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "آغاجاري"
					},
					new City
					{
						CityId = 319,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "ابوحميظه"
					},
					new City
					{
						CityId = 320,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "اروند کنار"
					},
					new City
					{
						CityId = 321,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "الهايي"
					},
					new City
					{
						CityId = 322,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "الوان"
					},
					new City
					{
						CityId = 323,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "اميديه"
					},
					new City
					{
						CityId = 324,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "انديمشک"
					},
					new City
					{
						CityId = 325,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "اهواز"
					},
					new City
					{
						CityId = 326,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "ايذه"
					},
					new City
					{
						CityId = 327,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "باغ ملک"
					},
					new City
					{
						CityId = 328,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "بستان"
					},
					new City
					{
						CityId = 329,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "بندر امام خميني"
					},
					new City
					{
						CityId = 330,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "بندر ماهشهر"
					},
					new City
					{
						CityId = 331,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "بهبهان"
					},
					new City
					{
						CityId = 332,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "بيدروبه"
					},
					new City
					{
						CityId = 333,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "ترکالکي"
					},
					new City
					{
						CityId = 334,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "تشان"
					},
					new City
					{
						CityId = 335,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "جايزان"
					},
					new City
					{
						CityId = 336,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "جنت مکان"
					},
					new City
					{
						CityId = 337,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "حر"
					},
					new City
					{
						CityId = 338,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "حسينيه"
					},
					new City
					{
						CityId = 339,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "حمزه"
					},
					new City
					{
						CityId = 340,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "حميديه"
					},
					new City
					{
						CityId = 341,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "خرمشهر"
					},
					new City
					{
						CityId = 342,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "خنافره"
					},
					new City
					{
						CityId = 343,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "دارخوين"
					},
					new City
					{
						CityId = 344,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "دزفول"
					},
					new City
					{
						CityId = 345,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "دهدز"
					},
					new City
					{
						CityId = 346,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "رامشير"
					},
					new City
					{
						CityId = 347,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "رامهرمز"
					},
					new City
					{
						CityId = 348,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "رفيع"
					},
					new City
					{
						CityId = 349,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "زهره"
					},
					new City
					{
						CityId = 350,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "سالند"
					},
					new City
					{
						CityId = 351,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "سرداران"
					},
					new City
					{
						CityId = 352,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "سردشت"
					},
					new City
					{
						CityId = 353,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "سماله"
					},
					new City
					{
						CityId = 354,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "سوسنگرد"
					},
					new City
					{
						CityId = 355,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "سياه منصور"
					},
					new City
					{
						CityId = 356,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "شادگان"
					},
					new City
					{
						CityId = 357,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "شاوور"
					},
					new City
					{
						CityId = 358,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "شرافت"
					},
					new City
					{
						CityId = 359,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "شمس آباد"
					},
					new City
					{
						CityId = 360,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "شهر امام"
					},
					new City
					{
						CityId = 361,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "شوش"
					},
					new City
					{
						CityId = 362,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "شوشتر"
					},
					new City
					{
						CityId = 363,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "شيبان"
					},
					new City
					{
						CityId = 364,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "صالح شهر"
					},
					new City
					{
						CityId = 365,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "صفي آباد"
					},
					new City
					{
						CityId = 366,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "صيدون"
					},
					new City
					{
						CityId = 367,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "فتح المبين"
					},
					new City
					{
						CityId = 368,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "قلعه تل"
					},
					new City
					{
						CityId = 369,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "قلعه خواجه"
					},
					new City
					{
						CityId = 370,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "لالي"
					},
					new City
					{
						CityId = 371,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "مسجد سليمان"
					},
					new City
					{
						CityId = 372,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "مشراگه"
					},
					new City
					{
						CityId = 373,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "مقاومت"
					},
					new City
					{
						CityId = 374,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "ملاثاني"
					},
					new City
					{
						CityId = 375,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "منصوريه"
					},
					new City
					{
						CityId = 376,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "ميانرود"
					},
					new City
					{
						CityId = 377,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "ميداود"
					},
					new City
					{
						CityId = 378,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "مينوشهر"
					},
					new City
					{
						CityId = 379,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "هفتگل"
					},
					new City
					{
						CityId = 380,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "هنديجان"
					},
					new City
					{
						CityId = 381,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "هويزه"
					},
					new City
					{
						CityId = 382,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "ويس"
					},
					new City
					{
						CityId = 383,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "چغاميش"
					},
					new City
					{
						CityId = 384,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "چم گلک"
					},
					new City
					{
						CityId = 385,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "چمران"
					},
					new City
					{
						CityId = 386,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "چوئبده"
					},
					new City
					{
						CityId = 387,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "کوت سيدنعيم"
					},
					new City
					{
						CityId = 388,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "کوت عبدالله"
					},
					new City
					{
						CityId = 389,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "گتوند"
					},
					new City
					{
						CityId = 390,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "گلگير"
					},
					new City
					{
						CityId = 391,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 11,
						Name = "گوريه"
					},
					new City
					{
						CityId = 392,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "آباد"
					},
					new City
					{
						CityId = 393,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "آبدان"
					},
					new City
					{
						CityId = 394,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "آبپخش"
					},
					new City
					{
						CityId = 395,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "امام حسن"
					},
					new City
					{
						CityId = 396,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "انارستان"
					},
					new City
					{
						CityId = 397,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "اهرم"
					},
					new City
					{
						CityId = 398,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بادوله"
					},
					new City
					{
						CityId = 399,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "برازجان"
					},
					new City
					{
						CityId = 400,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بردخون"
					},
					new City
					{
						CityId = 401,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بردستان"
					},
					new City
					{
						CityId = 402,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بندر دير"
					},
					new City
					{
						CityId = 403,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بندر ديلم"
					},
					new City
					{
						CityId = 404,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بندر ريگ"
					},
					new City
					{
						CityId = 405,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بندر کنگان"
					},
					new City
					{
						CityId = 406,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بندر گناوه"
					},
					new City
					{
						CityId = 407,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بنک"
					},
					new City
					{
						CityId = 408,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بوشهر"
					},
					new City
					{
						CityId = 409,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "بوشکان"
					},
					new City
					{
						CityId = 410,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "تنگ ارم"
					},
					new City
					{
						CityId = 411,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "جم"
					},
					new City
					{
						CityId = 412,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "خارک"
					},
					new City
					{
						CityId = 413,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "خورموج"
					},
					new City
					{
						CityId = 414,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "دالکي"
					},
					new City
					{
						CityId = 415,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "دلوار"
					},
					new City
					{
						CityId = 416,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "دوراهک"
					},
					new City
					{
						CityId = 417,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "ريز"
					},
					new City
					{
						CityId = 418,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "سعد آباد"
					},
					new City
					{
						CityId = 419,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "سيراف"
					},
					new City
					{
						CityId = 420,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "شبانکاره"
					},
					new City
					{
						CityId = 421,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "شنبه"
					},
					new City
					{
						CityId = 422,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "عسلويه"
					},
					new City
					{
						CityId = 423,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "نخل تقي"
					},
					new City
					{
						CityId = 424,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "وحدتيه"
					},
					new City
					{
						CityId = 425,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "چغادک"
					},
					new City
					{
						CityId = 426,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "کاکي"
					},
					new City
					{
						CityId = 427,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 12,
						Name = "کلمه"
					},
					new City
					{
						CityId = 428,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "آب بر"
					},
					new City
					{
						CityId = 429,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "ابهر"
					},
					new City
					{
						CityId = 430,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "ارمخانخانه"
					},
					new City
					{
						CityId = 431,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "حلب"
					},
					new City
					{
						CityId = 432,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "خرمدره"
					},
					new City
					{
						CityId = 433,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "دندي"
					},
					new City
					{
						CityId = 434,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "زرين آباد"
					},
					new City
					{
						CityId = 435,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "زرين رود"
					},
					new City
					{
						CityId = 436,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "زنجان"
					},
					new City
					{
						CityId = 437,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "سجاس"
					},
					new City
					{
						CityId = 438,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "سلطانيه"
					},
					new City
					{
						CityId = 439,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "سهرورد"
					},
					new City
					{
						CityId = 440,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "صائين قلعه"
					},
					new City
					{
						CityId = 441,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "قيدار"
					},
					new City
					{
						CityId = 442,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "ماه نشان"
					},
					new City
					{
						CityId = 443,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "نوربهار"
					},
					new City
					{
						CityId = 444,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "نيک پي"
					},
					new City
					{
						CityId = 445,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "هيدج"
					},
					new City
					{
						CityId = 446,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "چورزق"
					},
					new City
					{
						CityId = 447,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "کرسف"
					},
					new City
					{
						CityId = 448,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 13,
						Name = "گرماب"
					},
					new City
					{
						CityId = 449,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "آزاد شهر"
					},
					new City
					{
						CityId = 450,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "آق قلا"
					},
					new City
					{
						CityId = 451,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "انبار آلوم"
					},
					new City
					{
						CityId = 452,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "اينچه برون"
					},
					new City
					{
						CityId = 453,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "بندر ترکمن"
					},
					new City
					{
						CityId = 454,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "بندر گز"
					},
					new City
					{
						CityId = 455,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "تاتار عليا"
					},
					new City
					{
						CityId = 456,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "جلين"
					},
					new City
					{
						CityId = 457,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "خان ببين"
					},
					new City
					{
						CityId = 458,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "دلند"
					},
					new City
					{
						CityId = 459,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "راميان"
					},
					new City
					{
						CityId = 460,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "سرخنکلاته"
					},
					new City
					{
						CityId = 461,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "سنگدوين"
					},
					new City
					{
						CityId = 462,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "سيمين شهر"
					},
					new City
					{
						CityId = 463,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "علي آباد"
					},
					new City
					{
						CityId = 464,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "فاضل آباد"
					},
					new City
					{
						CityId = 465,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "فراغي"
					},
					new City
					{
						CityId = 466,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "مراوه تپه"
					},
					new City
					{
						CityId = 467,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "مزرعه"
					},
					new City
					{
						CityId = 468,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "مينودشت"
					},
					new City
					{
						CityId = 469,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "نوده خاندوز"
					},
					new City
					{
						CityId = 470,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "نوکنده"
					},
					new City
					{
						CityId = 471,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "نگين شهر"
					},
					new City
					{
						CityId = 472,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "کرد کوي"
					},
					new City
					{
						CityId = 473,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "کلاله"
					},
					new City
					{
						CityId = 474,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "گاليکش"
					},
					new City
					{
						CityId = 475,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "گرگان"
					},
					new City
					{
						CityId = 476,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "گميش تپه"
					},
					new City
					{
						CityId = 477,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 14,
						Name = "گنبدکاووس"
					},
					new City
					{
						CityId = 478,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "آلاشت"
					},
					new City
					{
						CityId = 479,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "آمل"
					},
					new City
					{
						CityId = 480,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "ارطه"
					},
					new City
					{
						CityId = 481,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "امامزاده عبدالله"
					},
					new City
					{
						CityId = 482,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "امير کلا"
					},
					new City
					{
						CityId = 483,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "ايزد شهر"
					},
					new City
					{
						CityId = 484,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "بابل"
					},
					new City
					{
						CityId = 485,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "بابلسر"
					},
					new City
					{
						CityId = 486,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "بلده"
					},
					new City
					{
						CityId = 487,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "بهشهر"
					},
					new City
					{
						CityId = 488,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "بهنمير"
					},
					new City
					{
						CityId = 489,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "تنکابن"
					},
					new City
					{
						CityId = 490,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "جويبار"
					},
					new City
					{
						CityId = 491,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "خرم آباد"
					},
					new City
					{
						CityId = 492,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "خليل شهر"
					},
					new City
					{
						CityId = 493,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "خوش رودپي"
					},
					new City
					{
						CityId = 494,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "دابودشت"
					},
					new City
					{
						CityId = 495,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "رامسر"
					},
					new City
					{
						CityId = 496,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "رستمکلا"
					},
					new City
					{
						CityId = 497,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "رويان"
					},
					new City
					{
						CityId = 498,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "رينه"
					},
					new City
					{
						CityId = 499,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "زرگر محله"
					},
					new City
					{
						CityId = 500,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "زيرآب"
					},
					new City
					{
						CityId = 501,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "ساري"
					},
					new City
					{
						CityId = 502,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "سرخرود"
					},
					new City
					{
						CityId = 503,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "سلمان شهر"
					},
					new City
					{
						CityId = 504,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "سورک"
					},
					new City
					{
						CityId = 505,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "شيرود"
					},
					new City
					{
						CityId = 506,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "شيرگاه"
					},
					new City
					{
						CityId = 507,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "عباس آباد"
					},
					new City
					{
						CityId = 508,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "فريدونکنار"
					},
					new City
					{
						CityId = 509,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "فريم"
					},
					new City
					{
						CityId = 510,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "قائم شهر"
					},
					new City
					{
						CityId = 511,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "محمود آباد"
					},
					new City
					{
						CityId = 512,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "مرزن آباد"
					},
					new City
					{
						CityId = 513,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "مرزيکلا"
					},
					new City
					{
						CityId = 514,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "نشتارود"
					},
					new City
					{
						CityId = 515,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "نور"
					},
					new City
					{
						CityId = 516,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "نوشهر"
					},
					new City
					{
						CityId = 517,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "نکا"
					},
					new City
					{
						CityId = 518,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "هادي شهر"
					},
					new City
					{
						CityId = 519,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "هچيرود"
					},
					new City
					{
						CityId = 520,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "پايين هولار"
					},
					new City
					{
						CityId = 521,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "پل سفيد"
					},
					new City
					{
						CityId = 522,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "پول"
					},
					new City
					{
						CityId = 523,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "چالوس"
					},
					new City
					{
						CityId = 524,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "چمستان"
					},
					new City
					{
						CityId = 525,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "کتالم و سادات شهر"
					},
					new City
					{
						CityId = 526,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "کجور"
					},
					new City
					{
						CityId = 527,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "کلارآباد"
					},
					new City
					{
						CityId = 528,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "کلاردشت"
					},
					new City
					{
						CityId = 529,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "کوهي خيل"
					},
					new City
					{
						CityId = 530,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "کياسر"
					},
					new City
					{
						CityId = 531,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "کياکلا"
					},
					new City
					{
						CityId = 532,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "گتاب"
					},
					new City
					{
						CityId = 533,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "گزنک"
					},
					new City
					{
						CityId = 534,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 15,
						Name = "گلوگاه"
					},
					new City
					{
						CityId = 535,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "آبيک"
					},
					new City
					{
						CityId = 536,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "آبگرم"
					},
					new City
					{
						CityId = 537,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "آوج"
					},
					new City
					{
						CityId = 538,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "ارداق"
					},
					new City
					{
						CityId = 539,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "اسفرورين"
					},
					new City
					{
						CityId = 540,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "اقباليه"
					},
					new City
					{
						CityId = 541,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "الوند"
					},
					new City
					{
						CityId = 542,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "بوئين زهرا"
					},
					new City
					{
						CityId = 543,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "بيدستان"
					},
					new City
					{
						CityId = 544,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "تاکستان"
					},
					new City
					{
						CityId = 545,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "خاکعلي"
					},
					new City
					{
						CityId = 546,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "خرمدشت"
					},
					new City
					{
						CityId = 547,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "دانسفهان"
					},
					new City
					{
						CityId = 548,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "رازميان"
					},
					new City
					{
						CityId = 549,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "سيردان"
					},
					new City
					{
						CityId = 550,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "سگز آباد"
					},
					new City
					{
						CityId = 551,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "شال"
					},
					new City
					{
						CityId = 552,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "شريفيه"
					},
					new City
					{
						CityId = 553,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "ضياء آباد"
					},
					new City
					{
						CityId = 554,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "قزوين"
					},
					new City
					{
						CityId = 555,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "محمديه"
					},
					new City
					{
						CityId = 556,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "محمود آباد نمونه"
					},
					new City
					{
						CityId = 557,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "معلم کلايه"
					},
					new City
					{
						CityId = 558,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "نرجه"
					},
					new City
					{
						CityId = 559,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 16,
						Name = "کوهين"
					},
					new City
					{
						CityId = 560,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "ازنا"
					},
					new City
					{
						CityId = 561,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "اشترينان"
					},
					new City
					{
						CityId = 562,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "الشتر"
					},
					new City
					{
						CityId = 563,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "اليگودرز"
					},
					new City
					{
						CityId = 564,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "بروجرد"
					},
					new City
					{
						CityId = 565,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "بيرانشهر"
					},
					new City
					{
						CityId = 566,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "خرم آباد"
					},
					new City
					{
						CityId = 567,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "درب گنبد"
					},
					new City
					{
						CityId = 568,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "دورود"
					},
					new City
					{
						CityId = 569,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "زاغه"
					},
					new City
					{
						CityId = 570,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "سراب دوره"
					},
					new City
					{
						CityId = 571,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "سپيد دشت"
					},
					new City
					{
						CityId = 572,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "شول آباد"
					},
					new City
					{
						CityId = 573,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "فيروزآباد"
					},
					new City
					{
						CityId = 574,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "معمولان"
					},
					new City
					{
						CityId = 575,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "مومن آباد"
					},
					new City
					{
						CityId = 576,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "نورآباد"
					},
					new City
					{
						CityId = 577,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "هفت چشمه"
					},
					new City
					{
						CityId = 578,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "ويسيان"
					},
					new City
					{
						CityId = 579,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "پلدختر"
					},
					new City
					{
						CityId = 580,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "چالانچولان"
					},
					new City
					{
						CityId = 581,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "چقابل"
					},
					new City
					{
						CityId = 582,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "کوهدشت"
					},
					new City
					{
						CityId = 583,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "کوهناني"
					},
					new City
					{
						CityId = 584,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 17,
						Name = "گراب"
					},
					new City
					{
						CityId = 585,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "آبي بيگلو"
					},
					new City
					{
						CityId = 586,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "اردبيل"
					},
					new City
					{
						CityId = 587,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "اسلام آباد"
					},
					new City
					{
						CityId = 588,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "اصلاندوز"
					},
					new City
					{
						CityId = 589,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "بيله سوار"
					},
					new City
					{
						CityId = 590,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "تازه کند"
					},
					new City
					{
						CityId = 591,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "تازه کند انگوت"
					},
					new City
					{
						CityId = 592,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "جعفر آباد"
					},
					new City
					{
						CityId = 593,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "خلخال"
					},
					new City
					{
						CityId = 594,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "رضي"
					},
					new City
					{
						CityId = 595,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "سرعين"
					},
					new City
					{
						CityId = 596,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "عنبران"
					},
					new City
					{
						CityId = 597,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "فخرآباد"
					},
					new City
					{
						CityId = 598,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "قصابه"
					},
					new City
					{
						CityId = 599,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "لاهرود"
					},
					new City
					{
						CityId = 600,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "مرادلو"
					},
					new City
					{
						CityId = 601,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "مشگين شهر"
					},
					new City
					{
						CityId = 602,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "نمين"
					},
					new City
					{
						CityId = 603,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "نير"
					},
					new City
					{
						CityId = 604,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "هشتجين"
					},
					new City
					{
						CityId = 605,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "هير"
					},
					new City
					{
						CityId = 606,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "پارس آباد"
					},
					new City
					{
						CityId = 607,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "کلور"
					},
					new City
					{
						CityId = 608,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "کورائيم"
					},
					new City
					{
						CityId = 609,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "گرمي"
					},
					new City
					{
						CityId = 610,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 18,
						Name = "گيوي"
					},
					new City
					{
						CityId = 611,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "آران و بيدگل"
					},
					new City
					{
						CityId = 612,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "ابريشم"
					},
					new City
					{
						CityId = 613,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "ابوزيد آباد"
					},
					new City
					{
						CityId = 614,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "اردستان"
					},
					new City
					{
						CityId = 615,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "اصغرآباد"
					},
					new City
					{
						CityId = 616,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "اصفهان"
					},
					new City
					{
						CityId = 617,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "افوس"
					},
					new City
					{
						CityId = 618,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "انارک"
					},
					new City
					{
						CityId = 619,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "ايمانشهر"
					},
					new City
					{
						CityId = 620,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "اژيه"
					},
					new City
					{
						CityId = 621,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "بادرود"
					},
					new City
					{
						CityId = 622,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "باغ بهادران"
					},
					new City
					{
						CityId = 623,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "باغشاد"
					},
					new City
					{
						CityId = 624,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "بافران"
					},
					new City
					{
						CityId = 625,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "برزک"
					},
					new City
					{
						CityId = 626,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "برف انبار"
					},
					new City
					{
						CityId = 627,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "بهاران شهر"
					},
					new City
					{
						CityId = 628,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "بهارستان"
					},
					new City
					{
						CityId = 629,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "بوئين مياندشت"
					},
					new City
					{
						CityId = 630,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "تودشک"
					},
					new City
					{
						CityId = 631,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "تيران"
					},
					new City
					{
						CityId = 632,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "جندق"
					},
					new City
					{
						CityId = 633,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "جوزدان"
					},
					new City
					{
						CityId = 634,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "جوشقان قالي"
					},
					new City
					{
						CityId = 635,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "حبيب آباد"
					},
					new City
					{
						CityId = 636,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "حسن آباد"
					},
					new City
					{
						CityId = 637,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "حنا"
					},
					new City
					{
						CityId = 638,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "خالد آباد"
					},
					new City
					{
						CityId = 639,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "خميني شهر"
					},
					new City
					{
						CityId = 640,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "خوانسار"
					},
					new City
					{
						CityId = 641,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "خور"
					},
					new City
					{
						CityId = 642,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "خورزوق"
					},
					new City
					{
						CityId = 643,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "داران"
					},
					new City
					{
						CityId = 644,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "دامنه"
					},
					new City
					{
						CityId = 645,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "درچه پياز"
					},
					new City
					{
						CityId = 646,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "دستگرد"
					},
					new City
					{
						CityId = 647,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "دهاقان"
					},
					new City
					{
						CityId = 648,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "دهق"
					},
					new City
					{
						CityId = 649,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "دولت آباد"
					},
					new City
					{
						CityId = 650,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "ديزيچه"
					},
					new City
					{
						CityId = 651,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "رزوه"
					},
					new City
					{
						CityId = 652,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "رضوانشهر"
					},
					new City
					{
						CityId = 653,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "زازران"
					},
					new City
					{
						CityId = 654,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "زاينده رود"
					},
					new City
					{
						CityId = 655,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "زرين شهر"
					},
					new City
					{
						CityId = 656,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "زواره"
					},
					new City
					{
						CityId = 657,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "زيار"
					},
					new City
					{
						CityId = 658,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "زيباشهر"
					},
					new City
					{
						CityId = 659,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "سده لنجان"
					},
					new City
					{
						CityId = 660,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "سفيد شهر"
					},
					new City
					{
						CityId = 661,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "سميرم"
					},
					new City
					{
						CityId = 662,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "سين"
					},
					new City
					{
						CityId = 663,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "سگزي"
					},
					new City
					{
						CityId = 664,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "شاهين شهر"
					},
					new City
					{
						CityId = 665,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "شاپورآباد"
					},
					new City
					{
						CityId = 666,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "شهرضا"
					},
					new City
					{
						CityId = 667,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "طالخونچه"
					},
					new City
					{
						CityId = 668,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "طرق رود"
					},
					new City
					{
						CityId = 669,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "عسگران"
					},
					new City
					{
						CityId = 670,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "علويچه"
					},
					new City
					{
						CityId = 671,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "فرخي"
					},
					new City
					{
						CityId = 672,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "فريدونشهر"
					},
					new City
					{
						CityId = 673,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "فلاورجان"
					},
					new City
					{
						CityId = 674,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "فولاد شهر"
					},
					new City
					{
						CityId = 675,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "قمصر"
					},
					new City
					{
						CityId = 676,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "قهجاورستان"
					},
					new City
					{
						CityId = 677,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "قهدريجان"
					},
					new City
					{
						CityId = 678,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "لاي بيد"
					},
					new City
					{
						CityId = 679,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "مبارکه"
					},
					new City
					{
						CityId = 680,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "محمد آباد"
					},
					new City
					{
						CityId = 681,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "مشکات"
					},
					new City
					{
						CityId = 682,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "منظريه"
					},
					new City
					{
						CityId = 683,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "مهاباد"
					},
					new City
					{
						CityId = 684,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "ميمه"
					},
					new City
					{
						CityId = 685,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "نائين"
					},
					new City
					{
						CityId = 686,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "نجف آباد"
					},
					new City
					{
						CityId = 687,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "نصرآباد"
					},
					new City
					{
						CityId = 688,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "نطنز"
					},
					new City
					{
						CityId = 689,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "نوش آباد"
					},
					new City
					{
						CityId = 690,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "نياسر"
					},
					new City
					{
						CityId = 691,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "نيک آباد"
					},
					new City
					{
						CityId = 692,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "هرند"
					},
					new City
					{
						CityId = 693,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "ورزنه"
					},
					new City
					{
						CityId = 694,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "ورنامخواست"
					},
					new City
					{
						CityId = 695,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "وزوان"
					},
					new City
					{
						CityId = 696,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "ونک"
					},
					new City
					{
						CityId = 697,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "پير بکران"
					},
					new City
					{
						CityId = 698,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "چادگان"
					},
					new City
					{
						CityId = 699,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "چرمهين"
					},
					new City
					{
						CityId = 700,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "چمگردان"
					},
					new City
					{
						CityId = 701,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کاشان"
					},
					new City
					{
						CityId = 702,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کامو و چوگان"
					},
					new City
					{
						CityId = 703,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کرکوند"
					},
					new City
					{
						CityId = 704,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کليشاد و سودرجان"
					},
					new City
					{
						CityId = 705,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کمشجه"
					},
					new City
					{
						CityId = 706,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کمه"
					},
					new City
					{
						CityId = 707,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کهريزسنگ"
					},
					new City
					{
						CityId = 708,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کوشک"
					},
					new City
					{
						CityId = 709,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "کوهپايه"
					},
					new City
					{
						CityId = 710,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "گرگاب"
					},
					new City
					{
						CityId = 711,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "گز برخوار"
					},
					new City
					{
						CityId = 712,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "گلدشت"
					},
					new City
					{
						CityId = 713,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "گلشن"
					},
					new City
					{
						CityId = 714,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "گلشهر"
					},
					new City
					{
						CityId = 715,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "گلپايگان"
					},
					new City
					{
						CityId = 716,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 19,
						Name = "گوگد"
					},
					new City
					{
						CityId = 717,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "آبدانان"
					},
					new City
					{
						CityId = 718,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "آسمان آباد"
					},
					new City
					{
						CityId = 719,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "ارکواز"
					},
					new City
					{
						CityId = 720,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "ايلام"
					},
					new City
					{
						CityId = 721,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "ايوان"
					},
					new City
					{
						CityId = 722,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "بدره"
					},
					new City
					{
						CityId = 723,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "بلاوه"
					},
					new City
					{
						CityId = 724,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "توحيد"
					},
					new City
					{
						CityId = 725,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "دره شهر"
					},
					new City
					{
						CityId = 726,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "دلگشا"
					},
					new City
					{
						CityId = 727,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "دهلران"
					},
					new City
					{
						CityId = 728,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "زرنه"
					},
					new City
					{
						CityId = 729,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "سراب باغ"
					},
					new City
					{
						CityId = 730,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "سرابله"
					},
					new City
					{
						CityId = 731,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "شباب"
					},
					new City
					{
						CityId = 732,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "صالح آباد"
					},
					new City
					{
						CityId = 733,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "لومار"
					},
					new City
					{
						CityId = 734,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "ماژين"
					},
					new City
					{
						CityId = 735,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "مهر"
					},
					new City
					{
						CityId = 736,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "مهران"
					},
					new City
					{
						CityId = 737,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "مورموري"
					},
					new City
					{
						CityId = 738,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "موسيان"
					},
					new City
					{
						CityId = 739,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "ميمه"
					},
					new City
					{
						CityId = 740,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "پهله"
					},
					new City
					{
						CityId = 741,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 20,
						Name = "چوار"
					},
					new City
					{
						CityId = 742,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "آبسرد"
					},
					new City
					{
						CityId = 743,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "آبعلي"
					},
					new City
					{
						CityId = 744,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "ارجمند"
					},
					new City
					{
						CityId = 745,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "اسلامشهر"
					},
					new City
					{
						CityId = 746,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "انديشه"
					},
					new City
					{
						CityId = 747,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "باغستان"
					},
					new City
					{
						CityId = 748,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "باقرشهر"
					},
					new City
					{
						CityId = 749,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "بومهن"
					},
					new City
					{
						CityId = 750,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "تجريش"
					},
					new City
					{
						CityId = 751,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "تهران"
					},
					new City
					{
						CityId = 752,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "جواد آباد"
					},
					new City
					{
						CityId = 753,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "حسن آباد"
					},
					new City
					{
						CityId = 754,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "دماوند"
					},
					new City
					{
						CityId = 755,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "رباط کريم"
					},
					new City
					{
						CityId = 756,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "رودهن"
					},
					new City
					{
						CityId = 757,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "ري"
					},
					new City
					{
						CityId = 758,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "شاهدشهر"
					},
					new City
					{
						CityId = 759,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "شريف آباد"
					},
					new City
					{
						CityId = 760,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "شمشک"
					},
					new City
					{
						CityId = 761,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "شهر جديد پرند"
					},
					new City
					{
						CityId = 762,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "شهريار"
					},
					new City
					{
						CityId = 763,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "صالحيه"
					},
					new City
					{
						CityId = 764,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "صبا شهر"
					},
					new City
					{
						CityId = 765,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "صفادشت"
					},
					new City
					{
						CityId = 766,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "فردوسيه"
					},
					new City
					{
						CityId = 767,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "فرون آباد"
					},
					new City
					{
						CityId = 768,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "فشم"
					},
					new City
					{
						CityId = 769,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "فيروزکوه"
					},
					new City
					{
						CityId = 770,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "قدس"
					},
					new City
					{
						CityId = 771,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "قرچک"
					},
					new City
					{
						CityId = 772,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "لواسان"
					},
					new City
					{
						CityId = 773,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "ملارد"
					},
					new City
					{
						CityId = 774,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "نسيم شهر"
					},
					new City
					{
						CityId = 775,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "نصيرشهر"
					},
					new City
					{
						CityId = 776,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "وحيديه"
					},
					new City
					{
						CityId = 777,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "ورامين"
					},
					new City
					{
						CityId = 778,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "پاکدشت"
					},
					new City
					{
						CityId = 779,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "پرديس"
					},
					new City
					{
						CityId = 780,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "پيشوا"
					},
					new City
					{
						CityId = 781,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "چهاردانگه"
					},
					new City
					{
						CityId = 782,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "کهريزک"
					},
					new City
					{
						CityId = 783,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "کيلان"
					},
					new City
					{
						CityId = 784,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 21,
						Name = "گلستان"
					},
					new City
					{
						CityId = 785,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "آبش احمد"
					},
					new City
					{
						CityId = 786,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "آذرشهر"
					},
					new City
					{
						CityId = 787,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "آقکند"
					},
					new City
					{
						CityId = 788,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "آچاچي"
					},
					new City
					{
						CityId = 789,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "اسکو"
					},
					new City
					{
						CityId = 790,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "اهر"
					},
					new City
					{
						CityId = 791,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "ايلخچي"
					},
					new City
					{
						CityId = 792,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "باسمنج"
					},
					new City
					{
						CityId = 793,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "بخشايش"
					},
					new City
					{
						CityId = 794,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "بستان آباد"
					},
					new City
					{
						CityId = 795,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "بناب"
					},
					new City
					{
						CityId = 796,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "بناب مرند"
					},
					new City
					{
						CityId = 797,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "تبريز"
					},
					new City
					{
						CityId = 798,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "ترک"
					},
					new City
					{
						CityId = 799,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "ترکمانچاي"
					},
					new City
					{
						CityId = 800,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "تسوج"
					},
					new City
					{
						CityId = 801,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "تيمورلو"
					},
					new City
					{
						CityId = 802,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "تيکمه داش"
					},
					new City
					{
						CityId = 803,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "جلفا"
					},
					new City
					{
						CityId = 804,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "جوان قلعه"
					},
					new City
					{
						CityId = 805,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "خاروانا"
					},
					new City
					{
						CityId = 806,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "خامنه"
					},
					new City
					{
						CityId = 807,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "خداجو"
					},
					new City
					{
						CityId = 808,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "خسروشاه"
					},
					new City
					{
						CityId = 809,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "خمارلو"
					},
					new City
					{
						CityId = 810,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "خواجه"
					},
					new City
					{
						CityId = 811,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "دوزدوزان"
					},
					new City
					{
						CityId = 812,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "زرنق"
					},
					new City
					{
						CityId = 813,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "زنوز"
					},
					new City
					{
						CityId = 814,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "سراب"
					},
					new City
					{
						CityId = 815,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "سردرود"
					},
					new City
					{
						CityId = 816,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "سيس"
					},
					new City
					{
						CityId = 817,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "سيه رود"
					},
					new City
					{
						CityId = 818,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "شبستر"
					},
					new City
					{
						CityId = 819,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "شربيان"
					},
					new City
					{
						CityId = 820,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "شرفخانه"
					},
					new City
					{
						CityId = 821,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "شند آباد"
					},
					new City
					{
						CityId = 822,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "شهر جديد سهند"
					},
					new City
					{
						CityId = 823,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "صوفيان"
					},
					new City
					{
						CityId = 824,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "عجب شير"
					},
					new City
					{
						CityId = 825,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "قره آغاج"
					},
					new City
					{
						CityId = 826,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "ليلان"
					},
					new City
					{
						CityId = 827,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "مبارک شهر"
					},
					new City
					{
						CityId = 828,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "مراغه"
					},
					new City
					{
						CityId = 829,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "مرند"
					},
					new City
					{
						CityId = 830,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "ملکان"
					},
					new City
					{
						CityId = 831,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "ممقان"
					},
					new City
					{
						CityId = 832,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "مهربان"
					},
					new City
					{
						CityId = 833,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "ميانه"
					},
					new City
					{
						CityId = 834,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "نظرکهريزي"
					},
					new City
					{
						CityId = 835,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "هاديشهر"
					},
					new City
					{
						CityId = 836,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "هريس"
					},
					new City
					{
						CityId = 837,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "هشترود"
					},
					new City
					{
						CityId = 838,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "هوراند"
					},
					new City
					{
						CityId = 839,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "وايقان"
					},
					new City
					{
						CityId = 840,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "ورزقان"
					},
					new City
					{
						CityId = 841,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "يامچي"
					},
					new City
					{
						CityId = 842,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "کشکسراي"
					},
					new City
					{
						CityId = 843,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "کلوانق"
					},
					new City
					{
						CityId = 844,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "کليبر"
					},
					new City
					{
						CityId = 845,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "کوزه کنان"
					},
					new City
					{
						CityId = 846,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 22,
						Name = "گوگان"
					},
					new City
					{
						CityId = 847,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "آباده"
					},
					new City
					{
						CityId = 848,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "آباده طشک"
					},
					new City
					{
						CityId = 849,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "اردکان"
					},
					new City
					{
						CityId = 850,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "ارسنجان"
					},
					new City
					{
						CityId = 851,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "استهبان"
					},
					new City
					{
						CityId = 852,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "اسير"
					},
					new City
					{
						CityId = 853,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "اشکنان"
					},
					new City
					{
						CityId = 854,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "افزر"
					},
					new City
					{
						CityId = 855,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "اقليد"
					},
					new City
					{
						CityId = 856,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "امام شهر"
					},
					new City
					{
						CityId = 857,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "اهل"
					},
					new City
					{
						CityId = 858,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "اوز"
					},
					new City
					{
						CityId = 859,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "ايج"
					},
					new City
					{
						CityId = 860,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "ايزد خواست"
					},
					new City
					{
						CityId = 861,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "باب انار"
					},
					new City
					{
						CityId = 862,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "بابامنير"
					},
					new City
					{
						CityId = 863,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "بالاده"
					},
					new City
					{
						CityId = 864,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "بنارويه"
					},
					new City
					{
						CityId = 865,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "بهمن"
					},
					new City
					{
						CityId = 866,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "بوانات"
					},
					new City
					{
						CityId = 867,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "بيرم"
					},
					new City
					{
						CityId = 868,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "بيضا"
					},
					new City
					{
						CityId = 869,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "جنت شهر"
					},
					new City
					{
						CityId = 870,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "جهرم"
					},
					new City
					{
						CityId = 871,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "جويم"
					},
					new City
					{
						CityId = 872,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "حاجي آباد"
					},
					new City
					{
						CityId = 873,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "حسامي"
					},
					new City
					{
						CityId = 874,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "حسن آباد"
					},
					new City
					{
						CityId = 875,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خانه زنيان"
					},
					new City
					{
						CityId = 876,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خانيمن"
					},
					new City
					{
						CityId = 877,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خاوران"
					},
					new City
					{
						CityId = 878,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خرامه"
					},
					new City
					{
						CityId = 879,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خشت"
					},
					new City
					{
						CityId = 880,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خنج"
					},
					new City
					{
						CityId = 881,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خور"
					},
					new City
					{
						CityId = 882,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خوزي"
					},
					new City
					{
						CityId = 883,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "خومه زار"
					},
					new City
					{
						CityId = 884,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "داراب"
					},
					new City
					{
						CityId = 885,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "داريان"
					},
					new City
					{
						CityId = 886,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "دبيران"
					},
					new City
					{
						CityId = 887,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "دهرم"
					},
					new City
					{
						CityId = 888,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "دوبرجي"
					},
					new City
					{
						CityId = 889,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "دوزه"
					},
					new City
					{
						CityId = 890,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "دژکرد"
					},
					new City
					{
						CityId = 891,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "رامجرد"
					},
					new City
					{
						CityId = 892,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "رونيز"
					},
					new City
					{
						CityId = 893,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "زاهد شهر"
					},
					new City
					{
						CityId = 894,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "زرقان"
					},
					new City
					{
						CityId = 895,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "سده"
					},
					new City
					{
						CityId = 896,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "سروستان"
					},
					new City
					{
						CityId = 897,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "سعادت شهر"
					},
					new City
					{
						CityId = 898,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "سلطان شهر"
					},
					new City
					{
						CityId = 899,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "سورمق"
					},
					new City
					{
						CityId = 900,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "سيدان"
					},
					new City
					{
						CityId = 901,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "ششده"
					},
					new City
					{
						CityId = 902,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "شهر جديد صدرا"
					},
					new City
					{
						CityId = 903,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "شهر پير"
					},
					new City
					{
						CityId = 904,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "شيراز"
					},
					new City
					{
						CityId = 905,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "صغاد"
					},
					new City
					{
						CityId = 906,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "صفا شهر"
					},
					new City
					{
						CityId = 907,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "علامرودشت"
					},
					new City
					{
						CityId = 908,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "عماد ده"
					},
					new City
					{
						CityId = 909,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "فدامي"
					},
					new City
					{
						CityId = 910,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "فراشبند"
					},
					new City
					{
						CityId = 911,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "فسا"
					},
					new City
					{
						CityId = 912,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "فيروزآباد"
					},
					new City
					{
						CityId = 913,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "قائميه"
					},
					new City
					{
						CityId = 914,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "قادرآباد"
					},
					new City
					{
						CityId = 915,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "قره بلاغ"
					},
					new City
					{
						CityId = 916,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "قطب آباد"
					},
					new City
					{
						CityId = 917,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "قطرويه"
					},
					new City
					{
						CityId = 918,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "قير"
					},
					new City
					{
						CityId = 919,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "لار"
					},
					new City
					{
						CityId = 920,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "لامرد"
					},
					new City
					{
						CityId = 921,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "لطيفي"
					},
					new City
					{
						CityId = 922,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "لپوئي"
					},
					new City
					{
						CityId = 923,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "مادرسليمان"
					},
					new City
					{
						CityId = 924,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "مبارک آباد"
					},
					new City
					{
						CityId = 925,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "مرودشت"
					},
					new City
					{
						CityId = 926,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "مزايجان"
					},
					new City
					{
						CityId = 927,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "مشکان"
					},
					new City
					{
						CityId = 928,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "مصيري"
					},
					new City
					{
						CityId = 929,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "مهر"
					},
					new City
					{
						CityId = 930,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "ميانشهر"
					},
					new City
					{
						CityId = 931,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "ميمند"
					},
					new City
					{
						CityId = 932,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "نوبندگان"
					},
					new City
					{
						CityId = 933,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "نوجين"
					},
					new City
					{
						CityId = 934,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "نودان"
					},
					new City
					{
						CityId = 935,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "نورآباد"
					},
					new City
					{
						CityId = 936,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "ني ريز"
					},
					new City
					{
						CityId = 937,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "هماشهر"
					},
					new City
					{
						CityId = 938,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "وراوي"
					},
					new City
					{
						CityId = 939,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "کارزين"
					},
					new City
					{
						CityId = 940,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "کازرون"
					},
					new City
					{
						CityId = 941,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "کامفيروز"
					},
					new City
					{
						CityId = 942,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "کره اي"
					},
					new City
					{
						CityId = 943,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "کنار تخته"
					},
					new City
					{
						CityId = 944,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "کوار"
					},
					new City
					{
						CityId = 945,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "کوهنجان"
					},
					new City
					{
						CityId = 946,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "کوپن"
					},
					new City
					{
						CityId = 947,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "گراش"
					},
					new City
					{
						CityId = 948,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 23,
						Name = "گله دار"
					},
					new City
					{
						CityId = 949,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "ازگله"
					},
					new City
					{
						CityId = 950,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "اسلام آباد غرب"
					},
					new City
					{
						CityId = 951,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "بانوره"
					},
					new City
					{
						CityId = 952,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "باينگان"
					},
					new City
					{
						CityId = 953,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "بيستون"
					},
					new City
					{
						CityId = 954,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "تازه آباد"
					},
					new City
					{
						CityId = 955,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "جوانرود"
					},
					new City
					{
						CityId = 956,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "حميل"
					},
					new City
					{
						CityId = 957,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "رباط"
					},
					new City
					{
						CityId = 958,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "روانسر"
					},
					new City
					{
						CityId = 959,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "ريجاب"
					},
					new City
					{
						CityId = 960,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "سر پل ذهاب"
					},
					new City
					{
						CityId = 961,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "سرمست"
					},
					new City
					{
						CityId = 962,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "سطر"
					},
					new City
					{
						CityId = 963,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "سنقر"
					},
					new City
					{
						CityId = 964,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "سومار"
					},
					new City
					{
						CityId = 965,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "شاهو"
					},
					new City
					{
						CityId = 966,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "صحنه"
					},
					new City
					{
						CityId = 967,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "قصر شيرين"
					},
					new City
					{
						CityId = 968,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "ميان راهان"
					},
					new City
					{
						CityId = 969,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "نودشه"
					},
					new City
					{
						CityId = 970,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "نوسود"
					},
					new City
					{
						CityId = 971,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "هرسين"
					},
					new City
					{
						CityId = 972,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "هلشي"
					},
					new City
					{
						CityId = 973,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "پاوه"
					},
					new City
					{
						CityId = 974,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "کرمانشاه"
					},
					new City
					{
						CityId = 975,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "کرند غرب"
					},
					new City
					{
						CityId = 976,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "کنگاور"
					},
					new City
					{
						CityId = 977,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "کوزران"
					},
					new City
					{
						CityId = 978,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "گهواره"
					},
					new City
					{
						CityId = 979,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "گودين"
					},
					new City
					{
						CityId = 980,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 24,
						Name = "گيلانغرب"
					},
					new City
					{
						CityId = 981,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "ابوموسي"
					},
					new City
					{
						CityId = 982,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "بستک"
					},
					new City
					{
						CityId = 983,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "بندر جاسک"
					},
					new City
					{
						CityId = 984,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "بندر عباس"
					},
					new City
					{
						CityId = 985,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "بندر لنگه"
					},
					new City
					{
						CityId = 986,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "بيکاه"
					},
					new City
					{
						CityId = 987,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "تازيان پائين"
					},
					new City
					{
						CityId = 988,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "تخت"
					},
					new City
					{
						CityId = 989,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "تيرور"
					},
					new City
					{
						CityId = 990,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "جناح"
					},
					new City
					{
						CityId = 991,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "حاجي آباد"
					},
					new City
					{
						CityId = 992,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "خمير"
					},
					new City
					{
						CityId = 993,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "درگهان"
					},
					new City
					{
						CityId = 994,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "دشتي"
					},
					new City
					{
						CityId = 995,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "دهبارز"
					},
					new City
					{
						CityId = 996,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "رويدر"
					},
					new City
					{
						CityId = 997,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "زيارتعلي"
					},
					new City
					{
						CityId = 998,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "سردشت"
					},
					new City
					{
						CityId = 999,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "سرگز"
					},
					new City
					{
						CityId = 1000,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "سندرک"
					},
					new City
					{
						CityId = 1001,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "سوزا"
					},
					new City
					{
						CityId = 1002,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "سيريک"
					},
					new City
					{
						CityId = 1003,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "فارغان"
					},
					new City
					{
						CityId = 1004,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "فين"
					},
					new City
					{
						CityId = 1005,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "قشم"
					},
					new City
					{
						CityId = 1006,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "قلعه قاضي"
					},
					new City
					{
						CityId = 1007,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "لمزان"
					},
					new City
					{
						CityId = 1008,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "ميناب"
					},
					new City
					{
						CityId = 1009,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "هرمز"
					},
					new City
					{
						CityId = 1010,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "هشتبندي"
					},
					new City
					{
						CityId = 1011,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "پارسيان"
					},
					new City
					{
						CityId = 1012,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "چارک"
					},
					new City
					{
						CityId = 1013,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "کنگ"
					},
					new City
					{
						CityId = 1014,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "کوخردهرنگ"
					},
					new City
					{
						CityId = 1015,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "کوشکنار"
					},
					new City
					{
						CityId = 1016,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "کوهستک"
					},
					new City
					{
						CityId = 1017,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "کيش"
					},
					new City
					{
						CityId = 1018,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "گروک"
					},
					new City
					{
						CityId = 1019,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 25,
						Name = "گوهران"
					},
					new City
					{
						CityId = 1020,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "آستانه"
					},
					new City
					{
						CityId = 1021,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "آشتيان"
					},
					new City
					{
						CityId = 1022,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "آوه"
					},
					new City
					{
						CityId = 1023,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "اراک"
					},
					new City
					{
						CityId = 1024,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "تفرش"
					},
					new City
					{
						CityId = 1025,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "توره"
					},
					new City
					{
						CityId = 1026,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "جاورسيان"
					},
					new City
					{
						CityId = 1027,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "خشکرود"
					},
					new City
					{
						CityId = 1028,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "خمين"
					},
					new City
					{
						CityId = 1029,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "خنجين"
					},
					new City
					{
						CityId = 1030,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "خنداب"
					},
					new City
					{
						CityId = 1031,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "داود آباد"
					},
					new City
					{
						CityId = 1032,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "دليجان"
					},
					new City
					{
						CityId = 1033,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "رازقان"
					},
					new City
					{
						CityId = 1034,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "زاويه"
					},
					new City
					{
						CityId = 1035,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "ساروق"
					},
					new City
					{
						CityId = 1036,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "ساوه"
					},
					new City
					{
						CityId = 1037,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "شازند"
					},
					new City
					{
						CityId = 1038,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "شهباز"
					},
					new City
					{
						CityId = 1039,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "شهر جديد مهاجران"
					},
					new City
					{
						CityId = 1040,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "غرق آباد"
					},
					new City
					{
						CityId = 1041,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "فرمهين"
					},
					new City
					{
						CityId = 1042,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "قورچي باشي"
					},
					new City
					{
						CityId = 1043,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "مامونيه"
					},
					new City
					{
						CityId = 1044,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "محلات"
					},
					new City
					{
						CityId = 1045,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "ميلاجرد"
					},
					new City
					{
						CityId = 1046,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "نراق"
					},
					new City
					{
						CityId = 1047,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "نوبران"
					},
					new City
					{
						CityId = 1048,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "نيمور"
					},
					new City
					{
						CityId = 1049,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "هندودر"
					},
					new City
					{
						CityId = 1050,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "پرندک"
					},
					new City
					{
						CityId = 1051,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "کارچان"
					},
					new City
					{
						CityId = 1052,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 26,
						Name = "کميجان"
					},
					new City
					{
						CityId = 1053,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "آستارا"
					},
					new City
					{
						CityId = 1054,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "آستانه اشرفيه"
					},
					new City
					{
						CityId = 1055,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "احمد سرگوراب"
					},
					new City
					{
						CityId = 1056,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "اسالم"
					},
					new City
					{
						CityId = 1057,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "اطاقور"
					},
					new City
					{
						CityId = 1058,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "املش"
					},
					new City
					{
						CityId = 1059,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "بازار جمعه"
					},
					new City
					{
						CityId = 1060,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "بره سر"
					},
					new City
					{
						CityId = 1061,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "بندر انزلي"
					},
					new City
					{
						CityId = 1062,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "توتکابن"
					},
					new City
					{
						CityId = 1063,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "جيرنده"
					},
					new City
					{
						CityId = 1064,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "حويق"
					},
					new City
					{
						CityId = 1065,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "خشکبيجار"
					},
					new City
					{
						CityId = 1066,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "خمام"
					},
					new City
					{
						CityId = 1067,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "ديلمان"
					},
					new City
					{
						CityId = 1068,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "رانکوه"
					},
					new City
					{
						CityId = 1069,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "رحيم آباد"
					},
					new City
					{
						CityId = 1070,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "رستم آباد"
					},
					new City
					{
						CityId = 1071,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "رشت"
					},
					new City
					{
						CityId = 1072,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "رضوانشهر"
					},
					new City
					{
						CityId = 1073,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "رودبار"
					},
					new City
					{
						CityId = 1074,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "رودبنه"
					},
					new City
					{
						CityId = 1075,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "رودسر"
					},
					new City
					{
						CityId = 1076,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "سنگر"
					},
					new City
					{
						CityId = 1077,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "سياهکل"
					},
					new City
					{
						CityId = 1078,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "شفت"
					},
					new City
					{
						CityId = 1079,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "شلمان"
					},
					new City
					{
						CityId = 1080,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "صومعه سرا"
					},
					new City
					{
						CityId = 1081,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "فومن"
					},
					new City
					{
						CityId = 1082,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "لاهيجان"
					},
					new City
					{
						CityId = 1083,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "لشت نشاء"
					},
					new City
					{
						CityId = 1084,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "لنگرود"
					},
					new City
					{
						CityId = 1085,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "لوشان"
					},
					new City
					{
						CityId = 1086,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "لولمان"
					},
					new City
					{
						CityId = 1087,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "لوندويل"
					},
					new City
					{
						CityId = 1088,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "ليسار"
					},
					new City
					{
						CityId = 1089,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "ماسال"
					},
					new City
					{
						CityId = 1090,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "ماسوله"
					},
					new City
					{
						CityId = 1091,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "ماکلوان"
					},
					new City
					{
						CityId = 1092,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "مرجقل"
					},
					new City
					{
						CityId = 1093,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "منجيل"
					},
					new City
					{
						CityId = 1094,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "هشتپر"
					},
					new City
					{
						CityId = 1095,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "واجارگاه"
					},
					new City
					{
						CityId = 1096,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "پره سر"
					},
					new City
					{
						CityId = 1097,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "چابکسر"
					},
					new City
					{
						CityId = 1098,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "چاف و چمخاله"
					},
					new City
					{
						CityId = 1099,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "چوبر"
					},
					new City
					{
						CityId = 1100,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "کلاچاي"
					},
					new City
					{
						CityId = 1101,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "کومله"
					},
					new City
					{
						CityId = 1102,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "کوچصفهان"
					},
					new City
					{
						CityId = 1103,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "کياشهر"
					},
					new City
					{
						CityId = 1104,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 27,
						Name = "گوراب زرميخ"
					},
					new City
					{
						CityId = 1105,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "آجين"
					},
					new City
					{
						CityId = 1106,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "ازندريان"
					},
					new City
					{
						CityId = 1107,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "اسد آباد"
					},
					new City
					{
						CityId = 1108,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "برزول"
					},
					new City
					{
						CityId = 1109,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "بهار"
					},
					new City
					{
						CityId = 1110,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "تويسرکان"
					},
					new City
					{
						CityId = 1111,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "جورقان"
					},
					new City
					{
						CityId = 1112,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "جوکار"
					},
					new City
					{
						CityId = 1113,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "دمق"
					},
					new City
					{
						CityId = 1114,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "رزن"
					},
					new City
					{
						CityId = 1115,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "زنگنه"
					},
					new City
					{
						CityId = 1116,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "سامن"
					},
					new City
					{
						CityId = 1117,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "سرکان"
					},
					new City
					{
						CityId = 1118,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "شيرين سو"
					},
					new City
					{
						CityId = 1119,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "صالح آباد"
					},
					new City
					{
						CityId = 1120,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "فامنين"
					},
					new City
					{
						CityId = 1121,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "فرسفج"
					},
					new City
					{
						CityId = 1122,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "فيروزان"
					},
					new City
					{
						CityId = 1123,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "قروه در جزين"
					},
					new City
					{
						CityId = 1124,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "قهاوند"
					},
					new City
					{
						CityId = 1125,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "لالجين"
					},
					new City
					{
						CityId = 1126,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "مريانج"
					},
					new City
					{
						CityId = 1127,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "ملاير"
					},
					new City
					{
						CityId = 1128,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "مهاجران"
					},
					new City
					{
						CityId = 1129,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "نهاوند"
					},
					new City
					{
						CityId = 1130,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "همدان"
					},
					new City
					{
						CityId = 1131,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "کبودر آهنگ"
					},
					new City
					{
						CityId = 1132,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "گل تپه"
					},
					new City
					{
						CityId = 1133,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 28,
						Name = "گيان"
					},
					new City
					{
						CityId = 1134,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "اختيار آباد"
					},
					new City
					{
						CityId = 1135,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "ارزوئيه"
					},
					new City
					{
						CityId = 1136,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "امين شهر"
					},
					new City
					{
						CityId = 1137,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "انار"
					},
					new City
					{
						CityId = 1138,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "اندوهجرد"
					},
					new City
					{
						CityId = 1139,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "باغين"
					},
					new City
					{
						CityId = 1140,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "بافت"
					},
					new City
					{
						CityId = 1141,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "بردسير"
					},
					new City
					{
						CityId = 1142,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "بروات"
					},
					new City
					{
						CityId = 1143,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "بزنجان"
					},
					new City
					{
						CityId = 1144,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "بلورد"
					},
					new City
					{
						CityId = 1145,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "بلوک"
					},
					new City
					{
						CityId = 1146,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "بم"
					},
					new City
					{
						CityId = 1147,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "بهرمان"
					},
					new City
					{
						CityId = 1148,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "جبالبارز"
					},
					new City
					{
						CityId = 1149,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "جوزم"
					},
					new City
					{
						CityId = 1150,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "جوپار"
					},
					new City
					{
						CityId = 1151,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "جيرفت"
					},
					new City
					{
						CityId = 1152,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "خاتون آباد"
					},
					new City
					{
						CityId = 1153,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "خانوک"
					},
					new City
					{
						CityId = 1154,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "خواجوشهر"
					},
					new City
					{
						CityId = 1155,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "خورسند"
					},
					new City
					{
						CityId = 1156,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "درب بهشت"
					},
					new City
					{
						CityId = 1157,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "دشتکار"
					},
					new City
					{
						CityId = 1158,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "دهج"
					},
					new City
					{
						CityId = 1159,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "دوساري"
					},
					new City
					{
						CityId = 1160,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "رابر"
					},
					new City
					{
						CityId = 1161,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "راور"
					},
					new City
					{
						CityId = 1162,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "راين"
					},
					new City
					{
						CityId = 1163,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "رفسنجان"
					},
					new City
					{
						CityId = 1164,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "رودبار"
					},
					new City
					{
						CityId = 1165,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "ريحان"
					},
					new City
					{
						CityId = 1166,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "زرند"
					},
					new City
					{
						CityId = 1167,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "زنگي آباد"
					},
					new City
					{
						CityId = 1168,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "زهکلوت"
					},
					new City
					{
						CityId = 1169,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "زيد آباد"
					},
					new City
					{
						CityId = 1170,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "سيرجان"
					},
					new City
					{
						CityId = 1171,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "شهداد"
					},
					new City
					{
						CityId = 1172,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "شهر بابک"
					},
					new City
					{
						CityId = 1173,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "صفائيه"
					},
					new City
					{
						CityId = 1174,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "عنبر آباد"
					},
					new City
					{
						CityId = 1175,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "فارياب"
					},
					new City
					{
						CityId = 1176,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "فهرج"
					},
					new City
					{
						CityId = 1177,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "قلعه گنج"
					},
					new City
					{
						CityId = 1178,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "لاله زار"
					},
					new City
					{
						CityId = 1179,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "ماهان"
					},
					new City
					{
						CityId = 1180,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "محمد آباد"
					},
					new City
					{
						CityId = 1181,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "محي آباد"
					},
					new City
					{
						CityId = 1182,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "مردهک"
					},
					new City
					{
						CityId = 1183,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "مس سرچشمه"
					},
					new City
					{
						CityId = 1184,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "منوجان"
					},
					new City
					{
						CityId = 1185,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "نجف شهر"
					},
					new City
					{
						CityId = 1186,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "نرماشير"
					},
					new City
					{
						CityId = 1187,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "نظام شهر"
					},
					new City
					{
						CityId = 1188,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "نودژ"
					},
					new City
					{
						CityId = 1189,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "نگار"
					},
					new City
					{
						CityId = 1190,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "هجدک"
					},
					new City
					{
						CityId = 1191,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "هماشهر"
					},
					new City
					{
						CityId = 1192,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "هنزا"
					},
					new City
					{
						CityId = 1193,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "يزدان شهر"
					},
					new City
					{
						CityId = 1194,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "پاريز"
					},
					new City
					{
						CityId = 1195,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "چترود"
					},
					new City
					{
						CityId = 1196,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "کاظم آباد"
					},
					new City
					{
						CityId = 1197,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "کرمان"
					},
					new City
					{
						CityId = 1198,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "کشکوئيه"
					},
					new City
					{
						CityId = 1199,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "کهنوج"
					},
					new City
					{
						CityId = 1200,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "کوهبنان"
					},
					new City
					{
						CityId = 1201,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "کيانشهر"
					},
					new City
					{
						CityId = 1202,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "گلباف"
					},
					new City
					{
						CityId = 1203,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "گلزار"
					},
					new City
					{
						CityId = 1204,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 29,
						Name = "گنبکي"
					},
					new City
					{
						CityId = 1205,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "آرادان"
					},
					new City
					{
						CityId = 1206,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "اميريه"
					},
					new City
					{
						CityId = 1207,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "ايوانکي"
					},
					new City
					{
						CityId = 1208,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "بسطام"
					},
					new City
					{
						CityId = 1209,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "بيارجمند"
					},
					new City
					{
						CityId = 1210,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "دامغان"
					},
					new City
					{
						CityId = 1211,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "درجزين"
					},
					new City
					{
						CityId = 1212,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "ديباج"
					},
					new City
					{
						CityId = 1213,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "روديان"
					},
					new City
					{
						CityId = 1214,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "سرخه"
					},
					new City
					{
						CityId = 1215,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "سمنان"
					},
					new City
					{
						CityId = 1216,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "شاهرود"
					},
					new City
					{
						CityId = 1217,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "شهميرزاد"
					},
					new City
					{
						CityId = 1218,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "مجن"
					},
					new City
					{
						CityId = 1219,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "مهدي شهر"
					},
					new City
					{
						CityId = 1220,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "ميامي"
					},
					new City
					{
						CityId = 1221,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "کلاته"
					},
					new City
					{
						CityId = 1222,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "کلاته خيج"
					},
					new City
					{
						CityId = 1223,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "کهن آباد"
					},
					new City
					{
						CityId = 1224,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 30,
						Name = "گرمسار"
					},
					new City
					{
						CityId = 1225,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "باشت"
					},
					new City
					{
						CityId = 1226,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "دهدشت"
					},
					new City
					{
						CityId = 1227,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "دوگنبدان"
					},
					new City
					{
						CityId = 1228,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "ديشموک"
					},
					new City
					{
						CityId = 1229,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "سرفارياب"
					},
					new City
					{
						CityId = 1230,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "سوق"
					},
					new City
					{
						CityId = 1231,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "سي سخت"
					},
					new City
					{
						CityId = 1232,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "قلعه رئيسي"
					},
					new City
					{
						CityId = 1233,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "لنده"
					},
					new City
					{
						CityId = 1234,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "ليکک"
					},
					new City
					{
						CityId = 1235,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "مادوان"
					},
					new City
					{
						CityId = 1236,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "مارگون"
					},
					new City
					{
						CityId = 1237,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "ياسوج"
					},
					new City
					{
						CityId = 1238,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "پاتاوه"
					},
					new City
					{
						CityId = 1239,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "چرام"
					},
					new City
					{
						CityId = 1240,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "چيتاب"
					},
					new City
					{
						CityId = 1241,
						CityGuid = Guid.NewGuid(),
						ProvinceId = 31,
						Name = "گراب سفلي"
					}
				);

			#endregion

			#region CodeGroup

			modelBuilder.Entity<CodeGroup>().HasData(
					new CodeGroup
					{
						CodeGroupId = 1,
						CodeGroupGuid = Guid.Parse("5b739a57-164e-4b39-8b1c-1129bc9d8991"),
						Name = "FilepondType",
						DisplayName = "نوع فایل"
					},
					new CodeGroup
					{
						CodeGroupId = 2,
						CodeGroupGuid = Guid.Parse("2d9c9e83-39eb-42d7-b71f-ef26002c8470"),
						Name = "BusinessType",
						DisplayName = "نوع کسب و کار"
					},
					new CodeGroup
					{
						CodeGroupId = 3,
						CodeGroupGuid = Guid.Parse("a76da3ba-d12a-42c4-b7e1-732d0990af70"),
						Name = "Gender",
						DisplayName = "جنسیت"
					},
                    new CodeGroup
                    {
                        CodeGroupId = 4,
                        CodeGroupGuid = Guid.Parse("39c56245-8e42-4cef-8ddd-5e4c17782e8b"),
                        Name = "OrderState",
                        DisplayName = "وضعیت سفارش"
                    },
                    new CodeGroup
                    {
                        CodeGroupId = 5,
                        CodeGroupGuid = Guid.Parse("7e9db57a-0c09-47ff-98b5-f49363beff67"),
						Name = "Role",
                        DisplayName = "نقش"
                    },
					new CodeGroup
					{
						CodeGroupId = 6,
						CodeGroupGuid = Guid.Parse("107a7244-6e66-4369-8ba6-dfb0636642c4"),
						Name = "ContactUsBusinessType",
						DisplayName = "نوع کسب و کار بخش ارتباط با ما"
					}
				);

			#endregion

			#region Code

			modelBuilder.Entity<Code>().HasData(
					new Code
					{
						CodeId = 1,
						CodeGuid = Guid.Parse("fc20e91f-1eb1-4912-87be-1708f2706367"),
						CodeGroupId = 1,
						Name = "image/png",
						DisplayName = "png",
						IsDelete = false
					},
					new Code
					{
						CodeId = 2,
						CodeGuid = Guid.Parse("3f009296-db7a-4fde-a659-4ca1541a2504"),
						CodeGroupId = 1,
						Name = "image/jpg",
						DisplayName = "jpg",
						IsDelete = false
					},
					new Code
					{
						CodeId = 3,
						CodeGuid = Guid.Parse("3209341a-07d4-437b-9301-2d0f909ad713"),
						CodeGroupId = 1,
						Name = "image/jpeg",
						DisplayName = "jpeg",
						IsDelete = false
					},
					new Code
					{
						CodeId = 4,
						CodeGuid = Guid.Parse("09cb21ac-d99e-42ba-904d-337bdd561e6e"),
						CodeGroupId = 2,
						Name = "به صورت شخصی فعالیت میکنم",
						DisplayName = "به صورت شخصی فعالیت میکنم",
						IsDelete = false
					},
					new Code
					{
						CodeId = 5,
						CodeGuid = Guid.Parse("2383b70e-f41f-4b67-b0c9-c48706a70a46"),
						CodeGroupId = 2,
						Name = "نماینده یک شرکت هستم",
						DisplayName = "نماینده یک شرکت هستم",
						IsDelete = false
					},
					new Code
					{
						CodeId = 6,
						CodeGuid = Guid.Parse("cf5a1929-db68-43d6-8fc7-e3b7ccc51678"),
						CodeGroupId = 2,
						Name = "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم",
						DisplayName = "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم",
						IsDelete = false
					},
					new Code
					{
						CodeId = 7,
						CodeGuid = Guid.Parse("2b451e4c-c9b8-415a-bcb4-05da15447b89"),
						CodeGroupId = 3,
						Name = "Female",
						DisplayName = "زن",
						IsDelete = false
					},
					new Code
					{
						CodeId = 8,
						CodeGuid = Guid.Parse("6e48b657-2c83-4481-a9c5-009ffe10158b"),
						CodeGroupId = 3,
						Name = "Male",
						DisplayName = "مرد",
						IsDelete = false
					},
                    new Code
                    {
                        CodeId = 9,
                        CodeGuid = Guid.Parse("b5d74bda-849b-427c-a6e0-463c1e5f615b"),
                        CodeGroupId = 4,
                        Name = "Waiting",
                        DisplayName = "در انتظار تایید",
                        IsDelete = false
                    },
                    new Code
                    {
                        CodeId = 10,
                        CodeGuid = Guid.Parse("10afdac9-a075-40e1-9207-1813befcf4d6"),
						CodeGroupId = 4,
                        Name = "Doing",
                        DisplayName = "در حال انجام",
                        IsDelete = false
                    },
                    new Code
                    {
                        CodeId = 11,
                        CodeGuid = Guid.Parse("2b9d07c8-5535-495e-8557-da32acb58600"),
						CodeGroupId = 4,
                        Name = "Done",
                        DisplayName = "انجام شده",
                        IsDelete = false
                    },
                    new Code
                    {
                        CodeId = 12,
                        CodeGuid = Guid.Parse("61960336-e912-4658-9ab3-59f4c58e0b23"),
						CodeGroupId = 4,
                        Name = "Canceled",
                        DisplayName = "لغو شده",
                        IsDelete = false
                    },
                    new Code
                    {
                        CodeId = 13,
                        CodeGuid = Guid.Parse("46a09d81-c57f-4655-a8f5-027c66a6cfb1"),
                        CodeGroupId = 4,
                        Name = "Admin",
                        DisplayName = "ادمین",
                        IsDelete = false
                    },
                    new Code
                    {
                        CodeId = 14,
                        CodeGuid = Guid.Parse("91b3cdab-39c1-40fb-b077-a2d6e611f50a"),
						CodeGroupId = 4,
                        Name = "Client",
                        DisplayName = "سرویس گیرنده",
                        IsDelete = false
                    },
                    new Code
                    {
                        CodeId = 15,
                        CodeGuid = Guid.Parse("959b10a3-b8ed-4a9d-bdf3-17ec9b2ceb15"),
						CodeGroupId = 4,
                        Name = "Contractor",
                        DisplayName = "سرویس دهنده",
                        IsDelete = false
                    },
					new Code
					{
						CodeId = 16,
						CodeGuid = Guid.Parse("a05c4f54-5999-42b9-a36f-6a04aa7cd476"),
						CodeGroupId = 6,
						Name = "Legal",
						DisplayName = "حقوقی",
						IsDelete = false
					},
					new Code
					{
						CodeId = 17,
						CodeGuid = Guid.Parse("ccef9d1f-343b-442a-a041-1908e4cbc235"),
						CodeGroupId = 6,
						Name = "Natural",
						DisplayName = "حقیقی",
						IsDelete = false
					}
				);

			#endregion

			#region SmsProviderConfiguration

			modelBuilder.Entity<SmsProviderConfiguration>().HasData(
					new SmsProviderConfiguration
					{
						SmsProviderConfigurationId = 1,
						SmsProviderConfigurationGuid = Guid.NewGuid(),
						Username = "ptmgroupco@gmail.com",
						Password = "ptcoptco",
						Apikey = "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D",
						ModifiedDate = DateTime.Now,
						IsDelete = false
					}
				);

			#endregion

			#region SmsSetting

			modelBuilder.Entity<SmsSetting>().HasData(
					new SmsSetting
					{
						SmsSettingId = 1,
						SmsSettingGuid = Guid.NewGuid(),
						SmsProviderConfigurationId = 1,
						Name = "Kavenegar",
						ModifiedDate = DateTime.Now,
						IsDelete = false
					}
				);

			#endregion

			#region SmsTemplate

			modelBuilder.Entity<SmsTemplate>().HasData(
					new SmsTemplate
					{
						SmsTemplateId = 1,
						SmsTemplateGuid = Guid.NewGuid(),
						SmsSettingId = 1,
						Name = "VerifyAccount",
						ModifiedDate = DateTime.Now,
						IsDelete = false
					}
				);

			#endregion

			#region Role

			modelBuilder.Entity<Role>().HasData(
					new Role
					{
						RoleId = 1,
						RoleGuid = Guid.NewGuid(),
						Name = "Admin",
						DisplayName = "ادمین",
						ModifiedDate = DateTime.Now,
						IsDelete = false
					},
					new Role
					{
						RoleId = 2,
						RoleGuid = Guid.NewGuid(),
						Name = "Contractor",
						DisplayName = "سرویس دهنده",
						ModifiedDate = DateTime.Now,
						IsDelete = false
					},
                    new Role
                    {
                        RoleId = 3,
                        RoleGuid = Guid.NewGuid(),
                        Name = "Client",
                        DisplayName = "سرویس گیرنده",
                        ModifiedDate = DateTime.Now,
                        IsDelete = false
                    }
				);

			#endregion

			#region User

			modelBuilder.Entity<User>().HasData(
					new User
					{
						UserId = 1,
						UserGuid = Guid.NewGuid(),
						RoleId = 1,
						GenderCodeId = 8,
						ProfileDocumentId = null,
						FirstName = "سید مهدی",
						LastName = "رودکی",
						Email = "mahdiroudaki@hotmail.com",
						PhoneNumber = "09227204305",
						RegisteredDate = DateTime.Now,
						ModifiedDate = DateTime.Now,
						IsActive = true,
						IsRegister = true,
						IsDelete = false
					},
					new User
					{
						UserId = 2,
						UserGuid = Guid.NewGuid(),
						RoleId = 3,
						GenderCodeId = 8,
						ProfileDocumentId = null,
						FirstName = "روزبه",
						LastName = "شامخی",
						Email = "roozbehshamekhi@hotmail.com",
						PhoneNumber = "09128277075",
						RegisteredDate = DateTime.Now,
						ModifiedDate = DateTime.Now,
						IsActive = true,
						IsRegister = true,
						IsDelete = false
					},
					new User
					{
						UserId = 3,
						UserGuid = Guid.NewGuid(),
						RoleId = 2,
						GenderCodeId = 8,
						ProfileDocumentId = null,
						FirstName = "حامد",
						LastName = "حقیقیان",
						Email = "dead.hh98@gmail.com",
						PhoneNumber = "09108347428",
						RegisteredDate = DateTime.Now,
						ModifiedDate = DateTime.Now,
						IsActive = true,
						IsRegister = true,
						IsDelete = false
					},
					new User
					{
						UserId = 4,
						UserGuid = Guid.NewGuid(),
						RoleId = 2,
						GenderCodeId = 8,
						ProfileDocumentId = null,
						FirstName = "محمد",
						LastName = "میرزایی",
						Email = "white.luciferrr@gmail.com",
						PhoneNumber = "09147830093",
						RegisteredDate = DateTime.Now,
						ModifiedDate = DateTime.Now,
						IsActive = true,
						IsRegister = true,
						IsDelete = false
					}
				);

			#endregion

			#region Admin

			modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId = 1,
                    AdminGuid = Guid.NewGuid(),
                    UserId = 1,
                    ModifiedDate = DateTime.Now,
                    IsDelete = false
                }
            );

			#endregion

			#region Client

			modelBuilder.Entity<Client>().HasData(
				new Client
				{
					ClientId = 1,
					ClientGuid = Guid.NewGuid(),
					UserId = 2,
					CityId = 751,
					IsDelete = false,
					ModifiedDate = DateTime.Now
				}
			);

			#endregion

			#region Contractor

			modelBuilder.Entity<Contractor>().HasData(
				new Contractor
				{
					ContractorId = 1,
					ContractorGuid = Guid.NewGuid(),
					UserId = 3,
					BusinessTypeCodeId = 4,
					CityId = 751,
					Latitude = "1",
					Longitude = "2",
					Credit = 0,
					AverageRate = null,
					IsDelete = false,
					ModifiedDate = DateTime.Now
				},
				new Contractor
				{
					ContractorId = 2,
					ContractorGuid = Guid.NewGuid(),
					UserId = 4,
					BusinessTypeCodeId = 4,
					CityId = 751,
					Latitude = "1",
					Longitude = "2",
					Credit = 10000,
					AverageRate = null,
					IsDelete = false,
					ModifiedDate = DateTime.Now
				}
			);

			#endregion

			#region ContractorCategory

			modelBuilder.Entity<ContractorCategory>().HasData(
				new ContractorCategory
				{
					ContractorCategoryId = 1,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 4
				},
				new ContractorCategory
				{
					ContractorCategoryId = 2,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 5
				},
				new ContractorCategory
				{
					ContractorCategoryId = 3,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 14
				},
				new ContractorCategory
				{
					ContractorCategoryId = 4,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 22
				},
				new ContractorCategory
				{
					ContractorCategoryId = 5,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 25
				},
				new ContractorCategory
				{
					ContractorCategoryId = 6,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 30
				},
				new ContractorCategory
				{
					ContractorCategoryId = 7,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 33
				},
				new ContractorCategory
				{
					ContractorCategoryId = 8,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 34
				},
				new ContractorCategory
				{
					ContractorCategoryId = 9,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 27
				},
				new ContractorCategory
				{
					ContractorCategoryId = 10,
					ContractorCategoryGuid = Guid.NewGuid(),
					ContractorId = 1,
					CategoryId = 20
				}
			);

			#endregion

			#region Order

			modelBuilder.Entity<Order>().HasData(
				new Order
				{
					OrderId = 1,
					OrderGuid = Guid.NewGuid(),
					ClientId = 1,
					CategoryId = 14,
					StateCodeId = 9,
					Title = "تیتر",
					Description = "توضیح",
					Comment = null,
					Rate = null,
					Cost = null,
					IsDelete = false,
					ModifiedDate = DateTime.Now
				},
				new Order
				{
					OrderId = 2,
					OrderGuid = Guid.NewGuid(),
					ClientId = 1,
					CategoryId = 22,
					StateCodeId = 9,
					Title = "مشکل",
					Description = "کولر ماشین مشکل داره",
					Comment = null,
					Rate = null,
					Cost = null,
					IsDelete = false,
					ModifiedDate = DateTime.Now
				}
			);

			#endregion

			#region OrderRequest

			modelBuilder.Entity<OrderRequest>().HasData(
				new OrderRequest
				{
					OrderRequestId = 1,
					OrderRequestGuid = Guid.NewGuid(),
					ContractorId = 1,
					OrderId = 1,
					Message = "پیام",
					OfferedPrice = 250000,
					IsAllow = true,
					IsAccept = false,
					IsDelete = false,
					ModifiedDate = DateTime.Now
				}
			);

			#endregion

			#region Category

			modelBuilder.Entity<Category>().HasData(
					new Category
					{
						CategoryId = 1,
						CategoryGuid = Guid.Parse("c265fd02-0194-4d38-83e8-a93bc3698fcc"),
						ParentCategoryId = null,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "سایت اصلی",
						Description = null,
						Sort = 1,
						ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
					},
                    new Category
					{
						CategoryId = 2,
						CategoryGuid = Guid.Parse("dec37f17-0ab2-4208-8ba7-11cc1120369b"),
						ParentCategoryId = null,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "وبلاگ",
						Description = null,
						Sort = 2,
						ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
					},
                    new Category
                    {
                        CategoryId = 3,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 1,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "خانه",
						Description = null,
						Sort = 1,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 4,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 1,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "حمل و نقل",
						Description = null,
						Sort = 2,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
					new Category
                    {
                        CategoryId = 5,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "تاسیسات",
						Description = null,
						Sort = 1,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 6,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "الکتریکی",
						Description = null,
						Sort = 2,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 7,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "ایمنی و امنیت",
						Description = null,
						Sort = 3,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 8,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "مبلمان",
						Description = null,
						Sort = 4,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 9,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "آلومینیوم سازی",
						Description = null,
						Sort = 5,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 10,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "شیشه بری و قابسازی",
						Description = null,
						Sort = 6,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 11,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "کابینت سازی",
						Description = null,
						Sort = 7,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
					},
                    new Category
                    {
                        CategoryId = 12,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "دکوراسیون داخلی",
						Description = null,
						Sort = 8,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 13,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "بنایی",
						Description = null,
						Sort = 9,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 14,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "آهنگری",
						Description = null,
						Sort = 10,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 15,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "عایق کاری",
						Description = null,
						Sort = 11,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 16,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "عایق کاری",
						Description = null,
						Sort = 12,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 17,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "نرده و حفاظ استیل",
						Description = null,
						Sort = 13,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 18,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "تعمیرات لوازم خانگی",
						Description = null,
						Sort = 14,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 19,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "نجاری",
						Description = null,
						Sort = 15,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 20,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "آسانسور و بالابر",
						Description = null,
						Sort = 16,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 21,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 3,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "کار در ارتفاع",
						Description = null,
						Sort = 17,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 22,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 5,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "سرویس کولر آبی",
						Description = null,
						Sort = 1,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 23,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 5,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "نقاشی ساختمان",
						Description = null,
						Sort = 2,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 24,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 8,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "رنگ کاری مبل",
						Description = null,
						Sort = 1,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 25,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 8,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "تعمیر صندلی اداری",
						Description = null,
						Sort = 2,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 26,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 8,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "ساخت مبلمان",
						Description = null,
						Sort = 3,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 27,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 8,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "دوخت کاور مبل",
						Description = null,
						Sort = 4,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 28,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 8,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "تعمیر مبل",
						Description = null,
						Sort = 5,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 29,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 4,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "اتوبار",
						Description = null,
						Sort = 1,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 30,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 4,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "اجاره خودرو",
						Description = null,
						Sort = 2,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 31,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 4,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "سرویس و تعمیر خودرو",
						Description = null,
						Sort = 3,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 32,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 29,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "وانت بار",
						Description = null,
						Sort = 1,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 33,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 29,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "باربری و اتوبار",
						Description = null,
						Sort = 2,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    },
                    new Category
                    {
                        CategoryId = 34,
                        CategoryGuid = Guid.NewGuid(),
                        ParentCategoryId = 29,
						CoverDocumentId = null,
						ActiveIconDocumentId = null,
						InactiveIconDocumentId = null,
						QuadMenuDocumentId = null,
						DisplayName = "کارگر اسباب کشی",
						Description = null,
						Sort = 3,
                        ModifiedDate = DateTime.Now,
						IsActive = true,
						IsDelete = false
                    }
            );

			#endregion
        }
    }
}
