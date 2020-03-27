using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pisheyar.Infrastructure.Migrations
{
    public partial class Addusagecolumntotagtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tag_Usage",
                table: "Tbl_Tag",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 1,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(3737), new Guid("28eb4c4a-6411-4317-a946-d787c19d8838"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 2,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5391), new Guid("124afdf0-6ba6-4f5f-a3eb-704f8f8e42fe"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5412) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 3,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5442), new Guid("3ec0d0f1-b5e9-45c9-8126-10b8f8a33f37"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5446) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 4,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5453), new Guid("e776b81c-d58f-41f4-88b8-67e769149030"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5456) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 5,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5463), new Guid("b569c0ec-0fef-4521-b838-5a88c9a78c5b"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5466) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 6,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5472), new Guid("0d9add27-67d1-4820-b677-1319fc4a99a9"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5475) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 7,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5481), new Guid("e4f81f08-f864-4968-9de3-552c83eec347"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 8,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5491), new Guid("2861178b-8edc-4496-8b63-d2edab2be0af"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 9,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5500), new Guid("04e9070f-21be-44e6-9e9e-15745f1c6038"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5503) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 10,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5513), new Guid("fbdfd52e-aa55-4049-9564-309b75cfb04c"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 11,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5523), new Guid("0deae108-cd73-44ba-90d9-79330e338e2a"), new DateTime(2020, 3, 24, 13, 58, 7, 681, DateTimeKind.Local).AddTicks(5526) });

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Role_ID",
                keyValue: 1,
                columns: new[] { "Role_CreateDate", "Role_Guid", "Role_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 679, DateTimeKind.Local).AddTicks(2197), new Guid("2406f99f-d219-47fa-adcf-1242884b9565"), new DateTime(2020, 3, 24, 13, 58, 7, 679, DateTimeKind.Local).AddTicks(2742) });

            migrationBuilder.UpdateData(
                table: "Tbl_Role",
                keyColumn: "Role_ID",
                keyValue: 2,
                columns: new[] { "Role_CreateDate", "Role_Guid", "Role_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 679, DateTimeKind.Local).AddTicks(3858), new Guid("d6f10f17-9ac8-4d3a-8766-1b2412cab10a"), new DateTime(2020, 3, 24, 13, 58, 7, 679, DateTimeKind.Local).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSProviderConfiguration",
                keyColumn: "SPC_ID",
                keyValue: 1,
                columns: new[] { "SPC_CreateDate", "SPC_Guid", "SPC_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 672, DateTimeKind.Local).AddTicks(6249), new Guid("54a98ce0-932a-44de-98e4-a873f43bcf23"), new DateTime(2020, 3, 24, 13, 58, 7, 675, DateTimeKind.Local).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSSetting",
                keyColumn: "SS_ID",
                keyValue: 1,
                columns: new[] { "SS_CreateDate", "SS_Guid", "SS_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 677, DateTimeKind.Local).AddTicks(9246), new Guid("d6cc466f-fffb-4a5d-ae00-709135a7c832"), new DateTime(2020, 3, 24, 13, 58, 7, 677, DateTimeKind.Local).AddTicks(9953) });

            migrationBuilder.UpdateData(
                table: "Tbl_SMSTemplate",
                keyColumn: "ST_ID",
                keyValue: 1,
                columns: new[] { "ST_CreateDate", "ST_Guid", "ST_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 678, DateTimeKind.Local).AddTicks(5277), new Guid("806c268a-ea8d-43a1-94b0-c4ab0b0b2f71"), new DateTime(2020, 3, 24, 13, 58, 7, 678, DateTimeKind.Local).AddTicks(5824) });

            migrationBuilder.UpdateData(
                table: "Tbl_User",
                keyColumn: "User_ID",
                keyValue: 1,
                columns: new[] { "User_CreateDate", "User_Guid", "User_IsActive", "User_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 24, 13, 58, 7, 680, DateTimeKind.Local).AddTicks(4561), new Guid("ce0a1900-e839-408f-a93f-fd8fd2d3b669"), true, new DateTime(2020, 3, 24, 13, 58, 7, 680, DateTimeKind.Local).AddTicks(5108) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag_Usage",
                table: "Tbl_Tag");

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 1,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(4405), new Guid("baea0600-9ba1-4193-87ea-18205f7edeb6"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(5232) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 2,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6285), new Guid("50ab149f-86ab-44bd-b46d-340fedc25cbf"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6308) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 3,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6332), new Guid("249bb330-cbb8-431c-8587-30e3445fc1b8"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6335) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 4,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6349), new Guid("e3e94921-1e55-48c9-900a-3aa46e28c3e2"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 5,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6358), new Guid("b47cd380-0102-41b6-8719-1fd405bc975d"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6362) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 6,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6367), new Guid("13afdb19-1216-479c-8a98-518dea901cff"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 7,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6376), new Guid("8cd7a188-b67f-4f62-8227-1dc7d3475453"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6379) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 8,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6385), new Guid("05110a87-cbea-4c9c-97d1-ac0dfba6e369"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6388) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 9,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6394), new Guid("01824353-abc0-4453-b756-0ba30b383748"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6397) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 10,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6402), new Guid("9ff99ed1-d3a4-4f32-8875-378a34158cdc"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6405) });

            migrationBuilder.UpdateData(
                table: "Tbl_Category",
                keyColumn: "Category_ID",
                keyValue: 11,
                columns: new[] { "Category_CreateDate", "Category_Guid", "Category_ModifyDate" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6411), new Guid("b5be86a0-125b-4303-aa92-67c561463faa"), new DateTime(2020, 3, 11, 17, 48, 13, 520, DateTimeKind.Local).AddTicks(6414) });

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
        }
    }
}
