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
                    User_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
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
                    table.PrimaryKey("PK_Tbl_User", x => x.User_Guid);
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
                name: "Tbl_ChatRoom",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    UserGuid = table.Column<Guid>(nullable: false),
                    OwnerConnectionId = table.Column<string>(maxLength: 450, nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ChatRoom", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_ChatRoom_Tbl_User_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Tbl_User",
                        principalColumn: "User_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Comment",
                columns: table => new
                {
                    Comment_Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Comment_UserGuid = table.Column<Guid>(nullable: false),
                    Comment_Text = table.Column<string>(nullable: false),
                    Comment_Date = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Comment", x => x.Comment_Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_Comment_Tbl_User",
                        column: x => x.Comment_UserGuid,
                        principalTable: "Tbl_User",
                        principalColumn: "User_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserPermission",
                columns: table => new
                {
                    UP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UP_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UP_UserGuid = table.Column<Guid>(nullable: false),
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
                        column: x => x.UP_UserGuid,
                        principalTable: "Tbl_User",
                        principalColumn: "User_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserToken",
                columns: table => new
                {
                    UT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UT_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UT_UserGuid = table.Column<Guid>(nullable: false),
                    UT_Token = table.Column<int>(nullable: false),
                    UT_ExpireDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserToken", x => x.UT_ID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserToken_Tbl_User",
                        column: x => x.UT_UserGuid,
                        principalTable: "Tbl_User",
                        principalColumn: "User_Guid",
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
                    Post_UserGuid = table.Column<Guid>(nullable: false),
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
                        column: x => x.Post_UserGuid,
                        principalTable: "Tbl_User",
                        principalColumn: "User_Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ChatMessage",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ChatRoomGuid = table.Column<Guid>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    IsSeen = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsModified = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    SentDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ChatMessage", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Tbl_ChatMessage_Tbl_ChatRoom_ChatRoomGuid",
                        column: x => x.ChatRoomGuid,
                        principalTable: "Tbl_ChatRoom",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SMSResponse",
                columns: table => new
                {
                    SMS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMS_Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMS_UserGuid = table.Column<Guid>(nullable: true),
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
                        column: x => x.SMS_UserGuid,
                        principalTable: "Tbl_User",
                        principalColumn: "User_Guid",
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
                    { new Guid("b10bdca5-406f-406d-ab39-8dc1f9522afd"), null, new DateTime(2020, 4, 19, 9, 56, 34, 380, DateTimeKind.Local).AddTicks(3920), "سایت اصلی", new DateTime(2020, 4, 19, 9, 56, 34, 380, DateTimeKind.Local).AddTicks(4556), 1 },
                    { new Guid("e5609825-5d5c-40dd-bbb4-be22dca70893"), null, new DateTime(2020, 4, 19, 9, 56, 34, 380, DateTimeKind.Local).AddTicks(5894), "وبلاگ", new DateTime(2020, 4, 19, 9, 56, 34, 380, DateTimeKind.Local).AddTicks(5931), 2 }
                });

            migrationBuilder.InsertData(
                table: "Tbl_CodeGroup",
                columns: new[] { "CG_ID", "CG_Display", "CG_Guid", "CG_Name" },
                values: new object[] { 1, "نوع فایل", new Guid("dbd12002-d5e5-41b4-81dd-e67829dea5f0"), "FilepondType" });

            migrationBuilder.InsertData(
                table: "Tbl_Role",
                columns: new[] { "Role_ID", "Role_CreateDate", "Role_Display", "Role_Guid", "Role_ModifyDate", "Role_Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 19, 9, 56, 34, 377, DateTimeKind.Local).AddTicks(1360), "کاربر عادی", new Guid("ccd2d78a-4088-45c0-8892-d189218d7551"), new DateTime(2020, 4, 19, 9, 56, 34, 377, DateTimeKind.Local).AddTicks(2197), "User" },
                    { 2, new DateTime(2020, 4, 19, 9, 56, 34, 377, DateTimeKind.Local).AddTicks(3780), "ادمین", new Guid("b6d59587-4a7c-40a6-af56-7fe6a6e1ac26"), new DateTime(2020, 4, 19, 9, 56, 34, 377, DateTimeKind.Local).AddTicks(3815), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_SMSProviderConfiguration",
                columns: new[] { "SPC_ID", "SPC_ApiKey", "SPC_CreateDate", "SPC_Guid", "SPC_ModifyDate", "SPC_Password", "SPC_Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 4, 19, 9, 56, 34, 369, DateTimeKind.Local).AddTicks(3469), new Guid("fcc16abf-0512-44d5-8894-026d791d4c84"), new DateTime(2020, 4, 19, 9, 56, 34, 372, DateTimeKind.Local).AddTicks(9962), "ptcoptco", "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Tbl_Code",
                columns: new[] { "Code_ID", "Code_CGID", "Code_Display", "Code_Guid", "Code_Name" },
                values: new object[,]
                {
                    { 1, 1, "png", new Guid("b2d5a677-51cb-4e81-8091-a7ecf32db3ce"), "image/png" },
                    { 2, 1, "jpg", new Guid("a9cc62f7-3397-4799-8989-966ed1142476"), "image/jpg" },
                    { 3, 1, "jpeg", new Guid("c6ac4f7f-bde4-46aa-b001-81c39216fa1e"), "image/jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_SMSSetting",
                columns: new[] { "SS_ID", "SS_CreateDate", "SS_Guid", "SS_ModifyDate", "SS_Name", "SS_SPCID" },
                values: new object[] { 1, new DateTime(2020, 4, 19, 9, 56, 34, 375, DateTimeKind.Local).AddTicks(2001), new Guid("aee87d64-5757-4fa9-b5f4-be91ec8fedb0"), new DateTime(2020, 4, 19, 9, 56, 34, 375, DateTimeKind.Local).AddTicks(2863), "Kavenegar", 1 });

            migrationBuilder.InsertData(
                table: "Tbl_User",
                columns: new[] { "User_Guid", "User_CreateDate", "User_Email", "User_Family", "User_IsActive", "User_Mobile", "User_ModifyDate", "User_Name", "User_RoleID" },
                values: new object[,]
                {
                    { new Guid("18871c7e-3569-41db-ba88-c4c23a2fa65c"), new DateTime(2020, 4, 19, 9, 56, 34, 379, DateTimeKind.Local).AddTicks(475), "mahdiroudaki@hotmail.com", "رودکی", true, "09227204305", new DateTime(2020, 4, 19, 9, 56, 34, 379, DateTimeKind.Local).AddTicks(1326), "سید مهدی", 1 },
                    { new Guid("4c8bac07-1f49-42f2-aead-5d72607304e8"), new DateTime(2020, 4, 19, 9, 56, 34, 379, DateTimeKind.Local).AddTicks(3707), "mahdiih@ymail.com", "حکمی زاده", true, "09199390494", new DateTime(2020, 4, 19, 9, 56, 34, 379, DateTimeKind.Local).AddTicks(3747), "مهدی", 1 },
                    { new Guid("a38ccdf5-3c25-4670-b093-be8fee5c3ad9"), new DateTime(2020, 4, 19, 9, 56, 34, 379, DateTimeKind.Local).AddTicks(3856), "arshiasarabi@gmail.com", "اموری سرابی", true, "09120509234", new DateTime(2020, 4, 19, 9, 56, 34, 379, DateTimeKind.Local).AddTicks(3864), "ارشیا", 1 },
                    { new Guid("b876db25-f7ba-4468-9f78-67679c340a3b"), new DateTime(2020, 4, 19, 9, 56, 34, 379, DateTimeKind.Local).AddTicks(3878), "roozbehshamekhi@hotmail.com", "شامخی", true, "09128277075", new DateTime(2020, 4, 19, 9, 56, 34, 379, DateTimeKind.Local).AddTicks(3883), "روزبه", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tbl_SMSTemplate",
                columns: new[] { "ST_ID", "ST_CreateDate", "ST_Guid", "ST_ModifyDate", "ST_Name", "ST_SSID" },
                values: new object[] { 1, new DateTime(2020, 4, 19, 9, 56, 34, 375, DateTimeKind.Local).AddTicks(9876), new Guid("89a6fc7a-b1ac-43ef-b8be-ab65c15b464a"), new DateTime(2020, 4, 19, 9, 56, 34, 376, DateTimeKind.Local).AddTicks(514), "VerifyAccount", 1 });

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
                name: "IX_Tbl_ChatMessage_ChatRoomGuid",
                table: "Tbl_ChatMessage",
                column: "ChatRoomGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ChatRoom_UserGuid",
                table: "Tbl_ChatRoom",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Code_Code_CGID",
                table: "Tbl_Code",
                column: "Code_CGID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Comment_Comment_UserGuid",
                table: "Tbl_Comment",
                column: "Comment_UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Document_Document_TypeCodeID",
                table: "Tbl_Document",
                column: "Document_TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Post_Post_DocumentGuid",
                table: "Tbl_Post",
                column: "Post_DocumentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Post_Post_UserGuid",
                table: "Tbl_Post",
                column: "Post_UserGuid");

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
                name: "IX_Tbl_SMSResponse_SMS_UserGuid",
                table: "Tbl_SMSResponse",
                column: "SMS_UserGuid");

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
                name: "IX_Tbl_UserPermission_UP_UserGuid",
                table: "Tbl_UserPermission",
                column: "UP_UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserToken_UT_UserGuid",
                table: "Tbl_UserToken",
                column: "UT_UserGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Advertisement");

            migrationBuilder.DropTable(
                name: "Tbl_CategoryTag");

            migrationBuilder.DropTable(
                name: "Tbl_ChatMessage");

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
                name: "Tbl_ChatRoom");

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
