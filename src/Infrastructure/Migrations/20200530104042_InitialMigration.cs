using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pisheyar.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeGroup",
                columns: table => new
                {
                    CodeGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGroupGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
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
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
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
                name: "ContactUs",
                columns: table => new
                {
                    ContactUsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactUsGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContactUsBusinessTypeCodeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactUsID);
                    table.ForeignKey(
                        name: "FK_ContactUs_Code",
                        column: x => x.ContactUsBusinessTypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
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
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ParentCategoryID = table.Column<int>(nullable: true),
                    CoverDocumentID = table.Column<int>(nullable: true),
                    ActiveIconDocumentID = table.Column<int>(nullable: true),
                    InactiveIconDocumentID = table.Column<int>(nullable: true),
                    QuadMenuDocumentID = table.Column<int>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    Abstract = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_Document1",
                        column: x => x.ActiveIconDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Document",
                        column: x => x.CoverDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Document2",
                        column: x => x.InactiveIconDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.ParentCategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Document3",
                        column: x => x.QuadMenuDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
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
                    GenderCodeID = table.Column<int>(nullable: true),
                    ProfileDocumentID = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsRegister = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    RegisteredDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Code",
                        column: x => x.GenderCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Document_ProfileDocumentID",
                        column: x => x.ProfileDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
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
                    CityID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
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
                    BusinessTypeCodeID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(maxLength: 128, nullable: false),
                    Longitude = table.Column<string>(maxLength: 128, nullable: false),
                    Credit = table.Column<int>(nullable: false),
                    AverageRate = table.Column<double>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ContractorID);
                    table.ForeignKey(
                        name: "FK_Contractor_Code",
                        column: x => x.BusinessTypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
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
                    Cost = table.Column<long>(nullable: false),
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
                name: "Token",
                columns: table => new
                {
                    TokenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    RoleCodeID = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_Token_Code",
                        column: x => x.RoleCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
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
                    ContractorID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    StateCodeID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: true),
                    Cost = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    DeadlineDate = table.Column<DateTime>(nullable: true),
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
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentGUID = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    TrackingToken = table.Column<long>(nullable: true),
                    IsSuccessful = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
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
                name: "OrderRequest",
                columns: table => new
                {
                    OrderRequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRequestGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    OfferedPrice = table.Column<long>(nullable: false),
                    IsAllow = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
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
                    OrderRequestID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    IsSeen = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsModified = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    SentAt = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.ChatMessageID);
                    table.ForeignKey(
                        name: "FK_ChatMessage_OrderRequest",
                        column: x => x.OrderRequestID,
                        principalTable: "OrderRequest",
                        principalColumn: "OrderRequestID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessage_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 1, null, null, new Guid("c265fd02-0194-4d38-83e8-a93bc3698fcc"), null, null, "سایت اصلی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(1343), null, null, 1 },
                    { 2, null, null, new Guid("dec37f17-0ab2-4208-8ba7-11cc1120369b"), null, null, "وبلاگ", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3578), null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "CodeGroupID", "CodeGroupGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("5b739a57-164e-4b39-8b1c-1129bc9d8991"), "نوع فایل", "FilepondType" },
                    { 2, new Guid("2d9c9e83-39eb-42d7-b71f-ef26002c8470"), "نوع کسب و کار", "BusinessType" },
                    { 3, new Guid("a76da3ba-d12a-42c4-b7e1-732d0990af70"), "جنسیت", "Gender" },
                    { 4, new Guid("39c56245-8e42-4cef-8ddd-5e4c17782e8b"), "وضعیت سفارش", "OrderState" },
                    { 5, new Guid("7e9db57a-0c09-47ff-98b5-f49363beff67"), "نقش", "Role" },
                    { 6, new Guid("107a7244-6e66-4369-8ba6-dfb0636642c4"), "نوع کسب و کار بخش ارتباط با ما", "ContactUsBusinessType" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("21490341-0593-4c5a-a57c-6fc73780d7dd") },
                    { 20, "ايلام", new Guid("e13dddd6-0d25-4d7e-8b3f-04308409e0ce") },
                    { 21, "تهران", new Guid("7980e1c5-9544-4d52-84cb-b16698d7287e") },
                    { 22, "آذربايجان شرقي", new Guid("484dc218-a85e-4a54-abcb-ed4f83f0e190") },
                    { 23, "فارس", new Guid("e6aeb680-9bd2-444b-9f9e-0d49c4dae05f") },
                    { 24, "کرمانشاه", new Guid("4abdbaed-44dc-4d9e-849b-dfb6ba463428") },
                    { 28, "همدان", new Guid("7498bc57-cd24-4a40-bfd5-e0db8864737f") },
                    { 26, "مرکزي", new Guid("35991069-bac1-4353-b86d-8c57aa4735c5") },
                    { 27, "گيلان", new Guid("a11a0f68-79fe-4df9-a2bb-6ca40530e503") },
                    { 18, "اردبيل", new Guid("e47803c0-891f-4b28-bd0b-74cc3f934bb4") },
                    { 29, "کرمان", new Guid("365b3465-216d-4295-a958-0dadd5b3628b") },
                    { 30, "سمنان", new Guid("8f101ce6-175f-4478-9506-33875d5d94f7") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("f1b8955c-b2d7-41bd-8872-12063f992452") },
                    { 25, "هرمزگان", new Guid("febdf31b-fff0-48d3-9bbc-34b64d7c356c") },
                    { 17, "لرستان", new Guid("0e66be02-70a1-44bb-8556-f4f4ee6c82e7") },
                    { 14, "گلستان", new Guid("d5ae4c3c-3c2a-465c-acaa-9d8d588f0a7f") },
                    { 15, "مازندران", new Guid("bfaed822-51e7-4fe5-8e1b-939a73ae4ee3") },
                    { 1, "يزد", new Guid("21ec1abd-7b00-4715-875b-7f6f7a35c9a4") },
                    { 2, "چهار محال و بختياري", new Guid("0477cc9b-5861-41be-8042-b8f3cd6b07ae") },
                    { 3, "خراسان شمالي", new Guid("2911e110-1f35-4d64-8911-36f8fd9d7249") },
                    { 4, "البرز", new Guid("5bf1161e-150d-4ef0-88be-4632211d8d9c") },
                    { 5, "قم", new Guid("71ccb67c-41f1-4abc-b69e-c1ea81453377") },
                    { 16, "قزوين", new Guid("9dd8cf38-6bbf-4ac8-84a2-fea02c9dd8b8") },
                    { 7, "آذربايجان غربي", new Guid("d8016011-034b-48e8-9fbe-9115ede5df52") },
                    { 6, "کردستان", new Guid("6a7e1587-5d6a-44de-bb52-32fbdca092c5") },
                    { 9, "سيستان و بلوچستان", new Guid("e511fdad-2021-482d-ab4f-c82f136c992e") },
                    { 10, "خراسان جنوبي", new Guid("78b91bf5-eb15-4b8c-b22e-e631bd811d4f") },
                    { 11, "خوزستان", new Guid("9954cafc-8be5-46a9-9c6b-f16aaa08d393") },
                    { 12, "بوشهر", new Guid("c3083c72-92ef-4a1f-a6ac-55ea25860388") },
                    { 13, "زنجان", new Guid("992cfb9f-0add-46e7-b628-71e89e966c87") },
                    { 8, "خراسان رضوي", new Guid("dfa637e1-0ba7-46d4-aee1-caf7db24bc7d") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 3, "سرویس گیرنده", new DateTime(2020, 5, 30, 15, 10, 40, 783, DateTimeKind.Local).AddTicks(96), "Client", new Guid("67aa2b73-1879-41f9-a3d4-b5070fca0cce") },
                    { 1, "ادمین", new DateTime(2020, 5, 30, 15, 10, 40, 782, DateTimeKind.Local).AddTicks(8973), "Admin", new Guid("37bc3365-c094-4b99-b530-d7bd8873c22b") },
                    { 2, "سرویس دهنده", new DateTime(2020, 5, 30, 15, 10, 40, 783, DateTimeKind.Local).AddTicks(63), "Contractor", new Guid("551ebfb9-adab-4a63-a183-8193811ac18e") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 5, 30, 15, 10, 40, 777, DateTimeKind.Local).AddTicks(7067), "ptcoptco", new Guid("b451a43b-ccb6-44d5-9dfa-71fc6020c392"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 3, null, null, new Guid("0b5a3450-3d45-4a80-b927-9b634f3525de"), null, null, "خانه", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3650), 1, null, 1 },
                    { 4, null, null, new Guid("51851d31-2182-497e-8165-c0a4461e6074"), null, null, "حمل و نقل", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3659), 1, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 826, new Guid("5cdf2ad4-46bd-4f75-a6dd-eb7d06970bd0"), "ليلان", 22 },
                    { 825, new Guid("76edeaa4-caeb-473f-8fea-ec15e9951e13"), "قره آغاج", 22 },
                    { 824, new Guid("c3fe652e-1368-48cb-b0be-787a74f86afe"), "عجب شير", 22 },
                    { 823, new Guid("ac2de811-c05d-47d0-83cc-bfa14c2fad8a"), "صوفيان", 22 },
                    { 822, new Guid("14c88715-4bbb-4724-a78a-de24823a5c79"), "شهر جديد سهند", 22 },
                    { 821, new Guid("a54f7998-a065-40d7-8925-1f9a492f2a5c"), "شند آباد", 22 },
                    { 820, new Guid("a05adbf9-a468-49fa-bfe3-e8f970555a43"), "شرفخانه", 22 },
                    { 819, new Guid("8900becc-c3fe-43b9-b591-9379af94a41a"), "شربيان", 22 },
                    { 818, new Guid("78804860-8ead-4e20-8503-0e6141da511d"), "شبستر", 22 },
                    { 817, new Guid("3fed72a2-c6df-4b10-9e42-11ea0591a2bc"), "سيه رود", 22 },
                    { 816, new Guid("3c5adde5-8c2a-40bd-988b-e40bf45649ff"), "سيس", 22 },
                    { 815, new Guid("79b0f689-2b7b-462a-ab1e-29a21fc16530"), "سردرود", 22 },
                    { 814, new Guid("aabdab21-53d6-4383-b23d-d5e4d2caf303"), "سراب", 22 },
                    { 813, new Guid("640250f4-3da4-4980-a4a8-caa97793323e"), "زنوز", 22 },
                    { 812, new Guid("4669fd04-eb5d-42f3-9f4e-61a82e3390e0"), "زرنق", 22 },
                    { 827, new Guid("f93a5f38-4994-4c25-b9e0-b0f40ce54489"), "مبارک شهر", 22 },
                    { 828, new Guid("13df4107-8e77-43e9-b5aa-23019d85045c"), "مراغه", 22 },
                    { 829, new Guid("ac945247-7d2a-4c15-b1bf-028c096a5fca"), "مرند", 22 },
                    { 830, new Guid("ad662268-3ee7-4bee-9c44-38f2a9f3b2af"), "ملکان", 22 },
                    { 846, new Guid("943e4af6-c624-499c-980a-3a076106cdd0"), "گوگان", 22 },
                    { 845, new Guid("9b40d57c-de9d-4e99-af9f-73cf855e5458"), "کوزه کنان", 22 },
                    { 844, new Guid("1aa474c0-12a9-4092-bcca-cffa513f6f5f"), "کليبر", 22 },
                    { 843, new Guid("e42ab1fe-be58-445a-bd7b-c8b2f5d48d63"), "کلوانق", 22 },
                    { 842, new Guid("6a425c10-4dd6-4e09-8531-149c591fa13c"), "کشکسراي", 22 },
                    { 841, new Guid("131ceaa3-51fd-4b82-a0f0-c739906d15da"), "يامچي", 22 },
                    { 840, new Guid("e08321ad-8700-4ed1-a1d3-d5663438f017"), "ورزقان", 22 },
                    { 811, new Guid("9331f677-3f05-497f-b1a1-1bc8a510ff63"), "دوزدوزان", 22 },
                    { 839, new Guid("7e2e845b-17bd-4402-8831-b4feb3ed67ce"), "وايقان", 22 },
                    { 837, new Guid("8f31e0ca-2b04-4e64-98d5-06d205e1862c"), "هشترود", 22 },
                    { 836, new Guid("2d41f809-23be-49c9-959e-41bc6d584642"), "هريس", 22 },
                    { 835, new Guid("5ebf56be-fdd0-49d5-9550-7b998d2ec826"), "هاديشهر", 22 },
                    { 834, new Guid("6977f8ff-da40-4e83-aac7-60ca7c640b80"), "نظرکهريزي", 22 },
                    { 833, new Guid("769e92b7-cc4c-4a80-8f18-1f1b1ea7fee1"), "ميانه", 22 },
                    { 832, new Guid("f395ed6b-cb2a-4743-b1af-8fe697431c50"), "مهربان", 22 },
                    { 831, new Guid("a1af2433-74e7-4a17-8b30-2f71c865829b"), "ممقان", 22 },
                    { 838, new Guid("5d82796a-a97b-4dad-988b-bfb797aef005"), "هوراند", 22 },
                    { 810, new Guid("b6c27ae7-7f49-4115-b7ec-176f96418720"), "خواجه", 22 },
                    { 809, new Guid("228fdfa2-6fd2-4a25-8b73-14029b151e50"), "خمارلو", 22 },
                    { 808, new Guid("d89cebb0-5be9-472f-9ff6-7a271a16da1b"), "خسروشاه", 22 },
                    { 787, new Guid("d837d792-1234-4463-91eb-f720996023b1"), "آقکند", 22 },
                    { 786, new Guid("e3a51709-19c0-4a8e-b3e2-6421d22a6ee9"), "آذرشهر", 22 },
                    { 785, new Guid("fe07d587-375f-4234-b49b-db298c4c0fc0"), "آبش احمد", 22 },
                    { 784, new Guid("3cfe539c-d70a-42d3-af52-a8d6f06d0e11"), "گلستان", 21 },
                    { 783, new Guid("1b32d023-561c-45ad-a7d2-14e0455dcbd0"), "کيلان", 21 },
                    { 782, new Guid("1940e0fd-8168-4a9d-86c2-8f25b938725a"), "کهريزک", 21 },
                    { 781, new Guid("76b62a63-b8e5-41c0-a423-72d5145a0a4a"), "چهاردانگه", 21 },
                    { 780, new Guid("1c49f2fd-b870-4e85-bb74-dfec2e4d367c"), "پيشوا", 21 },
                    { 779, new Guid("f7abc938-3220-4096-9b83-08d4a75f1338"), "پرديس", 21 },
                    { 778, new Guid("84fd6260-77f6-42be-82be-f0aa1b0669ae"), "پاکدشت", 21 },
                    { 777, new Guid("80debf64-4c0f-4c26-9457-7bff6abc9b82"), "ورامين", 21 },
                    { 776, new Guid("5ee31f11-376e-431e-9de8-9d8e152c36c6"), "وحيديه", 21 },
                    { 775, new Guid("b8c396ad-cf3e-4837-9d03-ba13214c4e84"), "نصيرشهر", 21 },
                    { 774, new Guid("cdc4a553-2414-4484-b71c-a98e54870dd1"), "نسيم شهر", 21 },
                    { 773, new Guid("af73607e-a3db-4f0f-8bbf-e20cabecbdb2"), "ملارد", 21 },
                    { 788, new Guid("606d15d3-f038-4059-a87f-62e8e0176db8"), "آچاچي", 22 },
                    { 789, new Guid("654b6f39-6148-4247-b99d-30a03db7f71b"), "اسکو", 22 },
                    { 790, new Guid("6aa0386c-7756-4dea-95b7-c229fcde3a08"), "اهر", 22 },
                    { 791, new Guid("30163fc1-5bfe-45fb-b8e9-2bc0a714cda4"), "ايلخچي", 22 },
                    { 807, new Guid("72352e11-5521-4bad-b2fe-f4f4d3eac79e"), "خداجو", 22 },
                    { 806, new Guid("55b069ef-918d-4719-88ba-1f7acaf131a4"), "خامنه", 22 },
                    { 805, new Guid("cb7599cf-c1c3-4eb0-badd-7b4010b07138"), "خاروانا", 22 },
                    { 804, new Guid("e5fd825b-f71e-4fb8-82d8-9fdfa5a8d1fb"), "جوان قلعه", 22 },
                    { 803, new Guid("e5c77c87-556f-44e1-8883-3dc64e2b8e06"), "جلفا", 22 },
                    { 802, new Guid("c8790410-208b-4d50-8d7e-2dc7ee5abfe1"), "تيکمه داش", 22 },
                    { 801, new Guid("da25a289-b322-4409-a6b2-7d59fe911e36"), "تيمورلو", 22 },
                    { 847, new Guid("612125b1-04b8-49b9-8c16-d59e944ed469"), "آباده", 23 },
                    { 800, new Guid("6a4b2e08-e831-4dd7-ba64-a6cf39dcd0a3"), "تسوج", 22 },
                    { 798, new Guid("fdac1c5b-a0d4-49c8-8228-1121f591a466"), "ترک", 22 },
                    { 797, new Guid("5936977a-21ba-439e-924f-74d927439745"), "تبريز", 22 },
                    { 796, new Guid("bb64e1a9-5dd5-4e6a-9b2d-095993a599ec"), "بناب مرند", 22 },
                    { 795, new Guid("ea995fd8-37f6-4d3e-9ab8-f31ce699c669"), "بناب", 22 },
                    { 794, new Guid("97e35740-fcc5-4acf-8f8c-979f9bbae020"), "بستان آباد", 22 },
                    { 793, new Guid("c6ed0648-4560-4d4a-a98a-0b4a926c9bd8"), "بخشايش", 22 },
                    { 792, new Guid("95bde1aa-4253-4cc7-b316-541f10f0daa6"), "باسمنج", 22 },
                    { 799, new Guid("909fbe5a-0a01-49f3-9f48-64ba051a2cb7"), "ترکمانچاي", 22 },
                    { 848, new Guid("6203abb1-b4ce-486c-a984-daa3a9a78cc7"), "آباده طشک", 23 },
                    { 849, new Guid("f497202b-0920-44d6-9815-c1a88a4e9a10"), "اردکان", 23 },
                    { 850, new Guid("87b3cd62-c836-4c1e-8409-78a531f23d26"), "ارسنجان", 23 },
                    { 905, new Guid("38a73e51-67e7-4499-9cbd-28468f80d33c"), "صغاد", 23 },
                    { 904, new Guid("1554c516-f5cd-4d49-a1ff-a6b932acfc48"), "شيراز", 23 },
                    { 903, new Guid("50861bf8-577a-4059-98c9-a7a164ed5608"), "شهر پير", 23 },
                    { 902, new Guid("534e7014-e8d5-466b-a0aa-a04edaee4b90"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("c9fcd850-9aed-4d9e-86ec-00ee7dec4a04"), "ششده", 23 },
                    { 900, new Guid("b3b3ebcc-0523-40f0-8cc6-db27cdefe1b5"), "سيدان", 23 },
                    { 899, new Guid("e976114f-f6ae-4a5c-a7a1-395fe01a280a"), "سورمق", 23 },
                    { 898, new Guid("50cfbc84-5300-420d-afeb-4bcd7df7542a"), "سلطان شهر", 23 },
                    { 897, new Guid("46aeb7a4-8056-40bf-afc2-a93da82f351e"), "سعادت شهر", 23 },
                    { 896, new Guid("d6758752-2e5d-4924-af2d-572b4bdc539d"), "سروستان", 23 },
                    { 895, new Guid("b369f621-b758-4c8c-a2a7-8d09092f6442"), "سده", 23 },
                    { 894, new Guid("8e7b8abe-0a6e-4147-a088-e00737e524c9"), "زرقان", 23 },
                    { 893, new Guid("14dcbe66-4dc7-421f-af95-4e5c726d8820"), "زاهد شهر", 23 },
                    { 892, new Guid("e9190cbd-65ac-402e-9521-f4895130f929"), "رونيز", 23 },
                    { 891, new Guid("13439988-e0d6-4efd-b3a6-e597245534ba"), "رامجرد", 23 },
                    { 906, new Guid("422f8abd-ffa1-4eb7-88bf-10d208b6ea15"), "صفا شهر", 23 },
                    { 907, new Guid("8510e437-c276-43a6-934d-7f6de64667a7"), "علامرودشت", 23 },
                    { 908, new Guid("17839a8a-27d3-491b-8a48-8b18b546eee4"), "عماد ده", 23 },
                    { 909, new Guid("edec522a-bc8b-4cfa-9dda-c47133568e07"), "فدامي", 23 },
                    { 925, new Guid("db057c10-e2eb-4842-bdc0-eb67d46739a8"), "مرودشت", 23 },
                    { 924, new Guid("60f47e0c-d959-404e-94a0-bfb4c7152ec0"), "مبارک آباد", 23 },
                    { 923, new Guid("36e5702f-e516-4353-a385-8c134c5425d3"), "مادرسليمان", 23 },
                    { 922, new Guid("62b7b0fa-acdc-4014-af81-8701f0794b2b"), "لپوئي", 23 },
                    { 921, new Guid("eaa13759-eafb-4dfd-8834-ca25a74c3bbb"), "لطيفي", 23 },
                    { 920, new Guid("c5549467-dd82-48df-80c6-9850ae256055"), "لامرد", 23 },
                    { 919, new Guid("3996196d-200b-460c-8677-679142fba95b"), "لار", 23 },
                    { 890, new Guid("ab3a676d-2cb0-43ac-bba7-69280a5633ec"), "دژکرد", 23 },
                    { 918, new Guid("2fd73038-c8fd-45de-aa6f-9c498eafc3df"), "قير", 23 },
                    { 916, new Guid("b1f77c23-7f4f-4b63-b33f-11ca2f3d081e"), "قطب آباد", 23 },
                    { 915, new Guid("9aad5726-85a4-4f50-98eb-ca165cfb9a56"), "قره بلاغ", 23 },
                    { 914, new Guid("996c50e1-f9ea-42eb-bf44-39fd939da203"), "قادرآباد", 23 },
                    { 913, new Guid("2fbc37ae-ec76-418a-be14-ae156074b0d6"), "قائميه", 23 },
                    { 912, new Guid("1a3b2caa-b3fc-4a38-962b-ddf4f43c14f8"), "فيروزآباد", 23 },
                    { 911, new Guid("69a49b39-0081-44b0-9298-fab411272e92"), "فسا", 23 },
                    { 910, new Guid("4152bf07-4588-4e08-aef8-75a45bda53df"), "فراشبند", 23 },
                    { 917, new Guid("63c49c68-5c03-4634-bd30-9c8c94ea3b9e"), "قطرويه", 23 },
                    { 889, new Guid("7e048ba1-1c18-4a70-b770-6c05c76217fc"), "دوزه", 23 },
                    { 888, new Guid("0d123595-af5a-480f-bc5d-f8cdbc25ce31"), "دوبرجي", 23 },
                    { 887, new Guid("a4db5a0f-c62d-491a-87e6-a046dde5516c"), "دهرم", 23 },
                    { 866, new Guid("0800e089-97dd-441c-8b07-e4fbf12037a2"), "بوانات", 23 },
                    { 865, new Guid("76af3bbe-55b2-4ca6-b36c-6bb73b654e02"), "بهمن", 23 },
                    { 864, new Guid("afb1f4fb-8b22-4b40-9391-408231d2fdfa"), "بنارويه", 23 },
                    { 863, new Guid("64d1a77e-8e8c-4052-997a-485a8912c58d"), "بالاده", 23 },
                    { 862, new Guid("4d403320-c996-4a15-87f2-5202f9f3064f"), "بابامنير", 23 },
                    { 861, new Guid("d172f94e-f2e5-413a-b2c6-6e561c4a6a79"), "باب انار", 23 },
                    { 860, new Guid("67a02ae4-dfd6-440b-a49c-6e8a7edbd400"), "ايزد خواست", 23 },
                    { 867, new Guid("95c34922-88cc-470a-a44a-47e7b6ea5bb6"), "بيرم", 23 },
                    { 859, new Guid("8dfe5fd1-ec0e-4c42-8fb9-3ee6445a9220"), "ايج", 23 },
                    { 857, new Guid("bda2734f-af00-40aa-96f0-6c8a2d1578ff"), "اهل", 23 },
                    { 856, new Guid("af2956fb-b137-441a-b266-68bbc00975b6"), "امام شهر", 23 },
                    { 855, new Guid("1f397bb4-516c-4d08-9cb3-eac2d378e521"), "اقليد", 23 },
                    { 854, new Guid("5c9e67a7-d273-4c50-8cd5-ee9df72a9196"), "افزر", 23 },
                    { 853, new Guid("dea400cf-386d-4e41-8dc1-294ffb75e8fd"), "اشکنان", 23 },
                    { 852, new Guid("9ebc5f62-dd91-4bd2-902e-31cb9130b2ac"), "اسير", 23 },
                    { 851, new Guid("047b293e-d2e1-426e-8705-0d3ce317be28"), "استهبان", 23 },
                    { 858, new Guid("588631ee-7393-401b-8ab7-42f25551e8e8"), "اوز", 23 },
                    { 772, new Guid("1bdd7593-ddaa-4a32-84f6-c0f3c88d3629"), "لواسان", 21 },
                    { 868, new Guid("f8bc8f5f-fd8e-4a15-bdac-71d23b209375"), "بيضا", 23 },
                    { 870, new Guid("5117824c-5eff-48fb-bda0-853d4591816e"), "جهرم", 23 },
                    { 886, new Guid("97337b8a-4f84-4be7-81d9-9b5dd8ce14b2"), "دبيران", 23 },
                    { 885, new Guid("c78cb54f-8d40-47dd-91d6-282a43a00cfb"), "داريان", 23 },
                    { 884, new Guid("236a5d57-aeb2-47a1-9cd6-edd3d7de19c6"), "داراب", 23 },
                    { 883, new Guid("acd7399c-1230-465d-979f-a45abbfc9d27"), "خومه زار", 23 },
                    { 882, new Guid("a6b8ebcd-e3f6-4ae5-ba46-e1e5639d2b02"), "خوزي", 23 },
                    { 881, new Guid("ac6fe8a4-943e-4af0-b538-7c37ca310e7e"), "خور", 23 },
                    { 880, new Guid("34d24693-73ce-4312-92c0-63896771e113"), "خنج", 23 },
                    { 869, new Guid("998aafd6-9130-419b-a03f-74b5723943cc"), "جنت شهر", 23 },
                    { 879, new Guid("2442f433-5ef3-4b8b-831e-d0abd5080998"), "خشت", 23 },
                    { 877, new Guid("60d72d98-3aa1-43df-bf46-21f6b584df6c"), "خاوران", 23 },
                    { 876, new Guid("8cb3ece6-33bb-426c-866a-1c251996006b"), "خانيمن", 23 },
                    { 875, new Guid("9d882339-057a-4f80-9774-9d196693fc75"), "خانه زنيان", 23 },
                    { 874, new Guid("741238f8-d92e-47a5-b69a-6a2ed3c08ba2"), "حسن آباد", 23 },
                    { 873, new Guid("6ffae027-18e7-4dea-af77-0857c483e25f"), "حسامي", 23 },
                    { 872, new Guid("b490f574-8370-4c6f-94ab-ba8d41f2b9da"), "حاجي آباد", 23 },
                    { 871, new Guid("583e0c5f-aca1-42c2-a028-09e4ad9f24a5"), "جويم", 23 },
                    { 878, new Guid("a98a0f85-b588-4719-b275-1ecfcf897d04"), "خرامه", 23 },
                    { 771, new Guid("4ada5669-2622-4323-81f4-48609956f0cc"), "قرچک", 21 },
                    { 770, new Guid("2594a1e4-5c6b-4bc2-acc4-ef283d53fba2"), "قدس", 21 },
                    { 769, new Guid("80b6f707-57f9-4fb8-9606-779d76c903fa"), "فيروزکوه", 21 },
                    { 669, new Guid("4e6d1f08-bbd2-43ad-be5d-6d6a246a05b7"), "عسگران", 19 },
                    { 668, new Guid("9fe91982-f14b-478b-95ce-18360b9dbf16"), "طرق رود", 19 },
                    { 667, new Guid("9aafa5b7-97ea-4fd9-abdf-3d742ab86b4c"), "طالخونچه", 19 },
                    { 666, new Guid("db25fd07-1a1e-4ec2-ac08-415e343b8906"), "شهرضا", 19 },
                    { 665, new Guid("136e8a46-d280-4566-9db6-fb10480e0681"), "شاپورآباد", 19 },
                    { 664, new Guid("8014c37e-0c58-4351-8e7a-1685366fa5f3"), "شاهين شهر", 19 },
                    { 663, new Guid("260c38bc-8917-4ea4-b191-dd5a59838a06"), "سگزي", 19 },
                    { 662, new Guid("6f6fc074-630e-414b-9242-fe4a2d34a6b4"), "سين", 19 },
                    { 661, new Guid("7b2b50f9-5a3f-4372-8abc-91bd2734b015"), "سميرم", 19 },
                    { 660, new Guid("79fae174-6bdd-4d34-98e0-f6cd7f8ea84d"), "سفيد شهر", 19 },
                    { 659, new Guid("ea75d341-c3c4-4cc6-9b84-ee046d8deb9b"), "سده لنجان", 19 },
                    { 658, new Guid("9080b53a-ed1b-4c76-a390-9fea9a4eb1aa"), "زيباشهر", 19 },
                    { 657, new Guid("7037da50-7d70-4476-a8e1-6356e99988bc"), "زيار", 19 },
                    { 656, new Guid("35b2e47e-1727-4785-9217-b9651db20f94"), "زواره", 19 },
                    { 655, new Guid("b51c5ee9-b754-4f79-a2fd-5138c891932b"), "زرين شهر", 19 },
                    { 670, new Guid("9ce2d6ed-94f9-4ece-9b36-1f71795161df"), "علويچه", 19 },
                    { 671, new Guid("4ec33b8c-7305-42a6-9a32-5cde29279c9e"), "فرخي", 19 },
                    { 672, new Guid("8f94731a-d346-40dd-ba0d-4abff64c48f7"), "فريدونشهر", 19 },
                    { 673, new Guid("1d2db771-dd32-4b27-a438-85f75617f59e"), "فلاورجان", 19 },
                    { 689, new Guid("7f217f1e-cf00-412b-ba41-e0ec6b816bf5"), "نوش آباد", 19 },
                    { 688, new Guid("abc1d083-8742-48e4-b515-dfdfc73e9d84"), "نطنز", 19 },
                    { 687, new Guid("9369f0ce-76a2-4145-9a46-6037e0db4a0a"), "نصرآباد", 19 },
                    { 686, new Guid("93c5206a-06e0-4700-b32c-1a932e14f7a8"), "نجف آباد", 19 },
                    { 685, new Guid("ac6ca323-fd4b-427e-8934-0c81fe53d35f"), "نائين", 19 },
                    { 684, new Guid("f1d13ef9-e1d1-40bf-84c2-e5b68baaebb8"), "ميمه", 19 },
                    { 683, new Guid("ba6217c6-67a7-4259-aeaa-fa5f89250ff7"), "مهاباد", 19 },
                    { 654, new Guid("25fa2ec2-da59-44e3-9dd4-c2df7e5a0ed5"), "زاينده رود", 19 },
                    { 682, new Guid("2d2f518b-caf2-40e3-aee0-da03d0b02b18"), "منظريه", 19 },
                    { 680, new Guid("74f33ca0-7488-4fc9-8736-b9c9d8bf927c"), "محمد آباد", 19 },
                    { 679, new Guid("e96c57bb-a225-4ed8-b30b-2a9734976db1"), "مبارکه", 19 },
                    { 678, new Guid("72b913ee-bbab-4968-a888-1c8d32463f04"), "لاي بيد", 19 },
                    { 677, new Guid("d045c757-3ac6-47ef-888c-375b39a22ff2"), "قهدريجان", 19 },
                    { 676, new Guid("442a5522-f27f-44e7-b47d-81583b8db094"), "قهجاورستان", 19 },
                    { 675, new Guid("11dbc821-795b-4f42-b611-72b303b1375b"), "قمصر", 19 },
                    { 674, new Guid("4af3d328-f263-4a8c-8c41-2283f8561823"), "فولاد شهر", 19 },
                    { 681, new Guid("30cad3c3-11c7-4a44-a146-17b06cc60220"), "مشکات", 19 },
                    { 653, new Guid("26739618-8247-4ee2-8055-ce43bf0101f7"), "زازران", 19 },
                    { 652, new Guid("fe2b68e0-6ed4-4acb-a89d-181b528a71d1"), "رضوانشهر", 19 },
                    { 651, new Guid("7b90e5e4-66c1-4456-9834-69c620f0bc9a"), "رزوه", 19 },
                    { 630, new Guid("9d2803af-6ccc-44bd-b7c7-a66e1a0cbf58"), "تودشک", 19 },
                    { 629, new Guid("fdd3a8cd-c6e8-4406-8c67-7d9951e25318"), "بوئين مياندشت", 19 },
                    { 628, new Guid("6406ef54-edb4-4d30-b109-7397be39184b"), "بهارستان", 19 },
                    { 627, new Guid("bd922114-de16-4260-acb3-3a9869e9e631"), "بهاران شهر", 19 },
                    { 626, new Guid("8fbbdb95-d36a-4dec-a09c-d7143d1bb6d3"), "برف انبار", 19 },
                    { 625, new Guid("b153c595-fb18-4691-9e0e-58158de99a74"), "برزک", 19 },
                    { 624, new Guid("1ef62e17-cd36-4411-a81e-bab40038b9cc"), "بافران", 19 },
                    { 631, new Guid("79264f09-7122-40bc-89a8-a8d6cda8a5d8"), "تيران", 19 },
                    { 623, new Guid("270e152a-7106-4c96-8877-742069ce3e84"), "باغشاد", 19 },
                    { 621, new Guid("8b092865-84ac-4c70-b631-4565716c7e07"), "بادرود", 19 },
                    { 620, new Guid("829fd4f0-24ee-4220-92c9-f5d6312befa9"), "اژيه", 19 },
                    { 619, new Guid("6802338c-7342-467e-be32-23487521db82"), "ايمانشهر", 19 },
                    { 618, new Guid("87dbe795-a69f-4cc3-97bb-7b00c438d8d6"), "انارک", 19 },
                    { 617, new Guid("54b9c39a-16b6-4b7f-8a0e-0376734784a7"), "افوس", 19 },
                    { 616, new Guid("b1abb8f3-f153-4b03-be0c-1014dad99c05"), "اصفهان", 19 },
                    { 615, new Guid("9c02f4dc-c62d-4496-bb0b-23b8d8a729e1"), "اصغرآباد", 19 },
                    { 622, new Guid("519fd891-7f95-4ac4-b254-048f8784b55b"), "باغ بهادران", 19 },
                    { 690, new Guid("aa2ce0f8-aa83-4a30-b2c2-d1abaaae0c4a"), "نياسر", 19 },
                    { 632, new Guid("d0ceb5ce-63ed-4841-a88e-41908e83ea37"), "جندق", 19 },
                    { 634, new Guid("1ee0305b-fe4a-4a46-9e25-9811c5d7934c"), "جوشقان قالي", 19 },
                    { 650, new Guid("1fb692a5-aad2-4c2d-b113-485c206d9195"), "ديزيچه", 19 },
                    { 649, new Guid("66497ba0-1007-4622-b38a-ba4286b7f575"), "دولت آباد", 19 },
                    { 648, new Guid("7f9d8970-1bbb-4f52-be20-4a51b33f9b65"), "دهق", 19 },
                    { 647, new Guid("b30f2bba-151b-4777-a697-e48781f625fa"), "دهاقان", 19 },
                    { 646, new Guid("5b112341-51d0-428b-82cd-5f5b1b6b53e0"), "دستگرد", 19 },
                    { 645, new Guid("89ef7518-f885-478e-9219-4caa7d53782a"), "درچه پياز", 19 },
                    { 644, new Guid("84ab920d-2d43-440b-b85c-4198476b32e6"), "دامنه", 19 },
                    { 633, new Guid("13c3c79b-13bf-4eb7-995a-239b6c647fbe"), "جوزدان", 19 },
                    { 643, new Guid("c9d8c528-8d5e-480b-b842-b5f944fcceb0"), "داران", 19 },
                    { 641, new Guid("1e1718ca-6edf-4233-8a21-ed7c109eb3e5"), "خور", 19 },
                    { 640, new Guid("ea3b0400-0e1d-4abe-aed3-4672a2f329e9"), "خوانسار", 19 },
                    { 639, new Guid("ab0c1a12-20ac-46ea-a8f3-ba5a75de6713"), "خميني شهر", 19 },
                    { 638, new Guid("98d53236-0dc7-4ce4-b159-1723af6c6e60"), "خالد آباد", 19 },
                    { 637, new Guid("d26342e0-7944-4ecc-ac90-5328fc371d3d"), "حنا", 19 },
                    { 636, new Guid("5c3d7a88-d794-4861-8f8d-7309baee9a34"), "حسن آباد", 19 },
                    { 635, new Guid("d28efe0e-8801-4200-b17b-40de45757f61"), "حبيب آباد", 19 },
                    { 642, new Guid("e772f086-3836-4800-b15e-e9758e089669"), "خورزوق", 19 },
                    { 926, new Guid("8ab9e5b9-9546-4d5c-b585-ba996c257224"), "مزايجان", 23 },
                    { 691, new Guid("ffaf4468-b018-472c-83a1-347eb7dbb1fb"), "نيک آباد", 19 },
                    { 693, new Guid("ddc41d81-96f4-4426-beb1-36022f6aee77"), "ورزنه", 19 },
                    { 748, new Guid("b6f0397e-b6d6-4de7-9c90-3997d4cd809f"), "باقرشهر", 21 },
                    { 747, new Guid("a6e438fa-e6a4-4de5-b33e-b452699f4b68"), "باغستان", 21 },
                    { 746, new Guid("5fe824b6-fc3a-476d-bca7-106754c9e6bf"), "انديشه", 21 },
                    { 745, new Guid("09e51b75-a7d5-43b3-8ebc-b27a504c87f1"), "اسلامشهر", 21 },
                    { 744, new Guid("76b83539-ecd2-408a-98e6-7a58d4c2717e"), "ارجمند", 21 },
                    { 743, new Guid("0d46ffc2-7a02-4fc1-80af-0dc8f27aeffa"), "آبعلي", 21 },
                    { 742, new Guid("aa34ebf9-529c-4e2c-8607-9a3981bcfd8c"), "آبسرد", 21 },
                    { 741, new Guid("56456685-84a2-4bd8-9af8-398f1a6cee15"), "چوار", 20 },
                    { 740, new Guid("7f1834e4-a629-4e5a-8079-029f016973b3"), "پهله", 20 },
                    { 739, new Guid("ce6b7c8a-3be7-477f-a035-30a475987464"), "ميمه", 20 },
                    { 738, new Guid("70ba2395-58ba-42cb-a401-a4fce629d08e"), "موسيان", 20 },
                    { 737, new Guid("7cd50181-16cf-41c3-b91e-dd0f46e41caa"), "مورموري", 20 },
                    { 736, new Guid("9a197f42-1195-4d92-bf86-53469808ea78"), "مهران", 20 },
                    { 735, new Guid("bf3fdea1-2aa7-4eef-a9a8-e4949ebb2f55"), "مهر", 20 },
                    { 734, new Guid("4d332f8c-5033-406b-ada0-d290c2192ec1"), "ماژين", 20 },
                    { 749, new Guid("678be955-f981-404e-881f-667c0889cb42"), "بومهن", 21 },
                    { 750, new Guid("121f3629-08dd-4650-bf28-c3d4e65f8038"), "تجريش", 21 },
                    { 751, new Guid("caac8ffb-2601-4780-9722-e81d6009b324"), "تهران", 21 },
                    { 752, new Guid("85b74ce9-0cb8-41c8-999f-8a840f65aa6d"), "جواد آباد", 21 },
                    { 768, new Guid("616cd972-365d-4ba7-a454-c2e48c2a0a85"), "فشم", 21 },
                    { 767, new Guid("e605a532-8d66-44ed-8466-a488f4c544db"), "فرون آباد", 21 },
                    { 766, new Guid("5c287f31-17a5-427e-acca-cb0198de01d1"), "فردوسيه", 21 },
                    { 765, new Guid("770e04e2-6294-4f11-aa0f-1b645e49c65b"), "صفادشت", 21 },
                    { 764, new Guid("6a50f809-6f8d-4fb8-81c6-b1c4b7892eca"), "صبا شهر", 21 },
                    { 763, new Guid("25700254-72cd-46da-ae49-4fc14084b068"), "صالحيه", 21 },
                    { 762, new Guid("0baa6e6f-9fc4-49f6-a2b1-5d504f64ba66"), "شهريار", 21 },
                    { 733, new Guid("a2ddedae-4918-4f65-968d-a92fa86db130"), "لومار", 20 },
                    { 761, new Guid("9157dd8d-be08-42ab-af50-eb8185dc5be7"), "شهر جديد پرند", 21 },
                    { 759, new Guid("1c1838da-90ad-4030-b5b4-62c5e4ae7ed8"), "شريف آباد", 21 },
                    { 758, new Guid("8be775e6-0f4b-4934-b777-b86a0f6c9aa5"), "شاهدشهر", 21 },
                    { 757, new Guid("f94ab150-36bb-4cc6-8269-65b0290826e5"), "ري", 21 },
                    { 756, new Guid("076b5c38-4355-4796-b104-13683dda224c"), "رودهن", 21 },
                    { 755, new Guid("86cb2ae0-a3ea-4b0e-a03a-31d7f5278cf0"), "رباط کريم", 21 },
                    { 754, new Guid("61daca50-4dbf-4797-9f2a-f249d60615a4"), "دماوند", 21 },
                    { 753, new Guid("fb4e148f-88c8-4ae8-b43d-3ae37c137052"), "حسن آباد", 21 },
                    { 760, new Guid("852f8b75-3c39-4bee-bc05-d747cfbd12b7"), "شمشک", 21 },
                    { 732, new Guid("2e02895f-131e-44b6-83fc-e031a44f17d5"), "صالح آباد", 20 },
                    { 731, new Guid("94d17efe-dd9b-4c8e-a98a-9cde6ec929f4"), "شباب", 20 },
                    { 730, new Guid("c70633b2-ddc6-4359-bc9d-b5f0c639099c"), "سرابله", 20 },
                    { 709, new Guid("f1e5bdc1-2e44-4eb8-9979-cabf82a8f57f"), "کوهپايه", 19 },
                    { 708, new Guid("b6b7e324-02fb-4274-acf2-9396dbdb2df6"), "کوشک", 19 },
                    { 707, new Guid("574ee9fb-4ed0-43fb-b194-4512922f5a3f"), "کهريزسنگ", 19 },
                    { 706, new Guid("f88998a8-5e6c-4729-9214-3e61fa598319"), "کمه", 19 },
                    { 705, new Guid("21313b15-2ba0-4a42-b87b-4a8f3b459552"), "کمشجه", 19 },
                    { 704, new Guid("91baf1b6-d171-46a0-a69e-6518675bb8a2"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("90eaa6eb-63c3-4764-890f-91700ffe8fb2"), "کرکوند", 19 },
                    { 710, new Guid("f22fd774-4d10-42ce-a03c-38e83cea1709"), "گرگاب", 19 },
                    { 702, new Guid("9b017b70-a73e-43b2-acc1-eb06b60f685f"), "کامو و چوگان", 19 },
                    { 700, new Guid("882edaa1-978d-4dcf-96c8-38b6939e7966"), "چمگردان", 19 },
                    { 699, new Guid("b02a28aa-2f4a-4bc9-a3d7-58f58e8858eb"), "چرمهين", 19 },
                    { 698, new Guid("ad3de53e-c423-4616-9660-9cdd6689ba0b"), "چادگان", 19 },
                    { 697, new Guid("194eedae-8bb1-42e8-93c3-3166c1f06389"), "پير بکران", 19 },
                    { 696, new Guid("06d79f55-4491-463a-8752-d83214469828"), "ونک", 19 },
                    { 695, new Guid("0b3a174e-a84f-4f72-b504-8982a3a0e408"), "وزوان", 19 },
                    { 694, new Guid("d3bb70ae-56a6-47ef-979c-4a330643301f"), "ورنامخواست", 19 },
                    { 701, new Guid("866e4eec-b04c-448d-9d2a-2d48adc7f6dd"), "کاشان", 19 },
                    { 692, new Guid("2accb3a1-417a-48ed-b8d5-7757713f4b86"), "هرند", 19 },
                    { 711, new Guid("4507029f-c932-4bcc-99e9-edd5c667bd0f"), "گز برخوار", 19 },
                    { 713, new Guid("58f0daa2-f041-4101-a9e9-acc5e23111a8"), "گلشن", 19 },
                    { 729, new Guid("8c0977b9-2f11-4f70-977e-b23cced7def1"), "سراب باغ", 20 },
                    { 728, new Guid("09c197ae-7d5e-4a44-90bd-5e6ac3e17b6b"), "زرنه", 20 },
                    { 727, new Guid("4964d8fb-77df-48e3-bc72-b635d72b4efe"), "دهلران", 20 },
                    { 726, new Guid("6ddd43be-ecf1-4076-9674-d1e710d24c49"), "دلگشا", 20 },
                    { 725, new Guid("df263cca-4508-42c6-9771-7b0374654783"), "دره شهر", 20 },
                    { 724, new Guid("3fd7b2b3-81c1-4d98-ace3-acb3b80cc5d7"), "توحيد", 20 },
                    { 723, new Guid("30cc3360-bf17-455e-a7e7-46f57ae326ef"), "بلاوه", 20 },
                    { 712, new Guid("40251958-9020-4409-921a-548b4361a7fe"), "گلدشت", 19 },
                    { 722, new Guid("9400eeb7-49ac-447e-8bb3-65103e3e3f1b"), "بدره", 20 },
                    { 720, new Guid("d1a9b54c-9410-4104-87cd-bb8ddd8fd162"), "ايلام", 20 },
                    { 719, new Guid("a4eeb2a4-61d8-47d7-aa6a-f08b60f0d7c4"), "ارکواز", 20 },
                    { 718, new Guid("9dfa5202-a740-49c0-a1b4-bc5ff493bc90"), "آسمان آباد", 20 },
                    { 717, new Guid("a2379b48-4e1c-4b21-a0e9-eed20119e72f"), "آبدانان", 20 },
                    { 716, new Guid("415c2705-42a7-42df-b49f-9ae56742344f"), "گوگد", 19 },
                    { 715, new Guid("b6ecc2d9-bf18-4f3d-be13-645e6c62e442"), "گلپايگان", 19 },
                    { 714, new Guid("6d85d35b-ebc3-4db1-84f9-d24708df31f5"), "گلشهر", 19 },
                    { 721, new Guid("abe285ff-45fb-4320-89e3-67730f39bac1"), "ايوان", 20 },
                    { 927, new Guid("b6b23a45-819f-4e13-9d17-2ab9ede5a8aa"), "مشکان", 23 },
                    { 928, new Guid("34e78c4a-78f6-4545-b53e-5fbea0d144ab"), "مصيري", 23 },
                    { 929, new Guid("7866fef0-7793-44ff-bac9-722954c8720c"), "مهر", 23 },
                    { 1141, new Guid("a9763a57-a72d-4a3b-a9a3-bec11b3a61a7"), "بردسير", 29 },
                    { 1140, new Guid("7c85d216-4634-480d-bd6a-da5a1f6b0775"), "بافت", 29 },
                    { 1139, new Guid("0cb8eb61-623e-4dfa-9cb8-cff0786ad679"), "باغين", 29 },
                    { 1138, new Guid("3fe50175-c4b2-4705-8d75-23e9d254b0ac"), "اندوهجرد", 29 },
                    { 1137, new Guid("51310062-5df0-4b3b-b7b2-edaa2b06d552"), "انار", 29 },
                    { 1136, new Guid("d67d8536-c865-4708-97da-2a1a4887b2e7"), "امين شهر", 29 },
                    { 1135, new Guid("d5bc4fa1-13a9-40e9-93e1-5677dbf419d3"), "ارزوئيه", 29 },
                    { 1134, new Guid("e1c4eba6-80d2-43ef-8e39-6b2f2cd57bb9"), "اختيار آباد", 29 },
                    { 1133, new Guid("31a5ffab-9fa5-4b2f-b7de-f27d92cdf556"), "گيان", 28 },
                    { 1132, new Guid("d13da653-fd7f-4cde-8a26-af08fa51cbeb"), "گل تپه", 28 },
                    { 1131, new Guid("047c662c-52e0-4d04-91f9-cb7f2127edf4"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("34098307-eab7-4cb7-92b2-6981f584b7cc"), "همدان", 28 },
                    { 1129, new Guid("f4ad8803-4537-48b4-8e0c-e914e7483462"), "نهاوند", 28 },
                    { 1128, new Guid("462f1510-ec15-411d-9e88-65d7ff95e93c"), "مهاجران", 28 },
                    { 1127, new Guid("b30a5b0c-210f-49ef-adb2-d659c8f6bde9"), "ملاير", 28 },
                    { 1142, new Guid("debfbd0e-76e2-4336-916f-eb3f6e772e2b"), "بروات", 29 },
                    { 1143, new Guid("e3d96753-66c8-4cb4-aed6-9d98b69a8dc4"), "بزنجان", 29 },
                    { 1144, new Guid("78296186-4048-4c9a-8551-9f76ca14d85a"), "بلورد", 29 },
                    { 1145, new Guid("906cc1ab-1de6-40f6-a6c7-20ed5521310d"), "بلوک", 29 },
                    { 1161, new Guid("47382bed-4233-4464-be9b-5ad962ddd2a9"), "راور", 29 },
                    { 1160, new Guid("802f2be7-f730-4110-9add-ae0551dfcf37"), "رابر", 29 },
                    { 1159, new Guid("b0ff9fa5-6f2b-4a50-809d-058e58ddd69e"), "دوساري", 29 },
                    { 1158, new Guid("3235cc49-6ddb-41dc-8092-b803cd005775"), "دهج", 29 },
                    { 1157, new Guid("b4805900-0f1f-499b-a9b2-c14c2829ec01"), "دشتکار", 29 },
                    { 1156, new Guid("3c806fa7-cab9-4289-933c-d03df3a59171"), "درب بهشت", 29 },
                    { 1155, new Guid("ef913aba-19a5-45c6-a1a4-689a1a923381"), "خورسند", 29 },
                    { 1126, new Guid("3950522e-e3d3-43ec-afcc-4b0ea68740cf"), "مريانج", 28 },
                    { 1154, new Guid("b0a13c9b-5c07-4d34-b0e1-b05bcdc8db60"), "خواجوشهر", 29 },
                    { 1152, new Guid("8090a015-d632-4dfb-a74b-3126f72f1dcf"), "خاتون آباد", 29 },
                    { 1151, new Guid("04e79c30-df49-4a79-9465-3629bb3dc35e"), "جيرفت", 29 },
                    { 1150, new Guid("ae39ce53-0b59-43bd-93e5-9aa6266abe21"), "جوپار", 29 },
                    { 1149, new Guid("e8113316-77f3-4e90-ade7-a0b8d289cbf3"), "جوزم", 29 },
                    { 1148, new Guid("7b2ce561-367f-481f-8c45-a85b3e738fe2"), "جبالبارز", 29 },
                    { 1147, new Guid("b7c8ec8d-b9ad-4cd0-8b2d-59539fc7601b"), "بهرمان", 29 },
                    { 1146, new Guid("9bec7b5f-38b7-4507-b1db-1e3c3b4cb2df"), "بم", 29 },
                    { 1153, new Guid("19701616-9aca-4b09-9342-7ae554e6f56e"), "خانوک", 29 },
                    { 1162, new Guid("a89eb683-65a5-47be-aaed-645d6786d8ea"), "راين", 29 },
                    { 1125, new Guid("d67528cc-b930-4dd4-b6cb-559e29793b58"), "لالجين", 28 },
                    { 1123, new Guid("b3b8a8e4-4efd-4b66-bd44-7cc2e1ebfec8"), "قروه در جزين", 28 },
                    { 1102, new Guid("a9599e76-b24f-4102-8b8c-d2f2fdd36f35"), "کوچصفهان", 27 },
                    { 1101, new Guid("c1ea7e60-bdb5-40a6-b113-9568c4b04622"), "کومله", 27 },
                    { 1100, new Guid("cbb6954f-a4a8-4be1-b9bd-e9d1ca940021"), "کلاچاي", 27 },
                    { 1099, new Guid("5c2739da-a0ba-4c8f-9035-5428d25327e0"), "چوبر", 27 },
                    { 1098, new Guid("0e60c403-63d3-44f7-95de-a293283dbe28"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("f49a0469-dae2-4252-a95b-c5e36a77cf8a"), "چابکسر", 27 },
                    { 1096, new Guid("79295a87-b905-41ed-89ca-4687cf8631dd"), "پره سر", 27 },
                    { 1095, new Guid("8cbb731b-ef94-453c-b280-d911eb48aa6e"), "واجارگاه", 27 },
                    { 1094, new Guid("1412bda3-6dde-40ca-822a-46b64e2bd5ee"), "هشتپر", 27 },
                    { 1093, new Guid("447b5e45-ef0f-4c5e-acc8-03f08cf176bd"), "منجيل", 27 },
                    { 1092, new Guid("b0fb9830-fcd3-4fbf-9417-df81698e33fd"), "مرجقل", 27 },
                    { 1091, new Guid("963bfec1-0535-43a9-a9ac-701e71e7f173"), "ماکلوان", 27 },
                    { 1090, new Guid("11afd875-7ba6-4ae2-9575-e52eff8b9c9c"), "ماسوله", 27 },
                    { 1089, new Guid("d6562394-5699-4c7b-87d0-5e954d2bb21d"), "ماسال", 27 },
                    { 1088, new Guid("28d12348-17be-4290-8240-8a019151731c"), "ليسار", 27 },
                    { 1103, new Guid("0267a22f-58da-4b24-a6ab-780134a23030"), "کياشهر", 27 },
                    { 1104, new Guid("b23f6f99-e3fb-429d-92a0-6a736c0d6614"), "گوراب زرميخ", 27 },
                    { 1105, new Guid("c194284a-0acb-41eb-af2f-7cd8a634069c"), "آجين", 28 },
                    { 1106, new Guid("0fd93c69-d801-453b-bbca-8aba69007642"), "ازندريان", 28 },
                    { 1122, new Guid("003bb3cc-1ca6-4925-9e51-6872d4d5a784"), "فيروزان", 28 },
                    { 1121, new Guid("6dad59d4-025f-4430-a99e-c7d51652297a"), "فرسفج", 28 },
                    { 1120, new Guid("ce9ba2a2-092c-48f5-9e6a-b802d328bc7a"), "فامنين", 28 },
                    { 1119, new Guid("a1768d5b-4db0-4383-a112-2fab2d438b67"), "صالح آباد", 28 },
                    { 1118, new Guid("ca784a01-f93b-43a7-8485-7a7cbc40cb8b"), "شيرين سو", 28 },
                    { 1117, new Guid("a11ef092-1f53-40e3-bbdc-3f82816a7112"), "سرکان", 28 },
                    { 1116, new Guid("a09e9b07-ad17-4068-a145-4e10880ded4b"), "سامن", 28 },
                    { 1124, new Guid("74dd661e-47b5-4376-b3f3-989ee99221d4"), "قهاوند", 28 },
                    { 1115, new Guid("a481e2e4-5427-49d7-8d04-c359015b188a"), "زنگنه", 28 },
                    { 1113, new Guid("220e47c3-1cd9-4061-ace2-358deed2ec23"), "دمق", 28 },
                    { 1112, new Guid("3a3d0279-d285-4bac-b821-a627f5f53cbe"), "جوکار", 28 },
                    { 1111, new Guid("d1ac5def-9fc8-4de8-a1d4-9da87bcf6ffd"), "جورقان", 28 },
                    { 1110, new Guid("1e6677fb-2e72-4283-a9bd-11c6ed3d6e8e"), "تويسرکان", 28 },
                    { 1109, new Guid("45d578af-5195-44c8-8c46-312d3ba96ca2"), "بهار", 28 },
                    { 1108, new Guid("afd68049-1dc9-4f14-9bb1-15c956179ec6"), "برزول", 28 },
                    { 1107, new Guid("cb33dcbe-d9ac-4b96-a6c1-e99b54688f86"), "اسد آباد", 28 },
                    { 1114, new Guid("22df2031-6f02-4128-bcc1-483e6a825de0"), "رزن", 28 },
                    { 1163, new Guid("066f0d73-9cdf-42ff-9bb2-4f62231bbfb2"), "رفسنجان", 29 },
                    { 1164, new Guid("2b94a329-1026-4479-a2a6-8b1daf2a704c"), "رودبار", 29 },
                    { 1165, new Guid("17e40566-8ae2-40a4-a888-101cea728b63"), "ريحان", 29 },
                    { 1220, new Guid("bc52204a-5d8d-4d25-9c7a-130ca68dcc88"), "ميامي", 30 },
                    { 1219, new Guid("4892a0f6-f650-45fb-9678-e86884af4b7c"), "مهدي شهر", 30 },
                    { 1218, new Guid("82f512ae-3b18-4887-a1b9-8e07bda71701"), "مجن", 30 },
                    { 1217, new Guid("b06d50cb-e8bf-4432-83f6-2816eba82dc5"), "شهميرزاد", 30 },
                    { 1216, new Guid("ffe3f108-08e4-4fc4-a045-6bfce86fcb17"), "شاهرود", 30 },
                    { 1215, new Guid("7617de3d-eef1-454f-9f70-baf4bc4ad823"), "سمنان", 30 },
                    { 1214, new Guid("d36bd138-8280-4fbe-9eb3-268095c290d2"), "سرخه", 30 },
                    { 1213, new Guid("18ab269e-cb8e-41a5-be1d-c1b1fc666a69"), "روديان", 30 },
                    { 1212, new Guid("d4b7e87c-c00d-4c11-98a2-e507c4908df5"), "ديباج", 30 },
                    { 1211, new Guid("11b3e74a-863f-4254-9c3b-fc2db812add3"), "درجزين", 30 },
                    { 1210, new Guid("19eab47f-8ec9-4bf2-afa1-b95e70ea054d"), "دامغان", 30 },
                    { 1209, new Guid("684c3a97-1d89-44d2-a9e9-00b5a823c7f5"), "بيارجمند", 30 },
                    { 1208, new Guid("edc07acb-9f3b-4822-a31d-5fd9bcb05b8a"), "بسطام", 30 },
                    { 1207, new Guid("cbfa813e-3ff5-496a-88f5-934c62a3b8a9"), "ايوانکي", 30 },
                    { 1206, new Guid("81d862fb-bc2f-4cd3-9ad2-826d8c37338b"), "اميريه", 30 },
                    { 1221, new Guid("d90513bf-a73e-4efe-b25c-b8e09bd7ee94"), "کلاته", 30 },
                    { 1222, new Guid("b6aa6645-d142-4f32-a49f-5875ef7b3a2b"), "کلاته خيج", 30 },
                    { 1223, new Guid("65c40367-d523-4132-a775-e2e2b79bc170"), "کهن آباد", 30 },
                    { 1224, new Guid("ddaba31c-2957-4d0e-b8c8-b2f4973916c7"), "گرمسار", 30 },
                    { 1240, new Guid("cd0f51d4-bbed-490d-86b1-41a1d45f351c"), "چيتاب", 31 },
                    { 1239, new Guid("7b0e20a8-d240-4541-91d1-dfe20cc7f05a"), "چرام", 31 },
                    { 1238, new Guid("cbcf873e-5e6c-41e1-82fa-cbcaab609464"), "پاتاوه", 31 },
                    { 1237, new Guid("a0863f60-fa39-4047-8c7c-ea9b4eae08e9"), "ياسوج", 31 },
                    { 1236, new Guid("4f37628c-2dde-47c7-a592-b508c214bb57"), "مارگون", 31 },
                    { 1235, new Guid("6a0505aa-dc72-42e3-8e44-3ece07186caa"), "مادوان", 31 },
                    { 1234, new Guid("dc897d45-967e-4685-9107-211610fe6e2a"), "ليکک", 31 },
                    { 1205, new Guid("e4113da8-e45c-483d-8827-dba07e4df196"), "آرادان", 30 },
                    { 1233, new Guid("cc15051b-a3a9-4e91-a33d-87f7d626f27d"), "لنده", 31 },
                    { 1231, new Guid("ddcf152b-9c42-42a3-86e1-514a8a978244"), "سي سخت", 31 },
                    { 1230, new Guid("e147174d-bd34-447a-a474-edf46fc46e92"), "سوق", 31 },
                    { 1229, new Guid("0ce408dc-4927-4521-a34f-8797e7716fe1"), "سرفارياب", 31 },
                    { 1228, new Guid("507c815d-c49a-483f-aa64-2da9f05e752b"), "ديشموک", 31 },
                    { 1227, new Guid("9b050cff-ab35-4828-92af-48b8036f5db0"), "دوگنبدان", 31 },
                    { 1226, new Guid("3dfd3ffb-ebbc-4ece-bd62-725cc5c3a5ca"), "دهدشت", 31 },
                    { 1225, new Guid("63364f34-0068-483f-be89-c953558f8a6f"), "باشت", 31 },
                    { 1232, new Guid("d700e3ed-ec0f-4616-b78f-9084e7bb828d"), "قلعه رئيسي", 31 },
                    { 1204, new Guid("e0d76400-4029-49d1-bf90-4937718857dd"), "گنبکي", 29 },
                    { 1203, new Guid("fd67d2e8-a58a-4e5c-afcb-de9a1465f356"), "گلزار", 29 },
                    { 1202, new Guid("b22f45a1-9a61-4b03-96bc-9751f2151b32"), "گلباف", 29 },
                    { 1181, new Guid("ea488545-70db-41df-8726-fa337e84bfcc"), "محي آباد", 29 },
                    { 1180, new Guid("9a309b8d-db47-4c38-9c5d-1992bd2e88e3"), "محمد آباد", 29 },
                    { 1179, new Guid("24f84787-b8d8-48d5-8f91-332e8fd5fbf8"), "ماهان", 29 },
                    { 1178, new Guid("78ebe516-e385-4213-91fa-5fd8cd758dc6"), "لاله زار", 29 },
                    { 1177, new Guid("270782e7-20a7-4928-92ec-dd677e84547c"), "قلعه گنج", 29 },
                    { 1176, new Guid("a57f26e0-244f-4b94-a404-47834392ecdb"), "فهرج", 29 },
                    { 1175, new Guid("eaef09ab-b071-42cc-a651-f0a026a6326b"), "فارياب", 29 },
                    { 1182, new Guid("2edae31b-c471-4e14-a67d-a416521bb3e7"), "مردهک", 29 },
                    { 1174, new Guid("f05646e9-1c95-40dd-b9f8-1ae43d97d476"), "عنبر آباد", 29 },
                    { 1172, new Guid("01386b86-09d8-4096-900e-314756872257"), "شهر بابک", 29 },
                    { 1171, new Guid("9b733110-5ccb-46f4-900a-29cdd221103f"), "شهداد", 29 },
                    { 1170, new Guid("ca3d7233-cfbb-4ac5-8f85-441cfda71113"), "سيرجان", 29 },
                    { 1169, new Guid("cca77cb7-56f1-4102-be64-67fbc5b066b2"), "زيد آباد", 29 },
                    { 1168, new Guid("3100b6c8-ccbe-46e6-aac6-59048f1aaa99"), "زهکلوت", 29 },
                    { 1167, new Guid("cc85549c-9257-4c2b-98ff-83d24319bc48"), "زنگي آباد", 29 },
                    { 1166, new Guid("e6a2a08b-5132-48b3-83e0-9fb9f7e21047"), "زرند", 29 },
                    { 1173, new Guid("ca1edb59-b991-4aa9-a45f-c2b8b1f8da75"), "صفائيه", 29 },
                    { 1087, new Guid("81fbfe7e-0107-4b42-bacc-fa9154502553"), "لوندويل", 27 },
                    { 1183, new Guid("9b7b5c62-eb74-44b4-92a9-c5c587068467"), "مس سرچشمه", 29 },
                    { 1185, new Guid("987e56a0-3c53-45a2-bfaa-e764122926d1"), "نجف شهر", 29 },
                    { 1201, new Guid("999220c0-edf4-4713-8c23-2ef500ae2e24"), "کيانشهر", 29 },
                    { 1200, new Guid("aff24e7e-3468-46f0-9d0d-1b517bfd876b"), "کوهبنان", 29 },
                    { 1199, new Guid("e5a49397-1f43-4db0-8964-770a41f4ccc6"), "کهنوج", 29 },
                    { 1198, new Guid("624c302d-52f4-49bf-9e34-abfa8168640b"), "کشکوئيه", 29 },
                    { 1197, new Guid("7ccd69c5-a181-4cf9-8745-0956b65fa5b5"), "کرمان", 29 },
                    { 1196, new Guid("09a06ed5-d420-430e-9fd5-4597d9121033"), "کاظم آباد", 29 },
                    { 1195, new Guid("0a06f82e-94c1-4f3d-b905-81fd5c5188a2"), "چترود", 29 },
                    { 1184, new Guid("80360e38-03c9-410b-96ff-9a529e99b2c8"), "منوجان", 29 },
                    { 1194, new Guid("c9767bf2-fe5f-4e73-9d34-f6a922833635"), "پاريز", 29 },
                    { 1192, new Guid("6ae48ec9-3f63-4337-91e3-175ec64e5de3"), "هنزا", 29 },
                    { 1191, new Guid("95bef88f-1192-4009-891e-2d7e3a2ba7e6"), "هماشهر", 29 },
                    { 1190, new Guid("1012cac5-ba63-423e-b451-4872f095af46"), "هجدک", 29 },
                    { 1189, new Guid("c4106773-8de1-40d0-8f3e-f4807d57cad2"), "نگار", 29 },
                    { 1188, new Guid("7b629594-56f9-46fd-b476-354b5ed8bd1d"), "نودژ", 29 },
                    { 1187, new Guid("4b4b1df8-6d57-4f2f-9c44-6ff3b894221f"), "نظام شهر", 29 },
                    { 1186, new Guid("2de8b6f2-1b38-4578-a889-c8460e2a0fd1"), "نرماشير", 29 },
                    { 1193, new Guid("727df1b7-3bbe-4405-be9a-036ebbb0d686"), "يزدان شهر", 29 },
                    { 1086, new Guid("d5f00fa0-c065-47c8-a953-fe0623936940"), "لولمان", 27 },
                    { 1085, new Guid("277c6b8f-03b9-41cd-b0f4-33727aa96764"), "لوشان", 27 },
                    { 1084, new Guid("c3d20717-02bf-4373-9acc-9d02c2af53d9"), "لنگرود", 27 },
                    { 984, new Guid("0748374f-f02f-48a6-9b62-e6e2c3514d14"), "بندر عباس", 25 },
                    { 983, new Guid("ed5d3fcf-1cb5-4151-a6c7-478220ed2b89"), "بندر جاسک", 25 },
                    { 982, new Guid("f9af34e4-0245-4fad-b21b-90b744a33e52"), "بستک", 25 },
                    { 981, new Guid("d2231bfa-fca2-47da-9abc-c32df11d5824"), "ابوموسي", 25 },
                    { 980, new Guid("7acf1226-d569-40c1-b961-4fa6f7f48db1"), "گيلانغرب", 24 },
                    { 979, new Guid("83486755-f2d2-4886-bdec-3462b2ac3f3f"), "گودين", 24 },
                    { 978, new Guid("59442c59-f95d-449a-b719-5080618030df"), "گهواره", 24 },
                    { 977, new Guid("03a4e139-dba3-498d-851c-1a1db2c114af"), "کوزران", 24 },
                    { 976, new Guid("5fadf07f-43e8-4185-9b08-16dcf5b4c8c8"), "کنگاور", 24 },
                    { 975, new Guid("c75a4ffa-1801-4adf-882a-63b030c38ee0"), "کرند غرب", 24 },
                    { 974, new Guid("ea7d450d-ca05-49e6-b869-67fd5c4f738f"), "کرمانشاه", 24 },
                    { 973, new Guid("cdae01e7-6235-4c52-a038-1cf2d4a731f2"), "پاوه", 24 },
                    { 972, new Guid("64bb64d8-f81a-499a-a3c3-7debeb41f594"), "هلشي", 24 },
                    { 971, new Guid("e7111f93-3452-4916-a0f2-304f82e98e0a"), "هرسين", 24 },
                    { 970, new Guid("a01aafe9-6522-4de5-a086-56dff137acfb"), "نوسود", 24 },
                    { 985, new Guid("f1f8b62e-0748-4da8-bb1e-65b1d6ee332b"), "بندر لنگه", 25 },
                    { 986, new Guid("58a73672-accc-46db-b4ac-0fb8daff01d1"), "بيکاه", 25 },
                    { 987, new Guid("203c8450-6f78-4e73-9e79-5cd8fe173666"), "تازيان پائين", 25 },
                    { 988, new Guid("e1021430-4e55-460c-9369-3bb857bae994"), "تخت", 25 },
                    { 1004, new Guid("cc4de4a4-5b69-45e7-9407-8591458d93bc"), "فين", 25 },
                    { 1003, new Guid("9c479ab8-2b20-4e51-a63c-7f81a60bfe99"), "فارغان", 25 },
                    { 1002, new Guid("2ff5b70f-58f4-4886-8963-21571886f03b"), "سيريک", 25 },
                    { 1001, new Guid("73473df0-cf6f-4d2b-9c55-a5d8e4c4ae0e"), "سوزا", 25 },
                    { 1000, new Guid("5df40f18-b27e-476c-b9ee-033924b95290"), "سندرک", 25 },
                    { 999, new Guid("bebe883b-f8c1-4798-a80a-8c11718e4476"), "سرگز", 25 },
                    { 998, new Guid("83c1735f-e7c2-41f3-b9a4-a522e2db00ca"), "سردشت", 25 },
                    { 969, new Guid("7d7cee76-8281-4d92-9975-d68078480482"), "نودشه", 24 },
                    { 997, new Guid("a09487c0-46a1-4255-b3da-713ed3cadda1"), "زيارتعلي", 25 },
                    { 995, new Guid("7c449bf3-aea7-4444-bc00-25666c01bb16"), "دهبارز", 25 },
                    { 994, new Guid("1d33d7ca-720b-4014-952c-a2ba5f191f17"), "دشتي", 25 },
                    { 993, new Guid("40ac71e3-a488-4265-b1c9-409f3576d515"), "درگهان", 25 },
                    { 992, new Guid("d67800cb-560f-4e84-9da7-c0c064e89f2b"), "خمير", 25 },
                    { 991, new Guid("6c56aaff-36fc-4502-b0ca-ff67c74986f8"), "حاجي آباد", 25 },
                    { 990, new Guid("1b7ce61f-220e-4f01-8e60-7ea5aef027a2"), "جناح", 25 },
                    { 989, new Guid("7133d6dc-7812-4b6e-81c7-0d273c1067fe"), "تيرور", 25 },
                    { 996, new Guid("1b03bc75-1739-48a0-91fe-6b468f20e849"), "رويدر", 25 },
                    { 968, new Guid("0d890930-09d0-462d-8560-6c9c8ab7ad72"), "ميان راهان", 24 },
                    { 967, new Guid("752f2236-bbfa-4e56-ac55-3cf30397164b"), "قصر شيرين", 24 },
                    { 966, new Guid("81f7a6f7-8792-4113-9df1-6108cdd82c82"), "صحنه", 24 },
                    { 945, new Guid("3aa147d2-de68-4632-a5c7-812c96b3fe20"), "کوهنجان", 23 },
                    { 944, new Guid("38182f8d-34ad-4f8e-9226-ed938ec469e9"), "کوار", 23 },
                    { 943, new Guid("154fb8a8-38df-4ea4-bf5f-c8ec78710918"), "کنار تخته", 23 },
                    { 942, new Guid("32e459a2-2c40-4e87-99d6-a28ed95fc6d1"), "کره اي", 23 },
                    { 941, new Guid("183ac50e-8a33-4f74-90e8-3fa86a47c236"), "کامفيروز", 23 },
                    { 940, new Guid("a98b3c18-8d6f-4f30-b98b-1ca605a98436"), "کازرون", 23 },
                    { 939, new Guid("0a96e7a0-ba51-465e-ae0e-0b34b119b5fd"), "کارزين", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 946, new Guid("4116bfe5-0858-49af-9489-87ad8315f0fe"), "کوپن", 23 },
                    { 938, new Guid("831cb1b1-da5f-4cb8-8d35-07b95a1cc285"), "وراوي", 23 },
                    { 936, new Guid("0553ca42-77d2-4715-9b10-767d569c7ef3"), "ني ريز", 23 },
                    { 935, new Guid("fab18daf-383d-471a-b4df-d83b08258412"), "نورآباد", 23 },
                    { 934, new Guid("d5bbba49-5b75-4f32-a8cd-18c4d3b05138"), "نودان", 23 },
                    { 933, new Guid("45f06b97-66ea-4a66-87a6-d86ec9500627"), "نوجين", 23 },
                    { 932, new Guid("72f36e44-a1f3-4899-a768-9531cd1844d4"), "نوبندگان", 23 },
                    { 931, new Guid("7fbd79f3-bd9b-44c1-b2a1-9e45c9d49b68"), "ميمند", 23 },
                    { 930, new Guid("1fd08be8-1fb3-439c-95b5-8685b10be429"), "ميانشهر", 23 },
                    { 937, new Guid("890eb4a4-96e4-4b0e-ac10-407ee4b6fb59"), "هماشهر", 23 },
                    { 1005, new Guid("770a8427-1c28-45e3-a807-7b67523d5b78"), "قشم", 25 },
                    { 947, new Guid("47f22eb4-18bc-4439-a82c-c8ddabbcc6bc"), "گراش", 23 },
                    { 949, new Guid("276e7792-65a8-4759-8675-0a2d66229bfd"), "ازگله", 24 },
                    { 965, new Guid("0ea27257-ee70-4329-a3b1-a2f3971177f5"), "شاهو", 24 },
                    { 964, new Guid("f3a1115f-d047-48d6-b4c1-bce81532149e"), "سومار", 24 },
                    { 963, new Guid("0ee93fdf-4352-48ef-8bbc-ae629474f5a1"), "سنقر", 24 },
                    { 962, new Guid("fe658f71-09b8-4d1a-8b4c-b0ee314c2034"), "سطر", 24 },
                    { 961, new Guid("e2ba7e48-af16-4972-9531-8d34289d2be3"), "سرمست", 24 },
                    { 960, new Guid("00a84dd8-cfdd-4ec0-ba3b-8de58e61de6e"), "سر پل ذهاب", 24 },
                    { 959, new Guid("3f445b02-039b-4082-9c0c-da4f38920203"), "ريجاب", 24 },
                    { 948, new Guid("f89c2192-1fa0-408f-98b8-a913d7de8b31"), "گله دار", 23 },
                    { 958, new Guid("290878a8-4874-421e-a654-86c915866abd"), "روانسر", 24 },
                    { 956, new Guid("f64df97a-b329-400f-88f5-f53309e57bb2"), "حميل", 24 },
                    { 955, new Guid("43fdfb17-b736-4e97-9603-29fbbcee0a14"), "جوانرود", 24 },
                    { 954, new Guid("b28bdd5c-3428-4f75-8b17-68a3124bf68e"), "تازه آباد", 24 },
                    { 953, new Guid("020a454d-3452-4958-979e-1f5608f71127"), "بيستون", 24 },
                    { 952, new Guid("3df53c28-c69e-4e11-85b8-7f03ee1f0a84"), "باينگان", 24 },
                    { 951, new Guid("3e3dbd8e-cafa-4469-a403-08ae7cd0efc9"), "بانوره", 24 },
                    { 950, new Guid("40a56062-936a-4a0c-befe-8344f06955ee"), "اسلام آباد غرب", 24 },
                    { 957, new Guid("0a87f099-37f4-4821-964c-511f1e9f1947"), "رباط", 24 },
                    { 614, new Guid("e5732170-a7bf-40f4-8738-760e1b3176a6"), "اردستان", 19 },
                    { 1006, new Guid("f61e8a82-b650-4161-976d-4f114eac5d83"), "قلعه قاضي", 25 },
                    { 1008, new Guid("b5778dfa-1c59-4c47-842b-309567661fdc"), "ميناب", 25 },
                    { 1063, new Guid("261b4848-93f2-4295-bef5-5721e03e4858"), "جيرنده", 27 },
                    { 1062, new Guid("5a63afd4-0a02-4d3d-b3f9-5780f4ce8f2b"), "توتکابن", 27 },
                    { 1061, new Guid("4913e063-5bbc-4e70-b27a-19e46f5bbafe"), "بندر انزلي", 27 },
                    { 1060, new Guid("b945975b-c78d-45d7-8494-273fb8c6824d"), "بره سر", 27 },
                    { 1059, new Guid("97e7a0ed-a11f-4b14-bad6-85b97b5164f8"), "بازار جمعه", 27 },
                    { 1058, new Guid("195973a7-92fc-4dd7-a9bb-0124ce90e840"), "املش", 27 },
                    { 1057, new Guid("12ca88c9-b53d-4920-9bdf-630c8c5dd5ff"), "اطاقور", 27 },
                    { 1056, new Guid("30577784-471b-4747-973a-d40abd79f80f"), "اسالم", 27 },
                    { 1055, new Guid("c91842bc-1c51-49fc-a785-7d8252205a62"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("c7e79c1e-5d07-4bcd-9c7f-02e3e751c39b"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("7dc9e86d-1868-4d74-96a8-0ca03d711cc6"), "آستارا", 27 },
                    { 1052, new Guid("50048787-4bc5-4c89-90aa-6711c693a3d8"), "کميجان", 26 },
                    { 1051, new Guid("1beec65b-d730-4e84-8a87-733e5095413a"), "کارچان", 26 },
                    { 1050, new Guid("c680090c-84ee-49e0-8c30-50561e005020"), "پرندک", 26 },
                    { 1049, new Guid("696b4d87-1d07-4240-820f-ae4a159b2b06"), "هندودر", 26 },
                    { 1064, new Guid("e4b6b63a-9ebc-43d4-a727-ff03404881ec"), "حويق", 27 },
                    { 1065, new Guid("d38220a9-816a-4803-bdde-def4d915e05b"), "خشکبيجار", 27 },
                    { 1066, new Guid("293b52a8-1f9e-42d0-8b6a-e749426bc2d5"), "خمام", 27 },
                    { 1067, new Guid("ef7354e9-c9a2-43ce-ab80-cf135de65bde"), "ديلمان", 27 },
                    { 1083, new Guid("81b7d2ce-17f9-4f42-8579-52e1af2a5c0e"), "لشت نشاء", 27 },
                    { 1082, new Guid("8fad1b9a-ad4e-4d44-8d76-37b83c86aad0"), "لاهيجان", 27 },
                    { 1081, new Guid("9d541dcd-ee43-4ece-bb7a-675c7cbaac67"), "فومن", 27 },
                    { 1080, new Guid("49c9a5ac-c31e-43f8-a3db-6b6935a573d3"), "صومعه سرا", 27 },
                    { 1079, new Guid("b69e43b3-9237-45cc-87ad-5c720fc2fb66"), "شلمان", 27 },
                    { 1078, new Guid("ee04a005-71a4-4875-987f-74676c877462"), "شفت", 27 },
                    { 1077, new Guid("1a8f4b93-7f27-49e1-80bf-d9c4866e9ac8"), "سياهکل", 27 },
                    { 1048, new Guid("e2c83c51-388e-481c-907b-98e70c3bb7b8"), "نيمور", 26 },
                    { 1076, new Guid("2ce6dd11-961f-44a2-be37-fb14cb5dc968"), "سنگر", 27 },
                    { 1074, new Guid("f8087d07-7d14-48cf-851b-26eede0ceb1a"), "رودبنه", 27 },
                    { 1073, new Guid("dd576986-5227-4322-8d81-41593a2e7435"), "رودبار", 27 },
                    { 1072, new Guid("60305a24-e44a-4c15-9c37-adc7f47941a9"), "رضوانشهر", 27 },
                    { 1071, new Guid("e0908bcb-1875-4881-9a97-d3188e3fac5a"), "رشت", 27 },
                    { 1070, new Guid("719e2a2b-0350-4599-90c6-5f2d60332f24"), "رستم آباد", 27 },
                    { 1069, new Guid("4c6f5f0e-4cf5-45b7-82b9-9dc194877c00"), "رحيم آباد", 27 },
                    { 1068, new Guid("908794ab-f622-4603-9bd4-41348296d419"), "رانکوه", 27 },
                    { 1075, new Guid("fac48eb0-86af-4a4d-bca6-4873e8118b0f"), "رودسر", 27 },
                    { 1047, new Guid("2568d176-d58b-4512-8f2d-69321bdf84fe"), "نوبران", 26 },
                    { 1046, new Guid("8ccb1388-70d1-4ab3-861e-4b038f04a308"), "نراق", 26 },
                    { 1045, new Guid("ca933378-582a-402a-8d2d-63effb753788"), "ميلاجرد", 26 },
                    { 1024, new Guid("d85e11dc-8546-4ae1-a368-81e4e99db0f0"), "تفرش", 26 },
                    { 1023, new Guid("d4bebbe1-5d49-4028-a700-9a61793a2ec7"), "اراک", 26 },
                    { 1022, new Guid("173b29a9-de20-4a65-887e-473eeaa6c788"), "آوه", 26 },
                    { 1021, new Guid("ff4f871d-8ccf-4012-9538-503e178dd54d"), "آشتيان", 26 },
                    { 1020, new Guid("4b0fbfc6-5129-4d25-97c3-0567540de760"), "آستانه", 26 },
                    { 1019, new Guid("cacc0ec0-ef91-41b8-ae25-6d5005d44bb2"), "گوهران", 25 },
                    { 1018, new Guid("6a0e5fa4-4bf4-417a-ac98-d32450de8fcb"), "گروک", 25 },
                    { 1025, new Guid("0aacc8eb-8a65-4b1b-b2bb-7daacef84f98"), "توره", 26 },
                    { 1017, new Guid("cf6cb4e9-beba-4ed4-bcef-7661ee220980"), "کيش", 25 },
                    { 1015, new Guid("399dbbf4-012d-4c75-ad51-a8ab2e0915e8"), "کوشکنار", 25 },
                    { 1014, new Guid("ded987f5-a871-467d-90f6-09349ad930c5"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("e186827b-b504-4c8f-ace1-c029e4305927"), "کنگ", 25 },
                    { 1012, new Guid("7f5b3432-9281-43d8-ba33-f527b734c395"), "چارک", 25 },
                    { 1011, new Guid("590449cb-b94b-4710-babf-6e76a0944e1d"), "پارسيان", 25 },
                    { 1010, new Guid("a3d0e471-6dd4-46a2-a722-9d4d473807de"), "هشتبندي", 25 },
                    { 1009, new Guid("7aba64f9-f2d3-4d70-8e8f-f9f8b7300e39"), "هرمز", 25 },
                    { 1016, new Guid("6e5cb974-58a9-4816-8d95-233a65ff1a73"), "کوهستک", 25 },
                    { 1007, new Guid("50ac563c-4bde-4469-8720-70f830b9e731"), "لمزان", 25 },
                    { 1026, new Guid("a6df6f2b-3ca6-4a81-a7cf-6bf4ae7798df"), "جاورسيان", 26 },
                    { 1028, new Guid("5e38051b-4fce-478f-8c3e-6159d1385ea3"), "خمين", 26 },
                    { 1044, new Guid("6fde75b8-2ef2-4acf-a182-37318ab900f6"), "محلات", 26 },
                    { 1043, new Guid("63d1c8b4-ff14-4d7c-87b9-b33cef542f42"), "مامونيه", 26 },
                    { 1042, new Guid("9b571995-1ebb-4912-bd72-2b39bad8a082"), "قورچي باشي", 26 },
                    { 1041, new Guid("019488c0-ea98-4796-809e-4870d8a46b55"), "فرمهين", 26 },
                    { 1040, new Guid("5847d53a-1131-4046-84ea-f8a7876e586a"), "غرق آباد", 26 },
                    { 1039, new Guid("4daed89c-f9f1-42cf-8187-d951ce993c08"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("2d09b9a1-d4a5-421d-bf67-4e50f24e51a0"), "شهباز", 26 },
                    { 1027, new Guid("a59f3819-eaaf-4495-96cc-a2542b23068a"), "خشکرود", 26 },
                    { 1037, new Guid("36b478e0-23a0-4a12-9419-1bc9776bf412"), "شازند", 26 },
                    { 1035, new Guid("4495870e-45d7-473b-b13b-598e49d670a0"), "ساروق", 26 },
                    { 1034, new Guid("7056d667-dd0e-4a71-bf12-0bef4a029f36"), "زاويه", 26 },
                    { 1033, new Guid("f9be7d09-764d-4596-8889-fa48029edcec"), "رازقان", 26 },
                    { 1032, new Guid("8047e590-052b-470b-99b9-f6dfc626a447"), "دليجان", 26 },
                    { 1031, new Guid("657b028f-ab16-4739-8568-1bbd8728b0ea"), "داود آباد", 26 },
                    { 1030, new Guid("080a2834-0c88-4c78-b8b9-6e899e5e5dde"), "خنداب", 26 },
                    { 1029, new Guid("a4048262-96cf-4bde-b034-021348d8bb56"), "خنجين", 26 },
                    { 1036, new Guid("b98e92b8-80c7-4ba8-973a-0f5976780d81"), "ساوه", 26 },
                    { 613, new Guid("4b5d810a-65e7-47b8-9fa3-c4fc806d6c39"), "ابوزيد آباد", 19 },
                    { 612, new Guid("23c9084b-411e-443a-908a-9e9d1b3a4ff5"), "ابريشم", 19 },
                    { 611, new Guid("b394dabc-4b68-45ea-95b9-fa4ec4e99b90"), "آران و بيدگل", 19 },
                    { 207, new Guid("52eb2429-c18c-47af-8956-7d4e3b1ec283"), "سلامي", 8 },
                    { 206, new Guid("44814e6a-12fc-4fee-972b-a3194fa0b468"), "سفيد سنگ", 8 },
                    { 205, new Guid("6f33a5b8-4dc7-4c6f-aec5-8075ed01c8d1"), "سرخس", 8 },
                    { 204, new Guid("41f3bee9-ff0c-4b29-9c02-3b1cefdb3c81"), "سبزوار", 8 },
                    { 203, new Guid("a5272b6a-e18b-4221-bd61-9cfbaef3fb8a"), "ريوش", 8 },
                    { 202, new Guid("fffe3149-af88-422c-9cdc-0c5aa200f947"), "روداب", 8 },
                    { 201, new Guid("b85e5e4b-d8c3-4891-bf53-dfa53d857151"), "رضويه", 8 },
                    { 200, new Guid("23206944-bda6-492a-a548-3a57dd93ee37"), "رشتخوار", 8 },
                    { 199, new Guid("e753526e-9ba4-42b6-8b13-dd87d24c6643"), "رباط سنگ", 8 },
                    { 198, new Guid("296a4f70-699d-4099-b956-36d176f6afe9"), "دولت آباد", 8 },
                    { 197, new Guid("672d014e-2ea4-44fc-91fe-c4baed72e94b"), "درگز", 8 },
                    { 196, new Guid("3873d952-061f-470d-bd23-926f72365329"), "درود", 8 },
                    { 195, new Guid("15c73fbd-3f2c-44a1-90cc-3433b66c5186"), "داورزن", 8 },
                    { 194, new Guid("6554c7d3-6afe-4716-a22f-d6a1b37924bc"), "خواف", 8 },
                    { 193, new Guid("7887367c-acce-4c70-8e73-d8aa58b527bc"), "خليل آباد", 8 },
                    { 208, new Guid("b5ee3791-0289-433f-af06-5d407d94c772"), "سلطان آباد", 8 },
                    { 192, new Guid("1a6c35ca-79be-4133-b1a5-c25785d4f6eb"), "خرو", 8 },
                    { 209, new Guid("57a16fa0-3d72-4305-ac6a-33646236a5c9"), "سنگان", 8 },
                    { 211, new Guid("fcf83199-5661-4646-9a11-1aceba50ee6f"), "شانديز", 8 },
                    { 226, new Guid("57762be0-6c8e-4cbe-aad0-605e331d2d77"), "لطف آباد", 8 },
                    { 225, new Guid("ec20172d-2a0d-4113-a1fa-05a521cacb24"), "قوچان", 8 },
                    { 224, new Guid("c2ac21fb-e6d3-429e-b703-c2c77681cde6"), "قلندر آباد", 8 },
                    { 223, new Guid("bc5434ba-b9fb-4ebe-ae4c-cd630ef1163d"), "قدمگاه", 8 },
                    { 222, new Guid("77db9803-b40f-4dc9-a796-4e7a3bb8ceba"), "قاسم آباد", 8 },
                    { 221, new Guid("b9d99386-a0c3-4679-82e8-59f55c66574f"), "فيض آباد", 8 },
                    { 220, new Guid("0a3f63b2-1762-41cf-8763-b8a7656b7cc2"), "فيروزه", 8 },
                    { 219, new Guid("729cda2b-2373-461d-b80f-c21ec73875a7"), "فريمان", 8 },
                    { 218, new Guid("497780c9-ad64-4108-b0ac-59ef858c9a8a"), "فرهاد گرد", 8 },
                    { 217, new Guid("def801a0-decc-4949-8997-17704204ae58"), "عشق آباد", 8 },
                    { 216, new Guid("af5761dc-99ad-486c-a21a-1374fbea7700"), "طرقبه", 8 },
                    { 215, new Guid("50920b58-0e07-4213-8e2f-4f6c4f3b35ff"), "صالح آباد", 8 },
                    { 214, new Guid("da8eaf71-c33a-4794-b097-1565fcb5d41e"), "شهرآباد", 8 },
                    { 213, new Guid("63269995-2d02-46a8-9c7a-cad9738ce827"), "شهر زو", 8 },
                    { 212, new Guid("3f38635e-4006-4a95-bf10-ab6b1819ed6f"), "ششتمد", 8 },
                    { 210, new Guid("3b78335e-cf53-4828-9c52-56d7d674dac3"), "شادمهر", 8 },
                    { 227, new Guid("3f42675b-70c5-4fcd-b710-7accd02416f7"), "مزدآوند", 8 },
                    { 191, new Guid("70d5a784-daab-4057-bc2e-4fe3a411bf45"), "جنگل", 8 },
                    { 189, new Guid("58e23ba0-dbaa-4eea-86e4-3273f9e1b8cb"), "تربت حيدريه", 8 },
                    { 169, new Guid("47a8eaa6-bf9c-49de-8fce-ac1aed14dce8"), "نازک عليا", 7 },
                    { 168, new Guid("96ce0a6c-70b5-4a01-be06-ea3d02753349"), "ميرآباد", 7 },
                    { 167, new Guid("2ca84276-a250-458c-a8db-ac2365271a4f"), "مياندوآب", 7 },
                    { 166, new Guid("2437943f-0eae-4dff-a06e-3da5ab4ee7d4"), "مهاباد", 7 },
                    { 165, new Guid("1d1b9bb6-3682-4d37-9518-01f6fda087e9"), "مرگنلر", 7 },
                    { 164, new Guid("5776b67d-328d-4ff1-9cc3-e85c46499e77"), "محمود آباد", 7 },
                    { 163, new Guid("8015fc8e-44a7-41f4-8de6-3287cf0823d8"), "محمد يار", 7 },
                    { 162, new Guid("9749335e-647f-4645-9b13-d0f2990c6b67"), "ماکو", 7 },
                    { 161, new Guid("41e6a5a4-8171-4210-93ee-3df55beef075"), "قوشچي", 7 },
                    { 160, new Guid("b0ad3543-1085-49e9-b360-3de879478749"), "قطور", 7 },
                    { 159, new Guid("92b99344-68a5-46a6-8fa6-d21a24d2136f"), "قره ضياء الدين", 7 },
                    { 158, new Guid("10d5f93e-23bf-4bb9-b4fe-685daa045639"), "فيرورق", 7 },
                    { 157, new Guid("d59ad229-b2c3-4dd2-a26f-575cf3d7b0ff"), "شوط", 7 },
                    { 156, new Guid("bafde993-b0c6-4127-888d-fe89b78222fa"), "شاهين دژ", 7 },
                    { 155, new Guid("4ae7fc6e-f864-485a-8d15-c21906667dfa"), "سيه چشمه", 7 },
                    { 170, new Guid("486c6530-8285-499f-9328-8e6e47dd4b03"), "نالوس", 7 },
                    { 190, new Guid("d42dbb33-a675-4bb3-b4d7-5ba827e7ae06"), "جغتاي", 8 },
                    { 171, new Guid("87ba1b76-051d-44b1-890a-2a0c94b13830"), "نقده", 7 },
                    { 173, new Guid("f96fea4f-4b19-4325-a1d8-546b4d7bb2c0"), "پلدشت", 7 },
                    { 188, new Guid("f7d5a879-d48a-4c42-932f-3217be670b05"), "تربت جام", 8 },
                    { 187, new Guid("11a16a3d-6d05-484a-9485-84f7c3360def"), "تايباد", 8 },
                    { 186, new Guid("b95b48cd-a67a-465f-8a0d-8d0f8d3dea7c"), "بيدخت", 8 },
                    { 185, new Guid("1087c010-14f2-4c81-91f2-5be555c63854"), "بردسکن", 8 },
                    { 184, new Guid("d2478c24-18d9-49b9-840a-1fff0a467dd7"), "بجستان", 8 },
                    { 183, new Guid("96e658e9-a69b-41ea-b9f8-2efb66ec310f"), "بايک", 8 },
                    { 182, new Guid("6355cf5d-2dd0-4e8c-8bf2-2bfc125136e5"), "بار", 8 },
                    { 181, new Guid("0774c59f-498e-44ec-8860-87cc2ba3850e"), "باخرز", 8 },
                    { 180, new Guid("3073c2e3-d579-4571-b81a-3feac14ed673"), "باجگيران", 8 },
                    { 179, new Guid("7051bd36-d050-4617-a983-956d24f7f199"), "انابد", 8 },
                    { 178, new Guid("dd4e115a-273f-4ece-a93a-e201e9b85556"), "احمدآباد صولت", 8 },
                    { 177, new Guid("63c2897c-5774-42f3-8a22-bd1d61c93814"), "گردکشانه", 7 },
                    { 176, new Guid("446ef3dc-816b-4510-a00e-63a37ac76d5d"), "کشاورز", 7 },
                    { 175, new Guid("dd7059d2-577d-4684-84d8-71bd4c9e199e"), "چهار برج", 7 },
                    { 174, new Guid("8eb91f41-d5be-4678-8611-37b76665f771"), "پيرانشهر", 7 },
                    { 172, new Guid("d777537b-f578-4414-8b78-d2c8291558b1"), "نوشين", 7 },
                    { 228, new Guid("3cc38487-94dd-4432-b981-2c3a72adc4a2"), "مشهد", 8 },
                    { 229, new Guid("b14e8808-a25f-4f1c-a30b-c1cc3d8d370e"), "مشهدريزه", 8 },
                    { 230, new Guid("c0213662-d439-4eba-bb56-9c1654cd858e"), "ملک آباد", 8 },
                    { 284, new Guid("dc7a5b97-ba42-4fca-9830-7f575aba5c13"), "کنارک", 9 },
                    { 283, new Guid("55378768-a2a7-4891-b33f-1780b7177bc8"), "چاه بهار", 9 },
                    { 282, new Guid("f28fbc0c-79f2-475a-b970-42a2cca79b34"), "پيشين", 9 },
                    { 281, new Guid("28a49d9a-ad94-49be-a506-e0013caf9137"), "هيدوچ", 9 },
                    { 280, new Guid("1bea7c91-5446-42ae-8631-654b9bb85845"), "نگور", 9 },
                    { 279, new Guid("0f27ef27-9087-4c48-bce3-6c54300a37b0"), "نيک شهر", 9 },
                    { 278, new Guid("e7734bf9-9150-496a-864a-7d7dc7a33956"), "نوک آباد", 9 },
                    { 277, new Guid("c3cd4962-a2bd-4179-ba68-1ea88da61549"), "نصرت آباد", 9 },
                    { 276, new Guid("8180c548-571e-4494-9d84-ed2594aa2320"), "ميرجاوه", 9 },
                    { 275, new Guid("9b67a1ab-2e19-43cd-adf5-29fcf7ceb496"), "مهرستان", 9 },
                    { 274, new Guid("648f3022-26bb-4fcb-b672-2ce861445136"), "محمدي", 9 },
                    { 273, new Guid("b85a29ae-92cb-48b5-a4bf-a3763558d9f9"), "محمدان", 9 },
                    { 272, new Guid("aeca941e-d4fb-4073-9d55-ea6f72ac59ee"), "محمد آباد", 9 },
                    { 271, new Guid("8fafc65b-fcfa-4a3f-a791-9be3c0ba781e"), "قصر قند", 9 },
                    { 270, new Guid("c0b8ce8d-9c78-4cf7-9c51-0f183bc7b34c"), "فنوج", 9 },
                    { 285, new Guid("7c82818e-2cee-41e7-862d-a59784eff9d2"), "گشت", 9 },
                    { 269, new Guid("af3bcc40-b8bf-4e7a-8a52-cd3dd14ed1ca"), "علي اکبر", 9 },
                    { 286, new Guid("1622edea-b597-4e31-a5a2-51b01a7dde64"), "گلمورتي", 9 },
                    { 288, new Guid("fe0f0869-c162-4ed4-bbe1-2c177c918307"), "آيسک", 10 },
                    { 303, new Guid("4ce66214-f8f5-4ff3-ba6b-a20ad1bac129"), "شوسف", 10 },
                    { 302, new Guid("dec39f40-cdee-40a7-8cb2-fc49dd516f88"), "سه قلعه", 10 },
                    { 301, new Guid("fc7ff0fa-029c-4180-99f4-8552332ddbcd"), "سربيشه", 10 },
                    { 300, new Guid("9dc9381a-8bc1-4bc3-9185-eeb7a5400fc4"), "سرايان", 10 },
                    { 299, new Guid("ec31cbdc-e1f8-4f5e-b8df-5aa9bf36e876"), "زهان", 10 },
                    { 298, new Guid("900533fe-4dd4-45b6-8ace-16e7e73477e4"), "ديهوک", 10 },
                    { 1241, new Guid("46945f15-aade-4140-9706-4a3cc44a11de"), "گراب سفلي", 31 },
                    { 296, new Guid("4c346a01-11df-4d47-90f5-a40880e2fb9f"), "خضري دشت بياض", 10 },
                    { 295, new Guid("f031b97f-7aa4-475d-8fbe-7da9fcdd550b"), "حاجي آباد", 10 },
                    { 294, new Guid("4b7fcaed-f128-4f18-b779-f1a99ecfc701"), "بيرجند", 10 },
                    { 293, new Guid("ffcd10a1-49c7-4cec-bffc-f2468d2e453f"), "بشرويه", 10 },
                    { 292, new Guid("12a9dad6-d920-4cad-a5c3-a245ecb6a661"), "اسلاميه", 10 },
                    { 291, new Guid("3c935cca-19fd-4037-a6da-88cf0660cb35"), "اسفدن", 10 },
                    { 290, new Guid("e4dbe2b3-bbba-49ac-ae6d-3ff1c949966e"), "اسديه", 10 },
                    { 289, new Guid("e5bd9a07-7d56-4bc2-bdfb-15f61fdfa1e4"), "ارسک", 10 },
                    { 287, new Guid("63df6aa6-265f-4e0e-89b3-8674d5a5ce33"), "آرين شهر", 10 },
                    { 268, new Guid("fe80cabc-1577-490b-996a-91c208cbcb30"), "سيرکان", 9 },
                    { 267, new Guid("3ea841b0-7796-4787-9e2b-dffc5939878f"), "سوران", 9 },
                    { 266, new Guid("ebd350eb-91c9-4b64-a837-e14fcad312a6"), "سرباز", 9 },
                    { 245, new Guid("95d36c3f-4086-4a7a-888c-94eb591e5eae"), "کدکن", 8 },
                    { 244, new Guid("37dc5bd6-0c38-48ea-8026-28e1867dc0d5"), "کاشمر", 8 },
                    { 243, new Guid("981ad4ef-12d1-4074-9b60-d23a4a5490d0"), "کاريز", 8 },
                    { 242, new Guid("782f5490-cc91-460e-8db7-747eff54522f"), "کاخک", 8 },
                    { 241, new Guid("aa455126-92a2-4a6b-b625-1b543a811440"), "چکنه", 8 },
                    { 240, new Guid("29d4d66c-b12b-4848-9401-e8421124a50c"), "چناران", 8 },
                    { 239, new Guid("47b00937-62cb-45af-bd84-239a6434a813"), "چاپشلو", 8 },
                    { 238, new Guid("6264a4d6-2e14-435e-9458-8403a5ecf906"), "يونسي", 8 },
                    { 237, new Guid("4214ddcc-a46f-4267-afdf-a5fccea14896"), "همت آباد", 8 },
                    { 236, new Guid("cb913bef-e86a-4508-b9dc-9476a8e836c3"), "نيل شهر", 8 },
                    { 235, new Guid("b714850a-8469-4f34-bbb6-7412df263e31"), "نيشابور", 8 },
                    { 234, new Guid("a0565e4f-2ffe-4b64-b166-084d21653d6d"), "نوخندان", 8 },
                    { 233, new Guid("181ea322-7005-47d9-8f31-1f136dbfd8d3"), "نقاب", 8 },
                    { 232, new Guid("22ee3079-2633-4930-9dae-88e063445abe"), "نصرآباد", 8 },
                    { 231, new Guid("a122ea24-ffb5-4b2e-949c-593a3720b449"), "نشتيفان", 8 },
                    { 246, new Guid("fa730afb-6aa1-4057-9484-357eb4053394"), "کلات", 8 },
                    { 247, new Guid("764c16ed-cb97-46a4-94ba-851e64bc31b2"), "کندر", 8 },
                    { 248, new Guid("db24a043-46e4-48cf-9f15-13cbc83a7553"), "گلمکان", 8 },
                    { 249, new Guid("5199e258-70df-410a-b75d-197b456edcfe"), "گناباد", 8 },
                    { 265, new Guid("9de52d85-dc09-4e41-8ac1-e585081510be"), "سراوان", 9 },
                    { 264, new Guid("b6121648-4ec1-4e42-a364-e0e5f0137fdb"), "زهک", 9 },
                    { 263, new Guid("b993356f-ee32-4c8b-8259-2c094e874a01"), "زرآباد", 9 },
                    { 262, new Guid("33e52cce-d6c5-40f3-8bad-32cce779a477"), "زاهدان", 9 },
                    { 261, new Guid("88ca82b2-f7b0-4674-8f1a-30f0ec5c8138"), "زابل", 9 },
                    { 260, new Guid("d9e3f4e1-ca09-415f-ad45-f01fd38616f9"), "راسک", 9 },
                    { 259, new Guid("9b07e031-59f5-483c-b049-9a705d825597"), "دوست محمد", 9 },
                    { 154, new Guid("c16e069f-565c-4618-a485-82b0a991e7dc"), "سيمينه", 7 },
                    { 258, new Guid("5e4c9ca0-7530-4c6e-ad96-c4bf3f88cabf"), "خاش", 9 },
                    { 256, new Guid("6ec80c7c-3eb0-41be-ba39-1e6a885ae163"), "بنجار", 9 },
                    { 255, new Guid("ba25e52e-0fdd-4c25-8f7b-348ec75c6537"), "بنت", 9 },
                    { 254, new Guid("27c6c343-7ad2-4a15-b0c5-92a8ee18e0c8"), "بمپور", 9 },
                    { 253, new Guid("24a75457-cc4d-4331-aae6-babe64dac19c"), "بزمان", 9 },
                    { 252, new Guid("cc62f9fb-6d0e-42eb-9f11-79514e3372f9"), "ايرانشهر", 9 },
                    { 251, new Guid("063518c4-d4b8-446d-af6d-9271ba805773"), "اسپکه", 9 },
                    { 250, new Guid("74023ecb-3416-4296-9376-22838b139d8b"), "اديمي", 9 },
                    { 257, new Guid("bdf17184-1e27-4a90-a1e4-6862ea8a68fb"), "جالق", 9 },
                    { 153, new Guid("196f4f70-7721-46ac-9ccc-4ec071ceba43"), "سيلوانه", 7 },
                    { 152, new Guid("23c2d1f3-e1c0-4cbf-a54f-ceb06c7bcc70"), "سلماس", 7 },
                    { 151, new Guid("68f37817-c8bf-4693-94c4-375949a61b9f"), "سرو", 7 },
                    { 54, new Guid("2d527db6-26bf-47dc-a1ee-6e62a6d9494a"), "پردنجان", 2 },
                    { 53, new Guid("a03e98e8-dd1a-4c24-8191-ecc250ef201c"), "وردنجان", 2 },
                    { 52, new Guid("2a31e417-f4e7-4771-a135-4b5db59210da"), "هفشجان", 2 },
                    { 51, new Guid("85256f6d-78e0-4a9a-b654-6914e7d4d568"), "هاروني", 2 },
                    { 50, new Guid("28afbd6a-0170-4f2e-bfef-cf73ebfd33c6"), "نقنه", 2 },
                    { 49, new Guid("85ebdcde-0cef-456a-b25b-5488439df216"), "نافچ", 2 },
                    { 48, new Guid("d499af62-7fee-40bc-80d0-22e3872f4131"), "ناغان", 2 },
                    { 47, new Guid("362f8f34-f476-4121-92cf-d9028cb936bf"), "منج", 2 },
                    { 46, new Guid("241a3c45-1368-4e84-bb4c-d1835e35347d"), "مال خليفه", 2 },
                    { 45, new Guid("d3259b3d-47e5-45ee-b1f4-9c1fbe111e78"), "لردگان", 2 },
                    { 44, new Guid("9333c68d-889d-42d5-a604-e3e99c47ca98"), "فرخ شهر", 2 },
                    { 43, new Guid("9e78c88f-a125-4e3e-a4a2-6b03320c6713"), "فرادنبه", 2 },
                    { 42, new Guid("6edd6bdf-44aa-4f85-95c7-de082fc68d91"), "فارسان", 2 },
                    { 41, new Guid("a7ee6b66-0ad3-4258-86a9-c1c9775bb8a2"), "طاقانک", 2 },
                    { 40, new Guid("51c969ac-1440-4a30-8bd8-4088df2d83aa"), "صمصامي", 2 },
                    { 55, new Guid("c622bc68-edac-4019-8cfe-617ffea05d90"), "چليچه", 2 },
                    { 39, new Guid("9e187ebc-6056-4616-8f7f-19faa172d347"), "شهرکرد", 2 },
                    { 56, new Guid("a46b0ab9-4ced-4536-bb18-b7f6df4ef3fd"), "چلگرد", 2 },
                    { 58, new Guid("cca19619-c873-4364-bd2a-1861753b9bc3"), "کيان", 2 },
                    { 73, new Guid("f6202e69-3047-4f65-a070-4eef60c77c46"), "سنخواست", 3 },
                    { 72, new Guid("90a36b8a-eeac-44e3-8792-f93c7b69bd47"), "زيارت", 3 },
                    { 71, new Guid("ad632454-f405-4e60-b73e-523f9a3a9075"), "راز", 3 },
                    { 70, new Guid("07e61f40-5b77-4008-bd03-c24f765682f2"), "درق", 3 },
                    { 69, new Guid("76cb45db-a4c0-4a44-9026-3c3b3a6a8a75"), "حصارگرمخان", 3 },
                    { 68, new Guid("d2a13088-e899-4388-a5d3-5389f417e317"), "جاجرم", 3 },
                    { 67, new Guid("3906e59f-23fb-4078-9d15-7b9d0eb3ef43"), "تيتکانلو", 3 },
                    { 66, new Guid("091386d5-9789-45e1-8988-3916c87b6c03"), "بجنورد", 3 },
                    { 65, new Guid("ef1f148b-9988-4265-8d86-70c9d74d02ef"), "ايور", 3 },
                    { 64, new Guid("36d33484-ae95-4539-99cc-9d6027e2ed43"), "اسفراين", 3 },
                    { 63, new Guid("fa01c669-1bb4-4f47-8607-b07f74da27ca"), "آوا", 3 },
                    { 62, new Guid("dc0504d7-dc4e-4bda-a6c1-5f58e58d73b6"), "آشخانه", 3 },
                    { 61, new Guid("fd2c2c5e-ad2b-46b4-a184-56e18b3ac627"), "گوجان", 2 },
                    { 60, new Guid("5f55cc84-9613-4444-b90a-d5583d6f9a75"), "گهرو", 2 },
                    { 59, new Guid("5fe6e51e-cdea-454e-925a-bcd91a4c46ba"), "گندمان", 2 },
                    { 57, new Guid("67adafa9-5327-40fb-9341-0a7bce3c4914"), "کاج", 2 },
                    { 38, new Guid("18290b5b-8a3f-4b09-b948-e0aca9c829da"), "شلمزار", 2 },
                    { 37, new Guid("2ce5353c-71b7-439f-8995-57b566672db4"), "سورشجان", 2 },
                    { 36, new Guid("24ea2d49-bc7b-4885-a5bc-ba0db44c7095"), "سودجان", 2 },
                    { 15, new Guid("451bc821-31f1-485d-86b0-858eb18927f9"), "مهردشت", 1 },
                    { 14, new Guid("881cf2b8-aea5-49ee-a17e-f9e9e555f896"), "مروست", 1 },
                    { 13, new Guid("0177d95b-a4e4-4b16-932e-02aecb05a3a9"), "عقدا", 1 },
                    { 12, new Guid("a2f72c2a-0131-4adc-a3d2-15629c02721f"), "شاهديه", 1 },
                    { 11, new Guid("490ecdcd-6808-483d-abf5-8f41bc1ce72d"), "زارچ", 1 },
                    { 10, new Guid("84203759-cec4-4cac-9fec-e179f5df3923"), "خضر آباد", 1 },
                    { 9, new Guid("8cbbdea1-c9f1-4d23-ab75-7ca320fa5f79"), "حميديا", 1 },
                    { 8, new Guid("5e34715f-ca69-4ad4-8115-3afb17cd2db1"), "تفت", 1 },
                    { 7, new Guid("b6b1d3a9-31af-4551-8389-627532c75e3e"), "بهاباد", 1 },
                    { 6, new Guid("848981e0-eaed-4a53-93e0-8e825f8ea698"), "بفروئيه", 1 },
                    { 5, new Guid("cf667765-b2df-43cc-b4cc-ec346988b5cf"), "بافق", 1 },
                    { 4, new Guid("a1f9d13e-9e47-498f-a2ac-d9aa9c6c2549"), "اشکذر", 1 },
                    { 3, new Guid("2bbfa6d5-c33a-4b3c-9944-1417566827f0"), "اردکان", 1 },
                    { 2, new Guid("ef38d404-22a8-4c3b-a743-73de1701eee1"), "احمد آباد", 1 },
                    { 1, new Guid("3e24bbdd-60cc-49c1-b928-e68a272d00f2"), "ابرکوه", 1 },
                    { 16, new Guid("a26d4e87-a947-4c8c-829e-ee303b77d3b1"), "مهريز", 1 },
                    { 17, new Guid("1a99a2cf-d9a0-4979-ae1a-fbed24354746"), "ميبد", 1 },
                    { 18, new Guid("87693037-8149-40f3-ad84-a505ed9cf968"), "ندوشن", 1 },
                    { 19, new Guid("c600f661-fa2b-440e-a285-394049cd4ca1"), "نير", 1 },
                    { 35, new Guid("6f99ad41-8b45-4c7c-8f8f-41e2ab84f445"), "سفيد دشت", 2 },
                    { 34, new Guid("8a8db7fb-2163-4b3a-b629-5ab2d6581727"), "سردشت لردگان", 2 },
                    { 33, new Guid("18f8406f-2ff4-4a78-9366-403296d77d32"), "سرخون", 2 },
                    { 32, new Guid("68053e1c-f310-4120-83dd-d930233c9bb1"), "سامان", 2 },
                    { 31, new Guid("e918c336-758c-441d-afed-34c0c58a2491"), "دشتک", 2 },
                    { 30, new Guid("3286caac-a37c-40f8-8683-3795ae45ecc3"), "دستناء", 2 },
                    { 29, new Guid("ae6ef16a-8c71-40e3-b45e-435807a9993d"), "جونقان", 2 },
                    { 74, new Guid("1aa73fbe-1d9f-43e3-a1c5-b45312f66edf"), "شوقان", 3 },
                    { 28, new Guid("5cb580af-20ab-4844-8f16-a742649c792a"), "بن", 2 },
                    { 26, new Guid("b9431356-7e2e-4505-ab11-d368219d3da7"), "بروجن", 2 },
                    { 25, new Guid("c01b915c-aafd-4776-8fcf-775c32e08775"), "بازفت", 2 },
                    { 24, new Guid("5618adad-f0ae-4cea-b18f-2bffa039a753"), "باباحيدر", 2 },
                    { 23, new Guid("a6e7ab55-12a8-4e5a-8f9b-09d765d89624"), "اردل", 2 },
                    { 22, new Guid("f7dac55e-3d1a-4e06-88fe-e7d1071a1bde"), "آلوني", 2 },
                    { 21, new Guid("e4f39311-1b2a-40a4-807a-f96f8ecd894a"), "يزد", 1 },
                    { 20, new Guid("7473d16b-8275-4447-bc8c-85d12657173e"), "هرات", 1 },
                    { 27, new Guid("d3b764c7-1b01-4ec0-b81d-d335ef4b0fed"), "بلداجي", 2 },
                    { 304, new Guid("1b65d503-0662-4f7c-ba1a-f4b0737e1c43"), "طبس", 10 },
                    { 75, new Guid("8436d768-60b8-4a8d-b474-5ae20c948f2c"), "شيروان", 3 },
                    { 77, new Guid("cca05b02-a5ca-4512-8341-d3b6e4d92fa2"), "فاروج", 3 },
                    { 131, new Guid("cd4c626a-1cf3-4ec3-88f8-33ed5b8e69be"), "پيرتاج", 6 },
                    { 130, new Guid("bb20de22-a145-4406-9cc5-39f74be93246"), "ياسوکند", 6 },
                    { 129, new Guid("d9639d91-b5fb-48d1-be62-3c8af434f1f0"), "موچش", 6 },
                    { 128, new Guid("7433750a-99ca-4bf9-a820-57e23424b529"), "مريوان", 6 },
                    { 127, new Guid("33d960e7-d386-4a97-a722-2f26a171f757"), "قروه", 6 },
                    { 126, new Guid("415a31f5-ded2-4f19-a28c-e3a867735355"), "صاحب", 6 },
                    { 125, new Guid("8387d4c3-fa01-4343-89c1-7f882d89ff75"), "شويشه", 6 },
                    { 124, new Guid("69b9000f-3296-46c2-abb4-985d8e992a87"), "سنندج", 6 },
                    { 123, new Guid("267e57f2-0219-461f-86b9-fb3fdbbd45bf"), "سقز", 6 },
                    { 122, new Guid("bf4eb453-686a-40e3-a1ff-ab2527e4b81d"), "سريش آباد", 6 },
                    { 121, new Guid("73cccddd-b531-4f41-b68e-8859d546c3a1"), "سرو آباد", 6 },
                    { 120, new Guid("a2ff1f7f-cbc2-4bc2-8562-d90337f09e50"), "زرينه", 6 },
                    { 119, new Guid("be01b952-13ba-4774-9788-c37f1360015b"), "ديواندره", 6 },
                    { 118, new Guid("1f541ed8-330b-4f3c-8ac4-974f7b9fbd59"), "دهگلان", 6 },
                    { 117, new Guid("d345eb18-a0e1-4a0d-8a99-8db34f711cbf"), "دلبران", 6 },
                    { 132, new Guid("37e9a32f-c3cf-45b9-ba66-ca9f5f62671d"), "چناره", 6 },
                    { 116, new Guid("7e2f2119-9206-4049-985e-ca8f44dc422e"), "دزج", 6 },
                    { 133, new Guid("309095fb-4ecd-4b07-b239-89056b90d08c"), "کامياران", 6 },
                    { 135, new Guid("fdedc6eb-2c5a-4cdb-a62f-88242557202b"), "کاني سور", 6 },
                    { 150, new Guid("a8c271ac-983d-4773-b116-a573d034dcb2"), "سردشت", 7 },
                    { 149, new Guid("2fe73e78-85db-48b0-af96-8b413689be53"), "زرآباد", 7 },
                    { 148, new Guid("4c9cd740-51fa-4ca7-8dce-96e715539db4"), "ربط", 7 },
                    { 147, new Guid("b3c10ddb-c366-4764-becd-e82a8209a868"), "ديزج ديز", 7 },
                    { 146, new Guid("4e011317-f197-4364-9c5d-6adab78fd523"), "خوي", 7 },
                    { 145, new Guid("3bafc20a-3190-443c-bf84-a04cc9887b3c"), "خليفان", 7 },
                    { 144, new Guid("abf3efc0-c94b-45d6-878d-b2b8260e47fa"), "تکاب", 7 },
                    { 143, new Guid("f1785350-4198-4f17-8978-a7babcc16427"), "تازه شهر", 7 },
                    { 142, new Guid("edfb1f29-8360-4252-bb6e-bf20312fdf23"), "بوکان", 7 },
                    { 141, new Guid("b14c1bcf-6641-4ff8-b843-23cce2b63546"), "بازرگان", 7 },
                    { 140, new Guid("7208c312-fd5f-4ec0-9005-a74fbb080f2c"), "باروق", 7 },
                    { 139, new Guid("faf4571d-a146-49f2-891f-481f47c0ffe8"), "ايواوغلي", 7 },
                    { 138, new Guid("96b5faab-f43f-450c-9caa-e170863c1d7c"), "اشنويه", 7 },
                    { 137, new Guid("63b113b5-3a6d-4370-90dd-26856035a6a4"), "اروميه", 7 },
                    { 136, new Guid("cb1e9847-d42c-4e34-9755-05f89d520029"), "آواجيق", 7 },
                    { 134, new Guid("f6f03516-4808-4af0-bb1c-6cf5e877ea8f"), "کاني دينار", 6 },
                    { 115, new Guid("f8018ab7-fc7c-495b-a73d-f796f55c028e"), "توپ آغاج", 6 },
                    { 114, new Guid("a4e06dc2-9a12-455d-82b5-19fb2950580d"), "بيجار", 6 },
                    { 113, new Guid("ea91d4f2-25c6-4aca-88cd-a269aff22e4e"), "بوئين سفلي", 6 },
                    { 92, new Guid("b96ddc43-fa00-4f90-ba95-f612c2d4b3ce"), "مشکين دشت", 4 },
                    { 91, new Guid("a234fcb4-27e8-4ec6-bbef-b9cb8534b2d1"), "محمد شهر", 4 },
                    { 90, new Guid("feb15d97-7c14-49f1-bb81-41e56c5a0c83"), "ماهدشت", 4 },
                    { 89, new Guid("aeb8d177-6359-4155-9bfe-6fc792f322ea"), "فرديس", 4 },
                    { 88, new Guid("d5cff889-8b66-4a32-b99d-2e6eeb4bb662"), "طالقان", 4 },
                    { 87, new Guid("ba8b560b-0094-45a8-bdab-0f3bbe731efc"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("cdedbe21-0f81-4f1e-9b7b-4b6e66d391bd"), "تنکمان", 4 },
                    { 85, new Guid("aa4a4573-ca9b-464c-acd1-1cd859dee27a"), "اشتهارد", 4 },
                    { 84, new Guid("7a01d910-3315-4a60-b4d6-029853cfd78a"), "آسارا", 4 },
                    { 83, new Guid("a07bba00-7d85-4194-bfc9-b8d383d59362"), "گرمه", 3 },
                    { 82, new Guid("b8c41304-a4e6-45eb-b7e7-59276591fec9"), "چناران شهر", 3 },
                    { 81, new Guid("ec08da02-b613-41db-92cc-31ca33840d8d"), "پيش قلعه", 3 },
                    { 80, new Guid("f1bd5f38-4e65-4bc3-91cf-ad205c05de86"), "لوجلي", 3 },
                    { 79, new Guid("81ba4d36-836e-4d8d-836d-7776ed9116a0"), "قوشخانه", 3 },
                    { 78, new Guid("1da7fb59-81df-4577-aee6-58e836c11c7a"), "قاضي", 3 },
                    { 93, new Guid("b21ab6e8-6b3c-4543-b016-f44ee1b6fab2"), "نظر آباد", 4 },
                    { 94, new Guid("0ee15942-514a-459c-ab2e-32d7f6ea1505"), "هشتگرد", 4 },
                    { 95, new Guid("d7dd9116-59ff-4bf8-ad61-5ee578f86990"), "چهارباغ", 4 },
                    { 96, new Guid("594276bd-2a48-47cd-98ab-845c68a1237c"), "کرج", 4 },
                    { 112, new Guid("af223d15-7727-4173-a36d-952b977a673b"), "بلبان آباد", 6 },
                    { 111, new Guid("07a645fd-b417-4899-8a41-3a1ef5fbe82d"), "برده رشه", 6 },
                    { 110, new Guid("80263d0b-a91f-4680-8f48-29c2d40df3ac"), "بانه", 6 },
                    { 109, new Guid("c79ba5d2-3ec6-47b8-8172-b486bf976a62"), "بابارشاني", 6 },
                    { 108, new Guid("8f865e9e-1518-41e2-9cc5-e2c6062720a8"), "اورامان تخت", 6 },
                    { 107, new Guid("9a03186e-c146-4435-a226-5acb8197768c"), "آرمرده", 6 },
                    { 106, new Guid("e11b5ee3-8922-462b-87fe-0663b9838d00"), "کهک", 5 },
                    { 76, new Guid("c385954c-16cf-4e55-b4b6-c7b312b7a329"), "صفي آباد", 3 },
                    { 105, new Guid("c1680902-5b15-43f3-ac23-d2a97529e6b3"), "قنوات", 5 },
                    { 103, new Guid("4ea76e39-0c55-49fa-b878-98d35189125d"), "سلفچگان", 5 },
                    { 102, new Guid("c10bcdb9-2e2d-4657-ace2-85f56d6c8f23"), "دستجرد", 5 },
                    { 101, new Guid("d83630fd-cdc4-4d8e-a6b6-36c752f82ae1"), "جعفريه", 5 },
                    { 100, new Guid("24e31a56-4cba-4699-99ab-bda2ba93f159"), "گلسار", 4 },
                    { 99, new Guid("f946c3d2-975b-4fa7-af6f-a0813fbc3d7c"), "گرمدره", 4 },
                    { 98, new Guid("ddcb51e9-9bb6-4acd-80d6-cc3d443169fe"), "کوهسار", 4 },
                    { 97, new Guid("1e643e53-3cee-44f0-a49d-80266b1fadb5"), "کمال شهر", 4 },
                    { 104, new Guid("31f3ba18-1301-4d21-9a44-18f119e31458"), "قم", 5 },
                    { 305, new Guid("220180e8-fbe1-487a-b914-6a9d29f57175"), "طبس مسينا", 10 },
                    { 297, new Guid("81f0627b-6f7d-426e-ad65-c8c0d7409d06"), "خوسف", 10 },
                    { 307, new Guid("880c0201-7ae7-4b9f-a525-347c7b818fd7"), "فردوس", 10 },
                    { 514, new Guid("95c45a57-1044-4cf2-a781-8a34a226e14d"), "نشتارود", 15 },
                    { 513, new Guid("7429765d-1171-425f-81f7-eb1f66f52060"), "مرزيکلا", 15 },
                    { 512, new Guid("464ccb09-9464-4f9b-a34f-1d6ed03d29e0"), "مرزن آباد", 15 },
                    { 511, new Guid("677c82f4-31f5-447c-8462-c248f1127e59"), "محمود آباد", 15 },
                    { 510, new Guid("2e698932-1418-42f6-a06a-86a117ad4bee"), "قائم شهر", 15 },
                    { 509, new Guid("7f67c59d-23c6-4d80-8e9c-e9377d9e123b"), "فريم", 15 },
                    { 508, new Guid("f595b3b1-427b-46cc-a95b-0fec7a3c2536"), "فريدونکنار", 15 },
                    { 507, new Guid("fd5f3126-fe26-45de-bab5-2eb34811f061"), "عباس آباد", 15 },
                    { 506, new Guid("54211a6d-e795-48d0-a4ac-a7bcd36afb84"), "شيرگاه", 15 },
                    { 505, new Guid("ffb74c85-1a84-4c4a-a625-079ed6aabdf5"), "شيرود", 15 },
                    { 504, new Guid("53569e81-c775-4f22-9ce5-d31746c3cce5"), "سورک", 15 },
                    { 503, new Guid("0dc79b7b-ebba-4681-a6bb-465b27ef1df0"), "سلمان شهر", 15 },
                    { 502, new Guid("b7c8530e-edf4-4043-9dad-6eec109f62e9"), "سرخرود", 15 },
                    { 501, new Guid("9bebf71c-1587-4418-a159-87b023a4ba72"), "ساري", 15 },
                    { 500, new Guid("d6893886-23c8-46f9-b30f-9bef0e8b182a"), "زيرآب", 15 },
                    { 515, new Guid("c03b32f4-324c-44fd-868d-b4e24c52b573"), "نور", 15 },
                    { 499, new Guid("c1ba99e4-9f89-44c6-8038-6d3ebb1a7cc7"), "زرگر محله", 15 },
                    { 516, new Guid("7f1d7317-9f23-4ec1-a708-a01bc970e314"), "نوشهر", 15 },
                    { 518, new Guid("aa8a9dd7-848a-4acc-8042-92b25e542723"), "هادي شهر", 15 },
                    { 533, new Guid("1179e09d-f048-4408-a3bf-7ba0e44e44a5"), "گزنک", 15 },
                    { 532, new Guid("0401bdfc-e587-401a-ae64-a373c8611087"), "گتاب", 15 },
                    { 531, new Guid("2a57559e-a4ee-4e71-a351-e3bd5fee915f"), "کياکلا", 15 },
                    { 530, new Guid("0d6ff159-eeee-48bd-9e6a-b1a9f1c6c0e9"), "کياسر", 15 },
                    { 529, new Guid("86b53009-e85e-4f01-aa58-c499cbe49774"), "کوهي خيل", 15 },
                    { 528, new Guid("61596a97-3630-43f6-baaa-c3b0dcb76279"), "کلاردشت", 15 },
                    { 527, new Guid("e973b5aa-0615-4005-9897-fd2e8d9d40d9"), "کلارآباد", 15 },
                    { 526, new Guid("3fa69876-aab3-443a-9f7d-98f3b75b39dd"), "کجور", 15 },
                    { 525, new Guid("a56b22aa-d4e1-420f-9aed-2e8e2cbf666b"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("defb425d-15c0-4bf4-bca0-c64ad8b4498a"), "چمستان", 15 },
                    { 523, new Guid("d928299e-76d6-4997-a91d-cfad00a88690"), "چالوس", 15 },
                    { 522, new Guid("9f4db337-65f7-4fb1-8006-eff6a2a9ca85"), "پول", 15 },
                    { 521, new Guid("e7bd96ac-4c67-49e6-86da-a53525b2ac83"), "پل سفيد", 15 },
                    { 520, new Guid("8499bb67-9cc0-4782-b513-9a64664a5e8f"), "پايين هولار", 15 },
                    { 519, new Guid("c305d938-440d-4106-bad9-bb8765a167f1"), "هچيرود", 15 },
                    { 517, new Guid("479e7ce8-7075-4f21-bd80-8db162a2589f"), "نکا", 15 },
                    { 534, new Guid("85042403-a6ec-45a3-9a0c-d7b2558fdc33"), "گلوگاه", 15 },
                    { 498, new Guid("73d9f4f6-0432-446c-8223-4af7ea7cd115"), "رينه", 15 },
                    { 496, new Guid("61c675ea-3c44-44bc-aa59-27823f1d68cc"), "رستمکلا", 15 },
                    { 476, new Guid("88e6d415-ce1f-4a38-8afc-2d45b888cf5d"), "گميش تپه", 14 },
                    { 475, new Guid("37d9a36a-ca99-4e4e-a6a1-4553b8ff0b3e"), "گرگان", 14 },
                    { 474, new Guid("dfd6f7d6-ec4d-4587-9bd7-42a7e48f2043"), "گاليکش", 14 },
                    { 473, new Guid("00319559-bc53-4707-88fa-2059c967606a"), "کلاله", 14 },
                    { 472, new Guid("f1322158-3398-45bb-b314-28e080c47bd3"), "کرد کوي", 14 },
                    { 471, new Guid("418fd1f1-dda8-45b9-b44d-ae138e2056f7"), "نگين شهر", 14 },
                    { 470, new Guid("b7417652-97c2-49ff-8787-c92f1f2bd8fa"), "نوکنده", 14 },
                    { 469, new Guid("48344ae2-201b-4588-a78f-c8b2d4c7aaa4"), "نوده خاندوز", 14 },
                    { 306, new Guid("f079d471-5be6-42ba-9f28-2b6a9b615b1d"), "عشق آباد", 10 },
                    { 467, new Guid("1c502823-d38e-4367-a0a2-f9c3ad1d8743"), "مزرعه", 14 },
                    { 466, new Guid("3e213c06-332a-4c07-b8c8-d01a9e3ae292"), "مراوه تپه", 14 },
                    { 465, new Guid("52f6376d-cb37-499c-9fb3-5687d19d46a0"), "فراغي", 14 },
                    { 464, new Guid("7fb6aa66-bffc-4c15-b5ca-6f20ab993a77"), "فاضل آباد", 14 },
                    { 463, new Guid("141620f3-2dc3-4e43-8b64-3cb65cd905ca"), "علي آباد", 14 },
                    { 462, new Guid("947dc4a5-4156-459f-b9e2-2402e18b914c"), "سيمين شهر", 14 },
                    { 477, new Guid("4ff43c36-0c35-4761-a903-10b0e2177e9c"), "گنبدکاووس", 14 },
                    { 497, new Guid("f665c83a-1d2d-4efc-8a9e-1a29f1b99674"), "رويان", 15 },
                    { 478, new Guid("77411bd4-7b29-48e5-a585-8974a89c3e28"), "آلاشت", 15 },
                    { 480, new Guid("10148fc2-8a3a-481f-8b5d-47e9b8c3098a"), "ارطه", 15 },
                    { 495, new Guid("4a23a65d-dd93-44db-a547-11d586aa6fe1"), "رامسر", 15 },
                    { 494, new Guid("7601f13a-c481-4263-9f77-4570b1c72003"), "دابودشت", 15 },
                    { 493, new Guid("0ce48f9d-3b0b-412a-a5f5-9d0ecd63055d"), "خوش رودپي", 15 },
                    { 492, new Guid("84c872a1-7cae-4c93-8f42-3106241dba0e"), "خليل شهر", 15 },
                    { 491, new Guid("9e534a08-215e-4a51-8aa9-8d58c4cf0c31"), "خرم آباد", 15 },
                    { 490, new Guid("679682c2-1df1-48dc-ae47-bdbf9c4fc4a7"), "جويبار", 15 },
                    { 489, new Guid("08a36f8a-d972-40aa-be75-aac61f9c8c08"), "تنکابن", 15 },
                    { 488, new Guid("3e27a7e6-f11c-476d-af49-bd0ab3f1764c"), "بهنمير", 15 },
                    { 487, new Guid("e44ebddf-9ba2-4648-b261-8035b1bfe081"), "بهشهر", 15 },
                    { 486, new Guid("be8ee55a-43c3-410d-8189-94776ea41737"), "بلده", 15 },
                    { 485, new Guid("b602c47b-322c-4b0a-956d-e0ef833589d4"), "بابلسر", 15 },
                    { 484, new Guid("f5176372-9e88-4d74-baff-057428348949"), "بابل", 15 },
                    { 483, new Guid("80b6c14c-70be-423e-9909-fab92484d23e"), "ايزد شهر", 15 },
                    { 482, new Guid("90de52a5-9ae2-41ef-9d3a-f46b5c0c0bc6"), "امير کلا", 15 },
                    { 481, new Guid("bfa57ad7-176b-4278-bb5b-9c1f8fa12e91"), "امامزاده عبدالله", 15 },
                    { 479, new Guid("d0664746-6889-4a46-a8e3-3130b8717a61"), "آمل", 15 },
                    { 535, new Guid("8b788116-9998-4de9-bc49-5f1ef383db21"), "آبيک", 16 },
                    { 536, new Guid("31ddcaf0-c239-4086-8058-50ed1e37b56a"), "آبگرم", 16 },
                    { 537, new Guid("e8d7e1cb-ca60-46be-9f71-d8ec0068da71"), "آوج", 16 },
                    { 591, new Guid("ed07151b-e4f3-4f97-8173-5ab8f6e8928a"), "تازه کند انگوت", 18 },
                    { 590, new Guid("8d2ae911-2bc1-4cc2-aae1-a63d1d511cdf"), "تازه کند", 18 },
                    { 589, new Guid("c23379bb-be51-46bf-9a61-2ff43b1b6769"), "بيله سوار", 18 },
                    { 588, new Guid("63491bfd-4399-4de3-a075-1a92ad92cf5a"), "اصلاندوز", 18 },
                    { 587, new Guid("83f7122f-1de4-4ced-95d9-a8f6a8d32828"), "اسلام آباد", 18 },
                    { 586, new Guid("da624108-cffa-4992-8c63-72ea65f4da16"), "اردبيل", 18 },
                    { 585, new Guid("1ca1cce7-a564-44bb-a309-ce9e8767b7e9"), "آبي بيگلو", 18 },
                    { 584, new Guid("0953dbf9-fe2b-4e87-b527-4ba4ac866d1f"), "گراب", 17 },
                    { 583, new Guid("e7820730-475e-410a-8271-b8fec7906316"), "کوهناني", 17 },
                    { 582, new Guid("d22c4ee3-6895-40b2-934f-43ee1954caae"), "کوهدشت", 17 },
                    { 581, new Guid("8fd094f1-d437-4b2e-af1e-7de32c33dd8b"), "چقابل", 17 },
                    { 580, new Guid("55d101ba-d375-4bbb-8045-b0957004868b"), "چالانچولان", 17 },
                    { 579, new Guid("73ee9dc0-152d-4a74-9110-d111db5aec3f"), "پلدختر", 17 },
                    { 578, new Guid("d60bdcb5-d8e1-48db-bd38-14460c51a61c"), "ويسيان", 17 },
                    { 577, new Guid("db5a6f9a-26c8-4ba1-8d83-c6a0d316fc5e"), "هفت چشمه", 17 },
                    { 592, new Guid("66474577-751f-4066-8d49-bdefc6bfdda9"), "جعفر آباد", 18 },
                    { 576, new Guid("b889edf0-fc2d-4bec-85e1-09cb62fbb4ba"), "نورآباد", 17 },
                    { 593, new Guid("468ab763-cb58-40ce-84f4-c356b947ded5"), "خلخال", 18 },
                    { 595, new Guid("ac40bcc8-b6cc-454f-aeab-c267cc12c253"), "سرعين", 18 },
                    { 610, new Guid("e1f6b06c-158e-468d-b3a0-f3ef1cf6a9b4"), "گيوي", 18 },
                    { 609, new Guid("47b382d7-4136-4071-ade3-4b3925929296"), "گرمي", 18 },
                    { 608, new Guid("489057e7-0929-4c97-8b37-62cf874a41b6"), "کورائيم", 18 },
                    { 607, new Guid("6f486fa8-90e7-4ced-9a70-2ed84567690c"), "کلور", 18 },
                    { 606, new Guid("990a48d7-dc65-413a-be78-d2950e570e08"), "پارس آباد", 18 },
                    { 605, new Guid("b6139d3a-e695-4c82-a4da-bc6538c21747"), "هير", 18 },
                    { 604, new Guid("8cbab781-0db9-4158-b5eb-807c103ffecd"), "هشتجين", 18 },
                    { 603, new Guid("66ef25fc-d433-4baf-a6ad-9f2252f60834"), "نير", 18 },
                    { 602, new Guid("7398ef3b-bff9-4a7c-a313-9c4fbf5bc19e"), "نمين", 18 },
                    { 601, new Guid("6242c829-d7de-4eee-9b21-be6696be35d1"), "مشگين شهر", 18 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 600, new Guid("8ae25363-20fd-4a68-9ced-b014c043fceb"), "مرادلو", 18 },
                    { 599, new Guid("c29e7eb8-0982-4968-b01a-49a5f2612fbd"), "لاهرود", 18 },
                    { 598, new Guid("2f48c502-d758-4540-9d95-7a1efb939876"), "قصابه", 18 },
                    { 597, new Guid("4527170a-ea61-4bbe-9aa9-ccbe7d7276c7"), "فخرآباد", 18 },
                    { 596, new Guid("6e20d9e7-9d5d-4800-b763-20b71dc66c2a"), "عنبران", 18 },
                    { 594, new Guid("3cf8a4e9-38db-42c8-a5c2-e158256b979d"), "رضي", 18 },
                    { 575, new Guid("27aa5a21-6cb9-49ac-89a0-b85c7de7b912"), "مومن آباد", 17 },
                    { 574, new Guid("783b45cc-ba85-4031-92ce-9520c3a8a9f1"), "معمولان", 17 },
                    { 573, new Guid("3864039f-a6de-412e-a613-f787f2c60bc3"), "فيروزآباد", 17 },
                    { 552, new Guid("5cace646-6205-45fa-810c-ed06d4148205"), "شريفيه", 16 },
                    { 551, new Guid("07a22261-292d-48d4-98ff-89241b5b26b0"), "شال", 16 },
                    { 550, new Guid("80a7390c-2078-4c82-ac9c-b79ca7765070"), "سگز آباد", 16 },
                    { 549, new Guid("ff03d07d-ccfe-4dd8-9dd1-f48ccc96b245"), "سيردان", 16 },
                    { 548, new Guid("cafbac33-68fc-4f1b-84d7-f9d21e84698d"), "رازميان", 16 },
                    { 547, new Guid("e656a927-47f5-4527-8d81-6a903dc9eab1"), "دانسفهان", 16 },
                    { 546, new Guid("93213ba8-1964-4422-9211-58aea677df80"), "خرمدشت", 16 },
                    { 545, new Guid("99785951-c3bf-4e2e-a74c-d482fb599b86"), "خاکعلي", 16 },
                    { 544, new Guid("73897885-c222-4897-bbdf-24bcf69a7fb0"), "تاکستان", 16 },
                    { 543, new Guid("866f41b6-f31e-4a7f-b214-160e5dd498e0"), "بيدستان", 16 },
                    { 542, new Guid("9a6cfe15-af77-408c-aa81-2067bf37ef81"), "بوئين زهرا", 16 },
                    { 541, new Guid("ade4495b-73a0-4323-b6dc-be8c934ac4f9"), "الوند", 16 },
                    { 540, new Guid("f6c10903-1353-40c1-be0b-6f866259b136"), "اقباليه", 16 },
                    { 539, new Guid("2b644f9d-2f7d-4319-b2d3-6ea507e6b888"), "اسفرورين", 16 },
                    { 538, new Guid("98365751-6a0a-4e02-9630-81cb2da23d04"), "ارداق", 16 },
                    { 553, new Guid("5ace649e-f29c-405b-a633-78ccbf2a815b"), "ضياء آباد", 16 },
                    { 554, new Guid("ea7a55fd-6c01-4279-8256-63f881bd4636"), "قزوين", 16 },
                    { 555, new Guid("7e7151b6-49a4-47aa-82c1-d30f752a1c49"), "محمديه", 16 },
                    { 556, new Guid("a4c5a8f0-96da-48e4-831c-0becf7340f18"), "محمود آباد نمونه", 16 },
                    { 572, new Guid("865ae4c6-052d-45b2-8d22-b331d0c6b9d7"), "شول آباد", 17 },
                    { 571, new Guid("51ea9ea0-8844-4a2b-acce-e28fdcf656ff"), "سپيد دشت", 17 },
                    { 570, new Guid("731ad972-432a-4216-a365-acb135bbbc09"), "سراب دوره", 17 },
                    { 569, new Guid("257d28d9-f672-4aaf-ab5b-41a250993535"), "زاغه", 17 },
                    { 568, new Guid("1b20c03b-9287-4bd8-be0b-8ddf3affc6a9"), "دورود", 17 },
                    { 567, new Guid("7eb63327-1eb1-4cfd-b889-e4b1104a65e5"), "درب گنبد", 17 },
                    { 566, new Guid("4a9af9c4-cb9b-4508-87ae-4dff64a12e05"), "خرم آباد", 17 },
                    { 461, new Guid("375cb8c4-b816-48d2-8e72-5b31db9620c0"), "سنگدوين", 14 },
                    { 565, new Guid("264f2068-1ff0-4506-a5d1-163fb271c36e"), "بيرانشهر", 17 },
                    { 563, new Guid("5fa40bce-3690-4826-b89d-75694add4232"), "اليگودرز", 17 },
                    { 562, new Guid("9ff6b197-64ae-4cb4-becd-39dbc1b37dab"), "الشتر", 17 },
                    { 561, new Guid("f1e29d63-900f-4635-b70c-1ac625998137"), "اشترينان", 17 },
                    { 560, new Guid("2f793828-e536-4db9-ac2b-13092704c1be"), "ازنا", 17 },
                    { 559, new Guid("b2b0734b-56c5-4308-ad12-38134999d6cd"), "کوهين", 16 },
                    { 558, new Guid("28aaed24-25bb-4b0f-a239-61275c555b4c"), "نرجه", 16 },
                    { 557, new Guid("b498d7d1-7fff-4851-a5a1-04fefe0117c1"), "معلم کلايه", 16 },
                    { 564, new Guid("4d914bce-cd3e-4067-abeb-1d32439e0301"), "بروجرد", 17 },
                    { 460, new Guid("fdfcd930-d720-42ff-8cdc-a4273aab7079"), "سرخنکلاته", 14 },
                    { 468, new Guid("c494afbf-5eb4-4a59-ad41-80092a461d84"), "مينودشت", 14 },
                    { 458, new Guid("26d10747-9326-40ca-9392-c1502caebed6"), "دلند", 14 },
                    { 361, new Guid("95be4061-8cab-4073-83e6-57d385774a53"), "شوش", 11 },
                    { 360, new Guid("2971607f-5072-4314-9f07-1e7f36419a8f"), "شهر امام", 11 },
                    { 359, new Guid("fe8a5df9-f317-4827-ab5a-54282c43ced7"), "شمس آباد", 11 },
                    { 358, new Guid("c02893c2-35a6-4d04-8723-fd87bc3709c5"), "شرافت", 11 },
                    { 357, new Guid("5472775c-aa6a-4d45-bfd9-aaca0c8ce873"), "شاوور", 11 },
                    { 356, new Guid("b92b444d-cf30-483b-b7da-3cba665d4080"), "شادگان", 11 },
                    { 355, new Guid("894f920f-868f-482a-8c71-faca374fae79"), "سياه منصور", 11 },
                    { 354, new Guid("2614d296-26a5-4d3d-864a-5ee8f2c12092"), "سوسنگرد", 11 },
                    { 353, new Guid("78fc0283-25ce-4261-b302-70e593a1b130"), "سماله", 11 },
                    { 352, new Guid("6359ddb0-d7ef-47bc-8dd0-09f191160e53"), "سردشت", 11 },
                    { 351, new Guid("84d5af01-a91a-4080-976b-ccf4a5a18402"), "سرداران", 11 },
                    { 350, new Guid("051c00f9-68ca-413b-bc4d-bb533ffac0c9"), "سالند", 11 },
                    { 349, new Guid("25fccedc-951b-45ed-a541-76e7c7d4fb55"), "زهره", 11 },
                    { 348, new Guid("ab64feb2-0ccf-4d11-ae71-7fb7231589f7"), "رفيع", 11 },
                    { 347, new Guid("537d95b2-ed28-44ec-9ed1-b88c41be06cc"), "رامهرمز", 11 },
                    { 362, new Guid("c5ade5b3-fde2-424a-ae9f-22a9acde08c6"), "شوشتر", 11 },
                    { 346, new Guid("bdd2a23f-c457-4792-893b-ba78544b7c57"), "رامشير", 11 },
                    { 363, new Guid("b5a7fd1f-fbe3-4e07-99a0-274eea8ce2fe"), "شيبان", 11 },
                    { 365, new Guid("bb8656ee-1bc0-4504-858d-e652f398243a"), "صفي آباد", 11 },
                    { 380, new Guid("78e97d62-62f6-4483-9771-760dce0937a3"), "هنديجان", 11 },
                    { 379, new Guid("5898a374-f38e-42ac-bd6c-ce6fe819d149"), "هفتگل", 11 },
                    { 378, new Guid("66e3c01e-a658-432e-a248-2d2fb9894932"), "مينوشهر", 11 },
                    { 377, new Guid("85fbc19a-f033-4102-aa09-c3373f5c8242"), "ميداود", 11 },
                    { 376, new Guid("3f0e4f37-0183-4761-9652-cf56972bf33c"), "ميانرود", 11 },
                    { 375, new Guid("3bf4ae38-d7b6-47f7-b468-6f25268d6338"), "منصوريه", 11 },
                    { 459, new Guid("3cd98bf8-71dc-4f71-8d82-b16b83233d5b"), "راميان", 14 },
                    { 373, new Guid("ad1f17cb-05cd-4f33-b0f0-77e687c1566e"), "مقاومت", 11 },
                    { 372, new Guid("dcc52029-f318-409c-aea1-18839366160c"), "مشراگه", 11 },
                    { 371, new Guid("7e402c86-a767-4e4a-9b2c-2ff303685019"), "مسجد سليمان", 11 },
                    { 370, new Guid("1a4d09df-199b-4674-a427-7d4b1e043e87"), "لالي", 11 },
                    { 369, new Guid("4c5947b2-e30e-4cb3-aee5-5c2eb216a61f"), "قلعه خواجه", 11 },
                    { 368, new Guid("59a8ea74-5b85-4e0f-9bcc-a109f4ed7df2"), "قلعه تل", 11 },
                    { 367, new Guid("cc307c53-534c-4e7a-9d42-c25cf5ce13b5"), "فتح المبين", 11 },
                    { 366, new Guid("99aacc3c-56e0-42d4-b3f0-e28b4ac36510"), "صيدون", 11 },
                    { 364, new Guid("04e78ddd-a16b-4b67-9ec8-e32f183b3652"), "صالح شهر", 11 },
                    { 345, new Guid("38d0db20-af81-4e9b-b389-9895f782d09c"), "دهدز", 11 },
                    { 344, new Guid("2168c831-345f-404c-af78-207858a7eb2f"), "دزفول", 11 },
                    { 343, new Guid("7e58e614-ffe7-42b0-9818-b769ac6b68ae"), "دارخوين", 11 },
                    { 322, new Guid("20cc4391-68d9-4920-9a5f-bd51c63450ae"), "الوان", 11 },
                    { 321, new Guid("6f051109-c7cf-4b72-a850-611779cfe159"), "الهايي", 11 },
                    { 320, new Guid("2a3105aa-3529-42b9-bf51-0a89e9e16316"), "اروند کنار", 11 },
                    { 319, new Guid("4432322e-a2e0-48db-ad77-8eb7fd283fb3"), "ابوحميظه", 11 },
                    { 318, new Guid("26b304ca-094c-47b4-adf0-4a29def660e2"), "آغاجاري", 11 },
                    { 317, new Guid("d49bc4c8-a1e6-49e3-be13-14e39beccb00"), "آزادي", 11 },
                    { 316, new Guid("40c76099-9efd-4e2e-b621-adfbc3b880fb"), "آبژدان", 11 },
                    { 315, new Guid("ef82aa49-de35-4daa-9372-9a355bf953f2"), "آبادان", 11 },
                    { 314, new Guid("8e709a73-f0ee-4d91-bf0c-3a011e82021a"), "گزيک", 10 },
                    { 313, new Guid("8507cde6-2517-4c3b-8df8-3a4af68ca220"), "نيمبلوک", 10 },
                    { 312, new Guid("e60c913e-74f6-4188-b04b-c96be95877e9"), "نهبندان", 10 },
                    { 311, new Guid("55c7d34e-912f-4a93-8e01-47ef7930f38f"), "مود", 10 },
                    { 310, new Guid("fa582dab-a7e2-4b8a-a4a2-354b8381a38d"), "محمدشهر", 10 },
                    { 309, new Guid("8b5ff325-05ed-4ef0-87ab-1177ca8dc493"), "قهستان", 10 },
                    { 308, new Guid("93191818-1694-48e2-adbb-6ec1f3c214c0"), "قائن", 10 },
                    { 323, new Guid("5d54199b-4477-447c-a193-3b1041cfb0dd"), "اميديه", 11 },
                    { 324, new Guid("c69b14e9-9ce1-428b-8fc0-a6081fd88b30"), "انديمشک", 11 },
                    { 325, new Guid("f32df064-2981-482f-a2cc-cee283722eea"), "اهواز", 11 },
                    { 326, new Guid("46d8de2c-d366-4b05-9cec-2756dd7910a1"), "ايذه", 11 },
                    { 342, new Guid("c1b3d64b-8684-447d-a0f7-32497a8ed74a"), "خنافره", 11 },
                    { 341, new Guid("b0601715-cbbc-4f76-b251-abebd286d44f"), "خرمشهر", 11 },
                    { 340, new Guid("b521697e-3eaf-4872-bb56-30cd00bca5c4"), "حميديه", 11 },
                    { 339, new Guid("01c23db8-ae89-418b-a983-c84dcabbbf90"), "حمزه", 11 },
                    { 338, new Guid("7818672b-68d6-4fc3-b33a-1971aa96fb8b"), "حسينيه", 11 },
                    { 337, new Guid("900be69d-2871-47d0-b863-2e9ebc34d40a"), "حر", 11 },
                    { 336, new Guid("59bec877-cb29-43fe-8f77-2c178b09df5f"), "جنت مکان", 11 },
                    { 381, new Guid("c02d5985-5f1c-4cb6-9c3b-df581aa54505"), "هويزه", 11 },
                    { 335, new Guid("5b25f41d-c676-41f1-987f-801b08c59dbf"), "جايزان", 11 },
                    { 333, new Guid("0b9832bc-3d7b-4f17-8f6b-f11375894953"), "ترکالکي", 11 },
                    { 332, new Guid("787eb4ae-5770-4c9d-a7e7-2ee80d0dc245"), "بيدروبه", 11 },
                    { 331, new Guid("aa78f13e-43c6-4b6c-a14a-28def8c743aa"), "بهبهان", 11 },
                    { 330, new Guid("d4653917-4f24-4b52-93fd-3a635dae2bb0"), "بندر ماهشهر", 11 },
                    { 329, new Guid("585087a3-53cd-45a4-adee-3fc221d9cf53"), "بندر امام خميني", 11 },
                    { 328, new Guid("6a0f9e7f-0cde-4201-b88c-ea2e53314d2e"), "بستان", 11 },
                    { 327, new Guid("9e38ef0b-a49d-4a70-bcb3-5c46d219c727"), "باغ ملک", 11 },
                    { 334, new Guid("23cde7dc-2571-4703-8b60-8b29f10c4dac"), "تشان", 11 },
                    { 382, new Guid("e026595c-34b3-4022-b046-afc82481e7f4"), "ويس", 11 },
                    { 374, new Guid("066e585b-e373-4b65-a936-0ca390e2a75c"), "ملاثاني", 11 },
                    { 384, new Guid("89ef9b06-4e52-470a-9de4-79a6d0dc61d9"), "چم گلک", 11 },
                    { 438, new Guid("51090812-7f6d-47d9-8176-54961cb3301a"), "سلطانيه", 13 },
                    { 437, new Guid("ef9920f3-6830-4de6-8cd0-45839cfa7498"), "سجاس", 13 },
                    { 436, new Guid("438d54d6-21bb-4a2c-b788-8d8847fc5abb"), "زنجان", 13 },
                    { 435, new Guid("c4f61e03-cc87-4578-b882-397b906eadcc"), "زرين رود", 13 },
                    { 434, new Guid("0958e79d-f19f-4e11-9f51-1c82ac575a3a"), "زرين آباد", 13 },
                    { 433, new Guid("bee8d602-1212-4176-a397-6602a804693b"), "دندي", 13 },
                    { 432, new Guid("63a1557e-b654-4f4f-8abc-9d4f921dccf9"), "خرمدره", 13 },
                    { 431, new Guid("023a8742-8f0c-4be4-8a29-59dcf8c2b7ea"), "حلب", 13 },
                    { 383, new Guid("a09235ab-42e1-4d2a-aad5-9e2b27f72f60"), "چغاميش", 11 },
                    { 429, new Guid("0488171e-6585-4f46-b45f-a4761b343cf1"), "ابهر", 13 },
                    { 428, new Guid("42b48c9b-c7a8-4875-9fda-12c05c4c44be"), "آب بر", 13 },
                    { 427, new Guid("c48fbb2a-b15f-40cf-a92f-d064a8297d28"), "کلمه", 12 },
                    { 426, new Guid("9bf047a6-c5d6-43fa-abbb-de26799619ca"), "کاکي", 12 },
                    { 425, new Guid("2c841d4e-5d19-4487-8a71-dc0cb8888eb2"), "چغادک", 12 },
                    { 424, new Guid("e83f7da0-ebb5-4f95-b527-06d82c41f444"), "وحدتيه", 12 },
                    { 439, new Guid("f405997d-a29d-42fc-9dbc-b9d0fd3afb7e"), "سهرورد", 13 },
                    { 423, new Guid("d9a95ea3-cd19-4e03-ad38-7f242e113d23"), "نخل تقي", 12 },
                    { 440, new Guid("84130c18-c835-4558-90ea-5cad6c47dfd6"), "صائين قلعه", 13 },
                    { 442, new Guid("d9f9485f-4f4a-4bf7-9c36-deb8424bbb56"), "ماه نشان", 13 },
                    { 457, new Guid("215b7200-729e-483b-8e9b-b3b3311b0080"), "خان ببين", 14 },
                    { 456, new Guid("23209fd5-8724-4098-a120-728647286a88"), "جلين", 14 },
                    { 455, new Guid("755f7ecf-bb98-4d0f-a7fb-c081c78804a6"), "تاتار عليا", 14 },
                    { 454, new Guid("f4cdf263-8345-4024-9a4a-12bddd735026"), "بندر گز", 14 },
                    { 453, new Guid("2108754a-319d-4e57-9612-f73251e30705"), "بندر ترکمن", 14 },
                    { 452, new Guid("ae9676c5-bc35-4c35-8354-5be4ca54f16f"), "اينچه برون", 14 },
                    { 451, new Guid("e2413dc8-d16d-4008-aad1-8b31ac867946"), "انبار آلوم", 14 },
                    { 450, new Guid("7722d34b-8c89-4e90-a40c-40a1c3a35af5"), "آق قلا", 14 },
                    { 449, new Guid("a377e406-0a89-4608-b2e1-1d39b7af1cc4"), "آزاد شهر", 14 },
                    { 448, new Guid("e49f4447-0a1c-48fe-95e3-ecd0faf41b00"), "گرماب", 13 },
                    { 447, new Guid("eaf26ba6-c68f-428c-843b-6ebfdf27e6fe"), "کرسف", 13 },
                    { 446, new Guid("d5fd755a-b538-4fa9-999c-6d96e555f990"), "چورزق", 13 },
                    { 445, new Guid("eccbe69b-f5e9-43ce-b328-962a97f50bfb"), "هيدج", 13 },
                    { 444, new Guid("71b2348a-5a33-4acc-a337-b1eecc3412f4"), "نيک پي", 13 },
                    { 443, new Guid("65f10fd7-2173-4837-8149-173ad811bfde"), "نوربهار", 13 },
                    { 441, new Guid("37b4dae7-8817-4cf9-8486-ca6b1440fe50"), "قيدار", 13 },
                    { 422, new Guid("35e96ad0-9c75-4308-a741-fbd99e45ac2f"), "عسلويه", 12 },
                    { 430, new Guid("826d7e5e-cda6-463b-abcc-192728e37bb7"), "ارمخانخانه", 13 },
                    { 420, new Guid("2ac63ff4-38c3-4ce6-a24b-24ca89d64b88"), "شبانکاره", 12 },
                    { 399, new Guid("8ccac477-cd82-4c44-a0b6-c6b3ae670a89"), "برازجان", 12 },
                    { 398, new Guid("80056c2b-d3f1-4a43-ad32-7520fba2a403"), "بادوله", 12 },
                    { 397, new Guid("04bcc84a-ba76-4a20-8916-bd7a956c7bda"), "اهرم", 12 },
                    { 396, new Guid("639adb44-cc2f-4434-8220-a7a6df564ef7"), "انارستان", 12 },
                    { 395, new Guid("10e6be7f-0bb2-476f-a654-95c7e8895fb9"), "امام حسن", 12 },
                    { 394, new Guid("41228be5-c15b-43cb-9b18-033cedf46bf8"), "آبپخش", 12 },
                    { 421, new Guid("e4981761-d411-48a5-996b-03a183178e21"), "شنبه", 12 },
                    { 392, new Guid("d69044e8-3801-4113-a8ee-d49b5a5185a4"), "آباد", 12 },
                    { 391, new Guid("b8b0a078-99d3-49ec-a897-8b31192896ec"), "گوريه", 11 },
                    { 390, new Guid("a0123ddc-a5bd-41fc-a369-369c4239188b"), "گلگير", 11 },
                    { 389, new Guid("bc5f7a7a-85b0-4da0-aaeb-48e33182721d"), "گتوند", 11 },
                    { 388, new Guid("768ddf93-73e2-48fd-b86d-e97425431a7f"), "کوت عبدالله", 11 },
                    { 387, new Guid("4a8a32c5-31e8-4e2f-b98c-deceb9ad28de"), "کوت سيدنعيم", 11 },
                    { 386, new Guid("61c4539e-c400-4df7-9b93-1955e9ca44e2"), "چوئبده", 11 },
                    { 385, new Guid("b626458a-2ead-4539-9e14-b04a3b92e547"), "چمران", 11 },
                    { 400, new Guid("68e18502-30d5-4eef-ad85-aed44b0ab343"), "بردخون", 12 },
                    { 401, new Guid("27357c0d-f8d6-4e0d-bbd1-8dcae9f685de"), "بردستان", 12 },
                    { 393, new Guid("4b449bfd-2d3b-4820-80e8-2151164ad598"), "آبدان", 12 },
                    { 403, new Guid("a493d1c1-8051-4e46-af80-0385c9f4dbdb"), "بندر ديلم", 12 },
                    { 402, new Guid("dfe655ee-86a6-4522-b267-8562754baa26"), "بندر دير", 12 },
                    { 419, new Guid("2c0458b2-54d9-45d0-873c-2469b7d7680a"), "سيراف", 12 },
                    { 418, new Guid("29b24138-d111-4795-a671-d080726cb3ce"), "سعد آباد", 12 },
                    { 417, new Guid("8875f2e3-f2cf-4fd4-8205-ec5228d250e4"), "ريز", 12 },
                    { 416, new Guid("e0ea095c-ceb5-40be-99d3-2810d46c7b67"), "دوراهک", 12 },
                    { 414, new Guid("aff66b55-c5a5-48f2-a157-20e00abb7b16"), "دالکي", 12 },
                    { 413, new Guid("5bd760d4-a9a9-4403-9e20-f4000b471315"), "خورموج", 12 },
                    { 412, new Guid("c08bede7-5182-4ccf-849f-9d4fe2bd3f68"), "خارک", 12 },
                    { 415, new Guid("618b04b3-eccb-4ad9-9ae0-3f081b754caa"), "دلوار", 12 },
                    { 410, new Guid("28bd30f7-18fe-483d-86cd-7678aa2026a7"), "تنگ ارم", 12 },
                    { 409, new Guid("1d1823b6-c9ef-45a7-ad56-1ba6f678b8ba"), "بوشکان", 12 },
                    { 408, new Guid("0119a807-23e4-4430-87b9-1bb779ebde85"), "بوشهر", 12 },
                    { 407, new Guid("39bbc4ec-1b1b-4220-aaef-3763d6a05829"), "بنک", 12 },
                    { 406, new Guid("c3caf75a-5509-408f-9c6f-35cbe714f70e"), "بندر گناوه", 12 },
                    { 405, new Guid("94dffdf0-ff78-4488-897e-1386a08907a0"), "بندر کنگان", 12 },
                    { 404, new Guid("249fa09b-448c-425f-b7a8-2d5b27388a8e"), "بندر ريگ", 12 },
                    { 411, new Guid("72bba512-5b94-4ef3-9325-e91b2f0b58fb"), "جم", 12 }
                });

            migrationBuilder.InsertData(
                table: "Code",
                columns: new[] { "CodeID", "CodeGroupID", "CodeGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 7, 3, new Guid("2b451e4c-c9b8-415a-bcb4-05da15447b89"), "زن", "Female" },
                    { 1, 1, new Guid("fc20e91f-1eb1-4912-87be-1708f2706367"), "png", "image/png" },
                    { 2, 1, new Guid("3f009296-db7a-4fde-a659-4ca1541a2504"), "jpg", "image/jpg" },
                    { 3, 1, new Guid("3209341a-07d4-437b-9301-2d0f909ad713"), "jpeg", "image/jpeg" },
                    { 4, 2, new Guid("09cb21ac-d99e-42ba-904d-337bdd561e6e"), "به صورت شخصی فعالیت میکنم", "به صورت شخصی فعالیت میکنم" },
                    { 5, 2, new Guid("2383b70e-f41f-4b67-b0c9-c48706a70a46"), "نماینده یک شرکت هستم", "نماینده یک شرکت هستم" },
                    { 6, 2, new Guid("cf5a1929-db68-43d6-8fc7-e3b7ccc51678"), "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم", "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم" },
                    { 8, 3, new Guid("6e48b657-2c83-4481-a9c5-009ffe10158b"), "مرد", "Male" },
                    { 17, 6, new Guid("ccef9d1f-343b-442a-a041-1908e4cbc235"), "حقیقی", "Natural" },
                    { 10, 4, new Guid("10afdac9-a075-40e1-9207-1813befcf4d6"), "در حال انجام", "Doing" },
                    { 11, 4, new Guid("2b9d07c8-5535-495e-8557-da32acb58600"), "انجام شده", "Done" },
                    { 12, 4, new Guid("61960336-e912-4658-9ab3-59f4c58e0b23"), "لغو شده", "Canceled" },
                    { 13, 4, new Guid("46a09d81-c57f-4655-a8f5-027c66a6cfb1"), "ادمین", "Admin" },
                    { 14, 4, new Guid("91b3cdab-39c1-40fb-b077-a2d6e611f50a"), "سرویس گیرنده", "Client" },
                    { 15, 4, new Guid("959b10a3-b8ed-4a9d-bdf3-17ec9b2ceb15"), "سرویس دهنده", "Contractor" },
                    { 16, 6, new Guid("a05c4f54-5999-42b9-a36f-6a04aa7cd476"), "حقوقی", "Legal" },
                    { 9, 4, new Guid("b5d74bda-849b-427c-a6e0-463c1e5f615b"), "در انتظار تایید", "Waiting" }
                });

            migrationBuilder.InsertData(
                table: "SMSSetting",
                columns: new[] { "SMSSettingID", "ModifiedDate", "Name", "SMSProviderConfigurationID", "SMSSettingGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 30, 15, 10, 40, 781, DateTimeKind.Local).AddTicks(5312), "Kavenegar", 1, new Guid("2b2e985e-dd17-42d9-b748-f662ab7536d6") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 5, null, null, new Guid("b347ece5-b533-4e20-8d62-841a352ef1c4"), null, null, "تاسیسات", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3683), 3, null, 1 },
                    { 31, null, null, new Guid("46e1352d-c7c1-48ce-b86b-21d6eedab925"), null, null, "سرویس و تعمیر خودرو", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4401), 4, null, 3 },
                    { 30, null, null, new Guid("dd69207b-8f30-4fef-a9d3-d33710f67b88"), null, null, "اجاره خودرو", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4390), 4, null, 2 },
                    { 29, null, null, new Guid("21e43a48-24dd-4b06-b245-517c182e7a15"), null, null, "اتوبار", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4375), 4, null, 1 },
                    { 21, null, null, new Guid("6a26ec3b-71f8-41ae-8c26-b225d32337e6"), null, null, "کار در ارتفاع", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4139), 3, null, 17 },
                    { 20, null, null, new Guid("e568a83a-6a58-4e67-92a8-199911a731f3"), null, null, "آسانسور و بالابر", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4105), 3, null, 16 },
                    { 19, null, null, new Guid("45bfbee3-7b43-482a-b259-8e1127bcb372"), null, null, "نجاری", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4080), 3, null, 15 },
                    { 18, null, null, new Guid("e38a6232-2aca-4d01-b49d-ebbe07957fdc"), null, null, "تعمیرات لوازم خانگی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4068), 3, null, 14 },
                    { 16, null, null, new Guid("052bc048-3bbd-499b-903a-97a7dfe0e0b2"), null, null, "عایق کاری", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4024), 3, null, 12 },
                    { 15, null, null, new Guid("d20d18bf-0a25-41b0-98ff-909dc6d7c160"), null, null, "عایق کاری", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3997), 3, null, 11 },
                    { 17, null, null, new Guid("d7a59bdb-7402-454d-a205-9eabe10e364d"), null, null, "نرده و حفاظ استیل", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4049), 3, null, 13 },
                    { 13, null, null, new Guid("7adf53f9-b22e-4b15-812d-aa2a2ada4ccd"), null, null, "بنایی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3932), 3, null, 9 },
                    { 12, null, null, new Guid("67493a93-6463-4397-9888-e1f70caac9d1"), null, null, "دکوراسیون داخلی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3741), 3, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[] { 11, null, null, new Guid("867535ef-be13-4dbd-8557-f1e704c852ab"), null, null, "کابینت سازی", null, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3733), 3, null, 7 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 10, null, null, new Guid("95195ea3-6cfa-4d7a-aa2e-14c59f05ab59"), null, null, "شیشه بری و قابسازی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3725), 3, null, 6 },
                    { 9, null, null, new Guid("f01ed45f-9012-46d7-8cda-a26ae22d26d6"), null, null, "آلومینیوم سازی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3716), 3, null, 5 },
                    { 8, null, null, new Guid("1ca7d840-7b91-47be-991d-521c9fe799dd"), null, null, "مبلمان", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3708), 3, null, 4 },
                    { 7, null, null, new Guid("d68c3f4a-bc65-4705-a7eb-3491742b19d5"), null, null, "ایمنی و امنیت", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3700), 3, null, 3 },
                    { 6, null, null, new Guid("dd701d01-d75d-49ac-9e50-8f7c6f2a788c"), null, null, "الکتریکی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3692), 3, null, 2 },
                    { 14, null, null, new Guid("40fe19e3-6890-4b95-b9eb-d47a43d82319"), null, null, "آهنگری", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(3978), 3, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 30, 15, 10, 40, 782, DateTimeKind.Local).AddTicks(1484), "VerifyAccount", 1, new Guid("660650ae-a04e-484d-99d2-8bdcf541b040") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "GenderCodeID", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "ProfileDocumentID", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 4, "white.luciferrr@gmail.com", "محمد", 8, true, true, "میرزایی", new DateTime(2020, 5, 30, 15, 10, 40, 785, DateTimeKind.Local).AddTicks(2628), "09147830093", null, new DateTime(2020, 5, 30, 15, 10, 40, 785, DateTimeKind.Local).AddTicks(2624), 2, new Guid("b36b7329-1187-4b1f-8b4c-a1eb02240f6e") },
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", 8, true, true, "رودکی", new DateTime(2020, 5, 30, 15, 10, 40, 785, DateTimeKind.Local).AddTicks(150), "09227204305", null, new DateTime(2020, 5, 30, 15, 10, 40, 784, DateTimeKind.Local).AddTicks(9558), 1, new Guid("69c7e973-7534-41cc-b203-412c86dd8a73") },
                    { 2, "roozbehshamekhi@hotmail.com", "روزبه", 8, true, true, "شامخی", new DateTime(2020, 5, 30, 15, 10, 40, 785, DateTimeKind.Local).AddTicks(2567), "09128277075", null, new DateTime(2020, 5, 30, 15, 10, 40, 785, DateTimeKind.Local).AddTicks(2544), 3, new Guid("d9cb7ec9-d4e6-4ced-b015-fb38537ea5e9") },
                    { 3, "dead.hh98@gmail.com", "حامد", 8, true, true, "حقیقیان", new DateTime(2020, 5, 30, 15, 10, 40, 785, DateTimeKind.Local).AddTicks(2614), "09108347428", null, new DateTime(2020, 5, 30, 15, 10, 40, 785, DateTimeKind.Local).AddTicks(2610), 2, new Guid("a6fb277c-67b4-470f-bdb5-36c4ad5d2ba1") }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "AdminGUID", "IsDelete", "ModifiedDate", "UserID" },
                values: new object[] { 1, new Guid("0a3f1f1c-3fbe-4f49-973b-99b90d1b4368"), false, new DateTime(2020, 5, 30, 15, 10, 40, 785, DateTimeKind.Local).AddTicks(5463), 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 22, null, null, new Guid("174e59ac-a495-43ae-8a29-749a42e85a4b"), null, null, "سرویس کولر آبی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4166), 5, null, 1 },
                    { 23, null, null, new Guid("a2bd7684-99e4-448f-820c-d8a9cb40a3b5"), null, null, "نقاشی ساختمان", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4193), 5, null, 2 },
                    { 24, null, null, new Guid("9856aa78-551e-4949-98f3-4785a7c4b87c"), null, null, "رنگ کاری مبل", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4236), 8, null, 1 },
                    { 25, null, null, new Guid("5f5af31f-65bb-4f76-804f-890e6bb2e49b"), null, null, "تعمیر صندلی اداری", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4251), 8, null, 2 },
                    { 26, null, null, new Guid("729aa87b-27dc-41a2-ae8f-4afb9de86ae1"), null, null, "ساخت مبلمان", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4261), 8, null, 3 },
                    { 27, null, null, new Guid("7edbf916-5436-4eb7-9b99-225daf1711ba"), null, null, "دوخت کاور مبل", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4273), 8, null, 4 },
                    { 28, null, null, new Guid("e69672e0-f8da-4d98-baf9-d0347230746e"), null, null, "تعمیر مبل", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4285), 8, null, 5 },
                    { 32, null, null, new Guid("20369633-eb02-49f1-8ff5-78c639e9247b"), null, null, "وانت بار", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4411), 29, null, 1 },
                    { 33, null, null, new Guid("9b0262b4-e85e-47e0-95a9-bd09684fada9"), null, null, "باربری و اتوبار", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4424), 29, null, 2 },
                    { 34, null, null, new Guid("c980969a-ccaa-415a-8628-a9ebe9e1e8d2"), null, null, "کارگر اسباب کشی", null, true, new DateTime(2020, 5, 30, 15, 10, 40, 790, DateTimeKind.Local).AddTicks(4435), 29, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "CityID", "ClientGUID", "ModifiedDate", "UserID" },
                values: new object[] { 1, 751, new Guid("9228c886-39cf-45c5-a9fb-1c3bbbe17862"), new DateTime(2020, 5, 30, 15, 10, 40, 786, DateTimeKind.Local).AddTicks(422), 2 });

            migrationBuilder.InsertData(
                table: "Contractor",
                columns: new[] { "ContractorID", "AverageRate", "BusinessTypeCodeID", "CityID", "ContractorGUID", "Credit", "Latitude", "Longitude", "ModifiedDate", "UserID" },
                values: new object[,]
                {
                    { 1, 0.0, 4, 751, new Guid("e43c6c64-d20f-420a-bd44-aee2c4cdd38d"), 0, "1", "2", new DateTime(2020, 5, 30, 15, 10, 40, 787, DateTimeKind.Local).AddTicks(2738), 3 },
                    { 2, 0.0, 4, 751, new Guid("cda5a3f8-05f3-4ecc-9d76-e3ea2a7f1a35"), 10000, "1", "2", new DateTime(2020, 5, 30, 15, 10, 40, 787, DateTimeKind.Local).AddTicks(3437), 4 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderID", "CategoryID", "ClientID", "Comment", "ContractorID", "Cost", "DeadlineDate", "Description", "ModifiedDate", "OrderGUID", "Rate", "StateCodeID", "Title" },
                values: new object[] { 1, 14, 1, null, null, null, null, "توضیح", new DateTime(2020, 5, 30, 15, 10, 40, 788, DateTimeKind.Local).AddTicks(1098), new Guid("4850f4a0-b552-4fd4-abb5-6c06d4af759d"), null, 9, "تیتر" });

            migrationBuilder.InsertData(
                table: "OrderRequest",
                columns: new[] { "OrderRequestID", "ContractorID", "IsAllow", "Message", "ModifiedDate", "OfferedPrice", "OrderID", "OrderRequestGUID" },
                values: new object[] { 1, 1, true, "پیام", new DateTime(2020, 5, 30, 15, 10, 40, 788, DateTimeKind.Local).AddTicks(8082), 250000L, 1, new Guid("0797faa0-f070-4252-aabe-f8816941ab4f") });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserID",
                table: "Admin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_DocumentID",
                table: "Advertisement",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ActiveIconDocumentID",
                table: "Category",
                column: "ActiveIconDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CoverDocumentID",
                table: "Category",
                column: "CoverDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_InactiveIconDocumentID",
                table: "Category",
                column: "InactiveIconDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryID",
                table: "Category",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_QuadMenuDocumentID",
                table: "Category",
                column: "QuadMenuDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTag_CategoryID",
                table: "CategoryTag",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTag_TagID",
                table: "CategoryTag",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_OrderRequestID",
                table: "ChatMessage",
                column: "OrderRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_UserID",
                table: "ChatMessage",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceID",
                table: "City",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CityID",
                table: "Client",
                column: "CityID");

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
                name: "IX_ContactUs_ContactUsBusinessTypeCodeID",
                table: "ContactUs",
                column: "ContactUsBusinessTypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_BusinessTypeCodeID",
                table: "Contractor",
                column: "BusinessTypeCodeID");

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
                name: "IX_Payment_ContractorID",
                table: "Payment",
                column: "ContractorID");

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
                name: "IX_Token_RoleCodeID",
                table: "Token",
                column: "RoleCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserID",
                table: "Token",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TypeCodeID",
                table: "Transaction",
                column: "TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderCodeID",
                table: "User",
                column: "GenderCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileDocumentID",
                table: "User",
                column: "ProfileDocumentID");

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
                name: "Payment");

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
                name: "OrderRequest");

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
                name: "SMSProviderConfiguration");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "CodeGroup");
        }
    }
}
