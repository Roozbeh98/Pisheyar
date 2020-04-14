using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pisheyar.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    Category_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Category_CategoryGuid = table.Column<Guid>(nullable: true),
                    Category_Display = table.Column<string>(maxLength: 128, nullable: false),
                    Category_Order = table.Column<int>(nullable: false),
                    Category_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Category_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Category_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.Category_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_Category_Tbl_Category",
                        column: x => x.Category_CategoryGuid,
                        principalTable: "Tbl_Category",
                        principalColumn: "Category_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CodeGroup",
                columns: table => new
                {
                    CG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CG_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CG_Name = table.Column<string>(maxLength: 128, nullable: false),
                    CG_Display = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CodeGroup", x => x.CG_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Permission",
                columns: table => new
                {
                    Permission_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permission_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Permission_Name = table.Column<string>(maxLength: 128, nullable: false),
                    Permission_Display = table.Column<string>(maxLength: 128, nullable: false),
                    Permission_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Permission_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Permission_IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Permission_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Permission", x => x.Permission_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Role",
                columns: table => new
                {
                    Role_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Role_Name = table.Column<string>(maxLength: 128, nullable: false),
                    Role_Display = table.Column<string>(maxLength: 128, nullable: false),
                    Role_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Role_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Role_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Role", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SMSProviderConfiguration",
                columns: table => new
                {
                    SPC_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SPC_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: true, defaultValueSql: "(newid())"),
                    SPC_Username = table.Column<string>(maxLength: 128, nullable: false),
                    SPC_Password = table.Column<string>(maxLength: 128, nullable: false),
                    SPC_ApiKey = table.Column<string>(maxLength: 128, nullable: false),
                    SPC_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SPC_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SPC_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SMSProviderConfiguration", x => x.SPC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Tag",
                columns: table => new
                {
                    Tag_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Tag_Name = table.Column<string>(nullable: false),
                    Tag_Usage = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Tag_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Tag_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Tag_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Tag", x => x.Tag_Guid);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Code",
                columns: table => new
                {
                    Code_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Code_CGID = table.Column<int>(nullable: false),
                    Code_Name = table.Column<string>(maxLength: 128, nullable: false),
                    Code_Display = table.Column<string>(maxLength: 128, nullable: false),
                    Code_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Code", x => x.Code_ID);
                    table.ForeignKey(
                        name: "FK_TblCode_TblCodeGroup",
                        column: x => x.Code_CGID,
                        principalTable: "Tbl_CodeGroup",
                        principalColumn: "CG_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RolePermission",
                columns: table => new
                {
                    RP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RP_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    RP_RoleID = table.Column<int>(nullable: false),
                    RP_PermissionID = table.Column<int>(nullable: false),
                    RP_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    RP_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    RP_IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    RP_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RolePermission", x => x.RP_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_RolePermission_Tbl_Permission",
                        column: x => x.RP_PermissionID,
                        principalTable: "Tbl_Permission",
                        principalColumn: "Permission_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_RolePermission_Tbl_Role",
                        column: x => x.RP_RoleID,
                        principalTable: "Tbl_Role",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    User_RoleID = table.Column<int>(nullable: false),
                    User_Name = table.Column<string>(maxLength: 128, nullable: false),
                    User_Family = table.Column<string>(maxLength: 128, nullable: false),
                    User_Email = table.Column<string>(maxLength: 256, nullable: false),
                    User_Mobile = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    User_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    User_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    User_IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    User_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_User_Tbl_Role",
                        column: x => x.User_RoleID,
                        principalTable: "Tbl_Role",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SMSProviderNumber",
                columns: table => new
                {
                    SPN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SPN_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SPN_SPCID = table.Column<int>(nullable: false),
                    SPN_Number = table.Column<string>(maxLength: 128, nullable: false),
                    SPN_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SPN_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SPN_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SMSProviderNumber", x => x.SPN_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_SMSProviderNumber_Tbl_SMSProviderConfiguration",
                        column: x => x.SPN_SPCID,
                        principalTable: "Tbl_SMSProviderConfiguration",
                        principalColumn: "SPC_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SMSSetting",
                columns: table => new
                {
                    SS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SS_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SS_SPCID = table.Column<int>(nullable: false),
                    SS_Name = table.Column<string>(maxLength: 50, nullable: false),
                    SS_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SS_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SS_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SMSSetting", x => x.SS_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_SMSSetting_Tbl_SMSProviderConfiguration",
                        column: x => x.SS_SPCID,
                        principalTable: "Tbl_SMSProviderConfiguration",
                        principalColumn: "SPC_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CategoryTag",
                columns: table => new
                {
                    CT_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    CT_CategoryGuid = table.Column<Guid>(nullable: false),
                    CT_TagGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CategoryTag", x => x.CT_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_CategoryTag_Tbl_Category",
                        column: x => x.CT_CategoryGuid,
                        principalTable: "Tbl_Category",
                        principalColumn: "Category_Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CategoryTag_Tbl_Tag",
                        column: x => x.CT_TagGuid,
                        principalTable: "Tbl_Tag",
                        principalColumn: "Tag_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Document",
                columns: table => new
                {
                    Document_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Document_TypeCodeID = table.Column<int>(nullable: false),
                    Document_Path = table.Column<string>(maxLength: 512, nullable: false),
                    Document_Size = table.Column<string>(maxLength: 128, nullable: false),
                    Document_FileName = table.Column<string>(maxLength: 128, nullable: false),
                    Document_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Document_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Document_IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Document", x => x.Document_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_Document_Tbl_Code",
                        column: x => x.Document_TypeCodeID,
                        principalTable: "Tbl_Code",
                        principalColumn: "Code_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Comment",
                columns: table => new
                {
                    Comment_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Comment_UserID = table.Column<int>(nullable: false),
                    Comment_Text = table.Column<string>(nullable: false),
                    Comment_Date = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Comment", x => x.Comment_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_Comment_Tbl_User",
                        column: x => x.Comment_UserID,
                        principalTable: "Tbl_User",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserPermission",
                columns: table => new
                {
                    UP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UP_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UP_UserID = table.Column<int>(nullable: false),
                    UP_PermissionID = table.Column<int>(nullable: false),
                    UP_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    UP_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    UP_IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    UP_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserPermission", x => x.UP_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserPermission_Tbl_Permission",
                        column: x => x.UP_PermissionID,
                        principalTable: "Tbl_Permission",
                        principalColumn: "Permission_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_UserPermission_Tbl_User",
                        column: x => x.UP_UserID,
                        principalTable: "Tbl_User",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserToken",
                columns: table => new
                {
                    UT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UT_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UT_UserID = table.Column<int>(nullable: false),
                    UT_Token = table.Column<int>(nullable: false),
                    UT_ExpireDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserToken", x => x.UT_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserToken_Tbl_User",
                        column: x => x.UT_UserID,
                        principalTable: "Tbl_User",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SMSTemplate",
                columns: table => new
                {
                    ST_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ST_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ST_SSID = table.Column<int>(nullable: false),
                    ST_Name = table.Column<string>(maxLength: 128, nullable: false),
                    ST_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ST_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ST_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SMSTemplate", x => x.ST_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_SMSTemplate_Tbl_SMSSetting",
                        column: x => x.ST_SSID,
                        principalTable: "Tbl_SMSSetting",
                        principalColumn: "SS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Advertisement",
                columns: table => new
                {
                    Advertisement_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Advertisement_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Advertisement_DocumentGuid = table.Column<Guid>(nullable: false),
                    Advertisement_Title = table.Column<string>(maxLength: 256, nullable: false),
                    Advertisement_Abstract = table.Column<string>(nullable: false),
                    Avertisement_Picture = table.Column<string>(maxLength: 512, nullable: false),
                    Advertisement_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Advertisement_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Advertisement_IsShow = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Advertisement_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Advertisement", x => x.Advertisement_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Advertisement_Tbl_Document",
                        column: x => x.Advertisement_DocumentGuid,
                        principalTable: "Tbl_Document",
                        principalColumn: "Document_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Post",
                columns: table => new
                {
                    Post_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Post_UserID = table.Column<int>(nullable: false),
                    Post_DocumentGuid = table.Column<Guid>(nullable: false),
                    Post_ViewCount = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Post_LikeCount = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Post_Title = table.Column<string>(nullable: false),
                    Post_Abstract = table.Column<string>(nullable: false),
                    Post_Description = table.Column<string>(nullable: false),
                    Post_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Post_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Post_IsShow = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Post_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Post", x => x.Post_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_Post_Tbl_Document",
                        column: x => x.Post_DocumentGuid,
                        principalTable: "Tbl_Document",
                        principalColumn: "Document_Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Post_Tbl_User",
                        column: x => x.Post_UserID,
                        principalTable: "Tbl_User",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SMSResponse",
                columns: table => new
                {
                    SMS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMS_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMS_UserID = table.Column<int>(nullable: true),
                    SMS_STID = table.Column<int>(nullable: true),
                    SMS_Status = table.Column<int>(nullable: false),
                    SMS_StatusText = table.Column<string>(nullable: false),
                    SMS_Message = table.Column<string>(nullable: false),
                    SMS_Token = table.Column<string>(maxLength: 128, nullable: true),
                    SMS_Token1 = table.Column<string>(maxLength: 128, nullable: true),
                    SMS_Token2 = table.Column<string>(maxLength: 128, nullable: true),
                    SMS_Sender = table.Column<string>(maxLength: 128, nullable: false),
                    SMS_Receptor = table.Column<string>(maxLength: 128, nullable: false),
                    SMS_Date = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SMS_Cost = table.Column<int>(nullable: false),
                    SMS_CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SMS_ModifyDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    SMS_IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SMSResponse", x => x.SMS_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_SMSResponse_Tbl_SMSTemplate",
                        column: x => x.SMS_STID,
                        principalTable: "Tbl_SMSTemplate",
                        principalColumn: "ST_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_SMSResponse_Tbl_User",
                        column: x => x.SMS_UserID,
                        principalTable: "Tbl_User",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PostCategory",
                columns: table => new
                {
                    PC_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    PC_CategoryGuid = table.Column<Guid>(nullable: false),
                    PC_PostGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PostCategory", x => x.PC_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_PostCategory_Tbl_Category",
                        column: x => x.PC_CategoryGuid,
                        principalTable: "Tbl_Category",
                        principalColumn: "Category_Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_PostCategory_Tbl_Post",
                        column: x => x.PC_PostGuid,
                        principalTable: "Tbl_Post",
                        principalColumn: "Post_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PostComment",
                columns: table => new
                {
                    PC_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    PcCommentGuid = table.Column<Guid>(nullable: false),
                    PC_PostGuid = table.Column<Guid>(nullable: false),
                    PC_IsAccept = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PostComment", x => x.PC_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_PostComment_Tbl_Comment",
                        column: x => x.PcCommentGuid,
                        principalTable: "Tbl_Comment",
                        principalColumn: "Comment_Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_PostComment_Tbl_Post",
                        column: x => x.PC_PostGuid,
                        principalTable: "Tbl_Post",
                        principalColumn: "Post_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PostTag",
                columns: table => new
                {
                    PT_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    PT_PostGuid = table.Column<Guid>(nullable: false),
                    PT_TagGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PostTag", x => x.PT_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_PostTag_Tbl_Post",
                        column: x => x.PT_PostGuid,
                        principalTable: "Tbl_Post",
                        principalColumn: "Post_Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_PostTag_Tbl_Tag",
                        column: x => x.PT_TagGuid,
                        principalTable: "Tbl_Tag",
                        principalColumn: "Tag_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tbl_Category",
                columns: new[] { "Category_Guid", "Category_CategoryGuid", "Category_CreateDate", "Category_Display", "Category_ModifyDate", "Category_Order" },
                values: new object[,]
                {
                    { new Guid("a4c273c0-84c6-4b2f-be16-947bc08e10c9"), null, new DateTime(2020, 4, 14, 17, 24, 36, 907, DateTimeKind.Local).AddTicks(7391), "سایت اصلی", new DateTime(2020, 4, 14, 17, 24, 36, 907, DateTimeKind.Local).AddTicks(7925), 1 },
                    { new Guid("c194f552-2359-46e9-a837-da016678860a"), null, new DateTime(2020, 4, 14, 17, 24, 36, 907, DateTimeKind.Local).AddTicks(8962), "وبلاگ", new DateTime(2020, 4, 14, 17, 24, 36, 907, DateTimeKind.Local).AddTicks(8986), 2 }
                });

            migrationBuilder.InsertData(
                table: "Tbl_CodeGroup",
                columns: new[] { "CG_ID", "CG_Display", "CG_Guid", "CG_Name" },
                values: new object[] { 1, "نوع فایل", new Guid("67be0e37-731a-4a84-822b-02442d6aeefc"), "FilepondType" });

            migrationBuilder.InsertData(
                table: "Tbl_Role",
                columns: new[] { "Role_ID", "Role_CreateDate", "Role_Display", "Role_Guid", "Role_ModifyDate", "Role_Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 14, 17, 24, 36, 905, DateTimeKind.Local).AddTicks(3675), "کاربر عادی", new Guid("ce01c462-7750-4bf3-adb5-87c4819b19c9"), new DateTime(2020, 4, 14, 17, 24, 36, 905, DateTimeKind.Local).AddTicks(4223), "User" },
                    { 2, new DateTime(2020, 4, 14, 17, 24, 36, 905, DateTimeKind.Local).AddTicks(5640), "ادمین", new Guid("8d1b1a95-fe5a-411d-a948-9dc7edbfe3b1"), new DateTime(2020, 4, 14, 17, 24, 36, 905, DateTimeKind.Local).AddTicks(5663), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_SMSProviderConfiguration",
                columns: new[] { "SPC_ID", "SPC_ApiKey", "SPC_CreateDate", "SPC_Guid", "SPC_ModifyDate", "SPC_Password", "SPC_Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 4, 14, 17, 24, 36, 898, DateTimeKind.Local).AddTicks(3639), new Guid("60bcb94f-0b6d-4620-9c92-dc4f79bcb161"), new DateTime(2020, 4, 14, 17, 24, 36, 901, DateTimeKind.Local).AddTicks(8324), "ptcoptco", "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Tbl_Code",
                columns: new[] { "Code_ID", "Code_CGID", "Code_Display", "Code_Guid", "Code_Name" },
                values: new object[,]
                {
                    { 1, 1, "png", new Guid("3e9c17fe-59a5-418f-9512-dac670833097"), "image/png" },
                    { 2, 1, "jpg", new Guid("3c06b9b8-75ae-4186-82eb-6799970933a8"), "image/jpg" },
                    { 3, 1, "jpeg", new Guid("56e9a431-a11b-4376-8097-17556a913197"), "image/jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_SMSSetting",
                columns: new[] { "SS_ID", "SS_CreateDate", "SS_Guid", "SS_ModifyDate", "SS_Name", "SS_SPCID" },
                values: new object[] { 1, new DateTime(2020, 4, 14, 17, 24, 36, 903, DateTimeKind.Local).AddTicks(8363), new Guid("6fb3f03f-e702-4c2b-9c57-3096380f8452"), new DateTime(2020, 4, 14, 17, 24, 36, 903, DateTimeKind.Local).AddTicks(8915), "Kavenegar", 1 });

            migrationBuilder.InsertData(
                table: "Tbl_User",
                columns: new[] { "User_ID", "User_CreateDate", "User_Email", "User_Family", "User_Guid", "User_IsActive", "User_Mobile", "User_ModifyDate", "User_Name", "User_RoleID" },
                values: new object[] { 1, new DateTime(2020, 4, 14, 17, 24, 36, 906, DateTimeKind.Local).AddTicks(7588), "mahdiroudaki@hotmail.com", "Roudaki", new Guid("52fa718e-a72d-4703-ae55-ffa37718193b"), true, "09227204305", new DateTime(2020, 4, 14, 17, 24, 36, 906, DateTimeKind.Local).AddTicks(8135), "Mahdi", 1 });

            migrationBuilder.InsertData(
                table: "Tbl_SMSTemplate",
                columns: new[] { "ST_ID", "ST_CreateDate", "ST_Guid", "ST_ModifyDate", "ST_Name", "ST_SSID" },
                values: new object[] { 1, new DateTime(2020, 4, 14, 17, 24, 36, 904, DateTimeKind.Local).AddTicks(5658), new Guid("fcf59273-c434-4488-9006-fdf68fb1c1f9"), new DateTime(2020, 4, 14, 17, 24, 36, 904, DateTimeKind.Local).AddTicks(6193), "VerifyAccount", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Advertisement_Advertisement_DocumentGuid",
                table: "Tbl_Advertisement",
                column: "Advertisement_DocumentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Category_Category_CategoryGuid",
                table: "Tbl_Category",
                column: "Category_CategoryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CategoryTag_CT_CategoryGuid",
                table: "Tbl_CategoryTag",
                column: "CT_CategoryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CategoryTag_CT_TagGuid",
                table: "Tbl_CategoryTag",
                column: "CT_TagGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Code_Code_CGID",
                table: "Tbl_Code",
                column: "Code_CGID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Comment_Comment_UserID",
                table: "Tbl_Comment",
                column: "Comment_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Document_Document_TypeCodeID",
                table: "Tbl_Document",
                column: "Document_TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Post_Post_DocumentGuid",
                table: "Tbl_Post",
                column: "Post_DocumentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Post_Post_UserID",
                table: "Tbl_Post",
                column: "Post_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostCategory_PC_CategoryGuid",
                table: "Tbl_PostCategory",
                column: "PC_CategoryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostCategory_PC_PostGuid",
                table: "Tbl_PostCategory",
                column: "PC_PostGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostComment_PcCommentGuid",
                table: "Tbl_PostComment",
                column: "PcCommentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostComment_PC_PostGuid",
                table: "Tbl_PostComment",
                column: "PC_PostGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostTag_PT_PostGuid",
                table: "Tbl_PostTag",
                column: "PT_PostGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostTag_PT_TagGuid",
                table: "Tbl_PostTag",
                column: "PT_TagGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RolePermission_RP_PermissionID",
                table: "Tbl_RolePermission",
                column: "RP_PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RolePermission_RP_RoleID",
                table: "Tbl_RolePermission",
                column: "RP_RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSProviderNumber_SPN_SPCID",
                table: "Tbl_SMSProviderNumber",
                column: "SPN_SPCID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSResponse_SMS_STID",
                table: "Tbl_SMSResponse",
                column: "SMS_STID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSResponse_SMS_UserID",
                table: "Tbl_SMSResponse",
                column: "SMS_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSSetting_SS_SPCID",
                table: "Tbl_SMSSetting",
                column: "SS_SPCID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSTemplate_ST_SSID",
                table: "Tbl_SMSTemplate",
                column: "ST_SSID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_User_User_RoleID",
                table: "Tbl_User",
                column: "User_RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserPermission_UP_PermissionID",
                table: "Tbl_UserPermission",
                column: "UP_PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserPermission_UP_UserID",
                table: "Tbl_UserPermission",
                column: "UP_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserToken_UT_UserID",
                table: "Tbl_UserToken",
                column: "UT_UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Advertisement");

            migrationBuilder.DropTable(
                name: "Tbl_CategoryTag");

            migrationBuilder.DropTable(
                name: "Tbl_PostCategory");

            migrationBuilder.DropTable(
                name: "Tbl_PostComment");

            migrationBuilder.DropTable(
                name: "Tbl_PostTag");

            migrationBuilder.DropTable(
                name: "Tbl_RolePermission");

            migrationBuilder.DropTable(
                name: "Tbl_SMSProviderNumber");

            migrationBuilder.DropTable(
                name: "Tbl_SMSResponse");

            migrationBuilder.DropTable(
                name: "Tbl_UserPermission");

            migrationBuilder.DropTable(
                name: "Tbl_UserToken");

            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropTable(
                name: "Tbl_Comment");

            migrationBuilder.DropTable(
                name: "Tbl_Post");

            migrationBuilder.DropTable(
                name: "Tbl_Tag");

            migrationBuilder.DropTable(
                name: "Tbl_SMSTemplate");

            migrationBuilder.DropTable(
                name: "Tbl_Permission");

            migrationBuilder.DropTable(
                name: "Tbl_Document");

            migrationBuilder.DropTable(
                name: "Tbl_User");

            migrationBuilder.DropTable(
                name: "Tbl_SMSSetting");

            migrationBuilder.DropTable(
                name: "Tbl_Code");

            migrationBuilder.DropTable(
                name: "Tbl_Role");

            migrationBuilder.DropTable(
                name: "Tbl_SMSProviderConfiguration");

            migrationBuilder.DropTable(
                name: "Tbl_CodeGroup");
        }
    }
}
