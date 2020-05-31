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
                    { 1, null, null, new Guid("c265fd02-0194-4d38-83e8-a93bc3698fcc"), null, null, "سایت اصلی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(6148), null, null, 1 },
                    { 2, null, null, new Guid("dec37f17-0ab2-4208-8ba7-11cc1120369b"), null, null, "وبلاگ", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(7996), null, null, 2 }
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
                    { 19, "اصفهان", new Guid("7a8db7a6-52d7-40d7-88f4-b8ca5812d7bc") },
                    { 20, "ايلام", new Guid("914f2d87-172a-4685-ad78-fff4f7b19ecf") },
                    { 21, "تهران", new Guid("af59fd1f-2810-4853-b838-ed3ff7531b83") },
                    { 22, "آذربايجان شرقي", new Guid("c916885e-a973-442a-978d-474eae2a6e2e") },
                    { 23, "فارس", new Guid("29a89e91-9bad-4dd9-b705-7b64b804cc83") },
                    { 24, "کرمانشاه", new Guid("8366b82d-92fa-485d-9c85-f0d00e5ad0fe") },
                    { 28, "همدان", new Guid("de68479d-355f-4e4a-801a-27bab7d329bd") },
                    { 26, "مرکزي", new Guid("754068a5-a946-4460-bc5b-287011924a1b") },
                    { 27, "گيلان", new Guid("204d06b1-1d3c-429c-afee-1ee57941efe2") },
                    { 18, "اردبيل", new Guid("4c09413b-512c-469f-8208-c103c6eb7249") },
                    { 29, "کرمان", new Guid("0fa47c40-239e-4bc3-99a9-151f8c636c7a") },
                    { 30, "سمنان", new Guid("4902d48a-3b31-4785-938d-fe0003997032") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("b3d1ac71-3d8d-4644-bd68-e79afb7e99db") },
                    { 25, "هرمزگان", new Guid("24d44963-57d7-44f0-8892-25d4ca36ea0f") },
                    { 17, "لرستان", new Guid("ec154207-a51d-4089-9476-c8501bf8e2da") },
                    { 14, "گلستان", new Guid("5e58491a-5646-486e-bf3c-e2e024e2786c") },
                    { 15, "مازندران", new Guid("ecdc6046-d08d-45bb-817b-ff5c95c8c3e8") },
                    { 1, "يزد", new Guid("30254e83-5493-4f29-8322-6a3d3bf71cb6") },
                    { 2, "چهار محال و بختياري", new Guid("c33b4349-fee7-4e49-b0a2-7a2923e67704") },
                    { 3, "خراسان شمالي", new Guid("b97bbb33-fd5c-45bd-9f35-28714d1d768a") },
                    { 4, "البرز", new Guid("393c0a1e-db98-4497-bd1a-4047c5ba00d5") },
                    { 5, "قم", new Guid("b483c2e4-edaa-427f-aff6-465287645c12") },
                    { 16, "قزوين", new Guid("ea9f84d6-43c2-4dc3-aedb-8257d6277984") },
                    { 7, "آذربايجان غربي", new Guid("7bf8f1a6-8c39-4ad0-9b48-e9e92fc875b1") },
                    { 6, "کردستان", new Guid("ddc2ca76-7faf-493b-88cb-97d6907edadf") },
                    { 9, "سيستان و بلوچستان", new Guid("9b676f50-696e-4b1a-b91b-0fa42b99c08c") },
                    { 10, "خراسان جنوبي", new Guid("8d067472-4977-4d89-b75a-6940246421d6") },
                    { 11, "خوزستان", new Guid("e198747f-7359-4237-984c-9f77aadeee0f") },
                    { 12, "بوشهر", new Guid("76007847-81fe-423b-af88-23d48d612d64") },
                    { 13, "زنجان", new Guid("309f5a9c-a0ad-45fe-b7c7-63b60c81094b") },
                    { 8, "خراسان رضوي", new Guid("e672e69d-9e41-48b7-b2a0-ba8c3430ee97") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 3, "سرویس گیرنده", new DateTime(2020, 5, 31, 15, 29, 22, 152, DateTimeKind.Local).AddTicks(9724), "Client", new Guid("649181f1-ba55-4998-8cef-bf17848d353c") },
                    { 1, "ادمین", new DateTime(2020, 5, 31, 15, 29, 22, 152, DateTimeKind.Local).AddTicks(8668), "Admin", new Guid("75c866e0-bcce-4038-972c-a2dba6f54315") },
                    { 2, "سرویس دهنده", new DateTime(2020, 5, 31, 15, 29, 22, 152, DateTimeKind.Local).AddTicks(9693), "Contractor", new Guid("ff48363b-4cb9-4649-b43f-b0b941e1fb03") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 5, 31, 15, 29, 22, 148, DateTimeKind.Local).AddTicks(112), "ptcoptco", new Guid("cd0a4f5f-020c-43e3-8ce2-cf505a90a0ec"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 3, null, null, new Guid("f32c3568-d38a-42d2-9fbe-6d9bf40ec535"), null, null, "خانه", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8044), 1, null, 1 },
                    { 4, null, null, new Guid("ee21fd18-130c-4051-9ac6-afa2b21027b3"), null, null, "حمل و نقل", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8103), 1, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 826, new Guid("02b10bca-9a1f-4d4b-89dd-57b6f4a49fe9"), "ليلان", 22 },
                    { 825, new Guid("a688357b-19a1-4ebf-873c-a665f5d48789"), "قره آغاج", 22 },
                    { 824, new Guid("cd5b6ccc-4dd5-4edf-9a40-63f698b4575b"), "عجب شير", 22 },
                    { 823, new Guid("05a1d9bd-90f9-4ff6-b943-2b45288d425d"), "صوفيان", 22 },
                    { 822, new Guid("8f0e161c-c8d1-4a70-b7e2-d545e47aa03e"), "شهر جديد سهند", 22 },
                    { 821, new Guid("afb4101d-e8d9-40df-b4b2-b113199ff5e3"), "شند آباد", 22 },
                    { 820, new Guid("3e695d07-2c3f-4138-bca6-a89df581bc0c"), "شرفخانه", 22 },
                    { 819, new Guid("ba3520ad-719f-466a-8e4b-9ecdf4d93fc3"), "شربيان", 22 },
                    { 818, new Guid("a9ecb4b4-d176-48c2-957a-6087560c112e"), "شبستر", 22 },
                    { 817, new Guid("4a1b9ce8-5e8a-43e2-8543-de838fda256c"), "سيه رود", 22 },
                    { 816, new Guid("5911f01b-88ba-46f1-ae1f-1b3a56517a8d"), "سيس", 22 },
                    { 815, new Guid("8dc4693e-886b-4991-86af-861fcb98f56b"), "سردرود", 22 },
                    { 814, new Guid("80df2971-2a26-490b-82ec-e4fc74ed94f3"), "سراب", 22 },
                    { 813, new Guid("822a1dc2-19a9-494f-91df-e79736033702"), "زنوز", 22 },
                    { 812, new Guid("5286d710-1021-4df3-b526-ed30b03b9d74"), "زرنق", 22 },
                    { 827, new Guid("dd327726-27dc-465d-a779-193087330c6c"), "مبارک شهر", 22 },
                    { 828, new Guid("f0d5c511-d77a-40e2-b14c-db4cb32c5d76"), "مراغه", 22 },
                    { 829, new Guid("0eb43ea2-76cf-421a-b64f-2795f968187a"), "مرند", 22 },
                    { 830, new Guid("44091167-59d0-4dcd-b72f-edacae297833"), "ملکان", 22 },
                    { 846, new Guid("08a467d2-7f25-4803-b973-b52d538d87cd"), "گوگان", 22 },
                    { 845, new Guid("da581d46-2907-4c7f-ae34-440457598c59"), "کوزه کنان", 22 },
                    { 844, new Guid("0f5acbde-6ad2-43bb-8256-22ebd5b60540"), "کليبر", 22 },
                    { 843, new Guid("167c8ecc-5a9a-45a7-93cf-aa6b030ea7da"), "کلوانق", 22 },
                    { 842, new Guid("8165c501-ebb4-40e0-b194-13b4b028de55"), "کشکسراي", 22 },
                    { 841, new Guid("e4bcbae7-94c3-4156-94c2-007a5edc59fb"), "يامچي", 22 },
                    { 840, new Guid("7b7ff920-0cf6-411c-aa6b-743450ebd0cc"), "ورزقان", 22 },
                    { 811, new Guid("2c685ec8-feca-4a77-92cb-2aefd9c97983"), "دوزدوزان", 22 },
                    { 839, new Guid("5ff86ddd-c34c-4291-9fcd-b2597cffe6af"), "وايقان", 22 },
                    { 837, new Guid("b4ac3c22-acc8-4529-956e-eb722c7cd2c1"), "هشترود", 22 },
                    { 836, new Guid("6e65847f-5713-4d3f-ba43-217b5893b0ec"), "هريس", 22 },
                    { 835, new Guid("a195b595-9fc6-4f3e-ad06-83e4902868b6"), "هاديشهر", 22 },
                    { 834, new Guid("d93190ee-e52c-4a2f-9606-da794c0a454b"), "نظرکهريزي", 22 },
                    { 833, new Guid("166d9272-6dc4-4de1-bde9-a7a0c2eb3aac"), "ميانه", 22 },
                    { 832, new Guid("63a5a680-f347-4d7c-9c82-eb4762ddb50e"), "مهربان", 22 },
                    { 831, new Guid("4eddc3f3-abf4-4133-aa88-202c77478d49"), "ممقان", 22 },
                    { 838, new Guid("5c6dd590-4ed3-46d1-9ed2-20333f6fa79a"), "هوراند", 22 },
                    { 810, new Guid("56eee6a6-b8ae-4b43-8949-5a488af2952c"), "خواجه", 22 },
                    { 809, new Guid("06c70e6e-d7d3-4fc1-83c8-37ef1a0a6066"), "خمارلو", 22 },
                    { 808, new Guid("74e84884-3a3a-4194-89e1-ba7f13dac7c2"), "خسروشاه", 22 },
                    { 787, new Guid("60711e02-f504-4480-b3fd-88be418f0d90"), "آقکند", 22 },
                    { 786, new Guid("b2f4cc65-5325-49da-ae0c-e52c8ad7ba5f"), "آذرشهر", 22 },
                    { 785, new Guid("5bcad925-23fd-4fae-9bc8-a79cc45f385f"), "آبش احمد", 22 },
                    { 784, new Guid("2d15db7c-bb8f-48a9-96b1-b8a748f25981"), "گلستان", 21 },
                    { 783, new Guid("6bad1adc-4902-49d6-b4d6-d461a6d9eeca"), "کيلان", 21 },
                    { 782, new Guid("3b7cf6e6-f1e6-4288-a33f-ae0aa77357a1"), "کهريزک", 21 },
                    { 781, new Guid("cc5bd1b5-784f-4a05-8978-d1ba106d21a7"), "چهاردانگه", 21 },
                    { 780, new Guid("0c9ed239-e761-42a6-9a25-2bc47b7e34f6"), "پيشوا", 21 },
                    { 779, new Guid("882734b1-63c5-4784-a82e-7d96b048c3ba"), "پرديس", 21 },
                    { 778, new Guid("6aabca0c-7e54-429a-b0ca-aeb2ad308a6c"), "پاکدشت", 21 },
                    { 777, new Guid("936e8266-d6e3-4795-bdc1-38d0c3ab703d"), "ورامين", 21 },
                    { 776, new Guid("82f93aa6-f444-4c77-bb42-6a9c9c73505d"), "وحيديه", 21 },
                    { 775, new Guid("5a841e70-ef06-40d1-98f7-ccb431869b66"), "نصيرشهر", 21 },
                    { 774, new Guid("c7eb948c-f0bf-40df-a54e-40dbd6b54fbb"), "نسيم شهر", 21 },
                    { 773, new Guid("796af53d-4f21-4396-ba34-59e23c11ddee"), "ملارد", 21 },
                    { 788, new Guid("033ddca9-a08c-4005-9bff-53e56056f492"), "آچاچي", 22 },
                    { 789, new Guid("6ce4b078-0ff5-4d71-b8ca-31b28809e0cf"), "اسکو", 22 },
                    { 790, new Guid("76775f93-ec8d-42c9-bc50-b6540f784e1c"), "اهر", 22 },
                    { 791, new Guid("bd51e0ad-df0a-4e98-97a1-f77efe12ad47"), "ايلخچي", 22 },
                    { 807, new Guid("f2782a6b-dcac-4cd2-bd09-9ff8d704972a"), "خداجو", 22 },
                    { 806, new Guid("c458d35a-fefc-43dd-8276-402fa7ce271e"), "خامنه", 22 },
                    { 805, new Guid("95bf6a83-c8f4-40cd-b48b-eb93b52b1f3d"), "خاروانا", 22 },
                    { 804, new Guid("e080fc49-ad33-481a-9af3-7cc6cf93ace5"), "جوان قلعه", 22 },
                    { 803, new Guid("929c8d7d-cc0d-480e-a338-c5a397472900"), "جلفا", 22 },
                    { 802, new Guid("55234e10-7d9a-408c-adeb-d717ed32894b"), "تيکمه داش", 22 },
                    { 801, new Guid("b0abd7f9-416c-49d8-b1a4-a93f7b69234a"), "تيمورلو", 22 },
                    { 847, new Guid("bc644c36-2131-4b42-8331-00ccc2486ae6"), "آباده", 23 },
                    { 800, new Guid("3bfd3f3e-dc2b-4bc7-9c4b-21711aef5614"), "تسوج", 22 },
                    { 798, new Guid("69186fcf-8282-4f62-aaa9-75fdc45ded57"), "ترک", 22 },
                    { 797, new Guid("6baa9dcf-a695-4a98-af7a-ba99d6d119bc"), "تبريز", 22 },
                    { 796, new Guid("86ba863c-8477-46e8-8894-8d0505f6d661"), "بناب مرند", 22 },
                    { 795, new Guid("70f148cb-90b1-4da1-8034-3b5780bf64c2"), "بناب", 22 },
                    { 794, new Guid("5a1cc492-4b7e-409e-b542-0603cc59cb20"), "بستان آباد", 22 },
                    { 793, new Guid("4db50eca-14ac-43bb-84ae-17292150f425"), "بخشايش", 22 },
                    { 792, new Guid("671eaae4-6494-4f52-a14c-53f7601b5b2a"), "باسمنج", 22 },
                    { 799, new Guid("2a19e8b8-fa40-4c2c-bb1d-8aee38bbaf45"), "ترکمانچاي", 22 },
                    { 848, new Guid("7f2b21da-802b-40e4-b0f1-4768ae360a5c"), "آباده طشک", 23 },
                    { 849, new Guid("7f0bd375-1039-4339-beaa-028f50fd01f5"), "اردکان", 23 },
                    { 850, new Guid("14b9e6a4-26f0-4945-a7c3-907415c85894"), "ارسنجان", 23 },
                    { 905, new Guid("12e7ad06-b7a0-4a42-b361-2a054e714557"), "صغاد", 23 },
                    { 904, new Guid("338ef449-a364-4505-879b-4f3397981160"), "شيراز", 23 },
                    { 903, new Guid("04077ad3-b6b8-4df9-9937-ea683deac72d"), "شهر پير", 23 },
                    { 902, new Guid("bed80cb5-9db3-4f60-b6e9-649dbc76f661"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("b786e104-2cc3-4248-aa44-c659e7ca8791"), "ششده", 23 },
                    { 900, new Guid("287bea9c-d82e-4cdf-a176-cc8e88282741"), "سيدان", 23 },
                    { 899, new Guid("7183500f-33d1-4d0a-8095-7b08f9114098"), "سورمق", 23 },
                    { 898, new Guid("f2af351c-d562-4711-b45e-c0f28e7ea3cf"), "سلطان شهر", 23 },
                    { 897, new Guid("5a80fcb5-b42e-445b-946f-b0e35f31e525"), "سعادت شهر", 23 },
                    { 896, new Guid("5253287e-81ce-4e05-a617-11b663c080aa"), "سروستان", 23 },
                    { 895, new Guid("9cc616f5-6e18-4d62-a71e-2eacbaba90ba"), "سده", 23 },
                    { 894, new Guid("24d20376-8c82-40d0-995a-98868b1d6ee2"), "زرقان", 23 },
                    { 893, new Guid("b49bbcc6-e28a-49e7-af14-17e2b797dea0"), "زاهد شهر", 23 },
                    { 892, new Guid("9f545b62-a6b6-4fb6-a82a-cf1e08b48c9d"), "رونيز", 23 },
                    { 891, new Guid("69483a3e-921a-4ea4-8a8f-012b91d6d388"), "رامجرد", 23 },
                    { 906, new Guid("5d6d72b3-acc6-4ab5-9e35-a5c09ffd4a37"), "صفا شهر", 23 },
                    { 907, new Guid("a3a9b951-546b-4c41-995e-cfa351ea74a8"), "علامرودشت", 23 },
                    { 908, new Guid("7b520ae6-5922-4cec-a1ae-79c417683a29"), "عماد ده", 23 },
                    { 909, new Guid("c561f832-dc0b-4812-9600-fc0b4b409a3c"), "فدامي", 23 },
                    { 925, new Guid("53b651d2-dbbd-44a0-89ef-efe3ce6ab5f4"), "مرودشت", 23 },
                    { 924, new Guid("c134b78c-c407-448f-b5d1-33a5d93b65f9"), "مبارک آباد", 23 },
                    { 923, new Guid("94601ead-0b01-44c4-8e2d-1adcdc9a9cda"), "مادرسليمان", 23 },
                    { 922, new Guid("f47a1bd1-02f7-4138-be5f-61ea2c05cbf6"), "لپوئي", 23 },
                    { 921, new Guid("6a8e655f-534d-4e93-bd5e-3fdfa7aecd50"), "لطيفي", 23 },
                    { 920, new Guid("29eea0ed-29a7-4def-8eb9-907ed6f64cac"), "لامرد", 23 },
                    { 919, new Guid("ee0dff3b-5dcd-4000-b1d4-36c961ea05c5"), "لار", 23 },
                    { 890, new Guid("67afa827-4697-46a7-86b9-193475269816"), "دژکرد", 23 },
                    { 918, new Guid("1364438e-de66-4c78-a367-30f73bc923d3"), "قير", 23 },
                    { 916, new Guid("5100a7c7-198f-4633-a066-4bc604475db0"), "قطب آباد", 23 },
                    { 915, new Guid("3df189d5-d1c7-48ba-9c06-773c658a2310"), "قره بلاغ", 23 },
                    { 914, new Guid("98192585-6114-4288-82b8-51d187a59433"), "قادرآباد", 23 },
                    { 913, new Guid("dffb6d6a-86e8-4bb4-ae39-a253f78ff997"), "قائميه", 23 },
                    { 912, new Guid("26e35dcd-0316-48e8-9462-9c79f75e1c37"), "فيروزآباد", 23 },
                    { 911, new Guid("0366d60e-9000-4af6-9614-4ebdf5ac81ab"), "فسا", 23 },
                    { 910, new Guid("cfb0daec-9f5e-49d7-989e-3852fa3f5239"), "فراشبند", 23 },
                    { 917, new Guid("cba801d8-cf37-4747-bda0-8a09ef3b9297"), "قطرويه", 23 },
                    { 889, new Guid("680185c6-73ff-46f3-adb4-be529e1be84b"), "دوزه", 23 },
                    { 888, new Guid("83cfff50-f6cf-402e-87e8-62b0b41fbe94"), "دوبرجي", 23 },
                    { 887, new Guid("fc84da09-945d-4457-a376-91f208a1e838"), "دهرم", 23 },
                    { 866, new Guid("53ab15b2-3284-4ce9-af17-1f90a129d347"), "بوانات", 23 },
                    { 865, new Guid("92f912ee-c634-454a-b4b1-eea92076527a"), "بهمن", 23 },
                    { 864, new Guid("73cd2d0f-d401-456a-b2a6-2b15361e833f"), "بنارويه", 23 },
                    { 863, new Guid("87691aab-8f9d-4346-921d-2b73487fdbb0"), "بالاده", 23 },
                    { 862, new Guid("456213af-ab7c-4e86-9532-c6b2db0f4d3c"), "بابامنير", 23 },
                    { 861, new Guid("4ed65718-73b8-4673-8dde-437132899027"), "باب انار", 23 },
                    { 860, new Guid("8d1780ce-23ea-40ff-bcf9-8550317ecd5d"), "ايزد خواست", 23 },
                    { 867, new Guid("a4ea4bd3-2f8a-4d84-accf-c79fc2702c22"), "بيرم", 23 },
                    { 859, new Guid("1524973c-8bcb-4cd5-ad75-c1a4755808ac"), "ايج", 23 },
                    { 857, new Guid("aa195702-3cab-458a-9405-279ab68e3bb6"), "اهل", 23 },
                    { 856, new Guid("fdcb101e-625a-4ddb-9ecd-fbfda93a2507"), "امام شهر", 23 },
                    { 855, new Guid("ae6029cb-fb6a-43b4-acde-9a1649ec58c1"), "اقليد", 23 },
                    { 854, new Guid("e8b16e76-a63f-4464-9d33-d5038b671068"), "افزر", 23 },
                    { 853, new Guid("ab35f5ef-ff3d-4b94-9a5b-832833e2dfbb"), "اشکنان", 23 },
                    { 852, new Guid("af2d2f0b-4d77-42a7-a559-1978a5cee6ef"), "اسير", 23 },
                    { 851, new Guid("d8d79c3b-5fa5-42fa-9120-30cf8a9dac5d"), "استهبان", 23 },
                    { 858, new Guid("a96ef8aa-75ae-4715-af6d-89726ce9911d"), "اوز", 23 },
                    { 772, new Guid("04a3d5a6-714a-40d7-9400-b23f033b5654"), "لواسان", 21 },
                    { 868, new Guid("c48e99c5-4ef5-41db-80ea-f28f63c65313"), "بيضا", 23 },
                    { 870, new Guid("531014c0-73cc-4ca3-9825-a9ff10253e9f"), "جهرم", 23 },
                    { 886, new Guid("d08dc532-4dde-4e1d-9f8a-64f34230ae90"), "دبيران", 23 },
                    { 885, new Guid("4e894027-a256-4aac-be8e-f0b63452102b"), "داريان", 23 },
                    { 884, new Guid("577cebc0-d759-4245-b827-5380988d0f9d"), "داراب", 23 },
                    { 883, new Guid("423d48bd-2459-4201-a52c-7ee0811ef569"), "خومه زار", 23 },
                    { 882, new Guid("9c019571-e937-442f-aa5f-c9d293ad33e2"), "خوزي", 23 },
                    { 881, new Guid("25591376-fd37-4af1-9219-17639dc814d7"), "خور", 23 },
                    { 880, new Guid("10a2b249-7d79-45dd-80ac-16858821ec18"), "خنج", 23 },
                    { 869, new Guid("1cb8af0f-183b-4f93-94c9-3ef3e0308dcb"), "جنت شهر", 23 },
                    { 879, new Guid("b70a0780-fa62-41ed-b1f8-9b07c71d4830"), "خشت", 23 },
                    { 877, new Guid("8e3e1e45-822b-44c3-b147-d351be09a8ef"), "خاوران", 23 },
                    { 876, new Guid("2f8ea11e-dcef-488c-a2f7-92df580dde98"), "خانيمن", 23 },
                    { 875, new Guid("d88aa347-ce4f-480b-8e87-b278a3f6fb95"), "خانه زنيان", 23 },
                    { 874, new Guid("9afb43d9-8015-496d-9554-5cfaf2725d2c"), "حسن آباد", 23 },
                    { 873, new Guid("89490725-858a-45be-b265-0bdbef451ca9"), "حسامي", 23 },
                    { 872, new Guid("8f7d058e-9c1d-4af3-afb2-21aa204007a3"), "حاجي آباد", 23 },
                    { 871, new Guid("ad44a423-5595-4a3c-90f9-62cf963b7aea"), "جويم", 23 },
                    { 878, new Guid("2fb47812-4313-47fb-8606-fc63cdfc1ecd"), "خرامه", 23 },
                    { 771, new Guid("232a04ca-cf9c-45f2-89ac-21c5adcc7dc5"), "قرچک", 21 },
                    { 770, new Guid("ad052d48-652b-47ae-8d53-a5ab0919167c"), "قدس", 21 },
                    { 769, new Guid("9fbda25c-0772-487a-9616-48289b13e0b4"), "فيروزکوه", 21 },
                    { 669, new Guid("a0495091-a25b-4475-88e6-fc0d3c5c50aa"), "عسگران", 19 },
                    { 668, new Guid("f73621b9-0ef6-4387-baf1-da68b482a7df"), "طرق رود", 19 },
                    { 667, new Guid("70e6768d-a671-4ba6-bc28-cde5fe7ddb47"), "طالخونچه", 19 },
                    { 666, new Guid("4518dbd3-403d-4865-ae46-572e55bfc5a2"), "شهرضا", 19 },
                    { 665, new Guid("abb84dc0-b849-466f-ab7b-8b385fc6a47b"), "شاپورآباد", 19 },
                    { 664, new Guid("b9cd03cc-9f17-4189-b9e0-6b2a8f279cf6"), "شاهين شهر", 19 },
                    { 663, new Guid("98efd473-19c4-44ba-b5f0-030e282e0561"), "سگزي", 19 },
                    { 662, new Guid("0196702d-988a-45e3-ba99-0518dbea3c72"), "سين", 19 },
                    { 661, new Guid("037d4260-483e-49fa-b5f4-3c64b583882b"), "سميرم", 19 },
                    { 660, new Guid("bc59a3a0-2abd-4600-8919-10d72e5fdc87"), "سفيد شهر", 19 },
                    { 659, new Guid("df8adcdd-f851-4558-862a-b13017a36c33"), "سده لنجان", 19 },
                    { 658, new Guid("19ce6721-683f-45db-b741-90e59220aa04"), "زيباشهر", 19 },
                    { 657, new Guid("3aa62550-3e66-47fb-b57e-589c46e486aa"), "زيار", 19 },
                    { 656, new Guid("85277302-393c-4cb9-822d-38d2189c660f"), "زواره", 19 },
                    { 655, new Guid("e8a03035-fbc4-42d9-8430-d7d6f452d86c"), "زرين شهر", 19 },
                    { 670, new Guid("9b1791cb-02b1-4633-83a2-579ec89e8a37"), "علويچه", 19 },
                    { 671, new Guid("50c51b54-e51b-4eea-a7cb-c22070bd10c5"), "فرخي", 19 },
                    { 672, new Guid("a6704845-e162-4d0c-b30c-805be7205631"), "فريدونشهر", 19 },
                    { 673, new Guid("3b557f90-a849-4497-99b1-47732386750d"), "فلاورجان", 19 },
                    { 689, new Guid("316b3125-fe1e-4daf-9d90-4c7d2e4e900f"), "نوش آباد", 19 },
                    { 688, new Guid("7b747fa9-bccb-4c65-96ba-5afb376e696f"), "نطنز", 19 },
                    { 687, new Guid("2b789cb7-3bf8-4e9c-a6d1-d4979544f096"), "نصرآباد", 19 },
                    { 686, new Guid("39e85ba0-f29d-479e-8188-8880be4503cc"), "نجف آباد", 19 },
                    { 685, new Guid("fb55f442-6d19-49ff-8a6b-d3e15359cff8"), "نائين", 19 },
                    { 684, new Guid("c7140d3d-edb8-4f4a-9e5c-78953799d0a3"), "ميمه", 19 },
                    { 683, new Guid("7f81ba16-c405-4727-9896-db638de11e7f"), "مهاباد", 19 },
                    { 654, new Guid("35a35e9b-2fa3-48b5-98e8-4f74e63eee51"), "زاينده رود", 19 },
                    { 682, new Guid("285ae566-b3a8-44d2-a9dc-1a045e7f8b77"), "منظريه", 19 },
                    { 680, new Guid("ceaf102a-d842-4c2b-a290-09ec4fda7aee"), "محمد آباد", 19 },
                    { 679, new Guid("fe5c4d1b-ab00-4973-98b6-0bd6fb4bf272"), "مبارکه", 19 },
                    { 678, new Guid("548e09c3-9595-442b-bd15-080d15dd1b32"), "لاي بيد", 19 },
                    { 677, new Guid("cfffe170-1255-422a-91e4-2483bb83ada0"), "قهدريجان", 19 },
                    { 676, new Guid("3b0c189c-4968-4404-9791-6465a9d403c9"), "قهجاورستان", 19 },
                    { 675, new Guid("67d42344-c844-4227-9c2f-86b6aa7b1dc4"), "قمصر", 19 },
                    { 674, new Guid("f86a6e03-8862-4b58-aec6-62917c41b9d3"), "فولاد شهر", 19 },
                    { 681, new Guid("ac28beba-762b-448a-b731-0ee696b54e3b"), "مشکات", 19 },
                    { 653, new Guid("4372742d-bfa3-448d-a510-d23745a0d788"), "زازران", 19 },
                    { 652, new Guid("68091bb1-6013-41a6-9b4a-b56fe5aa9451"), "رضوانشهر", 19 },
                    { 651, new Guid("9658b011-d058-4a0e-8149-2c3339e117c4"), "رزوه", 19 },
                    { 630, new Guid("24290046-42da-48f4-a8a3-e3a835489e5a"), "تودشک", 19 },
                    { 629, new Guid("52bf4982-10d4-40bd-8bae-a46d8501616f"), "بوئين مياندشت", 19 },
                    { 628, new Guid("f6e8ea5d-f2cd-4b27-bff6-115a8c7d2f60"), "بهارستان", 19 },
                    { 627, new Guid("0c9793bb-9eef-46f7-beec-2efd77427809"), "بهاران شهر", 19 },
                    { 626, new Guid("77fe6a34-6097-44b1-95f4-89f70a95d74e"), "برف انبار", 19 },
                    { 625, new Guid("da9fce53-710e-49b0-a137-f5d8249ed1e5"), "برزک", 19 },
                    { 624, new Guid("35e6ac28-6fbb-40bb-b7a8-91068d7f57b8"), "بافران", 19 },
                    { 631, new Guid("4bef14b3-7680-424a-8dc8-5abb4954efc1"), "تيران", 19 },
                    { 623, new Guid("6598d157-d95d-4ea9-bc29-44178ed6efe2"), "باغشاد", 19 },
                    { 621, new Guid("23461ce7-275d-41dd-a7f6-fe08fd303836"), "بادرود", 19 },
                    { 620, new Guid("c5b70403-8c91-48bb-8957-c72a9befa278"), "اژيه", 19 },
                    { 619, new Guid("6cbc7a67-3eeb-4703-a2be-d04df3542614"), "ايمانشهر", 19 },
                    { 618, new Guid("6ef0b390-f414-44cd-80ea-f79028ef7bda"), "انارک", 19 },
                    { 617, new Guid("e4c5721a-76bf-4bb9-9fa2-e74bc0f926ef"), "افوس", 19 },
                    { 616, new Guid("c9aed348-567f-404e-a723-575ae0c63f2b"), "اصفهان", 19 },
                    { 615, new Guid("e35ded97-6230-49d0-81b3-6fe540ad5bd9"), "اصغرآباد", 19 },
                    { 622, new Guid("2be3cf61-98c3-4474-a91d-fe9f0484323e"), "باغ بهادران", 19 },
                    { 690, new Guid("68dab86f-3bc2-4b01-aced-c918735df6b7"), "نياسر", 19 },
                    { 632, new Guid("622dc8c8-c3c4-4165-b87f-537380ded719"), "جندق", 19 },
                    { 634, new Guid("1aae6a80-5311-4b00-babf-f61bbf05bfb9"), "جوشقان قالي", 19 },
                    { 650, new Guid("26b11bf3-3837-4652-afb3-3b21f793e8a9"), "ديزيچه", 19 },
                    { 649, new Guid("83eeba40-5706-457e-bdd0-2d92df3cf057"), "دولت آباد", 19 },
                    { 648, new Guid("97cca982-500b-4c68-a811-22b9cb46ec46"), "دهق", 19 },
                    { 647, new Guid("9bec66e2-43bb-4735-8c75-3928eb244ad8"), "دهاقان", 19 },
                    { 646, new Guid("72ed584b-436a-410f-983a-074967c44b52"), "دستگرد", 19 },
                    { 645, new Guid("233537d3-04df-424a-b9d0-0f7d4f7df807"), "درچه پياز", 19 },
                    { 644, new Guid("a32747a6-4553-442c-bf3c-605557a6c91d"), "دامنه", 19 },
                    { 633, new Guid("d542a6a3-0de0-4648-92e3-755f26c90055"), "جوزدان", 19 },
                    { 643, new Guid("18ed6bd9-596d-4c4c-a2d5-bd5e50152f6f"), "داران", 19 },
                    { 641, new Guid("a8e9a913-3908-4c6e-9805-983619b9d62c"), "خور", 19 },
                    { 640, new Guid("dcff0c4d-494f-4671-94c4-84f7afe2d016"), "خوانسار", 19 },
                    { 639, new Guid("6fde675d-f471-4242-8c30-f84ce0509471"), "خميني شهر", 19 },
                    { 638, new Guid("9359de8d-662c-495f-8abf-7b9d14010dbb"), "خالد آباد", 19 },
                    { 637, new Guid("e2cf2b27-a95f-4502-b6ff-550ab3f6c7ec"), "حنا", 19 },
                    { 636, new Guid("b3d8a0f6-3a25-4969-b3ce-c6330dfc8e69"), "حسن آباد", 19 },
                    { 635, new Guid("a0fea4eb-4544-417e-b437-b59f9285985f"), "حبيب آباد", 19 },
                    { 642, new Guid("8d502813-b51c-499b-8f70-254f76a333c8"), "خورزوق", 19 },
                    { 926, new Guid("0f57a71a-71e7-415f-8bb8-4f0abfb07479"), "مزايجان", 23 },
                    { 691, new Guid("c82fc8e0-65c6-4941-a424-eab0e4bba40d"), "نيک آباد", 19 },
                    { 693, new Guid("6c7b99cf-2a78-40eb-abac-de9c764a36ef"), "ورزنه", 19 },
                    { 748, new Guid("3b55acfd-dcbd-4da6-8714-b8528f56de93"), "باقرشهر", 21 },
                    { 747, new Guid("29c3a764-991c-4487-871b-d450dd11d277"), "باغستان", 21 },
                    { 746, new Guid("b6029f8c-2aba-4d81-82a3-c18e49e4e514"), "انديشه", 21 },
                    { 745, new Guid("da3fca7d-7980-4686-bb23-c38ce1a6d2f1"), "اسلامشهر", 21 },
                    { 744, new Guid("f1f129e4-c611-4671-b785-9fcc9c6cb9c3"), "ارجمند", 21 },
                    { 743, new Guid("be4693cd-6f52-46f3-86cf-27ac334d45cf"), "آبعلي", 21 },
                    { 742, new Guid("b7a6c0fe-ca1f-4348-aed9-bafb16fdb560"), "آبسرد", 21 },
                    { 741, new Guid("495f72f2-78a2-4b03-b5e0-ffa9cd24dbb9"), "چوار", 20 },
                    { 740, new Guid("2a6fda9e-dee3-4b6f-9b3e-d48b30fe5221"), "پهله", 20 },
                    { 739, new Guid("c05000a4-d928-49aa-98fe-9eab7a8766da"), "ميمه", 20 },
                    { 738, new Guid("263f6825-4991-4397-83ea-c409159a54d3"), "موسيان", 20 },
                    { 737, new Guid("88236ad3-1198-4818-8a5f-b1f2e17d847e"), "مورموري", 20 },
                    { 736, new Guid("c50fe88e-a777-4992-a881-2dc4faff1ad4"), "مهران", 20 },
                    { 735, new Guid("aea3a53a-b5e4-44b7-9241-f0420c6b377c"), "مهر", 20 },
                    { 734, new Guid("797fac08-5cfa-4e3b-bcf1-4a1ce32d97f8"), "ماژين", 20 },
                    { 749, new Guid("665520a8-69ae-4d97-b1d3-f89a632a2df8"), "بومهن", 21 },
                    { 750, new Guid("774d826a-ebe2-4e82-be12-c457c11494dc"), "تجريش", 21 },
                    { 751, new Guid("57c990a7-fc3c-4e4e-8b27-98292d113343"), "تهران", 21 },
                    { 752, new Guid("9a11cfee-c04c-43be-8a63-155125ff0dc4"), "جواد آباد", 21 },
                    { 768, new Guid("8636631d-1e82-4d46-8955-5b77bf5c7671"), "فشم", 21 },
                    { 767, new Guid("10b32aad-b3c2-47e4-8714-79c41b5c620a"), "فرون آباد", 21 },
                    { 766, new Guid("752aaa25-c9bc-4ea0-b24b-4149eaa172f7"), "فردوسيه", 21 },
                    { 765, new Guid("613e96c2-9114-470b-b504-40393a9309d4"), "صفادشت", 21 },
                    { 764, new Guid("b9606cf3-e3a1-4017-be21-7c269b16f59b"), "صبا شهر", 21 },
                    { 763, new Guid("34910a5a-20ec-44d3-89b5-6645627415c6"), "صالحيه", 21 },
                    { 762, new Guid("7794da15-405c-4393-ab9f-6bae7d1bb2b2"), "شهريار", 21 },
                    { 733, new Guid("edf52544-83b9-44d9-ac52-e58b3071f803"), "لومار", 20 },
                    { 761, new Guid("824bddf2-3335-44a4-8387-0a59c2952e85"), "شهر جديد پرند", 21 },
                    { 759, new Guid("3d4763d1-c846-4605-96ad-3359f7d8de8d"), "شريف آباد", 21 },
                    { 758, new Guid("29b6f117-bca2-45f7-a31b-d37a2b6e1188"), "شاهدشهر", 21 },
                    { 757, new Guid("8b4312b2-abf6-4f6d-8e86-a0af60159078"), "ري", 21 },
                    { 756, new Guid("7abc8a2c-e880-4d28-9653-862b7100e970"), "رودهن", 21 },
                    { 755, new Guid("cc74fe0c-7a59-4816-aae8-0a34fe748bb0"), "رباط کريم", 21 },
                    { 754, new Guid("cabfb0bf-926b-41ba-94f3-fe918df9fed9"), "دماوند", 21 },
                    { 753, new Guid("fdc5c601-ac52-4313-a76b-22d7accdee72"), "حسن آباد", 21 },
                    { 760, new Guid("25fa198e-b0c9-4dcb-8d9f-9e33c540c122"), "شمشک", 21 },
                    { 732, new Guid("beeaddad-f530-465e-9500-88bfadd17f67"), "صالح آباد", 20 },
                    { 731, new Guid("19b7e705-261e-4e3a-abcc-faffeb46931a"), "شباب", 20 },
                    { 730, new Guid("0dd680b0-f683-419a-a8c0-a9b0265f2783"), "سرابله", 20 },
                    { 709, new Guid("024db787-664a-45cd-8f24-5750a75aa189"), "کوهپايه", 19 },
                    { 708, new Guid("7217ee96-f84c-4d98-9ee5-a7ff8c1fda04"), "کوشک", 19 },
                    { 707, new Guid("91b17aca-d454-47be-a887-b72f147faff9"), "کهريزسنگ", 19 },
                    { 706, new Guid("944a7bac-cb87-42bc-b524-2a5b6faa61f1"), "کمه", 19 },
                    { 705, new Guid("a218963a-937d-4bd5-b445-2d0c9f6755a8"), "کمشجه", 19 },
                    { 704, new Guid("f20ff5c1-0483-4721-b46c-f8637653e638"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("cd1e692a-e3ae-4175-8577-523ccca69ee0"), "کرکوند", 19 },
                    { 710, new Guid("a19c9eb5-4739-4b02-aef4-79f040d236ec"), "گرگاب", 19 },
                    { 702, new Guid("ba54b1bc-378d-4a61-8662-94b296970704"), "کامو و چوگان", 19 },
                    { 700, new Guid("4c011737-4bca-432d-9afa-ad0835eee6e4"), "چمگردان", 19 },
                    { 699, new Guid("a4d7b3d9-d54c-42ba-a96d-bc75a04c626a"), "چرمهين", 19 },
                    { 698, new Guid("0f683531-b56e-4348-810c-45faaa6ce9fb"), "چادگان", 19 },
                    { 697, new Guid("e074ba7f-f9f4-400c-8934-397b75300545"), "پير بکران", 19 },
                    { 696, new Guid("52a811fc-92c7-4fa5-8df0-a47468e7d7fc"), "ونک", 19 },
                    { 695, new Guid("4b78e3f2-ee52-44fc-b468-067c85d17922"), "وزوان", 19 },
                    { 694, new Guid("3450b5f3-e977-4289-b6ee-42b217b9a263"), "ورنامخواست", 19 },
                    { 701, new Guid("e64866c2-bbc5-4f57-960e-7e91b52d026a"), "کاشان", 19 },
                    { 692, new Guid("afde16fd-af9e-48b4-b4a5-91035fcf469c"), "هرند", 19 },
                    { 711, new Guid("b4dcfbd1-2d7d-4f0d-8f12-99c616fef1a7"), "گز برخوار", 19 },
                    { 713, new Guid("28b84a64-95ab-4d25-bca7-9cc05f4f45af"), "گلشن", 19 },
                    { 729, new Guid("8ec9bed7-2550-41e9-aaa2-299a756bcf50"), "سراب باغ", 20 },
                    { 728, new Guid("e47c6fdb-f492-4e2c-b90e-1ffb9df7ce65"), "زرنه", 20 },
                    { 727, new Guid("2d2e49f4-425c-477e-898a-468d42360b4f"), "دهلران", 20 },
                    { 726, new Guid("90d02b42-1dd4-4a66-b428-bbd517f0d170"), "دلگشا", 20 },
                    { 725, new Guid("f04407a5-2a0c-4ff4-a434-dde87dd0a332"), "دره شهر", 20 },
                    { 724, new Guid("f50f8b7c-9da3-4974-a1aa-13b4b1e53664"), "توحيد", 20 },
                    { 723, new Guid("d7aca44d-6412-4382-974a-b07878b36a97"), "بلاوه", 20 },
                    { 712, new Guid("b74d80f1-fa17-4f15-9a0f-84d36c974c53"), "گلدشت", 19 },
                    { 722, new Guid("4aeff63e-8e9d-4c09-b561-2c84b0802556"), "بدره", 20 },
                    { 720, new Guid("0db5e68b-65cd-4ec7-858e-0f22127cf75b"), "ايلام", 20 },
                    { 719, new Guid("20ecfd3b-2443-4442-93e6-6dfa90b2f851"), "ارکواز", 20 },
                    { 718, new Guid("314f715b-85ba-4111-94f2-9f9e3828438b"), "آسمان آباد", 20 },
                    { 717, new Guid("a17dc1c4-7c32-4267-b859-a59a8a9ad2aa"), "آبدانان", 20 },
                    { 716, new Guid("152f0bb6-c36c-43a8-b631-9cece2258231"), "گوگد", 19 },
                    { 715, new Guid("60a33929-4697-4529-ab9d-74940c16ee8e"), "گلپايگان", 19 },
                    { 714, new Guid("107d7c9f-d29b-41cd-bf23-8b2da0ebc896"), "گلشهر", 19 },
                    { 721, new Guid("364f115d-02e1-416b-acd3-f112b2b46cf3"), "ايوان", 20 },
                    { 927, new Guid("fe4a3661-fc1d-4588-8ecf-319b0d977c18"), "مشکان", 23 },
                    { 928, new Guid("301cdad6-2a14-4a20-82ee-8a349a5aa614"), "مصيري", 23 },
                    { 929, new Guid("34a1438d-35a9-4261-8e61-c9db409684c7"), "مهر", 23 },
                    { 1141, new Guid("6ee43c07-7a47-42de-b9a5-4a4436ad0972"), "بردسير", 29 },
                    { 1140, new Guid("e91695b6-511c-44f7-a47d-d1c4510530ff"), "بافت", 29 },
                    { 1139, new Guid("b47d52dc-a44e-438b-9228-60f32c525703"), "باغين", 29 },
                    { 1138, new Guid("ca272224-efed-49aa-ab76-85ec179ee032"), "اندوهجرد", 29 },
                    { 1137, new Guid("c63cb144-f264-487e-a462-a66d2ce97b5d"), "انار", 29 },
                    { 1136, new Guid("7bbd9f84-24e6-40a6-bd58-d558403f8ee5"), "امين شهر", 29 },
                    { 1135, new Guid("73848377-107f-4f98-b652-d263035764a9"), "ارزوئيه", 29 },
                    { 1134, new Guid("98f9dc4a-9e39-49ad-9bfb-096c140bd910"), "اختيار آباد", 29 },
                    { 1133, new Guid("03a3a834-7566-428c-8ffd-34ef8cac3a92"), "گيان", 28 },
                    { 1132, new Guid("6c41d419-6926-4072-8a26-7af6d66b4d0c"), "گل تپه", 28 },
                    { 1131, new Guid("eb61307d-c8a3-4c65-9be2-902c454d0fd2"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("90cb3270-8088-4db9-b844-5e1a0bde87e8"), "همدان", 28 },
                    { 1129, new Guid("4cc79f95-1a3a-4ac1-92b2-b58395a6f826"), "نهاوند", 28 },
                    { 1128, new Guid("0195370e-ee02-438e-8ec9-ff11822a8c8b"), "مهاجران", 28 },
                    { 1127, new Guid("6660b819-f2b1-409f-bb55-1adf8c3e9b5e"), "ملاير", 28 },
                    { 1142, new Guid("d85819ec-8f44-4b57-b51f-ba2171523308"), "بروات", 29 },
                    { 1143, new Guid("f48483c9-d747-4ac3-bbb6-4ecd2495be51"), "بزنجان", 29 },
                    { 1144, new Guid("d3cde7c0-8f10-4e0c-bc68-b0bbfc0e69e4"), "بلورد", 29 },
                    { 1145, new Guid("66e39c66-5611-47b1-99f7-75a5beeb2a6f"), "بلوک", 29 },
                    { 1161, new Guid("b6d73b8f-3544-4fb6-9abb-8904875d91ea"), "راور", 29 },
                    { 1160, new Guid("4680020b-7cf4-4f34-8370-40f52114a569"), "رابر", 29 },
                    { 1159, new Guid("a7f6e574-f105-49e4-8a5f-066928e4a000"), "دوساري", 29 },
                    { 1158, new Guid("4491ea1d-ce73-4317-88a2-4ecca9e78fe7"), "دهج", 29 },
                    { 1157, new Guid("1e8f4423-7112-4d88-aaf2-e76f12cffc25"), "دشتکار", 29 },
                    { 1156, new Guid("0b2449a6-7b01-41d8-a2ff-dea361bc5162"), "درب بهشت", 29 },
                    { 1155, new Guid("2e53fc03-38b3-4aeb-9c22-4c71aa07b312"), "خورسند", 29 },
                    { 1126, new Guid("475dda53-b7ff-45c0-885a-80ade8a1e7cb"), "مريانج", 28 },
                    { 1154, new Guid("c3c25440-e5af-4208-953a-952406359ab1"), "خواجوشهر", 29 },
                    { 1152, new Guid("b792345f-6c9f-4e4a-acd8-70bb105e6b03"), "خاتون آباد", 29 },
                    { 1151, new Guid("8bfa4109-55a3-4ab6-807a-1157708fdf54"), "جيرفت", 29 },
                    { 1150, new Guid("7814fd8d-0287-426c-b18a-acd82f3eb583"), "جوپار", 29 },
                    { 1149, new Guid("f397ccae-3df9-4920-a738-b194d530fd59"), "جوزم", 29 },
                    { 1148, new Guid("448ac33b-a928-446e-b7de-ef5a96bda9f1"), "جبالبارز", 29 },
                    { 1147, new Guid("c1a31f4c-a55a-4466-84ea-790db14bb2e0"), "بهرمان", 29 },
                    { 1146, new Guid("e92a4e4a-fe89-49e8-ad6a-a8883c5a95a5"), "بم", 29 },
                    { 1153, new Guid("cf430b91-4af7-4d46-9dc3-06c7c485e8c1"), "خانوک", 29 },
                    { 1162, new Guid("cf29a67d-74f5-4677-988e-88d741031c02"), "راين", 29 },
                    { 1125, new Guid("a0b3c6be-f602-408c-a216-6b907b46dcec"), "لالجين", 28 },
                    { 1123, new Guid("0b83a297-a102-451a-8cc8-223c9367de4e"), "قروه در جزين", 28 },
                    { 1102, new Guid("d82cbd04-a64d-4bad-bee2-0566c80b4579"), "کوچصفهان", 27 },
                    { 1101, new Guid("da43a87b-7ce3-460a-af2c-cc635c474c03"), "کومله", 27 },
                    { 1100, new Guid("431b44b8-4331-42ab-b591-67eb5bdaec35"), "کلاچاي", 27 },
                    { 1099, new Guid("a42b86f0-ae4b-452f-aa77-27eb7173ec2a"), "چوبر", 27 },
                    { 1098, new Guid("70720d71-533e-48b2-aa63-cc290866ec9e"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("286b2ba1-c178-49b1-aa40-d21b11b4b23d"), "چابکسر", 27 },
                    { 1096, new Guid("a1f79771-dad8-48c8-9aee-0e2a2fe97f6c"), "پره سر", 27 },
                    { 1095, new Guid("619dfbbb-c091-4c3d-a6d7-daf4d266da18"), "واجارگاه", 27 },
                    { 1094, new Guid("9ccab9a1-f86b-48fd-8dd0-9ba5cbcf9870"), "هشتپر", 27 },
                    { 1093, new Guid("bfad1b3a-b50e-4cd1-9aea-523c62e9db07"), "منجيل", 27 },
                    { 1092, new Guid("b2d58a93-b7c2-4694-850b-dc8f8e357901"), "مرجقل", 27 },
                    { 1091, new Guid("ab3929ad-7c0e-45e9-81db-f4263680699e"), "ماکلوان", 27 },
                    { 1090, new Guid("5da9a1fd-2849-4b75-b116-460556f0cf08"), "ماسوله", 27 },
                    { 1089, new Guid("e163645a-7611-43cb-95a8-eb176f2065ed"), "ماسال", 27 },
                    { 1088, new Guid("25acd50b-c5f1-4b95-9278-8e0abb44e680"), "ليسار", 27 },
                    { 1103, new Guid("ed0854df-ba22-4b63-82ab-90e3490a40c6"), "کياشهر", 27 },
                    { 1104, new Guid("bf403548-a017-426a-a25c-d9af04e74a88"), "گوراب زرميخ", 27 },
                    { 1105, new Guid("37da4e5e-c92d-44a3-a301-8785514ac23b"), "آجين", 28 },
                    { 1106, new Guid("c0ddb53d-f228-44b7-865e-e6c09a562db0"), "ازندريان", 28 },
                    { 1122, new Guid("839a1463-11bc-4c8b-8a27-2824edf9e77f"), "فيروزان", 28 },
                    { 1121, new Guid("b98652b8-7edb-4eda-88fe-251a35f8df7b"), "فرسفج", 28 },
                    { 1120, new Guid("4f2e00b8-7087-4531-9209-e8cd0937b58e"), "فامنين", 28 },
                    { 1119, new Guid("70c484ae-8334-4ddf-9edf-3203405e6030"), "صالح آباد", 28 },
                    { 1118, new Guid("f6561f38-52c4-4480-9b65-362010a4764c"), "شيرين سو", 28 },
                    { 1117, new Guid("b64e3036-077e-4eea-abfa-7f03a582efb5"), "سرکان", 28 },
                    { 1116, new Guid("935494b9-2c1f-483a-aa1c-27e465a58942"), "سامن", 28 },
                    { 1124, new Guid("ecb00b75-7818-4102-9f96-5a6ca8b09dc6"), "قهاوند", 28 },
                    { 1115, new Guid("3bdb69fd-a33c-42ec-9620-2923f72cce85"), "زنگنه", 28 },
                    { 1113, new Guid("805e13c0-06fe-4e04-b4e4-d82ff94394c3"), "دمق", 28 },
                    { 1112, new Guid("68eb0a60-bf03-48e8-8251-101cec9a71e7"), "جوکار", 28 },
                    { 1111, new Guid("96ae18e6-7fb4-4f31-8dd0-5edc9d53bbc7"), "جورقان", 28 },
                    { 1110, new Guid("2697989a-c070-4ad6-b152-3b564da153cd"), "تويسرکان", 28 },
                    { 1109, new Guid("e2d2cd4b-3000-4ccf-8f7f-c02b2846df43"), "بهار", 28 },
                    { 1108, new Guid("4a395106-4dbb-459a-95e3-b7c14c898954"), "برزول", 28 },
                    { 1107, new Guid("e1cf4073-7087-4725-ab52-ada4c468e239"), "اسد آباد", 28 },
                    { 1114, new Guid("9ab3dcba-2dcd-4520-b844-f1f68acf038b"), "رزن", 28 },
                    { 1163, new Guid("1832b406-3a02-491a-89f1-80dcd0212b39"), "رفسنجان", 29 },
                    { 1164, new Guid("bf280ca9-20ab-4742-ba34-5db313306b58"), "رودبار", 29 },
                    { 1165, new Guid("b05adcfc-6097-44f3-bd96-697ba4d7b835"), "ريحان", 29 },
                    { 1220, new Guid("077610d5-0c6f-44f0-8d7f-f3480d7c4414"), "ميامي", 30 },
                    { 1219, new Guid("3ee7f76d-1669-4ac3-8571-35c6b5208b2f"), "مهدي شهر", 30 },
                    { 1218, new Guid("2e6ce902-32d0-4bee-b714-88aeaf48e548"), "مجن", 30 },
                    { 1217, new Guid("b5260655-5e00-4f7f-821a-731b056d12b6"), "شهميرزاد", 30 },
                    { 1216, new Guid("e19ecb03-15a3-4305-b9d0-b9714117dc45"), "شاهرود", 30 },
                    { 1215, new Guid("cf2a5e56-d6dd-493c-9f8a-978d4772aeb3"), "سمنان", 30 },
                    { 1214, new Guid("6ae757dc-5336-48a6-b1e3-904a3cd4ddc8"), "سرخه", 30 },
                    { 1213, new Guid("9321c230-ddb8-4c69-849f-f8a272e1bfc0"), "روديان", 30 },
                    { 1212, new Guid("58ada605-9ce4-4cee-ad23-b810f9508dcb"), "ديباج", 30 },
                    { 1211, new Guid("70576daf-44df-44b8-9c35-d3ed6baf543e"), "درجزين", 30 },
                    { 1210, new Guid("cc3155dc-6d81-4d8a-9e42-1607e4cb2c92"), "دامغان", 30 },
                    { 1209, new Guid("66181ba2-d70d-4497-a50f-7b4cf13673f1"), "بيارجمند", 30 },
                    { 1208, new Guid("4361d114-c62e-4026-9d14-4a070d034f93"), "بسطام", 30 },
                    { 1207, new Guid("821f8da3-0a71-4364-9f01-29cd92d753d3"), "ايوانکي", 30 },
                    { 1206, new Guid("49a2e437-2cc4-4fe3-8a84-60f65a7360fa"), "اميريه", 30 },
                    { 1221, new Guid("7b5f7aef-ff62-49ee-8c5d-0cc25915300e"), "کلاته", 30 },
                    { 1222, new Guid("62b85308-2459-47ce-8ef0-af5686c4e469"), "کلاته خيج", 30 },
                    { 1223, new Guid("15b6a5c7-ee1d-4423-8a54-1a8971babac2"), "کهن آباد", 30 },
                    { 1224, new Guid("48397b96-e825-467b-87a7-f34147af4ed6"), "گرمسار", 30 },
                    { 1240, new Guid("93a2c5aa-6e84-428d-a95a-6d6b07e6f712"), "چيتاب", 31 },
                    { 1239, new Guid("ebdc64da-82f3-4b73-93ef-248e9d1dbfbc"), "چرام", 31 },
                    { 1238, new Guid("bcf8bbf4-eab6-435a-91a0-76380a8e7c62"), "پاتاوه", 31 },
                    { 1237, new Guid("077da544-95a6-4228-9fa0-34240a3bfd6f"), "ياسوج", 31 },
                    { 1236, new Guid("71596995-68fe-4c99-8cf7-d374baa276b8"), "مارگون", 31 },
                    { 1235, new Guid("db7f5c7d-f383-4e80-840d-113fb63564fd"), "مادوان", 31 },
                    { 1234, new Guid("76f40d84-5e19-4878-9d63-6a0d631b4b2b"), "ليکک", 31 },
                    { 1205, new Guid("04c369a9-10b8-4fbe-bfe5-3e6ec21416c2"), "آرادان", 30 },
                    { 1233, new Guid("45773748-cdf0-4078-b8b3-1bf63b6840da"), "لنده", 31 },
                    { 1231, new Guid("06fc8ec3-659d-42b7-9eae-eb93f1a44e41"), "سي سخت", 31 },
                    { 1230, new Guid("f7be7bd3-0543-452d-91a2-b3758e9dad3b"), "سوق", 31 },
                    { 1229, new Guid("7cf74731-2a63-4a22-8b7a-eef3c3ff88c7"), "سرفارياب", 31 },
                    { 1228, new Guid("68637465-dae2-471f-b7ea-afc0b16c1e1c"), "ديشموک", 31 },
                    { 1227, new Guid("09357f0a-31d5-4a35-ac4a-6f2e770f1858"), "دوگنبدان", 31 },
                    { 1226, new Guid("2565fb19-6c81-4606-a1a1-b5c9e43608ad"), "دهدشت", 31 },
                    { 1225, new Guid("efa7869e-3e42-4276-b5a6-5a56812ca5ca"), "باشت", 31 },
                    { 1232, new Guid("dc67686c-d5c1-4d6b-845f-e7e725941cb2"), "قلعه رئيسي", 31 },
                    { 1204, new Guid("d093aab9-602b-4c86-a051-473bb1e91215"), "گنبکي", 29 },
                    { 1203, new Guid("aa371d2a-74d4-49b5-b852-e02564b5f973"), "گلزار", 29 },
                    { 1202, new Guid("fedec3a8-9f0f-457c-b95f-31dd3525e396"), "گلباف", 29 },
                    { 1181, new Guid("62c8a454-b2fb-4b3e-b065-61e690ed81c0"), "محي آباد", 29 },
                    { 1180, new Guid("b6280668-5b93-4612-a165-4e0df832ddc2"), "محمد آباد", 29 },
                    { 1179, new Guid("71ab2795-5153-4904-ad60-bfabbdbe0d5d"), "ماهان", 29 },
                    { 1178, new Guid("3b124d86-4471-428c-ad99-efd25665509c"), "لاله زار", 29 },
                    { 1177, new Guid("0e3804fc-68fa-48ec-97d0-6f3240614d0d"), "قلعه گنج", 29 },
                    { 1176, new Guid("b5ec7aa0-a3a2-4d7d-98d3-f6f502a525ba"), "فهرج", 29 },
                    { 1175, new Guid("96489454-a02f-4532-a727-42cca3c21675"), "فارياب", 29 },
                    { 1182, new Guid("d27a65bd-36ad-429f-8677-afb1b52892b6"), "مردهک", 29 },
                    { 1174, new Guid("8e16b5c9-0be0-45fd-aae2-08b24674f2b7"), "عنبر آباد", 29 },
                    { 1172, new Guid("31b718ae-4649-4bf1-b341-3a0561e1c9a9"), "شهر بابک", 29 },
                    { 1171, new Guid("08ba4bd3-ec48-442d-8d40-b90b442b0e56"), "شهداد", 29 },
                    { 1170, new Guid("a6884f7b-8c0f-448d-8d40-6b84fb079640"), "سيرجان", 29 },
                    { 1169, new Guid("59f0ce5a-71ab-435f-94f9-c5a327f97136"), "زيد آباد", 29 },
                    { 1168, new Guid("21c67878-26dc-47d8-b502-a486dee7c893"), "زهکلوت", 29 },
                    { 1167, new Guid("4ec0badf-95e3-496e-9057-017e8476eb92"), "زنگي آباد", 29 },
                    { 1166, new Guid("ae30e11b-9552-4afa-9b29-a004a3940d7e"), "زرند", 29 },
                    { 1173, new Guid("00fe82ae-009e-41b7-9d36-b2183b73f886"), "صفائيه", 29 },
                    { 1087, new Guid("233753e7-a494-4837-afde-333c92951d06"), "لوندويل", 27 },
                    { 1183, new Guid("3893f68c-4ae0-4910-b9af-661f7b448a8f"), "مس سرچشمه", 29 },
                    { 1185, new Guid("47ee56ae-e178-4c86-9a56-cbde20ab390a"), "نجف شهر", 29 },
                    { 1201, new Guid("f8254934-3f88-4c79-9da7-39338df96bc0"), "کيانشهر", 29 },
                    { 1200, new Guid("b3552ee0-2a82-47ab-9fae-48a8e6c5ba23"), "کوهبنان", 29 },
                    { 1199, new Guid("85abd607-f15f-41f8-90fb-4905d6af2580"), "کهنوج", 29 },
                    { 1198, new Guid("b0b13e0b-00ff-4bf1-8b4a-21fe958a7a70"), "کشکوئيه", 29 },
                    { 1197, new Guid("597161e1-8c6b-4f13-a3be-95170af21671"), "کرمان", 29 },
                    { 1196, new Guid("137d6685-6497-447f-bbd5-ae304984ca20"), "کاظم آباد", 29 },
                    { 1195, new Guid("a54099a4-5e5f-416a-b13c-4df1586b6a2f"), "چترود", 29 },
                    { 1184, new Guid("fdae8613-1ed3-438c-9505-80ee07b2f8b1"), "منوجان", 29 },
                    { 1194, new Guid("9eba4c2a-af69-4e49-967b-74e53ddbf215"), "پاريز", 29 },
                    { 1192, new Guid("344f5349-8832-471c-9c99-e79c75ae9cde"), "هنزا", 29 },
                    { 1191, new Guid("bc4c2b23-46d0-4a45-8519-def742d0ac06"), "هماشهر", 29 },
                    { 1190, new Guid("b1f1d6f4-fcfc-4ecd-bbe8-aa1f88986615"), "هجدک", 29 },
                    { 1189, new Guid("1e265a3a-5744-4719-ba65-866b2f808af7"), "نگار", 29 },
                    { 1188, new Guid("3c9fb622-2c1c-4336-8933-2e46b6a95bac"), "نودژ", 29 },
                    { 1187, new Guid("5b4a3721-9d88-49fa-bb5a-84c736c7e7ea"), "نظام شهر", 29 },
                    { 1186, new Guid("92be0c5d-f48d-48fa-a8ea-26358fc069e7"), "نرماشير", 29 },
                    { 1193, new Guid("b9eba4d3-974d-4469-91c4-9690fc0b5d76"), "يزدان شهر", 29 },
                    { 1086, new Guid("f1860c99-5988-485c-8c60-1c8a12a3e809"), "لولمان", 27 },
                    { 1085, new Guid("2e248f1a-d5f3-4bbe-9cac-51002a835c38"), "لوشان", 27 },
                    { 1084, new Guid("e7e0f0dd-be6c-422d-a2b9-f33e9870476c"), "لنگرود", 27 },
                    { 984, new Guid("b0160dfc-a4bc-4a15-be2f-17ca5040551d"), "بندر عباس", 25 },
                    { 983, new Guid("e938023c-9613-47ec-90f7-92df8cf17586"), "بندر جاسک", 25 },
                    { 982, new Guid("49af67f5-5813-4ba2-b2a7-9155660f94e1"), "بستک", 25 },
                    { 981, new Guid("31203707-977f-4c92-babe-204258c165ca"), "ابوموسي", 25 },
                    { 980, new Guid("53aff039-0bb3-4fbd-8a71-9a616441430b"), "گيلانغرب", 24 },
                    { 979, new Guid("b8931a47-3633-4478-a75b-3cd5f6399452"), "گودين", 24 },
                    { 978, new Guid("25cb2a77-d86a-49ec-aba7-69d7ed0a0c0d"), "گهواره", 24 },
                    { 977, new Guid("6de7f5ec-8398-4af1-a38a-230f4371902d"), "کوزران", 24 },
                    { 976, new Guid("82579d6a-99d9-4f5a-b9ff-a0a6166d2ec0"), "کنگاور", 24 },
                    { 975, new Guid("f488997f-342c-4103-8a53-e264dfc4df45"), "کرند غرب", 24 },
                    { 974, new Guid("cc778309-7cad-49a1-a434-1ef0ba700a93"), "کرمانشاه", 24 },
                    { 973, new Guid("385f5031-b46f-43c2-abca-e305051ec450"), "پاوه", 24 },
                    { 972, new Guid("f0d9896c-1b07-470c-ab6f-cd8e1db7c57b"), "هلشي", 24 },
                    { 971, new Guid("368f2f12-a9b4-4797-88c3-db181679f0d5"), "هرسين", 24 },
                    { 970, new Guid("2b5f0db3-ecc3-45ae-bd47-cfe442b393de"), "نوسود", 24 },
                    { 985, new Guid("aff037ea-b7be-42c1-aee5-994eb8f7cbc3"), "بندر لنگه", 25 },
                    { 986, new Guid("6dc4b43b-433e-4636-af7d-066079c5d638"), "بيکاه", 25 },
                    { 987, new Guid("6d3034f4-fcb6-4a84-b047-6f32cb54e4ec"), "تازيان پائين", 25 },
                    { 988, new Guid("e4ac7c99-d597-4633-9a3c-dd812161fc5d"), "تخت", 25 },
                    { 1004, new Guid("305c7767-f68e-499d-a8f0-6ba46d19704d"), "فين", 25 },
                    { 1003, new Guid("21191b48-0d83-42c4-8919-706d5ca91649"), "فارغان", 25 },
                    { 1002, new Guid("84487f17-b0c1-4131-bfd3-297811927196"), "سيريک", 25 },
                    { 1001, new Guid("32087305-fe2f-417c-9a58-93fda55795c6"), "سوزا", 25 },
                    { 1000, new Guid("7cf1b5b2-4c1f-4a8e-b17c-fa4e206d3d42"), "سندرک", 25 },
                    { 999, new Guid("5198f674-3f46-4be7-809f-91634b9fe00a"), "سرگز", 25 },
                    { 998, new Guid("dc989c14-269f-4488-aee9-5d6c86adddbc"), "سردشت", 25 },
                    { 969, new Guid("16f23f83-3d71-44cf-b9e0-ccb7382cf945"), "نودشه", 24 },
                    { 997, new Guid("472f0d48-4280-41f6-90d7-00c46ac767af"), "زيارتعلي", 25 },
                    { 995, new Guid("71229c43-0623-4083-bfae-f2c749c17570"), "دهبارز", 25 },
                    { 994, new Guid("e02ae3a3-3e5d-439b-8154-59660d991067"), "دشتي", 25 },
                    { 993, new Guid("a7d30789-c1b0-4278-905d-b5abd1a0c7b3"), "درگهان", 25 },
                    { 992, new Guid("4d8feff6-7b3d-489d-a526-0bbd794e5227"), "خمير", 25 },
                    { 991, new Guid("6207ccde-bfbc-409b-ae61-5322b216580a"), "حاجي آباد", 25 },
                    { 990, new Guid("83278733-ad31-470f-88d8-52d71d2cdd47"), "جناح", 25 },
                    { 989, new Guid("a18785d8-6173-453d-a7f3-80b8b36b0be0"), "تيرور", 25 },
                    { 996, new Guid("50909055-e1b5-469c-a090-6a4ed475c5da"), "رويدر", 25 },
                    { 968, new Guid("8ea5bdae-c0e6-464f-ab37-8896647008bd"), "ميان راهان", 24 },
                    { 967, new Guid("c7ed69fb-621a-476d-a09f-2082f3b60367"), "قصر شيرين", 24 },
                    { 966, new Guid("71a8f4e4-c31b-4678-b6d2-71c63a26a0da"), "صحنه", 24 },
                    { 945, new Guid("3c5ebf67-079a-4f37-8378-db39e31177c3"), "کوهنجان", 23 },
                    { 944, new Guid("22a18bd9-b914-46f3-bb48-069a0afca202"), "کوار", 23 },
                    { 943, new Guid("a874b34b-cc5a-4c1a-ab4b-35e8a86a118d"), "کنار تخته", 23 },
                    { 942, new Guid("0422f367-5e4c-4c75-87c4-a130478883a7"), "کره اي", 23 },
                    { 941, new Guid("07478c4f-e24e-4bd1-bb01-8377e4876b41"), "کامفيروز", 23 },
                    { 940, new Guid("1b79526f-0985-4785-90c2-cd477eb176fa"), "کازرون", 23 },
                    { 939, new Guid("39d91d51-334b-46ad-a3a1-2862b800373a"), "کارزين", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 946, new Guid("b729a4be-3248-4136-b98c-fb2255088258"), "کوپن", 23 },
                    { 938, new Guid("1aa76fcc-deb8-48fa-be96-4287b79fc92e"), "وراوي", 23 },
                    { 936, new Guid("98328a7e-ae62-4786-b90a-d9277a795bbd"), "ني ريز", 23 },
                    { 935, new Guid("f68f17eb-7a26-492f-a448-df8a12a98dbf"), "نورآباد", 23 },
                    { 934, new Guid("f0f66989-12a4-4233-9ff0-beb0c79b4a54"), "نودان", 23 },
                    { 933, new Guid("52414baf-fd84-4f76-886e-2ef820fa4ca5"), "نوجين", 23 },
                    { 932, new Guid("f103a61b-0bc3-4d4e-9c9e-a433ed13bf70"), "نوبندگان", 23 },
                    { 931, new Guid("dc25549c-a714-4e55-b354-393d973b8091"), "ميمند", 23 },
                    { 930, new Guid("48e33e3f-49be-4811-9bfd-a5f754d0219d"), "ميانشهر", 23 },
                    { 937, new Guid("d99fafc3-419c-4ec6-acd8-62562dc9df04"), "هماشهر", 23 },
                    { 1005, new Guid("671da058-8e8f-4455-962f-e086118964c2"), "قشم", 25 },
                    { 947, new Guid("4162e34f-4ae0-4406-b0e5-602349433fd6"), "گراش", 23 },
                    { 949, new Guid("009e4c5a-d29c-4800-96af-eef9fce7c787"), "ازگله", 24 },
                    { 965, new Guid("5207cc58-5e7a-46c6-ae39-647b212bc48b"), "شاهو", 24 },
                    { 964, new Guid("d340af64-a012-4adf-b017-00cc9576b9f2"), "سومار", 24 },
                    { 963, new Guid("c60484e0-8aa4-4fe9-b75a-b58a73915cd0"), "سنقر", 24 },
                    { 962, new Guid("40ca2dc6-0a1d-48cd-86ff-4ff73d9a55a1"), "سطر", 24 },
                    { 961, new Guid("47000760-ff23-4df8-8437-2bb64f884a02"), "سرمست", 24 },
                    { 960, new Guid("f419abfa-adbe-4345-906a-1d7a005bb8a1"), "سر پل ذهاب", 24 },
                    { 959, new Guid("f3063e22-5774-4ef9-be0c-75d542cbbec1"), "ريجاب", 24 },
                    { 948, new Guid("c75be56b-ef23-4b9c-ac44-8d17620ed17c"), "گله دار", 23 },
                    { 958, new Guid("9f8bd5b9-92e5-4c09-a7fa-361f060dfdd5"), "روانسر", 24 },
                    { 956, new Guid("4e0933ae-46c8-48e6-b5d7-ec8d3abca8a1"), "حميل", 24 },
                    { 955, new Guid("fef144c3-e93c-4a74-83a0-c46330f040a4"), "جوانرود", 24 },
                    { 954, new Guid("433bc5fb-ff56-4d59-8e7f-f1eb53b7e1a6"), "تازه آباد", 24 },
                    { 953, new Guid("753a452a-bacf-4cc6-a0a5-2224584d7b98"), "بيستون", 24 },
                    { 952, new Guid("d196f8b4-bf60-4dbd-aff5-47c96bcfa01c"), "باينگان", 24 },
                    { 951, new Guid("7fa32cd0-9cfe-4649-9c7a-16a8ddf0a030"), "بانوره", 24 },
                    { 950, new Guid("079e064d-d929-4b86-b438-528dd3045a5c"), "اسلام آباد غرب", 24 },
                    { 957, new Guid("afd410df-41a9-4ff9-8ab2-badaa06716fe"), "رباط", 24 },
                    { 614, new Guid("42786c17-6a07-4f62-8de6-db3e7c5d1993"), "اردستان", 19 },
                    { 1006, new Guid("6d9bd125-d696-4a22-a9e0-9e70d233dd3c"), "قلعه قاضي", 25 },
                    { 1008, new Guid("e0610c66-b2cd-4244-bb6b-d1ed32003e0f"), "ميناب", 25 },
                    { 1063, new Guid("48a359b3-f462-4464-a4a1-c002537fae9d"), "جيرنده", 27 },
                    { 1062, new Guid("3bfd44b6-3ac4-41fa-8594-55e0e5130d7e"), "توتکابن", 27 },
                    { 1061, new Guid("e94beb24-f0bc-4092-800d-658bd69762f5"), "بندر انزلي", 27 },
                    { 1060, new Guid("9083851c-c095-4d30-bb7d-89e49797ae6a"), "بره سر", 27 },
                    { 1059, new Guid("e8300b90-d8e6-4304-91a5-0987bdf7b353"), "بازار جمعه", 27 },
                    { 1058, new Guid("aa05149c-9f4c-4b36-8e5c-95e42f30e240"), "املش", 27 },
                    { 1057, new Guid("fb85d1fa-b394-4c28-b40e-f0f44ac8edb9"), "اطاقور", 27 },
                    { 1056, new Guid("33330dc6-1a01-486a-a4fd-8d64755ed0c4"), "اسالم", 27 },
                    { 1055, new Guid("f94efe71-c05c-48d3-943e-01536452acbf"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("350465bf-c51d-41da-b709-d672db802ae1"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("88122fd4-b7b5-4c9b-bf2f-b23ea6b6bce9"), "آستارا", 27 },
                    { 1052, new Guid("0aeab5f3-f5ce-4030-8d45-7945023ee6b9"), "کميجان", 26 },
                    { 1051, new Guid("5e03d17e-8c73-416a-be9f-ee01cade84c6"), "کارچان", 26 },
                    { 1050, new Guid("bcac6572-2259-43da-a224-066eafb2c53d"), "پرندک", 26 },
                    { 1049, new Guid("66829e0a-f680-4e0f-b830-fdddd9c4a18a"), "هندودر", 26 },
                    { 1064, new Guid("13587de5-5dc8-4728-b874-9eb8088283d4"), "حويق", 27 },
                    { 1065, new Guid("98d48e8b-3b5c-4014-b9dd-84f5c8495788"), "خشکبيجار", 27 },
                    { 1066, new Guid("cf1a62be-9d47-43fb-b5b4-6ee0dd5d342d"), "خمام", 27 },
                    { 1067, new Guid("3ea24e93-3744-4899-b563-5939264b532d"), "ديلمان", 27 },
                    { 1083, new Guid("8239e878-9b5c-42ab-a088-3ef353b39d86"), "لشت نشاء", 27 },
                    { 1082, new Guid("56294879-dd8b-453a-9c33-6c281751d6b6"), "لاهيجان", 27 },
                    { 1081, new Guid("6fd09374-9725-4981-8e1b-29f8569dc06f"), "فومن", 27 },
                    { 1080, new Guid("cada697c-db07-4156-b747-53b80849e023"), "صومعه سرا", 27 },
                    { 1079, new Guid("56829624-30cd-4dd8-9a30-3734db717294"), "شلمان", 27 },
                    { 1078, new Guid("c4d9b351-3930-4b30-b9fe-cfec0a9622a4"), "شفت", 27 },
                    { 1077, new Guid("50ce1e3c-f4bf-461b-b420-04dda3dd814d"), "سياهکل", 27 },
                    { 1048, new Guid("aa3a181a-cec5-4983-874c-7eab1f3b5973"), "نيمور", 26 },
                    { 1076, new Guid("945f4d6d-4818-4f11-b95f-0b5c9557fbdc"), "سنگر", 27 },
                    { 1074, new Guid("c762f20f-d0f5-4e3c-9c2c-0b831e5c32b5"), "رودبنه", 27 },
                    { 1073, new Guid("3c9494d2-d5fe-4e6a-8d6b-e88cf9a31e5e"), "رودبار", 27 },
                    { 1072, new Guid("2db0c874-a4fd-4fa0-a843-1cfc411247c3"), "رضوانشهر", 27 },
                    { 1071, new Guid("93b53f49-28bb-4f81-a08f-0250cfdf9730"), "رشت", 27 },
                    { 1070, new Guid("e76d33cb-e9d1-4497-b52c-239d3fcbeb2c"), "رستم آباد", 27 },
                    { 1069, new Guid("6e3f37cc-a8c4-4c6a-9d75-cb3921c25038"), "رحيم آباد", 27 },
                    { 1068, new Guid("d7a970bb-ec20-4ddf-abf2-4c4ec3b3f845"), "رانکوه", 27 },
                    { 1075, new Guid("651f55c9-b4e6-468a-bd97-2b2fb710719b"), "رودسر", 27 },
                    { 1047, new Guid("d035d2a3-25f3-4368-bb11-0a2e8548e436"), "نوبران", 26 },
                    { 1046, new Guid("57fc9d4f-c1b8-45ca-ba6e-e15e7684858d"), "نراق", 26 },
                    { 1045, new Guid("8ce67666-3971-4298-bd3e-11eb32e68cc9"), "ميلاجرد", 26 },
                    { 1024, new Guid("520cd506-32c2-4806-b63e-718c77f5d934"), "تفرش", 26 },
                    { 1023, new Guid("493fa48f-e67d-4405-b773-99bbaa34c559"), "اراک", 26 },
                    { 1022, new Guid("9fbfd01c-d7fc-428a-b207-7406722c14a5"), "آوه", 26 },
                    { 1021, new Guid("9c037501-76ec-47ad-85db-96067ca29419"), "آشتيان", 26 },
                    { 1020, new Guid("f3573813-2858-4b89-90c8-182dbf029663"), "آستانه", 26 },
                    { 1019, new Guid("4069ec7d-6745-494c-96ff-206c0566287a"), "گوهران", 25 },
                    { 1018, new Guid("5b696018-88b9-41db-bf56-4c54c264f3cf"), "گروک", 25 },
                    { 1025, new Guid("ceb9534b-94e1-4921-bd8a-917c1b0ea31f"), "توره", 26 },
                    { 1017, new Guid("184a77e3-d320-418e-9b51-e83b4ab51503"), "کيش", 25 },
                    { 1015, new Guid("e8d67063-5bab-45e8-b5cb-691388f4d009"), "کوشکنار", 25 },
                    { 1014, new Guid("d371e1d3-be33-4469-94a7-8758c5eaa64d"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("bd527361-68ed-42cc-abf1-d83b17f7090f"), "کنگ", 25 },
                    { 1012, new Guid("6cb4a30b-8f83-4b82-b029-0fe63aaac8ff"), "چارک", 25 },
                    { 1011, new Guid("ba618900-c665-442f-9f5c-1642b0f55645"), "پارسيان", 25 },
                    { 1010, new Guid("99497852-018d-4772-8d2a-9841b6b8c84c"), "هشتبندي", 25 },
                    { 1009, new Guid("4fe01490-04c0-44ae-97ae-8b1233ae35f6"), "هرمز", 25 },
                    { 1016, new Guid("5f6453db-4752-48a7-97bd-5c86a946ccd4"), "کوهستک", 25 },
                    { 1007, new Guid("a7e71c99-09d3-4d59-b354-927eca339d91"), "لمزان", 25 },
                    { 1026, new Guid("243cb38f-b5a1-4414-959e-0f51cf884ad2"), "جاورسيان", 26 },
                    { 1028, new Guid("e3d59f3e-474d-4805-bd24-ca79a5f8a0ea"), "خمين", 26 },
                    { 1044, new Guid("bd324536-2b23-48a7-9a67-52552ee556b2"), "محلات", 26 },
                    { 1043, new Guid("4c7f5c43-a5d5-48eb-9575-fd1d9561d4cb"), "مامونيه", 26 },
                    { 1042, new Guid("a37465fb-deae-4247-8109-e92402b2471c"), "قورچي باشي", 26 },
                    { 1041, new Guid("43990f7c-e33f-4af0-8ac1-8977fe3a94bf"), "فرمهين", 26 },
                    { 1040, new Guid("e2e5b19d-8795-4508-834e-969a447f8551"), "غرق آباد", 26 },
                    { 1039, new Guid("4309935d-0bcb-4f46-b148-571023e8a351"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("fac26b81-dfb8-4c4b-adae-2b98c520bb4c"), "شهباز", 26 },
                    { 1027, new Guid("3419736b-cc9b-4417-8331-b8932abb148d"), "خشکرود", 26 },
                    { 1037, new Guid("c0fb4af7-55a0-4263-842b-1e9bbdb827a8"), "شازند", 26 },
                    { 1035, new Guid("7a53cecb-925f-442b-b71e-bde099517b26"), "ساروق", 26 },
                    { 1034, new Guid("f29f34d4-5276-48ed-96f9-68851e982918"), "زاويه", 26 },
                    { 1033, new Guid("d156a766-e4d5-48e0-8533-e230ac6d4caf"), "رازقان", 26 },
                    { 1032, new Guid("dd1d257d-6d44-469e-b451-df3c19b75c4f"), "دليجان", 26 },
                    { 1031, new Guid("e639b29e-abc1-4e6e-a2c3-f34dbf323ddf"), "داود آباد", 26 },
                    { 1030, new Guid("d195e507-02d5-4923-9826-1a9547480607"), "خنداب", 26 },
                    { 1029, new Guid("3e27890d-846f-4909-bdac-2416bcdf75e2"), "خنجين", 26 },
                    { 1036, new Guid("21506912-621e-4ca5-b15b-6a3cd60933d5"), "ساوه", 26 },
                    { 613, new Guid("f0acf738-4372-486c-8140-8e20941b63ed"), "ابوزيد آباد", 19 },
                    { 612, new Guid("76aa2c48-494b-452d-ad03-e264a1a17d39"), "ابريشم", 19 },
                    { 611, new Guid("204f4751-4513-4de0-b17d-d91f11c4da04"), "آران و بيدگل", 19 },
                    { 207, new Guid("a1f4de67-fc24-4473-8762-49a698001ab9"), "سلامي", 8 },
                    { 206, new Guid("1af103e1-744f-4b3c-9140-40df127e685d"), "سفيد سنگ", 8 },
                    { 205, new Guid("8fc9141e-38c1-4e28-97e1-c06f575a47d0"), "سرخس", 8 },
                    { 204, new Guid("f6e3cdc4-ddb9-427d-bbe7-88a951b95af2"), "سبزوار", 8 },
                    { 203, new Guid("06f9ccc1-e07d-4eb3-a000-196feabcd2cb"), "ريوش", 8 },
                    { 202, new Guid("a62abf63-a09a-437c-8967-39e47db96503"), "روداب", 8 },
                    { 201, new Guid("baab40ee-5950-426e-bd68-527c9fda63a8"), "رضويه", 8 },
                    { 200, new Guid("980c38e6-956e-4269-a276-65fc89a1f1bf"), "رشتخوار", 8 },
                    { 199, new Guid("4c6de884-69df-461c-80a5-5138d5ae725f"), "رباط سنگ", 8 },
                    { 198, new Guid("8b643e39-d5d3-46c6-9d00-7f2063f44ae7"), "دولت آباد", 8 },
                    { 197, new Guid("1043b622-fc4b-47ec-b777-1cd5fa7134c2"), "درگز", 8 },
                    { 196, new Guid("4c9553a1-29e3-4785-983f-6e7aada0851d"), "درود", 8 },
                    { 195, new Guid("e58fade1-4307-4309-88a0-2df14f545a1c"), "داورزن", 8 },
                    { 194, new Guid("6ad8a39c-74a6-4526-882d-76e187a5df67"), "خواف", 8 },
                    { 193, new Guid("2c529867-d1a8-4583-b54b-8d9732892c92"), "خليل آباد", 8 },
                    { 208, new Guid("6f9bd62b-0636-477c-93db-477461d3f9d9"), "سلطان آباد", 8 },
                    { 192, new Guid("3f052af7-1c3d-4b23-b28e-0fa0aa78598c"), "خرو", 8 },
                    { 209, new Guid("4b56608d-51fc-4184-90ae-bb9a9ac8b875"), "سنگان", 8 },
                    { 211, new Guid("2d0be8cf-0f72-44e3-9ea9-69d180117cb1"), "شانديز", 8 },
                    { 226, new Guid("60e6b4da-355d-4b40-a612-544e92d63429"), "لطف آباد", 8 },
                    { 225, new Guid("fc35c2c8-0258-4da5-a699-b1df764d9b78"), "قوچان", 8 },
                    { 224, new Guid("ec659451-4433-4c45-825f-08244b083e0c"), "قلندر آباد", 8 },
                    { 223, new Guid("a2718bdb-bd38-4f38-b878-3fa84f801c68"), "قدمگاه", 8 },
                    { 222, new Guid("5d65cb51-33b5-4089-921f-801d4b264f5e"), "قاسم آباد", 8 },
                    { 221, new Guid("fc6a93b6-9905-450b-87bd-584e4106bac4"), "فيض آباد", 8 },
                    { 220, new Guid("bde989f2-3e68-4420-9494-aaaee05ec218"), "فيروزه", 8 },
                    { 219, new Guid("45a61087-9254-420b-b4b8-cef92ac4513a"), "فريمان", 8 },
                    { 218, new Guid("4773eeba-b40b-476e-90b1-e378f0f254c5"), "فرهاد گرد", 8 },
                    { 217, new Guid("a86bfe0d-9533-4a63-91bb-eded507ceb0a"), "عشق آباد", 8 },
                    { 216, new Guid("3267b2e3-0c58-4b15-8816-ef5c96a9740f"), "طرقبه", 8 },
                    { 215, new Guid("78873468-f8f4-410a-b80b-ee77c40ba593"), "صالح آباد", 8 },
                    { 214, new Guid("7bf7db82-64c1-4b5d-b9f0-61aa93343101"), "شهرآباد", 8 },
                    { 213, new Guid("6cef3c45-cf03-417d-b2df-c87f2499ab7d"), "شهر زو", 8 },
                    { 212, new Guid("57e76193-127e-4489-b552-d34dbbf0d27b"), "ششتمد", 8 },
                    { 210, new Guid("726eb08a-e0a5-4e12-8704-ead5d591a1c3"), "شادمهر", 8 },
                    { 227, new Guid("5e6b24d4-2d26-41f7-90d4-3f5bc27b75a0"), "مزدآوند", 8 },
                    { 191, new Guid("35a7e1e0-43c3-4a56-a560-c0462e2daa20"), "جنگل", 8 },
                    { 189, new Guid("c94bc7bb-88bb-43f9-a980-460f581c5d2a"), "تربت حيدريه", 8 },
                    { 169, new Guid("a76f813c-a07d-4672-a9ba-b062ca9acb53"), "نازک عليا", 7 },
                    { 168, new Guid("5f24b55e-84e3-4081-854f-a26180feff00"), "ميرآباد", 7 },
                    { 167, new Guid("137f6e2b-5fb4-4811-a0f5-e5805056bee0"), "مياندوآب", 7 },
                    { 166, new Guid("3bfc3c57-e933-4d9d-91d6-dadae4c20f6c"), "مهاباد", 7 },
                    { 165, new Guid("28f9eb88-e02c-4648-b003-20c50f7386cb"), "مرگنلر", 7 },
                    { 164, new Guid("28b3f939-0b64-4f32-9df9-c1622ba6041a"), "محمود آباد", 7 },
                    { 163, new Guid("e56e2027-5f40-4bdc-a33a-52bc614a1eef"), "محمد يار", 7 },
                    { 162, new Guid("ff974252-e397-4a2e-a3e3-8b9c1c13613b"), "ماکو", 7 },
                    { 161, new Guid("c91bd6f3-3bb8-4ed2-ad1c-2e190a882b5f"), "قوشچي", 7 },
                    { 160, new Guid("d068513f-0728-4e19-8893-8f11aa6601d8"), "قطور", 7 },
                    { 159, new Guid("63746dc5-7816-4505-b004-735c8a5acefb"), "قره ضياء الدين", 7 },
                    { 158, new Guid("013dfcad-7c09-4ced-bf61-c618ee5e9008"), "فيرورق", 7 },
                    { 157, new Guid("c0b833d7-16c3-46b4-a8c0-1dfefba92d4c"), "شوط", 7 },
                    { 156, new Guid("d0d4c9a8-6184-4b27-a005-849f12e48b0b"), "شاهين دژ", 7 },
                    { 155, new Guid("21b3f8cd-245c-47c0-9d1a-9a0c704bde94"), "سيه چشمه", 7 },
                    { 170, new Guid("2fcac315-2abb-44c3-a3e0-9189c56d05bc"), "نالوس", 7 },
                    { 190, new Guid("59ffb0fe-9bb5-4f7e-af90-8f211b0bc952"), "جغتاي", 8 },
                    { 171, new Guid("c6f682da-272e-48a3-84dc-f4b888265958"), "نقده", 7 },
                    { 173, new Guid("fed7f423-c89b-484b-8923-8d450304d9b9"), "پلدشت", 7 },
                    { 188, new Guid("d5125455-1af0-431f-b385-e5daf90aecf9"), "تربت جام", 8 },
                    { 187, new Guid("8db48776-b49e-4a44-9e1d-5ca9af635d9d"), "تايباد", 8 },
                    { 186, new Guid("56e18341-e886-43d4-85a7-94f192599df4"), "بيدخت", 8 },
                    { 185, new Guid("25aaa541-eb90-4819-a067-bad67948dc48"), "بردسکن", 8 },
                    { 184, new Guid("91bf4162-2778-407e-8baa-7a82b34995d4"), "بجستان", 8 },
                    { 183, new Guid("2d097412-ce91-4273-9f29-dd84b6b45e8f"), "بايک", 8 },
                    { 182, new Guid("e880059a-6b77-471b-aa94-3b8e38250d37"), "بار", 8 },
                    { 181, new Guid("09262b9a-7f50-48e2-b9e2-67af50a5aa61"), "باخرز", 8 },
                    { 180, new Guid("781aad3f-b33c-44d1-ae9c-e59c4ff7f9e9"), "باجگيران", 8 },
                    { 179, new Guid("cdce76cd-bbd6-4ee7-aa2e-091a30dd6396"), "انابد", 8 },
                    { 178, new Guid("7d8b75ee-b503-4958-bac8-520040f9a162"), "احمدآباد صولت", 8 },
                    { 177, new Guid("a6aa207f-d821-41e4-bd94-38fd059c5e73"), "گردکشانه", 7 },
                    { 176, new Guid("40f382f0-2409-4e6a-8c1d-b2e8bca9496f"), "کشاورز", 7 },
                    { 175, new Guid("e9ae636f-5eb1-48ed-84e9-54fd86231aa7"), "چهار برج", 7 },
                    { 174, new Guid("6aeb83a5-3e2a-432a-83a4-d001dd62f8f5"), "پيرانشهر", 7 },
                    { 172, new Guid("77ee497e-d09d-4887-bf56-2290d753dc91"), "نوشين", 7 },
                    { 228, new Guid("f4778803-de90-48cb-b753-899204a67f72"), "مشهد", 8 },
                    { 229, new Guid("9b771e8d-b352-460a-a4d3-3ca2dd2bc13d"), "مشهدريزه", 8 },
                    { 230, new Guid("8c72a011-ef58-4c1f-a563-541158e7f145"), "ملک آباد", 8 },
                    { 284, new Guid("8679b755-a148-4284-9e48-7c06fc330cc9"), "کنارک", 9 },
                    { 283, new Guid("6565c2e4-7bd8-4445-b41f-4488ff8c8cbf"), "چاه بهار", 9 },
                    { 282, new Guid("d3f63f0c-87c1-4c6d-b3e4-5aa346831725"), "پيشين", 9 },
                    { 281, new Guid("4ba08833-def9-41f6-aced-5c70875f5232"), "هيدوچ", 9 },
                    { 280, new Guid("73def4fd-da08-4fd9-9b7f-9329507130c7"), "نگور", 9 },
                    { 279, new Guid("153407a3-21d1-48bf-a189-fb470633c7ae"), "نيک شهر", 9 },
                    { 278, new Guid("bbd38aca-50d9-4a2a-b288-08c11f4f4283"), "نوک آباد", 9 },
                    { 277, new Guid("abc13684-f8bd-40b6-9881-2e0a601eda3f"), "نصرت آباد", 9 },
                    { 276, new Guid("29e5f5f8-b7bf-4f55-a619-30516f394c82"), "ميرجاوه", 9 },
                    { 275, new Guid("f1c785b4-119d-48b6-8d7e-55b3615ad9ca"), "مهرستان", 9 },
                    { 274, new Guid("225299f1-abcd-4263-b320-7aaa1a767a24"), "محمدي", 9 },
                    { 273, new Guid("62c16ced-b3e1-477c-aedd-47ad7afca7cd"), "محمدان", 9 },
                    { 272, new Guid("687d24d3-84d3-4ca7-a8f4-56077a9726c7"), "محمد آباد", 9 },
                    { 271, new Guid("beabf5cf-d01e-433b-b76b-07d49b365def"), "قصر قند", 9 },
                    { 270, new Guid("7b3eaf28-9f22-4453-940d-dfaf27b55375"), "فنوج", 9 },
                    { 285, new Guid("5e91bcc2-29d2-428a-b098-4a52faced9ee"), "گشت", 9 },
                    { 269, new Guid("ee92b9bf-246a-48ed-b9c0-17a758cb373e"), "علي اکبر", 9 },
                    { 286, new Guid("c71ce043-df38-45bf-a937-3aaf7c1910f4"), "گلمورتي", 9 },
                    { 288, new Guid("96c569ed-d872-4ae1-a713-9d9b1ea81523"), "آيسک", 10 },
                    { 303, new Guid("9864ea30-d4b2-4dc5-9ec3-4ac4ecb8208f"), "شوسف", 10 },
                    { 302, new Guid("23e9feae-2675-439c-949e-2278f68e63fc"), "سه قلعه", 10 },
                    { 301, new Guid("71f446e8-7b50-4645-8618-520caeea7867"), "سربيشه", 10 },
                    { 300, new Guid("6b6c1a5e-7689-467a-9dba-6c67efa8599c"), "سرايان", 10 },
                    { 299, new Guid("d39ee372-c379-4f3a-9a26-ed7dbd77a38d"), "زهان", 10 },
                    { 298, new Guid("86947287-bc91-4d0a-8333-e0648cab739d"), "ديهوک", 10 },
                    { 1241, new Guid("abacf388-0e92-4126-b549-8adacaf4aaa3"), "گراب سفلي", 31 },
                    { 296, new Guid("f78b32d8-4a38-49cb-91c1-12dfa69c2632"), "خضري دشت بياض", 10 },
                    { 295, new Guid("b9c7f0c2-892a-4aa7-a3c7-f178ec96a63d"), "حاجي آباد", 10 },
                    { 294, new Guid("46be66d2-49b3-453e-bc33-9a67901d26bc"), "بيرجند", 10 },
                    { 293, new Guid("4ffa3df2-b90e-4c7b-8ae1-5a37cca1468e"), "بشرويه", 10 },
                    { 292, new Guid("4f5f7cc1-6ae1-4ff1-adfd-6f3106498e94"), "اسلاميه", 10 },
                    { 291, new Guid("ee142bbb-716e-4784-ac97-c5a1ff556dd0"), "اسفدن", 10 },
                    { 290, new Guid("752c2f76-907b-4a1e-ac3d-68c6da9a1679"), "اسديه", 10 },
                    { 289, new Guid("879496d4-06b4-4972-91fd-19af17fad4f2"), "ارسک", 10 },
                    { 287, new Guid("ce664882-b704-4340-b16c-0000f60c8c53"), "آرين شهر", 10 },
                    { 268, new Guid("74f5ee17-3f21-44d7-b04d-7e87c85bc9b9"), "سيرکان", 9 },
                    { 267, new Guid("cdf0acf5-9c77-4039-90d6-f81e67b00fac"), "سوران", 9 },
                    { 266, new Guid("49e775ca-1b70-4d5a-af5f-0b9f5c82882f"), "سرباز", 9 },
                    { 245, new Guid("acd00ed7-1755-4c1b-a6f5-97e5ee37b255"), "کدکن", 8 },
                    { 244, new Guid("24ae001e-e697-48b1-b7cf-ab0fcf1316a4"), "کاشمر", 8 },
                    { 243, new Guid("ef9fbc55-6580-4ee8-b53c-6201f840e216"), "کاريز", 8 },
                    { 242, new Guid("d7309ea1-102a-4e13-b0e3-dd743a93904c"), "کاخک", 8 },
                    { 241, new Guid("58ba80bd-8389-4712-a354-65ce055d1b95"), "چکنه", 8 },
                    { 240, new Guid("997ca4b7-265c-4eaa-ab2c-0ad7e8a11107"), "چناران", 8 },
                    { 239, new Guid("c357d22b-9f7c-4fab-8499-85da9fb110db"), "چاپشلو", 8 },
                    { 238, new Guid("6b61abdd-da31-48f2-8d73-37b755abf804"), "يونسي", 8 },
                    { 237, new Guid("45e38a79-4b37-4367-a578-cb8cdad5a240"), "همت آباد", 8 },
                    { 236, new Guid("70445b8a-31e6-468a-8c56-fc64e1b3f7ce"), "نيل شهر", 8 },
                    { 235, new Guid("98423e6b-a4b2-4e0b-bef6-d7362e941021"), "نيشابور", 8 },
                    { 234, new Guid("5c809374-1086-41d0-8adb-72bb16e51e90"), "نوخندان", 8 },
                    { 233, new Guid("201fd5ed-9a9a-40b2-a0a5-71454a9b9d26"), "نقاب", 8 },
                    { 232, new Guid("a452b38e-f311-4a8f-977a-87b5e110970b"), "نصرآباد", 8 },
                    { 231, new Guid("14dc6e17-f57f-4e31-9638-021e7c86c491"), "نشتيفان", 8 },
                    { 246, new Guid("89c53988-035d-4ce9-9537-9096587dca5a"), "کلات", 8 },
                    { 247, new Guid("20d91726-6bf2-43d0-ae55-c52385ca649a"), "کندر", 8 },
                    { 248, new Guid("cc47b2bd-d692-42d3-9037-61b8606c4419"), "گلمکان", 8 },
                    { 249, new Guid("5811a2d1-ea2c-4d8f-8e6c-5532950ddc97"), "گناباد", 8 },
                    { 265, new Guid("64d62f7a-ac77-4452-9d65-246eb97f4e8a"), "سراوان", 9 },
                    { 264, new Guid("7352e057-1d4a-457f-ae6e-8cdc66cf2f08"), "زهک", 9 },
                    { 263, new Guid("c324dce0-4cfd-4fb5-a2aa-269397b01696"), "زرآباد", 9 },
                    { 262, new Guid("9930584e-b99b-41dd-9529-d50c75f85e9a"), "زاهدان", 9 },
                    { 261, new Guid("0127a3b1-a17c-409b-8eed-99718ae58bae"), "زابل", 9 },
                    { 260, new Guid("ffad4373-8e29-4c3a-8fed-d5630d52f55a"), "راسک", 9 },
                    { 259, new Guid("80d59f89-8aff-4a7c-91ca-4d8ed827fb2b"), "دوست محمد", 9 },
                    { 154, new Guid("a73e40aa-aae8-488b-98e2-292603129d58"), "سيمينه", 7 },
                    { 258, new Guid("de2f762e-3c83-44a1-bfa4-d30a9b92cc4a"), "خاش", 9 },
                    { 256, new Guid("2c85539f-20ec-4f46-bfa9-1c7f2c253f78"), "بنجار", 9 },
                    { 255, new Guid("f29b7c47-41dd-4bab-b6a9-6e4773b01adb"), "بنت", 9 },
                    { 254, new Guid("b1e24575-d938-4bf2-a468-77aeebbec7eb"), "بمپور", 9 },
                    { 253, new Guid("560a1e1d-09d2-4a91-95c8-f82952ced0f1"), "بزمان", 9 },
                    { 252, new Guid("be0e5d61-f3eb-496f-8e88-da5307685f4b"), "ايرانشهر", 9 },
                    { 251, new Guid("7ef8979e-2e47-4f6e-88f2-95d0744133f5"), "اسپکه", 9 },
                    { 250, new Guid("b402f5fb-93be-46f8-add1-9e101b329294"), "اديمي", 9 },
                    { 257, new Guid("afdf273c-ebc0-42a5-9eee-b2ed4eb2d700"), "جالق", 9 },
                    { 153, new Guid("cb2cc491-22fa-42d7-9f48-0811f1ca8270"), "سيلوانه", 7 },
                    { 152, new Guid("61715f5a-0338-49df-8af2-5d33aba6a094"), "سلماس", 7 },
                    { 151, new Guid("fdcd19b6-bfd9-424b-824d-962f775a0626"), "سرو", 7 },
                    { 54, new Guid("3e6ea290-1581-49fc-904b-19440c1636fb"), "پردنجان", 2 },
                    { 53, new Guid("4c77dc71-46b2-44ec-878e-93cec8dd57d5"), "وردنجان", 2 },
                    { 52, new Guid("a7481f31-fac3-45da-8771-758ae8c587b0"), "هفشجان", 2 },
                    { 51, new Guid("85bb4378-7164-4c74-a2dc-b3f519ebaf6e"), "هاروني", 2 },
                    { 50, new Guid("9044fd49-27e4-41e4-b246-6cba20c43f2d"), "نقنه", 2 },
                    { 49, new Guid("b41f8f7f-9b5f-4212-84f8-40295d09e467"), "نافچ", 2 },
                    { 48, new Guid("b503d561-e93f-4179-8b26-6690071d735d"), "ناغان", 2 },
                    { 47, new Guid("6f3547ec-cf96-4912-8743-36c7d7329635"), "منج", 2 },
                    { 46, new Guid("fa05ed8e-30eb-4000-87e8-ba4b6178e5f6"), "مال خليفه", 2 },
                    { 45, new Guid("3e6b7fb4-bf02-4035-bc8c-a929169e0049"), "لردگان", 2 },
                    { 44, new Guid("e238021f-72a2-4f13-978d-558075fa037c"), "فرخ شهر", 2 },
                    { 43, new Guid("5c1b2f9f-bdca-4a70-a517-882dc118666c"), "فرادنبه", 2 },
                    { 42, new Guid("e399fd8f-c0f4-4ddd-8d16-79c3763a3ba2"), "فارسان", 2 },
                    { 41, new Guid("f9e494fe-2cb9-4a61-b717-b6815540435c"), "طاقانک", 2 },
                    { 40, new Guid("d1538655-d017-4896-a38e-0679cce19879"), "صمصامي", 2 },
                    { 55, new Guid("09ba3934-2c52-465d-88b8-558c96af7b92"), "چليچه", 2 },
                    { 39, new Guid("6a351b6a-d6fb-491e-bd42-36250dc38e71"), "شهرکرد", 2 },
                    { 56, new Guid("372876eb-0fa8-4f1b-be53-a7082ab8e59b"), "چلگرد", 2 },
                    { 58, new Guid("eb808aed-0b47-4277-8cee-630d882a42dd"), "کيان", 2 },
                    { 73, new Guid("76168c94-7f3e-44d4-9274-fe9ade36fb46"), "سنخواست", 3 },
                    { 72, new Guid("cb1a8f79-9d96-4edb-80fc-78817685da89"), "زيارت", 3 },
                    { 71, new Guid("67a90bd4-e34f-480f-bf28-1e660a1814fc"), "راز", 3 },
                    { 70, new Guid("4c320e88-79c0-4daf-a1ce-9e1835306fa3"), "درق", 3 },
                    { 69, new Guid("f3437594-e8ea-4f88-8131-4ad9cdb5936f"), "حصارگرمخان", 3 },
                    { 68, new Guid("c6e3bb44-f1fc-4b83-932e-4379d62555e8"), "جاجرم", 3 },
                    { 67, new Guid("68ca6b1b-a8cc-487d-b7b9-1a5a5c715a0a"), "تيتکانلو", 3 },
                    { 66, new Guid("cafda3c8-cd13-44a0-8788-475f5ad3ed9a"), "بجنورد", 3 },
                    { 65, new Guid("c3965da2-0cd8-4334-9425-03152532045b"), "ايور", 3 },
                    { 64, new Guid("f33385a5-f01f-4ad0-b1f1-fe522d94fb0e"), "اسفراين", 3 },
                    { 63, new Guid("78a79841-ed88-49c6-ba3b-c7072dabda79"), "آوا", 3 },
                    { 62, new Guid("2ddecd94-7355-4cd2-88cf-68ed7095c9bc"), "آشخانه", 3 },
                    { 61, new Guid("8fae0e85-c181-4b9e-b55a-8ed564b52013"), "گوجان", 2 },
                    { 60, new Guid("0bd0b35b-2cca-48a7-8708-581278e89230"), "گهرو", 2 },
                    { 59, new Guid("66d29895-00ba-46e4-8039-4da2be76be64"), "گندمان", 2 },
                    { 57, new Guid("1e81f858-6460-4e3c-82f4-29ae25515cdd"), "کاج", 2 },
                    { 38, new Guid("724e5521-f303-4660-a2b4-0cc8d8ebd3be"), "شلمزار", 2 },
                    { 37, new Guid("2fef6727-0a37-4333-af07-fa4b4e70a97f"), "سورشجان", 2 },
                    { 36, new Guid("0c80c251-3b51-4fe1-bda2-064f271252c9"), "سودجان", 2 },
                    { 15, new Guid("13d31e85-5a2f-4f57-ac12-572964baebec"), "مهردشت", 1 },
                    { 14, new Guid("01a1643b-7d46-43b1-81c1-e2a7dd5d3983"), "مروست", 1 },
                    { 13, new Guid("c9232868-9b9d-4a47-b77b-870bae5ae4a1"), "عقدا", 1 },
                    { 12, new Guid("0a0ff8e6-55a8-402f-8913-9f62436adba6"), "شاهديه", 1 },
                    { 11, new Guid("d36fbc73-a89d-487e-9ba7-a9df3cd4177a"), "زارچ", 1 },
                    { 10, new Guid("d45b3a89-2b43-44b2-ad14-9db488c20ad6"), "خضر آباد", 1 },
                    { 9, new Guid("ee784d0a-1696-48ee-81df-cadda515a24e"), "حميديا", 1 },
                    { 8, new Guid("267b7ffa-425c-4be6-9518-ccbcf78ae195"), "تفت", 1 },
                    { 7, new Guid("f8379b3b-7be6-439f-ba71-fdedc2d22634"), "بهاباد", 1 },
                    { 6, new Guid("65de1e5e-0bc4-492e-990f-85574ce12347"), "بفروئيه", 1 },
                    { 5, new Guid("004c2491-895e-4b16-aa51-64f891b8577f"), "بافق", 1 },
                    { 4, new Guid("3f345c46-da94-449a-9a95-c02b36b6a1fc"), "اشکذر", 1 },
                    { 3, new Guid("b92ef5b1-4b41-44dc-99c9-e93d0e469f72"), "اردکان", 1 },
                    { 2, new Guid("447fcffa-09c3-4e3d-8d90-0889f3032735"), "احمد آباد", 1 },
                    { 1, new Guid("8a1ed461-9458-4a3f-90a3-24ed2ceb6b75"), "ابرکوه", 1 },
                    { 16, new Guid("603879bf-725e-48b8-9bfe-e70930d1492b"), "مهريز", 1 },
                    { 17, new Guid("ca9851e5-eaa0-460e-9647-962c75b75db5"), "ميبد", 1 },
                    { 18, new Guid("b3a348e3-34a2-408f-928d-d63272669270"), "ندوشن", 1 },
                    { 19, new Guid("772c3026-b097-4d41-a3d0-e212dad02a03"), "نير", 1 },
                    { 35, new Guid("879da14f-5b79-4446-8149-f376614a29fd"), "سفيد دشت", 2 },
                    { 34, new Guid("c164da4c-d634-478f-8d1a-029c70479981"), "سردشت لردگان", 2 },
                    { 33, new Guid("401e2aa9-9f67-4c05-b140-3e060734da49"), "سرخون", 2 },
                    { 32, new Guid("081bf4ba-d862-459d-ba7e-99b9ad40c73b"), "سامان", 2 },
                    { 31, new Guid("b08c4b2c-13c2-4ca9-b205-2a24cbf11f40"), "دشتک", 2 },
                    { 30, new Guid("bd58504b-421e-4a28-b640-b3722db0a7a8"), "دستناء", 2 },
                    { 29, new Guid("2ef5b788-32c7-41b0-8de1-31089a113258"), "جونقان", 2 },
                    { 74, new Guid("3984d35b-b10a-480c-9666-af2a4f880469"), "شوقان", 3 },
                    { 28, new Guid("29908326-524e-49c0-99a3-dbcd16a54c55"), "بن", 2 },
                    { 26, new Guid("5af0e4fa-d314-4c4e-92b9-2e17ab3b9d47"), "بروجن", 2 },
                    { 25, new Guid("acf52711-795d-4b2a-ba50-dd8941c47c3e"), "بازفت", 2 },
                    { 24, new Guid("d7dd3926-d8db-4462-ba22-6900d9d29f63"), "باباحيدر", 2 },
                    { 23, new Guid("2324b640-2219-4142-9eb1-4c14f119b4d2"), "اردل", 2 },
                    { 22, new Guid("074406bf-7975-4507-bfde-41343cdfe2ca"), "آلوني", 2 },
                    { 21, new Guid("360cbda0-d472-4ae2-b7c6-d33854bf3a1f"), "يزد", 1 },
                    { 20, new Guid("0deb3cd9-9b14-4f92-b0f7-77c023990888"), "هرات", 1 },
                    { 27, new Guid("d6cfd3ae-0a82-4675-bf90-d64aa1707f8e"), "بلداجي", 2 },
                    { 304, new Guid("51f4c98c-6e5e-4661-be03-6e4b45c418f9"), "طبس", 10 },
                    { 75, new Guid("22a24df9-6d61-48da-a4b6-51b3a5463300"), "شيروان", 3 },
                    { 77, new Guid("71bcb654-7b6d-4b7a-876e-8244564bcbef"), "فاروج", 3 },
                    { 131, new Guid("21363deb-e6a0-415f-9d2e-dd175ae82277"), "پيرتاج", 6 },
                    { 130, new Guid("71454154-b03c-497c-9a8c-2b0ef06f7fb9"), "ياسوکند", 6 },
                    { 129, new Guid("419f86cc-2de2-410c-821c-dfec21495885"), "موچش", 6 },
                    { 128, new Guid("e0172745-8df4-4753-8532-a64c4fdef55f"), "مريوان", 6 },
                    { 127, new Guid("6d114617-57e7-44e4-b7a6-456ec3a3031b"), "قروه", 6 },
                    { 126, new Guid("c7a9ed43-3047-4be3-a46d-93fa26c7fd0b"), "صاحب", 6 },
                    { 125, new Guid("2753fbb9-91df-4a31-a3bb-e3fd395b99a2"), "شويشه", 6 },
                    { 124, new Guid("bbc473b1-02a8-4dd7-81f3-70f7162a6919"), "سنندج", 6 },
                    { 123, new Guid("840a3749-89ec-48e8-abc8-294ace188e69"), "سقز", 6 },
                    { 122, new Guid("3c6a850f-1306-496f-9848-2cc50ad3124a"), "سريش آباد", 6 },
                    { 121, new Guid("ac6e2347-3179-4ac8-9852-76dd2f08cc11"), "سرو آباد", 6 },
                    { 120, new Guid("180d0660-cbb9-41b9-b5a7-53afcadba141"), "زرينه", 6 },
                    { 119, new Guid("5884489e-eaae-4630-8e8d-1b79482b129b"), "ديواندره", 6 },
                    { 118, new Guid("65092f75-567a-4a80-abc6-1a5bc819988d"), "دهگلان", 6 },
                    { 117, new Guid("a5d30a61-ad2f-42be-b5fc-ddee3bdf598f"), "دلبران", 6 },
                    { 132, new Guid("8713d39b-553b-4e53-92e8-abb823222981"), "چناره", 6 },
                    { 116, new Guid("e69e99b4-8d64-45e1-b7ce-f341a040d3d9"), "دزج", 6 },
                    { 133, new Guid("6d453b9a-22a8-4397-a2f1-224d65599dcf"), "کامياران", 6 },
                    { 135, new Guid("5a93bc60-2119-4a46-a6d6-b62ef9a3ce59"), "کاني سور", 6 },
                    { 150, new Guid("8fe8be1d-8c9e-4e5a-b997-ff89ecd84621"), "سردشت", 7 },
                    { 149, new Guid("cf416fde-3df2-49a5-8407-523d9abd37be"), "زرآباد", 7 },
                    { 148, new Guid("1f5f32a2-edbd-47e9-a5db-2ee2c142ce9a"), "ربط", 7 },
                    { 147, new Guid("010de5ff-1643-4f81-a047-d852209af2cf"), "ديزج ديز", 7 },
                    { 146, new Guid("b6e0c837-adbb-43c1-a004-34eb2d4da4d4"), "خوي", 7 },
                    { 145, new Guid("b99a7400-9f23-4a8f-9023-3f8046b0db5a"), "خليفان", 7 },
                    { 144, new Guid("da5c9e8f-9a83-494b-82b1-5c3b8789dc17"), "تکاب", 7 },
                    { 143, new Guid("a4b1c3c3-e6fd-4a3d-91b9-e51177fa6d9b"), "تازه شهر", 7 },
                    { 142, new Guid("f757321d-0dce-4b47-b37e-aa65d7a76529"), "بوکان", 7 },
                    { 141, new Guid("87b0ffe1-2a4a-44f7-94f8-cdad44caaf3b"), "بازرگان", 7 },
                    { 140, new Guid("0095f6a6-8024-427d-a8d5-52bc3006a0a1"), "باروق", 7 },
                    { 139, new Guid("354f35fb-1bac-4c61-a5c8-ef16bfa634bd"), "ايواوغلي", 7 },
                    { 138, new Guid("b84da5d0-2bfe-4131-a1bb-2ff10785ee7a"), "اشنويه", 7 },
                    { 137, new Guid("1fa1f122-4af0-41b1-a098-25aa673c694c"), "اروميه", 7 },
                    { 136, new Guid("7e0d1544-3070-476e-b329-3c1202c5dd93"), "آواجيق", 7 },
                    { 134, new Guid("6c3aca6e-8b9c-4423-b082-eacf764a6c7f"), "کاني دينار", 6 },
                    { 115, new Guid("5a2ef5fc-57f6-4657-bc11-ce824476eb92"), "توپ آغاج", 6 },
                    { 114, new Guid("0571ec23-e257-45e5-aab7-29b7751e799b"), "بيجار", 6 },
                    { 113, new Guid("481fb21d-f98c-415b-8fa9-98cfd9acd73f"), "بوئين سفلي", 6 },
                    { 92, new Guid("bd360383-cf8f-477f-984b-740287479dd2"), "مشکين دشت", 4 },
                    { 91, new Guid("b6a30010-b070-49b6-ab75-bb7d6cd77770"), "محمد شهر", 4 },
                    { 90, new Guid("e4104315-15c6-434c-9ac2-e84395c35010"), "ماهدشت", 4 },
                    { 89, new Guid("22ba80a3-ad17-4db4-be8c-307c889f33d8"), "فرديس", 4 },
                    { 88, new Guid("a688dfd7-0d2c-4cdb-8120-4e55a2d1d22b"), "طالقان", 4 },
                    { 87, new Guid("62c207e7-9bac-4583-926a-369a102909e5"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("55d4704e-1d15-4f5e-9311-ec1d7bc4ad8e"), "تنکمان", 4 },
                    { 85, new Guid("52a5178d-f23b-40d0-9ad4-1b19a284c440"), "اشتهارد", 4 },
                    { 84, new Guid("34b1473d-b350-4219-bc9d-abc357e4f49f"), "آسارا", 4 },
                    { 83, new Guid("d050eea2-9907-48e8-8f52-8daa813dbb19"), "گرمه", 3 },
                    { 82, new Guid("430001bb-a9a8-4ee9-9b16-0f1500b033a6"), "چناران شهر", 3 },
                    { 81, new Guid("f0e1b79f-926c-47ec-8c2a-3ef26fb878d1"), "پيش قلعه", 3 },
                    { 80, new Guid("b6d3d2f2-1f28-41e0-889c-3ce315c06583"), "لوجلي", 3 },
                    { 79, new Guid("2545eec4-8057-4214-ab9f-bb35524e8bab"), "قوشخانه", 3 },
                    { 78, new Guid("b7b9207c-b7b8-4b4a-bb4a-811042aabeb3"), "قاضي", 3 },
                    { 93, new Guid("5c03f9f0-fd1c-4502-910c-548dba7df4ff"), "نظر آباد", 4 },
                    { 94, new Guid("411fa5ea-b13b-474e-af64-42a9c467153f"), "هشتگرد", 4 },
                    { 95, new Guid("632b49a1-4af5-47e6-85c1-b37a78f8bf3d"), "چهارباغ", 4 },
                    { 96, new Guid("d5e5ae14-f49c-49c1-b566-798a41280374"), "کرج", 4 },
                    { 112, new Guid("80058036-380f-4ff3-860e-b3115396292d"), "بلبان آباد", 6 },
                    { 111, new Guid("51f4ef2e-cdf4-494f-a433-dc6c3167b619"), "برده رشه", 6 },
                    { 110, new Guid("dc187e84-3dc7-4577-b257-17cd9c297f2c"), "بانه", 6 },
                    { 109, new Guid("7af386fd-bd1a-42a5-bba4-6d72e920930b"), "بابارشاني", 6 },
                    { 108, new Guid("bf7ff8b6-d4f0-459b-9369-fce54376b951"), "اورامان تخت", 6 },
                    { 107, new Guid("d43ebfd4-039f-44c3-b34e-5f6b29bdd341"), "آرمرده", 6 },
                    { 106, new Guid("44de7dac-93fd-4e05-ad9a-d57936791278"), "کهک", 5 },
                    { 76, new Guid("c5123544-692a-4737-9410-0a17e6c9f07b"), "صفي آباد", 3 },
                    { 105, new Guid("254973ab-ddac-43a0-8740-fa09ccd292e6"), "قنوات", 5 },
                    { 103, new Guid("9eedfb0e-ba8f-4d81-8a1c-1e79cd300351"), "سلفچگان", 5 },
                    { 102, new Guid("e157fa35-c9ce-49d4-9e67-ff1ec231234c"), "دستجرد", 5 },
                    { 101, new Guid("3c06e3de-39d0-4e50-9c4e-65ccc6fa2606"), "جعفريه", 5 },
                    { 100, new Guid("7aa340cc-c0c8-4ca1-8e6d-4fc2dccc3592"), "گلسار", 4 },
                    { 99, new Guid("b7c3ddbd-ebf5-410e-82c7-bd86bbd29b1a"), "گرمدره", 4 },
                    { 98, new Guid("6a9f156f-7f2e-4c5e-a40d-375bbdf5c838"), "کوهسار", 4 },
                    { 97, new Guid("48c0b8dc-767a-49ca-ab68-8e4734698670"), "کمال شهر", 4 },
                    { 104, new Guid("a3549f3a-2c12-46f7-8462-18e73d18215c"), "قم", 5 },
                    { 305, new Guid("b1e16c00-bdd5-49e0-bed1-2aceb8548520"), "طبس مسينا", 10 },
                    { 297, new Guid("45f578d3-0304-4ee9-87af-bae50554f16f"), "خوسف", 10 },
                    { 307, new Guid("e30befd6-d71c-4714-8812-262f899e84d3"), "فردوس", 10 },
                    { 514, new Guid("5ba56ae3-c98b-4bd6-b2e2-f922b6ad3dd3"), "نشتارود", 15 },
                    { 513, new Guid("1877a196-c4c7-45e2-a91d-6ad61c634421"), "مرزيکلا", 15 },
                    { 512, new Guid("2b324bd6-5171-4e02-8bb7-f225863ff292"), "مرزن آباد", 15 },
                    { 511, new Guid("26a80511-fc82-45c6-8ae5-c065789cb10e"), "محمود آباد", 15 },
                    { 510, new Guid("f2b03f32-5eb3-49a3-b5c1-8a3d125c7ad8"), "قائم شهر", 15 },
                    { 509, new Guid("e380d58a-ae3c-4ad6-9e47-12293e522661"), "فريم", 15 },
                    { 508, new Guid("c5155936-1c75-43bc-8a1a-55ffa26e4673"), "فريدونکنار", 15 },
                    { 507, new Guid("43fe17c3-d960-478e-9697-6f06eda7afa6"), "عباس آباد", 15 },
                    { 506, new Guid("e87a8f3b-b507-480e-8b49-aade1aa21e80"), "شيرگاه", 15 },
                    { 505, new Guid("989a7ded-4755-4329-af58-13ce898cc0e9"), "شيرود", 15 },
                    { 504, new Guid("a9173940-1cf4-4877-9302-9a06249282af"), "سورک", 15 },
                    { 503, new Guid("995277da-542a-4d24-9eff-6eecb35a31c3"), "سلمان شهر", 15 },
                    { 502, new Guid("da554f15-8650-4a1e-aa7f-14001efd748c"), "سرخرود", 15 },
                    { 501, new Guid("d3488186-8579-44bd-a9b1-48c828e3141c"), "ساري", 15 },
                    { 500, new Guid("1eac15b7-9d45-469e-936b-5ce55d25e815"), "زيرآب", 15 },
                    { 515, new Guid("1835e64e-d82d-4ae9-be1f-bb91b59da324"), "نور", 15 },
                    { 499, new Guid("3b7c7b1c-8eee-4644-83da-638e9c321a68"), "زرگر محله", 15 },
                    { 516, new Guid("20d17a09-71eb-4478-b44f-9d83b2e6f895"), "نوشهر", 15 },
                    { 518, new Guid("d205d656-ed10-4a1a-a505-da1864c0d702"), "هادي شهر", 15 },
                    { 533, new Guid("f8bbfbb4-cfbc-4108-a238-4db890fbf44e"), "گزنک", 15 },
                    { 532, new Guid("469fcb34-bc9a-4e3c-8b38-1e5630ca8d4d"), "گتاب", 15 },
                    { 531, new Guid("542919a5-b9bb-4d24-9881-b2af1d66348f"), "کياکلا", 15 },
                    { 530, new Guid("40934c49-cfb4-45ef-a9d4-23115861075a"), "کياسر", 15 },
                    { 529, new Guid("106534bf-ed58-4b80-a966-f7686ecbc0bd"), "کوهي خيل", 15 },
                    { 528, new Guid("ad242a4d-46d1-428a-ba05-55c0996fb9c6"), "کلاردشت", 15 },
                    { 527, new Guid("e2672dbc-e03f-47ac-b048-e1a7778c2f73"), "کلارآباد", 15 },
                    { 526, new Guid("ea5d4a83-6c7c-413b-97aa-d3b5cb67ed80"), "کجور", 15 },
                    { 525, new Guid("b67bcc5a-f8c9-4ffd-91ba-7ea94a69a3eb"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("9c1209cf-313c-4cc7-ab03-15c1bd4c8dc9"), "چمستان", 15 },
                    { 523, new Guid("d5753c2b-a348-4e30-ac9b-0349a0598f75"), "چالوس", 15 },
                    { 522, new Guid("44915605-b5e0-449e-8b2d-2bf522d19a6f"), "پول", 15 },
                    { 521, new Guid("0fa0d2ce-7e5c-43c4-ac9f-0d4805195e0c"), "پل سفيد", 15 },
                    { 520, new Guid("b0c59981-0e3e-4265-b877-31b24be34261"), "پايين هولار", 15 },
                    { 519, new Guid("2ae1d733-a06b-4532-8d88-bf47e083c792"), "هچيرود", 15 },
                    { 517, new Guid("1c247d76-3aae-40b7-aaa8-428569e07378"), "نکا", 15 },
                    { 534, new Guid("a78a361c-0058-4dc2-883c-680927bd2401"), "گلوگاه", 15 },
                    { 498, new Guid("d1e6e538-ba14-42ca-9a75-0e3072e0017b"), "رينه", 15 },
                    { 496, new Guid("63fa5f28-d19e-42cd-9fbf-22b70abbdff0"), "رستمکلا", 15 },
                    { 476, new Guid("362cbe3c-7587-417f-a751-a849fb899dee"), "گميش تپه", 14 },
                    { 475, new Guid("329e133d-9353-45e5-9820-9ea989c92bbe"), "گرگان", 14 },
                    { 474, new Guid("59d7f125-bfd1-430a-9541-19d960876e11"), "گاليکش", 14 },
                    { 473, new Guid("4e1dc155-5aae-46e6-9015-032299569bfb"), "کلاله", 14 },
                    { 472, new Guid("30638888-5abe-4f6a-91dc-7fdd75fc67ca"), "کرد کوي", 14 },
                    { 471, new Guid("06d9c717-a410-4f79-ba04-7c0675a45a6f"), "نگين شهر", 14 },
                    { 470, new Guid("37eb7faa-266b-4dc9-a8a2-f5bbbc0033ad"), "نوکنده", 14 },
                    { 469, new Guid("b2211c14-f6a7-4d0d-86e9-3eca765221a3"), "نوده خاندوز", 14 },
                    { 306, new Guid("8bce3b22-ef7b-484e-83dd-ec8692aca543"), "عشق آباد", 10 },
                    { 467, new Guid("aebc717d-8d61-46b2-9445-d78b66e84311"), "مزرعه", 14 },
                    { 466, new Guid("8578f2a5-e145-42ba-8df5-27db222cd185"), "مراوه تپه", 14 },
                    { 465, new Guid("1ef04b50-0809-4e01-be48-f088ffb41565"), "فراغي", 14 },
                    { 464, new Guid("a1d0d6f2-c20a-4df1-8dd3-9d5b58759ed1"), "فاضل آباد", 14 },
                    { 463, new Guid("bfbcbe3a-f052-4826-86a9-d591808b7c3b"), "علي آباد", 14 },
                    { 462, new Guid("1d927b1e-8914-4072-87d3-02d75c08a89a"), "سيمين شهر", 14 },
                    { 477, new Guid("fc9bd43a-792f-4854-a0e2-0be93977fa89"), "گنبدکاووس", 14 },
                    { 497, new Guid("44bf370e-5a6b-4bc6-a025-1634c3512c6d"), "رويان", 15 },
                    { 478, new Guid("1fa19783-39b1-4cf8-89d1-9c09d4a912e3"), "آلاشت", 15 },
                    { 480, new Guid("18e94452-be41-45ec-8706-15c094a62bcd"), "ارطه", 15 },
                    { 495, new Guid("7df05aed-10fb-47fa-9959-25c7477d7b28"), "رامسر", 15 },
                    { 494, new Guid("e01b7e00-fd1d-4fef-86d8-6a043dc02f6c"), "دابودشت", 15 },
                    { 493, new Guid("6aae43fe-bd33-42b2-b031-e5d9c0591d82"), "خوش رودپي", 15 },
                    { 492, new Guid("7387a1cd-83ed-4cc1-935f-b387efe0a07f"), "خليل شهر", 15 },
                    { 491, new Guid("ea582869-4ccb-4a57-919d-0d77b91c6062"), "خرم آباد", 15 },
                    { 490, new Guid("f2b5da9d-2125-4a22-b240-e38eefd1a930"), "جويبار", 15 },
                    { 489, new Guid("879a6d8d-cc80-4785-ac08-655d7e45b7a3"), "تنکابن", 15 },
                    { 488, new Guid("f58cab11-078a-4fda-9c06-663e422504e9"), "بهنمير", 15 },
                    { 487, new Guid("ba433575-92f8-45fe-940f-759f1f07f3ef"), "بهشهر", 15 },
                    { 486, new Guid("bbdc7abb-d23f-47c7-867e-462d7d1e512a"), "بلده", 15 },
                    { 485, new Guid("42d7ff44-ce76-4cb3-903b-9cfd4dc207bc"), "بابلسر", 15 },
                    { 484, new Guid("afd58724-ca81-4f91-8e6b-f2754d378f24"), "بابل", 15 },
                    { 483, new Guid("55a5c511-45ce-4022-9fc1-e803ae17592a"), "ايزد شهر", 15 },
                    { 482, new Guid("08aa4b5c-eef0-437d-9267-a82d2bfffa80"), "امير کلا", 15 },
                    { 481, new Guid("62012c5f-d439-4d0a-8a95-3037b65b84c1"), "امامزاده عبدالله", 15 },
                    { 479, new Guid("19c00fb9-5916-41de-a821-f57b1f77335f"), "آمل", 15 },
                    { 535, new Guid("c6cdda54-8334-43c1-ad27-7fa9287e70c2"), "آبيک", 16 },
                    { 536, new Guid("92e849d2-ce21-4215-9562-c7d8cf8f15cc"), "آبگرم", 16 },
                    { 537, new Guid("9fcb9592-91b5-48b7-a273-3cd53eae3447"), "آوج", 16 },
                    { 591, new Guid("569ce52d-cb21-472c-b5e1-cc047e62793f"), "تازه کند انگوت", 18 },
                    { 590, new Guid("7af5c8de-4b7a-4ce9-b629-d4cc69951d8b"), "تازه کند", 18 },
                    { 589, new Guid("597e1b50-7c35-419e-9d83-93acae40582a"), "بيله سوار", 18 },
                    { 588, new Guid("3dd2af94-e05c-49e8-bca6-dd42120786fe"), "اصلاندوز", 18 },
                    { 587, new Guid("ce727388-7c5a-41fc-a8c7-92a2252bb069"), "اسلام آباد", 18 },
                    { 586, new Guid("44d221c9-eefb-4967-a994-0158a0f38587"), "اردبيل", 18 },
                    { 585, new Guid("308ec851-9e3b-43aa-b4aa-df75a4812a9d"), "آبي بيگلو", 18 },
                    { 584, new Guid("274c5d15-9b15-4270-9c1b-68b1d83468e1"), "گراب", 17 },
                    { 583, new Guid("1c718ecc-4eb4-4e49-ab03-2c5933bd1c24"), "کوهناني", 17 },
                    { 582, new Guid("53cdab7e-4dbf-45fd-b569-992fa1261e0a"), "کوهدشت", 17 },
                    { 581, new Guid("866aa482-2bda-4ae8-92c3-6bdec3d9ff92"), "چقابل", 17 },
                    { 580, new Guid("41ed3dfe-078f-4ce6-ade0-76c2a616b60d"), "چالانچولان", 17 },
                    { 579, new Guid("3cc8b6d6-a81d-447f-80d4-5028b956f257"), "پلدختر", 17 },
                    { 578, new Guid("1177bf7f-09ee-4146-8742-01cbe598315a"), "ويسيان", 17 },
                    { 577, new Guid("eb69e7ce-42bb-46b6-9b7c-931598b13d13"), "هفت چشمه", 17 },
                    { 592, new Guid("00ded3a1-a592-4e93-89ee-6b5e5e6582a7"), "جعفر آباد", 18 },
                    { 576, new Guid("72adc500-ad01-47f0-a6b0-fb8313d57815"), "نورآباد", 17 },
                    { 593, new Guid("5a7a4087-8a20-4d9c-9bab-d38b8ad3ea3c"), "خلخال", 18 },
                    { 595, new Guid("c63ec374-c463-4d34-9613-4cae4cb9120f"), "سرعين", 18 },
                    { 610, new Guid("a84f9411-e298-4377-a625-48fa3c60e575"), "گيوي", 18 },
                    { 609, new Guid("d17549db-2dff-4149-b509-ad4e42b85b87"), "گرمي", 18 },
                    { 608, new Guid("1cac8de0-cf95-41e2-8780-4f9ef0ab3f32"), "کورائيم", 18 },
                    { 607, new Guid("4da8b30e-b075-4c79-8c50-b447e7d448d6"), "کلور", 18 },
                    { 606, new Guid("bf178972-fedf-47e1-99b3-369e311113a0"), "پارس آباد", 18 },
                    { 605, new Guid("f86b62ee-4270-43a7-9f57-5af83624922a"), "هير", 18 },
                    { 604, new Guid("070666b2-440a-48bf-843e-49798cd9d633"), "هشتجين", 18 },
                    { 603, new Guid("8b65c9e4-c2cd-46ec-bfb1-09c2af5fdd9e"), "نير", 18 },
                    { 602, new Guid("555c4c89-5228-49d0-8d68-1cf85886c8ee"), "نمين", 18 },
                    { 601, new Guid("772d202d-e166-4397-8adb-79487a314210"), "مشگين شهر", 18 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 600, new Guid("f82e25dc-b10d-43cf-ba0d-2c1e04b2dbe7"), "مرادلو", 18 },
                    { 599, new Guid("28ff43f1-801f-4c44-8aaf-6417e86ae0aa"), "لاهرود", 18 },
                    { 598, new Guid("67aeee2f-b7b6-4cc2-84fc-9bfa65ad3f44"), "قصابه", 18 },
                    { 597, new Guid("5fd9aeb0-3719-4b2c-8f6d-cb8f062cfb92"), "فخرآباد", 18 },
                    { 596, new Guid("a3a2763f-7c93-4015-81e3-126ecc1e1f1d"), "عنبران", 18 },
                    { 594, new Guid("4ac03a0f-7386-4a5d-97d0-0257533e7a7d"), "رضي", 18 },
                    { 575, new Guid("4417ad77-5105-4a5f-beb9-67a119f4ec07"), "مومن آباد", 17 },
                    { 574, new Guid("d2dee0b9-0f93-4186-89cb-9ab3f80c1fe4"), "معمولان", 17 },
                    { 573, new Guid("f163a9dc-2387-4333-9057-e724f46a3f8c"), "فيروزآباد", 17 },
                    { 552, new Guid("258ed66a-6b02-4783-ae9d-ffac5700c7eb"), "شريفيه", 16 },
                    { 551, new Guid("c3e416b0-46f1-4ab1-b7eb-715df35b6794"), "شال", 16 },
                    { 550, new Guid("dc53587e-22b3-47ef-9257-4a577ccb1340"), "سگز آباد", 16 },
                    { 549, new Guid("1a14a9e8-fc01-48a8-a0ac-3dc1156c0c51"), "سيردان", 16 },
                    { 548, new Guid("db51753c-f989-4874-8ae3-8ff0b5f7c146"), "رازميان", 16 },
                    { 547, new Guid("0673ed3e-187e-4757-971b-fb6ea64f9154"), "دانسفهان", 16 },
                    { 546, new Guid("444d7c22-b979-4e0f-a0c7-4b7c8606444f"), "خرمدشت", 16 },
                    { 545, new Guid("16087cde-c39c-4011-a36e-cdef372cfdb2"), "خاکعلي", 16 },
                    { 544, new Guid("e06c218b-7aae-4e2f-ba90-4a3eac044ce7"), "تاکستان", 16 },
                    { 543, new Guid("de4b23a9-42de-410a-85c1-338a9a76fd3c"), "بيدستان", 16 },
                    { 542, new Guid("1d087869-d3ab-47ff-87fb-8e1e612889a8"), "بوئين زهرا", 16 },
                    { 541, new Guid("2b3061f1-bed8-4ed0-bbda-38c6a2470d3c"), "الوند", 16 },
                    { 540, new Guid("6229a2fe-206b-4a50-aab2-bd3177feb405"), "اقباليه", 16 },
                    { 539, new Guid("0fcbc285-df74-4df5-b827-80ce0d1db1b7"), "اسفرورين", 16 },
                    { 538, new Guid("115260b5-3ecb-49c7-92f8-278b06e356a8"), "ارداق", 16 },
                    { 553, new Guid("6f13319a-5703-439c-b925-fe8ac1f50e67"), "ضياء آباد", 16 },
                    { 554, new Guid("e7aed6dc-4653-4438-876d-d28d37485132"), "قزوين", 16 },
                    { 555, new Guid("961b8c2c-5b41-4d5f-ac28-635e82085038"), "محمديه", 16 },
                    { 556, new Guid("1f979da6-f870-4389-8e93-4bb1c180a848"), "محمود آباد نمونه", 16 },
                    { 572, new Guid("d7e57184-5f7a-4b92-aa1e-d133cf2977ef"), "شول آباد", 17 },
                    { 571, new Guid("0faa7847-f590-4ab2-b80e-7bfefb9c6ee6"), "سپيد دشت", 17 },
                    { 570, new Guid("79f8110d-7388-411b-9f96-ec9390b97789"), "سراب دوره", 17 },
                    { 569, new Guid("ebb201ae-aa3e-4198-9a15-93c6b028de7c"), "زاغه", 17 },
                    { 568, new Guid("0743bdcf-bf92-4fb2-96a9-58cded07ca32"), "دورود", 17 },
                    { 567, new Guid("225d76cc-1019-492f-bb03-ad552819426e"), "درب گنبد", 17 },
                    { 566, new Guid("59f9459a-fe5b-491c-b5a4-0d29ae36ba1e"), "خرم آباد", 17 },
                    { 461, new Guid("d06e3bc7-7e48-4108-ae32-6684c7bbcc24"), "سنگدوين", 14 },
                    { 565, new Guid("ecade3cb-0aaa-4341-9b12-78f56dbcf68b"), "بيرانشهر", 17 },
                    { 563, new Guid("377179a4-7d24-4150-913e-af09b7d97923"), "اليگودرز", 17 },
                    { 562, new Guid("2565c287-b35b-4880-97a0-a9d9a2d6c34e"), "الشتر", 17 },
                    { 561, new Guid("6c4e519e-0b48-4206-9d93-7e15e56b72d2"), "اشترينان", 17 },
                    { 560, new Guid("e5f67b29-dc72-45b8-a0bd-7774e31a38e6"), "ازنا", 17 },
                    { 559, new Guid("0191f40f-7ba5-4c49-92b9-93b4d45885ab"), "کوهين", 16 },
                    { 558, new Guid("ce4f0e33-3a61-400c-8bfe-6f44d2757072"), "نرجه", 16 },
                    { 557, new Guid("c69b39a8-7e99-43ac-9913-163145e5963a"), "معلم کلايه", 16 },
                    { 564, new Guid("75736494-9256-4993-9383-8568192f0418"), "بروجرد", 17 },
                    { 460, new Guid("1765c501-ee74-4ee9-b579-3d42d0f05a87"), "سرخنکلاته", 14 },
                    { 468, new Guid("c3c264ca-cfc1-4b64-b4e2-c6ce86d89d06"), "مينودشت", 14 },
                    { 458, new Guid("2c149794-6b81-4e23-b6a8-ad165f5f3584"), "دلند", 14 },
                    { 361, new Guid("b749d4cf-63f3-4f9a-beb0-ce444637cc48"), "شوش", 11 },
                    { 360, new Guid("b8abe03d-fe83-4d39-8d30-a6cc3906010a"), "شهر امام", 11 },
                    { 359, new Guid("095c16ac-83f0-469a-97c8-1892d45768fb"), "شمس آباد", 11 },
                    { 358, new Guid("36a10139-666d-4a85-a303-1d2ad8ec9c02"), "شرافت", 11 },
                    { 357, new Guid("b72f0171-ff4c-41d0-b8b0-81214721a034"), "شاوور", 11 },
                    { 356, new Guid("7b3b37f6-eee8-48b9-b22f-810eab6d5e82"), "شادگان", 11 },
                    { 355, new Guid("2b65f0a3-a8f8-4421-9e4a-8b34989c52cf"), "سياه منصور", 11 },
                    { 354, new Guid("b025e6f3-36c5-4da3-b7a6-1d82d9d906fd"), "سوسنگرد", 11 },
                    { 353, new Guid("a8d2ff35-80a0-474b-a927-74bc11382f86"), "سماله", 11 },
                    { 352, new Guid("7340b309-d25e-45ae-9284-a13b351b5644"), "سردشت", 11 },
                    { 351, new Guid("f723b17b-3662-43d4-bc1a-9bf8d2139025"), "سرداران", 11 },
                    { 350, new Guid("342bf2f5-3eac-4a1d-a012-9f621726ec5e"), "سالند", 11 },
                    { 349, new Guid("bb901592-1137-4346-8f06-3bb24de93251"), "زهره", 11 },
                    { 348, new Guid("73bcb420-9202-4fd4-ba95-39252b1613b7"), "رفيع", 11 },
                    { 347, new Guid("3a86cc9f-c00d-4e4f-8f0c-1786ea3b5f4b"), "رامهرمز", 11 },
                    { 362, new Guid("f220e11d-a68d-4fb9-8b4f-93295f5fe18c"), "شوشتر", 11 },
                    { 346, new Guid("b6c61c44-3bd9-4fc1-b592-afb614ce2908"), "رامشير", 11 },
                    { 363, new Guid("33cfa123-6292-4caf-ad2f-d7fc901366e8"), "شيبان", 11 },
                    { 365, new Guid("04926166-dbac-4c3e-ac02-53cd45f6df9f"), "صفي آباد", 11 },
                    { 380, new Guid("ad91816b-1546-4b99-887a-64fdf4f7733a"), "هنديجان", 11 },
                    { 379, new Guid("655543ba-38ad-49fc-ba60-d47eb7faab6e"), "هفتگل", 11 },
                    { 378, new Guid("6d3a97a9-a812-463f-bf47-475c8766b8bf"), "مينوشهر", 11 },
                    { 377, new Guid("44980186-bc72-434d-9eaa-e72abb08a200"), "ميداود", 11 },
                    { 376, new Guid("0351c52d-eeaa-4e32-9cde-46e68ee3d48c"), "ميانرود", 11 },
                    { 375, new Guid("59bb72eb-b980-4315-9036-3067d45d706c"), "منصوريه", 11 },
                    { 459, new Guid("fb38b7d0-d003-4f24-8f1b-151991c799a8"), "راميان", 14 },
                    { 373, new Guid("7cad703c-2f38-4f5b-87bb-f9b024543ead"), "مقاومت", 11 },
                    { 372, new Guid("49886192-8a06-4e7d-9370-10a0f79b8a3c"), "مشراگه", 11 },
                    { 371, new Guid("38467de6-5b0b-4adc-a974-d851a84abaf1"), "مسجد سليمان", 11 },
                    { 370, new Guid("921130ef-da90-473e-b908-8aa7b060b9fb"), "لالي", 11 },
                    { 369, new Guid("6a48cea0-456a-4685-a3bd-cea9ff6e1031"), "قلعه خواجه", 11 },
                    { 368, new Guid("c75fa04f-8354-4e8b-997c-d8a0971fb35e"), "قلعه تل", 11 },
                    { 367, new Guid("81231052-ce94-4706-b29f-1ce0f29a39e1"), "فتح المبين", 11 },
                    { 366, new Guid("ec99253c-893f-4923-a52c-b5c30cfde36b"), "صيدون", 11 },
                    { 364, new Guid("ceb2e697-3a8a-45c7-a889-ad154bd48440"), "صالح شهر", 11 },
                    { 345, new Guid("fffd0ad2-fcb3-4ba7-b12d-82db3efc7be4"), "دهدز", 11 },
                    { 344, new Guid("8ee214f7-453f-4ff7-9ada-0e36bfeebd65"), "دزفول", 11 },
                    { 343, new Guid("c630739d-7adc-4797-b12d-d454619690e7"), "دارخوين", 11 },
                    { 322, new Guid("b5978e64-38b4-4e48-a5c3-08ea52cd285e"), "الوان", 11 },
                    { 321, new Guid("98721c57-69de-4c05-803d-85dd9c26df71"), "الهايي", 11 },
                    { 320, new Guid("81989ca7-d35c-4531-97e8-0c7d026195d3"), "اروند کنار", 11 },
                    { 319, new Guid("8886b66f-b1fd-4629-82fc-17c29c1570e1"), "ابوحميظه", 11 },
                    { 318, new Guid("dfea4217-023d-410c-a701-2bd1c930c5f6"), "آغاجاري", 11 },
                    { 317, new Guid("ca1c89b8-c2de-4303-a651-9ca7e87f22cb"), "آزادي", 11 },
                    { 316, new Guid("d1d529f3-8749-4cf7-bffa-a7f1007aea90"), "آبژدان", 11 },
                    { 315, new Guid("a293a4a1-37fa-46c4-88e0-2cfe2da75111"), "آبادان", 11 },
                    { 314, new Guid("4877aba6-1198-4853-a8aa-addb8e068beb"), "گزيک", 10 },
                    { 313, new Guid("044f2cc8-07ad-4d74-adbc-90e742402398"), "نيمبلوک", 10 },
                    { 312, new Guid("21120535-a79e-4df4-a194-afc3aed8d95c"), "نهبندان", 10 },
                    { 311, new Guid("8cb06a9d-73de-4f43-b8cc-d946bc98fc22"), "مود", 10 },
                    { 310, new Guid("79f44890-d130-49f7-9aff-d80ec356c0d5"), "محمدشهر", 10 },
                    { 309, new Guid("7c1bcb38-33bc-479f-b743-87fe81b39e0e"), "قهستان", 10 },
                    { 308, new Guid("f5eee6d7-033b-43eb-beff-9fbdf0ece2ca"), "قائن", 10 },
                    { 323, new Guid("39e83225-755e-46b9-bbcc-30dc7a431557"), "اميديه", 11 },
                    { 324, new Guid("e75c7fda-ba41-4054-8d5d-90b5efea2a77"), "انديمشک", 11 },
                    { 325, new Guid("77f28a11-712f-4ddf-aea9-7bba339f018a"), "اهواز", 11 },
                    { 326, new Guid("cc67ac0b-3a7b-464c-a7cb-07519d49c822"), "ايذه", 11 },
                    { 342, new Guid("7520d18d-743c-40a4-8dac-c3cd15eae144"), "خنافره", 11 },
                    { 341, new Guid("cc4e0ee4-d560-43a2-a019-d43e3fb849a2"), "خرمشهر", 11 },
                    { 340, new Guid("3542827e-8f3c-41fb-a451-86db55a47c20"), "حميديه", 11 },
                    { 339, new Guid("ebfb147e-caa8-4a90-9c53-9c5ef7e41cd9"), "حمزه", 11 },
                    { 338, new Guid("a90e7d1a-8853-492f-ac24-fa36184bfe6a"), "حسينيه", 11 },
                    { 337, new Guid("e14c8934-cfaa-4401-b79e-5792bbbfa688"), "حر", 11 },
                    { 336, new Guid("2e9a58b5-d3b1-46f6-ae3f-1c00b8cf57ba"), "جنت مکان", 11 },
                    { 381, new Guid("20eb1925-0074-4258-8672-b752d269cd9b"), "هويزه", 11 },
                    { 335, new Guid("076d05f5-ca20-4e67-8117-81d8571ab5fa"), "جايزان", 11 },
                    { 333, new Guid("6fbbd161-ef4f-4d0d-ba67-caf31b9a2b73"), "ترکالکي", 11 },
                    { 332, new Guid("c2b387a8-1959-4060-9a52-cc65bcfe0200"), "بيدروبه", 11 },
                    { 331, new Guid("ceb0b896-3442-4e39-a6e8-17d7933eef2e"), "بهبهان", 11 },
                    { 330, new Guid("4e1d28b6-29d8-4305-8c00-4f2f4491b4d7"), "بندر ماهشهر", 11 },
                    { 329, new Guid("126454b4-c73b-4225-a43e-970168bbba00"), "بندر امام خميني", 11 },
                    { 328, new Guid("7b2aca7a-d143-4c7a-ad56-ea52dc8c8a23"), "بستان", 11 },
                    { 327, new Guid("c930adb4-1c7a-4a48-a119-d0a6e1a4a881"), "باغ ملک", 11 },
                    { 334, new Guid("786cb243-9385-49e0-9502-690867eb169b"), "تشان", 11 },
                    { 382, new Guid("a9b4e11b-cdec-447f-a073-2c77a306401b"), "ويس", 11 },
                    { 374, new Guid("a57edee2-5f30-4c4d-a776-670aad05de38"), "ملاثاني", 11 },
                    { 384, new Guid("b9b6a587-7609-4048-a502-710c7e3058dc"), "چم گلک", 11 },
                    { 438, new Guid("3edf047e-ef04-421b-ab82-e1b76285b4f4"), "سلطانيه", 13 },
                    { 437, new Guid("70096ebd-2597-4e11-b1fd-49bd994dfe1b"), "سجاس", 13 },
                    { 436, new Guid("48a4d9ca-8adb-45ae-b0a6-5aeace8ba8ed"), "زنجان", 13 },
                    { 435, new Guid("95d2d606-34ab-4d82-a6ae-d1f829ffcb86"), "زرين رود", 13 },
                    { 434, new Guid("5bcf9533-1578-4f8c-9acb-4b001a1a55f9"), "زرين آباد", 13 },
                    { 433, new Guid("cd17a5fd-760e-4d1e-ac47-ca401c944525"), "دندي", 13 },
                    { 432, new Guid("253579ba-594c-4143-91c3-c0376b4909bf"), "خرمدره", 13 },
                    { 431, new Guid("d8cb409d-c143-4e66-ba38-306c0c342ed0"), "حلب", 13 },
                    { 383, new Guid("c55539b0-37d3-497e-8d5d-eaba8740c9af"), "چغاميش", 11 },
                    { 429, new Guid("9b9e6c6e-3f29-456d-a984-0990ed04184f"), "ابهر", 13 },
                    { 428, new Guid("9edcac70-94e7-4a8d-b817-96b84fa735f0"), "آب بر", 13 },
                    { 427, new Guid("d77136d4-e9c6-40e4-8c1a-8fed835efb4b"), "کلمه", 12 },
                    { 426, new Guid("c1454f66-7e94-455c-8593-f2db9447bf4d"), "کاکي", 12 },
                    { 425, new Guid("b084e187-05bb-4168-afc4-3ddfb4940843"), "چغادک", 12 },
                    { 424, new Guid("17695443-0d95-4bef-aa90-4325942adb84"), "وحدتيه", 12 },
                    { 439, new Guid("6a81c1e5-9c5d-4c12-ba52-7f687c6c453b"), "سهرورد", 13 },
                    { 423, new Guid("773b25ba-ed29-48d6-abd7-4283400676a0"), "نخل تقي", 12 },
                    { 440, new Guid("888cee70-7372-4b45-81ed-f3240344b23c"), "صائين قلعه", 13 },
                    { 442, new Guid("3fc919dd-f831-4571-ab38-182f2e7dc27c"), "ماه نشان", 13 },
                    { 457, new Guid("4dfcfb72-950c-4d50-ba89-a71f94b29982"), "خان ببين", 14 },
                    { 456, new Guid("b236e9bf-cd6e-4f95-b57d-eac06972be23"), "جلين", 14 },
                    { 455, new Guid("9086381a-8077-49c0-a97e-b251262eb578"), "تاتار عليا", 14 },
                    { 454, new Guid("4a3117f1-d5dc-48d9-9137-2173c39bffe7"), "بندر گز", 14 },
                    { 453, new Guid("ef15c32d-edaa-4091-8017-d52429a04575"), "بندر ترکمن", 14 },
                    { 452, new Guid("ca55b4e3-323e-4e24-b8c2-bd4035ab45b6"), "اينچه برون", 14 },
                    { 451, new Guid("855e05f7-f11a-4c96-b176-6fa8b7d05dda"), "انبار آلوم", 14 },
                    { 450, new Guid("1af39243-bf27-4063-991d-b482866bd61e"), "آق قلا", 14 },
                    { 449, new Guid("71e7fa4b-ebba-49bf-9356-f8b8bc0f5276"), "آزاد شهر", 14 },
                    { 448, new Guid("960d7ca2-1e88-44d7-bed2-a89c042ea893"), "گرماب", 13 },
                    { 447, new Guid("3429a59c-aa77-4c9f-9b3d-bfe1bc7b3614"), "کرسف", 13 },
                    { 446, new Guid("e4fea466-2df1-4087-b7ce-f7afb9491425"), "چورزق", 13 },
                    { 445, new Guid("6f5213db-8f20-40bd-83d0-ceabfb093bbe"), "هيدج", 13 },
                    { 444, new Guid("4137235e-3936-473f-8a64-a899fba371d7"), "نيک پي", 13 },
                    { 443, new Guid("2037d422-6ae9-48e8-8df8-60ecd0020476"), "نوربهار", 13 },
                    { 441, new Guid("717bf960-080e-44eb-b261-7afda034f00b"), "قيدار", 13 },
                    { 422, new Guid("4949d6f6-fb50-4bce-9cb3-79e2b4b3cd66"), "عسلويه", 12 },
                    { 430, new Guid("d72c01b8-ac3f-4da5-a112-6fbb44a4a08d"), "ارمخانخانه", 13 },
                    { 420, new Guid("9742887f-0188-42a6-91a1-b1830e833bc7"), "شبانکاره", 12 },
                    { 399, new Guid("ad3b7800-4dec-494e-b682-5ca9e8655008"), "برازجان", 12 },
                    { 398, new Guid("3fba483b-8d83-4547-9019-f38be2728129"), "بادوله", 12 },
                    { 397, new Guid("7f455ac1-03dc-4778-ad34-77339fbb102b"), "اهرم", 12 },
                    { 396, new Guid("c1bbc196-3efc-42f5-bfc8-61ef3abcd007"), "انارستان", 12 },
                    { 395, new Guid("f637f7a5-7a29-4b04-9618-e9bf3c6c56c0"), "امام حسن", 12 },
                    { 394, new Guid("c663191c-ed98-4cb8-9552-92e8c0cd08fd"), "آبپخش", 12 },
                    { 421, new Guid("65d57124-1b15-4669-9dab-3d890b890bd8"), "شنبه", 12 },
                    { 392, new Guid("4976ffbe-4823-49c8-a10a-a20fdd6adf62"), "آباد", 12 },
                    { 391, new Guid("3fd579b3-548f-48e4-bf65-40bc9dea7f1d"), "گوريه", 11 },
                    { 390, new Guid("98ae6e4b-9deb-401d-88e2-5b918b27ca02"), "گلگير", 11 },
                    { 389, new Guid("adec59b6-3f76-41bf-875e-eecec7634448"), "گتوند", 11 },
                    { 388, new Guid("14f1c7c4-2649-464d-b70c-205816dcb390"), "کوت عبدالله", 11 },
                    { 387, new Guid("54bbda61-7859-4602-85e2-2d83b2bda7b2"), "کوت سيدنعيم", 11 },
                    { 386, new Guid("5ecee57f-35b0-463d-bda4-05a407dcefab"), "چوئبده", 11 },
                    { 385, new Guid("615e912f-15f0-4285-baee-dd8e61a8abef"), "چمران", 11 },
                    { 400, new Guid("904d9739-671e-40a9-9f51-d65554a80744"), "بردخون", 12 },
                    { 401, new Guid("3ba87b60-1d5a-4834-a1cd-f26232c23b23"), "بردستان", 12 },
                    { 393, new Guid("bf9aa4d9-5eb5-4711-919e-b40f7b854daa"), "آبدان", 12 },
                    { 403, new Guid("eb49a5ab-db36-4368-8514-f6a460669acd"), "بندر ديلم", 12 },
                    { 402, new Guid("17e43a75-97d1-4042-9ea7-a7c15b993842"), "بندر دير", 12 },
                    { 419, new Guid("72bf2c7d-6d42-49d6-a070-f5ea15444143"), "سيراف", 12 },
                    { 418, new Guid("48f21710-ebf6-467a-8974-fa7a81d8b2c5"), "سعد آباد", 12 },
                    { 417, new Guid("637a60fb-1f53-498e-8bab-5a0545ab7932"), "ريز", 12 },
                    { 416, new Guid("00e5492f-49c8-47bb-a934-38819bc61d2d"), "دوراهک", 12 },
                    { 414, new Guid("6f22e2da-58a4-4b93-9f8c-fe384984ac74"), "دالکي", 12 },
                    { 413, new Guid("01404ab3-6a32-4620-ae68-b414a31b3d54"), "خورموج", 12 },
                    { 412, new Guid("54999306-8f2c-4a1f-a44b-cb67737c9515"), "خارک", 12 },
                    { 415, new Guid("45f7f1b6-96e0-4926-98c1-0f84050686d6"), "دلوار", 12 },
                    { 410, new Guid("c5f00c10-0eb1-48aa-8bc1-23c359741912"), "تنگ ارم", 12 },
                    { 409, new Guid("cedb63ac-16f4-4ec2-9b17-a169108ef5b4"), "بوشکان", 12 },
                    { 408, new Guid("c73f79cf-a463-4e23-9956-01f60f9b8a98"), "بوشهر", 12 },
                    { 407, new Guid("37b74246-ae39-4a09-8b67-d3098f8732ad"), "بنک", 12 },
                    { 406, new Guid("265263de-72ec-425c-ba9b-184800807600"), "بندر گناوه", 12 },
                    { 405, new Guid("e22403e5-fb27-4720-9728-10fe8c098a2f"), "بندر کنگان", 12 },
                    { 404, new Guid("ccb2533a-e487-4a65-9e51-8a51c81332e9"), "بندر ريگ", 12 },
                    { 411, new Guid("cee23791-6052-4224-9c23-150a7083eda0"), "جم", 12 }
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
                values: new object[] { 1, new DateTime(2020, 5, 31, 15, 29, 22, 151, DateTimeKind.Local).AddTicks(8074), "Kavenegar", 1, new Guid("97a9cf05-865b-4553-8b48-bf0e67ac4ef2") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 5, null, null, new Guid("ec280897-5121-41fb-9998-03a0d099b537"), null, null, "تاسیسات", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8111), 3, null, 1 },
                    { 31, null, null, new Guid("32840171-1287-4a85-9774-4fe0421c7f0c"), null, null, "سرویس و تعمیر خودرو", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8348), 4, null, 3 },
                    { 30, null, null, new Guid("3406b5d6-dd6b-4041-b40e-60fdbb335a6f"), null, null, "اجاره خودرو", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8338), 4, null, 2 },
                    { 29, null, null, new Guid("659b989f-bd5d-49bd-bafa-b929bee4957d"), null, null, "اتوبار", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8331), 4, null, 1 },
                    { 21, null, null, new Guid("c0242e69-67b4-4c59-9634-9411705a0bc2"), null, null, "کار در ارتفاع", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8268), 3, null, 17 },
                    { 20, null, null, new Guid("256244bb-f571-440f-807b-14a750a70436"), null, null, "آسانسور و بالابر", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8260), 3, null, 16 },
                    { 19, null, null, new Guid("aebfe70d-b2b1-4832-b4f3-fc66df39c20e"), null, null, "نجاری", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8227), 3, null, 15 },
                    { 18, null, null, new Guid("014bf726-935c-4b8a-a870-0f5939b2e564"), null, null, "تعمیرات لوازم خانگی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8220), 3, null, 14 },
                    { 16, null, null, new Guid("e1d789de-a417-49f5-adca-b12e8b294fde"), null, null, "عایق کاری", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8206), 3, null, 12 },
                    { 15, null, null, new Guid("0b9a97c2-3588-4191-b774-d067455d18e8"), null, null, "عایق کاری", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8199), 3, null, 11 },
                    { 17, null, null, new Guid("3477ccb4-d7d1-4182-8e3e-4d4f2c1270c2"), null, null, "نرده و حفاظ استیل", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8213), 3, null, 13 },
                    { 13, null, null, new Guid("f6487b10-c99d-4b9a-bd2e-19045431d6dc"), null, null, "بنایی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8181), 3, null, 9 },
                    { 12, null, null, new Guid("e240469f-f87d-4a4a-bf79-2cb38e99a4c7"), null, null, "دکوراسیون داخلی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8173), 3, null, 8 },
                    { 11, null, null, new Guid("39aac5f2-d73c-4793-a9ef-58b0d34acc31"), null, null, "کابینت سازی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8166), 3, null, 7 },
                    { 10, null, null, new Guid("5286785f-74fc-4fa8-8e8e-ea9c39bac4ce"), null, null, "شیشه بری و قابسازی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8159), 3, null, 6 },
                    { 9, null, null, new Guid("cb90a321-8eb8-4aec-8396-2985f5e28bc5"), null, null, "آلومینیوم سازی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8151), 3, null, 5 },
                    { 8, null, null, new Guid("66f93429-c99a-4db3-8905-99aecb716f61"), null, null, "مبلمان", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8143), 3, null, 4 },
                    { 7, null, null, new Guid("bb9cf753-2340-4156-a16a-b4da29bb6e8c"), null, null, "ایمنی و امنیت", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8135), 3, null, 3 },
                    { 6, null, null, new Guid("b0007142-5302-487d-acf5-07ed92bf086f"), null, null, "الکتریکی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8121), 3, null, 2 },
                    { 14, null, null, new Guid("de5f9c38-9778-4dbe-8ae8-dc472d33b13c"), null, null, "آهنگری", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8188), 3, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 31, 15, 29, 22, 152, DateTimeKind.Local).AddTicks(2989), "VerifyAccount", 1, new Guid("37078822-c939-4e93-9e5b-2e056e34938f") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "GenderCodeID", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "ProfileDocumentID", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 4, "white.luciferrr@gmail.com", "محمد", 8, true, true, "میرزایی", new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(6496), "09147830093", null, new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(6493), 2, new Guid("cdd61d0e-16f1-4b2e-8799-1d0a0e339b3b") },
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", 8, true, true, "رودکی", new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(4094), "09227204305", null, new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(3538), 1, new Guid("ec4ad1b4-dc7a-4048-887f-482333415571") },
                    { 2, "roozbehshamekhi@hotmail.com", "روزبه", 8, true, true, "شامخی", new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(6440), "09128277075", null, new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(6418), 3, new Guid("031ce13e-678a-4fb5-97b5-69fa42d85de1") },
                    { 3, "dead.hh98@gmail.com", "حامد", 8, true, true, "حقیقیان", new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(6483), "09108347428", null, new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(6479), 2, new Guid("78d16ba2-a83c-4479-8c49-63c7a2c899b1") }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "AdminGUID", "IsDelete", "ModifiedDate", "UserID" },
                values: new object[] { 1, new Guid("865f87b9-660d-4ad8-a25c-0566e983ba8a"), false, new DateTime(2020, 5, 31, 15, 29, 22, 154, DateTimeKind.Local).AddTicks(8679), 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 22, null, null, new Guid("dd6b1cb2-7abc-4c73-a57a-f885d68127aa"), null, null, "سرویس کولر آبی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8276), 5, null, 1 },
                    { 23, null, null, new Guid("37c98adc-2089-4123-ae98-69c6e5201dbc"), null, null, "نقاشی ساختمان", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8287), 5, null, 2 },
                    { 24, null, null, new Guid("e562f9c2-70ff-44eb-be6a-fd2778231ebe"), null, null, "رنگ کاری مبل", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8294), 8, null, 1 },
                    { 25, null, null, new Guid("0e6ec30b-427c-41de-a53f-26315ef6887a"), null, null, "تعمیر صندلی اداری", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8302), 8, null, 2 },
                    { 26, null, null, new Guid("fd0817a6-0c70-4f36-ab22-d28f75d3a760"), null, null, "ساخت مبلمان", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8309), 8, null, 3 },
                    { 27, null, null, new Guid("4b5e2557-011c-44d5-bd3b-82929b52e139"), null, null, "دوخت کاور مبل", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8316), 8, null, 4 },
                    { 28, null, null, new Guid("aaf5fd69-e3ca-48ed-9dbd-17f74c54fa1c"), null, null, "تعمیر مبل", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8323), 8, null, 5 },
                    { 32, null, null, new Guid("bf34042e-0b65-4411-ad98-f9b9be25fd9c"), null, null, "وانت بار", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8355), 29, null, 1 },
                    { 33, null, null, new Guid("7ca27d6a-e162-4424-a1e3-059f3774fd25"), null, null, "باربری و اتوبار", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8363), 29, null, 2 },
                    { 34, null, null, new Guid("81d368ec-bfdf-4b24-be78-0128185963fd"), null, null, "کارگر اسباب کشی", null, true, new DateTime(2020, 5, 31, 15, 29, 22, 159, DateTimeKind.Local).AddTicks(8370), 29, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "CityID", "ClientGUID", "ModifiedDate", "UserID" },
                values: new object[] { 1, 751, new Guid("fbe3f6f2-6770-4cb8-bb98-791dc01d0677"), new DateTime(2020, 5, 31, 15, 29, 22, 155, DateTimeKind.Local).AddTicks(4823), 2 });

            migrationBuilder.InsertData(
                table: "Contractor",
                columns: new[] { "ContractorID", "AverageRate", "BusinessTypeCodeID", "CityID", "ContractorGUID", "Credit", "Latitude", "Longitude", "ModifiedDate", "UserID" },
                values: new object[,]
                {
                    { 1, null, 4, 751, new Guid("90d46f9f-ef04-437f-a27c-4f0a44df01f7"), 0, "1", "2", new DateTime(2020, 5, 31, 15, 29, 22, 156, DateTimeKind.Local).AddTicks(5208), 3 },
                    { 2, null, 4, 751, new Guid("5d92c92e-4865-4c17-99cb-a43d8d95ccfc"), 10000, "1", "2", new DateTime(2020, 5, 31, 15, 29, 22, 156, DateTimeKind.Local).AddTicks(5922), 4 }
                });

            migrationBuilder.InsertData(
                table: "ContractorCategory",
                columns: new[] { "ContractorCategoryID", "CategoryID", "ContractorCategoryGUID", "ContractorID" },
                values: new object[,]
                {
                    { 1, 4, new Guid("ff00eb64-28c5-432a-bb85-e62a3e49c5ea"), 1 },
                    { 2, 5, new Guid("6e6cad59-eb11-4b9a-81e4-01cf70ab408b"), 1 },
                    { 3, 14, new Guid("27b1400b-3c9e-4c30-b2e3-e29b4683ccd5"), 1 },
                    { 4, 22, new Guid("9981ac32-1e7d-4f7e-adf4-fb374f0f2165"), 1 },
                    { 5, 25, new Guid("f02c0ebf-9ae0-4dff-8ddd-9ffddb6605cc"), 1 },
                    { 6, 30, new Guid("8c787195-4463-4dba-822c-7fa6d9f1b522"), 1 },
                    { 7, 33, new Guid("d65262da-7f25-4c76-ab52-b2940f4f30fe"), 1 },
                    { 8, 34, new Guid("a27bae18-fa4f-4772-96cd-e1b642124fb6"), 1 },
                    { 9, 27, new Guid("1e2472f0-b9d1-46f9-aafa-4ddc7df0e07c"), 1 },
                    { 10, 20, new Guid("aea85e1d-9772-422b-863e-481dd964c5bf"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderID", "CategoryID", "ClientID", "Comment", "ContractorID", "Cost", "DeadlineDate", "Description", "ModifiedDate", "OrderGUID", "Rate", "StateCodeID", "Title" },
                values: new object[,]
                {
                    { 1, 14, 1, null, null, null, null, "توضیح", new DateTime(2020, 5, 31, 15, 29, 22, 157, DateTimeKind.Local).AddTicks(5950), new Guid("e763b9e9-f39c-4a92-94e4-6555edc85d50"), null, 9, "تیتر" },
                    { 2, 22, 1, null, null, null, null, "کولر ماشین مشکل داره", new DateTime(2020, 5, 31, 15, 29, 22, 157, DateTimeKind.Local).AddTicks(7227), new Guid("74559ca5-8da9-4b73-b558-535f57484aeb"), null, 9, "مشکل" }
                });

            migrationBuilder.InsertData(
                table: "OrderRequest",
                columns: new[] { "OrderRequestID", "ContractorID", "IsAllow", "Message", "ModifiedDate", "OfferedPrice", "OrderID", "OrderRequestGUID" },
                values: new object[] { 1, 1, true, "پیام", new DateTime(2020, 5, 31, 15, 29, 22, 158, DateTimeKind.Local).AddTicks(2732), 250000L, 1, new Guid("4840c276-52db-46db-a208-959844a3e9f3") });

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
