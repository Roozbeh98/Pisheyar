using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pisheyar.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ParentCategoryID = table.Column<int>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.ParentCategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CodeGroup",
                columns: table => new
                {
                    CodeGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGroupGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeGroup", x => x.CodeGroupID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                columns: table => new
                {
                    PermissionGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionGroupGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.PermissionGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SMSProviderConfiguration",
                columns: table => new
                {
                    SMSProviderConfigurationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSProviderConfigurationGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Username = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    APIKey = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSProviderConfiguration", x => x.SMSProviderConfigurationID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Usage = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    CodeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CodeGroupID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.CodeID);
                    table.ForeignKey(
                        name: "FK_Code_CodeGroup",
                        column: x => x.CodeGroupID,
                        principalTable: "CodeGroup",
                        principalColumn: "CodeGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PermissionGroupID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionID);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionGroup",
                        column: x => x.PermissionGroupID,
                        principalTable: "PermissionGroup",
                        principalColumn: "PermissionGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ProvinceID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Province",
                        column: x => x.ProvinceID,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    RoleID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsRegister = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    RegisteredDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSProviderNumber",
                columns: table => new
                {
                    SMSProviderNumberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSProviderNumberGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMSProviderConfigurationID = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSProviderNumber", x => x.SMSProviderNumberID);
                    table.ForeignKey(
                        name: "FK_SMSProviderNumber_SMSProviderConfiguration",
                        column: x => x.SMSProviderConfigurationID,
                        principalTable: "SMSProviderConfiguration",
                        principalColumn: "SMSProviderConfigurationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSSetting",
                columns: table => new
                {
                    SMSSettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSSettingGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMSProviderConfigurationID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSSetting", x => x.SMSSettingID);
                    table.ForeignKey(
                        name: "FK_SMSSetting_SMSProviderConfiguration",
                        column: x => x.SMSProviderConfigurationID,
                        principalTable: "SMSProviderConfiguration",
                        principalColumn: "SMSProviderConfigurationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTag",
                columns: table => new
                {
                    CategoryTagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTagGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CategoryID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTag", x => x.CategoryTagID);
                    table.ForeignKey(
                        name: "FK_CategoryTag_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTag_Tag",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    TypeCodeID = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Size = table.Column<long>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Document_Code",
                        column: x => x.TypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    TypeCodeID = table.Column<int>(nullable: false),
                    Cost = table.Column<long>(nullable: false),
                    Serial = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Code",
                        column: x => x.TypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RolePermissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePermissionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PermissionID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.RolePermissionID);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admin_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ContractorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    Credit = table.Column<long>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ContractorID);
                    table.ForeignKey(
                        name: "FK_Contractor_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    TokenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_Token_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    UserPermissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPermissionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PermissionID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.UserPermissionID);
                    table.ForeignKey(
                        name: "FK_UserPermission_Permission",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermission_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSTemplate",
                columns: table => new
                {
                    SMSTemplateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSTemplateGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMSSettingID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSTemplate", x => x.SMSTemplateID);
                    table.ForeignKey(
                        name: "FK_SMSTemplate_SMSSetting",
                        column: x => x.SMSSettingID,
                        principalTable: "SMSSetting",
                        principalColumn: "SMSSettingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    AdvertisementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    DocumentID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.AdvertisementID);
                    table.ForeignKey(
                        name: "FK_Advertisement_Document",
                        column: x => x.DocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    DocumentID = table.Column<int>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Abstract = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Post_Document",
                        column: x => x.DocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ClientID = table.Column<int>(nullable: false),
                    ContractorID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    StateCodeID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    DeadlineDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Code",
                        column: x => x.StateCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSResponse",
                columns: table => new
                {
                    SMSResponseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSResponseGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMSTemplateID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusText = table.Column<string>(nullable: false),
                    Sender = table.Column<string>(maxLength: 128, nullable: false),
                    Receptor = table.Column<string>(maxLength: 128, nullable: false),
                    Token = table.Column<string>(maxLength: 128, nullable: true),
                    Token1 = table.Column<string>(maxLength: 128, nullable: true),
                    Token2 = table.Column<string>(maxLength: 128, nullable: true),
                    Message = table.Column<string>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    SentDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSResponse", x => x.SMSResponseID);
                    table.ForeignKey(
                        name: "FK_SMSResponse_SMSTemplate",
                        column: x => x.SMSTemplateID,
                        principalTable: "SMSTemplate",
                        principalColumn: "SMSTemplateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMSResponse_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    PostCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCategoryGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CategoryID = table.Column<int>(nullable: false),
                    PostID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => x.PostCategoryID);
                    table.ForeignKey(
                        name: "FK_PostCategory_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategory_Post",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    PostCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCommentGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CommentID = table.Column<int>(nullable: false),
                    PostID = table.Column<int>(nullable: false),
                    IsAccept = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.PostCommentID);
                    table.ForeignKey(
                        name: "FK_PostComment_Comment",
                        column: x => x.CommentID,
                        principalTable: "Comment",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComment_Post",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostTagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTagGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PostID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => x.PostTagID);
                    table.ForeignKey(
                        name: "FK_PostTag_Post",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostTag_Tag",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    ChatRoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatRoomGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false),
                    OwnerConnectionID = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.ChatRoomID);
                    table.ForeignKey(
                        name: "FK_ChatRoom_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatRoom_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatRoom_Order",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderRequest",
                columns: table => new
                {
                    OrderRequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRequestGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    IsAccept = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequest", x => x.OrderRequestID);
                    table.ForeignKey(
                        name: "FK_OrderRequest_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderRequest_Order",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    ChatMessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatMessageGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ChatRoomID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    IsSeen = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsModified = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    SentDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.ChatMessageID);
                    table.ForeignKey(
                        name: "FK_ChatMessage_ChatRoom",
                        column: x => x.ChatRoomID,
                        principalTable: "ChatRoom",
                        principalColumn: "ChatRoomID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 1, new Guid("4719439b-7920-45c4-baba-fcb68a230da1"), "سایت اصلی", new DateTime(2020, 4, 30, 18, 30, 27, 457, DateTimeKind.Local).AddTicks(3347), null, 1 },
                    { 2, new Guid("00581c7e-93da-4415-9417-5320fe7239a2"), "وبلاگ", new DateTime(2020, 4, 30, 18, 30, 27, 457, DateTimeKind.Local).AddTicks(4952), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "CodeGroupID", "CodeGroupGUID", "DisplayName", "Name" },
                values: new object[] { 1, new Guid("df61f8ba-0d8f-4288-8985-6ff836990351"), "نوع فایل", "FilepondType" });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("98112d7a-5202-4cc4-937a-ef0027ed7e9a") },
                    { 20, "ايلام", new Guid("694f31fb-8860-4410-b85d-fcb987bb2a75") },
                    { 21, "تهران", new Guid("d74cddb4-0fd8-4781-9fc9-8f45da77c061") },
                    { 22, "آذربايجان شرقي", new Guid("16246b26-68d0-42a2-ac11-ceb01cb6db5a") },
                    { 23, "فارس", new Guid("cebc5093-d40e-4234-963d-1a4cfa626a7f") },
                    { 24, "کرمانشاه", new Guid("efbfe75f-816a-4702-8ff8-5e677c7a3c5c") },
                    { 26, "مرکزي", new Guid("6423758e-29bb-4c12-9fb8-3eaa5294ea82") },
                    { 18, "اردبيل", new Guid("9e7b041b-96e2-4c9e-a71e-7eb15843ebe3") },
                    { 27, "گيلان", new Guid("5c4a3567-1631-46b3-a2bd-7d610badc7dc") },
                    { 28, "همدان", new Guid("a52ebcbe-b26d-4c6e-82f3-9ce20bb3cb56") },
                    { 29, "کرمان", new Guid("883f5cca-cf9b-4fe1-af4a-b7aacf04d1ac") },
                    { 30, "سمنان", new Guid("65beff9b-eb21-4d78-9dba-b8dd5d60a89d") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("b6a6ddb3-4a83-423c-bf82-0822774766b7") },
                    { 25, "هرمزگان", new Guid("40b3626c-f48c-4b1c-a95c-2cba368e344a") },
                    { 17, "لرستان", new Guid("d48737bc-d1df-4ba6-9c8e-4007ad323f53") },
                    { 16, "قزوين", new Guid("566a289e-eb92-4a66-a9e3-d64453ae5fec") },
                    { 15, "مازندران", new Guid("ec30f62b-d907-493f-b17a-4c80968ab570") },
                    { 1, "يزد", new Guid("7005655b-e367-467e-bca1-5bd0d3f04127") },
                    { 2, "چهار محال و بختياري", new Guid("a1f2a473-13a3-4c76-acef-b8509718defb") },
                    { 3, "خراسان شمالي", new Guid("fc5ba5fc-ddf0-48f7-b814-45d6d468f06f") },
                    { 4, "البرز", new Guid("f131c448-4035-4364-86a5-50e82f6fab2b") },
                    { 5, "قم", new Guid("6ea8e2ee-e7dc-420a-8225-b21a0394405b") },
                    { 6, "کردستان", new Guid("a7d28287-f87d-4eb9-acd2-2f9f4097355d") },
                    { 7, "آذربايجان غربي", new Guid("b6ba2ce4-8c25-411d-8d5a-cc4ab2175e4b") },
                    { 9, "سيستان و بلوچستان", new Guid("76017386-7732-47b3-ae87-1651028d282f") },
                    { 10, "خراسان جنوبي", new Guid("5a79b624-add9-4c50-9211-a0fa5301e726") },
                    { 11, "خوزستان", new Guid("22e3899c-c4c4-4fe8-bbe7-22ba6204be8b") },
                    { 12, "بوشهر", new Guid("4f434bf6-9358-4158-a9d5-8f1efd6cc183") },
                    { 13, "زنجان", new Guid("5e12133b-f222-4d97-88c6-2c2f6c6df8b8") },
                    { 14, "گلستان", new Guid("a2b10cb8-206c-49f3-b1a9-9eba89845f37") },
                    { 8, "خراسان رضوي", new Guid("a3b25605-749f-4e7e-bc1e-c60f623d8b93") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 2, "ادمین", new DateTime(2020, 4, 30, 18, 30, 27, 453, DateTimeKind.Local).AddTicks(4035), "Admin", new Guid("4e076119-78ed-46b1-ad43-c359555f47f6") },
                    { 1, "کاربر عادی", new DateTime(2020, 4, 30, 18, 30, 27, 453, DateTimeKind.Local).AddTicks(2442), "User", new Guid("f5bb439f-5237-40ba-a582-2972365bdded") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 4, 30, 18, 30, 27, 445, DateTimeKind.Local).AddTicks(9895), "ptcoptco", new Guid("4ce0d4fc-1f32-4b48-b581-92eef6f72356"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 621, new Guid("c58b22ad-326d-47ab-be64-845190ab2124"), "بادرود", 19 },
                    { 828, new Guid("ba52a639-2ab7-425c-8f34-5dcf48650043"), "مراغه", 22 },
                    { 827, new Guid("5810a955-2145-41aa-b83d-acd66d0da8a0"), "مبارک شهر", 22 },
                    { 826, new Guid("ef8d96a4-a3c5-476a-a03b-20b2b54fbd2b"), "ليلان", 22 },
                    { 825, new Guid("f88a15e0-6a1a-4f76-8494-6bbdd9b164f8"), "قره آغاج", 22 },
                    { 824, new Guid("ec591a6c-03bd-4650-95f5-8198d1014f22"), "عجب شير", 22 },
                    { 823, new Guid("986ebb93-d053-44af-9a9f-ad74b71155fe"), "صوفيان", 22 },
                    { 822, new Guid("cf745105-7100-4e2e-b8a4-f77671a17232"), "شهر جديد سهند", 22 },
                    { 821, new Guid("2c7d916d-3759-484d-b35e-40bb5cec5914"), "شند آباد", 22 },
                    { 820, new Guid("4e4a364b-4e10-4aaa-9d08-ad63486e24b4"), "شرفخانه", 22 },
                    { 819, new Guid("d6b052fe-5ddb-407c-89a8-ae4cf462d880"), "شربيان", 22 },
                    { 818, new Guid("77b60e87-780c-4798-9439-73e09095b872"), "شبستر", 22 },
                    { 817, new Guid("e818531a-a338-4447-8151-0059ebbd8d0b"), "سيه رود", 22 },
                    { 816, new Guid("3b9473b3-e867-44cd-8c3a-0d7d336fcd46"), "سيس", 22 },
                    { 815, new Guid("009cfc17-cf84-4883-b537-a51565cb73d0"), "سردرود", 22 },
                    { 814, new Guid("161a068f-024a-464d-8b76-3379ee45f7f3"), "سراب", 22 },
                    { 829, new Guid("7c6c701f-1fa5-47ef-838c-351766b84601"), "مرند", 22 },
                    { 813, new Guid("9ad30711-caf3-4560-a5fe-bf61ad813738"), "زنوز", 22 },
                    { 830, new Guid("15cbc000-6648-46ac-a61b-b80d4530f86b"), "ملکان", 22 },
                    { 832, new Guid("7e6ede97-bf88-42a9-a2f0-8a4ecce7d778"), "مهربان", 22 },
                    { 847, new Guid("d78e67e6-cd0b-4af8-bd48-3a9c0220685c"), "آباده", 23 },
                    { 846, new Guid("2a546cb4-8be4-4e20-8708-8ae58cdfa2c5"), "گوگان", 22 },
                    { 845, new Guid("ca931798-5872-4b03-a84b-fe4bdd0c1bb8"), "کوزه کنان", 22 },
                    { 844, new Guid("fd583483-d9da-4832-b443-e25e08b501cf"), "کليبر", 22 },
                    { 843, new Guid("babdf6bd-4a89-420f-b93a-907a4b6c144e"), "کلوانق", 22 },
                    { 842, new Guid("5ff06534-5004-4c61-94b8-57920e7d0a53"), "کشکسراي", 22 },
                    { 841, new Guid("0d6d5131-d3b8-4d07-8853-f93e7a32cbbc"), "يامچي", 22 },
                    { 840, new Guid("3ca73f76-0fc0-4b1a-afb7-9921d8b996eb"), "ورزقان", 22 },
                    { 839, new Guid("696a94df-3e6a-46a6-8140-4136bc3b12ea"), "وايقان", 22 },
                    { 838, new Guid("c3d9c8cc-dfb8-40bb-8123-a6ae010fa4da"), "هوراند", 22 },
                    { 837, new Guid("b55fbcfb-ac45-4bbb-a51e-8fc9aecbdaa5"), "هشترود", 22 },
                    { 836, new Guid("352e07f8-7045-4c63-9adb-6ca19c294128"), "هريس", 22 },
                    { 835, new Guid("0caca978-ae25-4d57-bb8a-ef70e2a7861f"), "هاديشهر", 22 },
                    { 834, new Guid("af439a0f-54ac-4489-98f6-91c18abb2006"), "نظرکهريزي", 22 },
                    { 833, new Guid("78bc60f3-787e-4409-a95f-4a6675528f87"), "ميانه", 22 },
                    { 831, new Guid("7c1ff670-8f0b-4d02-8160-f58133cd55d8"), "ممقان", 22 },
                    { 812, new Guid("b20e28b7-92d8-46f7-ae18-a8bbb94af367"), "زرنق", 22 },
                    { 811, new Guid("a62cd5c6-8b15-43a0-9491-d150aa1e2e34"), "دوزدوزان", 22 },
                    { 810, new Guid("811dac41-b6da-48d5-90b2-b35d30fc83d6"), "خواجه", 22 },
                    { 789, new Guid("2883cc56-5b2b-4841-b0d9-0732a05a459a"), "اسکو", 22 },
                    { 788, new Guid("3a97949c-2962-4388-809d-0b3ff68a9649"), "آچاچي", 22 },
                    { 787, new Guid("70cd2685-9647-4dbb-a0db-826faa8f752b"), "آقکند", 22 },
                    { 786, new Guid("9fd47a22-67d1-49fa-ad10-621e90ebfbfd"), "آذرشهر", 22 },
                    { 785, new Guid("5fa9d859-f4b5-4a06-b504-6a287dec68cf"), "آبش احمد", 22 },
                    { 784, new Guid("b3eafb07-5d51-4dba-bbe9-4e35ebbbc706"), "گلستان", 21 },
                    { 783, new Guid("3f2b99c1-7435-46e9-b29e-490a1c4799e6"), "کيلان", 21 },
                    { 782, new Guid("b2a8449f-374e-4090-8e32-8d560b880558"), "کهريزک", 21 },
                    { 781, new Guid("857ddc27-c25e-48de-ae14-776e8416b431"), "چهاردانگه", 21 },
                    { 780, new Guid("1ec63951-1dee-4d77-b93d-6de785086e27"), "پيشوا", 21 },
                    { 779, new Guid("21b28b11-fd4b-45b0-b2af-238e1cb0d92e"), "پرديس", 21 },
                    { 778, new Guid("59f48ac4-2827-4fb2-905e-c5ff229aebae"), "پاکدشت", 21 },
                    { 777, new Guid("8055557d-4ef6-42b4-8b8a-0dbd8b43b5bb"), "ورامين", 21 },
                    { 776, new Guid("96472547-c764-42fb-8091-e25ddd0e16a8"), "وحيديه", 21 },
                    { 775, new Guid("e7531849-b145-41d4-87b3-db8183f80d00"), "نصيرشهر", 21 },
                    { 790, new Guid("c28d1903-15f9-4508-8ad6-1baf8449174b"), "اهر", 22 },
                    { 791, new Guid("dac84b2c-6e0f-46fc-b376-3b2703ef98f8"), "ايلخچي", 22 },
                    { 792, new Guid("b7382421-a7c2-4df0-8442-870d0a3d3e54"), "باسمنج", 22 },
                    { 793, new Guid("794dc68d-045d-42fa-af75-0f701dbeb936"), "بخشايش", 22 },
                    { 809, new Guid("34c5a9b3-d3d8-4dce-9cdd-9da67505a1c7"), "خمارلو", 22 },
                    { 808, new Guid("d00fca0c-899d-40e2-a8de-0adf44b0e703"), "خسروشاه", 22 },
                    { 807, new Guid("7c83d3e0-2bc9-4be0-b210-5386251ebb89"), "خداجو", 22 },
                    { 806, new Guid("f5f609dd-0455-4803-be79-8ab130c4b694"), "خامنه", 22 },
                    { 805, new Guid("1ce30f78-3fd9-41f1-b861-ab33cc3a939e"), "خاروانا", 22 },
                    { 804, new Guid("8d923256-e321-4c1d-a889-e6146edf97f7"), "جوان قلعه", 22 },
                    { 803, new Guid("9245742e-c48b-4948-bcf0-17faf82f957d"), "جلفا", 22 },
                    { 848, new Guid("528c8b93-1938-4509-a116-cc344e150430"), "آباده طشک", 23 },
                    { 802, new Guid("305dd56f-077a-4834-8dfb-18430cbd04d8"), "تيکمه داش", 22 },
                    { 800, new Guid("1152735a-c10b-4981-8322-9a33e5c7ea3b"), "تسوج", 22 },
                    { 799, new Guid("103b3c86-5747-41e2-a0b1-6d89309779d3"), "ترکمانچاي", 22 },
                    { 798, new Guid("1b532cbd-816a-415e-aa06-30f8d315e8d7"), "ترک", 22 },
                    { 797, new Guid("9d296a2f-08fe-4cef-848b-24db29621e2e"), "تبريز", 22 },
                    { 796, new Guid("d2da5110-95ea-444c-9edc-f3befe7ebdf0"), "بناب مرند", 22 },
                    { 795, new Guid("d08bc09f-5acf-4e8c-aa51-3ed8cf0751d1"), "بناب", 22 },
                    { 794, new Guid("bd47b608-18fb-4044-af58-f4adfe285d8d"), "بستان آباد", 22 },
                    { 801, new Guid("c3fea94e-e80f-4fcb-894a-fab10620e517"), "تيمورلو", 22 },
                    { 849, new Guid("aeaa9c82-182a-4b2b-aa3c-fd879aa1a6a0"), "اردکان", 23 },
                    { 850, new Guid("5e25a923-ae78-410c-bfe9-f98af6480e80"), "ارسنجان", 23 },
                    { 851, new Guid("ddcb97b8-f0fd-40a1-afd3-a4e154a0d230"), "استهبان", 23 },
                    { 905, new Guid("00293c61-41d0-491f-bca4-d7427ead4a57"), "صغاد", 23 },
                    { 904, new Guid("100d072b-b5e1-4ede-9732-171904d25eac"), "شيراز", 23 },
                    { 903, new Guid("5535c54f-c10e-4598-8542-c852b40c7c41"), "شهر پير", 23 },
                    { 902, new Guid("77cfc3fa-2cb9-4e48-9721-d30b667586cd"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("4aaeb662-00f7-47c0-b853-a9fbb1f07cfb"), "ششده", 23 },
                    { 900, new Guid("3a40bb70-6916-4f7a-b0aa-5d3fe3dee641"), "سيدان", 23 },
                    { 899, new Guid("162cd341-dcab-4ec6-92d2-d826170ad39f"), "سورمق", 23 },
                    { 898, new Guid("dd1e687c-89a3-4e3c-acf0-bfebdf611280"), "سلطان شهر", 23 },
                    { 897, new Guid("7bb2ea74-ecd8-4086-969e-1925322e9f7a"), "سعادت شهر", 23 },
                    { 896, new Guid("b7045fb2-a56d-42c5-8ec0-197485148371"), "سروستان", 23 },
                    { 895, new Guid("01ee8753-50e5-4462-9ccd-5905e5c0d0c4"), "سده", 23 },
                    { 894, new Guid("30d7d26a-e927-4465-9deb-cab80d6a086d"), "زرقان", 23 },
                    { 893, new Guid("0b7a616a-1796-429a-ad9a-4b968a679458"), "زاهد شهر", 23 },
                    { 892, new Guid("7af6421d-8d37-487c-9a27-a9d9b8f0aaff"), "رونيز", 23 },
                    { 891, new Guid("b3071b66-37b1-40ca-9718-a06dc69f6908"), "رامجرد", 23 },
                    { 906, new Guid("d468eb88-d899-4ddc-a857-e440d3518b31"), "صفا شهر", 23 },
                    { 907, new Guid("f36c8d41-c199-4e1c-ae70-d78572eac501"), "علامرودشت", 23 },
                    { 908, new Guid("07b08c9c-2982-4e47-843f-11fdfd5b74b3"), "عماد ده", 23 },
                    { 909, new Guid("67608853-b730-41ec-af99-46b46264c3ef"), "فدامي", 23 },
                    { 925, new Guid("0bf0a804-47fc-4752-8b1c-f82cc15460bd"), "مرودشت", 23 },
                    { 924, new Guid("539d0300-7356-46c5-ad45-23db3eef79ab"), "مبارک آباد", 23 },
                    { 923, new Guid("aec7a314-99ab-40de-8d4c-9e4224b08cb5"), "مادرسليمان", 23 },
                    { 922, new Guid("31b0259f-9ecf-43c5-9942-436aa1d9e726"), "لپوئي", 23 },
                    { 921, new Guid("ab87b5ea-59bc-4cb7-8327-d96e0f176f15"), "لطيفي", 23 },
                    { 920, new Guid("21c4898a-991f-45ea-a5aa-5992745df83e"), "لامرد", 23 },
                    { 919, new Guid("748016f6-1d40-4931-a784-72f378110f76"), "لار", 23 },
                    { 890, new Guid("1f5736eb-a233-4ba0-8c11-93435bc183c0"), "دژکرد", 23 },
                    { 918, new Guid("c482b549-d1f3-4b90-8fdc-f5ba9d1df876"), "قير", 23 },
                    { 916, new Guid("69df3751-c7fd-42d8-ba28-8762e2ca6ec4"), "قطب آباد", 23 },
                    { 915, new Guid("b5180637-4bce-4536-8976-6168dbe44c2b"), "قره بلاغ", 23 },
                    { 914, new Guid("ed056afa-6c76-405f-a44f-e82c6f760505"), "قادرآباد", 23 },
                    { 913, new Guid("97d100c4-02c1-48d4-b0fe-a5e1bba5c93c"), "قائميه", 23 },
                    { 912, new Guid("c55ef8b8-8b78-4a61-9613-72dc23f3cf34"), "فيروزآباد", 23 },
                    { 911, new Guid("6d650e49-2cbf-4403-8141-96deee4dc264"), "فسا", 23 },
                    { 910, new Guid("696c8480-ccb7-4276-963a-c79f0807202d"), "فراشبند", 23 },
                    { 917, new Guid("f8da64b6-d4d1-424c-8832-2f983cce4cf3"), "قطرويه", 23 },
                    { 774, new Guid("a22abfdd-c703-4d7b-a1a9-74e924062bac"), "نسيم شهر", 21 },
                    { 889, new Guid("c98b0703-e168-4e17-b789-95fc0d6296b0"), "دوزه", 23 },
                    { 887, new Guid("de11c75e-a1a7-4eed-af67-6ddf6be68d6c"), "دهرم", 23 },
                    { 866, new Guid("eba8d036-211d-46b1-870b-449220f105df"), "بوانات", 23 },
                    { 865, new Guid("90541fce-e1f7-4159-8bf1-554307683973"), "بهمن", 23 },
                    { 864, new Guid("777d4e1f-c3f6-41cb-ae2f-5aabb9648e0c"), "بنارويه", 23 },
                    { 863, new Guid("953961d4-0097-4092-9188-5d0d7994d0e2"), "بالاده", 23 },
                    { 862, new Guid("e39d40e5-a3ad-40d3-a034-33543cd75360"), "بابامنير", 23 },
                    { 861, new Guid("58c8f1f4-2be2-4cdd-a2b6-76852c7794a6"), "باب انار", 23 },
                    { 860, new Guid("f3290de2-6118-486b-b6da-3fee2db6f950"), "ايزد خواست", 23 },
                    { 859, new Guid("96850b8a-f13f-428d-8906-81bbd90efda4"), "ايج", 23 },
                    { 858, new Guid("194862b1-c0d7-4799-ba29-1a29f8e79f41"), "اوز", 23 },
                    { 857, new Guid("aa9d6cfe-ef7c-48be-bcbc-c0abb0e99887"), "اهل", 23 },
                    { 856, new Guid("3e904ede-b7c1-4848-aad3-9eb49229becf"), "امام شهر", 23 },
                    { 855, new Guid("b7141722-f3ae-479d-a855-10c558fbd834"), "اقليد", 23 },
                    { 854, new Guid("b84e5dbb-b701-4518-bd0f-1605d24d4f8a"), "افزر", 23 },
                    { 853, new Guid("1972e6c7-6b69-4d26-a2bf-d421e4a5d5e0"), "اشکنان", 23 },
                    { 852, new Guid("9b58d823-df4f-452e-9911-62ae5be07aec"), "اسير", 23 },
                    { 867, new Guid("2aa914fd-9d72-48df-bd20-cd9e5806a317"), "بيرم", 23 },
                    { 868, new Guid("1069e815-cdd6-4812-a73e-010a5c5fc707"), "بيضا", 23 },
                    { 869, new Guid("60f61e60-bd00-4b2d-a22f-f74ca68ac89d"), "جنت شهر", 23 },
                    { 870, new Guid("a7fa10ad-4ea1-4bd4-b247-009ff645bf15"), "جهرم", 23 },
                    { 886, new Guid("d11b0c1b-62bc-47bd-8e5b-8b71292dad6e"), "دبيران", 23 },
                    { 885, new Guid("6df99c64-48a0-4600-b104-21cb6866b1c6"), "داريان", 23 },
                    { 884, new Guid("a65e6a25-ca17-488e-9b6b-2e1524c0d6f6"), "داراب", 23 },
                    { 883, new Guid("81c684ec-c94a-4e25-ab2b-c6dbbfa992f8"), "خومه زار", 23 },
                    { 882, new Guid("842ed171-0fb0-424a-b9d0-8630ac06eac0"), "خوزي", 23 },
                    { 881, new Guid("6357e741-34c0-4403-b0fc-e7cd637b15d8"), "خور", 23 },
                    { 880, new Guid("b6147103-9bf0-4615-9c56-36d480e60693"), "خنج", 23 },
                    { 888, new Guid("9d076541-2110-4012-9bb5-f8446745bd04"), "دوبرجي", 23 },
                    { 879, new Guid("3d295066-bfbc-4c1f-9661-3ba8796b0153"), "خشت", 23 },
                    { 877, new Guid("d8094bfc-3581-4fea-b091-79a1aef8a91e"), "خاوران", 23 },
                    { 876, new Guid("4174eb92-e96a-4c9b-8c54-650acf074395"), "خانيمن", 23 },
                    { 875, new Guid("6df07efd-7c34-4654-884c-ffdcd7717167"), "خانه زنيان", 23 },
                    { 874, new Guid("c490e76a-86ed-4bd1-8b18-6b6d4c81d403"), "حسن آباد", 23 },
                    { 873, new Guid("34320973-5252-4f40-999f-10e0fbbf3562"), "حسامي", 23 },
                    { 872, new Guid("29a95611-62cc-4550-bb4e-96a571c785b2"), "حاجي آباد", 23 },
                    { 871, new Guid("060e6021-75c9-4220-a1c7-136f1b712372"), "جويم", 23 },
                    { 878, new Guid("f8971303-b9cf-4b99-8451-0df286d571d2"), "خرامه", 23 },
                    { 926, new Guid("29728961-d260-410d-91ad-4990f3ce6fd6"), "مزايجان", 23 },
                    { 773, new Guid("eff1dc12-72bd-460e-9b9f-7edff01c0954"), "ملارد", 21 },
                    { 771, new Guid("400a4c17-7305-444e-ae0d-0f246277b195"), "قرچک", 21 },
                    { 673, new Guid("56d22f05-315a-4cbd-88d5-dd1a5130fe61"), "فلاورجان", 19 },
                    { 672, new Guid("a7c7b78e-0ed0-4abf-a214-0ef276042f7c"), "فريدونشهر", 19 },
                    { 671, new Guid("50e33ddd-62f5-4d20-afba-4ebeaf65f627"), "فرخي", 19 },
                    { 670, new Guid("18611852-9109-4b0b-9df5-8ea9a0c75e5e"), "علويچه", 19 },
                    { 669, new Guid("dcf0cca6-8b84-4502-8df9-aa301aa0440d"), "عسگران", 19 },
                    { 668, new Guid("ff732c3a-af4b-49a7-a5bc-b0d73bcd35f6"), "طرق رود", 19 },
                    { 667, new Guid("4827ee6e-1138-4c3d-88cc-583d798a003c"), "طالخونچه", 19 },
                    { 666, new Guid("3f88d97d-f2ec-4aa8-8836-c11c45971039"), "شهرضا", 19 },
                    { 665, new Guid("541b0b22-c18d-44fa-9595-c7a9cb2d113f"), "شاپورآباد", 19 },
                    { 664, new Guid("e4e429aa-ecb3-43f7-b50b-56b1f0f50448"), "شاهين شهر", 19 },
                    { 663, new Guid("7cc7e179-81c1-4f5b-87a8-bb50a3dc2d95"), "سگزي", 19 },
                    { 662, new Guid("0029d9d6-e83d-4bc3-b5db-ee8a07537afe"), "سين", 19 },
                    { 661, new Guid("6e4ad7c0-002f-4d1b-97ce-d0d81380b58c"), "سميرم", 19 },
                    { 660, new Guid("0d62adbe-5c12-40a0-9d2b-d05f8a324ac9"), "سفيد شهر", 19 },
                    { 659, new Guid("ffcbf68e-7823-4dab-b731-aedd8c39d0ce"), "سده لنجان", 19 },
                    { 674, new Guid("f2bd7bb8-3c91-406c-a009-39983859aeab"), "فولاد شهر", 19 },
                    { 658, new Guid("72ae9df6-68cb-4b4f-9179-d17232cf1acf"), "زيباشهر", 19 },
                    { 675, new Guid("a99dbfbd-a257-4104-b2ac-61adfeace24d"), "قمصر", 19 },
                    { 677, new Guid("8da7f5db-bd2a-4eee-a364-be5e686e8ec3"), "قهدريجان", 19 },
                    { 692, new Guid("dfd42f7c-b5d3-45fa-8c71-7ec532fe3217"), "هرند", 19 },
                    { 691, new Guid("bdb3605e-b19d-4d61-8edb-6b61ca62c7d4"), "نيک آباد", 19 },
                    { 690, new Guid("7303680b-1067-43da-8e00-8bac2c7191f3"), "نياسر", 19 },
                    { 689, new Guid("9e7c1059-e209-4003-b8e8-d1d54add8260"), "نوش آباد", 19 },
                    { 688, new Guid("6c2be0c7-b37d-40e5-a82d-23fbafaad7d1"), "نطنز", 19 },
                    { 687, new Guid("2373ac2e-478b-40e6-a72e-2543cb8bfe0d"), "نصرآباد", 19 },
                    { 686, new Guid("11f5828b-759b-44d4-828b-98418753f101"), "نجف آباد", 19 },
                    { 685, new Guid("222a9596-24bc-48f0-a912-ec673575ea50"), "نائين", 19 },
                    { 684, new Guid("a9607b2d-9096-4812-998a-587707a0fc62"), "ميمه", 19 },
                    { 683, new Guid("044c2988-4351-41e8-83fb-0c6b6298f142"), "مهاباد", 19 },
                    { 682, new Guid("a05ad03b-f971-4e8f-91bd-b713b7fd358e"), "منظريه", 19 },
                    { 681, new Guid("f6b1680e-8b4b-4708-98b7-1ca4d74c5eba"), "مشکات", 19 },
                    { 680, new Guid("af740a4b-8edb-4333-9b65-80cbef558e99"), "محمد آباد", 19 },
                    { 679, new Guid("65db5f47-eeed-4e56-a678-a45378189dee"), "مبارکه", 19 },
                    { 678, new Guid("03c5da22-4c15-4918-99e9-be420c1c230a"), "لاي بيد", 19 },
                    { 676, new Guid("ca206bfb-83da-447a-9cb4-f452299b3d1a"), "قهجاورستان", 19 },
                    { 657, new Guid("4435df10-0bb4-49ef-8c41-708e2fd45bc0"), "زيار", 19 },
                    { 656, new Guid("0ee89bc3-4b53-447f-9d5f-03fabb4036f3"), "زواره", 19 },
                    { 655, new Guid("d54d0f3a-ba06-4d4f-a8b1-fcb478ef0fc5"), "زرين شهر", 19 },
                    { 634, new Guid("7deedb6b-b308-4db4-8446-ae4ff7574606"), "جوشقان قالي", 19 },
                    { 633, new Guid("9132cb16-6806-47e8-aca6-d040376fb95f"), "جوزدان", 19 },
                    { 632, new Guid("b9019b0b-832d-4b26-90e8-08d3736215ab"), "جندق", 19 },
                    { 631, new Guid("8dee42ea-97e9-4c2c-a0bb-99a3c5bc1b19"), "تيران", 19 },
                    { 630, new Guid("e7c31b82-6ee8-4df3-84e9-742b9a6cfb8e"), "تودشک", 19 },
                    { 629, new Guid("80bf7fe9-ccf9-40df-b38a-71184139c962"), "بوئين مياندشت", 19 },
                    { 628, new Guid("b511df4a-8f63-4f3e-9167-a6d3e144f1dc"), "بهارستان", 19 },
                    { 627, new Guid("627f71d9-58d5-4e90-8ced-1964bcc6841d"), "بهاران شهر", 19 },
                    { 626, new Guid("f8077ffb-2d12-48bf-a10b-4a9e706272a1"), "برف انبار", 19 },
                    { 625, new Guid("80c0e50e-3542-4a7d-8c1b-fea6f0a75302"), "برزک", 19 },
                    { 624, new Guid("57ca2e0d-9d28-4780-94b7-af965c16cc58"), "بافران", 19 },
                    { 623, new Guid("0f194215-9081-4e3a-a7c4-59c94c46246e"), "باغشاد", 19 },
                    { 622, new Guid("969ca2ba-c143-41ce-80e8-d9bff789bf00"), "باغ بهادران", 19 },
                    { 1239, new Guid("0c841eb4-8ef9-49d0-8844-922bb4bf15ce"), "چرام", 31 },
                    { 620, new Guid("e1d45612-6afe-467a-b32f-29572d66fba4"), "اژيه", 19 },
                    { 635, new Guid("7d6ddbc2-6027-4aa2-a2ab-bfa74929c1c7"), "حبيب آباد", 19 },
                    { 636, new Guid("542c900b-e861-46ee-8a47-b99176c28058"), "حسن آباد", 19 },
                    { 637, new Guid("ec6b9e16-b73c-4542-a2cb-0b3da8bcf907"), "حنا", 19 },
                    { 638, new Guid("1847a5b3-015c-4e23-ab97-36511199fe3f"), "خالد آباد", 19 },
                    { 654, new Guid("c2b55b0b-f362-46c8-94df-75aec670c87d"), "زاينده رود", 19 },
                    { 653, new Guid("609a0a7a-2fb9-4864-b30f-e28b64d69020"), "زازران", 19 },
                    { 652, new Guid("6060fe8b-cee4-4b89-8b6a-2c4702effa5e"), "رضوانشهر", 19 },
                    { 651, new Guid("148e273c-110f-45d9-a575-ca4bfd1c461f"), "رزوه", 19 },
                    { 650, new Guid("cce56ea6-b5ff-431c-af58-187c0af95d53"), "ديزيچه", 19 },
                    { 649, new Guid("be918484-5f29-4d93-87b4-30c155240bfe"), "دولت آباد", 19 },
                    { 648, new Guid("a8d98d38-8eba-4413-8646-13269402de47"), "دهق", 19 },
                    { 693, new Guid("e08a21a1-df9c-44d8-a764-a3f61ab9ac43"), "ورزنه", 19 },
                    { 647, new Guid("9a85bb0a-0704-4979-84df-7b59a670709f"), "دهاقان", 19 },
                    { 645, new Guid("f7d42ebf-6a95-444f-b6c7-af2752d51285"), "درچه پياز", 19 },
                    { 644, new Guid("0158f6f2-b84d-403b-bdad-0afb71ffd71e"), "دامنه", 19 },
                    { 643, new Guid("9a174ec4-7e4b-4f0d-beba-d612903c12ce"), "داران", 19 },
                    { 642, new Guid("80abb1e9-e576-4983-80d3-1f7ca8854524"), "خورزوق", 19 },
                    { 641, new Guid("2b76ac51-5fbf-4500-8718-4e6a08f2a201"), "خور", 19 },
                    { 640, new Guid("736b64fe-5414-49f5-aceb-d8dd498c0fb9"), "خوانسار", 19 },
                    { 639, new Guid("5871b72a-e0ba-4612-b77f-b13f584ca263"), "خميني شهر", 19 },
                    { 646, new Guid("c46001f8-07bd-4131-89c2-2e8e0265ce0c"), "دستگرد", 19 },
                    { 694, new Guid("43fea1f1-65ca-47a5-acf9-552d64768088"), "ورنامخواست", 19 },
                    { 695, new Guid("929167e1-fc4b-4491-9cbb-87951ba05dbc"), "وزوان", 19 },
                    { 696, new Guid("5cf8906b-e716-4f0f-9b5b-24ac69642d64"), "ونک", 19 },
                    { 750, new Guid("d3857d3f-96ed-40b5-83d3-0230d2fea69c"), "تجريش", 21 },
                    { 749, new Guid("736f0421-433b-4616-be2a-667ceb409cf8"), "بومهن", 21 },
                    { 748, new Guid("daea82f5-8014-46fe-90b3-fc95eb52bbe9"), "باقرشهر", 21 },
                    { 747, new Guid("1692c0f2-805c-4ae4-8b1e-69bbdadc4e79"), "باغستان", 21 },
                    { 746, new Guid("d875855e-ea4a-4bd2-9f9c-8fe667e3bcf1"), "انديشه", 21 },
                    { 745, new Guid("8bef5317-202d-43e4-8239-bfecefba7e9a"), "اسلامشهر", 21 },
                    { 744, new Guid("a72d8baa-d788-4909-8d00-b38ebc459a2b"), "ارجمند", 21 },
                    { 743, new Guid("3bd2e300-5c5e-4eec-8229-08c3da1048dc"), "آبعلي", 21 },
                    { 742, new Guid("a4f284eb-709c-4d45-825e-38d3a27818e3"), "آبسرد", 21 },
                    { 741, new Guid("851c3275-cfbb-4cb7-8d85-97e16e07edab"), "چوار", 20 },
                    { 740, new Guid("c4ed9498-9d6c-485f-bf8f-69237fc2fb22"), "پهله", 20 },
                    { 739, new Guid("df3a531a-400f-4bf6-9e72-ac27d801fc6b"), "ميمه", 20 },
                    { 738, new Guid("9858f0a7-8b6f-4b79-a695-3b7272d87980"), "موسيان", 20 },
                    { 737, new Guid("f53cb638-0f49-47a7-beaa-541c5d268f53"), "مورموري", 20 },
                    { 736, new Guid("d309c052-8e27-4b03-8800-394cc94524e9"), "مهران", 20 },
                    { 751, new Guid("d3f3e223-0c09-4a23-9ded-21856e6aa0b7"), "تهران", 21 },
                    { 752, new Guid("4707f89f-a5f3-48e1-9174-2a62e2647768"), "جواد آباد", 21 },
                    { 753, new Guid("39773ff3-88f4-4f3e-9b99-b969ed71fe05"), "حسن آباد", 21 },
                    { 754, new Guid("5d12d454-0185-40bf-a50c-a6eb816552ab"), "دماوند", 21 },
                    { 770, new Guid("0265ab25-47e2-4c9c-a0b3-704d7ef4a53b"), "قدس", 21 },
                    { 769, new Guid("9733a42e-b970-4886-b6c5-9c028f716bd2"), "فيروزکوه", 21 },
                    { 768, new Guid("6367b629-60a5-419e-a7e7-89b8e08fc33a"), "فشم", 21 },
                    { 767, new Guid("393f4220-d53b-4c6c-9a3c-a8181bb5431b"), "فرون آباد", 21 },
                    { 766, new Guid("d937fc58-f358-4012-ba01-e0b945f49011"), "فردوسيه", 21 },
                    { 765, new Guid("5bf5010c-fd9e-49a4-87d1-79b1215e4cd8"), "صفادشت", 21 },
                    { 764, new Guid("91e912b6-0e8a-47b4-aaf7-4a1b0e0b2e0f"), "صبا شهر", 21 },
                    { 735, new Guid("4c2282ab-d909-4740-9f81-962b7cbdfb22"), "مهر", 20 },
                    { 763, new Guid("0409f36c-6569-4d12-8c48-63452cfb2865"), "صالحيه", 21 },
                    { 761, new Guid("969990cb-d912-4ee0-a790-90988d10d14e"), "شهر جديد پرند", 21 },
                    { 760, new Guid("ffd46fbd-ac1c-477c-b9c9-94aa3e4d31a0"), "شمشک", 21 },
                    { 759, new Guid("7320d793-a336-40fb-8e5d-923cc7d323ca"), "شريف آباد", 21 },
                    { 758, new Guid("6820d461-0aed-4102-a530-64afaf8461d2"), "شاهدشهر", 21 },
                    { 757, new Guid("2e7b867b-21f1-4698-95d4-484d82634d79"), "ري", 21 },
                    { 756, new Guid("1cfb062c-0b77-4507-add8-d09ace4b7008"), "رودهن", 21 },
                    { 755, new Guid("e8a27a07-7039-4863-bbb7-f32eb26ef402"), "رباط کريم", 21 },
                    { 762, new Guid("9ddebcaf-70e5-4011-86f4-e4eef88e23de"), "شهريار", 21 },
                    { 772, new Guid("41352911-f921-41a6-868a-a15fca8bf30b"), "لواسان", 21 },
                    { 734, new Guid("f3e27199-2f0b-4f5f-ad0a-827409164481"), "ماژين", 20 },
                    { 732, new Guid("16d07be6-bada-4349-a46f-62fd180bddcc"), "صالح آباد", 20 },
                    { 711, new Guid("56a713f8-e334-4140-8402-014c015b2a8b"), "گز برخوار", 19 },
                    { 710, new Guid("9e4b2c7e-5714-4b4d-894f-b678e1f2cd73"), "گرگاب", 19 },
                    { 709, new Guid("845d8742-07f6-46e4-a53b-ca9919150ddd"), "کوهپايه", 19 },
                    { 708, new Guid("f8481dbe-e835-492e-bdab-3315eeb0d725"), "کوشک", 19 },
                    { 707, new Guid("fb293671-f6b0-4ea6-98a2-73fecb4acd7d"), "کهريزسنگ", 19 },
                    { 706, new Guid("1406c7c2-ef81-4aa7-90c2-b06e26bbc1e3"), "کمه", 19 },
                    { 705, new Guid("84d1d491-1524-4e4e-b1a5-3cafd86f8a97"), "کمشجه", 19 },
                    { 704, new Guid("ddff2435-72d5-4310-8db3-aa8f8cdd1293"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("c1f68312-ebd5-4327-b6c3-0291ddb05159"), "کرکوند", 19 },
                    { 702, new Guid("90a41d1b-18a9-44c6-a633-2268ffeb3859"), "کامو و چوگان", 19 },
                    { 701, new Guid("01b7cd50-94db-412d-a3a4-cf506146017c"), "کاشان", 19 },
                    { 700, new Guid("7fbafa05-94ac-4184-8e5b-618b3bd55706"), "چمگردان", 19 },
                    { 699, new Guid("4e67ba85-e9bb-45d0-85e4-cc0003656adc"), "چرمهين", 19 },
                    { 698, new Guid("4bba95d5-e835-4908-8e21-da6394ccdc71"), "چادگان", 19 },
                    { 697, new Guid("725344d9-5800-427f-b2d4-a74325717fb2"), "پير بکران", 19 },
                    { 712, new Guid("f435411d-6c1a-4919-8377-628cd20de561"), "گلدشت", 19 },
                    { 713, new Guid("17a25439-97b9-4b7b-a7ab-4c1d56e23cf5"), "گلشن", 19 },
                    { 714, new Guid("f9f180eb-8cc7-4207-8a5d-2309adf90e4a"), "گلشهر", 19 },
                    { 715, new Guid("08d93e4a-7ca0-4479-a38f-3c7e91dfad47"), "گلپايگان", 19 },
                    { 731, new Guid("60c2e8ea-2269-41e5-8afe-a78801a5e7b1"), "شباب", 20 },
                    { 730, new Guid("9be1f22e-9874-4d94-8d27-d43c3ec0675e"), "سرابله", 20 },
                    { 729, new Guid("3b8b8a5b-68ba-49cb-bb34-2b07ae83c5eb"), "سراب باغ", 20 },
                    { 728, new Guid("2c147da1-b5fb-4012-a02b-db2fef2c0f53"), "زرنه", 20 },
                    { 727, new Guid("a602ce29-800e-4910-af99-4bc274f28907"), "دهلران", 20 },
                    { 726, new Guid("4640a622-a1d5-44c4-bf92-bbe76836a953"), "دلگشا", 20 },
                    { 725, new Guid("8071954a-1a98-401c-ae4d-6bc464ff015e"), "دره شهر", 20 },
                    { 733, new Guid("fa178d02-d3a7-489d-aa8f-437e4f1dc7bf"), "لومار", 20 },
                    { 724, new Guid("a603cf24-e9c2-45d5-8585-3203e5332a2d"), "توحيد", 20 },
                    { 722, new Guid("3ff59051-a1e0-48e3-b732-9243ae677661"), "بدره", 20 },
                    { 721, new Guid("6d0cc596-8b3e-4d1e-bf00-f46552660cce"), "ايوان", 20 },
                    { 720, new Guid("e5c23e6f-1c0b-4b27-b437-3bf69b6b3007"), "ايلام", 20 },
                    { 719, new Guid("48e35b7f-2fd9-47c9-8a80-3f7feea584f1"), "ارکواز", 20 },
                    { 718, new Guid("447b3d76-0e08-4216-8cc0-5e01d529d464"), "آسمان آباد", 20 },
                    { 717, new Guid("5536e030-4a8f-4161-8904-24a4d2a46268"), "آبدانان", 20 },
                    { 716, new Guid("4c1368c4-7634-45eb-a7fd-4fbf751a602e"), "گوگد", 19 },
                    { 723, new Guid("34e4139f-7956-41c0-adfa-153d396ec32c"), "بلاوه", 20 },
                    { 927, new Guid("a738ff8f-0054-4722-9951-a7249edf521e"), "مشکان", 23 },
                    { 928, new Guid("a8009773-f1e7-4d24-bd40-81f80d5efa1c"), "مصيري", 23 },
                    { 929, new Guid("413d742e-8d02-44e6-8524-be34f1150f70"), "مهر", 23 },
                    { 1139, new Guid("c9b86eef-1b74-4b24-b1e4-1156b8dc802e"), "باغين", 29 },
                    { 1138, new Guid("debf5ee6-e2f3-4ca1-be14-618405d5a3b9"), "اندوهجرد", 29 },
                    { 1137, new Guid("c9c982ab-13d0-49c7-8a33-dbf4410cccb4"), "انار", 29 },
                    { 1136, new Guid("9635d855-f24d-4072-a870-b782643e2ec4"), "امين شهر", 29 },
                    { 1135, new Guid("f562329d-3340-44f6-a276-883aa102fb24"), "ارزوئيه", 29 },
                    { 1134, new Guid("798cfdbe-8b01-4247-b16b-9258c4f720a0"), "اختيار آباد", 29 },
                    { 1133, new Guid("43e66dcb-e0f2-44a0-9925-c455d1c4720d"), "گيان", 28 },
                    { 1132, new Guid("6c0c2280-4182-4d44-aca4-4da8e21f402a"), "گل تپه", 28 },
                    { 1131, new Guid("69f238b4-aab2-4f07-9a85-9d23366ead80"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("6026d1e4-d6f7-409a-8594-cf2f769ca2e8"), "همدان", 28 },
                    { 1129, new Guid("ec3606fa-09fa-496f-b5f7-0993bf54db64"), "نهاوند", 28 },
                    { 1128, new Guid("84642c6e-0ce3-42c4-b369-0284c4ff2658"), "مهاجران", 28 },
                    { 1127, new Guid("66e0f200-c2a8-438b-a801-eed7ff291ca4"), "ملاير", 28 },
                    { 1126, new Guid("f4917b0d-6a7e-4be5-9423-93affb6fa46e"), "مريانج", 28 },
                    { 1125, new Guid("469a359c-9f5f-4e58-a2a1-b3f0359e3cb2"), "لالجين", 28 },
                    { 1140, new Guid("3deb430d-ca62-44bd-a344-c570aaed16f1"), "بافت", 29 },
                    { 1124, new Guid("4dfce90c-085a-41fa-afb0-3c9ea0bf5b0f"), "قهاوند", 28 },
                    { 1141, new Guid("4d9cbffc-1dc5-4e38-ba7a-42d2fc6b63ad"), "بردسير", 29 },
                    { 1143, new Guid("7538ae6b-fd80-43e0-8539-66f1766c24da"), "بزنجان", 29 },
                    { 1158, new Guid("9999b36a-b8c4-4147-aed2-41114c424fd6"), "دهج", 29 },
                    { 1157, new Guid("f94b35a7-9635-4654-8220-d9dc1266c79e"), "دشتکار", 29 },
                    { 1156, new Guid("4647ce8e-29d5-4bb6-9ac7-57b3d6ed8c07"), "درب بهشت", 29 },
                    { 1155, new Guid("2801d381-4b2f-496c-8c10-7b368f51d957"), "خورسند", 29 },
                    { 1154, new Guid("21f3721f-9412-4ab2-bfba-1a4f33c685fa"), "خواجوشهر", 29 },
                    { 1153, new Guid("e1119b41-903c-4e55-87c1-24c53288713d"), "خانوک", 29 },
                    { 1152, new Guid("34ac4917-6518-4099-b46e-48d37637809c"), "خاتون آباد", 29 },
                    { 1151, new Guid("a8c3d3f9-c470-43dd-b52a-f084dbfd6e2a"), "جيرفت", 29 },
                    { 1150, new Guid("39677c5c-8e6c-4421-b048-73d2c779947f"), "جوپار", 29 },
                    { 1149, new Guid("dad98251-55e1-4185-9b07-ec785305769c"), "جوزم", 29 },
                    { 1148, new Guid("85632eec-c0ec-4753-b97e-6008f961340e"), "جبالبارز", 29 },
                    { 1147, new Guid("7f4ce435-6ead-413a-8620-958204002e3a"), "بهرمان", 29 },
                    { 1146, new Guid("863d60d5-0972-48b3-87fd-244d705c5397"), "بم", 29 },
                    { 1145, new Guid("f0944eac-a54a-43a2-921d-13b2e03c3d89"), "بلوک", 29 },
                    { 1144, new Guid("caa00b86-f781-42ff-9356-f2ba6cc45f63"), "بلورد", 29 },
                    { 1142, new Guid("c80550c7-1132-468a-a23e-fcbb5c9647b9"), "بروات", 29 },
                    { 1123, new Guid("7e514306-1ff3-4e17-921d-3be7376fcaa3"), "قروه در جزين", 28 },
                    { 1122, new Guid("f936322c-a52d-4ebc-9c3f-0023ceaca3a6"), "فيروزان", 28 },
                    { 1121, new Guid("a81eac16-a7b3-4f4e-8f6c-2b6caf88f73b"), "فرسفج", 28 },
                    { 1100, new Guid("a792660b-e8ee-49c1-9422-c080743126ed"), "کلاچاي", 27 },
                    { 1099, new Guid("5067e541-af7b-40b2-a33c-106f939ba3a4"), "چوبر", 27 },
                    { 1098, new Guid("543d6667-390b-4152-9b95-435f24f4240e"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("e7c4417d-26eb-4e92-8ea6-ffc80f8b377d"), "چابکسر", 27 },
                    { 1096, new Guid("e7db844a-d9d6-4a07-9e34-c2b9d722216c"), "پره سر", 27 },
                    { 1095, new Guid("81b861d6-6f15-4cbd-bdcf-7dba5cb4c19c"), "واجارگاه", 27 },
                    { 1094, new Guid("4a7f8301-4581-4cba-8c62-9c392cf5c5b4"), "هشتپر", 27 },
                    { 1093, new Guid("cec09aee-bc15-4b33-b808-b3096115005f"), "منجيل", 27 },
                    { 1092, new Guid("f31a0f0f-2699-409e-93fa-8601b6549fe4"), "مرجقل", 27 },
                    { 1091, new Guid("b6786f77-dc18-4961-95ce-d0a38d908cc2"), "ماکلوان", 27 },
                    { 1090, new Guid("67a4db66-daeb-4bf6-b627-ee5a78ffe984"), "ماسوله", 27 },
                    { 1089, new Guid("b551b2ef-ad53-496b-8f47-303d36f1146c"), "ماسال", 27 },
                    { 1088, new Guid("b9723b90-3fe4-4985-88ef-c40e5825248f"), "ليسار", 27 },
                    { 1087, new Guid("d97198ef-7eef-49c6-be0c-551e1fcc829e"), "لوندويل", 27 },
                    { 1086, new Guid("0ab876da-15f6-47ba-883c-97ec0c8acbea"), "لولمان", 27 },
                    { 1101, new Guid("e331c0d2-2678-4236-842b-8ef883e59772"), "کومله", 27 },
                    { 1102, new Guid("c478bdc9-3094-4d15-8d1f-579a2dee47b0"), "کوچصفهان", 27 },
                    { 1103, new Guid("5425234b-6569-459b-bc08-c2de3fe4c3c7"), "کياشهر", 27 },
                    { 1104, new Guid("9eaa7605-672a-40ed-ae95-e4bc53bff2cd"), "گوراب زرميخ", 27 },
                    { 1120, new Guid("1189f1ca-1d8f-42eb-aa71-fedb79236646"), "فامنين", 28 },
                    { 1119, new Guid("b77ef2bc-0002-4979-9b6e-1cb0f0dfdedb"), "صالح آباد", 28 },
                    { 1118, new Guid("7dd2e753-30a2-487c-af96-6639d8afc4f0"), "شيرين سو", 28 },
                    { 1117, new Guid("faf3a11a-798a-447c-915f-ed8d8bf9a6d7"), "سرکان", 28 },
                    { 1116, new Guid("2c73aebe-c55c-4a89-bfcc-f2f966f78dfb"), "سامن", 28 },
                    { 1115, new Guid("3ddcc313-4b6b-4483-a6ad-2eece3290708"), "زنگنه", 28 },
                    { 1114, new Guid("8c8ec6e6-cf1f-46c0-95ba-a6bc20b7f375"), "رزن", 28 },
                    { 1159, new Guid("a6e9f700-9238-4ba3-b58c-1a5a7f279bbe"), "دوساري", 29 },
                    { 1113, new Guid("6a69c2b6-94de-4b96-9e10-72275d5d181c"), "دمق", 28 },
                    { 1111, new Guid("ad0ae215-6b60-4533-87c9-c1adc188d7a5"), "جورقان", 28 },
                    { 1110, new Guid("13e06e53-657e-4ef8-9ced-ffa57d5bf5e2"), "تويسرکان", 28 },
                    { 1109, new Guid("1445795f-80bd-46d3-9ea4-3a411e40296b"), "بهار", 28 },
                    { 1108, new Guid("2206cb0d-ce91-4546-a819-a60815126837"), "برزول", 28 },
                    { 1107, new Guid("80210821-f52f-44e6-9daa-28c850f1c71c"), "اسد آباد", 28 },
                    { 1106, new Guid("88eef001-d093-4d5f-8093-6b186e7322f4"), "ازندريان", 28 },
                    { 1105, new Guid("d32aad21-890e-4749-b205-6416c9e85e68"), "آجين", 28 },
                    { 1112, new Guid("a455837f-eb23-4432-8f49-110eeebab33d"), "جوکار", 28 },
                    { 1160, new Guid("8f1386ff-3215-4025-a141-5b95e09bbcb0"), "رابر", 29 },
                    { 1161, new Guid("e78dab01-ec3b-4a00-af66-f2b128954c59"), "راور", 29 },
                    { 1162, new Guid("d8fcefd1-4a26-4cb3-bf84-81ee6e897c76"), "راين", 29 },
                    { 1216, new Guid("ef32847e-7ced-405f-8ad3-442e8ff74730"), "شاهرود", 30 },
                    { 1215, new Guid("b7eaa106-0b0c-48b3-b279-189866b3bb2c"), "سمنان", 30 },
                    { 1214, new Guid("47e16967-ed4f-4964-a25c-086899b40b13"), "سرخه", 30 },
                    { 1213, new Guid("5463e7de-2ddf-4269-a5a7-3bb4f36e4ac6"), "روديان", 30 },
                    { 1212, new Guid("5e4e93cb-4268-49df-9502-f0d1626fe215"), "ديباج", 30 },
                    { 1211, new Guid("2d4a5661-bce7-4a2a-a90b-4c232a335d1c"), "درجزين", 30 },
                    { 1210, new Guid("2d854a9b-5156-4cd1-bd81-41bc4ffebcad"), "دامغان", 30 },
                    { 1209, new Guid("de3cae1c-b9f7-4dca-a95c-53890073b4cf"), "بيارجمند", 30 },
                    { 1208, new Guid("504a5fcc-a6c3-4844-a705-58018d17aef7"), "بسطام", 30 },
                    { 1207, new Guid("ad8b8fe6-c5b1-4977-8715-d95a8f32730b"), "ايوانکي", 30 },
                    { 1206, new Guid("8393bb1e-1313-4ad5-8e4b-fc16974a3ca7"), "اميريه", 30 },
                    { 1205, new Guid("62bb8249-f4a1-4da9-9589-f19e01530155"), "آرادان", 30 },
                    { 1204, new Guid("3f509c2f-9c3d-43e3-aea0-275128cad7af"), "گنبکي", 29 },
                    { 1203, new Guid("3bd7acb0-e6f0-478b-b94e-432ab462d6d5"), "گلزار", 29 },
                    { 1202, new Guid("ce9a1f6e-ca19-4be2-9971-5f8e0fbff9e7"), "گلباف", 29 },
                    { 1217, new Guid("9ee991dc-cc10-4667-aac3-73b5905f2cc6"), "شهميرزاد", 30 },
                    { 1218, new Guid("f690b5cd-d7bb-45a2-91d9-5477ff87d87a"), "مجن", 30 },
                    { 1219, new Guid("760be8c8-fc2c-4e56-8ece-490c3dd2040c"), "مهدي شهر", 30 },
                    { 1220, new Guid("35a20efd-bede-4d06-a894-c1013a3ce457"), "ميامي", 30 },
                    { 1236, new Guid("f78e84f3-ddd9-4f5b-bf04-03a9c5dc664e"), "مارگون", 31 },
                    { 1235, new Guid("a012ac80-4859-4214-91eb-b93662d7fb4a"), "مادوان", 31 },
                    { 1234, new Guid("a5b97b95-b07c-4025-976f-052bd4ffb2af"), "ليکک", 31 },
                    { 1233, new Guid("e46b0a05-679d-4ef1-b320-5c70a03a59d8"), "لنده", 31 },
                    { 1232, new Guid("45a9fafe-974a-4eb6-805e-b2450e97d152"), "قلعه رئيسي", 31 },
                    { 1231, new Guid("991ddf9f-f3ae-4cd6-a894-d70d49e5dc79"), "سي سخت", 31 },
                    { 1230, new Guid("5acdc26d-184f-463a-9cee-bf94d8c839fd"), "سوق", 31 },
                    { 1201, new Guid("1d20161b-16c0-4681-9d14-472f78b80ebb"), "کيانشهر", 29 },
                    { 1229, new Guid("2779a923-3868-4c93-87b7-a66f1ed89b03"), "سرفارياب", 31 },
                    { 1227, new Guid("5b82c717-2cbf-4834-a8f9-994f80e68b13"), "دوگنبدان", 31 },
                    { 1226, new Guid("f35a9429-f54e-4582-b0ea-fe04605b465b"), "دهدشت", 31 },
                    { 1225, new Guid("ede3ef14-049c-4364-96ee-94aad8d93674"), "باشت", 31 },
                    { 1224, new Guid("1ca9874a-33b0-4007-93e3-61cdff6def4d"), "گرمسار", 30 },
                    { 1223, new Guid("946dd6a8-91fe-4fae-8e26-32a9eac71587"), "کهن آباد", 30 },
                    { 1222, new Guid("18726e7f-154f-490c-9d3d-c67acb17a95e"), "کلاته خيج", 30 },
                    { 1221, new Guid("42bed986-70e2-4e9c-a282-6dfd8610ebc7"), "کلاته", 30 },
                    { 1228, new Guid("1230d1d1-2fa5-4bba-a72a-fb5ee6357304"), "ديشموک", 31 },
                    { 1085, new Guid("fdd5e7e9-4360-4f7f-a935-63f2b96a77cb"), "لوشان", 27 },
                    { 1200, new Guid("a4c95640-68a5-4e0f-8ee3-fc3c3e70ecf5"), "کوهبنان", 29 },
                    { 1198, new Guid("6d73df76-3f69-4cf4-9176-91fd8e08a59b"), "کشکوئيه", 29 },
                    { 1177, new Guid("8d518ab8-64bc-4662-8e68-17db962ee358"), "قلعه گنج", 29 },
                    { 1176, new Guid("ebcd841d-d2f0-4014-91e6-c3603715a3f2"), "فهرج", 29 },
                    { 1175, new Guid("20a3ee0c-2f7d-4a01-9e5d-4045424a9315"), "فارياب", 29 },
                    { 1174, new Guid("ec77f88a-14ab-4c58-9fcc-40e2cad55e84"), "عنبر آباد", 29 },
                    { 1173, new Guid("4227cda0-9838-470f-ba67-0c04c9daa1e9"), "صفائيه", 29 },
                    { 1172, new Guid("d97ebd4f-7edf-46ce-a3c6-d358c716a791"), "شهر بابک", 29 },
                    { 1171, new Guid("fcd80400-21a3-4df5-bcde-699d18991f3d"), "شهداد", 29 },
                    { 1170, new Guid("b1c16c66-fa3e-4289-9592-98649bb48393"), "سيرجان", 29 },
                    { 1169, new Guid("0d0fb0ad-4b31-40eb-856a-08aa12bf462f"), "زيد آباد", 29 },
                    { 1168, new Guid("ce07fffe-8187-4074-9cd3-17b83b12338d"), "زهکلوت", 29 },
                    { 1167, new Guid("840d830a-3d2e-4038-8bdc-0b9a0c94d6f4"), "زنگي آباد", 29 },
                    { 1166, new Guid("81cb3840-834f-4ce5-b402-4c9237d06a33"), "زرند", 29 },
                    { 1165, new Guid("39181168-17e9-4411-8d38-1e69cb15cc0f"), "ريحان", 29 },
                    { 1164, new Guid("05330feb-c7db-4b3f-a612-16f10cad19fc"), "رودبار", 29 },
                    { 1163, new Guid("b6c80296-19ff-4a1d-b20c-67d17d6b4d05"), "رفسنجان", 29 },
                    { 1178, new Guid("5d2e29c4-9239-4b19-bbd2-0dfed39d3277"), "لاله زار", 29 },
                    { 1179, new Guid("703e9200-8cfb-4ed5-8d25-940a405dc986"), "ماهان", 29 },
                    { 1180, new Guid("d31a381c-0715-4b80-8766-1db156346f01"), "محمد آباد", 29 },
                    { 1181, new Guid("b0a7cf23-6287-402e-94fd-f7fcd3170da3"), "محي آباد", 29 },
                    { 1197, new Guid("4dd077df-c6cd-45e6-91b2-d8dfd44875da"), "کرمان", 29 },
                    { 1196, new Guid("4d2a99d2-efb5-41a7-8190-662cb67e2861"), "کاظم آباد", 29 },
                    { 1195, new Guid("49d1113a-f3a5-4f93-b284-f3dfefd2ccc0"), "چترود", 29 },
                    { 1194, new Guid("2b965b79-defe-4eba-8345-fe1a465ed38b"), "پاريز", 29 },
                    { 1193, new Guid("6cec2fdb-903e-4a97-a762-a42dba1263ca"), "يزدان شهر", 29 },
                    { 1192, new Guid("e4f80b91-97bb-4878-8e9c-06b8de9d33b9"), "هنزا", 29 },
                    { 1191, new Guid("b5956002-5e2d-4dcc-be35-b1da7fb97789"), "هماشهر", 29 },
                    { 1199, new Guid("6af9ddf7-c9a1-4a82-8180-96ef9fe094e7"), "کهنوج", 29 },
                    { 1190, new Guid("037bc2eb-b1b5-4298-9449-1e4dde76fd55"), "هجدک", 29 },
                    { 1188, new Guid("724e03fa-f4ea-430a-8d4f-801b9a2ad10c"), "نودژ", 29 },
                    { 1187, new Guid("1ce4c0f0-08c4-4647-b30a-3278902c171d"), "نظام شهر", 29 },
                    { 1186, new Guid("32d5d75d-6749-4c89-9795-2a7d34911d01"), "نرماشير", 29 },
                    { 1185, new Guid("5a4c05d8-6a60-4e48-9034-ef8a57e167f9"), "نجف شهر", 29 },
                    { 1184, new Guid("021ce314-5908-4f3e-8072-df94332f3c9e"), "منوجان", 29 },
                    { 1183, new Guid("e8c99432-87d3-4eb6-84da-54053676c744"), "مس سرچشمه", 29 },
                    { 1182, new Guid("68e20853-acd9-4c50-a191-0abfcf8f8b58"), "مردهک", 29 },
                    { 1189, new Guid("d1157b14-2abe-4938-b44f-9ee2c1630e3f"), "نگار", 29 },
                    { 1084, new Guid("bc5feaa6-033e-4126-994a-4176a0ed3d0d"), "لنگرود", 27 },
                    { 1083, new Guid("a0c4cd52-1fa7-4a50-85f6-aed8b01fc7cd"), "لشت نشاء", 27 },
                    { 1082, new Guid("9daf3971-1e13-47ae-b8aa-5b76ecc3c333"), "لاهيجان", 27 },
                    { 983, new Guid("e4b4771c-04db-475d-b77b-eee401e6ba16"), "بندر جاسک", 25 },
                    { 982, new Guid("c67459a1-79cb-4963-a597-ac56f124d9a2"), "بستک", 25 },
                    { 981, new Guid("6dc5108d-9544-42eb-b98c-dfe959daf803"), "ابوموسي", 25 },
                    { 980, new Guid("7759f1ac-1805-4020-902d-f11c6376c2ec"), "گيلانغرب", 24 },
                    { 979, new Guid("11170abf-70f9-4020-96cb-53e75aaf6521"), "گودين", 24 },
                    { 978, new Guid("38367db5-0213-4b1a-92f1-3e13a1e03159"), "گهواره", 24 },
                    { 977, new Guid("ef75e354-f23e-4a72-9765-46e889047c3f"), "کوزران", 24 },
                    { 976, new Guid("bf4d1830-b092-4b8f-b355-2f75c3827f44"), "کنگاور", 24 },
                    { 975, new Guid("865cfe31-0d2f-46a6-9448-b8555e29aa2b"), "کرند غرب", 24 },
                    { 974, new Guid("d22ad27f-5a95-498b-a910-8ea4fdf4c00a"), "کرمانشاه", 24 },
                    { 973, new Guid("7997d840-aa36-431d-a0bc-234694f8d2f7"), "پاوه", 24 },
                    { 972, new Guid("0ae29ff7-f020-4899-84cc-83774676bd51"), "هلشي", 24 },
                    { 971, new Guid("5a5b4344-0ae7-4727-8f74-68799262c2e6"), "هرسين", 24 },
                    { 970, new Guid("114a2065-16ee-4c2d-9ca9-c4643b093626"), "نوسود", 24 },
                    { 969, new Guid("c1f103b4-3cbe-466a-9943-ae550a93062e"), "نودشه", 24 },
                    { 984, new Guid("c3c9b1c8-2364-405d-8438-9669388493ef"), "بندر عباس", 25 },
                    { 985, new Guid("761c9f81-2455-4370-bd36-bd52eb04193f"), "بندر لنگه", 25 },
                    { 986, new Guid("9527470d-9ae3-4ba9-95d2-aa971138741a"), "بيکاه", 25 },
                    { 987, new Guid("8d63a842-9a41-41ec-b649-4065648e9819"), "تازيان پائين", 25 },
                    { 1003, new Guid("99b38695-178f-4a22-a4e1-771ef0b7b23e"), "فارغان", 25 },
                    { 1002, new Guid("925f3c32-79c2-48a8-9c57-f79b58669718"), "سيريک", 25 },
                    { 1001, new Guid("563c1f4d-75ca-4d2d-b04d-48cd40991a57"), "سوزا", 25 },
                    { 1000, new Guid("85a67065-f76a-406a-9187-28c7a5262193"), "سندرک", 25 },
                    { 999, new Guid("cb7862a1-5a5d-44e2-8dd6-e3795c593776"), "سرگز", 25 },
                    { 998, new Guid("51a2b066-69c4-4b49-94b1-62a15fc6a56a"), "سردشت", 25 },
                    { 997, new Guid("6ebbfcaf-b4bb-4e75-b131-4495c476997a"), "زيارتعلي", 25 },
                    { 968, new Guid("32af581d-9f7f-49ee-ab26-7554c799f6f1"), "ميان راهان", 24 },
                    { 996, new Guid("6497a039-1639-4ef8-8b05-77c3f1142b74"), "رويدر", 25 },
                    { 994, new Guid("cec4ab32-fdb6-43d5-b04c-c35833ef80d3"), "دشتي", 25 },
                    { 993, new Guid("7af5b126-1e26-481d-809f-f7c799e9e334"), "درگهان", 25 },
                    { 992, new Guid("dc7965ab-90a2-4680-95a3-54b8bdc58299"), "خمير", 25 },
                    { 991, new Guid("225229e8-d954-4633-8368-00d5c0f7c4ff"), "حاجي آباد", 25 },
                    { 990, new Guid("de5dbfd8-21c3-43a2-a1b4-4505324f8023"), "جناح", 25 },
                    { 989, new Guid("b3489938-0455-45b9-892f-a2d190e0bf4a"), "تيرور", 25 },
                    { 988, new Guid("e3b2666e-2658-4910-8d28-a7c7db12374a"), "تخت", 25 },
                    { 995, new Guid("c954a0a2-71b7-4b1a-bc72-33b0fdde0c5e"), "دهبارز", 25 },
                    { 1004, new Guid("8b21f122-ae7b-4e5a-9ce4-525fcafcda4b"), "فين", 25 },
                    { 967, new Guid("2cbdec64-fc3c-4f97-9a2f-d49435de5b39"), "قصر شيرين", 24 },
                    { 965, new Guid("7eb8e85d-362c-4d84-be17-f92e690e61a6"), "شاهو", 24 },
                    { 944, new Guid("d184f7f4-8846-4aa3-8604-eec18422e75f"), "کوار", 23 },
                    { 943, new Guid("901ef76e-3abc-40be-8d6c-8ba83bb0caba"), "کنار تخته", 23 },
                    { 942, new Guid("4eb301ca-b901-4db0-af1f-f3b123bff53d"), "کره اي", 23 },
                    { 941, new Guid("ef555cf2-6a50-44f9-a898-0d022eb6b4c7"), "کامفيروز", 23 },
                    { 940, new Guid("3a0bf49e-a01a-4388-8dd2-5aed5bb1f8b3"), "کازرون", 23 },
                    { 939, new Guid("ac4bc844-00b4-4a4b-8719-4bc61d6c46c5"), "کارزين", 23 },
                    { 938, new Guid("189f9a99-0551-42b1-9366-11d1381c93b2"), "وراوي", 23 },
                    { 937, new Guid("621e0a66-22fe-42d5-917c-85dd3895bbbc"), "هماشهر", 23 },
                    { 936, new Guid("743c0f46-2f1d-402e-ae4c-c9f94f29ea26"), "ني ريز", 23 },
                    { 935, new Guid("cf5ca6b8-05e5-4d79-be72-d2a7e42ebced"), "نورآباد", 23 },
                    { 934, new Guid("19ec9aef-129c-4fdc-b506-6b2bf7b108df"), "نودان", 23 },
                    { 933, new Guid("b1c34663-4d82-471f-b17b-dcd0c5da14e4"), "نوجين", 23 },
                    { 932, new Guid("2a9e8204-acd3-4e1c-a3aa-c6f2b831c3fd"), "نوبندگان", 23 },
                    { 931, new Guid("7bd2f807-abbc-40a4-9c50-f2022f6f1889"), "ميمند", 23 },
                    { 930, new Guid("d3974d0f-2d4a-4d35-a776-e2e2041b8a6d"), "ميانشهر", 23 },
                    { 945, new Guid("3859cbd4-59d6-4f8c-8761-57a7ea34b9be"), "کوهنجان", 23 },
                    { 946, new Guid("60e7f770-377d-4ca0-9675-baf7028b6bb8"), "کوپن", 23 },
                    { 947, new Guid("a5a5be8c-f73d-400f-97d2-1c7b08baaa82"), "گراش", 23 },
                    { 948, new Guid("f013ccee-a451-40fb-bede-971173e73999"), "گله دار", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 964, new Guid("ca6e1914-2364-4220-b770-ce2619a95bed"), "سومار", 24 },
                    { 963, new Guid("974d1dd6-185c-4e96-8227-d1b839b750b2"), "سنقر", 24 },
                    { 962, new Guid("d9da8d0a-b347-4a84-8e81-9b223d837055"), "سطر", 24 },
                    { 961, new Guid("63a10d03-335f-4bcc-a862-ca587bf5f53b"), "سرمست", 24 },
                    { 960, new Guid("b9217030-077a-40cb-b42e-404683dfe40d"), "سر پل ذهاب", 24 },
                    { 959, new Guid("5598bdfd-f027-455f-9528-7bba9bbcc984"), "ريجاب", 24 },
                    { 958, new Guid("3d271427-2ebc-42cc-be90-df2daaf9460e"), "روانسر", 24 },
                    { 966, new Guid("8a9393eb-48d0-43bb-b977-25109bb25fe4"), "صحنه", 24 },
                    { 957, new Guid("45ae62b6-0644-473c-a7f3-7e001081ec43"), "رباط", 24 },
                    { 955, new Guid("74b6999c-08c0-4f6c-99e7-b0df9a883035"), "جوانرود", 24 },
                    { 954, new Guid("19170996-9eb3-4118-b275-c352a6b623fb"), "تازه آباد", 24 },
                    { 953, new Guid("2fd57360-d4ed-4b52-a495-98162d5baa65"), "بيستون", 24 },
                    { 952, new Guid("32e0b802-a232-4308-aa95-3c57eeb6c6a5"), "باينگان", 24 },
                    { 951, new Guid("57500a97-1710-4a48-b4d3-4fe2d9e8f182"), "بانوره", 24 },
                    { 950, new Guid("ccc4eddd-80ff-4061-bea8-4c469d016fbe"), "اسلام آباد غرب", 24 },
                    { 949, new Guid("aba8f01c-622e-4380-bc17-900e34d6b0fa"), "ازگله", 24 },
                    { 956, new Guid("27900df7-cfd5-4aeb-8116-fd9f2e189940"), "حميل", 24 },
                    { 619, new Guid("1068d7ab-f9d8-4096-a352-1a16136de09c"), "ايمانشهر", 19 },
                    { 1005, new Guid("944756a9-c827-42a6-aafd-a48eebf63ab7"), "قشم", 25 },
                    { 1007, new Guid("afc315f0-e4c9-439a-b98f-63ebbd49d094"), "لمزان", 25 },
                    { 1061, new Guid("d96df768-445d-482c-b653-99a3e240c5df"), "بندر انزلي", 27 },
                    { 1060, new Guid("276596d0-257b-4ec5-aa05-1fc55eea7191"), "بره سر", 27 },
                    { 1059, new Guid("936ad031-c82c-49c1-a3e7-e3c7d2e5adc9"), "بازار جمعه", 27 },
                    { 1058, new Guid("dd9ef13e-6a1f-4d1d-9105-9b24320ac03b"), "املش", 27 },
                    { 1057, new Guid("2d365d0d-78a4-447f-825d-e9d0ca55dae0"), "اطاقور", 27 },
                    { 1056, new Guid("4435c41c-1ea3-4d1f-8779-f6424ea71653"), "اسالم", 27 },
                    { 1055, new Guid("be5b972b-7d2c-438a-9ae3-b6ac1a787b45"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("5cf99105-27e0-42a0-86d7-e63d6b16eaec"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("48373bdf-94a0-4de4-b7d8-e4a84e6ca291"), "آستارا", 27 },
                    { 1052, new Guid("07dd1d32-72b2-4143-bd26-8d95ca0b79e6"), "کميجان", 26 },
                    { 1051, new Guid("0daf24ab-a59b-42d8-ae4d-aa0913e10f11"), "کارچان", 26 },
                    { 1050, new Guid("639670da-271a-42e9-9d3d-60197e32d57f"), "پرندک", 26 },
                    { 1049, new Guid("65a5f639-f8b8-4933-bdf1-93ae1d82a948"), "هندودر", 26 },
                    { 1048, new Guid("f2ee0e84-913e-4c20-8388-5865bc56084e"), "نيمور", 26 },
                    { 1047, new Guid("5067a808-33d1-48fe-90bc-0d606d2ff383"), "نوبران", 26 },
                    { 1062, new Guid("9ec1e8ec-60a0-4495-b5e3-731664b6729a"), "توتکابن", 27 },
                    { 1063, new Guid("91cc25f2-ada2-487b-9079-fbcc2cbd22fa"), "جيرنده", 27 },
                    { 1064, new Guid("7066d0f1-f511-46d7-9dec-c405f80efd7c"), "حويق", 27 },
                    { 1065, new Guid("7e40eb4e-8b17-4a2a-bee4-a029552eeae8"), "خشکبيجار", 27 },
                    { 1081, new Guid("274e35fa-0829-4435-829a-3ee34f3e63b8"), "فومن", 27 },
                    { 1080, new Guid("44ffa369-632e-48fa-a938-603c0a852bfb"), "صومعه سرا", 27 },
                    { 1079, new Guid("7b3b1cbb-8597-4c9d-9580-846405c1c2c8"), "شلمان", 27 },
                    { 1078, new Guid("e3b4a200-5096-43e6-98d4-200e4e64a363"), "شفت", 27 },
                    { 1077, new Guid("a1988a02-94a3-4cbb-825c-e22463affbf6"), "سياهکل", 27 },
                    { 1076, new Guid("e2ff70ae-c8fa-427b-8f1a-140a38727547"), "سنگر", 27 },
                    { 1075, new Guid("29773a6c-6ad4-4a22-a98e-b31dceb943de"), "رودسر", 27 },
                    { 1046, new Guid("d2fb4293-35df-41f9-9d95-dd9ca7f3d928"), "نراق", 26 },
                    { 1074, new Guid("53f625f7-ebaf-47f4-9007-8d6e82b3bd19"), "رودبنه", 27 },
                    { 1072, new Guid("2b9cb792-cb79-46f7-9039-6224686d36ff"), "رضوانشهر", 27 },
                    { 1071, new Guid("a8ccfe68-a5ce-4e97-8f00-4f7b5e688110"), "رشت", 27 },
                    { 1070, new Guid("b4e01744-ea4d-46e5-acc2-aaa5601d3c1b"), "رستم آباد", 27 },
                    { 1069, new Guid("9f430361-3182-40ac-93ab-e9443cc03173"), "رحيم آباد", 27 },
                    { 1068, new Guid("2908f3e6-9b58-4874-a1a8-af2effd8aa5b"), "رانکوه", 27 },
                    { 1067, new Guid("31b16510-c33f-4fe7-9fdd-e81d51aa5d95"), "ديلمان", 27 },
                    { 1066, new Guid("5ae7b6d3-b1a9-4c3b-a561-abd2d36852de"), "خمام", 27 },
                    { 1073, new Guid("c7265b7d-d4db-4e85-b795-707e751605d2"), "رودبار", 27 },
                    { 1006, new Guid("208bc9d2-dfbf-45b8-9b78-aef827568faa"), "قلعه قاضي", 25 },
                    { 1045, new Guid("8c8ec23a-9239-4e8b-ba25-5598514f6200"), "ميلاجرد", 26 },
                    { 1043, new Guid("4feb47c9-ea1a-4c99-9069-e90e8ab24416"), "مامونيه", 26 },
                    { 1022, new Guid("aadbf65a-2e82-4240-90c9-9acce4908e0e"), "آوه", 26 },
                    { 1021, new Guid("f2787d05-76fd-4c34-bf38-fe01115c9504"), "آشتيان", 26 },
                    { 1020, new Guid("a4d0c5fd-da89-4209-967d-0685391899cc"), "آستانه", 26 },
                    { 1019, new Guid("78f73540-a607-4e99-adc7-ab557031e97c"), "گوهران", 25 },
                    { 1018, new Guid("33641912-77db-443c-9bd2-f1054cbd0a04"), "گروک", 25 },
                    { 1017, new Guid("91b738a8-0991-49d7-ae30-626e32f5694a"), "کيش", 25 },
                    { 1016, new Guid("742ef1fe-279d-4e06-8f84-b710ace09b8f"), "کوهستک", 25 },
                    { 1015, new Guid("3402d831-c2a2-4801-9615-4170920c0a8c"), "کوشکنار", 25 },
                    { 1014, new Guid("281bd3a3-9453-4795-8a89-aaf7e7663ba3"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("54e23c62-03f0-45c1-acfd-903428e7c866"), "کنگ", 25 },
                    { 1012, new Guid("ee949a05-68d5-42a6-b480-673fdc045deb"), "چارک", 25 },
                    { 1011, new Guid("8a86bf59-b2e4-4a60-b37e-dc3d11872b24"), "پارسيان", 25 },
                    { 1010, new Guid("f812d504-06a6-466a-83c7-2d28a796e349"), "هشتبندي", 25 },
                    { 1009, new Guid("34b4ade5-80fa-42a9-8d0d-51f0f0a7812f"), "هرمز", 25 },
                    { 1008, new Guid("b9e559d1-dbb1-4ea6-9088-5f04bf65d15e"), "ميناب", 25 },
                    { 1023, new Guid("4b45295d-ceb1-4db2-8fdb-e8b9b27edcc1"), "اراک", 26 },
                    { 1024, new Guid("1053f83c-6ba5-4a49-bfe4-2738545db534"), "تفرش", 26 },
                    { 1025, new Guid("c1a613af-71d1-4c00-a732-c9c1a76b0637"), "توره", 26 },
                    { 1026, new Guid("99991157-c131-451b-8d9d-3153936fe0ea"), "جاورسيان", 26 },
                    { 1042, new Guid("9b891447-c8cb-4475-b51c-e637fb54a661"), "قورچي باشي", 26 },
                    { 1041, new Guid("d5823226-6a1e-49de-a705-885be7b32a6c"), "فرمهين", 26 },
                    { 1040, new Guid("78695a32-6f2f-4312-bd05-73acb1eafe14"), "غرق آباد", 26 },
                    { 1039, new Guid("15c05991-f29e-4208-8816-84fa100e5f95"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("7fc88e7a-88fe-4926-a4f4-38e2933b1c8f"), "شهباز", 26 },
                    { 1037, new Guid("7cc2f108-4cae-4c47-b9d1-5cb1473866e8"), "شازند", 26 },
                    { 1036, new Guid("7173aafb-aa39-46d2-9e27-d7630e482c12"), "ساوه", 26 },
                    { 1044, new Guid("c0d4ecd7-225b-4d5f-b263-7b15c179dd4c"), "محلات", 26 },
                    { 1035, new Guid("8178bfd8-54b1-4828-bbbe-8707ffab08d5"), "ساروق", 26 },
                    { 1033, new Guid("5f506c7c-a02a-4901-beab-1215752dc9fb"), "رازقان", 26 },
                    { 1032, new Guid("1aa1e2f6-a156-40f0-a04e-cf69a3c44869"), "دليجان", 26 },
                    { 1031, new Guid("82352f8b-be15-4f6e-8015-9c1959df1dfb"), "داود آباد", 26 },
                    { 1030, new Guid("f3a1aef7-452f-4645-be17-3bd6953729b9"), "خنداب", 26 },
                    { 1029, new Guid("395f4055-72da-4fb5-a4cc-99722f39dfa7"), "خنجين", 26 },
                    { 1028, new Guid("a3b11c22-dbd3-4d95-a334-edb8a911e810"), "خمين", 26 },
                    { 1027, new Guid("21cd65ab-1dbd-4f96-8d21-301952e226a5"), "خشکرود", 26 },
                    { 1034, new Guid("714c3e75-5dff-40d3-a73b-62f1eab34ad6"), "زاويه", 26 },
                    { 1237, new Guid("b2447cb8-cd71-44e1-a490-f6f5f522f1a2"), "ياسوج", 31 },
                    { 618, new Guid("f6eb5c3b-73cb-4f57-a06b-51305df7be35"), "انارک", 19 },
                    { 616, new Guid("f529965e-1eed-458c-b0c9-44e5282a3ec6"), "اصفهان", 19 },
                    { 207, new Guid("17d397e9-dea4-450a-9021-f1c5447d9ec0"), "سلامي", 8 },
                    { 206, new Guid("ba24bbec-c11b-47e2-99d8-b50ef295aecb"), "سفيد سنگ", 8 },
                    { 205, new Guid("8d601a76-533a-43ab-bf58-f21984991110"), "سرخس", 8 },
                    { 204, new Guid("ebcdc802-f55e-4c3e-9f40-1134622a7ce2"), "سبزوار", 8 },
                    { 203, new Guid("0162b91b-7563-4f10-8818-a49d6842dde9"), "ريوش", 8 },
                    { 202, new Guid("8df81c05-f2b5-434d-9711-3bcc4d172f1a"), "روداب", 8 },
                    { 201, new Guid("7e48bfbb-eeaf-4e50-b4f6-473a2476a4bb"), "رضويه", 8 },
                    { 200, new Guid("39446868-dbc0-4f39-91d3-5f47262f8f68"), "رشتخوار", 8 },
                    { 199, new Guid("21e2e54d-de3e-427c-afbe-06ba8f8fbf22"), "رباط سنگ", 8 },
                    { 198, new Guid("b39e191a-e33d-4f7f-8a60-611253c76d68"), "دولت آباد", 8 },
                    { 197, new Guid("ff2489e5-1537-4745-a33c-064d7ba91cfa"), "درگز", 8 },
                    { 196, new Guid("44485048-d3b9-4985-bffe-3a71ea78a2c0"), "درود", 8 },
                    { 195, new Guid("763b6a28-15eb-4444-ba00-cff73f2f585b"), "داورزن", 8 },
                    { 194, new Guid("97d42563-451f-4cd5-9f51-ce0f3f672c82"), "خواف", 8 },
                    { 193, new Guid("5195a487-e7de-4c5b-be57-451e88db2468"), "خليل آباد", 8 },
                    { 208, new Guid("b66deb52-4d70-4165-8eec-4db601cd3fc7"), "سلطان آباد", 8 },
                    { 192, new Guid("d40f5a5d-16ad-4d00-9410-d07246e313cd"), "خرو", 8 },
                    { 209, new Guid("7040274f-664c-480a-aed4-d8ddd3077e5f"), "سنگان", 8 },
                    { 211, new Guid("b531f01f-920c-4aae-8a53-b8b06aab8bad"), "شانديز", 8 },
                    { 226, new Guid("53e1d7b3-0fcc-44fe-b109-66eb9c8f15bd"), "لطف آباد", 8 },
                    { 225, new Guid("fe66365e-a8e2-4c4b-9338-b4da32788dec"), "قوچان", 8 },
                    { 224, new Guid("5ba6f2c7-a515-4e8b-a7d6-1e38bc17e597"), "قلندر آباد", 8 },
                    { 223, new Guid("d6ead08d-e07c-4bd8-b5e4-22ab6194547c"), "قدمگاه", 8 },
                    { 222, new Guid("6736fd69-ce47-4f09-8d8f-810e4b5375d6"), "قاسم آباد", 8 },
                    { 221, new Guid("e5c66bb0-b7b3-4e8c-a555-e298d0727042"), "فيض آباد", 8 },
                    { 220, new Guid("937171aa-b32f-4eb7-9881-aa54a8b63d05"), "فيروزه", 8 },
                    { 219, new Guid("89f90289-52e4-4a0f-952d-81c930d3051b"), "فريمان", 8 },
                    { 218, new Guid("1c416c3d-a9a8-44ee-99ff-d402c40b4a8f"), "فرهاد گرد", 8 },
                    { 217, new Guid("6cbe7bf1-3177-41a9-b238-bf07eab2c9a5"), "عشق آباد", 8 },
                    { 216, new Guid("edb303cf-58ea-4950-b067-d5eaf1db1842"), "طرقبه", 8 },
                    { 215, new Guid("225746ef-3cc6-48b9-9089-aa51f8c746cd"), "صالح آباد", 8 },
                    { 214, new Guid("33d16b3a-651f-4edf-9ad0-edcd9b6e3596"), "شهرآباد", 8 },
                    { 213, new Guid("c31b2494-1f35-4fae-a599-e3cb7245704f"), "شهر زو", 8 },
                    { 212, new Guid("078f0a34-bb8d-4ac0-b5e6-f4dd3c82ca35"), "ششتمد", 8 },
                    { 210, new Guid("8a75087a-d208-4efc-b9e5-216785b4e057"), "شادمهر", 8 },
                    { 191, new Guid("dddd4722-e6ae-4a92-8687-eda0a961be87"), "جنگل", 8 },
                    { 190, new Guid("fa6fdf5a-d073-4f1c-892e-7db9c05153c8"), "جغتاي", 8 },
                    { 189, new Guid("784cd82c-f861-4eba-aa01-e5e58038dd4f"), "تربت حيدريه", 8 },
                    { 168, new Guid("8a527bf0-7f51-4a67-a025-fc133359cfee"), "ميرآباد", 7 },
                    { 167, new Guid("f2affd1e-e8a7-456c-9852-7cc4574acc44"), "مياندوآب", 7 },
                    { 166, new Guid("393bb864-2fc5-43ec-8259-5ebad7311279"), "مهاباد", 7 },
                    { 165, new Guid("9825b2bf-8327-423d-8a71-a3a4b48b0ad3"), "مرگنلر", 7 },
                    { 164, new Guid("916ccb99-dac5-4858-b69b-a875d983d495"), "محمود آباد", 7 },
                    { 163, new Guid("e33dd7e1-36b7-426d-b5ba-a2473d1e6539"), "محمد يار", 7 },
                    { 162, new Guid("14573395-5b3f-49df-8894-8f555b09a3e3"), "ماکو", 7 },
                    { 161, new Guid("0038d0ff-3fea-4044-8f6e-839101652770"), "قوشچي", 7 },
                    { 160, new Guid("d8482439-1c90-4c6a-9cde-377ffde8c777"), "قطور", 7 },
                    { 159, new Guid("e57ab929-3daf-470a-b227-8c7fd8434411"), "قره ضياء الدين", 7 },
                    { 158, new Guid("f0c5babc-15a5-48fa-bb27-f75cd46f35c1"), "فيرورق", 7 },
                    { 157, new Guid("3fff75e2-8996-457f-8b50-9efce0039c8e"), "شوط", 7 },
                    { 156, new Guid("904fbbd8-543f-4733-9ecd-21688c2fe299"), "شاهين دژ", 7 },
                    { 155, new Guid("2beae373-adca-4cd8-8f62-8f55f17be369"), "سيه چشمه", 7 },
                    { 154, new Guid("ae1e799d-1b51-43fe-906d-b82069728a0a"), "سيمينه", 7 },
                    { 169, new Guid("4ace97ce-874f-4746-a954-daff05fec4ff"), "نازک عليا", 7 },
                    { 170, new Guid("82b363c9-f6b9-4abb-b398-e6fbaf3201d3"), "نالوس", 7 },
                    { 171, new Guid("57bc8399-b19b-453b-875f-089f8482bd31"), "نقده", 7 },
                    { 172, new Guid("1a83dac5-23bb-4836-9b5e-d978bfe47045"), "نوشين", 7 },
                    { 188, new Guid("8f08229d-580b-40cc-ba28-78ae5259ef33"), "تربت جام", 8 },
                    { 187, new Guid("d2a16a3a-e9f8-4de7-ac8e-cd7e8fd3bf52"), "تايباد", 8 },
                    { 186, new Guid("aabd7789-f531-4290-bdcb-3d486a773b76"), "بيدخت", 8 },
                    { 185, new Guid("043f0eae-401f-49b5-a2d2-b8934d5f5a26"), "بردسکن", 8 },
                    { 184, new Guid("c3bf0611-b3c2-4369-bf3f-57e0d394346b"), "بجستان", 8 },
                    { 183, new Guid("290eb3b2-3801-4bcb-90c3-235c2164bba2"), "بايک", 8 },
                    { 182, new Guid("57411221-a16b-40da-98c4-8089152be940"), "بار", 8 },
                    { 227, new Guid("7fd404ae-e91a-4f80-9884-1b287efbf279"), "مزدآوند", 8 },
                    { 181, new Guid("89a2e9ef-30b5-439b-b51d-65d433989466"), "باخرز", 8 },
                    { 179, new Guid("e511bd3a-cd19-47cf-8d83-1f4010409b9c"), "انابد", 8 },
                    { 178, new Guid("7dd247ae-67b0-4489-8482-5a1cf33ea8ad"), "احمدآباد صولت", 8 },
                    { 177, new Guid("d7307557-1778-44b6-8534-1948b9bb8be6"), "گردکشانه", 7 },
                    { 176, new Guid("e0ea615e-c5a4-4f96-93c8-543f437e72af"), "کشاورز", 7 },
                    { 175, new Guid("f9fe4a54-0be5-41cb-bcc6-fd20f3b0a92a"), "چهار برج", 7 },
                    { 174, new Guid("58d66504-7847-4463-a86f-4c57434c49c1"), "پيرانشهر", 7 },
                    { 173, new Guid("6bd0e3f1-3203-4cf1-ad8a-5c553327f55d"), "پلدشت", 7 },
                    { 180, new Guid("4c2683c9-3e2d-4e47-ba3a-e5765ea21237"), "باجگيران", 8 },
                    { 228, new Guid("0601b62f-3094-4538-b5db-cda2fe11e97a"), "مشهد", 8 },
                    { 229, new Guid("79028a3b-8bc8-4fea-ad00-00780c4c0cfa"), "مشهدريزه", 8 },
                    { 230, new Guid("8c216bb9-dc39-479b-82af-a5154406e938"), "ملک آباد", 8 },
                    { 284, new Guid("2fb464fc-75f6-41b4-97e7-2a7eaf77610e"), "کنارک", 9 },
                    { 283, new Guid("9b94b080-f82b-4699-8399-57a92e6d618b"), "چاه بهار", 9 },
                    { 282, new Guid("6a6fb4a8-5501-4e22-8453-832873b3af12"), "پيشين", 9 },
                    { 281, new Guid("499dc690-ecee-49af-a756-7a32e03b5c93"), "هيدوچ", 9 },
                    { 280, new Guid("f2b013e3-e1ea-4783-9b4a-ed50a222dd1e"), "نگور", 9 },
                    { 279, new Guid("cf09045e-deb2-4601-96bf-9b9f560001fa"), "نيک شهر", 9 },
                    { 278, new Guid("3832e5dc-e8bf-4c12-bb7b-c0d57019e71f"), "نوک آباد", 9 },
                    { 277, new Guid("3b9eba3c-3974-42b6-b0bf-c24c474d2225"), "نصرت آباد", 9 },
                    { 276, new Guid("3fcc82d8-ff18-4367-aa21-06307985e133"), "ميرجاوه", 9 },
                    { 275, new Guid("09053cd2-5619-4ab4-86f9-178248a9e77f"), "مهرستان", 9 },
                    { 274, new Guid("26baefc5-3658-42e1-9d12-9d779f25182a"), "محمدي", 9 },
                    { 273, new Guid("c319ad67-e274-48eb-a3f7-f43b773e2af3"), "محمدان", 9 },
                    { 272, new Guid("8dc167c3-8278-466d-ad27-3fdf771ad4ac"), "محمد آباد", 9 },
                    { 271, new Guid("60ff82fd-706d-4c72-849d-25b1d866adf9"), "قصر قند", 9 },
                    { 270, new Guid("cad173c9-8e60-4a96-9e32-6f64e04a9eb9"), "فنوج", 9 },
                    { 285, new Guid("dbcd012f-9317-4775-b133-c4d466b9d059"), "گشت", 9 },
                    { 286, new Guid("83dbd760-da57-4eff-a573-7e79e234ed90"), "گلمورتي", 9 },
                    { 287, new Guid("fc5228cb-ae34-42e6-bab8-f643afe42525"), "آرين شهر", 10 },
                    { 288, new Guid("2fdee690-a90d-4c1f-9c07-91970b960e47"), "آيسک", 10 },
                    { 304, new Guid("03c5abd2-7486-4a9d-a618-c0f0cc7b0479"), "طبس", 10 },
                    { 303, new Guid("d36bb250-0fcd-45f5-b3c0-6e7eb0a8f0c1"), "شوسف", 10 },
                    { 302, new Guid("719b0eb3-6a1e-4b15-9f81-aa222b146ba2"), "سه قلعه", 10 },
                    { 301, new Guid("93358e70-c5dd-4f9b-965d-f633e07f7dfe"), "سربيشه", 10 },
                    { 300, new Guid("0203d9cb-36ed-4e4c-8170-2a036374b9ed"), "سرايان", 10 },
                    { 299, new Guid("91cf7141-428c-4c45-903a-4d2fb8c1e698"), "زهان", 10 },
                    { 298, new Guid("91330ee1-1add-4b9a-b26a-bef7db491e01"), "ديهوک", 10 },
                    { 269, new Guid("e92f1e91-f6ea-4653-8010-ed2336bc3faa"), "علي اکبر", 9 },
                    { 297, new Guid("59b4811c-b160-40a5-a11e-ae1c6a34c228"), "خوسف", 10 },
                    { 295, new Guid("56b623b0-20c5-4990-8cc5-7cdbb28a952c"), "حاجي آباد", 10 },
                    { 294, new Guid("e6ab7975-ff63-4c19-9c75-6ec9897e35ea"), "بيرجند", 10 },
                    { 293, new Guid("b183b900-c426-4b60-9314-75313c2a1c09"), "بشرويه", 10 },
                    { 292, new Guid("6d6d0189-7415-469d-9454-3e4a22f2cfd5"), "اسلاميه", 10 },
                    { 291, new Guid("4dfabc19-cbee-4ba3-aea6-c5a74d9b9d54"), "اسفدن", 10 },
                    { 290, new Guid("d8e29a61-d53d-49a7-9436-4ce3ed235981"), "اسديه", 10 },
                    { 289, new Guid("3e49ff30-41d4-46b6-b0e6-ddad262bc37f"), "ارسک", 10 },
                    { 296, new Guid("d341697e-6941-452c-b391-4e119e523319"), "خضري دشت بياض", 10 },
                    { 153, new Guid("18705f31-ff4c-4489-bf8f-c7a36b977119"), "سيلوانه", 7 },
                    { 268, new Guid("c907bef8-d150-477f-963f-e6bf53a5631c"), "سيرکان", 9 },
                    { 266, new Guid("13a2d709-2adf-4799-b360-ccb9a5fbd8a4"), "سرباز", 9 },
                    { 245, new Guid("bba8fb70-322b-4e2e-89ab-1e513b05f520"), "کدکن", 8 },
                    { 244, new Guid("f78b6f9b-fb91-4eee-97f5-4394b890b8f5"), "کاشمر", 8 },
                    { 243, new Guid("dad949a4-5a11-42dc-9bc6-613abf230ac7"), "کاريز", 8 },
                    { 242, new Guid("57a2bd6d-2825-424c-aaff-5fa1a2cce968"), "کاخک", 8 },
                    { 241, new Guid("4fff0aca-6c09-419e-8107-55719e7bbd71"), "چکنه", 8 },
                    { 240, new Guid("452fd5f5-13d3-446b-baae-2d983eda5820"), "چناران", 8 },
                    { 239, new Guid("8b0431eb-e8ad-4396-bb3e-3dd5cb0094e5"), "چاپشلو", 8 },
                    { 238, new Guid("8fb4f554-a47f-4f50-b428-b286e81002fe"), "يونسي", 8 },
                    { 237, new Guid("c6a808ac-2e62-45d7-9c6f-4981e188f1d5"), "همت آباد", 8 },
                    { 236, new Guid("6212ac14-751b-4869-961e-2db96bbf4953"), "نيل شهر", 8 },
                    { 235, new Guid("342080f4-c7b0-48e4-a4eb-21fd2224d17b"), "نيشابور", 8 },
                    { 234, new Guid("f6eeab67-530b-4f93-939c-045bfe652996"), "نوخندان", 8 },
                    { 233, new Guid("6e46e06f-00b5-4811-a0db-b96708965fad"), "نقاب", 8 },
                    { 232, new Guid("8485028e-5394-46f5-9b3a-1fe94d0b91f3"), "نصرآباد", 8 },
                    { 231, new Guid("de43ead4-a591-475a-a586-ecfd6c90c650"), "نشتيفان", 8 },
                    { 246, new Guid("6de74d82-8931-4b99-8413-0989e7ca0883"), "کلات", 8 },
                    { 247, new Guid("746663c9-b292-4dfd-b5b5-d4c307af8e82"), "کندر", 8 },
                    { 248, new Guid("70b18c85-8f68-4474-a927-3f9ea2320e69"), "گلمکان", 8 },
                    { 249, new Guid("822405c8-3067-445c-9f2e-a3862f25387b"), "گناباد", 8 },
                    { 265, new Guid("273b85bc-dc76-41b3-8ece-46e6d1c277cd"), "سراوان", 9 },
                    { 264, new Guid("08ac96fc-e066-44f2-9230-e429ae4b9ad7"), "زهک", 9 },
                    { 263, new Guid("e2b3037b-a5f6-47b8-b511-456d33afdcbf"), "زرآباد", 9 },
                    { 262, new Guid("e80a4f62-95c7-4fad-86e3-3922895eac96"), "زاهدان", 9 },
                    { 261, new Guid("bd3bd494-0811-4628-8e52-30a3173ed589"), "زابل", 9 },
                    { 260, new Guid("b5737fda-7610-4868-96d3-28a25dcd0809"), "راسک", 9 },
                    { 259, new Guid("4ebb36da-f101-4726-a750-2f69cab5b913"), "دوست محمد", 9 },
                    { 267, new Guid("021b0b6a-9757-4372-822a-d0093c6651bc"), "سوران", 9 },
                    { 258, new Guid("2fb6a8ce-cf05-44b6-876c-08a34ca86eea"), "خاش", 9 },
                    { 256, new Guid("db045f8e-7e4c-4f72-9de4-169081407594"), "بنجار", 9 },
                    { 255, new Guid("85b4d977-b35e-40b9-bc47-e9a65d2ba924"), "بنت", 9 },
                    { 254, new Guid("53c518f5-4565-4ffc-9329-ba29d19b164a"), "بمپور", 9 },
                    { 253, new Guid("d8e4c2c1-31e2-4a63-a081-0a3e2afe4f56"), "بزمان", 9 },
                    { 252, new Guid("c48e8408-2bfc-4525-8d4e-78bc5d890cae"), "ايرانشهر", 9 },
                    { 251, new Guid("6e387789-227c-4f90-beea-7e7639e6104f"), "اسپکه", 9 },
                    { 250, new Guid("524ce967-a2fe-4e0c-838d-858f2365e475"), "اديمي", 9 },
                    { 257, new Guid("ac567ab9-e0c7-422d-90e3-f8164b2966c5"), "جالق", 9 },
                    { 305, new Guid("b3d459fa-9b58-4457-bf83-d8e4b1d49258"), "طبس مسينا", 10 },
                    { 152, new Guid("2a228402-f311-41e0-ad60-2833ae3ee64b"), "سلماس", 7 },
                    { 150, new Guid("b6aa8478-9a58-4358-9d9f-2e0a656fc4af"), "سردشت", 7 },
                    { 52, new Guid("c167e1d5-7e8a-4ee8-81a0-0a08f3051549"), "هفشجان", 2 },
                    { 51, new Guid("733f0909-2d75-4b6e-b80e-8778ba349b5d"), "هاروني", 2 },
                    { 50, new Guid("1d8ae8b3-1c84-4ffc-bd45-a8702540219d"), "نقنه", 2 },
                    { 49, new Guid("f5fa206e-29b6-4e4f-9ba0-e2852cb490cc"), "نافچ", 2 },
                    { 48, new Guid("48e84588-a9f1-40c0-8533-21e9ee1e3ba6"), "ناغان", 2 },
                    { 47, new Guid("64fe0cfe-e9db-47be-a642-ce2ff761adbc"), "منج", 2 },
                    { 46, new Guid("f88a1812-297a-489b-af8a-d3db3d8129a4"), "مال خليفه", 2 },
                    { 45, new Guid("8c65b770-1e53-45fe-acf9-18d18b00709e"), "لردگان", 2 },
                    { 44, new Guid("d92365c1-fb14-44d1-bb4a-9b027bdc9595"), "فرخ شهر", 2 },
                    { 43, new Guid("63fd5e60-f6fc-4720-a842-7514b82724cc"), "فرادنبه", 2 },
                    { 42, new Guid("cc88dcee-e528-4a57-85d5-f8d76ff8b5f6"), "فارسان", 2 },
                    { 41, new Guid("60408f14-408c-41c0-b406-9d5731f03b9b"), "طاقانک", 2 },
                    { 40, new Guid("0cd0f68f-e805-4f77-b251-a6c30d190f2b"), "صمصامي", 2 },
                    { 39, new Guid("04bc33be-784e-4cb1-89ac-78c08523d044"), "شهرکرد", 2 },
                    { 38, new Guid("badc1aec-c9bc-4b14-868c-2b23d680d174"), "شلمزار", 2 },
                    { 53, new Guid("8d1bb37e-4908-436c-9f7e-00c8e7338564"), "وردنجان", 2 },
                    { 37, new Guid("c191aab5-52f7-4f0f-bc4a-1273d1713a2b"), "سورشجان", 2 },
                    { 54, new Guid("bbb0f21e-7d1d-4570-b5ea-22deff85cfbe"), "پردنجان", 2 },
                    { 56, new Guid("17a7044c-4d8b-41fa-90c1-12a19d482e70"), "چلگرد", 2 },
                    { 71, new Guid("7ac5a79f-cd6a-4728-9aeb-11c378ea2a16"), "راز", 3 },
                    { 70, new Guid("5c0bd2e4-81bd-4a6b-8dc0-257a319475ee"), "درق", 3 },
                    { 69, new Guid("e437b120-a071-49a1-a282-9eba47061cf1"), "حصارگرمخان", 3 },
                    { 68, new Guid("5907ed65-2393-4364-8bed-5480af0714f3"), "جاجرم", 3 },
                    { 67, new Guid("652b995a-b758-4b45-960a-b8281e0d7699"), "تيتکانلو", 3 },
                    { 66, new Guid("e3469193-1a1f-4dd4-96be-b94d4d001a02"), "بجنورد", 3 },
                    { 65, new Guid("73e74522-fd45-42e6-9bf5-3e944dcae7d5"), "ايور", 3 },
                    { 64, new Guid("51e357fb-7632-4c35-a20a-4827b634e0cc"), "اسفراين", 3 },
                    { 63, new Guid("e92197a4-6c14-4a87-af51-ee3d7290fb13"), "آوا", 3 },
                    { 62, new Guid("fcb44f44-5886-45dd-83cb-614c6619819e"), "آشخانه", 3 },
                    { 61, new Guid("7aa26e56-28d0-4d76-a908-c44baad6603f"), "گوجان", 2 },
                    { 60, new Guid("9088eb10-758f-4ddf-893b-c4202d2f3bd3"), "گهرو", 2 },
                    { 59, new Guid("3029653f-1212-4057-92a8-ee1fd41762f3"), "گندمان", 2 },
                    { 58, new Guid("a6770418-0fef-48bc-8c37-f7ed0dea3b44"), "کيان", 2 },
                    { 57, new Guid("a94efb9d-0bff-4b25-9570-7dc6244a38dd"), "کاج", 2 },
                    { 55, new Guid("3ea114b0-985c-45e7-ac55-e79f03e92c6e"), "چليچه", 2 },
                    { 36, new Guid("43f8b042-7d9a-4bde-b2a8-6f9f114407fe"), "سودجان", 2 },
                    { 35, new Guid("646b6db0-8f5a-4f03-b956-8e0ef3b737d0"), "سفيد دشت", 2 },
                    { 34, new Guid("59871145-1a69-4ef6-86cd-f3f1a889954b"), "سردشت لردگان", 2 },
                    { 13, new Guid("ec7fb5fa-808e-4c3d-ae8b-a6375860308c"), "عقدا", 1 },
                    { 12, new Guid("0f4795c3-945d-4ace-a555-ce1cf906d4b8"), "شاهديه", 1 },
                    { 11, new Guid("9aabe3ff-7fb5-4c73-8e50-11f2146b6c51"), "زارچ", 1 },
                    { 10, new Guid("74946087-ba5d-458b-bae0-cb282f165623"), "خضر آباد", 1 },
                    { 9, new Guid("f4661c33-9239-4780-9636-c726763417ff"), "حميديا", 1 },
                    { 8, new Guid("3d0433ad-2fd5-4762-bc4e-54af1535da7b"), "تفت", 1 },
                    { 7, new Guid("a8fcc214-2516-4317-ace0-61ef66f00dc7"), "بهاباد", 1 },
                    { 6, new Guid("6217f3ab-7034-40a6-a4a2-094cdcb6342c"), "بفروئيه", 1 },
                    { 5, new Guid("1fa1c548-0335-4b8b-ae2b-96c0272cc55c"), "بافق", 1 },
                    { 4, new Guid("ad4f507c-c7a9-4aa9-942b-107fdbe8d8d6"), "اشکذر", 1 },
                    { 3, new Guid("872e5561-bb8f-439f-b1c0-0f347684013c"), "اردکان", 1 },
                    { 2, new Guid("c81b9c9f-09df-44eb-902e-0ed083fdb0df"), "احمد آباد", 1 },
                    { 1, new Guid("c5e8cf07-bc43-4ed2-997b-1c8bcd51c6c2"), "ابرکوه", 1 },
                    { 1240, new Guid("3e7e85f7-f71f-4920-a358-a1a3f43c1a92"), "چيتاب", 31 },
                    { 1241, new Guid("6f30000a-99dc-4fd3-8583-525b4d8d08ea"), "گراب سفلي", 31 },
                    { 14, new Guid("cbfee8cc-934b-42c8-ae0e-76c957605bee"), "مروست", 1 },
                    { 15, new Guid("3ad063fa-ecf4-48d7-af91-d7504bf9b852"), "مهردشت", 1 },
                    { 16, new Guid("69ac7c71-2d76-4973-be83-2b2f0f584ca9"), "مهريز", 1 },
                    { 17, new Guid("ea958c79-0e1c-4392-920e-4a82b3c041b3"), "ميبد", 1 },
                    { 33, new Guid("279a6cf4-b5a5-466d-8b78-804d59755791"), "سرخون", 2 },
                    { 32, new Guid("951e9426-c039-4934-b81a-b72e24b67574"), "سامان", 2 },
                    { 31, new Guid("0de53afe-7d7f-4507-8fd7-da4bc53cf2d1"), "دشتک", 2 },
                    { 30, new Guid("fd51919d-e896-45d8-9bae-eefcb5ece0e4"), "دستناء", 2 },
                    { 29, new Guid("a8e5f945-cbad-4fb8-9df2-c4387cf10aa0"), "جونقان", 2 },
                    { 28, new Guid("c246e310-2d53-465a-8170-f797529c87de"), "بن", 2 },
                    { 27, new Guid("fb72c747-f672-474e-b3e9-4722e9d50366"), "بلداجي", 2 },
                    { 72, new Guid("f44214f2-6993-404e-9f4b-0c962aa5f995"), "زيارت", 3 },
                    { 26, new Guid("9935c7bc-1605-4a8b-843a-0ac67d39d632"), "بروجن", 2 },
                    { 24, new Guid("9ceb4cf0-055e-4d1e-aedc-c6315378a21c"), "باباحيدر", 2 },
                    { 23, new Guid("0047cbfe-a0f6-451e-a835-cd7f47f10de8"), "اردل", 2 },
                    { 22, new Guid("e3d631bc-3c65-4f96-9a5b-e8c6502d24fa"), "آلوني", 2 },
                    { 21, new Guid("3ac9d1b6-c16a-45a8-82b5-a4a46f3227c7"), "يزد", 1 },
                    { 20, new Guid("173323d8-26ce-4d42-90d4-7e27246089fb"), "هرات", 1 },
                    { 19, new Guid("90bab573-930f-4c88-8018-77cba5bbc6e2"), "نير", 1 },
                    { 18, new Guid("5054abc7-bfa6-423c-beac-1740f9068ce2"), "ندوشن", 1 },
                    { 25, new Guid("bbfe1d9c-b426-4aff-a77d-83dcce32be73"), "بازفت", 2 },
                    { 73, new Guid("3e519a2c-d1ba-4922-8f6a-9416ae9907cc"), "سنخواست", 3 },
                    { 74, new Guid("39c7bd86-c0e1-475f-97f2-4c43390ff143"), "شوقان", 3 },
                    { 75, new Guid("f99b8a06-a839-433c-b236-48753a9535f3"), "شيروان", 3 },
                    { 129, new Guid("d4d712b7-c1be-4fe4-8fad-7b51828094b4"), "موچش", 6 },
                    { 128, new Guid("3e035c9b-a930-446b-ac4b-a58e3e5a50e3"), "مريوان", 6 },
                    { 127, new Guid("7c464b7e-197a-4cd9-8e0f-2e40499a1ed1"), "قروه", 6 },
                    { 126, new Guid("2531ebd5-c028-4307-806d-f1cd32c3a38e"), "صاحب", 6 },
                    { 125, new Guid("ad3865f4-d790-403d-b054-4f515afb5a0e"), "شويشه", 6 },
                    { 124, new Guid("b098b7b1-7df9-4360-a084-99c5bc1c63e7"), "سنندج", 6 },
                    { 123, new Guid("c44b7a75-2ec5-4eb4-a47e-09bee52fa02a"), "سقز", 6 },
                    { 122, new Guid("c2adb5f3-3572-41db-addb-db5a597a6765"), "سريش آباد", 6 },
                    { 121, new Guid("2b961478-2899-4816-b703-db2205b5961b"), "سرو آباد", 6 },
                    { 120, new Guid("9b4e86a5-e277-4faa-9a79-d1b164de6e12"), "زرينه", 6 },
                    { 119, new Guid("84b03c32-4f0d-4f70-bdf7-0d8ca150d6ef"), "ديواندره", 6 },
                    { 118, new Guid("0fe2e38c-8dc2-4757-90d3-b8d5e599f2c3"), "دهگلان", 6 },
                    { 117, new Guid("729eb3db-5cbb-42da-9ab7-d22ce6e204b7"), "دلبران", 6 },
                    { 116, new Guid("12ad27cf-d136-4b0a-a0fc-4329e19051cc"), "دزج", 6 },
                    { 115, new Guid("92156f2e-ed22-4f6b-84e9-193a42086585"), "توپ آغاج", 6 },
                    { 130, new Guid("238cabe0-2359-4d89-9678-bf352a589f46"), "ياسوکند", 6 },
                    { 131, new Guid("b35f200b-ccac-4965-9207-b7419561fb36"), "پيرتاج", 6 },
                    { 132, new Guid("6d0b9b03-ecd4-4322-8d8e-c9113cf6811d"), "چناره", 6 },
                    { 133, new Guid("0f67a3e5-862a-4e4e-be8b-b3b8739fcb77"), "کامياران", 6 },
                    { 149, new Guid("c3aebc28-9a10-402c-bd69-ff4fc6593d7d"), "زرآباد", 7 },
                    { 148, new Guid("7f4b9e72-29b3-4e8e-b6c1-6027d8237bba"), "ربط", 7 },
                    { 147, new Guid("85ac133d-7834-4324-a78b-2562746072db"), "ديزج ديز", 7 },
                    { 146, new Guid("e303d637-05f4-4da6-870f-4ba2ba8115d0"), "خوي", 7 },
                    { 145, new Guid("63524922-a064-470d-a7db-0c2df1daf79f"), "خليفان", 7 },
                    { 144, new Guid("a22bd96c-6487-4268-8f4c-dbc0f2222d3d"), "تکاب", 7 },
                    { 143, new Guid("bf39a3e1-7cfd-41b1-b8ec-6cf875ae9b2a"), "تازه شهر", 7 },
                    { 114, new Guid("ca53be48-32c2-4d3c-9be5-66c902951d5a"), "بيجار", 6 },
                    { 142, new Guid("d9e12a52-02cb-4770-a6eb-c8873350bdc1"), "بوکان", 7 },
                    { 140, new Guid("c204bd6a-d02a-4d0a-af81-baf65e52e40e"), "باروق", 7 },
                    { 139, new Guid("37089b8f-ec70-43a6-a69e-21f5e932f90f"), "ايواوغلي", 7 },
                    { 138, new Guid("9603c333-2327-4b0d-864c-e21a19a28166"), "اشنويه", 7 },
                    { 137, new Guid("2dd3eacc-4dea-4557-ac23-a884d356f63f"), "اروميه", 7 },
                    { 136, new Guid("3956ffc4-e45f-4493-85a3-ec5591cef664"), "آواجيق", 7 },
                    { 135, new Guid("95f7f675-b920-4264-8539-e92094d3f24d"), "کاني سور", 6 },
                    { 134, new Guid("eb906253-e31a-4912-9c95-e355fc841a7f"), "کاني دينار", 6 },
                    { 141, new Guid("56170ea7-cfe4-4e5d-9cb9-7dab0018a417"), "بازرگان", 7 },
                    { 151, new Guid("4b162830-17ef-4930-9741-2507fb07bd94"), "سرو", 7 },
                    { 113, new Guid("1b21c56e-c6c5-4e2f-b3d6-4a74b779b2c1"), "بوئين سفلي", 6 },
                    { 111, new Guid("719b8e3e-faa4-4fd0-b475-e5252070d321"), "برده رشه", 6 },
                    { 90, new Guid("b5c26042-46f9-42f4-aa78-a92e96c408bf"), "ماهدشت", 4 },
                    { 89, new Guid("063a9c62-7c92-4e23-bd3e-4a3c2cce05b6"), "فرديس", 4 },
                    { 88, new Guid("ac6e3a35-ec8f-46c0-bb40-56330bec0485"), "طالقان", 4 },
                    { 87, new Guid("a9e461d7-1252-4d25-80e9-b7d15c7786de"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("0cdbc9bd-cd00-41b5-aed0-9deb110c29be"), "تنکمان", 4 },
                    { 85, new Guid("0329f880-d8ab-4e39-9b41-e9cfdd2f4943"), "اشتهارد", 4 },
                    { 84, new Guid("598c6e73-3a33-4445-82d8-a66042f944c9"), "آسارا", 4 },
                    { 83, new Guid("cdd41ab9-493b-4a70-a1bb-5015c0faede6"), "گرمه", 3 },
                    { 82, new Guid("d9bc0903-4ff1-4a00-8b71-a9dfcaf8f2b7"), "چناران شهر", 3 },
                    { 81, new Guid("d73c9a82-11b5-4b5a-a1f4-7037e749d5c0"), "پيش قلعه", 3 },
                    { 80, new Guid("5466e043-a9e8-43ad-8560-8c9dc644612c"), "لوجلي", 3 },
                    { 79, new Guid("efc037b3-ef16-48c7-b816-26c40083a8c2"), "قوشخانه", 3 },
                    { 78, new Guid("05da27d0-188c-4e55-a850-e8ec36c9f38e"), "قاضي", 3 },
                    { 77, new Guid("f7a5d9a0-d11e-4bb5-9360-af67ff6b8b11"), "فاروج", 3 },
                    { 76, new Guid("1c83f62c-7390-4dbc-856a-6c5cbb9f2074"), "صفي آباد", 3 },
                    { 91, new Guid("bb920123-c228-4a99-88b3-ed1362df0b88"), "محمد شهر", 4 },
                    { 92, new Guid("6cb27c07-32d5-4eda-92f6-9a704b976067"), "مشکين دشت", 4 },
                    { 93, new Guid("3471f390-da42-4546-bc90-f04a90b57944"), "نظر آباد", 4 },
                    { 94, new Guid("13dd6f66-1942-428f-af6b-1bfabb047ace"), "هشتگرد", 4 },
                    { 110, new Guid("4071c4df-5d16-4d54-ac6d-78afdbedf489"), "بانه", 6 },
                    { 109, new Guid("d8e32973-fc11-4f47-8279-acdebdc5edd3"), "بابارشاني", 6 },
                    { 108, new Guid("5d7c5bd6-0d1f-4dd2-8847-d3a5540c2a8a"), "اورامان تخت", 6 },
                    { 107, new Guid("9807184a-eeff-4b21-89ae-ace429e52c23"), "آرمرده", 6 },
                    { 106, new Guid("dde0757c-ada8-4a99-81a3-efba68f8d366"), "کهک", 5 },
                    { 105, new Guid("603c17e1-d16b-4b59-a8b6-823447285715"), "قنوات", 5 },
                    { 104, new Guid("8c312d70-3bdf-45bd-b31a-06f5fd9489c4"), "قم", 5 },
                    { 112, new Guid("7bcb2f1d-8028-4a37-bfdc-ce60ba7db2a6"), "بلبان آباد", 6 },
                    { 103, new Guid("f3b80413-6858-4e3b-bccb-86ce4124c52d"), "سلفچگان", 5 },
                    { 101, new Guid("31b5f956-9374-4f40-b3a1-0e21271b8b47"), "جعفريه", 5 },
                    { 100, new Guid("567ce51f-842b-4028-8678-44a32a428151"), "گلسار", 4 },
                    { 99, new Guid("f2966485-3e09-40d4-942e-cbeab4fcc877"), "گرمدره", 4 },
                    { 98, new Guid("deebb865-4951-49fa-b695-9dd251fe8d32"), "کوهسار", 4 },
                    { 97, new Guid("285e6fd9-2635-4be5-930c-25d2b94289e0"), "کمال شهر", 4 },
                    { 96, new Guid("c1af50b6-57f7-4daf-bc08-07822e759986"), "کرج", 4 },
                    { 95, new Guid("f92da4f8-525f-47c2-8149-bc2074fd483f"), "چهارباغ", 4 },
                    { 102, new Guid("5e207c0f-d9d9-4161-af2d-666833954d1a"), "دستجرد", 5 },
                    { 306, new Guid("cc334c6f-3ec8-42fe-ad4f-65e35568bf37"), "عشق آباد", 10 },
                    { 307, new Guid("deb281eb-6edd-46ce-b130-ac005bb24c89"), "فردوس", 10 },
                    { 308, new Guid("aa645b01-c79a-4104-afed-ab3df38bb987"), "قائن", 10 },
                    { 518, new Guid("1003fe22-f6b1-41ee-b75d-eaddeb60dc19"), "هادي شهر", 15 },
                    { 517, new Guid("2ab4734d-1902-4088-9d9b-0de2722e4a35"), "نکا", 15 },
                    { 516, new Guid("3c6ddcb8-d522-4ce2-bada-1d28d1c42e3b"), "نوشهر", 15 },
                    { 515, new Guid("b4173481-3708-4522-93b8-806731d2b11a"), "نور", 15 },
                    { 514, new Guid("d617c27a-6f03-41c5-8ff1-6c8d9a4ded44"), "نشتارود", 15 },
                    { 513, new Guid("3f4a5b97-28e0-45c7-8889-d6c1f0716b12"), "مرزيکلا", 15 },
                    { 512, new Guid("84f8beab-b435-4c67-bda6-5572e6531355"), "مرزن آباد", 15 },
                    { 511, new Guid("d0d940c4-0bef-4974-aba4-230d298dd1e8"), "محمود آباد", 15 },
                    { 510, new Guid("d417c29e-490c-471c-abf9-1c852346055e"), "قائم شهر", 15 },
                    { 509, new Guid("52a397d7-abbe-4a5c-ae05-df897768aef3"), "فريم", 15 },
                    { 508, new Guid("6748ff44-aec3-4da7-b553-6abd91ef8c57"), "فريدونکنار", 15 },
                    { 507, new Guid("49b6e202-12a0-442f-a23b-56d206e98746"), "عباس آباد", 15 },
                    { 506, new Guid("00608551-2899-4af8-af56-03dca037e609"), "شيرگاه", 15 },
                    { 505, new Guid("0ff827d4-3556-400e-9119-ad1df69d6939"), "شيرود", 15 },
                    { 504, new Guid("7cc3fdee-8c92-479c-8a83-113ee01cd3b7"), "سورک", 15 },
                    { 519, new Guid("ee06922f-c937-4cd9-ae35-95b2c17c0da1"), "هچيرود", 15 },
                    { 503, new Guid("c3bcdc2c-1d24-45f4-b2cc-e149cd04d57f"), "سلمان شهر", 15 },
                    { 520, new Guid("b7288630-643d-4b89-87e6-8d7553f8d1d9"), "پايين هولار", 15 },
                    { 522, new Guid("e82535f1-a376-498f-9895-d96ed4230ca4"), "پول", 15 },
                    { 537, new Guid("22c51ede-6884-4f20-b33c-ddac60716676"), "آوج", 16 },
                    { 536, new Guid("0135cfcc-b11a-4955-aeb5-0204fc7db8b9"), "آبگرم", 16 },
                    { 535, new Guid("59912653-55f5-418f-8868-3e82dbaac27e"), "آبيک", 16 },
                    { 534, new Guid("fb95eaac-c2d9-48ab-a400-b78eb225f912"), "گلوگاه", 15 },
                    { 533, new Guid("4ee54ecd-462f-4645-af3f-c1c0d5eff428"), "گزنک", 15 },
                    { 532, new Guid("44a2fd8a-4fc0-4981-a6fe-09c21214c459"), "گتاب", 15 },
                    { 531, new Guid("33952a1d-0f3c-4c47-9cd4-e8ad94884348"), "کياکلا", 15 },
                    { 530, new Guid("28fb220d-5848-4223-a88d-47a0340ff9d7"), "کياسر", 15 },
                    { 529, new Guid("440a150c-b361-4f79-9a63-df1f9e1cf67f"), "کوهي خيل", 15 },
                    { 528, new Guid("f71e3bc3-5ff1-47fb-9d24-b7b0ddbfb9d3"), "کلاردشت", 15 },
                    { 527, new Guid("a5d2eb6f-6e0f-40b1-a24b-7ff7aa9d716e"), "کلارآباد", 15 },
                    { 526, new Guid("163d714c-d112-475b-b395-bc45d44dc724"), "کجور", 15 },
                    { 525, new Guid("6fbe3dbf-4568-4fbb-ba50-802f51a39a92"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("e2de1d8d-c7f0-44c5-99b1-30d3289ce7eb"), "چمستان", 15 },
                    { 523, new Guid("f89e8c90-32ef-4a66-95b3-074a29197c5e"), "چالوس", 15 },
                    { 521, new Guid("7422fa79-4738-4ebc-8257-dc7d27b3509b"), "پل سفيد", 15 },
                    { 502, new Guid("bf74ded8-8363-45e6-804d-e64f1e901b5d"), "سرخرود", 15 },
                    { 501, new Guid("980c3600-3971-4cb6-ac87-761420d4b5d0"), "ساري", 15 },
                    { 500, new Guid("cfbe85b9-17d4-4c4b-9cb3-17b62259111f"), "زيرآب", 15 },
                    { 479, new Guid("b46a9b06-aeb7-4579-8fb9-d757a24c50d2"), "آمل", 15 },
                    { 478, new Guid("e5750c2a-e63e-4d8d-95c0-3d1ffff842cf"), "آلاشت", 15 },
                    { 477, new Guid("81fe46f0-0c6c-4c0a-9967-482a51f6e693"), "گنبدکاووس", 14 },
                    { 476, new Guid("7a1abbcb-93c1-4343-a205-2d2e1e36b37c"), "گميش تپه", 14 },
                    { 475, new Guid("59fce237-dc49-4609-ac81-5a6ac3753bf4"), "گرگان", 14 },
                    { 474, new Guid("7f5db8a6-fd82-4cf4-b3e8-83903b7b77ec"), "گاليکش", 14 },
                    { 473, new Guid("bb7c51ce-a469-4447-a4b4-0f2091980677"), "کلاله", 14 },
                    { 472, new Guid("ea5128b0-5f0b-4608-8112-939ff9420ecc"), "کرد کوي", 14 },
                    { 471, new Guid("f1b4295f-e3b2-4e2b-8d64-0c734b3c1943"), "نگين شهر", 14 },
                    { 470, new Guid("334cb221-7545-4574-9889-a6a004f8eeb7"), "نوکنده", 14 },
                    { 469, new Guid("73666f4e-1dcc-4954-a3b4-ba401e56c540"), "نوده خاندوز", 14 },
                    { 468, new Guid("1144628a-db4a-487f-a9b3-4c0732995b16"), "مينودشت", 14 },
                    { 467, new Guid("8472719a-1681-4dd0-9ac2-c772897c349b"), "مزرعه", 14 },
                    { 466, new Guid("2e07a4ac-c35b-4aad-b969-c77c75aefc98"), "مراوه تپه", 14 },
                    { 465, new Guid("13b8d249-79cf-4f94-a2fc-0cd797be85d6"), "فراغي", 14 },
                    { 480, new Guid("5f763c25-a18b-4fe5-9538-cf9d81f9afc2"), "ارطه", 15 },
                    { 481, new Guid("182a6028-0f67-4e5a-8114-1dd88a520c17"), "امامزاده عبدالله", 15 },
                    { 482, new Guid("f7afd835-974e-4b91-b9be-a46ea1b001fa"), "امير کلا", 15 },
                    { 483, new Guid("a7e0a6fa-98c7-4d7e-b5d9-16463f65aaa9"), "ايزد شهر", 15 },
                    { 499, new Guid("81b9afb6-9304-4239-a90c-3df210eea29d"), "زرگر محله", 15 },
                    { 498, new Guid("fecf9cb4-7f13-43e9-ac0e-a731b3b979d8"), "رينه", 15 },
                    { 497, new Guid("c907b000-4ac1-47b9-91c2-5af65c6ef6fa"), "رويان", 15 },
                    { 496, new Guid("2236e88a-ba2d-479a-a063-1003a4f46408"), "رستمکلا", 15 },
                    { 495, new Guid("b9a450c7-aeff-491a-aec5-ed4d7b76bb53"), "رامسر", 15 },
                    { 494, new Guid("ec2e5079-68ef-48ce-b069-72e5eda3d634"), "دابودشت", 15 },
                    { 493, new Guid("62d404a7-44d5-4e76-846a-67caa4777045"), "خوش رودپي", 15 },
                    { 538, new Guid("06f4f750-dba2-41a2-8633-356c932389bf"), "ارداق", 16 },
                    { 492, new Guid("f7415342-3bf2-4fba-9950-441996ee2bbf"), "خليل شهر", 15 },
                    { 490, new Guid("a5ac9c46-30ad-4024-b702-c3fa2521782e"), "جويبار", 15 },
                    { 489, new Guid("160caf80-ff51-4bb1-9f36-f3e4d932e0a9"), "تنکابن", 15 },
                    { 488, new Guid("8cdb0161-d544-460c-b8b7-5de11628bacb"), "بهنمير", 15 },
                    { 487, new Guid("01395bac-3565-430a-aec3-34b5de715347"), "بهشهر", 15 },
                    { 486, new Guid("d4ed0919-d40c-4b0b-a169-319896f55e09"), "بلده", 15 },
                    { 485, new Guid("431ca4dd-6413-4e22-8544-6f3ed33d41ee"), "بابلسر", 15 },
                    { 484, new Guid("7f5572ce-f4ce-4199-8961-4128db294777"), "بابل", 15 },
                    { 491, new Guid("61b79461-da0f-495c-99ff-3f340f703c6a"), "خرم آباد", 15 },
                    { 539, new Guid("addf9d3c-1c02-4659-a0ea-9c488e1dd338"), "اسفرورين", 16 },
                    { 540, new Guid("f5b19512-9d7e-4e86-92af-9d41b75c63f6"), "اقباليه", 16 },
                    { 541, new Guid("ffefb4e7-625f-4131-9632-eaa2325802d0"), "الوند", 16 },
                    { 595, new Guid("3c058c61-9355-400b-b7ed-fbacefd502d0"), "سرعين", 18 },
                    { 594, new Guid("0da2064b-279e-4219-b7a8-9c11113d76db"), "رضي", 18 },
                    { 593, new Guid("02fa9f27-da07-456f-9856-34b06b6489e7"), "خلخال", 18 },
                    { 592, new Guid("d6a90fd9-0497-4b9d-a4ac-eb4bb5358824"), "جعفر آباد", 18 },
                    { 591, new Guid("799d0d17-9963-4829-92b1-46e147b9d76f"), "تازه کند انگوت", 18 },
                    { 590, new Guid("15cd2c44-a563-48bc-9fbb-a1782d8bf947"), "تازه کند", 18 },
                    { 589, new Guid("0042065f-2276-4908-b928-8c94766d4002"), "بيله سوار", 18 },
                    { 588, new Guid("0f67e2e5-14bc-4c24-a83f-8f783cf4a97e"), "اصلاندوز", 18 },
                    { 587, new Guid("219eceb9-e4f5-4775-b437-6b2a93fc3296"), "اسلام آباد", 18 },
                    { 586, new Guid("b5778b3c-cc7e-4942-b159-4fd0d7cdb701"), "اردبيل", 18 },
                    { 585, new Guid("959d3cb4-6dcc-48de-9224-7fc241170d83"), "آبي بيگلو", 18 },
                    { 584, new Guid("97f98f74-8e90-434c-a5d8-d44f2c9388cb"), "گراب", 17 },
                    { 583, new Guid("aa072cbb-c7d0-47b9-908e-15b850329ff8"), "کوهناني", 17 },
                    { 582, new Guid("5ebfd079-c24e-45ea-894e-f50189fa72b4"), "کوهدشت", 17 },
                    { 581, new Guid("17327b12-a44a-4dcf-b346-225a7f3bff9f"), "چقابل", 17 },
                    { 596, new Guid("fb09204b-a3cf-43c3-9955-81a895f9a8b9"), "عنبران", 18 },
                    { 597, new Guid("a75e16b4-7df8-4e60-bc5c-38e9bc321330"), "فخرآباد", 18 },
                    { 598, new Guid("8714987b-f153-4f14-9036-6ead87701c76"), "قصابه", 18 },
                    { 599, new Guid("4dd12737-c48a-4f69-b44c-49e8ad69a0a8"), "لاهرود", 18 },
                    { 615, new Guid("b35ee168-57dc-4f10-96d5-37238cc8174d"), "اصغرآباد", 19 },
                    { 614, new Guid("baee765d-1404-4835-a06b-fee8bdf44dcc"), "اردستان", 19 },
                    { 613, new Guid("debd3627-842f-4430-a334-4b560b6c835d"), "ابوزيد آباد", 19 },
                    { 612, new Guid("e25984df-30a4-40c6-9a49-9db9266a00dd"), "ابريشم", 19 },
                    { 611, new Guid("10a20104-b13d-48ba-809d-f4a77653086f"), "آران و بيدگل", 19 },
                    { 610, new Guid("46c5da91-3d7b-45c8-b641-5a7b69e1a398"), "گيوي", 18 },
                    { 609, new Guid("1b5153a3-db61-4d5f-9830-558d047e015d"), "گرمي", 18 },
                    { 580, new Guid("7dc333aa-0aeb-4948-b372-ef8235159545"), "چالانچولان", 17 },
                    { 608, new Guid("578df3ca-076d-4e5f-bee6-9fe546032049"), "کورائيم", 18 },
                    { 606, new Guid("55019a3c-8672-4d1d-81e2-144235b4d0c1"), "پارس آباد", 18 },
                    { 605, new Guid("568c2368-5a14-4871-9fe1-baaa12f6df4f"), "هير", 18 },
                    { 604, new Guid("29ebd694-ba80-462e-a93a-e850cb179f02"), "هشتجين", 18 },
                    { 603, new Guid("a51f1bde-d020-4976-9a7e-733d1f5a06ff"), "نير", 18 },
                    { 602, new Guid("fadf2c04-673c-42d4-8935-5274b55563e7"), "نمين", 18 },
                    { 601, new Guid("a9463d68-3b2d-4124-9f9d-8bd4404904ff"), "مشگين شهر", 18 },
                    { 600, new Guid("b6f18eb0-144e-49af-8531-38d0bcb83f41"), "مرادلو", 18 },
                    { 607, new Guid("ecbe4c11-5352-4772-9bef-39afd89d3187"), "کلور", 18 },
                    { 464, new Guid("d3581f28-b7aa-444c-88bb-9d16019de4cb"), "فاضل آباد", 14 },
                    { 579, new Guid("a1673a00-8a3e-4239-ab3d-cb3011604577"), "پلدختر", 17 },
                    { 577, new Guid("53b218d4-4c17-484c-9a95-641858e00625"), "هفت چشمه", 17 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 556, new Guid("8a775496-205e-4421-9a86-99a7ba3994a2"), "محمود آباد نمونه", 16 },
                    { 555, new Guid("e7c04a9b-c1aa-49cd-9f14-8e7b519ef469"), "محمديه", 16 },
                    { 554, new Guid("cec88ea1-cdf9-4160-9ceb-f4862ee33a32"), "قزوين", 16 },
                    { 553, new Guid("72dcd6f3-cf9d-4fec-bc8e-d22ec1a983f4"), "ضياء آباد", 16 },
                    { 552, new Guid("d63b46c9-5b09-470e-86db-2299898df486"), "شريفيه", 16 },
                    { 551, new Guid("0d4f2f19-d15e-4dca-a684-f4b05e85b225"), "شال", 16 },
                    { 550, new Guid("3fda85b2-bc83-4b42-a086-3339fb265964"), "سگز آباد", 16 },
                    { 549, new Guid("7e4f6bcc-ff1b-40bc-aa5e-0b581840d398"), "سيردان", 16 },
                    { 548, new Guid("e3cd0755-b3ea-4179-bf99-5d587f19fd31"), "رازميان", 16 },
                    { 547, new Guid("87e33235-56a5-423f-9144-0e064c76513a"), "دانسفهان", 16 },
                    { 546, new Guid("fea8f565-8c75-4581-a9b0-132edaaefd0b"), "خرمدشت", 16 },
                    { 545, new Guid("17301a59-df37-4ee1-b26c-ae04505ce67d"), "خاکعلي", 16 },
                    { 544, new Guid("bc77370b-5e92-4a2d-bee9-d26a13b4c7f8"), "تاکستان", 16 },
                    { 543, new Guid("a89e2aca-ad0c-4e7c-b20d-3ad8cf4a7125"), "بيدستان", 16 },
                    { 542, new Guid("d8da4d44-0d87-4709-80a6-5f935e3f35fe"), "بوئين زهرا", 16 },
                    { 557, new Guid("23476476-5ea2-4f9c-8c92-98b8daee1b85"), "معلم کلايه", 16 },
                    { 558, new Guid("056a523e-1c3e-42a9-86b3-15540eddd1fb"), "نرجه", 16 },
                    { 559, new Guid("c3a713e7-41e6-4c84-95ff-b4bc60dab84c"), "کوهين", 16 },
                    { 560, new Guid("1bef3d81-4f6a-452b-9e18-65e3c6c2897e"), "ازنا", 17 },
                    { 576, new Guid("34a56e42-d59e-4b78-b790-36b082d9a7be"), "نورآباد", 17 },
                    { 575, new Guid("0ba99d4b-9fac-4c6e-9a03-f5ba2e4fc675"), "مومن آباد", 17 },
                    { 574, new Guid("f6d929e4-c8b3-4797-951d-465ed1998e5b"), "معمولان", 17 },
                    { 573, new Guid("8f4d8599-57d8-40be-8bdc-da0e5aa0f6b2"), "فيروزآباد", 17 },
                    { 572, new Guid("004d0a10-cf4b-4167-883c-d5585d8490a4"), "شول آباد", 17 },
                    { 571, new Guid("679d8ec0-9228-43d6-a064-168510d85b55"), "سپيد دشت", 17 },
                    { 570, new Guid("44aea5ab-2c39-4baa-8c8c-05da8f890bc2"), "سراب دوره", 17 },
                    { 578, new Guid("baa4df76-8190-45c4-8d1d-d4103b7f2134"), "ويسيان", 17 },
                    { 569, new Guid("ce135df2-0221-4515-8d31-8b80f4122e66"), "زاغه", 17 },
                    { 567, new Guid("f987c125-58d6-4233-8e3c-32cb252a2814"), "درب گنبد", 17 },
                    { 566, new Guid("7d59e0a5-02ca-400d-a514-63bd1b081e8d"), "خرم آباد", 17 },
                    { 565, new Guid("274a1132-0470-48d2-955d-e62dbe9687ef"), "بيرانشهر", 17 },
                    { 564, new Guid("e2c64e8b-c7ef-49f9-b24a-4bfcc1707f61"), "بروجرد", 17 },
                    { 563, new Guid("5baab0b2-e068-476f-bc82-ff73565b790d"), "اليگودرز", 17 },
                    { 562, new Guid("cf992041-c1c1-4a1c-93d0-93beb18009d7"), "الشتر", 17 },
                    { 561, new Guid("29e4a22c-f1ab-43ea-a676-0d1072672ce1"), "اشترينان", 17 },
                    { 568, new Guid("e8ada14d-66ff-494c-abd1-c326b739e2e3"), "دورود", 17 },
                    { 463, new Guid("7f143200-eae6-4081-807c-ee7a82158d87"), "علي آباد", 14 },
                    { 462, new Guid("b4d72c34-0a97-46f6-8a27-8307c654ba0e"), "سيمين شهر", 14 },
                    { 461, new Guid("875cae07-1c1f-40ad-a460-0a5abebbea01"), "سنگدوين", 14 },
                    { 362, new Guid("42f70e99-0f48-45fb-97bf-d7b73a8608e7"), "شوشتر", 11 },
                    { 361, new Guid("05c27647-bc55-4cc0-baea-3a857ece4030"), "شوش", 11 },
                    { 360, new Guid("49e6e734-4bec-4926-a3c6-8ed06859bd08"), "شهر امام", 11 },
                    { 359, new Guid("93fbbaa5-e500-4e64-ae21-9122e0586f6d"), "شمس آباد", 11 },
                    { 358, new Guid("2e7439ca-3f31-43f8-9a85-e71e3a503ec5"), "شرافت", 11 },
                    { 357, new Guid("a6a33dad-00c3-4704-aa8d-7b1a5121502a"), "شاوور", 11 },
                    { 356, new Guid("bdc245cf-b2b5-4bfe-a38f-90ee99076ec9"), "شادگان", 11 },
                    { 355, new Guid("fc773a97-008e-4460-a772-57cab2cd1160"), "سياه منصور", 11 },
                    { 354, new Guid("1a8d2534-0d10-4dc2-87f3-b1606cd5f405"), "سوسنگرد", 11 },
                    { 353, new Guid("da5ced52-38f9-41be-a571-241720bdbe69"), "سماله", 11 },
                    { 352, new Guid("0317e6d5-a418-42b1-996d-6a860fac8631"), "سردشت", 11 },
                    { 351, new Guid("836f4b33-4ab0-4935-adc7-400dd70f356b"), "سرداران", 11 },
                    { 350, new Guid("9e41bc12-ba81-4fb2-9ba3-fde17c266b9f"), "سالند", 11 },
                    { 349, new Guid("89cbe17e-ea3e-4bef-a974-b6853c88bc51"), "زهره", 11 },
                    { 348, new Guid("876a5d5c-0708-4093-988c-21bb459289d1"), "رفيع", 11 },
                    { 363, new Guid("f212922a-61de-4b0a-98f0-fecf722e0891"), "شيبان", 11 },
                    { 364, new Guid("5aa25146-7347-45f4-8e42-04daa5652fb3"), "صالح شهر", 11 },
                    { 365, new Guid("5324bebc-b104-4d0b-86f3-428f29f283ee"), "صفي آباد", 11 },
                    { 366, new Guid("55aad100-1f7b-4a4c-b4ef-17c7385d49e9"), "صيدون", 11 },
                    { 382, new Guid("3c1f1158-9711-41cc-b24a-5de2b7aa4d0c"), "ويس", 11 },
                    { 381, new Guid("fd0e75e7-c952-443a-8b98-303f680de058"), "هويزه", 11 },
                    { 380, new Guid("21055d70-b281-41a3-a977-b4422b790fd0"), "هنديجان", 11 },
                    { 379, new Guid("49e09755-ac26-4271-b779-7b5d58fc9ab7"), "هفتگل", 11 },
                    { 378, new Guid("0506aece-d4b6-4a61-ac8c-6e6869bfdccc"), "مينوشهر", 11 },
                    { 377, new Guid("e7ebd803-529b-49a7-8dc6-d34c5b9f1d52"), "ميداود", 11 },
                    { 376, new Guid("a0ec480a-c3b1-4e65-a218-5371b3e147e1"), "ميانرود", 11 },
                    { 347, new Guid("df3aa63c-133c-41b1-a53d-e1687db06812"), "رامهرمز", 11 },
                    { 375, new Guid("5f128288-b31d-4da3-9123-510b122adde2"), "منصوريه", 11 },
                    { 373, new Guid("89bd40cf-d282-4954-a4a2-ba8bafd546a4"), "مقاومت", 11 },
                    { 372, new Guid("fbfecbe5-6c1f-4ded-b2ec-0e23c1f7da31"), "مشراگه", 11 },
                    { 371, new Guid("84cbe746-2797-41fa-8bb3-b45d098482b1"), "مسجد سليمان", 11 },
                    { 370, new Guid("794142c3-e714-4dfc-862a-0877bab50c1e"), "لالي", 11 },
                    { 369, new Guid("f7793e16-16ee-4147-a5fa-f53e67a6aef9"), "قلعه خواجه", 11 },
                    { 368, new Guid("a88d42b1-8c3a-4f1b-b2f5-908ed7638054"), "قلعه تل", 11 },
                    { 367, new Guid("f7737d06-e076-448a-b4de-0b10f2f30ca1"), "فتح المبين", 11 },
                    { 374, new Guid("bd3afdf3-0355-48af-89e6-fd68aee29e76"), "ملاثاني", 11 },
                    { 383, new Guid("70c299de-e482-4cb1-8685-025be1810191"), "چغاميش", 11 },
                    { 346, new Guid("9effe4a3-363e-488a-8bb7-aa902108542e"), "رامشير", 11 },
                    { 344, new Guid("a64fe80a-5c75-452d-b2e4-b2235e809ce2"), "دزفول", 11 },
                    { 323, new Guid("d806e383-42e5-416a-8e8c-c2eda9acca65"), "اميديه", 11 },
                    { 322, new Guid("2140e9a5-3d1a-4401-a76f-753fbaf808eb"), "الوان", 11 },
                    { 321, new Guid("7af911c2-dd02-44c7-91a9-edf37222313b"), "الهايي", 11 },
                    { 320, new Guid("1e9f7f4c-ed6e-4617-aa2f-4205dfd9d1e4"), "اروند کنار", 11 },
                    { 319, new Guid("09b89d00-889d-4572-a476-36b4de9d0987"), "ابوحميظه", 11 },
                    { 318, new Guid("13d92b97-4d63-4e53-8732-c4c892bbe8f3"), "آغاجاري", 11 },
                    { 317, new Guid("76480d3a-652b-4060-9b9c-e39b6dcc48a0"), "آزادي", 11 },
                    { 316, new Guid("f6bbe662-549f-42fa-95f4-c8ddd03c6a14"), "آبژدان", 11 },
                    { 315, new Guid("ddf28191-53a8-4b62-9376-f7727decb9cc"), "آبادان", 11 },
                    { 314, new Guid("fc136695-8110-4ee0-9132-e8455bd182bd"), "گزيک", 10 },
                    { 313, new Guid("25a5d42d-5268-4636-8b36-def493b48c3d"), "نيمبلوک", 10 },
                    { 312, new Guid("2735d8c7-a1e8-4be4-aade-1e5e1db0498d"), "نهبندان", 10 },
                    { 311, new Guid("51252392-efea-44f8-b36b-9009087ce3b0"), "مود", 10 },
                    { 310, new Guid("1e0829ae-2f0a-4bd8-8855-e556c98ed37a"), "محمدشهر", 10 },
                    { 309, new Guid("33ee8f90-2f28-48d4-b2ba-f32dd72c7b0e"), "قهستان", 10 },
                    { 324, new Guid("cee0fcf0-3fbe-44d6-a50e-d5cc23f9060e"), "انديمشک", 11 },
                    { 325, new Guid("b75e5877-50fc-4467-b58e-6394539e3b9e"), "اهواز", 11 },
                    { 326, new Guid("39cda215-257b-4f1a-9c4f-b8779c0161ef"), "ايذه", 11 },
                    { 327, new Guid("e75588ab-5eb7-43cf-9b2c-b375ca11a090"), "باغ ملک", 11 },
                    { 343, new Guid("e0507a18-48e1-4bdc-a953-b37f8de2550f"), "دارخوين", 11 },
                    { 342, new Guid("6027c624-c72b-4c04-9e66-156f8b3e0f58"), "خنافره", 11 },
                    { 341, new Guid("6d020389-45e5-40be-9ab4-9932561f7561"), "خرمشهر", 11 },
                    { 340, new Guid("9825a503-89b2-4398-9df9-bdf31792cffa"), "حميديه", 11 },
                    { 339, new Guid("12de467d-7b10-4eb7-85cf-a5e698819eb2"), "حمزه", 11 },
                    { 338, new Guid("e4861f5b-6ad2-48de-94f2-d1fc02c87e5f"), "حسينيه", 11 },
                    { 337, new Guid("80e43db5-d93b-4042-bb09-58b0d182a1ef"), "حر", 11 },
                    { 345, new Guid("b42b8bb8-34a5-4248-8207-4b99b4a670b8"), "دهدز", 11 },
                    { 336, new Guid("2eb65f6d-b232-4a29-8c90-218bcf7b960f"), "جنت مکان", 11 },
                    { 334, new Guid("de511f47-543b-4e0c-b927-80bd1e60c8bc"), "تشان", 11 },
                    { 333, new Guid("4852751a-36e3-4139-94ca-209496a3753e"), "ترکالکي", 11 },
                    { 332, new Guid("60271ab6-957c-4fbe-97ed-fd7377491b89"), "بيدروبه", 11 },
                    { 331, new Guid("fa779b7f-c228-4406-bfa8-be053f49895d"), "بهبهان", 11 },
                    { 330, new Guid("a2c6438b-0ef5-48f4-b317-d88b869b62aa"), "بندر ماهشهر", 11 },
                    { 329, new Guid("3704484f-e82a-4bce-a282-9fa2e8974cdf"), "بندر امام خميني", 11 },
                    { 328, new Guid("f2a67766-1c5e-48ce-9f4f-b6b060485b27"), "بستان", 11 },
                    { 335, new Guid("0ad5c55f-9cb6-4d4b-975f-d82803565c05"), "جايزان", 11 },
                    { 617, new Guid("d2d44948-e59e-4b0f-998d-99cdcf0e6bba"), "افوس", 19 },
                    { 384, new Guid("4e3e9d8f-25ba-4057-8459-47d57344e1fe"), "چم گلک", 11 },
                    { 386, new Guid("4116f510-d713-4d71-ab4b-6835bfe75512"), "چوئبده", 11 },
                    { 440, new Guid("0244b5ce-ed45-4eb1-9a3d-f47e798f1e12"), "صائين قلعه", 13 },
                    { 439, new Guid("e791fb11-c510-4b41-8306-463d28f4ef24"), "سهرورد", 13 },
                    { 438, new Guid("eaed4f4f-ab5e-465f-aaa3-29e100871d0f"), "سلطانيه", 13 },
                    { 437, new Guid("670f0dd2-582f-48fc-8e37-d1f1baa95aa2"), "سجاس", 13 },
                    { 436, new Guid("9ef2d240-85dc-45bb-becd-df1d4e2b6de5"), "زنجان", 13 },
                    { 435, new Guid("a3e0a9d5-7f18-4eaa-ab9a-e8d75b0a2689"), "زرين رود", 13 },
                    { 434, new Guid("bdb65ffa-6774-4260-9bc0-5f42bd568da3"), "زرين آباد", 13 },
                    { 433, new Guid("7af9c703-929d-4d6d-9fd2-6a8fb12b79ee"), "دندي", 13 },
                    { 432, new Guid("3cfae8b3-f73b-4ccb-9e22-d671fefdaf35"), "خرمدره", 13 },
                    { 431, new Guid("cf60c90d-78ad-4ed8-b4ea-5b39b5c746ac"), "حلب", 13 },
                    { 430, new Guid("c16eb40e-eb82-427e-8154-428ea5144295"), "ارمخانخانه", 13 },
                    { 429, new Guid("d91f6392-f826-4f5d-b78f-2f16db7d9aaf"), "ابهر", 13 },
                    { 428, new Guid("ca2dc402-bb16-4bb2-b437-07c82bcebeb9"), "آب بر", 13 },
                    { 427, new Guid("658868ff-1b36-4526-97f7-ab5a630559e5"), "کلمه", 12 },
                    { 426, new Guid("5e032f26-1d33-470d-b2bd-3ede7b27ea5f"), "کاکي", 12 },
                    { 441, new Guid("401ba525-a009-47fb-b869-8bbdb99bdfa7"), "قيدار", 13 },
                    { 442, new Guid("fafb75e8-1c81-4e08-8262-51ca154beb66"), "ماه نشان", 13 },
                    { 443, new Guid("5cfa8613-2c15-45c4-8f85-032faf7faf80"), "نوربهار", 13 },
                    { 444, new Guid("d6d63387-9d65-489e-815e-db170cf79351"), "نيک پي", 13 },
                    { 460, new Guid("45921412-b5cf-4c4f-a59f-b7722b65bce7"), "سرخنکلاته", 14 },
                    { 459, new Guid("3da993b4-ceee-4622-ae40-20704aafde01"), "راميان", 14 },
                    { 458, new Guid("69da7b07-e5b7-4b0e-bf46-9b036c3209b1"), "دلند", 14 },
                    { 457, new Guid("70404e58-9875-4ba9-845e-edf431b868d7"), "خان ببين", 14 },
                    { 456, new Guid("ef6cc1a4-563a-4f57-a7da-e2e6e058b1b9"), "جلين", 14 },
                    { 455, new Guid("c86c1399-015f-4d5c-a762-21adbb8b0cc7"), "تاتار عليا", 14 },
                    { 454, new Guid("cab3f083-6bae-4040-94c5-a558ed1fa666"), "بندر گز", 14 },
                    { 425, new Guid("dd2687fd-9e8d-48e7-8fc7-e5d061181d06"), "چغادک", 12 },
                    { 453, new Guid("fffb48d1-195c-4fb0-bcb4-ec59dcf201c1"), "بندر ترکمن", 14 },
                    { 451, new Guid("003dda9e-1b54-4c47-8046-4e58d3702712"), "انبار آلوم", 14 },
                    { 450, new Guid("8fa5d279-3a8e-46a3-90a0-2aac315aa007"), "آق قلا", 14 },
                    { 449, new Guid("e6c2870d-ebdf-43d0-ad0f-c6670370df6c"), "آزاد شهر", 14 },
                    { 448, new Guid("7b670977-9fe1-47df-8407-1d5f4254f06c"), "گرماب", 13 },
                    { 447, new Guid("ea22268e-35b8-4335-8f8d-ec22e4f472b7"), "کرسف", 13 },
                    { 446, new Guid("eedff0b1-c1f1-483f-90dd-a200a7069bac"), "چورزق", 13 },
                    { 445, new Guid("2359a25c-7a4f-4fbd-b62f-cc2276bb1588"), "هيدج", 13 },
                    { 452, new Guid("12d75cb5-7b68-447b-a8bc-df0e32800fd0"), "اينچه برون", 14 },
                    { 385, new Guid("e4c3e39c-9836-4e88-a1c9-03e945926983"), "چمران", 11 },
                    { 424, new Guid("0132d10f-4579-42a4-b8f1-f26d818f20e9"), "وحدتيه", 12 },
                    { 422, new Guid("edc189f8-2d09-4f31-909c-bc855e8efda3"), "عسلويه", 12 },
                    { 401, new Guid("f31567b8-71f2-472c-b1e2-ab916b1194e2"), "بردستان", 12 },
                    { 400, new Guid("00140297-3d55-4e19-b5b0-2eec077bd47b"), "بردخون", 12 },
                    { 399, new Guid("433e6449-a6f3-4c08-99cf-f75d4d62f4e6"), "برازجان", 12 },
                    { 398, new Guid("027da688-0b24-40d9-8357-aead4a493916"), "بادوله", 12 },
                    { 397, new Guid("83e79081-d028-47e5-a56b-57247391a4a0"), "اهرم", 12 },
                    { 396, new Guid("8689037d-ad37-41bc-a756-5ceaa5266bb2"), "انارستان", 12 },
                    { 395, new Guid("ff2a49d7-8f86-4b5e-9a72-6fa23ae78aa8"), "امام حسن", 12 },
                    { 394, new Guid("1abfeb13-e97b-46a8-b752-a89150dd9ef6"), "آبپخش", 12 },
                    { 393, new Guid("9965004e-2f9e-42bb-8c95-0108c6cdb0c3"), "آبدان", 12 },
                    { 392, new Guid("5714a10d-3c00-49a9-bbc5-92b6cdbc5b20"), "آباد", 12 },
                    { 391, new Guid("3a7b4f0c-632b-4485-a298-6f117224c70c"), "گوريه", 11 },
                    { 390, new Guid("d97b3de3-234a-4c08-8286-c10802df2240"), "گلگير", 11 },
                    { 389, new Guid("8f4c1e1f-3c9e-4924-9940-c792c3250da3"), "گتوند", 11 },
                    { 388, new Guid("4df8ee1b-eb44-482c-b15a-1133df04ccf5"), "کوت عبدالله", 11 },
                    { 387, new Guid("95cc99ab-40ce-4fc2-b569-ee8387ead268"), "کوت سيدنعيم", 11 },
                    { 402, new Guid("ce7f6ae5-9ebb-4e50-9e4b-7feb62609d3c"), "بندر دير", 12 },
                    { 403, new Guid("529d28f5-9998-4925-b471-af1911489783"), "بندر ديلم", 12 },
                    { 404, new Guid("0978e2c1-ddce-40e6-bd5b-1eb5b5e585bb"), "بندر ريگ", 12 },
                    { 405, new Guid("8807d5d9-92ce-4da9-9977-b36abd3400b2"), "بندر کنگان", 12 },
                    { 421, new Guid("82c1ed23-8c06-4fd9-adf6-48e837696dea"), "شنبه", 12 },
                    { 420, new Guid("6a157e3d-9020-467f-9f85-6d919892d6ab"), "شبانکاره", 12 },
                    { 419, new Guid("0d2765d0-7502-45c6-a825-f54385d61a59"), "سيراف", 12 },
                    { 418, new Guid("a476443b-b15f-43f3-90f1-857f6deb3602"), "سعد آباد", 12 },
                    { 417, new Guid("f6d6e3f0-1ec1-4ec1-b977-1685d7227e3f"), "ريز", 12 },
                    { 416, new Guid("773cd790-c72a-4616-bbf1-1e00b0b6c6d9"), "دوراهک", 12 },
                    { 415, new Guid("b0343bab-c4ee-4b2b-856f-e1fe15d68b7c"), "دلوار", 12 },
                    { 423, new Guid("2c4c8a15-c3cd-4dee-8af9-599cd4cebec1"), "نخل تقي", 12 },
                    { 414, new Guid("888e7d49-fcbc-40d5-bfab-53c189907390"), "دالکي", 12 },
                    { 412, new Guid("d222dbcd-e8fe-4686-bf3e-471c670f8a2a"), "خارک", 12 },
                    { 411, new Guid("96cd5d8a-0433-434b-abd3-594321344c9e"), "جم", 12 },
                    { 410, new Guid("513e2bc5-e0c6-4d4f-a961-4c83368a3443"), "تنگ ارم", 12 },
                    { 409, new Guid("b0547ad2-0d98-432c-88cc-2f1a141e0f01"), "بوشکان", 12 },
                    { 408, new Guid("a63a49fc-fa0b-4135-983f-670737fac19a"), "بوشهر", 12 },
                    { 407, new Guid("1be7d007-73b7-407e-823f-cb68a8e528b5"), "بنک", 12 },
                    { 406, new Guid("cc1dd02b-5000-49a4-a0fb-3abf92267e00"), "بندر گناوه", 12 },
                    { 413, new Guid("421d77cc-3e45-4d12-9c7f-9ef5e5e4df3f"), "خورموج", 12 },
                    { 1238, new Guid("7c4e5e42-629c-48d5-8746-9bf123742fb1"), "پاتاوه", 31 }
                });

            migrationBuilder.InsertData(
                table: "Code",
                columns: new[] { "CodeID", "CodeGroupID", "CodeGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, 1, new Guid("4fe48aed-c253-4e6e-b998-17b650a93b5b"), "png", "image/png" },
                    { 3, 1, new Guid("595367ba-44c9-4736-b524-9bfbc5848c44"), "jpeg", "image/jpeg" },
                    { 2, 1, new Guid("33baf7ad-dd3f-41f3-b1b5-cbed2a3b1c01"), "jpg", "image/jpg" }
                });

            migrationBuilder.InsertData(
                table: "SMSSetting",
                columns: new[] { "SMSSettingID", "ModifiedDate", "Name", "SMSProviderConfigurationID", "SMSSettingGUID" },
                values: new object[] { 1, new DateTime(2020, 4, 30, 18, 30, 27, 451, DateTimeKind.Local).AddTicks(2955), "Kavenegar", 1, new Guid("536a9f71-6f9c-4754-9f60-d32c41b73fbd") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", true, true, "رودکی", new DateTime(2020, 4, 30, 18, 30, 27, 455, DateTimeKind.Local).AddTicks(6805), "09227204305", new DateTime(2020, 4, 30, 18, 30, 27, 455, DateTimeKind.Local).AddTicks(5971), 1, new Guid("ea2739a8-eac7-416a-80c7-f59556850ca6") },
                    { 2, "mahdiih@ymail.com", "مهدی", true, true, "حکمی زاده", new DateTime(2020, 4, 30, 18, 30, 27, 456, DateTimeKind.Local).AddTicks(206), "09199390494", new DateTime(2020, 4, 30, 18, 30, 27, 456, DateTimeKind.Local).AddTicks(166), 1, new Guid("37b29980-03f5-4a6e-8013-8a230e886636") },
                    { 3, "roozbehshamekhi@hotmail.com", "روزبه", true, true, "شامخی", new DateTime(2020, 4, 30, 18, 30, 27, 456, DateTimeKind.Local).AddTicks(286), "09128277075", new DateTime(2020, 4, 30, 18, 30, 27, 456, DateTimeKind.Local).AddTicks(278), 1, new Guid("1ed97766-0a23-474f-b00a-39de52e2c09c") }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 4, 30, 18, 30, 27, 452, DateTimeKind.Local).AddTicks(2105), "VerifyAccount", 1, new Guid("4a94afb1-4900-44b9-a87d-09134ef418af") });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserID",
                table: "Admin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_DocumentID",
                table: "Advertisement",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryID",
                table: "Category",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTag_CategoryID",
                table: "CategoryTag",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTag_TagID",
                table: "CategoryTag",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_ChatRoomID",
                table: "ChatMessage",
                column: "ChatRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_ClientID",
                table: "ChatRoom",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_ContractorID",
                table: "ChatRoom",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_OrderID",
                table: "ChatRoom",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceID",
                table: "City",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserID",
                table: "Client",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Code_Code_CGID",
                table: "Code",
                column: "CodeGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_UserID",
                table: "Contractor",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Document_Document_TypeCodeID",
                table: "Document",
                column: "TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CategoryID",
                table: "Order",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientID",
                table: "Order",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ContractorID",
                table: "Order",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StateCodeID",
                table: "Order",
                column: "StateCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequest_ContractorID",
                table: "OrderRequest",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequest_OrderID",
                table: "OrderRequest",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionGroupID",
                table: "Permission",
                column: "PermissionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_DocumentID",
                table: "Post",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserID",
                table: "Post",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_CategoryID",
                table: "PostCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_PostID",
                table: "PostCategory",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_CommentID",
                table: "PostComment",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostID",
                table: "PostComment",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_PostID",
                table: "PostTag",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagID",
                table: "PostTag",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RolePermission_RP_PermissionID",
                table: "RolePermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RolePermission_RP_RoleID",
                table: "RolePermission",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSProviderNumber_SPN_SPCID",
                table: "SMSProviderNumber",
                column: "SMSProviderConfigurationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSResponse_SMS_STID",
                table: "SMSResponse",
                column: "SMSTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_SMSResponse_UserID",
                table: "SMSResponse",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSSetting_SS_SPCID",
                table: "SMSSetting",
                column: "SMSProviderConfigurationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSTemplate_ST_SSID",
                table: "SMSTemplate",
                column: "SMSSettingID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserID",
                table: "Token",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TypeCodeID",
                table: "Transaction",
                column: "TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserPermission_UP_PermissionID",
                table: "UserPermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_UserID",
                table: "UserPermission",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "CategoryTag");

            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "OrderRequest");

            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "SMSProviderNumber");

            migrationBuilder.DropTable(
                name: "SMSResponse");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "SMSTemplate");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "SMSSetting");

            migrationBuilder.DropTable(
                name: "PermissionGroup");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "SMSProviderConfiguration");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CodeGroup");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
