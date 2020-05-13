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
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    RoleID = table.Column<int>(nullable: false),
                    GenderCodeID = table.Column<int>(nullable: true),
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
                        name: "FK_User_Role",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
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
                    Credit = table.Column<long>(nullable: false),
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
                    { 1, new Guid("c265fd02-0194-4d38-83e8-a93bc3698fcc"), "سایت اصلی", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(1716), null, 1 },
                    { 10, new Guid("dec37f17-0ab2-4208-8ba7-11cc1120369b"), "وبلاگ", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2935), null, 2 }
                });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "CodeGroupID", "CodeGroupGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("5b739a57-164e-4b39-8b1c-1129bc9d8991"), "نوع فایل", "FilepondType" },
                    { 2, new Guid("2d9c9e83-39eb-42d7-b71f-ef26002c8470"), "نوع کسب و کار", "BusinessType" },
                    { 3, new Guid("a76da3ba-d12a-42c4-b7e1-732d0990af70"), "جنسیت", "Gender" },
                    { 4, new Guid("39c56245-8e42-4cef-8ddd-5e4c17782e8b"), "وضعیت سفارش", "OrderState" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("81f6284e-5c1b-4439-9b30-31bbc34715de") },
                    { 20, "ايلام", new Guid("4e8f110e-77ee-4a23-9f98-695ef33f2817") },
                    { 21, "تهران", new Guid("d4a2dbb7-0005-447a-868a-af9ca3c9c4dc") },
                    { 22, "آذربايجان شرقي", new Guid("de130a5a-e6d0-4d7e-8510-cdf4c0ae3fef") },
                    { 23, "فارس", new Guid("8abac150-0f8c-4e27-847e-a0a76e45335f") },
                    { 24, "کرمانشاه", new Guid("c92891d0-80f8-491f-b407-b731d55d12c4") },
                    { 27, "گيلان", new Guid("d0988005-2c82-49fc-8853-121fa7962cd2") },
                    { 26, "مرکزي", new Guid("a2b1750e-4bcd-47dc-9371-8db3d16b87a1") },
                    { 18, "اردبيل", new Guid("959c7e74-844f-44a9-a088-1898d58b047c") },
                    { 28, "همدان", new Guid("b02e2d10-e6e0-47b9-be90-1c7b70af604e") },
                    { 29, "کرمان", new Guid("d9a25708-7b09-4bca-8bca-10cad88e22d3") },
                    { 30, "سمنان", new Guid("e9f7563a-bc8e-453e-ad50-3b22f1f5525d") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("9e66fb65-3b11-4355-bee0-66c0ad5e51d0") },
                    { 25, "هرمزگان", new Guid("1b6655d3-10d0-458e-8287-7b499a7f7c07") },
                    { 17, "لرستان", new Guid("ea074cb1-2471-4cec-a8a8-bdb90dcad2e9") },
                    { 15, "مازندران", new Guid("d13be1a7-ec08-4a12-90a4-33e7b9dce89d") },
                    { 6, "کردستان", new Guid("ca392395-0851-4d0d-8773-79592171699a") },
                    { 14, "گلستان", new Guid("2d4c47fb-f541-4379-a3c0-c4321645c950") },
                    { 13, "زنجان", new Guid("9d7e57fe-ecbd-40fc-9f8b-01517fd25b03") },
                    { 12, "بوشهر", new Guid("5dbde226-8e64-4259-998e-03e1f82f7d5b") },
                    { 11, "خوزستان", new Guid("c0adf33d-6373-40a5-affb-d42d11532a3e") },
                    { 10, "خراسان جنوبي", new Guid("308c1040-ab5c-48cd-b75f-6019f65ac673") },
                    { 9, "سيستان و بلوچستان", new Guid("b02b3284-197c-405f-b56e-f036dab6bcf8") },
                    { 8, "خراسان رضوي", new Guid("3f66ab42-2634-4f45-ac18-482d15d500db") },
                    { 7, "آذربايجان غربي", new Guid("b0e80aad-a959-459e-892f-381aa785df77") },
                    { 16, "قزوين", new Guid("5ff04f99-8c91-4bec-a594-e468ef1c06b7") },
                    { 5, "قم", new Guid("d29e98b3-e823-49ea-b9a8-f1f752a2b7bd") },
                    { 4, "البرز", new Guid("142f9f01-6325-41d4-a509-54fceb3e6560") },
                    { 3, "خراسان شمالي", new Guid("5b4a6119-83f2-49cb-b230-fdbcbda2b07c") },
                    { 2, "چهار محال و بختياري", new Guid("23364df4-3302-4eeb-9fa4-9ba041d0373d") },
                    { 1, "يزد", new Guid("cd8abccd-155a-47d4-8ed5-249d78fa5787") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 2, "سرویس دهنده", new DateTime(2020, 5, 13, 16, 10, 2, 843, DateTimeKind.Local).AddTicks(2973), "Contractor", new Guid("4da0dd90-6d3f-4e51-8f20-1ecfb43605bb") },
                    { 3, "سرویس گیرنده", new DateTime(2020, 5, 13, 16, 10, 2, 843, DateTimeKind.Local).AddTicks(3008), "Client", new Guid("fd10f51b-349f-4541-b807-703070cb1ca6") },
                    { 1, "ادمین", new DateTime(2020, 5, 13, 16, 10, 2, 843, DateTimeKind.Local).AddTicks(1947), "Admin", new Guid("688a0f62-d3a5-4741-b176-f1b4cd237637") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 5, 13, 16, 10, 2, 837, DateTimeKind.Local).AddTicks(7888), "ptcoptco", new Guid("936bdd9a-830e-4d30-aafa-cae06382516c"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 2, new Guid("1c8acdb2-15e3-4db0-a8ae-d1533b780a24"), "ابزار و لوازم صنعتی", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2833), 1, 1 },
                    { 3, new Guid("52724edc-9a22-453c-abec-308fcb527e5e"), "مصنوعات صنعتی", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2869), 1, 2 },
                    { 4, new Guid("181fc922-c0da-4687-91cf-6746dafa1476"), "کالا و خدمات صنعتی", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2887), 1, 3 },
                    { 5, new Guid("45c27674-a827-458c-9782-e3a8b98cc5f1"), "مواد شیمیایی", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2896), 1, 4 },
                    { 6, new Guid("01e15243-86d0-4c5e-b87a-7f23fd9debc8"), "دستگاه و ماشین آلات", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2905), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 827, new Guid("79bff91a-5d22-4fbc-a38a-b3940294f1ae"), "مبارک شهر", 22 },
                    { 826, new Guid("82c0841d-7c3c-467f-961c-7784262035f0"), "ليلان", 22 },
                    { 825, new Guid("b8b3aab5-175d-46a0-9bf1-2c78de5b70c7"), "قره آغاج", 22 },
                    { 824, new Guid("d2b18836-51f1-43ea-8222-012ac5f82486"), "عجب شير", 22 },
                    { 823, new Guid("42c28b6c-c5d7-443f-895d-57a4e74004b8"), "صوفيان", 22 },
                    { 822, new Guid("bd7150a4-9c01-4869-9a39-c8278b459ea4"), "شهر جديد سهند", 22 },
                    { 821, new Guid("ba00983b-64bb-490c-93dc-205a2f35964a"), "شند آباد", 22 },
                    { 818, new Guid("da006f06-25d5-42ce-a4a4-2aef1735f941"), "شبستر", 22 },
                    { 819, new Guid("443f2ec5-c176-44f8-9284-9a7707f6b05e"), "شربيان", 22 },
                    { 828, new Guid("fbfd3766-84cd-4eb5-b058-6a06e760ab6a"), "مراغه", 22 },
                    { 817, new Guid("3e8e7d4b-38a2-4a0d-b08b-011efd4d9ff9"), "سيه رود", 22 },
                    { 816, new Guid("f08a5d61-7020-4160-8adc-2c8cc4817684"), "سيس", 22 },
                    { 815, new Guid("9acaced1-d4c6-4016-841a-1c305b668bfe"), "سردرود", 22 },
                    { 814, new Guid("9a756151-b367-4af9-899f-98e4036b5373"), "سراب", 22 },
                    { 813, new Guid("5d47622d-8bfc-43f1-90a9-98a94f59a57d"), "زنوز", 22 },
                    { 820, new Guid("af7a4f20-5298-4586-8d65-7f2439ab6678"), "شرفخانه", 22 },
                    { 829, new Guid("a524fc95-0b64-4d9a-8ead-f56d0fab2ea4"), "مرند", 22 },
                    { 832, new Guid("2fd85833-7dfa-4bf4-b1b1-b5ef96f845da"), "مهربان", 22 },
                    { 831, new Guid("8d752669-ae23-414a-8cd1-a7d0e79b0293"), "ممقان", 22 },
                    { 847, new Guid("1fdac8f1-c94f-4347-ba4a-a66d8f481603"), "آباده", 23 },
                    { 846, new Guid("1c585316-4848-4182-96e3-85d144e7e3cb"), "گوگان", 22 },
                    { 845, new Guid("5cd8cc04-be53-4c8f-bd6b-46045574c86a"), "کوزه کنان", 22 },
                    { 844, new Guid("b06c3cbd-5967-45b2-b6e5-25f7ddc9dca4"), "کليبر", 22 },
                    { 843, new Guid("a35ac80a-9e04-4ff1-b496-06ef44f7aa0f"), "کلوانق", 22 },
                    { 842, new Guid("d22cd747-e6ad-4e4c-b978-3ea5c4c73b7f"), "کشکسراي", 22 },
                    { 841, new Guid("4de6c486-fe50-4b3d-b487-33fc6fa93d12"), "يامچي", 22 },
                    { 830, new Guid("b2efbbba-0868-4292-8f1f-762104aaa2c7"), "ملکان", 22 },
                    { 840, new Guid("2aa01fd3-cc6c-4fa2-8a13-de110151eb3d"), "ورزقان", 22 },
                    { 838, new Guid("d2b778f1-a5c1-468b-9b6f-c36da55c9969"), "هوراند", 22 },
                    { 837, new Guid("628a8bd7-5a46-4678-b7c4-a9860fb193cd"), "هشترود", 22 },
                    { 836, new Guid("26216a75-2242-4e50-a1b4-6c9ec64f84e6"), "هريس", 22 },
                    { 835, new Guid("36c47b9f-d154-40ad-966b-fda134baa98e"), "هاديشهر", 22 },
                    { 834, new Guid("eeed34d6-3a41-475f-ae95-fd986b9b21d2"), "نظرکهريزي", 22 },
                    { 833, new Guid("c8770754-e376-4191-8ed7-046d68b129d9"), "ميانه", 22 },
                    { 812, new Guid("851da751-fa01-44ce-b34c-1b4405893035"), "زرنق", 22 },
                    { 839, new Guid("4f1fc8e7-732c-44ff-9f3f-7dcb7dbcb157"), "وايقان", 22 },
                    { 811, new Guid("2b52f25e-5b1b-4210-bcf1-7cd738ce02f8"), "دوزدوزان", 22 },
                    { 809, new Guid("df082ca2-a560-4c0e-8425-9af768853889"), "خمارلو", 22 },
                    { 848, new Guid("da0f1a23-3911-4602-8c7e-34b3163c2bb4"), "آباده طشک", 23 },
                    { 788, new Guid("0451d2f3-d53e-4c9b-924d-b68409d17982"), "آچاچي", 22 },
                    { 787, new Guid("2b80be0c-0822-47ba-be7d-068b143c924f"), "آقکند", 22 },
                    { 786, new Guid("f3aedff7-45ea-4b55-8b71-0f05a6960390"), "آذرشهر", 22 },
                    { 785, new Guid("f3c054c6-a4d5-4de1-ab68-abc008a5a2e5"), "آبش احمد", 22 },
                    { 784, new Guid("87480cd3-eb6e-4665-aba5-af129f939032"), "گلستان", 21 },
                    { 783, new Guid("c9d7cf71-f732-4daa-8fb8-3cf5f15b1504"), "کيلان", 21 },
                    { 782, new Guid("a2390640-d0b1-4d25-bc66-7ab8fce085cd"), "کهريزک", 21 },
                    { 781, new Guid("56507fda-07b5-48e6-a2e0-bb60d9e0c9ec"), "چهاردانگه", 21 },
                    { 780, new Guid("6241afce-bebf-4b10-874a-ee243aabe79e"), "پيشوا", 21 },
                    { 779, new Guid("55b81b3c-95fc-4eb9-bd8a-d0b0b0714f13"), "پرديس", 21 },
                    { 778, new Guid("28c099fd-fee8-47d5-ace7-8c5ab04c895c"), "پاکدشت", 21 },
                    { 777, new Guid("80d60705-93a1-4758-861f-6e5cbfed568d"), "ورامين", 21 },
                    { 776, new Guid("a1ae0f6f-55c8-4f6b-8345-68cab15ced96"), "وحيديه", 21 },
                    { 775, new Guid("bdf8679e-f81c-455f-8493-78b80a40df7d"), "نصيرشهر", 21 },
                    { 774, new Guid("0ce73a9c-1f44-469f-9730-8e5458769260"), "نسيم شهر", 21 },
                    { 789, new Guid("3dd668cd-d682-4f19-b5c9-c52cfad55ffd"), "اسکو", 22 },
                    { 790, new Guid("45560c33-795e-48ff-89de-e39b50de80e2"), "اهر", 22 },
                    { 791, new Guid("aba94526-76b9-4f06-8e7a-406516b2ab08"), "ايلخچي", 22 },
                    { 792, new Guid("dd1ff599-3ad3-4a1c-9fe8-c2884fd30422"), "باسمنج", 22 },
                    { 808, new Guid("967f9a88-3a13-44e3-ba63-8c08e1ac3f09"), "خسروشاه", 22 },
                    { 807, new Guid("33eb6506-4c3e-4288-8659-909a6021b939"), "خداجو", 22 },
                    { 806, new Guid("5d9ec987-be59-4fed-bc11-af5786aefd94"), "خامنه", 22 },
                    { 805, new Guid("fd2b98fe-af00-480a-97af-e46b323b6dc9"), "خاروانا", 22 },
                    { 804, new Guid("4799388e-fd5c-4054-aeb5-b9b7f719310a"), "جوان قلعه", 22 },
                    { 803, new Guid("0594ff75-cdc0-46d8-9a7e-079d9cc50a1d"), "جلفا", 22 },
                    { 802, new Guid("6fa1d8de-06fe-476e-9a33-562f4e62b3d3"), "تيکمه داش", 22 },
                    { 810, new Guid("d7107534-8cc4-4568-8de1-5cc5394661f0"), "خواجه", 22 },
                    { 801, new Guid("8a6d2b22-48ba-40d6-98a1-59f66ed2fb5a"), "تيمورلو", 22 },
                    { 799, new Guid("31ec8790-2d8e-4c3b-805a-360a66bab3ca"), "ترکمانچاي", 22 },
                    { 798, new Guid("cca790f4-e546-459c-a218-574ee78402a3"), "ترک", 22 },
                    { 797, new Guid("43f62cde-f113-44f7-9bcd-444d53a379c2"), "تبريز", 22 },
                    { 796, new Guid("01da080d-ee6b-4f85-920f-c6ef56bfc1ce"), "بناب مرند", 22 },
                    { 795, new Guid("7d440551-1d8a-45e0-bb2a-daa85b0763d5"), "بناب", 22 },
                    { 794, new Guid("3912d6ab-28e0-4298-85f6-2ebf3b66551f"), "بستان آباد", 22 },
                    { 793, new Guid("4d95e511-3f66-41fc-ae5e-77b2a74dfb11"), "بخشايش", 22 },
                    { 800, new Guid("140ccd97-fdb4-4aeb-8cea-7c93da7ec93e"), "تسوج", 22 },
                    { 849, new Guid("5d7ab878-5178-41da-8d26-2dd5c4cefde6"), "اردکان", 23 },
                    { 852, new Guid("b0dfc5db-9c14-403d-a168-61853c32310b"), "اسير", 23 },
                    { 851, new Guid("f6591d7f-b7fc-45d0-b200-65ccd57c7cad"), "استهبان", 23 },
                    { 906, new Guid("fbbf8bfe-c280-4fe3-8cc6-80a76236e44f"), "صفا شهر", 23 },
                    { 905, new Guid("70f57c5c-0323-41bf-900d-aa17086e91ed"), "صغاد", 23 },
                    { 904, new Guid("a5d0982f-c34b-4ee5-a963-e9ec5c45c5da"), "شيراز", 23 },
                    { 903, new Guid("48bf1520-ab60-4519-928f-c6be7389d319"), "شهر پير", 23 },
                    { 902, new Guid("4813916d-00b8-443f-b8d0-826b702d020d"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("bb3779c4-e1a2-4854-b356-786c869117de"), "ششده", 23 },
                    { 900, new Guid("e9bf3206-990b-4e36-bed2-5035ae9b6d38"), "سيدان", 23 },
                    { 899, new Guid("36e7003b-04c9-4373-84e9-924821ec2656"), "سورمق", 23 },
                    { 898, new Guid("c1bb534f-11ea-4e51-8a2b-84a3b1e0329a"), "سلطان شهر", 23 },
                    { 897, new Guid("a3f55d64-a5b1-4a69-9596-206241ac11b2"), "سعادت شهر", 23 },
                    { 896, new Guid("c882aa27-a267-4843-8892-ea7e6c0921c3"), "سروستان", 23 },
                    { 895, new Guid("6f67f4ac-050e-40e0-8586-437d761b3d6b"), "سده", 23 },
                    { 894, new Guid("4c54f8c1-638c-4f80-b7c1-1aa9666f5dd2"), "زرقان", 23 },
                    { 893, new Guid("fc67b4e0-7e05-4084-8292-966122bd57e1"), "زاهد شهر", 23 },
                    { 892, new Guid("f9719da7-d466-4e58-9d1e-53d5050c7d54"), "رونيز", 23 },
                    { 907, new Guid("c7f2ea8c-eb65-4c37-be38-31f95ef8d801"), "علامرودشت", 23 },
                    { 908, new Guid("3d18e212-8a6e-4d9e-a77f-f76f68787f0c"), "عماد ده", 23 },
                    { 909, new Guid("ec4ff013-1e74-4f0e-b9c0-b657e4cac225"), "فدامي", 23 },
                    { 910, new Guid("ecfb16d8-cdcb-43fb-8f78-820d8a8ba502"), "فراشبند", 23 },
                    { 926, new Guid("5a462114-4d11-4592-8b5d-9229c8db177d"), "مزايجان", 23 },
                    { 925, new Guid("f8248a99-7cb3-4170-afc2-9f0a0994b62d"), "مرودشت", 23 },
                    { 924, new Guid("7d753d98-0bbc-46ad-ac5f-0ec7b49af54d"), "مبارک آباد", 23 },
                    { 923, new Guid("c0a8c774-02fc-495d-b6f2-04d84349f48f"), "مادرسليمان", 23 },
                    { 922, new Guid("cb44d098-a713-4722-9817-88ec72b98b05"), "لپوئي", 23 },
                    { 921, new Guid("8b46164b-b5ad-457e-8939-746a3cea7e86"), "لطيفي", 23 },
                    { 920, new Guid("c4953af8-5043-4e6d-9bf9-6d21b2d5c3fb"), "لامرد", 23 },
                    { 891, new Guid("687335b5-377b-46d1-a59b-f4898507d961"), "رامجرد", 23 },
                    { 919, new Guid("87239e09-ec11-47b2-a85e-86615549e55b"), "لار", 23 },
                    { 917, new Guid("cea3a89e-3369-44d3-937d-361a9c0da1a5"), "قطرويه", 23 },
                    { 916, new Guid("ce92010f-ef58-4fdb-9584-871e189833ea"), "قطب آباد", 23 },
                    { 915, new Guid("20b10555-1f0b-4540-91f5-fbde622b289f"), "قره بلاغ", 23 },
                    { 914, new Guid("7a529670-f2d3-4974-afc2-19fc3bfe76e3"), "قادرآباد", 23 },
                    { 913, new Guid("fdc9514f-259d-4130-80f7-09e74eed295e"), "قائميه", 23 },
                    { 912, new Guid("96301f24-ec23-4312-bbbd-7a6026161f66"), "فيروزآباد", 23 },
                    { 911, new Guid("16bd106e-8f29-40c2-af83-061aa40013ef"), "فسا", 23 },
                    { 918, new Guid("26ff7536-6678-40c3-bc8c-30f823b82f91"), "قير", 23 },
                    { 890, new Guid("d0eac999-0264-4c1e-a196-8154dae2ce0d"), "دژکرد", 23 },
                    { 889, new Guid("90af6c4e-f956-4fb0-ab63-7ecfff788d01"), "دوزه", 23 },
                    { 888, new Guid("c565aa11-0d06-42e3-9fba-9a3d6ee2162c"), "دوبرجي", 23 },
                    { 867, new Guid("32603077-4966-473a-92a3-39dae6682d24"), "بيرم", 23 },
                    { 866, new Guid("3088e241-6958-4cc7-ae34-8391a08fbe1b"), "بوانات", 23 },
                    { 865, new Guid("c6c42197-3ab1-4197-96a8-56c3e11495a0"), "بهمن", 23 },
                    { 864, new Guid("33c6c194-7e9c-4fa5-bcbe-3ca65d89c968"), "بنارويه", 23 },
                    { 863, new Guid("240c9656-525f-4da5-98e1-381755f72209"), "بالاده", 23 },
                    { 862, new Guid("95a12615-2768-41e2-926b-a48c8bbf020e"), "بابامنير", 23 },
                    { 861, new Guid("1906ebfb-2044-4f24-a98f-abb3e00962f6"), "باب انار", 23 },
                    { 868, new Guid("60a8e516-f0af-4029-844a-405c1f6311a2"), "بيضا", 23 },
                    { 860, new Guid("a66a90fc-d84f-4a27-8953-0cfe5f3a3106"), "ايزد خواست", 23 },
                    { 858, new Guid("03de6ed6-24ff-42be-bb5b-ffe02bab382f"), "اوز", 23 },
                    { 857, new Guid("22d5fd2d-54a2-4883-b380-3cc31281e16f"), "اهل", 23 },
                    { 856, new Guid("fbd8c771-776e-4868-b2f1-3eb02a58bcb7"), "امام شهر", 23 },
                    { 855, new Guid("f1264c47-b066-4a23-830d-92fdf2fb7072"), "اقليد", 23 },
                    { 854, new Guid("672f0f3d-c772-4210-a150-72b8105e6f3d"), "افزر", 23 },
                    { 853, new Guid("4f0d4cdd-a4fa-49f6-888a-a465c65c4077"), "اشکنان", 23 },
                    { 773, new Guid("aa879867-693f-4f15-ae6d-34a8cc2830ef"), "ملارد", 21 },
                    { 859, new Guid("c074bf88-e057-4ba6-bfe2-cd196c9371d7"), "ايج", 23 },
                    { 850, new Guid("83b8bc54-dcea-476a-81b9-547fdc6f8206"), "ارسنجان", 23 },
                    { 869, new Guid("a3b8fa3f-78cc-4d47-ba4f-fee6dba59b18"), "جنت شهر", 23 },
                    { 871, new Guid("66bc3d87-9a46-48b0-8965-0d93eb1046d5"), "جويم", 23 },
                    { 887, new Guid("5b699b6b-4373-494d-b7a1-854128888ae3"), "دهرم", 23 },
                    { 886, new Guid("450adb92-824c-495d-992f-e0ddf99418cf"), "دبيران", 23 },
                    { 885, new Guid("f2946d73-6605-4815-bcc0-461603a600b6"), "داريان", 23 },
                    { 884, new Guid("ee105af7-9d08-4f3d-87fe-f748a35c81d6"), "داراب", 23 },
                    { 883, new Guid("293e562b-876f-4bac-850f-7746d7084c16"), "خومه زار", 23 },
                    { 882, new Guid("a01adaf3-e6dd-4dea-b80a-9883c080a2f9"), "خوزي", 23 },
                    { 881, new Guid("8fbd9382-8103-4883-aaf1-d75c83f9966e"), "خور", 23 },
                    { 870, new Guid("af17bfee-74cc-4984-b28e-22820218e742"), "جهرم", 23 },
                    { 880, new Guid("fddef854-ba1a-42fd-9c4e-175aef661115"), "خنج", 23 },
                    { 878, new Guid("60d0e58b-f5f9-42c2-a827-8c612fdbacc9"), "خرامه", 23 },
                    { 877, new Guid("afb2fb76-3153-409a-9cc1-3651f8e181bf"), "خاوران", 23 },
                    { 876, new Guid("ae9a396d-866b-4c47-992b-d2dc4d7e02a9"), "خانيمن", 23 },
                    { 875, new Guid("e10e35d2-c011-4f35-8b96-b6181ea2c333"), "خانه زنيان", 23 },
                    { 874, new Guid("026f5f70-059e-405f-8c6a-757300827d25"), "حسن آباد", 23 },
                    { 873, new Guid("9cc7d26e-7e23-4956-b56b-2ea7395ea366"), "حسامي", 23 },
                    { 872, new Guid("a97fbdb0-a1b6-406f-abc1-35cd722d18b0"), "حاجي آباد", 23 },
                    { 879, new Guid("d0d63389-3bd6-4176-875f-d89b6bfbad1f"), "خشت", 23 },
                    { 772, new Guid("03b12807-7b0c-4d47-9675-17edac15c877"), "لواسان", 21 },
                    { 770, new Guid("97405830-f8d1-455c-8432-d817fa020991"), "قدس", 21 },
                    { 927, new Guid("dbb127e2-964e-494f-98d0-c153e8c9aa74"), "مشکان", 23 },
                    { 670, new Guid("b6eb0bbd-5c50-4143-83a2-6daa1888dced"), "علويچه", 19 },
                    { 669, new Guid("ee0c6169-158f-412e-b2aa-b6a9a3b1ab8b"), "عسگران", 19 },
                    { 668, new Guid("4b6f66ec-c7ae-4f2d-bc40-48ce00070d13"), "طرق رود", 19 },
                    { 667, new Guid("6f756d2f-f103-4001-903d-01771b2986bd"), "طالخونچه", 19 },
                    { 666, new Guid("29520bd7-efcb-4fe4-8ed2-8d13b9f5d2c7"), "شهرضا", 19 },
                    { 665, new Guid("2af14857-5809-487a-85ce-4248e9f0555b"), "شاپورآباد", 19 },
                    { 664, new Guid("5cdf976b-c26f-4f11-aade-52f69f465933"), "شاهين شهر", 19 },
                    { 663, new Guid("996d5015-a3f8-4418-bbf5-2ae0851579b6"), "سگزي", 19 },
                    { 662, new Guid("281ae809-edb6-435a-a231-386cd320f3e3"), "سين", 19 },
                    { 661, new Guid("69351fad-eb7f-4c51-996a-21ab63c06127"), "سميرم", 19 },
                    { 660, new Guid("55a44128-8886-4f07-9eb5-ba25a5397010"), "سفيد شهر", 19 },
                    { 659, new Guid("201242f0-a3bb-4d49-aca1-b3be5464dc82"), "سده لنجان", 19 },
                    { 658, new Guid("e1dd9401-6023-4e86-9c78-9358a246d1e5"), "زيباشهر", 19 },
                    { 657, new Guid("03783967-ba5c-45df-bf2a-c1a1025c1b87"), "زيار", 19 },
                    { 656, new Guid("f7e1eb4a-9457-41f8-95e0-f544174b4085"), "زواره", 19 },
                    { 671, new Guid("29ebf507-54b8-4166-9a02-57f7ef404609"), "فرخي", 19 },
                    { 672, new Guid("487b8a83-0e9a-4368-a0ab-9d1582f93067"), "فريدونشهر", 19 },
                    { 673, new Guid("325e801f-f132-460f-9a24-23f44f7d91f6"), "فلاورجان", 19 },
                    { 674, new Guid("ffa0d1a4-066e-4b49-b2c5-edd1345c4fbb"), "فولاد شهر", 19 },
                    { 690, new Guid("d30b441f-ccdd-4255-9999-8f7b30476923"), "نياسر", 19 },
                    { 689, new Guid("f3662ee7-4ddc-4ef0-a691-d1f920fefb88"), "نوش آباد", 19 },
                    { 688, new Guid("56edc7c1-efb2-4b45-89c9-9c97dbf0c4f2"), "نطنز", 19 },
                    { 687, new Guid("f3c49b59-c306-4db7-9244-a7a2a3d65782"), "نصرآباد", 19 },
                    { 686, new Guid("3a2e5917-f94e-43bc-b2b0-385b68e92e0a"), "نجف آباد", 19 },
                    { 685, new Guid("e2276465-0a56-4538-9c78-c10fe2c3201d"), "نائين", 19 },
                    { 684, new Guid("5462d558-2a7f-43c3-b922-b8aa4bba2d1b"), "ميمه", 19 },
                    { 655, new Guid("a4e6f2c5-b5ec-4c72-a793-020183bd3bbf"), "زرين شهر", 19 },
                    { 683, new Guid("01c5b17f-a4a6-45dc-ae81-305903143633"), "مهاباد", 19 },
                    { 681, new Guid("6f979879-5893-426e-a53f-4942d76b0b74"), "مشکات", 19 },
                    { 680, new Guid("b991a8a0-e78a-4942-a420-397ba2afbcfb"), "محمد آباد", 19 },
                    { 679, new Guid("fa092127-bd46-470d-b96f-0c0ff2fd5fb4"), "مبارکه", 19 },
                    { 678, new Guid("a13024e6-c92f-4586-9908-293949da3a49"), "لاي بيد", 19 },
                    { 677, new Guid("5601297d-dca2-4e90-97b3-a02480ab7b5d"), "قهدريجان", 19 },
                    { 676, new Guid("0cfc27ae-5b12-4926-ad08-a844903dbb0c"), "قهجاورستان", 19 },
                    { 675, new Guid("1df15a1e-17cc-46d5-afb7-f494482956d0"), "قمصر", 19 },
                    { 682, new Guid("0f400a84-0404-46a6-933e-d74e25604b0d"), "منظريه", 19 },
                    { 691, new Guid("49318863-8a99-49b4-9633-0820caeafc80"), "نيک آباد", 19 },
                    { 654, new Guid("9c3cd700-2f2d-493e-b509-e9d3bbf2b3d8"), "زاينده رود", 19 },
                    { 652, new Guid("21a516eb-2a8d-4329-8921-843ef2f00fd2"), "رضوانشهر", 19 },
                    { 631, new Guid("35bcaa0a-27c3-44ed-b8de-c6c5b18664de"), "تيران", 19 },
                    { 630, new Guid("19c7a715-8b8e-4160-9b28-03e47ee5039f"), "تودشک", 19 },
                    { 629, new Guid("69ecf689-a82f-4250-b8d8-0c7375b8db5c"), "بوئين مياندشت", 19 },
                    { 628, new Guid("6da9e178-79c4-443f-926a-e022f75b53a6"), "بهارستان", 19 },
                    { 627, new Guid("28876561-e7fa-44f8-bc39-92fc808e662d"), "بهاران شهر", 19 },
                    { 626, new Guid("0e03573d-701e-480c-b4c4-6a2f149a7e6d"), "برف انبار", 19 },
                    { 625, new Guid("4ebdee6a-01a9-4088-b1cd-5b0621919334"), "برزک", 19 },
                    { 624, new Guid("c29992ad-c530-4801-9ecf-ce83a90087c2"), "بافران", 19 },
                    { 623, new Guid("19a8ec6c-43e7-4de9-b889-e9fb7f6e1366"), "باغشاد", 19 },
                    { 622, new Guid("5ed7e0a5-28cb-411e-af20-7774a93c3252"), "باغ بهادران", 19 },
                    { 621, new Guid("fd11b4e7-9674-4992-8426-6b48e9587f29"), "بادرود", 19 },
                    { 620, new Guid("fef2d50a-863a-4ae6-8e75-dead594929a1"), "اژيه", 19 },
                    { 619, new Guid("2731aead-63fb-476b-92ad-67323c9ba0bc"), "ايمانشهر", 19 },
                    { 618, new Guid("ccd25aab-bc07-47af-a5d0-530402913ddc"), "انارک", 19 },
                    { 617, new Guid("ba856018-8e89-4d5b-b7ff-b217f6105a48"), "افوس", 19 },
                    { 632, new Guid("aec6bb1f-f830-4a77-beca-d30ed630bdff"), "جندق", 19 },
                    { 633, new Guid("dd7ed6f5-3764-452c-a604-e2ea8e945af6"), "جوزدان", 19 },
                    { 634, new Guid("2d9fad08-a88c-4ef7-bb80-554c9b3e8767"), "جوشقان قالي", 19 },
                    { 635, new Guid("997a1b14-61c6-45f8-bab5-07a96cf4e50e"), "حبيب آباد", 19 },
                    { 651, new Guid("3589a3b0-fc1d-4843-8aa2-dc4d5ade0eb9"), "رزوه", 19 },
                    { 650, new Guid("6db16b97-604a-4b0a-ac73-27fdda11aaed"), "ديزيچه", 19 },
                    { 649, new Guid("6f1fd045-9329-4cc1-aad4-22340e789569"), "دولت آباد", 19 },
                    { 648, new Guid("5f8e1454-617d-40e1-9bc3-ddc706263ba0"), "دهق", 19 },
                    { 647, new Guid("dfd67f6c-8281-41e6-a2cf-2131a6d3c262"), "دهاقان", 19 },
                    { 646, new Guid("f84111f6-5143-4df2-91f9-64f978043369"), "دستگرد", 19 },
                    { 645, new Guid("e86d1f47-b7c6-4630-b392-69102d24a7fa"), "درچه پياز", 19 },
                    { 653, new Guid("bccaface-14d5-4825-bb27-2d997531cbec"), "زازران", 19 },
                    { 644, new Guid("b97ba7bf-7829-4ff5-b7ba-c6ac2ec7255f"), "دامنه", 19 },
                    { 642, new Guid("26768768-c218-454e-96b2-b5ae7d7de4e6"), "خورزوق", 19 },
                    { 641, new Guid("9a316f6a-0d32-4960-b709-2de98a961af7"), "خور", 19 },
                    { 640, new Guid("93f4e61b-a9be-455b-bd5f-85a7bfd4790d"), "خوانسار", 19 },
                    { 639, new Guid("49e6e4ea-9111-43a0-87fc-1c94d16e5c8c"), "خميني شهر", 19 },
                    { 638, new Guid("12f91828-4f57-483b-8d3c-fb86e7058154"), "خالد آباد", 19 },
                    { 637, new Guid("074baab6-2d6d-43eb-b4da-5d6558824f14"), "حنا", 19 },
                    { 636, new Guid("e8c6827b-3a91-49d8-8d08-a9b7aede963c"), "حسن آباد", 19 },
                    { 643, new Guid("ac73147c-6aeb-4568-80fc-16dea51213ef"), "داران", 19 },
                    { 692, new Guid("b637d499-f3a6-459c-bd1e-51808440b3f6"), "هرند", 19 },
                    { 693, new Guid("224a3ed7-df1d-4ce0-b0df-e347817ca37e"), "ورزنه", 19 },
                    { 694, new Guid("c64f2371-1f62-4c12-9e71-feb4c4531614"), "ورنامخواست", 19 },
                    { 749, new Guid("c7975aaa-ace9-4d03-ad42-17a895563f70"), "بومهن", 21 },
                    { 748, new Guid("e8322690-0223-4e5f-967d-dff5fc00b398"), "باقرشهر", 21 },
                    { 747, new Guid("8e45f8d0-3316-4868-b595-34a763a8fc5a"), "باغستان", 21 },
                    { 746, new Guid("17f90cc3-022e-4737-b1b9-d3209e6a82a7"), "انديشه", 21 },
                    { 745, new Guid("6bd2bcb8-9ecc-480c-b76d-60eca693e41c"), "اسلامشهر", 21 },
                    { 744, new Guid("0838a271-d891-47ca-9021-0f55f7b1a08c"), "ارجمند", 21 },
                    { 743, new Guid("76ffa6d8-6d9e-436c-969d-bb287cc0b010"), "آبعلي", 21 },
                    { 742, new Guid("6f6fcb30-0847-45fe-af3c-1c3951787e9c"), "آبسرد", 21 },
                    { 741, new Guid("2ca4064b-d955-4897-a793-8d8a8b269415"), "چوار", 20 },
                    { 740, new Guid("d9625d25-dd43-4f9c-8ba5-183fc41e9a7d"), "پهله", 20 },
                    { 739, new Guid("f095c73a-a323-4b7f-8708-2169dce8cf68"), "ميمه", 20 },
                    { 738, new Guid("84601054-2add-4907-885b-0b170e98e251"), "موسيان", 20 },
                    { 737, new Guid("fa3ac5e3-8358-4c6f-bb89-1424dd770eb4"), "مورموري", 20 },
                    { 736, new Guid("522e370f-d545-4bc6-9bb7-7d698876ca81"), "مهران", 20 },
                    { 735, new Guid("d907271f-d66b-499a-ba9a-058ea4219c55"), "مهر", 20 },
                    { 750, new Guid("1a334e94-f9d4-4524-af6f-3b21a4c7cb70"), "تجريش", 21 },
                    { 751, new Guid("bf1a7816-91d8-4360-be04-5f36a9633254"), "تهران", 21 },
                    { 752, new Guid("54117fa7-7e4c-42b1-8a67-5e622b713596"), "جواد آباد", 21 },
                    { 753, new Guid("ebd4baba-f111-45b5-b0bb-6bdce3d72a22"), "حسن آباد", 21 },
                    { 769, new Guid("57a17414-c14d-405d-b107-2a397d06e900"), "فيروزکوه", 21 },
                    { 768, new Guid("dea5ee7c-4424-4f96-9c53-899c5c2b3736"), "فشم", 21 },
                    { 767, new Guid("5a6c94ce-3c1e-4d77-bb7a-28b5abd80db1"), "فرون آباد", 21 },
                    { 766, new Guid("c5d3499d-b1ef-499a-8147-e008da5f90cb"), "فردوسيه", 21 },
                    { 765, new Guid("f8c95415-76e3-405a-827c-049e13e7f227"), "صفادشت", 21 },
                    { 764, new Guid("f62aa58d-c3be-4ab4-bfbc-c3a1aa86de02"), "صبا شهر", 21 },
                    { 763, new Guid("9b774f99-d44c-42a2-a001-27d991b71df4"), "صالحيه", 21 },
                    { 734, new Guid("84a2c805-60f3-40f9-b5fc-3f08248c295b"), "ماژين", 20 },
                    { 762, new Guid("91e00151-8afd-4fc8-a1d4-5a0d157080a3"), "شهريار", 21 },
                    { 760, new Guid("0fbdf01e-ef4e-4b61-9035-9485f667fcf6"), "شمشک", 21 },
                    { 759, new Guid("089e852a-e920-42ed-b952-afc8599ab733"), "شريف آباد", 21 },
                    { 758, new Guid("7cf6bac1-9eff-4db9-a0c1-cd57f0156f53"), "شاهدشهر", 21 },
                    { 757, new Guid("c87dffa8-3b7c-414d-8ca9-f90154b61c8f"), "ري", 21 },
                    { 756, new Guid("3d615f50-6a4b-446f-ae4c-e385db81eadf"), "رودهن", 21 },
                    { 755, new Guid("737de433-50f0-4b14-bb07-21edb0ac70e6"), "رباط کريم", 21 },
                    { 754, new Guid("8038481b-ed77-4448-8733-c216570131d6"), "دماوند", 21 },
                    { 761, new Guid("bbbd9f93-62f0-482d-b136-8ad15093577a"), "شهر جديد پرند", 21 },
                    { 733, new Guid("4fecbabd-8786-4f32-8afb-89c93eea98a9"), "لومار", 20 },
                    { 732, new Guid("9b8472dc-23e6-48c7-935b-60b43f407722"), "صالح آباد", 20 },
                    { 731, new Guid("7eb45af9-63dd-4bad-b616-a311fff5a4cd"), "شباب", 20 },
                    { 710, new Guid("2965a799-b4ca-459b-a5f3-cf43c24f4219"), "گرگاب", 19 },
                    { 709, new Guid("432daba5-2b9b-4bb1-a349-37a8795c8d97"), "کوهپايه", 19 },
                    { 708, new Guid("4ff34699-997c-43e7-804f-20f788b61d5f"), "کوشک", 19 },
                    { 707, new Guid("556f515a-0108-40c1-b491-471b414d251c"), "کهريزسنگ", 19 },
                    { 706, new Guid("4676f922-d29c-459d-a352-bf8dfd5ffdb3"), "کمه", 19 },
                    { 705, new Guid("e7565084-d681-40a7-8d36-34c86acc3055"), "کمشجه", 19 },
                    { 704, new Guid("da4ec564-3871-4715-bc36-b75beaa30cc0"), "کليشاد و سودرجان", 19 },
                    { 711, new Guid("94850424-88c8-4750-8728-229f71cb8ce7"), "گز برخوار", 19 },
                    { 703, new Guid("8a118f5a-54ac-4982-95b1-553fdf13b33f"), "کرکوند", 19 },
                    { 701, new Guid("952bc2f7-4be6-4e49-8eb0-cdc922f0ad2e"), "کاشان", 19 },
                    { 700, new Guid("d32810ac-25d2-49c6-a06e-6e2587653bd0"), "چمگردان", 19 },
                    { 699, new Guid("51065d12-97c1-48a8-b80f-5fb4a7b0a2ba"), "چرمهين", 19 },
                    { 698, new Guid("35406c93-ef5c-4a57-84b5-5851077a49a5"), "چادگان", 19 },
                    { 697, new Guid("052eb6a0-2688-433f-9141-89e238c1490e"), "پير بکران", 19 },
                    { 696, new Guid("3b681d72-2dd5-4935-b5c7-85ae6de4bac3"), "ونک", 19 },
                    { 695, new Guid("a0b39245-8b36-4ad9-ae2f-228a5a4e77f4"), "وزوان", 19 },
                    { 702, new Guid("4144e5c4-36b2-4241-bca7-b5e44457c788"), "کامو و چوگان", 19 },
                    { 771, new Guid("030964c2-10a8-4f5f-8751-833a34550067"), "قرچک", 21 },
                    { 712, new Guid("58106dbc-511c-4274-b363-e9fbb22e4e29"), "گلدشت", 19 },
                    { 714, new Guid("6d0da5f4-3a51-4ca9-ad82-b4349710f95c"), "گلشهر", 19 },
                    { 730, new Guid("38365084-3ad9-4147-9f7d-1562b4daeb20"), "سرابله", 20 },
                    { 729, new Guid("2b127a44-1284-4d46-b816-946eeb03dc80"), "سراب باغ", 20 },
                    { 728, new Guid("4b7e7bdf-1300-4002-a1b4-8b97012740d5"), "زرنه", 20 },
                    { 727, new Guid("67511319-ec87-445e-abee-197c4f6782c4"), "دهلران", 20 },
                    { 726, new Guid("f829305b-8227-405f-9714-a3112d26f980"), "دلگشا", 20 },
                    { 725, new Guid("010e14ee-60e5-49d1-8790-b236250160db"), "دره شهر", 20 },
                    { 724, new Guid("c27e3960-f46e-4856-b8f2-9b8e4962e0fe"), "توحيد", 20 },
                    { 713, new Guid("73e1c06d-2fc9-40c7-876a-970f2d365e98"), "گلشن", 19 },
                    { 723, new Guid("0d677199-9c1c-415c-8dec-330169c3ec07"), "بلاوه", 20 },
                    { 721, new Guid("50e5d381-3956-46c1-a054-f138be517618"), "ايوان", 20 },
                    { 720, new Guid("67003ed9-cd1a-4d47-9b42-bca71da01796"), "ايلام", 20 },
                    { 719, new Guid("4ae8eb48-ed29-4ede-b6cc-58bc705eb194"), "ارکواز", 20 },
                    { 718, new Guid("01e2dd55-cfc8-4675-9090-a6f97e13e2d7"), "آسمان آباد", 20 },
                    { 717, new Guid("274a0cb4-10f1-4f72-9eae-4df57dd39ae7"), "آبدانان", 20 },
                    { 716, new Guid("b1844c05-0bbc-4eeb-948c-d962e4f73ab3"), "گوگد", 19 },
                    { 715, new Guid("227d1327-aace-43d3-b66c-01a01f9a7f80"), "گلپايگان", 19 },
                    { 722, new Guid("6e7fbde2-a0c7-4410-9492-27bc3ec7e91d"), "بدره", 20 },
                    { 928, new Guid("2d30f4b3-b2e4-4b8b-9577-6419af22ba9b"), "مصيري", 23 },
                    { 930, new Guid("3112fe27-95bd-4a60-a815-05268ae7bbf0"), "ميانشهر", 23 },
                    { 616, new Guid("bc9524ec-fe07-417d-b03b-9b8fde7d07d5"), "اصفهان", 19 },
                    { 1141, new Guid("d39f1d07-24eb-4475-a857-2ea57f8386ec"), "بردسير", 29 },
                    { 1140, new Guid("d40148ce-290d-4b9d-a8fa-b73665ee2383"), "بافت", 29 },
                    { 1139, new Guid("359c494d-1bc9-48d2-94e5-a8a6cb4f30b9"), "باغين", 29 },
                    { 1138, new Guid("18378d19-93e2-45c2-a07b-a5dde1c47232"), "اندوهجرد", 29 },
                    { 1137, new Guid("0ad9750b-869c-49df-9706-5bc5962b95c9"), "انار", 29 },
                    { 1136, new Guid("74b1b436-1a0e-4194-b30d-1ebdfefea109"), "امين شهر", 29 },
                    { 1135, new Guid("c7117547-c578-4071-8027-f63447f14d1c"), "ارزوئيه", 29 },
                    { 1134, new Guid("c3e0ca48-0b22-4c49-a6a8-fe044b6fd39a"), "اختيار آباد", 29 },
                    { 1133, new Guid("895a8130-f186-44fd-84e2-452a51b96aa8"), "گيان", 28 },
                    { 1132, new Guid("e17336d9-5f92-41af-a678-de462f3926b4"), "گل تپه", 28 },
                    { 1131, new Guid("60850434-afed-41a2-a689-754d083782e7"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("48d8dfa2-de35-4216-8d3d-758fbfc253b2"), "همدان", 28 },
                    { 1129, new Guid("f57373d9-4915-426d-9766-b9e18698fe9e"), "نهاوند", 28 },
                    { 1128, new Guid("49a30037-f748-45f1-ac3a-8942c63b416c"), "مهاجران", 28 },
                    { 1127, new Guid("1b0b9564-4bb0-4b56-a98a-c4331147a0f1"), "ملاير", 28 },
                    { 1142, new Guid("10d479d0-9f9f-4db7-8b8d-657aa2c0603b"), "بروات", 29 },
                    { 1143, new Guid("1a643f67-74a4-4fb5-910d-3115a2ec0ea2"), "بزنجان", 29 },
                    { 1144, new Guid("9f295d22-d4fc-4c34-94bf-46a298b50f96"), "بلورد", 29 },
                    { 1145, new Guid("2b5de415-7ef6-451b-a3f4-cac3ef1ad91e"), "بلوک", 29 },
                    { 1161, new Guid("37c823e4-177d-4be6-8d0d-ee0dc0fa682b"), "راور", 29 },
                    { 1160, new Guid("7fe57810-1818-44ba-8e2b-7d929c2f17f2"), "رابر", 29 },
                    { 1159, new Guid("439f5be1-83f1-487a-a7ea-d1a4cf15e6cb"), "دوساري", 29 },
                    { 1158, new Guid("ec92de5c-5e2b-4379-a795-cd938b107e05"), "دهج", 29 },
                    { 1157, new Guid("6205884f-0017-47a2-bdc1-a62cb8095cb1"), "دشتکار", 29 },
                    { 1156, new Guid("a15ced9b-2c4e-4385-b5f8-2d5a5ea0e976"), "درب بهشت", 29 },
                    { 1155, new Guid("4bd453e7-6b41-4e24-85c7-063adcac10ca"), "خورسند", 29 },
                    { 1126, new Guid("f8ed531f-3d50-4cdb-acd6-c492f4a6e57c"), "مريانج", 28 },
                    { 1154, new Guid("1a72dceb-3994-4d91-99b8-6b2b53b9cb49"), "خواجوشهر", 29 },
                    { 1152, new Guid("105fd58b-b75e-45fc-81ad-5e2053eae779"), "خاتون آباد", 29 },
                    { 1151, new Guid("9ca01b9b-43a2-489f-9d25-c74bdb458a8e"), "جيرفت", 29 },
                    { 1150, new Guid("b337064d-2a9a-4c18-8a81-043438cb2475"), "جوپار", 29 },
                    { 1149, new Guid("ccec4617-2f3a-4777-a02a-a6ecf0a70bae"), "جوزم", 29 },
                    { 1148, new Guid("399a42d5-af1b-4670-8e79-b7c5c2de5b37"), "جبالبارز", 29 },
                    { 1147, new Guid("2894b161-fb06-4094-9666-45eddd3cb3ce"), "بهرمان", 29 },
                    { 1146, new Guid("a7022b9f-5278-4755-ba3c-c17419ca85f3"), "بم", 29 },
                    { 1153, new Guid("4e3e5cf3-ca5a-4d82-98d8-dd151acf6684"), "خانوک", 29 },
                    { 1162, new Guid("ab221af4-1f7f-41e2-9c7b-fd528947d4e7"), "راين", 29 },
                    { 1125, new Guid("6065f207-d48e-46db-bfa3-423a28f303b4"), "لالجين", 28 },
                    { 1123, new Guid("f56fd5ac-b387-4876-a6c5-7afcc00cd8e0"), "قروه در جزين", 28 },
                    { 1102, new Guid("a39eb986-7792-4306-89ae-1f46c6e48bfd"), "کوچصفهان", 27 },
                    { 1101, new Guid("9afff1e1-749d-4e55-8e72-5d9dc23e7a29"), "کومله", 27 },
                    { 1100, new Guid("97b9497e-9efb-4427-8ac7-65dac95c7523"), "کلاچاي", 27 },
                    { 1099, new Guid("65990f88-00af-4397-ab56-7d2678247f2a"), "چوبر", 27 },
                    { 1098, new Guid("44bbfc60-48ae-474d-82f8-9767568631da"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("a9b8dbbd-8dbc-47b4-bf57-e600b19ab9b1"), "چابکسر", 27 },
                    { 1096, new Guid("d3060d5b-63c1-4ff1-a3c6-2dd407e20f24"), "پره سر", 27 },
                    { 1095, new Guid("df53fb01-0f33-4e69-87be-2814e0f5929f"), "واجارگاه", 27 },
                    { 1094, new Guid("01b9b382-987d-4ce5-9a6d-4f753fa7c7eb"), "هشتپر", 27 },
                    { 1093, new Guid("6ca23f4c-207b-4c65-abf2-ccd7239911d3"), "منجيل", 27 },
                    { 1092, new Guid("778afd53-acfd-4d3e-9257-48b1ad467a94"), "مرجقل", 27 },
                    { 1091, new Guid("4599dc76-0f1c-459b-ae1e-e475e9931bcc"), "ماکلوان", 27 },
                    { 1090, new Guid("43e1686e-2e60-493a-8426-0e8ed9416fd8"), "ماسوله", 27 },
                    { 1089, new Guid("fcd8a5c2-6666-42a5-954b-2638aeef397d"), "ماسال", 27 },
                    { 1088, new Guid("7c90ed9e-ee0e-4495-a615-4904041351c1"), "ليسار", 27 },
                    { 1103, new Guid("c3386692-17d8-46c6-af1a-840230cc8682"), "کياشهر", 27 },
                    { 1104, new Guid("f09deed6-1d9f-4b5e-b84b-da58ec9542c6"), "گوراب زرميخ", 27 },
                    { 1105, new Guid("bf1e1819-c323-4ec0-a74d-3bf66c65ba46"), "آجين", 28 },
                    { 1106, new Guid("b5e1a9b7-31ca-4f0d-9974-9b68f93fb327"), "ازندريان", 28 },
                    { 1122, new Guid("6476e0b7-c7f6-412c-9fb5-71a058df68aa"), "فيروزان", 28 },
                    { 1121, new Guid("b66a2385-1fb1-47cc-b542-088d539167e4"), "فرسفج", 28 },
                    { 1120, new Guid("ad9d4506-2057-4405-9276-424fed2fda33"), "فامنين", 28 },
                    { 1119, new Guid("05c27d82-3251-4850-ac87-e687124ddde4"), "صالح آباد", 28 },
                    { 1118, new Guid("937198ac-4553-47ab-88b0-e5a9c2e4cbdc"), "شيرين سو", 28 },
                    { 1117, new Guid("bc6b97bf-8bce-48e4-a944-b8006da43c7a"), "سرکان", 28 },
                    { 1116, new Guid("acf443a9-7a00-42ea-b9a2-0849007ffe68"), "سامن", 28 },
                    { 1124, new Guid("1c070c95-ffe1-4734-b88c-5cd06b95dbe9"), "قهاوند", 28 },
                    { 1115, new Guid("ca61ffe6-a5be-4c1d-a956-98a09c6370d1"), "زنگنه", 28 },
                    { 1113, new Guid("f1f56b55-c68f-495c-8013-9800bf15ee97"), "دمق", 28 },
                    { 1112, new Guid("288f6f53-1b64-44d7-adfd-b77cfa7c16a5"), "جوکار", 28 },
                    { 1111, new Guid("f548a61a-3452-47e8-b914-c5f89d29780b"), "جورقان", 28 },
                    { 1110, new Guid("dbb34479-a07d-48f9-998c-5a6ca4dfb8a0"), "تويسرکان", 28 },
                    { 1109, new Guid("6d6b19f0-c01a-4aed-9b02-d5c975f491fb"), "بهار", 28 },
                    { 1108, new Guid("5a0e9d04-cd70-436c-8024-d9dc58e93ec6"), "برزول", 28 },
                    { 1107, new Guid("5aefb744-6188-4f09-a757-6983108598b2"), "اسد آباد", 28 },
                    { 1114, new Guid("e9a85f0f-6b6c-45a1-a9d1-90f80ef557b6"), "رزن", 28 },
                    { 1163, new Guid("84d20d80-17a7-4bd1-8f39-b1e489a2295a"), "رفسنجان", 29 },
                    { 1164, new Guid("e5cd9fe5-d471-4e07-ab13-0248a4c0c436"), "رودبار", 29 },
                    { 1165, new Guid("7fa619ec-31f8-4d6e-9366-3841e3239c99"), "ريحان", 29 },
                    { 1220, new Guid("f972ae6f-3f23-41c8-b1e0-03f3f7385107"), "ميامي", 30 },
                    { 1219, new Guid("79b158fc-17e8-4e43-9987-3ac7d901ce1b"), "مهدي شهر", 30 },
                    { 1218, new Guid("b1619e54-b5b9-4405-8b9e-54137e045826"), "مجن", 30 },
                    { 1217, new Guid("f0e9014f-1c45-496b-886f-541fa8760a2c"), "شهميرزاد", 30 },
                    { 1216, new Guid("1e2f2661-1252-42c6-9507-561af3c5fe43"), "شاهرود", 30 },
                    { 1215, new Guid("de93e092-e14e-43ba-98b1-29f1ff214e7f"), "سمنان", 30 },
                    { 1214, new Guid("8e17281a-c8fe-4760-b8f9-c1d51015027d"), "سرخه", 30 },
                    { 1213, new Guid("28fb01cc-24fa-4bc6-9ca6-5e9b46fbdda9"), "روديان", 30 },
                    { 1212, new Guid("8fd3639c-e32c-4c0e-bf8a-b9076422a208"), "ديباج", 30 },
                    { 1211, new Guid("d4d35cbc-c32b-491c-aa6c-700f221c8298"), "درجزين", 30 },
                    { 1210, new Guid("74488e9e-2fa8-4cf2-be94-063e86ab0340"), "دامغان", 30 },
                    { 1209, new Guid("32c64fbf-8cc9-4b97-a16e-675ce00ba099"), "بيارجمند", 30 },
                    { 1208, new Guid("650a2079-0bb8-40be-9245-0b1e8838240e"), "بسطام", 30 },
                    { 1207, new Guid("9417423e-0818-471f-9f39-e744a9e58f68"), "ايوانکي", 30 },
                    { 1206, new Guid("ecaa4923-3999-4f4a-ae88-938dc86db103"), "اميريه", 30 },
                    { 1221, new Guid("31683123-552e-45cd-a1b9-c37d830e1189"), "کلاته", 30 },
                    { 1222, new Guid("2f8640c9-21b2-4717-bdc4-0644633d10da"), "کلاته خيج", 30 },
                    { 1223, new Guid("ece2295e-b1c9-4ddb-bd5d-2e586b0b4746"), "کهن آباد", 30 },
                    { 1224, new Guid("3ed16f77-24ff-4722-9235-647ca97b3f90"), "گرمسار", 30 },
                    { 1240, new Guid("7dc68c1d-0371-4669-a371-bdff20b1c97c"), "چيتاب", 31 },
                    { 1239, new Guid("17c7506d-cd7d-4f61-8385-639a9e215abd"), "چرام", 31 },
                    { 1238, new Guid("735859a7-1d53-4632-9c6d-0a325e89fb5d"), "پاتاوه", 31 },
                    { 1237, new Guid("355803b7-1483-4b0f-9d0f-6e7fd21f688a"), "ياسوج", 31 },
                    { 1236, new Guid("f0aca863-33bb-4a09-a642-a71019ba2b4a"), "مارگون", 31 },
                    { 1235, new Guid("9511a7c4-f0ae-4665-bb3e-efc03e61b42e"), "مادوان", 31 },
                    { 1234, new Guid("dab1189d-df70-4ab4-bf93-894e0757bfd0"), "ليکک", 31 },
                    { 1205, new Guid("f91428a2-45cc-4666-b427-d561d16797f3"), "آرادان", 30 },
                    { 1233, new Guid("1bf75db1-92d4-47ee-bbe8-af7836e55352"), "لنده", 31 },
                    { 1231, new Guid("c4893b04-2d60-4f40-8f0a-7e9a463afe46"), "سي سخت", 31 },
                    { 1230, new Guid("8aaee347-e4ee-4a39-939c-da59d4b69571"), "سوق", 31 },
                    { 1229, new Guid("0b895b29-9a42-4aa1-9551-988071b70ba5"), "سرفارياب", 31 },
                    { 1228, new Guid("9aef5bca-b0d7-49bc-8be1-0b162af62183"), "ديشموک", 31 },
                    { 1227, new Guid("eb0fd6b8-fb3a-4a2c-a049-d7f0b32ab41b"), "دوگنبدان", 31 },
                    { 1226, new Guid("de56eb13-f1ab-48fc-935f-d41e8b5f3ae4"), "دهدشت", 31 },
                    { 1225, new Guid("68bd3608-dba1-498b-95c4-adb0ea95eeef"), "باشت", 31 },
                    { 1232, new Guid("855442d5-049e-4ad7-bcd6-5648fd1fd8f7"), "قلعه رئيسي", 31 },
                    { 1204, new Guid("454761a6-a044-4904-a193-2e13adec85af"), "گنبکي", 29 },
                    { 1203, new Guid("1ca9d7af-8174-4e94-a9ca-d2ede9334fcf"), "گلزار", 29 },
                    { 1202, new Guid("8e25c9cf-e36d-4676-ad41-e795d7ed24c6"), "گلباف", 29 },
                    { 1181, new Guid("4ab8647b-f4d2-429a-8534-8ab74a84b801"), "محي آباد", 29 },
                    { 1180, new Guid("0e1231ea-f180-414d-91a6-01d515e02216"), "محمد آباد", 29 },
                    { 1179, new Guid("f558edfa-9ce0-40ec-bead-a9387cd27411"), "ماهان", 29 },
                    { 1178, new Guid("81984e73-fa8d-49ba-88e4-ca0fd19dc57c"), "لاله زار", 29 },
                    { 1177, new Guid("a1f888fa-ee97-4a08-9a19-91cc7dd4d7b5"), "قلعه گنج", 29 },
                    { 1176, new Guid("596441de-7624-48ab-9107-fd04af0a8601"), "فهرج", 29 },
                    { 1175, new Guid("35881b06-4d1d-401d-875b-24be859a7a42"), "فارياب", 29 },
                    { 1182, new Guid("7a6af3a8-0c11-4420-ae80-e84bd7b7190e"), "مردهک", 29 },
                    { 1174, new Guid("2df20e37-321a-44e8-8bb2-1e6db83c7af2"), "عنبر آباد", 29 },
                    { 1172, new Guid("57ffcea9-fb51-4c89-b2e9-93e3eeb0d712"), "شهر بابک", 29 },
                    { 1171, new Guid("169df3e9-db01-49cc-85c4-1ad521a404cc"), "شهداد", 29 },
                    { 1170, new Guid("cc9a5a23-b204-435c-a193-640f6795e32e"), "سيرجان", 29 },
                    { 1169, new Guid("90c69602-de61-4a0b-9b8b-398b9ba076bd"), "زيد آباد", 29 },
                    { 1168, new Guid("c79cda2c-15d6-462e-b496-0648168a4fad"), "زهکلوت", 29 },
                    { 1167, new Guid("32e50372-a6d0-4c83-a21f-d034032e519e"), "زنگي آباد", 29 },
                    { 1166, new Guid("0cf14dde-a330-4cb8-9cb0-44c12143b94b"), "زرند", 29 },
                    { 1173, new Guid("faa61ede-631d-4ad5-b51b-484d02f5d9be"), "صفائيه", 29 },
                    { 1087, new Guid("4f81e591-d2c1-47b7-8314-1f71ddb319eb"), "لوندويل", 27 },
                    { 1183, new Guid("9bd5d020-c3af-47ab-aff2-ba3b34983494"), "مس سرچشمه", 29 },
                    { 1185, new Guid("69c1a715-0ca0-47a5-831c-1877b34d8330"), "نجف شهر", 29 },
                    { 1201, new Guid("1c32e142-93f8-4f0e-ad90-3ab03ca44118"), "کيانشهر", 29 },
                    { 1200, new Guid("1a9dbd2e-637f-4440-97ec-24702541d5d0"), "کوهبنان", 29 },
                    { 1199, new Guid("ce2b2f9c-7754-4dd3-a8ed-f8b59213afc3"), "کهنوج", 29 },
                    { 1198, new Guid("4f6720d7-a4d5-43c5-996a-027044ab58d7"), "کشکوئيه", 29 },
                    { 1197, new Guid("c09015f1-e3c7-4e89-9a98-c39076774abc"), "کرمان", 29 },
                    { 1196, new Guid("4a8972f4-f055-4600-99a2-ecd1249f22cd"), "کاظم آباد", 29 },
                    { 1195, new Guid("c72add4b-7198-4353-94f0-7306e5e3aa81"), "چترود", 29 },
                    { 1184, new Guid("4c0f54f8-24f8-48a6-a5ea-2b7c76f4bf26"), "منوجان", 29 },
                    { 1194, new Guid("d6a53c09-1503-4ecd-8d18-006e72d9f503"), "پاريز", 29 },
                    { 1192, new Guid("50275ed2-6ecd-4eef-b6d9-43bd55f9bdd4"), "هنزا", 29 },
                    { 1191, new Guid("c14fda50-d06d-4c67-9a2a-93f63c9f9d62"), "هماشهر", 29 },
                    { 1190, new Guid("a5e1ec5b-1e43-448f-b1c1-e0592e681398"), "هجدک", 29 },
                    { 1189, new Guid("38a14331-4b51-47f0-b24b-e0fc44dbdd73"), "نگار", 29 },
                    { 1188, new Guid("2bd5160c-e2f4-4d02-ad0f-7bb3ccedaa86"), "نودژ", 29 },
                    { 1187, new Guid("eb449943-703d-45db-a31d-9e53a7d79be6"), "نظام شهر", 29 },
                    { 1186, new Guid("01c054a6-b6b3-4efe-b78a-86b763188b4e"), "نرماشير", 29 },
                    { 1193, new Guid("bf21c1f9-0be5-4330-bc85-b446b578db19"), "يزدان شهر", 29 },
                    { 929, new Guid("d2a76008-a718-4f44-902b-c7ba2fdc5bd1"), "مهر", 23 },
                    { 1086, new Guid("c179c175-365b-4ae4-b277-b1a9842cd6b8"), "لولمان", 27 },
                    { 1084, new Guid("e1c59abf-e77f-4f62-8449-edb002c54d95"), "لنگرود", 27 },
                    { 984, new Guid("421c35c0-c603-4b10-9b02-74e80f973eba"), "بندر عباس", 25 },
                    { 983, new Guid("84644e81-c2dc-45ae-ad7c-32d64071eef4"), "بندر جاسک", 25 },
                    { 982, new Guid("a190e50c-a41e-4def-a55e-e3edb490be6b"), "بستک", 25 },
                    { 981, new Guid("668b23a8-e8ab-4c16-990b-680b0121fda4"), "ابوموسي", 25 },
                    { 980, new Guid("a0f94eac-b131-4d0c-b84d-f66717197eaa"), "گيلانغرب", 24 },
                    { 979, new Guid("9932bac1-680b-412e-94de-2b9009c5654c"), "گودين", 24 },
                    { 978, new Guid("33140a60-a63f-4133-b19a-546f2beb284e"), "گهواره", 24 },
                    { 977, new Guid("a2b41ffb-43a2-4b34-8f62-9a6b6e250e9a"), "کوزران", 24 },
                    { 976, new Guid("61191d61-65c7-4f90-9a31-b7ba43256add"), "کنگاور", 24 },
                    { 975, new Guid("c80e5c92-5122-4dc8-a5e8-4c5bd8a95d9a"), "کرند غرب", 24 },
                    { 974, new Guid("c34b4102-483e-47c4-9d3f-f12ed7649e1d"), "کرمانشاه", 24 },
                    { 973, new Guid("2f238468-46d7-4526-b726-0fbc67f3a82e"), "پاوه", 24 },
                    { 972, new Guid("19d53eab-1544-4dff-b3ea-3daa7ee50098"), "هلشي", 24 },
                    { 971, new Guid("cccd50a3-78ef-4b20-be39-d2415ca7aa6b"), "هرسين", 24 },
                    { 970, new Guid("92b12186-3eab-41b8-953b-55841b6e21ce"), "نوسود", 24 },
                    { 985, new Guid("fe29c8db-ec3c-4627-8aae-bab9a1083010"), "بندر لنگه", 25 },
                    { 986, new Guid("2a32e40a-b5dc-4d39-97c5-8ac819cb8f6c"), "بيکاه", 25 },
                    { 987, new Guid("93208cf8-3538-4bb7-b37f-059f2f4c1cf7"), "تازيان پائين", 25 },
                    { 988, new Guid("efda4f3b-d09a-4ffe-b4a1-812775674db8"), "تخت", 25 },
                    { 1004, new Guid("170c91d3-decc-4f5d-927c-83da65d4a38e"), "فين", 25 },
                    { 1003, new Guid("bf5967f8-9c7d-4b91-b32d-fac619c55cd7"), "فارغان", 25 },
                    { 1002, new Guid("18737c33-97c9-49d0-b59d-d1f03b9d2268"), "سيريک", 25 },
                    { 1001, new Guid("749998d2-c28b-427b-9f6a-8c13678a77cc"), "سوزا", 25 },
                    { 1000, new Guid("fe3480a7-f744-4052-8fe9-24d4c0e3f58c"), "سندرک", 25 },
                    { 999, new Guid("b8feac72-5684-470c-89d3-d2997ac88595"), "سرگز", 25 },
                    { 998, new Guid("8d4d1d13-ec3a-4b78-8109-8faf937fce92"), "سردشت", 25 },
                    { 969, new Guid("e371c9b9-2ee7-4e42-a944-a49319128fc5"), "نودشه", 24 },
                    { 997, new Guid("50e1092c-cdbe-46cb-a551-861a91205073"), "زيارتعلي", 25 },
                    { 995, new Guid("bd254170-f484-4338-b2b6-62b06ad5c748"), "دهبارز", 25 },
                    { 994, new Guid("a8da2e76-76d8-402c-a3cd-bbbde689c3d3"), "دشتي", 25 },
                    { 993, new Guid("4ec4b647-1d7b-41b5-a967-219767a6f7e7"), "درگهان", 25 },
                    { 992, new Guid("91fdae70-2dea-4f08-b867-3fe7aa71130b"), "خمير", 25 },
                    { 991, new Guid("98e7b35d-7fc0-4e82-9c0a-2a2dfd053613"), "حاجي آباد", 25 },
                    { 990, new Guid("dd9cec56-ab21-4edd-8c42-4c3ebeb09b49"), "جناح", 25 },
                    { 989, new Guid("54779cd9-e2c7-466e-b6fe-b4dc4a744699"), "تيرور", 25 },
                    { 996, new Guid("012c344b-cc5b-4928-9ab6-a89774f21d56"), "رويدر", 25 },
                    { 1005, new Guid("d970bad5-2206-4b5d-b117-e706b3de9f44"), "قشم", 25 },
                    { 968, new Guid("4996c239-94c0-43d4-811c-c61c2e4b47f0"), "ميان راهان", 24 },
                    { 966, new Guid("3f354bc2-dddb-4546-a216-ef63cdb7a8a0"), "صحنه", 24 },
                    { 945, new Guid("74d4f829-d124-4848-843a-66610c717faf"), "کوهنجان", 23 },
                    { 944, new Guid("b45820f0-c8a4-4af4-8cd7-dcdd4323a1b3"), "کوار", 23 },
                    { 943, new Guid("870e2c98-cf98-4417-88f8-85fb5ecbb196"), "کنار تخته", 23 },
                    { 942, new Guid("7bee3269-a7c5-41f2-a48b-18e80d21738a"), "کره اي", 23 },
                    { 941, new Guid("a3adcf09-bfe6-46a4-9bc5-81cb37de3c88"), "کامفيروز", 23 },
                    { 940, new Guid("be0b6981-1f63-418c-b2cc-c9adc9f6d5c1"), "کازرون", 23 },
                    { 939, new Guid("d7dd8654-1d3a-4782-be2d-00d63824bac7"), "کارزين", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 938, new Guid("d981a2bf-ea84-4637-8d5b-1e36981893cb"), "وراوي", 23 },
                    { 937, new Guid("7d1a7875-ae19-47ab-9bee-edf487db0e5d"), "هماشهر", 23 },
                    { 936, new Guid("373c49d9-17ec-4aee-8df7-acb6d3189297"), "ني ريز", 23 },
                    { 935, new Guid("0961b919-44f7-48dc-9a97-517cc235819c"), "نورآباد", 23 },
                    { 934, new Guid("211776ab-6b05-42aa-9a2a-990ba4add547"), "نودان", 23 },
                    { 933, new Guid("81355c21-e552-4ed9-875f-8bc13dcec759"), "نوجين", 23 },
                    { 932, new Guid("44feca97-e856-494b-becd-b7515975ffb2"), "نوبندگان", 23 },
                    { 931, new Guid("4017e5d9-80cd-417f-ab3a-2d2d25fdc92b"), "ميمند", 23 },
                    { 946, new Guid("0b318e5f-1ae8-4022-bc45-f4f32687614b"), "کوپن", 23 },
                    { 947, new Guid("94b341a9-2c7f-4ec8-bf97-3e94cc786638"), "گراش", 23 },
                    { 948, new Guid("24cfef8d-9b23-4350-b8b9-c6daae5297c8"), "گله دار", 23 },
                    { 949, new Guid("759bf05e-1c2c-4270-aea8-16ea9d5a64d4"), "ازگله", 24 },
                    { 965, new Guid("aac88dd9-ef2f-487b-a646-811406f5903e"), "شاهو", 24 },
                    { 964, new Guid("66f1c4b0-77fc-4b56-a705-d30ed19e5ebd"), "سومار", 24 },
                    { 963, new Guid("ae1302ad-79a0-47e5-8392-02695091e613"), "سنقر", 24 },
                    { 962, new Guid("e73a6a93-472d-4ff9-9839-55158df92b2a"), "سطر", 24 },
                    { 961, new Guid("67fa2e7a-ed01-4c9b-aecc-6a772231fd22"), "سرمست", 24 },
                    { 960, new Guid("ec6dff10-1f01-4553-a172-e0839bfdb20e"), "سر پل ذهاب", 24 },
                    { 959, new Guid("e4a24913-445e-4baf-bfc2-790528428aef"), "ريجاب", 24 },
                    { 967, new Guid("2b27ce28-c3b6-46bf-8b2d-340b5b5cb122"), "قصر شيرين", 24 },
                    { 958, new Guid("c448b759-e0dd-4075-b42c-2b0afb08b78d"), "روانسر", 24 },
                    { 956, new Guid("0e9d1488-902b-4db5-bf61-3966eb0ad380"), "حميل", 24 },
                    { 955, new Guid("10efdd92-4873-448d-beb1-d5be717cdf35"), "جوانرود", 24 },
                    { 954, new Guid("05b7cb5c-ddc2-4221-8ba2-ccb23d6a29ea"), "تازه آباد", 24 },
                    { 953, new Guid("84248163-1f0c-4e91-9e25-0bb2fcb9932d"), "بيستون", 24 },
                    { 952, new Guid("d9ad6c73-13c2-4659-8514-48add20ccab7"), "باينگان", 24 },
                    { 951, new Guid("b815bdd9-86a1-47fe-8f20-53fb0e322a4b"), "بانوره", 24 },
                    { 950, new Guid("21506bf0-5fae-400e-b16f-19c3db83541b"), "اسلام آباد غرب", 24 },
                    { 957, new Guid("e4e43649-87be-4ae1-b10f-b493f2083dec"), "رباط", 24 },
                    { 1006, new Guid("a14450ef-e304-4976-a0a1-40bcc3da944f"), "قلعه قاضي", 25 },
                    { 1007, new Guid("794362ec-2cd7-4f67-8e8e-956cde22e964"), "لمزان", 25 },
                    { 1008, new Guid("15093722-abe7-4092-8591-3e355e4a5a6c"), "ميناب", 25 },
                    { 1063, new Guid("54919cf5-824f-4546-93eb-cdcbc97fbd5f"), "جيرنده", 27 },
                    { 1062, new Guid("96174b40-ac24-466d-b750-aa27a4a4cf62"), "توتکابن", 27 },
                    { 1061, new Guid("2478409e-57d5-4e97-9e0d-1045c5932f20"), "بندر انزلي", 27 },
                    { 1060, new Guid("519d84e5-cd76-4017-a1ee-604d69ac115e"), "بره سر", 27 },
                    { 1059, new Guid("f4d61a57-ee4a-4769-821c-6ee26a8a0a13"), "بازار جمعه", 27 },
                    { 1058, new Guid("47dc880f-9347-41d4-8367-411811dfef82"), "املش", 27 },
                    { 1057, new Guid("bceceb4e-0924-45d4-b57d-e791390fbb05"), "اطاقور", 27 },
                    { 1056, new Guid("11b9b883-4591-4d27-b4cb-97bbb07cbc8f"), "اسالم", 27 },
                    { 1055, new Guid("213088cc-be72-4459-a2a3-768df744633f"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("57368da8-7cbc-436b-8f7f-e1c2de96e530"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("5aa64b25-9905-4b16-910e-f46a4b1da495"), "آستارا", 27 },
                    { 1052, new Guid("49d45008-6a50-4931-9690-a6643abd1bc2"), "کميجان", 26 },
                    { 1051, new Guid("2d705013-7583-476b-a3d3-5a9acfad5d1d"), "کارچان", 26 },
                    { 1050, new Guid("4e820362-1aa9-43dc-b3b2-40cc351f4fd8"), "پرندک", 26 },
                    { 1049, new Guid("d3796e35-ece4-42ee-8dab-02b4c8648a10"), "هندودر", 26 },
                    { 1064, new Guid("3b20a32d-19da-4160-8fb6-1dfa21ff2d2a"), "حويق", 27 },
                    { 1065, new Guid("14b5fda2-f3be-4774-aacc-c69f3e1fc2cb"), "خشکبيجار", 27 },
                    { 1066, new Guid("337514c8-3902-4bf4-ab02-d3b5eaf29e53"), "خمام", 27 },
                    { 1067, new Guid("429dd8d8-8197-42e9-9561-43c598eaedf9"), "ديلمان", 27 },
                    { 1083, new Guid("86d86b2a-a2c1-4d1d-8b0e-26b755639d96"), "لشت نشاء", 27 },
                    { 1082, new Guid("56c1545e-c6a4-4b6c-a229-c43a8da331dd"), "لاهيجان", 27 },
                    { 1081, new Guid("ebd97e77-82c5-47ce-a61d-35f7930aea71"), "فومن", 27 },
                    { 1080, new Guid("554d4884-0050-4205-84a2-57bc31f5cb21"), "صومعه سرا", 27 },
                    { 1079, new Guid("266810dd-cfc2-4d80-83c9-6533fe1c65a0"), "شلمان", 27 },
                    { 1078, new Guid("d71efc1e-2d58-4630-92f7-440efefd24bb"), "شفت", 27 },
                    { 1077, new Guid("0f4d38e5-ec6d-4baa-aa39-97d89ef0b6b9"), "سياهکل", 27 },
                    { 1048, new Guid("235c9451-ad76-4565-bd11-d84468ce3f94"), "نيمور", 26 },
                    { 1076, new Guid("fd857656-c96e-4780-a541-20689e939801"), "سنگر", 27 },
                    { 1074, new Guid("e2b197ba-af99-41ec-be0d-63827d8a5353"), "رودبنه", 27 },
                    { 1073, new Guid("1a520a1b-21df-4c2f-818b-b5d730e22d72"), "رودبار", 27 },
                    { 1072, new Guid("2db487fc-51d7-482b-8f45-c5bef0760ba5"), "رضوانشهر", 27 },
                    { 1071, new Guid("c2accaec-eb4e-4195-8e63-f52457ad7dbe"), "رشت", 27 },
                    { 1070, new Guid("76fcf13e-915c-4e04-adeb-9aa388a09ebb"), "رستم آباد", 27 },
                    { 1069, new Guid("c62d3206-d181-447f-98e6-e742aff0be8a"), "رحيم آباد", 27 },
                    { 1068, new Guid("9dfe33bc-c8ad-4fd4-883b-7b248312b89b"), "رانکوه", 27 },
                    { 1075, new Guid("2ec4de62-51b8-4ce3-9b2c-49e468d88d44"), "رودسر", 27 },
                    { 1047, new Guid("f6e2ae77-49fa-4912-aed9-97e05120149d"), "نوبران", 26 },
                    { 1046, new Guid("59375eb2-996b-4217-9da6-b087b1b9ee3f"), "نراق", 26 },
                    { 1045, new Guid("1ac379e2-4f66-4914-babb-f380a8ef0b4c"), "ميلاجرد", 26 },
                    { 1024, new Guid("7f6337ca-b742-45bf-bd12-816577857eb6"), "تفرش", 26 },
                    { 1023, new Guid("62f289e4-b8cf-4867-aa23-80466e7b29a0"), "اراک", 26 },
                    { 1022, new Guid("fb087b74-5741-45d3-a707-9268f2ef834d"), "آوه", 26 },
                    { 1021, new Guid("9a9b18c5-29ba-4eaf-bb95-24254e58ce24"), "آشتيان", 26 },
                    { 1020, new Guid("73b1ce8d-a7dc-4abe-a540-ff6922ff4396"), "آستانه", 26 },
                    { 1019, new Guid("7b53b13a-8d1d-4266-8b24-3db62026d720"), "گوهران", 25 },
                    { 1018, new Guid("c611280c-8b93-407e-bbbf-56f5318a9ae2"), "گروک", 25 },
                    { 1025, new Guid("5cae04dd-136e-4b8c-9b36-57f06cde4684"), "توره", 26 },
                    { 1017, new Guid("ecc15c6f-45bc-4048-bb73-527e7a6552be"), "کيش", 25 },
                    { 1015, new Guid("07e67aa3-5fcb-4904-bb11-070b7633b0a5"), "کوشکنار", 25 },
                    { 1014, new Guid("9ee734bc-fc69-48d6-8322-00e051d9f692"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("a8a8f73d-5fdf-456d-b9bb-c17545e5da9b"), "کنگ", 25 },
                    { 1012, new Guid("5b5eb55c-d59c-4a0a-a01a-5a9b45f43927"), "چارک", 25 },
                    { 1011, new Guid("65da3b53-5483-43c0-b88b-02e9d8904041"), "پارسيان", 25 },
                    { 1010, new Guid("1ba3f4e7-eec7-4675-b178-5bfb4f6f288c"), "هشتبندي", 25 },
                    { 1009, new Guid("3f10ca1d-2411-4efe-b798-c30f8f7e9a68"), "هرمز", 25 },
                    { 1016, new Guid("a753a012-5f33-4c3d-98ec-b1732c645fff"), "کوهستک", 25 },
                    { 1085, new Guid("abd917b7-f424-4987-b9b3-37fef4325cfb"), "لوشان", 27 },
                    { 1026, new Guid("25ee45a6-43e6-4b64-8c9b-b124db39ca46"), "جاورسيان", 26 },
                    { 1028, new Guid("3b2a00b1-e357-4e48-825f-fae9e835f202"), "خمين", 26 },
                    { 1044, new Guid("979c29f1-89cc-475c-b596-049d0539b885"), "محلات", 26 },
                    { 1043, new Guid("66236244-dbdb-4608-af93-8cb28c54729d"), "مامونيه", 26 },
                    { 1042, new Guid("8c0ec71b-2dfd-41b5-a360-ef35a57c13ad"), "قورچي باشي", 26 },
                    { 1041, new Guid("0081885d-dc3f-42b2-b8ce-744498ef9745"), "فرمهين", 26 },
                    { 1040, new Guid("df5d45a0-1e9b-4da7-b40b-79022baa412a"), "غرق آباد", 26 },
                    { 1039, new Guid("574b46b4-b16c-4a84-bdc2-ad28f2b984a2"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("9915b17f-f12a-4864-b27a-1a0451496a3d"), "شهباز", 26 },
                    { 1027, new Guid("5a3a4459-f7e1-4c26-a72f-9258eaf062f5"), "خشکرود", 26 },
                    { 1037, new Guid("b2c6f58c-6900-4ade-8f41-b8a117a70f1c"), "شازند", 26 },
                    { 1035, new Guid("50796807-c6eb-453e-a8eb-ad0e82c29ffe"), "ساروق", 26 },
                    { 1034, new Guid("dfa4d21e-520f-4171-93e4-74a86dcae67b"), "زاويه", 26 },
                    { 1033, new Guid("0946c969-0743-4da1-8351-5e41cfc7bd21"), "رازقان", 26 },
                    { 1032, new Guid("298e420e-e9c1-41f6-a5bb-64253fe5704a"), "دليجان", 26 },
                    { 1031, new Guid("9126ef9d-3edc-4778-8138-c7c5eb2f25d4"), "داود آباد", 26 },
                    { 1030, new Guid("e80282db-cb60-4536-a542-61a8a5f43afd"), "خنداب", 26 },
                    { 1029, new Guid("f42ef1e2-8365-4b6f-81dc-eb9841d349f9"), "خنجين", 26 },
                    { 1036, new Guid("6ef44fad-7cc1-4095-b77e-072a621aa233"), "ساوه", 26 },
                    { 615, new Guid("cdb00a0e-389a-4682-9252-d83a8f5a0550"), "اصغرآباد", 19 },
                    { 613, new Guid("e3882ea1-8961-4894-bb27-83ecae29cec8"), "ابوزيد آباد", 19 },
                    { 1241, new Guid("e90e405f-9af2-4f8a-949e-bec191874d9c"), "گراب سفلي", 31 },
                    { 208, new Guid("7f3bc0d1-40c5-4b5f-aa31-2e11daad3f8f"), "سلطان آباد", 8 },
                    { 207, new Guid("e04f717d-8232-4e8a-bf46-e8a9310b35b3"), "سلامي", 8 },
                    { 206, new Guid("4c591043-7344-4fb0-b050-43715c05dc4a"), "سفيد سنگ", 8 },
                    { 205, new Guid("fe86796e-5088-405f-8a52-3d6053be326f"), "سرخس", 8 },
                    { 204, new Guid("ac2d39f1-01ce-4255-ad76-aafbe033fbac"), "سبزوار", 8 },
                    { 203, new Guid("2745f2da-86a1-49f0-a139-2498589997a1"), "ريوش", 8 },
                    { 202, new Guid("2b3aa0f1-09e0-4e55-84dd-8f43f422dcb0"), "روداب", 8 },
                    { 201, new Guid("75bf375e-0404-459c-a75e-01848810febf"), "رضويه", 8 },
                    { 200, new Guid("8856057f-8003-436f-9c74-4145ff167fde"), "رشتخوار", 8 },
                    { 199, new Guid("3285ffa4-5afd-440b-874b-b02380076ee3"), "رباط سنگ", 8 },
                    { 198, new Guid("de9d3e50-323c-469c-a94b-c52de93cbdd0"), "دولت آباد", 8 },
                    { 197, new Guid("86341e30-0eab-41f7-9826-699301eb59ad"), "درگز", 8 },
                    { 196, new Guid("a8898c45-e702-4627-af8b-8dcb2917e951"), "درود", 8 },
                    { 195, new Guid("2bb321b2-4adc-497c-b74c-3f33f3f1a103"), "داورزن", 8 },
                    { 194, new Guid("5030e4b4-4233-4418-ae03-ee2021067eb3"), "خواف", 8 },
                    { 209, new Guid("68005eff-c120-463c-b4de-3865de52953f"), "سنگان", 8 },
                    { 193, new Guid("ff047575-5c59-4d63-8c9b-ebd51c3392f6"), "خليل آباد", 8 },
                    { 210, new Guid("2d2c9df0-38a2-4b2a-a350-5d4d7087a65c"), "شادمهر", 8 },
                    { 212, new Guid("2909baa7-c86b-483f-999f-4fde564709ec"), "ششتمد", 8 },
                    { 227, new Guid("f845a186-3a72-46af-b192-378a4b28b70c"), "مزدآوند", 8 },
                    { 226, new Guid("82318ffc-5c10-43da-b6ce-c4fb62bfd878"), "لطف آباد", 8 },
                    { 225, new Guid("1d031392-5a82-44a0-a8bf-3e7a01a4be83"), "قوچان", 8 },
                    { 224, new Guid("ade9911f-0940-4137-9cfe-1153c728e2b6"), "قلندر آباد", 8 },
                    { 223, new Guid("0acff910-a999-437d-b837-f4258b3916d5"), "قدمگاه", 8 },
                    { 222, new Guid("b626b217-0d4e-4447-9ed5-8bd65a008850"), "قاسم آباد", 8 },
                    { 221, new Guid("b2c3eb73-8e60-4c72-b81b-af0f9d40c3d9"), "فيض آباد", 8 },
                    { 220, new Guid("a1d47746-ec1e-480c-a1c6-d30b4a48c47e"), "فيروزه", 8 },
                    { 219, new Guid("69ad4b2f-7a08-4026-a12b-9b40fef2e23f"), "فريمان", 8 },
                    { 218, new Guid("726b9175-4ecb-4f83-a1bb-051ebf6aef9e"), "فرهاد گرد", 8 },
                    { 217, new Guid("ea118250-1c03-4d0f-bdad-e898736dd4d7"), "عشق آباد", 8 },
                    { 216, new Guid("0294a179-711f-4bbc-8354-08c3998d9101"), "طرقبه", 8 },
                    { 215, new Guid("b8700c75-45e8-43e7-9485-22d2b6e0023c"), "صالح آباد", 8 },
                    { 214, new Guid("d3f19c9d-cde5-4b64-9d83-5991010c818b"), "شهرآباد", 8 },
                    { 213, new Guid("7e3bf8b1-61f5-45ae-a735-9d1dad594627"), "شهر زو", 8 },
                    { 211, new Guid("023c2d65-7418-47cf-91a1-85b42d7c50b1"), "شانديز", 8 },
                    { 192, new Guid("79ce3d17-9f89-4fb9-8199-4268a3aad38c"), "خرو", 8 },
                    { 191, new Guid("039ca734-0927-4728-b398-cc389c70489e"), "جنگل", 8 },
                    { 190, new Guid("1d344d3d-4ac1-4e76-89c9-104128b6193f"), "جغتاي", 8 },
                    { 169, new Guid("9db4ebfe-a492-4a1e-aaed-63836d3271bd"), "نازک عليا", 7 },
                    { 168, new Guid("7b8ced36-e190-4a07-9f3f-241e8ffd167b"), "ميرآباد", 7 },
                    { 167, new Guid("69cfcbca-ab20-4ef3-a118-6549e2183bd0"), "مياندوآب", 7 },
                    { 166, new Guid("944d57c9-a9f1-4c5a-b28b-364694a0ab8c"), "مهاباد", 7 },
                    { 165, new Guid("ec6e11d8-3d19-45c4-87a8-1454507659df"), "مرگنلر", 7 },
                    { 164, new Guid("5cd7c20d-ea7a-475a-bc41-4bd35ec15dd2"), "محمود آباد", 7 },
                    { 163, new Guid("7fe66828-d841-4585-8601-d1c3ef37b825"), "محمد يار", 7 },
                    { 162, new Guid("a3da9752-5b1b-49f2-bfb0-784744389820"), "ماکو", 7 },
                    { 161, new Guid("bf18c81d-345c-4541-9d61-b42e9a0b8650"), "قوشچي", 7 },
                    { 160, new Guid("a16dbcef-8fe5-40d2-beb4-57aeb5425ed3"), "قطور", 7 },
                    { 159, new Guid("a0f57fa4-f166-4b1a-b2dc-8afcd98bae03"), "قره ضياء الدين", 7 },
                    { 158, new Guid("17e76316-6c63-4fed-abd3-2b019d2552bb"), "فيرورق", 7 },
                    { 157, new Guid("12053a33-de60-4601-a644-91bfbe724726"), "شوط", 7 },
                    { 156, new Guid("d0c7d429-e418-431d-b33b-ec61bac90342"), "شاهين دژ", 7 },
                    { 155, new Guid("d7bc3d60-e3a6-4290-8f62-849d3fd787c5"), "سيه چشمه", 7 },
                    { 170, new Guid("d052f018-f077-4c90-b854-83a6130e5af2"), "نالوس", 7 },
                    { 171, new Guid("99e96373-2040-4c50-a6b5-00cf93e9c0d9"), "نقده", 7 },
                    { 172, new Guid("db92a724-a3ad-428b-81bc-fce296c446a9"), "نوشين", 7 },
                    { 173, new Guid("29376763-d4cc-4be2-85ed-11b697ccd189"), "پلدشت", 7 },
                    { 189, new Guid("f47684d7-5f9b-4f2c-9397-32940b335ea8"), "تربت حيدريه", 8 },
                    { 188, new Guid("5ddf4b03-36fe-4fd6-a892-04c3e354ee09"), "تربت جام", 8 },
                    { 187, new Guid("3bf2f651-44ca-48c7-a696-be098198cbd3"), "تايباد", 8 },
                    { 186, new Guid("902f94aa-8e12-4c62-91ba-431037ab3564"), "بيدخت", 8 },
                    { 185, new Guid("6a2fab46-a20a-44c0-b633-f000306c9f54"), "بردسکن", 8 },
                    { 184, new Guid("3e8bc6af-01c7-4152-96d4-53ef65b05362"), "بجستان", 8 },
                    { 183, new Guid("f15c4133-d4f7-45b0-ba8d-7e67782db76e"), "بايک", 8 },
                    { 228, new Guid("4cca791f-337f-4518-84e3-112e99178f17"), "مشهد", 8 },
                    { 182, new Guid("f0f5b4b5-b48e-4f5c-bba9-0c49c81fcbd6"), "بار", 8 },
                    { 180, new Guid("98b64dea-339f-492d-9018-0fbedce45f5a"), "باجگيران", 8 },
                    { 179, new Guid("c6148689-7036-46b6-a906-9d46e241b711"), "انابد", 8 },
                    { 178, new Guid("a234ec9d-19da-4f3f-b3da-86d8db6b7e41"), "احمدآباد صولت", 8 },
                    { 177, new Guid("55b49cbe-b9b2-433a-a7d5-9f9feb69987a"), "گردکشانه", 7 },
                    { 176, new Guid("e3cdede0-9eef-46aa-83cb-b3a9e9faafe7"), "کشاورز", 7 },
                    { 175, new Guid("36ec6856-0fcc-44c2-b7bc-c9375c0f17b5"), "چهار برج", 7 },
                    { 174, new Guid("fdb9ae9c-e3bc-4411-9ca6-36ef57cd67ec"), "پيرانشهر", 7 },
                    { 181, new Guid("bc4741ee-d8d2-42ce-829b-4bcb68009d1f"), "باخرز", 8 },
                    { 154, new Guid("4843094a-b61c-49f4-94d6-2939ebd2a587"), "سيمينه", 7 },
                    { 229, new Guid("aaadcaba-db50-49dd-b7c2-6e380aef7e56"), "مشهدريزه", 8 },
                    { 231, new Guid("6981872e-c9ab-47c2-8db0-2cd93e6a3167"), "نشتيفان", 8 },
                    { 285, new Guid("0f423a6a-ba3e-43ea-adde-c10b7861da89"), "گشت", 9 },
                    { 284, new Guid("bfe71f20-1d77-4a60-803f-a932167ef800"), "کنارک", 9 },
                    { 283, new Guid("2e0fe05d-3dbc-45db-b2f2-a9ca1354f7ec"), "چاه بهار", 9 },
                    { 282, new Guid("f197f131-6dd2-4df4-8086-9197ad783ae0"), "پيشين", 9 },
                    { 281, new Guid("d060a601-ad17-4d76-bda5-393c7c24ca9a"), "هيدوچ", 9 },
                    { 280, new Guid("89c79c02-c5ef-40c6-ae16-24e06ec99e58"), "نگور", 9 },
                    { 279, new Guid("25326188-0d61-4e5c-9f07-aa6dfa18d44a"), "نيک شهر", 9 },
                    { 278, new Guid("0b14e0c5-a1de-437a-a2ad-d179a67d54a2"), "نوک آباد", 9 },
                    { 277, new Guid("fce932cb-c01a-42df-a6aa-8f2f60277946"), "نصرت آباد", 9 },
                    { 276, new Guid("1e96b5d2-afe7-447f-9f7a-5629f4dfa8dd"), "ميرجاوه", 9 },
                    { 275, new Guid("a65d3b84-52ec-4f8b-9bbc-0f8742e3bde6"), "مهرستان", 9 },
                    { 274, new Guid("b48b03ad-5ab7-438b-bc9f-f5b5cbff27a1"), "محمدي", 9 },
                    { 273, new Guid("4a840817-0115-4fcf-b8f0-922944a36178"), "محمدان", 9 },
                    { 272, new Guid("74f1c3c9-d70f-4a8c-8787-e4011077d9b8"), "محمد آباد", 9 },
                    { 271, new Guid("5928be53-b2a4-4503-b32b-db35b2329d2c"), "قصر قند", 9 },
                    { 286, new Guid("b183ae49-d792-4958-a43b-dd7f9ac80163"), "گلمورتي", 9 },
                    { 270, new Guid("0e71f1e1-970b-4e19-a941-6b4863886954"), "فنوج", 9 },
                    { 287, new Guid("845ce5b0-96bb-4c31-bade-3483f122c2cc"), "آرين شهر", 10 },
                    { 289, new Guid("79615749-b65d-47b8-8d22-46463cdc1d55"), "ارسک", 10 },
                    { 304, new Guid("16a47862-108b-447b-bd92-3c2a8f3fbce1"), "طبس", 10 },
                    { 303, new Guid("d7477f4b-1db2-41bf-8068-14540fa9d695"), "شوسف", 10 },
                    { 302, new Guid("356bdd70-4f51-429d-aae8-41c9fab2462c"), "سه قلعه", 10 },
                    { 301, new Guid("6859ff84-2704-4fdf-bca2-c564d293dbab"), "سربيشه", 10 },
                    { 614, new Guid("8b15770f-1c8d-48ff-bfc3-a5ff37507485"), "اردستان", 19 },
                    { 299, new Guid("719fea5a-5d35-4d48-97fa-344929458e5b"), "زهان", 10 },
                    { 298, new Guid("1a913198-e409-43e1-8c10-57afa59351c2"), "ديهوک", 10 },
                    { 297, new Guid("54b22bd4-7800-4d21-9be8-d3b370eb2ab8"), "خوسف", 10 },
                    { 296, new Guid("3e94ec15-3f47-4576-ab4e-d76b495d92e7"), "خضري دشت بياض", 10 },
                    { 295, new Guid("ef797fd5-0262-4b29-8d25-987f97493fc6"), "حاجي آباد", 10 },
                    { 294, new Guid("eaddeb0c-6cb7-48aa-9c3f-92b1e0f6c324"), "بيرجند", 10 },
                    { 293, new Guid("d19f7259-c946-4bde-8cb2-82a5250ec965"), "بشرويه", 10 },
                    { 292, new Guid("8e83cbc3-ecae-4528-828a-fed0e36fcc02"), "اسلاميه", 10 },
                    { 291, new Guid("fcf1bb1f-b773-498f-88fe-769eb3e9e30f"), "اسفدن", 10 },
                    { 290, new Guid("3ba5de2b-2846-46e5-bced-f8b5f746e021"), "اسديه", 10 },
                    { 288, new Guid("f33b2bbd-4151-4651-b6aa-147d28962cfc"), "آيسک", 10 },
                    { 269, new Guid("493f2039-5e02-43a0-938c-89d7726b46c4"), "علي اکبر", 9 },
                    { 268, new Guid("355d9c26-df5b-43b1-b840-30bff3d0b733"), "سيرکان", 9 },
                    { 267, new Guid("32b218d4-61cc-4099-972b-a473f9ef569f"), "سوران", 9 },
                    { 246, new Guid("81d341a2-a9d8-4fe5-afb8-654a13572905"), "کلات", 8 },
                    { 245, new Guid("5d22c7c9-0746-4e3b-8cb7-ecf9333198d7"), "کدکن", 8 },
                    { 244, new Guid("ca907a6d-044f-405e-95b6-8ac07ce4ea92"), "کاشمر", 8 },
                    { 243, new Guid("ac649bc6-e34e-4b17-a605-2d6c702e4c96"), "کاريز", 8 },
                    { 242, new Guid("8c9d64b2-5bd3-42b9-806c-a87e50ba8512"), "کاخک", 8 },
                    { 241, new Guid("fd90dc71-3188-4b74-a90b-b14260046800"), "چکنه", 8 },
                    { 240, new Guid("3bf60d51-19b9-4d5d-ac4b-8f320cc39bfa"), "چناران", 8 },
                    { 239, new Guid("800cb6ea-f7bc-4af9-9c61-8d64bb976f6b"), "چاپشلو", 8 },
                    { 238, new Guid("a1f645da-3f73-48cf-a6b9-86a739a81e1c"), "يونسي", 8 },
                    { 237, new Guid("ae6b5676-b8c0-419b-8d26-c5e3deeaa0a1"), "همت آباد", 8 },
                    { 236, new Guid("40746c16-cd06-4fbc-b542-5ab0a09b57ef"), "نيل شهر", 8 },
                    { 235, new Guid("961b7592-a703-45f8-abce-3278b50fbe3f"), "نيشابور", 8 },
                    { 234, new Guid("66685c05-567d-438b-a45e-81dd46bf2c85"), "نوخندان", 8 },
                    { 233, new Guid("1a383588-cbf4-43b1-879b-9b76cb350d37"), "نقاب", 8 },
                    { 232, new Guid("7c139c38-2451-4d19-8de8-73248a20e0f0"), "نصرآباد", 8 },
                    { 247, new Guid("8073b7df-64b4-41db-aa2c-8905bcc272f4"), "کندر", 8 },
                    { 248, new Guid("f11ce60e-ba62-4188-9e53-6141ee87db2a"), "گلمکان", 8 },
                    { 249, new Guid("19f8f49a-45c3-4924-91b3-5ec59fec3a82"), "گناباد", 8 },
                    { 250, new Guid("baceded7-309c-4846-b57c-b01bed16797e"), "اديمي", 9 },
                    { 266, new Guid("bbe0d91e-acae-4ca3-abb5-45a40eadee08"), "سرباز", 9 },
                    { 265, new Guid("8928dbbd-79c5-4c1d-b194-76ea9030a40c"), "سراوان", 9 },
                    { 264, new Guid("bcdb45ce-2dc8-40f4-9d7a-5eb65df6dc84"), "زهک", 9 },
                    { 263, new Guid("6b339a00-de82-4ac7-9f3f-7206e1af144c"), "زرآباد", 9 },
                    { 262, new Guid("10f22a67-2354-4445-94f9-1669f4644998"), "زاهدان", 9 },
                    { 261, new Guid("00151101-b8ac-42b0-9520-41cd7ff32e28"), "زابل", 9 },
                    { 260, new Guid("a642aaa4-a979-42f1-817f-e823fcffee23"), "راسک", 9 },
                    { 230, new Guid("cebdcde2-5eca-4272-84a4-091314840c5d"), "ملک آباد", 8 },
                    { 259, new Guid("1f910cda-8009-456d-a989-5fc0a018802f"), "دوست محمد", 9 },
                    { 257, new Guid("37de5a01-8522-4cd2-a7a8-f7add6fa9dcc"), "جالق", 9 },
                    { 256, new Guid("859cb521-a92d-4c7a-920b-c1b52e55ee22"), "بنجار", 9 },
                    { 255, new Guid("35cf2816-c867-4faa-8c62-63aacb0c9d83"), "بنت", 9 },
                    { 254, new Guid("f074aff3-ef9d-454f-a6d0-496ae9ecfeb2"), "بمپور", 9 },
                    { 253, new Guid("7a068727-96bf-4413-971f-db6c06c5b583"), "بزمان", 9 },
                    { 252, new Guid("371e1ab8-083e-45a2-bbf1-2223edc19834"), "ايرانشهر", 9 },
                    { 251, new Guid("364def0e-dcd5-49da-a02a-03dd7c220b69"), "اسپکه", 9 },
                    { 258, new Guid("e7c67d95-5965-45f0-b573-0f9dc1b999cc"), "خاش", 9 },
                    { 305, new Guid("dda51cf4-2807-433c-985c-d7acd85419ba"), "طبس مسينا", 10 },
                    { 153, new Guid("0d592bac-a51f-4c90-9ed0-1f3992c50c54"), "سيلوانه", 7 },
                    { 151, new Guid("17a98f8e-8f6a-4820-b333-d20765048216"), "سرو", 7 },
                    { 54, new Guid("5636cc47-ec71-4996-873f-8441210f0c75"), "پردنجان", 2 },
                    { 53, new Guid("1d229518-1341-4835-9201-e9254f4e2acb"), "وردنجان", 2 },
                    { 52, new Guid("72616a73-bd1e-404c-9a04-0b3ccc055e55"), "هفشجان", 2 },
                    { 51, new Guid("9627ec27-0596-4e60-9995-a2d011bd8311"), "هاروني", 2 },
                    { 50, new Guid("4d834038-5b3d-41b5-a667-94e278efa768"), "نقنه", 2 },
                    { 49, new Guid("bcf5db9c-6f32-4248-ac6e-ffb1e3ceb499"), "نافچ", 2 },
                    { 48, new Guid("ead71b18-e51f-4699-95d3-88617e134942"), "ناغان", 2 },
                    { 47, new Guid("305fa8d1-c7d6-4b08-92a2-f2b60e4cab80"), "منج", 2 },
                    { 46, new Guid("62d3e468-b95f-4efa-b3e6-7be9e584884b"), "مال خليفه", 2 },
                    { 45, new Guid("aed68e24-bd4f-4136-bbb0-e44c5bef98cd"), "لردگان", 2 },
                    { 44, new Guid("5c206d7a-5d45-49e0-b53a-42a9f4a7ac4b"), "فرخ شهر", 2 },
                    { 43, new Guid("27ad2b70-01b0-40a3-99fd-c7eaa9c5abb7"), "فرادنبه", 2 },
                    { 42, new Guid("08d26644-d47c-4b52-b54f-5a1b819ce199"), "فارسان", 2 },
                    { 41, new Guid("a39caef9-66e1-4ad1-8dcb-76e222c16312"), "طاقانک", 2 },
                    { 40, new Guid("7d1d4be7-b384-4349-8091-36f2d4e82341"), "صمصامي", 2 },
                    { 55, new Guid("fd58ab89-3aa9-45a9-a7fb-c1c636f37c1b"), "چليچه", 2 },
                    { 39, new Guid("570971f2-bb3e-4777-b14f-86d2d50b8ebf"), "شهرکرد", 2 },
                    { 56, new Guid("e0a2abb2-b71f-4bd8-9436-d60538ad11d8"), "چلگرد", 2 },
                    { 58, new Guid("5aae7c8e-a9d7-4f61-8f1d-70f014b11688"), "کيان", 2 },
                    { 73, new Guid("3fde1073-bb17-4abb-b86e-2aa35e8801dc"), "سنخواست", 3 },
                    { 72, new Guid("1e2254e6-5de0-46b9-b1c0-4b2b226b26e9"), "زيارت", 3 },
                    { 71, new Guid("a0f7d4bf-2867-45bf-aae2-81ff72ab8699"), "راز", 3 },
                    { 70, new Guid("910c3121-31e7-42c5-9c06-6d37a3f76a34"), "درق", 3 },
                    { 69, new Guid("9ff07724-90d3-4a0c-bac1-bc595e1409cb"), "حصارگرمخان", 3 },
                    { 68, new Guid("b96ba46a-985e-4b08-a9cd-aacf90baaff6"), "جاجرم", 3 },
                    { 67, new Guid("32c61022-7e4d-43cd-a25b-465b212cf619"), "تيتکانلو", 3 },
                    { 66, new Guid("3dc2e037-c54b-422f-bc84-ef471b978c1b"), "بجنورد", 3 },
                    { 65, new Guid("a1317536-4a85-4dee-b060-e46696b887c1"), "ايور", 3 },
                    { 64, new Guid("b656e4ec-c8ac-4464-bb70-d0dc62b19c41"), "اسفراين", 3 },
                    { 63, new Guid("baf6cf6e-a905-467d-b35f-3eee62b151b9"), "آوا", 3 },
                    { 62, new Guid("23cd413a-ccb0-4345-95c5-d06aa80953b1"), "آشخانه", 3 },
                    { 61, new Guid("f31abbe3-94cc-409c-a891-4882ed5b0f24"), "گوجان", 2 },
                    { 60, new Guid("041d4a5e-1e03-44f9-b156-533184b82ba3"), "گهرو", 2 },
                    { 59, new Guid("7ad97f1d-681f-484a-9e50-98eb7dabb5d0"), "گندمان", 2 },
                    { 57, new Guid("1f7ce60d-1291-4ee5-b2dd-1a9bd71f067b"), "کاج", 2 },
                    { 38, new Guid("2cce3d48-a40e-4597-a170-e03d4276bf77"), "شلمزار", 2 },
                    { 37, new Guid("07b24966-e280-4e58-b5d7-e8b656b8e2d4"), "سورشجان", 2 },
                    { 36, new Guid("3bd6932b-a78e-4218-9320-e30c3765cc47"), "سودجان", 2 },
                    { 15, new Guid("64fe48e9-78c5-4db4-8586-cc62afe874b1"), "مهردشت", 1 },
                    { 14, new Guid("cb4c6a55-2776-4da2-bdea-c6e949ac780f"), "مروست", 1 },
                    { 13, new Guid("f6ec019c-b66e-4d16-9b72-cd829f13a029"), "عقدا", 1 },
                    { 12, new Guid("d12cd391-7457-4e87-a7e1-d95e843f6051"), "شاهديه", 1 },
                    { 11, new Guid("607a688b-489b-4b29-924f-9b17654b695f"), "زارچ", 1 },
                    { 10, new Guid("c85f25bc-1eac-4136-aded-70f4a1a6a98a"), "خضر آباد", 1 },
                    { 9, new Guid("1c95249e-25d6-41e4-a15a-1c2db4d45bb5"), "حميديا", 1 },
                    { 8, new Guid("5743ec72-efd0-4762-a45f-f80c74b8d30e"), "تفت", 1 },
                    { 7, new Guid("f61e9ee2-8b5d-44df-bd94-4a67f4858806"), "بهاباد", 1 },
                    { 6, new Guid("7a05568d-54e4-4256-a065-4ad60fa8dc5d"), "بفروئيه", 1 },
                    { 5, new Guid("15d14df7-2e74-45eb-a2a7-5fc05a6eaf3a"), "بافق", 1 },
                    { 4, new Guid("69f15cd8-8266-4238-8b5e-b21a0949005e"), "اشکذر", 1 },
                    { 3, new Guid("94077e09-5149-4e68-bcd5-e82f24ad204a"), "اردکان", 1 },
                    { 2, new Guid("5a901fb1-8184-4bbd-b014-dc0af408858f"), "احمد آباد", 1 },
                    { 1, new Guid("2434b279-0dad-45c4-b28d-7fb109d32f75"), "ابرکوه", 1 },
                    { 16, new Guid("8ae4880e-f540-46c6-bf46-f1a431236f8d"), "مهريز", 1 },
                    { 17, new Guid("3ce46476-5ab5-470b-aa06-0fdac81671de"), "ميبد", 1 },
                    { 18, new Guid("1bf4ade2-88ed-4670-bfc4-49b2a0442d68"), "ندوشن", 1 },
                    { 19, new Guid("5be68ce5-a196-4663-bd14-41323f28ebb5"), "نير", 1 },
                    { 35, new Guid("f2392653-41fe-417d-92fe-d2408f5eb0c0"), "سفيد دشت", 2 },
                    { 34, new Guid("fd947b73-1f50-4ec1-97e4-984af6bc28b6"), "سردشت لردگان", 2 },
                    { 33, new Guid("5f674e24-e4f1-4e76-be30-4be8fac7e6ba"), "سرخون", 2 },
                    { 32, new Guid("ab9aba23-2b4a-40e5-afe1-e8f770a8cc12"), "سامان", 2 },
                    { 31, new Guid("7284c26d-1db2-4526-936a-84861f642345"), "دشتک", 2 },
                    { 30, new Guid("5166fa45-8791-4fe0-8f6f-3274ba6b9383"), "دستناء", 2 },
                    { 29, new Guid("5c12851c-0b3a-490a-96ec-963b555161d4"), "جونقان", 2 },
                    { 74, new Guid("0234c2a6-745b-4723-b8ca-ac56f656de20"), "شوقان", 3 },
                    { 28, new Guid("3f8de504-15f9-4786-aaa8-b6135fa12a7d"), "بن", 2 },
                    { 26, new Guid("35d6d6c6-ebf3-47d4-96a1-2c82635b3390"), "بروجن", 2 },
                    { 25, new Guid("e78d1c1f-052d-41e1-96c1-646304d8ba7a"), "بازفت", 2 },
                    { 24, new Guid("db455ca2-d1ac-4d0d-bf50-e133f6920f26"), "باباحيدر", 2 },
                    { 23, new Guid("406c852a-3dae-4c6c-bced-6a3947c73783"), "اردل", 2 },
                    { 22, new Guid("e860fe5f-2002-4649-9f0f-d8720a49359a"), "آلوني", 2 },
                    { 21, new Guid("9b3affe1-de6a-4b93-b6d5-c5dafddce05a"), "يزد", 1 },
                    { 20, new Guid("bee44174-87e2-4c59-aec7-e57326f23a2b"), "هرات", 1 },
                    { 27, new Guid("afb10518-dabd-4e3a-9062-130b595c6e9b"), "بلداجي", 2 },
                    { 152, new Guid("0f535876-02da-4b7c-8963-ff826411b7a9"), "سلماس", 7 },
                    { 75, new Guid("da8d3cd5-54dc-4573-8acd-c967fb70b24e"), "شيروان", 3 },
                    { 77, new Guid("f7658a10-919c-4e94-901d-21fb878f29c9"), "فاروج", 3 },
                    { 131, new Guid("167cdcaf-0659-4011-8c1f-7f2e98b7a5ff"), "پيرتاج", 6 },
                    { 130, new Guid("ce5fad11-1f1c-4ee1-b24a-afd465a982c7"), "ياسوکند", 6 },
                    { 129, new Guid("0beddeef-a30a-43d0-91a8-76e7aa3ab29f"), "موچش", 6 },
                    { 128, new Guid("9838d3b6-1cd8-49e3-9eec-f0ec08070dbd"), "مريوان", 6 },
                    { 127, new Guid("89a0fb0b-d62c-4e03-a7b0-3e95b7ba2f56"), "قروه", 6 },
                    { 126, new Guid("69f3ba06-d940-4587-aadb-1d725b267524"), "صاحب", 6 },
                    { 125, new Guid("db188d1b-2389-4b85-a01e-2e04171323c0"), "شويشه", 6 },
                    { 124, new Guid("34707f4f-0b85-4c63-b179-00f589ed141b"), "سنندج", 6 },
                    { 123, new Guid("c8004a4e-f6d6-46ae-9ef0-bcb922a07da0"), "سقز", 6 },
                    { 122, new Guid("53034059-1f27-424d-ada9-f32bc92ab017"), "سريش آباد", 6 },
                    { 121, new Guid("64ce2861-ff91-451c-a7e2-c316a1671fa8"), "سرو آباد", 6 },
                    { 120, new Guid("c042486c-02da-4b36-b6c0-e30ffb1ff4a6"), "زرينه", 6 },
                    { 119, new Guid("6d36df73-eca9-42cf-8734-1f15c6662fe9"), "ديواندره", 6 },
                    { 118, new Guid("7e17d09f-ba2f-4a2b-a46a-8661e80d6bff"), "دهگلان", 6 },
                    { 117, new Guid("f84ac1d9-121b-4b00-9eef-5ffbf449f57c"), "دلبران", 6 },
                    { 132, new Guid("c1b44e24-67bd-4e0e-821a-4ae933f49f5c"), "چناره", 6 },
                    { 116, new Guid("95311de0-2c70-4569-89b2-2cfbbe03777b"), "دزج", 6 },
                    { 133, new Guid("20ad59c3-a856-4b34-8197-2ff13a1e9ca3"), "کامياران", 6 },
                    { 135, new Guid("299be0af-7f25-489f-99b6-65967d97ec29"), "کاني سور", 6 },
                    { 150, new Guid("22e8e2a3-7103-4a3d-aa8d-a49b20734b97"), "سردشت", 7 },
                    { 149, new Guid("ea400357-f91f-4b06-96c5-5066ee9f5bf1"), "زرآباد", 7 },
                    { 148, new Guid("f8876771-9afd-4a67-b72a-a169f08aca4e"), "ربط", 7 },
                    { 147, new Guid("dc5b3f9a-5dbe-410f-9042-a9fedd877986"), "ديزج ديز", 7 },
                    { 146, new Guid("8426c444-94b1-4e6e-b15a-c0d08211b002"), "خوي", 7 },
                    { 145, new Guid("283797c1-6080-424b-8e8e-ea9e9ea6090b"), "خليفان", 7 },
                    { 144, new Guid("6a3324e8-fe59-41cb-8a4b-31e8351c2f08"), "تکاب", 7 },
                    { 143, new Guid("c8694925-5822-480e-b9d8-94af775c17d8"), "تازه شهر", 7 },
                    { 142, new Guid("f6699287-3af5-430f-9133-61e8e65658e4"), "بوکان", 7 },
                    { 141, new Guid("808ad628-e631-472f-bf09-738d68ae8229"), "بازرگان", 7 },
                    { 140, new Guid("2061609b-5109-4a1f-b0de-07734e0af1ec"), "باروق", 7 },
                    { 139, new Guid("13a1c16a-4277-483f-abcd-a679a2a13388"), "ايواوغلي", 7 },
                    { 138, new Guid("342e5f2d-5c40-4107-8cc8-e13b03cf75ee"), "اشنويه", 7 },
                    { 137, new Guid("8a62886e-e37e-4343-822e-3d75c8ed0586"), "اروميه", 7 },
                    { 136, new Guid("e3f880f1-55b1-4ef4-9938-92686b1f7b1c"), "آواجيق", 7 },
                    { 134, new Guid("5e630e37-5b95-4005-b511-fdb080c4a4c1"), "کاني دينار", 6 },
                    { 115, new Guid("d76e8ab2-3ffd-4351-8fcb-afaaaa836737"), "توپ آغاج", 6 },
                    { 114, new Guid("f324fa12-0a3d-4628-91a0-6ca7d8ae4760"), "بيجار", 6 },
                    { 113, new Guid("b08f8a7b-f5b0-4869-a143-d416876cd644"), "بوئين سفلي", 6 },
                    { 92, new Guid("fc58b289-3234-4a28-8fb5-b0d7385aa40e"), "مشکين دشت", 4 },
                    { 91, new Guid("3bf4660c-6289-442b-b7e2-a1981579af47"), "محمد شهر", 4 },
                    { 90, new Guid("1c6e1fb6-e70b-4a09-b782-a0dead338c67"), "ماهدشت", 4 },
                    { 89, new Guid("3adb0ce3-04e3-44fd-8463-1531541ed481"), "فرديس", 4 },
                    { 88, new Guid("329b500a-11e8-4dba-8ade-2453d7b63d26"), "طالقان", 4 },
                    { 87, new Guid("c955054e-676d-45a2-a174-1f6f93ec67f8"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("5b60b273-6e0c-412c-851c-053dc2c700c7"), "تنکمان", 4 },
                    { 85, new Guid("157b2dca-c97d-44cf-9ae3-83140eb77aec"), "اشتهارد", 4 },
                    { 84, new Guid("bdbb09d4-74f4-4e71-bb56-5f25c3834050"), "آسارا", 4 },
                    { 83, new Guid("e1fd9cd3-ea3d-435e-8d66-d6cceca18ead"), "گرمه", 3 },
                    { 82, new Guid("182e19a2-bcf0-4195-a07f-467a257799cd"), "چناران شهر", 3 },
                    { 81, new Guid("dce2e60e-6cb8-481b-afaf-d0bb63c531da"), "پيش قلعه", 3 },
                    { 80, new Guid("b3c4332d-c721-4c33-b53c-bce76d925803"), "لوجلي", 3 },
                    { 79, new Guid("045cc3a1-6a03-4549-9ad4-16a92bde4a4a"), "قوشخانه", 3 },
                    { 78, new Guid("6ef4d5d8-748f-4a28-a6eb-5824f9eb2a09"), "قاضي", 3 },
                    { 93, new Guid("d67b8dcb-64d8-467f-a85e-83bd3fc52242"), "نظر آباد", 4 },
                    { 94, new Guid("a33ecbbd-6c6b-4b9c-a6eb-093fc9181481"), "هشتگرد", 4 },
                    { 95, new Guid("46b14238-4c54-400c-b9fa-c4bc2ff5d518"), "چهارباغ", 4 },
                    { 96, new Guid("492453a6-63a7-454f-bd4f-e28b27e41e90"), "کرج", 4 },
                    { 112, new Guid("f0f4a2d6-87aa-4aa6-9fa8-d8422bf70dd0"), "بلبان آباد", 6 },
                    { 111, new Guid("da591cf7-327c-4c64-9df0-60ac9885f946"), "برده رشه", 6 },
                    { 110, new Guid("be5144a2-f343-41db-af32-745a58bfdc56"), "بانه", 6 },
                    { 109, new Guid("4f653534-f1be-4647-9fa7-b715a80f42a5"), "بابارشاني", 6 },
                    { 108, new Guid("71106a5f-88fd-46cf-a20d-f5b71d25bf17"), "اورامان تخت", 6 },
                    { 107, new Guid("f8f41bab-7653-45bf-8ce1-538636bac094"), "آرمرده", 6 },
                    { 106, new Guid("4b42875b-bd0f-4b65-9760-99286ecc271c"), "کهک", 5 },
                    { 76, new Guid("a8b472b3-65db-429f-a496-b323db3f2446"), "صفي آباد", 3 },
                    { 105, new Guid("aa8299e3-97a6-40fb-8378-80525e1d8fd6"), "قنوات", 5 },
                    { 103, new Guid("3d20badc-3ec8-47aa-a32d-15351b3140ae"), "سلفچگان", 5 },
                    { 102, new Guid("2f806ffe-e52d-48aa-a820-d41fdabe5265"), "دستجرد", 5 },
                    { 101, new Guid("175c4bb4-43ee-49b4-9e70-71c8e4b417aa"), "جعفريه", 5 },
                    { 100, new Guid("789bbe7f-0d26-4372-a5d0-7b6f02d81571"), "گلسار", 4 },
                    { 99, new Guid("a2687052-efab-4b54-b415-8b5e290a7592"), "گرمدره", 4 },
                    { 98, new Guid("bdad6b85-fc53-4d5f-82df-752f4040d197"), "کوهسار", 4 },
                    { 97, new Guid("ad53e310-349d-4eb6-bda7-ece4d4fb79ac"), "کمال شهر", 4 },
                    { 104, new Guid("7b055c06-8a49-48c0-861d-5852e9a1249c"), "قم", 5 },
                    { 306, new Guid("a436b819-f8d2-43c7-adb4-52a72c1fd3c8"), "عشق آباد", 10 },
                    { 300, new Guid("34480e06-e230-40e7-a268-f39619112852"), "سرايان", 10 },
                    { 308, new Guid("543f369f-1d50-4177-8e72-345df560dfea"), "قائن", 10 },
                    { 516, new Guid("f10fe977-b2a3-497d-951e-ba5f4497a451"), "نوشهر", 15 },
                    { 515, new Guid("14d07a21-32f6-4d4c-812b-98366e1e1c15"), "نور", 15 },
                    { 514, new Guid("01822efd-ee23-4123-8cac-beebc3ce5889"), "نشتارود", 15 },
                    { 513, new Guid("4c98227f-7fe6-429e-82de-8efdaef12876"), "مرزيکلا", 15 },
                    { 512, new Guid("591da205-618e-48c0-bb72-e3c4c20272ff"), "مرزن آباد", 15 },
                    { 511, new Guid("021a3ef3-2a86-4ccf-a0b2-c0d132e7613c"), "محمود آباد", 15 },
                    { 510, new Guid("31bfc756-45d3-4ca5-8d8d-319491c77ecf"), "قائم شهر", 15 },
                    { 509, new Guid("8f17de16-8352-4007-bbe8-8ec7958525d9"), "فريم", 15 },
                    { 508, new Guid("d5166478-e66f-43a8-b1fb-052462a24e5e"), "فريدونکنار", 15 },
                    { 507, new Guid("7436d93f-c790-43a7-bb3a-bc9bf73f6f4a"), "عباس آباد", 15 },
                    { 506, new Guid("b637423d-df22-4924-a49a-4b47ed407066"), "شيرگاه", 15 },
                    { 505, new Guid("01c06426-f1c3-4c42-a03b-8d17fd741c66"), "شيرود", 15 },
                    { 504, new Guid("fc9ec88a-df56-4628-9e67-8154974b0a82"), "سورک", 15 },
                    { 503, new Guid("8599cd9a-cda4-406f-a15f-6879baa6fb1d"), "سلمان شهر", 15 },
                    { 502, new Guid("14bc0c1d-f383-471a-b54f-db76613fd1ff"), "سرخرود", 15 },
                    { 517, new Guid("b0b98bed-511d-4918-b575-e97be0bac1ca"), "نکا", 15 },
                    { 501, new Guid("fba4f858-5585-47e6-a6ca-46772baf682a"), "ساري", 15 },
                    { 518, new Guid("6f74fcf7-f4ae-46b0-8d06-597485ce0f3e"), "هادي شهر", 15 },
                    { 520, new Guid("7f93ece7-f868-45fb-8e94-839e04e58acd"), "پايين هولار", 15 },
                    { 535, new Guid("3abe7ce3-7927-4b3e-ab6d-8eceddd15189"), "آبيک", 16 },
                    { 534, new Guid("19b274a7-270a-404c-99ac-56ce9fda821d"), "گلوگاه", 15 },
                    { 533, new Guid("2030493b-78e1-430f-bbde-9c3bf3bf38f3"), "گزنک", 15 },
                    { 532, new Guid("f9f3caf1-ca50-43a7-9695-9024c8815b2b"), "گتاب", 15 },
                    { 531, new Guid("67c8fbef-4375-438b-a1ef-f85861e3fabb"), "کياکلا", 15 },
                    { 530, new Guid("d3721857-ffc0-4299-839d-097a28bfdfae"), "کياسر", 15 },
                    { 529, new Guid("650e0c7c-9690-4d8b-ae7b-3098bf12f166"), "کوهي خيل", 15 },
                    { 528, new Guid("4a355ee6-7249-4617-bbf2-553677899b66"), "کلاردشت", 15 },
                    { 527, new Guid("5461d4b6-9d47-4146-93d0-55dfed792125"), "کلارآباد", 15 },
                    { 526, new Guid("a2149e23-cabd-4129-8691-54eeb3482311"), "کجور", 15 },
                    { 525, new Guid("9a37110c-a375-4377-90ea-d96e632c209f"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("54a81709-e76f-4ccc-a210-4cf3d566bcb8"), "چمستان", 15 },
                    { 523, new Guid("582c2d0b-ed90-480a-b4b6-80091427f391"), "چالوس", 15 },
                    { 522, new Guid("21d87e26-bdd6-40fa-ba3c-0790d7cd2be9"), "پول", 15 },
                    { 521, new Guid("fa731629-0baf-49c4-97f8-7f34c51a820b"), "پل سفيد", 15 },
                    { 519, new Guid("edaa1e8c-7d6d-4240-aa72-02d14dff3c36"), "هچيرود", 15 },
                    { 500, new Guid("d4304d9a-62cc-4add-8950-85d6a83be727"), "زيرآب", 15 },
                    { 499, new Guid("7177e081-7793-44c7-9fb2-522322564f0e"), "زرگر محله", 15 },
                    { 498, new Guid("bb962ff8-18d5-4008-bb9d-2fc289c7a591"), "رينه", 15 },
                    { 477, new Guid("449ae870-9c36-47f0-a0d1-f79bd1d1bd81"), "گنبدکاووس", 14 },
                    { 476, new Guid("91a6a620-cf7d-4359-9c8c-5bbe73ecde23"), "گميش تپه", 14 },
                    { 475, new Guid("4a8605a8-932c-44d2-8661-d638af9d27fd"), "گرگان", 14 },
                    { 474, new Guid("69358d36-04de-4eb5-a8a9-6d650d8babbb"), "گاليکش", 14 },
                    { 473, new Guid("776ae3bb-465a-49d4-bb81-b9ef177a308a"), "کلاله", 14 },
                    { 472, new Guid("79413137-c57a-4cca-91ec-b83d6ce22a6a"), "کرد کوي", 14 },
                    { 471, new Guid("ed89c146-0ec4-4577-97e8-c2e316a08c33"), "نگين شهر", 14 },
                    { 470, new Guid("8f7e6273-a075-47e1-b567-7c7ad6ad9600"), "نوکنده", 14 },
                    { 469, new Guid("d237e992-238f-4063-91f7-39bfccb56a9d"), "نوده خاندوز", 14 },
                    { 468, new Guid("03c7386a-ccfb-491a-80fc-067329f43c1f"), "مينودشت", 14 },
                    { 307, new Guid("794d49b2-d512-4ae4-850f-2842103a4e52"), "فردوس", 10 },
                    { 466, new Guid("d91bd6e5-db24-4b44-b1f5-381c69d03f00"), "مراوه تپه", 14 },
                    { 465, new Guid("6824e859-45c7-4646-a140-4ae3c568d426"), "فراغي", 14 },
                    { 464, new Guid("bae114bd-eddb-488e-8a5a-ffce436efff0"), "فاضل آباد", 14 },
                    { 463, new Guid("8818f51b-cb61-4dca-8bfa-1213b068a54d"), "علي آباد", 14 },
                    { 478, new Guid("48bf9a6e-e479-485a-92a5-184792092a07"), "آلاشت", 15 },
                    { 479, new Guid("932ab25f-9fa3-4696-9bd5-03b2778e7b70"), "آمل", 15 },
                    { 480, new Guid("41943714-56ed-4625-8857-b1415f9ec9dd"), "ارطه", 15 },
                    { 481, new Guid("30c994f6-af2b-4953-b687-09a2fd6e7b4a"), "امامزاده عبدالله", 15 },
                    { 497, new Guid("81b00912-60ee-43bd-a4d8-45806ac91287"), "رويان", 15 },
                    { 496, new Guid("242e61f6-0369-4956-bd6c-aadbbb63bfdc"), "رستمکلا", 15 },
                    { 495, new Guid("6b355f7a-8bfd-44a4-b15e-000a42af0fa3"), "رامسر", 15 },
                    { 494, new Guid("265ae689-eb41-454e-8a5b-5b9102fe20f5"), "دابودشت", 15 },
                    { 493, new Guid("ec678db9-0c2f-44ba-910a-e68d2c11fd37"), "خوش رودپي", 15 },
                    { 492, new Guid("e9cf6de9-51c1-4a35-83c5-f3f0855c2260"), "خليل شهر", 15 },
                    { 491, new Guid("469eaa6f-7d40-4067-b417-563d0ffc99e1"), "خرم آباد", 15 },
                    { 536, new Guid("e6048e10-9345-4675-ae54-025ddf4dd75e"), "آبگرم", 16 },
                    { 490, new Guid("5d1c089f-4e78-4e03-b81c-cb35832e2596"), "جويبار", 15 },
                    { 488, new Guid("3dc7f6c9-6422-4a41-9800-147e91c403cc"), "بهنمير", 15 },
                    { 487, new Guid("ead10ec7-e369-493e-bacf-5e1d2d6d77e8"), "بهشهر", 15 },
                    { 486, new Guid("32ef9d3c-fcbc-4d30-9572-849bff7853e1"), "بلده", 15 },
                    { 485, new Guid("46227e99-103f-4677-8e71-34510b824390"), "بابلسر", 15 },
                    { 484, new Guid("ffa966c6-de9f-4c0c-8799-a3bfad3ad709"), "بابل", 15 },
                    { 483, new Guid("efef946c-9ae6-4b87-8585-2cf587759599"), "ايزد شهر", 15 },
                    { 482, new Guid("954c7330-88b4-4ebf-b900-158bfe8f1ccf"), "امير کلا", 15 },
                    { 489, new Guid("1f2f3042-fb2f-4528-a34d-485e21a07310"), "تنکابن", 15 },
                    { 462, new Guid("5b7a8d05-4a6e-4cab-bd92-be995a36e6eb"), "سيمين شهر", 14 },
                    { 537, new Guid("278e4577-556f-4a0f-b694-b50b682e2766"), "آوج", 16 },
                    { 539, new Guid("284bea88-2401-417f-b105-cedd12bdc48c"), "اسفرورين", 16 },
                    { 593, new Guid("3799a9fc-6c6c-4281-9180-1108735030cc"), "خلخال", 18 },
                    { 592, new Guid("b520d90e-fa71-4526-8dc3-ca9ce0328555"), "جعفر آباد", 18 },
                    { 591, new Guid("96ffd102-8d35-4039-bb4a-696985272a48"), "تازه کند انگوت", 18 },
                    { 590, new Guid("5a3bb982-c19b-4fcb-bf28-be66c1c6f2d3"), "تازه کند", 18 },
                    { 589, new Guid("61149b92-0ef0-45a0-a735-ff4315474361"), "بيله سوار", 18 },
                    { 588, new Guid("65829753-2178-4e41-83ac-d386ec679fd9"), "اصلاندوز", 18 },
                    { 587, new Guid("dc4d65af-03ce-4dd6-9504-d446c644cd3e"), "اسلام آباد", 18 },
                    { 586, new Guid("16bdfba3-412c-4b36-9e28-a67cfcedf243"), "اردبيل", 18 },
                    { 585, new Guid("e97dbadd-1013-4d61-abfc-a85258b83017"), "آبي بيگلو", 18 },
                    { 584, new Guid("56c7c8da-7579-4ebf-9121-0316de47de7a"), "گراب", 17 },
                    { 583, new Guid("aca0e345-8243-410b-969f-d3729f7a68dc"), "کوهناني", 17 },
                    { 582, new Guid("ea32523e-8603-4096-b551-c46bab16da33"), "کوهدشت", 17 },
                    { 581, new Guid("cd96f81e-5c23-4cab-9881-aca88e263438"), "چقابل", 17 },
                    { 580, new Guid("0b5c8fe7-8316-43eb-80a9-77752e03ab4b"), "چالانچولان", 17 },
                    { 579, new Guid("b584ab3f-be84-434a-919f-0bc92e7a2e3b"), "پلدختر", 17 },
                    { 594, new Guid("20949ca4-4d69-4d25-a70e-6cbe4def8d6c"), "رضي", 18 },
                    { 578, new Guid("4cc3c932-e485-475f-a86c-412d3f38dd9d"), "ويسيان", 17 },
                    { 595, new Guid("5c6744b3-95ef-43dc-a080-4d8012e6d779"), "سرعين", 18 },
                    { 597, new Guid("39a829de-0768-4e01-b630-22650eae909e"), "فخرآباد", 18 },
                    { 612, new Guid("6c92da70-a4f5-4cdc-bb63-e3378b0079ad"), "ابريشم", 19 },
                    { 611, new Guid("4afec79a-524e-4759-afc4-1b10b6f0fa9f"), "آران و بيدگل", 19 },
                    { 610, new Guid("f3f3d8d5-b787-4b1e-ae16-222766a6d142"), "گيوي", 18 },
                    { 609, new Guid("04a8c49c-e660-48f3-838d-bb33f285cee3"), "گرمي", 18 },
                    { 608, new Guid("95c9e572-2a46-4888-8d3c-83bb6fe0fe2e"), "کورائيم", 18 },
                    { 607, new Guid("919e99ac-5cde-4b25-8b00-4835e6520058"), "کلور", 18 },
                    { 606, new Guid("6e348667-3348-4cf2-8391-0276314af87f"), "پارس آباد", 18 },
                    { 605, new Guid("63404da2-fbf6-4b32-99a0-6ed0fe9c6bd7"), "هير", 18 },
                    { 604, new Guid("d776b3f7-49be-4235-9d8a-618dcfef7538"), "هشتجين", 18 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 603, new Guid("df58fd90-6a35-4c74-a4ce-6bd01d01c8ff"), "نير", 18 },
                    { 602, new Guid("fd45184b-9de7-4dfc-8935-954dd03fb0fe"), "نمين", 18 },
                    { 601, new Guid("905ece4d-96c9-4f2a-aa5f-a17528614619"), "مشگين شهر", 18 },
                    { 600, new Guid("bc7f2b16-6b52-4d0b-9a74-616460ca8b18"), "مرادلو", 18 },
                    { 599, new Guid("54ddf35d-1f61-463e-b4b5-82bbb2866473"), "لاهرود", 18 },
                    { 598, new Guid("d81c8e88-cee5-4b8e-aaeb-117fa753704e"), "قصابه", 18 },
                    { 596, new Guid("9c77de65-c283-4af0-9334-b6ed401409c2"), "عنبران", 18 },
                    { 577, new Guid("ca34dd90-b034-4b68-a305-79dfee0e65c1"), "هفت چشمه", 17 },
                    { 576, new Guid("ef1eb313-3584-4f91-b6d6-5151a7622469"), "نورآباد", 17 },
                    { 575, new Guid("9e13c06d-6bf0-429e-bb65-6d105bcc8e2d"), "مومن آباد", 17 },
                    { 554, new Guid("19ab96bf-b907-4728-ad1e-bccb03e58978"), "قزوين", 16 },
                    { 553, new Guid("c336979c-2289-4235-b1ad-5128a0c2037f"), "ضياء آباد", 16 },
                    { 552, new Guid("1835023b-83dd-4460-b3df-d3debeed25c8"), "شريفيه", 16 },
                    { 551, new Guid("cae6b65d-fb6a-44e2-a6e6-0fb18c10ecf2"), "شال", 16 },
                    { 550, new Guid("675c3c5b-a0cf-44b3-9c81-20e9f1d96b6b"), "سگز آباد", 16 },
                    { 549, new Guid("f6ebadce-fff4-42e1-9a2f-d4170845ce47"), "سيردان", 16 },
                    { 548, new Guid("0f74d47d-75b8-4164-869b-4ef1d8f88913"), "رازميان", 16 },
                    { 547, new Guid("cf071acb-f5b0-4d78-900d-2e49957b97ee"), "دانسفهان", 16 },
                    { 546, new Guid("dc6a3c2c-ede0-4f1f-ad75-0dbe2482104f"), "خرمدشت", 16 },
                    { 545, new Guid("e86a4bb9-f3df-49fc-b381-e28321f50f40"), "خاکعلي", 16 },
                    { 544, new Guid("c7b9ae39-96e2-489d-944b-a1f709a7099c"), "تاکستان", 16 },
                    { 543, new Guid("d8fade34-30df-4991-9fad-9e4a2e42ed17"), "بيدستان", 16 },
                    { 542, new Guid("f6ec1ca7-0c4d-4493-85fa-10107bf768f1"), "بوئين زهرا", 16 },
                    { 541, new Guid("0a79a732-b09a-4efa-ae45-3d2d0fd7a154"), "الوند", 16 },
                    { 540, new Guid("dcf5507b-e695-4427-8918-356e2927d665"), "اقباليه", 16 },
                    { 555, new Guid("5870a9d4-f647-4cee-a884-f606a58757a0"), "محمديه", 16 },
                    { 556, new Guid("c8d82836-e114-4aaf-9c68-e82a711967ab"), "محمود آباد نمونه", 16 },
                    { 557, new Guid("2bf0d68e-bbe3-4ac5-9e7c-5484166a4e8a"), "معلم کلايه", 16 },
                    { 558, new Guid("1c8023b8-1d96-483a-8361-7a42c2ae4086"), "نرجه", 16 },
                    { 574, new Guid("4a406c85-3cd0-4d64-908d-e78340f62230"), "معمولان", 17 },
                    { 573, new Guid("0d283810-2537-4d02-8fff-236c81b87cdd"), "فيروزآباد", 17 },
                    { 572, new Guid("9b18a185-d8e8-478c-856b-874749b1df41"), "شول آباد", 17 },
                    { 571, new Guid("16054bcf-3078-4add-8c02-299317880a62"), "سپيد دشت", 17 },
                    { 570, new Guid("31375910-da1c-433e-b603-b56d78e527b7"), "سراب دوره", 17 },
                    { 569, new Guid("a32b72a7-5868-46dc-866a-519b8e1a994d"), "زاغه", 17 },
                    { 568, new Guid("bf3466fa-49be-4ccc-aa4d-457f372efa20"), "دورود", 17 },
                    { 538, new Guid("3216b154-b31b-4c29-bddf-3c649b769817"), "ارداق", 16 },
                    { 567, new Guid("62c24e51-9645-4a41-a40a-e0688cdd03fc"), "درب گنبد", 17 },
                    { 565, new Guid("6e358c10-63ba-4260-ad75-85bc01a6108c"), "بيرانشهر", 17 },
                    { 564, new Guid("a6e1e641-a1ea-4de4-94d5-eb145e7704c9"), "بروجرد", 17 },
                    { 563, new Guid("c81e82e1-1736-4306-8f78-6bf51f8e2c3b"), "اليگودرز", 17 },
                    { 562, new Guid("42ead61b-96af-491c-adbe-fa573b4bb9f9"), "الشتر", 17 },
                    { 561, new Guid("915ee62a-f768-4979-ab0e-78528acbd55a"), "اشترينان", 17 },
                    { 560, new Guid("339cf662-a653-4c8a-8353-067483d9c2f8"), "ازنا", 17 },
                    { 559, new Guid("4452c012-4eea-432a-bc23-5a1b5fca7584"), "کوهين", 16 },
                    { 566, new Guid("6b28ed3d-218c-4955-baca-dc8262ce5210"), "خرم آباد", 17 },
                    { 461, new Guid("5bd299f1-9878-49b8-a01d-98667893250e"), "سنگدوين", 14 },
                    { 467, new Guid("a8a02fd8-571d-4463-bff3-d889ed23e861"), "مزرعه", 14 },
                    { 459, new Guid("7f703be8-7b40-4a88-adf6-f8f0b473c93c"), "راميان", 14 },
                    { 362, new Guid("78960775-0841-4e28-8543-1a971b6f4835"), "شوشتر", 11 },
                    { 361, new Guid("f15d1d04-c693-41d0-be75-03b622da5e4e"), "شوش", 11 },
                    { 360, new Guid("ce40b21c-1007-4678-80bd-d440ec14a947"), "شهر امام", 11 },
                    { 359, new Guid("6d0e9f62-2fcb-4526-a1f8-ef83bfc00b42"), "شمس آباد", 11 },
                    { 358, new Guid("b20f8ea1-0c45-4c23-95a1-dc9b7156596c"), "شرافت", 11 },
                    { 357, new Guid("c18ba1dd-a7ff-47c5-a922-4edbc8e87227"), "شاوور", 11 },
                    { 356, new Guid("8c4fa4e1-fc22-4c84-97d4-5209af87ef94"), "شادگان", 11 },
                    { 355, new Guid("51e9850b-4ddf-4001-83f4-501d999924de"), "سياه منصور", 11 },
                    { 354, new Guid("b4e403cc-45a1-4ba4-b654-accb655382c9"), "سوسنگرد", 11 },
                    { 353, new Guid("9f9370da-4ed9-423e-b6af-ee924261bc62"), "سماله", 11 },
                    { 352, new Guid("f1a7e354-e8eb-48ff-9446-fa2f7f874a1a"), "سردشت", 11 },
                    { 351, new Guid("97749dcd-76bb-46f8-a76f-c994f909c8b0"), "سرداران", 11 },
                    { 350, new Guid("d6c91b03-b84f-49ea-b448-e038949ab078"), "سالند", 11 },
                    { 349, new Guid("32629f65-7f08-4594-acb6-76af8c86fb54"), "زهره", 11 },
                    { 348, new Guid("49634f69-508d-4617-9522-1a8cf05d87d7"), "رفيع", 11 },
                    { 363, new Guid("8e595e51-f21b-4334-b01b-e1e41c7509d3"), "شيبان", 11 },
                    { 347, new Guid("d3872944-f5fc-4938-9743-bb6ff0eb4468"), "رامهرمز", 11 },
                    { 364, new Guid("3507aa39-aa63-4708-aa9a-63da75ac6e21"), "صالح شهر", 11 },
                    { 366, new Guid("77670651-e947-450c-a4b4-2edf39d80baf"), "صيدون", 11 },
                    { 381, new Guid("3ddd9077-6a58-4c60-9133-de8f57d457d4"), "هويزه", 11 },
                    { 380, new Guid("e26ada44-6882-4632-9cb3-2c0fe9aa2c50"), "هنديجان", 11 },
                    { 379, new Guid("b811425e-017c-4974-937c-e1caa639c67a"), "هفتگل", 11 },
                    { 378, new Guid("54e5ad47-9a03-4e64-ad7f-a8cd8737e1e8"), "مينوشهر", 11 },
                    { 460, new Guid("cabb32d6-2dd6-46c2-aa2a-4bba202198c5"), "سرخنکلاته", 14 },
                    { 376, new Guid("23dfc484-eb66-4821-879c-3723a7f06924"), "ميانرود", 11 },
                    { 375, new Guid("4b1491cb-2b40-4bfa-95fa-3d06f8349c5a"), "منصوريه", 11 },
                    { 374, new Guid("cf49a859-04e2-4170-a82f-61476f124123"), "ملاثاني", 11 },
                    { 373, new Guid("91a04ed7-cfe7-4f8f-aad6-676080a39be3"), "مقاومت", 11 },
                    { 372, new Guid("0d40f791-955f-4415-af19-6de7ba04130a"), "مشراگه", 11 },
                    { 371, new Guid("97f94317-fcde-4472-b6ae-63b94fd036e7"), "مسجد سليمان", 11 },
                    { 370, new Guid("0e53bbd9-1947-465d-938f-1058373926ec"), "لالي", 11 },
                    { 369, new Guid("4881e159-c272-4a35-8ed3-55af2e6c7ca0"), "قلعه خواجه", 11 },
                    { 368, new Guid("d3169082-db28-451d-bbeb-d9124d39e50e"), "قلعه تل", 11 },
                    { 367, new Guid("a83ef832-6e23-4942-9635-41bc9bea58d2"), "فتح المبين", 11 },
                    { 365, new Guid("57a84b14-1faa-4f8c-a89b-228e511462c7"), "صفي آباد", 11 },
                    { 346, new Guid("e3fd30e5-99b5-4046-89b6-ee304d6025ee"), "رامشير", 11 },
                    { 345, new Guid("2b1d18fb-1c47-4f28-86b8-e0a043dfc495"), "دهدز", 11 },
                    { 344, new Guid("8243f9cd-da98-4e1a-b0d7-14d55f858f09"), "دزفول", 11 },
                    { 323, new Guid("f165be44-419a-4b93-bc17-fbf7742213c6"), "اميديه", 11 },
                    { 322, new Guid("8be5ef96-f77d-4a47-8811-270ada4e48ad"), "الوان", 11 },
                    { 321, new Guid("55da0505-23a7-4e74-a593-3690bd091b5d"), "الهايي", 11 },
                    { 320, new Guid("1c1f842d-a0c5-49c5-9f0e-17cff7703604"), "اروند کنار", 11 },
                    { 319, new Guid("e38f4f0b-170e-41b6-bf01-68ab720e4f0e"), "ابوحميظه", 11 },
                    { 318, new Guid("b45b3099-3341-4acc-9fbc-41db4a588f2e"), "آغاجاري", 11 },
                    { 317, new Guid("272192bb-9234-46c9-9b3b-76967b4b4513"), "آزادي", 11 },
                    { 316, new Guid("638885f3-c301-4757-a1ac-81701d70e847"), "آبژدان", 11 },
                    { 315, new Guid("6f819cfe-90fe-41a0-906c-13ea19e105ed"), "آبادان", 11 },
                    { 314, new Guid("c6724463-51f1-439b-bc5e-ffc22c78bcfe"), "گزيک", 10 },
                    { 313, new Guid("fde94528-3dbd-4074-96d3-80624941e267"), "نيمبلوک", 10 },
                    { 312, new Guid("69c56205-ab26-4ea2-b5d3-3641d86a81e5"), "نهبندان", 10 },
                    { 311, new Guid("e287b711-7c2a-4bdf-aec2-e463cd01422f"), "مود", 10 },
                    { 310, new Guid("cb457aae-682b-4d71-858c-32618a517ce5"), "محمدشهر", 10 },
                    { 309, new Guid("857e86cc-9221-46fd-a77e-8719b91a2481"), "قهستان", 10 },
                    { 324, new Guid("969bec9d-61df-484c-bd73-d58ebc56c849"), "انديمشک", 11 },
                    { 325, new Guid("827167de-e432-498e-99bc-6848030b7001"), "اهواز", 11 },
                    { 326, new Guid("81a2c743-dd5a-4ac9-9fee-81f7fb696dbd"), "ايذه", 11 },
                    { 327, new Guid("15e8c641-114f-40fb-8b9b-e443aac24210"), "باغ ملک", 11 },
                    { 343, new Guid("3e6bd41f-a0e0-4198-b0c3-1d44a2917180"), "دارخوين", 11 },
                    { 342, new Guid("c4800c3c-9acc-4c6d-b310-ae1fab54d59c"), "خنافره", 11 },
                    { 341, new Guid("bab0df15-23f2-4f38-ba78-325db1268f62"), "خرمشهر", 11 },
                    { 340, new Guid("9a6dfaa2-8a9f-4342-9059-71356dc002e9"), "حميديه", 11 },
                    { 339, new Guid("f09f1f2d-73d1-4777-8d32-e9d16199ff2a"), "حمزه", 11 },
                    { 338, new Guid("220bc58a-983d-4021-9602-f56f391db865"), "حسينيه", 11 },
                    { 337, new Guid("62b87660-9950-487b-8db9-3c83d62e4b17"), "حر", 11 },
                    { 382, new Guid("ff184eba-9dba-41a0-90f2-abd5d4c10cc8"), "ويس", 11 },
                    { 336, new Guid("35e5c190-f4b7-49e4-9046-90882fa540c7"), "جنت مکان", 11 },
                    { 334, new Guid("5ff65101-537e-4b30-a7d9-432fab1c6946"), "تشان", 11 },
                    { 333, new Guid("debbf825-f92b-4ac7-93c9-fcb6c1a3fb6c"), "ترکالکي", 11 },
                    { 332, new Guid("2d8e610a-0792-4f81-815a-281b70174e7b"), "بيدروبه", 11 },
                    { 331, new Guid("a67f6ba1-c195-49c8-a936-62711f753ac3"), "بهبهان", 11 },
                    { 330, new Guid("8035b134-bd8b-4c36-a9c4-e09fd7f85a6f"), "بندر ماهشهر", 11 },
                    { 329, new Guid("5c46a865-16f6-47db-93fc-0c6949c10dc4"), "بندر امام خميني", 11 },
                    { 328, new Guid("2cdf1858-0c65-41e3-a651-2d36c6420b47"), "بستان", 11 },
                    { 335, new Guid("7d88d6ec-a2f7-497d-80f5-ca9f855f85df"), "جايزان", 11 },
                    { 383, new Guid("6d913b8d-3bac-40fe-ace9-31f727fe36d9"), "چغاميش", 11 },
                    { 377, new Guid("3b6ab0e3-6841-430d-a21d-20985c19a745"), "ميداود", 11 },
                    { 385, new Guid("982789e1-f754-4bf5-8418-076efded60f9"), "چمران", 11 },
                    { 439, new Guid("4eaef2af-b18f-42bc-9ee1-3e2f08d94a89"), "سهرورد", 13 },
                    { 438, new Guid("90555825-8c3e-4ed6-8aaf-5fa6896ae906"), "سلطانيه", 13 },
                    { 437, new Guid("85600fe7-0543-47d5-a765-e658a59683f9"), "سجاس", 13 },
                    { 436, new Guid("c9d48c41-d8e7-4d43-b7c0-b2b64d060627"), "زنجان", 13 },
                    { 435, new Guid("5dafac07-af71-4d8c-b757-709f897822fe"), "زرين رود", 13 },
                    { 434, new Guid("3b85a65a-31ee-46a1-af7e-946295a19caa"), "زرين آباد", 13 },
                    { 433, new Guid("8f69ac48-7367-4c81-8f82-f45d88b203a5"), "دندي", 13 },
                    { 432, new Guid("0ed409b4-7896-4f45-b5ca-0ea126a0dbd8"), "خرمدره", 13 },
                    { 431, new Guid("df2433c3-28b9-4f71-992e-fdf69b890e0a"), "حلب", 13 },
                    { 430, new Guid("b794134e-66b4-4a79-8a86-a44b9eff3cb7"), "ارمخانخانه", 13 },
                    { 429, new Guid("1c0d6ef5-846b-42c7-9e3e-4135d068699b"), "ابهر", 13 },
                    { 384, new Guid("d1264c09-084f-4351-8939-5858ede48fb9"), "چم گلک", 11 },
                    { 427, new Guid("04f23df4-3da1-4918-bf51-478e15ae63ac"), "کلمه", 12 },
                    { 426, new Guid("996d0870-e526-42fa-ab69-0e2059fa0aeb"), "کاکي", 12 },
                    { 425, new Guid("4ff75440-b457-43e0-a701-23ffaf3a2ea8"), "چغادک", 12 },
                    { 440, new Guid("cfa26dce-dfcb-4ffc-a931-1f1ee0f2ea06"), "صائين قلعه", 13 },
                    { 424, new Guid("77869d0f-b600-4ea3-89c4-8ddbc72a041e"), "وحدتيه", 12 },
                    { 441, new Guid("5fc689d7-e1f7-408d-bfdd-a9d8e13f8912"), "قيدار", 13 },
                    { 443, new Guid("c1ae7f65-7960-4a79-9ca5-9aa5c2c7f95f"), "نوربهار", 13 },
                    { 458, new Guid("810f1bdf-a18c-477e-9bb6-c7dc94faf55e"), "دلند", 14 },
                    { 457, new Guid("6ae4c994-6cef-47f3-b613-8dad2966b0ed"), "خان ببين", 14 },
                    { 456, new Guid("92b29ee1-9be8-47d2-ac85-b528245d1990"), "جلين", 14 },
                    { 455, new Guid("faf15e2f-1c7e-4aec-9244-24c208ee2c4a"), "تاتار عليا", 14 },
                    { 454, new Guid("c6c417ae-f6fc-43fa-877b-7f763dc1d916"), "بندر گز", 14 },
                    { 453, new Guid("559df80a-7fbe-444e-8fed-eb32c38cda10"), "بندر ترکمن", 14 },
                    { 452, new Guid("7d21022b-a490-42df-8b52-774bc6622b93"), "اينچه برون", 14 },
                    { 451, new Guid("ee3b2daa-479c-4bbc-ba46-6e8c63bc86fb"), "انبار آلوم", 14 },
                    { 450, new Guid("ad0a33fd-73bb-4777-965e-41eee7d76246"), "آق قلا", 14 },
                    { 449, new Guid("59b66396-d965-4e38-879c-9cb2e77ad722"), "آزاد شهر", 14 },
                    { 448, new Guid("16bf0889-d458-4f3a-8c2b-d0c6e762f9a1"), "گرماب", 13 },
                    { 447, new Guid("69a6ed7f-5426-44e5-8972-d40a4fac7962"), "کرسف", 13 },
                    { 446, new Guid("a0f8e438-5c03-45b2-bb58-172fef5accb1"), "چورزق", 13 },
                    { 445, new Guid("d2c91a23-2592-4f89-b9cc-af2d29c24582"), "هيدج", 13 },
                    { 444, new Guid("24f050e1-33a0-4d9b-bde7-7fab66bb78fc"), "نيک پي", 13 },
                    { 442, new Guid("c670bf24-1332-4ab8-baf1-aa1e01bb7af5"), "ماه نشان", 13 },
                    { 423, new Guid("c7d47279-b39e-443b-bb85-595ab9eb2c76"), "نخل تقي", 12 },
                    { 428, new Guid("82c7e04f-911d-4c1b-b790-f9004f0e2d7f"), "آب بر", 13 },
                    { 421, new Guid("80a11468-78cc-45e1-a900-8c6940698ae2"), "شنبه", 12 },
                    { 400, new Guid("dc0b3d6e-6cff-47c8-98d0-7d3a2d9c1c40"), "بردخون", 12 },
                    { 399, new Guid("ad639908-83c2-404a-a613-08e8eacdc539"), "برازجان", 12 },
                    { 398, new Guid("8f246b9a-3c80-4487-8be8-2b6128578467"), "بادوله", 12 },
                    { 422, new Guid("80caf2f7-b3c4-4ba2-ae3e-209d884d1336"), "عسلويه", 12 },
                    { 396, new Guid("1e770b33-3671-4ac2-8c31-e613c477debe"), "انارستان", 12 },
                    { 395, new Guid("c5941fcd-8004-4490-810f-c0319ce4053e"), "امام حسن", 12 },
                    { 394, new Guid("0e6055cf-2ff4-45c0-a8a3-83b679dd5957"), "آبپخش", 12 },
                    { 393, new Guid("56c0fe1d-d216-4922-88b7-aa8fd6d11111"), "آبدان", 12 },
                    { 392, new Guid("8b216439-1793-4397-800e-d232fc0be65e"), "آباد", 12 },
                    { 391, new Guid("0b94cc26-a126-45fb-abe8-96ce5ba95870"), "گوريه", 11 },
                    { 390, new Guid("c0fcd62c-cf99-4254-aec5-0d5600311c2d"), "گلگير", 11 },
                    { 389, new Guid("0ad439b6-4c32-40fc-8bc7-3da47e49fd01"), "گتوند", 11 },
                    { 388, new Guid("e9c369c8-88d2-4843-a430-3845a970a84a"), "کوت عبدالله", 11 },
                    { 387, new Guid("e719e754-62f1-4ff9-84ea-ab31bc4f9175"), "کوت سيدنعيم", 11 },
                    { 386, new Guid("35772607-5991-438b-a448-ba0bb5594e2e"), "چوئبده", 11 },
                    { 401, new Guid("943b9857-0cd6-47c9-9248-33831c309fab"), "بردستان", 12 },
                    { 402, new Guid("b826dd3b-3bbf-4399-879e-a46f75c1b41a"), "بندر دير", 12 },
                    { 397, new Guid("4776bd90-573e-4788-b5c1-194b7b79a041"), "اهرم", 12 },
                    { 404, new Guid("186a01b3-140c-4bba-887a-2909549de9ed"), "بندر ريگ", 12 },
                    { 420, new Guid("be907e5d-c592-450a-b263-8c133cd35468"), "شبانکاره", 12 },
                    { 403, new Guid("a29c97f4-adda-4b25-b3eb-4c41af67647d"), "بندر ديلم", 12 },
                    { 418, new Guid("bf9a3820-714b-41b9-a7f1-047c65c120dc"), "سعد آباد", 12 },
                    { 417, new Guid("cda01adf-5b57-4e2d-a571-0edc358dcc4f"), "ريز", 12 },
                    { 416, new Guid("d4d9f6a8-f888-4db8-a04f-004d6d2c5e3b"), "دوراهک", 12 },
                    { 415, new Guid("11a05128-dfda-473a-8b1b-c4a548152722"), "دلوار", 12 },
                    { 414, new Guid("f74bdd66-910d-4e64-9cbc-03d40bdd844e"), "دالکي", 12 },
                    { 413, new Guid("bba89dbf-f623-4f07-95bb-e0e700d99c13"), "خورموج", 12 },
                    { 419, new Guid("948f7eac-52d0-4822-81c6-508849b9dbb3"), "سيراف", 12 },
                    { 411, new Guid("8cfbb65a-5dc7-4602-90bd-6ba68edb1215"), "جم", 12 },
                    { 410, new Guid("75fc2c9d-9ae4-405a-a9ee-3f26094ef65e"), "تنگ ارم", 12 },
                    { 409, new Guid("033196d9-250a-4c62-a278-74dcd2037392"), "بوشکان", 12 },
                    { 408, new Guid("f54a86ae-6e8b-4cf1-921e-795978296e10"), "بوشهر", 12 },
                    { 407, new Guid("a4cd287a-7f6f-419e-9056-31349d6d61a7"), "بنک", 12 },
                    { 406, new Guid("152abba4-851d-410b-8c60-0da425d1577c"), "بندر گناوه", 12 },
                    { 405, new Guid("4201d576-3b76-4dc1-b382-7026e45b8628"), "بندر کنگان", 12 },
                    { 412, new Guid("fdff1f26-c575-4c6c-b6a7-10effda9e844"), "خارک", 12 }
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
                    { 9, 4, new Guid("b5d74bda-849b-427c-a6e0-463c1e5f615b"), "در انتظار تایید", "Waiting" },
                    { 7, 3, new Guid("2b451e4c-c9b8-415a-bcb4-05da15447b89"), "زن", "Female" },
                    { 8, 3, new Guid("6e48b657-2c83-4481-a9c5-009ffe10158b"), "مرد", "Male" },
                    { 10, 4, new Guid("10afdac9-a075-40e1-9207-1813befcf4d6"), "در حال انجام", "Doing" },
                    { 11, 4, new Guid("2b9d07c8-5535-495e-8557-da32acb58600"), "انجام شده", "Done" },
                    { 12, 4, new Guid("61960336-e912-4658-9ab3-59f4c58e0b23"), "لغو", "Canceled" },
                    { 6, 2, new Guid("cf5a1929-db68-43d6-8fc7-e3b7ccc51678"), "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم", "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم" }
                });

            migrationBuilder.InsertData(
                table: "SMSSetting",
                columns: new[] { "SMSSettingID", "ModifiedDate", "Name", "SMSProviderConfigurationID", "SMSSettingGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 13, 16, 10, 2, 842, DateTimeKind.Local).AddTicks(1054), "Kavenegar", 1, new Guid("b4afd513-5da4-4ee8-97c5-8d6af5fbe8c3") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 7, new Guid("25bdd94c-13b0-4a59-80b9-3f5b95bcd5da"), "جوشکار صنعتی", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2912), 2, 1 },
                    { 8, new Guid("5cc07b8e-8851-4b56-a320-5820a98e0197"), "اره و نجار", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2920), 2, 2 },
                    { 9, new Guid("c696b7da-e008-4d8b-9db3-181f0644539a"), "ساختمان", new DateTime(2020, 5, 13, 16, 10, 2, 846, DateTimeKind.Local).AddTicks(2928), 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 13, 16, 10, 2, 842, DateTimeKind.Local).AddTicks(6468), "VerifyAccount", 1, new Guid("526b6d46-8ef3-44ce-ab0f-c35027757343") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "GenderCodeID", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", 8, true, true, "رودکی", new DateTime(2020, 5, 13, 16, 10, 2, 844, DateTimeKind.Local).AddTicks(6991), "09227204305", new DateTime(2020, 5, 13, 16, 10, 2, 844, DateTimeKind.Local).AddTicks(6003), 1, new Guid("827a2ea2-6809-42bc-a71e-b58dcbb62198") },
                    { 2, "mahdiih@ymail.com", "مهدی", 8, true, true, "حکمی زاده", new DateTime(2020, 5, 13, 16, 10, 2, 845, DateTimeKind.Local).AddTicks(618), "09199390494", new DateTime(2020, 5, 13, 16, 10, 2, 845, DateTimeKind.Local).AddTicks(595), 1, new Guid("7e0652a1-03e8-4ba1-82a0-991fd85500be") },
                    { 3, "roozbehshamekhi@hotmail.com", "روزبه", 8, true, true, "شامخی", new DateTime(2020, 5, 13, 16, 10, 2, 845, DateTimeKind.Local).AddTicks(666), "09128277075", new DateTime(2020, 5, 13, 16, 10, 2, 845, DateTimeKind.Local).AddTicks(662), 1, new Guid("28eb06ce-882d-4fd9-b49b-a1e22c9988e1") }
                });

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
                name: "IX_User_GenderCodeID",
                table: "User",
                column: "GenderCodeID");

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
                name: "SMSProviderConfiguration");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "CodeGroup");
        }
    }
}
