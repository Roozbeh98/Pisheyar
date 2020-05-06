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
                name: "ContactUs",
                columns: table => new
                {
                    ContactUsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactUsGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactUsID);
                    table.ForeignKey(
                        name: "FK_Contact_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
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
                    CityID = table.Column<int>(nullable: false),
                    Credit = table.Column<long>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ContractorID);
                    table.ForeignKey(
                        name: "FK_Contractor_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
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
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
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
                name: "ContractorCategory",
                columns: table => new
                {
                    ContractorCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorCategoryGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorCategory", x => x.ContractorCategoryID);
                    table.ForeignKey(
                        name: "FK_ContractorCategory_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractorCategory_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
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
                    { 1, new Guid("dfbfa2ed-5515-4dd4-905b-7050dfbd2996"), "سایت اصلی", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(4771), null, 1 },
                    { 10, new Guid("9ffdea1c-caef-4855-babe-52de5d5e46e7"), "وبلاگ", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5944), null, 2 }
                });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "CodeGroupID", "CodeGroupGUID", "DisplayName", "Name" },
                values: new object[] { 1, new Guid("bbcef49c-c10b-485e-9036-669c264f1592"), "نوع فایل", "FilepondType" });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("d0bce0f8-aab3-4543-a556-7f72717fa7e6") },
                    { 20, "ايلام", new Guid("d1715fa0-67e7-45b8-b9cf-dae6da9e19e5") },
                    { 21, "تهران", new Guid("74cc908d-1e27-4ec7-a305-93c320f19b67") },
                    { 22, "آذربايجان شرقي", new Guid("612c8ed7-98b4-4d01-adb8-127c54a8ee3a") },
                    { 23, "فارس", new Guid("b84bb196-fce6-42f4-9dc2-c37863926560") },
                    { 24, "کرمانشاه", new Guid("657cce6e-b50b-43db-82ad-b7a16380c0a6") },
                    { 26, "مرکزي", new Guid("4feee137-4458-4a18-b4d5-40c77f44a476") },
                    { 18, "اردبيل", new Guid("a262f521-35a7-4afb-b380-2bd5ef1f242f") },
                    { 27, "گيلان", new Guid("7dedf182-b0f3-4925-8602-2b9cc2080b33") },
                    { 28, "همدان", new Guid("3505ee83-9ba8-406e-98eb-3f5102f515c9") },
                    { 29, "کرمان", new Guid("6b45a47e-ece0-4228-9b07-45fc0f3ef6bb") },
                    { 30, "سمنان", new Guid("679c6f49-3bfc-4ea9-8c86-5d57f0528d16") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("74c2257d-edbb-483e-aa5d-1c86a8a901e4") },
                    { 25, "هرمزگان", new Guid("d61777c2-24f5-4cbd-bff9-1321ddbaf7ad") },
                    { 17, "لرستان", new Guid("c4ec355b-2e85-4a2b-bdce-8627400b5272") },
                    { 16, "قزوين", new Guid("404dc5cc-7371-4aea-893c-4a6b2a56825b") },
                    { 15, "مازندران", new Guid("3a895e61-3bcb-4acc-b18c-8f6e4e1abca1") },
                    { 1, "يزد", new Guid("3ab09d21-df47-4109-b2d7-bdb89d5e1c34") },
                    { 2, "چهار محال و بختياري", new Guid("83cc3b23-6c59-4734-8485-86297ce7a071") },
                    { 3, "خراسان شمالي", new Guid("b39fa192-099a-4eea-ad4a-ac2389ef7af7") },
                    { 4, "البرز", new Guid("9192dd3d-3c70-41e9-a6fe-2d29ee74c423") },
                    { 5, "قم", new Guid("8d11e06e-c787-457d-98af-6a32726a776e") },
                    { 6, "کردستان", new Guid("8213382c-b4d2-4baf-bb45-c14efdc071ff") },
                    { 7, "آذربايجان غربي", new Guid("084338be-fc89-4529-bb10-141774b8d46f") },
                    { 9, "سيستان و بلوچستان", new Guid("9b2cb4ab-f54c-49c5-91a8-cd1b37a4d83b") },
                    { 10, "خراسان جنوبي", new Guid("6001b130-96f3-4038-924d-23b5a56e6b42") },
                    { 11, "خوزستان", new Guid("e26ddd62-acad-4255-a7d5-8a38872022d2") },
                    { 12, "بوشهر", new Guid("63c53e7c-da88-4f05-8d8d-7ce3784639ac") },
                    { 13, "زنجان", new Guid("ee57d26e-15a3-4ff4-adbf-c37e347541a3") },
                    { 14, "گلستان", new Guid("206d37bb-6db2-42b7-bbea-9959c85db0ab") },
                    { 8, "خراسان رضوي", new Guid("90af2aa0-48a5-475a-b357-2e5f46159533") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 2, "ادمین", new DateTime(2020, 5, 6, 16, 13, 14, 920, DateTimeKind.Local).AddTicks(2470), "Admin", new Guid("450ec318-9dd9-4199-8120-ce12dc59e91c") },
                    { 1, "کاربر عادی", new DateTime(2020, 5, 6, 16, 13, 14, 920, DateTimeKind.Local).AddTicks(1429), "User", new Guid("e755554c-68b4-47f9-bf49-036a55e0c640") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 5, 6, 16, 13, 14, 915, DateTimeKind.Local).AddTicks(357), "ptcoptco", new Guid("223c96c8-a6fa-44fe-894f-1313e0f58899"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 2, new Guid("4913b104-b17d-4aae-bb13-ccbbf1289db5"), "ابزار و لوازم صنعتی", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5835), 1, 1 },
                    { 3, new Guid("52e09856-b663-4065-8f9f-590ad4b0f593"), "مصنوعات صنعتی", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5877), 1, 2 },
                    { 4, new Guid("cb432538-124a-456c-8a03-e755a71dc433"), "کالا و خدمات صنعتی", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5885), 1, 3 },
                    { 5, new Guid("1004cabe-5eec-4ff6-988f-458500db4abc"), "مواد شیمیایی", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5903), 1, 4 },
                    { 6, new Guid("39008b4f-7e49-4813-87ad-84c4c9cf3d4f"), "دستگاه و ماشین آلات", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5911), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 831, new Guid("640c9ae4-a0f5-4ed7-a7bc-2110bccda644"), "ممقان", 22 },
                    { 830, new Guid("b186ddc1-6a64-476a-85ea-31286e9f7568"), "ملکان", 22 },
                    { 829, new Guid("2cda5405-9236-46e3-96b2-8652983d5a12"), "مرند", 22 },
                    { 828, new Guid("60845954-b8b5-43df-a3eb-5ced964631e7"), "مراغه", 22 },
                    { 827, new Guid("b4080295-ae83-4749-9f66-ce086d448d36"), "مبارک شهر", 22 },
                    { 826, new Guid("024b21ec-4201-4357-ba81-b0e771d970b1"), "ليلان", 22 },
                    { 825, new Guid("3a53dc51-3637-4a52-9ef5-faed0785b0a7"), "قره آغاج", 22 },
                    { 822, new Guid("1b1fb6f3-c9c1-4ef9-b18e-6e298b7ff199"), "شهر جديد سهند", 22 },
                    { 823, new Guid("277346f0-3d6a-42f1-b4e8-97a8397b33e8"), "صوفيان", 22 },
                    { 832, new Guid("eb439e30-33ed-42d8-b129-4f630dae5f41"), "مهربان", 22 },
                    { 821, new Guid("ebcbe396-3a24-4fc1-8388-06a962749ef2"), "شند آباد", 22 },
                    { 820, new Guid("e6e513b8-d1d7-4876-8319-77b60797a325"), "شرفخانه", 22 },
                    { 819, new Guid("c13b2281-5c32-4288-af21-21c011532a8f"), "شربيان", 22 },
                    { 818, new Guid("c289c871-d624-40d4-b9f7-0e15d72f5220"), "شبستر", 22 },
                    { 817, new Guid("6da42bfc-d45d-49de-a874-d98cdd0ea1f9"), "سيه رود", 22 },
                    { 824, new Guid("161858c7-483a-45c4-8691-1ad62d8e6786"), "عجب شير", 22 },
                    { 833, new Guid("efb648b9-5954-412a-b291-4207cda49049"), "ميانه", 22 },
                    { 836, new Guid("d621c792-ed61-43c7-a0e5-fd96c6aa7827"), "هريس", 22 },
                    { 835, new Guid("e132819c-05aa-4417-aea4-0b575c46825b"), "هاديشهر", 22 },
                    { 851, new Guid("8d27504a-4a78-4af8-b3b0-63ae010d3a2a"), "استهبان", 23 },
                    { 850, new Guid("b46c1c26-dffc-4150-bdff-7bf63d9dd23a"), "ارسنجان", 23 },
                    { 849, new Guid("37dec946-8255-41ab-8ace-600a47a45dfb"), "اردکان", 23 },
                    { 848, new Guid("6c452577-088e-4100-9913-b5560f462cb9"), "آباده طشک", 23 },
                    { 847, new Guid("5a570528-dfc9-4e2e-b18d-b63953108b44"), "آباده", 23 },
                    { 846, new Guid("551d3a66-7aae-4d8f-a54d-aef070967d02"), "گوگان", 22 },
                    { 845, new Guid("e22c4ef0-b60d-4b51-8475-509f485c771b"), "کوزه کنان", 22 },
                    { 834, new Guid("4d594524-9c49-431d-9e7c-e40d82c77482"), "نظرکهريزي", 22 },
                    { 844, new Guid("c319bcfe-5975-4363-aef0-61edef1b7ca0"), "کليبر", 22 },
                    { 842, new Guid("efe995b4-c076-4fc0-b760-7cf8c57cbc34"), "کشکسراي", 22 },
                    { 841, new Guid("c1dc5acd-531d-4f5d-aafa-d691011c6418"), "يامچي", 22 },
                    { 840, new Guid("4e74af33-c305-4ab1-9965-5b5a90289abd"), "ورزقان", 22 },
                    { 839, new Guid("7af3230b-0f48-4892-82a8-0c4f173597ac"), "وايقان", 22 },
                    { 838, new Guid("1a611259-deb0-4836-91fe-bf76aa679d50"), "هوراند", 22 },
                    { 837, new Guid("e0ff012a-2efe-435b-9ca6-49ad8fa73f82"), "هشترود", 22 },
                    { 816, new Guid("e4485bb0-bfbe-4e25-9997-3e8874c15c36"), "سيس", 22 },
                    { 843, new Guid("07631d7d-273e-4895-b68a-1f802ed9d699"), "کلوانق", 22 },
                    { 815, new Guid("25c92970-ecf5-4fca-b071-57fc0756cd56"), "سردرود", 22 },
                    { 813, new Guid("da9b09a0-f0f3-4f3b-ab24-5242b1b1964f"), "زنوز", 22 },
                    { 852, new Guid("0e11352a-9e5d-4500-b631-9d1789d96418"), "اسير", 23 },
                    { 792, new Guid("8237e0af-5fa8-46a0-aa2a-dca0316c6271"), "باسمنج", 22 },
                    { 791, new Guid("67ce8efd-69da-47cd-b3ad-283787e463ef"), "ايلخچي", 22 },
                    { 790, new Guid("56f4578b-8a9b-4d93-a06e-7b7b87d1a451"), "اهر", 22 },
                    { 789, new Guid("444f6c13-a0c5-42e7-b30e-0636363fc6b9"), "اسکو", 22 },
                    { 788, new Guid("59d95af8-e15c-4523-941e-a3e8fd342c5e"), "آچاچي", 22 },
                    { 787, new Guid("be7e2e08-70e6-4dfc-9119-6577b9c358db"), "آقکند", 22 },
                    { 786, new Guid("57a92307-251c-46a4-8e16-9d16989baa31"), "آذرشهر", 22 },
                    { 785, new Guid("84a80456-6350-42e7-b87f-950cd1f9c5cb"), "آبش احمد", 22 },
                    { 784, new Guid("2327e09b-2166-442f-a28c-899a60b99ebb"), "گلستان", 21 },
                    { 783, new Guid("5a70f152-0253-4adb-b2b1-f23baab051ac"), "کيلان", 21 },
                    { 782, new Guid("48444cc4-4e28-461c-8e04-924dfa26247b"), "کهريزک", 21 },
                    { 781, new Guid("7990bdd0-ad9a-4284-8605-6e9e27e65f7f"), "چهاردانگه", 21 },
                    { 780, new Guid("5431f40d-7d41-489e-a93f-baadbe806ec5"), "پيشوا", 21 },
                    { 779, new Guid("55e1d323-0f25-4d22-b74d-ab7bba85a695"), "پرديس", 21 },
                    { 778, new Guid("8dd736d6-bf19-499a-8712-b0b6e75ba1c2"), "پاکدشت", 21 },
                    { 793, new Guid("d5ed2130-96fb-400f-9725-36bd9ed067f6"), "بخشايش", 22 },
                    { 794, new Guid("27c0138d-d618-479d-bde9-e10473084f5a"), "بستان آباد", 22 },
                    { 795, new Guid("4f4a5ee9-ecc7-4693-b981-152f4c6421d6"), "بناب", 22 },
                    { 796, new Guid("1ed0e4f9-3280-40ff-ad7c-c0e796723ef3"), "بناب مرند", 22 },
                    { 812, new Guid("969d7ced-eeb1-432c-990a-1acd38db6f8b"), "زرنق", 22 },
                    { 811, new Guid("1236bc03-9452-4c1a-9ab5-c5d6cbcc68fb"), "دوزدوزان", 22 },
                    { 810, new Guid("ee662ad6-6842-4c69-ac82-eb1a9b77fec4"), "خواجه", 22 },
                    { 809, new Guid("7fa4e794-2065-4f57-91de-57d0b9bdd9d1"), "خمارلو", 22 },
                    { 808, new Guid("31e36fa6-91c4-4c5f-881f-60e598a1a356"), "خسروشاه", 22 },
                    { 807, new Guid("ca89a3f7-25da-4663-bfa7-28323c6b0c69"), "خداجو", 22 },
                    { 806, new Guid("12b24fb7-0a71-475d-b087-b2578b32de65"), "خامنه", 22 },
                    { 814, new Guid("bae099ff-a9fe-4c82-8cb6-4d4137e57c8d"), "سراب", 22 },
                    { 805, new Guid("f2373e21-a296-4fc9-b917-a8b0d4ff5722"), "خاروانا", 22 },
                    { 803, new Guid("81172005-1a6e-4603-8a5a-a67fd658792c"), "جلفا", 22 },
                    { 802, new Guid("9b88fcc6-5eba-4c37-bedc-0c8ea9d5aa9f"), "تيکمه داش", 22 },
                    { 801, new Guid("570f11bb-4aa9-4ba5-bd67-0d5296b97555"), "تيمورلو", 22 },
                    { 800, new Guid("f173a2eb-9c3b-4f35-8e45-a7aa23b2a33a"), "تسوج", 22 },
                    { 799, new Guid("73f6cec1-46ce-4616-987f-665cca492b82"), "ترکمانچاي", 22 },
                    { 798, new Guid("fac7ff4c-3cc3-4b7c-80c1-38354c150b6e"), "ترک", 22 },
                    { 797, new Guid("60534942-30e1-4083-9071-9909334deb8f"), "تبريز", 22 },
                    { 804, new Guid("c36e382c-2e56-49a4-b9bb-a27051cad155"), "جوان قلعه", 22 },
                    { 853, new Guid("6639ec4e-1a72-4a8b-8aeb-85d710cc44c2"), "اشکنان", 23 },
                    { 855, new Guid("9ba5e6f5-eb38-46eb-b727-1e87a7abdf3c"), "اقليد", 23 },
                    { 777, new Guid("5cf32aa2-ce14-4c7e-8584-6dc7910ad040"), "ورامين", 21 },
                    { 909, new Guid("00f1bbf0-3bd5-4886-b31e-1f3b886c9c60"), "فدامي", 23 },
                    { 908, new Guid("f288122c-0e4f-4d6d-a4ba-924113636c1b"), "عماد ده", 23 },
                    { 907, new Guid("56bf3834-4185-4d4d-b889-ac7f9f62f371"), "علامرودشت", 23 },
                    { 906, new Guid("19dcd458-babc-45e6-b991-74a0ab2e729a"), "صفا شهر", 23 },
                    { 905, new Guid("6aeb14e5-b451-4d20-bf2b-0cf06de70e47"), "صغاد", 23 },
                    { 904, new Guid("76bc1ed1-1752-4780-9c83-41b8a3ebba7f"), "شيراز", 23 },
                    { 903, new Guid("a9eaded3-2142-487f-a84b-74e79d2903bf"), "شهر پير", 23 },
                    { 902, new Guid("e0940fa2-0fce-4491-a9f7-f02755827519"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("0a31a52b-4bc1-4bd3-9160-112df446693a"), "ششده", 23 },
                    { 900, new Guid("e0cd59de-3ee9-4feb-a403-2aada0230a3e"), "سيدان", 23 },
                    { 899, new Guid("835b761a-4e63-47ba-adba-97e6d8238e3c"), "سورمق", 23 },
                    { 898, new Guid("8197ca0b-ec02-43fc-84fc-3e470d8750f0"), "سلطان شهر", 23 },
                    { 897, new Guid("6081b53f-89de-4e15-8138-98b7501babdc"), "سعادت شهر", 23 },
                    { 896, new Guid("f2139353-f1e1-48bf-b61c-df05b0dac86d"), "سروستان", 23 },
                    { 895, new Guid("4dce8e2a-f0f0-49e6-b03f-59639e8675de"), "سده", 23 },
                    { 910, new Guid("11caea0a-bb36-4bc5-997b-19b4c02f4144"), "فراشبند", 23 },
                    { 911, new Guid("5dbb364c-67a6-4535-8cd1-8455d02623e3"), "فسا", 23 },
                    { 912, new Guid("1d98ed09-6c44-49ac-b766-7d4eea952cd5"), "فيروزآباد", 23 },
                    { 913, new Guid("05479710-04c0-42b2-b2b7-84924f3606bf"), "قائميه", 23 },
                    { 929, new Guid("e670a4c2-2bbd-44b6-9dc2-21be189aef05"), "مهر", 23 },
                    { 928, new Guid("7f753afb-55cd-4621-8a86-dd34cf85a1d9"), "مصيري", 23 },
                    { 927, new Guid("2a271c8b-debc-4840-8c9f-0bcf42372d83"), "مشکان", 23 },
                    { 926, new Guid("6c819521-3c50-4c0c-a0c9-15f33ed7dad0"), "مزايجان", 23 },
                    { 925, new Guid("46355f1c-784f-4324-a860-35dc9832b5ba"), "مرودشت", 23 },
                    { 924, new Guid("8d130f19-0df4-44d4-8665-7214f76eafc8"), "مبارک آباد", 23 },
                    { 923, new Guid("d22b45a0-1820-483d-af1b-a7cf2087c26a"), "مادرسليمان", 23 },
                    { 894, new Guid("f3aa9b62-553f-4fe7-967b-59940508087f"), "زرقان", 23 },
                    { 922, new Guid("9f5c5884-601a-49f6-ac81-de80e5ea84e5"), "لپوئي", 23 },
                    { 920, new Guid("786a3a71-9270-4843-9674-30cf91bcb50e"), "لامرد", 23 },
                    { 919, new Guid("b2c1436b-f867-45c7-8e40-31c4a3a76002"), "لار", 23 },
                    { 918, new Guid("d22911a9-d265-422e-b813-262471e9df45"), "قير", 23 },
                    { 917, new Guid("9b45a43d-7ea7-4f54-84f2-674fbf20064c"), "قطرويه", 23 },
                    { 916, new Guid("dec12e6f-9d39-4c55-9194-afbfad0c4d0c"), "قطب آباد", 23 },
                    { 915, new Guid("34e8e195-1921-4d06-b88c-64d288a57efb"), "قره بلاغ", 23 },
                    { 914, new Guid("4f3a1596-f17a-4cd1-85d2-1e006a5a8432"), "قادرآباد", 23 },
                    { 921, new Guid("c785a72b-eb8f-4f3e-b07a-c6e05305c4b4"), "لطيفي", 23 },
                    { 854, new Guid("19f536c9-99a2-490e-bdc1-a3124b7f1b9f"), "افزر", 23 },
                    { 893, new Guid("344cab06-ffb9-49df-9afa-ea4f60c8eae7"), "زاهد شهر", 23 },
                    { 891, new Guid("00bbecd9-7c9d-4b11-8765-53d0d2e5143c"), "رامجرد", 23 },
                    { 870, new Guid("acf82fcd-d7df-446f-962c-33de50612503"), "جهرم", 23 },
                    { 869, new Guid("acf74c00-ac02-48e2-a50c-99457801d1ef"), "جنت شهر", 23 },
                    { 868, new Guid("84d15e16-f222-458d-856f-efc055ff90ad"), "بيضا", 23 },
                    { 867, new Guid("5ed60fd3-daa3-46c4-8e4d-e7af33435c33"), "بيرم", 23 },
                    { 866, new Guid("af641d44-3145-46bd-9d23-70abeda5b5b6"), "بوانات", 23 },
                    { 865, new Guid("f0b0c1d1-2fd8-4055-a4b3-b7a1d6c2aa2d"), "بهمن", 23 },
                    { 864, new Guid("1114916a-6bf2-4dd1-93bf-e1656e8bf190"), "بنارويه", 23 },
                    { 863, new Guid("028a78b7-394b-4aa0-9508-8674b408f5ba"), "بالاده", 23 },
                    { 862, new Guid("7496f6ce-b17c-477a-8f68-e8df8aaf6f77"), "بابامنير", 23 },
                    { 861, new Guid("b87523e3-0cb4-41ef-9e45-e00dc2260b3e"), "باب انار", 23 },
                    { 860, new Guid("04f1debf-e790-4cb9-b535-a3ffcae8e59e"), "ايزد خواست", 23 },
                    { 859, new Guid("0c430669-cb93-4a68-943a-718839e92e6c"), "ايج", 23 },
                    { 858, new Guid("1c5ae910-f692-4a43-8dcd-d4d82981c409"), "اوز", 23 },
                    { 857, new Guid("2e7c1bbf-e939-4df0-bea4-0ae506a0df0a"), "اهل", 23 },
                    { 856, new Guid("f553ba49-bc7e-4a94-8564-49295d0f8084"), "امام شهر", 23 },
                    { 871, new Guid("c3caaf49-6c03-446c-b432-2f687a2c8621"), "جويم", 23 },
                    { 872, new Guid("f77d5fc8-daa4-412e-8ee6-99c44172d5c0"), "حاجي آباد", 23 },
                    { 873, new Guid("f74c6938-c5da-484c-b47c-233142677efb"), "حسامي", 23 },
                    { 874, new Guid("e8b36445-44a7-4ec8-aac0-da4f9318411f"), "حسن آباد", 23 },
                    { 890, new Guid("e257da0f-cc23-4817-8c63-67bdb2885ce9"), "دژکرد", 23 },
                    { 889, new Guid("59fd6d17-b34d-4bc1-a193-0cd1ca34c819"), "دوزه", 23 },
                    { 888, new Guid("7f88b9e1-dc24-4ca6-968a-40e27478146c"), "دوبرجي", 23 },
                    { 887, new Guid("33c3f063-4b00-4997-b29b-0ea13d94734c"), "دهرم", 23 },
                    { 886, new Guid("a7e28f8e-46a2-46b5-add2-afb1bbd4d33e"), "دبيران", 23 },
                    { 885, new Guid("a3af71cc-ef5d-45fd-83b7-783594ede47c"), "داريان", 23 },
                    { 884, new Guid("7b690c27-2611-45d6-bb06-f748f68a1037"), "داراب", 23 },
                    { 892, new Guid("218ef4cd-d4bd-4275-bd90-c6f0fda9ee62"), "رونيز", 23 },
                    { 883, new Guid("0d0477b4-4784-4675-aec3-5771f0833ae1"), "خومه زار", 23 },
                    { 881, new Guid("7f85b083-e22d-491e-9f2d-3c19a7644472"), "خور", 23 },
                    { 880, new Guid("36894c98-d818-4dc4-a659-6aebb33be296"), "خنج", 23 },
                    { 879, new Guid("b4f43aff-45cf-48af-8ee8-dad272bfae06"), "خشت", 23 },
                    { 878, new Guid("0dfe36cd-1e70-4dc3-8379-6e474ce15294"), "خرامه", 23 },
                    { 877, new Guid("745a9cde-66fc-444e-af35-d0d38c0c72d6"), "خاوران", 23 },
                    { 876, new Guid("177a9668-e92e-4a3d-a774-33b60a48273a"), "خانيمن", 23 },
                    { 875, new Guid("904c2a74-2cb9-4d7e-bfb9-90395ef5d388"), "خانه زنيان", 23 },
                    { 882, new Guid("1b76381e-f74b-429f-b18b-b82449e804aa"), "خوزي", 23 },
                    { 776, new Guid("f19b9dae-4566-4201-869b-bd89e9f55787"), "وحيديه", 21 },
                    { 774, new Guid("a1a00df3-2fbf-4007-9e7a-5d7a1d2f9818"), "نسيم شهر", 21 },
                    { 930, new Guid("6f3214f0-ac1f-4851-a423-a80ddaf0dde3"), "ميانشهر", 23 },
                    { 675, new Guid("7b43a147-a2fc-404a-a1bd-19f631ec2bac"), "قمصر", 19 },
                    { 674, new Guid("9caa6ba6-4c5b-4ad9-bebe-b7cf8cf68568"), "فولاد شهر", 19 },
                    { 673, new Guid("6532a696-bfe0-49dd-a290-b8a63e34fdc9"), "فلاورجان", 19 },
                    { 672, new Guid("7f81b9a3-9092-4e22-bf62-163e8a5fff4f"), "فريدونشهر", 19 },
                    { 671, new Guid("de2dd5f2-40e1-48bb-bb8e-2f0a085ccc9d"), "فرخي", 19 },
                    { 670, new Guid("5fef7440-912d-4308-8a7a-7880b3ea0115"), "علويچه", 19 },
                    { 669, new Guid("e04d43d6-cc7b-4e48-8241-7b9e1a7d1850"), "عسگران", 19 },
                    { 668, new Guid("7de5bd89-7ac5-45ac-afd8-f1c384e8bbc0"), "طرق رود", 19 },
                    { 667, new Guid("2909a929-0340-42b9-8517-653716f97f21"), "طالخونچه", 19 },
                    { 666, new Guid("d0101d30-f6a3-482c-bd5d-faacab280a33"), "شهرضا", 19 },
                    { 665, new Guid("b30a64f3-a14c-41d6-b9e3-a5de2bc109f6"), "شاپورآباد", 19 },
                    { 664, new Guid("a592ea97-fe2a-4461-a288-e80bcb363367"), "شاهين شهر", 19 },
                    { 663, new Guid("c51422c6-aea0-4dc0-8865-587b43313d1f"), "سگزي", 19 },
                    { 662, new Guid("2f3ab0e7-c2d7-4c3e-986b-0bfe3abdef48"), "سين", 19 },
                    { 661, new Guid("4e20fab9-2dcd-4127-aa3d-c779ab7d8f54"), "سميرم", 19 },
                    { 676, new Guid("1f220e13-0d56-4661-9be8-144f367f0705"), "قهجاورستان", 19 },
                    { 677, new Guid("0cacdc4c-d1aa-4046-9170-1fa46ed52d0e"), "قهدريجان", 19 },
                    { 678, new Guid("46c111ad-3dba-4778-88f2-e22fe95338d4"), "لاي بيد", 19 },
                    { 679, new Guid("d9388ef3-7f53-4306-bd75-6dd5a533fe78"), "مبارکه", 19 },
                    { 695, new Guid("c76faaed-91f8-4d02-a5bd-2837e5f78cad"), "وزوان", 19 },
                    { 694, new Guid("8b70e5f9-ec58-4392-9095-7d7cccd0aa52"), "ورنامخواست", 19 },
                    { 693, new Guid("2d76e68d-5f20-4053-871e-c94154025262"), "ورزنه", 19 },
                    { 692, new Guid("e323fb51-85f3-4b1c-9c5b-89f2cbb8aee3"), "هرند", 19 },
                    { 691, new Guid("ff3dfa10-0dc2-40f5-8465-ac5381228d0a"), "نيک آباد", 19 },
                    { 690, new Guid("1c576a0d-47c2-4dac-9819-c1e5aa488df0"), "نياسر", 19 },
                    { 689, new Guid("2c5d1063-6c66-4278-91fb-41dbc639d77a"), "نوش آباد", 19 },
                    { 660, new Guid("fb6ead6a-ec1a-44a5-b3bb-6b2720c5ffbf"), "سفيد شهر", 19 },
                    { 688, new Guid("e2b94985-cfda-4367-aea9-df100951a60f"), "نطنز", 19 },
                    { 686, new Guid("8f0ddb3e-18c8-4abd-a9cd-46db2cb5519e"), "نجف آباد", 19 },
                    { 685, new Guid("6d5e4059-ab90-4b79-bc8c-f78b4b90a1b2"), "نائين", 19 },
                    { 684, new Guid("daa5d067-31ba-4aa1-bbe6-6cfedb363d28"), "ميمه", 19 },
                    { 683, new Guid("603a2339-afd3-43f6-91d0-f5e3be2d6181"), "مهاباد", 19 },
                    { 682, new Guid("74d60ec4-711f-4939-aa4c-72d914ceb7a7"), "منظريه", 19 },
                    { 681, new Guid("02821252-65bf-4119-a800-da2529becaa1"), "مشکات", 19 },
                    { 680, new Guid("f902728f-7a97-45a0-8ce1-c35a4d239975"), "محمد آباد", 19 },
                    { 687, new Guid("1697aa51-4d43-4344-8e6d-dc04a34f2c90"), "نصرآباد", 19 },
                    { 696, new Guid("1cb5b0ed-874b-4d66-a7e5-2b563a82d4bb"), "ونک", 19 },
                    { 659, new Guid("16b459b6-bc11-46d7-9eff-158b02f6358b"), "سده لنجان", 19 },
                    { 657, new Guid("088a743e-543c-42b6-9f5a-62ea2b214078"), "زيار", 19 },
                    { 636, new Guid("b96a70b8-6738-4535-b296-3a3e7c55e197"), "حسن آباد", 19 },
                    { 635, new Guid("11949c7d-ec8b-4348-8c8a-09bfb4f76392"), "حبيب آباد", 19 },
                    { 634, new Guid("5bc00e41-3b3e-45f0-b3b4-e4e48ea72867"), "جوشقان قالي", 19 },
                    { 633, new Guid("526f4c39-de82-46db-8389-6e5512fed9eb"), "جوزدان", 19 },
                    { 632, new Guid("bebc4552-43af-43fe-baf4-3a6e9667e8c7"), "جندق", 19 },
                    { 631, new Guid("185bcc33-0082-4cf4-af75-47037a7f4db6"), "تيران", 19 },
                    { 630, new Guid("8f7852b6-7911-41b8-b3a6-d4e79db3562e"), "تودشک", 19 },
                    { 629, new Guid("4f1e18cb-b2d5-423b-a8df-430931b3e3fc"), "بوئين مياندشت", 19 },
                    { 628, new Guid("e1d21a36-f623-4eca-95d2-4a453c52910c"), "بهارستان", 19 },
                    { 627, new Guid("efdbcd2a-cf70-4313-8fb5-74f32a59f61a"), "بهاران شهر", 19 },
                    { 626, new Guid("51b2658f-7d6d-47a7-92b1-fa71ed4cc0cd"), "برف انبار", 19 },
                    { 625, new Guid("d47fd6fc-1add-4b7a-8319-d8ee1365fdea"), "برزک", 19 },
                    { 624, new Guid("16a49fe4-b768-4191-a7ca-480e9147265f"), "بافران", 19 },
                    { 623, new Guid("11927761-2761-4e36-b80f-042798f7ef56"), "باغشاد", 19 },
                    { 622, new Guid("ec7cc2b5-6606-4541-a080-a8ab87370c6f"), "باغ بهادران", 19 },
                    { 637, new Guid("587d21f0-a960-4cb8-96cc-fdbed2a5f683"), "حنا", 19 },
                    { 638, new Guid("5b5b1e0d-74fb-4468-94bc-57220bab5d83"), "خالد آباد", 19 },
                    { 639, new Guid("57a29799-cbb7-4317-8ba1-740795b00098"), "خميني شهر", 19 },
                    { 640, new Guid("4d089da4-d3e1-40eb-a495-b3701d4fc235"), "خوانسار", 19 },
                    { 656, new Guid("bc598ed7-2822-4a92-883d-045747292f1a"), "زواره", 19 },
                    { 655, new Guid("4942b1b8-6567-40ea-b175-f2275f1b2725"), "زرين شهر", 19 },
                    { 654, new Guid("6851c95b-749d-4579-8b2c-76e4d65e06ee"), "زاينده رود", 19 },
                    { 653, new Guid("7f9916a5-ad31-44ed-9189-4f3d72d50e2e"), "زازران", 19 },
                    { 652, new Guid("6597a571-be10-4ac0-8127-f847863fbb23"), "رضوانشهر", 19 },
                    { 651, new Guid("c20bd1e7-3624-4b0d-a59f-f319a017c3d1"), "رزوه", 19 },
                    { 650, new Guid("f9c1e155-e838-451c-bb80-69eee15b0184"), "ديزيچه", 19 },
                    { 658, new Guid("9cacc7c7-8b50-4451-b280-535572193649"), "زيباشهر", 19 },
                    { 649, new Guid("1c78ac2c-93cf-47ed-a838-064341057d48"), "دولت آباد", 19 },
                    { 647, new Guid("0124225d-8a29-4e48-8ecb-f1d78509ceaf"), "دهاقان", 19 },
                    { 646, new Guid("b4c18b38-297c-4db9-ae17-fab87b8186b7"), "دستگرد", 19 },
                    { 645, new Guid("e3b6f117-f44f-45c9-8813-4b911bff592b"), "درچه پياز", 19 },
                    { 644, new Guid("41949206-7a73-4f27-8388-83cadd357388"), "دامنه", 19 },
                    { 643, new Guid("90c4ccfa-12b5-43ad-8c38-c5a5e8c6046d"), "داران", 19 },
                    { 642, new Guid("ff54cf78-6836-4d92-b5ed-37abf3ab9914"), "خورزوق", 19 },
                    { 641, new Guid("268b1178-5a4b-4240-8992-ce96e51f67af"), "خور", 19 },
                    { 648, new Guid("73a249f2-92a6-4b6a-b745-9640cf33ab6c"), "دهق", 19 },
                    { 775, new Guid("7e359419-d9fa-4bfc-9760-19da2049af88"), "نصيرشهر", 21 },
                    { 697, new Guid("7ae8da6e-9b2c-4642-bb2d-d205daea3338"), "پير بکران", 19 },
                    { 699, new Guid("cc8e4666-1cec-4725-9d55-472a4a8e03ff"), "چرمهين", 19 },
                    { 753, new Guid("eb2b21f2-6f47-4b76-8b7f-fd08f1ccab12"), "حسن آباد", 21 },
                    { 752, new Guid("aae80359-02ae-4a05-95e6-650deede7bc9"), "جواد آباد", 21 },
                    { 751, new Guid("cb6ae1bb-65a9-4cae-9932-d723b1dfbef0"), "تهران", 21 },
                    { 750, new Guid("68c539ae-3e84-4623-a5a0-48ee2aed9c84"), "تجريش", 21 },
                    { 749, new Guid("6080e21f-ead3-41b8-9de3-ca434a7c06f3"), "بومهن", 21 },
                    { 748, new Guid("b57c4f9f-7c9d-402f-ad7d-08632caa6fca"), "باقرشهر", 21 },
                    { 747, new Guid("4d45c886-0563-4d22-8833-894b8aa8bdd7"), "باغستان", 21 },
                    { 746, new Guid("50f9ef1e-7665-4946-b1c6-d74165fc8493"), "انديشه", 21 },
                    { 745, new Guid("7895830f-baf7-4bad-a7c2-0fb2f2c59bc4"), "اسلامشهر", 21 },
                    { 744, new Guid("c5e0f686-4e34-4c59-a054-4ebb885faef5"), "ارجمند", 21 },
                    { 743, new Guid("d3ec2df9-92e7-4061-a35d-8b71ab62da6f"), "آبعلي", 21 },
                    { 742, new Guid("dc0419c5-197c-45f1-8e56-e1c17d04648f"), "آبسرد", 21 },
                    { 741, new Guid("afa8a839-429a-438c-ac66-8f06ff715438"), "چوار", 20 },
                    { 740, new Guid("93ac985b-1f53-4c42-910f-1c8cd4d5311a"), "پهله", 20 },
                    { 739, new Guid("20ec60bc-ee55-44dc-8104-86f68c99b871"), "ميمه", 20 },
                    { 754, new Guid("a0e0e3d5-9571-450c-8bff-e4b492fc53ac"), "دماوند", 21 },
                    { 755, new Guid("0dcd1e3f-1821-4790-9041-650c217477b4"), "رباط کريم", 21 },
                    { 756, new Guid("627e1c3f-45a6-4f73-a2fc-85860989a0ed"), "رودهن", 21 },
                    { 757, new Guid("addbdc4c-1cf2-4f88-be6b-7a955eb8dffd"), "ري", 21 },
                    { 773, new Guid("692cc2c4-b040-49a8-a26d-506dc9b7dff2"), "ملارد", 21 },
                    { 772, new Guid("49e3f146-3dd8-4d58-9cad-e52eeafd3880"), "لواسان", 21 },
                    { 771, new Guid("1e3b0da1-3b1b-4233-9892-c9d1e2c78128"), "قرچک", 21 },
                    { 770, new Guid("b3a185de-da71-4675-9a1d-82faa720ca72"), "قدس", 21 },
                    { 769, new Guid("8eda23f9-926d-4288-aa5b-ebbf928d4304"), "فيروزکوه", 21 },
                    { 768, new Guid("9da4d02b-7c5d-49f5-8950-e7f04131174b"), "فشم", 21 },
                    { 767, new Guid("68395450-eb5a-44da-9f53-247285a57dca"), "فرون آباد", 21 },
                    { 738, new Guid("880da88c-26a7-4f1b-931f-4717379b1e4e"), "موسيان", 20 },
                    { 766, new Guid("6a1569f2-0501-44f9-a688-a19fe15b43e2"), "فردوسيه", 21 },
                    { 764, new Guid("11dfd4d3-f002-4681-aa6f-b7051edab9c2"), "صبا شهر", 21 },
                    { 763, new Guid("6f74e8fd-f825-4727-be69-94387a1e4cbf"), "صالحيه", 21 },
                    { 762, new Guid("fa8a1f65-9e18-40ae-ab52-55272d11dbd1"), "شهريار", 21 },
                    { 761, new Guid("d6dc9f3f-6cba-4191-a4dd-a746f6d130bb"), "شهر جديد پرند", 21 },
                    { 760, new Guid("5e452b1b-f4c2-476f-a9c3-77919e5f37d8"), "شمشک", 21 },
                    { 759, new Guid("c757fc9d-d18a-4839-80e1-256bb5171962"), "شريف آباد", 21 },
                    { 758, new Guid("4439fbed-23fb-426e-835e-c251c3e2ec1c"), "شاهدشهر", 21 },
                    { 765, new Guid("a1b0b30d-751f-4e5c-98fc-f129b281b883"), "صفادشت", 21 },
                    { 698, new Guid("0c7b55c9-f958-460d-b336-e3e4b3bcc2fb"), "چادگان", 19 },
                    { 737, new Guid("87d811cc-4253-40fe-91bd-1344f972810c"), "مورموري", 20 },
                    { 735, new Guid("84579964-45c6-4e8f-af97-95a87dff471e"), "مهر", 20 },
                    { 714, new Guid("2cd92f1f-5346-4840-91fb-5ff95cb984a8"), "گلشهر", 19 },
                    { 713, new Guid("6e8cad8e-86bf-4b8d-a79e-d2b560f7bd29"), "گلشن", 19 },
                    { 712, new Guid("834b00ac-ccc2-4a6b-b3bd-671ca271c118"), "گلدشت", 19 },
                    { 711, new Guid("ec519c19-2f4e-43e0-b604-d76bbbf83e3e"), "گز برخوار", 19 },
                    { 710, new Guid("91d7ff12-bfac-4429-a194-ab80a956e9b0"), "گرگاب", 19 },
                    { 709, new Guid("fac18c8a-57de-4a33-9292-d14a0ff32a54"), "کوهپايه", 19 },
                    { 708, new Guid("2fda0673-7f75-46a2-b876-a38f4b8f8f95"), "کوشک", 19 },
                    { 707, new Guid("2d061653-0472-4f9a-af0d-0ab865c3f1d8"), "کهريزسنگ", 19 },
                    { 706, new Guid("1988e43f-aaf3-4e67-bec0-6be7e79e7612"), "کمه", 19 },
                    { 705, new Guid("e4254070-c553-4ffa-9139-9482c6a1e1a6"), "کمشجه", 19 },
                    { 704, new Guid("b7aea414-80d0-4f40-bb2d-1d96a0b37e74"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("e09ea716-f97c-42ec-bc29-039ef289543a"), "کرکوند", 19 },
                    { 702, new Guid("cb630401-ab0c-4863-9dad-a9586e4e9a48"), "کامو و چوگان", 19 },
                    { 701, new Guid("5d3a72f8-2724-4687-928c-4b9c448fbd1e"), "کاشان", 19 },
                    { 700, new Guid("bf6c5ff1-f3cd-4590-8736-818080d50180"), "چمگردان", 19 },
                    { 715, new Guid("f481de4b-4b0c-4dbb-b310-9fa1190c9e5f"), "گلپايگان", 19 },
                    { 716, new Guid("143bdff6-ebe1-48e3-89dd-ce68efec59e2"), "گوگد", 19 },
                    { 717, new Guid("3c6c8263-26fe-412e-8370-2dbf7ed87283"), "آبدانان", 20 },
                    { 718, new Guid("84372f57-a55a-4ee8-b927-bbd7be14eb4b"), "آسمان آباد", 20 },
                    { 734, new Guid("e83648b0-41fb-48fa-af37-364708e9cbe4"), "ماژين", 20 },
                    { 733, new Guid("062e28ff-6d71-4520-af53-c90d8de1a614"), "لومار", 20 },
                    { 732, new Guid("6ee34589-3626-4553-97e4-524f836c6cf3"), "صالح آباد", 20 },
                    { 731, new Guid("e26d8485-cc35-4c98-ab94-28ad04ebe34a"), "شباب", 20 },
                    { 730, new Guid("7ad36215-89c1-4d8b-be76-73c4d114a0b6"), "سرابله", 20 },
                    { 729, new Guid("684ff423-1822-49ca-8a60-464aeb3fd0c7"), "سراب باغ", 20 },
                    { 728, new Guid("a40f358c-78dc-4db0-93ac-1ca0ba6c4b68"), "زرنه", 20 },
                    { 736, new Guid("57f96d38-c887-4453-835a-0ac36eb2e256"), "مهران", 20 },
                    { 727, new Guid("12a711cc-b31c-49df-8042-bbb826fb27cc"), "دهلران", 20 },
                    { 725, new Guid("cfb8aad0-a96b-467e-bdc1-8f1d14b64aa1"), "دره شهر", 20 },
                    { 724, new Guid("1d072536-f19b-4ccf-aef0-7b336345c772"), "توحيد", 20 },
                    { 723, new Guid("5a445691-ea5c-45c0-82c7-c709f1445119"), "بلاوه", 20 },
                    { 722, new Guid("4566fd18-4486-4012-a53f-d065a8b312e8"), "بدره", 20 },
                    { 721, new Guid("ba369d3a-1c9a-449a-a2f5-d5f3098fdd36"), "ايوان", 20 },
                    { 720, new Guid("b814f060-6c46-4447-8e06-2a8c54e356ff"), "ايلام", 20 },
                    { 719, new Guid("6118cdc4-0884-4439-a314-e220665a5ba6"), "ارکواز", 20 },
                    { 726, new Guid("501da80b-81bf-42c4-8207-b8b394d4748a"), "دلگشا", 20 },
                    { 931, new Guid("49531e3f-6958-4fd3-be24-fa7d9d1a98b4"), "ميمند", 23 },
                    { 933, new Guid("0431ccc9-a914-4f2c-8563-cb96fda85411"), "نوجين", 23 },
                    { 621, new Guid("5dc1b327-9bc2-41c4-b337-8483d41c6f2d"), "بادرود", 19 },
                    { 1143, new Guid("4ce1a199-d96b-4985-b863-60815ab238b8"), "بزنجان", 29 },
                    { 1142, new Guid("1e2f72c4-b8df-4cf3-ad03-1ed8d91f5dba"), "بروات", 29 },
                    { 1141, new Guid("222f4ebc-72d6-43ca-9047-e9f07e5277c2"), "بردسير", 29 },
                    { 1140, new Guid("7653f303-2fca-4714-aebe-6809d7c415dd"), "بافت", 29 },
                    { 1139, new Guid("8fbfe4a3-fc90-4762-a078-283ebe88ca96"), "باغين", 29 },
                    { 1138, new Guid("4b159cae-0126-464b-a254-1af4a5db6503"), "اندوهجرد", 29 },
                    { 1137, new Guid("af7a90cf-a7a6-4f18-a238-2dc4036ccf2b"), "انار", 29 },
                    { 1136, new Guid("56995a35-c183-4f27-98fd-3a6a79fbd7ae"), "امين شهر", 29 },
                    { 1135, new Guid("93a5757c-1b22-40ee-8376-aa3b9b51da18"), "ارزوئيه", 29 },
                    { 1134, new Guid("c0da8589-211d-4ca3-a81c-6cb44d108f24"), "اختيار آباد", 29 },
                    { 1133, new Guid("c6f6eed1-2e08-49df-968c-d031eb59c605"), "گيان", 28 },
                    { 1132, new Guid("fe498f4d-0936-492e-909e-0c7207e3cd50"), "گل تپه", 28 },
                    { 1131, new Guid("b447d1fa-13c8-4af3-9e5b-31663198803c"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("c92e79ba-4440-4d34-a88a-04828f019616"), "همدان", 28 },
                    { 1129, new Guid("a11d1386-dcfd-4ace-b546-6f1911e91491"), "نهاوند", 28 },
                    { 1144, new Guid("0d9245c9-3a6d-4fcd-9ded-e3f69116651b"), "بلورد", 29 },
                    { 1145, new Guid("fbd12896-1b3a-4234-9abe-7666ed752d4c"), "بلوک", 29 },
                    { 1146, new Guid("605d9fcc-8ffd-4c85-9339-201dd25c3dcc"), "بم", 29 },
                    { 1147, new Guid("85ec8fc0-cdea-4ad1-8f82-a536447a54e5"), "بهرمان", 29 },
                    { 1163, new Guid("dd51ea2d-b903-4bee-a38d-81d5e46df83a"), "رفسنجان", 29 },
                    { 1162, new Guid("b4ae3117-cd25-4a43-ac1f-9aee8b5a4e59"), "راين", 29 },
                    { 1161, new Guid("25ca37b0-ffe0-40f8-a140-b815d736b4b4"), "راور", 29 },
                    { 1160, new Guid("3b2a5176-325b-4568-97c3-a1095c310e55"), "رابر", 29 },
                    { 1159, new Guid("9ce07edb-5d19-4c1a-a621-749a8640e204"), "دوساري", 29 },
                    { 1158, new Guid("1a7e04ef-5ec4-4566-98bf-b9842ff1b89a"), "دهج", 29 },
                    { 1157, new Guid("529f3db4-7d7d-42ee-b7ef-2c0825b99f8e"), "دشتکار", 29 },
                    { 1128, new Guid("3875e871-2228-48d8-bb18-bd3a6e3d10e7"), "مهاجران", 28 },
                    { 1156, new Guid("91d4fdb1-8af0-4748-8f66-b8ba554c632a"), "درب بهشت", 29 },
                    { 1154, new Guid("9fbdbd1a-975b-4324-8629-c42828446ac1"), "خواجوشهر", 29 },
                    { 1153, new Guid("ed3a94d2-6f77-4c65-b72f-f42d2af955e6"), "خانوک", 29 },
                    { 1152, new Guid("42427065-6cf8-4a80-a934-233377829519"), "خاتون آباد", 29 },
                    { 1151, new Guid("4361821d-eb96-4988-a273-a5c25c7c1374"), "جيرفت", 29 },
                    { 1150, new Guid("a023af6d-61f0-4f5d-ad67-cefac1b1e305"), "جوپار", 29 },
                    { 1149, new Guid("ed29d5b0-be15-4ca4-9997-3db3a615a287"), "جوزم", 29 },
                    { 1148, new Guid("a69c8919-600a-4f45-9f92-98f92b1eb677"), "جبالبارز", 29 },
                    { 1155, new Guid("c104462b-caad-42fd-9466-36df7c0205a2"), "خورسند", 29 },
                    { 1164, new Guid("524801ff-3589-4cf2-8352-d960511fec90"), "رودبار", 29 },
                    { 1127, new Guid("fa9a6dc9-e82e-4f96-b0d2-219f990de2ba"), "ملاير", 28 },
                    { 1125, new Guid("8b9b79a3-2d1a-443a-a96e-0aa57feb5a85"), "لالجين", 28 },
                    { 1104, new Guid("e03bd35c-6889-4538-ad49-4b362fdea83f"), "گوراب زرميخ", 27 },
                    { 1103, new Guid("5324e3a7-0eb1-42bd-9479-74bd6655f3ac"), "کياشهر", 27 },
                    { 1102, new Guid("2c5cb3ec-92fd-40cc-9f25-71374c21fd58"), "کوچصفهان", 27 },
                    { 1101, new Guid("e1b2030c-f3dd-4709-85d5-489f548528c6"), "کومله", 27 },
                    { 1100, new Guid("d56a4dd8-1a1e-4225-9e73-77aff9f2c883"), "کلاچاي", 27 },
                    { 1099, new Guid("dd9c742a-1132-4383-a623-0264155e1d86"), "چوبر", 27 },
                    { 1098, new Guid("a6fadb42-f456-46d1-94f0-b7a6fd8b5735"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("9823c3ed-ba80-49f0-8efe-9568e9cbcc06"), "چابکسر", 27 },
                    { 1096, new Guid("0a975f47-c93d-49d2-8943-1dbf902159e8"), "پره سر", 27 },
                    { 1095, new Guid("63e12d8e-ab75-4729-811b-0e633d2e49e1"), "واجارگاه", 27 },
                    { 1094, new Guid("59248b54-7b6c-44bd-a225-01d8938d044b"), "هشتپر", 27 },
                    { 1093, new Guid("43f896c9-e6a8-4a1c-9c8b-d245eb117f43"), "منجيل", 27 },
                    { 1092, new Guid("e8bac42f-8b8a-43fa-9b0a-e3cafd1f1d63"), "مرجقل", 27 },
                    { 1091, new Guid("4ea5a7bc-5ce1-4ec7-8223-097414e90911"), "ماکلوان", 27 },
                    { 1090, new Guid("166abeb9-0815-4949-a364-1154fa8e6bb6"), "ماسوله", 27 },
                    { 1105, new Guid("ffd21eba-1a39-4c2a-9ddc-1dcae87393f8"), "آجين", 28 },
                    { 1106, new Guid("48842565-327b-4597-9d6c-2a9fd64f37f3"), "ازندريان", 28 },
                    { 1107, new Guid("41a28cf8-6251-4d9f-8726-9068b9f7d948"), "اسد آباد", 28 },
                    { 1108, new Guid("d80f1158-4af8-4e91-8ea9-c27f35d3bbc0"), "برزول", 28 },
                    { 1124, new Guid("7425c036-43db-4274-9b91-eca960b3da84"), "قهاوند", 28 },
                    { 1123, new Guid("0201caed-a2cd-4f6b-b0c0-c2c239af49a7"), "قروه در جزين", 28 },
                    { 1122, new Guid("1f8e3543-e7a0-4622-986a-4bf6a2ac33de"), "فيروزان", 28 },
                    { 1121, new Guid("548e675f-e2af-4b3b-ae4e-1fda8cc676af"), "فرسفج", 28 },
                    { 1120, new Guid("7bbf18d0-1999-4995-a284-94a761fcadde"), "فامنين", 28 },
                    { 1119, new Guid("7e69d4ce-d0e9-4e0e-92f2-1827157fa574"), "صالح آباد", 28 },
                    { 1118, new Guid("0f2e96a5-e266-4baa-89be-615bb8e4e3c1"), "شيرين سو", 28 },
                    { 1126, new Guid("26ea7746-e630-45ee-8cf0-78a8706ce272"), "مريانج", 28 },
                    { 1117, new Guid("6a9b7347-acb7-48aa-8737-a1ef17e03974"), "سرکان", 28 },
                    { 1115, new Guid("9b193ca4-af5f-4bf4-9e36-da104b3345aa"), "زنگنه", 28 },
                    { 1114, new Guid("a28fdaf1-44bc-4c0d-a118-f545f6ee09b1"), "رزن", 28 },
                    { 1113, new Guid("80158690-2ce4-48fc-9c57-3ed93e59ce8a"), "دمق", 28 },
                    { 1112, new Guid("b355b71d-25bf-4976-b296-fb3a6adc55db"), "جوکار", 28 },
                    { 1111, new Guid("c22fe030-51e7-4e6d-81a5-19e7683259e2"), "جورقان", 28 },
                    { 1110, new Guid("60a281e1-086d-49b3-9a50-b869de6ce442"), "تويسرکان", 28 },
                    { 1109, new Guid("c2b264ef-462e-4599-904c-ca48a1d15adb"), "بهار", 28 },
                    { 1116, new Guid("f205bd21-623a-42f1-b340-2b3eb192be4a"), "سامن", 28 },
                    { 1089, new Guid("1e2271d4-fa0f-4b3f-afa2-c4a2ecb0216b"), "ماسال", 27 },
                    { 1165, new Guid("de3c82bb-88a7-4fb6-9fc7-cc99d1241ff2"), "ريحان", 29 },
                    { 1167, new Guid("6995d6f2-672c-46a3-8fa9-2661518da5b6"), "زنگي آباد", 29 },
                    { 1221, new Guid("01518348-a6ac-4e09-b56f-5ca79eddb0c7"), "کلاته", 30 },
                    { 1220, new Guid("471f15a2-4640-410f-9662-3847abb6b533"), "ميامي", 30 },
                    { 1219, new Guid("d224cd09-5e09-4b6e-bb87-141cf4bb9516"), "مهدي شهر", 30 },
                    { 1218, new Guid("64423d24-a58b-4050-8647-20a107fc591b"), "مجن", 30 },
                    { 1217, new Guid("f6b83cb6-4898-4b0a-a0e5-b9c708a5a8c1"), "شهميرزاد", 30 },
                    { 1216, new Guid("09aab17a-bd19-482c-822b-fbde23e1dbc2"), "شاهرود", 30 },
                    { 1215, new Guid("c3b8e6e2-45ca-45c6-8bb3-1130c450289b"), "سمنان", 30 },
                    { 1214, new Guid("760d172a-8246-4738-85cf-3edce79611b5"), "سرخه", 30 },
                    { 1213, new Guid("080ca0d4-05ef-499a-9501-8f6326a484f9"), "روديان", 30 },
                    { 1212, new Guid("3454cbf8-d22f-497c-98b5-4473ec9bfd88"), "ديباج", 30 },
                    { 1211, new Guid("7d696213-0e81-4a03-8ab5-56da56490610"), "درجزين", 30 },
                    { 1210, new Guid("82a3ca85-fca2-40bd-afdf-43259b3a8e3d"), "دامغان", 30 },
                    { 1209, new Guid("ac3c8530-8427-4112-ac99-7f44aa1fb621"), "بيارجمند", 30 },
                    { 1208, new Guid("0fbcf51b-1bef-446b-af0d-6bbac44dbaaf"), "بسطام", 30 },
                    { 1207, new Guid("0f1fecaf-6294-45fa-aed6-b42ee610397b"), "ايوانکي", 30 },
                    { 1222, new Guid("d4e7cd9c-0576-4cca-9578-05072104c93c"), "کلاته خيج", 30 },
                    { 1223, new Guid("ef9d8522-95a2-49cb-b686-d1382107625d"), "کهن آباد", 30 },
                    { 1224, new Guid("5d5205ef-9a37-4da0-9cb3-b3dccdc137b5"), "گرمسار", 30 },
                    { 1225, new Guid("be0f0280-b9c9-49b0-a46a-bb5a46303a5a"), "باشت", 31 },
                    { 1241, new Guid("ad9e0e7b-4c2b-4937-83d3-350104e11ae1"), "گراب سفلي", 31 },
                    { 1240, new Guid("7f566a04-eef3-4a80-a4a0-8d26cd0bbeca"), "چيتاب", 31 },
                    { 1239, new Guid("5ef1fa6e-9ee5-463b-93c7-fc67c4fcd033"), "چرام", 31 },
                    { 1238, new Guid("dba6ece1-ec8e-4a06-b0e9-d22328fc63bc"), "پاتاوه", 31 },
                    { 1237, new Guid("9c25944a-9a58-4a2f-bcc9-d11e19e36255"), "ياسوج", 31 },
                    { 1236, new Guid("b00415ee-9726-4087-b87e-19b56599ccc2"), "مارگون", 31 },
                    { 1235, new Guid("0bde6b11-fa76-44cb-9b7d-d0cc98484cfb"), "مادوان", 31 },
                    { 1206, new Guid("ce7e8258-843d-417c-a72b-8d081b3d91bf"), "اميريه", 30 },
                    { 1234, new Guid("5c7f39d4-31d2-4bf2-8517-57fe92160c02"), "ليکک", 31 },
                    { 1232, new Guid("23f142cc-4b9b-4164-821c-e15509fc5fec"), "قلعه رئيسي", 31 },
                    { 1231, new Guid("248243ed-5d93-478a-9f2b-33af141445b7"), "سي سخت", 31 },
                    { 1230, new Guid("e56eea28-f5ef-44b9-80fd-87e2868b030f"), "سوق", 31 },
                    { 1229, new Guid("d81d3474-6957-49b8-b49d-fa3499c8364e"), "سرفارياب", 31 },
                    { 1228, new Guid("0442c0ee-9aed-402a-b368-14f2e6571677"), "ديشموک", 31 },
                    { 1227, new Guid("331d74aa-45af-4be8-8a05-8926943897ca"), "دوگنبدان", 31 },
                    { 1226, new Guid("9db49add-ac74-45a9-abd0-2d21c98b396e"), "دهدشت", 31 },
                    { 1233, new Guid("fa0568c2-6fe5-4035-b4d4-002e88ed2398"), "لنده", 31 },
                    { 1166, new Guid("76b96d50-10df-4c6b-98d0-f43fee4dcf40"), "زرند", 29 },
                    { 1205, new Guid("e26f50f4-2e92-4ad9-bcd1-71688d88de15"), "آرادان", 30 },
                    { 1203, new Guid("7fbbf3dd-c052-400f-9f7c-e5d3514bed3f"), "گلزار", 29 },
                    { 1182, new Guid("927c12c3-ce2b-43a0-b4e1-f89399a3b635"), "مردهک", 29 },
                    { 1181, new Guid("b963d105-4fb6-483d-b0ad-3d130b30ee96"), "محي آباد", 29 },
                    { 1180, new Guid("00814895-0547-491e-9271-c28ff6279e6b"), "محمد آباد", 29 },
                    { 1179, new Guid("0f230d0b-aabb-4d35-9b77-aec48616578e"), "ماهان", 29 },
                    { 1178, new Guid("08f5e4e9-9141-4d18-9379-63227c6320e7"), "لاله زار", 29 },
                    { 1177, new Guid("71d6dba6-a4ca-460b-a1fb-076fb33d1826"), "قلعه گنج", 29 },
                    { 1176, new Guid("bae35a4b-1613-46e1-95bd-5dd045acbaf7"), "فهرج", 29 },
                    { 1175, new Guid("3004674c-5871-4b1e-8229-6895a8a21c71"), "فارياب", 29 },
                    { 1174, new Guid("ed94e5fe-c0b5-434d-968f-0285880323c6"), "عنبر آباد", 29 },
                    { 1173, new Guid("04de5ee4-0b4e-4a62-993f-01651ce424c8"), "صفائيه", 29 },
                    { 1172, new Guid("5aaf54c3-a8d2-4031-b3c7-ebf32955f734"), "شهر بابک", 29 },
                    { 1171, new Guid("475e077c-757f-4649-b9d6-6fcf12bae6b2"), "شهداد", 29 },
                    { 1170, new Guid("67da20eb-b889-405c-8168-8ded1edd518e"), "سيرجان", 29 },
                    { 1169, new Guid("a5e74032-672c-4142-9b4b-eeb58b5928fb"), "زيد آباد", 29 },
                    { 1168, new Guid("37020a74-dd74-454d-9d78-dbbccd2c5ab1"), "زهکلوت", 29 },
                    { 1183, new Guid("2aaaa3bb-c2c3-41db-876d-eaa7cbf5b56c"), "مس سرچشمه", 29 },
                    { 1184, new Guid("ced52262-6995-41ef-954a-34f23739bccd"), "منوجان", 29 },
                    { 1185, new Guid("ea1919b9-efe7-446d-ad96-deee58e92b3f"), "نجف شهر", 29 },
                    { 1186, new Guid("ef1cb470-6f5b-47e6-873c-e28fda0874a4"), "نرماشير", 29 },
                    { 1202, new Guid("1f467413-a962-4795-8c55-7389078e87cf"), "گلباف", 29 },
                    { 1201, new Guid("b2481bcf-b310-4f6f-8d50-869c7dc0576e"), "کيانشهر", 29 },
                    { 1200, new Guid("5c5069c6-635e-4db2-b37e-722f3e3180b4"), "کوهبنان", 29 },
                    { 1199, new Guid("8b735216-28f2-4cd5-b37c-48210b7eabe3"), "کهنوج", 29 },
                    { 1198, new Guid("5cfaebdf-4585-49cb-a8ab-6c06ac47809d"), "کشکوئيه", 29 },
                    { 1197, new Guid("d5661b91-a11e-4d60-a87c-aca6d599b0a8"), "کرمان", 29 },
                    { 1196, new Guid("2bab4ead-1f52-4d0e-b2ad-32a0b055c7d3"), "کاظم آباد", 29 },
                    { 1204, new Guid("f4c9941c-5a1e-4776-843f-79e71cdc5ffb"), "گنبکي", 29 },
                    { 1195, new Guid("500bf3c9-ca47-48ce-892a-e6d90a18bb6d"), "چترود", 29 },
                    { 1193, new Guid("9be5023e-4a0a-4dbc-afaf-299178ed6802"), "يزدان شهر", 29 },
                    { 1192, new Guid("be641034-67b9-4708-9f2b-4a0653a8ab00"), "هنزا", 29 },
                    { 1191, new Guid("6a39d49b-bf72-4019-9459-273fb6f40f2b"), "هماشهر", 29 },
                    { 1190, new Guid("6350163c-8293-4f68-9d2b-a82d5e78a820"), "هجدک", 29 },
                    { 1189, new Guid("ed0dae58-5583-4162-bb2d-193e619c546a"), "نگار", 29 },
                    { 1188, new Guid("7c5e1a75-a05e-4559-9573-13cac873db7b"), "نودژ", 29 },
                    { 1187, new Guid("722e8bf1-3fde-4a1f-9dca-0f15251be174"), "نظام شهر", 29 },
                    { 1194, new Guid("7bb4c52e-a74d-4d58-a0e9-37df007aeac5"), "پاريز", 29 },
                    { 932, new Guid("983fd751-a191-46cb-ab5a-1822a5c49d17"), "نوبندگان", 23 },
                    { 1088, new Guid("3912c825-bc39-41e1-88f5-0ad826004543"), "ليسار", 27 },
                    { 1086, new Guid("e83fbf88-f26b-4fa1-b6cf-07fce7328cff"), "لولمان", 27 },
                    { 987, new Guid("7d78a5d4-9646-4499-963f-4a588776d65d"), "تازيان پائين", 25 },
                    { 986, new Guid("e8ab7814-ffb7-4a90-97c2-65e244f98bf9"), "بيکاه", 25 },
                    { 985, new Guid("2f89bdf2-076e-4706-b948-d8f25a131f78"), "بندر لنگه", 25 },
                    { 984, new Guid("82bb4e0d-f5eb-4ec3-ba21-f3e65a3ceb97"), "بندر عباس", 25 },
                    { 983, new Guid("239053f0-1811-418d-8483-1e62c901235f"), "بندر جاسک", 25 },
                    { 982, new Guid("a5c11e7d-2e2d-4b69-abf8-2fc44cbb55fc"), "بستک", 25 },
                    { 981, new Guid("79e5105b-4cbe-4b08-aeff-bd1dabfaceee"), "ابوموسي", 25 },
                    { 980, new Guid("e919f825-f913-4f35-8255-95565c9338b9"), "گيلانغرب", 24 },
                    { 979, new Guid("3f465357-87f9-464e-a37e-214c24bce5d9"), "گودين", 24 },
                    { 978, new Guid("6ce9199e-7f6f-4eaf-a592-53b6e28410f2"), "گهواره", 24 },
                    { 977, new Guid("7943a630-ca30-4838-859f-1353402566e7"), "کوزران", 24 },
                    { 976, new Guid("fc89027d-676d-41c2-9481-9fd3d3d43f9f"), "کنگاور", 24 },
                    { 975, new Guid("f77758da-66c1-42ff-aeb9-8af3217ba757"), "کرند غرب", 24 },
                    { 974, new Guid("13803c83-6a4e-4ce5-80ed-8edd08c09ed8"), "کرمانشاه", 24 },
                    { 973, new Guid("3c7b4406-2f4d-4bbb-9b84-db2d71c46620"), "پاوه", 24 },
                    { 988, new Guid("3245515c-97f8-49f7-a175-598da4f2ca4f"), "تخت", 25 },
                    { 989, new Guid("9f74f726-1226-461f-aa78-9933dc0570ed"), "تيرور", 25 },
                    { 990, new Guid("12b84b65-b005-46dc-88aa-c9619cf0d31b"), "جناح", 25 },
                    { 991, new Guid("a75968e6-0b64-4136-876a-fb7fea9c54aa"), "حاجي آباد", 25 },
                    { 1007, new Guid("860d3f77-83ab-42bb-9533-8f45e49126fb"), "لمزان", 25 },
                    { 1006, new Guid("b3f252e3-38f0-4218-a626-e785558eb270"), "قلعه قاضي", 25 },
                    { 1005, new Guid("b4859bd5-c557-4bcb-9614-32d1186e19f4"), "قشم", 25 },
                    { 1004, new Guid("19b88823-d47d-49d4-a913-5a69da4c1bad"), "فين", 25 },
                    { 1003, new Guid("136fbffb-69ca-4f6e-ad6b-842f30351114"), "فارغان", 25 },
                    { 1002, new Guid("aae917f8-458a-4ed3-89b7-e807339f1523"), "سيريک", 25 },
                    { 1001, new Guid("087fdf40-8b9b-4faa-8f05-16b6becb64c9"), "سوزا", 25 },
                    { 972, new Guid("7583eaeb-c906-4253-b7b8-56cd74be3d26"), "هلشي", 24 },
                    { 1000, new Guid("91cbb073-5eff-4bcc-bdb8-842aad7776b2"), "سندرک", 25 },
                    { 998, new Guid("8c216bfe-016b-44db-a193-bb2d2d0e9a47"), "سردشت", 25 },
                    { 997, new Guid("d5ac4e4e-12cd-4b6c-b78a-9617a892095a"), "زيارتعلي", 25 },
                    { 996, new Guid("76d27855-0501-4a5c-96c7-b6ee311b8fa6"), "رويدر", 25 },
                    { 995, new Guid("ed75347b-3254-4854-b970-0b8d93ece148"), "دهبارز", 25 },
                    { 994, new Guid("bdba5bad-6a45-4472-9dc8-9bccafe03bab"), "دشتي", 25 },
                    { 993, new Guid("847a6dd5-efe3-4f6e-833a-4b4eb0c9f176"), "درگهان", 25 },
                    { 992, new Guid("0e962fa1-4cec-4c92-a04b-4119e96e7a0c"), "خمير", 25 },
                    { 999, new Guid("dd35afbb-85e9-47c5-b44d-1fa3d591ca2c"), "سرگز", 25 },
                    { 1008, new Guid("74c378e8-489a-48d1-8ac0-c9e6018a6ada"), "ميناب", 25 },
                    { 971, new Guid("36f61553-9580-4d8c-b658-2a87153f73a4"), "هرسين", 24 },
                    { 969, new Guid("cd78d77b-522f-4dfb-8a63-ca73e218eb21"), "نودشه", 24 },
                    { 948, new Guid("e0f4f6f6-a95c-49db-bc38-3af587474c28"), "گله دار", 23 },
                    { 947, new Guid("b2cc9c80-af06-4a88-b017-6e99757b80cc"), "گراش", 23 },
                    { 946, new Guid("718237cc-5f73-4382-8c43-c1f89704331a"), "کوپن", 23 },
                    { 945, new Guid("ac70a27a-e69d-41d4-b5d2-850735e2449d"), "کوهنجان", 23 },
                    { 944, new Guid("8f3d502f-228e-41b2-b10f-f9880448197b"), "کوار", 23 },
                    { 943, new Guid("2ed726ee-164f-4808-8fd5-82d84cf55b78"), "کنار تخته", 23 },
                    { 942, new Guid("9464cafa-c9f9-4219-a4b5-69acb85f2006"), "کره اي", 23 },
                    { 941, new Guid("9fa14ac1-1d4b-45ca-a6cd-c51f37f09c14"), "کامفيروز", 23 },
                    { 940, new Guid("ab249c0f-6667-4961-90cc-e5561b621d7b"), "کازرون", 23 },
                    { 939, new Guid("58372ef3-0e59-4006-9672-dffbada3e8f5"), "کارزين", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 938, new Guid("945e4aa8-1120-4586-a8e0-d81239cb3a99"), "وراوي", 23 },
                    { 937, new Guid("64713485-38e9-451d-b4a6-f706377f2558"), "هماشهر", 23 },
                    { 936, new Guid("fca5b5b4-23d3-4da5-849e-78d51813ca56"), "ني ريز", 23 },
                    { 935, new Guid("e7e669b3-def4-43a5-8bfc-d4cac7b825c1"), "نورآباد", 23 },
                    { 934, new Guid("9515d237-1c6e-438e-8372-6ce4e37f9609"), "نودان", 23 },
                    { 949, new Guid("a119d355-7a81-44f1-8139-46545127503b"), "ازگله", 24 },
                    { 950, new Guid("98f103c1-3749-4244-92fb-eca084108c51"), "اسلام آباد غرب", 24 },
                    { 951, new Guid("469965e3-ff65-4fc5-a0fa-4e16e6ff504c"), "بانوره", 24 },
                    { 952, new Guid("9e530503-ba26-4585-b6f9-c1d355ffc4af"), "باينگان", 24 },
                    { 968, new Guid("05365ccf-d86b-427f-92b9-94a6ffb52932"), "ميان راهان", 24 },
                    { 967, new Guid("6c7ba9b1-3235-42e1-8dc6-a7a8b22b355f"), "قصر شيرين", 24 },
                    { 966, new Guid("de630c71-0ade-48fb-8fdc-58e5c1c4837a"), "صحنه", 24 },
                    { 965, new Guid("b088ae7e-5ae7-434d-bb5f-198156ee690f"), "شاهو", 24 },
                    { 964, new Guid("1a5c00dc-72d4-4da3-b7d4-cc9792c2bc42"), "سومار", 24 },
                    { 963, new Guid("75696919-d4f4-4a23-bac9-1267da98715f"), "سنقر", 24 },
                    { 962, new Guid("0065ba27-1e27-4ad5-987b-9807a1516d2a"), "سطر", 24 },
                    { 970, new Guid("8bbe97af-c89b-4fa1-bd57-4e5aa82e8ccc"), "نوسود", 24 },
                    { 961, new Guid("d04c07f2-674e-4da6-b303-0378c6792c63"), "سرمست", 24 },
                    { 959, new Guid("f2f3fa9b-6df7-4e3d-ae9d-b7a249dc3b56"), "ريجاب", 24 },
                    { 958, new Guid("5b8f8816-f111-402c-ad52-f30c0819ff6b"), "روانسر", 24 },
                    { 957, new Guid("eb14ef5f-c101-4d5b-a5a4-6aac1e05b3a2"), "رباط", 24 },
                    { 956, new Guid("c7b20768-0c6f-4546-9c74-1313de94104c"), "حميل", 24 },
                    { 955, new Guid("5347fb22-6ad3-40c5-a7f6-f954fcf85cad"), "جوانرود", 24 },
                    { 954, new Guid("059320f5-629c-4981-94cb-834491b1254c"), "تازه آباد", 24 },
                    { 953, new Guid("c6d1d9e8-d83e-4436-a134-0217609e473c"), "بيستون", 24 },
                    { 960, new Guid("ab8e4ede-c1b3-463e-82fb-42103ead2952"), "سر پل ذهاب", 24 },
                    { 1087, new Guid("eeb67138-9d8b-49e3-9d40-f431e1638a7b"), "لوندويل", 27 },
                    { 1009, new Guid("08e6fc1d-e0d9-48fd-8a1b-8d9ea31bf886"), "هرمز", 25 },
                    { 1011, new Guid("ca625ece-7503-40b6-9392-9381f6cd1086"), "پارسيان", 25 },
                    { 1065, new Guid("3385b14c-3476-48a5-916c-3700413383fa"), "خشکبيجار", 27 },
                    { 1064, new Guid("9f1fc4fe-6b39-4123-8761-daca3e5b2e2c"), "حويق", 27 },
                    { 1063, new Guid("f67e442e-9558-46ff-96f6-d6c470e607d2"), "جيرنده", 27 },
                    { 1062, new Guid("6c9f77ad-52f8-4fff-927c-c4a3f141683a"), "توتکابن", 27 },
                    { 1061, new Guid("ff94b7eb-5a6e-4f2b-85bc-09b1774a0759"), "بندر انزلي", 27 },
                    { 1060, new Guid("96c1d751-da79-433f-a055-e55f3b4b6e1b"), "بره سر", 27 },
                    { 1059, new Guid("9ba0f59d-2c46-46c0-b3d4-f437cebb3b1f"), "بازار جمعه", 27 },
                    { 1058, new Guid("5850f2e1-e07b-4b67-8e1a-6f190d9997b4"), "املش", 27 },
                    { 1057, new Guid("b21292c6-5fb6-40e0-a99e-de8983e70fa0"), "اطاقور", 27 },
                    { 1056, new Guid("cbcf3ab9-0aa5-46ba-a1c4-a1ccbb1eb5c9"), "اسالم", 27 },
                    { 1055, new Guid("f867bf2e-2a86-40a4-bb1d-e1a25f4609bb"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("79c05079-d5f8-46f7-8712-a0de74d9f300"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("f7fd1814-66c9-4a2d-9af5-89e94a4e3e2d"), "آستارا", 27 },
                    { 1052, new Guid("2ab21653-f751-43fc-8214-7d630300b115"), "کميجان", 26 },
                    { 1051, new Guid("5f5a228c-499d-40d1-aa15-161a91e36267"), "کارچان", 26 },
                    { 1066, new Guid("612224f8-0699-469c-8119-1f13fcdef022"), "خمام", 27 },
                    { 1067, new Guid("7bd9a2e2-83c6-4bbc-9eb1-74a5400127bc"), "ديلمان", 27 },
                    { 1068, new Guid("baed1f84-30f0-413e-a8eb-2da45c90bccf"), "رانکوه", 27 },
                    { 1069, new Guid("89e04516-56f9-40dd-9533-13172ac32950"), "رحيم آباد", 27 },
                    { 1085, new Guid("d8206696-bdbd-4817-817b-c187783a7b30"), "لوشان", 27 },
                    { 1084, new Guid("3b590594-d639-4504-a8e1-f0e22b7b307d"), "لنگرود", 27 },
                    { 1083, new Guid("d50a725e-cc9e-4d71-aa09-6f89ec987a18"), "لشت نشاء", 27 },
                    { 1082, new Guid("2556ca90-580a-47f7-84fd-90208d22fd76"), "لاهيجان", 27 },
                    { 1081, new Guid("f40d0415-a986-4a94-8f45-d831283abe72"), "فومن", 27 },
                    { 1080, new Guid("6daf288d-c2fc-42a9-8235-965553fa2e47"), "صومعه سرا", 27 },
                    { 1079, new Guid("782b96b8-1e3c-4f42-b4b5-4edeba8fd946"), "شلمان", 27 },
                    { 1050, new Guid("d27a77a7-03c6-4c88-8619-c2e5def97cac"), "پرندک", 26 },
                    { 1078, new Guid("bdffd43b-575d-417b-8927-c4b306aa83cc"), "شفت", 27 },
                    { 1076, new Guid("fff26e6c-ec9d-49de-9777-85ece5d2238f"), "سنگر", 27 },
                    { 1075, new Guid("3dcc4b2a-d71c-4864-8cc8-ab9259a2b32a"), "رودسر", 27 },
                    { 1074, new Guid("d2860732-2666-4f64-82a3-1c9137744cd9"), "رودبنه", 27 },
                    { 1073, new Guid("3248e6e5-cd95-4b85-8cc2-38a41e582f94"), "رودبار", 27 },
                    { 1072, new Guid("9ae05c5f-c1fc-4263-b7cf-a074b64ed0cd"), "رضوانشهر", 27 },
                    { 1071, new Guid("16d3f5f5-0b1c-4fe5-8883-b2bebecad510"), "رشت", 27 },
                    { 1070, new Guid("50c201ae-ac7d-448f-816d-b54af59d4437"), "رستم آباد", 27 },
                    { 1077, new Guid("7c5e9390-f1a0-4239-b4fc-aa48b906cbe0"), "سياهکل", 27 },
                    { 1010, new Guid("48f364fe-ee7d-4e03-868b-6c3852b4f343"), "هشتبندي", 25 },
                    { 1049, new Guid("88f10ab7-f7ee-491c-8c9c-f663c1a8cebd"), "هندودر", 26 },
                    { 1047, new Guid("54f5df13-cb20-4743-bdfb-88941ddfdf24"), "نوبران", 26 },
                    { 1026, new Guid("00c92284-0b35-497d-93e3-f98c0807a2b1"), "جاورسيان", 26 },
                    { 1025, new Guid("dc22e89d-4da9-4a7e-9384-726b53b278cd"), "توره", 26 },
                    { 1024, new Guid("82830387-bc03-41ca-987f-10bd5b250372"), "تفرش", 26 },
                    { 1023, new Guid("c84c7b83-fefd-4b06-9dc9-fdc6eb6a42ac"), "اراک", 26 },
                    { 1022, new Guid("aa32c434-2272-4cef-be65-4d2106a9a932"), "آوه", 26 },
                    { 1021, new Guid("0e5773bb-ca4c-4b78-a13b-e3995566ead5"), "آشتيان", 26 },
                    { 1020, new Guid("352ae9e3-2e71-40eb-8f2d-9b1e91d17dc2"), "آستانه", 26 },
                    { 1019, new Guid("444a8947-850d-4d03-a0a5-5aad1d3278c8"), "گوهران", 25 },
                    { 1018, new Guid("baac4c75-de5e-4d24-ad5a-364e0e3cec20"), "گروک", 25 },
                    { 1017, new Guid("b2bcfbe1-a70c-4483-97ab-0f1b6dc73f92"), "کيش", 25 },
                    { 1016, new Guid("bd37a2d3-0773-4c89-8f09-9ae8d30a461a"), "کوهستک", 25 },
                    { 1015, new Guid("f110b4c6-d06a-456b-9393-e595a848da35"), "کوشکنار", 25 },
                    { 1014, new Guid("eb6bcc21-7eef-4f2b-847d-b1f922a76f6c"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("d00e89bc-835a-4b17-a7a8-c5f30953a6d6"), "کنگ", 25 },
                    { 1012, new Guid("0aedb41e-ff44-49ce-9cdd-4ffa87bc2ee6"), "چارک", 25 },
                    { 1027, new Guid("23ce818c-d130-4ba8-8d90-4d58cc63a5c4"), "خشکرود", 26 },
                    { 1028, new Guid("8a8b9dff-7764-4011-b23f-ae9981a414e0"), "خمين", 26 },
                    { 1029, new Guid("287fefee-0f8f-4a0f-a593-8b72c507b48c"), "خنجين", 26 },
                    { 1030, new Guid("334f037e-698e-4f24-ba9c-a84b0e6f7480"), "خنداب", 26 },
                    { 1046, new Guid("6a534d06-5e19-4229-a43d-cac58954c02c"), "نراق", 26 },
                    { 1045, new Guid("2b883ad4-168b-4758-b8a5-9c9ea195fd30"), "ميلاجرد", 26 },
                    { 1044, new Guid("531a9532-f79e-4920-94e7-ec6921a58dab"), "محلات", 26 },
                    { 1043, new Guid("fba603ae-abf4-4ce7-9621-dd2e54b6308d"), "مامونيه", 26 },
                    { 1042, new Guid("a95c1768-9a4e-432f-8444-93785795d5d7"), "قورچي باشي", 26 },
                    { 1041, new Guid("9e82f7ac-c99a-4180-9e5c-9dd389d43da7"), "فرمهين", 26 },
                    { 1040, new Guid("c7a7a8ac-c086-45e8-a60a-91ba3737a047"), "غرق آباد", 26 },
                    { 1048, new Guid("b90bd2ae-366b-4628-8088-83355ca51af5"), "نيمور", 26 },
                    { 1039, new Guid("9bfd2e9f-767d-4a1b-9647-4f348891a10f"), "شهر جديد مهاجران", 26 },
                    { 1037, new Guid("ee9a8f40-7396-4acf-aa7f-2f696d8ab2d1"), "شازند", 26 },
                    { 1036, new Guid("5a3143c5-0481-4b03-b104-c2a4027b34e1"), "ساوه", 26 },
                    { 1035, new Guid("488fcc98-c539-4613-b7b6-bcd437610a53"), "ساروق", 26 },
                    { 1034, new Guid("726bc986-97b1-41ce-8c43-18845b04bacb"), "زاويه", 26 },
                    { 1033, new Guid("b2e706ea-8d33-4b16-b852-c7380b845d79"), "رازقان", 26 },
                    { 1032, new Guid("ca115666-be4f-4993-afc4-7df5824c8cdf"), "دليجان", 26 },
                    { 1031, new Guid("d4e5c33a-4898-4f4e-85e8-86e1b2511980"), "داود آباد", 26 },
                    { 1038, new Guid("269545ee-e99c-44f4-ab08-e5b7e7593c51"), "شهباز", 26 },
                    { 620, new Guid("aee84e52-f0c5-49a7-9c29-e233174a1935"), "اژيه", 19 },
                    { 619, new Guid("6ea8f318-91a2-4d89-b4b7-dea98b490839"), "ايمانشهر", 19 },
                    { 618, new Guid("0d384181-da3b-45a4-9291-5cd68d484f7f"), "انارک", 19 },
                    { 209, new Guid("db55d870-bc73-43e8-b288-bd6439daf023"), "سنگان", 8 },
                    { 208, new Guid("88fd906e-0a95-4a97-9877-48e993b456ca"), "سلطان آباد", 8 },
                    { 207, new Guid("6de115cb-ed13-42d0-b130-8b7e3bba0041"), "سلامي", 8 },
                    { 206, new Guid("d5b22589-c6a5-43a4-b99d-d77f10d1307b"), "سفيد سنگ", 8 },
                    { 205, new Guid("fa9a7955-adbc-49a7-868a-4b19b011131d"), "سرخس", 8 },
                    { 204, new Guid("0b3578ab-5a60-49d0-9adf-e9d70078b9b7"), "سبزوار", 8 },
                    { 203, new Guid("f1113c2b-0602-409c-978e-f1831862d750"), "ريوش", 8 },
                    { 202, new Guid("a7e025b4-f10a-4f52-a17a-e6c9b5984df6"), "روداب", 8 },
                    { 201, new Guid("ee13c22d-5ca9-48a3-8799-96922d538ffc"), "رضويه", 8 },
                    { 200, new Guid("c5bf5566-61a8-4c63-9b1b-fb5c7837cbc4"), "رشتخوار", 8 },
                    { 199, new Guid("6de04a3a-1270-4d45-9b9f-16f0e17afb77"), "رباط سنگ", 8 },
                    { 198, new Guid("43ec0655-fec6-43be-a16d-d56878b1377d"), "دولت آباد", 8 },
                    { 197, new Guid("428759d7-216f-4109-9b41-ae7a570325dd"), "درگز", 8 },
                    { 196, new Guid("9333d4c1-e012-4e55-93e1-5d937acf0ee8"), "درود", 8 },
                    { 195, new Guid("46bf3bb1-1809-4ec0-9e18-577e28fd4e75"), "داورزن", 8 },
                    { 210, new Guid("e34aa997-bfde-4202-a8f0-3b52f2c1d7cb"), "شادمهر", 8 },
                    { 194, new Guid("595dee73-8b1d-4b44-8eb1-559a198876fb"), "خواف", 8 },
                    { 211, new Guid("bba8c811-0666-4ba2-87a1-dde4d14d5e5f"), "شانديز", 8 },
                    { 213, new Guid("92701a9e-c219-4df7-8629-7e1b9f907e61"), "شهر زو", 8 },
                    { 228, new Guid("27a2903e-d75e-4ff1-98df-89845098e704"), "مشهد", 8 },
                    { 227, new Guid("cbc47ac5-af7e-4015-af16-ed98dd4a3fa7"), "مزدآوند", 8 },
                    { 226, new Guid("b594be90-d9e1-4d23-972b-09fd8d6f80b3"), "لطف آباد", 8 },
                    { 225, new Guid("099997b5-ff0f-42e7-8f81-8c465d6f21a2"), "قوچان", 8 },
                    { 224, new Guid("b0f5aa1f-160e-484b-aff5-4bc5438723d0"), "قلندر آباد", 8 },
                    { 223, new Guid("2c3ca9ce-9847-491f-943c-083c4b2c3bc9"), "قدمگاه", 8 },
                    { 222, new Guid("53f5ae15-6d61-4842-908b-6250a2af4a8a"), "قاسم آباد", 8 },
                    { 221, new Guid("5c1ccaa5-de63-42c9-aa3f-982dd8f97eee"), "فيض آباد", 8 },
                    { 220, new Guid("51cf9e2c-28cc-4793-b0a5-3518f43bd1df"), "فيروزه", 8 },
                    { 219, new Guid("63301aad-6b8f-489c-96cc-5d120d3429a2"), "فريمان", 8 },
                    { 218, new Guid("c33ce2d0-165a-4639-8d7e-a4647cfb0bcf"), "فرهاد گرد", 8 },
                    { 217, new Guid("8a6a2982-f703-490e-818b-c7c62dddf8f0"), "عشق آباد", 8 },
                    { 216, new Guid("0e16f93d-fa85-40e0-bb08-130213d1a500"), "طرقبه", 8 },
                    { 215, new Guid("06f18b87-dede-4925-a47b-5dc5715f9f60"), "صالح آباد", 8 },
                    { 214, new Guid("052a3df0-7ba6-432e-aed9-df41247a361d"), "شهرآباد", 8 },
                    { 212, new Guid("591c4c25-6272-44f2-bed1-8c400961fb4d"), "ششتمد", 8 },
                    { 193, new Guid("f221fdf3-faf9-4099-8c98-b8dde830998a"), "خليل آباد", 8 },
                    { 192, new Guid("c1d45443-a585-4b6f-8073-c9bb765703e4"), "خرو", 8 },
                    { 191, new Guid("991b7993-d8f3-4f56-b813-36d7bba3c3a0"), "جنگل", 8 },
                    { 170, new Guid("e520bcc1-305e-4338-bf66-a17aaea4aa0d"), "نالوس", 7 },
                    { 169, new Guid("c6b88961-1402-4cc0-ab14-d5d7651962aa"), "نازک عليا", 7 },
                    { 168, new Guid("9acd0158-efc0-463f-9105-b19622e70677"), "ميرآباد", 7 },
                    { 167, new Guid("a122d085-ffb5-4ef1-9605-54220f4b141b"), "مياندوآب", 7 },
                    { 166, new Guid("93175609-464e-4d0d-8ac9-ef4edc2cd31a"), "مهاباد", 7 },
                    { 165, new Guid("e02e6dc8-814d-4978-8f54-a5d06e06a837"), "مرگنلر", 7 },
                    { 164, new Guid("bda6f00a-80df-41d1-96e5-39001b2b4239"), "محمود آباد", 7 },
                    { 163, new Guid("d3d58cf6-3430-4d79-a0a5-a0f31ce0936e"), "محمد يار", 7 },
                    { 162, new Guid("cb0ba091-de1c-47be-a2aa-e0d257ebbc68"), "ماکو", 7 },
                    { 161, new Guid("5df2a4ea-d9cf-4e17-9e3e-63bf6b9ce9a8"), "قوشچي", 7 },
                    { 160, new Guid("7a704d69-b06c-476e-866b-ac628d6c6ca6"), "قطور", 7 },
                    { 159, new Guid("c63cb092-0d46-40ba-b6cf-2c45954e402c"), "قره ضياء الدين", 7 },
                    { 158, new Guid("f170dca2-1abc-4709-be3a-9cebb747e494"), "فيرورق", 7 },
                    { 157, new Guid("b6155003-8f31-426a-85c8-f4ee32176142"), "شوط", 7 },
                    { 156, new Guid("27577a6c-6e1b-4646-a88e-4fc43b78443d"), "شاهين دژ", 7 },
                    { 171, new Guid("e3bd7252-b2e8-458f-901a-992c8474e806"), "نقده", 7 },
                    { 172, new Guid("95403b04-e3ba-499e-a759-1f56eb1b5fe9"), "نوشين", 7 },
                    { 173, new Guid("899fdc8c-d786-4fc5-bae4-f6875d7b0ddd"), "پلدشت", 7 },
                    { 174, new Guid("81b76340-c1ce-4a9b-9253-ee124268c89b"), "پيرانشهر", 7 },
                    { 190, new Guid("6971d219-f05a-4f99-9033-69b390d9576c"), "جغتاي", 8 },
                    { 189, new Guid("8eb38ba6-a4f8-4080-8a90-daf576cc6171"), "تربت حيدريه", 8 },
                    { 188, new Guid("b70572c2-215a-4d93-b85e-9405158455a4"), "تربت جام", 8 },
                    { 187, new Guid("4c8237ab-7a4f-4d6e-90a9-182bf8184735"), "تايباد", 8 },
                    { 186, new Guid("eb73ca91-5ce8-45a1-9e63-0d1bb7395a70"), "بيدخت", 8 },
                    { 185, new Guid("d6f80388-403b-46ce-9338-6c2baae6306b"), "بردسکن", 8 },
                    { 184, new Guid("580609e3-74ad-41d4-849d-f1cdbf539be2"), "بجستان", 8 },
                    { 229, new Guid("fa41d107-3efd-4639-a038-937e03c85a61"), "مشهدريزه", 8 },
                    { 183, new Guid("8d362134-7dfb-4871-a369-32af828cfa74"), "بايک", 8 },
                    { 181, new Guid("4747cfd6-a957-4987-9e20-47583dcee18b"), "باخرز", 8 },
                    { 180, new Guid("ca6a0304-e1dc-4d45-9639-c0bc626e940c"), "باجگيران", 8 },
                    { 179, new Guid("69241ff9-e6f2-48a0-8168-fdac307c71b9"), "انابد", 8 },
                    { 178, new Guid("67a71031-80d7-4802-933b-13310990c75b"), "احمدآباد صولت", 8 },
                    { 177, new Guid("2e510472-5b59-4ee5-931c-290c684da027"), "گردکشانه", 7 },
                    { 176, new Guid("31dd7ef4-08f7-4031-a5e9-397873a6a242"), "کشاورز", 7 },
                    { 175, new Guid("21e11d62-240a-4e79-9127-985de31f8c9e"), "چهار برج", 7 },
                    { 182, new Guid("6737bd5f-2e9f-4c1d-8b61-effc8e25ce6a"), "بار", 8 },
                    { 230, new Guid("436ba99f-a12c-4c63-a18f-c0a7c3ea97bb"), "ملک آباد", 8 },
                    { 231, new Guid("73cf77d8-7922-471b-9a01-7149a596f69e"), "نشتيفان", 8 },
                    { 232, new Guid("a76ab56e-b8e6-43f9-b08d-ef9cf53fbbd0"), "نصرآباد", 8 },
                    { 286, new Guid("501d5f3f-3079-4ce8-bf4a-622a39289495"), "گلمورتي", 9 },
                    { 285, new Guid("18d6ba18-94e6-4cb2-adf8-ce4b8e90f934"), "گشت", 9 },
                    { 284, new Guid("41a3b258-a545-447d-8eeb-6a6061bca9dd"), "کنارک", 9 },
                    { 283, new Guid("3f8287bc-e4dc-4639-a23a-3cf7a1f99969"), "چاه بهار", 9 },
                    { 282, new Guid("e881a985-19ca-4691-8f8d-0950b33850ad"), "پيشين", 9 },
                    { 281, new Guid("123290c9-55a4-4d31-87d6-c51de021aaa9"), "هيدوچ", 9 },
                    { 280, new Guid("6fcffbcd-bbf3-4563-8d3c-fef1943fdac8"), "نگور", 9 },
                    { 279, new Guid("093ae5ef-f6b6-4c6f-9061-0860d16a9ef1"), "نيک شهر", 9 },
                    { 278, new Guid("d3f6481e-bab3-4690-a7f8-cfb6d1e7d9ee"), "نوک آباد", 9 },
                    { 277, new Guid("cca02863-9221-4814-a93d-57bec70edd22"), "نصرت آباد", 9 },
                    { 276, new Guid("868b9830-d20a-4a33-bf50-0c811fd38558"), "ميرجاوه", 9 },
                    { 275, new Guid("7ce672b9-5007-46fa-bc6a-e67ef47683e2"), "مهرستان", 9 },
                    { 274, new Guid("f651980b-3a01-4222-9b43-fdd70ca5c505"), "محمدي", 9 },
                    { 273, new Guid("369b8948-9c2f-45f0-8f7f-f3630129f183"), "محمدان", 9 },
                    { 272, new Guid("11d0a0ec-954e-4594-8938-422b3e145f19"), "محمد آباد", 9 },
                    { 287, new Guid("970afa80-5cbc-488c-9bc4-b9c461e4e216"), "آرين شهر", 10 },
                    { 288, new Guid("172f99fc-7d4f-41a4-849d-c3b05a7f3aae"), "آيسک", 10 },
                    { 289, new Guid("6476eec8-77ee-4058-882c-0dd4a943526d"), "ارسک", 10 },
                    { 290, new Guid("3bca75c5-204c-4167-b69e-0a20fc5a1970"), "اسديه", 10 },
                    { 307, new Guid("c1624cca-97ae-4577-8673-d317ca235dee"), "فردوس", 10 },
                    { 305, new Guid("f913dc2d-4682-409a-b1ac-44505c7c1a9f"), "طبس مسينا", 10 },
                    { 304, new Guid("74415264-67ae-4821-9c37-ebcc710a6663"), "طبس", 10 },
                    { 303, new Guid("863e9017-4206-4eaf-b140-5761307163ea"), "شوسف", 10 },
                    { 302, new Guid("b1c93218-f676-40a7-870b-91fdd50087ef"), "سه قلعه", 10 },
                    { 301, new Guid("c2532d3c-af0c-4f91-8d33-55aa3b394e23"), "سربيشه", 10 },
                    { 300, new Guid("9bbf6592-97cf-4769-b7d2-cf81603a7195"), "سرايان", 10 },
                    { 271, new Guid("26a397f3-d637-40a4-86d6-62a3c0f6ab90"), "قصر قند", 9 },
                    { 299, new Guid("77a4180f-f579-4489-9c73-060783852ea0"), "زهان", 10 },
                    { 297, new Guid("a4ab15dc-1893-4ab6-85a1-7e122883495e"), "خوسف", 10 },
                    { 296, new Guid("52b21dc5-578d-4900-80c9-c5600d2c6099"), "خضري دشت بياض", 10 },
                    { 295, new Guid("778075fa-a3d3-4164-b600-ad74cf7df1fc"), "حاجي آباد", 10 },
                    { 294, new Guid("51a3452a-791a-4255-86b1-ed9c5eb812c2"), "بيرجند", 10 },
                    { 293, new Guid("7eb2e000-c75f-466b-8264-2b53e5d47efc"), "بشرويه", 10 },
                    { 292, new Guid("168f3e98-082f-4a18-9b4e-2d1b1c0cb0a6"), "اسلاميه", 10 },
                    { 291, new Guid("4cea8071-7817-4579-b34a-1e27b98983ed"), "اسفدن", 10 },
                    { 298, new Guid("8a975d13-0a65-4a2e-b505-c2cd99419edc"), "ديهوک", 10 },
                    { 155, new Guid("b00b3624-f419-47eb-939b-f6deec6f6127"), "سيه چشمه", 7 },
                    { 270, new Guid("e455019a-a5b0-49a9-8f02-b6454a00f1b9"), "فنوج", 9 },
                    { 268, new Guid("63d2f3ec-e752-42ca-8373-60d64155ab68"), "سيرکان", 9 },
                    { 247, new Guid("901e042e-123a-433b-a8ea-98684dcba7c4"), "کندر", 8 },
                    { 246, new Guid("e1c3213c-16ce-439a-9b67-f25c8a69aa12"), "کلات", 8 },
                    { 245, new Guid("87711974-41c5-45ac-a97f-20ab325f485c"), "کدکن", 8 },
                    { 244, new Guid("beb0c4ff-a9c5-4931-a9a6-e173bb76696a"), "کاشمر", 8 },
                    { 243, new Guid("de67c02c-1702-4436-88b0-1dfc4c720bb5"), "کاريز", 8 },
                    { 242, new Guid("2a9b3d15-c803-43ab-9adf-2b8830422140"), "کاخک", 8 },
                    { 241, new Guid("acfba720-b550-4e22-8504-82d8156994f7"), "چکنه", 8 },
                    { 240, new Guid("d5874e7c-4df2-43fd-8536-2a933d6ab23f"), "چناران", 8 },
                    { 239, new Guid("d42c9523-e3f0-4657-bd65-fa1d326a4a2d"), "چاپشلو", 8 },
                    { 238, new Guid("9d21ed2e-0c7d-49f4-9e7a-319a8571c9d2"), "يونسي", 8 },
                    { 237, new Guid("6d1bf868-35d2-4e7a-b8fa-1841ec2bccb5"), "همت آباد", 8 },
                    { 236, new Guid("adc8e635-9b5a-4937-a11a-cc42a8a11cd9"), "نيل شهر", 8 },
                    { 235, new Guid("c08e1ed4-9304-41d9-92d6-5cf0a4d3f4d1"), "نيشابور", 8 },
                    { 234, new Guid("09ed5f83-dd4f-4b33-9b3d-1e1dd38187d3"), "نوخندان", 8 },
                    { 233, new Guid("8e8ebe1b-5ff3-4f87-92fd-779c8a828671"), "نقاب", 8 },
                    { 248, new Guid("bbb688c5-791b-4041-816e-56fab5f60d24"), "گلمکان", 8 },
                    { 249, new Guid("8a683d79-08b2-4f96-8651-bd57076b09e4"), "گناباد", 8 },
                    { 250, new Guid("2a1f1e17-f955-4cbb-9006-e6e661ba8f86"), "اديمي", 9 },
                    { 251, new Guid("a1b421ec-4842-4260-a97a-343176fc184d"), "اسپکه", 9 },
                    { 267, new Guid("ce3b5583-0373-487c-b414-6a0ee9c2a3c8"), "سوران", 9 },
                    { 266, new Guid("71292710-840b-4edf-92b1-f796372d2d01"), "سرباز", 9 },
                    { 265, new Guid("8349b0ba-77f4-4fb0-9b25-a3b63f2b7871"), "سراوان", 9 },
                    { 264, new Guid("32428d14-12d1-4b8e-8e77-06222c387a2d"), "زهک", 9 },
                    { 263, new Guid("659d8dab-9c79-40c4-af39-b7bfdbd208d1"), "زرآباد", 9 },
                    { 262, new Guid("d8e09ce2-16c6-4fc8-8019-7760d2893e73"), "زاهدان", 9 },
                    { 261, new Guid("575fb71d-b3e1-4ce6-913f-e35d580ea38f"), "زابل", 9 },
                    { 269, new Guid("dd165d9a-9d2d-4ef0-8e56-6a1a8a4e0933"), "علي اکبر", 9 },
                    { 260, new Guid("e50469eb-9f36-489e-ab3c-e87eddcbc0fe"), "راسک", 9 },
                    { 258, new Guid("cd93a326-feeb-4ab9-8eb2-f8792ce10f24"), "خاش", 9 },
                    { 257, new Guid("140e2666-3a30-4e5a-ad4e-1b632b27765a"), "جالق", 9 },
                    { 256, new Guid("e4efb526-4a5c-434c-ae76-80207fde57a2"), "بنجار", 9 },
                    { 255, new Guid("d8d6f13f-0ef1-4837-a423-f6ba49e3ac63"), "بنت", 9 },
                    { 254, new Guid("a7c6326c-e4a0-4a26-9c23-fa27923dce08"), "بمپور", 9 },
                    { 253, new Guid("a70c268f-e08b-491d-9679-4ee5e8f6dfec"), "بزمان", 9 },
                    { 252, new Guid("9d23e5d7-0dda-48da-bfce-5cb0dce12ec6"), "ايرانشهر", 9 },
                    { 259, new Guid("ad5a5142-be05-430f-baad-153419a6e095"), "دوست محمد", 9 },
                    { 308, new Guid("d747fb0a-a5e2-4cac-80c9-2f67eb8acb1a"), "قائن", 10 },
                    { 154, new Guid("8e90b3d3-a692-4893-a9b4-41e363363055"), "سيمينه", 7 },
                    { 152, new Guid("93a1c6a4-75a8-4100-a6a8-482f2cc100cc"), "سلماس", 7 },
                    { 54, new Guid("518b5b77-5d31-455d-aaf4-582ee42b60b4"), "پردنجان", 2 },
                    { 53, new Guid("91db5d98-ec40-4d65-aa58-4b76a743f335"), "وردنجان", 2 },
                    { 52, new Guid("8d51297d-008b-4403-85c1-ecf444abc55f"), "هفشجان", 2 },
                    { 51, new Guid("69156ba1-c933-48fa-b2c6-db9f1ef88f71"), "هاروني", 2 },
                    { 50, new Guid("8e808dca-0c9f-47ae-b2d7-73d82e631a0a"), "نقنه", 2 },
                    { 49, new Guid("a4356879-2a39-428a-a41a-3d09f99b292d"), "نافچ", 2 },
                    { 48, new Guid("cf4abf0c-55df-4912-9526-a2a8c968f9d4"), "ناغان", 2 },
                    { 47, new Guid("f7884114-1e17-4bea-8274-81332cb8f848"), "منج", 2 },
                    { 46, new Guid("2018be14-bdbc-48a8-bf86-62267d778d05"), "مال خليفه", 2 },
                    { 45, new Guid("149eb5f6-ea6f-4148-af8f-4707ce7f1fdd"), "لردگان", 2 },
                    { 44, new Guid("5f11c2a5-194e-4685-b936-4697bf5a70ac"), "فرخ شهر", 2 },
                    { 43, new Guid("694fd518-1312-4ddd-adae-bd9799ab29a8"), "فرادنبه", 2 },
                    { 42, new Guid("a1aec869-48f7-4ba1-8686-1af848fecd43"), "فارسان", 2 },
                    { 41, new Guid("154a3e18-e9c4-403d-b400-feb243bf3387"), "طاقانک", 2 },
                    { 40, new Guid("d19fcfe6-f116-431b-acbb-27850d7f2605"), "صمصامي", 2 },
                    { 55, new Guid("feb67d36-00b4-4045-b255-6e2b9c5c1b83"), "چليچه", 2 },
                    { 39, new Guid("5e593469-4cbf-44f1-8806-8692f882b82b"), "شهرکرد", 2 },
                    { 56, new Guid("3b33ce02-3fb1-49d7-9ab3-fe9d0c77b8bd"), "چلگرد", 2 },
                    { 58, new Guid("f9c56532-f01c-476d-a3f7-3d75d79e26f6"), "کيان", 2 },
                    { 73, new Guid("d26bedff-c153-417d-b441-af29b96c496a"), "سنخواست", 3 },
                    { 72, new Guid("c26489f1-fb85-48ab-8fee-96519b67d9df"), "زيارت", 3 },
                    { 71, new Guid("3d25cd85-799e-426d-9878-3d11135e4800"), "راز", 3 },
                    { 70, new Guid("16d88e5b-7830-4f65-be4f-3623c19adab1"), "درق", 3 },
                    { 69, new Guid("075787e1-480a-4ff2-a95f-71866a2f923c"), "حصارگرمخان", 3 },
                    { 68, new Guid("ad5517b2-974e-4cb4-b1b6-788c0bce94c0"), "جاجرم", 3 },
                    { 67, new Guid("d6a897ab-acbb-4cdd-a128-f50ef39ea426"), "تيتکانلو", 3 },
                    { 66, new Guid("02e6b95d-994f-47c8-ae3b-5af4b8270021"), "بجنورد", 3 },
                    { 65, new Guid("99c0d941-b936-4dcb-84c6-c96fb068329c"), "ايور", 3 },
                    { 64, new Guid("654b9c04-0fb0-458f-96a9-8729b345c7ec"), "اسفراين", 3 },
                    { 63, new Guid("f2b78432-cb55-47b7-8dc6-c526404832a0"), "آوا", 3 },
                    { 62, new Guid("172fbea9-761f-4890-a9a6-600d4efd21e4"), "آشخانه", 3 },
                    { 61, new Guid("a2d28413-8d7e-466c-97ea-82ced807d762"), "گوجان", 2 },
                    { 60, new Guid("1f1ea2da-7d77-4a3b-a51c-be9f0d43eb18"), "گهرو", 2 },
                    { 59, new Guid("a68e884f-4225-43ec-adb0-ebeb3f34a246"), "گندمان", 2 },
                    { 57, new Guid("1480cda0-f47e-4aed-bb5f-6c13a7ddf19e"), "کاج", 2 },
                    { 38, new Guid("f2974e36-693b-4fe6-b7dc-3dbaf00abae9"), "شلمزار", 2 },
                    { 37, new Guid("b0b6dcb1-15a4-4205-8c0f-a2a5e7eee540"), "سورشجان", 2 },
                    { 36, new Guid("a1a94014-90b9-483e-b019-1f149150405f"), "سودجان", 2 },
                    { 15, new Guid("3d15d122-01dd-4aa5-b12e-a3e6a25bfd35"), "مهردشت", 1 },
                    { 14, new Guid("ad9a4261-f669-4135-a4b6-05443e587d33"), "مروست", 1 },
                    { 13, new Guid("fbdc068d-e37a-48e8-9651-09aaa1c8b1b5"), "عقدا", 1 },
                    { 12, new Guid("80d12818-d250-4185-adac-5f717bf50a50"), "شاهديه", 1 },
                    { 11, new Guid("dde8d41c-e719-49ff-80e0-59cf90e23f93"), "زارچ", 1 },
                    { 10, new Guid("b8a5c9ea-d6bb-49b4-a343-85ea5ca36e71"), "خضر آباد", 1 },
                    { 9, new Guid("e9876c2d-9a6a-4fdf-b2c9-c5591ae2b983"), "حميديا", 1 },
                    { 8, new Guid("b6d5c7e0-c2ec-4191-a641-e5092e907363"), "تفت", 1 },
                    { 7, new Guid("042e8c74-aa41-4e9f-b8f3-04963829b8d2"), "بهاباد", 1 },
                    { 6, new Guid("b6fa50f5-3b94-434e-8aac-60adcea7eb98"), "بفروئيه", 1 },
                    { 5, new Guid("0e082d9e-8c8e-4c0e-930e-a5a35c441271"), "بافق", 1 },
                    { 4, new Guid("d9b996d3-73bc-473e-9527-240dc1be7853"), "اشکذر", 1 },
                    { 3, new Guid("471f78ac-21c4-43a9-a5f9-a45ab44e1be7"), "اردکان", 1 },
                    { 2, new Guid("108c04ba-f601-4e52-9047-72f8e224694d"), "احمد آباد", 1 },
                    { 1, new Guid("b085f6e4-eb69-40eb-bf22-0b33741c0219"), "ابرکوه", 1 },
                    { 16, new Guid("3f842855-f1c5-4d4f-8bd0-3a92adcb4ffa"), "مهريز", 1 },
                    { 17, new Guid("20a80b63-d013-4730-9fcc-7b4fcb8c082f"), "ميبد", 1 },
                    { 18, new Guid("ea6dbfb0-a986-4cb5-88df-98dfbe61607b"), "ندوشن", 1 },
                    { 19, new Guid("b9da5068-c2ce-4d8a-9c08-99c236d7638d"), "نير", 1 },
                    { 35, new Guid("36c3394d-74b6-47dd-9ea8-40d1a19c5ee2"), "سفيد دشت", 2 },
                    { 34, new Guid("893f48c7-f85c-48f1-ab0e-c511af89c239"), "سردشت لردگان", 2 },
                    { 33, new Guid("c31a9b5b-951e-4be6-aa03-4a7eb813b201"), "سرخون", 2 },
                    { 32, new Guid("b655f9f2-beaf-43bb-a99d-808517444693"), "سامان", 2 },
                    { 31, new Guid("a4f31a04-3b66-4e17-8c08-53cab96e8257"), "دشتک", 2 },
                    { 30, new Guid("da127f0c-1a39-480b-8f82-14f27e8abf17"), "دستناء", 2 },
                    { 29, new Guid("87186433-a674-44e8-ae87-6114681b2e99"), "جونقان", 2 },
                    { 74, new Guid("120f51cf-6c58-4826-8a31-3dd93ea27707"), "شوقان", 3 },
                    { 28, new Guid("8dafc5b5-1470-44ec-bc99-799f16886a26"), "بن", 2 },
                    { 26, new Guid("fd4d8ca0-a609-47c8-9514-d4d260284e1e"), "بروجن", 2 },
                    { 25, new Guid("dd825db3-8363-4fc9-8881-c506c36914e4"), "بازفت", 2 },
                    { 24, new Guid("19a4ae12-3ee8-4302-aea6-aa9617576398"), "باباحيدر", 2 },
                    { 23, new Guid("9ebe5f28-f14c-4357-bbaf-2681edb15135"), "اردل", 2 },
                    { 22, new Guid("d4d138f0-414d-4402-a557-6c5ea9f529aa"), "آلوني", 2 },
                    { 21, new Guid("163aacb2-2c1e-4e56-a5b0-c31135580a48"), "يزد", 1 },
                    { 20, new Guid("f16f5033-6569-42ae-942b-c5613f05bf7a"), "هرات", 1 },
                    { 27, new Guid("2cb450b2-10b2-4cf0-9edb-0823b8aa3121"), "بلداجي", 2 },
                    { 75, new Guid("6f23a942-629a-4adb-8d2c-f22f7ffc658b"), "شيروان", 3 },
                    { 76, new Guid("99f66107-7fc5-49ef-a1f3-59e2ee2bf936"), "صفي آباد", 3 },
                    { 77, new Guid("03abd2c6-ccff-4c39-b9f6-b66a9d752f9f"), "فاروج", 3 },
                    { 131, new Guid("0f1fc497-2de6-4caa-bcdc-14afb6e9dd01"), "پيرتاج", 6 },
                    { 130, new Guid("fb4c2876-f219-40fc-89c6-7811a56e677b"), "ياسوکند", 6 },
                    { 129, new Guid("ba92a201-5742-4adc-81f2-8d172000e0eb"), "موچش", 6 },
                    { 128, new Guid("9ed7ad12-d8b5-42ac-a0fc-c2ef2768f0ba"), "مريوان", 6 },
                    { 127, new Guid("46299809-0d3d-46d5-90a2-65906cffb94a"), "قروه", 6 },
                    { 126, new Guid("3dffe9a0-f2b4-4806-a500-b85cf8afca7d"), "صاحب", 6 },
                    { 125, new Guid("373ebace-7ffb-495f-8b27-e177b4fad1eb"), "شويشه", 6 },
                    { 124, new Guid("a1ccdab9-a7a0-4814-902e-40743622eb4e"), "سنندج", 6 },
                    { 123, new Guid("642813ba-9195-487b-b0b6-02e698696a02"), "سقز", 6 },
                    { 122, new Guid("a5e8cf1c-2bbd-4447-a811-34efeac836a5"), "سريش آباد", 6 },
                    { 121, new Guid("93d98506-7fc0-4c90-9cce-bcdaa7e2cb38"), "سرو آباد", 6 },
                    { 120, new Guid("98d4cad5-1101-4df1-ac77-40a64bc06f74"), "زرينه", 6 },
                    { 119, new Guid("e3f07c75-9efa-4298-bded-075847ee6497"), "ديواندره", 6 },
                    { 118, new Guid("e260f8e5-8ea5-4c93-b8f3-c9a967f9bd80"), "دهگلان", 6 },
                    { 117, new Guid("e97154e3-3fa5-4aa8-81c5-bb7f122bebbd"), "دلبران", 6 },
                    { 132, new Guid("a6a062bf-5be8-45c4-902b-2895f6594918"), "چناره", 6 },
                    { 133, new Guid("9360b153-1f82-4bdd-9cd4-5fe8efd40a41"), "کامياران", 6 },
                    { 134, new Guid("28c22172-d3f9-43c9-b87e-45e35692f633"), "کاني دينار", 6 },
                    { 135, new Guid("9645a710-3931-49e6-98ae-b88dc8e690c9"), "کاني سور", 6 },
                    { 151, new Guid("ce1c1758-8879-4473-9266-5b8864cc3712"), "سرو", 7 },
                    { 150, new Guid("58ec3fc5-861f-4391-81b3-2fdb1661b24b"), "سردشت", 7 },
                    { 149, new Guid("ad6e5adf-1ebc-4709-ac1b-3fd5c962192b"), "زرآباد", 7 },
                    { 148, new Guid("16038e13-3325-49dc-882c-0b4921c427ce"), "ربط", 7 },
                    { 147, new Guid("03243cf7-06d5-4056-b386-b98421b8e305"), "ديزج ديز", 7 },
                    { 146, new Guid("58b08dc2-ce97-4028-bf35-294af05518c1"), "خوي", 7 },
                    { 145, new Guid("b30df415-3f00-49df-9488-ddb15f0848c0"), "خليفان", 7 },
                    { 116, new Guid("bf78ae5e-2b83-41cb-8ef7-77616a35a14d"), "دزج", 6 },
                    { 144, new Guid("abd12d51-cce3-44e1-9664-df411a388e96"), "تکاب", 7 },
                    { 142, new Guid("9a63f301-5747-4248-9a50-b461b96cb792"), "بوکان", 7 },
                    { 141, new Guid("7b968f38-995a-4a41-bae9-32f9cee9dc9c"), "بازرگان", 7 },
                    { 140, new Guid("245e1392-9def-4c1a-8c67-a676ff76018f"), "باروق", 7 },
                    { 139, new Guid("0cc5b985-922b-4752-a9e5-aa79ed2abf74"), "ايواوغلي", 7 },
                    { 138, new Guid("a6829184-7ff2-44cb-9cd3-d81049ee4ce7"), "اشنويه", 7 },
                    { 137, new Guid("91c48819-0373-4692-9968-609d3d317000"), "اروميه", 7 },
                    { 136, new Guid("dac36713-1475-40bf-8010-2449f40a415f"), "آواجيق", 7 },
                    { 143, new Guid("9b3517b9-dac4-4405-94fb-35ab9d051deb"), "تازه شهر", 7 },
                    { 153, new Guid("9cfed7d6-bbae-4031-b632-3015dfc0963c"), "سيلوانه", 7 },
                    { 115, new Guid("6d81f36f-d4ac-4c20-a9c0-aa21fce6f2d7"), "توپ آغاج", 6 },
                    { 113, new Guid("55c823d4-640f-4849-b59d-e4c9dbcc2e70"), "بوئين سفلي", 6 },
                    { 92, new Guid("c1e0011c-12be-4b7a-9125-63d62d47662e"), "مشکين دشت", 4 },
                    { 91, new Guid("63905022-41a3-4bae-9a68-65d193b4650e"), "محمد شهر", 4 },
                    { 90, new Guid("0068365f-ea47-47cb-989a-959155b03aae"), "ماهدشت", 4 },
                    { 89, new Guid("ec237bfa-8c5d-435b-b21a-1172fa5cc104"), "فرديس", 4 },
                    { 88, new Guid("b2869acd-6d68-4794-ae36-9ed0c7f13745"), "طالقان", 4 },
                    { 87, new Guid("8e0c262d-1e4b-41a9-aeff-cee81910041e"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("e0885f10-8cad-42ad-be30-aab993496056"), "تنکمان", 4 },
                    { 85, new Guid("6fb58020-34cd-426f-a019-a1f13355520d"), "اشتهارد", 4 },
                    { 84, new Guid("087df4d8-3f45-497b-8e6e-32f2ec9ab904"), "آسارا", 4 },
                    { 83, new Guid("b810e039-7d5f-4222-a056-2f62fe1b58f1"), "گرمه", 3 },
                    { 82, new Guid("b233c830-e980-47fc-87f8-ad6bb27766ec"), "چناران شهر", 3 },
                    { 81, new Guid("be1e02a2-fabc-4749-b21b-d99deee073f9"), "پيش قلعه", 3 },
                    { 80, new Guid("ad19eb64-7dec-42ed-a1f4-2ed427adc707"), "لوجلي", 3 },
                    { 79, new Guid("ef7f205b-72ec-4f0e-93ec-87f915dd77d1"), "قوشخانه", 3 },
                    { 78, new Guid("3605c44f-51fe-4665-9856-490072f58dad"), "قاضي", 3 },
                    { 93, new Guid("e3e7966a-f1c8-4a92-9643-a021fc2487e9"), "نظر آباد", 4 },
                    { 94, new Guid("130418d8-02e1-4110-9b13-0b987f40c826"), "هشتگرد", 4 },
                    { 95, new Guid("5c3c4e53-15b3-4631-894d-d4f5b9b6e056"), "چهارباغ", 4 },
                    { 96, new Guid("75d71e25-a2d1-499b-b726-6922d6721000"), "کرج", 4 },
                    { 112, new Guid("0ff53443-e5bb-421e-a054-1d12aaf6fec9"), "بلبان آباد", 6 },
                    { 111, new Guid("a48b24d8-6e5a-4ea7-b5c6-0f906bbbd4e3"), "برده رشه", 6 },
                    { 110, new Guid("dbf5d1c0-26d0-4237-8297-2929d4515ff7"), "بانه", 6 },
                    { 109, new Guid("a3ab4586-5f73-4bcf-bfcf-08f31a627a10"), "بابارشاني", 6 },
                    { 108, new Guid("aa47d786-494e-479e-94b2-add274cc1fd4"), "اورامان تخت", 6 },
                    { 107, new Guid("fcb083e5-5658-41e9-b8ec-d3c1ab413316"), "آرمرده", 6 },
                    { 106, new Guid("d9205a4d-96a6-4538-8d6e-45f4330d9dd3"), "کهک", 5 },
                    { 114, new Guid("fe989e20-6df7-4f6a-91e7-4831f2109db1"), "بيجار", 6 },
                    { 105, new Guid("cd6b03e5-bafa-4d06-8ef7-d8a76f03a7a9"), "قنوات", 5 },
                    { 103, new Guid("0e010799-6791-4467-90ff-be8b4fd2572c"), "سلفچگان", 5 },
                    { 102, new Guid("5d370f0e-146d-490d-b44a-8379d400f0bd"), "دستجرد", 5 },
                    { 101, new Guid("ee0faf99-de1f-47bb-9355-cd69a62a7f7d"), "جعفريه", 5 },
                    { 100, new Guid("c2436314-21a9-4747-a81b-691078e08dc2"), "گلسار", 4 },
                    { 99, new Guid("869a4ede-2c28-4efc-8fcb-efea2b014d86"), "گرمدره", 4 },
                    { 98, new Guid("39daacb7-d14e-4eeb-b413-00348a028654"), "کوهسار", 4 },
                    { 97, new Guid("61d88112-1b9d-4832-bdcf-d3a42a643fdd"), "کمال شهر", 4 },
                    { 104, new Guid("20dfd9d0-ba9c-4a53-ba2e-08e9a00d52d1"), "قم", 5 },
                    { 309, new Guid("7c297280-83d5-4b3a-b039-de88cf0c11af"), "قهستان", 10 },
                    { 306, new Guid("e402e495-e801-4bce-9032-f5499d62416a"), "عشق آباد", 10 },
                    { 311, new Guid("ae161a1b-f970-4ffe-b429-a50468e24943"), "مود", 10 },
                    { 520, new Guid("07491cbf-e510-4b68-aea7-0fd40a4cc66f"), "پايين هولار", 15 },
                    { 519, new Guid("0ac81590-06c0-4740-b320-59133370a151"), "هچيرود", 15 },
                    { 518, new Guid("48f4d220-dee8-4f97-8c86-6724f5df0bb3"), "هادي شهر", 15 },
                    { 517, new Guid("535ed906-446e-4537-b155-639126070054"), "نکا", 15 },
                    { 516, new Guid("3df07590-9f9b-4143-88b0-eb010df794b5"), "نوشهر", 15 },
                    { 515, new Guid("adaf8354-24fd-4750-9276-26fcbd405650"), "نور", 15 },
                    { 514, new Guid("54b1b967-91a4-4597-84de-f48c30ac13ae"), "نشتارود", 15 },
                    { 513, new Guid("218e84cc-d51e-49ce-a051-eafbdddc0d76"), "مرزيکلا", 15 },
                    { 512, new Guid("c7e0b3f9-bdc3-4f7d-82bd-ca0defc2de72"), "مرزن آباد", 15 },
                    { 511, new Guid("41cd6b9d-7ea9-4915-a728-cff63efbe994"), "محمود آباد", 15 },
                    { 510, new Guid("ac35f1be-8485-4589-a22e-5e3496ca4b44"), "قائم شهر", 15 },
                    { 509, new Guid("a5fc9623-aaa2-48e7-88d6-3e98273d9c4f"), "فريم", 15 },
                    { 508, new Guid("290c747e-6b27-4975-a45f-a0a3230b1b63"), "فريدونکنار", 15 },
                    { 507, new Guid("a9516c7a-e7fe-496a-9424-97733c5648c6"), "عباس آباد", 15 },
                    { 506, new Guid("6cdc0b87-77d9-4971-82b6-298d04331442"), "شيرگاه", 15 },
                    { 521, new Guid("d3659871-585e-491f-9a3d-24a0bc828c00"), "پل سفيد", 15 },
                    { 505, new Guid("d288220a-062f-41ee-b973-4c2f5966f87e"), "شيرود", 15 },
                    { 522, new Guid("7ab9d7c3-74a0-4ab5-9687-247bb8efd03d"), "پول", 15 },
                    { 524, new Guid("33e63ae8-a660-4c23-b83b-bb51b657375e"), "چمستان", 15 },
                    { 539, new Guid("f898c7df-f085-4f90-a02e-1fe1f70267aa"), "اسفرورين", 16 },
                    { 538, new Guid("cf6e2910-0928-4c39-85ae-92f8d8f5fa6d"), "ارداق", 16 },
                    { 537, new Guid("ec20ce3f-40b9-4e67-9b8d-530ba4798668"), "آوج", 16 },
                    { 536, new Guid("6124699d-b844-422a-8622-912a904f62ba"), "آبگرم", 16 },
                    { 535, new Guid("b3c204ad-216a-4075-88da-c128e5cb3adf"), "آبيک", 16 },
                    { 534, new Guid("ed59de20-55fa-4cd7-a30c-73088b7f0287"), "گلوگاه", 15 },
                    { 533, new Guid("864bae12-2c15-43ff-800b-5ca6acf5d1af"), "گزنک", 15 },
                    { 532, new Guid("888c5e4a-ecb9-4903-bfb0-f33cac729835"), "گتاب", 15 },
                    { 531, new Guid("eb437298-7946-443b-8090-4e4ce6fafcd0"), "کياکلا", 15 },
                    { 530, new Guid("cc2ac614-8779-4753-9adc-4bc127aa5c45"), "کياسر", 15 },
                    { 529, new Guid("2f67631d-d256-40b0-a6b6-9042c27e4b93"), "کوهي خيل", 15 },
                    { 528, new Guid("d41effbc-f86a-4675-9fef-035482a86d33"), "کلاردشت", 15 },
                    { 527, new Guid("ebcc8a69-9b8b-4f8e-993b-773f0eed45ad"), "کلارآباد", 15 },
                    { 526, new Guid("ab5e39b2-579e-4c8e-8cee-337116083a7d"), "کجور", 15 },
                    { 525, new Guid("ec55123e-7dc7-439c-a3b0-8689709cde3b"), "کتالم و سادات شهر", 15 },
                    { 523, new Guid("d1987315-e6a4-4a49-99b3-7c38c2bac88d"), "چالوس", 15 },
                    { 504, new Guid("bfa08a88-2ccb-46fd-bccf-2163a7d962e5"), "سورک", 15 },
                    { 503, new Guid("6e850b37-5359-4249-9324-7f2d123068b2"), "سلمان شهر", 15 },
                    { 502, new Guid("72a0401b-3efb-401d-a7fe-83ecf9c88e17"), "سرخرود", 15 },
                    { 481, new Guid("4641f7ed-8233-44e5-b546-e2a8760ff0e4"), "امامزاده عبدالله", 15 },
                    { 480, new Guid("1d15d1b3-c859-4fc8-b489-bbc7ecd23497"), "ارطه", 15 },
                    { 479, new Guid("a787124d-3649-4f71-9fbb-9ed85d641876"), "آمل", 15 },
                    { 478, new Guid("59789692-3822-4953-8191-164923816525"), "آلاشت", 15 },
                    { 477, new Guid("fd1c81bd-d744-4ef4-aa9d-0c5e9c0a1ba7"), "گنبدکاووس", 14 },
                    { 476, new Guid("d21bfa74-ccfb-4122-9161-19050aa43231"), "گميش تپه", 14 },
                    { 475, new Guid("6023ec84-787b-4c6f-a26e-21e434644b06"), "گرگان", 14 },
                    { 474, new Guid("790a95d4-1c11-400a-bb25-cde3ff434732"), "گاليکش", 14 },
                    { 473, new Guid("4d5eb35d-9b39-4e39-92ea-bbd3aa3675ee"), "کلاله", 14 },
                    { 472, new Guid("9ca3b0f2-80db-4924-b048-be38819fd466"), "کرد کوي", 14 },
                    { 471, new Guid("54df0787-a572-4dfc-90b3-e86c9e38b970"), "نگين شهر", 14 },
                    { 470, new Guid("ae13a170-9dc9-496a-914c-bc97c562373f"), "نوکنده", 14 },
                    { 469, new Guid("1c1cb7b7-9de8-43fa-8971-95fb6235e545"), "نوده خاندوز", 14 },
                    { 468, new Guid("3941205a-6d88-4dc9-aa10-87355059d4b9"), "مينودشت", 14 },
                    { 310, new Guid("01593c5a-e8c1-4b1a-93d6-455fd54a5b58"), "محمدشهر", 10 },
                    { 482, new Guid("d9aea374-0293-4ff0-b142-6b88fbe72275"), "امير کلا", 15 },
                    { 483, new Guid("1de06cd0-8fb2-4223-8965-f039e5f54bd4"), "ايزد شهر", 15 },
                    { 484, new Guid("29203581-e345-4c39-b778-dc765fdf83bf"), "بابل", 15 },
                    { 485, new Guid("71563fdc-d31b-4263-8e02-d0690095305d"), "بابلسر", 15 },
                    { 501, new Guid("71f2b091-e4a3-4a51-8525-2b65b47201e3"), "ساري", 15 },
                    { 500, new Guid("343ceae0-a50a-4d0f-9f4e-ca3f047894cf"), "زيرآب", 15 },
                    { 499, new Guid("171b709f-0730-428d-aa36-59db47fb21cc"), "زرگر محله", 15 },
                    { 498, new Guid("adf84fb2-345b-4432-946d-b1ff8fbff5b7"), "رينه", 15 },
                    { 497, new Guid("4d5f2209-4948-4a75-b19b-677aa9de1440"), "رويان", 15 },
                    { 496, new Guid("fa3ccf34-5f24-43bd-8f5f-cca89c559c7b"), "رستمکلا", 15 },
                    { 495, new Guid("d509c6ab-90f6-4caa-b60c-541e948c03dc"), "رامسر", 15 },
                    { 540, new Guid("09e5b4a5-1c26-42d8-b7bf-2cee561c40c9"), "اقباليه", 16 },
                    { 494, new Guid("9ac386e4-5692-4f75-9f3d-f7b992467a7a"), "دابودشت", 15 },
                    { 492, new Guid("8a2fe45f-fd23-419b-b7cb-8a2913b29082"), "خليل شهر", 15 },
                    { 491, new Guid("a1b029af-7319-4ecc-86de-e6e1f357cf1e"), "خرم آباد", 15 },
                    { 490, new Guid("8820108f-7ebe-4dc3-a71f-97a3982bb6ae"), "جويبار", 15 },
                    { 489, new Guid("ca2c6d24-09e3-4cc0-93a7-849a5629b44f"), "تنکابن", 15 },
                    { 488, new Guid("54b57fb5-2866-47f9-b814-d50cdc9136e6"), "بهنمير", 15 },
                    { 487, new Guid("27d74272-f420-4e0a-b81f-160f51b77173"), "بهشهر", 15 },
                    { 486, new Guid("b8db42a6-7deb-49ab-aaf7-e80169905505"), "بلده", 15 },
                    { 493, new Guid("9d0c95b0-5ca3-4450-b3a9-def0a8c5c0e7"), "خوش رودپي", 15 },
                    { 541, new Guid("6de47a3c-6a34-4397-a116-5877d40c932e"), "الوند", 16 },
                    { 542, new Guid("eee242bb-ba6f-4966-a176-99e6174736d2"), "بوئين زهرا", 16 },
                    { 543, new Guid("620ed7e3-5129-45e5-ac16-f4025f8c9852"), "بيدستان", 16 },
                    { 597, new Guid("70310caf-0922-4262-8b08-4231e94c7f7e"), "فخرآباد", 18 },
                    { 596, new Guid("9f66491b-ab9e-408d-b306-f4fb458cc6cb"), "عنبران", 18 },
                    { 595, new Guid("0edbc6a5-1446-4955-a345-d835f08e8dad"), "سرعين", 18 },
                    { 594, new Guid("80bb32d7-2e1f-4b64-98d0-e77730197d98"), "رضي", 18 },
                    { 593, new Guid("af9272b6-4da6-490e-ab6a-0f32f97a893a"), "خلخال", 18 },
                    { 592, new Guid("7cf7b683-5c6f-404a-a26b-9d5cf1ce8f95"), "جعفر آباد", 18 },
                    { 591, new Guid("9382dd5f-dca6-417d-9436-8e751b126a53"), "تازه کند انگوت", 18 },
                    { 590, new Guid("aa89dca3-d636-4544-a87a-21aab7c5c8e2"), "تازه کند", 18 },
                    { 589, new Guid("196e3cdc-a3ae-45e6-8302-a3632c3cfa82"), "بيله سوار", 18 },
                    { 588, new Guid("c9500dde-ab47-4894-88fd-3551c630dd24"), "اصلاندوز", 18 },
                    { 587, new Guid("716f7ab7-4b75-4508-b9f0-d6c7ca95ee85"), "اسلام آباد", 18 },
                    { 586, new Guid("eff03b5b-102c-484b-b172-f28b01dd14f6"), "اردبيل", 18 },
                    { 585, new Guid("e3be080d-7b9b-42c7-b0cd-0c417bcd1748"), "آبي بيگلو", 18 },
                    { 584, new Guid("c532400a-14ec-458c-937d-cd9a75e72523"), "گراب", 17 },
                    { 583, new Guid("b0c1b0fc-d5d8-4243-9c6b-6e6018bc237c"), "کوهناني", 17 },
                    { 598, new Guid("44f14d9d-194d-4c06-9b99-17a77cb2024f"), "قصابه", 18 },
                    { 599, new Guid("12851778-9632-47ea-808e-2f3eebab6a2f"), "لاهرود", 18 },
                    { 600, new Guid("bae09356-dd01-4eb7-956d-4f846f6dbd9a"), "مرادلو", 18 },
                    { 601, new Guid("b14ac804-6466-40e5-af32-9bba23bbc30f"), "مشگين شهر", 18 },
                    { 617, new Guid("28aac937-ebcf-4674-820c-15273531e725"), "افوس", 19 },
                    { 616, new Guid("39961974-9773-4146-8e35-6fb949867fed"), "اصفهان", 19 },
                    { 615, new Guid("3748a61c-06ad-44d8-aab9-f2cc6576ca0d"), "اصغرآباد", 19 },
                    { 614, new Guid("d497f87f-9634-430c-9b24-43540b0262a5"), "اردستان", 19 },
                    { 613, new Guid("79e699f3-1ef1-41cf-8d5a-d3d2d0b4d764"), "ابوزيد آباد", 19 },
                    { 612, new Guid("acf486f5-4118-4730-992f-b982937fddf4"), "ابريشم", 19 },
                    { 611, new Guid("7b16fdbf-be5c-499b-9797-ad7bc31c6370"), "آران و بيدگل", 19 },
                    { 582, new Guid("4b11bd6b-4cba-4f2f-80f1-97af4762d2ff"), "کوهدشت", 17 },
                    { 610, new Guid("ad9f2859-f097-4009-b839-bf45f0158a77"), "گيوي", 18 },
                    { 608, new Guid("c257c578-8c4f-439f-aaa2-114a24fe97c5"), "کورائيم", 18 },
                    { 607, new Guid("202a9cb5-271f-4ddf-96f9-9913c29eab6f"), "کلور", 18 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 606, new Guid("3f7d10b9-d15a-4fed-8426-439c01992284"), "پارس آباد", 18 },
                    { 605, new Guid("15d0d78f-c724-4b93-892c-cef3414063b4"), "هير", 18 },
                    { 604, new Guid("c47ece4d-ce74-4729-8660-5dc7124f98c3"), "هشتجين", 18 },
                    { 603, new Guid("983f248f-6c4f-45ef-9c37-1fe02f50423c"), "نير", 18 },
                    { 602, new Guid("3e374967-3632-43d1-90db-3aa852a9e77d"), "نمين", 18 },
                    { 609, new Guid("8acac075-8266-4ac4-a7ff-8303e84ad0ca"), "گرمي", 18 },
                    { 466, new Guid("9e5c32c2-5ca5-4b08-9ec9-6e09a6887093"), "مراوه تپه", 14 },
                    { 581, new Guid("26b8fe60-72af-443a-8d3d-3d094e31045d"), "چقابل", 17 },
                    { 579, new Guid("c025be56-5c41-45c1-af9e-3991a8efe807"), "پلدختر", 17 },
                    { 558, new Guid("dee6f1fd-a510-4efd-a0d9-1a2ba594f51d"), "نرجه", 16 },
                    { 557, new Guid("6d9956df-0b92-464f-8b67-f669df144950"), "معلم کلايه", 16 },
                    { 556, new Guid("fd09fd0c-9c29-4a24-837f-6a0b8b34e9ad"), "محمود آباد نمونه", 16 },
                    { 555, new Guid("7eb241a4-c14c-42f4-90f4-ec377a84edfc"), "محمديه", 16 },
                    { 554, new Guid("69caf66e-c7b5-4a81-b7c2-d5b3a62478de"), "قزوين", 16 },
                    { 553, new Guid("f04455ba-1547-4334-8f8a-eac85ece7db0"), "ضياء آباد", 16 },
                    { 552, new Guid("02701712-28a0-4fce-846e-a4520b2bb10e"), "شريفيه", 16 },
                    { 551, new Guid("df095fc8-ac26-45d2-808d-af31a2ffda6f"), "شال", 16 },
                    { 550, new Guid("1ebbdd35-6b67-49c4-8ca3-ef23ae0c5d4e"), "سگز آباد", 16 },
                    { 549, new Guid("8edcfd52-a51b-4a4e-b761-f370505b8253"), "سيردان", 16 },
                    { 548, new Guid("b2efeed0-7c32-4a50-9531-54bd2d675072"), "رازميان", 16 },
                    { 547, new Guid("41e3e7e2-835f-4207-b7df-b0867531dd54"), "دانسفهان", 16 },
                    { 546, new Guid("343b48be-58f4-4698-83ee-2d0a09b1af33"), "خرمدشت", 16 },
                    { 545, new Guid("684e446c-2562-4d79-b9ef-0aff7ea6e593"), "خاکعلي", 16 },
                    { 544, new Guid("9c2dfa5f-88c5-4f27-899d-16027b0ed4ca"), "تاکستان", 16 },
                    { 559, new Guid("caf695ad-e029-493c-90a6-de08692202a5"), "کوهين", 16 },
                    { 560, new Guid("8481395b-17f9-4393-86d4-cff36db2cb25"), "ازنا", 17 },
                    { 561, new Guid("2d84ce2b-a5ea-42f6-a667-3a4ed28678fc"), "اشترينان", 17 },
                    { 562, new Guid("ab0f78e1-ca68-4db4-a3fd-60ef24d6ff72"), "الشتر", 17 },
                    { 578, new Guid("811e530e-c8b0-4040-96ad-fe089d66ad36"), "ويسيان", 17 },
                    { 577, new Guid("c3110a02-a33f-481f-86a3-86813d344257"), "هفت چشمه", 17 },
                    { 576, new Guid("8a46f6b7-b16a-4b62-89f1-3d15742d8c11"), "نورآباد", 17 },
                    { 575, new Guid("f23d4f96-6ca8-43aa-ba6b-298e4a31cb57"), "مومن آباد", 17 },
                    { 574, new Guid("54e8efba-84b5-4e8c-a526-e409463f49c3"), "معمولان", 17 },
                    { 573, new Guid("4e394760-10b3-4d65-aafd-59767950653d"), "فيروزآباد", 17 },
                    { 572, new Guid("9abd1e17-c5e5-4322-b301-80521298c3b2"), "شول آباد", 17 },
                    { 580, new Guid("91ebff77-cdc1-45c7-bc0a-d066052dc791"), "چالانچولان", 17 },
                    { 571, new Guid("57acdbbf-8879-40bd-95c8-53113244b87c"), "سپيد دشت", 17 },
                    { 569, new Guid("089d015f-8a55-4e14-8fbf-9d3092223799"), "زاغه", 17 },
                    { 568, new Guid("4abc90d0-2cd3-4f71-8518-b6fab05c7d2b"), "دورود", 17 },
                    { 567, new Guid("fd6ea14f-3eaf-4d6d-8025-1afd43bf22eb"), "درب گنبد", 17 },
                    { 566, new Guid("c96a6098-62fb-47a8-a00e-caebf99fb8bd"), "خرم آباد", 17 },
                    { 565, new Guid("99cadbf8-cf9b-4a52-8e56-ed9ffb1edfa6"), "بيرانشهر", 17 },
                    { 564, new Guid("a6ddd606-1f11-454e-8544-5ce459d5f43b"), "بروجرد", 17 },
                    { 563, new Guid("a16ef1cd-49a7-4d34-83a3-d5f54c10c992"), "اليگودرز", 17 },
                    { 570, new Guid("a55c5cbf-69cc-4e13-9cca-3068c7a6d266"), "سراب دوره", 17 },
                    { 465, new Guid("67aa07da-b568-44b1-9446-d3174a35816d"), "فراغي", 14 },
                    { 467, new Guid("e22b8c8c-e0ee-461d-b977-e745e346eefe"), "مزرعه", 14 },
                    { 463, new Guid("231a2de1-2048-4c2c-9f27-b2ec94578e1f"), "علي آباد", 14 },
                    { 365, new Guid("1771dbde-e7b2-422e-b6a9-3a4b493d70ac"), "صفي آباد", 11 },
                    { 364, new Guid("8ded0dae-bdc9-43cd-b024-ae460c44250f"), "صالح شهر", 11 },
                    { 363, new Guid("c5ac956c-fb99-44dc-8dd2-c34715e86447"), "شيبان", 11 },
                    { 362, new Guid("55942f1a-311e-4e81-a9c9-1256f9aac021"), "شوشتر", 11 },
                    { 361, new Guid("696fc8b0-b381-4495-a1bc-3fa138f9030d"), "شوش", 11 },
                    { 360, new Guid("cc18c96e-9508-4d2f-9a62-cd76f0de5970"), "شهر امام", 11 },
                    { 359, new Guid("925f6283-8cb5-4660-8486-6c6523b661a5"), "شمس آباد", 11 },
                    { 358, new Guid("3d64f582-9c54-41ba-abfb-38891ee5c642"), "شرافت", 11 },
                    { 357, new Guid("db58abce-f96c-487d-85f7-fefaf3caa5ad"), "شاوور", 11 },
                    { 356, new Guid("144e2ac9-f7e7-4bcc-9f27-326485b43c81"), "شادگان", 11 },
                    { 355, new Guid("add2a894-2a03-4837-8c8b-910a44058555"), "سياه منصور", 11 },
                    { 354, new Guid("b9b267b9-d72a-4e08-97a4-0c4476a9cc34"), "سوسنگرد", 11 },
                    { 353, new Guid("fb9bf397-4c0d-48f6-a354-72cc64c312e2"), "سماله", 11 },
                    { 352, new Guid("92bf8e16-709c-484e-b7e5-58ac5fbc1802"), "سردشت", 11 },
                    { 351, new Guid("3d25028f-8a91-470b-81dc-245c84c9ee27"), "سرداران", 11 },
                    { 366, new Guid("6142b296-06b1-4c17-a18a-a53307bf544c"), "صيدون", 11 },
                    { 350, new Guid("bbc75fde-607b-49ab-8585-b479614ba4d8"), "سالند", 11 },
                    { 367, new Guid("fc749f3a-a6f9-4125-a4cb-4243bcf1273a"), "فتح المبين", 11 },
                    { 369, new Guid("e4d8f927-544d-4db0-b04c-05ffe56af660"), "قلعه خواجه", 11 },
                    { 464, new Guid("db437f0c-4b11-4082-a726-a225e1cd0b3a"), "فاضل آباد", 14 },
                    { 383, new Guid("b18ce413-6b01-49df-a2cd-672b69d004b5"), "چغاميش", 11 },
                    { 382, new Guid("9112d809-fe33-4823-8366-bb405d28b2dc"), "ويس", 11 },
                    { 381, new Guid("c5905ea5-d7ae-483d-b031-54a88a503c4c"), "هويزه", 11 },
                    { 380, new Guid("053b3f2b-28f8-42d1-b09a-b61abe954bc3"), "هنديجان", 11 },
                    { 379, new Guid("a923e2f9-7085-41c9-b38a-0334bb895671"), "هفتگل", 11 },
                    { 378, new Guid("7898390b-b53d-474d-b82e-392ab8491766"), "مينوشهر", 11 },
                    { 377, new Guid("b98b49da-3847-4ab9-91b7-2654590a390b"), "ميداود", 11 },
                    { 376, new Guid("faa84810-7f8c-413d-97c2-249b9990a67a"), "ميانرود", 11 },
                    { 375, new Guid("d6d7bc04-6621-4dbe-aebc-481a43ed9c54"), "منصوريه", 11 },
                    { 374, new Guid("17ff10b5-765b-4cda-b6bf-1ba99172b5f4"), "ملاثاني", 11 },
                    { 373, new Guid("f0f22839-d6a4-471e-bee7-3768add01203"), "مقاومت", 11 },
                    { 372, new Guid("f5efb4e8-a2f2-4776-a27b-0b3c3436f6fa"), "مشراگه", 11 },
                    { 371, new Guid("85f7852b-35fe-427c-a9e2-2d8895e443a9"), "مسجد سليمان", 11 },
                    { 370, new Guid("7158aff4-9093-4d2d-b89c-0036a5e96099"), "لالي", 11 },
                    { 368, new Guid("8e0cb068-5082-4bde-9ba7-372de79ee7e6"), "قلعه تل", 11 },
                    { 349, new Guid("33a9b896-10c4-4d9b-b07c-b36dfca280b7"), "زهره", 11 },
                    { 348, new Guid("1ad0c721-b8e5-409e-a297-81888e0b3705"), "رفيع", 11 },
                    { 347, new Guid("731d4691-8487-4ed6-b479-83408492699a"), "رامهرمز", 11 },
                    { 326, new Guid("319c5111-ca07-4651-a569-8d4a06700503"), "ايذه", 11 },
                    { 325, new Guid("182f325a-b375-4230-a223-7c0da0018bbe"), "اهواز", 11 },
                    { 324, new Guid("9dd11194-00c7-4539-a89b-be03cd5b4d9b"), "انديمشک", 11 },
                    { 323, new Guid("058d42dc-d410-4f86-82f6-2ce6b8f68f3e"), "اميديه", 11 },
                    { 322, new Guid("4e1d495d-c464-4d7f-b848-61f6fba8df4a"), "الوان", 11 },
                    { 321, new Guid("d22eeecf-6d2d-41c1-ab2e-83e4af67ea92"), "الهايي", 11 },
                    { 320, new Guid("c6d543db-75dc-40e2-974d-023580b7314d"), "اروند کنار", 11 },
                    { 319, new Guid("fd93b6a0-b73d-4583-89c6-168ee9378d78"), "ابوحميظه", 11 },
                    { 318, new Guid("c1669438-f80d-4287-bc0f-46f3924df61f"), "آغاجاري", 11 },
                    { 317, new Guid("872e91ac-4b30-4598-b493-c4eef28e67ff"), "آزادي", 11 },
                    { 316, new Guid("76d60c1f-6950-4a24-b164-e0e126820ccb"), "آبژدان", 11 },
                    { 315, new Guid("44f249ab-9f20-4166-894b-be8f96c64b58"), "آبادان", 11 },
                    { 314, new Guid("42f0c235-7c31-4aae-b333-2afee58eb616"), "گزيک", 10 },
                    { 313, new Guid("b8b7a58d-8d5d-446f-97ce-c238ca20bc90"), "نيمبلوک", 10 },
                    { 312, new Guid("520c0dda-1f9e-4099-ad4f-39cce8fa4db3"), "نهبندان", 10 },
                    { 327, new Guid("e0dd7b99-1e56-4cfe-9913-36157e0b5de5"), "باغ ملک", 11 },
                    { 328, new Guid("61e1ab1f-5eb0-49ce-827b-77a9e801a1a2"), "بستان", 11 },
                    { 329, new Guid("3a969a99-4a50-4a86-bf38-ee4a39aa1afe"), "بندر امام خميني", 11 },
                    { 330, new Guid("a97556ea-6128-4242-92d7-1ebeb46f8e81"), "بندر ماهشهر", 11 },
                    { 346, new Guid("ff7dbc41-3283-46ed-9067-124daf7a96a4"), "رامشير", 11 },
                    { 345, new Guid("c654036b-4468-477b-a827-b65cda2d3ea3"), "دهدز", 11 },
                    { 344, new Guid("528d76ec-6040-47d3-8f1a-5a685aa8a0ad"), "دزفول", 11 },
                    { 343, new Guid("32650acb-fc09-489e-92a2-b2682c42773a"), "دارخوين", 11 },
                    { 342, new Guid("7eb097e8-7472-4656-a666-742b5c45416e"), "خنافره", 11 },
                    { 341, new Guid("ccf50a01-20c5-4d95-bde9-0fe650c59561"), "خرمشهر", 11 },
                    { 340, new Guid("0f0a1d59-3f91-46c2-bc3a-f5342069e0f7"), "حميديه", 11 },
                    { 385, new Guid("027231d2-56dc-4ee5-baa4-d6366cab52ff"), "چمران", 11 },
                    { 339, new Guid("75319866-3490-499c-a5c9-9915a4450e4e"), "حمزه", 11 },
                    { 337, new Guid("6de02d9c-b87a-42fe-b52f-204af7855e01"), "حر", 11 },
                    { 336, new Guid("3243a24d-0974-4748-a59a-64c2cb1099da"), "جنت مکان", 11 },
                    { 335, new Guid("e836f7e8-b471-4afd-bb51-09b7136bfffc"), "جايزان", 11 },
                    { 334, new Guid("70669084-a3e5-4143-ab2e-d2aefb77f926"), "تشان", 11 },
                    { 333, new Guid("0035e7f4-101f-4317-9277-fd80032c4e8a"), "ترکالکي", 11 },
                    { 332, new Guid("77e7fb00-e317-46ae-849f-c743bc6361df"), "بيدروبه", 11 },
                    { 331, new Guid("6fa1cda7-06e4-43c3-8bfd-5ea29e765345"), "بهبهان", 11 },
                    { 338, new Guid("236edb77-2ca0-405c-a26d-fd5331864662"), "حسينيه", 11 },
                    { 386, new Guid("97c1031f-be3c-4e85-afce-b5038f51e7f1"), "چوئبده", 11 },
                    { 384, new Guid("790f5bb8-eb17-4d0a-808e-4f31077e78dd"), "چم گلک", 11 },
                    { 388, new Guid("eab33477-4155-4a78-a9bf-79c71010bdd8"), "کوت عبدالله", 11 },
                    { 442, new Guid("7632b0cb-8b64-4bfe-9e6c-f2c304ee56d8"), "ماه نشان", 13 },
                    { 441, new Guid("1836eaae-6e0a-4f71-b977-07161effd0ae"), "قيدار", 13 },
                    { 440, new Guid("08b1e767-567c-4b4e-8965-8ea44244a1b7"), "صائين قلعه", 13 },
                    { 439, new Guid("8f1ec922-03b5-4573-9c67-7a8d9bfcc82f"), "سهرورد", 13 },
                    { 438, new Guid("ecc30c0f-37e1-4ff5-a7d4-2dc42f936cbd"), "سلطانيه", 13 },
                    { 437, new Guid("e7a8f7e7-9363-48ec-bb6b-c4c350d21b6e"), "سجاس", 13 },
                    { 436, new Guid("a5a43b01-8b1d-4384-86b6-530468507148"), "زنجان", 13 },
                    { 435, new Guid("4c6789a3-ff78-4f81-aa87-f0f71c95213d"), "زرين رود", 13 },
                    { 434, new Guid("c494dff7-dff5-49b5-bb0d-fdbc24e228a5"), "زرين آباد", 13 },
                    { 433, new Guid("61db1612-6b0b-4852-8268-17c2ac31183c"), "دندي", 13 },
                    { 432, new Guid("a442fd23-d878-46b7-b1f6-219f6d207f2f"), "خرمدره", 13 },
                    { 431, new Guid("604c43a1-33a4-4911-9248-b8e394b053b3"), "حلب", 13 },
                    { 430, new Guid("33c218bf-2480-49ab-84b3-e59c5029265f"), "ارمخانخانه", 13 },
                    { 387, new Guid("66c80d5b-cd73-4856-bba7-0a56954292f6"), "کوت سيدنعيم", 11 },
                    { 428, new Guid("5ebaae4d-f918-41ac-8642-e17dbee96dc9"), "آب بر", 13 },
                    { 443, new Guid("371182c2-7bbb-4970-8240-0ee533d7a360"), "نوربهار", 13 },
                    { 444, new Guid("0352ae1f-5104-412b-88db-3cd0b54cc26d"), "نيک پي", 13 },
                    { 445, new Guid("77cf48e0-be0e-408b-9d9f-17a4687a952d"), "هيدج", 13 },
                    { 446, new Guid("356e5e25-3331-444b-ad61-80743cd422d0"), "چورزق", 13 },
                    { 462, new Guid("2065a0ab-4762-44fc-82e0-c170fa0b2204"), "سيمين شهر", 14 },
                    { 461, new Guid("696d25c0-87d4-4189-a7b0-a67bbc6ae255"), "سنگدوين", 14 },
                    { 460, new Guid("fed9e0c2-363f-4f05-abb9-5a84e911f200"), "سرخنکلاته", 14 },
                    { 459, new Guid("d8494cc2-9d07-48f4-9027-a258e5349143"), "راميان", 14 },
                    { 458, new Guid("6b112d25-4993-4b57-9933-109438ae1af8"), "دلند", 14 },
                    { 457, new Guid("b93a464b-d74d-4acd-bbc5-061a40102e15"), "خان ببين", 14 },
                    { 456, new Guid("da1d52db-a3ec-4c5d-96e2-bc43a4ac6ab6"), "جلين", 14 },
                    { 427, new Guid("43f3419b-3235-4109-abd2-5ca511433475"), "کلمه", 12 },
                    { 455, new Guid("280f70de-4b96-4dba-bab7-845f7e128607"), "تاتار عليا", 14 },
                    { 453, new Guid("fe917354-9ac6-4784-b16d-e04eb7082a7c"), "بندر ترکمن", 14 },
                    { 452, new Guid("efa11338-ac30-486c-856e-15196d3e9cb0"), "اينچه برون", 14 },
                    { 451, new Guid("8c537ef8-5b43-4fd2-82da-b73944db1a65"), "انبار آلوم", 14 },
                    { 450, new Guid("c590e37f-4812-4163-a456-4a78e3776c30"), "آق قلا", 14 },
                    { 449, new Guid("0e273a34-6685-4722-92c5-416370ef52cf"), "آزاد شهر", 14 },
                    { 448, new Guid("302eddce-0a65-4bfe-b35c-7426ebe87adb"), "گرماب", 13 },
                    { 447, new Guid("7fa6cbce-1570-4820-91a5-6527559fbd4a"), "کرسف", 13 },
                    { 454, new Guid("ffe1c309-d52c-4a0e-9880-b3ceeff27a3b"), "بندر گز", 14 },
                    { 426, new Guid("fc7a5f2c-42c5-40b7-a8a1-c5d438d80833"), "کاکي", 12 },
                    { 429, new Guid("01b203a0-8c25-4df2-870e-a40f59ddce1b"), "ابهر", 13 },
                    { 424, new Guid("11c1e3d0-63fc-4d3a-940c-b5375841f452"), "وحدتيه", 12 },
                    { 425, new Guid("066d028b-712d-427f-96d1-3d5eea6af3a3"), "چغادک", 12 },
                    { 402, new Guid("1a1efbb4-bb8d-4616-b49d-b040d3cdc537"), "بندر دير", 12 },
                    { 401, new Guid("e206f5a7-0caa-443e-8547-118f53792b7c"), "بردستان", 12 },
                    { 400, new Guid("4c67c95b-4ad1-438b-a3d2-3a620f6b950c"), "بردخون", 12 },
                    { 399, new Guid("517154e0-8ce1-4b2a-bfd5-1c9d1a5e1572"), "برازجان", 12 },
                    { 398, new Guid("48388416-b5f2-438b-a84f-7ca8415320b6"), "بادوله", 12 },
                    { 397, new Guid("56d38724-cf03-4f2c-809f-1da0fed19b22"), "اهرم", 12 },
                    { 396, new Guid("39ac92c2-9b63-4d16-9f44-b57693b179ed"), "انارستان", 12 },
                    { 395, new Guid("2e4f32fa-d331-4488-91b3-56fd1535b540"), "امام حسن", 12 },
                    { 394, new Guid("5209a38d-c4ac-4b31-ac6e-5d2f0b8313be"), "آبپخش", 12 },
                    { 393, new Guid("3b195530-452d-439c-aacc-c67204e061cc"), "آبدان", 12 },
                    { 392, new Guid("99d76ed4-1eb4-4952-8017-7fb761f32673"), "آباد", 12 },
                    { 391, new Guid("991cd48a-9869-49e4-9537-2f7d50a9d9f8"), "گوريه", 11 },
                    { 390, new Guid("0831f088-8d63-4a9c-8278-20190e6712c2"), "گلگير", 11 },
                    { 389, new Guid("d491f03d-ad7e-4999-83be-5a3d697f12e8"), "گتوند", 11 },
                    { 404, new Guid("96b0e3c5-7531-446a-a6aa-e83b1d663460"), "بندر ريگ", 12 },
                    { 405, new Guid("b304df53-25c6-43d2-8410-849baf425373"), "بندر کنگان", 12 },
                    { 403, new Guid("566898f3-f773-41b8-9f1b-7e57034c98fe"), "بندر ديلم", 12 },
                    { 407, new Guid("e42e20b5-721c-470a-b707-83d21631eb03"), "بنک", 12 },
                    { 423, new Guid("e6e3c0d2-f49d-4473-af8b-dfaf93d5d23c"), "نخل تقي", 12 },
                    { 422, new Guid("95e262ab-d63b-4eee-97e5-a4bcf477df61"), "عسلويه", 12 },
                    { 421, new Guid("7d2bd669-eedc-4473-a86e-290dfb1241a3"), "شنبه", 12 },
                    { 420, new Guid("7561eefb-dd41-49c9-adb2-9619d009bbdf"), "شبانکاره", 12 },
                    { 406, new Guid("166f37c0-6206-4871-8ed0-4854864dd69e"), "بندر گناوه", 12 },
                    { 418, new Guid("926c238b-e721-4599-b9df-024b50909b60"), "سعد آباد", 12 },
                    { 417, new Guid("6008e6a1-1099-4d9b-bb21-14a82acaeb4f"), "ريز", 12 },
                    { 416, new Guid("9abfa934-0db1-4379-b77e-eb2cba814213"), "دوراهک", 12 },
                    { 419, new Guid("cb3fc712-f09c-4f67-a863-ace6cbd779fd"), "سيراف", 12 },
                    { 414, new Guid("687d2615-f8c9-4e32-8ab8-a9fdd5a9d82e"), "دالکي", 12 },
                    { 413, new Guid("ca808c34-6f35-4b63-a774-c85b60345f5c"), "خورموج", 12 },
                    { 412, new Guid("396989b8-92d0-4628-9700-43a060159861"), "خارک", 12 },
                    { 411, new Guid("dab1d1b6-9ba3-41ff-88dd-d25c31c77e30"), "جم", 12 },
                    { 410, new Guid("4f23bd7b-fca5-4de5-8078-5c198a018391"), "تنگ ارم", 12 },
                    { 409, new Guid("8924c59c-bd4f-4373-aa10-43ffba05f037"), "بوشکان", 12 },
                    { 408, new Guid("2592bf01-3275-4ce6-be0e-ae99dfc7cf02"), "بوشهر", 12 },
                    { 415, new Guid("43a64577-e4c6-4f2c-96a4-7ef615b45a9b"), "دلوار", 12 }
                });

            migrationBuilder.InsertData(
                table: "Code",
                columns: new[] { "CodeID", "CodeGroupID", "CodeGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 3, 1, new Guid("ba955885-ee32-4e48-a7f7-551c08ec66f7"), "jpeg", "image/jpeg" },
                    { 2, 1, new Guid("5dbf9427-5527-4b7a-8367-8cf5006a4c89"), "jpg", "image/jpg" },
                    { 1, 1, new Guid("224a7e48-f9b3-4a08-a4bb-40506bd6d631"), "png", "image/png" }
                });

            migrationBuilder.InsertData(
                table: "SMSSetting",
                columns: new[] { "SMSSettingID", "ModifiedDate", "Name", "SMSProviderConfigurationID", "SMSSettingGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 6, 16, 13, 14, 918, DateTimeKind.Local).AddTicks(9993), "Kavenegar", 1, new Guid("65c3e034-b2de-4a02-951d-985e2939e71e") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 3, "roozbehshamekhi@hotmail.com", "روزبه", true, true, "شامخی", new DateTime(2020, 5, 6, 16, 13, 14, 921, DateTimeKind.Local).AddTicks(9736), "09128277075", new DateTime(2020, 5, 6, 16, 13, 14, 921, DateTimeKind.Local).AddTicks(9732), 1, new Guid("0440b8ec-c1b8-4993-9eb6-127028a364cb") },
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", true, true, "رودکی", new DateTime(2020, 5, 6, 16, 13, 14, 921, DateTimeKind.Local).AddTicks(6706), "09227204305", new DateTime(2020, 5, 6, 16, 13, 14, 921, DateTimeKind.Local).AddTicks(6179), 1, new Guid("61170876-be74-47f5-8935-9a1ed73d3137") },
                    { 2, "mahdiih@ymail.com", "مهدی", true, true, "حکمی زاده", new DateTime(2020, 5, 6, 16, 13, 14, 921, DateTimeKind.Local).AddTicks(9664), "09199390494", new DateTime(2020, 5, 6, 16, 13, 14, 921, DateTimeKind.Local).AddTicks(9643), 1, new Guid("080048cf-4791-4cbf-9ef3-a3b0cb4a4e33") }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 7, new Guid("6c813526-df7a-4310-94ff-59177ffc24f6"), "جوشکار صنعتی", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5920), 2, 1 },
                    { 8, new Guid("63f0a503-04f7-4fa6-9e23-80324847da7d"), "اره و نجار", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5929), 2, 2 },
                    { 9, new Guid("ec5a4f39-d1bf-453e-9270-07bc28e44e04"), "ساختمان", new DateTime(2020, 5, 6, 16, 13, 14, 923, DateTimeKind.Local).AddTicks(5936), 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 6, 16, 13, 14, 919, DateTimeKind.Local).AddTicks(5069), "VerifyAccount", 1, new Guid("690b6004-f568-4480-ae7b-f55cc64b7c2a") });

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
                name: "IX_ContactUs_CategoryID",
                table: "ContactUs",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_CityID",
                table: "Contractor",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_UserID",
                table: "Contractor",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorCategory_CategoryID",
                table: "ContractorCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorCategory_ContractorID",
                table: "ContractorCategory",
                column: "ContractorID");

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
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "ContractorCategory");

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
                name: "City");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CodeGroup");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
