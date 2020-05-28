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
                columns: new[] { "CategoryID", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 1, null, new Guid("c265fd02-0194-4d38-83e8-a93bc3698fcc"), null, null, "سایت اصلی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(7443), null, null, 1 },
                    { 2, null, new Guid("dec37f17-0ab2-4208-8ba7-11cc1120369b"), null, null, "وبلاگ", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9028), null, null, 2 }
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
                    { 5, new Guid("676e5967-28eb-4d2e-9393-38afa5afd703"), "نقش", "Role" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("6ef3a0a8-88b7-4a13-b1c3-eedc8057b1e1") },
                    { 20, "ايلام", new Guid("d7d94f99-30e3-4b7e-af91-3030274a86ea") },
                    { 21, "تهران", new Guid("ff00c94e-1a27-48a9-bc72-b27862034bb4") },
                    { 22, "آذربايجان شرقي", new Guid("fe4ad803-9550-4bf1-a294-83a9a556db0a") },
                    { 23, "فارس", new Guid("c9e705a5-1576-48dd-9308-0f678ea28ed6") },
                    { 24, "کرمانشاه", new Guid("d30dcd8e-fd97-480e-b7d2-10ba5ae720de") },
                    { 28, "همدان", new Guid("7fbcf1a9-3fb5-4f33-86cc-a6220c8a422d") },
                    { 26, "مرکزي", new Guid("65147009-e91a-4332-83ca-de04fa9e0d98") },
                    { 27, "گيلان", new Guid("001207bd-e1e6-46dc-be92-515d7ca5e932") },
                    { 18, "اردبيل", new Guid("59ee64d5-7854-4aec-b6c1-0775e9c5d7b3") },
                    { 29, "کرمان", new Guid("5b876337-6e47-4f3e-9cd6-58b0c24d00d3") },
                    { 30, "سمنان", new Guid("e107610b-e5e5-4f95-9585-f7734987e254") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("ad7d4274-7721-4996-827a-1bb4893e15bb") },
                    { 25, "هرمزگان", new Guid("79d2a35d-9f82-4335-9ffd-06dede95d3fc") },
                    { 17, "لرستان", new Guid("b7f4aaf0-ad03-4a2a-8537-51f5a1a54465") },
                    { 14, "گلستان", new Guid("25964361-47f5-41ce-adda-b60ed3266fb1") },
                    { 15, "مازندران", new Guid("bb3d74ce-7691-4ee2-b453-bab86962b174") },
                    { 1, "يزد", new Guid("af273cb5-132e-45ca-858a-5818a0ffa33a") },
                    { 2, "چهار محال و بختياري", new Guid("50335ca0-837c-4be5-a251-4bcbf619d717") },
                    { 3, "خراسان شمالي", new Guid("306b198f-2c54-4dba-a736-7bb85ff8834c") },
                    { 4, "البرز", new Guid("7116e039-ea7e-426e-b8e9-46ec2a39ad41") },
                    { 5, "قم", new Guid("fcdd57b2-883a-402e-b38b-54c0dfb316e8") },
                    { 16, "قزوين", new Guid("7d467b61-cc85-4567-a7db-4d37096f8870") },
                    { 7, "آذربايجان غربي", new Guid("1333538b-d2aa-4b27-81a3-c7327407934b") },
                    { 6, "کردستان", new Guid("1b5ff893-db15-4d47-b44e-5f87654dc64c") },
                    { 9, "سيستان و بلوچستان", new Guid("60cf2a6b-f55a-44af-891b-bd6693750e6e") },
                    { 10, "خراسان جنوبي", new Guid("20d95067-428e-4076-bc95-66553d5a084e") },
                    { 11, "خوزستان", new Guid("a11bb8bb-4bd6-4af5-975c-f470cfddd37b") },
                    { 12, "بوشهر", new Guid("7baedd5c-6b03-40b5-88a3-fd840b29aab6") },
                    { 13, "زنجان", new Guid("aeae4af2-9825-43c0-b685-9105ecff0bab") },
                    { 8, "خراسان رضوي", new Guid("92ddb22c-60a2-498c-941a-1be25412e207") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 3, "سرویس گیرنده", new DateTime(2020, 5, 29, 1, 34, 59, 194, DateTimeKind.Local).AddTicks(2813), "Client", new Guid("2a49658e-704d-4389-b370-89caa485daca") },
                    { 1, "ادمین", new DateTime(2020, 5, 29, 1, 34, 59, 194, DateTimeKind.Local).AddTicks(1563), "Admin", new Guid("b0348b2e-6e8f-4d63-9f19-7635421eb3fe") },
                    { 2, "سرویس دهنده", new DateTime(2020, 5, 29, 1, 34, 59, 194, DateTimeKind.Local).AddTicks(2776), "Contractor", new Guid("5f8c2ea8-4597-4e31-b6ca-13c81565442c") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 5, 29, 1, 34, 59, 188, DateTimeKind.Local).AddTicks(4620), "ptcoptco", new Guid("f1957737-a162-4f49-a655-945360a58926"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 3, null, new Guid("89a3707e-05ea-4553-b71a-a46c7bcc4692"), null, null, "خانه", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9166), 1, null, 1 },
                    { 4, null, new Guid("b394a939-6de0-46c9-bcf8-743fa984fc5a"), null, null, "حمل و نقل", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9178), 1, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 826, new Guid("3f89d5d8-c237-41c6-bde0-9acba9352732"), "ليلان", 22 },
                    { 825, new Guid("a3fba371-43db-4cae-af6a-ab8adbcbc2b1"), "قره آغاج", 22 },
                    { 824, new Guid("8392a490-bf62-425c-87e6-3d83f6319f6b"), "عجب شير", 22 },
                    { 823, new Guid("76e8e64e-6b05-4e89-a3d4-3de4ec923cfd"), "صوفيان", 22 },
                    { 822, new Guid("1e599817-929e-46e8-9c0d-b4a0e924256e"), "شهر جديد سهند", 22 },
                    { 821, new Guid("382fd130-6265-42d2-8b6c-7e0967eaaa47"), "شند آباد", 22 },
                    { 820, new Guid("94566332-198c-414e-9ad1-3f502d30cb28"), "شرفخانه", 22 },
                    { 819, new Guid("e8586295-e24f-44d8-8969-8a40f72b2876"), "شربيان", 22 },
                    { 818, new Guid("d8e4fee1-0a91-42d6-a29e-33fc0067a4ae"), "شبستر", 22 },
                    { 817, new Guid("10245027-dd9f-4b47-9282-87f675114784"), "سيه رود", 22 },
                    { 816, new Guid("eaa29185-f701-4d7e-a9f0-b532c2809a5d"), "سيس", 22 },
                    { 815, new Guid("337a502b-f4d6-446c-b2e2-e68bd92fdc48"), "سردرود", 22 },
                    { 814, new Guid("3c9423cc-8b06-4b01-847f-b0776702e949"), "سراب", 22 },
                    { 813, new Guid("2202a8bd-6ee3-4c03-98f3-45621d5e3b70"), "زنوز", 22 },
                    { 812, new Guid("f91f0575-8a66-454b-94b1-147abb7adf16"), "زرنق", 22 },
                    { 827, new Guid("921cab06-7fdd-4972-a023-5694192b5f76"), "مبارک شهر", 22 },
                    { 828, new Guid("6bd7e6a4-30ba-4c9a-a624-d64f02eecbb9"), "مراغه", 22 },
                    { 829, new Guid("4a240005-4224-47bc-b63f-a954f732f291"), "مرند", 22 },
                    { 830, new Guid("1733096d-8802-4bdc-b961-f16303115ea0"), "ملکان", 22 },
                    { 846, new Guid("7b4ed9a1-e53f-47cc-b816-fa3143920c43"), "گوگان", 22 },
                    { 845, new Guid("df23e1f4-4bee-4ea1-b5df-186dbc4af8be"), "کوزه کنان", 22 },
                    { 844, new Guid("274f542f-560f-406a-96ef-3856bab7e6d2"), "کليبر", 22 },
                    { 843, new Guid("25da7e48-c662-47aa-9d43-a3e0cb0e0228"), "کلوانق", 22 },
                    { 842, new Guid("3c3a6b68-45d1-4af3-a753-2d6b5c5b7f9e"), "کشکسراي", 22 },
                    { 841, new Guid("8d7aa73e-0eee-429e-8339-c1a01e962833"), "يامچي", 22 },
                    { 840, new Guid("f36a6e9c-01d5-4451-9ad2-0fd74cc545bb"), "ورزقان", 22 },
                    { 811, new Guid("9e6745d7-8833-465f-b907-7316acfb8ed0"), "دوزدوزان", 22 },
                    { 839, new Guid("f6f39a8e-ae23-4894-a6de-94432a94e693"), "وايقان", 22 },
                    { 837, new Guid("353faec7-8fa8-4569-b5c4-ef7d083a5d65"), "هشترود", 22 },
                    { 836, new Guid("7f9bf3bc-5fbd-49cc-973c-3195819759f2"), "هريس", 22 },
                    { 835, new Guid("d7f19c26-3811-4b59-a8f0-b01a88c95f13"), "هاديشهر", 22 },
                    { 834, new Guid("eb6f99f1-b899-45e4-818d-716eea518ae3"), "نظرکهريزي", 22 },
                    { 833, new Guid("de95f03a-a37e-4ca8-b31f-56cec41aca83"), "ميانه", 22 },
                    { 832, new Guid("664d12dc-e292-48dd-abb1-a78ebc0b76eb"), "مهربان", 22 },
                    { 831, new Guid("23743ec3-9c8c-41cc-8f31-09850ec553d3"), "ممقان", 22 },
                    { 838, new Guid("1c376a75-3181-46bf-ae19-d182399d2c97"), "هوراند", 22 },
                    { 810, new Guid("ec5e985c-196c-49f2-a46a-92a70ef5b036"), "خواجه", 22 },
                    { 809, new Guid("075250f8-ae98-48b1-8648-0e855edcb536"), "خمارلو", 22 },
                    { 808, new Guid("43a415e3-5d49-4a8a-ae90-597775a0941c"), "خسروشاه", 22 },
                    { 787, new Guid("beadecf5-5196-456b-9ec1-bdf5d5f3d4ef"), "آقکند", 22 },
                    { 786, new Guid("d3741e6d-affe-4838-968a-2a5f908156cb"), "آذرشهر", 22 },
                    { 785, new Guid("19b1349d-2480-45fd-be32-9b39f468a5ce"), "آبش احمد", 22 },
                    { 784, new Guid("39f956ca-e9c3-4dd7-83c0-da27f6ba949a"), "گلستان", 21 },
                    { 783, new Guid("74e27c6c-bb0e-4b9d-97d8-c8ab52d3e3db"), "کيلان", 21 },
                    { 782, new Guid("3442d722-b43d-470e-9b36-ae3bda487be7"), "کهريزک", 21 },
                    { 781, new Guid("73be9098-ee83-4fb5-abce-0492f7254553"), "چهاردانگه", 21 },
                    { 780, new Guid("48635dbf-9581-437b-acb9-5b72ed08dfee"), "پيشوا", 21 },
                    { 779, new Guid("5d1235f6-dfb8-41a9-974c-bc8d4d90a9b7"), "پرديس", 21 },
                    { 778, new Guid("2f155ad0-a5fd-461c-b94a-5bb1de54d5f3"), "پاکدشت", 21 },
                    { 777, new Guid("2e5a91cb-9ce6-41ae-9e0d-99e6bd14e26b"), "ورامين", 21 },
                    { 776, new Guid("104be951-4db9-4219-8aba-121a938bcb00"), "وحيديه", 21 },
                    { 775, new Guid("146bd79b-234f-4501-9bf5-2786ad7d05f9"), "نصيرشهر", 21 },
                    { 774, new Guid("4136e5ed-21c9-42e9-8580-d9101b075391"), "نسيم شهر", 21 },
                    { 773, new Guid("2edffaaf-e28a-49ed-858f-5ae10c98c586"), "ملارد", 21 },
                    { 788, new Guid("b7de7c1f-a876-47d6-830a-70f5a88ee09d"), "آچاچي", 22 },
                    { 789, new Guid("40936ce4-be02-431b-8dc2-c9f00d4c53ad"), "اسکو", 22 },
                    { 790, new Guid("7d42e97e-17a6-4dbd-ba52-b30b2b8eb578"), "اهر", 22 },
                    { 791, new Guid("b6015967-b3e2-41a9-a951-8a8a69e95c11"), "ايلخچي", 22 },
                    { 807, new Guid("6da5eba2-b67f-4eab-b445-76e156a384c3"), "خداجو", 22 },
                    { 806, new Guid("ba03ff5f-9149-46f6-a0a6-fc1943cda3aa"), "خامنه", 22 },
                    { 805, new Guid("bbc9ef4e-7d5d-41c4-93a8-28056b2844e4"), "خاروانا", 22 },
                    { 804, new Guid("6ca267bc-07a2-4587-a1fe-826666aebf55"), "جوان قلعه", 22 },
                    { 803, new Guid("d1cc002b-9dac-4b81-a9cc-1e13332bab85"), "جلفا", 22 },
                    { 802, new Guid("b864fb79-1ddb-4d8e-9f89-7c7e28a40214"), "تيکمه داش", 22 },
                    { 801, new Guid("a70b6583-602d-4aa3-85c1-7370f33728f0"), "تيمورلو", 22 },
                    { 847, new Guid("31437573-f11f-4f8c-81ca-25e3aadbcaa0"), "آباده", 23 },
                    { 800, new Guid("747fea73-a924-4022-89b7-1c6f4bb9074c"), "تسوج", 22 },
                    { 798, new Guid("9d63b374-4fb9-484e-95aa-70c4aac3e329"), "ترک", 22 },
                    { 797, new Guid("93202afe-4093-4993-9a6f-0e18b40d3522"), "تبريز", 22 },
                    { 796, new Guid("43373b02-d97e-46a7-9eb3-178f959c7a38"), "بناب مرند", 22 },
                    { 795, new Guid("7d473e13-b28d-41c5-b97a-bc3972d14378"), "بناب", 22 },
                    { 794, new Guid("2e8f6759-7f3a-42ba-8c8c-c2f755e30b6a"), "بستان آباد", 22 },
                    { 793, new Guid("7d44277a-c9f1-4a7b-bfa2-8fb71afdf157"), "بخشايش", 22 },
                    { 792, new Guid("cef18d59-cd7a-4b14-a6ee-7d669cddd442"), "باسمنج", 22 },
                    { 799, new Guid("23e606c0-4c63-4f74-b217-431e33fef88a"), "ترکمانچاي", 22 },
                    { 848, new Guid("5617d768-c224-4fad-ae22-1629644f91a0"), "آباده طشک", 23 },
                    { 849, new Guid("730c74a1-819b-422a-a3f6-a953ab2a86c1"), "اردکان", 23 },
                    { 850, new Guid("d88e4306-714b-4e91-95b0-747155ea94a2"), "ارسنجان", 23 },
                    { 905, new Guid("8d252174-a6d8-4a40-befd-b17cc0d9f825"), "صغاد", 23 },
                    { 904, new Guid("adb90149-79c3-463b-98d0-50d97442198a"), "شيراز", 23 },
                    { 903, new Guid("6806aa45-cd0e-48b3-b77f-0b1a94257e24"), "شهر پير", 23 },
                    { 902, new Guid("dc166801-021c-429d-9493-2f8e66f7dbe3"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("7f664415-b007-45ae-9ee9-d281ff4f5cc0"), "ششده", 23 },
                    { 900, new Guid("b9d4d3c4-27c2-4d68-970d-999a68858b25"), "سيدان", 23 },
                    { 899, new Guid("8e2943db-6815-4cba-a0ba-4c633428e76c"), "سورمق", 23 },
                    { 898, new Guid("3f46274a-17bf-4bd7-b744-fee94afac164"), "سلطان شهر", 23 },
                    { 897, new Guid("8989021c-fef7-4e53-bc91-01e218b28f8c"), "سعادت شهر", 23 },
                    { 896, new Guid("65919038-bf6d-405f-aa60-7ced97287109"), "سروستان", 23 },
                    { 895, new Guid("aed0547f-be72-4c3c-860f-79aaf299a4dc"), "سده", 23 },
                    { 894, new Guid("11ce429c-7a9e-44c7-92f6-ce742f80807b"), "زرقان", 23 },
                    { 893, new Guid("9349b219-a4f5-4b0c-8e97-1b8c2a80a7a7"), "زاهد شهر", 23 },
                    { 892, new Guid("def76bdb-7839-45ad-bd54-c6d41166968d"), "رونيز", 23 },
                    { 891, new Guid("0076cb7d-81c6-43fa-a068-1d7d955c88fe"), "رامجرد", 23 },
                    { 906, new Guid("0bff255f-6784-4248-82dc-317925b9bbf3"), "صفا شهر", 23 },
                    { 907, new Guid("3f62b264-23f3-4a55-909c-a82642dffc5b"), "علامرودشت", 23 },
                    { 908, new Guid("c642cc67-eb9e-4d38-bf13-e86ad98fd87b"), "عماد ده", 23 },
                    { 909, new Guid("377374f2-1db8-4f1c-b97b-1a4adf795a6f"), "فدامي", 23 },
                    { 925, new Guid("aa168cf0-3268-4b99-9324-00fa6c6f4ffb"), "مرودشت", 23 },
                    { 924, new Guid("3223fcef-c41e-40c7-83c3-77f2aba00932"), "مبارک آباد", 23 },
                    { 923, new Guid("d5eeecef-f784-4d5f-8c64-5cf218680059"), "مادرسليمان", 23 },
                    { 922, new Guid("9b6ab909-c310-46bf-960b-3cddf18eee82"), "لپوئي", 23 },
                    { 921, new Guid("223758c2-ce4e-4a61-85ce-39b1d669691d"), "لطيفي", 23 },
                    { 920, new Guid("2273a849-01b2-4277-962c-7aab173a48b6"), "لامرد", 23 },
                    { 919, new Guid("79d2ea3c-0ac7-4fe9-99f3-77d56795257a"), "لار", 23 },
                    { 890, new Guid("39595a5c-2ead-4d5e-93b7-bcad344efee7"), "دژکرد", 23 },
                    { 918, new Guid("4d5be211-e19d-46ba-8e4b-028b6da5af07"), "قير", 23 },
                    { 916, new Guid("da3eab7e-9e3d-4b44-804f-f4bcf1fb40ce"), "قطب آباد", 23 },
                    { 915, new Guid("45784e65-f8ca-490d-96c7-3de17ba20f78"), "قره بلاغ", 23 },
                    { 914, new Guid("df739b99-43ed-44e9-89d4-d391ff023a42"), "قادرآباد", 23 },
                    { 913, new Guid("d33f2d48-ee65-4f1f-af73-328f1e4cc36a"), "قائميه", 23 },
                    { 912, new Guid("c24f7d08-5fee-416e-b782-a20efde7ec66"), "فيروزآباد", 23 },
                    { 911, new Guid("e078e7f4-c257-414f-a233-65bf490ee344"), "فسا", 23 },
                    { 910, new Guid("f73923ec-9ab9-4307-a89d-8ebdf468ff02"), "فراشبند", 23 },
                    { 917, new Guid("e795f65b-0bef-450d-ac45-f05f12a14970"), "قطرويه", 23 },
                    { 889, new Guid("d660e2df-7cf2-4ee6-a572-845be2602460"), "دوزه", 23 },
                    { 888, new Guid("5682de6e-a188-4773-804f-71c1f354ac41"), "دوبرجي", 23 },
                    { 887, new Guid("c608a97e-bc17-42a5-b07b-0cfc07d90cb7"), "دهرم", 23 },
                    { 866, new Guid("a188f550-7c7f-458c-b407-843233adb940"), "بوانات", 23 },
                    { 865, new Guid("7f41435c-b13b-479d-b7f4-9a68695f6573"), "بهمن", 23 },
                    { 864, new Guid("010bbe4f-1c02-4068-9779-2437aa9a8ffc"), "بنارويه", 23 },
                    { 863, new Guid("040e6318-46bb-495a-b74e-6d97e4070b92"), "بالاده", 23 },
                    { 862, new Guid("c1be7452-4476-4027-b4d9-4f3e69495877"), "بابامنير", 23 },
                    { 861, new Guid("74ecf255-74f0-4c99-b94c-33526f6bd618"), "باب انار", 23 },
                    { 860, new Guid("b39ba15f-aa81-4319-a76f-a854d590e14a"), "ايزد خواست", 23 },
                    { 867, new Guid("765ba087-086c-4d5b-8b48-b74c49ccaff8"), "بيرم", 23 },
                    { 859, new Guid("fdebe94a-dfd6-4f9e-ab2f-32ace0ec516a"), "ايج", 23 },
                    { 857, new Guid("8f460379-dd01-4f41-9052-b9507fb2bf7f"), "اهل", 23 },
                    { 856, new Guid("de29641f-ef9e-49ae-ac0d-704732c64d66"), "امام شهر", 23 },
                    { 855, new Guid("cda2e80f-6529-4e1d-8ff5-1b10ff53e5c9"), "اقليد", 23 },
                    { 854, new Guid("1820e5fa-466c-49b6-b40f-a2e111a2030d"), "افزر", 23 },
                    { 853, new Guid("8ef3128b-4971-4cd8-8a2f-7bd071a61a4f"), "اشکنان", 23 },
                    { 852, new Guid("47098837-3529-4fa2-9474-d1290c69c23f"), "اسير", 23 },
                    { 851, new Guid("73542b1a-92f7-417b-bd54-b178949bebd4"), "استهبان", 23 },
                    { 858, new Guid("ecec2595-af2b-4711-aae1-eb6e94c292a6"), "اوز", 23 },
                    { 772, new Guid("79b84fb7-1e2f-47ba-8b63-18ece8849f47"), "لواسان", 21 },
                    { 868, new Guid("bbe6fde3-85b8-4e65-8ad7-721c634ef45d"), "بيضا", 23 },
                    { 870, new Guid("75c122ca-17b9-48a5-b3f8-d9fba4b9e926"), "جهرم", 23 },
                    { 886, new Guid("6bc0fd99-19f3-42a3-a777-a571a65c939d"), "دبيران", 23 },
                    { 885, new Guid("77131c49-ed66-4b50-9668-a241cdcd5642"), "داريان", 23 },
                    { 884, new Guid("fb04d49a-0460-4799-8d02-cf39b332a27a"), "داراب", 23 },
                    { 883, new Guid("ec1f639f-94c1-4dcf-ad46-76804eb1ebd1"), "خومه زار", 23 },
                    { 882, new Guid("5d761685-30eb-4d58-a40e-3beeb3bfdf6a"), "خوزي", 23 },
                    { 881, new Guid("0d7c8a56-d074-460d-8fd5-e50167e93325"), "خور", 23 },
                    { 880, new Guid("ea421057-23d3-49e8-bd06-7b282eea088e"), "خنج", 23 },
                    { 869, new Guid("dd5a5035-8a4b-47bf-aa40-ca61f7ce444c"), "جنت شهر", 23 },
                    { 879, new Guid("9376d6a1-5544-4585-8581-0fea013a735f"), "خشت", 23 },
                    { 877, new Guid("be16835d-ccb1-42bd-9ecb-c9ad5db8f3d3"), "خاوران", 23 },
                    { 876, new Guid("5ecd8f60-37d5-45fb-8ed5-2000960d896e"), "خانيمن", 23 },
                    { 875, new Guid("9ecc63b4-367f-4620-aff8-a198b150993c"), "خانه زنيان", 23 },
                    { 874, new Guid("10691f04-3b40-465b-a03e-7c9e34e0396b"), "حسن آباد", 23 },
                    { 873, new Guid("c55c5ff2-498a-49e6-a0bf-7cc7eebeb77e"), "حسامي", 23 },
                    { 872, new Guid("9b415e72-fdee-4b5c-8bd7-a9932c064975"), "حاجي آباد", 23 },
                    { 871, new Guid("f0c0792e-5f90-4f28-a483-6538d1f044f4"), "جويم", 23 },
                    { 878, new Guid("01aef1ee-7a05-4839-bc42-9f00ee5367c3"), "خرامه", 23 },
                    { 771, new Guid("957771da-4b95-4464-a2c6-7261bf1fdae9"), "قرچک", 21 },
                    { 770, new Guid("52b772f3-4e69-4412-8014-c538acbb0364"), "قدس", 21 },
                    { 769, new Guid("291e5240-fa36-4045-8af6-254477ec03d1"), "فيروزکوه", 21 },
                    { 669, new Guid("5aaaebc6-9014-4496-9903-0cc9471006e1"), "عسگران", 19 },
                    { 668, new Guid("da8c02ba-b3e9-490b-bce5-76b40237ad5a"), "طرق رود", 19 },
                    { 667, new Guid("add96e3c-b9c9-44d5-8ce5-3668329715ff"), "طالخونچه", 19 },
                    { 666, new Guid("d79f681e-8564-405a-85f3-294e93ea94c4"), "شهرضا", 19 },
                    { 665, new Guid("250b9421-dd61-46c8-8b0c-490ea4911753"), "شاپورآباد", 19 },
                    { 664, new Guid("0e2b546c-c464-44c4-be88-749b45883f45"), "شاهين شهر", 19 },
                    { 663, new Guid("39481ad3-7abe-447c-a2c8-4f2785f2c8cf"), "سگزي", 19 },
                    { 662, new Guid("9f3e0dfd-4df1-4bc5-bdd2-fcac1ef1a96a"), "سين", 19 },
                    { 661, new Guid("b7f6bc88-341b-4ea2-a4c5-1028b8b9a4eb"), "سميرم", 19 },
                    { 660, new Guid("aca5a033-bf40-467f-b10e-ab5aad0b87d6"), "سفيد شهر", 19 },
                    { 659, new Guid("d2610a96-4339-4a53-8781-51215b1c87ff"), "سده لنجان", 19 },
                    { 658, new Guid("9130ae43-9411-43ec-9d82-e0688ff2157d"), "زيباشهر", 19 },
                    { 657, new Guid("163634b1-5988-4d49-b8d9-8065446ca02b"), "زيار", 19 },
                    { 656, new Guid("28d4503e-2426-40a2-aef4-7795c054e38f"), "زواره", 19 },
                    { 655, new Guid("9ed67263-4445-4cb4-9a5d-94822119bbbc"), "زرين شهر", 19 },
                    { 670, new Guid("a30bc322-9988-48eb-b68b-89ca97b8a514"), "علويچه", 19 },
                    { 671, new Guid("b5796b41-4f96-4484-9311-03e3fe4725ae"), "فرخي", 19 },
                    { 672, new Guid("bb4e5a9b-fe1b-418e-bfac-4180073f79c4"), "فريدونشهر", 19 },
                    { 673, new Guid("7a3119bf-5a12-4c4f-bea8-380dc231a830"), "فلاورجان", 19 },
                    { 689, new Guid("f0fa7fdd-206d-4339-ab8d-6605c644e9c8"), "نوش آباد", 19 },
                    { 688, new Guid("90de361e-da8f-495f-bedc-ce09dcf80cd5"), "نطنز", 19 },
                    { 687, new Guid("9d6db0cf-8be0-4197-aa1b-ce42b37aeb5a"), "نصرآباد", 19 },
                    { 686, new Guid("92c258cc-1a3e-4148-a525-6e9f37dff780"), "نجف آباد", 19 },
                    { 685, new Guid("23598149-3da2-4b1c-908f-7fa21ea2ffb3"), "نائين", 19 },
                    { 684, new Guid("49b71a8c-a826-4b62-8a9d-869d32151edc"), "ميمه", 19 },
                    { 683, new Guid("79715e65-ae4c-47ef-9a35-eacc826a5981"), "مهاباد", 19 },
                    { 654, new Guid("d869170b-22e4-4bed-96bd-694a8d5ad4e7"), "زاينده رود", 19 },
                    { 682, new Guid("9b021d36-b62a-4f13-8a1d-ad704962e28d"), "منظريه", 19 },
                    { 680, new Guid("c8e5f9c8-b277-4dd7-bc84-0276dbe9e9ce"), "محمد آباد", 19 },
                    { 679, new Guid("61855b85-53d8-4d5b-9432-be7a87621a46"), "مبارکه", 19 },
                    { 678, new Guid("ffe74e96-0e71-423b-8ec5-91462f77e2d0"), "لاي بيد", 19 },
                    { 677, new Guid("aa7004c9-8433-491b-a8a2-30f67585c51f"), "قهدريجان", 19 },
                    { 676, new Guid("ef30063f-a867-4f4a-b86d-f391d0e668e0"), "قهجاورستان", 19 },
                    { 675, new Guid("374b65fd-189e-402b-8a6f-f0440c9dccc8"), "قمصر", 19 },
                    { 674, new Guid("c7e38293-a8d1-46ab-ae77-6b798cdab310"), "فولاد شهر", 19 },
                    { 681, new Guid("14cb2739-e0e2-4462-85ba-846cc20158dd"), "مشکات", 19 },
                    { 690, new Guid("5ed586bd-5181-4add-87e8-35eac9fe45d3"), "نياسر", 19 },
                    { 653, new Guid("31af3b94-55af-49b6-beef-b85ed3d8df5e"), "زازران", 19 },
                    { 651, new Guid("2e2e1482-dc5f-4a3c-b9bf-c7ffbb8b3999"), "رزوه", 19 },
                    { 630, new Guid("a44b5a30-c1ea-4349-afc4-86d9e5faf14c"), "تودشک", 19 },
                    { 629, new Guid("d9f3e103-fa6d-4e19-a011-714be24ea8b6"), "بوئين مياندشت", 19 },
                    { 628, new Guid("d1bc3385-d008-4b5f-a809-8229fab71742"), "بهارستان", 19 },
                    { 627, new Guid("31fccea5-5df2-4025-b15f-104b5448b1a8"), "بهاران شهر", 19 },
                    { 626, new Guid("bbe7d336-6018-4803-8352-091840a2581f"), "برف انبار", 19 },
                    { 625, new Guid("920a56a7-81ec-4a0e-a6f7-1dd6ea0303b9"), "برزک", 19 },
                    { 624, new Guid("7d551eb3-079a-45e5-81d1-57d4f1c4dcd6"), "بافران", 19 },
                    { 623, new Guid("af661ad8-ba5f-4753-af0a-0612030765d9"), "باغشاد", 19 },
                    { 622, new Guid("4ce2de6c-3e7b-41e3-8e03-5a62f2ac540a"), "باغ بهادران", 19 },
                    { 621, new Guid("0822b3e8-1dc9-4584-9d32-d4658c00ae38"), "بادرود", 19 },
                    { 620, new Guid("13f6a6a8-4d9c-4325-a55b-c389bc3ffcb0"), "اژيه", 19 },
                    { 619, new Guid("d3741b4c-33c0-4cbb-a4bc-79c07db23caf"), "ايمانشهر", 19 },
                    { 618, new Guid("1b951256-027a-450f-b76c-9cdc7f722ddd"), "انارک", 19 },
                    { 617, new Guid("66ce7afc-a8e2-4669-bc45-cb37d525618c"), "افوس", 19 },
                    { 616, new Guid("da6eaa37-2668-460e-96b6-059611b6f556"), "اصفهان", 19 },
                    { 631, new Guid("59c53dd5-6a23-4e22-973a-bf61a4690567"), "تيران", 19 },
                    { 632, new Guid("8f5effce-db3f-4693-bdc3-c9d8a2b0936d"), "جندق", 19 },
                    { 633, new Guid("b75b8b77-7f04-4859-b37f-e42b1b407ae7"), "جوزدان", 19 },
                    { 634, new Guid("efabf7df-477d-4835-928b-5afea31a687a"), "جوشقان قالي", 19 },
                    { 650, new Guid("518f01d3-7f81-4741-874f-e3d27af9539d"), "ديزيچه", 19 },
                    { 649, new Guid("ec14a618-5097-42d1-897f-ef66a43d73b6"), "دولت آباد", 19 },
                    { 648, new Guid("afa94a7c-c056-4e6d-a2ca-28981268ae11"), "دهق", 19 },
                    { 647, new Guid("35e1a30d-2a7d-4cf1-9bde-0ad91ba08c93"), "دهاقان", 19 },
                    { 646, new Guid("3a84892e-b613-4054-a9cd-857152fa1da9"), "دستگرد", 19 },
                    { 645, new Guid("e0add3d2-d845-4a87-8cc2-b980023df257"), "درچه پياز", 19 },
                    { 644, new Guid("0d13facc-b039-4a7e-a838-1d5f6e4a4fa4"), "دامنه", 19 },
                    { 652, new Guid("6927c30b-b4d1-40cf-9bf5-10f36a57c1b7"), "رضوانشهر", 19 },
                    { 643, new Guid("3cadaf3f-67ef-42cd-85d6-3e60a379eb74"), "داران", 19 },
                    { 641, new Guid("a6c3d98f-aaca-4461-9901-61c82e1fb864"), "خور", 19 },
                    { 640, new Guid("1187375d-9f1a-46a0-bf20-4e986658b7eb"), "خوانسار", 19 },
                    { 639, new Guid("aa567282-919e-45da-96e6-4b5f83f47906"), "خميني شهر", 19 },
                    { 638, new Guid("b0878059-2a32-450c-a4dd-6fb9b21d53c5"), "خالد آباد", 19 },
                    { 637, new Guid("2d579521-e196-4728-957a-e4e1f9e8ce4e"), "حنا", 19 },
                    { 636, new Guid("5223eb16-40b4-41b4-81c5-f93dcbab3ecb"), "حسن آباد", 19 },
                    { 635, new Guid("8a25f4d4-2ed4-4e7d-949f-df40fcb51b03"), "حبيب آباد", 19 },
                    { 642, new Guid("d00980ab-369a-4c7d-b21b-3a10e8dc43e8"), "خورزوق", 19 },
                    { 691, new Guid("c2fabe4f-daeb-45fa-bebb-6f1f41c60655"), "نيک آباد", 19 },
                    { 692, new Guid("576ae707-7066-455c-8329-91382717a9fb"), "هرند", 19 },
                    { 693, new Guid("bfb89a8b-8604-40ef-b611-6132f66f65ec"), "ورزنه", 19 },
                    { 748, new Guid("c2cac4ad-d76c-4f03-9ae7-70980319e99c"), "باقرشهر", 21 },
                    { 747, new Guid("d8588025-97ce-46e8-aaff-c2bb5c01a4d6"), "باغستان", 21 },
                    { 746, new Guid("a5b6c21b-93fb-4a67-8631-2aa96fe8af12"), "انديشه", 21 },
                    { 745, new Guid("f959b0c4-5f43-4432-ba0e-8dfeb4048f5c"), "اسلامشهر", 21 },
                    { 744, new Guid("de1ee7d5-d4c0-41b4-bd1b-b6fb8723a75e"), "ارجمند", 21 },
                    { 743, new Guid("16ec906c-9f90-4584-9cd1-adba9a778a25"), "آبعلي", 21 },
                    { 742, new Guid("29f9c8e1-0c09-4135-aecd-7fd62d846d42"), "آبسرد", 21 },
                    { 741, new Guid("770dcb43-248c-49cc-96d3-88dba3f433b1"), "چوار", 20 },
                    { 740, new Guid("a2bbf05f-3faf-4b45-9875-4abffc85806d"), "پهله", 20 },
                    { 739, new Guid("1929e9fd-0523-4028-8885-d4196f6aaacd"), "ميمه", 20 },
                    { 738, new Guid("4a627b22-b726-4846-815b-b075ce317d19"), "موسيان", 20 },
                    { 737, new Guid("6381fc6b-d56a-422d-ac32-69f22131c75f"), "مورموري", 20 },
                    { 736, new Guid("2fb0acc8-ce3d-47de-ba1b-17c443805ae5"), "مهران", 20 },
                    { 735, new Guid("4ad27508-081e-43d4-ba12-1bbda5c7773d"), "مهر", 20 },
                    { 734, new Guid("e2883ea6-3b72-496f-b018-93471f4e6875"), "ماژين", 20 },
                    { 749, new Guid("a747fb02-a296-4586-a19e-1b58e45d5c53"), "بومهن", 21 },
                    { 750, new Guid("136e65c6-5448-4c59-9e44-f0b062aab233"), "تجريش", 21 },
                    { 751, new Guid("7632c58d-e4ab-4032-843d-948861520ffd"), "تهران", 21 },
                    { 752, new Guid("7d2d83c2-ca3f-45b5-b635-5d6486988fdb"), "جواد آباد", 21 },
                    { 768, new Guid("e68129ea-ba94-4b24-a958-1948a2e83730"), "فشم", 21 },
                    { 767, new Guid("6f9927c0-f555-48c9-b73e-433ec368f24a"), "فرون آباد", 21 },
                    { 766, new Guid("82d03a00-5f3c-4455-bbb8-7f53e9498406"), "فردوسيه", 21 },
                    { 765, new Guid("6a1a7566-a2f3-439a-9655-177695588bd8"), "صفادشت", 21 },
                    { 764, new Guid("91e3612d-cc68-412d-81e3-fd7ee3736b96"), "صبا شهر", 21 },
                    { 763, new Guid("7f3127f1-4e1c-4829-a7b7-b47efb2c44e0"), "صالحيه", 21 },
                    { 762, new Guid("fd13b418-559b-462c-b50c-89584bf24a44"), "شهريار", 21 },
                    { 733, new Guid("f13a794c-1e99-4af8-bee7-985141d56d25"), "لومار", 20 },
                    { 761, new Guid("03edb72d-b48c-4283-8448-21b36869eadd"), "شهر جديد پرند", 21 },
                    { 759, new Guid("89ab9680-fa3b-4269-8f3e-ca4826880515"), "شريف آباد", 21 },
                    { 758, new Guid("1f217c59-8f42-47ba-a5f3-cc4404f0befd"), "شاهدشهر", 21 },
                    { 757, new Guid("49448d64-084b-4479-97f7-5e451e1dca8e"), "ري", 21 },
                    { 756, new Guid("c2589f43-e0c6-4364-9240-f13e066719fd"), "رودهن", 21 },
                    { 755, new Guid("0ad741e4-6adc-4721-9870-1092d62b6840"), "رباط کريم", 21 },
                    { 754, new Guid("45dc6600-22a6-44e7-92ae-7b4f795bc88c"), "دماوند", 21 },
                    { 753, new Guid("09173468-de39-489d-b06d-f65a2904a875"), "حسن آباد", 21 },
                    { 760, new Guid("8418b494-b7c4-46ce-b03b-53077193d192"), "شمشک", 21 },
                    { 732, new Guid("b5065887-3552-4836-9138-73c67204b2d4"), "صالح آباد", 20 },
                    { 731, new Guid("3fc3dd50-d43e-4ed9-aa09-926741378d70"), "شباب", 20 },
                    { 730, new Guid("0e2e927c-1207-478b-ab7f-7d898be3ae46"), "سرابله", 20 },
                    { 709, new Guid("c17c2275-7c92-4c5d-bf13-ee252f7b0a24"), "کوهپايه", 19 },
                    { 708, new Guid("22459625-8ee2-4786-8cbf-0375120c0416"), "کوشک", 19 },
                    { 707, new Guid("f9a53d27-a694-480c-a351-53e24f81ee6f"), "کهريزسنگ", 19 },
                    { 706, new Guid("f1f2c3c4-9970-4f60-a38c-b61d6866c969"), "کمه", 19 },
                    { 705, new Guid("e913bf2a-a5ec-4fa3-82ed-7925c2c8b70b"), "کمشجه", 19 },
                    { 704, new Guid("49e277f7-8c8b-4ff7-b706-f96bf8ed9f3f"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("6b6eddba-203d-4a12-a16a-f3db517654b1"), "کرکوند", 19 },
                    { 710, new Guid("6e11fe80-b105-4289-86c0-2520a62e00c3"), "گرگاب", 19 },
                    { 702, new Guid("b6489827-e703-441a-8419-3190933460f0"), "کامو و چوگان", 19 },
                    { 700, new Guid("d0440e64-0176-44fa-863e-92a8c85b1d42"), "چمگردان", 19 },
                    { 699, new Guid("968d45cc-512f-4110-88e5-224593d79e96"), "چرمهين", 19 },
                    { 698, new Guid("2656908e-0f7d-4f74-b935-6a471ee1f7b6"), "چادگان", 19 },
                    { 697, new Guid("47cd8773-86cf-45ae-aa85-6aad83915863"), "پير بکران", 19 },
                    { 696, new Guid("1ed15aac-56e3-45dd-9405-0cc88bdaef63"), "ونک", 19 },
                    { 695, new Guid("3702d21a-6771-4f2f-bb92-3edcc4277a61"), "وزوان", 19 },
                    { 694, new Guid("be30a0f9-65c8-4c3e-b892-b624e5480728"), "ورنامخواست", 19 },
                    { 701, new Guid("d1e31cf3-8495-45f8-a1ad-c7f25c0e9742"), "کاشان", 19 },
                    { 926, new Guid("53d649bb-9448-4ff2-879b-9315c9298b3e"), "مزايجان", 23 },
                    { 711, new Guid("1ebd0840-13cf-4e55-8f50-b08aa28b1d61"), "گز برخوار", 19 },
                    { 713, new Guid("9e0b6683-b6f2-4c71-8ddc-5f0032f17f20"), "گلشن", 19 },
                    { 729, new Guid("b0e751cc-52e2-4f05-b7b7-4848490d9c55"), "سراب باغ", 20 },
                    { 728, new Guid("dd5ed9b4-a8b8-44d0-a2cc-7173c7adc6ff"), "زرنه", 20 },
                    { 727, new Guid("76b9ffee-72dd-4b62-9434-bdcc40ea682a"), "دهلران", 20 },
                    { 726, new Guid("01ea1030-b774-487b-aab6-bb651dc799e6"), "دلگشا", 20 },
                    { 725, new Guid("b93934ab-ea79-4084-b778-56337b7db857"), "دره شهر", 20 },
                    { 724, new Guid("5ef97f01-b957-449f-a80a-bf12786fc550"), "توحيد", 20 },
                    { 723, new Guid("562b917e-1ef8-4368-96eb-2b705401db19"), "بلاوه", 20 },
                    { 712, new Guid("38ff58eb-1385-473a-952e-c895837e8994"), "گلدشت", 19 },
                    { 722, new Guid("fe0d3b1f-64d3-4cab-855d-df0104ede128"), "بدره", 20 },
                    { 720, new Guid("77e4fdde-19c6-4260-9436-db1d5498da3e"), "ايلام", 20 },
                    { 719, new Guid("078e5d62-a717-4e86-94be-633f51cf4abf"), "ارکواز", 20 },
                    { 718, new Guid("e4374372-ed7f-4c9e-b437-f5c7e10ded94"), "آسمان آباد", 20 },
                    { 717, new Guid("c6722046-f527-48ae-891e-37fdf8ba4b4f"), "آبدانان", 20 },
                    { 716, new Guid("66bc5bbd-3035-4fd8-81b8-2e917279e2fa"), "گوگد", 19 },
                    { 715, new Guid("f80c796e-039b-4fb7-8498-c553b3303c69"), "گلپايگان", 19 },
                    { 714, new Guid("5587cbc6-56f9-4b92-b794-b3dd179e9070"), "گلشهر", 19 },
                    { 721, new Guid("99ff44d3-e512-4aa1-8f19-c81eeb746b28"), "ايوان", 20 },
                    { 927, new Guid("1fdbb8ca-f08e-45c8-834d-079145af569c"), "مشکان", 23 },
                    { 928, new Guid("a287e99b-0c18-457f-b199-360c33a6968a"), "مصيري", 23 },
                    { 929, new Guid("5fb65011-df78-4877-b02c-619e09fda3c5"), "مهر", 23 },
                    { 1141, new Guid("17c30613-346d-4eff-a797-1491e63354b3"), "بردسير", 29 },
                    { 1140, new Guid("8be7432f-51be-498d-82b9-ee50f4c012a1"), "بافت", 29 },
                    { 1139, new Guid("56b9b10d-1fdb-40bf-88f9-f006b1e8b37b"), "باغين", 29 },
                    { 1138, new Guid("b7082dc4-4769-4fb2-acdb-be41b00b9913"), "اندوهجرد", 29 },
                    { 1137, new Guid("af066630-b55e-4be5-9cf5-738c8202851b"), "انار", 29 },
                    { 1136, new Guid("cf6aee5c-b48b-4f2b-ac09-4cc6e1877464"), "امين شهر", 29 },
                    { 1135, new Guid("6f91b4c0-b297-40fa-8f7a-cdc7faf3fad9"), "ارزوئيه", 29 },
                    { 1134, new Guid("820e6380-758b-4191-aaa5-bf4a40f87902"), "اختيار آباد", 29 },
                    { 1133, new Guid("4f773e56-6da7-4ff8-a90d-b7be7ddac3a6"), "گيان", 28 },
                    { 1132, new Guid("371b1c2f-8bd3-4176-ac05-8043a1712edc"), "گل تپه", 28 },
                    { 1131, new Guid("4824bd46-2657-4697-9914-06cf849ec8fa"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("01ed7a93-8616-4335-83f3-89664e3f59cb"), "همدان", 28 },
                    { 1129, new Guid("94c30d7e-4f86-4ff7-850f-8a289ac78078"), "نهاوند", 28 },
                    { 1128, new Guid("737670bc-7574-4e78-9e08-823faf4ef352"), "مهاجران", 28 },
                    { 1127, new Guid("f0a1aedb-25ca-48c4-ada4-b2241349cf3a"), "ملاير", 28 },
                    { 1142, new Guid("08ec5ba6-c69c-4708-8ac9-de18125ab740"), "بروات", 29 },
                    { 1143, new Guid("7560eb42-8dc7-4660-a115-b0176ccc5e54"), "بزنجان", 29 },
                    { 1144, new Guid("92993224-6fdf-41e7-bbbc-e79784a01c11"), "بلورد", 29 },
                    { 1145, new Guid("e1ad986d-7a68-488d-8064-8ff195ed1102"), "بلوک", 29 },
                    { 1161, new Guid("922c641f-8071-48db-ac08-a51f23670489"), "راور", 29 },
                    { 1160, new Guid("075ea2c9-a9f0-41da-8902-489077dfc2be"), "رابر", 29 },
                    { 1159, new Guid("d40a4abd-7b07-4b02-acf1-06654505c81e"), "دوساري", 29 },
                    { 1158, new Guid("cf765a3c-c858-4092-9a02-9b0ce7f25759"), "دهج", 29 },
                    { 1157, new Guid("c1c30d88-2c90-426e-9774-aff6dc604546"), "دشتکار", 29 },
                    { 1156, new Guid("0db471d2-f1a0-480c-846c-0aa93de8bdae"), "درب بهشت", 29 },
                    { 1155, new Guid("97f38505-5566-4149-b56f-c2727a015627"), "خورسند", 29 },
                    { 1126, new Guid("a2890a9d-7575-4b7d-9b12-15f3e81c98eb"), "مريانج", 28 },
                    { 1154, new Guid("1822330d-2fff-48c8-8ab2-a8c0cecfc75f"), "خواجوشهر", 29 },
                    { 1152, new Guid("3191c270-1bef-4afa-abe4-16b06075f2b7"), "خاتون آباد", 29 },
                    { 1151, new Guid("af93cd99-2b38-456c-ace6-69ffb935fe8c"), "جيرفت", 29 },
                    { 1150, new Guid("d313bf35-06f7-4edf-919f-ed43f0bca8a4"), "جوپار", 29 },
                    { 1149, new Guid("ef3ed8f3-f79a-40cb-9f38-a7f9f02116a8"), "جوزم", 29 },
                    { 1148, new Guid("a16782c7-05d6-4b4a-99e8-855c6c5469d7"), "جبالبارز", 29 },
                    { 1147, new Guid("0225fb9d-dacb-4ada-a7f5-2b1e948b9c95"), "بهرمان", 29 },
                    { 1146, new Guid("67f4aea9-806f-4486-a63c-f326b2fc0762"), "بم", 29 },
                    { 1153, new Guid("780ef923-9571-481e-881d-778617248af4"), "خانوک", 29 },
                    { 1162, new Guid("bedca581-1b1d-4574-b62c-134d48f35391"), "راين", 29 },
                    { 1125, new Guid("61e0bae5-fa39-44a7-853f-b298edf92e86"), "لالجين", 28 },
                    { 1123, new Guid("f312de3d-7fa4-4ce7-a151-98ee80fab115"), "قروه در جزين", 28 },
                    { 1102, new Guid("7a10fa73-7ece-4c34-8ff2-1b935993324a"), "کوچصفهان", 27 },
                    { 1101, new Guid("fa9e130a-b86f-4b2a-9749-cb2dfb001ca2"), "کومله", 27 },
                    { 1100, new Guid("6a4a1c8b-a172-4265-b7ff-3ebecc0c1e22"), "کلاچاي", 27 },
                    { 1099, new Guid("5d93e165-bf29-4d3a-a299-25851c09a815"), "چوبر", 27 },
                    { 1098, new Guid("c42adead-4c90-4ef8-a82d-b109381e263c"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("1d13f5b0-6358-437c-b8ff-946f57dfa65a"), "چابکسر", 27 },
                    { 1096, new Guid("fb2621f9-ad01-4339-92c9-6b74c68095e9"), "پره سر", 27 },
                    { 1095, new Guid("a9bcd5b6-48ba-430f-b870-cc82c5205ee0"), "واجارگاه", 27 },
                    { 1094, new Guid("84a25cbb-8fb6-4128-8053-c85f4e86e96e"), "هشتپر", 27 },
                    { 1093, new Guid("8812bf78-cf55-4475-a097-80b2a76645df"), "منجيل", 27 },
                    { 1092, new Guid("0755cce6-5d6e-49fa-9433-ea215f00d6e4"), "مرجقل", 27 },
                    { 1091, new Guid("7f9485b1-7943-4894-a0ba-71970bab7319"), "ماکلوان", 27 },
                    { 1090, new Guid("86e5993f-37f5-4f60-974b-59ff399f320a"), "ماسوله", 27 },
                    { 1089, new Guid("d7d3c9dd-33bc-4644-a71b-1ce9c4b88cb6"), "ماسال", 27 },
                    { 1088, new Guid("e01d281c-dfc9-464e-a8da-540339a2fc94"), "ليسار", 27 },
                    { 1103, new Guid("28776644-cc4d-40d2-8499-06b5d8d5f7a0"), "کياشهر", 27 },
                    { 1104, new Guid("f235ae51-edb3-4289-8f7e-5a5352a24800"), "گوراب زرميخ", 27 },
                    { 1105, new Guid("53c47ac0-d058-4516-b691-5ee10425c30b"), "آجين", 28 },
                    { 1106, new Guid("a327fcbd-2afa-4771-80c0-94ca9d35f878"), "ازندريان", 28 },
                    { 1122, new Guid("fde7ecb6-c583-41ed-a995-e0c3bd8cfe74"), "فيروزان", 28 },
                    { 1121, new Guid("7b273e41-e63e-4167-81d8-e67de05cec2f"), "فرسفج", 28 },
                    { 1120, new Guid("940263b1-f228-4ede-8ef1-f3474e4059e1"), "فامنين", 28 },
                    { 1119, new Guid("3ba987ec-f3af-4715-8273-28486d6b8025"), "صالح آباد", 28 },
                    { 1118, new Guid("19ac56d0-28a0-4f83-8ed9-94dbefdfd398"), "شيرين سو", 28 },
                    { 1117, new Guid("e8ddad96-d971-49a0-956c-ab5369daf0d0"), "سرکان", 28 },
                    { 1116, new Guid("5a385153-5356-495f-98e9-47cea4e25553"), "سامن", 28 },
                    { 1124, new Guid("22361636-0508-4dd0-bb8e-b3b0dc26fda7"), "قهاوند", 28 },
                    { 1115, new Guid("bba24716-fe69-4602-9b8a-e36a8b441ad7"), "زنگنه", 28 },
                    { 1113, new Guid("f8747256-89d1-4c5d-885f-3e9ee1be3c76"), "دمق", 28 },
                    { 1112, new Guid("a7aecf6a-ef64-4daa-94ed-5fee4ff59f9d"), "جوکار", 28 },
                    { 1111, new Guid("0388dafc-753e-4b61-a60f-7c32f83ac53d"), "جورقان", 28 },
                    { 1110, new Guid("2d445a17-666f-4fdc-b3bc-9088fe5921ac"), "تويسرکان", 28 },
                    { 1109, new Guid("1387ae4d-b3ea-4281-8e25-cb1951956fab"), "بهار", 28 },
                    { 1108, new Guid("3c6646c1-7a91-41c5-ae67-211a701123e5"), "برزول", 28 },
                    { 1107, new Guid("b446ecb2-1883-404b-8358-8fc9b749694e"), "اسد آباد", 28 },
                    { 1114, new Guid("9a439ed8-b934-4d5a-8a16-cf4287dabf4d"), "رزن", 28 },
                    { 1163, new Guid("392d4014-c5e2-4e2a-be28-e67c78aa3840"), "رفسنجان", 29 },
                    { 1164, new Guid("7a9ad61b-58ee-4341-9dfb-485f4a2dcf1b"), "رودبار", 29 },
                    { 1165, new Guid("7259c2e6-588e-4582-89bc-3f6bf6e1647f"), "ريحان", 29 },
                    { 1220, new Guid("be570810-37a7-492b-a43c-8d35cb2ed098"), "ميامي", 30 },
                    { 1219, new Guid("108869c3-cd2d-4164-8044-5a8c75999a7e"), "مهدي شهر", 30 },
                    { 1218, new Guid("35db920c-b873-4b2f-8a23-b378b2525109"), "مجن", 30 },
                    { 1217, new Guid("7de3effb-fae7-40b0-aea8-97ef2e3e9d5c"), "شهميرزاد", 30 },
                    { 1216, new Guid("f21f34c5-4137-4129-8970-5b110fc33f01"), "شاهرود", 30 },
                    { 1215, new Guid("d9620ba6-e78c-4d86-ac3f-c83476756296"), "سمنان", 30 },
                    { 1214, new Guid("5f888e5d-8c71-411e-8fea-d7d096648561"), "سرخه", 30 },
                    { 1213, new Guid("65526bcc-4de6-4db7-b08d-a595cd714d29"), "روديان", 30 },
                    { 1212, new Guid("ecb139c7-816e-4b3f-94c2-2ba9a186105e"), "ديباج", 30 },
                    { 1211, new Guid("01c11229-b75a-4070-93da-f616f5bc25c8"), "درجزين", 30 },
                    { 1210, new Guid("aeb497ea-40c2-48eb-8de6-f6a6587f207d"), "دامغان", 30 },
                    { 1209, new Guid("57e37bf0-3a92-42f8-8b16-519ccaafface"), "بيارجمند", 30 },
                    { 1208, new Guid("d9276231-27b4-4661-8217-856c22e923f3"), "بسطام", 30 },
                    { 1207, new Guid("8b588c0e-067a-491d-98f7-02ba66ae5cc3"), "ايوانکي", 30 },
                    { 1206, new Guid("e0a8964f-2f26-4990-90c5-7b48a8b19cb5"), "اميريه", 30 },
                    { 1221, new Guid("0ac6dbb3-4300-4273-9195-7d452b220916"), "کلاته", 30 },
                    { 1222, new Guid("41bb69f7-93ba-46b4-a404-345cc9acf535"), "کلاته خيج", 30 },
                    { 1223, new Guid("a9ee591d-c146-4b37-81ea-3efb9a927137"), "کهن آباد", 30 },
                    { 1224, new Guid("2c7fe002-3295-40cd-afa9-b48310787a12"), "گرمسار", 30 },
                    { 1240, new Guid("71dee698-b22b-4321-b7c6-2a6f14ab6076"), "چيتاب", 31 },
                    { 1239, new Guid("9fe8d028-ba6a-4e37-a216-0e31073df1c3"), "چرام", 31 },
                    { 1238, new Guid("5b12f121-7a31-4d1d-8184-168842e1886e"), "پاتاوه", 31 },
                    { 1237, new Guid("bb01d7d3-63ab-4302-a5b7-89d0314594a1"), "ياسوج", 31 },
                    { 1236, new Guid("3bd958b7-c190-4c85-8cd2-27042d919b82"), "مارگون", 31 },
                    { 1235, new Guid("309cc579-7cab-4ca7-b50c-c13854dc2163"), "مادوان", 31 },
                    { 1234, new Guid("cf84b25a-ee46-4ad9-81b5-dd81cf6a77fa"), "ليکک", 31 },
                    { 1205, new Guid("70d00565-cf8f-4266-abce-4c94acd69cb2"), "آرادان", 30 },
                    { 1233, new Guid("93cffd16-79fa-4686-9217-36b791305a57"), "لنده", 31 },
                    { 1231, new Guid("3af3c211-845c-44b8-b226-843fe7612de4"), "سي سخت", 31 },
                    { 1230, new Guid("e55104c6-2775-44d6-a219-30507262063a"), "سوق", 31 },
                    { 1229, new Guid("fc0ab8ab-e3cd-483a-b887-20e6f7e1f181"), "سرفارياب", 31 },
                    { 1228, new Guid("09fb26da-885c-4585-a6de-a4edfb7ff49e"), "ديشموک", 31 },
                    { 1227, new Guid("08ca70e3-a042-4b57-8368-8fd500ac2d87"), "دوگنبدان", 31 },
                    { 1226, new Guid("3d84cad9-9641-4e0a-8b7a-e718aec719c8"), "دهدشت", 31 },
                    { 1225, new Guid("1e748019-d42e-4636-9465-505dd8a924f5"), "باشت", 31 },
                    { 1232, new Guid("a860dcb4-2ecd-448b-827d-ca2abe6d6921"), "قلعه رئيسي", 31 },
                    { 1204, new Guid("979f1d19-2727-453f-8f9c-afeff4829a89"), "گنبکي", 29 },
                    { 1203, new Guid("31860c00-4998-4255-a0a2-039213cefa51"), "گلزار", 29 },
                    { 1202, new Guid("912ab879-9a17-4214-b34b-b88a224f4d70"), "گلباف", 29 },
                    { 1181, new Guid("f7597afe-1053-49f4-b4a0-2b0e2c9348d7"), "محي آباد", 29 },
                    { 1180, new Guid("ddb7b144-72cc-43db-b96b-41ce1683cf70"), "محمد آباد", 29 },
                    { 1179, new Guid("aaf83c57-8d4e-4a3c-8b71-352261ffdf5e"), "ماهان", 29 },
                    { 1178, new Guid("d2e7e5f2-cf72-407c-985d-cf284933d591"), "لاله زار", 29 },
                    { 1177, new Guid("33687fb4-eb8d-4364-8921-eb049d2d051e"), "قلعه گنج", 29 },
                    { 1176, new Guid("ca609617-888c-48eb-89f6-7ddc5b282f04"), "فهرج", 29 },
                    { 1175, new Guid("d9def6ad-6560-4133-888e-3500ba57f352"), "فارياب", 29 },
                    { 1182, new Guid("0e3e02e8-d389-46ea-b5cf-e92ed56ef920"), "مردهک", 29 },
                    { 1174, new Guid("9e6146c9-76e3-4410-a0af-8cc7f315211d"), "عنبر آباد", 29 },
                    { 1172, new Guid("8eb97900-3aa3-42ac-9881-b2a61f6101e0"), "شهر بابک", 29 },
                    { 1171, new Guid("95bf3bf0-8218-4c85-bcea-58b32b0ed00c"), "شهداد", 29 },
                    { 1170, new Guid("dd21c31b-5d60-4d84-a6b5-1ecf1ac8ce39"), "سيرجان", 29 },
                    { 1169, new Guid("beda808b-c3e1-492b-ada5-cd34b5783ab0"), "زيد آباد", 29 },
                    { 1168, new Guid("f22fbca3-1854-4b3d-b34c-fc1da4388534"), "زهکلوت", 29 },
                    { 1167, new Guid("205fb166-b532-4f4c-baa8-bb59536b7cdb"), "زنگي آباد", 29 },
                    { 1166, new Guid("0654f57f-6451-4ad7-ae97-891ed9c66070"), "زرند", 29 },
                    { 1173, new Guid("a82deb1e-d566-42b8-8fb5-ac93b95e8ceb"), "صفائيه", 29 },
                    { 1087, new Guid("2141417b-b8d0-4fb2-bb97-1637bbf182a8"), "لوندويل", 27 },
                    { 1183, new Guid("b3aebb17-8270-4d4b-9ae5-0d5f114147f5"), "مس سرچشمه", 29 },
                    { 1185, new Guid("506f35b0-738d-4cd6-a933-d5f63c62545c"), "نجف شهر", 29 },
                    { 1201, new Guid("54d2afe8-d8f8-4c29-bebe-65daa7b9eb9b"), "کيانشهر", 29 },
                    { 1200, new Guid("ae1925df-b86f-4397-aa58-f1985da03b06"), "کوهبنان", 29 },
                    { 1199, new Guid("3340dd42-ed88-4f49-a82a-15d2fab9727a"), "کهنوج", 29 },
                    { 1198, new Guid("de113490-69c2-48d3-b12f-7b891f3abee8"), "کشکوئيه", 29 },
                    { 1197, new Guid("cf3f95b0-416d-48fa-a1be-727b41f90e8b"), "کرمان", 29 },
                    { 1196, new Guid("6c63e699-cdda-4cc3-ad63-48e44bfba237"), "کاظم آباد", 29 },
                    { 1195, new Guid("af6620a4-bd6a-4b7c-87db-3929cfb05c38"), "چترود", 29 },
                    { 1184, new Guid("481dcc72-fcf7-44a3-bb6f-e8447acd9afe"), "منوجان", 29 },
                    { 1194, new Guid("28996bc6-34f3-49b8-9332-44fb25f2ef7c"), "پاريز", 29 },
                    { 1192, new Guid("bbff5fe4-a30c-4fee-9d35-4751d54e3636"), "هنزا", 29 },
                    { 1191, new Guid("9e998710-b17f-4926-8461-22574c00417b"), "هماشهر", 29 },
                    { 1190, new Guid("5284a688-d39b-4a8e-9509-39c1b7c34500"), "هجدک", 29 },
                    { 1189, new Guid("ed645418-5b64-4150-9bf9-779244441caf"), "نگار", 29 },
                    { 1188, new Guid("6a02baf3-6cd6-4d64-bbff-55b5bc09d0ba"), "نودژ", 29 },
                    { 1187, new Guid("c9b2a6c7-f31b-45d5-9731-d861ec76cfd8"), "نظام شهر", 29 },
                    { 1186, new Guid("549a5e93-1ebc-47dc-b347-8af375f609f8"), "نرماشير", 29 },
                    { 1193, new Guid("f471a6e7-c573-4065-ad87-0928a2acf06b"), "يزدان شهر", 29 },
                    { 1086, new Guid("45a25588-5f4a-4c03-91d9-e9c37079547a"), "لولمان", 27 },
                    { 1085, new Guid("b7cf2b67-dc6f-49b0-87cc-7073a8e0c822"), "لوشان", 27 },
                    { 1084, new Guid("1376218f-8048-448e-9a9c-b325f640451d"), "لنگرود", 27 },
                    { 984, new Guid("14d859fd-383f-46ad-9ee3-42514ec281d5"), "بندر عباس", 25 },
                    { 983, new Guid("48fdd489-6c51-4da3-a6e0-bdc445564099"), "بندر جاسک", 25 },
                    { 982, new Guid("5bd7b687-0c88-455c-93f2-bf12447e1c04"), "بستک", 25 },
                    { 981, new Guid("3a10a74f-7275-473a-9b65-f3209bd3d539"), "ابوموسي", 25 },
                    { 980, new Guid("df44cc06-5db0-473d-915d-68a9be33c111"), "گيلانغرب", 24 },
                    { 979, new Guid("6ad125dc-3c59-46a7-90c3-6e2fcfb6d31b"), "گودين", 24 },
                    { 978, new Guid("d0d48518-3eb9-43ad-b381-d49f0469c222"), "گهواره", 24 },
                    { 977, new Guid("7c3c1a02-b773-4b5e-979d-b2d199b79c0a"), "کوزران", 24 },
                    { 976, new Guid("b633a42e-8fd6-4193-8e59-4af9448e18c9"), "کنگاور", 24 },
                    { 975, new Guid("47c0ee6c-e9fa-496e-adbd-885c039ee6b6"), "کرند غرب", 24 },
                    { 974, new Guid("987e36eb-48be-4824-a3e9-e23ee4e127c0"), "کرمانشاه", 24 },
                    { 973, new Guid("1693b053-edbb-44ce-82a3-b71a96913b02"), "پاوه", 24 },
                    { 972, new Guid("8908b593-4584-4c44-ae25-36d25146a375"), "هلشي", 24 },
                    { 971, new Guid("aa7be5de-5566-41c4-af06-b0ac01426e50"), "هرسين", 24 },
                    { 970, new Guid("03264c91-7b19-484d-94f9-85a987f7f0a4"), "نوسود", 24 },
                    { 985, new Guid("469c3d57-fd23-4b47-a000-94709d84c374"), "بندر لنگه", 25 },
                    { 986, new Guid("97a56604-4071-4767-b7c6-d4d47ea5c266"), "بيکاه", 25 },
                    { 987, new Guid("d4630a02-4734-4d09-b74a-0ca1b3ec3041"), "تازيان پائين", 25 },
                    { 988, new Guid("7e43a947-d6be-4286-9b9e-fddc94f9dbae"), "تخت", 25 },
                    { 1004, new Guid("e5f3587d-4ab7-4c22-a4ba-5c49c4381cef"), "فين", 25 },
                    { 1003, new Guid("4d79e92c-39be-470e-8e97-9d4ca826753c"), "فارغان", 25 },
                    { 1002, new Guid("4748d2ea-99da-4cb1-a424-6c0cf87835f5"), "سيريک", 25 },
                    { 1001, new Guid("839fe787-ae8d-45ee-acea-18a95546fcad"), "سوزا", 25 },
                    { 1000, new Guid("f70f56fd-4825-4add-9cb4-1e915731ee5f"), "سندرک", 25 },
                    { 999, new Guid("c9f261cc-0919-4248-922e-54bced5793f7"), "سرگز", 25 },
                    { 998, new Guid("89313ee9-d324-487a-b785-88e1a0263ef9"), "سردشت", 25 },
                    { 969, new Guid("3b63f789-2016-431e-8845-fe7a20c5b217"), "نودشه", 24 },
                    { 997, new Guid("5af1be09-1252-4588-b737-8974bc161451"), "زيارتعلي", 25 },
                    { 995, new Guid("4930ce8f-59d5-4238-b1ff-d367cec7d23d"), "دهبارز", 25 },
                    { 994, new Guid("12358f03-948b-413a-89c1-48f3e74dcde1"), "دشتي", 25 },
                    { 993, new Guid("34fd5cb2-add1-4ef9-8c98-64d29103117c"), "درگهان", 25 },
                    { 992, new Guid("d5dadbdb-3d59-4530-91db-5ccddc3a0d96"), "خمير", 25 },
                    { 991, new Guid("c67890da-009d-48a7-acd6-da2c62c96a99"), "حاجي آباد", 25 },
                    { 990, new Guid("39b84682-063a-4825-b02e-aaddf706434b"), "جناح", 25 },
                    { 989, new Guid("cf143974-7764-4c81-a79a-9f487803d4ae"), "تيرور", 25 },
                    { 996, new Guid("dcca5e9c-ccb6-45d8-9a8a-b8b22a617782"), "رويدر", 25 },
                    { 968, new Guid("4733836a-4026-491d-a08f-ce4e67f6f804"), "ميان راهان", 24 },
                    { 967, new Guid("b03c9b2e-6168-4037-ac3d-dbdfc38df008"), "قصر شيرين", 24 },
                    { 966, new Guid("d43e6130-f14a-4f33-819d-691bca5f924e"), "صحنه", 24 },
                    { 945, new Guid("b1887ada-9512-4f30-b18e-da1e7e183470"), "کوهنجان", 23 },
                    { 944, new Guid("7d8b6757-3d5f-4247-99ea-55a5055a41fb"), "کوار", 23 },
                    { 943, new Guid("560258a3-6828-4526-81d3-febdbf95829e"), "کنار تخته", 23 },
                    { 942, new Guid("ab02e6b0-406b-48db-a958-a029a82ac061"), "کره اي", 23 },
                    { 941, new Guid("1054120c-9f29-42a7-93ff-8239a6c543c1"), "کامفيروز", 23 },
                    { 940, new Guid("dd5c86e8-c66f-4e37-818d-6d729d15eef4"), "کازرون", 23 },
                    { 939, new Guid("56bf5d90-2f95-4425-a75b-20e4d9f7f4c3"), "کارزين", 23 },
                    { 946, new Guid("d617ae27-3268-4413-aa73-249c1c360f55"), "کوپن", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 938, new Guid("95b5d525-4d32-480d-abd6-2849c7282d21"), "وراوي", 23 },
                    { 936, new Guid("b5b3358f-1596-4614-949f-f938120e390d"), "ني ريز", 23 },
                    { 935, new Guid("8731f109-5c86-4813-866b-5e3f63139727"), "نورآباد", 23 },
                    { 934, new Guid("4909aa8e-5691-4f63-989e-f4670387dcc7"), "نودان", 23 },
                    { 933, new Guid("32de6779-a1e1-4b00-b4c8-57d1ac568e28"), "نوجين", 23 },
                    { 932, new Guid("3c61db42-6f25-45a9-9bf1-19d619ad678b"), "نوبندگان", 23 },
                    { 931, new Guid("36bc3d09-e2c2-41c5-9212-2875b1c0eab3"), "ميمند", 23 },
                    { 930, new Guid("498e80b7-a9ea-4ca2-aaba-9260f8578a88"), "ميانشهر", 23 },
                    { 937, new Guid("32560695-da80-479c-9e82-c0ae0ba1b2af"), "هماشهر", 23 },
                    { 1005, new Guid("8208e7e4-152e-4268-9b5a-1fc4edebc960"), "قشم", 25 },
                    { 947, new Guid("ff31501b-0240-44ba-bb95-7347dbf89c61"), "گراش", 23 },
                    { 949, new Guid("f8095f15-806d-40f3-bb35-8e0ed6421897"), "ازگله", 24 },
                    { 965, new Guid("b8e9285e-9851-4188-a4fb-eb5342bb8f33"), "شاهو", 24 },
                    { 964, new Guid("d0bdd876-3d6f-4d86-a244-c61dfb1d7ba0"), "سومار", 24 },
                    { 963, new Guid("5a09d673-93d5-437c-a768-1b3c5ab5dc8d"), "سنقر", 24 },
                    { 962, new Guid("a31e1d65-e07a-40af-9010-760b4af7fb2a"), "سطر", 24 },
                    { 961, new Guid("7286926a-847a-4352-b91b-82c4df7dfb35"), "سرمست", 24 },
                    { 960, new Guid("c442e2c4-b0e4-4c5a-9f5b-63d649754a1f"), "سر پل ذهاب", 24 },
                    { 959, new Guid("fac49956-63be-480d-9666-86cb02aab03a"), "ريجاب", 24 },
                    { 948, new Guid("8a8ac593-d796-417d-8515-23a1a6a981fe"), "گله دار", 23 },
                    { 958, new Guid("03877b82-bcd0-48f6-bd9e-21a17c8ff0d7"), "روانسر", 24 },
                    { 956, new Guid("47e855ee-916a-420d-bc7e-9fa24a894688"), "حميل", 24 },
                    { 955, new Guid("9fbddaf0-2e50-447f-9d9c-5205ec999d37"), "جوانرود", 24 },
                    { 954, new Guid("76a85054-1923-49fb-9946-b285a65736fd"), "تازه آباد", 24 },
                    { 953, new Guid("4519c3e9-6fc5-4729-979c-aa77682a46b5"), "بيستون", 24 },
                    { 952, new Guid("fce9b0cc-0155-4d47-8de1-2692d030b54b"), "باينگان", 24 },
                    { 951, new Guid("7b84fb66-3b66-438c-9ea2-4133db7b09f8"), "بانوره", 24 },
                    { 950, new Guid("5f0f8015-a264-4af9-bb65-8c8d521eb660"), "اسلام آباد غرب", 24 },
                    { 957, new Guid("072a9dcd-633f-48b3-811c-774d3e3d43f8"), "رباط", 24 },
                    { 615, new Guid("88c55be9-c793-417e-9777-17531bcb06d8"), "اصغرآباد", 19 },
                    { 1006, new Guid("8e674585-9a5d-4a32-9397-026a289fe68f"), "قلعه قاضي", 25 },
                    { 1008, new Guid("b99f16e4-d09e-4c3b-925a-0cd77adef84e"), "ميناب", 25 },
                    { 1063, new Guid("5cdbc73b-d18f-433d-969f-db0d60968623"), "جيرنده", 27 },
                    { 1062, new Guid("93b7243d-4419-4f63-99f9-83900447ad03"), "توتکابن", 27 },
                    { 1061, new Guid("d766e0ac-8ab3-4056-906e-e6a5d39cc1e3"), "بندر انزلي", 27 },
                    { 1060, new Guid("1610b71e-a158-4039-b47a-3d33b53d0ac4"), "بره سر", 27 },
                    { 1059, new Guid("713882be-c680-4171-ab87-7083a774aabb"), "بازار جمعه", 27 },
                    { 1058, new Guid("caf1b646-6c38-471a-8758-f679ebe414e5"), "املش", 27 },
                    { 1057, new Guid("8e78aa43-8ebe-46f6-9e8c-f630d738a495"), "اطاقور", 27 },
                    { 1056, new Guid("1d4e41c8-cfbf-4399-88d7-27009bb58ef1"), "اسالم", 27 },
                    { 1055, new Guid("73750576-b4b7-411d-9283-5c09e7688849"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("6c9a9e0a-910e-4fcf-bbc5-8d0355731b15"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("093412fd-cf01-4937-8a0e-a57a59e5019c"), "آستارا", 27 },
                    { 1052, new Guid("689dbbd0-535f-4ff3-a28b-76276c5f9272"), "کميجان", 26 },
                    { 1051, new Guid("840f2e5e-4e89-44f6-b751-e9f83053e97e"), "کارچان", 26 },
                    { 1050, new Guid("65f0eab9-5a32-4afd-ac86-6eaff2eb5034"), "پرندک", 26 },
                    { 1049, new Guid("7ad27146-d879-4ada-9f77-b6475c35a073"), "هندودر", 26 },
                    { 1064, new Guid("fa000fb1-7874-46a6-a6bc-4e6e18151091"), "حويق", 27 },
                    { 1065, new Guid("3866490f-ef2e-4910-b8ac-015970c5d8c6"), "خشکبيجار", 27 },
                    { 1066, new Guid("2602980d-dc8f-4980-80aa-447dfdd1400e"), "خمام", 27 },
                    { 1067, new Guid("97f1083f-48fb-42b6-8502-64d3339b011e"), "ديلمان", 27 },
                    { 1083, new Guid("ed5c8781-9acb-4e87-877b-b95f77e3d3ea"), "لشت نشاء", 27 },
                    { 1082, new Guid("da15d0a8-2c27-4362-bfad-5c534f309d9c"), "لاهيجان", 27 },
                    { 1081, new Guid("7123dc88-7ef1-4db9-8569-5073c90fb121"), "فومن", 27 },
                    { 1080, new Guid("5fd46a11-1bbc-4545-b87f-c5c60c41ea8a"), "صومعه سرا", 27 },
                    { 1079, new Guid("a7fe9534-cfa6-4b06-b007-6991ee5a1107"), "شلمان", 27 },
                    { 1078, new Guid("00559311-33ee-44cf-a883-1d941ece12ea"), "شفت", 27 },
                    { 1077, new Guid("de6cb151-bba5-4cb9-a976-f29183926155"), "سياهکل", 27 },
                    { 1048, new Guid("6cceae66-cff8-4b00-a85d-7108c82e0355"), "نيمور", 26 },
                    { 1076, new Guid("294b7b36-5ef2-42cb-86fd-159c9f3f6c93"), "سنگر", 27 },
                    { 1074, new Guid("64eb7794-9e41-4740-82cf-80502f8fd12e"), "رودبنه", 27 },
                    { 1073, new Guid("539679a8-4bc2-4816-911d-d714b52949eb"), "رودبار", 27 },
                    { 1072, new Guid("3d0e938b-bc36-4551-a711-433c43c8f4fe"), "رضوانشهر", 27 },
                    { 1071, new Guid("782a2178-ac7c-4720-80fd-a5ce8fb4c288"), "رشت", 27 },
                    { 1070, new Guid("d4eba0e8-52e5-4ad0-a2ac-83ab547729a5"), "رستم آباد", 27 },
                    { 1069, new Guid("98a12f61-7c38-4938-83cd-df523092afcb"), "رحيم آباد", 27 },
                    { 1068, new Guid("15aef472-4f41-4e12-b244-966c80814870"), "رانکوه", 27 },
                    { 1075, new Guid("1338dc4d-bcbb-4382-a04e-d8c5768b7edc"), "رودسر", 27 },
                    { 1047, new Guid("c36edf8f-6869-4494-ae15-95984721719c"), "نوبران", 26 },
                    { 1046, new Guid("84c3d5d4-a7ef-4897-9890-4a42208fc4b6"), "نراق", 26 },
                    { 1045, new Guid("664b7655-47dd-4114-b8ae-f5ca551bc75e"), "ميلاجرد", 26 },
                    { 1024, new Guid("7ff66941-5f45-4c1a-b245-1b7b332b7b2c"), "تفرش", 26 },
                    { 1023, new Guid("febaab0f-db9d-45cb-8665-578072f80b64"), "اراک", 26 },
                    { 1022, new Guid("fe70318a-6353-4a54-b3ce-9567eae1b24d"), "آوه", 26 },
                    { 1021, new Guid("63e74fa6-c8bf-406d-9120-1533b9872552"), "آشتيان", 26 },
                    { 1020, new Guid("503e53e1-bd7d-496a-980d-f675dc80bcce"), "آستانه", 26 },
                    { 1019, new Guid("9fc44a9a-eff3-40b4-9dbc-2e7bdabd9b05"), "گوهران", 25 },
                    { 1018, new Guid("ae338fc5-8919-40d5-b601-c5ffee8db75e"), "گروک", 25 },
                    { 1025, new Guid("4a64caf8-b605-4118-a71b-13fabc215ba0"), "توره", 26 },
                    { 1017, new Guid("088c65c7-193b-4e9c-b1ca-d305b6542b57"), "کيش", 25 },
                    { 1015, new Guid("a4208674-eba2-4b17-b631-97e85985df25"), "کوشکنار", 25 },
                    { 1014, new Guid("d0d36467-cefd-44db-ba49-89c1b1dda068"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("c53c1885-47ce-42f1-a919-a089ed0b6842"), "کنگ", 25 },
                    { 1012, new Guid("384dd848-0f35-4d90-941f-93022836f606"), "چارک", 25 },
                    { 1011, new Guid("2ff3fcaa-8bac-42e5-99c8-09b5aa4a7048"), "پارسيان", 25 },
                    { 1010, new Guid("f49134f2-c33a-4bc8-96f3-58a3672db245"), "هشتبندي", 25 },
                    { 1009, new Guid("eb6cfa72-bc94-44d7-a7e9-66ac9c087992"), "هرمز", 25 },
                    { 1016, new Guid("8fa36590-99da-4266-86b4-8109393bb98d"), "کوهستک", 25 },
                    { 1007, new Guid("7c0e799b-af69-4647-884f-bf68b8688988"), "لمزان", 25 },
                    { 1026, new Guid("29a5e857-e1e4-4e2d-ae1c-e8d8e38dba1f"), "جاورسيان", 26 },
                    { 1028, new Guid("d1b52d69-c47f-447e-95f3-a5eea1850e94"), "خمين", 26 },
                    { 1044, new Guid("7fe5401b-4ef0-4077-94e8-38e97a4409bd"), "محلات", 26 },
                    { 1043, new Guid("aaf112b6-c7a4-455b-8eb4-cd8519388464"), "مامونيه", 26 },
                    { 1042, new Guid("3fb01166-f07b-4aff-8bab-40d2d4aacc82"), "قورچي باشي", 26 },
                    { 1041, new Guid("073fd8dd-4e6f-4f7d-acf0-1ea4f5321169"), "فرمهين", 26 },
                    { 1040, new Guid("7f0cd565-3599-43cc-9223-f180b443e6bd"), "غرق آباد", 26 },
                    { 1039, new Guid("8bbcac7d-7428-4c46-b337-0e015803aa07"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("0a6ec504-e514-4b74-a8ad-db5fe42b288c"), "شهباز", 26 },
                    { 1027, new Guid("4637c113-f173-4eab-81be-a463812611c9"), "خشکرود", 26 },
                    { 1037, new Guid("66f9f560-4c40-4782-9ea4-2537d3bde637"), "شازند", 26 },
                    { 1035, new Guid("27b14313-d615-47f0-9beb-eaa1b3b1de25"), "ساروق", 26 },
                    { 1034, new Guid("ecfa1154-754a-4814-9026-7585f2a24905"), "زاويه", 26 },
                    { 1033, new Guid("a9b3c81d-0bca-4c7b-800b-93552b982598"), "رازقان", 26 },
                    { 1032, new Guid("d5084b82-8305-4e7e-b5d3-4a2743f5803b"), "دليجان", 26 },
                    { 1031, new Guid("9ec7c4a2-5e92-4eee-a723-e8464d23ce5c"), "داود آباد", 26 },
                    { 1030, new Guid("c1e27d87-0a3b-4e6b-be67-1f1f108b792c"), "خنداب", 26 },
                    { 1029, new Guid("a8a1fe4d-33da-41cf-8c0b-02e2b349bdfe"), "خنجين", 26 },
                    { 1036, new Guid("e33c74ae-2a95-45fe-a8ec-6cf9d319ad40"), "ساوه", 26 },
                    { 614, new Guid("66d56666-5ba5-4b74-b2a0-e2ffa9d66dd1"), "اردستان", 19 },
                    { 613, new Guid("0e2e6f48-ebb8-453c-ad93-39c3798a1c09"), "ابوزيد آباد", 19 },
                    { 612, new Guid("04d403ae-0958-493a-bfd8-6840e5609b03"), "ابريشم", 19 },
                    { 207, new Guid("eb511f72-cbb8-4247-acfc-78597fd78954"), "سلامي", 8 },
                    { 206, new Guid("6c9eeb5a-7ab7-45e7-a0e4-5786a3bbda45"), "سفيد سنگ", 8 },
                    { 205, new Guid("2e1731e6-60f9-4e86-b617-cc81b2e10d6c"), "سرخس", 8 },
                    { 204, new Guid("d099e759-7aee-4671-a03c-d39d1d890f9d"), "سبزوار", 8 },
                    { 203, new Guid("0892be26-519e-4cc6-8f6c-ccc646c4a1f1"), "ريوش", 8 },
                    { 202, new Guid("72f21959-0fe9-450b-be99-8b7b12ee7eed"), "روداب", 8 },
                    { 201, new Guid("bd929bed-5d7e-4dbe-9700-1363e4a83ad7"), "رضويه", 8 },
                    { 200, new Guid("4b78afe9-8b5a-4b7c-80d7-9ee8c673206b"), "رشتخوار", 8 },
                    { 199, new Guid("dabb66b6-c24d-4afe-b463-ac1bab5f9eb1"), "رباط سنگ", 8 },
                    { 198, new Guid("5609dc4d-e9c0-419f-a114-4d8360e7c23f"), "دولت آباد", 8 },
                    { 197, new Guid("c0ce22a5-675d-45ac-9bc8-8c349d5a2fcb"), "درگز", 8 },
                    { 196, new Guid("aba1ee6c-1073-4548-8e58-23519be3acbf"), "درود", 8 },
                    { 195, new Guid("bb53cd9c-bb73-462c-97bc-23dd6bc9aeac"), "داورزن", 8 },
                    { 194, new Guid("d57f5540-07dc-4892-bdae-d41eec8aaf51"), "خواف", 8 },
                    { 193, new Guid("3fa5fa99-83bf-4cec-be0d-153f7c14c8f5"), "خليل آباد", 8 },
                    { 208, new Guid("28c8b25f-96b9-4094-83f4-26ed37ed04e8"), "سلطان آباد", 8 },
                    { 192, new Guid("8127563f-046b-4f9a-af97-21a38f4520b6"), "خرو", 8 },
                    { 209, new Guid("76acfaa1-e8b1-4218-81dc-80f0ae9b78b2"), "سنگان", 8 },
                    { 211, new Guid("da332dbc-7f39-4ab5-81cf-fb433cfff20d"), "شانديز", 8 },
                    { 226, new Guid("7b27d25f-914e-4633-ba7d-fa474454cecb"), "لطف آباد", 8 },
                    { 225, new Guid("3bb020a5-4218-4a77-bf0d-6351aa0873b4"), "قوچان", 8 },
                    { 224, new Guid("8e3e95e7-40d8-4d63-b662-aa90038c00bf"), "قلندر آباد", 8 },
                    { 223, new Guid("a11f0eb3-e36f-4374-8fa9-2e4e76e580ec"), "قدمگاه", 8 },
                    { 222, new Guid("0df48c30-e992-42af-8baa-b291c67a6463"), "قاسم آباد", 8 },
                    { 221, new Guid("797d7fa5-c5ba-46dd-a5d3-bfe9d8f1570e"), "فيض آباد", 8 },
                    { 220, new Guid("56ac94a8-7dc9-4e5d-ae69-9ab5eb13931f"), "فيروزه", 8 },
                    { 219, new Guid("4fa77b56-803c-405f-838e-3e3c7a02873e"), "فريمان", 8 },
                    { 218, new Guid("49df1dea-ba42-4ae8-9dfb-fa63a7026a9f"), "فرهاد گرد", 8 },
                    { 217, new Guid("837cb705-3c85-4df5-b528-e048ea549fe3"), "عشق آباد", 8 },
                    { 216, new Guid("a55cc53b-1b94-48d4-bbaa-ee151b7575a9"), "طرقبه", 8 },
                    { 215, new Guid("427ff96b-537d-45fa-a95b-0ab2513b7943"), "صالح آباد", 8 },
                    { 214, new Guid("a6b6f019-ffd9-432a-a597-dfc3351bdc5c"), "شهرآباد", 8 },
                    { 213, new Guid("d8e6dcc2-4b80-4bbb-8d01-c747b40f33d9"), "شهر زو", 8 },
                    { 212, new Guid("54eb9a6c-a492-493b-bcf0-70157a1b47e5"), "ششتمد", 8 },
                    { 210, new Guid("fdb0600e-cdce-48fd-9fba-438ea5fe5a91"), "شادمهر", 8 },
                    { 227, new Guid("0c12d1b2-eb6e-4032-ac28-a662c031f64c"), "مزدآوند", 8 },
                    { 191, new Guid("3b1f0f5e-338c-4d8b-b3f7-036d1de054e4"), "جنگل", 8 },
                    { 189, new Guid("35e8f73c-fba0-4d64-b38f-42f68360c022"), "تربت حيدريه", 8 },
                    { 169, new Guid("8f2fb0ef-2f6e-4824-a57e-efde71c65cc9"), "نازک عليا", 7 },
                    { 168, new Guid("f0f05af7-3c07-41e3-b8ce-20fc306fa811"), "ميرآباد", 7 },
                    { 167, new Guid("6510f8a9-63b7-4d53-a549-fbc4010f80ce"), "مياندوآب", 7 },
                    { 166, new Guid("b0101cd8-3e2e-4cf4-b7a6-ee79689a7f63"), "مهاباد", 7 },
                    { 165, new Guid("595a6afc-c1eb-4648-8346-9c42ce5e34b4"), "مرگنلر", 7 },
                    { 164, new Guid("da86cb94-b391-4b59-8c67-ea6211db8c73"), "محمود آباد", 7 },
                    { 163, new Guid("4f22fe32-bf85-4a19-863b-ce8ef85035aa"), "محمد يار", 7 },
                    { 162, new Guid("555ef52d-9aa5-4d07-b06a-19299f639006"), "ماکو", 7 },
                    { 161, new Guid("6a96a4d8-1ee4-411a-ab0e-cb3e6a8db66c"), "قوشچي", 7 },
                    { 160, new Guid("0ece04ff-c395-4166-989e-a2782cd3427a"), "قطور", 7 },
                    { 159, new Guid("bca959be-4ed7-49e6-93fa-1510f93b4db9"), "قره ضياء الدين", 7 },
                    { 158, new Guid("6fca5c5e-ba51-429d-97d5-0cdf51b77ef3"), "فيرورق", 7 },
                    { 157, new Guid("e7d4e47f-015a-45d8-9e3f-79b708fda616"), "شوط", 7 },
                    { 156, new Guid("e9ca8215-babd-4d8b-8bd4-7fcbc0390aa0"), "شاهين دژ", 7 },
                    { 155, new Guid("3165a854-35cc-4d68-b816-fe9bf98d7095"), "سيه چشمه", 7 },
                    { 170, new Guid("2c5b1545-180d-4ac1-b76a-0fd47b1ca05c"), "نالوس", 7 },
                    { 190, new Guid("f5fe8572-3e8b-4dbb-a28f-d4fb1fbc1571"), "جغتاي", 8 },
                    { 171, new Guid("dcd16139-f258-4165-bc76-ed1955390f87"), "نقده", 7 },
                    { 173, new Guid("924fe44f-4c39-4169-be44-71e5c3157500"), "پلدشت", 7 },
                    { 188, new Guid("c68239d5-3a3f-4160-a19a-f4f3943666d8"), "تربت جام", 8 },
                    { 187, new Guid("806125d5-92d1-4076-8048-f9c8632b1541"), "تايباد", 8 },
                    { 186, new Guid("1ca7ad71-510a-4cfa-8f28-a421310a0cb6"), "بيدخت", 8 },
                    { 185, new Guid("8a6c0a0a-b8c2-43d9-b1a4-ab61965121c8"), "بردسکن", 8 },
                    { 184, new Guid("5f7f3a27-408b-430f-a42d-59fe41cd8a7a"), "بجستان", 8 },
                    { 183, new Guid("13d81d9d-3f81-4601-9a26-54c77f1d5243"), "بايک", 8 },
                    { 182, new Guid("688642a0-4cd5-4b86-bbdb-b5fe9c1d1130"), "بار", 8 },
                    { 181, new Guid("bd53961d-44bc-4796-8aed-e1df68e1b350"), "باخرز", 8 },
                    { 180, new Guid("bb3eb94b-b243-4267-b47e-ac62df6d10cd"), "باجگيران", 8 },
                    { 179, new Guid("d396b519-570b-4aba-a089-9beb20e2e2c4"), "انابد", 8 },
                    { 178, new Guid("e0c73d06-c44a-41bd-bc58-e166f7bb104f"), "احمدآباد صولت", 8 },
                    { 177, new Guid("9b8fc00b-5467-406d-858e-7505c9ce2d44"), "گردکشانه", 7 },
                    { 176, new Guid("5cb5b44b-466b-4d46-ae6a-10181703da53"), "کشاورز", 7 },
                    { 175, new Guid("4475be17-df77-4990-af51-2c147e81c418"), "چهار برج", 7 },
                    { 174, new Guid("ace2fb91-986b-4dad-a640-a71770ffb012"), "پيرانشهر", 7 },
                    { 172, new Guid("13151e0a-9562-4f96-a5c1-5b9f9dfd46db"), "نوشين", 7 },
                    { 228, new Guid("6355d6c3-06dc-49b1-b1e5-7a4a6be4e46d"), "مشهد", 8 },
                    { 229, new Guid("ce262567-887c-4a9c-bf55-911162aa55f7"), "مشهدريزه", 8 },
                    { 230, new Guid("65b45eaa-d306-41fb-bcbc-b1273caf2414"), "ملک آباد", 8 },
                    { 284, new Guid("23385c35-2aab-423d-9592-50aa9597fe1b"), "کنارک", 9 },
                    { 283, new Guid("9021ed20-39f8-4489-8648-ffaf24d8bba5"), "چاه بهار", 9 },
                    { 282, new Guid("2fbdc839-712d-4c61-bf8f-ecca96dff163"), "پيشين", 9 },
                    { 281, new Guid("c7f6615e-f0f2-41d4-94a7-5d9e10dd4914"), "هيدوچ", 9 },
                    { 280, new Guid("5bb1e710-75c5-4240-bb1e-846df17d21a4"), "نگور", 9 },
                    { 279, new Guid("a64853df-877f-4564-a557-57f5db0b4b1a"), "نيک شهر", 9 },
                    { 278, new Guid("45fc52bc-a9bf-4cbf-afbc-298a9a766f0e"), "نوک آباد", 9 },
                    { 277, new Guid("26693061-ce86-44da-b8b7-920d052b1b7b"), "نصرت آباد", 9 },
                    { 276, new Guid("3b1281da-e300-4a60-9b56-e903ea9abde6"), "ميرجاوه", 9 },
                    { 275, new Guid("4e3e16cc-9243-490c-a606-3f68389fefb2"), "مهرستان", 9 },
                    { 274, new Guid("a6581505-fda5-4c22-98d4-b4fa3da3c6ea"), "محمدي", 9 },
                    { 273, new Guid("5076d825-dbb4-4a64-a0cf-8a1b454224c7"), "محمدان", 9 },
                    { 272, new Guid("8d1e1a23-0247-474e-a8f6-90f334cf4c38"), "محمد آباد", 9 },
                    { 271, new Guid("50d0dcec-6daa-471d-ab9a-45c56a58b018"), "قصر قند", 9 },
                    { 270, new Guid("c4e07e1a-eed2-4465-8bfd-01a262bd9959"), "فنوج", 9 },
                    { 285, new Guid("2126ddb1-fbca-43b0-8e1d-7fb5ed2633b2"), "گشت", 9 },
                    { 269, new Guid("5857781f-221a-4df4-8724-02c832e2430c"), "علي اکبر", 9 },
                    { 286, new Guid("6a058e13-00b9-47f1-8871-b6df3304b9d4"), "گلمورتي", 9 },
                    { 288, new Guid("71c23bd4-ffe4-41a7-bcdc-7336ded1b367"), "آيسک", 10 },
                    { 303, new Guid("5cfc856a-9f4d-4a4e-8ce5-aa168e89b7ec"), "شوسف", 10 },
                    { 302, new Guid("c3277a7b-207f-4b77-98ea-792f47467461"), "سه قلعه", 10 },
                    { 301, new Guid("6a4eda47-f693-45c1-9f98-7a3ec50ecacf"), "سربيشه", 10 },
                    { 300, new Guid("651292e9-3172-4444-b091-76bf660e95fa"), "سرايان", 10 },
                    { 299, new Guid("adf6c59c-b36d-4285-b296-b6a12898eede"), "زهان", 10 },
                    { 1241, new Guid("6a6e3ffb-ff68-4f02-9908-493cd7280a23"), "گراب سفلي", 31 },
                    { 297, new Guid("0bfd8f7a-00b8-4c68-b946-1ec4df41d96e"), "خوسف", 10 },
                    { 296, new Guid("23f8f65a-7c72-4f21-a8d2-f43bf35d8157"), "خضري دشت بياض", 10 },
                    { 295, new Guid("83ebb16e-44b3-4ef2-81c0-9a232668073f"), "حاجي آباد", 10 },
                    { 294, new Guid("418d9eed-ccf6-4aae-8f2f-3bb410acf68a"), "بيرجند", 10 },
                    { 293, new Guid("e30c23cf-6018-4ea3-9339-1f531995c570"), "بشرويه", 10 },
                    { 292, new Guid("09616f50-0f81-4d42-bea8-1f34aab2a8e1"), "اسلاميه", 10 },
                    { 291, new Guid("28953e1c-8a3f-4ee2-9729-b3ac1d6497c3"), "اسفدن", 10 },
                    { 290, new Guid("365b07d9-2af4-433b-8673-fe50b0f13515"), "اسديه", 10 },
                    { 289, new Guid("65ea07ee-15c3-404c-8527-67fd2fe19c4d"), "ارسک", 10 },
                    { 287, new Guid("dc22b62f-f2ea-490e-9e26-7fee81cce5ae"), "آرين شهر", 10 },
                    { 268, new Guid("9967e57f-b19d-48e2-9feb-ef8abb978190"), "سيرکان", 9 },
                    { 267, new Guid("29e68cdf-dc2b-48c0-8f0c-b1dddbfed8ad"), "سوران", 9 },
                    { 266, new Guid("db729b7a-3bd9-4622-abe9-60d9a67c28e4"), "سرباز", 9 },
                    { 245, new Guid("51b91167-cf8b-43dd-badc-1b8aec338df9"), "کدکن", 8 },
                    { 244, new Guid("16ed6204-b4f3-42f1-b652-8ba434e64caa"), "کاشمر", 8 },
                    { 243, new Guid("8b2806b1-e805-4cd6-a8ce-4f10a46450d1"), "کاريز", 8 },
                    { 242, new Guid("e1c7d1f4-11d4-4194-80e7-6162c50532a4"), "کاخک", 8 },
                    { 241, new Guid("1cc69b75-678e-47bf-91de-bd5e65f18c6c"), "چکنه", 8 },
                    { 240, new Guid("b11d9949-b483-4681-8659-cc5cd252d464"), "چناران", 8 },
                    { 239, new Guid("2e4a5a7d-6fa7-436d-9c6d-5685c4a9c047"), "چاپشلو", 8 },
                    { 238, new Guid("5899f015-07e2-4760-8340-2ac3eda89799"), "يونسي", 8 },
                    { 237, new Guid("b47e1c49-e830-4e5f-8c74-b622a342425e"), "همت آباد", 8 },
                    { 236, new Guid("8ad595c0-c7f6-4156-a30f-a180f8690544"), "نيل شهر", 8 },
                    { 235, new Guid("0d1dae66-a3b6-40b6-a9ae-d4eb8e034f43"), "نيشابور", 8 },
                    { 234, new Guid("96acc1c1-1c55-436c-80f6-938fdde5cc68"), "نوخندان", 8 },
                    { 233, new Guid("d60e2276-b488-4f36-9b4c-e15b694cdb95"), "نقاب", 8 },
                    { 232, new Guid("9468a2a0-ef6c-48d7-8dc9-8b8da2103145"), "نصرآباد", 8 },
                    { 231, new Guid("afbda8f7-a216-4937-bbf9-633d83257daf"), "نشتيفان", 8 },
                    { 246, new Guid("f12ee44e-5f86-4bbb-93d5-b5125b0ab5d6"), "کلات", 8 },
                    { 247, new Guid("de32e4d6-3d24-49e6-825c-aa286bdac736"), "کندر", 8 },
                    { 248, new Guid("a5393a82-549b-4579-9034-53d2f092c5b3"), "گلمکان", 8 },
                    { 249, new Guid("a3d5f71e-13ca-443a-a493-883764f49c56"), "گناباد", 8 },
                    { 265, new Guid("28c13cbf-9a4a-4c9f-822c-7913aa2cfd93"), "سراوان", 9 },
                    { 264, new Guid("95e78243-c3bd-42a4-a7e3-0b9706ed25ab"), "زهک", 9 },
                    { 263, new Guid("836a8dfc-6748-4663-a2c5-6ff22d7b45e4"), "زرآباد", 9 },
                    { 262, new Guid("dd96d35f-db25-414f-af4c-ec8aff438b10"), "زاهدان", 9 },
                    { 261, new Guid("f4915a48-fb4f-45ab-bde6-bf557724cb2b"), "زابل", 9 },
                    { 260, new Guid("72a57f86-e984-4852-bbe9-c8aacd289c8d"), "راسک", 9 },
                    { 259, new Guid("5927bcc6-89b7-4bbe-91bf-20b4eff6d52b"), "دوست محمد", 9 },
                    { 154, new Guid("508c5674-07fd-403e-919a-2ccb47dbf3b9"), "سيمينه", 7 },
                    { 258, new Guid("07b49c2c-a313-47d6-aada-88b440914120"), "خاش", 9 },
                    { 256, new Guid("62e8376d-d371-4361-81df-2b9029ac5c9c"), "بنجار", 9 },
                    { 255, new Guid("26f0e173-2940-4a96-b765-0ca376e8d271"), "بنت", 9 },
                    { 254, new Guid("3e629cc7-5668-40e4-81d9-3aa5c528ebc5"), "بمپور", 9 },
                    { 253, new Guid("2a943847-e609-4ff2-ac9d-6ab251eeaf5c"), "بزمان", 9 },
                    { 252, new Guid("baf10ae7-8975-42b1-8086-860ec2c00bf5"), "ايرانشهر", 9 },
                    { 251, new Guid("79dd453a-c12d-4956-adf4-acbd5912354d"), "اسپکه", 9 },
                    { 250, new Guid("a5026b49-0a7a-4c48-94e5-fc563b7279e1"), "اديمي", 9 },
                    { 257, new Guid("2089d82f-4070-4979-b0ff-68f719080898"), "جالق", 9 },
                    { 153, new Guid("c8bc3847-be25-4e72-9961-233a6f3160fa"), "سيلوانه", 7 },
                    { 152, new Guid("247bd122-37ce-4b63-9385-12177d50acea"), "سلماس", 7 },
                    { 151, new Guid("8780c97d-bdd7-4f96-91a8-94ac9614a76e"), "سرو", 7 },
                    { 54, new Guid("d503aee1-582e-4cd6-9a90-943c767b8f92"), "پردنجان", 2 },
                    { 53, new Guid("e615edc9-1eb0-4153-8155-457bb6a66184"), "وردنجان", 2 },
                    { 52, new Guid("65085428-69f7-4e56-9c9e-f28cd838d19f"), "هفشجان", 2 },
                    { 51, new Guid("0371c76d-77ea-44fe-a06f-d8fa5b1e8c18"), "هاروني", 2 },
                    { 50, new Guid("a783b01d-aabf-4ef7-a824-94b010a251b6"), "نقنه", 2 },
                    { 49, new Guid("6877f169-9522-4b40-97bb-9cc97b092834"), "نافچ", 2 },
                    { 48, new Guid("4a80f1e4-96d6-42ca-9219-fb885e0d1a6b"), "ناغان", 2 },
                    { 47, new Guid("a93a8597-b4c1-439e-80ad-efe06e59ebaa"), "منج", 2 },
                    { 46, new Guid("c73e4dc7-f04d-4e4d-8e41-f6e94069051a"), "مال خليفه", 2 },
                    { 45, new Guid("79ccf551-e9e0-4bec-b99b-73a1bc1bea74"), "لردگان", 2 },
                    { 44, new Guid("64765315-47b7-4e08-bee1-ea5ca041eee2"), "فرخ شهر", 2 },
                    { 43, new Guid("04524b7a-6229-4122-b2bc-a0d7f172d05c"), "فرادنبه", 2 },
                    { 42, new Guid("5726af28-08eb-45e2-b4e7-66b093c7ab94"), "فارسان", 2 },
                    { 41, new Guid("c03a6adf-40a0-41d7-8ec6-903d7d1bf22b"), "طاقانک", 2 },
                    { 40, new Guid("3b06b7da-9ab9-4470-9e43-79e1086b6f76"), "صمصامي", 2 },
                    { 55, new Guid("af6e6713-1717-49d5-b8c7-6d7208226a7c"), "چليچه", 2 },
                    { 39, new Guid("b2769d82-7904-4ad9-87db-2b23a1c515a2"), "شهرکرد", 2 },
                    { 56, new Guid("92e05250-a276-4bea-8d1d-3a3d78b51746"), "چلگرد", 2 },
                    { 58, new Guid("edf1cf5e-9205-4359-87ac-ed6c4e887177"), "کيان", 2 },
                    { 73, new Guid("a357d563-c218-4719-8066-036a9165e483"), "سنخواست", 3 },
                    { 72, new Guid("03745525-5ece-4258-ad68-ae03d3f53cee"), "زيارت", 3 },
                    { 71, new Guid("12e3415e-f0f6-49c2-8c4f-12cd6daf646e"), "راز", 3 },
                    { 70, new Guid("604f2465-7a01-4ba5-a33b-06bd39a5f07c"), "درق", 3 },
                    { 69, new Guid("41affb3b-f54c-42ca-8aa2-372a77c2492d"), "حصارگرمخان", 3 },
                    { 68, new Guid("d70e6e64-bff0-435d-a999-3d0a310c084f"), "جاجرم", 3 },
                    { 67, new Guid("98ea86d5-ae69-4be5-94a4-495876e5a76d"), "تيتکانلو", 3 },
                    { 66, new Guid("916ee359-64a4-4869-9749-f4cd8a2bdaee"), "بجنورد", 3 },
                    { 65, new Guid("4c32208d-fc35-40bb-8429-4210fbd206ae"), "ايور", 3 },
                    { 64, new Guid("77698ddb-cb50-456d-b280-7bc6ca4d75ae"), "اسفراين", 3 },
                    { 63, new Guid("59689a3e-1189-4803-ac68-0b61948f5b40"), "آوا", 3 },
                    { 62, new Guid("6f66f774-f445-4a7e-9537-aa620f39e929"), "آشخانه", 3 },
                    { 61, new Guid("702ce335-470f-4167-af40-18b838272066"), "گوجان", 2 },
                    { 60, new Guid("00bbbe8a-f6eb-4add-8411-6226e9d53246"), "گهرو", 2 },
                    { 59, new Guid("730d7c44-2785-4f34-bb7b-a8e20cdff3e9"), "گندمان", 2 },
                    { 57, new Guid("7e97f867-800d-4308-99b9-7767a1fb34de"), "کاج", 2 },
                    { 38, new Guid("1f304711-c757-4adb-a399-24150d6e5fa1"), "شلمزار", 2 },
                    { 37, new Guid("c7752a9a-9317-4b1a-a92e-ead2c37a825e"), "سورشجان", 2 },
                    { 36, new Guid("a58a0b34-9562-490b-82d9-89a9da7017df"), "سودجان", 2 },
                    { 15, new Guid("1e7bd121-0514-4e3b-bda4-339156584daa"), "مهردشت", 1 },
                    { 14, new Guid("a52f6bd5-0b2b-4223-9f14-ca7dbe0f7428"), "مروست", 1 },
                    { 13, new Guid("bee98245-1ef8-4e09-a356-b2e50c973f08"), "عقدا", 1 },
                    { 12, new Guid("779e41fe-c016-4357-88f0-2a43487fe0d0"), "شاهديه", 1 },
                    { 11, new Guid("e298a81c-d904-493b-b5a7-0aea58877e86"), "زارچ", 1 },
                    { 10, new Guid("08d68545-c1f6-41d0-8eef-df313e1e018d"), "خضر آباد", 1 },
                    { 9, new Guid("5289a507-faf5-4ffc-b76c-23ab7607b4bd"), "حميديا", 1 },
                    { 8, new Guid("6da2c336-0278-4dbd-8828-08851cc8d353"), "تفت", 1 },
                    { 7, new Guid("fc006726-6379-4af2-9d3f-0a7a79fe7e91"), "بهاباد", 1 },
                    { 6, new Guid("f4583b06-ed84-401f-b9ee-971cce5bd166"), "بفروئيه", 1 },
                    { 5, new Guid("726d368b-1558-45b2-9ece-eb2e9393a13f"), "بافق", 1 },
                    { 4, new Guid("1d320e5c-5690-4fc8-871c-130c7074d33b"), "اشکذر", 1 },
                    { 3, new Guid("b53b7ba4-956e-455d-bb53-f53fa5b9be57"), "اردکان", 1 },
                    { 2, new Guid("0133b2f4-66a9-4e64-baf0-545dbfb8f2d2"), "احمد آباد", 1 },
                    { 1, new Guid("7187f858-d24e-4249-8ef2-b93e5ecd54b5"), "ابرکوه", 1 },
                    { 16, new Guid("b5be2f04-f89d-49b8-85a1-4d49e0ab2f5e"), "مهريز", 1 },
                    { 17, new Guid("05f8490d-7e85-43e6-88df-72ad2aef42c7"), "ميبد", 1 },
                    { 18, new Guid("aa033d92-cfbe-4400-9fb5-e87e29450e45"), "ندوشن", 1 },
                    { 19, new Guid("2de77a42-b36c-420d-837b-590561a09c87"), "نير", 1 },
                    { 35, new Guid("454ad99f-4681-4ffe-8488-856784f0ea9a"), "سفيد دشت", 2 },
                    { 34, new Guid("427042fd-5590-4b4c-bd05-8c5a7a418e94"), "سردشت لردگان", 2 },
                    { 33, new Guid("3c7fe8da-6b4f-49e1-ad1f-89312fbfbc91"), "سرخون", 2 },
                    { 32, new Guid("c6593aad-7bcb-48f5-a0aa-1889744e4c59"), "سامان", 2 },
                    { 31, new Guid("17e44ad6-dc5a-4b46-a347-a72ce5662912"), "دشتک", 2 },
                    { 30, new Guid("21990ab7-cace-4907-be13-a5db824087d4"), "دستناء", 2 },
                    { 29, new Guid("bdf8d514-b7a3-4520-9d18-d04a40364846"), "جونقان", 2 },
                    { 74, new Guid("7eb5b48a-9c47-403e-a683-8ab810db088e"), "شوقان", 3 },
                    { 28, new Guid("3ffb10a8-efb5-4e42-b397-c4170b8c2644"), "بن", 2 },
                    { 26, new Guid("5f80de6a-0ebc-495d-b6f4-f3b0cee3701b"), "بروجن", 2 },
                    { 25, new Guid("281784ab-5386-404c-adaa-5fecc0e30cfe"), "بازفت", 2 },
                    { 24, new Guid("c5eab1b2-95d4-41a1-8a44-278ef60e4316"), "باباحيدر", 2 },
                    { 23, new Guid("3c8bb835-3e02-41b9-b37b-a472e82afe5c"), "اردل", 2 },
                    { 22, new Guid("08b52477-70eb-4e8b-9703-530c2bfbd592"), "آلوني", 2 },
                    { 21, new Guid("2d2c5044-b262-4475-8b1e-294dc6a03c6a"), "يزد", 1 },
                    { 20, new Guid("55984f82-03c7-48cd-a37b-6783e912e11a"), "هرات", 1 },
                    { 27, new Guid("7ef72c15-57f0-4fe1-8528-77d0934a6644"), "بلداجي", 2 },
                    { 304, new Guid("cbc31504-f144-4b80-9ec6-f7311554f7eb"), "طبس", 10 },
                    { 75, new Guid("a44bf599-270f-4a1a-9696-490a5afa361d"), "شيروان", 3 },
                    { 77, new Guid("3fc1cef5-1613-4345-a975-c02cacb51090"), "فاروج", 3 },
                    { 131, new Guid("d1483200-5ec0-465c-9d49-68c337844907"), "پيرتاج", 6 },
                    { 130, new Guid("d667afa3-2a60-4ac3-a9b6-242258eb24de"), "ياسوکند", 6 },
                    { 129, new Guid("0609de35-ad70-4a83-99ca-3a4ff753e2b6"), "موچش", 6 },
                    { 128, new Guid("cc743db8-246e-492a-89bb-d1ae1aea7552"), "مريوان", 6 },
                    { 127, new Guid("1de2ebef-aab5-4221-a207-f3e2f500f693"), "قروه", 6 },
                    { 126, new Guid("262b905b-6cbf-47cd-9a01-e75a8e561e9d"), "صاحب", 6 },
                    { 125, new Guid("9ad2aef4-5fe6-49fb-a84a-0e9628fceb7c"), "شويشه", 6 },
                    { 124, new Guid("4e173164-a477-412a-b78c-a7da7c0d652d"), "سنندج", 6 },
                    { 123, new Guid("3b64d3f6-35a8-4e36-9c2b-131f856b4d9a"), "سقز", 6 },
                    { 122, new Guid("f9c10745-abc0-43e9-9950-cf52006b15f5"), "سريش آباد", 6 },
                    { 121, new Guid("da886080-09b0-4dbf-9cb7-0f6d7987308c"), "سرو آباد", 6 },
                    { 120, new Guid("d152f48a-baec-4300-acc8-fab8878f6af7"), "زرينه", 6 },
                    { 119, new Guid("37e64588-2014-4503-a8ea-b6cb5fcf6bf6"), "ديواندره", 6 },
                    { 118, new Guid("44ad3d59-244e-4745-bec8-51dd45703382"), "دهگلان", 6 },
                    { 117, new Guid("199f14d9-295e-4681-a70d-2849950dbb33"), "دلبران", 6 },
                    { 132, new Guid("952f007f-d13a-4088-a47c-e65280aa9f25"), "چناره", 6 },
                    { 116, new Guid("c7fd4ede-8afa-4f9b-8410-2100d3ab0dbe"), "دزج", 6 },
                    { 133, new Guid("b65a1862-0161-46c2-9e81-7489a439cc96"), "کامياران", 6 },
                    { 135, new Guid("84a51b24-3d1e-42f6-88cd-5f23a95c2a41"), "کاني سور", 6 },
                    { 150, new Guid("49a660b0-bfc0-412a-b35a-d41c686e914f"), "سردشت", 7 },
                    { 149, new Guid("2c4ce996-a9ac-4403-a829-58679c289d9e"), "زرآباد", 7 },
                    { 148, new Guid("d7ef8b38-8877-467b-ab17-26bb9858317b"), "ربط", 7 },
                    { 147, new Guid("b6dfd1ac-7aca-43c2-8ea8-eff497c039f9"), "ديزج ديز", 7 },
                    { 146, new Guid("3fc218cc-f802-45de-bf86-abdf9315ede0"), "خوي", 7 },
                    { 145, new Guid("bdd23e61-0051-437c-8159-884f2811a8ab"), "خليفان", 7 },
                    { 144, new Guid("00a52406-4b4c-42ff-a5bb-a8a7f6e7aa91"), "تکاب", 7 },
                    { 143, new Guid("75b1555b-5eaa-4f6f-a5ab-36d5659719b6"), "تازه شهر", 7 },
                    { 142, new Guid("21ac8af6-2ae8-4abb-951c-b427d369cc59"), "بوکان", 7 },
                    { 141, new Guid("390d073c-db4a-462e-991e-59fc5f45242e"), "بازرگان", 7 },
                    { 140, new Guid("f0b9296c-1b98-4565-8da0-2e8e0c61c4f4"), "باروق", 7 },
                    { 139, new Guid("9b95e291-639d-4cf2-b7b0-c5e2035d71ac"), "ايواوغلي", 7 },
                    { 138, new Guid("364d20d7-7c44-450c-9b43-99f4f33107fd"), "اشنويه", 7 },
                    { 137, new Guid("2947d8b0-b37a-4b22-8ac4-0dfa4ba6f315"), "اروميه", 7 },
                    { 136, new Guid("0d410aea-c4a0-41d9-aee3-e7c4e89e2a72"), "آواجيق", 7 },
                    { 134, new Guid("2b1d05ea-f69a-47e7-a13b-61a5b3881b06"), "کاني دينار", 6 },
                    { 115, new Guid("d440cdf3-584f-47e6-9b4a-d8e10999bcad"), "توپ آغاج", 6 },
                    { 114, new Guid("ba2f743b-5f8c-4414-beea-9159d7512369"), "بيجار", 6 },
                    { 113, new Guid("3424cbe2-eed2-4fdd-9988-43834ee46791"), "بوئين سفلي", 6 },
                    { 92, new Guid("2474c70e-292a-432b-84d4-f2feeee901c7"), "مشکين دشت", 4 },
                    { 91, new Guid("c4ad0983-4fdd-4360-8f56-dd69a4e5b22a"), "محمد شهر", 4 },
                    { 90, new Guid("111dcc16-5928-4ddc-b6a2-2a2970db60ab"), "ماهدشت", 4 },
                    { 89, new Guid("b84573dd-0fed-404c-b81f-9f77bf0fc69c"), "فرديس", 4 },
                    { 88, new Guid("5f5871e7-7569-4f0f-a580-1d2beebd4d6a"), "طالقان", 4 },
                    { 87, new Guid("c338251c-cc23-4e41-a759-c798504a0538"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("4e4cc489-3f5b-4090-872b-437774438d23"), "تنکمان", 4 },
                    { 85, new Guid("1e6aa654-b388-4ef2-9f30-fa651ec8ca89"), "اشتهارد", 4 },
                    { 84, new Guid("7a7cac9e-0368-4f6c-be9b-ee0d0cadd6d6"), "آسارا", 4 },
                    { 83, new Guid("90faa839-7e73-42a2-b9d5-234e7c466074"), "گرمه", 3 },
                    { 82, new Guid("9fd29a0d-b137-4e9e-b48e-543c9e380111"), "چناران شهر", 3 },
                    { 81, new Guid("0560d61c-e71b-452e-9426-589dfe0122de"), "پيش قلعه", 3 },
                    { 80, new Guid("8b737450-9189-49f5-88da-4428f31c9e52"), "لوجلي", 3 },
                    { 79, new Guid("d9b9760a-8b88-4e4e-90a9-0d80653d1346"), "قوشخانه", 3 },
                    { 78, new Guid("793c963e-c1f4-406c-849f-40f1281cdf41"), "قاضي", 3 },
                    { 93, new Guid("16ee4f16-1fbf-48d4-b53e-9c06dc92f8c1"), "نظر آباد", 4 },
                    { 94, new Guid("f25a682e-474a-411b-b064-0bb66b0ed409"), "هشتگرد", 4 },
                    { 95, new Guid("d0dcbef7-3429-46a1-b8b1-4d4d4ac8025e"), "چهارباغ", 4 },
                    { 96, new Guid("c48684c9-a278-4d8b-8653-baa339803aad"), "کرج", 4 },
                    { 112, new Guid("85de1e8d-0e47-40d9-805b-a3073c7088e3"), "بلبان آباد", 6 },
                    { 111, new Guid("67ed048c-5e82-4223-87d6-1ea79f0b041b"), "برده رشه", 6 },
                    { 110, new Guid("abbcb073-87da-456c-9345-b83f3f9d9404"), "بانه", 6 },
                    { 109, new Guid("967a58a7-e15e-4a62-8d0b-044748245996"), "بابارشاني", 6 },
                    { 108, new Guid("84238ec1-e793-43db-8f47-2acbba4abfb2"), "اورامان تخت", 6 },
                    { 107, new Guid("0d5c7a90-ac9d-42d5-8e51-1e4d50cb546c"), "آرمرده", 6 },
                    { 106, new Guid("259f3679-2b9a-4de9-a7c6-c0d6291bc9ff"), "کهک", 5 },
                    { 76, new Guid("79513de1-c575-41e5-b05b-6145e5b7220b"), "صفي آباد", 3 },
                    { 105, new Guid("86ad1f83-1745-4bed-8a03-3a96a9eb8751"), "قنوات", 5 },
                    { 103, new Guid("e85006ec-ac43-4ee0-a1a8-fe5ab21f188a"), "سلفچگان", 5 },
                    { 102, new Guid("b85237bc-d83a-4d72-b29e-5b6c1f6cc1a0"), "دستجرد", 5 },
                    { 101, new Guid("995262ca-cf1d-4ed4-b2ca-03ab9eafa40e"), "جعفريه", 5 },
                    { 100, new Guid("5472daaa-e04c-45d0-9f67-ccc8310d4f98"), "گلسار", 4 },
                    { 99, new Guid("37934c59-df9f-4afb-b9b8-0b55735079e0"), "گرمدره", 4 },
                    { 98, new Guid("6d9f3900-ff57-49dd-b31f-e6b6c23777b6"), "کوهسار", 4 },
                    { 97, new Guid("e7cba8f5-0819-44c4-b62f-a6c0202f81ba"), "کمال شهر", 4 },
                    { 104, new Guid("d3e63d7d-1440-47ba-bda1-ec54fe32dff7"), "قم", 5 },
                    { 305, new Guid("e35e376a-053a-4e9b-98f3-6939dab7f5da"), "طبس مسينا", 10 },
                    { 298, new Guid("d39f233a-76fd-4e54-860a-7394ba707aaa"), "ديهوک", 10 },
                    { 307, new Guid("ee0a8bba-665d-408c-97db-15055c46bc9a"), "فردوس", 10 },
                    { 515, new Guid("4d4677b5-b024-4708-ab71-0bbb671b23e1"), "نور", 15 },
                    { 514, new Guid("d1a0c57a-7f10-4648-a248-3eab77ac4357"), "نشتارود", 15 },
                    { 513, new Guid("79d14d50-58eb-40e4-80fd-e803b5a324b7"), "مرزيکلا", 15 },
                    { 512, new Guid("676815ba-67bd-49c0-a3a6-153352c574ce"), "مرزن آباد", 15 },
                    { 511, new Guid("4e346d57-6aa0-4907-b22f-4345b662dbe1"), "محمود آباد", 15 },
                    { 510, new Guid("88f33015-7d6c-4d71-92e6-2e9cc1d694e8"), "قائم شهر", 15 },
                    { 509, new Guid("7eea0085-4fba-4b4d-8d0f-29820802d8df"), "فريم", 15 },
                    { 508, new Guid("0ee53603-e96d-470b-b90b-e6d474657811"), "فريدونکنار", 15 },
                    { 507, new Guid("c5091710-b544-4303-aab5-62484cacbafe"), "عباس آباد", 15 },
                    { 506, new Guid("d48a0d1f-2a42-4b44-bf36-a7fa71e3043d"), "شيرگاه", 15 },
                    { 505, new Guid("af8f4bfc-acec-49fd-8eda-af72798ddb6a"), "شيرود", 15 },
                    { 504, new Guid("299264ec-6d47-478d-a8ec-b938905eb080"), "سورک", 15 },
                    { 503, new Guid("5ed88f39-1611-4e2e-b97d-64b6007a26ce"), "سلمان شهر", 15 },
                    { 502, new Guid("9ae48d9b-851e-4643-8fb3-935ec10ddbf1"), "سرخرود", 15 },
                    { 501, new Guid("985a58df-641d-4790-9c19-c88a25c3c968"), "ساري", 15 },
                    { 516, new Guid("881d9569-2c08-49cd-9b6c-ff5ac7879625"), "نوشهر", 15 },
                    { 500, new Guid("08d10c1b-9f0f-4b3d-b7e8-38992f4b11d8"), "زيرآب", 15 },
                    { 517, new Guid("2c9c7242-3d19-43c6-af6d-5b592c9f9456"), "نکا", 15 },
                    { 519, new Guid("63337ab2-28ba-46f5-9c28-e0219dd50289"), "هچيرود", 15 },
                    { 534, new Guid("ae36f85b-f77d-4316-8803-22ad574da91d"), "گلوگاه", 15 },
                    { 533, new Guid("f5d2b7c9-a391-42b9-a54d-470b2414eedc"), "گزنک", 15 },
                    { 532, new Guid("52ba0fa1-bb4a-40f9-a521-364e6e424d51"), "گتاب", 15 },
                    { 531, new Guid("7efd1edc-a7b6-4ec0-abf1-0c87006e1dd8"), "کياکلا", 15 },
                    { 530, new Guid("55818a72-5058-42bd-a5e7-58d500440582"), "کياسر", 15 },
                    { 529, new Guid("e8f01bf8-2e04-45cc-b6ef-243d2e464516"), "کوهي خيل", 15 },
                    { 528, new Guid("3aed252b-b757-4cb3-9081-6e16674b2d48"), "کلاردشت", 15 },
                    { 527, new Guid("76c18ada-1d9e-4077-beb0-08dfa3f54dd6"), "کلارآباد", 15 },
                    { 526, new Guid("784d8ba6-0fe5-40c7-9875-28864a5f118c"), "کجور", 15 },
                    { 525, new Guid("8393f26d-5cb3-4ce8-9cc2-67ebc406d938"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("4ff01a3f-5c59-41b6-bf74-2b0e9209029d"), "چمستان", 15 },
                    { 523, new Guid("face2bf5-1b2f-48d7-b614-ae3bd9c75e76"), "چالوس", 15 },
                    { 522, new Guid("4d30e1c2-d377-4e9e-a745-e264a1b7b168"), "پول", 15 },
                    { 521, new Guid("290aa856-0c9a-4fd9-b5f7-2bbeefa5379b"), "پل سفيد", 15 },
                    { 520, new Guid("6da513e4-7c73-4b9b-877c-2d764821063f"), "پايين هولار", 15 },
                    { 518, new Guid("2f812583-758e-44f7-89af-b47fc8f7c4a5"), "هادي شهر", 15 },
                    { 499, new Guid("31f1f3bf-300c-4f40-8851-9d581cf3983c"), "زرگر محله", 15 },
                    { 498, new Guid("f73d1f76-6062-469f-bdbf-5cacecd2e764"), "رينه", 15 },
                    { 497, new Guid("b52746f0-94ab-4dfa-8a10-7c323b33c146"), "رويان", 15 },
                    { 476, new Guid("12cb9e27-17e5-4e39-be9f-fc86451355e5"), "گميش تپه", 14 },
                    { 475, new Guid("d8901d39-b577-45f5-800d-ca2f67e4423b"), "گرگان", 14 },
                    { 474, new Guid("b52f96cd-75e1-4098-9b3c-52c08890b6dc"), "گاليکش", 14 },
                    { 473, new Guid("178f07cd-a70a-4d10-af78-589ee23a79cd"), "کلاله", 14 },
                    { 472, new Guid("13dfdc28-3a3f-4bb7-abc9-0654f4f8ead1"), "کرد کوي", 14 },
                    { 471, new Guid("8cdeba81-02bd-4a6f-af2a-c7cc36dfd5fa"), "نگين شهر", 14 },
                    { 470, new Guid("89040afe-fcd8-4d86-bc61-97d1c21d6012"), "نوکنده", 14 },
                    { 469, new Guid("f5855730-2bb7-4099-a872-74c313b40e11"), "نوده خاندوز", 14 },
                    { 468, new Guid("7ec980df-43b6-43e9-9286-a863cc42abf0"), "مينودشت", 14 },
                    { 306, new Guid("03c5dd1f-459c-4351-b22d-414499bcc78b"), "عشق آباد", 10 },
                    { 466, new Guid("77c5cdc5-37ea-4e6f-b946-e9647f064b89"), "مراوه تپه", 14 },
                    { 465, new Guid("d83eedc0-378a-4231-b783-72f87d819492"), "فراغي", 14 },
                    { 464, new Guid("dc84549c-df8e-4d16-963b-79828d41df7f"), "فاضل آباد", 14 },
                    { 463, new Guid("6188b96e-1117-42bf-ae4f-46baa42ca21a"), "علي آباد", 14 },
                    { 462, new Guid("99561557-deec-4ccf-bd0b-5e8bafdf814a"), "سيمين شهر", 14 },
                    { 477, new Guid("6e2043aa-37c6-4ea6-aede-697baef56f71"), "گنبدکاووس", 14 },
                    { 478, new Guid("021883c8-a28f-4570-9ddc-d48e4374d383"), "آلاشت", 15 },
                    { 479, new Guid("d19a3abb-f7ef-49ef-a248-b3afc98cef5a"), "آمل", 15 },
                    { 480, new Guid("a0496573-3b14-4f6e-aa8e-e7cb0b3bc09e"), "ارطه", 15 },
                    { 496, new Guid("f3e0c9df-042c-40b8-8343-ace3836f3b2d"), "رستمکلا", 15 },
                    { 495, new Guid("6ef46ec9-d86c-45ad-ad71-55a36266bb48"), "رامسر", 15 },
                    { 494, new Guid("e82d30ce-ff45-48dc-ab3f-87fafffb1b95"), "دابودشت", 15 },
                    { 493, new Guid("62619076-8eec-4e7a-a8a7-5495d17b7c9e"), "خوش رودپي", 15 },
                    { 492, new Guid("5d0c60d4-3944-4847-b221-a0d5765e29c9"), "خليل شهر", 15 },
                    { 491, new Guid("04f79590-8416-496a-9a88-1c1ec35ee388"), "خرم آباد", 15 },
                    { 490, new Guid("700d2508-9573-428d-b1a1-c64f44a6fc6d"), "جويبار", 15 },
                    { 535, new Guid("2f06e7e7-53d6-4c62-8121-d4e4b9c2e0b0"), "آبيک", 16 },
                    { 489, new Guid("46b278da-af08-4a1a-8051-7e84c9e925ad"), "تنکابن", 15 },
                    { 487, new Guid("319a84ec-0219-41b5-b355-5f43776db603"), "بهشهر", 15 },
                    { 486, new Guid("8101a4f5-f5c9-4201-a7c6-9db3d2a44653"), "بلده", 15 },
                    { 485, new Guid("b72d2396-852c-455d-be5b-47ad4b9108fe"), "بابلسر", 15 },
                    { 484, new Guid("70114619-3797-41f3-a5f0-dfe1cf91d056"), "بابل", 15 },
                    { 483, new Guid("12f936f1-587a-4983-84bc-564edd84f5f8"), "ايزد شهر", 15 },
                    { 482, new Guid("99da31fb-cb11-4cbd-b3f3-e48aab4f0929"), "امير کلا", 15 },
                    { 481, new Guid("4b57fea9-490f-42cf-b494-1f045aca5e79"), "امامزاده عبدالله", 15 },
                    { 488, new Guid("68b7bb8e-1599-40b8-a04a-5df9e6689fb5"), "بهنمير", 15 },
                    { 461, new Guid("4c3986e1-3409-4245-a203-d1de399c2e36"), "سنگدوين", 14 },
                    { 536, new Guid("e1ce7eac-96c0-4a6d-9e6d-8f970fde1c8c"), "آبگرم", 16 },
                    { 538, new Guid("ef571b07-2fcb-49dd-9a27-8e12253a8c5d"), "ارداق", 16 },
                    { 592, new Guid("e9d5ab62-95f0-4e63-9c34-ebd7410f78fb"), "جعفر آباد", 18 },
                    { 591, new Guid("5e4fb466-67a3-4985-b082-7b4d52d73779"), "تازه کند انگوت", 18 },
                    { 590, new Guid("81a16cd8-7b8b-46aa-8728-656509175a01"), "تازه کند", 18 },
                    { 589, new Guid("5e71b7bb-b172-4210-9f0e-905187059e6b"), "بيله سوار", 18 },
                    { 588, new Guid("67bcab5a-c23a-4896-b5ff-2bcd1d5d11c1"), "اصلاندوز", 18 },
                    { 587, new Guid("d4a5e3a2-5847-496a-9c15-09db2826f6c2"), "اسلام آباد", 18 },
                    { 586, new Guid("05293102-7ac3-48fa-a333-119488268904"), "اردبيل", 18 },
                    { 585, new Guid("ce56f755-9457-45bf-99f2-fbb573b760f7"), "آبي بيگلو", 18 },
                    { 584, new Guid("a337b4aa-58be-4636-8ea3-ae904babf0f3"), "گراب", 17 },
                    { 583, new Guid("d3204316-e0cd-45bf-a84f-8bf692e4420d"), "کوهناني", 17 },
                    { 582, new Guid("705b19c1-53ce-4767-a43f-06ef8f635065"), "کوهدشت", 17 },
                    { 581, new Guid("898960a8-f032-4107-a08c-c2ee510d1572"), "چقابل", 17 },
                    { 580, new Guid("8c177f7f-8307-4453-bf28-5bebd222d4bb"), "چالانچولان", 17 },
                    { 579, new Guid("d638b899-152e-4216-8551-24516fb0b110"), "پلدختر", 17 },
                    { 578, new Guid("7f376ace-554e-44e5-9f2e-1d3030bcef70"), "ويسيان", 17 },
                    { 593, new Guid("00c9d662-2d66-4eb2-a09f-d8a05a38eb98"), "خلخال", 18 },
                    { 577, new Guid("06e79a9d-e067-468e-8535-7bbb896f3ce2"), "هفت چشمه", 17 },
                    { 594, new Guid("a5d55706-b8f8-466b-a1ee-beffdf314bfc"), "رضي", 18 },
                    { 596, new Guid("ee603479-12e0-4654-8411-2ab1b808daaf"), "عنبران", 18 },
                    { 611, new Guid("b46733f6-d10a-457e-9a3b-1b3d90472b4c"), "آران و بيدگل", 19 },
                    { 610, new Guid("7b1b42ca-15ab-499c-93d7-085805395d26"), "گيوي", 18 },
                    { 609, new Guid("7d231693-be34-4036-9615-a7e9e646c42e"), "گرمي", 18 },
                    { 608, new Guid("14d02f9b-aa7e-4023-975a-c423fc2c84b4"), "کورائيم", 18 },
                    { 607, new Guid("c700dfa7-6bb0-4277-a190-8789f1e12769"), "کلور", 18 },
                    { 606, new Guid("85814de1-275c-45fd-b534-ca163b4dfb97"), "پارس آباد", 18 },
                    { 605, new Guid("6efa2357-0754-4a22-8320-12cd14a49fe6"), "هير", 18 },
                    { 604, new Guid("fa96ce3e-85f4-44a6-8aae-3610c035e5e4"), "هشتجين", 18 },
                    { 603, new Guid("4f909a2f-e2ee-40c2-a4ea-bc9376b1233d"), "نير", 18 },
                    { 602, new Guid("2810b9e9-5c6c-4057-b99d-8ea7e480fb21"), "نمين", 18 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 601, new Guid("539d9926-2b73-44d7-a4ce-f09ad5c9756e"), "مشگين شهر", 18 },
                    { 600, new Guid("7329e281-e8b9-4ae9-9dbc-ab779ae0a0ad"), "مرادلو", 18 },
                    { 599, new Guid("642ec83e-bf71-4a46-83b5-a4792d3e2544"), "لاهرود", 18 },
                    { 598, new Guid("a395f1b3-4a41-4fe9-ac22-459a5035c119"), "قصابه", 18 },
                    { 597, new Guid("422ae478-ff23-4a18-9179-af55938244ad"), "فخرآباد", 18 },
                    { 595, new Guid("e35f45e7-0999-4f29-a908-2cc0138dda01"), "سرعين", 18 },
                    { 576, new Guid("64d6aca3-12c5-4e0a-9f55-995ab4820c20"), "نورآباد", 17 },
                    { 575, new Guid("00a4b37a-6e21-4a6e-b484-6d6100dbf7ba"), "مومن آباد", 17 },
                    { 574, new Guid("ebede61d-b2e2-40bc-b5f6-69f8537f0c26"), "معمولان", 17 },
                    { 553, new Guid("ceaec1e1-058f-4542-acae-193d36868cb7"), "ضياء آباد", 16 },
                    { 552, new Guid("2c5ef571-85ac-45bd-9359-6f774fdb13af"), "شريفيه", 16 },
                    { 551, new Guid("2c47257f-3c97-4aaf-8a42-56eb6de107bd"), "شال", 16 },
                    { 550, new Guid("48551e6e-9a09-40e4-8249-ffd2ea6810a5"), "سگز آباد", 16 },
                    { 549, new Guid("2a7c5812-845b-4754-8b54-dc8848b80cc7"), "سيردان", 16 },
                    { 548, new Guid("7fb0aae2-33db-44a0-a1c2-ccdc2c4ae13c"), "رازميان", 16 },
                    { 547, new Guid("127eed9b-6ea5-47a8-b1ab-5c7aa71ef9ff"), "دانسفهان", 16 },
                    { 546, new Guid("06fb3432-5674-4301-a374-87b8c8a717e3"), "خرمدشت", 16 },
                    { 545, new Guid("8c97b20d-f5c4-4e18-9fed-cca15ef624f3"), "خاکعلي", 16 },
                    { 544, new Guid("d9fbe609-ba21-480f-a306-9f2b3ad70691"), "تاکستان", 16 },
                    { 543, new Guid("ae2967f0-d18f-45d9-bc1d-ff47f577d574"), "بيدستان", 16 },
                    { 542, new Guid("9b8b9f4c-582b-4b19-b328-23ca1484362a"), "بوئين زهرا", 16 },
                    { 541, new Guid("c484d1c7-da2e-44e1-8088-7725615f6834"), "الوند", 16 },
                    { 540, new Guid("a73c38e2-8e41-4ee8-bdbd-35eb2b47ce2e"), "اقباليه", 16 },
                    { 539, new Guid("9cbf97b2-4297-4834-926e-66a8852b5c81"), "اسفرورين", 16 },
                    { 554, new Guid("c587a92a-1dc2-438c-b591-74809c6bfbe3"), "قزوين", 16 },
                    { 555, new Guid("6d688473-3cd2-4231-a5c8-968275afaa5f"), "محمديه", 16 },
                    { 556, new Guid("feafe0c8-af8c-47e6-a63d-d0f17efcc524"), "محمود آباد نمونه", 16 },
                    { 557, new Guid("cc6ab22d-35fd-49ae-8755-88fd9916ac0c"), "معلم کلايه", 16 },
                    { 573, new Guid("1687829d-a5df-49f4-8a90-697ed06afb9b"), "فيروزآباد", 17 },
                    { 572, new Guid("58d62fd1-f3b3-4697-b673-4361a96f9ab9"), "شول آباد", 17 },
                    { 571, new Guid("60d46d60-e0be-478d-a290-82b9171fcb7a"), "سپيد دشت", 17 },
                    { 570, new Guid("a22c3030-9710-443d-b7be-7a4bc0f65357"), "سراب دوره", 17 },
                    { 569, new Guid("88834e68-7f7d-4e42-ab81-8c3a96e69a45"), "زاغه", 17 },
                    { 568, new Guid("32823b74-8251-4b64-ba45-daebd8b1ad73"), "دورود", 17 },
                    { 567, new Guid("7c6f869b-41cb-42e1-9839-8a1264e65ffb"), "درب گنبد", 17 },
                    { 537, new Guid("a22743ab-fba1-477b-bd26-6b3856bbeee3"), "آوج", 16 },
                    { 566, new Guid("24f2ff5d-ae9d-4c6a-a878-fadd5dd11587"), "خرم آباد", 17 },
                    { 564, new Guid("7a7956fb-453c-4678-8c62-94fa47fc6281"), "بروجرد", 17 },
                    { 563, new Guid("7d076f89-7a05-4416-9e2e-8621c55048a5"), "اليگودرز", 17 },
                    { 562, new Guid("450773c3-76a2-4de0-8067-0d2ef83e3e7f"), "الشتر", 17 },
                    { 561, new Guid("f3ac7c7b-1d37-4c3f-8bb9-e9ef26e25eda"), "اشترينان", 17 },
                    { 560, new Guid("3a2cf586-303a-4ede-9838-6996fd7a065e"), "ازنا", 17 },
                    { 559, new Guid("c3903e66-0d7f-4e8f-8bd9-04b34a161211"), "کوهين", 16 },
                    { 558, new Guid("a3ed7907-6ee2-4896-a1e3-06222c661b2f"), "نرجه", 16 },
                    { 565, new Guid("3db00578-8406-4396-bd2c-3c48e503d36d"), "بيرانشهر", 17 },
                    { 460, new Guid("de7e10a6-13f3-4bd1-88db-0510c2a0e17a"), "سرخنکلاته", 14 },
                    { 467, new Guid("c113fea6-2d71-4454-8169-bddc34ed4bc2"), "مزرعه", 14 },
                    { 458, new Guid("df9d5ef7-d8cf-4ca2-b487-b250567a3698"), "دلند", 14 },
                    { 361, new Guid("7d813fec-99ba-46cc-96c8-bcd4a4ae033d"), "شوش", 11 },
                    { 360, new Guid("5cdf7187-6db7-4a98-a337-fdfe37716639"), "شهر امام", 11 },
                    { 359, new Guid("cdee0b22-1948-4fef-8fed-5a5170412c82"), "شمس آباد", 11 },
                    { 358, new Guid("b3165eb2-1b98-4fdf-8e5d-b94cb3d25ca4"), "شرافت", 11 },
                    { 357, new Guid("c560160b-1bdf-4c0d-aac6-a5262521640e"), "شاوور", 11 },
                    { 356, new Guid("b29ebe6d-b7fe-4002-bb3d-6b34dd45f6c5"), "شادگان", 11 },
                    { 355, new Guid("29a16a4b-4507-4ef1-a3a3-ce1fc4b7c63d"), "سياه منصور", 11 },
                    { 354, new Guid("28cbee81-c3e5-45d6-8416-2dc39b8f5b86"), "سوسنگرد", 11 },
                    { 353, new Guid("4b7cf5ba-3f71-4c7a-9979-9cd0038f281a"), "سماله", 11 },
                    { 352, new Guid("a57ef143-5de3-419e-9fe9-0c9a56c38ef7"), "سردشت", 11 },
                    { 351, new Guid("3d0dd218-a215-459a-8841-75e145c3c93e"), "سرداران", 11 },
                    { 350, new Guid("94f789ef-89e5-481f-b1b5-21096655ae8f"), "سالند", 11 },
                    { 349, new Guid("48c4e07b-fc66-4eb2-8f5b-54177097ad75"), "زهره", 11 },
                    { 348, new Guid("66943c18-960d-4eb3-8ba2-07dae2cc753e"), "رفيع", 11 },
                    { 347, new Guid("9911fdda-9a3d-4915-a793-d80740f61572"), "رامهرمز", 11 },
                    { 362, new Guid("a3503d74-eaa3-40a0-b808-f00af2d75198"), "شوشتر", 11 },
                    { 346, new Guid("63c78f18-8074-4a65-a807-6f583355ec46"), "رامشير", 11 },
                    { 363, new Guid("1507e2a9-fac5-46d0-b62e-e5adb4509265"), "شيبان", 11 },
                    { 365, new Guid("4e476fd8-11ac-4cfc-b4dc-8f5dec0b6c33"), "صفي آباد", 11 },
                    { 380, new Guid("e7dec3e3-c1fd-46a2-ad37-10683744ddb2"), "هنديجان", 11 },
                    { 379, new Guid("c3cd3aeb-1377-4bed-bcc2-9ecdd83160c4"), "هفتگل", 11 },
                    { 378, new Guid("a8dbbd3a-9eb4-4ed8-8345-fbaf2e72089a"), "مينوشهر", 11 },
                    { 377, new Guid("401c452e-2f7f-4de3-ad68-53cdabdcfc19"), "ميداود", 11 },
                    { 376, new Guid("77653697-219e-4334-a7ab-8a7c2f60dc6a"), "ميانرود", 11 },
                    { 459, new Guid("f74aba08-4b57-4610-9f57-f92a33ff1a14"), "راميان", 14 },
                    { 374, new Guid("0f6945c7-0f49-4b70-a535-5238db81cc35"), "ملاثاني", 11 },
                    { 373, new Guid("dcb6e0a8-64b3-4c84-9920-6ca7e6730e24"), "مقاومت", 11 },
                    { 372, new Guid("c95c0691-1212-40b5-a899-0c27a9ba2526"), "مشراگه", 11 },
                    { 371, new Guid("2b3c4642-ef0d-4cb2-9808-b6f230d94dfe"), "مسجد سليمان", 11 },
                    { 370, new Guid("b1bde694-d836-45ba-95e4-f7d1762ac4f6"), "لالي", 11 },
                    { 369, new Guid("0284fe4e-742c-432f-a4ac-9871dec569e0"), "قلعه خواجه", 11 },
                    { 368, new Guid("48d588bf-38ad-459d-ba4b-ab71704b348c"), "قلعه تل", 11 },
                    { 367, new Guid("6ac54e0f-9aa6-4c24-b4ed-83b657461004"), "فتح المبين", 11 },
                    { 366, new Guid("c1620478-6f8d-4ed0-805f-b571e1cfab59"), "صيدون", 11 },
                    { 364, new Guid("ed00a53d-04a9-49ad-b70d-ae47dbd2b0ed"), "صالح شهر", 11 },
                    { 345, new Guid("9b896bf6-44fc-4faa-a783-ea3eb6c1244d"), "دهدز", 11 },
                    { 344, new Guid("468cef23-f01a-4b06-adf1-0cd556b079b5"), "دزفول", 11 },
                    { 343, new Guid("4110f54b-c99b-496a-a036-57a9162f4cbc"), "دارخوين", 11 },
                    { 322, new Guid("21925af5-18dc-4b09-8e2a-34cc7f737044"), "الوان", 11 },
                    { 321, new Guid("1a896e63-9863-4548-9dc5-d9ed88648ecc"), "الهايي", 11 },
                    { 320, new Guid("295c8f79-033b-45f2-892d-370400380187"), "اروند کنار", 11 },
                    { 319, new Guid("6eb48d47-fdf9-4ee0-9f95-b662c0c6d16e"), "ابوحميظه", 11 },
                    { 318, new Guid("22044dd3-1aaf-4eed-9a44-5d8f0512920d"), "آغاجاري", 11 },
                    { 317, new Guid("eb5a610f-d21f-469c-9db3-dd2b4076fff7"), "آزادي", 11 },
                    { 316, new Guid("20044d87-d573-4062-8eda-c27407ef0505"), "آبژدان", 11 },
                    { 315, new Guid("a255b58e-77ec-4c5a-a093-caabb6fc6b9e"), "آبادان", 11 },
                    { 314, new Guid("10dd14c5-1baf-499d-9d5e-8e62e111595b"), "گزيک", 10 },
                    { 313, new Guid("8306b3fc-e139-4424-a512-709d2ca4a191"), "نيمبلوک", 10 },
                    { 312, new Guid("acf7a976-8685-48dd-b20b-bc190a3dac40"), "نهبندان", 10 },
                    { 311, new Guid("17b7443c-8769-465f-b0b4-9033675527e1"), "مود", 10 },
                    { 310, new Guid("45e8c811-c452-457e-b3dc-6b3dabb64d06"), "محمدشهر", 10 },
                    { 309, new Guid("524c93c2-06bc-460d-9df8-223d38452918"), "قهستان", 10 },
                    { 308, new Guid("c2f45335-82c9-4939-b02b-d5491e9cb4b2"), "قائن", 10 },
                    { 323, new Guid("36dccfa5-021f-4c45-bd1b-1e6883ea0330"), "اميديه", 11 },
                    { 324, new Guid("8568d10f-0314-49f0-80e8-dfa0983b38ce"), "انديمشک", 11 },
                    { 325, new Guid("a0080716-5786-44fa-b80a-718da2cd91f9"), "اهواز", 11 },
                    { 326, new Guid("091cf1a3-2ad9-4a52-bb2a-b202b98c2fc1"), "ايذه", 11 },
                    { 342, new Guid("17bd1408-a2e8-4339-b170-25acd45efa3e"), "خنافره", 11 },
                    { 341, new Guid("fc6c5742-e8d2-4209-a673-d842bec9c613"), "خرمشهر", 11 },
                    { 340, new Guid("03acfa26-08b1-41c8-b260-d1d3466935c6"), "حميديه", 11 },
                    { 339, new Guid("a6df042e-f752-42b3-b78c-82f51d35c964"), "حمزه", 11 },
                    { 338, new Guid("5ca50171-06ae-4406-b441-13f370ba0651"), "حسينيه", 11 },
                    { 337, new Guid("1ace072e-b3c3-4eb7-a822-1f9f34174325"), "حر", 11 },
                    { 336, new Guid("06b45b30-60a8-432a-8b3d-bab493edf5d1"), "جنت مکان", 11 },
                    { 381, new Guid("4d46e59d-afa5-4960-87aa-8faf4e03cf49"), "هويزه", 11 },
                    { 335, new Guid("ca02c188-b4ce-4b10-b0c1-c48277c2b049"), "جايزان", 11 },
                    { 333, new Guid("86ef4c53-4357-413c-be07-d01dddedf20f"), "ترکالکي", 11 },
                    { 332, new Guid("d2ca7503-579b-492d-8692-ab7c3b56f64f"), "بيدروبه", 11 },
                    { 331, new Guid("c9b32d4d-646c-4f89-ad70-36aaa03121fb"), "بهبهان", 11 },
                    { 330, new Guid("5be293b9-a5a0-41f0-8400-ae6a17974ffc"), "بندر ماهشهر", 11 },
                    { 329, new Guid("a5410e9e-032b-4247-8031-61f2afcf1f00"), "بندر امام خميني", 11 },
                    { 328, new Guid("c5f21145-f438-40a7-bd4d-3ab78b5ed280"), "بستان", 11 },
                    { 327, new Guid("92b763a3-1448-4db9-967d-aa6a1add2755"), "باغ ملک", 11 },
                    { 334, new Guid("c16f9dd2-2b4b-446a-aa85-f9ceffe6f97b"), "تشان", 11 },
                    { 382, new Guid("f276d29b-0857-469c-bfc1-3ed279b4ad5c"), "ويس", 11 },
                    { 375, new Guid("ccfce818-d0dc-4ada-b0dd-d0c824b72b74"), "منصوريه", 11 },
                    { 384, new Guid("69809861-2847-4435-b3e5-26fdfb028c4c"), "چم گلک", 11 },
                    { 438, new Guid("0eb9c308-919a-4a5e-9069-4437d90bc5ac"), "سلطانيه", 13 },
                    { 437, new Guid("4847eb0f-981f-48a3-8b33-e39e2d99cd8f"), "سجاس", 13 },
                    { 436, new Guid("a1f8bf28-3415-4ee4-860b-3bd074d9b56d"), "زنجان", 13 },
                    { 435, new Guid("e3f5a649-e44f-4765-a6a9-9f308f5d7f16"), "زرين رود", 13 },
                    { 434, new Guid("6da230bb-2e61-40c8-b488-c752ea9ff8af"), "زرين آباد", 13 },
                    { 433, new Guid("e0231821-b4a6-4b6d-b37d-62ca88037d23"), "دندي", 13 },
                    { 432, new Guid("ceb275c5-58e0-4fe1-9298-ecc956a88c84"), "خرمدره", 13 },
                    { 431, new Guid("3fe19cf8-4eec-4ce1-932e-cfb53aea0490"), "حلب", 13 },
                    { 430, new Guid("f1008c64-3bca-43c8-bd16-b19e7cd2c6a2"), "ارمخانخانه", 13 },
                    { 383, new Guid("12af6086-f67e-49be-b376-56843038ad4c"), "چغاميش", 11 },
                    { 428, new Guid("5468ca4d-e441-4d87-8b4d-a8d9bd4a9f97"), "آب بر", 13 },
                    { 427, new Guid("afb1903b-3ce7-44e7-a536-6209a3e1fe4a"), "کلمه", 12 },
                    { 426, new Guid("64ceb402-c319-4dcd-ab75-763fd16843a4"), "کاکي", 12 },
                    { 425, new Guid("103f84fd-3970-48ab-8dd4-64dc204eeeba"), "چغادک", 12 },
                    { 424, new Guid("6f0a2b3b-87d2-4727-ab0a-dbbaf3e96371"), "وحدتيه", 12 },
                    { 439, new Guid("d434ed7a-b469-4577-bf45-a674ce399463"), "سهرورد", 13 },
                    { 423, new Guid("83549578-4fc6-4744-bfa6-9fff0ee94609"), "نخل تقي", 12 },
                    { 440, new Guid("30616a3d-3dc3-499d-acfb-9344472f1ff9"), "صائين قلعه", 13 },
                    { 442, new Guid("81fcbf5c-9deb-4a38-b495-e7aad79e51f9"), "ماه نشان", 13 },
                    { 457, new Guid("1f237066-fdeb-427e-b63e-ed454386cf61"), "خان ببين", 14 },
                    { 456, new Guid("9c1e2028-5b74-4e86-ad5a-4afb2b4f9351"), "جلين", 14 },
                    { 455, new Guid("04e682fe-2110-47fa-a01b-f023f4df1431"), "تاتار عليا", 14 },
                    { 454, new Guid("952840fd-2980-4e36-a182-08ed882a99a3"), "بندر گز", 14 },
                    { 453, new Guid("ebe2e11b-d0e4-4622-b41d-d4683ccee032"), "بندر ترکمن", 14 },
                    { 452, new Guid("ab220c4b-63f7-4b5b-ba1e-74ce3cf16c0e"), "اينچه برون", 14 },
                    { 451, new Guid("e28ab987-827f-4611-a036-deeb0761f227"), "انبار آلوم", 14 },
                    { 450, new Guid("b8ff1ed9-6c28-4c8d-8cd1-023bfa8cfcf7"), "آق قلا", 14 },
                    { 449, new Guid("8a7200c4-be66-468e-a08b-5156efc4f706"), "آزاد شهر", 14 },
                    { 448, new Guid("997c1a92-deca-46a0-87a9-112534721cea"), "گرماب", 13 },
                    { 447, new Guid("b74eb647-68d4-4be9-9f35-975d8b54a1d0"), "کرسف", 13 },
                    { 446, new Guid("eb437a91-c5b7-44cb-ac01-803c92a05c35"), "چورزق", 13 },
                    { 445, new Guid("60bb20b7-3d1f-42ee-8616-e37c6e980a66"), "هيدج", 13 },
                    { 444, new Guid("bc19454f-da8b-474f-bdfc-72400e604506"), "نيک پي", 13 },
                    { 443, new Guid("2d6b6139-c628-4547-bdd4-056fb7545fe6"), "نوربهار", 13 },
                    { 441, new Guid("43f4f87a-46be-47c2-8f37-d328c2848b9a"), "قيدار", 13 },
                    { 422, new Guid("63e42e3c-c496-4d4a-a20a-6ac0f9287cf2"), "عسلويه", 12 },
                    { 429, new Guid("5d2170cd-8eaf-4138-91a4-d7697eddb26a"), "ابهر", 13 },
                    { 420, new Guid("49bb26f9-e740-4d89-8cb5-8c14a669f450"), "شبانکاره", 12 },
                    { 399, new Guid("ca4f1197-5102-48df-a385-c2c8b2c7b737"), "برازجان", 12 },
                    { 398, new Guid("b4667547-0941-42d3-af5c-ccdb20d37800"), "بادوله", 12 },
                    { 397, new Guid("f9b46795-bfd3-453c-b64f-0cc89bdee51a"), "اهرم", 12 },
                    { 396, new Guid("ae992a3e-51d6-4937-94cb-ac80559caa28"), "انارستان", 12 },
                    { 395, new Guid("3128afcc-0bfd-4f9f-b46a-e72fc2878428"), "امام حسن", 12 },
                    { 421, new Guid("4859f62a-2f94-4cf3-a468-d8759279599c"), "شنبه", 12 },
                    { 393, new Guid("56964975-bf90-4983-93d6-d3ebf50f2085"), "آبدان", 12 },
                    { 392, new Guid("b1b75724-796f-413c-b86a-0f57258c9a64"), "آباد", 12 },
                    { 391, new Guid("45313b57-46c2-447e-b501-e022274907a6"), "گوريه", 11 },
                    { 390, new Guid("a21a4926-4afd-4bca-a689-ac5f306f9068"), "گلگير", 11 },
                    { 389, new Guid("5cd67722-2a1c-4c36-b5b2-6b60932a5392"), "گتوند", 11 },
                    { 388, new Guid("229dc5e1-d821-4b97-84a1-b501925e52c0"), "کوت عبدالله", 11 },
                    { 387, new Guid("0795fbd7-cfa3-467c-b5d4-dd5d200b28bb"), "کوت سيدنعيم", 11 },
                    { 386, new Guid("e3749b35-058c-4c6b-9b10-dfe0618415e4"), "چوئبده", 11 },
                    { 385, new Guid("e98e338a-97fd-41d8-ad71-e84ba55c78bc"), "چمران", 11 },
                    { 400, new Guid("0ffc4328-fa16-4c86-b829-2f4cc757ab3c"), "بردخون", 12 },
                    { 401, new Guid("e33cd49f-1fc1-4197-8a6b-ad8c273fd4b6"), "بردستان", 12 },
                    { 394, new Guid("50bd6875-c171-4ff3-98c6-0e91cdb33ede"), "آبپخش", 12 },
                    { 403, new Guid("89b9b432-3a8f-47d4-b2c1-763c5cbe02f0"), "بندر ديلم", 12 },
                    { 402, new Guid("7221b101-b4d2-4ba7-9583-73b392a4f81d"), "بندر دير", 12 },
                    { 418, new Guid("9b1c320f-2841-48c5-b7c3-54e2a04a9576"), "سعد آباد", 12 },
                    { 417, new Guid("19d912a4-bee8-4928-bb67-5ad1a9156da4"), "ريز", 12 },
                    { 416, new Guid("aef4e328-d3c7-4ee9-bbb7-c0e53e477d50"), "دوراهک", 12 },
                    { 415, new Guid("9c02548f-4e79-4770-a7b1-b4f85980ac91"), "دلوار", 12 },
                    { 414, new Guid("39b8b04a-aa40-4275-843d-2d3c7e119fa4"), "دالکي", 12 },
                    { 413, new Guid("7037396c-26f9-4d6e-93c2-1277b14e1d47"), "خورموج", 12 },
                    { 412, new Guid("5c968251-9654-4745-b89a-36719048faca"), "خارک", 12 },
                    { 419, new Guid("8127bab3-39c2-4460-b190-e21b331db3c2"), "سيراف", 12 },
                    { 410, new Guid("8cbd9217-4ff9-41ec-9037-6e2e40cf78b2"), "تنگ ارم", 12 },
                    { 409, new Guid("b9ec4e86-6496-4071-afbc-868eb9a77d84"), "بوشکان", 12 },
                    { 408, new Guid("d7b34614-f7cf-421c-9451-010a334482f6"), "بوشهر", 12 },
                    { 407, new Guid("e332558b-d396-4a3f-92b1-d94a619e750b"), "بنک", 12 },
                    { 406, new Guid("86355e4a-530a-4aac-b56d-f0c6756ac5c7"), "بندر گناوه", 12 },
                    { 405, new Guid("f95cfd94-2e1b-4aea-9601-b7932c7cdab0"), "بندر کنگان", 12 },
                    { 404, new Guid("89ed7ff6-fe86-4d0a-ad25-c77c45fecba5"), "بندر ريگ", 12 },
                    { 411, new Guid("6a708f1c-b2e6-4856-96de-f110e83c4248"), "جم", 12 }
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
                values: new object[] { 1, new DateTime(2020, 5, 29, 1, 34, 59, 192, DateTimeKind.Local).AddTicks(9753), "Kavenegar", 1, new Guid("e6fdd83a-490c-4493-87b8-e669fa2b747a") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 5, null, new Guid("7ac0d14f-9585-444b-b97b-9615b4ddbd07"), null, null, "تاسیسات", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9186), 3, null, 1 },
                    { 31, null, new Guid("6522ca5f-8b10-4cd8-85c7-0905c9018cf7"), null, null, "سرویس و تعمیر خودرو", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9608), 4, null, 3 },
                    { 30, null, new Guid("21554894-bdc0-45df-a60a-ce615048d47b"), null, null, "اجاره خودرو", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9436), 4, null, 2 },
                    { 29, null, new Guid("f59d25b8-895f-412b-8755-d348d2d163e1"), null, null, "اتوبار", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9427), 4, null, 1 },
                    { 21, null, new Guid("dc7fcc15-9322-47d2-9dcb-43922465dd24"), null, null, "کار در ارتفاع", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9361), 3, null, 17 },
                    { 20, null, new Guid("711287ad-2122-4c6a-a27a-87916005747c"), null, null, "آسانسور و بالابر", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9354), 3, null, 16 },
                    { 19, null, new Guid("f776cbb1-e040-4ade-af0e-091d19a39328"), null, null, "نجاری", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9346), 3, null, 15 },
                    { 18, null, new Guid("ebe7af77-2fea-496e-9e9a-102afe277df6"), null, null, "تعمیرات لوازم خانگی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9335), 3, null, 14 },
                    { 16, null, new Guid("f4b2a8b0-fadb-49dd-bee1-2826980bc516"), null, null, "عایق کاری", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9277), 3, null, 12 },
                    { 15, null, new Guid("09c91db2-6c05-45b5-b5c4-bd0093edf9cd"), null, null, "عایق کاری", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9270), 3, null, 11 },
                    { 17, null, new Guid("3073382c-f4e7-4966-a001-ca9c6e4fa50e"), null, null, "نرده و حفاظ استیل", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9328), 3, null, 13 },
                    { 13, null, new Guid("8fbf3417-098e-4844-ab4c-7c014f0f9b8d"), null, null, "بنایی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9253), 3, null, 9 },
                    { 12, null, new Guid("b7aa3ee5-afb8-4555-9d3e-d1136ec363f0"), null, null, "دکوراسیون داخلی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9245), 3, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[] { 11, null, new Guid("f8cbd1f1-26d4-4fe1-9698-81e5d739b003"), null, null, "کابینت سازی", null, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9237), 3, null, 7 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 10, null, new Guid("f0e125b0-cbe1-4b4f-a636-fd31178c1881"), null, null, "شیشه بری و قابسازی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9226), 3, null, 6 },
                    { 9, null, new Guid("7b96f6d6-c001-4412-acc0-3007cde27439"), null, null, "آلومینیوم سازی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9218), 3, null, 5 },
                    { 8, null, new Guid("ae898e28-f6ea-4535-b6d7-9d95afaaeb02"), null, null, "مبلمان", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9210), 3, null, 4 },
                    { 7, null, new Guid("198bc3fa-efff-4229-8bae-f2fbe75aed8d"), null, null, "ایمنی و امنیت", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9202), 3, null, 3 },
                    { 6, null, new Guid("af409ed3-9581-4952-99c2-bfc07e2f6165"), null, null, "الکتریکی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9195), 3, null, 2 },
                    { 14, null, new Guid("a954ad23-d27a-4632-8c3a-e709cbd2f432"), null, null, "آهنگری", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9261), 3, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 1, 34, 59, 193, DateTimeKind.Local).AddTicks(5496), "VerifyAccount", 1, new Guid("2f165281-e595-45e9-ae38-e7f3336f86fa") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "GenderCodeID", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "ProfileDocumentID", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 4, "white.luciferrr@gmail.com", "محمد", 8, true, true, "میرزایی", new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(4512), "09147830093", null, new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(4509), 2, new Guid("de610b68-4de2-48d2-88a5-540fd9839d03") },
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", 8, true, true, "رودکی", new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(933), "09227204305", null, new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(347), 1, new Guid("a47960bf-4335-4268-b457-20e03813f081") },
                    { 2, "roozbehshamekhi@hotmail.com", "روزبه", 8, true, true, "شامخی", new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(4371), "09128277075", null, new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(4339), 3, new Guid("eafda0e4-6d11-46de-8a39-246dd95b9e8f") },
                    { 3, "dead.hh98@gmail.com", "حامد", 8, true, true, "حقیقیان", new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(4497), "09108347428", null, new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(4492), 2, new Guid("55f92d87-cedb-4053-a092-cf35e9f77da5") }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "AdminGUID", "IsDelete", "ModifiedDate", "UserID" },
                values: new object[] { 1, new Guid("f3c0f475-64a3-401e-991e-c4608fbcaed5"), false, new DateTime(2020, 5, 29, 1, 34, 59, 196, DateTimeKind.Local).AddTicks(7256), 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "Sort" },
                values: new object[,]
                {
                    { 22, null, new Guid("fb66d2b7-8afe-45fd-a7cd-d2eba4d2809e"), null, null, "سرویس کولر آبی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9370), 5, null, 1 },
                    { 23, null, new Guid("0d00732a-eec0-43fd-859e-2ca038caf8ec"), null, null, "نقاشی ساختمان", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9378), 5, null, 2 },
                    { 24, null, new Guid("42f18bf4-c6b2-4478-be2d-5149f7f00bff"), null, null, "رنگ کاری مبل", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9386), 8, null, 1 },
                    { 25, null, new Guid("435e7b98-d3fd-408b-913e-f87d14114ce4"), null, null, "تعمیر صندلی اداری", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9394), 8, null, 2 },
                    { 26, null, new Guid("d512d33d-0e47-47b8-88df-c9dd3fc7e705"), null, null, "ساخت مبلمان", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9401), 8, null, 3 },
                    { 27, null, new Guid("be98f269-04c6-4be3-9729-1a88fba330e9"), null, null, "دوخت کاور مبل", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9412), 8, null, 4 },
                    { 28, null, new Guid("4b12b8e8-4c93-43a9-9825-e3a2e33461be"), null, null, "تعمیر مبل", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9420), 8, null, 5 },
                    { 32, null, new Guid("42be4e96-fbd6-4a75-8e83-096c3e835322"), null, null, "وانت بار", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9619), 29, null, 1 },
                    { 33, null, new Guid("881ab67c-b018-4cf8-9f29-4c8382f7d5cd"), null, null, "باربری و اتوبار", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9626), 29, null, 2 },
                    { 34, null, new Guid("bf62a619-2b7b-4bca-a922-0c3d714fb246"), null, null, "کارگر اسباب کشی", null, true, new DateTime(2020, 5, 29, 1, 34, 59, 201, DateTimeKind.Local).AddTicks(9634), 29, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "CityID", "ClientGUID", "ModifiedDate", "UserID" },
                values: new object[] { 1, 750, new Guid("8cdac401-e651-4df3-b91b-00249f89b2d8"), new DateTime(2020, 5, 29, 1, 34, 59, 197, DateTimeKind.Local).AddTicks(3416), 2 });

            migrationBuilder.InsertData(
                table: "Contractor",
                columns: new[] { "ContractorID", "AverageRate", "BusinessTypeCodeID", "CityID", "ContractorGUID", "Credit", "Latitude", "Longitude", "ModifiedDate", "UserID" },
                values: new object[,]
                {
                    { 1, 0.0, 4, 750, new Guid("da7e4e7c-c119-409b-86fb-1321443f702b"), 0, "1", "2", new DateTime(2020, 5, 29, 1, 34, 59, 198, DateTimeKind.Local).AddTicks(6559), 3 },
                    { 2, 0.0, 4, 750, new Guid("da73f690-b6ec-4552-b605-f3bbd6aa0f01"), 10000, "1", "2", new DateTime(2020, 5, 29, 1, 34, 59, 198, DateTimeKind.Local).AddTicks(7842), 4 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderID", "CategoryID", "ClientID", "Comment", "ContractorID", "Cost", "DeadlineDate", "Description", "ModifiedDate", "OrderGUID", "Rate", "StateCodeID", "Title" },
                values: new object[] { 1, 14, 1, "", null, null, null, "توضیح", new DateTime(2020, 5, 29, 1, 34, 59, 199, DateTimeKind.Local).AddTicks(5605), new Guid("a007cc56-fb08-49e2-808c-0305ba587245"), 0.0, 9, "تیتر" });

            migrationBuilder.InsertData(
                table: "OrderRequest",
                columns: new[] { "OrderRequestID", "ContractorID", "IsAllow", "Message", "ModifiedDate", "OfferedPrice", "OrderID", "OrderRequestGUID" },
                values: new object[] { 1, 1, true, "پیام", new DateTime(2020, 5, 29, 1, 34, 59, 200, DateTimeKind.Local).AddTicks(4063), 250000L, 1, new Guid("78f6b078-76d3-4b98-be1f-59ab49decbbc") });

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
