using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pisheyar.Infrastructure.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tbl_Category",
                columns: new[] { "Category_ID", "Category_CategoryID", "Category_CreateDate", "Category_Display", "Category_Guid", "Category_ModifyDate", "Category_Order" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(4405), "سایت اصلی", new Guid("baea0600-9ba1-4193-87ea-18205f7edeb6"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(5232), 1 },
                    { 2, null, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6285), "وبلاگ", new Guid("50ab149f-86ab-44bd-b46d-340fedc25cbf"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6308), 2 }
                });

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Role_ID",
                keyValue: 1,
                columns: new[] { "Role_CreateDate", "Role_Guid", "Role_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 518, DateTimeKind.Local).AddTicks(4134), new Guid("b008de40-9ec6-47a6-94bd-42dcc095bbde"), new DateTime(2020, 3, 11, 17, 48, 13, 518, DateTimeKind.Local).AddTicks(4683) });

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Role_ID",
                keyValue: 2,
                columns: new[] { "Role_CreateDate", "Role_Guid", "Role_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 518, DateTimeKind.Local).AddTicks(5782), new Guid("9ae5f170-ef4d-4da7-9b0b-6bbc2cbb09b7"), new DateTime(2020, 3, 11, 17, 48, 13, 518, DateTimeKind.Local).AddTicks(5805) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSProviderConfiguration",
                keyColumn: "SPC_ID",
                keyValue: 1,
                columns: new[] { "SPC_CreateDate", "SPC_Guid", "SPC_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 509, DateTimeKind.Local).AddTicks(3994), new Guid("5ba9093f-988a-4faa-9386-b5164a2a957d"), new DateTime(2020, 3, 11, 17, 48, 13, 514, DateTimeKind.Local).AddTicks(9906) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSSetting",
                keyColumn: "SS_ID",
                keyValue: 1,
                columns: new[] { "SS_CreateDate", "SS_Guid", "SS_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 517, DateTimeKind.Local).AddTicks(872), new Guid("c7594145-56b9-4a75-a5eb-8561c8ecf2d2"), new DateTime(2020, 3, 11, 17, 48, 13, 517, DateTimeKind.Local).AddTicks(1444) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSTemplate",
                keyColumn: "ST_ID",
                keyValue: 1,
                columns: new[] { "ST_CreateDate", "ST_Guid", "ST_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 517, DateTimeKind.Local).AddTicks(7152), new Guid("6883fdb6-5cd7-414a-b6d3-4e449318aa5b"), new DateTime(2020, 3, 11, 17, 48, 13, 517, DateTimeKind.Local).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "Tbl_User",
                keyColumn: "User_ID",
                keyValue: 1,
                columns: new[] { "User_CreateDate", "User_Guid", "User_IsActive", "User_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 519, DateTimeKind.Local).AddTicks(5392), new Guid("77daee11-ef27-4a8e-8692-236f682a9959"), true, new DateTime(2020, 3, 11, 17, 48, 13, 519, DateTimeKind.Local).AddTicks(5945) });

            migrationBuilder.InsertData(
                table: "Tbl_Category",
                columns: new[] { "Category_ID", "Category_CategoryID", "Category_CreateDate", "Category_Display", "Category_Guid", "Category_ModifyDate", "Category_Order" },
                values: new object[,]
                {
                    { 9, 1, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6394), "1", new Guid("01824353-abc0-4453-b756-0ba30b383748"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6397), 1 },
                    { 10, 1, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6402), "2", new Guid("9ff99ed1-d3a4-4f32-8875-378a34158cdc"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6405), 2 },
                    { 3, 2, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6332), "1", new Guid("249bb330-cbb8-431c-8587-30e3445fc1b8"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6335), 1 },
                    { 4, 2, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6349), "2", new Guid("e3e94921-1e55-48c9-900a-3aa46e28c3e2"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6352), 2 }
                });

            migrationBuilder.InsertData(
                table: "Tbl_Category",
                columns: new[] { "Category_ID", "Category_CategoryID", "Category_CreateDate", "Category_Display", "Category_Guid", "Category_ModifyDate", "Category_Order" },
                values: new object[,]
                {
                    { 11, 10, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6411), "1", new Guid("b5be86a0-125b-4303-aa92-67c561463faa"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6414), 1 },
                    { 5, 3, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6358), "3", new Guid("b47cd380-0102-41b6-8719-1fd405bc975d"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6362), 3 },
                    { 6, 4, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6367), "1", new Guid("13afdb19-1216-479c-8a98-518dea901cff"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6370), 1 },
                    { 7, 4, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6376), "2", new Guid("8cd7a188-b67f-4f62-8227-1dc7d3475453"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6379), 2 }
                });

            migrationBuilder.InsertData(
                table: "Tbl_Category",
                columns: new[] { "Category_ID", "Category_CategoryID", "Category_CreateDate", "Category_Display", "Category_Guid", "Category_ModifyDate", "Category_Order" },
                values: new object[] { 8, 6, new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6385), "1", new Guid("05110a87-cbea-4c9c-97d1-ac0dfba6e369"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6388), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Role_ID",
                keyValue: 1,
                columns: new[] { "Role_CreateDate", "Role_Guid", "Role_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 13, 34, 11, 369, DateTimeKind.Local).AddTicks(6052), new Guid("73056503-d578-40d7-a957-95e7ed8c84ca"), new DateTime(2020, 3, 11, 13, 34, 11, 369, DateTimeKind.Local).AddTicks(6603) });

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Role_ID",
                keyValue: 2,
                columns: new[] { "Role_CreateDate", "Role_Guid", "Role_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 13, 34, 11, 369, DateTimeKind.Local).AddTicks(7660), new Guid("d158a7ba-3f5b-4ad8-9d0f-6aedab56c5aa"), new DateTime(2020, 3, 11, 13, 34, 11, 369, DateTimeKind.Local).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSProviderConfiguration",
                keyColumn: "SPC_ID",
                keyValue: 1,
                columns: new[] { "SPC_CreateDate", "SPC_Guid", "SPC_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 13, 34, 11, 361, DateTimeKind.Local).AddTicks(4579), new Guid("8b18f666-a796-43a6-9a96-7ba3dff18784"), new DateTime(2020, 3, 11, 13, 34, 11, 365, DateTimeKind.Local).AddTicks(8610) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSSetting",
                keyColumn: "SS_ID",
                keyValue: 1,
                columns: new[] { "SS_CreateDate", "SS_Guid", "SS_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 13, 34, 11, 368, DateTimeKind.Local).AddTicks(2187), new Guid("9bb87a38-34e9-490b-8ab9-63950bc504b7"), new DateTime(2020, 3, 11, 13, 34, 11, 368, DateTimeKind.Local).AddTicks(3204) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSTemplate",
                keyColumn: "ST_ID",
                keyValue: 1,
                columns: new[] { "ST_CreateDate", "ST_Guid", "ST_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 13, 34, 11, 368, DateTimeKind.Local).AddTicks(9039), new Guid("aca218b6-e8bd-4eb8-8ff4-9747383e9ec6"), new DateTime(2020, 3, 11, 13, 34, 11, 368, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Tbl_User",
                keyColumn: "User_ID",
                keyValue: 1,
                columns: new[] { "User_CreateDate", "User_Guid", "User_IsActive", "User_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 13, 34, 11, 370, DateTimeKind.Local).AddTicks(8560), new Guid("fd48250d-50e7-4ffa-a644-82e43980a781"), true, new DateTime(2020, 3, 11, 13, 34, 11, 370, DateTimeKind.Local).AddTicks(9296) });
        }
    }
}
