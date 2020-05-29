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
                    { 1, null, null, new Guid("c265fd02-0194-4d38-83e8-a93bc3698fcc"), null, null, "سایت اصلی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(722), null, null, 1 },
                    { 2, null, null, new Guid("dec37f17-0ab2-4208-8ba7-11cc1120369b"), null, null, "وبلاگ", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3646), null, null, 2 }
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
                    { 5, new Guid("0e0e5d1a-ba22-41b1-8ecc-4e030cfbe235"), "نقش", "Role" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("862c4398-ad55-405b-85c5-a078b9d4c7ea") },
                    { 20, "ايلام", new Guid("89d80177-de65-4ece-93b5-35dc38028404") },
                    { 21, "تهران", new Guid("07c9fb0c-c2e3-4296-96b7-f9a1d312e3f8") },
                    { 22, "آذربايجان شرقي", new Guid("769cad13-4f11-4b52-8a57-bcfdc3a150ed") },
                    { 23, "فارس", new Guid("f1a763fc-cbe8-42ca-9cc6-4dee1d57d881") },
                    { 24, "کرمانشاه", new Guid("5ffc28f4-392f-406c-9ed4-64dcb22bae9a") },
                    { 28, "همدان", new Guid("65f144f7-d5f7-4bc5-b16d-159adc903047") },
                    { 26, "مرکزي", new Guid("01b26b7d-5f16-4891-9321-74443b5c2654") },
                    { 27, "گيلان", new Guid("06963ae5-8862-4513-aaba-942e1527451f") },
                    { 18, "اردبيل", new Guid("f92638a3-9759-48a3-96e6-01e3dc7d531b") },
                    { 29, "کرمان", new Guid("836ca7f6-28e6-48c0-b169-239e639f2985") },
                    { 30, "سمنان", new Guid("fc194e99-9ab3-4ed9-b7a2-344b8ec72552") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("5fd38fa1-c763-4d1b-8ee1-83588642e20d") },
                    { 25, "هرمزگان", new Guid("2ca20b09-ac31-4cf0-a1f2-8c6e5a519c78") },
                    { 17, "لرستان", new Guid("91b9d8ad-ca7d-4834-baad-15a903398122") },
                    { 14, "گلستان", new Guid("3e6055b3-790f-4839-a302-e0ad18e45c7a") },
                    { 15, "مازندران", new Guid("4365fc4e-7a8a-4cc0-b784-43779ed143f5") },
                    { 1, "يزد", new Guid("93bd0bfe-c607-4cbb-b7a5-8e8718751328") },
                    { 2, "چهار محال و بختياري", new Guid("c0fb5567-30a7-4c84-a9d2-1a0692a1fdd3") },
                    { 3, "خراسان شمالي", new Guid("62838f52-6dcc-4e27-98d5-098a8a4cb0d9") },
                    { 4, "البرز", new Guid("cc857539-6e6a-4ffa-919b-45a74a5ca451") },
                    { 5, "قم", new Guid("8a7bddbb-1a36-497a-814f-c397621e5ecc") },
                    { 16, "قزوين", new Guid("580e1c80-a0ae-414b-b322-92e8b73da915") },
                    { 7, "آذربايجان غربي", new Guid("42a98007-7385-4039-a587-0e6aa5f1bd42") },
                    { 6, "کردستان", new Guid("1119e473-10ed-4cc2-9b0d-466ef437f832") },
                    { 9, "سيستان و بلوچستان", new Guid("0d1420a0-eb82-4dc0-a19c-34f260009427") },
                    { 10, "خراسان جنوبي", new Guid("ff7b153a-3818-419d-a989-64fc436c1109") },
                    { 11, "خوزستان", new Guid("1b86f60b-9fa5-43bd-8d55-a49e78701af7") },
                    { 12, "بوشهر", new Guid("d1bcc22c-736e-4c4e-99e0-4477f1377fd3") },
                    { 13, "زنجان", new Guid("6f63e4c8-7e31-46ec-8e56-75ab2cd16cf0") },
                    { 8, "خراسان رضوي", new Guid("a5eeed3e-1b23-4be0-835a-8dca3dca01c1") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 3, "سرویس گیرنده", new DateTime(2020, 5, 29, 14, 47, 44, 745, DateTimeKind.Local).AddTicks(542), "Client", new Guid("7df210a5-af5a-4d67-802e-dc39afbd6652") },
                    { 1, "ادمین", new DateTime(2020, 5, 29, 14, 47, 44, 744, DateTimeKind.Local).AddTicks(9331), "Admin", new Guid("df2cf68f-54a3-48cc-880f-a9ba5e4fa194") },
                    { 2, "سرویس دهنده", new DateTime(2020, 5, 29, 14, 47, 44, 745, DateTimeKind.Local).AddTicks(501), "Contractor", new Guid("5ac686f1-0869-49dc-bb3c-0b5cfc74df07") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 5, 29, 14, 47, 44, 738, DateTimeKind.Local).AddTicks(8844), "ptcoptco", new Guid("c30bcbe3-5fcc-4843-bb03-58a9312a493f"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 3, null, null, new Guid("96e893e7-535c-465b-96e5-4a73f6099e02"), null, null, "خانه", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3742), 1, null, 1 },
                    { 4, null, null, new Guid("2dddd1fb-5bf1-464c-9bb4-748bc8f543bb"), null, null, "حمل و نقل", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3775), 1, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 826, new Guid("1674ed9d-09bb-439e-87ba-6aca03ca9503"), "ليلان", 22 },
                    { 825, new Guid("5a86f16f-ac70-4e25-b139-8d1af1585732"), "قره آغاج", 22 },
                    { 824, new Guid("c6525038-046b-408a-8992-3e4d8c0e849e"), "عجب شير", 22 },
                    { 823, new Guid("c62dcace-68d9-43d1-a51e-5f106da0233b"), "صوفيان", 22 },
                    { 822, new Guid("a1cd9409-12e5-4550-b66c-22816e995d01"), "شهر جديد سهند", 22 },
                    { 821, new Guid("c599be8a-6a45-4b12-af93-8c287f30ba21"), "شند آباد", 22 },
                    { 820, new Guid("289822a1-9ebe-4841-a841-b43b435e1d97"), "شرفخانه", 22 },
                    { 819, new Guid("75d9aa66-2282-43c8-9426-e5e6d3162025"), "شربيان", 22 },
                    { 818, new Guid("22fcdc01-8a59-464c-a81e-fe7c91f68d76"), "شبستر", 22 },
                    { 817, new Guid("5c6cd4f2-3efc-4eec-a3df-5a435812cb54"), "سيه رود", 22 },
                    { 816, new Guid("811a98c4-2ff4-4efd-bb8d-a570deed4371"), "سيس", 22 },
                    { 815, new Guid("6ac1dba9-e26c-416a-92c2-c7bdf9febcd2"), "سردرود", 22 },
                    { 814, new Guid("8598dcb1-aba7-4bbd-b01f-003f40e0687a"), "سراب", 22 },
                    { 813, new Guid("e842290a-8cad-447c-b292-80f6779d1772"), "زنوز", 22 },
                    { 812, new Guid("ed074993-33ad-46b3-a849-6db48e8e7d5f"), "زرنق", 22 },
                    { 827, new Guid("2db4438d-27ba-4bed-a0e9-03dd9c83effe"), "مبارک شهر", 22 },
                    { 828, new Guid("d9b442c0-1499-46e2-b6ff-6e7ab3a25585"), "مراغه", 22 },
                    { 829, new Guid("c427c2d6-5f7c-45bb-8fee-687444876cf0"), "مرند", 22 },
                    { 830, new Guid("14b36653-dbab-4456-9646-2e1120e0e45f"), "ملکان", 22 },
                    { 846, new Guid("8c5242af-d127-406f-9622-287bbd29a061"), "گوگان", 22 },
                    { 845, new Guid("13e19085-1560-4524-ab39-02ccb81ecf61"), "کوزه کنان", 22 },
                    { 844, new Guid("ee104e60-85da-4d60-bcc0-08ee55670a8d"), "کليبر", 22 },
                    { 843, new Guid("e843373c-ce90-4fe1-83e0-1a2efe2f3eed"), "کلوانق", 22 },
                    { 842, new Guid("5a244d59-a5fc-410f-9824-f01d620f0fe2"), "کشکسراي", 22 },
                    { 841, new Guid("caf74feb-8b0f-4391-9975-e9d993d405e0"), "يامچي", 22 },
                    { 840, new Guid("8317a822-0299-4b73-a2e6-55bd6cbf6306"), "ورزقان", 22 },
                    { 811, new Guid("0d989d81-a193-45cb-8b6e-9900c008c5a2"), "دوزدوزان", 22 },
                    { 839, new Guid("b261136d-5320-46b2-9e50-184f0d4345fe"), "وايقان", 22 },
                    { 837, new Guid("7e53dc49-db49-42b2-aeff-70ae899f6d65"), "هشترود", 22 },
                    { 836, new Guid("76e6e932-0c8e-4a13-9b74-73a975280acf"), "هريس", 22 },
                    { 835, new Guid("757f8015-31be-4b03-8d7e-341fad045e9f"), "هاديشهر", 22 },
                    { 834, new Guid("c8bbbd95-aa98-4f24-bad4-87f130b8d363"), "نظرکهريزي", 22 },
                    { 833, new Guid("1ef5685f-e17a-44a0-a8cf-862b9432f73c"), "ميانه", 22 },
                    { 832, new Guid("c31b31d8-d12a-476f-b28c-6b7816181b6d"), "مهربان", 22 },
                    { 831, new Guid("fc78e62e-acf3-4662-9b3a-e4ecfcad9e52"), "ممقان", 22 },
                    { 838, new Guid("b68e7d10-07ad-4365-bc8c-49948cdbb65b"), "هوراند", 22 },
                    { 810, new Guid("6d5a6ee3-dc4f-4c08-9356-6645b1d22e38"), "خواجه", 22 },
                    { 809, new Guid("82dcb33c-cbd3-4949-9b71-d1c8ae4284ce"), "خمارلو", 22 },
                    { 808, new Guid("6d7b9b9a-6e5a-4518-a68e-2652079afd6b"), "خسروشاه", 22 },
                    { 787, new Guid("3667c1c9-0ab0-4062-8971-fed1d06f8d2e"), "آقکند", 22 },
                    { 786, new Guid("4b92b04f-0a28-42b6-a6b8-fc07d80a042b"), "آذرشهر", 22 },
                    { 785, new Guid("a35db492-6f85-4b2c-9f9e-97da33f14bb3"), "آبش احمد", 22 },
                    { 784, new Guid("edd92686-9594-4386-8441-cbfc5629b3c5"), "گلستان", 21 },
                    { 783, new Guid("86d3be6b-c35f-4aac-9929-d8d83152d115"), "کيلان", 21 },
                    { 782, new Guid("4d46bf25-2e1e-4c2a-8a05-d09584bc21dd"), "کهريزک", 21 },
                    { 781, new Guid("75999448-d4a6-4c03-bab6-23dbbad4a79f"), "چهاردانگه", 21 },
                    { 780, new Guid("b7565c75-df78-40de-94ad-c92cf2399e0e"), "پيشوا", 21 },
                    { 779, new Guid("4708675e-1de9-46c1-81f7-f4cb1cfda17e"), "پرديس", 21 },
                    { 778, new Guid("700acbb4-c036-4e57-9c5b-633d10fca683"), "پاکدشت", 21 },
                    { 777, new Guid("c8cc5552-3b97-4858-ae36-244bce601711"), "ورامين", 21 },
                    { 776, new Guid("1563c81b-b7e1-4809-88f1-b590fc5253ca"), "وحيديه", 21 },
                    { 775, new Guid("b124459d-b306-4e6e-b3df-535919c314f5"), "نصيرشهر", 21 },
                    { 774, new Guid("a6b264a3-298d-41cb-bae4-4aaa72ddf212"), "نسيم شهر", 21 },
                    { 773, new Guid("4edfa0ce-f718-467d-a4ab-7acdba65f9f0"), "ملارد", 21 },
                    { 788, new Guid("4fa8ab5b-5172-46aa-9040-869a10a080ef"), "آچاچي", 22 },
                    { 789, new Guid("e12ebb2b-b477-4177-89bb-94e3b4cb4883"), "اسکو", 22 },
                    { 790, new Guid("fca6fb83-394c-4071-83fc-f81cb1bd811e"), "اهر", 22 },
                    { 791, new Guid("40f35b93-2932-4590-a1d6-d4629aafd226"), "ايلخچي", 22 },
                    { 807, new Guid("5fb501f2-d416-433a-a04b-4af8812c4274"), "خداجو", 22 },
                    { 806, new Guid("4cb028b1-7d90-4992-9db7-0ea7fcdf90fc"), "خامنه", 22 },
                    { 805, new Guid("2fd23b38-b327-455d-be1a-b051ee403ba5"), "خاروانا", 22 },
                    { 804, new Guid("42ab7668-fb26-44c2-9e5a-1d0cca0c0614"), "جوان قلعه", 22 },
                    { 803, new Guid("5b2ac709-1ff5-4e22-8998-ebee22ebfa73"), "جلفا", 22 },
                    { 802, new Guid("161fe927-e2ee-4114-a880-c9e938b89662"), "تيکمه داش", 22 },
                    { 801, new Guid("38709c6e-9533-4268-b461-fee02722ab6a"), "تيمورلو", 22 },
                    { 847, new Guid("d3977536-fefb-4d27-b574-b5bf31f575de"), "آباده", 23 },
                    { 800, new Guid("98db0324-2fed-427e-979a-86f873c3e043"), "تسوج", 22 },
                    { 798, new Guid("11d5d05f-0273-4bfa-a945-b9a9efadefc7"), "ترک", 22 },
                    { 797, new Guid("ddc8f032-e94b-42b9-ad2c-496f32518eca"), "تبريز", 22 },
                    { 796, new Guid("b4f4ebcc-b77c-4ef1-aa92-c2b100548fcb"), "بناب مرند", 22 },
                    { 795, new Guid("e05db9ec-73df-46db-ae75-feba2096d62c"), "بناب", 22 },
                    { 794, new Guid("2b3187d4-09fe-44e1-a727-2d94f2a56d92"), "بستان آباد", 22 },
                    { 793, new Guid("4c7f2e75-c71c-42a7-baa4-a409a6d87c5f"), "بخشايش", 22 },
                    { 792, new Guid("579d3e1d-44dd-4edd-ab79-5857a2114598"), "باسمنج", 22 },
                    { 799, new Guid("e851b7ea-b756-48f9-92eb-f7e9e0894ecb"), "ترکمانچاي", 22 },
                    { 848, new Guid("bb2c3ad6-e16d-4ff4-97ab-c14e88e6f553"), "آباده طشک", 23 },
                    { 849, new Guid("4f4c3459-da3b-46a0-8893-9f7f27bbf624"), "اردکان", 23 },
                    { 850, new Guid("e08d1908-73d8-4432-a272-4c044bf1416f"), "ارسنجان", 23 },
                    { 905, new Guid("47fe4e6d-347f-42ba-8cf5-a6b9384f4ece"), "صغاد", 23 },
                    { 904, new Guid("145fc4f0-4f5d-44b3-86bc-3e8bbaa0fa8f"), "شيراز", 23 },
                    { 903, new Guid("be2fbc32-c0c9-4d2c-ba1e-c7a7a3c9bd37"), "شهر پير", 23 },
                    { 902, new Guid("f80ba306-9326-481f-990a-105d196d222d"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("d1b1334d-4bbf-426b-8f46-f016ad8b6fd4"), "ششده", 23 },
                    { 900, new Guid("9d83fbe1-bb57-4977-9efe-d4418218cc0f"), "سيدان", 23 },
                    { 899, new Guid("ad9a6835-b62c-4621-a5b9-dbc380865cb1"), "سورمق", 23 },
                    { 898, new Guid("559e49a8-0d94-43f0-a559-fc2207cfef13"), "سلطان شهر", 23 },
                    { 897, new Guid("b11067a0-d899-4787-994b-c446f09c001a"), "سعادت شهر", 23 },
                    { 896, new Guid("e195e6e6-6871-4e5b-905d-6f9dfbbb2f4f"), "سروستان", 23 },
                    { 895, new Guid("00c6a6ef-6a63-4000-995e-a05ccd271695"), "سده", 23 },
                    { 894, new Guid("0591eade-2c51-465d-a866-0890fa1ba5cf"), "زرقان", 23 },
                    { 893, new Guid("882944a0-89c9-40c2-8f27-12494e502280"), "زاهد شهر", 23 },
                    { 892, new Guid("383e44e9-00a4-44be-8086-90555c4e79e0"), "رونيز", 23 },
                    { 891, new Guid("06269336-707c-4636-a3bb-dcd817a6ecbb"), "رامجرد", 23 },
                    { 906, new Guid("4c0f07b3-2bc9-4a40-8962-40223ea9d732"), "صفا شهر", 23 },
                    { 907, new Guid("6ae0da05-5d09-4212-8c46-e984f9c4c50c"), "علامرودشت", 23 },
                    { 908, new Guid("9c0d4b46-b261-4e14-a57b-df5e3a445050"), "عماد ده", 23 },
                    { 909, new Guid("d568c712-dbf7-4c28-b7f3-45df16650518"), "فدامي", 23 },
                    { 925, new Guid("51ba797f-0e31-4674-8fcd-cd80a5a38b47"), "مرودشت", 23 },
                    { 924, new Guid("5004d29e-4915-4639-b206-74afb180d64b"), "مبارک آباد", 23 },
                    { 923, new Guid("68a33d9c-161b-494a-b612-0f7833b3dc9f"), "مادرسليمان", 23 },
                    { 922, new Guid("e7d2681c-d0e0-493f-a24b-59a75ac4f32a"), "لپوئي", 23 },
                    { 921, new Guid("c21e4760-7e3c-44e7-a8c3-e36819c885f4"), "لطيفي", 23 },
                    { 920, new Guid("9abb268f-f879-4892-b07a-f8e924cffef8"), "لامرد", 23 },
                    { 919, new Guid("5e49ee0a-6e89-477f-bf34-e17ad4fb6d4e"), "لار", 23 },
                    { 890, new Guid("f2d417a0-94ea-4af9-ad94-7a32185a6fa2"), "دژکرد", 23 },
                    { 918, new Guid("1a36d78b-5973-407f-8216-c09d205b450b"), "قير", 23 },
                    { 916, new Guid("f2fd6c31-90ca-4060-8ffb-f42b236807a4"), "قطب آباد", 23 },
                    { 915, new Guid("1b8eff04-28c4-41da-ae92-e23e02406bca"), "قره بلاغ", 23 },
                    { 914, new Guid("3026e811-0efc-44e6-9b42-88547c12a09d"), "قادرآباد", 23 },
                    { 913, new Guid("8bc617fc-f94b-4b8e-bf45-10245a9180e3"), "قائميه", 23 },
                    { 912, new Guid("7baf0832-bc84-489f-accb-2c8bc7f563a8"), "فيروزآباد", 23 },
                    { 911, new Guid("485712ba-3041-46bc-abd1-14787275064c"), "فسا", 23 },
                    { 910, new Guid("ae225ca1-0917-4244-aa54-de18e48d3b39"), "فراشبند", 23 },
                    { 917, new Guid("b3674541-faeb-4c3b-8fb0-ae9a309a3431"), "قطرويه", 23 },
                    { 889, new Guid("df28e313-c536-4744-a4f8-3d28eb058929"), "دوزه", 23 },
                    { 888, new Guid("9f19005f-6072-4642-a8ad-d52d46547aa1"), "دوبرجي", 23 },
                    { 887, new Guid("5e431ce2-afdc-4ede-94ec-e2176f2ef865"), "دهرم", 23 },
                    { 866, new Guid("afea7eeb-d842-49f9-a837-96d43437383a"), "بوانات", 23 },
                    { 865, new Guid("269ca6cb-4fe3-4be6-9768-18e0796f5657"), "بهمن", 23 },
                    { 864, new Guid("20e60161-2541-4e1b-a136-0a248e683320"), "بنارويه", 23 },
                    { 863, new Guid("d7675b2b-1a49-4729-9444-db1ef67bc114"), "بالاده", 23 },
                    { 862, new Guid("41d2477f-3836-4924-92f0-12299eb7527e"), "بابامنير", 23 },
                    { 861, new Guid("33ea6b06-d13b-4a4d-a98e-f98593efca95"), "باب انار", 23 },
                    { 860, new Guid("2940bc97-d0d1-4eb7-8495-0d5b5f984fa1"), "ايزد خواست", 23 },
                    { 867, new Guid("8242b2ba-acac-49ec-9b96-fd023fcfc000"), "بيرم", 23 },
                    { 859, new Guid("ceb40261-d53f-4f5f-99d3-d3f3e8f84145"), "ايج", 23 },
                    { 857, new Guid("0beaec88-754e-4404-91e3-04768083e7a6"), "اهل", 23 },
                    { 856, new Guid("f5f666b7-57e0-43b8-b534-7894a0236384"), "امام شهر", 23 },
                    { 855, new Guid("85b4d0fb-b2d3-4bed-8616-b46abed3df2a"), "اقليد", 23 },
                    { 854, new Guid("a3a45fe8-5a1a-49a4-ae7c-ba6eaa2608dd"), "افزر", 23 },
                    { 853, new Guid("2db82a89-48a9-4f30-9060-3d66f4595f7c"), "اشکنان", 23 },
                    { 852, new Guid("80ef0f88-e2ba-4565-af0f-0b2c5650db57"), "اسير", 23 },
                    { 851, new Guid("d1852278-ef4f-4ea9-96da-2d85648f81e8"), "استهبان", 23 },
                    { 858, new Guid("14f6043f-0f05-4176-98ed-0712e5359096"), "اوز", 23 },
                    { 772, new Guid("961ab1fe-ce15-4440-8138-2a0866f9e767"), "لواسان", 21 },
                    { 868, new Guid("fc3418ea-9e22-4220-9c29-5edad0d1b93d"), "بيضا", 23 },
                    { 870, new Guid("4b367cf2-1742-436f-bb25-f546d6bcef48"), "جهرم", 23 },
                    { 886, new Guid("8cb98236-015a-414e-956c-db50b551989a"), "دبيران", 23 },
                    { 885, new Guid("dd09b2d7-acbe-45da-9b11-9dab64e8c81e"), "داريان", 23 },
                    { 884, new Guid("1bc98053-e511-4128-8d29-d9083b15805a"), "داراب", 23 },
                    { 883, new Guid("b893c2df-ade2-4139-a83c-aa83c826deee"), "خومه زار", 23 },
                    { 882, new Guid("f196a684-0184-41b2-9e16-e9b9c1f6d76d"), "خوزي", 23 },
                    { 881, new Guid("a7610967-8f83-4d1b-9e38-50d97bc4b8bd"), "خور", 23 },
                    { 880, new Guid("2c511beb-3253-4433-8716-dc565ce92036"), "خنج", 23 },
                    { 869, new Guid("756f607c-b630-4deb-b73d-150e5ebaa863"), "جنت شهر", 23 },
                    { 879, new Guid("1203353e-678d-4cb1-b804-ad462e2b9859"), "خشت", 23 },
                    { 877, new Guid("24c913d4-4136-40ed-9869-3840a6e9f028"), "خاوران", 23 },
                    { 876, new Guid("9e7c9864-b713-4c3f-90e5-36704bf35a61"), "خانيمن", 23 },
                    { 875, new Guid("88ec2fcc-75e4-4c08-b7da-360b6d0a98d1"), "خانه زنيان", 23 },
                    { 874, new Guid("57537776-2fcc-4436-bacc-68b83d527d14"), "حسن آباد", 23 },
                    { 873, new Guid("fc9d1e8c-5d2d-4624-bac3-5d0ce700e233"), "حسامي", 23 },
                    { 872, new Guid("9936b31e-4c5d-4e78-bef9-5ebab726f0f1"), "حاجي آباد", 23 },
                    { 871, new Guid("528cb9c3-891e-4df4-b705-06dc18b13dd2"), "جويم", 23 },
                    { 878, new Guid("de932c7b-0c14-4634-b669-9446f16ee549"), "خرامه", 23 },
                    { 771, new Guid("52af3636-7d8a-468f-9e35-9d302dfb81c9"), "قرچک", 21 },
                    { 770, new Guid("c9c4877a-7803-4bfe-b9fe-0d10bfa1b46e"), "قدس", 21 },
                    { 769, new Guid("45155638-cd73-40de-ac49-6f52cd9f030c"), "فيروزکوه", 21 },
                    { 669, new Guid("8803ac50-2cc3-46f0-b018-3a4e025db7df"), "عسگران", 19 },
                    { 668, new Guid("66103729-adb5-4424-9170-bedf1042f8d7"), "طرق رود", 19 },
                    { 667, new Guid("c63a0672-7f24-4301-a957-7fdf25cef216"), "طالخونچه", 19 },
                    { 666, new Guid("1a09de30-b464-449d-b3f1-820b2bad9ca9"), "شهرضا", 19 },
                    { 665, new Guid("8bfcfc42-afa8-4205-9d25-ef4b4c8f60de"), "شاپورآباد", 19 },
                    { 664, new Guid("51db3814-c427-4611-b771-040a8625802d"), "شاهين شهر", 19 },
                    { 663, new Guid("89d66912-593a-4b01-8477-1ecd022298fe"), "سگزي", 19 },
                    { 662, new Guid("58abb0af-6ea2-451c-a04c-818fb52e5987"), "سين", 19 },
                    { 661, new Guid("d4d0d8a9-f844-4fc7-a1f8-3a15dcd76df7"), "سميرم", 19 },
                    { 660, new Guid("0deb0526-e23e-46de-8fb0-45674e44b50f"), "سفيد شهر", 19 },
                    { 659, new Guid("69e45ca2-5052-4c78-ab65-fbea4c3e7083"), "سده لنجان", 19 },
                    { 658, new Guid("8e7133c5-d246-4e5e-997e-804b75cf0919"), "زيباشهر", 19 },
                    { 657, new Guid("eb9bb999-7262-4ba4-b52a-21d05cfda55b"), "زيار", 19 },
                    { 656, new Guid("b8d21a90-f91a-4e25-a4b6-c39885b6bf57"), "زواره", 19 },
                    { 655, new Guid("01c4778d-fc79-43e6-8554-f709109c2a67"), "زرين شهر", 19 },
                    { 670, new Guid("06bcb090-092e-4012-8090-d79ae92192f0"), "علويچه", 19 },
                    { 671, new Guid("6d06eb35-bef7-4dd9-a33c-aece29d0e631"), "فرخي", 19 },
                    { 672, new Guid("2d2ef456-5e57-47ca-8a49-a9663079d890"), "فريدونشهر", 19 },
                    { 673, new Guid("d488c67b-fc46-4990-a680-f74fa811f2c0"), "فلاورجان", 19 },
                    { 689, new Guid("d5fde361-3df4-4d5c-b8ea-5770e196d13c"), "نوش آباد", 19 },
                    { 688, new Guid("d2067c1f-7f87-480c-8f18-bc3a3b8a6382"), "نطنز", 19 },
                    { 687, new Guid("14d2ca9b-ea2b-43f8-afef-ac04ded98833"), "نصرآباد", 19 },
                    { 686, new Guid("4fa675f8-0292-4702-8566-0d3f69e34a48"), "نجف آباد", 19 },
                    { 685, new Guid("a0f90e1b-a039-45b9-b025-834a447228f2"), "نائين", 19 },
                    { 684, new Guid("f6ad25c2-75ff-4091-94a9-ae576d3fec72"), "ميمه", 19 },
                    { 683, new Guid("19e2274b-1373-4b7b-bbb8-17038e648a50"), "مهاباد", 19 },
                    { 654, new Guid("ea9a2de3-de1d-4ccf-9ec2-6d12d8538013"), "زاينده رود", 19 },
                    { 682, new Guid("d807d53b-c2be-44ba-b149-18b895b4c711"), "منظريه", 19 },
                    { 680, new Guid("4d1747b4-71f3-4a4d-b808-c39c3f7cd321"), "محمد آباد", 19 },
                    { 679, new Guid("797bafdd-8d46-4efa-b905-f536380ba8a2"), "مبارکه", 19 },
                    { 678, new Guid("4746dada-db35-44a1-b903-bbd4ecf06d15"), "لاي بيد", 19 },
                    { 677, new Guid("3fc2fbbe-b25a-4481-90f6-bcbb23f33d92"), "قهدريجان", 19 },
                    { 676, new Guid("d3d3cb2d-9041-455d-b3db-40555200e2ae"), "قهجاورستان", 19 },
                    { 675, new Guid("6e67678c-29f0-4646-bb5d-113945b12ae0"), "قمصر", 19 },
                    { 674, new Guid("7e69bf0a-830e-4d16-beac-bb9751e89030"), "فولاد شهر", 19 },
                    { 681, new Guid("a3693ec3-6071-494d-9261-c53c642b159a"), "مشکات", 19 },
                    { 690, new Guid("c5739e72-a760-41ea-8575-2f3d895fa5a6"), "نياسر", 19 },
                    { 653, new Guid("5105be79-e7f4-49a2-9e3e-bc624157d80e"), "زازران", 19 },
                    { 651, new Guid("0f2d436e-365b-49c1-bf4a-f244555132fb"), "رزوه", 19 },
                    { 630, new Guid("5b94b872-d455-4651-a66a-2c80c90a0b5c"), "تودشک", 19 },
                    { 629, new Guid("9234cb9f-ee2b-4983-9cc8-e32f67b5c052"), "بوئين مياندشت", 19 },
                    { 628, new Guid("e08a4d08-915c-41a3-a651-dd420968a7c3"), "بهارستان", 19 },
                    { 627, new Guid("8a16492f-48b9-41f6-a55b-7ae14fefff5d"), "بهاران شهر", 19 },
                    { 626, new Guid("34e0705d-de0a-4758-bd23-e307b2e89d58"), "برف انبار", 19 },
                    { 625, new Guid("62dc091d-00f1-4613-8ade-d9b7db5b3dd4"), "برزک", 19 },
                    { 624, new Guid("5785b1e9-cd4c-4aa8-9862-079dc1be8c00"), "بافران", 19 },
                    { 623, new Guid("5056f5f0-79ca-4baa-87e2-99089f259741"), "باغشاد", 19 },
                    { 622, new Guid("ac50582d-d75e-4b55-ad0c-ce45ec380b29"), "باغ بهادران", 19 },
                    { 621, new Guid("f02fd299-c582-43ae-a75f-1d20a1787d34"), "بادرود", 19 },
                    { 620, new Guid("171f3ab4-6159-4b1f-a29f-81f6d3ff62ef"), "اژيه", 19 },
                    { 619, new Guid("29d9cdaa-6ef7-4c04-a005-f66ac972a14c"), "ايمانشهر", 19 },
                    { 618, new Guid("bf1ab6a5-c6b6-4fff-a618-53fc052946e0"), "انارک", 19 },
                    { 617, new Guid("620ab284-86e8-47eb-afdf-362a2c45a447"), "افوس", 19 },
                    { 616, new Guid("e7dbf926-34c3-488e-a731-009633f081c3"), "اصفهان", 19 },
                    { 631, new Guid("26885d8b-987f-4118-a138-4dbdb2c5f1b5"), "تيران", 19 },
                    { 632, new Guid("9042e0fc-84a2-4fbc-944c-1f455f5e7468"), "جندق", 19 },
                    { 633, new Guid("c9d6b5d9-f05b-4c66-950a-bc86fe9115f9"), "جوزدان", 19 },
                    { 634, new Guid("e55c8d64-a621-451b-83f1-6906164aac72"), "جوشقان قالي", 19 },
                    { 650, new Guid("78465924-e32c-4aaf-86bf-bf52def85848"), "ديزيچه", 19 },
                    { 649, new Guid("e1fd8156-b7bd-4e8e-bc65-6a2230c7b0a2"), "دولت آباد", 19 },
                    { 648, new Guid("be9d76ac-2604-4194-9dc3-0d9a0bfde53c"), "دهق", 19 },
                    { 647, new Guid("c6c7dddd-1c88-4d4d-a97f-093f67388176"), "دهاقان", 19 },
                    { 646, new Guid("05f86948-d27c-47db-adc8-4d4621c57a02"), "دستگرد", 19 },
                    { 645, new Guid("7c290c3e-3d7a-4cf3-8150-51706a736dae"), "درچه پياز", 19 },
                    { 644, new Guid("275195b9-90e2-4b8f-9959-d8bf2b1fb1ff"), "دامنه", 19 },
                    { 652, new Guid("5bc1d446-6f71-49fe-b657-ab1280dc008e"), "رضوانشهر", 19 },
                    { 643, new Guid("0e27874a-d01d-4cc9-b11f-80af6bcc5e06"), "داران", 19 },
                    { 641, new Guid("5961b451-b49c-40ba-b09d-6558b6161fd1"), "خور", 19 },
                    { 640, new Guid("a15dad28-b3cd-4b34-a786-c145f6cb038a"), "خوانسار", 19 },
                    { 639, new Guid("b63a70bb-9122-469d-8e5d-3186332716ee"), "خميني شهر", 19 },
                    { 638, new Guid("041bf9f8-9b9e-43e9-b56d-8995817b60c4"), "خالد آباد", 19 },
                    { 637, new Guid("3a833864-4dff-46f3-9c2c-f67618aee8e0"), "حنا", 19 },
                    { 636, new Guid("ca3830ca-ef58-41f3-be68-07ce69f806df"), "حسن آباد", 19 },
                    { 635, new Guid("1baf9625-6cad-46b4-ba4e-c18f51de2d39"), "حبيب آباد", 19 },
                    { 642, new Guid("d3f49158-ba21-4d42-8537-12200f8c2694"), "خورزوق", 19 },
                    { 691, new Guid("75c6cb7c-7605-4073-91a1-703cb68bfe6e"), "نيک آباد", 19 },
                    { 692, new Guid("7c476a17-ba59-4148-a259-cf0e48bcec89"), "هرند", 19 },
                    { 693, new Guid("1795cf4a-0da6-46ac-9236-28e6c6521acc"), "ورزنه", 19 },
                    { 748, new Guid("cdb1f00d-fbe2-440b-9549-04f1ab9c1505"), "باقرشهر", 21 },
                    { 747, new Guid("1c5bdeda-c6da-4610-b82e-37bb6a36810f"), "باغستان", 21 },
                    { 746, new Guid("56a783c7-a5ec-495e-9845-a20f4a11e783"), "انديشه", 21 },
                    { 745, new Guid("0b5de05b-cd6e-4765-888b-2b8fb04e73ba"), "اسلامشهر", 21 },
                    { 744, new Guid("1a6b925e-882c-4930-90db-1656e76a9e62"), "ارجمند", 21 },
                    { 743, new Guid("72727823-1b33-4555-8805-6c6ce1d72867"), "آبعلي", 21 },
                    { 742, new Guid("8db4d6d1-3a04-4555-9832-23feb70f4686"), "آبسرد", 21 },
                    { 741, new Guid("d8e281cb-c6fb-4518-9d39-0e3dfa86eec8"), "چوار", 20 },
                    { 740, new Guid("1fba25f5-09a8-495b-aa9f-299d35b9b068"), "پهله", 20 },
                    { 739, new Guid("b745517f-2164-4e3f-b1ed-330b8a08d6d0"), "ميمه", 20 },
                    { 738, new Guid("8e150bf9-fe7f-4df0-b224-92c816ab767d"), "موسيان", 20 },
                    { 737, new Guid("de1fd839-87eb-4fe2-88c3-873b103aa34c"), "مورموري", 20 },
                    { 736, new Guid("522d1fbc-ce7e-43d0-83bc-8a6b23645c8c"), "مهران", 20 },
                    { 735, new Guid("47c2909a-e1c7-42a6-957e-cedabd5521b0"), "مهر", 20 },
                    { 734, new Guid("9404fa38-76ab-4b02-a409-0699f13f469b"), "ماژين", 20 },
                    { 749, new Guid("712b4a2f-3581-45d2-bb74-371aa91c7125"), "بومهن", 21 },
                    { 750, new Guid("ad78b57b-8d9b-4ed5-bceb-dbbc6d0f17d8"), "تجريش", 21 },
                    { 751, new Guid("4e2b232a-bf97-4e56-944f-4971d2dfcf47"), "تهران", 21 },
                    { 752, new Guid("4211a111-2ed2-45bf-ab11-56853c2f5ba9"), "جواد آباد", 21 },
                    { 768, new Guid("4ca94316-2615-4bd7-b7b4-a670e7e51240"), "فشم", 21 },
                    { 767, new Guid("95e1e6c3-6b81-46a7-a608-9423c33665ee"), "فرون آباد", 21 },
                    { 766, new Guid("680fe0d5-6ecf-4834-8648-fc0873ea8050"), "فردوسيه", 21 },
                    { 765, new Guid("779d2634-e2a6-4c3d-bd23-e4a80260dbe5"), "صفادشت", 21 },
                    { 764, new Guid("7a3cb130-5631-45c2-b749-5848c0772f66"), "صبا شهر", 21 },
                    { 763, new Guid("302287bf-b2de-47c5-822b-c16de82520bd"), "صالحيه", 21 },
                    { 762, new Guid("07824eae-ce43-47ba-8faa-2004ff9570fc"), "شهريار", 21 },
                    { 733, new Guid("8d4bb948-3a51-45d1-82ba-90ef24b7feb4"), "لومار", 20 },
                    { 761, new Guid("2a2be848-7d05-4f17-94d7-390d01a0b80e"), "شهر جديد پرند", 21 },
                    { 759, new Guid("7642a45a-b8f1-4cdd-9a75-457fa320adb0"), "شريف آباد", 21 },
                    { 758, new Guid("8ca1b92a-688f-4f09-8fb3-1ac7078f5c6e"), "شاهدشهر", 21 },
                    { 757, new Guid("951c8a14-de69-48e1-9acc-5955ed37bd75"), "ري", 21 },
                    { 756, new Guid("1bfa3741-7e28-46bb-88bc-9f9e22b307dd"), "رودهن", 21 },
                    { 755, new Guid("89582742-6afd-4f81-999d-c80216c06056"), "رباط کريم", 21 },
                    { 754, new Guid("ddf928fd-e56f-4be0-aa4d-43b3a21bb99e"), "دماوند", 21 },
                    { 753, new Guid("f8498187-a9cf-4e6f-8250-e60e1f552eea"), "حسن آباد", 21 },
                    { 760, new Guid("d7720984-3b52-4e5a-b656-dc110b45e408"), "شمشک", 21 },
                    { 732, new Guid("f684b5f0-d20e-4be3-ba65-aa8830b75198"), "صالح آباد", 20 },
                    { 731, new Guid("b776baa2-998d-4d58-9cbb-d59725e2c943"), "شباب", 20 },
                    { 730, new Guid("21a372f0-7040-4a4b-9548-bd44819f7714"), "سرابله", 20 },
                    { 709, new Guid("b14d8af8-735e-431a-b201-5f2c2709e8aa"), "کوهپايه", 19 },
                    { 708, new Guid("06d1bd02-4ed5-4cd8-9f0a-959a5824062d"), "کوشک", 19 },
                    { 707, new Guid("ace0f3b4-e6c1-4d38-919c-75cdc157857d"), "کهريزسنگ", 19 },
                    { 706, new Guid("6ffb8938-f147-4d5e-8d0c-f1b6c8f670cb"), "کمه", 19 },
                    { 705, new Guid("e2e89ea3-f032-4a70-956c-159a7ed07b6f"), "کمشجه", 19 },
                    { 704, new Guid("15c0ee7a-edef-440c-bd00-064326982764"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("b48477d8-8aff-42a9-93f3-2421b2b3e02b"), "کرکوند", 19 },
                    { 710, new Guid("be1d8536-7c50-4490-90c3-f3f2113cfc37"), "گرگاب", 19 },
                    { 702, new Guid("0941c07c-2a84-42e8-9d1c-558773eaf0b1"), "کامو و چوگان", 19 },
                    { 700, new Guid("8a6785dc-25d6-4d4a-ba93-7194e53cb3e4"), "چمگردان", 19 },
                    { 699, new Guid("45501679-98da-4fe2-8e82-448df32a8880"), "چرمهين", 19 },
                    { 698, new Guid("05a8dec8-1ff8-4acb-a053-777651d27701"), "چادگان", 19 },
                    { 697, new Guid("5d560d14-53ce-45d2-86dc-d477fd252770"), "پير بکران", 19 },
                    { 696, new Guid("7d48c16e-7989-4884-aef5-3a8772ed81d4"), "ونک", 19 },
                    { 695, new Guid("a130a3ee-2d7e-40f6-a113-6f3ad6e2310b"), "وزوان", 19 },
                    { 694, new Guid("5885ccf1-1d4d-45e1-a3a3-c099ca53bbc6"), "ورنامخواست", 19 },
                    { 701, new Guid("eb25d790-2508-4560-bbfb-17ce000ea995"), "کاشان", 19 },
                    { 926, new Guid("c1a9846a-7697-4ddd-ae57-8f1f39618d5d"), "مزايجان", 23 },
                    { 711, new Guid("191c4225-6134-4f90-af18-0f3d3e14be20"), "گز برخوار", 19 },
                    { 713, new Guid("b700742d-5e9b-445b-9490-8107a9d448e3"), "گلشن", 19 },
                    { 729, new Guid("2cde4ec1-6317-4a04-8d62-fcaa88db08a3"), "سراب باغ", 20 },
                    { 728, new Guid("8c8c76b8-a354-47cd-ae9c-b9bf86c44886"), "زرنه", 20 },
                    { 727, new Guid("4de44b54-09e6-4694-aaaf-17bacec8d3f1"), "دهلران", 20 },
                    { 726, new Guid("e9c503b8-c722-4359-b0b4-a594d3c061f6"), "دلگشا", 20 },
                    { 725, new Guid("8d25458c-43fe-4cea-a618-22ec29661379"), "دره شهر", 20 },
                    { 724, new Guid("ee1779ef-1c63-44d3-8595-f1c85a3033e4"), "توحيد", 20 },
                    { 723, new Guid("be4b61a9-4415-45b4-8009-761670f14327"), "بلاوه", 20 },
                    { 712, new Guid("94760015-1076-48ce-881e-431515e7943c"), "گلدشت", 19 },
                    { 722, new Guid("c9e05ca2-c645-4b27-872e-d795a7fa2e07"), "بدره", 20 },
                    { 720, new Guid("96bc847c-6855-4bb0-b2b3-19ddd71a30eb"), "ايلام", 20 },
                    { 719, new Guid("1598dceb-b0b9-4c63-8616-d00b45c6dd01"), "ارکواز", 20 },
                    { 718, new Guid("491a470d-4312-44af-81fd-62bd578e558d"), "آسمان آباد", 20 },
                    { 717, new Guid("7545a36e-ad5f-4db0-ab83-acb3bbfa8f97"), "آبدانان", 20 },
                    { 716, new Guid("c7b37b5b-2164-4f36-a7b9-373200e52465"), "گوگد", 19 },
                    { 715, new Guid("754c035a-cc2e-4006-bbf4-666d4f7e8d7f"), "گلپايگان", 19 },
                    { 714, new Guid("1a4479d0-4a3b-4fde-867c-bce1970d7717"), "گلشهر", 19 },
                    { 721, new Guid("73613273-df51-45ac-ac36-051c7a9d1313"), "ايوان", 20 },
                    { 927, new Guid("47ba9d15-2897-48e5-a8c7-2224a7a8a3b9"), "مشکان", 23 },
                    { 928, new Guid("7934da33-37db-472a-ba81-44c5d92e4241"), "مصيري", 23 },
                    { 929, new Guid("b05ece91-7b3c-4138-bc1d-84ea52cf6c80"), "مهر", 23 },
                    { 1141, new Guid("f1d783ec-245c-4d7a-a242-e4a992281f8b"), "بردسير", 29 },
                    { 1140, new Guid("a4ef5964-3068-440d-ace7-c1cb514e63b4"), "بافت", 29 },
                    { 1139, new Guid("81a5388f-f53d-4ce8-a52f-9b87a373840f"), "باغين", 29 },
                    { 1138, new Guid("b6b75339-b491-4ce2-9b22-468fdc61872e"), "اندوهجرد", 29 },
                    { 1137, new Guid("e64d3b2f-5f76-4d82-9222-b18f24223c61"), "انار", 29 },
                    { 1136, new Guid("39059574-c228-4e46-a187-e7ed36a076d2"), "امين شهر", 29 },
                    { 1135, new Guid("957c40c3-4a41-48e6-baf4-a915061ae5ed"), "ارزوئيه", 29 },
                    { 1134, new Guid("f4dc72a6-e359-4fc0-ab0f-88b671022e6b"), "اختيار آباد", 29 },
                    { 1133, new Guid("468baed3-6cb5-4992-be88-fbe42106fe16"), "گيان", 28 },
                    { 1132, new Guid("82af4c27-50b4-4fa0-a993-2eacf0dbeb3a"), "گل تپه", 28 },
                    { 1131, new Guid("4a5aab9f-ddf2-4e04-8494-7989694e9c10"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("85435714-03ad-43d0-b52d-41b911324fe9"), "همدان", 28 },
                    { 1129, new Guid("9948036c-88c4-41b4-935b-d5c4ab32082d"), "نهاوند", 28 },
                    { 1128, new Guid("3c421c63-42f0-42ec-8c01-716e459f5e56"), "مهاجران", 28 },
                    { 1127, new Guid("1a794e98-6125-4c2b-b020-26a8e9803319"), "ملاير", 28 },
                    { 1142, new Guid("df9f20d0-c86b-4382-bfaf-e787693236dd"), "بروات", 29 },
                    { 1143, new Guid("75eb7316-0e08-4245-9247-fc29356e76a2"), "بزنجان", 29 },
                    { 1144, new Guid("b880b588-8cd4-4bc6-b663-01b10326ff61"), "بلورد", 29 },
                    { 1145, new Guid("bb35415a-85f3-4fa5-b237-e82f2467f378"), "بلوک", 29 },
                    { 1161, new Guid("af3e277f-9349-4a4b-b48b-772d12aeca26"), "راور", 29 },
                    { 1160, new Guid("1811deca-43d0-466e-9038-2894c9ca526d"), "رابر", 29 },
                    { 1159, new Guid("a5a9af43-daeb-478d-b776-8e3ff5c08ded"), "دوساري", 29 },
                    { 1158, new Guid("3ac125c4-ebbd-4510-b6ac-bdfca9230eec"), "دهج", 29 },
                    { 1157, new Guid("3286987a-1494-4de3-9122-dc5e26e9c593"), "دشتکار", 29 },
                    { 1156, new Guid("f4a5e4d7-8658-4997-82a0-f5adb3711edd"), "درب بهشت", 29 },
                    { 1155, new Guid("e83babc4-353c-4f4f-859a-8f91a0ec9471"), "خورسند", 29 },
                    { 1126, new Guid("41e97467-f690-4b2a-bfb5-726b88abae22"), "مريانج", 28 },
                    { 1154, new Guid("19e45685-6b2f-47cb-996d-b5164f994528"), "خواجوشهر", 29 },
                    { 1152, new Guid("822230bb-79ca-445e-96aa-6bf2a72ffbf0"), "خاتون آباد", 29 },
                    { 1151, new Guid("ab7ccb19-e451-4c85-b93a-d1d08b5efbef"), "جيرفت", 29 },
                    { 1150, new Guid("547ae705-abfd-4b43-82f6-f98f28fb195e"), "جوپار", 29 },
                    { 1149, new Guid("db1ad23b-dd51-4853-86f3-a7e528ac8c40"), "جوزم", 29 },
                    { 1148, new Guid("6c143207-082a-4763-af47-7f5980aadfc3"), "جبالبارز", 29 },
                    { 1147, new Guid("c30ac36e-6346-46f3-9dd7-679adf74ec4e"), "بهرمان", 29 },
                    { 1146, new Guid("be7a5c61-87a2-4750-b6ff-8df33c83ad15"), "بم", 29 },
                    { 1153, new Guid("4c759c61-31f3-4338-9e3f-207b18e83fb0"), "خانوک", 29 },
                    { 1162, new Guid("d66567c5-1003-4ff2-9cad-ed7a9b6be48e"), "راين", 29 },
                    { 1125, new Guid("6203636f-7bf0-442f-8af4-5b8a39b9a860"), "لالجين", 28 },
                    { 1123, new Guid("c00ee7d6-8904-4563-9aff-5e67bd19a3ba"), "قروه در جزين", 28 },
                    { 1102, new Guid("b5712321-b8bb-45c3-b41e-a7bc244a5be9"), "کوچصفهان", 27 },
                    { 1101, new Guid("8ab682cb-7b2d-47a7-a407-0300b7600c53"), "کومله", 27 },
                    { 1100, new Guid("718cff5d-cecc-4fae-9275-d75bda98b62b"), "کلاچاي", 27 },
                    { 1099, new Guid("d10d4269-8f2d-4e60-a924-eafd998c85e9"), "چوبر", 27 },
                    { 1098, new Guid("ef3c7823-2e78-4595-8181-acf82b408e24"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("55b84dd1-b9cf-4b98-bcf7-47bb8bbf5fbb"), "چابکسر", 27 },
                    { 1096, new Guid("83ec148f-c339-42d1-a597-721bf56b6868"), "پره سر", 27 },
                    { 1095, new Guid("fca318fd-424d-4904-9768-4138f490d059"), "واجارگاه", 27 },
                    { 1094, new Guid("2f16e6dd-c244-43f3-bc99-677928288d60"), "هشتپر", 27 },
                    { 1093, new Guid("9c3d214b-87f2-496c-8ac6-9c9776f7ef43"), "منجيل", 27 },
                    { 1092, new Guid("0df2ed10-b858-4964-8ed7-b918526b35cf"), "مرجقل", 27 },
                    { 1091, new Guid("e76c1496-9837-4bf9-bc13-1c116ea8cbc4"), "ماکلوان", 27 },
                    { 1090, new Guid("ce362f76-aca5-47b5-a8ba-bc958f005e36"), "ماسوله", 27 },
                    { 1089, new Guid("33db0dec-9913-4e3b-8a58-5c7fd418c4fc"), "ماسال", 27 },
                    { 1088, new Guid("e3d70f25-f6ba-424a-b6f4-b994e3acf436"), "ليسار", 27 },
                    { 1103, new Guid("d047e483-6267-4ece-9907-1e7f182b0bbb"), "کياشهر", 27 },
                    { 1104, new Guid("82d4f986-dab5-450a-bdec-700ff18fa163"), "گوراب زرميخ", 27 },
                    { 1105, new Guid("cee7e21a-6ced-4ccd-9aaa-3d71889d369a"), "آجين", 28 },
                    { 1106, new Guid("2ef18de9-1538-41b7-a425-879ed073c19b"), "ازندريان", 28 },
                    { 1122, new Guid("91a926fb-602e-46d3-9390-7ff00527d339"), "فيروزان", 28 },
                    { 1121, new Guid("59eb528e-5e26-4608-ad98-746b56fa0882"), "فرسفج", 28 },
                    { 1120, new Guid("5cdf724f-d5ca-4a36-a34c-9d87880f1800"), "فامنين", 28 },
                    { 1119, new Guid("de4ba3cd-e7e0-4fe1-895a-2d000233fb89"), "صالح آباد", 28 },
                    { 1118, new Guid("e31381e4-2bf1-4bd5-a635-95c1123b64a8"), "شيرين سو", 28 },
                    { 1117, new Guid("47fca075-a724-4704-ae88-6a43c2e819af"), "سرکان", 28 },
                    { 1116, new Guid("9f2bf6fb-c79b-4baa-a73b-6b27cfb56c8c"), "سامن", 28 },
                    { 1124, new Guid("0a166d8d-16f5-47da-9584-07e7ab35b6ee"), "قهاوند", 28 },
                    { 1115, new Guid("35c8ea26-5e81-458c-8fb3-7f529732dfef"), "زنگنه", 28 },
                    { 1113, new Guid("3ae0c66b-db52-4fb1-b826-c515f54d66fa"), "دمق", 28 },
                    { 1112, new Guid("9afc2dd8-0389-4287-b127-82f8dbf36a03"), "جوکار", 28 },
                    { 1111, new Guid("9df32edf-7fcc-4058-b0ac-6795f02164fc"), "جورقان", 28 },
                    { 1110, new Guid("bb988d65-ad83-4b26-af74-bdab572de652"), "تويسرکان", 28 },
                    { 1109, new Guid("c8da43aa-d217-43f0-a779-ac914f2b39d3"), "بهار", 28 },
                    { 1108, new Guid("57ec5cd1-6b1c-44f6-8223-a9eead1b0de4"), "برزول", 28 },
                    { 1107, new Guid("87e2a992-4628-41b8-9629-519807205f48"), "اسد آباد", 28 },
                    { 1114, new Guid("a0e3c39e-918c-4c13-9cd3-cb1419f1d2dc"), "رزن", 28 },
                    { 1163, new Guid("f02c9c20-a3f6-408a-8ca8-68220cd431d5"), "رفسنجان", 29 },
                    { 1164, new Guid("53a5208f-d6ae-4e0b-8f19-d0ba6a4a5b03"), "رودبار", 29 },
                    { 1165, new Guid("f79bd3dd-9ef7-4082-b505-72ba5896e9bb"), "ريحان", 29 },
                    { 1220, new Guid("eece54a5-e859-407f-8af3-091b25535b19"), "ميامي", 30 },
                    { 1219, new Guid("6bffd412-7fe5-4cda-ae56-6fc73935a083"), "مهدي شهر", 30 },
                    { 1218, new Guid("5d82e60d-4885-45c4-a862-3350c02c1b5e"), "مجن", 30 },
                    { 1217, new Guid("fb547468-88be-430d-93c1-4bffdce3b26a"), "شهميرزاد", 30 },
                    { 1216, new Guid("d418c377-3814-4b0a-8d3d-0af5affd6775"), "شاهرود", 30 },
                    { 1215, new Guid("4c6e64a7-abe4-426a-9ad5-db94b8bca0cb"), "سمنان", 30 },
                    { 1214, new Guid("a3219b6a-c5ce-40d8-93b6-51bf8b1e6c77"), "سرخه", 30 },
                    { 1213, new Guid("f8d53f49-a4e1-43ad-872f-d794eb642b7c"), "روديان", 30 },
                    { 1212, new Guid("07a13e32-4fee-4e27-bd03-36edcfa116a8"), "ديباج", 30 },
                    { 1211, new Guid("6fe27266-d2f8-4fcf-9ef1-fa3103838d04"), "درجزين", 30 },
                    { 1210, new Guid("7a8c2ee2-f45c-487f-baec-d6265264f161"), "دامغان", 30 },
                    { 1209, new Guid("058e0b42-9c7a-4771-9fe5-f16670b853eb"), "بيارجمند", 30 },
                    { 1208, new Guid("eb97b769-719d-4c2a-a934-abbbdf7e626c"), "بسطام", 30 },
                    { 1207, new Guid("20a9a431-a0df-4fc8-9562-1c80c0b860f8"), "ايوانکي", 30 },
                    { 1206, new Guid("c0508056-7973-4f60-966f-d2c05d4adf74"), "اميريه", 30 },
                    { 1221, new Guid("605534c4-d84d-4d68-91c8-a47954b314bd"), "کلاته", 30 },
                    { 1222, new Guid("758cb54b-089f-49f0-9466-79020a43904a"), "کلاته خيج", 30 },
                    { 1223, new Guid("a0f86a28-2fbf-4fa9-8d2d-458caa4b156a"), "کهن آباد", 30 },
                    { 1224, new Guid("c8a1e0af-e603-419e-8f11-33d346cd6608"), "گرمسار", 30 },
                    { 1240, new Guid("21a6c369-892a-422a-983b-a559f5edb4b9"), "چيتاب", 31 },
                    { 1239, new Guid("f4ca12ca-322a-400a-8f7e-7da4444a358c"), "چرام", 31 },
                    { 1238, new Guid("57811c8f-8207-4ec6-8917-b2f471a3e050"), "پاتاوه", 31 },
                    { 1237, new Guid("fb29f3cb-cdbf-4b88-bc47-1f5b8a24f692"), "ياسوج", 31 },
                    { 1236, new Guid("71a39255-adb5-4f10-b1be-fa2f4bfb1c63"), "مارگون", 31 },
                    { 1235, new Guid("93addbe6-373e-4161-8518-a86b3fe4e48f"), "مادوان", 31 },
                    { 1234, new Guid("039073e5-a2e2-42d6-b6e7-0818ef6df45d"), "ليکک", 31 },
                    { 1205, new Guid("44418e0a-5922-4d89-92e8-c98ea5e943d6"), "آرادان", 30 },
                    { 1233, new Guid("235cb00a-092b-4df4-8219-c32d6d003e52"), "لنده", 31 },
                    { 1231, new Guid("d5e7474e-3688-46f3-ac4c-373d283ee059"), "سي سخت", 31 },
                    { 1230, new Guid("dd45c15a-5014-4c21-8628-4360d4e0b881"), "سوق", 31 },
                    { 1229, new Guid("6fbf8d19-3313-4c82-b54e-fb795c3e2b28"), "سرفارياب", 31 },
                    { 1228, new Guid("d41c6245-88ca-45e5-aea0-1219e47ff995"), "ديشموک", 31 },
                    { 1227, new Guid("f2e54f04-dd0a-4084-a018-87a917f71d1c"), "دوگنبدان", 31 },
                    { 1226, new Guid("9ecc5ca6-5dae-4839-9c52-96f638b19e36"), "دهدشت", 31 },
                    { 1225, new Guid("bb0f33e0-6941-414e-8a52-abb4af80de8b"), "باشت", 31 },
                    { 1232, new Guid("b6e3c5fe-07a4-4717-9c1b-f6d1eb39726d"), "قلعه رئيسي", 31 },
                    { 1204, new Guid("158c96a4-2054-4ce4-b691-b235b3a1f6cc"), "گنبکي", 29 },
                    { 1203, new Guid("4fcb3e58-11de-464b-900c-8179be4d7b03"), "گلزار", 29 },
                    { 1202, new Guid("c4ad79fa-c845-4e85-a1f7-5abc0a0cbeb8"), "گلباف", 29 },
                    { 1181, new Guid("ad366d93-2275-45c9-80d7-cd75cbaaddd1"), "محي آباد", 29 },
                    { 1180, new Guid("52835401-b374-488c-9b4f-79e563293966"), "محمد آباد", 29 },
                    { 1179, new Guid("7e0172a2-524c-4e64-98a1-a403ae839721"), "ماهان", 29 },
                    { 1178, new Guid("980f7522-47c2-4eab-9d2a-34614ded67c5"), "لاله زار", 29 },
                    { 1177, new Guid("f4c45b33-c04d-4e30-85ea-3b5d8f15566f"), "قلعه گنج", 29 },
                    { 1176, new Guid("290dffdc-b1be-436a-b2e7-835f0b97e37c"), "فهرج", 29 },
                    { 1175, new Guid("7efbcd5f-85ea-4024-8bdf-8a8e536d408e"), "فارياب", 29 },
                    { 1182, new Guid("faa09ff0-2d66-4288-b3d9-824b0246b118"), "مردهک", 29 },
                    { 1174, new Guid("0b94692c-5952-4f45-8d56-b5937bda7ea0"), "عنبر آباد", 29 },
                    { 1172, new Guid("ab1b166b-6d11-4e93-9736-5cfb9b89f791"), "شهر بابک", 29 },
                    { 1171, new Guid("9b033c5a-fac2-4e75-9ac5-3e0c467e31f8"), "شهداد", 29 },
                    { 1170, new Guid("b481c689-3b42-445b-8bce-23765cfa9d4b"), "سيرجان", 29 },
                    { 1169, new Guid("c53d96ef-a64f-4acd-b119-58a13665ac8e"), "زيد آباد", 29 },
                    { 1168, new Guid("bc7c3b45-59d3-49db-bab0-abf1025f39b7"), "زهکلوت", 29 },
                    { 1167, new Guid("35dd8396-ef90-445c-8858-6ec68a15fbf9"), "زنگي آباد", 29 },
                    { 1166, new Guid("f20291d0-a6af-498c-954f-e5e4000efeda"), "زرند", 29 },
                    { 1173, new Guid("fc0a5086-5f70-477c-8a8d-d7c47e3ccee4"), "صفائيه", 29 },
                    { 1087, new Guid("efc93682-cb41-45f0-b12c-be08000953f7"), "لوندويل", 27 },
                    { 1183, new Guid("c0c63f33-2bb7-4f84-95d1-285e3c8ea493"), "مس سرچشمه", 29 },
                    { 1185, new Guid("6654eded-bfb6-476c-b2c6-f094e23d87b7"), "نجف شهر", 29 },
                    { 1201, new Guid("620b6f56-8053-4f6f-8723-0ec7e1e94bc5"), "کيانشهر", 29 },
                    { 1200, new Guid("4a0381c4-0826-4eaa-8f55-743975689e75"), "کوهبنان", 29 },
                    { 1199, new Guid("e7bb207f-5ae5-4d75-ab5f-e47d2f75e9ae"), "کهنوج", 29 },
                    { 1198, new Guid("91530ade-c983-4da7-9c8f-14976358489e"), "کشکوئيه", 29 },
                    { 1197, new Guid("d78c6440-702e-40d2-b657-4337ba8a4308"), "کرمان", 29 },
                    { 1196, new Guid("8a54ba60-44b5-49b2-b287-6cd6a843204b"), "کاظم آباد", 29 },
                    { 1195, new Guid("bc77fe58-1019-48fc-91ed-a18c08b46024"), "چترود", 29 },
                    { 1184, new Guid("2023dc0d-a2d9-46dc-892e-1d3e1a557933"), "منوجان", 29 },
                    { 1194, new Guid("14dbb410-ae30-4999-85c0-166261e62821"), "پاريز", 29 },
                    { 1192, new Guid("a1fe98fb-2fe1-4447-a6a2-813a8b5e3e8b"), "هنزا", 29 },
                    { 1191, new Guid("be908301-15e7-46c5-b281-c4fb9380ca0c"), "هماشهر", 29 },
                    { 1190, new Guid("218ffd73-edd4-45bf-a405-c413da6695b5"), "هجدک", 29 },
                    { 1189, new Guid("2895082d-3404-4d7f-b62f-b4868caa0ec8"), "نگار", 29 },
                    { 1188, new Guid("f9ec6254-3364-45e2-9126-df55c8d48b59"), "نودژ", 29 },
                    { 1187, new Guid("4511350b-894f-4303-8682-c6d79f6f0702"), "نظام شهر", 29 },
                    { 1186, new Guid("0e8b676c-85c7-44fc-bd89-1661b639b1ac"), "نرماشير", 29 },
                    { 1193, new Guid("56366ef0-b0b9-4e03-8caa-85871a01b4a8"), "يزدان شهر", 29 },
                    { 1086, new Guid("3eb4fe74-fb7f-4b07-bf92-aad8cfb67651"), "لولمان", 27 },
                    { 1085, new Guid("cd3cbf7e-de28-4303-83c1-b4702a6a3924"), "لوشان", 27 },
                    { 1084, new Guid("36bdcfbc-2a21-4305-a1e5-2ea0950f0350"), "لنگرود", 27 },
                    { 984, new Guid("2fbaa465-fec7-4682-8e8c-986885f17735"), "بندر عباس", 25 },
                    { 983, new Guid("4a03dbb4-f08d-4f8d-ab9d-85167a467004"), "بندر جاسک", 25 },
                    { 982, new Guid("c01eb4aa-0310-4bbb-ad68-2c5cf9606e27"), "بستک", 25 },
                    { 981, new Guid("c5ab10bf-f3e3-42e5-b75c-ee73d93148e1"), "ابوموسي", 25 },
                    { 980, new Guid("05f97b42-9f04-425e-99e4-9a2e0db9320b"), "گيلانغرب", 24 },
                    { 979, new Guid("3bc1eb0d-3af9-4a36-a6f8-23724df2c253"), "گودين", 24 },
                    { 978, new Guid("59f2e59b-d81a-4c1e-8a3d-ee903a9734be"), "گهواره", 24 },
                    { 977, new Guid("57d43430-82d4-436d-93ae-434e481da5fe"), "کوزران", 24 },
                    { 976, new Guid("c8e866c6-eb25-411c-84de-5f9cf0ba3e60"), "کنگاور", 24 },
                    { 975, new Guid("1b21a038-6d19-4826-9886-e15c1ad0eb34"), "کرند غرب", 24 },
                    { 974, new Guid("9a709969-bdb6-4aa6-8082-c3758d9d5e78"), "کرمانشاه", 24 },
                    { 973, new Guid("877025b1-5391-4915-b514-8d13630f9c66"), "پاوه", 24 },
                    { 972, new Guid("ded64a23-3377-4d13-98d0-ae869bd35251"), "هلشي", 24 },
                    { 971, new Guid("0d115583-e5df-4d3c-8fd8-5147ba8cab68"), "هرسين", 24 },
                    { 970, new Guid("24a4173b-9a30-4c3d-9b40-1676a852b60b"), "نوسود", 24 },
                    { 985, new Guid("1ef22f94-9274-4ba6-954a-02e396125026"), "بندر لنگه", 25 },
                    { 986, new Guid("8c478aec-17f5-426f-80aa-d4cd0f0f5272"), "بيکاه", 25 },
                    { 987, new Guid("af5a8825-5db9-4966-a4c3-78ac806d5e1f"), "تازيان پائين", 25 },
                    { 988, new Guid("d19429b5-6337-468a-b0d4-17cb670b5be6"), "تخت", 25 },
                    { 1004, new Guid("897b403b-fab2-467d-8022-8f773c6a84a8"), "فين", 25 },
                    { 1003, new Guid("a94cdc12-e74d-41a9-8d46-439705012481"), "فارغان", 25 },
                    { 1002, new Guid("b84ebf6c-169a-44d9-8421-89c2cda05f67"), "سيريک", 25 },
                    { 1001, new Guid("3defee69-603d-4c33-a4a7-4c86391e7e78"), "سوزا", 25 },
                    { 1000, new Guid("3cb9a660-1f44-4aff-abdd-5dd3a776aecb"), "سندرک", 25 },
                    { 999, new Guid("5b4014ef-77a5-4ebf-926b-8e01072ed75c"), "سرگز", 25 },
                    { 998, new Guid("041dd7cf-4893-4e43-b0ea-683011590443"), "سردشت", 25 },
                    { 969, new Guid("bc534aaf-4436-4a1e-9e9e-e87a82dc494a"), "نودشه", 24 },
                    { 997, new Guid("9fe2fc24-18ab-45d1-875b-2372bf3b02c5"), "زيارتعلي", 25 },
                    { 995, new Guid("a5a999f9-83cc-412c-b6aa-1e3865c2f54d"), "دهبارز", 25 },
                    { 994, new Guid("d16e47d6-b140-4306-9d59-f5325fca3c07"), "دشتي", 25 },
                    { 993, new Guid("d948304f-052b-41fb-bc6f-6ecc416b058c"), "درگهان", 25 },
                    { 992, new Guid("2275ba67-52d7-41b7-ab07-77588da3a01d"), "خمير", 25 },
                    { 991, new Guid("8526bdf6-4c29-4f25-bb3f-d37a1f91a17f"), "حاجي آباد", 25 },
                    { 990, new Guid("22b1d4c6-18b3-4e3d-a15c-f501cb1b94f3"), "جناح", 25 },
                    { 989, new Guid("60b1480e-8d2d-491e-ad01-707057210944"), "تيرور", 25 },
                    { 996, new Guid("83aad45e-3ff2-4422-afb7-bb0661af9ab4"), "رويدر", 25 },
                    { 968, new Guid("bb9b218a-dd78-46ee-8d45-96e56cdaba38"), "ميان راهان", 24 },
                    { 967, new Guid("64bc0b12-6e45-4663-aee8-c4ebcc433939"), "قصر شيرين", 24 },
                    { 966, new Guid("6ad4372a-a4e3-4970-b593-0eef0ae50f7b"), "صحنه", 24 },
                    { 945, new Guid("da66f679-41c3-410e-9222-128452497875"), "کوهنجان", 23 },
                    { 944, new Guid("8b9adafc-af19-4704-81a4-188b020e34d4"), "کوار", 23 },
                    { 943, new Guid("0bceaa8b-8d32-4cac-a667-f2e38ba9b47f"), "کنار تخته", 23 },
                    { 942, new Guid("6e4d2518-36a7-4763-ba3d-09a7d76d2c42"), "کره اي", 23 },
                    { 941, new Guid("81d21f7e-a5e9-46a8-8327-b6e3614d89af"), "کامفيروز", 23 },
                    { 940, new Guid("5560ec77-7939-46fc-9f0b-40fe37bd7b2f"), "کازرون", 23 },
                    { 939, new Guid("72b6e5d0-e2e8-4dcf-a3a7-1e8fd3385020"), "کارزين", 23 },
                    { 946, new Guid("02fa3a1a-2159-4f7e-83ba-6f3632794f76"), "کوپن", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 938, new Guid("344fd53d-6641-41d5-991b-26d6942e9108"), "وراوي", 23 },
                    { 936, new Guid("d76ac731-3259-4809-a7d1-a3b74d381b06"), "ني ريز", 23 },
                    { 935, new Guid("26db7d03-48d0-4986-beb7-7692553e2417"), "نورآباد", 23 },
                    { 934, new Guid("df392099-916f-4873-a33e-e9a4d17fe5c3"), "نودان", 23 },
                    { 933, new Guid("5f7d4263-fab1-406a-953a-bd2aa2375fc7"), "نوجين", 23 },
                    { 932, new Guid("ddb9b6ba-ac3a-4bee-9b68-7ecf344d6c70"), "نوبندگان", 23 },
                    { 931, new Guid("683bcae9-68f3-4bab-b84b-cba516ff0590"), "ميمند", 23 },
                    { 930, new Guid("813dbe6d-b735-4955-9194-e0917a9233f3"), "ميانشهر", 23 },
                    { 937, new Guid("57d8a76e-5cce-4952-bc42-1895bef7046c"), "هماشهر", 23 },
                    { 1005, new Guid("dc00b287-6c14-467b-b220-319f62276a87"), "قشم", 25 },
                    { 947, new Guid("31332060-16ec-4313-a42a-42e1e073eb79"), "گراش", 23 },
                    { 949, new Guid("eb807d8c-b1d7-4956-a273-b76428645169"), "ازگله", 24 },
                    { 965, new Guid("46a38bcb-426e-4887-93d6-e8daca90d574"), "شاهو", 24 },
                    { 964, new Guid("8ea0c7db-90c2-4bba-9f9b-799c9ea6b47d"), "سومار", 24 },
                    { 963, new Guid("3eadc816-57e5-4644-9e3a-4437ba26669c"), "سنقر", 24 },
                    { 962, new Guid("65a683a6-b678-470a-9395-ac2bd27ab0a9"), "سطر", 24 },
                    { 961, new Guid("8b64d041-96bc-4cda-b1b3-e010335c46f5"), "سرمست", 24 },
                    { 960, new Guid("7f3c1339-df90-4494-9e01-f79808cfbcda"), "سر پل ذهاب", 24 },
                    { 959, new Guid("34b6fe39-c2bc-42d9-af48-0894f60d965d"), "ريجاب", 24 },
                    { 948, new Guid("024652fc-c42b-476d-ad04-40858e0ea6fa"), "گله دار", 23 },
                    { 958, new Guid("3bd10b78-e673-426a-916a-6eefa53eaff2"), "روانسر", 24 },
                    { 956, new Guid("a3f4500e-aa46-4146-a0d9-8950879c94a5"), "حميل", 24 },
                    { 955, new Guid("b14701c5-d0c6-4542-88e5-2288bc34097c"), "جوانرود", 24 },
                    { 954, new Guid("ddecbe6c-8a9f-4066-aaaa-a1f7b2cf2cc7"), "تازه آباد", 24 },
                    { 953, new Guid("62255abc-35ef-4c16-a476-d2a4446632eb"), "بيستون", 24 },
                    { 952, new Guid("c7619bde-37b0-4faf-9ec8-c406d942f4e9"), "باينگان", 24 },
                    { 951, new Guid("7f2f59cc-814c-4212-a500-357d9c8537d3"), "بانوره", 24 },
                    { 950, new Guid("d90ddb8f-62a0-4506-9fbb-fb2f4b277053"), "اسلام آباد غرب", 24 },
                    { 957, new Guid("435a20c4-42bd-42be-9a3e-27daf961d157"), "رباط", 24 },
                    { 615, new Guid("6c48a386-07fa-4099-a5d9-791c7d2dfdf5"), "اصغرآباد", 19 },
                    { 1006, new Guid("4b3e2186-5316-4bae-b854-7200bde0bb22"), "قلعه قاضي", 25 },
                    { 1008, new Guid("e2d8a64b-c1bb-4eb1-92c0-022d8c201dc9"), "ميناب", 25 },
                    { 1063, new Guid("dcca86ad-c733-4e4d-9392-fbfdfa4174eb"), "جيرنده", 27 },
                    { 1062, new Guid("cbccd5ca-0ba7-4261-8e59-c4c2e17c98f2"), "توتکابن", 27 },
                    { 1061, new Guid("467eb4cb-a7e4-4b22-bc7c-934e699ac32f"), "بندر انزلي", 27 },
                    { 1060, new Guid("583b89c8-a785-4aeb-93d8-3a9cfcf4c94f"), "بره سر", 27 },
                    { 1059, new Guid("cacebe86-aaa2-4763-aeec-9d7df4d6489c"), "بازار جمعه", 27 },
                    { 1058, new Guid("6b455829-f4ad-4144-923d-76f4947224e1"), "املش", 27 },
                    { 1057, new Guid("1cff374d-8810-4fc9-9463-eebbc09b5595"), "اطاقور", 27 },
                    { 1056, new Guid("ab1947d5-686d-4bdb-9e95-b840288769e4"), "اسالم", 27 },
                    { 1055, new Guid("689b065b-deea-4bf2-aafc-18f2530f8120"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("ccd00337-79ab-4236-87ae-2647bef64cd7"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("4e888061-2027-4df7-b8cf-3aedf023fcfa"), "آستارا", 27 },
                    { 1052, new Guid("d8e983dd-6bff-41f5-b057-eaeb583b4b7b"), "کميجان", 26 },
                    { 1051, new Guid("b4aef0c1-916c-4085-9792-a6f3cadba950"), "کارچان", 26 },
                    { 1050, new Guid("45b1a7e8-01f0-45ec-bad1-6887e8a12052"), "پرندک", 26 },
                    { 1049, new Guid("a8b26555-26f8-488a-9e0f-4a608c4c7fe3"), "هندودر", 26 },
                    { 1064, new Guid("3767b433-4fa6-4bf9-8729-3e8df93691b0"), "حويق", 27 },
                    { 1065, new Guid("68505703-c7b0-479d-be4a-8567db7edf0e"), "خشکبيجار", 27 },
                    { 1066, new Guid("f283ae00-f7a9-4f4d-bf90-e86219561093"), "خمام", 27 },
                    { 1067, new Guid("7d10e2fd-1cab-4698-b122-fb293ad1e475"), "ديلمان", 27 },
                    { 1083, new Guid("f2f25cdd-cff6-4468-ab08-8240009a6f49"), "لشت نشاء", 27 },
                    { 1082, new Guid("2e5bb81b-75d1-4817-afef-6518b3f3fece"), "لاهيجان", 27 },
                    { 1081, new Guid("0b953b37-75f8-4db2-83d4-6abb8df867c0"), "فومن", 27 },
                    { 1080, new Guid("beaedae8-2e1c-4391-99ed-881a45c9a0da"), "صومعه سرا", 27 },
                    { 1079, new Guid("6fead741-d75b-4004-beca-1b93ac067bcf"), "شلمان", 27 },
                    { 1078, new Guid("905996ac-b019-4118-a7f7-39a627b94185"), "شفت", 27 },
                    { 1077, new Guid("e9fbe0aa-5d6c-4257-8547-517e56ab178b"), "سياهکل", 27 },
                    { 1048, new Guid("c370f399-4a71-4eb6-99c9-3d9be3ae9c83"), "نيمور", 26 },
                    { 1076, new Guid("79bac018-571d-419f-af67-68b2dc73d89c"), "سنگر", 27 },
                    { 1074, new Guid("90e9f37f-91e2-40f6-9ee2-371592decac0"), "رودبنه", 27 },
                    { 1073, new Guid("f399afc8-d9cd-4c05-b214-0be58f5c9f14"), "رودبار", 27 },
                    { 1072, new Guid("bff98ab6-987e-4e8a-b3dd-2663c45f3062"), "رضوانشهر", 27 },
                    { 1071, new Guid("66c97878-86db-4d9c-84cf-2e05e932d7ab"), "رشت", 27 },
                    { 1070, new Guid("92cee190-e973-4125-aff5-e6aff3fda2b2"), "رستم آباد", 27 },
                    { 1069, new Guid("bcbafa25-7bbc-4f4f-ad41-748f0ea97bd0"), "رحيم آباد", 27 },
                    { 1068, new Guid("557e3d55-b8f9-472f-b0f1-e1ea59461f4c"), "رانکوه", 27 },
                    { 1075, new Guid("35189edd-6cf2-4641-ab61-2b795bd8c354"), "رودسر", 27 },
                    { 1047, new Guid("1652df54-e98d-42bf-8027-659c0a496751"), "نوبران", 26 },
                    { 1046, new Guid("ce662f4a-b87c-4b56-9ff7-15e81ddbcb54"), "نراق", 26 },
                    { 1045, new Guid("9b686387-ac69-43f9-9887-eafe468d8b87"), "ميلاجرد", 26 },
                    { 1024, new Guid("d6b42359-9f7b-4849-9818-65e2f13fe19d"), "تفرش", 26 },
                    { 1023, new Guid("69ec475e-8b26-4cb3-b5e3-2510e22d6e68"), "اراک", 26 },
                    { 1022, new Guid("17ae16ce-e6c5-4602-8845-c61827cc7b02"), "آوه", 26 },
                    { 1021, new Guid("abb20e0d-d32a-49e1-baa3-8da60021fdef"), "آشتيان", 26 },
                    { 1020, new Guid("384b0046-8d0a-4900-b926-0af3961e085b"), "آستانه", 26 },
                    { 1019, new Guid("2192c54e-a041-419d-8f0f-7d397ca6cc93"), "گوهران", 25 },
                    { 1018, new Guid("deae5129-29db-42bf-8d9a-d8c3b46d7988"), "گروک", 25 },
                    { 1025, new Guid("5bf94b6c-4d57-4025-bcb9-da25990b2199"), "توره", 26 },
                    { 1017, new Guid("3d211b8d-403c-436a-8dd5-af584de40ca1"), "کيش", 25 },
                    { 1015, new Guid("8c7cbd8d-d4e8-444a-9145-bba434c6fe0a"), "کوشکنار", 25 },
                    { 1014, new Guid("d8a32aa6-82cc-4d82-b137-78f92a89e317"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("ab6aab75-08fe-4639-ab91-01946b5ba8f3"), "کنگ", 25 },
                    { 1012, new Guid("0c036827-8aa3-4f3e-88a6-bc4a46638728"), "چارک", 25 },
                    { 1011, new Guid("8dc7a0ee-27ad-4f7b-b3d5-8a95b0368e64"), "پارسيان", 25 },
                    { 1010, new Guid("ea1884a0-1322-4364-a5db-3a8b0ee6e6e1"), "هشتبندي", 25 },
                    { 1009, new Guid("ef1e72d8-d187-4082-8859-50ebec0b92a3"), "هرمز", 25 },
                    { 1016, new Guid("9aced4b4-2b34-4a80-83b3-c46fcbfb85ae"), "کوهستک", 25 },
                    { 1007, new Guid("1030bf9c-a250-4fc3-94e1-181d1d9399b8"), "لمزان", 25 },
                    { 1026, new Guid("7ec2d439-1cdc-46bb-b534-6abf66e31753"), "جاورسيان", 26 },
                    { 1028, new Guid("1ea222bf-a45e-43f1-bd5a-2aaae0e48a5d"), "خمين", 26 },
                    { 1044, new Guid("1ef841cb-f497-42bb-8cb3-0d85e6c26c11"), "محلات", 26 },
                    { 1043, new Guid("b344a36c-ed02-4091-beff-8e1bc9e04c13"), "مامونيه", 26 },
                    { 1042, new Guid("4544a33a-7174-43d4-9c07-fbcb412e7f14"), "قورچي باشي", 26 },
                    { 1041, new Guid("2cad9f88-5edf-4e33-aeba-5bec55c05a35"), "فرمهين", 26 },
                    { 1040, new Guid("ab2df09f-8086-45f7-a107-c21b26c41fde"), "غرق آباد", 26 },
                    { 1039, new Guid("5e528ca4-b44e-476a-a232-f09db39e7f1a"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("8efc97d5-ad99-4d75-9195-9807cc2615b9"), "شهباز", 26 },
                    { 1027, new Guid("52927521-6f7b-41fb-ae19-68c092e4de76"), "خشکرود", 26 },
                    { 1037, new Guid("97dfb5ae-d4e0-4c84-ad9a-01d33ac44732"), "شازند", 26 },
                    { 1035, new Guid("15774d56-3767-482e-8724-563cf844e4e3"), "ساروق", 26 },
                    { 1034, new Guid("b98a98da-76e9-4802-a6a8-9dd24a246d56"), "زاويه", 26 },
                    { 1033, new Guid("a13af0d0-0314-481b-8424-0f782fc80749"), "رازقان", 26 },
                    { 1032, new Guid("dbf16ff0-ebf4-4697-a36b-ccdde1dbc002"), "دليجان", 26 },
                    { 1031, new Guid("498094ee-e0d2-4571-9a18-5be75d7fea72"), "داود آباد", 26 },
                    { 1030, new Guid("32795359-825d-4fef-b1ce-0bb45d2ab531"), "خنداب", 26 },
                    { 1029, new Guid("27010113-7471-424e-a9b0-4a33877e5180"), "خنجين", 26 },
                    { 1036, new Guid("97b43326-9272-4f29-bddc-33e6449c5825"), "ساوه", 26 },
                    { 614, new Guid("7317b153-2cd1-4004-b6ca-118d5685711a"), "اردستان", 19 },
                    { 613, new Guid("671c91c4-5f2c-4048-8525-fa9eba9f7838"), "ابوزيد آباد", 19 },
                    { 612, new Guid("ff9210f8-a3ee-4db1-96d1-32654449f8cf"), "ابريشم", 19 },
                    { 207, new Guid("19f2224e-bc15-4fba-935a-0048b73b56ea"), "سلامي", 8 },
                    { 206, new Guid("335aa85a-e37f-4be0-9bd5-1f400292e494"), "سفيد سنگ", 8 },
                    { 205, new Guid("f2ecb5cc-261b-4265-8a6e-836aa1671c9b"), "سرخس", 8 },
                    { 204, new Guid("692837ee-b24f-4ee2-a1ca-df5022d746a3"), "سبزوار", 8 },
                    { 203, new Guid("89201032-90e8-4241-8062-34dcac6ffcc4"), "ريوش", 8 },
                    { 202, new Guid("9f4caf77-b467-49c5-954a-5493150dd969"), "روداب", 8 },
                    { 201, new Guid("f69806ff-72ba-4c9e-b080-0637b9fb6c5e"), "رضويه", 8 },
                    { 200, new Guid("802d6872-3f71-441b-ba3d-25d76eb9010c"), "رشتخوار", 8 },
                    { 199, new Guid("6242b241-6fe6-4fc9-ad89-5efd7743f1fb"), "رباط سنگ", 8 },
                    { 198, new Guid("a80b3eae-2b95-4f0a-a1d3-7a825636c8e6"), "دولت آباد", 8 },
                    { 197, new Guid("8f6bbd65-ade2-444b-9ed3-a4392a3de955"), "درگز", 8 },
                    { 196, new Guid("8b3c4bcb-079f-4e88-b8d6-f1bdbc6110e9"), "درود", 8 },
                    { 195, new Guid("230028f0-2e29-483b-8770-3b309c701cf9"), "داورزن", 8 },
                    { 194, new Guid("da821256-0a47-45a9-ac5d-da19c20f0da1"), "خواف", 8 },
                    { 193, new Guid("544887a6-df02-46be-8270-b17939e8b4ee"), "خليل آباد", 8 },
                    { 208, new Guid("e76f7870-4ec5-40d7-9ac5-77151e408fd4"), "سلطان آباد", 8 },
                    { 192, new Guid("43b1e865-95da-4f6e-b74b-d266c29b5cca"), "خرو", 8 },
                    { 209, new Guid("4475e3e6-da95-4aa0-aa95-83c98faa087f"), "سنگان", 8 },
                    { 211, new Guid("f8f4131f-ab67-4abd-a649-be10e1e366bf"), "شانديز", 8 },
                    { 226, new Guid("1f4b3d08-9214-4560-ad87-0e15a0cf0422"), "لطف آباد", 8 },
                    { 225, new Guid("948d7ab2-f1e2-4d7d-878b-ce56b8519704"), "قوچان", 8 },
                    { 224, new Guid("59dd3086-7cd3-432c-9391-2253f888ea78"), "قلندر آباد", 8 },
                    { 223, new Guid("3048bafc-ea24-411c-9c6b-5726d2343ff4"), "قدمگاه", 8 },
                    { 222, new Guid("00a4824b-523a-44a5-bc6d-b1b7de18c3fb"), "قاسم آباد", 8 },
                    { 221, new Guid("0e989f28-9200-42ab-b80d-0cbdac6ca127"), "فيض آباد", 8 },
                    { 220, new Guid("c7a9c4cd-eb8b-417c-9c1b-6dd1f1c0d286"), "فيروزه", 8 },
                    { 219, new Guid("a0b0da60-4c55-4ad8-acc5-5c7c999fb9a3"), "فريمان", 8 },
                    { 218, new Guid("af9c443c-8030-40d7-9841-b0c6ac00e2b8"), "فرهاد گرد", 8 },
                    { 217, new Guid("94228860-ed1b-467c-ad15-e2f7bb73d487"), "عشق آباد", 8 },
                    { 216, new Guid("6ea60efd-f6cc-40e0-b74c-9c52514a0b6a"), "طرقبه", 8 },
                    { 215, new Guid("7e3b83da-08d9-43fa-879c-8306218ca09a"), "صالح آباد", 8 },
                    { 214, new Guid("21ab8209-fafd-4131-a0a7-6897a1550dfd"), "شهرآباد", 8 },
                    { 213, new Guid("8f7d67cc-9a84-40c8-b982-9fe4c3be0dbe"), "شهر زو", 8 },
                    { 212, new Guid("cc78b3b4-9856-402d-a17e-80cdfc57b25b"), "ششتمد", 8 },
                    { 210, new Guid("5f6ea943-db1a-403d-8533-0dc5ec526f8b"), "شادمهر", 8 },
                    { 227, new Guid("973cadd9-b801-4738-9a3a-237f6f0bc873"), "مزدآوند", 8 },
                    { 191, new Guid("67012b9b-1690-4502-ad99-e6e3d079590d"), "جنگل", 8 },
                    { 189, new Guid("46486868-93a1-4ec5-ac81-2ae0419d6aeb"), "تربت حيدريه", 8 },
                    { 169, new Guid("110f5d7c-be48-4fac-a88c-ea45a2ac2d02"), "نازک عليا", 7 },
                    { 168, new Guid("cfe92840-bcf3-4970-80d4-5c13b403f698"), "ميرآباد", 7 },
                    { 167, new Guid("a906cc54-3ade-48eb-be7b-6c935568b6dc"), "مياندوآب", 7 },
                    { 166, new Guid("8c61ffe6-6ac3-4a5e-91e8-ffb39c78eadb"), "مهاباد", 7 },
                    { 165, new Guid("8759e486-bc27-481d-bb0f-1bf974197d35"), "مرگنلر", 7 },
                    { 164, new Guid("26cd8f2d-5f6f-4a0c-92fe-0ed912f47619"), "محمود آباد", 7 },
                    { 163, new Guid("f9100f23-91f8-4956-a654-c8d76af80d18"), "محمد يار", 7 },
                    { 162, new Guid("90a2d094-149a-417d-b591-30066c9ff0ba"), "ماکو", 7 },
                    { 161, new Guid("8134d2df-b1d1-4269-a773-98ef9cd82270"), "قوشچي", 7 },
                    { 160, new Guid("dd17ba2b-c92b-4cd0-8a72-80f3c0f75d9b"), "قطور", 7 },
                    { 159, new Guid("74d14324-b9d1-4fcd-8b83-e7a061f681a9"), "قره ضياء الدين", 7 },
                    { 158, new Guid("040cb509-dd9d-4c65-8af8-914b24f31188"), "فيرورق", 7 },
                    { 157, new Guid("dc890248-ed78-4873-9161-14fcc6fb588a"), "شوط", 7 },
                    { 156, new Guid("a778d9ec-60fa-4579-8fd1-4a9a5c19fed7"), "شاهين دژ", 7 },
                    { 155, new Guid("bb2bd0f3-04c0-4ebf-b2ef-b5452dda3242"), "سيه چشمه", 7 },
                    { 170, new Guid("e6d6323c-d3a1-429e-a0cf-fa1d4369d01e"), "نالوس", 7 },
                    { 190, new Guid("44262406-bedf-466d-9e65-4d0310188e25"), "جغتاي", 8 },
                    { 171, new Guid("ac3e0e12-dad4-443a-b01a-7659035fe4f5"), "نقده", 7 },
                    { 173, new Guid("2b9e0c50-24fe-4b10-9d77-341c900aff71"), "پلدشت", 7 },
                    { 188, new Guid("960db1cd-4c0b-4859-856d-a6dbf40d3f1c"), "تربت جام", 8 },
                    { 187, new Guid("f55cdf5e-bafb-4a5a-b0dc-07682ec7a4bf"), "تايباد", 8 },
                    { 186, new Guid("1ff15670-2bf0-4279-944d-411f6384524c"), "بيدخت", 8 },
                    { 185, new Guid("55ca4359-b85c-43b7-9329-fa6fcfe9f420"), "بردسکن", 8 },
                    { 184, new Guid("fe1a2952-8410-4c7e-a6e6-bb4bea64dd85"), "بجستان", 8 },
                    { 183, new Guid("3e49a26a-54e4-4525-8bd3-d9caebc7d241"), "بايک", 8 },
                    { 182, new Guid("1982281b-aec2-4617-a246-086c7e68c99e"), "بار", 8 },
                    { 181, new Guid("cf846366-f290-4862-9660-5f15b988fb38"), "باخرز", 8 },
                    { 180, new Guid("6e979210-43f8-4006-a774-ade87c376599"), "باجگيران", 8 },
                    { 179, new Guid("c4d82baa-a0d4-4c87-8bc5-39274fe75608"), "انابد", 8 },
                    { 178, new Guid("a5cc2bcf-46e1-4927-8426-49d015d248b0"), "احمدآباد صولت", 8 },
                    { 177, new Guid("713fda11-6227-47ad-84f7-50bcbf106197"), "گردکشانه", 7 },
                    { 176, new Guid("b300d846-5d70-4b21-be54-9233b845a8bc"), "کشاورز", 7 },
                    { 175, new Guid("9d7401a8-2422-4a59-a942-e45c1dce9f5c"), "چهار برج", 7 },
                    { 174, new Guid("f39ee24a-0d5d-4b49-b52a-077419d83813"), "پيرانشهر", 7 },
                    { 172, new Guid("e9af540a-6185-4f55-af31-87c2556a001b"), "نوشين", 7 },
                    { 228, new Guid("ebb37c3e-3a84-4149-9d32-f8de2637ded0"), "مشهد", 8 },
                    { 229, new Guid("06062ac8-7a28-4d47-a33b-30c3ea3bafe2"), "مشهدريزه", 8 },
                    { 230, new Guid("c54e3af1-5e64-4d48-a379-2f2259460794"), "ملک آباد", 8 },
                    { 284, new Guid("6057dde7-8a5c-4610-9f60-1b1f18ad8635"), "کنارک", 9 },
                    { 283, new Guid("e032211a-d61e-4cd3-bc98-e37fc86b414f"), "چاه بهار", 9 },
                    { 282, new Guid("12844389-aca6-4660-a47b-df1c5eb1d0d7"), "پيشين", 9 },
                    { 281, new Guid("d7e002b6-0401-4d73-8581-068147953907"), "هيدوچ", 9 },
                    { 280, new Guid("909422f2-9763-460c-8b97-6c5b222a7eeb"), "نگور", 9 },
                    { 279, new Guid("2802f0a4-2c73-49f3-8ba4-15a21324fdde"), "نيک شهر", 9 },
                    { 278, new Guid("a389d67b-3d4a-4711-890e-cd665e71bde1"), "نوک آباد", 9 },
                    { 277, new Guid("f8732551-ea87-4a5d-aaef-214b195b4022"), "نصرت آباد", 9 },
                    { 276, new Guid("ba61891a-082d-4db7-8286-a202ad78afe8"), "ميرجاوه", 9 },
                    { 275, new Guid("cd3eae99-2c40-40e6-8bf5-6583ae8e6496"), "مهرستان", 9 },
                    { 274, new Guid("451d45c4-c679-463f-b5fe-8a78c8cb07df"), "محمدي", 9 },
                    { 273, new Guid("cc9f746d-2ec8-4462-bdef-30484465a44f"), "محمدان", 9 },
                    { 272, new Guid("950b03f6-2f5b-4675-9ac2-4e1a013e63ca"), "محمد آباد", 9 },
                    { 271, new Guid("feb8a660-4bf2-43d8-ad45-85556c22613a"), "قصر قند", 9 },
                    { 270, new Guid("83a16bd4-f931-4b7e-9834-498831fba99d"), "فنوج", 9 },
                    { 285, new Guid("c224777f-2042-4d9f-905a-dca88f295f5a"), "گشت", 9 },
                    { 269, new Guid("b64e2d14-1c4f-410d-ba07-5d1a70fac380"), "علي اکبر", 9 },
                    { 286, new Guid("c5b03743-f698-456b-a8e8-780bb6e60c97"), "گلمورتي", 9 },
                    { 288, new Guid("63c01059-b1f6-49f0-8e4e-91cc042052eb"), "آيسک", 10 },
                    { 303, new Guid("5bb65057-62df-4440-b3d4-a298877c84f2"), "شوسف", 10 },
                    { 302, new Guid("36c98bea-d146-46e0-ab7f-28adba334934"), "سه قلعه", 10 },
                    { 301, new Guid("d0a73da1-c344-4265-98cb-2910dd8a8070"), "سربيشه", 10 },
                    { 300, new Guid("28af12f3-31d0-4a1e-a455-a710205ad17f"), "سرايان", 10 },
                    { 299, new Guid("a080be88-3742-4866-bc62-a355a5aff7eb"), "زهان", 10 },
                    { 1241, new Guid("01290d98-cae7-4393-9bad-89ab2518d7e4"), "گراب سفلي", 31 },
                    { 297, new Guid("27eb35fb-75c7-4ac4-b726-a1b161897404"), "خوسف", 10 },
                    { 296, new Guid("f2ea235e-024e-4061-ac09-86632d48a94f"), "خضري دشت بياض", 10 },
                    { 295, new Guid("4d0ebba4-48be-4d73-8228-b551f24c00ef"), "حاجي آباد", 10 },
                    { 294, new Guid("34a27438-3d1f-48aa-8e8d-92e3020617da"), "بيرجند", 10 },
                    { 293, new Guid("4d8e0e68-4d25-4f52-94d4-f1f52969c1e0"), "بشرويه", 10 },
                    { 292, new Guid("acec14b4-91f5-4e04-ac09-b6d50be29d64"), "اسلاميه", 10 },
                    { 291, new Guid("e8d9c615-6f87-4062-ab40-4dc92dfe6dc5"), "اسفدن", 10 },
                    { 290, new Guid("bc39fea2-ba6a-4f6f-b850-5ee4f502a804"), "اسديه", 10 },
                    { 289, new Guid("e84f8522-0598-49d2-9763-fee9e6dd7397"), "ارسک", 10 },
                    { 287, new Guid("d44f265b-7574-4655-be41-dd51c709c791"), "آرين شهر", 10 },
                    { 268, new Guid("0a2233fd-4bd7-419d-91a2-566027bbdf65"), "سيرکان", 9 },
                    { 267, new Guid("b7f2450b-afca-43ad-841b-fceff8b117f2"), "سوران", 9 },
                    { 266, new Guid("9a9b3ed1-8e48-4eff-96ba-cdbb23cd5cdd"), "سرباز", 9 },
                    { 245, new Guid("d7f5c3d7-36a9-4334-a322-19ec3e8ddcb1"), "کدکن", 8 },
                    { 244, new Guid("40c18785-8780-4227-bfbf-4cdfbb546014"), "کاشمر", 8 },
                    { 243, new Guid("d18e5c47-f0ce-4e94-ab71-a60e762b052b"), "کاريز", 8 },
                    { 242, new Guid("99c66d45-2f4d-45aa-bcff-72b515c585ae"), "کاخک", 8 },
                    { 241, new Guid("4b771f65-3045-419b-953a-abfdd4fd68a1"), "چکنه", 8 },
                    { 240, new Guid("9c02a32a-1dae-4642-b372-a18c9f7c37ea"), "چناران", 8 },
                    { 239, new Guid("4ac5d619-8201-4363-a9c5-4cebce079bfe"), "چاپشلو", 8 },
                    { 238, new Guid("4f6759bf-dd73-4cd5-90bb-825e13907896"), "يونسي", 8 },
                    { 237, new Guid("b1a345f9-a144-4685-ada4-c395cb059e99"), "همت آباد", 8 },
                    { 236, new Guid("61b946cd-0795-44ec-93e5-499ac8d54382"), "نيل شهر", 8 },
                    { 235, new Guid("e32be3fe-8a1e-4693-af28-6bd798632667"), "نيشابور", 8 },
                    { 234, new Guid("7faa5400-bf36-4b76-8f13-1b203287b72c"), "نوخندان", 8 },
                    { 233, new Guid("9d78c2a0-793b-46bc-8340-a1bc26b081e3"), "نقاب", 8 },
                    { 232, new Guid("7b2a5aa4-7773-4754-8a08-f9459355195b"), "نصرآباد", 8 },
                    { 231, new Guid("e23a6987-fc30-47ad-87f8-e8431e6a4c63"), "نشتيفان", 8 },
                    { 246, new Guid("40e606f4-9928-4004-ad68-e4a563774b40"), "کلات", 8 },
                    { 247, new Guid("5cf80579-ef46-4266-8e1f-20f7395bbe65"), "کندر", 8 },
                    { 248, new Guid("82242ea5-ccbb-49e3-aa0a-9db4eb111838"), "گلمکان", 8 },
                    { 249, new Guid("1f8b326c-289d-47f1-af9d-77b40f7e2de1"), "گناباد", 8 },
                    { 265, new Guid("afbaf9b8-877d-43e1-8a0d-e3d19d7be8af"), "سراوان", 9 },
                    { 264, new Guid("03843e11-f3ac-4436-8683-8e694d74fbd3"), "زهک", 9 },
                    { 263, new Guid("90bafcc2-8c65-4da5-ad29-3058c6c0ac20"), "زرآباد", 9 },
                    { 262, new Guid("b4c13123-ec04-48fa-88a6-8cd1313ed34d"), "زاهدان", 9 },
                    { 261, new Guid("4dc503c6-f3c3-47bc-b33c-527fb0c06e82"), "زابل", 9 },
                    { 260, new Guid("0728eab1-503e-46dd-b5d3-306f82ced059"), "راسک", 9 },
                    { 259, new Guid("2e412496-e50a-436d-ac6b-a628ef6b41d0"), "دوست محمد", 9 },
                    { 154, new Guid("90bc7cd4-9379-4a5a-a22e-aed58d2881b5"), "سيمينه", 7 },
                    { 258, new Guid("b7a9f229-d18d-4cb4-b1b4-f9b982b0a302"), "خاش", 9 },
                    { 256, new Guid("f46944dd-6510-4e02-a9c7-c8c178b87151"), "بنجار", 9 },
                    { 255, new Guid("a429e4f4-59ff-48c4-879c-a552d94061d3"), "بنت", 9 },
                    { 254, new Guid("daa54378-3a0a-4a87-9b18-f3c74c9ba3cb"), "بمپور", 9 },
                    { 253, new Guid("6d598772-b3d9-4c2d-ad52-f0f4cbafb008"), "بزمان", 9 },
                    { 252, new Guid("dc91a460-61b2-4df8-8a30-b9a1779baeae"), "ايرانشهر", 9 },
                    { 251, new Guid("3f7d6755-760b-46a0-b748-a91d5ff59746"), "اسپکه", 9 },
                    { 250, new Guid("87bdeb49-1480-4926-b615-4821f4bd9448"), "اديمي", 9 },
                    { 257, new Guid("f80f5b11-5357-4c8f-892d-64be14b99ab8"), "جالق", 9 },
                    { 153, new Guid("c0c5d5f5-1c4a-4c78-9e47-acbf64dc02b2"), "سيلوانه", 7 },
                    { 152, new Guid("6d1f151a-ca75-4c04-9870-7c291869b086"), "سلماس", 7 },
                    { 151, new Guid("29b8a1f0-f7d4-46ab-9d7b-82f9ee15a429"), "سرو", 7 },
                    { 54, new Guid("71276e34-177d-4a33-a94c-e1ea24e24898"), "پردنجان", 2 },
                    { 53, new Guid("7823450b-0158-475a-bd21-6516e5a92166"), "وردنجان", 2 },
                    { 52, new Guid("539978c9-4db5-4b15-abfb-1d35c1805cbf"), "هفشجان", 2 },
                    { 51, new Guid("e42db058-fa1c-4ec6-812f-813a1e103947"), "هاروني", 2 },
                    { 50, new Guid("fa12c331-1a9e-44c5-96a7-d416b09a8766"), "نقنه", 2 },
                    { 49, new Guid("1b4c4bcf-8b50-4072-88f5-e875a603c2b2"), "نافچ", 2 },
                    { 48, new Guid("03f1d417-180a-4ae3-a736-f0d705c08fa6"), "ناغان", 2 },
                    { 47, new Guid("ee43ca0d-5d57-4cf8-ae3b-62df3045ce14"), "منج", 2 },
                    { 46, new Guid("c2d95a53-536f-4dd7-b267-c856cf4ad309"), "مال خليفه", 2 },
                    { 45, new Guid("1efd4878-cb5b-47f6-adfc-d94533ae3c43"), "لردگان", 2 },
                    { 44, new Guid("a2c64729-fbcb-4546-9d18-1c10dbd88175"), "فرخ شهر", 2 },
                    { 43, new Guid("7ce11fef-41c7-4184-afa2-ed341fc9b8c2"), "فرادنبه", 2 },
                    { 42, new Guid("44098f94-f559-4d77-b8db-fde223db8adc"), "فارسان", 2 },
                    { 41, new Guid("bcd59860-b141-4bd2-a475-7c93549b4522"), "طاقانک", 2 },
                    { 40, new Guid("b89e088c-35b3-42ce-acc6-c2dd4d973147"), "صمصامي", 2 },
                    { 55, new Guid("ccffda61-ae59-495b-884c-a2ad3cbef2fb"), "چليچه", 2 },
                    { 39, new Guid("b1958ca7-22a9-4ce9-a228-9cdf9e9e74a7"), "شهرکرد", 2 },
                    { 56, new Guid("97c06596-cdab-421b-ae4e-4b9a9e7f785b"), "چلگرد", 2 },
                    { 58, new Guid("2e0db432-ce07-42ac-ace2-f6a5d9602a8b"), "کيان", 2 },
                    { 73, new Guid("0a9d9a8e-971c-4de5-9aae-76a0ad7e1215"), "سنخواست", 3 },
                    { 72, new Guid("632d76df-4c3b-4c37-9a3e-60e822c1e182"), "زيارت", 3 },
                    { 71, new Guid("2d9bd20d-6d1b-435a-a50a-7a72523f94c0"), "راز", 3 },
                    { 70, new Guid("c76c18ae-0562-4595-a797-695ded6a404c"), "درق", 3 },
                    { 69, new Guid("ae0d27b8-c2e5-45c7-8d6f-bde03ddc9a42"), "حصارگرمخان", 3 },
                    { 68, new Guid("a7acf3b2-4448-4cf3-af50-9ea5ebe771c9"), "جاجرم", 3 },
                    { 67, new Guid("7c502f8d-0cb5-4008-8360-5daba43a0abf"), "تيتکانلو", 3 },
                    { 66, new Guid("58b038ea-ad97-4ccb-ad21-5618e3acde20"), "بجنورد", 3 },
                    { 65, new Guid("1a72ec78-426f-4eed-99d4-df50b9be7620"), "ايور", 3 },
                    { 64, new Guid("a240a1ac-0a78-4b43-bb5d-d4f45babe8ea"), "اسفراين", 3 },
                    { 63, new Guid("7d0bf73f-0719-4750-922f-bfb534018bc6"), "آوا", 3 },
                    { 62, new Guid("2fe0e8eb-4377-4147-9ab1-0b237ae1cdb2"), "آشخانه", 3 },
                    { 61, new Guid("1711ce7a-0bcd-48fd-b3c5-9e32fbb35057"), "گوجان", 2 },
                    { 60, new Guid("f225c293-d020-4fb7-ad14-45947bb61c62"), "گهرو", 2 },
                    { 59, new Guid("35809a76-e07a-4acc-907a-5d790e3334e6"), "گندمان", 2 },
                    { 57, new Guid("5afdfeaa-441a-4428-bff7-4f0fae2a91ec"), "کاج", 2 },
                    { 38, new Guid("b8166113-f232-4adf-8917-4629ecb5fed4"), "شلمزار", 2 },
                    { 37, new Guid("0f8f2f59-1282-4cc0-8034-e04241c6b667"), "سورشجان", 2 },
                    { 36, new Guid("b9cf7249-5763-4747-9ac8-43603959056e"), "سودجان", 2 },
                    { 15, new Guid("07d26aea-d367-4e3f-a0c1-4f0df1f414ec"), "مهردشت", 1 },
                    { 14, new Guid("631bcfb4-2f57-46e8-807e-500cdc6c8a1a"), "مروست", 1 },
                    { 13, new Guid("59284413-344f-4e5b-9547-08e8703a52bf"), "عقدا", 1 },
                    { 12, new Guid("541b714b-da2b-475c-98a4-8b9ed6595ba1"), "شاهديه", 1 },
                    { 11, new Guid("e89858a0-aecc-43c6-a434-4328087661cc"), "زارچ", 1 },
                    { 10, new Guid("732574f6-c132-4ab9-aaea-36885d56c3ab"), "خضر آباد", 1 },
                    { 9, new Guid("8773270c-2af5-4a3f-afde-6226c6ae6e2d"), "حميديا", 1 },
                    { 8, new Guid("a89068f9-ad53-49a3-9208-5c4f42d61a2e"), "تفت", 1 },
                    { 7, new Guid("8e1ab57a-01bb-4bcf-9a43-99a69a32717f"), "بهاباد", 1 },
                    { 6, new Guid("5944faec-497e-4f42-a3ba-4ac085099047"), "بفروئيه", 1 },
                    { 5, new Guid("31c07868-f144-4fa0-a1d2-5eed5c225a3d"), "بافق", 1 },
                    { 4, new Guid("5fcbeed6-550a-467a-9bcb-f551534cc2aa"), "اشکذر", 1 },
                    { 3, new Guid("0ba2046e-8c1b-4b00-956a-c38e2fa9e075"), "اردکان", 1 },
                    { 2, new Guid("1b35e00e-38be-4ced-89ff-ee3b4eb0768b"), "احمد آباد", 1 },
                    { 1, new Guid("55bc23a8-7b7e-4a54-9485-f63035938c09"), "ابرکوه", 1 },
                    { 16, new Guid("90483576-d7c2-4027-b2c3-b2e27641b717"), "مهريز", 1 },
                    { 17, new Guid("698799b5-72a9-4e3b-977c-b0b29e6b970d"), "ميبد", 1 },
                    { 18, new Guid("f7b6d8b7-1b6f-4a98-908b-d2f8f2b07d44"), "ندوشن", 1 },
                    { 19, new Guid("b201983b-1302-4a33-8289-19729b7d3c94"), "نير", 1 },
                    { 35, new Guid("53148048-b6c7-413e-a923-217cfef03ff3"), "سفيد دشت", 2 },
                    { 34, new Guid("cdc8b6b6-3f9d-42d8-8a86-89d9455c012f"), "سردشت لردگان", 2 },
                    { 33, new Guid("cee2cda8-27d3-465f-990f-de3af899d954"), "سرخون", 2 },
                    { 32, new Guid("619eb7bb-3ae7-404c-add9-5f89f3d85b3a"), "سامان", 2 },
                    { 31, new Guid("67bdab72-78e3-47ab-8df8-06942288cc69"), "دشتک", 2 },
                    { 30, new Guid("730b72bd-91cf-410b-b4a7-8571b6d8a7dc"), "دستناء", 2 },
                    { 29, new Guid("5173c229-a843-44df-a5cf-3ef575a2a86a"), "جونقان", 2 },
                    { 74, new Guid("8b6297fe-1164-465c-9629-1377a27864f4"), "شوقان", 3 },
                    { 28, new Guid("aab05ff8-e306-4452-b208-55be7dccd941"), "بن", 2 },
                    { 26, new Guid("4261f9a6-7cfd-4533-a34d-5ab562d857a5"), "بروجن", 2 },
                    { 25, new Guid("39133ce3-cc68-40a0-b251-b198c7a1ba3b"), "بازفت", 2 },
                    { 24, new Guid("dc7d4ada-3d8e-4685-9fe8-acf430aa3106"), "باباحيدر", 2 },
                    { 23, new Guid("ef2e7fa8-6c39-488b-8efe-fff318fb08ba"), "اردل", 2 },
                    { 22, new Guid("5d53bfca-306b-4870-aa5d-ecfa077543be"), "آلوني", 2 },
                    { 21, new Guid("f89ac655-2d7e-45c2-8758-074a481bdfd5"), "يزد", 1 },
                    { 20, new Guid("63c51109-68ae-4e6d-baca-cd8adc08d51e"), "هرات", 1 },
                    { 27, new Guid("5a1880f3-fd81-45a7-9368-ece72ba7753f"), "بلداجي", 2 },
                    { 304, new Guid("b9575c2e-0f49-4109-8479-0d7b622b8805"), "طبس", 10 },
                    { 75, new Guid("505ae87e-8927-4ed3-9567-62068fed6871"), "شيروان", 3 },
                    { 77, new Guid("e2de3ecc-4b10-49b2-b930-07fbbbe127ab"), "فاروج", 3 },
                    { 131, new Guid("f9874b3f-352c-4751-8008-6a13bbf42214"), "پيرتاج", 6 },
                    { 130, new Guid("f56622f8-4eaf-4bf4-8524-09e18e86ab7f"), "ياسوکند", 6 },
                    { 129, new Guid("023f63c6-0c6d-484a-b5af-d364964a2317"), "موچش", 6 },
                    { 128, new Guid("1be84d53-37f2-4beb-bf8b-f32aa4063bba"), "مريوان", 6 },
                    { 127, new Guid("25f40a35-cea7-4e03-a2de-25c0a16bc0be"), "قروه", 6 },
                    { 126, new Guid("4c747770-15a8-466c-baa1-54ea16788cce"), "صاحب", 6 },
                    { 125, new Guid("e43c5b35-b4d7-4622-b2de-a4993d940d2e"), "شويشه", 6 },
                    { 124, new Guid("b65a1fd1-5ce2-4723-a0b7-ee1a91268edc"), "سنندج", 6 },
                    { 123, new Guid("46fcd2fb-3a60-4986-b359-1cfd4fdda0b8"), "سقز", 6 },
                    { 122, new Guid("ce77d017-9612-4980-844f-bbfb33786988"), "سريش آباد", 6 },
                    { 121, new Guid("c909afa6-69a7-4c55-90c2-fb0a7d183eb6"), "سرو آباد", 6 },
                    { 120, new Guid("86af2fb4-e898-409a-90d9-f8cb7a7921e4"), "زرينه", 6 },
                    { 119, new Guid("beade45d-1181-4d22-b3af-99a223a780fa"), "ديواندره", 6 },
                    { 118, new Guid("524be907-d4a6-42d2-9439-e4914d54f731"), "دهگلان", 6 },
                    { 117, new Guid("096a15db-c2a1-4286-882d-05ad4ddc9524"), "دلبران", 6 },
                    { 132, new Guid("58fd46bd-2fb2-42ba-ad56-13126ecd9c6c"), "چناره", 6 },
                    { 116, new Guid("7765f990-12dd-4958-9997-1805cf55dedc"), "دزج", 6 },
                    { 133, new Guid("6b0f47d6-9cdb-4234-88a1-43ea5e4c6e31"), "کامياران", 6 },
                    { 135, new Guid("3a794274-0b3a-4b78-8b3d-44acac48cf4f"), "کاني سور", 6 },
                    { 150, new Guid("6257d4ef-0021-4558-bfb9-5dd3823f5639"), "سردشت", 7 },
                    { 149, new Guid("7228134d-6262-4111-b6c7-d30aa1052286"), "زرآباد", 7 },
                    { 148, new Guid("ec635ca9-0dd9-4e91-a1c4-fde035546c25"), "ربط", 7 },
                    { 147, new Guid("8ff53d37-a343-46be-a99a-c62cfcaa9cfe"), "ديزج ديز", 7 },
                    { 146, new Guid("e10c4063-29a7-4eb2-b929-689c47d28ee8"), "خوي", 7 },
                    { 145, new Guid("07034e69-61b5-463b-89af-4cecae74430c"), "خليفان", 7 },
                    { 144, new Guid("7c7fa71a-8d91-4f6f-8885-2ddc39f475ab"), "تکاب", 7 },
                    { 143, new Guid("cb657004-b662-4797-95dc-153756809453"), "تازه شهر", 7 },
                    { 142, new Guid("d6b18088-2cc3-4862-bf2a-80cc7acdcd59"), "بوکان", 7 },
                    { 141, new Guid("9f76854c-b728-4852-9a9a-067b54d0c496"), "بازرگان", 7 },
                    { 140, new Guid("28232183-8fac-4cf9-878d-91be7449b696"), "باروق", 7 },
                    { 139, new Guid("2a7d8d8a-e760-4edc-ab0b-b64ff96606c9"), "ايواوغلي", 7 },
                    { 138, new Guid("e83d807d-4c35-49c4-a67e-3f91c1e77dfb"), "اشنويه", 7 },
                    { 137, new Guid("6815acc8-47e2-4ad5-97eb-1793870a6d3a"), "اروميه", 7 },
                    { 136, new Guid("0cc9b439-1ccb-40d2-939a-f101b846039c"), "آواجيق", 7 },
                    { 134, new Guid("63af095a-7a03-4eec-b4fa-d9a306e0153c"), "کاني دينار", 6 },
                    { 115, new Guid("3210fc77-8e42-43d4-8d2f-1cb3c549f62a"), "توپ آغاج", 6 },
                    { 114, new Guid("c72940a1-25b9-42c6-8c07-7ab846c78fb3"), "بيجار", 6 },
                    { 113, new Guid("e5360995-482d-4267-b92f-d1b99525f45e"), "بوئين سفلي", 6 },
                    { 92, new Guid("41968390-633c-4cf3-8d91-df5f6c496d9e"), "مشکين دشت", 4 },
                    { 91, new Guid("2c122eda-fa84-48d3-a291-bf11f784a2cb"), "محمد شهر", 4 },
                    { 90, new Guid("d2691b95-c4c1-4c8e-94de-52fdde743a9a"), "ماهدشت", 4 },
                    { 89, new Guid("ea862496-a521-4e61-adcd-6a1270a102f2"), "فرديس", 4 },
                    { 88, new Guid("ad93c31b-e104-4ce8-b186-aa72ad065dc4"), "طالقان", 4 },
                    { 87, new Guid("16523df0-9f69-4a5c-8360-fca0cab5e6f4"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("3434b714-1908-4b70-8e13-5c23f89a0cdc"), "تنکمان", 4 },
                    { 85, new Guid("edfe865a-60cf-444f-9da6-74ff05919409"), "اشتهارد", 4 },
                    { 84, new Guid("811b59d5-a916-4feb-bf59-7f03400c5f6c"), "آسارا", 4 },
                    { 83, new Guid("fa7a8bde-0492-4a30-8d12-9a13df43b326"), "گرمه", 3 },
                    { 82, new Guid("7ef96848-afcd-4bd1-8475-8fa56455811d"), "چناران شهر", 3 },
                    { 81, new Guid("9e09a43b-688a-46eb-8bc9-71099bc7a2ad"), "پيش قلعه", 3 },
                    { 80, new Guid("c0ab5263-e806-4d63-89a4-dd966ecbf5f0"), "لوجلي", 3 },
                    { 79, new Guid("99c8bf0f-1333-4e92-8b92-a6620c8a5d59"), "قوشخانه", 3 },
                    { 78, new Guid("1ee351c9-aaff-4a1f-824e-bd8e995ad38a"), "قاضي", 3 },
                    { 93, new Guid("35ee0762-d1bc-4b8a-945f-e9cea716f901"), "نظر آباد", 4 },
                    { 94, new Guid("4ae15031-adae-49d1-ab66-4e5ec71cb465"), "هشتگرد", 4 },
                    { 95, new Guid("194de989-efa2-4e53-bce3-53128a0f38d6"), "چهارباغ", 4 },
                    { 96, new Guid("d9216bd0-1087-4d98-b99f-aadcdbf49a2e"), "کرج", 4 },
                    { 112, new Guid("8f257074-f39e-4cf0-bd49-96c94f557b3d"), "بلبان آباد", 6 },
                    { 111, new Guid("8fe8c738-c8da-4e06-854f-32ee08453a63"), "برده رشه", 6 },
                    { 110, new Guid("533a43ab-6811-44e0-b731-f88c43f08c15"), "بانه", 6 },
                    { 109, new Guid("2a476dab-2505-47d4-ae36-e81e876e9340"), "بابارشاني", 6 },
                    { 108, new Guid("43640e2f-7921-4aea-a045-254b34ae0983"), "اورامان تخت", 6 },
                    { 107, new Guid("d79e3932-2e1f-41ca-8c6a-61209a4247f0"), "آرمرده", 6 },
                    { 106, new Guid("a49a07d9-e36f-4bec-b001-f797e0910489"), "کهک", 5 },
                    { 76, new Guid("35eed29c-aed3-44e0-a124-57694ea71a78"), "صفي آباد", 3 },
                    { 105, new Guid("b9edf0ae-6b40-4f41-af40-747b5b770223"), "قنوات", 5 },
                    { 103, new Guid("6d4395c5-bd89-4f7b-bd1c-a8e3253c6201"), "سلفچگان", 5 },
                    { 102, new Guid("2f2ddae7-5e2a-4def-b896-625f7eda86cf"), "دستجرد", 5 },
                    { 101, new Guid("50dd692a-0b42-4523-8257-9ab1af0c87a8"), "جعفريه", 5 },
                    { 100, new Guid("f84e834c-7ffa-4996-a3ed-8015fbf37b32"), "گلسار", 4 },
                    { 99, new Guid("748b3797-f864-4bd1-bda0-37b336f556ca"), "گرمدره", 4 },
                    { 98, new Guid("9215a5e0-668e-4751-8e1a-238c2e370bab"), "کوهسار", 4 },
                    { 97, new Guid("35845c1c-7e79-46f2-8182-10aaf38589b9"), "کمال شهر", 4 },
                    { 104, new Guid("d4837a2a-61f7-4225-8d21-a0d2da5b8b61"), "قم", 5 },
                    { 305, new Guid("49406677-2657-49f6-a31c-9ebb410d4a6f"), "طبس مسينا", 10 },
                    { 298, new Guid("8b92bccb-1aee-499a-bbd9-833dcde5da2e"), "ديهوک", 10 },
                    { 307, new Guid("be3d9977-1df1-4e3d-941c-f825deafdddd"), "فردوس", 10 },
                    { 515, new Guid("0f25de89-af4e-4895-a391-707e60a8c4f3"), "نور", 15 },
                    { 514, new Guid("93630977-2c83-4951-8f0c-8163838485ed"), "نشتارود", 15 },
                    { 513, new Guid("b96f3bc2-6357-4ea5-8059-f4fd589c038d"), "مرزيکلا", 15 },
                    { 512, new Guid("bb3d396a-55e1-43a1-b729-1de3d17574a3"), "مرزن آباد", 15 },
                    { 511, new Guid("68c2ed83-b35a-4d6d-93ca-d297229d6124"), "محمود آباد", 15 },
                    { 510, new Guid("cfe04d4a-3c48-452e-9363-fe80372b2b84"), "قائم شهر", 15 },
                    { 509, new Guid("a0181cc7-d196-45c3-9bd9-a59da15b3554"), "فريم", 15 },
                    { 508, new Guid("906ff93c-b688-4847-a769-8c14f2730f66"), "فريدونکنار", 15 },
                    { 507, new Guid("a50de7bc-4b5a-4290-863f-99d86d6e9ad9"), "عباس آباد", 15 },
                    { 506, new Guid("ce3949d6-efdb-438a-bd1a-a2eb0bfce4a8"), "شيرگاه", 15 },
                    { 505, new Guid("7fa21b07-17e4-47ee-834e-bd4af5b2b359"), "شيرود", 15 },
                    { 504, new Guid("85141082-4ed0-4518-8433-3394d204294f"), "سورک", 15 },
                    { 503, new Guid("d48e2f7c-9f17-4a34-9425-8ecceb0227b3"), "سلمان شهر", 15 },
                    { 502, new Guid("99acdd2f-159a-4bd9-9baa-164fc2adef4a"), "سرخرود", 15 },
                    { 501, new Guid("58dba0bc-694d-43f3-8a9f-21080081d669"), "ساري", 15 },
                    { 516, new Guid("08f4dd1a-115d-44fa-b1c1-f6e9632f3c7d"), "نوشهر", 15 },
                    { 500, new Guid("6971a731-5352-49ae-9257-13c7a79964a4"), "زيرآب", 15 },
                    { 517, new Guid("0e7a0dc7-dabc-49e5-b692-8ccd34ee5264"), "نکا", 15 },
                    { 519, new Guid("7f99a206-63c3-468c-881c-bcd76c5fc6fc"), "هچيرود", 15 },
                    { 534, new Guid("d650309e-0a30-400c-a79e-6e1ead7f4584"), "گلوگاه", 15 },
                    { 533, new Guid("f9a2eebf-431d-4f53-bf67-49069ed5ad8e"), "گزنک", 15 },
                    { 532, new Guid("b700615f-188e-42a8-b414-a5e002550010"), "گتاب", 15 },
                    { 531, new Guid("1292951e-77fd-4d1e-a9aa-42e28c6bd579"), "کياکلا", 15 },
                    { 530, new Guid("6303f547-e9cc-429c-b063-defb96fe1ea7"), "کياسر", 15 },
                    { 529, new Guid("40c4c83c-a9ea-4d8c-9dad-c3603db5d0fc"), "کوهي خيل", 15 },
                    { 528, new Guid("dfce8dea-93b5-47ae-97be-484d5d2686bc"), "کلاردشت", 15 },
                    { 527, new Guid("f1a67cdb-22d7-4cab-8420-f011e5a566fe"), "کلارآباد", 15 },
                    { 526, new Guid("55471767-55dd-443d-b010-ca020511ca05"), "کجور", 15 },
                    { 525, new Guid("c72e8360-c55f-4347-9eb2-477f8dafc420"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("4032a996-0019-42b7-9d1f-ff1d3a084a54"), "چمستان", 15 },
                    { 523, new Guid("3d32a8bf-6fe2-4985-bb5a-fecabc906290"), "چالوس", 15 },
                    { 522, new Guid("54a73910-e16f-4b8d-af99-1805bfa90968"), "پول", 15 },
                    { 521, new Guid("9fc1c5d0-437b-48ed-a7be-1e7208f579c0"), "پل سفيد", 15 },
                    { 520, new Guid("dd0fe304-82e2-4ade-b94e-ebf00ac1c17f"), "پايين هولار", 15 },
                    { 518, new Guid("58b28801-9ab4-4882-a1d5-35095abd51f1"), "هادي شهر", 15 },
                    { 499, new Guid("ff71ceb7-598f-449a-b064-db1d1a77cef9"), "زرگر محله", 15 },
                    { 498, new Guid("8740b7d4-81c3-4b9b-bd4a-cd56641e72ed"), "رينه", 15 },
                    { 497, new Guid("547c9fd7-b876-4237-a98d-e44c70ec9f6c"), "رويان", 15 },
                    { 476, new Guid("5de34167-5e9d-45f7-848a-c20c7536eba6"), "گميش تپه", 14 },
                    { 475, new Guid("6b49fd2a-2806-4368-ad09-367a5e5e8a31"), "گرگان", 14 },
                    { 474, new Guid("95a3af5d-facc-4741-8cf3-4d1d91475526"), "گاليکش", 14 },
                    { 473, new Guid("357034fa-b817-4ee3-8b02-11e04b5aedc2"), "کلاله", 14 },
                    { 472, new Guid("9c872334-61fd-4b60-b9e1-ff30cf89d0ef"), "کرد کوي", 14 },
                    { 471, new Guid("6d655f0e-5920-48a8-8313-9d738432e5a6"), "نگين شهر", 14 },
                    { 470, new Guid("0fdcc474-878b-42b9-a097-8c0a832bbcd7"), "نوکنده", 14 },
                    { 469, new Guid("644bf88c-f3ae-4a3c-b80a-affbefdd07a7"), "نوده خاندوز", 14 },
                    { 468, new Guid("aef2417f-d989-497d-87ab-fbfc465ac059"), "مينودشت", 14 },
                    { 306, new Guid("4d5b8340-086e-4886-92b8-40ad7a2e7e1b"), "عشق آباد", 10 },
                    { 466, new Guid("ab5b63e5-ec60-4491-941c-2102e5bc0cc4"), "مراوه تپه", 14 },
                    { 465, new Guid("46cf54d9-fcf7-4f6a-8412-4e3c02c4a9c2"), "فراغي", 14 },
                    { 464, new Guid("510f0ba4-8aa3-43ba-b2e4-da3152ec5da0"), "فاضل آباد", 14 },
                    { 463, new Guid("ccec8680-1ef3-4523-84d6-4995770619e6"), "علي آباد", 14 },
                    { 462, new Guid("54bd8d86-9816-4d49-883c-0aca21148e28"), "سيمين شهر", 14 },
                    { 477, new Guid("79bba766-4818-43dd-9a34-1d4ba57ac46f"), "گنبدکاووس", 14 },
                    { 478, new Guid("f90d5de9-f3f5-40ea-9421-c811570c9d8a"), "آلاشت", 15 },
                    { 479, new Guid("6f9cba9b-6087-49bb-8b56-49c6ed954067"), "آمل", 15 },
                    { 480, new Guid("40ae968d-8079-4556-ab71-38d3cef8e3ff"), "ارطه", 15 },
                    { 496, new Guid("dfb43612-6254-4b42-8a53-9bcb28b8c96b"), "رستمکلا", 15 },
                    { 495, new Guid("d9564b6a-1f86-423d-9c28-620f50f24ad4"), "رامسر", 15 },
                    { 494, new Guid("efee595c-5167-4e76-a9e9-94b7fd11801d"), "دابودشت", 15 },
                    { 493, new Guid("412b9c22-39d1-45cd-a8b3-548647bdd500"), "خوش رودپي", 15 },
                    { 492, new Guid("bc8d2ffa-84fd-44ef-867a-538df71a6489"), "خليل شهر", 15 },
                    { 491, new Guid("8ddc38b3-000f-4b50-9421-32edc8efcc15"), "خرم آباد", 15 },
                    { 490, new Guid("5d1ef22f-0e91-4b2f-9aa1-1c992a7e4f4b"), "جويبار", 15 },
                    { 535, new Guid("1226c4b9-3610-440d-b57d-60fa898b183f"), "آبيک", 16 },
                    { 489, new Guid("f8c9ddd2-bafc-47b7-bf5e-d25ad90218b2"), "تنکابن", 15 },
                    { 487, new Guid("18f0ee8a-867f-4b04-881b-3096c9607ea8"), "بهشهر", 15 },
                    { 486, new Guid("91e68a62-6373-4eec-9e89-e3fc7b002923"), "بلده", 15 },
                    { 485, new Guid("177684b4-2c39-404e-9334-e96d9e82fb8c"), "بابلسر", 15 },
                    { 484, new Guid("5d0cd48b-5298-4b47-86c3-1c11531ff4ef"), "بابل", 15 },
                    { 483, new Guid("ce9c5993-b4cb-4aa3-b251-ee2797b56f2f"), "ايزد شهر", 15 },
                    { 482, new Guid("f4c57103-babc-472f-ba57-5ba86e4cf7e5"), "امير کلا", 15 },
                    { 481, new Guid("9445eb89-8b2b-46fd-9902-58bd0a8e2831"), "امامزاده عبدالله", 15 },
                    { 488, new Guid("52987527-9520-495a-9c0b-204f08dec689"), "بهنمير", 15 },
                    { 461, new Guid("1961a663-919a-400e-b109-e43f02986556"), "سنگدوين", 14 },
                    { 536, new Guid("feb4df10-cf5c-4d51-b198-5816f0326355"), "آبگرم", 16 },
                    { 538, new Guid("e597c139-e8f4-4010-ab46-36e27834f6a0"), "ارداق", 16 },
                    { 592, new Guid("cfe51037-33db-4034-8aa7-363d453b1e05"), "جعفر آباد", 18 },
                    { 591, new Guid("8b05c274-af01-429e-96c4-4948ebe1f636"), "تازه کند انگوت", 18 },
                    { 590, new Guid("c820bb46-7775-4400-9dff-5b5d16c77c0d"), "تازه کند", 18 },
                    { 589, new Guid("22614607-511c-407b-a50f-7222fa83c907"), "بيله سوار", 18 },
                    { 588, new Guid("0d9e04b1-bd2e-49d7-85de-fff8a674ae0b"), "اصلاندوز", 18 },
                    { 587, new Guid("5475bc62-df42-42de-930d-9736bdb3a6ba"), "اسلام آباد", 18 },
                    { 586, new Guid("717568f9-b653-4cd7-a99f-cc6095d89189"), "اردبيل", 18 },
                    { 585, new Guid("100a7aa9-33ad-4496-8d3b-97cf68c05210"), "آبي بيگلو", 18 },
                    { 584, new Guid("3dd69b3f-8344-4991-b8c9-f0d0e738b360"), "گراب", 17 },
                    { 583, new Guid("fa58d13e-e68d-4dc8-8741-b8bacfbc48e1"), "کوهناني", 17 },
                    { 582, new Guid("ee47e2fb-9839-4c79-91f1-eb39dfca59b2"), "کوهدشت", 17 },
                    { 581, new Guid("9eccb11e-5c39-4834-a17a-4785eb704e86"), "چقابل", 17 },
                    { 580, new Guid("56305357-9bdf-4e7e-a654-a8d183ae7ea0"), "چالانچولان", 17 },
                    { 579, new Guid("4f46d995-7918-4f4b-a907-e758cb7d0c4e"), "پلدختر", 17 },
                    { 578, new Guid("cd93a294-a970-43e9-bd15-45cf3c74f716"), "ويسيان", 17 },
                    { 593, new Guid("f11b62d1-a7ff-47a9-af69-fac81a17f2aa"), "خلخال", 18 },
                    { 577, new Guid("160bd9da-066d-4771-a844-42a556c1d238"), "هفت چشمه", 17 },
                    { 594, new Guid("d89b109c-8d4c-4cd0-a570-36843c15b06d"), "رضي", 18 },
                    { 596, new Guid("deeed1e3-7d40-4aa8-9ef3-b3931ea332b0"), "عنبران", 18 },
                    { 611, new Guid("d47b7841-77fc-43a1-befe-69049d02b537"), "آران و بيدگل", 19 },
                    { 610, new Guid("c64d1013-8a28-417e-8692-2730f9f6d2dd"), "گيوي", 18 },
                    { 609, new Guid("5ea89203-6cdb-476f-a14f-3f65351b8f13"), "گرمي", 18 },
                    { 608, new Guid("02398ab6-7383-474d-a315-b68e002f392c"), "کورائيم", 18 },
                    { 607, new Guid("4f4791b6-5770-4ec4-8efb-4e76f0922b37"), "کلور", 18 },
                    { 606, new Guid("834a7116-0ff8-48fd-836b-47557a83d7a5"), "پارس آباد", 18 },
                    { 605, new Guid("4135b61d-e2a9-45db-bd01-6547a5c66da2"), "هير", 18 },
                    { 604, new Guid("39d2c7b8-04b1-4383-b1c2-f869f3b3e8ee"), "هشتجين", 18 },
                    { 603, new Guid("b9d1dadc-f35c-479f-bb8b-16bc167feee1"), "نير", 18 },
                    { 602, new Guid("d0dcbf58-6c14-451a-96f6-a078c43f35ca"), "نمين", 18 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 601, new Guid("14793f40-a6d5-45c8-8981-925d4926d5ad"), "مشگين شهر", 18 },
                    { 600, new Guid("3e9e2c61-2bbc-4e12-9a8a-c546f3a6503c"), "مرادلو", 18 },
                    { 599, new Guid("b094045a-4ceb-4534-bb18-241dce9b5a2d"), "لاهرود", 18 },
                    { 598, new Guid("b17f21a3-06c3-4c9b-86bb-18bb905958b5"), "قصابه", 18 },
                    { 597, new Guid("0abd2644-7b11-41f9-8a0c-fb2e5eec5885"), "فخرآباد", 18 },
                    { 595, new Guid("29cb41a7-5da3-40d0-9961-c3f894a4627f"), "سرعين", 18 },
                    { 576, new Guid("c33873d3-40ee-4ea0-ab2a-e6dfffad8240"), "نورآباد", 17 },
                    { 575, new Guid("17de1532-1766-413d-976d-e24fef33521d"), "مومن آباد", 17 },
                    { 574, new Guid("8d28212a-d66a-49f6-be0a-30743537a57f"), "معمولان", 17 },
                    { 553, new Guid("dabee812-2eb4-4df1-995f-1d0c8d1593ff"), "ضياء آباد", 16 },
                    { 552, new Guid("aafba1fb-e987-4ac7-9af3-e7af3c6b9edb"), "شريفيه", 16 },
                    { 551, new Guid("d76ed18c-8f88-4829-93be-5cdb131e6eb3"), "شال", 16 },
                    { 550, new Guid("c5674855-fde6-4b97-bfa7-175cee8917f5"), "سگز آباد", 16 },
                    { 549, new Guid("6c2beaa3-e701-4e7c-9998-7ab4fd265813"), "سيردان", 16 },
                    { 548, new Guid("f67516d2-2fe6-4fdb-9b68-93a12b528ec2"), "رازميان", 16 },
                    { 547, new Guid("4a9801d3-2675-4b7d-84c0-3468d447953e"), "دانسفهان", 16 },
                    { 546, new Guid("8e31c702-207d-43c8-bcef-2d6345b38683"), "خرمدشت", 16 },
                    { 545, new Guid("53c2352a-c050-4231-b7e4-cf62273219ce"), "خاکعلي", 16 },
                    { 544, new Guid("064271c9-00eb-4bdb-b1ce-82a9c7778b0e"), "تاکستان", 16 },
                    { 543, new Guid("9a828685-106f-4fe2-b23f-b4bf4508d3ea"), "بيدستان", 16 },
                    { 542, new Guid("bc9a05be-b201-4753-8423-406ded9b8f27"), "بوئين زهرا", 16 },
                    { 541, new Guid("f51bcd30-8a2f-4ece-a48b-a9694ceaf7eb"), "الوند", 16 },
                    { 540, new Guid("c9e95d6b-a669-4871-b1a6-1ef723f1fd4d"), "اقباليه", 16 },
                    { 539, new Guid("33b0848e-9260-4fbe-9f04-4a18a0ea16dd"), "اسفرورين", 16 },
                    { 554, new Guid("c66a56c1-07da-4def-a5ba-ab4ee047860c"), "قزوين", 16 },
                    { 555, new Guid("78bb968e-e897-43b9-9ac4-f003fbacf29b"), "محمديه", 16 },
                    { 556, new Guid("1c4b426e-d26a-4d80-b836-a2bb07f50413"), "محمود آباد نمونه", 16 },
                    { 557, new Guid("98a3bc0f-cd17-4bb9-bcdb-7e757736ec3e"), "معلم کلايه", 16 },
                    { 573, new Guid("7783b601-fa4f-45f5-b1a9-cddb84ca52f8"), "فيروزآباد", 17 },
                    { 572, new Guid("09cbfc69-bba2-444a-acc3-41d96b4f5ebe"), "شول آباد", 17 },
                    { 571, new Guid("e2be762b-8484-4622-86f8-adf284d4cebb"), "سپيد دشت", 17 },
                    { 570, new Guid("040fae00-a5b3-4cce-a1bc-bde4c05176ee"), "سراب دوره", 17 },
                    { 569, new Guid("1301abbe-9250-4872-aee1-41639cb658ed"), "زاغه", 17 },
                    { 568, new Guid("9ceebd35-1bf6-4434-b81d-44d6fe702102"), "دورود", 17 },
                    { 567, new Guid("2d215685-e5cd-46ce-9f0e-d13728f7b6de"), "درب گنبد", 17 },
                    { 537, new Guid("2b1f0590-2d6f-4aa6-bb79-54bd2e61476b"), "آوج", 16 },
                    { 566, new Guid("0386094e-4d74-469b-a27f-00f7cbe10402"), "خرم آباد", 17 },
                    { 564, new Guid("83c31d08-12d5-421d-ac91-00b6c965e5d6"), "بروجرد", 17 },
                    { 563, new Guid("b726fcae-29c3-446b-bd6b-4d7d8a04363d"), "اليگودرز", 17 },
                    { 562, new Guid("0cc34c28-1636-45a7-b1b1-ae1c57853a59"), "الشتر", 17 },
                    { 561, new Guid("2634b826-f1ce-4ac4-a237-3775e5461c60"), "اشترينان", 17 },
                    { 560, new Guid("25365a20-835e-415a-9b2f-d05ad3a55c89"), "ازنا", 17 },
                    { 559, new Guid("8943b192-d762-42a3-ab81-3157d0bae67b"), "کوهين", 16 },
                    { 558, new Guid("4a2049e5-44f2-46a2-97f8-6af7d3f96912"), "نرجه", 16 },
                    { 565, new Guid("51e6866b-e1d0-4241-a5e1-7b310a6d1f29"), "بيرانشهر", 17 },
                    { 460, new Guid("52807589-653c-440d-8376-758e5b9d26c7"), "سرخنکلاته", 14 },
                    { 467, new Guid("f742f4f9-7605-4938-9eda-d63d129e8647"), "مزرعه", 14 },
                    { 458, new Guid("e8a7808f-5db6-421f-80d0-6f585846b483"), "دلند", 14 },
                    { 361, new Guid("5b12fdba-3a81-446f-9f7c-985e1bd4be5a"), "شوش", 11 },
                    { 360, new Guid("138c3792-13c5-4309-a8b9-7f542483b424"), "شهر امام", 11 },
                    { 359, new Guid("0e8210c9-26f6-45c3-b47f-1ebcbc729ecc"), "شمس آباد", 11 },
                    { 358, new Guid("3bca647f-3f7e-440a-b88f-cbf080c53445"), "شرافت", 11 },
                    { 357, new Guid("6f8bc059-52a2-4cbe-afb7-924ac55a1c52"), "شاوور", 11 },
                    { 356, new Guid("188e4e9c-403d-43bb-a99d-cc0b0f13b87f"), "شادگان", 11 },
                    { 355, new Guid("a881cb99-022e-4220-98a5-ccd4f14989b3"), "سياه منصور", 11 },
                    { 354, new Guid("d473dd65-3cd6-4857-902d-18a9805d8cc5"), "سوسنگرد", 11 },
                    { 353, new Guid("261eb108-41c3-4b29-967f-4dba66c6a85d"), "سماله", 11 },
                    { 352, new Guid("1d14e1c1-8d47-490a-b713-2db66a0d35b3"), "سردشت", 11 },
                    { 351, new Guid("066220ad-fb1a-49fb-88c5-efd3504fb564"), "سرداران", 11 },
                    { 350, new Guid("2ed48e78-406d-4e54-a795-1f772970ba91"), "سالند", 11 },
                    { 349, new Guid("765be761-0f57-417c-ba38-d3fb5fff6758"), "زهره", 11 },
                    { 348, new Guid("397b5ba0-b22a-47d4-9b31-56a9d1d6b9e2"), "رفيع", 11 },
                    { 347, new Guid("891c8027-e525-4c4b-8aef-e3c48861d67c"), "رامهرمز", 11 },
                    { 362, new Guid("3bc940f7-c5a4-44c9-b4e3-1cfd5715ef27"), "شوشتر", 11 },
                    { 346, new Guid("413375b9-cfea-4c7a-b3a2-473ee57f24d1"), "رامشير", 11 },
                    { 363, new Guid("eec2b4f0-3f35-4371-ae9f-753222ea19cf"), "شيبان", 11 },
                    { 365, new Guid("d753634c-11a2-44c3-95cb-ae0ab063f11c"), "صفي آباد", 11 },
                    { 380, new Guid("8bdc1064-e3bc-430d-a074-209283ac9deb"), "هنديجان", 11 },
                    { 379, new Guid("fb888c00-3758-461c-9686-b15a273b6779"), "هفتگل", 11 },
                    { 378, new Guid("34292740-d2f6-4248-a68a-1fd8a270ebf5"), "مينوشهر", 11 },
                    { 377, new Guid("788a9bcf-b65b-4b91-b69d-462d4bcd9c76"), "ميداود", 11 },
                    { 376, new Guid("88c59b41-639a-4082-9a36-62691f7d4670"), "ميانرود", 11 },
                    { 459, new Guid("3a2969a0-a070-4506-8505-179fb5fcab8e"), "راميان", 14 },
                    { 374, new Guid("31aa9f05-355b-4776-967c-3ebd5c9ee697"), "ملاثاني", 11 },
                    { 373, new Guid("c0d19c44-c172-475d-9cc2-5ff797577616"), "مقاومت", 11 },
                    { 372, new Guid("a270ead3-4b0d-47d6-96b6-ee353d803bf7"), "مشراگه", 11 },
                    { 371, new Guid("19c9f933-f6a3-4a70-a5cf-ff1666c69fa2"), "مسجد سليمان", 11 },
                    { 370, new Guid("73d6646e-8a02-4ead-8ac3-0cef2f81e29d"), "لالي", 11 },
                    { 369, new Guid("b1bb28ba-4385-4ea3-9f12-e1c9334ff9e0"), "قلعه خواجه", 11 },
                    { 368, new Guid("3a76e156-d606-4fd3-af55-56793f3594e3"), "قلعه تل", 11 },
                    { 367, new Guid("60f372e4-fff5-4ffc-89cd-afe546de39dd"), "فتح المبين", 11 },
                    { 366, new Guid("89bb7371-d257-412d-817d-4831b2f657e4"), "صيدون", 11 },
                    { 364, new Guid("3e3e8163-f403-4484-b9d6-7d1b290e0cac"), "صالح شهر", 11 },
                    { 345, new Guid("93cd496a-e5ed-41de-b5c4-30d2719f9b50"), "دهدز", 11 },
                    { 344, new Guid("8cec9608-aed0-44f6-bb56-344d4ef4443b"), "دزفول", 11 },
                    { 343, new Guid("33047707-4bd3-4ab3-9ae7-7026c9acc16b"), "دارخوين", 11 },
                    { 322, new Guid("39af090a-14a3-465c-a94c-3aef957dbd5e"), "الوان", 11 },
                    { 321, new Guid("21baca3c-e3fe-42a6-9763-46b6ccc517c4"), "الهايي", 11 },
                    { 320, new Guid("116fc426-bf4c-4310-8785-1e1953364723"), "اروند کنار", 11 },
                    { 319, new Guid("8624ec60-2793-4707-be85-f7ced28ef336"), "ابوحميظه", 11 },
                    { 318, new Guid("e676a000-fb5a-4ce8-b506-d7c4b465dc8e"), "آغاجاري", 11 },
                    { 317, new Guid("0d3ec9c9-66f2-4f3c-bbaa-62590d4f5c00"), "آزادي", 11 },
                    { 316, new Guid("e1b4c4f1-7f86-42b0-bb70-eb50caaf8bf7"), "آبژدان", 11 },
                    { 315, new Guid("0aef33eb-fabb-4622-b0db-3b305b9a5086"), "آبادان", 11 },
                    { 314, new Guid("9d6b6152-992f-438f-92ab-3c8a02bfe132"), "گزيک", 10 },
                    { 313, new Guid("4b39386b-0db5-4efb-b665-be6af2bca205"), "نيمبلوک", 10 },
                    { 312, new Guid("098e145c-d738-4b17-9019-50bdb8f9ec87"), "نهبندان", 10 },
                    { 311, new Guid("5b650877-0056-4b2f-8642-4e2b6c23547c"), "مود", 10 },
                    { 310, new Guid("7d5c82fd-d918-4dbe-8cfc-6336c8b17982"), "محمدشهر", 10 },
                    { 309, new Guid("5ba31dc8-8f32-42ad-864b-65d74aba8d60"), "قهستان", 10 },
                    { 308, new Guid("bbac8b58-3f89-45e0-afab-f71d03264942"), "قائن", 10 },
                    { 323, new Guid("4c742712-2889-46bb-a01c-a894fc54d348"), "اميديه", 11 },
                    { 324, new Guid("bbf0e57c-e048-4553-a226-51ff0541b509"), "انديمشک", 11 },
                    { 325, new Guid("c8c00918-3d40-4593-a29e-a3a44d9727df"), "اهواز", 11 },
                    { 326, new Guid("a01bc784-2040-4f98-95f0-ae526f5cf651"), "ايذه", 11 },
                    { 342, new Guid("764c2af2-bbb1-4f4a-85a8-f2a843b8d3ad"), "خنافره", 11 },
                    { 341, new Guid("4a92b383-b580-4e99-8ef9-c22aa831bd5e"), "خرمشهر", 11 },
                    { 340, new Guid("f4a1d046-234a-4566-9040-59fa44941327"), "حميديه", 11 },
                    { 339, new Guid("9c038802-0754-4c41-8d70-658ebe9a7248"), "حمزه", 11 },
                    { 338, new Guid("8f5677a2-9f00-4df6-a64f-8a65991df25d"), "حسينيه", 11 },
                    { 337, new Guid("6449ff2a-1fb6-4aa2-9672-69a9f3ea6976"), "حر", 11 },
                    { 336, new Guid("c0d0f2df-38c9-4794-8a91-52ef5d36c6fd"), "جنت مکان", 11 },
                    { 381, new Guid("fe4d0730-b718-4c0b-bd28-1ffb5b58b2f0"), "هويزه", 11 },
                    { 335, new Guid("8cf8b9b6-0e1e-4e07-bdfa-5bd6581d667a"), "جايزان", 11 },
                    { 333, new Guid("6bbc733e-31a5-4d89-8e83-c8c01456d771"), "ترکالکي", 11 },
                    { 332, new Guid("79f02b8b-ac25-45a7-a19f-1dc1e4fce26f"), "بيدروبه", 11 },
                    { 331, new Guid("ead3139d-93d5-4ddf-9e62-6915bbbc593b"), "بهبهان", 11 },
                    { 330, new Guid("ca68c07d-de20-4bed-b0c0-2caffc02577a"), "بندر ماهشهر", 11 },
                    { 329, new Guid("50e985e6-a228-4806-8985-4eef22109b9b"), "بندر امام خميني", 11 },
                    { 328, new Guid("268b2848-5057-40a2-bd59-df2555f2544d"), "بستان", 11 },
                    { 327, new Guid("5bf27b67-972f-4256-9c68-8bbea0805c7e"), "باغ ملک", 11 },
                    { 334, new Guid("0dc82733-fd79-419d-8fa4-3d27a33024a5"), "تشان", 11 },
                    { 382, new Guid("fd78f33d-c1de-463e-9567-2485cc6929d5"), "ويس", 11 },
                    { 375, new Guid("24fa3faf-db8c-4f4b-b655-fb227a5f5309"), "منصوريه", 11 },
                    { 384, new Guid("dcd0838d-6bd9-4acf-aa0f-2721fe9326d8"), "چم گلک", 11 },
                    { 438, new Guid("73479cbc-72ff-4650-91f7-791109d820fc"), "سلطانيه", 13 },
                    { 437, new Guid("cf096b43-c26b-4191-9bb1-c1deadd41b13"), "سجاس", 13 },
                    { 436, new Guid("f0d25588-e781-4415-a1ce-a45bc1dba575"), "زنجان", 13 },
                    { 435, new Guid("751260e5-12dc-485c-9437-46f8334672ea"), "زرين رود", 13 },
                    { 434, new Guid("2bb5c23a-8216-4d17-a1ed-a1fd3001f202"), "زرين آباد", 13 },
                    { 433, new Guid("bfedd22e-3574-4d2b-a568-c1be1685b2d1"), "دندي", 13 },
                    { 432, new Guid("a0d95057-41cd-4bbf-930b-c59ac325dbb2"), "خرمدره", 13 },
                    { 431, new Guid("d8ee4391-2f18-4327-b1d5-08183335cea4"), "حلب", 13 },
                    { 430, new Guid("0341194c-fb85-4792-9f86-9e8e89ac379b"), "ارمخانخانه", 13 },
                    { 383, new Guid("6c3123ef-d07c-49b0-958d-b1364db69391"), "چغاميش", 11 },
                    { 428, new Guid("3897622b-2867-4f3e-8803-6301b0ca32e3"), "آب بر", 13 },
                    { 427, new Guid("d5521475-854b-4491-8804-369b042b23e4"), "کلمه", 12 },
                    { 426, new Guid("41ee8998-810d-4032-80f8-abcdd9e53bb3"), "کاکي", 12 },
                    { 425, new Guid("811abd57-7d34-43ea-911c-f57a0ad801ff"), "چغادک", 12 },
                    { 424, new Guid("0da24bb3-f621-435a-85f7-236c0eb0b070"), "وحدتيه", 12 },
                    { 439, new Guid("90b668bb-37e3-4f5a-adb5-01a3315b68e2"), "سهرورد", 13 },
                    { 423, new Guid("02b2d783-9ca2-4e91-878c-02efc243d528"), "نخل تقي", 12 },
                    { 440, new Guid("6946a417-d609-4b28-ae0e-21990a5e546d"), "صائين قلعه", 13 },
                    { 442, new Guid("879a7c7c-e1e1-48c9-adef-dd7a57d6c517"), "ماه نشان", 13 },
                    { 457, new Guid("e449894b-1282-45bd-a334-589935c220b5"), "خان ببين", 14 },
                    { 456, new Guid("4bc2135c-c74b-4c06-bfe5-7d514dea6b41"), "جلين", 14 },
                    { 455, new Guid("a5306927-db95-4e29-9312-04234b1c4672"), "تاتار عليا", 14 },
                    { 454, new Guid("8d59aa3c-e420-4ff1-ac1e-4f2d6fe4f81c"), "بندر گز", 14 },
                    { 453, new Guid("94fb0f31-51cd-4eee-b939-4b7fc484b821"), "بندر ترکمن", 14 },
                    { 452, new Guid("737d0837-fc43-43b9-b473-0ad9a52d5ed1"), "اينچه برون", 14 },
                    { 451, new Guid("9dd6a0ac-2b45-426a-99a4-d74963cbd37c"), "انبار آلوم", 14 },
                    { 450, new Guid("c0dc7e30-522d-4ab8-a5c9-574aad9f4d34"), "آق قلا", 14 },
                    { 449, new Guid("9e0877db-0681-4f05-80a0-0d8197873432"), "آزاد شهر", 14 },
                    { 448, new Guid("3cea005a-4767-42f5-a0e7-74b596a07e2d"), "گرماب", 13 },
                    { 447, new Guid("e7a5300d-259e-4530-b106-9071c03d5172"), "کرسف", 13 },
                    { 446, new Guid("05b12fb9-47a4-40ef-abc4-113d70bcf975"), "چورزق", 13 },
                    { 445, new Guid("73805756-bef5-4608-b2b4-3be8a4817209"), "هيدج", 13 },
                    { 444, new Guid("da5de69c-291e-4175-89e2-e172b5ac6397"), "نيک پي", 13 },
                    { 443, new Guid("21ca71b1-7d02-4156-9c63-c8fcedd9106f"), "نوربهار", 13 },
                    { 441, new Guid("011e972a-e8c0-4ef6-9a63-914b27990be6"), "قيدار", 13 },
                    { 422, new Guid("1f8bd188-aa23-4101-bbb1-56a81928d309"), "عسلويه", 12 },
                    { 429, new Guid("d6ca0deb-a36b-4dca-aa0f-e7bdaf90c792"), "ابهر", 13 },
                    { 420, new Guid("b589a35b-6c68-4ffc-bf17-10481b89bd5e"), "شبانکاره", 12 },
                    { 399, new Guid("7a6a9ede-48ae-44e9-8265-4ad7cca0f41a"), "برازجان", 12 },
                    { 398, new Guid("17565310-4fd9-4a24-b2ea-309f680d70f9"), "بادوله", 12 },
                    { 397, new Guid("922a1ebd-8a92-43b1-8852-09f42497a0ba"), "اهرم", 12 },
                    { 396, new Guid("94831775-f0ed-44ec-ae56-246e0a6e0242"), "انارستان", 12 },
                    { 395, new Guid("5bbc55fe-8de0-419a-833b-e6e50cbcb3fd"), "امام حسن", 12 },
                    { 421, new Guid("36525873-77a4-4fae-9c97-a0adb6e165a0"), "شنبه", 12 },
                    { 393, new Guid("ce732e6c-3fc0-48f6-aafe-dd8b3432ac4f"), "آبدان", 12 },
                    { 392, new Guid("f431aaff-de25-4ddf-9232-3cb4597aaf95"), "آباد", 12 },
                    { 391, new Guid("efcb0b95-972e-4bf5-bf41-2198d3b48289"), "گوريه", 11 },
                    { 390, new Guid("5b821e11-46cb-4b83-a967-7a16362a11bd"), "گلگير", 11 },
                    { 389, new Guid("f57df1c8-8205-46a4-847d-bd693b3520ff"), "گتوند", 11 },
                    { 388, new Guid("ea66f604-0b19-45c3-9709-9f0f27e842b7"), "کوت عبدالله", 11 },
                    { 387, new Guid("5188d1c2-dbf0-4780-981d-c5b23eee036f"), "کوت سيدنعيم", 11 },
                    { 386, new Guid("95ff24c2-b692-48cf-af5d-430d9a87b9b2"), "چوئبده", 11 },
                    { 385, new Guid("58ed0279-ec24-4d10-a607-e92b1fcbd928"), "چمران", 11 },
                    { 400, new Guid("16b15872-977a-4a98-a326-7423f125802e"), "بردخون", 12 },
                    { 401, new Guid("95b5fd34-c09d-4b87-ba7c-0f9233724aeb"), "بردستان", 12 },
                    { 394, new Guid("d74f20ea-1995-4e06-947f-da09ec74447d"), "آبپخش", 12 },
                    { 403, new Guid("1d18f95b-bb39-452e-a482-9791f26f3bc4"), "بندر ديلم", 12 },
                    { 402, new Guid("07908629-4e60-4a2d-bba9-1d04c72d124c"), "بندر دير", 12 },
                    { 418, new Guid("e79ce6b3-d87b-447b-ae5e-e616417478f9"), "سعد آباد", 12 },
                    { 417, new Guid("8dc6449c-3ba7-4ffd-a281-b546d8e9053b"), "ريز", 12 },
                    { 416, new Guid("d0a3db39-8e8c-4636-a301-b8f4bf963fe7"), "دوراهک", 12 },
                    { 415, new Guid("82ce7c62-5b38-4a00-ad60-3b1594666571"), "دلوار", 12 },
                    { 414, new Guid("f9fef770-ffcb-4005-b3bd-b06f6fa864e6"), "دالکي", 12 },
                    { 413, new Guid("3f0524f0-fa95-40a8-95c8-dfd66c010737"), "خورموج", 12 },
                    { 412, new Guid("4a67054d-8dee-4a79-828c-c3057ea15c15"), "خارک", 12 },
                    { 419, new Guid("c2f866d2-f093-4d0c-b6de-1c30ab5d0959"), "سيراف", 12 },
                    { 410, new Guid("4e810a5b-ac12-440c-89ec-debe1b0894ce"), "تنگ ارم", 12 },
                    { 409, new Guid("13892250-07ae-4baa-89a3-d00753219242"), "بوشکان", 12 },
                    { 408, new Guid("cd718fe0-77f0-4227-b8c2-f2bd28e8f8df"), "بوشهر", 12 },
                    { 407, new Guid("9b6ccd09-1404-42ab-bbf6-49e0ce421f6f"), "بنک", 12 },
                    { 406, new Guid("0ccf82e0-bd3c-4223-8b2e-e01dcdbb95b0"), "بندر گناوه", 12 },
                    { 405, new Guid("d6c8afe6-796e-408f-80c0-b6e540208767"), "بندر کنگان", 12 },
                    { 404, new Guid("f303a0d1-1a8f-4293-a47a-ed99d5b9d5be"), "بندر ريگ", 12 },
                    { 411, new Guid("80c5eb07-fb77-49ff-b7d0-8aec218e61a4"), "جم", 12 }
                });

            migrationBuilder.InsertData(
                table: "Code",
                columns: new[] { "CodeID", "CodeGroupID", "CodeGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, 1, new Guid("fc20e91f-1eb1-4912-87be-1708f2706367"), "png", "image/png" },
                    { 2, 1, new Guid("3f009296-db7a-4fde-a659-4ca1541a2504"), "jpg", "image/jpg" },
                    { 3, 1, new Guid("3209341a-07d4-437b-9301-2d0f909ad713"), "jpeg", "image/jpeg" },
                    { 4, 2, new Guid("09cb21ac-d99e-42ba-904d-337bdd561e6e"), "به صورت شخصی فعالیت میکنم", "به صورت شخصی فعالیت میکنم" },
                    { 5, 2, new Guid("2383b70e-f41f-4b67-b0c9-c48706a70a46"), "نماینده یک شرکت هستم", "نماینده یک شرکت هستم" },
                    { 6, 2, new Guid("cf5a1929-db68-43d6-8fc7-e3b7ccc51678"), "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم", "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم" },
                    { 7, 3, new Guid("2b451e4c-c9b8-415a-bcb4-05da15447b89"), "زن", "Female" },
                    { 11, 4, new Guid("2b9d07c8-5535-495e-8557-da32acb58600"), "انجام شده", "Done" },
                    { 9, 4, new Guid("b5d74bda-849b-427c-a6e0-463c1e5f615b"), "در انتظار تایید", "Waiting" },
                    { 10, 4, new Guid("10afdac9-a075-40e1-9207-1813befcf4d6"), "در حال انجام", "Doing" },
                    { 12, 4, new Guid("61960336-e912-4658-9ab3-59f4c58e0b23"), "لغو شده", "Canceled" },
                    { 13, 4, new Guid("46a09d81-c57f-4655-a8f5-027c66a6cfb1"), "ادمین", "Admin" },
                    { 14, 4, new Guid("91b3cdab-39c1-40fb-b077-a2d6e611f50a"), "سرویس گیرنده", "Client" },
                    { 15, 4, new Guid("959b10a3-b8ed-4a9d-bdf3-17ec9b2ceb15"), "سرویس دهنده", "Contractor" },
                    { 8, 3, new Guid("6e48b657-2c83-4481-a9c5-009ffe10158b"), "مرد", "Male" }
                });

            migrationBuilder.InsertData(
                table: "SMSSetting",
                columns: new[] { "SMSSettingID", "ModifiedDate", "Name", "SMSProviderConfigurationID", "SMSSettingGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 14, 47, 44, 743, DateTimeKind.Local).AddTicks(4273), "Kavenegar", 1, new Guid("0507b4d8-8289-4132-836b-079ca9829740") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 5, null, null, new Guid("810801f6-3f31-4c1c-8838-17793b003a55"), null, null, "تاسیسات", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3790), 3, null, 1 },
                    { 31, null, null, new Guid("2a3bf86e-5799-48e8-a619-b03eccbe4a09"), null, null, "سرویس و تعمیر خودرو", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4399), 4, null, 3 },
                    { 30, null, null, new Guid("4eb6f3cc-8b38-4237-8bee-23a9488e694c"), null, null, "اجاره خودرو", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4385), 4, null, 2 },
                    { 29, null, null, new Guid("aa19589d-cd89-4b7c-8f5c-2e29d2fa84ba"), null, null, "اتوبار", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4368), 4, null, 1 },
                    { 21, null, null, new Guid("d95695d5-b6bf-46f7-a3fa-c82f432504d9"), null, null, "کار در ارتفاع", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4196), 3, null, 17 },
                    { 20, null, null, new Guid("82725f5c-dab0-4ba8-bbf9-d72b08b7e673"), null, null, "آسانسور و بالابر", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4182), 3, null, 16 },
                    { 19, null, null, new Guid("5dbf3937-e10c-4640-b4d9-731c0ae6f866"), null, null, "نجاری", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4163), 3, null, 15 },
                    { 18, null, null, new Guid("8548e260-75a0-43ef-a945-5962e63437e8"), null, null, "تعمیرات لوازم خانگی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4149), 3, null, 14 },
                    { 16, null, null, new Guid("7e0f98e6-e81b-484e-afec-0d42145c88b5"), null, null, "عایق کاری", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4122), 3, null, 12 },
                    { 15, null, null, new Guid("62fd9a40-65af-4e7c-9597-66e466c1243c"), null, null, "عایق کاری", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4108), 3, null, 11 },
                    { 17, null, null, new Guid("ffb6fc1e-8a3d-4db4-9c95-8b84514019c9"), null, null, "نرده و حفاظ استیل", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4135), 3, null, 13 },
                    { 13, null, null, new Guid("a5ea798f-c8a7-466c-9e99-016239d93361"), null, null, "بنایی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3905), 3, null, 9 },
                    { 12, null, null, new Guid("cb99dc9b-9f6e-4b66-99e7-04d90f815691"), null, null, "دکوراسیون داخلی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3892), 3, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[] { 11, null, null, new Guid("bbfba9d0-eacd-4f51-ab94-24e3d76dfc52"), null, null, "کابینت سازی", null, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3873), 3, null, 7 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 10, null, null, new Guid("750da52c-964f-4b8d-bc97-afc449efc1fc"), null, null, "شیشه بری و قابسازی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3859), 3, null, 6 },
                    { 9, null, null, new Guid("69776de1-b8cd-482b-9461-ac511483f7f6"), null, null, "آلومینیوم سازی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3845), 3, null, 5 },
                    { 8, null, null, new Guid("9e73d2fe-ca42-48a9-be93-4f16536ac94c"), null, null, "مبلمان", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3832), 3, null, 4 },
                    { 7, null, null, new Guid("37bdbfd4-4377-4a5e-b17d-30c0d5b876e6"), null, null, "ایمنی و امنیت", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3817), 3, null, 3 },
                    { 6, null, null, new Guid("3311104b-c3bc-4a35-b898-19a7443a3fc3"), null, null, "الکتریکی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(3804), 3, null, 2 },
                    { 14, null, null, new Guid("bf04fb2a-e9e8-4675-8a0c-b96acf08f82a"), null, null, "آهنگری", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4091), 3, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 14, 47, 44, 744, DateTimeKind.Local).AddTicks(2535), "VerifyAccount", 1, new Guid("0d83899b-712f-47d8-9d64-b56b67a8a67f") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "GenderCodeID", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "ProfileDocumentID", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 4, "white.luciferrr@gmail.com", "محمد", 8, true, true, "میرزایی", new DateTime(2020, 5, 29, 14, 47, 44, 746, DateTimeKind.Local).AddTicks(8894), "09147830093", null, new DateTime(2020, 5, 29, 14, 47, 44, 746, DateTimeKind.Local).AddTicks(8890), 2, new Guid("c6758378-3e38-4b5c-a779-dc2990c480fd") },
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", 8, true, true, "رودکی", new DateTime(2020, 5, 29, 14, 47, 44, 746, DateTimeKind.Local).AddTicks(6583), "09227204305", null, new DateTime(2020, 5, 29, 14, 47, 44, 746, DateTimeKind.Local).AddTicks(5860), 1, new Guid("6d91c055-39b8-4d3c-be1e-bb925826c488") },
                    { 2, "roozbehshamekhi@hotmail.com", "روزبه", 8, true, true, "شامخی", new DateTime(2020, 5, 29, 14, 47, 44, 746, DateTimeKind.Local).AddTicks(8812), "09128277075", null, new DateTime(2020, 5, 29, 14, 47, 44, 746, DateTimeKind.Local).AddTicks(8789), 3, new Guid("59f4538d-74cb-4661-af77-a10c33e92508") },
                    { 3, "dead.hh98@gmail.com", "حامد", 8, true, true, "حقیقیان", new DateTime(2020, 5, 29, 14, 47, 44, 746, DateTimeKind.Local).AddTicks(8878), "09108347428", null, new DateTime(2020, 5, 29, 14, 47, 44, 746, DateTimeKind.Local).AddTicks(8874), 2, new Guid("b37c6b53-c962-4142-b099-a230bf3d22c6") }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "AdminGUID", "IsDelete", "ModifiedDate", "UserID" },
                values: new object[] { 1, new Guid("124a4f41-d79d-4646-954a-811247304dde"), false, new DateTime(2020, 5, 29, 14, 47, 44, 747, DateTimeKind.Local).AddTicks(1494), 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 22, null, null, new Guid("fae81370-01d7-4f15-80e7-34e3605dcf85"), null, null, "سرویس کولر آبی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4210), 5, null, 1 },
                    { 23, null, null, new Guid("ab6b7d70-59b2-4f6f-abc1-68344d299cb8"), null, null, "نقاشی ساختمان", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4224), 5, null, 2 },
                    { 24, null, null, new Guid("9e22aff1-452c-4477-9ebd-3a3891726e4b"), null, null, "رنگ کاری مبل", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4238), 8, null, 1 },
                    { 25, null, null, new Guid("b3590486-7257-49bf-a11b-6b4c1961cd95"), null, null, "تعمیر صندلی اداری", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4252), 8, null, 2 },
                    { 26, null, null, new Guid("ad39b2f5-fe17-4aec-a841-cd21ef73ee32"), null, null, "ساخت مبلمان", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4265), 8, null, 3 },
                    { 27, null, null, new Guid("bcd9c315-fa43-4458-bfa0-f33caec15e54"), null, null, "دوخت کاور مبل", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4278), 8, null, 4 },
                    { 28, null, null, new Guid("f48bc09a-d5f4-49c6-8d5e-bc5addc57f7d"), null, null, "تعمیر مبل", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4353), 8, null, 5 },
                    { 32, null, null, new Guid("71e02a3e-eb06-4059-be34-6703cf999b16"), null, null, "وانت بار", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4413), 29, null, 1 },
                    { 33, null, null, new Guid("e11d1650-aef5-4095-a9af-becd1b51fae2"), null, null, "باربری و اتوبار", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4426), 29, null, 2 },
                    { 34, null, null, new Guid("d4dd8b99-1d4a-43bf-afb5-75fcf6f17065"), null, null, "کارگر اسباب کشی", null, true, new DateTime(2020, 5, 29, 14, 47, 44, 752, DateTimeKind.Local).AddTicks(4440), 29, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "CityID", "ClientGUID", "ModifiedDate", "UserID" },
                values: new object[] { 1, 750, new Guid("cb15bb05-3c5e-4ad7-b417-2f4b0d7d4e89"), new DateTime(2020, 5, 29, 14, 47, 44, 747, DateTimeKind.Local).AddTicks(8433), 2 });

            migrationBuilder.InsertData(
                table: "Contractor",
                columns: new[] { "ContractorID", "AverageRate", "BusinessTypeCodeID", "CityID", "ContractorGUID", "Credit", "Latitude", "Longitude", "ModifiedDate", "UserID" },
                values: new object[,]
                {
                    { 1, 0.0, 4, 750, new Guid("ea87a183-f09c-42b2-af2c-d8134eaa0f21"), 0, "1", "2", new DateTime(2020, 5, 29, 14, 47, 44, 749, DateTimeKind.Local).AddTicks(397), 3 },
                    { 2, 0.0, 4, 750, new Guid("141c49b1-0b5e-4853-aa69-df0bc235ec8b"), 10000, "1", "2", new DateTime(2020, 5, 29, 14, 47, 44, 749, DateTimeKind.Local).AddTicks(1140), 4 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderID", "CategoryID", "ClientID", "Comment", "ContractorID", "Cost", "DeadlineDate", "Description", "ModifiedDate", "OrderGUID", "Rate", "StateCodeID", "Title" },
                values: new object[] { 1, 14, 1, "", null, null, null, "توضیح", new DateTime(2020, 5, 29, 14, 47, 44, 749, DateTimeKind.Local).AddTicks(8313), new Guid("4bf658ba-fb2a-41f0-869d-013eb958bce9"), 0.0, 9, "تیتر" });

            migrationBuilder.InsertData(
                table: "OrderRequest",
                columns: new[] { "OrderRequestID", "ContractorID", "IsAllow", "Message", "ModifiedDate", "OfferedPrice", "OrderID", "OrderRequestGUID" },
                values: new object[] { 1, 1, true, "پیام", new DateTime(2020, 5, 29, 14, 47, 44, 750, DateTimeKind.Local).AddTicks(5374), 250000L, 1, new Guid("8dd6c45a-d6a8-4380-8a18-9c948af3c6d1") });

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
                name: "IX_ContactUs_CategoryID",
                table: "ContactUs",
                column: "CategoryID");

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
