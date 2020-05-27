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
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 1, new Guid("c265fd02-0194-4d38-83e8-a93bc3698fcc"), "سایت اصلی", new DateTime(2020, 5, 27, 18, 47, 59, 555, DateTimeKind.Local).AddTicks(9324), null, 1 },
                    { 2, new Guid("dec37f17-0ab2-4208-8ba7-11cc1120369b"), "وبلاگ", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(370), null, 2 }
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
                    { 5, new Guid("91a225a2-b2a6-480d-a0fe-9461f5ecf76f"), "نقش", "Role" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("eb527316-924e-41e3-a5dd-f1131325a9bd") },
                    { 20, "ايلام", new Guid("1b487114-9abf-4e05-891d-e952117ddbae") },
                    { 21, "تهران", new Guid("d4b67d1e-c076-4760-a5b6-14ad557d99ac") },
                    { 22, "آذربايجان شرقي", new Guid("d4f909ef-782f-4bec-81d7-84f57129a3fa") },
                    { 23, "فارس", new Guid("024a8543-0d70-49ec-ab3d-a9ac3a7f66fa") },
                    { 24, "کرمانشاه", new Guid("df23a239-a8d0-46e3-8037-d343f22bc1f0") },
                    { 28, "همدان", new Guid("bc4fa65c-6835-47b3-bb34-78982a2346ea") },
                    { 26, "مرکزي", new Guid("9cfdf820-f5c0-4127-9261-b20e44507162") },
                    { 27, "گيلان", new Guid("c821b000-fbd9-470c-9181-132b73339989") },
                    { 18, "اردبيل", new Guid("8a823835-2fac-42dd-a05c-77fff851fc0a") },
                    { 29, "کرمان", new Guid("30862f5b-a047-41bd-a2f1-9fcd72dc23e6") },
                    { 30, "سمنان", new Guid("71c82d92-64a8-48a3-abd4-e38045210c34") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("49b66cca-d043-46cf-9dab-92ac143d8afe") },
                    { 25, "هرمزگان", new Guid("e1c3f739-92bf-43ff-8a05-39987e5ea19d") },
                    { 17, "لرستان", new Guid("3e79ca67-6c3c-457b-9f16-9f7557929619") },
                    { 14, "گلستان", new Guid("2e06a182-7ed0-458d-945c-34fdc7263959") },
                    { 15, "مازندران", new Guid("e5a76630-eb41-49e5-aa13-90ddbfbe09b1") },
                    { 1, "يزد", new Guid("4bb99c21-02d2-4dea-8058-5e7f6e4a6b20") },
                    { 2, "چهار محال و بختياري", new Guid("7f8e96b7-d840-4ef4-81d9-ee7265330ee5") },
                    { 3, "خراسان شمالي", new Guid("d076f4b5-260a-4a4c-89db-bd4fdaa6a446") },
                    { 4, "البرز", new Guid("b520adb4-a184-4594-99cf-a72f522fd80c") },
                    { 5, "قم", new Guid("7c88c67d-f06f-40ec-b01f-ebed37cd4b62") },
                    { 16, "قزوين", new Guid("e6baf295-b624-4649-a961-ae1c3449940a") },
                    { 7, "آذربايجان غربي", new Guid("a513da00-9658-4840-9d34-ec9d961801b7") },
                    { 6, "کردستان", new Guid("8a9854a8-0124-47f3-ae12-dce41199d8ac") },
                    { 9, "سيستان و بلوچستان", new Guid("fc8eadee-2564-431b-a74f-0046cdbaea26") },
                    { 10, "خراسان جنوبي", new Guid("4a09053f-972c-48fb-a0b9-46dca9b7d4aa") },
                    { 11, "خوزستان", new Guid("8badb72a-cacd-4546-b500-5bf2b2a51807") },
                    { 12, "بوشهر", new Guid("fb7c81ff-d677-492f-806b-14fd00f6bfab") },
                    { 13, "زنجان", new Guid("f752c15a-1803-4ba8-a020-06c84df8518f") },
                    { 8, "خراسان رضوي", new Guid("97bb3d0c-f977-4edb-a4b3-1cb100aa433c") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 3, "سرویس گیرنده", new DateTime(2020, 5, 27, 18, 47, 59, 549, DateTimeKind.Local).AddTicks(4361), "Client", new Guid("86642b72-b4e3-47eb-bfd6-c1ad8149c62b") },
                    { 1, "ادمین", new DateTime(2020, 5, 27, 18, 47, 59, 549, DateTimeKind.Local).AddTicks(3182), "Admin", new Guid("35f2c9af-34ac-4cea-a18b-132e06c3d4ba") },
                    { 2, "سرویس دهنده", new DateTime(2020, 5, 27, 18, 47, 59, 549, DateTimeKind.Local).AddTicks(4326), "Contractor", new Guid("26af8be3-b65d-4c89-b68f-0b6bfc5e0989") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 5, 27, 18, 47, 59, 542, DateTimeKind.Local).AddTicks(9766), "ptcoptco", new Guid("048a0fd9-3362-422e-aa95-c66cb7d24e47"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 3, new Guid("d50da910-8a11-41c6-a32e-a3ff9dd576a8"), "خانه", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(419), 1, 1 },
                    { 4, new Guid("f82ba009-da04-46c5-a646-834a1d2c9527"), "حمل و نقل", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(481), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 826, new Guid("c27f94cc-55e4-4d89-a331-0c7cbd23f572"), "ليلان", 22 },
                    { 825, new Guid("da4986d1-ced7-4aff-b965-5cc93a4e902f"), "قره آغاج", 22 },
                    { 824, new Guid("75da175e-071e-4ed0-a2e6-92c6c71f2d31"), "عجب شير", 22 },
                    { 823, new Guid("9bb8649b-98a6-479f-8d95-7da03e171116"), "صوفيان", 22 },
                    { 822, new Guid("b087b5b7-1a68-473e-831e-25a606742a31"), "شهر جديد سهند", 22 },
                    { 821, new Guid("4e5b5adf-ae76-43f1-ab1a-d706124a1d87"), "شند آباد", 22 },
                    { 820, new Guid("a06cfe43-e74a-4635-a485-73653342face"), "شرفخانه", 22 },
                    { 819, new Guid("e8dbdd27-2200-4e4a-91f9-7666fe034212"), "شربيان", 22 },
                    { 818, new Guid("fb40b40f-c798-497b-a6a5-e025ca0b2264"), "شبستر", 22 },
                    { 817, new Guid("8eb2baf3-0854-4f10-b386-995e449040f0"), "سيه رود", 22 },
                    { 816, new Guid("553da3ea-e2b6-493b-9b9b-9db99dbf0ca1"), "سيس", 22 },
                    { 815, new Guid("c07d6315-0181-430d-9197-d1a84dec57b6"), "سردرود", 22 },
                    { 814, new Guid("11fc3360-eb67-4c60-8634-c439d6dace0a"), "سراب", 22 },
                    { 813, new Guid("a8a520c7-b527-48f6-899f-ad666b3461fe"), "زنوز", 22 },
                    { 812, new Guid("035dfac9-f7df-47a0-b2b4-4126e4e0aabf"), "زرنق", 22 },
                    { 827, new Guid("f7c5bb8f-a8ff-4b1b-81c4-b6319326e147"), "مبارک شهر", 22 },
                    { 828, new Guid("62abc620-03cd-4a6f-b624-620d6e02bd51"), "مراغه", 22 },
                    { 829, new Guid("9f23e88c-d465-459e-90bc-d2337587ba6e"), "مرند", 22 },
                    { 830, new Guid("57ac5428-b695-4c83-b81a-2806c5fcc12b"), "ملکان", 22 },
                    { 846, new Guid("90d4e8a1-26d7-48d7-abe3-7f7e276b0eb4"), "گوگان", 22 },
                    { 845, new Guid("a5b4dadc-2bf4-4d3a-b894-8a42463a70be"), "کوزه کنان", 22 },
                    { 844, new Guid("14e08081-09ca-4846-8a1c-c2d69e649de8"), "کليبر", 22 },
                    { 843, new Guid("710d167b-1753-4cff-9102-bb24aaf101fe"), "کلوانق", 22 },
                    { 842, new Guid("197585f6-43c8-4b85-9617-1994decfb505"), "کشکسراي", 22 },
                    { 841, new Guid("c68b1ade-cc21-4591-8f81-f07388a7ba9f"), "يامچي", 22 },
                    { 840, new Guid("f0384437-2956-462d-97a3-5de4ec37b5ef"), "ورزقان", 22 },
                    { 811, new Guid("2ab6ae86-fe47-4ce9-afe1-6afcb48a4f2f"), "دوزدوزان", 22 },
                    { 839, new Guid("1e5d483f-9581-4f2f-8d2c-7472d6aff30d"), "وايقان", 22 },
                    { 837, new Guid("20766f7d-d7ab-4fc7-b376-e1e45e43d83c"), "هشترود", 22 },
                    { 836, new Guid("b5ed1acb-2203-49ec-8c3f-ea3e91a8fe49"), "هريس", 22 },
                    { 835, new Guid("c5d83c33-cf38-46eb-9bbd-1d4a79e0dbfd"), "هاديشهر", 22 },
                    { 834, new Guid("8329791d-63e4-4706-886f-26f874776de2"), "نظرکهريزي", 22 },
                    { 833, new Guid("52aca23e-3376-4933-97cc-1e5a3bae40bb"), "ميانه", 22 },
                    { 832, new Guid("90df4b75-4a38-4ca0-b436-a25d059ca296"), "مهربان", 22 },
                    { 831, new Guid("b06c9a12-e109-46f0-968a-0d658f7048fe"), "ممقان", 22 },
                    { 838, new Guid("9025091a-04ca-4ec9-82ae-392e24e6fa39"), "هوراند", 22 },
                    { 810, new Guid("ed62dd56-2020-43ba-b6a8-400154ebf7fb"), "خواجه", 22 },
                    { 809, new Guid("a466748e-f425-49be-a44d-e40cdded8e4e"), "خمارلو", 22 },
                    { 808, new Guid("a5af1110-a868-445b-bccf-ea82dfae1275"), "خسروشاه", 22 },
                    { 787, new Guid("d003a12c-73af-4be2-b303-f2fa9098fe8b"), "آقکند", 22 },
                    { 786, new Guid("cc298011-e2f3-48a0-9336-d5f5ecf5802d"), "آذرشهر", 22 },
                    { 785, new Guid("09b53482-41f1-4645-8d5e-1f26cd158e1d"), "آبش احمد", 22 },
                    { 784, new Guid("de6e4c49-d0a8-4652-a635-80527b7fc6f8"), "گلستان", 21 },
                    { 783, new Guid("099ca169-0a00-4eaf-964a-db21948f1433"), "کيلان", 21 },
                    { 782, new Guid("6938cf75-65c8-4c17-a74c-2881d6de1481"), "کهريزک", 21 },
                    { 781, new Guid("88fd2a2e-4e25-4c5b-b7d0-15b6fafeea07"), "چهاردانگه", 21 },
                    { 780, new Guid("1f943e8e-a781-40d4-b082-0b7448f1e435"), "پيشوا", 21 },
                    { 779, new Guid("b0f80ac8-af64-41d8-9bcc-3c302fe29c9c"), "پرديس", 21 },
                    { 778, new Guid("ceffcf5d-7748-4009-9b3a-f74e4691d63a"), "پاکدشت", 21 },
                    { 777, new Guid("f87e0cae-6cf9-460f-9d03-599ed723232f"), "ورامين", 21 },
                    { 776, new Guid("aef99bb5-c055-4469-9ae4-75ac18295bbf"), "وحيديه", 21 },
                    { 775, new Guid("68362003-35d1-48fb-9e7f-ad2e3c39406d"), "نصيرشهر", 21 },
                    { 774, new Guid("52a9ff57-c4eb-45f5-97f9-4b6f69ca2ec4"), "نسيم شهر", 21 },
                    { 773, new Guid("aea4d34b-912d-48a4-ac02-0a0a2da30b1a"), "ملارد", 21 },
                    { 788, new Guid("9edc59a0-39db-4f26-8ffc-701dc4ab0025"), "آچاچي", 22 },
                    { 789, new Guid("1c94430d-eb8d-44aa-b0cc-e924d4c53bf8"), "اسکو", 22 },
                    { 790, new Guid("9ea38701-1819-45ea-bee9-187167260077"), "اهر", 22 },
                    { 791, new Guid("aa6da448-941c-4012-a997-b81a67053806"), "ايلخچي", 22 },
                    { 807, new Guid("65350d84-e0f7-4a4b-ad78-47a37be27c70"), "خداجو", 22 },
                    { 806, new Guid("391d9e31-01b6-4f8b-81d7-bdb3c254ab79"), "خامنه", 22 },
                    { 805, new Guid("564342b4-325c-4d3d-a0dc-40f7665d3db4"), "خاروانا", 22 },
                    { 804, new Guid("6596167d-c9fa-419a-98e1-dc32a7615931"), "جوان قلعه", 22 },
                    { 803, new Guid("07474abe-ed29-4ace-9fc2-ee9a80540aff"), "جلفا", 22 },
                    { 802, new Guid("193b358e-e512-43a0-86ac-5f5b9f8790fa"), "تيکمه داش", 22 },
                    { 801, new Guid("6c8a0d96-5735-470f-ab97-bc698a20038d"), "تيمورلو", 22 },
                    { 847, new Guid("39a9cdcd-127e-4c53-b10d-45e9d7f001cf"), "آباده", 23 },
                    { 800, new Guid("95ab1cf5-00ff-4d11-ad40-062befff936c"), "تسوج", 22 },
                    { 798, new Guid("efaaa636-5baf-448f-815b-53817650247f"), "ترک", 22 },
                    { 797, new Guid("0fa78001-987e-4d5d-866a-9d888e7cb4c2"), "تبريز", 22 },
                    { 796, new Guid("7513c7d2-8390-458b-ab63-26db190df5b0"), "بناب مرند", 22 },
                    { 795, new Guid("213f1347-95d4-4254-9877-2ef209cb9ef9"), "بناب", 22 },
                    { 794, new Guid("06d0d84d-90cf-4f40-86a9-cee4e34fa4de"), "بستان آباد", 22 },
                    { 793, new Guid("17e77b07-35f3-46fb-9785-55b90a439cfa"), "بخشايش", 22 },
                    { 792, new Guid("b6d34708-2d6f-474f-8dd7-d3a9e75dbc91"), "باسمنج", 22 },
                    { 799, new Guid("89ba68ff-b863-4220-9410-ac6f6dbfab58"), "ترکمانچاي", 22 },
                    { 848, new Guid("3e1bd280-518a-4d42-bf11-ecd1c1def220"), "آباده طشک", 23 },
                    { 849, new Guid("cd4f8e25-ec67-4769-bb7e-2ca9afd6a0b8"), "اردکان", 23 },
                    { 850, new Guid("ae8f1fa8-6f00-40c8-a881-f787fb5900ae"), "ارسنجان", 23 },
                    { 905, new Guid("9bd66567-098f-44c5-8c0a-5e9ba58a970b"), "صغاد", 23 },
                    { 904, new Guid("22742e0b-38cf-4f29-9818-b917251239f9"), "شيراز", 23 },
                    { 903, new Guid("dd014119-0005-47b0-a34d-f7ed50d276f7"), "شهر پير", 23 },
                    { 902, new Guid("9451d4df-a5e6-492d-a7ed-d5d29fd90d7d"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("6f6f41f8-8ce1-4cb4-a031-13ad1b18e0e2"), "ششده", 23 },
                    { 900, new Guid("61150fc6-840f-4855-9c30-0f3df83e239e"), "سيدان", 23 },
                    { 899, new Guid("2da98e52-faca-40e5-8b6e-ef1cdd364306"), "سورمق", 23 },
                    { 898, new Guid("eb1fb999-9cdf-4479-b849-b9a35e91eb59"), "سلطان شهر", 23 },
                    { 897, new Guid("01321084-13e4-4eb6-be49-a773799cb0f6"), "سعادت شهر", 23 },
                    { 896, new Guid("cdb37c31-3b69-4de5-9e70-693bf33027cb"), "سروستان", 23 },
                    { 895, new Guid("c0230172-a057-4902-8eba-0456ffc8893a"), "سده", 23 },
                    { 894, new Guid("9d1d5a1a-491a-4c6b-bb37-029e5c5db2bc"), "زرقان", 23 },
                    { 893, new Guid("8c1744a7-f950-481a-ab82-64426d405235"), "زاهد شهر", 23 },
                    { 892, new Guid("369ee91b-92f0-43a3-9f71-398d600e1d79"), "رونيز", 23 },
                    { 891, new Guid("09420558-65e3-433b-a622-fabc5127113e"), "رامجرد", 23 },
                    { 906, new Guid("bb806cb8-16cd-4bb0-a40b-52ce487458ea"), "صفا شهر", 23 },
                    { 907, new Guid("a92cd624-1c87-4216-a585-4c23896614a5"), "علامرودشت", 23 },
                    { 908, new Guid("ea63dd2f-6444-4d6f-b897-74ddc8c62aa8"), "عماد ده", 23 },
                    { 909, new Guid("698b092c-a5d2-4afb-9af4-72cf5b576298"), "فدامي", 23 },
                    { 925, new Guid("818b783f-89b9-4bdb-9daf-219b28ef214c"), "مرودشت", 23 },
                    { 924, new Guid("731ca4ba-1813-400f-971c-32c3423a17c7"), "مبارک آباد", 23 },
                    { 923, new Guid("d2797d58-4a61-441f-88cf-2f76d9597df5"), "مادرسليمان", 23 },
                    { 922, new Guid("b4738aca-cce1-4928-8d5c-550f0b289d7e"), "لپوئي", 23 },
                    { 921, new Guid("ba547667-c5ee-43f1-b645-efff279618e0"), "لطيفي", 23 },
                    { 920, new Guid("1a5db0f1-33f5-469c-bae7-26addb57dc82"), "لامرد", 23 },
                    { 919, new Guid("a0ff9d6d-ed1f-4c0e-925b-48c9a7abd18a"), "لار", 23 },
                    { 890, new Guid("16c91e47-eeeb-4bcc-a64f-aeffbe7299d4"), "دژکرد", 23 },
                    { 918, new Guid("46e2cca5-3e58-4e6d-9d2f-0a5b02744c0d"), "قير", 23 },
                    { 916, new Guid("4e56d7b3-3f5c-4178-bbd4-742f0a686cd6"), "قطب آباد", 23 },
                    { 915, new Guid("42e58dc2-ffc3-412e-88bf-94462565ea7f"), "قره بلاغ", 23 },
                    { 914, new Guid("2b9e5cd7-b58c-495b-a3c0-c7bfc3fda422"), "قادرآباد", 23 },
                    { 913, new Guid("74753ffa-09c3-45b1-b153-ceb94081b904"), "قائميه", 23 },
                    { 912, new Guid("bfc6aa33-458c-4b64-882f-f3d4d0e793a2"), "فيروزآباد", 23 },
                    { 911, new Guid("5c8e3509-0f2b-4e81-b948-5e7cfa01bb5e"), "فسا", 23 },
                    { 910, new Guid("e32befe2-1bd5-40f3-841c-c7a09e9c45de"), "فراشبند", 23 },
                    { 917, new Guid("26075320-513e-40f8-a190-a8347fd0eb73"), "قطرويه", 23 },
                    { 889, new Guid("0dff40a8-b5bc-4b09-81c4-df5f0812179d"), "دوزه", 23 },
                    { 888, new Guid("9ae1be49-dabf-4ff6-b2b7-cd11cfd468a0"), "دوبرجي", 23 },
                    { 887, new Guid("6d559556-f306-45fd-bf0d-c9042ac051fe"), "دهرم", 23 },
                    { 866, new Guid("01155103-0f05-4480-b030-225824b55bc5"), "بوانات", 23 },
                    { 865, new Guid("496d944b-e75c-489f-97b1-f57b659821c2"), "بهمن", 23 },
                    { 864, new Guid("ab76b663-94fa-4f1d-b217-8ca7b10db3f8"), "بنارويه", 23 },
                    { 863, new Guid("62f6c4c4-dcf4-49e3-9a23-b9666ced6e99"), "بالاده", 23 },
                    { 862, new Guid("50038879-60c9-4cfe-ab94-7d259e457d28"), "بابامنير", 23 },
                    { 861, new Guid("c30743c3-f647-455c-8d7f-7f0f0b7a406c"), "باب انار", 23 },
                    { 860, new Guid("8176d280-4f88-4231-9f5c-7f3bb56b1f5a"), "ايزد خواست", 23 },
                    { 867, new Guid("cab68a12-cfab-4cf8-b7be-49047ef476a7"), "بيرم", 23 },
                    { 859, new Guid("1599d03f-12f7-40c8-a65d-32a46bdda58b"), "ايج", 23 },
                    { 857, new Guid("f9b68599-08fb-4eac-850d-548f00ef588e"), "اهل", 23 },
                    { 856, new Guid("20642a2a-790d-4c10-aff8-27d5b3703af1"), "امام شهر", 23 },
                    { 855, new Guid("b51ff677-e6cc-4be9-adc8-6576cf75a016"), "اقليد", 23 },
                    { 854, new Guid("326e66fe-2fc6-4699-91c9-795a5a56dcde"), "افزر", 23 },
                    { 853, new Guid("b8111985-b1d6-4fce-b404-c2d513b9359a"), "اشکنان", 23 },
                    { 852, new Guid("762591cf-9359-40c5-ab79-9cbfabf45d51"), "اسير", 23 },
                    { 851, new Guid("b15bb32a-81c2-4e35-9146-86e8af3b24c0"), "استهبان", 23 },
                    { 858, new Guid("f7ca4b97-7b9c-4ae6-88e2-baa902080137"), "اوز", 23 },
                    { 772, new Guid("8897f93f-cba9-4e85-88a6-33f2dcbe92eb"), "لواسان", 21 },
                    { 868, new Guid("da25f43f-5918-4af4-bb4a-92042ec92cd3"), "بيضا", 23 },
                    { 870, new Guid("4ea78398-cebc-4f07-85f3-78e8a79daa4c"), "جهرم", 23 },
                    { 886, new Guid("3b074194-f0c1-432d-9227-7fc0eb1c290f"), "دبيران", 23 },
                    { 885, new Guid("1d90b4b4-a196-4260-a601-cdbdee334690"), "داريان", 23 },
                    { 884, new Guid("dcf0fbed-ed8a-4a3e-aad8-dfad08f15440"), "داراب", 23 },
                    { 883, new Guid("4e60d545-b19b-4ca3-a3d8-3c7beca5a641"), "خومه زار", 23 },
                    { 882, new Guid("195b09ab-6b15-4f4c-bc02-909b79c1e74d"), "خوزي", 23 },
                    { 881, new Guid("c0ff3d59-4e57-4c61-abeb-28626ec42d99"), "خور", 23 },
                    { 880, new Guid("a8468ef9-15b6-4e4e-845d-fbe541bc30ff"), "خنج", 23 },
                    { 869, new Guid("62bcb374-fb6e-4046-853a-d70cbede39ce"), "جنت شهر", 23 },
                    { 879, new Guid("b5c39380-24ca-4fae-8abe-882f3e249b31"), "خشت", 23 },
                    { 877, new Guid("e74500fc-7f0a-4eef-962a-a4aa93038be3"), "خاوران", 23 },
                    { 876, new Guid("484499da-ba1f-4709-bb7b-c1ffa4cfa4ba"), "خانيمن", 23 },
                    { 875, new Guid("10825e9d-8d3d-449e-8000-6c5c68300f97"), "خانه زنيان", 23 },
                    { 874, new Guid("c0d49488-6ff4-449a-95cf-7ad5924f50c5"), "حسن آباد", 23 },
                    { 873, new Guid("ea7e35fe-0bb3-4565-8b6f-0f62d67b865f"), "حسامي", 23 },
                    { 872, new Guid("5989ad7a-466d-40da-ada5-727e033e27c1"), "حاجي آباد", 23 },
                    { 871, new Guid("433e624a-4640-47b7-87a7-a10449631ff4"), "جويم", 23 },
                    { 878, new Guid("e18f6dc4-3162-4f07-baa3-14c5771f2c7f"), "خرامه", 23 },
                    { 771, new Guid("afa17bc2-2e10-405f-a036-ec396c99d9ad"), "قرچک", 21 },
                    { 770, new Guid("a6d0db12-b589-4aac-ab43-3240fac5d2e5"), "قدس", 21 },
                    { 769, new Guid("391b48f0-7e04-4957-bd82-38e3e667633d"), "فيروزکوه", 21 },
                    { 669, new Guid("ebb90f7f-3bda-4e88-9838-6046bdd73deb"), "عسگران", 19 },
                    { 668, new Guid("f5d22b80-a0dd-4237-a421-eacd4e9bd6ca"), "طرق رود", 19 },
                    { 667, new Guid("f1d1cbfa-bfd5-4ac1-8b96-ab50d3aa184f"), "طالخونچه", 19 },
                    { 666, new Guid("b13147a7-eec8-4b34-86b8-a484d47d947c"), "شهرضا", 19 },
                    { 665, new Guid("7b774a14-c202-450d-b9e2-0571d46c2f0d"), "شاپورآباد", 19 },
                    { 664, new Guid("2392b0ba-6d41-4b65-b62b-68b44c1e7af7"), "شاهين شهر", 19 },
                    { 663, new Guid("a386ae27-c605-46d9-ac0a-cf1ec043dfb6"), "سگزي", 19 },
                    { 662, new Guid("85c279bd-5750-4ea0-82ed-847857ddbe0a"), "سين", 19 },
                    { 661, new Guid("1ad21dca-c407-4152-a27b-7845fe6a911e"), "سميرم", 19 },
                    { 660, new Guid("58906f1f-b654-443b-89fe-1fe1e8fd9445"), "سفيد شهر", 19 },
                    { 659, new Guid("2db49234-87f3-4570-9df8-097944199de7"), "سده لنجان", 19 },
                    { 658, new Guid("816e9edd-ad25-491f-b4f2-aa2145e4576f"), "زيباشهر", 19 },
                    { 657, new Guid("c22000fb-0ad7-48f6-a6d8-fc28743a60b6"), "زيار", 19 },
                    { 656, new Guid("c3c520a8-5bdd-4d82-b4e4-d6e6d11bc59b"), "زواره", 19 },
                    { 655, new Guid("87d3f07e-7613-4b68-a372-3347f8a70216"), "زرين شهر", 19 },
                    { 670, new Guid("51ca251f-a945-4568-bb0d-e90adf4e9d46"), "علويچه", 19 },
                    { 671, new Guid("d7812064-ca3c-464d-9ff1-9b00fd99d470"), "فرخي", 19 },
                    { 672, new Guid("2fa8345e-cc38-4614-9d03-40539fda8fcf"), "فريدونشهر", 19 },
                    { 673, new Guid("0b4e3f04-eb06-4d5d-95e7-85f6b8068ed3"), "فلاورجان", 19 },
                    { 689, new Guid("9d0e05b7-5579-496e-aaae-201957a78d71"), "نوش آباد", 19 },
                    { 688, new Guid("9bf9f503-43df-4257-aaa1-67b54c845879"), "نطنز", 19 },
                    { 687, new Guid("f9d6497f-4bc1-4de1-9510-0d2db64cfe48"), "نصرآباد", 19 },
                    { 686, new Guid("801fac4c-6721-49cd-839a-e3dd3fbbc026"), "نجف آباد", 19 },
                    { 685, new Guid("f5dfe1cd-f728-4b41-b7db-b0e4dd8603bc"), "نائين", 19 },
                    { 684, new Guid("79051e24-89d8-4769-834e-1cf46f7758ff"), "ميمه", 19 },
                    { 683, new Guid("bf300517-16d3-4900-882a-d5ca4fc705b8"), "مهاباد", 19 },
                    { 654, new Guid("ab88b185-0d50-4031-a302-b465832e60ab"), "زاينده رود", 19 },
                    { 682, new Guid("b2eb07e9-c80e-4beb-aecc-6627b236109b"), "منظريه", 19 },
                    { 680, new Guid("7ebadf9f-e423-4fab-8ab6-dcfd86a41e5b"), "محمد آباد", 19 },
                    { 679, new Guid("37324b81-24a9-47df-be27-ab7e80722b89"), "مبارکه", 19 },
                    { 678, new Guid("bb98f2da-ceda-4a50-a8e1-39e0173523c0"), "لاي بيد", 19 },
                    { 677, new Guid("29700461-9faa-4f35-8ca3-8c23e6b79460"), "قهدريجان", 19 },
                    { 676, new Guid("5cc6b72b-5920-4aa0-ba52-a964b0b169b5"), "قهجاورستان", 19 },
                    { 675, new Guid("67f8b711-610e-4071-9a82-9f5a89ea67ad"), "قمصر", 19 },
                    { 674, new Guid("e930ee16-ce6e-4bc3-b48b-f26769f61cf9"), "فولاد شهر", 19 },
                    { 681, new Guid("7ba4af1a-1e9e-4746-b727-d01be3f1fe0a"), "مشکات", 19 },
                    { 690, new Guid("838f449d-a033-45a4-8aeb-8d08b6077ec2"), "نياسر", 19 },
                    { 653, new Guid("c5491c46-cf58-4cd2-92ad-72bcca80152d"), "زازران", 19 },
                    { 651, new Guid("c73fc922-b8e2-4ce3-8c1b-526ed54b1bd2"), "رزوه", 19 },
                    { 630, new Guid("0a907e5c-628d-4ac9-8889-0c159a64bd50"), "تودشک", 19 },
                    { 629, new Guid("1deedcbb-afdb-47bf-852e-01f2b6c77281"), "بوئين مياندشت", 19 },
                    { 628, new Guid("729264a3-5b7c-40d7-9b74-86d3176d293f"), "بهارستان", 19 },
                    { 627, new Guid("9d17fd9b-ebc2-403f-b16f-5b35eada1900"), "بهاران شهر", 19 },
                    { 626, new Guid("a9aba084-2b1b-4ba0-a56b-b25deeaac453"), "برف انبار", 19 },
                    { 625, new Guid("0a543ec3-3c7a-4688-a83b-d4acb12249ed"), "برزک", 19 },
                    { 624, new Guid("cde316f8-0484-45f0-98fb-d122fd80b345"), "بافران", 19 },
                    { 623, new Guid("ca44b771-bbb2-4639-97f3-02d4c67f92b7"), "باغشاد", 19 },
                    { 622, new Guid("dfc75ace-e024-4bb0-a1ed-9cf2b8f04190"), "باغ بهادران", 19 },
                    { 621, new Guid("4428dbea-6425-4403-9e28-ce84591d5606"), "بادرود", 19 },
                    { 620, new Guid("28869441-2ec5-4c47-b09f-9781d1e73a13"), "اژيه", 19 },
                    { 619, new Guid("c51382c0-0167-4849-8e63-23d78535050b"), "ايمانشهر", 19 },
                    { 618, new Guid("78be427a-1c0e-449b-aadc-76c7ae28055c"), "انارک", 19 },
                    { 617, new Guid("d1282398-85b3-4d50-a55d-da1452b0e9f1"), "افوس", 19 },
                    { 616, new Guid("682f37ec-8521-4475-a962-1e6831deaf91"), "اصفهان", 19 },
                    { 631, new Guid("2a0843d6-3d71-4755-9c2a-5425ae833c8a"), "تيران", 19 },
                    { 632, new Guid("79b86e9e-4fc1-481f-9150-b7054f200f28"), "جندق", 19 },
                    { 633, new Guid("4e024a24-ec23-490a-b76d-f56b87782776"), "جوزدان", 19 },
                    { 634, new Guid("5d410098-9731-48b0-855d-9a8242ee1151"), "جوشقان قالي", 19 },
                    { 650, new Guid("6df7bede-599f-4e6f-bbee-c939cbfe8f73"), "ديزيچه", 19 },
                    { 649, new Guid("5e5e63e8-35eb-49d1-ac55-2472992b6b50"), "دولت آباد", 19 },
                    { 648, new Guid("00c38c3f-3242-43e4-bf5b-aad37b1547c1"), "دهق", 19 },
                    { 647, new Guid("65473d0e-eed1-4c4f-a700-f9956b3da96c"), "دهاقان", 19 },
                    { 646, new Guid("7c779007-7e5d-450a-9857-8d94139c710a"), "دستگرد", 19 },
                    { 645, new Guid("763f0f73-3004-42c9-b350-f83fa0413064"), "درچه پياز", 19 },
                    { 644, new Guid("292ad78e-b2c1-4a94-8450-bd30ad101292"), "دامنه", 19 },
                    { 652, new Guid("820d0121-205a-4b9a-86b9-a99b4079165d"), "رضوانشهر", 19 },
                    { 643, new Guid("28ea61fb-6226-469a-aec7-d50b23fd07ba"), "داران", 19 },
                    { 641, new Guid("95c0f13a-7e36-4e23-b424-3f5306fddfe5"), "خور", 19 },
                    { 640, new Guid("a478fab0-6ad1-4b4f-a5a3-899aea80aca0"), "خوانسار", 19 },
                    { 639, new Guid("1488cb67-2d80-4ddc-9dc8-54257a14529c"), "خميني شهر", 19 },
                    { 638, new Guid("2a124ff1-be81-4323-87f5-98da77a2a018"), "خالد آباد", 19 },
                    { 637, new Guid("2b87a11b-16b0-4a6a-8bdf-869b8870c5ef"), "حنا", 19 },
                    { 636, new Guid("2683a5b5-790e-4607-8464-95939d8d1d65"), "حسن آباد", 19 },
                    { 635, new Guid("c62b9a9b-1097-41b4-9017-dea982e9828f"), "حبيب آباد", 19 },
                    { 642, new Guid("7294be1a-55d4-4215-8f51-307c572d850a"), "خورزوق", 19 },
                    { 691, new Guid("83f72367-433c-47ec-87fe-ef030a66f752"), "نيک آباد", 19 },
                    { 692, new Guid("6977983a-49d0-4b70-86a7-9c0f95844737"), "هرند", 19 },
                    { 693, new Guid("bd453731-1087-4067-ae2d-2a488985e041"), "ورزنه", 19 },
                    { 748, new Guid("bf6098d8-e970-492d-8c6d-d7cb7f552eb4"), "باقرشهر", 21 },
                    { 747, new Guid("9d62e246-6c0a-4342-93ab-5f1f940e4c90"), "باغستان", 21 },
                    { 746, new Guid("b47f0906-52b8-4d91-a70c-00efd300dbe3"), "انديشه", 21 },
                    { 745, new Guid("486233db-758e-4086-888f-b8feb044865e"), "اسلامشهر", 21 },
                    { 744, new Guid("4f06f157-27ad-41ba-9482-e8edb275d51c"), "ارجمند", 21 },
                    { 743, new Guid("c832bd55-1604-4af4-9e62-c4c3a72c71fe"), "آبعلي", 21 },
                    { 742, new Guid("0b3ddc56-c669-4d3c-bff1-ee596a4582e3"), "آبسرد", 21 },
                    { 741, new Guid("f3c5e120-7585-465c-95f3-cdd39351dd2e"), "چوار", 20 },
                    { 740, new Guid("73b3476b-3645-4713-8773-7901d2a81ecf"), "پهله", 20 },
                    { 739, new Guid("b31ca826-e64a-44ea-9f81-cfd905755623"), "ميمه", 20 },
                    { 738, new Guid("1e05aaa3-92d1-4dfe-8a38-aadff9e065d4"), "موسيان", 20 },
                    { 737, new Guid("53136ae9-c025-4a40-9bc5-a8cb4271af87"), "مورموري", 20 },
                    { 736, new Guid("00229ba7-b89c-4397-963c-d77246275793"), "مهران", 20 },
                    { 735, new Guid("27cf6b15-b936-4033-a368-634f6832ecf5"), "مهر", 20 },
                    { 734, new Guid("0cd54a1c-c58f-492f-ba2b-6d550b36fba3"), "ماژين", 20 },
                    { 749, new Guid("71373157-1249-4ad4-8eee-6f47d8d31eaf"), "بومهن", 21 },
                    { 750, new Guid("865ee51f-5d9d-4133-a85c-b491b57cb0d3"), "تجريش", 21 },
                    { 751, new Guid("3b74ab69-8731-4016-b95c-114a384ca698"), "تهران", 21 },
                    { 752, new Guid("de55ea55-f005-47b7-9014-c579613362de"), "جواد آباد", 21 },
                    { 768, new Guid("c360207f-4d1a-4f13-9431-3010e8f0d67d"), "فشم", 21 },
                    { 767, new Guid("3c35f223-7d87-4bd2-837c-5fe37ab6ecf3"), "فرون آباد", 21 },
                    { 766, new Guid("3944dddf-55ef-433b-a5a4-2d76740ba89d"), "فردوسيه", 21 },
                    { 765, new Guid("dc270a4b-13ff-41ac-ba5a-9c819369e7d2"), "صفادشت", 21 },
                    { 764, new Guid("f3159497-71e7-4bac-8445-1e868e69316a"), "صبا شهر", 21 },
                    { 763, new Guid("7a53b683-ad6d-421d-8746-09499e83f9c6"), "صالحيه", 21 },
                    { 762, new Guid("9e893bc0-e19e-45ff-bd81-a91185cc09c8"), "شهريار", 21 },
                    { 733, new Guid("6e33d4db-84e2-4764-84b4-4b3195ded397"), "لومار", 20 },
                    { 761, new Guid("295f4091-0332-4a5c-8652-403a91282134"), "شهر جديد پرند", 21 },
                    { 759, new Guid("864dd4e9-05bf-49f6-b89c-bf2e05ff1eb1"), "شريف آباد", 21 },
                    { 758, new Guid("bbc7ebb4-5cac-4ae0-b1fd-f9cd28adf3dc"), "شاهدشهر", 21 },
                    { 757, new Guid("2ccb8734-3045-4a2b-bd10-2c25b6c2dc36"), "ري", 21 },
                    { 756, new Guid("2942c591-b28e-49f4-bcae-79b2665feb09"), "رودهن", 21 },
                    { 755, new Guid("433a557a-ce20-4f70-8800-a7703a8043af"), "رباط کريم", 21 },
                    { 754, new Guid("aed996a7-8c3a-4351-8223-0a21e16962f0"), "دماوند", 21 },
                    { 753, new Guid("e6e152b0-f330-41b4-ac95-eabd5e3eb594"), "حسن آباد", 21 },
                    { 760, new Guid("fd5271d5-bd53-406b-886f-359493d11f2f"), "شمشک", 21 },
                    { 732, new Guid("4a38d7e7-fce6-4b8b-ae1c-a26a51e90304"), "صالح آباد", 20 },
                    { 731, new Guid("2c43e5a5-e5f5-4d6d-b53c-9df5d56f81b1"), "شباب", 20 },
                    { 730, new Guid("be76f635-9d73-4c92-8393-489f09790a9f"), "سرابله", 20 },
                    { 709, new Guid("9c3e1a81-7ea5-466b-a705-07695de0a996"), "کوهپايه", 19 },
                    { 708, new Guid("d58b40b2-1634-45ab-90c3-ef28b1b37164"), "کوشک", 19 },
                    { 707, new Guid("c2169892-9e7d-44fb-8f1c-5090cda65d6c"), "کهريزسنگ", 19 },
                    { 706, new Guid("06b8d30a-7aa8-460c-b35b-25372ada7fff"), "کمه", 19 },
                    { 705, new Guid("c3c56872-7b21-4fad-b782-a573ab4e95d1"), "کمشجه", 19 },
                    { 704, new Guid("7de0e82a-a4a1-4458-b1eb-749443e6e29c"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("31f1451b-bd9e-45ee-9673-2de22257e4e7"), "کرکوند", 19 },
                    { 710, new Guid("8fe277c9-d268-45ed-b860-ff45073556df"), "گرگاب", 19 },
                    { 702, new Guid("fd2a1c40-9a23-487c-a9a5-025a8412a797"), "کامو و چوگان", 19 },
                    { 700, new Guid("ac10df3b-9b96-490f-85b4-cc0128584529"), "چمگردان", 19 },
                    { 699, new Guid("98e805ba-a7e7-4df8-8c7c-d3dbc5b7cc07"), "چرمهين", 19 },
                    { 698, new Guid("d26734d4-46a0-400d-aa0c-f3b380569841"), "چادگان", 19 },
                    { 697, new Guid("e270346c-41e0-4890-9a65-d6b9a83e100c"), "پير بکران", 19 },
                    { 696, new Guid("bbca9c36-50f2-47d4-960f-a2b05aa9503d"), "ونک", 19 },
                    { 695, new Guid("ee3b6bfe-f76e-46a6-bed8-4546d56a3a13"), "وزوان", 19 },
                    { 694, new Guid("dd2742e9-a046-46f8-878a-49679e7740da"), "ورنامخواست", 19 },
                    { 701, new Guid("176f69ca-c08b-4635-804e-1cda11444498"), "کاشان", 19 },
                    { 926, new Guid("d34b2266-853e-43d5-9ca7-9adb42fdda89"), "مزايجان", 23 },
                    { 711, new Guid("1f880536-141c-4ec3-aed6-93ba429e49c7"), "گز برخوار", 19 },
                    { 713, new Guid("ffa56370-4fff-467d-8e7e-63397bac4a38"), "گلشن", 19 },
                    { 729, new Guid("6bfdddff-5960-4207-8eeb-fb42e20014b0"), "سراب باغ", 20 },
                    { 728, new Guid("544bbd57-7d30-47b0-87fe-431049299920"), "زرنه", 20 },
                    { 727, new Guid("5706253c-36c7-49e2-9440-2a97a9fb1a92"), "دهلران", 20 },
                    { 726, new Guid("ace671bf-3610-472c-8ccb-de746b1897cc"), "دلگشا", 20 },
                    { 725, new Guid("22e52853-95e4-468d-bceb-29eab46f5904"), "دره شهر", 20 },
                    { 724, new Guid("d1ab3fa2-023a-4f24-b00f-b6179402aded"), "توحيد", 20 },
                    { 723, new Guid("46e6e512-c3e5-4b9e-8e52-c21faf366318"), "بلاوه", 20 },
                    { 712, new Guid("ece65c2a-7588-4c6c-821e-2c4ddf792f1e"), "گلدشت", 19 },
                    { 722, new Guid("54710a2a-64a1-4c97-8f6d-82cc1e68f5dd"), "بدره", 20 },
                    { 720, new Guid("89bf7517-645c-4d44-8a9e-0e3082f35f63"), "ايلام", 20 },
                    { 719, new Guid("1eff8cd6-3187-46cb-98d3-6fa0120f377d"), "ارکواز", 20 },
                    { 718, new Guid("e3b503f2-ab69-45f5-a17c-d6bf1646c687"), "آسمان آباد", 20 },
                    { 717, new Guid("f4f5d715-ca11-4f05-80f0-e96062c99966"), "آبدانان", 20 },
                    { 716, new Guid("84f20588-5fa7-49d8-8acb-a481677d31e4"), "گوگد", 19 },
                    { 715, new Guid("f1d8cb2f-4b0a-4b77-8039-4d76f4ebc06e"), "گلپايگان", 19 },
                    { 714, new Guid("327aca4d-f4bc-4252-9e3b-5248856bdfea"), "گلشهر", 19 },
                    { 721, new Guid("68ee0e7f-b4fc-41ec-a3d0-03d549202144"), "ايوان", 20 },
                    { 927, new Guid("3cf9da42-7195-4d8f-8821-5cbaa44a42ef"), "مشکان", 23 },
                    { 928, new Guid("6b87083e-f1c6-411c-bbd2-043343083cdb"), "مصيري", 23 },
                    { 929, new Guid("2ad81fe8-7f5f-4195-9687-a577cbbf1fde"), "مهر", 23 },
                    { 1141, new Guid("d79c352d-27b8-46e5-a469-613fe02ae276"), "بردسير", 29 },
                    { 1140, new Guid("1bb4b0bc-7644-4d9b-869f-61694c5654d6"), "بافت", 29 },
                    { 1139, new Guid("c2f12a22-a3df-4ebb-b859-d595046da3f6"), "باغين", 29 },
                    { 1138, new Guid("05a962d6-b292-4f7c-b00f-1cedd1da5f9e"), "اندوهجرد", 29 },
                    { 1137, new Guid("c37ecf21-14a4-46c4-8bf4-b38653f52721"), "انار", 29 },
                    { 1136, new Guid("ba7756ce-eb0d-4142-9881-9bd555c47b38"), "امين شهر", 29 },
                    { 1135, new Guid("ce101839-c43c-49c0-a928-9b871da77f93"), "ارزوئيه", 29 },
                    { 1134, new Guid("765f2fc3-c183-4cb7-9760-b54c37acd0fb"), "اختيار آباد", 29 },
                    { 1133, new Guid("11f0d605-a4eb-4066-9da7-e3f9a2c2dc87"), "گيان", 28 },
                    { 1132, new Guid("8497eee4-75b2-4f9e-b723-96660ad305e9"), "گل تپه", 28 },
                    { 1131, new Guid("ef02eda0-f4fc-4639-b012-b3d3d151a05c"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("d9d7fff6-57fd-4e6b-87e9-88d39732070a"), "همدان", 28 },
                    { 1129, new Guid("1f09fdbe-abcf-47e8-9f79-4e44620ce381"), "نهاوند", 28 },
                    { 1128, new Guid("9023dcc3-e0dc-4456-a303-41cfaa595829"), "مهاجران", 28 },
                    { 1127, new Guid("2e545bba-3dd0-40b3-8ddc-5a4f11ec3bdc"), "ملاير", 28 },
                    { 1142, new Guid("d856a0ba-6024-4f57-91d2-02894598111c"), "بروات", 29 },
                    { 1143, new Guid("540a2c2e-55de-4e90-bde3-80bac61ce011"), "بزنجان", 29 },
                    { 1144, new Guid("36a812a0-ea31-420f-b02f-cd6627f10042"), "بلورد", 29 },
                    { 1145, new Guid("6b196373-fc11-4cda-a159-845605af0203"), "بلوک", 29 },
                    { 1161, new Guid("5a86d38d-ce56-4a23-950b-4bcd4835d02f"), "راور", 29 },
                    { 1160, new Guid("e54a0c11-cff8-49f9-b6b6-9b240fad0760"), "رابر", 29 },
                    { 1159, new Guid("c87eb2e0-c6db-4830-8e37-23f1573fb645"), "دوساري", 29 },
                    { 1158, new Guid("12617aa9-436d-4908-9aa0-01a8da77d7c3"), "دهج", 29 },
                    { 1157, new Guid("8afac8d1-7abb-48aa-88bf-102240191bc6"), "دشتکار", 29 },
                    { 1156, new Guid("d41b82fc-0152-4c32-9921-726ff15101d7"), "درب بهشت", 29 },
                    { 1155, new Guid("1c9078af-53ae-48fb-8216-06e6476a0066"), "خورسند", 29 },
                    { 1126, new Guid("f90dd2bc-f440-4e96-b2a2-99055b0f5f34"), "مريانج", 28 },
                    { 1154, new Guid("acff2d62-4a0a-4b2f-805e-3c5cbf4f833a"), "خواجوشهر", 29 },
                    { 1152, new Guid("fba143b3-32d9-4b20-9a34-9440c4ca369b"), "خاتون آباد", 29 },
                    { 1151, new Guid("64960194-d38f-49dd-b8f9-2ab57d9a6987"), "جيرفت", 29 },
                    { 1150, new Guid("dfe6afa3-0276-46df-8f0f-c705da8a8720"), "جوپار", 29 },
                    { 1149, new Guid("3631c351-4600-455d-8b02-91028159a28d"), "جوزم", 29 },
                    { 1148, new Guid("f73738fc-efe9-4492-b5af-acd318962013"), "جبالبارز", 29 },
                    { 1147, new Guid("208ff14c-620d-4502-806b-fa3e27ea8caf"), "بهرمان", 29 },
                    { 1146, new Guid("30aa1c98-dfc3-4aa9-8f39-f8858c44e53f"), "بم", 29 },
                    { 1153, new Guid("b591df32-9503-4690-9971-ada6e937705f"), "خانوک", 29 },
                    { 1162, new Guid("af371cbc-380c-4f27-afb7-11c0db7abb9f"), "راين", 29 },
                    { 1125, new Guid("38d57857-3f05-4939-b9ca-84b49c9609f8"), "لالجين", 28 },
                    { 1123, new Guid("1767ad0d-9c28-46a4-8d0b-45fe74e79720"), "قروه در جزين", 28 },
                    { 1102, new Guid("cd6cb7b7-4941-43bb-ad16-70d1415f55a5"), "کوچصفهان", 27 },
                    { 1101, new Guid("56af3731-ab03-48db-ad28-69866116aa80"), "کومله", 27 },
                    { 1100, new Guid("9aff4467-71da-4546-9522-b2f29025e732"), "کلاچاي", 27 },
                    { 1099, new Guid("3ebfc334-bb80-441a-b023-d20416a32c56"), "چوبر", 27 },
                    { 1098, new Guid("3820c93a-5a4a-472e-a263-15e7b5213e48"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("cfe505f5-9d22-4677-8cd4-9a22f268bf99"), "چابکسر", 27 },
                    { 1096, new Guid("7df3d8c4-0638-4841-a8c9-128aba5ec71f"), "پره سر", 27 },
                    { 1095, new Guid("36780841-e2cc-4724-ba10-837323a68d3e"), "واجارگاه", 27 },
                    { 1094, new Guid("761d6cd6-3725-4dd6-8c0f-ab7f219c6bed"), "هشتپر", 27 },
                    { 1093, new Guid("60a881fa-9a01-4790-9a53-53ec7af92568"), "منجيل", 27 },
                    { 1092, new Guid("555e52a8-6344-45b5-8db4-391a82bbea8d"), "مرجقل", 27 },
                    { 1091, new Guid("f86457a6-e634-48c9-90e1-3a98637677af"), "ماکلوان", 27 },
                    { 1090, new Guid("237a45f5-a620-4d76-8e3d-28c0a3fdcc73"), "ماسوله", 27 },
                    { 1089, new Guid("f4988540-8142-408e-9ec6-efdc5653221d"), "ماسال", 27 },
                    { 1088, new Guid("aff1a900-baa7-41f2-b718-a5bf71eca41d"), "ليسار", 27 },
                    { 1103, new Guid("e2a24f2f-6724-4ee3-80c1-427901b511cc"), "کياشهر", 27 },
                    { 1104, new Guid("bbc5fa9e-baf4-4189-a071-1b187eede7eb"), "گوراب زرميخ", 27 },
                    { 1105, new Guid("dc6214ba-d1a7-46b5-810c-53e48c6c0fe9"), "آجين", 28 },
                    { 1106, new Guid("9a85c6f2-fcec-415f-a7f1-4a23e5a57ebc"), "ازندريان", 28 },
                    { 1122, new Guid("81988a45-a81a-41fc-929c-cb098586a9f9"), "فيروزان", 28 },
                    { 1121, new Guid("0e139fb0-e3fb-4d08-939b-35b0b1a9831a"), "فرسفج", 28 },
                    { 1120, new Guid("51e89276-5762-4e25-82e6-58a52a650b25"), "فامنين", 28 },
                    { 1119, new Guid("0aa98bb8-6c4c-4050-95c3-8ecc834e529f"), "صالح آباد", 28 },
                    { 1118, new Guid("587c3ca2-c639-44f9-9858-d03ce59d641b"), "شيرين سو", 28 },
                    { 1117, new Guid("05e9076b-e8bc-4433-bfd4-eb2819aad6f4"), "سرکان", 28 },
                    { 1116, new Guid("47248266-eb11-4f4d-b6da-146fdee13f86"), "سامن", 28 },
                    { 1124, new Guid("e874cf65-e437-4c99-bad1-1608329dc947"), "قهاوند", 28 },
                    { 1115, new Guid("6a32a686-b4f8-4b30-bf60-4cbe5b7a90dd"), "زنگنه", 28 },
                    { 1113, new Guid("a4e560f0-7e96-48bb-b709-71cdb11bef94"), "دمق", 28 },
                    { 1112, new Guid("4200535e-205b-4204-b0d8-279d4c6fed4f"), "جوکار", 28 },
                    { 1111, new Guid("97b81454-7332-4800-ba52-5ef3663d62e8"), "جورقان", 28 },
                    { 1110, new Guid("f2aa6d83-d68c-447b-84cc-c47471d3a0d3"), "تويسرکان", 28 },
                    { 1109, new Guid("3d56d27a-2bcc-4fbc-941c-7bb2204e66d0"), "بهار", 28 },
                    { 1108, new Guid("cb5202a8-01f5-49cd-931a-e5ce11627ca2"), "برزول", 28 },
                    { 1107, new Guid("a042d200-db0f-403d-9f4d-006576919ee1"), "اسد آباد", 28 },
                    { 1114, new Guid("3aa5cdb1-b8ed-44b0-ba7f-2b3c987f33ee"), "رزن", 28 },
                    { 1163, new Guid("419cb1e9-7a10-4d47-8703-b745d2d5d150"), "رفسنجان", 29 },
                    { 1164, new Guid("115a8429-0197-477e-b0df-4a8c9c6891e2"), "رودبار", 29 },
                    { 1165, new Guid("ed29f8d9-a02b-4258-9ee1-4782edd2b2f4"), "ريحان", 29 },
                    { 1220, new Guid("5de68097-3fdb-4a6f-bb87-643e6b05e5cb"), "ميامي", 30 },
                    { 1219, new Guid("2e3658cf-e521-45ea-8ca1-70dc56025160"), "مهدي شهر", 30 },
                    { 1218, new Guid("019ce053-0fb8-41af-bbd3-cf1eb37954ef"), "مجن", 30 },
                    { 1217, new Guid("4f3f35ec-0160-4faf-9748-ab26445cdcef"), "شهميرزاد", 30 },
                    { 1216, new Guid("d7541d35-08ea-4901-b48b-b99da28bd8d1"), "شاهرود", 30 },
                    { 1215, new Guid("ef509fc6-3452-4a1e-9999-501e62a4caf3"), "سمنان", 30 },
                    { 1214, new Guid("47ccecb6-1545-465e-987e-8de135b4700e"), "سرخه", 30 },
                    { 1213, new Guid("252f68b3-bb31-4837-a885-4e29710c2611"), "روديان", 30 },
                    { 1212, new Guid("f9ee6140-16d8-4822-aea3-5ad5092f4966"), "ديباج", 30 },
                    { 1211, new Guid("0e135d3a-4027-4965-ae62-33b18e635b24"), "درجزين", 30 },
                    { 1210, new Guid("0ebbb4b0-1e12-42b5-93cf-69c78f620747"), "دامغان", 30 },
                    { 1209, new Guid("e067b9f6-5c84-478b-8a6c-4bf93065acca"), "بيارجمند", 30 },
                    { 1208, new Guid("680b7992-3865-49bf-b91f-034982285848"), "بسطام", 30 },
                    { 1207, new Guid("eef752b1-dcdf-408e-a259-ccca2945fc44"), "ايوانکي", 30 },
                    { 1206, new Guid("53645056-7215-4bbf-9eeb-a72594b623fd"), "اميريه", 30 },
                    { 1221, new Guid("e5b96adb-0755-41cd-94b4-633433fdc6ab"), "کلاته", 30 },
                    { 1222, new Guid("b9cb822d-5b28-440e-a046-3d5be911f4e8"), "کلاته خيج", 30 },
                    { 1223, new Guid("b03977e5-6730-4fde-b621-2e3f42f67058"), "کهن آباد", 30 },
                    { 1224, new Guid("5ffb3c55-3e08-4640-a441-f8cfb1567a58"), "گرمسار", 30 },
                    { 1240, new Guid("054c692d-6222-4e44-8261-255d96ed865f"), "چيتاب", 31 },
                    { 1239, new Guid("513a0ed2-66c9-4ea4-8b09-8a6e79236dc0"), "چرام", 31 },
                    { 1238, new Guid("c6a19838-cc5b-4c39-beed-0c403a68dc01"), "پاتاوه", 31 },
                    { 1237, new Guid("707af2b8-a640-4f66-9057-58f5f97a7bb0"), "ياسوج", 31 },
                    { 1236, new Guid("9ce83a75-ad75-4850-b719-8c1063efe79b"), "مارگون", 31 },
                    { 1235, new Guid("3141131f-fde0-481a-ad8f-1daeb23434ea"), "مادوان", 31 },
                    { 1234, new Guid("69821472-5ea4-4293-9e15-b37318fc9543"), "ليکک", 31 },
                    { 1205, new Guid("c612a4f9-38e8-4957-a508-3b2a9f009899"), "آرادان", 30 },
                    { 1233, new Guid("3410effb-63c4-4d46-8756-0b7897f849d5"), "لنده", 31 },
                    { 1231, new Guid("e44c9ffb-4040-4b09-b868-3c6180cc8384"), "سي سخت", 31 },
                    { 1230, new Guid("43e95705-2d3b-4a41-bd83-0d73dc610767"), "سوق", 31 },
                    { 1229, new Guid("92e37d9e-06da-4574-87ee-9f81838f1978"), "سرفارياب", 31 },
                    { 1228, new Guid("512de1ac-d47e-4cee-9bd2-e99951ca46e8"), "ديشموک", 31 },
                    { 1227, new Guid("5f939fa1-0df8-4170-a28c-04c0c329bb96"), "دوگنبدان", 31 },
                    { 1226, new Guid("dc92a288-5c24-4db0-bfcb-61f5eae76ae7"), "دهدشت", 31 },
                    { 1225, new Guid("ab2c7a8b-34b1-4857-8446-839b2d1de323"), "باشت", 31 },
                    { 1232, new Guid("19975b5f-bca7-42cf-9b59-5db5026b3a67"), "قلعه رئيسي", 31 },
                    { 1204, new Guid("a8ebd302-dc90-4802-9916-f554f4ea311e"), "گنبکي", 29 },
                    { 1203, new Guid("24776496-99c4-420d-800a-14eae53eb13b"), "گلزار", 29 },
                    { 1202, new Guid("89560fe2-d072-4fec-a43e-4425d37a6550"), "گلباف", 29 },
                    { 1181, new Guid("567abe1e-a3fc-4fba-804a-b0e06a3d5d8c"), "محي آباد", 29 },
                    { 1180, new Guid("7cf87d84-ebc9-4a95-bfef-c43d60061a30"), "محمد آباد", 29 },
                    { 1179, new Guid("6a2c808e-b47c-4331-94d3-fa1e6c2b357a"), "ماهان", 29 },
                    { 1178, new Guid("9fc53d54-d1c4-4cad-81c9-c4a9fd8c7d3a"), "لاله زار", 29 },
                    { 1177, new Guid("d2a86b49-a50b-4df7-b280-8441c1953799"), "قلعه گنج", 29 },
                    { 1176, new Guid("14862aaa-8e37-471e-ba01-16c9b39a4bd6"), "فهرج", 29 },
                    { 1175, new Guid("231e2f0e-9921-4112-9de6-bb2ca64e9408"), "فارياب", 29 },
                    { 1182, new Guid("deed0d9d-3481-47eb-b2e6-e0fd02047ff1"), "مردهک", 29 },
                    { 1174, new Guid("5f6ec387-796c-4a65-aa07-13664483ccc3"), "عنبر آباد", 29 },
                    { 1172, new Guid("8ddcbd9f-cfc5-4dfa-8163-a1be6cea16d7"), "شهر بابک", 29 },
                    { 1171, new Guid("8587b1aa-7e77-4bc7-946c-51fbb9c2fa59"), "شهداد", 29 },
                    { 1170, new Guid("0b1addbc-a63b-43da-a459-276a248861c6"), "سيرجان", 29 },
                    { 1169, new Guid("98a49383-d773-4fb2-a4dc-4336c430923e"), "زيد آباد", 29 },
                    { 1168, new Guid("4b8a7d8c-b608-46a9-b7a2-b64e5100116c"), "زهکلوت", 29 },
                    { 1167, new Guid("5e661e98-0068-474e-8519-83f1c1ac651b"), "زنگي آباد", 29 },
                    { 1166, new Guid("3d73b438-bcbf-4f6d-9f20-5e9e772dac72"), "زرند", 29 },
                    { 1173, new Guid("3d791e62-d5a9-432c-bace-bf085d3c3341"), "صفائيه", 29 },
                    { 1087, new Guid("7a235de3-94cf-49e3-acec-fc65694c6cd6"), "لوندويل", 27 },
                    { 1183, new Guid("ed38f502-bbe1-4dbe-8b84-affcbc09bb3d"), "مس سرچشمه", 29 },
                    { 1185, new Guid("35f7ff42-fcde-4ea1-ab99-003fbebbf778"), "نجف شهر", 29 },
                    { 1201, new Guid("020c469f-7710-4caa-9fa3-e6e6cce43f39"), "کيانشهر", 29 },
                    { 1200, new Guid("2c2fa84f-bbce-4b35-947d-cdb9e83dcfdd"), "کوهبنان", 29 },
                    { 1199, new Guid("4fb238c9-4a08-4365-be76-bdd98ed54c82"), "کهنوج", 29 },
                    { 1198, new Guid("0d3d5f5e-9dce-4a22-9365-4daafc3af489"), "کشکوئيه", 29 },
                    { 1197, new Guid("b26de6cb-2f38-4ae3-8ade-35f993fb5b8f"), "کرمان", 29 },
                    { 1196, new Guid("6849ee09-725c-47bf-962a-bfe47d92b9d2"), "کاظم آباد", 29 },
                    { 1195, new Guid("66c7b28a-e29b-4eb8-ac5d-ce8aea75f4a4"), "چترود", 29 },
                    { 1184, new Guid("714990b9-0bf9-444b-b488-0c4646835814"), "منوجان", 29 },
                    { 1194, new Guid("dfe37a96-23a7-49c7-9d6f-3d844110bad7"), "پاريز", 29 },
                    { 1192, new Guid("c4194b2d-3dda-4230-91a9-357a8c94e940"), "هنزا", 29 },
                    { 1191, new Guid("f212b84e-c10a-47d1-baab-14c7be2f41ae"), "هماشهر", 29 },
                    { 1190, new Guid("4c2fb58c-e512-4db2-9c2a-be39c7c13358"), "هجدک", 29 },
                    { 1189, new Guid("438a1761-15c2-43ef-a2a4-5d77f5a9c736"), "نگار", 29 },
                    { 1188, new Guid("00607693-8392-496c-86cd-676d286f2c8e"), "نودژ", 29 },
                    { 1187, new Guid("c5b6205a-d63d-49f6-b588-8f26eb1c066d"), "نظام شهر", 29 },
                    { 1186, new Guid("2aac3e30-16ed-4b2a-b91e-751a19808db9"), "نرماشير", 29 },
                    { 1193, new Guid("36d900bb-d027-4f1b-8ccc-2c8befb423cd"), "يزدان شهر", 29 },
                    { 1086, new Guid("bddce003-aeb2-4cce-8c20-04a46b9b9383"), "لولمان", 27 },
                    { 1085, new Guid("61945ad1-e8b8-493c-9c30-192b3d2aea43"), "لوشان", 27 },
                    { 1084, new Guid("729b6c8f-6eb7-4ee1-872f-10ce9b46cbb3"), "لنگرود", 27 },
                    { 984, new Guid("9074f01a-5585-4472-bada-4ebfe7c8be2a"), "بندر عباس", 25 },
                    { 983, new Guid("0db4e17d-d6ea-4be1-b342-f02c40d608c2"), "بندر جاسک", 25 },
                    { 982, new Guid("c6ce826a-7f6d-46b4-8cad-690f9dfd2e92"), "بستک", 25 },
                    { 981, new Guid("df7f8c7d-4c8f-4bb4-aa9e-a8c1db7218a6"), "ابوموسي", 25 },
                    { 980, new Guid("88c5a1b4-54cc-4f07-8521-0e825f79a2c7"), "گيلانغرب", 24 },
                    { 979, new Guid("ea150e76-8424-4fe1-8186-4d313091f55a"), "گودين", 24 },
                    { 978, new Guid("602ab434-0745-4a9b-91af-887d6dc89013"), "گهواره", 24 },
                    { 977, new Guid("296e5118-54ff-4225-b693-3e053b492f45"), "کوزران", 24 },
                    { 976, new Guid("9546a653-2bfd-435f-9da7-6f9c97266188"), "کنگاور", 24 },
                    { 975, new Guid("8ebc9937-81dc-4b66-afcc-93302e21200c"), "کرند غرب", 24 },
                    { 974, new Guid("e541bde8-f9df-4fb5-94cc-d99185efe953"), "کرمانشاه", 24 },
                    { 973, new Guid("cbd84f0e-fdf7-4d2f-9205-0fcc8d055727"), "پاوه", 24 },
                    { 972, new Guid("c4500198-e9d2-45ae-84fe-b7fba2fb69b3"), "هلشي", 24 },
                    { 971, new Guid("45bc62b7-0eaf-4d0d-8405-4835ae607656"), "هرسين", 24 },
                    { 970, new Guid("67ae87e4-70d0-4247-8eea-78ee8de96d01"), "نوسود", 24 },
                    { 985, new Guid("e83b17a8-0393-40d8-bb3c-debf33bf776f"), "بندر لنگه", 25 },
                    { 986, new Guid("f88b0de1-5631-41ed-84d9-b7ee6e88b204"), "بيکاه", 25 },
                    { 987, new Guid("d2886a1a-75c8-4bdc-8e79-ece18df1d889"), "تازيان پائين", 25 },
                    { 988, new Guid("7a9231ac-83fc-4fcb-ac65-eb410b2ef82a"), "تخت", 25 },
                    { 1004, new Guid("4cad2657-b492-4c78-b9d8-cba5d6aa9957"), "فين", 25 },
                    { 1003, new Guid("b49d35ac-5eb3-4497-95eb-e87d11ac271f"), "فارغان", 25 },
                    { 1002, new Guid("8e8f000d-e2af-4b2f-b76d-61d0c1a285da"), "سيريک", 25 },
                    { 1001, new Guid("fb56ea2c-a693-4252-a05d-0194f3622a25"), "سوزا", 25 },
                    { 1000, new Guid("afbc0308-7958-41be-89e5-927116c52135"), "سندرک", 25 },
                    { 999, new Guid("ff177181-6f5e-405f-815b-19f6dc49f80f"), "سرگز", 25 },
                    { 998, new Guid("c264e191-e2f0-46a0-a86b-5a158436a68d"), "سردشت", 25 },
                    { 969, new Guid("d44b2dca-fd5a-4c66-9e1b-e3b149046b0c"), "نودشه", 24 },
                    { 997, new Guid("97fa59f8-01a6-4817-9d1a-81d4ce4d592a"), "زيارتعلي", 25 },
                    { 995, new Guid("fdfc2db3-e37d-418d-9d70-5e5e61fa403a"), "دهبارز", 25 },
                    { 994, new Guid("3ced87ea-5c97-4648-876e-90eaf35977d2"), "دشتي", 25 },
                    { 993, new Guid("39be63bb-d48b-4bc0-8df7-95638e59fe8d"), "درگهان", 25 },
                    { 992, new Guid("7fe4b69b-5fcb-4fb9-962e-66647a00e68c"), "خمير", 25 },
                    { 991, new Guid("19579538-69ee-4f6a-b71c-4459bf0eb235"), "حاجي آباد", 25 },
                    { 990, new Guid("46d815ce-5650-4543-bc6d-a9caee411c7f"), "جناح", 25 },
                    { 989, new Guid("83dfb806-4584-40c9-8efb-11e6caa6fbc5"), "تيرور", 25 },
                    { 996, new Guid("e02ecac6-dd53-4d0d-a5f0-1e529322e4c7"), "رويدر", 25 },
                    { 968, new Guid("544464af-7e78-4f18-b981-eada1451acd7"), "ميان راهان", 24 },
                    { 967, new Guid("8337bb6d-879c-44fa-8835-cb03c5a47bcc"), "قصر شيرين", 24 },
                    { 966, new Guid("0e75e9c9-d24f-4469-a34e-15b37a8ffeab"), "صحنه", 24 },
                    { 945, new Guid("0c71543d-be86-447c-a75d-03fb2a581238"), "کوهنجان", 23 },
                    { 944, new Guid("d1510c30-9258-44a4-8642-60d61b0a00aa"), "کوار", 23 },
                    { 943, new Guid("e9206391-5b30-482f-abc3-2ebc41a8d939"), "کنار تخته", 23 },
                    { 942, new Guid("e30f8711-ceae-46ad-9e24-f30c77d185b3"), "کره اي", 23 },
                    { 941, new Guid("1a00d65c-56f5-4e88-a152-25d5aa164fc3"), "کامفيروز", 23 },
                    { 940, new Guid("7f92884b-bce4-4e84-a2bd-bfacff990680"), "کازرون", 23 },
                    { 939, new Guid("2e5f02e5-1367-43f0-84ca-a483f43a9e66"), "کارزين", 23 },
                    { 946, new Guid("32c223ea-e7b3-46c2-9f7c-91feca7959d9"), "کوپن", 23 },
                    { 938, new Guid("409bc040-47f4-42fb-81d6-1a92b85e0d9e"), "وراوي", 23 },
                    { 936, new Guid("16092c90-b82f-438c-b1cb-9491bce2bdcf"), "ني ريز", 23 },
                    { 935, new Guid("21843222-873e-46f6-9594-059a7ead395e"), "نورآباد", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 934, new Guid("1b2cff64-aefe-48b9-8b83-f1e95ff98ae6"), "نودان", 23 },
                    { 933, new Guid("0f649546-986b-4801-9f6d-226eca632ae3"), "نوجين", 23 },
                    { 932, new Guid("dd413247-deb2-4e43-ac45-41b00f924be8"), "نوبندگان", 23 },
                    { 931, new Guid("3a440bd6-878e-42b5-8be8-138acb5e9933"), "ميمند", 23 },
                    { 930, new Guid("caa16b2e-f3fe-43a3-abfb-379210fce8b7"), "ميانشهر", 23 },
                    { 937, new Guid("1f3d7742-5736-4391-8e38-9ef37dc8bba5"), "هماشهر", 23 },
                    { 1005, new Guid("883cd918-ba44-4053-a92a-dae7e071d30a"), "قشم", 25 },
                    { 947, new Guid("336e34ed-c8b9-40fe-92a7-4a3b2c922137"), "گراش", 23 },
                    { 949, new Guid("5e7c1ca1-891b-4f23-b253-0b92fb59056c"), "ازگله", 24 },
                    { 965, new Guid("cd1a546b-6200-407e-a94b-76498881354a"), "شاهو", 24 },
                    { 964, new Guid("d72ca412-7187-4848-b457-d5682d141b6d"), "سومار", 24 },
                    { 963, new Guid("277a9357-ee14-489a-96e3-70c7e9eb1168"), "سنقر", 24 },
                    { 962, new Guid("5994bf2e-c88d-44ed-a7a0-7fa2a52f75d1"), "سطر", 24 },
                    { 961, new Guid("c7c435f7-7009-49fc-a2de-3c8ec5f41f92"), "سرمست", 24 },
                    { 960, new Guid("4c82e48f-179d-44ed-b338-bf5c56575976"), "سر پل ذهاب", 24 },
                    { 959, new Guid("f285b38d-fe64-470a-af39-f99054400d80"), "ريجاب", 24 },
                    { 948, new Guid("9e7c104b-3656-4618-a49a-7b0d3ca427b9"), "گله دار", 23 },
                    { 958, new Guid("bdc400ca-5b32-4c32-bad6-c62a30e8f957"), "روانسر", 24 },
                    { 956, new Guid("a0aebcc6-646c-4c00-9460-3c2d13a353b4"), "حميل", 24 },
                    { 955, new Guid("066d604d-e661-49c5-a3db-6d9e2106fa5d"), "جوانرود", 24 },
                    { 954, new Guid("584acc27-72bd-4cda-9a85-7f4d344acb12"), "تازه آباد", 24 },
                    { 953, new Guid("767f4dd4-860a-4490-a220-060f6b5306cf"), "بيستون", 24 },
                    { 952, new Guid("e5bd27b1-005d-46f0-80b3-167e4661f059"), "باينگان", 24 },
                    { 951, new Guid("419bc83d-be37-44f8-aef1-a75a89d78670"), "بانوره", 24 },
                    { 950, new Guid("67eb5880-1629-4ca1-871a-688f7cf93d60"), "اسلام آباد غرب", 24 },
                    { 957, new Guid("2211bbf9-5372-4ce5-b643-9c89ba1a8a75"), "رباط", 24 },
                    { 615, new Guid("333f1555-6a60-4772-999f-f68a6032f9ef"), "اصغرآباد", 19 },
                    { 1006, new Guid("68e66dc5-6bfb-44c8-beb7-a4390518c3bb"), "قلعه قاضي", 25 },
                    { 1008, new Guid("0b9e1851-2ada-4550-a3e9-0a5df1a9b4bb"), "ميناب", 25 },
                    { 1063, new Guid("2081ebd4-708e-4403-9676-9af989c11e16"), "جيرنده", 27 },
                    { 1062, new Guid("6b59ae2d-91c2-4761-8eb0-fa34b5354cdc"), "توتکابن", 27 },
                    { 1061, new Guid("339e4894-e1fa-487e-a1d6-a4aebc404d48"), "بندر انزلي", 27 },
                    { 1060, new Guid("c75c0523-39ae-4b9b-8b9f-13921574eaac"), "بره سر", 27 },
                    { 1059, new Guid("711f9448-51e5-4643-a695-2d42c0913971"), "بازار جمعه", 27 },
                    { 1058, new Guid("48da11a2-e06f-41a6-b2c2-e0fc6983cd54"), "املش", 27 },
                    { 1057, new Guid("426c03bb-7f31-426c-9637-24825018f9ca"), "اطاقور", 27 },
                    { 1056, new Guid("31f676de-042a-492c-af59-04fc62cb560a"), "اسالم", 27 },
                    { 1055, new Guid("169b1ec6-e099-4eb5-b262-8b590bbbf235"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("8ea12562-c0c6-4f83-8b8e-23902003a328"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("f478bcdc-c867-4b2c-bf20-bdd37d1853d1"), "آستارا", 27 },
                    { 1052, new Guid("dc5168cd-798f-4f42-b9b8-e257483bd0b4"), "کميجان", 26 },
                    { 1051, new Guid("69e06be5-6ed4-4291-8f0c-2acdb06c2240"), "کارچان", 26 },
                    { 1050, new Guid("1aadecad-e123-485d-b53b-2d6e4be10b9f"), "پرندک", 26 },
                    { 1049, new Guid("1e317768-14df-4704-8045-aafa10d6053e"), "هندودر", 26 },
                    { 1064, new Guid("39b74fa4-4a4b-4987-8797-d27b93f1622c"), "حويق", 27 },
                    { 1065, new Guid("4f8515e1-e2eb-462d-9c51-d432b9814f5e"), "خشکبيجار", 27 },
                    { 1066, new Guid("11470f42-956a-41f8-8a1c-3f50bc9e5c8e"), "خمام", 27 },
                    { 1067, new Guid("6ee39e95-d046-4775-bac5-19e8a92b4e46"), "ديلمان", 27 },
                    { 1083, new Guid("dcb02f0e-b0fe-451a-b286-5f8070a69675"), "لشت نشاء", 27 },
                    { 1082, new Guid("c70e610e-ffb6-4003-9b7b-851ee5ae1a76"), "لاهيجان", 27 },
                    { 1081, new Guid("af9b43a3-dfdd-4306-ab55-ae73d3a9afdb"), "فومن", 27 },
                    { 1080, new Guid("629b8bc5-7936-4e5e-b1f1-2d9988186b53"), "صومعه سرا", 27 },
                    { 1079, new Guid("92c568e7-5801-464f-b5c1-3752fec0f946"), "شلمان", 27 },
                    { 1078, new Guid("83141d6a-f910-4c3b-bb6e-96207941bfe9"), "شفت", 27 },
                    { 1077, new Guid("eb3e571b-7c77-47ad-9958-34f58f5029da"), "سياهکل", 27 },
                    { 1048, new Guid("5ba15990-e080-4018-9b25-0f6a5e54ff84"), "نيمور", 26 },
                    { 1076, new Guid("c2a3d525-7c59-4de9-9175-7381e10687a9"), "سنگر", 27 },
                    { 1074, new Guid("650e6398-6ce0-4540-9eda-b4f54dcfbc65"), "رودبنه", 27 },
                    { 1073, new Guid("2e3126c9-a0fd-45be-93af-fcdced39f843"), "رودبار", 27 },
                    { 1072, new Guid("746e73b1-96e8-49df-8369-8b4946a7cda4"), "رضوانشهر", 27 },
                    { 1071, new Guid("71bf7fb7-de49-400b-8858-5d82a9b0ac90"), "رشت", 27 },
                    { 1070, new Guid("b861fdd5-f121-4e53-b91a-cc9ce49c7348"), "رستم آباد", 27 },
                    { 1069, new Guid("9c5abb64-ce65-43ac-9fd1-a65b6143a39e"), "رحيم آباد", 27 },
                    { 1068, new Guid("e1d7e838-ab27-4275-be2f-ce54a294dba1"), "رانکوه", 27 },
                    { 1075, new Guid("23f3990d-3c81-4983-b840-a94a1d62fa05"), "رودسر", 27 },
                    { 1047, new Guid("1019537f-5981-481e-a926-315fa6071856"), "نوبران", 26 },
                    { 1046, new Guid("100c69c1-1771-4338-8b9e-596901b0bdb5"), "نراق", 26 },
                    { 1045, new Guid("4072ca1a-0b3d-4ba0-86ae-c8c88c89b0bf"), "ميلاجرد", 26 },
                    { 1024, new Guid("0f8d8cc7-5fb7-4fa9-9a24-2b519cdf1cd9"), "تفرش", 26 },
                    { 1023, new Guid("966a71e1-0236-4a75-b1df-af88d1bbf89d"), "اراک", 26 },
                    { 1022, new Guid("355bf01a-5568-4806-a07d-b42f7626658c"), "آوه", 26 },
                    { 1021, new Guid("d52cc43c-1e21-4b3f-b9bd-0e457d7182ca"), "آشتيان", 26 },
                    { 1020, new Guid("3b483f3f-228d-41fb-b304-1f39281ceb25"), "آستانه", 26 },
                    { 1019, new Guid("68677d0d-fac7-442e-99fe-97e2d4979f3a"), "گوهران", 25 },
                    { 1018, new Guid("bab12aa8-5f56-4ef5-be9b-80512d862363"), "گروک", 25 },
                    { 1025, new Guid("d188ff29-41b3-403c-bb9b-d6a039f71ae0"), "توره", 26 },
                    { 1017, new Guid("b349c4a7-132f-44d6-95d7-f5c3aac88468"), "کيش", 25 },
                    { 1015, new Guid("9c4a6796-34a3-4cad-bd35-64c6a18a6095"), "کوشکنار", 25 },
                    { 1014, new Guid("244da6d4-c4d3-4a4a-a015-962a9ab41248"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("fc7f7cad-e594-49e4-83bd-2daee4fa2d3b"), "کنگ", 25 },
                    { 1012, new Guid("ce9074ea-8d72-48e4-bbdf-1fa633ec2155"), "چارک", 25 },
                    { 1011, new Guid("fd10544f-52ee-4c00-b5a2-1245a72cd408"), "پارسيان", 25 },
                    { 1010, new Guid("fdaed583-6938-40b8-82c8-a97681a5c7d7"), "هشتبندي", 25 },
                    { 1009, new Guid("3c5378c4-72c8-44a1-837a-d865cbcc33b9"), "هرمز", 25 },
                    { 1016, new Guid("ae581857-78e1-4c15-98a0-c8a292616e28"), "کوهستک", 25 },
                    { 1007, new Guid("484b8d26-4d6a-4be0-84ed-043e78531f83"), "لمزان", 25 },
                    { 1026, new Guid("1b52399b-10e0-4a8a-b880-84cf785a2199"), "جاورسيان", 26 },
                    { 1028, new Guid("838e027e-d733-4d10-9d7a-c3b4f3422d7c"), "خمين", 26 },
                    { 1044, new Guid("b5428062-c514-48c7-8609-a09682a839e9"), "محلات", 26 },
                    { 1043, new Guid("e7a25491-6665-40ef-82ad-87c56c392a5a"), "مامونيه", 26 },
                    { 1042, new Guid("24554d23-ba3a-4cd8-9960-8dc6de0f06fe"), "قورچي باشي", 26 },
                    { 1041, new Guid("7d5645b7-2356-4850-8c54-a72e554e12cf"), "فرمهين", 26 },
                    { 1040, new Guid("9b9dba37-d41a-488d-8b0c-15c04390c76d"), "غرق آباد", 26 },
                    { 1039, new Guid("e2211ad8-6a9f-4b3f-bd08-e1e11a311f3f"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("46871470-9342-4a5e-9336-7c41860178ee"), "شهباز", 26 },
                    { 1027, new Guid("f78a2663-ee26-469c-b986-6c17c15ce3cf"), "خشکرود", 26 },
                    { 1037, new Guid("de9b80dc-05c1-43af-ae24-c43bca5a5962"), "شازند", 26 },
                    { 1035, new Guid("4186274c-98fa-4a84-9158-5cc728feecdb"), "ساروق", 26 },
                    { 1034, new Guid("dc0cec15-abc9-4e0e-b292-6b255799607f"), "زاويه", 26 },
                    { 1033, new Guid("82f4e97d-0158-4254-97bf-06cbe8b95b89"), "رازقان", 26 },
                    { 1032, new Guid("59dfa49e-6697-43e8-9e28-be789e9004b3"), "دليجان", 26 },
                    { 1031, new Guid("1fcf9c04-c4e2-4898-83e4-5c25a20310b4"), "داود آباد", 26 },
                    { 1030, new Guid("0f0b08d7-b203-4d4a-afd6-f5eef825dddd"), "خنداب", 26 },
                    { 1029, new Guid("8cb727a3-5305-4f18-9d86-46fbe96839a8"), "خنجين", 26 },
                    { 1036, new Guid("a6010d72-f981-4eb2-9714-b62a45082f89"), "ساوه", 26 },
                    { 614, new Guid("8269f52d-8052-467d-92c5-f5c9459204b5"), "اردستان", 19 },
                    { 613, new Guid("cdd2e34d-26ed-478c-8c79-acfa0e1ed52f"), "ابوزيد آباد", 19 },
                    { 612, new Guid("1d958603-1f68-4af9-989b-403269dc0904"), "ابريشم", 19 },
                    { 207, new Guid("b1281128-8246-4495-b81d-2031dcfd52db"), "سلامي", 8 },
                    { 206, new Guid("7565ccc7-53ae-41de-961b-7c7a8945862b"), "سفيد سنگ", 8 },
                    { 205, new Guid("303807fe-6dd1-439f-bfdb-1002e924603b"), "سرخس", 8 },
                    { 204, new Guid("366d9ff9-a63c-4dd1-b68e-36b18335e934"), "سبزوار", 8 },
                    { 203, new Guid("c1557ee8-8ae5-4b05-bb06-4db6aa311eff"), "ريوش", 8 },
                    { 202, new Guid("0c87e944-daed-41d8-bfd5-044d2204b286"), "روداب", 8 },
                    { 201, new Guid("6403880b-272f-491b-bd82-601d496ef138"), "رضويه", 8 },
                    { 200, new Guid("c7427465-d095-4b59-ad5c-57e1c080b57a"), "رشتخوار", 8 },
                    { 199, new Guid("f4e53771-e2ad-452d-9e79-b65f84f8a572"), "رباط سنگ", 8 },
                    { 198, new Guid("5614f8d2-d219-4e78-859d-dbe4dbcd4d2d"), "دولت آباد", 8 },
                    { 197, new Guid("0bd0f9ab-e178-4a1a-b5e2-918da651c5f3"), "درگز", 8 },
                    { 196, new Guid("21040abf-2913-4c64-89bf-fc8e37e69d61"), "درود", 8 },
                    { 195, new Guid("f0ee54c2-d10b-4ff5-995c-5ca25ee6a7a1"), "داورزن", 8 },
                    { 194, new Guid("f9dc7be3-d56f-4bec-8285-47b56c510703"), "خواف", 8 },
                    { 193, new Guid("6912b2f4-a109-4170-8aa4-395626199197"), "خليل آباد", 8 },
                    { 208, new Guid("065428bd-62b0-476a-b982-c94c565d93a6"), "سلطان آباد", 8 },
                    { 192, new Guid("78cc69df-6c5d-4070-9971-7b7941cfc30b"), "خرو", 8 },
                    { 209, new Guid("ddd7a3d9-79dc-4188-81ff-f8f271e9c5b5"), "سنگان", 8 },
                    { 211, new Guid("f73b657b-10e4-424b-a8dd-a168cc7c124d"), "شانديز", 8 },
                    { 226, new Guid("acdd3333-2ef3-494e-89f6-400ff5eedf87"), "لطف آباد", 8 },
                    { 225, new Guid("619ed48c-62cc-449f-81cf-d709d51c1490"), "قوچان", 8 },
                    { 224, new Guid("4d0724f6-1eb0-40ab-b270-51fd19b6b23c"), "قلندر آباد", 8 },
                    { 223, new Guid("02629daf-2a88-421b-88f9-77a5338ee511"), "قدمگاه", 8 },
                    { 222, new Guid("7c5edd59-9141-499b-bc14-653909c5e4b9"), "قاسم آباد", 8 },
                    { 221, new Guid("d34e6509-dee0-4985-bd69-9364a15dd90f"), "فيض آباد", 8 },
                    { 220, new Guid("754f5458-296b-4f94-968a-663e2c2d5f05"), "فيروزه", 8 },
                    { 219, new Guid("b7cb7105-8b9e-447c-952f-96188cdad7cb"), "فريمان", 8 },
                    { 218, new Guid("df083c90-e6ad-43ee-aae7-4e9c2de2aec9"), "فرهاد گرد", 8 },
                    { 217, new Guid("7abea791-2670-4afe-9c93-b3f79c764605"), "عشق آباد", 8 },
                    { 216, new Guid("c06c1c44-0fe9-441f-8ca0-3d51aa11ec67"), "طرقبه", 8 },
                    { 215, new Guid("e989bc03-ab01-4514-b186-acb8594d2c70"), "صالح آباد", 8 },
                    { 214, new Guid("e7990981-0c3f-4b21-96d5-627692693a75"), "شهرآباد", 8 },
                    { 213, new Guid("f96f94af-22d7-4d9c-a8a7-f22213b65bc0"), "شهر زو", 8 },
                    { 212, new Guid("ffbd5e7d-5c91-4ae7-a4b4-b4d2184a36ba"), "ششتمد", 8 },
                    { 210, new Guid("4c6ee98e-89f9-43bc-ab83-762e0e1220d1"), "شادمهر", 8 },
                    { 227, new Guid("3a426a16-f2ec-4b65-b42c-b8796ae76f43"), "مزدآوند", 8 },
                    { 191, new Guid("d6154f7e-e764-41d2-ade8-b3c2fe0599df"), "جنگل", 8 },
                    { 189, new Guid("c3ec83cd-ff3c-4c58-8a5f-d710605833cd"), "تربت حيدريه", 8 },
                    { 169, new Guid("5038a082-df20-42ab-bc81-5fda2a8f3afd"), "نازک عليا", 7 },
                    { 168, new Guid("16420b8d-42a0-45da-a2db-43121bdde824"), "ميرآباد", 7 },
                    { 167, new Guid("497c982a-8b91-43a5-9e05-544c87e6ae7d"), "مياندوآب", 7 },
                    { 166, new Guid("9aea8bdd-cb9d-4ef0-89ed-6d63b8e17ba7"), "مهاباد", 7 },
                    { 165, new Guid("730eb0a2-7682-4246-8fa7-2ebe37e0ee3c"), "مرگنلر", 7 },
                    { 164, new Guid("95831b12-6360-4b06-a788-22dd46eaae2e"), "محمود آباد", 7 },
                    { 163, new Guid("65b45861-b281-4ee0-963a-f6da337555d7"), "محمد يار", 7 },
                    { 162, new Guid("18265617-c07c-48b5-8bc3-7d51fa60c198"), "ماکو", 7 },
                    { 161, new Guid("26a18831-71dc-4520-8331-d0bbcc2bbdb7"), "قوشچي", 7 },
                    { 160, new Guid("dae6d450-6020-42b5-ac31-8bd452f2cd95"), "قطور", 7 },
                    { 159, new Guid("49dba929-9c73-4e6c-9fd6-3965b5023855"), "قره ضياء الدين", 7 },
                    { 158, new Guid("62a563e2-b526-436d-b66d-f1c36c38a1de"), "فيرورق", 7 },
                    { 157, new Guid("6bf41ff1-7967-4120-b25f-83e11d0bc72c"), "شوط", 7 },
                    { 156, new Guid("3d233ab0-6c13-40ac-af22-f8bc5c58c8c9"), "شاهين دژ", 7 },
                    { 155, new Guid("7387ed98-581f-4f09-9811-1dfb31d2ec6f"), "سيه چشمه", 7 },
                    { 170, new Guid("d96fe5c3-3ecf-456b-a0d0-8a81db73725f"), "نالوس", 7 },
                    { 190, new Guid("4ac29893-0a89-4601-b94e-576021e9735f"), "جغتاي", 8 },
                    { 171, new Guid("5ee64854-a73f-416a-bb5b-296d9499f66b"), "نقده", 7 },
                    { 173, new Guid("d1c9cde3-dc87-4204-92f7-674b4dcd5047"), "پلدشت", 7 },
                    { 188, new Guid("780692f5-c8dd-4af9-9be8-73fb1afd5bff"), "تربت جام", 8 },
                    { 187, new Guid("34c00ed6-af68-4a07-a26c-3b20984e681f"), "تايباد", 8 },
                    { 186, new Guid("024479a4-6421-4d74-96de-a509bf3439ff"), "بيدخت", 8 },
                    { 185, new Guid("371fb25f-d775-4f76-b2d1-9f82f2b99bdd"), "بردسکن", 8 },
                    { 184, new Guid("109129d2-9c53-4146-b9ab-42751f56fbda"), "بجستان", 8 },
                    { 183, new Guid("d7162fa5-ef52-4cb1-bedb-cde67046f684"), "بايک", 8 },
                    { 182, new Guid("c7382b8b-0a99-4b56-b770-73517680d3b0"), "بار", 8 },
                    { 181, new Guid("3f5090f9-f0e6-4ddd-9c8d-cef3e42ebe99"), "باخرز", 8 },
                    { 180, new Guid("b953063a-4dbf-441a-b082-1740b5047e48"), "باجگيران", 8 },
                    { 179, new Guid("ca3eaee3-8596-4ce5-a5b8-7adc9dc2b13a"), "انابد", 8 },
                    { 178, new Guid("ed808a52-5ff8-469d-99ec-3be8760e986e"), "احمدآباد صولت", 8 },
                    { 177, new Guid("783883b1-b2e4-40a5-84fb-94bcbdf12de3"), "گردکشانه", 7 },
                    { 176, new Guid("6dbbd0f2-ef23-4a3b-b9f5-b2c8998c1d90"), "کشاورز", 7 },
                    { 175, new Guid("2c2da77a-002b-4e83-bb5c-63ba5d325f84"), "چهار برج", 7 },
                    { 174, new Guid("5fd9ad3b-dfbf-4fc6-b656-2dd5c40b2263"), "پيرانشهر", 7 },
                    { 172, new Guid("19957a64-3dab-47a2-934f-14f8dcfe01c6"), "نوشين", 7 },
                    { 228, new Guid("ab2f2f4c-ac2a-4539-bad8-0df596953a85"), "مشهد", 8 },
                    { 229, new Guid("56e25b37-4108-44f1-8d52-97c1d19422fb"), "مشهدريزه", 8 },
                    { 230, new Guid("77b5b270-b70e-4582-8cb2-b6938f4d616c"), "ملک آباد", 8 },
                    { 284, new Guid("73992623-a1e7-4bcb-92ad-0e7793feb63f"), "کنارک", 9 },
                    { 283, new Guid("5c629737-687c-44df-a471-d35f32fc0df0"), "چاه بهار", 9 },
                    { 282, new Guid("d0461162-a844-4df9-9508-f1289061c550"), "پيشين", 9 },
                    { 281, new Guid("889e8a54-f586-4a71-aa31-aad05e3b80bb"), "هيدوچ", 9 },
                    { 280, new Guid("0f463c91-4d8d-482b-8790-0ef89641ed38"), "نگور", 9 },
                    { 279, new Guid("7a12bb04-a0fa-4288-b77e-570f3757f578"), "نيک شهر", 9 },
                    { 278, new Guid("b514fc78-618a-4f1c-8744-41380aefe049"), "نوک آباد", 9 },
                    { 277, new Guid("7eba6398-72cb-4173-9d4e-4f8651e9168c"), "نصرت آباد", 9 },
                    { 276, new Guid("a08a3d31-baac-4a0d-828f-28e4dd1ae531"), "ميرجاوه", 9 },
                    { 275, new Guid("005ad58e-c287-4e46-8d10-08d83ef5ac1e"), "مهرستان", 9 },
                    { 274, new Guid("a0ea3526-fc28-40ca-a850-47ff32cd2d1b"), "محمدي", 9 },
                    { 273, new Guid("5c95e960-9d08-401c-bf47-4d696e001f3b"), "محمدان", 9 },
                    { 272, new Guid("2307c49e-2715-41ba-be55-03b70e3bea75"), "محمد آباد", 9 },
                    { 271, new Guid("67292f66-ba49-42af-b68c-fcee1d4f14c1"), "قصر قند", 9 },
                    { 270, new Guid("8e45f2b3-6a40-4189-8834-a878b61b824f"), "فنوج", 9 },
                    { 285, new Guid("fbf41bcc-a0e3-4494-a7f9-624042da26b3"), "گشت", 9 },
                    { 269, new Guid("888aa1d5-a954-401f-bb8f-d8d16e5824ae"), "علي اکبر", 9 },
                    { 286, new Guid("495f3dbc-65d2-4e9e-aaf0-edc007da8f05"), "گلمورتي", 9 },
                    { 288, new Guid("cac71cdc-bcb3-47a2-8fda-f64deaf4e891"), "آيسک", 10 },
                    { 303, new Guid("fb2fe42e-ffd2-45ea-b1d5-5a22a02deb20"), "شوسف", 10 },
                    { 302, new Guid("26bf64f0-3f01-43bb-aeac-4df09b215cc9"), "سه قلعه", 10 },
                    { 301, new Guid("c5259591-d9e4-497f-b356-ac8a67165500"), "سربيشه", 10 },
                    { 300, new Guid("0b718475-15f0-4dee-942e-c0517614d3bc"), "سرايان", 10 },
                    { 299, new Guid("25439f89-abae-4f5f-a23c-dcee00e0f957"), "زهان", 10 },
                    { 1241, new Guid("7d1eb940-e1db-4485-9b85-df31ee2bdc27"), "گراب سفلي", 31 },
                    { 297, new Guid("6c606500-0f00-4905-a9e6-8992760e549b"), "خوسف", 10 },
                    { 296, new Guid("fc021b4f-5212-40ef-9ae6-49c6b522f222"), "خضري دشت بياض", 10 },
                    { 295, new Guid("7067d390-bf6d-4904-971c-e1b609e242dd"), "حاجي آباد", 10 },
                    { 294, new Guid("12699369-1f05-47e8-be20-2b8eabf844b8"), "بيرجند", 10 },
                    { 293, new Guid("8fb8a2be-86ff-46ce-8d0f-b434fcd5f459"), "بشرويه", 10 },
                    { 292, new Guid("24d244ed-c690-40ee-bd13-480c59383b25"), "اسلاميه", 10 },
                    { 291, new Guid("e06132d3-a242-4ebb-8b78-c0634194f69a"), "اسفدن", 10 },
                    { 290, new Guid("9ac1c56f-5ba9-4726-b7ca-959c095155fc"), "اسديه", 10 },
                    { 289, new Guid("25eb25f1-b530-4c55-b615-9f3f019c5566"), "ارسک", 10 },
                    { 287, new Guid("b09c2818-10dd-4ca2-b620-eb4f199cdf81"), "آرين شهر", 10 },
                    { 268, new Guid("bb96cf9b-b6cc-4fe1-bc6a-24f6070f8e07"), "سيرکان", 9 },
                    { 267, new Guid("2f1b5ee9-25e5-414a-8d56-9a61da2a7c58"), "سوران", 9 },
                    { 266, new Guid("05fb07ba-d9a9-4c06-a1a0-d4c688dd20be"), "سرباز", 9 },
                    { 245, new Guid("3313976c-7312-42a2-a5c2-6c30914ec34e"), "کدکن", 8 },
                    { 244, new Guid("c1eddade-aa2d-4a2d-b8bf-4de397993f6c"), "کاشمر", 8 },
                    { 243, new Guid("2555b1d1-b91d-408d-9d95-86020333186a"), "کاريز", 8 },
                    { 242, new Guid("aa106cac-0691-4f9f-8dc5-d2a821d21496"), "کاخک", 8 },
                    { 241, new Guid("b6464c8a-cd15-4eb8-8ade-0fe8c4648ac2"), "چکنه", 8 },
                    { 240, new Guid("ce8fc60e-ef13-4404-b6d3-e59fa980e6fc"), "چناران", 8 },
                    { 239, new Guid("dd588084-5bbf-462b-99dd-bfd4e5070c3c"), "چاپشلو", 8 },
                    { 238, new Guid("906a76a9-16d0-4c97-ab16-0ac6b4bf70ae"), "يونسي", 8 },
                    { 237, new Guid("86ad0835-90e1-4d30-9c55-8cb4f21cc7b1"), "همت آباد", 8 },
                    { 236, new Guid("0be0c3e0-c5ba-4d91-a5f2-5adb89dd3b58"), "نيل شهر", 8 },
                    { 235, new Guid("5996c0ce-cee8-45d9-a215-31d6afae6bbe"), "نيشابور", 8 },
                    { 234, new Guid("4bd2ecc6-c816-4ce4-920d-6ebd23c65273"), "نوخندان", 8 },
                    { 233, new Guid("f491f6d2-2316-4672-8564-78c442b44912"), "نقاب", 8 },
                    { 232, new Guid("962b5355-a58f-4470-8647-e788a52df004"), "نصرآباد", 8 },
                    { 231, new Guid("6405e450-1f5a-410a-858a-23ad7baf4675"), "نشتيفان", 8 },
                    { 246, new Guid("fad7db6c-3b8a-46e1-b586-201acdfffa1f"), "کلات", 8 },
                    { 247, new Guid("6dee3a07-c595-4f48-9638-1768a12b6856"), "کندر", 8 },
                    { 248, new Guid("f225a63f-3c7c-4eae-8a99-fcfcd15c1173"), "گلمکان", 8 },
                    { 249, new Guid("9a7ccc82-60bf-47a4-b8f1-a4c38411b131"), "گناباد", 8 },
                    { 265, new Guid("9627b597-8bc3-441f-95d1-ce7796521c62"), "سراوان", 9 },
                    { 264, new Guid("48af47ba-08d6-4348-bebb-9653868ad0a8"), "زهک", 9 },
                    { 263, new Guid("2d1dd5d8-183b-442b-a2e1-0f1a313d2690"), "زرآباد", 9 },
                    { 262, new Guid("fb2b826f-7bb2-4790-a49c-a4ee0b929daf"), "زاهدان", 9 },
                    { 261, new Guid("ee4cafc2-4f82-4fd5-8eca-e17c42caabf4"), "زابل", 9 },
                    { 260, new Guid("34de36eb-0eff-48d6-9a89-c5c349f39030"), "راسک", 9 },
                    { 259, new Guid("d9a63f7a-454e-4240-9fdf-92086d72d51d"), "دوست محمد", 9 },
                    { 154, new Guid("dcf9af44-1fff-440b-8a96-5ba5c7abfbd3"), "سيمينه", 7 },
                    { 258, new Guid("a07b55dd-bae7-4947-96e2-91f21f2e3d4a"), "خاش", 9 },
                    { 256, new Guid("2fa302c6-2016-41cd-a41d-b43100e55d83"), "بنجار", 9 },
                    { 255, new Guid("cb3b6c14-3bc0-4611-bf08-7669fa2f6482"), "بنت", 9 },
                    { 254, new Guid("96b9d333-c14f-4591-a8d0-82344efd619d"), "بمپور", 9 },
                    { 253, new Guid("44b5edf4-f5d4-460b-9464-64f257536917"), "بزمان", 9 },
                    { 252, new Guid("4132c05b-bdd3-4b1f-bd13-69ea7c03263e"), "ايرانشهر", 9 },
                    { 251, new Guid("750fd283-e577-47a5-9e10-e5ca771f0bfc"), "اسپکه", 9 },
                    { 250, new Guid("e9df0de9-06be-4293-b8cd-961e4cdbc464"), "اديمي", 9 },
                    { 257, new Guid("7426fb9c-3a25-4040-8bfd-0989ce6382f2"), "جالق", 9 },
                    { 153, new Guid("b218f639-1a84-4922-97e3-26d4f693ef36"), "سيلوانه", 7 },
                    { 152, new Guid("5de56990-811f-4df2-8d85-c0436665bd30"), "سلماس", 7 },
                    { 151, new Guid("e3e05451-f10b-4b5a-a855-bec93ba7419a"), "سرو", 7 },
                    { 54, new Guid("c04420b8-818e-44bf-9665-1b109c9e64bb"), "پردنجان", 2 },
                    { 53, new Guid("e9ff51cf-6b0d-4fe2-bf12-6161aaf85c3d"), "وردنجان", 2 },
                    { 52, new Guid("2e9bde75-8215-45e8-a476-6d0af4fde3ea"), "هفشجان", 2 },
                    { 51, new Guid("4d7db112-1104-40b8-a0bd-1b71aa8eef92"), "هاروني", 2 },
                    { 50, new Guid("6046560b-257a-49d8-a4ce-fb3bdd809b78"), "نقنه", 2 },
                    { 49, new Guid("cb454780-2465-4882-8acc-ba03845f151b"), "نافچ", 2 },
                    { 48, new Guid("420d86c9-cdd6-4877-adf9-054966498bec"), "ناغان", 2 },
                    { 47, new Guid("8114bf09-2ff8-4047-bccf-b578f4fb4ed2"), "منج", 2 },
                    { 46, new Guid("71a2c4aa-8b8a-4708-ab88-62ecced22e98"), "مال خليفه", 2 },
                    { 45, new Guid("eb6ab5a1-df33-469d-a7b5-3d7532b71816"), "لردگان", 2 },
                    { 44, new Guid("96f5f615-2861-4767-afac-70052e8867a9"), "فرخ شهر", 2 },
                    { 43, new Guid("747104ba-97a2-4cbf-8788-8d8f5bbf11bd"), "فرادنبه", 2 },
                    { 42, new Guid("48ac353a-bf9a-4d02-9d2b-3c2226ce551c"), "فارسان", 2 },
                    { 41, new Guid("2f23b1c7-56dd-4cd4-879f-bb951bcb3843"), "طاقانک", 2 },
                    { 40, new Guid("827ab90f-a8e5-42dc-b6d2-bc4555769826"), "صمصامي", 2 },
                    { 55, new Guid("de78b170-97ac-4b4a-83a9-0aba47f4902f"), "چليچه", 2 },
                    { 39, new Guid("7989a58c-3b84-436f-a9c9-4e54fb013165"), "شهرکرد", 2 },
                    { 56, new Guid("16fc5bbc-adee-4313-aa7b-045004299c35"), "چلگرد", 2 },
                    { 58, new Guid("d1434a6c-450e-42b6-aa54-6dccb25ff102"), "کيان", 2 },
                    { 73, new Guid("a6977389-44b8-43a2-976b-2c0780c1dfca"), "سنخواست", 3 },
                    { 72, new Guid("5af9358c-a704-40b1-bf9c-0f50abd005ad"), "زيارت", 3 },
                    { 71, new Guid("bd58f7b9-7a64-4436-8bc9-cca3c33b35c5"), "راز", 3 },
                    { 70, new Guid("31371525-ea88-49d1-81ce-b3b6b8ae39e1"), "درق", 3 },
                    { 69, new Guid("8f04b925-c29e-4f31-8a3e-68cf61e0e80b"), "حصارگرمخان", 3 },
                    { 68, new Guid("43cc5138-f8b9-403d-b3b7-d00e18699431"), "جاجرم", 3 },
                    { 67, new Guid("acf8c5c2-31b4-4f2a-a1b9-9457c6cb1d6b"), "تيتکانلو", 3 },
                    { 66, new Guid("7125f09c-3f16-4666-bff9-730934ce8e19"), "بجنورد", 3 },
                    { 65, new Guid("7a5a2f5b-039f-48a8-86bf-cb2503d9b63f"), "ايور", 3 },
                    { 64, new Guid("38e56e0d-9c83-49b9-81f9-3e5a2dfa6033"), "اسفراين", 3 },
                    { 63, new Guid("32127c31-bbb8-4045-8126-3a40b4ed2ae9"), "آوا", 3 },
                    { 62, new Guid("1d7146fc-25ea-4bc3-bb42-a9d60d92a6f8"), "آشخانه", 3 },
                    { 61, new Guid("67c87329-958f-482b-be28-a97ce9b2f9a2"), "گوجان", 2 },
                    { 60, new Guid("7f15a347-f9a9-4d7d-b194-de42089f53db"), "گهرو", 2 },
                    { 59, new Guid("19d61ac2-d9d1-48d2-b5ab-4ad0d1148113"), "گندمان", 2 },
                    { 57, new Guid("dbe48d38-5637-4c6f-85a2-e819290de1b7"), "کاج", 2 },
                    { 38, new Guid("0406b38f-bc20-4600-a0f0-3aa996dc2fbf"), "شلمزار", 2 },
                    { 37, new Guid("f01715a4-1bd5-48ca-a2c0-06d48b0ac706"), "سورشجان", 2 },
                    { 36, new Guid("a6dbb9c6-4a1f-448c-9043-fe62f882c22e"), "سودجان", 2 },
                    { 15, new Guid("186b4fcc-77b2-4469-b2b6-2b0c5593d5f3"), "مهردشت", 1 },
                    { 14, new Guid("5faee3df-a8e4-43b1-a3ab-e11abd1ada6c"), "مروست", 1 },
                    { 13, new Guid("a705f366-d1ef-4228-8640-96920def72a1"), "عقدا", 1 },
                    { 12, new Guid("1d277097-6cd0-4e62-8582-db9f19784cea"), "شاهديه", 1 },
                    { 11, new Guid("c1437ef8-20bc-4a6c-ae3a-36d3043944d4"), "زارچ", 1 },
                    { 10, new Guid("ed444d43-24ff-491d-b1b4-f8a421388d65"), "خضر آباد", 1 },
                    { 9, new Guid("54eca386-68f7-4752-bb8f-bcb8cbef2fbf"), "حميديا", 1 },
                    { 8, new Guid("bfea4f59-b3e0-434f-87d0-70aab1c8d0b2"), "تفت", 1 },
                    { 7, new Guid("7311cc4f-e8da-435d-81a3-cc6cf08b7847"), "بهاباد", 1 },
                    { 6, new Guid("c5172468-8611-4e1e-b79a-e72ac5a97b0d"), "بفروئيه", 1 },
                    { 5, new Guid("60151ef3-615e-47ef-9e6a-24cf727a751d"), "بافق", 1 },
                    { 4, new Guid("b80a1148-aad5-4931-a46b-f90018cd6095"), "اشکذر", 1 },
                    { 3, new Guid("18b71efc-e5f5-46e0-9400-49508e0d5faf"), "اردکان", 1 },
                    { 2, new Guid("249fa2f5-479e-4fa6-90d9-0b53c0d2393e"), "احمد آباد", 1 },
                    { 1, new Guid("102f0b3e-1b15-4989-9223-e0e24ac8152a"), "ابرکوه", 1 },
                    { 16, new Guid("90304689-0262-49c1-9de8-c36df6c1d086"), "مهريز", 1 },
                    { 17, new Guid("bafc8ee2-a469-4cd2-9a9c-1077537fb925"), "ميبد", 1 },
                    { 18, new Guid("d1e0b140-5dd2-4872-bcce-6c593e5fb87f"), "ندوشن", 1 },
                    { 19, new Guid("5f493cae-768e-4291-b467-5e4c5bcf6c6c"), "نير", 1 },
                    { 35, new Guid("d8f5386c-1537-4ed7-937f-0300781ce1b5"), "سفيد دشت", 2 },
                    { 34, new Guid("d5d45561-5aed-4db8-9b12-d08c58a64fa2"), "سردشت لردگان", 2 },
                    { 33, new Guid("52337171-b299-42f9-82bc-48c581bfe393"), "سرخون", 2 },
                    { 32, new Guid("78268602-97f4-4c60-ba0f-ff95dea4f71d"), "سامان", 2 },
                    { 31, new Guid("d5f87dd6-8fce-4228-927f-435b2a78178d"), "دشتک", 2 },
                    { 30, new Guid("eea10da8-b043-4f87-ae9b-092276d943ba"), "دستناء", 2 },
                    { 29, new Guid("06ce9f1c-c35b-45bc-98da-584bf13c9064"), "جونقان", 2 },
                    { 74, new Guid("59b3e7da-7900-42aa-9a1b-75a3e3ee4528"), "شوقان", 3 },
                    { 28, new Guid("9726cfc3-3440-4bfd-af8a-b6e4f65944cd"), "بن", 2 },
                    { 26, new Guid("5aaa35ef-c1ce-42b8-a702-1d4bbc47b153"), "بروجن", 2 },
                    { 25, new Guid("7af2385b-9f2b-46e7-b78f-5f25cf009423"), "بازفت", 2 },
                    { 24, new Guid("9fbf0742-d899-4bcc-9074-837d9fdbb25b"), "باباحيدر", 2 },
                    { 23, new Guid("6cf1672f-ddc3-431d-b7d6-5eec4825eaa2"), "اردل", 2 },
                    { 22, new Guid("881f83a3-db5b-4797-a6b3-fad404e9625b"), "آلوني", 2 },
                    { 21, new Guid("d3dcbda0-f994-4ccc-9c13-57cc5047af10"), "يزد", 1 },
                    { 20, new Guid("7c0400e8-53f9-46c3-976d-122fd6b9c874"), "هرات", 1 },
                    { 27, new Guid("5f63b513-f9d5-4ee9-993c-df244e282245"), "بلداجي", 2 },
                    { 304, new Guid("d83e22e4-a67f-4abc-991c-3b33fd20fda7"), "طبس", 10 },
                    { 75, new Guid("a127126d-a919-4259-a84a-decc3fdb902d"), "شيروان", 3 },
                    { 77, new Guid("228fc5de-d91f-4159-95f0-e5738a4983f0"), "فاروج", 3 },
                    { 131, new Guid("3880501d-8810-4e3a-bdc0-927311e75b34"), "پيرتاج", 6 },
                    { 130, new Guid("f9004966-a4fb-479a-8b3f-45034d36c5d0"), "ياسوکند", 6 },
                    { 129, new Guid("20328220-f1e7-4508-ba4a-730a34e62a75"), "موچش", 6 },
                    { 128, new Guid("a2934a12-96bf-4079-b6bf-0c8cbb313f03"), "مريوان", 6 },
                    { 127, new Guid("7d10b717-c476-4708-8df8-e8511d1f0700"), "قروه", 6 },
                    { 126, new Guid("ef501da9-8663-4e1e-a3b0-53273db66281"), "صاحب", 6 },
                    { 125, new Guid("cc2d9941-4da6-422e-81f6-048a1abd6cfe"), "شويشه", 6 },
                    { 124, new Guid("bd6b66ad-2ea7-43f4-a2d3-5c75bf5deb28"), "سنندج", 6 },
                    { 123, new Guid("ef6cb53e-a36b-43a8-a6f7-1122154f19e7"), "سقز", 6 },
                    { 122, new Guid("0eb7749f-a9fb-4419-9b0a-a9f6b8c8d932"), "سريش آباد", 6 },
                    { 121, new Guid("c17fc26e-c8fe-4fec-b953-c36335cb79e9"), "سرو آباد", 6 },
                    { 120, new Guid("88f62d97-4bda-4c77-b808-bfb4da48c958"), "زرينه", 6 },
                    { 119, new Guid("d259216b-ee3e-4efc-820b-b27f0b08b21a"), "ديواندره", 6 },
                    { 118, new Guid("ddae3a3c-53ba-4484-a3c5-ef143ca7c098"), "دهگلان", 6 },
                    { 117, new Guid("332754d3-0357-4e0f-a163-cdad3dee40ca"), "دلبران", 6 },
                    { 132, new Guid("fd051c95-a9d2-4a03-9d31-44e6513bbe76"), "چناره", 6 },
                    { 116, new Guid("4d8ee34d-9767-4829-bd9b-bb8e58420e39"), "دزج", 6 },
                    { 133, new Guid("5c75586b-040e-4778-857e-07139ddc0be5"), "کامياران", 6 },
                    { 135, new Guid("a60099bd-6353-4e81-886a-7f76b655c600"), "کاني سور", 6 },
                    { 150, new Guid("c15f72bd-6232-4f25-a9e1-74ff00bb6e7d"), "سردشت", 7 },
                    { 149, new Guid("60efd642-f235-45ef-9e6e-cfe1c094041f"), "زرآباد", 7 },
                    { 148, new Guid("bd3cab8f-0cb9-451e-a0ff-75bd540f32bd"), "ربط", 7 },
                    { 147, new Guid("e8b4fd67-97a4-4c54-bbaf-cde790e7015d"), "ديزج ديز", 7 },
                    { 146, new Guid("cb39ca0f-f6b6-4366-aef9-851369bb9277"), "خوي", 7 },
                    { 145, new Guid("573eec73-165d-46c3-ac5c-0f03762e6c3b"), "خليفان", 7 },
                    { 144, new Guid("be28dd6d-2432-4e41-8e56-6ddec170b88a"), "تکاب", 7 },
                    { 143, new Guid("4199052a-d1a5-4d0d-88f4-6484fb0bae46"), "تازه شهر", 7 },
                    { 142, new Guid("5eb04c4c-80e9-4a36-99cc-72599c7403df"), "بوکان", 7 },
                    { 141, new Guid("25ada8bb-eab5-46a6-8ad5-84e2dfbe9e33"), "بازرگان", 7 },
                    { 140, new Guid("91c41fb7-f68d-43c3-a009-104d20d9dc58"), "باروق", 7 },
                    { 139, new Guid("e4cc0279-d7fb-48f8-a527-5f19de3db13d"), "ايواوغلي", 7 },
                    { 138, new Guid("9cb90ac2-7f5f-40b8-8575-0329e5ebed9f"), "اشنويه", 7 },
                    { 137, new Guid("a11ffb26-aa2f-4e0d-8c28-d60eca0c39c7"), "اروميه", 7 },
                    { 136, new Guid("492a79c8-268f-40bd-b5ef-7d3af36d9d7b"), "آواجيق", 7 },
                    { 134, new Guid("953076df-1dbf-4d9b-8498-38a042e2eb89"), "کاني دينار", 6 },
                    { 115, new Guid("2af2ee1e-54fe-42b6-ad08-387aca112ccf"), "توپ آغاج", 6 },
                    { 114, new Guid("9e7225b4-8d76-4786-a3e7-7a45c47dc970"), "بيجار", 6 },
                    { 113, new Guid("056da2cb-a93e-43e2-b61e-e66c1d29c8a6"), "بوئين سفلي", 6 },
                    { 92, new Guid("b7253477-aa4c-42c9-bad7-bfcd43d21c9f"), "مشکين دشت", 4 },
                    { 91, new Guid("c93bd96d-b65c-49f2-a8d6-ccba72b4e259"), "محمد شهر", 4 },
                    { 90, new Guid("26e37f2f-3cac-4cfc-ba0a-4bcb1b287588"), "ماهدشت", 4 },
                    { 89, new Guid("8ae1843b-8210-420c-b9ec-fbd179591e47"), "فرديس", 4 },
                    { 88, new Guid("59cd2646-385e-4a94-9747-30abecacc5ee"), "طالقان", 4 },
                    { 87, new Guid("5b4630a2-9201-42c8-81f8-26b6010d2330"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("1802f09d-2354-49b2-9b40-8e44410c24d7"), "تنکمان", 4 },
                    { 85, new Guid("94779f27-8a87-4e3a-a68b-fee3863f2562"), "اشتهارد", 4 },
                    { 84, new Guid("214f06a4-6eee-4817-8eb7-1115d0f78573"), "آسارا", 4 },
                    { 83, new Guid("a8f9b5e0-028a-4ded-92a2-03703a1005b7"), "گرمه", 3 },
                    { 82, new Guid("74974723-ceb8-4e53-983b-ee40fe17d964"), "چناران شهر", 3 },
                    { 81, new Guid("742aa428-f8f0-477a-b9fc-a9a3e79a0668"), "پيش قلعه", 3 },
                    { 80, new Guid("a10de094-0e52-44bc-8a1b-fb754213bddd"), "لوجلي", 3 },
                    { 79, new Guid("6ba0b07d-ffb2-4dac-93a6-64c4b6082be7"), "قوشخانه", 3 },
                    { 78, new Guid("51a6cfd3-6816-4af4-a3a9-5e52adf14068"), "قاضي", 3 },
                    { 93, new Guid("cfdaf615-9626-482f-96de-caec07c85818"), "نظر آباد", 4 },
                    { 94, new Guid("c957c77e-931a-434b-9ea9-6b36846eacb3"), "هشتگرد", 4 },
                    { 95, new Guid("269d2513-5bfa-4a98-b92b-8cea929d88c8"), "چهارباغ", 4 },
                    { 96, new Guid("08ff9bf1-6e75-4ec1-a936-ac18f9f3ccfb"), "کرج", 4 },
                    { 112, new Guid("fb34be65-7a04-4ec8-a9e0-17396fc56ec1"), "بلبان آباد", 6 },
                    { 111, new Guid("dae5cc85-e464-42d1-8227-310510518c60"), "برده رشه", 6 },
                    { 110, new Guid("9b9576a6-23b9-4cc9-aac7-92b2b09d5565"), "بانه", 6 },
                    { 109, new Guid("6fd4a08c-bdf8-4abe-832e-9a2076ae95a5"), "بابارشاني", 6 },
                    { 108, new Guid("d2ac199c-a7f1-4f38-b4ed-22e135dcd84b"), "اورامان تخت", 6 },
                    { 107, new Guid("bcb386c6-a19a-456a-8194-01f450cac12c"), "آرمرده", 6 },
                    { 106, new Guid("08b44462-be4b-4654-8582-8c3d3f08fb8f"), "کهک", 5 },
                    { 76, new Guid("eaa052f1-e3a7-47f0-9709-f1ab2a0b9f46"), "صفي آباد", 3 },
                    { 105, new Guid("32ab65cc-107b-4eca-a667-d29d445ab56b"), "قنوات", 5 },
                    { 103, new Guid("7e8bb1de-9484-43ba-9811-5c34e85ed98e"), "سلفچگان", 5 },
                    { 102, new Guid("0f583b7f-a585-4733-bdfc-481a97478125"), "دستجرد", 5 },
                    { 101, new Guid("0fae8a91-2876-4e41-9bab-d8d710831146"), "جعفريه", 5 },
                    { 100, new Guid("a693efaa-3d97-4ad4-a4aa-cb22ecdf479f"), "گلسار", 4 },
                    { 99, new Guid("9d52af9b-e132-4c5b-ab39-3a823cadb1e1"), "گرمدره", 4 },
                    { 98, new Guid("3c4891b8-106c-4cd0-8275-2883a46c1c70"), "کوهسار", 4 },
                    { 97, new Guid("4deb1041-8e5c-4ac8-85b5-47b17d8102fd"), "کمال شهر", 4 },
                    { 104, new Guid("662a3eac-feb8-4963-8360-388ede0ae49c"), "قم", 5 },
                    { 305, new Guid("26e6760a-bfdd-43ab-a539-29586b8eb4f2"), "طبس مسينا", 10 },
                    { 298, new Guid("94f68398-d9d8-4c50-a0fd-c934b67fcdf7"), "ديهوک", 10 },
                    { 307, new Guid("b5662299-8b29-4e09-aa51-30f19642a9ae"), "فردوس", 10 },
                    { 515, new Guid("1e8bb151-04ba-403d-9566-7bd13a97fa89"), "نور", 15 },
                    { 514, new Guid("64a77e41-2cc6-4489-b07d-4356fc4c82d8"), "نشتارود", 15 },
                    { 513, new Guid("cd69a51c-deea-404a-b194-cd13805bc9df"), "مرزيکلا", 15 },
                    { 512, new Guid("e267f2bc-a6ca-4d97-8d77-366d61907b84"), "مرزن آباد", 15 },
                    { 511, new Guid("8425522f-ea02-4425-aeae-acf20e3f3a5a"), "محمود آباد", 15 },
                    { 510, new Guid("2d961b63-6d77-48d4-ad90-59654b3afbaf"), "قائم شهر", 15 },
                    { 509, new Guid("1c0ee8e3-29e1-4419-a2d5-b7b3cd8d3731"), "فريم", 15 },
                    { 508, new Guid("e27a0d35-48e8-4e2b-9d5e-5b34b2548905"), "فريدونکنار", 15 },
                    { 507, new Guid("69c4bfe1-11e8-43c8-a9eb-2767200917ca"), "عباس آباد", 15 },
                    { 506, new Guid("ff2a0e8f-34f4-4f53-9a35-926b76685f8e"), "شيرگاه", 15 },
                    { 505, new Guid("7cb6826c-a5ed-4f19-b5a8-430e2c27d455"), "شيرود", 15 },
                    { 504, new Guid("ffb0f656-522c-47ea-9f6c-ed8e9d1bdd43"), "سورک", 15 },
                    { 503, new Guid("d78c223a-ff4e-423e-925a-5c4a92d5ac19"), "سلمان شهر", 15 },
                    { 502, new Guid("07ed8142-9a8b-4006-b767-6574e6a9d014"), "سرخرود", 15 },
                    { 501, new Guid("047de612-cad7-42ce-ab1c-06351d68eb5d"), "ساري", 15 },
                    { 516, new Guid("b389bdcc-89af-4323-8d5e-ff3742435155"), "نوشهر", 15 },
                    { 500, new Guid("813f6210-faf8-428d-8ccb-c7733dbdb1ae"), "زيرآب", 15 },
                    { 517, new Guid("1602f2dc-32ca-46fb-b4a6-fc85309ca7cb"), "نکا", 15 },
                    { 519, new Guid("b9e008aa-d38c-4fc4-9fc8-3d793d2de658"), "هچيرود", 15 },
                    { 534, new Guid("eec08b6d-f6c4-4206-a663-4f7e3765d17b"), "گلوگاه", 15 },
                    { 533, new Guid("7decd74d-f5b4-4f58-adb3-4b5c73421957"), "گزنک", 15 },
                    { 532, new Guid("e227fc72-aece-4928-a822-589b1ad46eb3"), "گتاب", 15 },
                    { 531, new Guid("e06a83ac-415a-4b1c-9231-b096941ad914"), "کياکلا", 15 },
                    { 530, new Guid("7106b12d-4e7c-4636-be41-2f7a6e27f3f2"), "کياسر", 15 },
                    { 529, new Guid("cdb8bf7e-751b-4377-98ae-2c9385e90ac7"), "کوهي خيل", 15 },
                    { 528, new Guid("41846858-876b-45d2-bd61-664e5a51e5f6"), "کلاردشت", 15 },
                    { 527, new Guid("a4bb162a-6999-48eb-8ed3-dfda5f4db2bf"), "کلارآباد", 15 },
                    { 526, new Guid("ba1a956f-90bc-4d81-9103-ae58df878418"), "کجور", 15 },
                    { 525, new Guid("df7b57a1-8f86-4882-8366-6cf575d7f30b"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("1d3cdb57-c9c4-484e-99ae-326fdbb3c0dd"), "چمستان", 15 },
                    { 523, new Guid("70da5203-9238-470c-91ea-b8757c15743d"), "چالوس", 15 },
                    { 522, new Guid("0d9bfa4b-ab26-4121-a82a-4e6b4f162374"), "پول", 15 },
                    { 521, new Guid("740a64bc-eae5-446d-8fa0-2fc9f8c09865"), "پل سفيد", 15 },
                    { 520, new Guid("0b736aa5-db46-461a-9978-03f6dd2f5ffe"), "پايين هولار", 15 },
                    { 518, new Guid("fc8bc8a5-a7c1-4ed5-b957-e10d25a3be8c"), "هادي شهر", 15 },
                    { 499, new Guid("0809081a-fbc1-4a1c-ab0a-7d7fbcba10d4"), "زرگر محله", 15 },
                    { 498, new Guid("aa2fbc7d-e006-4e5b-af5e-833721a59a0f"), "رينه", 15 },
                    { 497, new Guid("35959a7e-959e-42a5-a92f-901ce9dac6bf"), "رويان", 15 },
                    { 476, new Guid("f3266b67-481f-4a66-a5e9-fba2e76bcddd"), "گميش تپه", 14 },
                    { 475, new Guid("4fce2d55-8aea-45dd-b119-1635dd143e4a"), "گرگان", 14 },
                    { 474, new Guid("84081de6-324d-4aab-963b-68ba30385ea0"), "گاليکش", 14 },
                    { 473, new Guid("06380564-8e60-4b08-b643-9bfd8e7b6db7"), "کلاله", 14 },
                    { 472, new Guid("0938cb3f-4651-4f04-9773-c90b57a3ff1b"), "کرد کوي", 14 },
                    { 471, new Guid("82ef592c-23c6-4341-b345-eb5b1813b7d0"), "نگين شهر", 14 },
                    { 470, new Guid("a21afc8a-f5c5-4db0-832e-579fa3f67a5f"), "نوکنده", 14 },
                    { 469, new Guid("a63d845a-d6d4-469c-a4c3-8ff4d6546df6"), "نوده خاندوز", 14 },
                    { 468, new Guid("b0ec746b-4281-4737-870e-38ba3c2a33e1"), "مينودشت", 14 },
                    { 306, new Guid("aa577a0e-9f0c-463e-b45a-6f4d6f5cbb65"), "عشق آباد", 10 },
                    { 466, new Guid("306cb433-1fb1-414f-ad1b-b443cc9711be"), "مراوه تپه", 14 },
                    { 465, new Guid("dbffc98f-fe82-4f45-959c-17ece6476fab"), "فراغي", 14 },
                    { 464, new Guid("77756a80-3bde-4014-ab16-39dac4d2c5de"), "فاضل آباد", 14 },
                    { 463, new Guid("6aa5e008-0576-4b60-b906-4bdba42587aa"), "علي آباد", 14 },
                    { 462, new Guid("71093228-4bca-46a7-ad71-0346eaf936fc"), "سيمين شهر", 14 },
                    { 477, new Guid("b15bfd9c-d03a-4277-aec2-a2c1339a6063"), "گنبدکاووس", 14 },
                    { 478, new Guid("63430240-3d37-4484-8749-6b29836ff75a"), "آلاشت", 15 },
                    { 479, new Guid("ea6a1ef9-a788-40a4-8c95-bebfd20abb3c"), "آمل", 15 },
                    { 480, new Guid("6de6891b-da7c-41da-9836-56a36bf031e9"), "ارطه", 15 },
                    { 496, new Guid("12a9ed3a-85a2-4a5b-9d33-00824ba2a7d2"), "رستمکلا", 15 },
                    { 495, new Guid("c4108eeb-f94e-453f-995c-d78f5e5d25cb"), "رامسر", 15 },
                    { 494, new Guid("f62439b3-421d-4ece-a127-c3a8f109ac37"), "دابودشت", 15 },
                    { 493, new Guid("3452faee-9e18-45ba-b254-3c04963d22d2"), "خوش رودپي", 15 },
                    { 492, new Guid("b6ad84d7-e8b6-4a9e-af30-aa6ded85b875"), "خليل شهر", 15 },
                    { 491, new Guid("e7dab1aa-186a-48e3-9f87-a0fc65f84cf5"), "خرم آباد", 15 },
                    { 490, new Guid("aa88643e-6ede-4f2b-a690-a29df195ad6a"), "جويبار", 15 },
                    { 535, new Guid("190ef0d3-2ccf-4acc-86a8-df611055bc32"), "آبيک", 16 },
                    { 489, new Guid("3e397c9d-bdac-4dcd-afab-2669a88188ba"), "تنکابن", 15 },
                    { 487, new Guid("1c91fcaa-9b88-4551-8b96-a92562f15256"), "بهشهر", 15 },
                    { 486, new Guid("5d094d92-4474-4835-af11-e581dbf2e3d2"), "بلده", 15 },
                    { 485, new Guid("bbc70ad9-3f5b-4aec-85e2-227b3c60aea1"), "بابلسر", 15 },
                    { 484, new Guid("0b9ffbb8-0c9e-44c6-bbbf-3b6835aeea76"), "بابل", 15 },
                    { 483, new Guid("12a79be7-27aa-4b52-b03e-47ef769a8154"), "ايزد شهر", 15 },
                    { 482, new Guid("96894f14-f002-4bb7-8203-74f5a411435c"), "امير کلا", 15 },
                    { 481, new Guid("54ab74c8-e477-434e-af06-6b37a65e6da3"), "امامزاده عبدالله", 15 },
                    { 488, new Guid("f56ea17b-6337-403a-aaab-c275e8e186f4"), "بهنمير", 15 },
                    { 461, new Guid("c4a6e461-5a17-48c2-b1a6-de72e1780d61"), "سنگدوين", 14 },
                    { 536, new Guid("f49f9654-07ab-4928-939c-0236b2cbeee5"), "آبگرم", 16 },
                    { 538, new Guid("c12c2474-b411-4764-9c56-482da739a5b4"), "ارداق", 16 },
                    { 592, new Guid("a4918c84-e3b8-4169-a282-4292491087ac"), "جعفر آباد", 18 },
                    { 591, new Guid("81fba96b-67ca-4a0a-bd55-b72835813151"), "تازه کند انگوت", 18 },
                    { 590, new Guid("d349b5ab-1bde-46fd-a2ed-3ed1960a2ec4"), "تازه کند", 18 },
                    { 589, new Guid("de4a9e58-1a01-4338-b71c-6956b1286e5d"), "بيله سوار", 18 },
                    { 588, new Guid("7d56274f-033d-4bd3-80d3-0d13ca51f1d1"), "اصلاندوز", 18 },
                    { 587, new Guid("f91ff7a2-95a0-41d0-b833-8a10042df0f1"), "اسلام آباد", 18 },
                    { 586, new Guid("b746a8fb-361c-436d-bda9-9112f2ef2fd4"), "اردبيل", 18 },
                    { 585, new Guid("05c6a8b9-5a1e-4f5e-b1ac-82e1b11078fd"), "آبي بيگلو", 18 },
                    { 584, new Guid("300f8c59-3284-46a8-9dd1-e87db583e93e"), "گراب", 17 },
                    { 583, new Guid("0858ea8a-d4fe-4774-befa-116bd5c491c6"), "کوهناني", 17 },
                    { 582, new Guid("091d2e49-7120-46e1-952e-5bb921268072"), "کوهدشت", 17 },
                    { 581, new Guid("2549a341-f302-4af3-ac7c-f1af95586ef2"), "چقابل", 17 },
                    { 580, new Guid("af90365d-8819-4ef3-9b7e-e74c4a548a06"), "چالانچولان", 17 },
                    { 579, new Guid("b30dfd96-07f2-401b-86ec-315af191a9e3"), "پلدختر", 17 },
                    { 578, new Guid("841a05e3-a6f4-4d65-8a12-5af214a35a8e"), "ويسيان", 17 },
                    { 593, new Guid("6fe690b6-f986-4a70-9b28-77e982742677"), "خلخال", 18 },
                    { 577, new Guid("f673c3fd-d1c0-4bd5-95e9-7ce0bf034ecc"), "هفت چشمه", 17 },
                    { 594, new Guid("245acea2-4370-4504-8755-43116e57ff8c"), "رضي", 18 },
                    { 596, new Guid("4fbc64f8-1842-4523-ba40-a2aed72c921b"), "عنبران", 18 },
                    { 611, new Guid("adc51e97-d464-4934-accb-ab3a968db181"), "آران و بيدگل", 19 },
                    { 610, new Guid("103e77b3-f1ee-4f59-a1eb-410181805464"), "گيوي", 18 },
                    { 609, new Guid("aa05f0d6-2429-4699-8319-cde2b7d85efa"), "گرمي", 18 },
                    { 608, new Guid("dc0fab07-47ad-4356-8cbf-a7db18659a36"), "کورائيم", 18 },
                    { 607, new Guid("a2b2071c-7615-496a-aa6f-d597a61236d4"), "کلور", 18 },
                    { 606, new Guid("a913df60-f023-4322-a802-8c404f2f17b9"), "پارس آباد", 18 },
                    { 605, new Guid("04adbe8a-4d64-4c3f-ab5a-945e6aa28b4a"), "هير", 18 },
                    { 604, new Guid("038100fe-cce1-4b18-831e-5cfc80f617fd"), "هشتجين", 18 },
                    { 603, new Guid("5f4619c4-0a13-45c7-a52a-46c397154d66"), "نير", 18 },
                    { 602, new Guid("3b519b68-8ba7-4e97-82ed-ebba9e6586ee"), "نمين", 18 },
                    { 601, new Guid("7e66a74b-535d-4728-aaa0-9160874e1506"), "مشگين شهر", 18 },
                    { 600, new Guid("7c5a99a3-8435-4d78-9239-cf7437c56c76"), "مرادلو", 18 },
                    { 599, new Guid("3b0e4e01-0ffd-45dc-a241-14ae170cc022"), "لاهرود", 18 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 598, new Guid("78376d8e-0979-4e0e-a873-85852510638b"), "قصابه", 18 },
                    { 597, new Guid("29b7362c-9536-41a2-8c57-a2e8a0dd44dc"), "فخرآباد", 18 },
                    { 595, new Guid("d45c670b-36ea-4679-8eef-37307c1da590"), "سرعين", 18 },
                    { 576, new Guid("d379f065-1d60-426a-a50d-7061da3d728f"), "نورآباد", 17 },
                    { 575, new Guid("217a3901-5e5f-4f1a-b45a-5f06e6c9f76a"), "مومن آباد", 17 },
                    { 574, new Guid("f0c04a2c-1d80-4d25-af37-398cb3c0c53c"), "معمولان", 17 },
                    { 553, new Guid("5b79002d-08eb-4f4b-9106-ddeb39d317f0"), "ضياء آباد", 16 },
                    { 552, new Guid("3fec92cf-6524-4e47-8a59-5f14b4780d81"), "شريفيه", 16 },
                    { 551, new Guid("8063c3fb-0f6a-4246-af95-a8f630b229cb"), "شال", 16 },
                    { 550, new Guid("c774fcc5-b1ac-4ac3-82f7-6aa38995d91e"), "سگز آباد", 16 },
                    { 549, new Guid("3666dc2b-c056-43e1-90c1-d14ce51de5ea"), "سيردان", 16 },
                    { 548, new Guid("1e73d523-97c6-4a62-a737-cefe2c5f10a2"), "رازميان", 16 },
                    { 547, new Guid("2363a2de-b735-4151-adb4-d075e37cf46f"), "دانسفهان", 16 },
                    { 546, new Guid("48ff5312-f5f2-46e3-bd0f-d1aedb8b9907"), "خرمدشت", 16 },
                    { 545, new Guid("5c095d82-fd83-4164-a53c-f2c7cc886d83"), "خاکعلي", 16 },
                    { 544, new Guid("eac758f6-cf93-4093-a606-26752019c0b6"), "تاکستان", 16 },
                    { 543, new Guid("ead34f49-3b59-4095-b50d-957bdcaf4139"), "بيدستان", 16 },
                    { 542, new Guid("3140b81f-fee4-4961-865f-6201fa1c608d"), "بوئين زهرا", 16 },
                    { 541, new Guid("424e5e44-cfe0-41f0-8ea8-3e271dd0eb25"), "الوند", 16 },
                    { 540, new Guid("4a0e5b95-8586-4266-aeb3-791f5bb9322f"), "اقباليه", 16 },
                    { 539, new Guid("f99e27c1-7abc-4045-9cc6-16b562bede02"), "اسفرورين", 16 },
                    { 554, new Guid("f7260627-b0b9-48ba-860e-80ab28cf6178"), "قزوين", 16 },
                    { 555, new Guid("3032e3f2-abd9-4181-8109-adbd3c2f8521"), "محمديه", 16 },
                    { 556, new Guid("c38dd561-fb2a-4108-9a79-d82e40f78a49"), "محمود آباد نمونه", 16 },
                    { 557, new Guid("c0ec4fea-be42-49c9-8b1a-1472bface2c9"), "معلم کلايه", 16 },
                    { 573, new Guid("381c480d-c385-4bdf-9e9f-e713230d6e55"), "فيروزآباد", 17 },
                    { 572, new Guid("b7021237-5f94-4dc3-b719-47f91b72abff"), "شول آباد", 17 },
                    { 571, new Guid("5d5ffcb1-e8bf-4705-a098-0ed10acf6cfd"), "سپيد دشت", 17 },
                    { 570, new Guid("b03886c0-2652-45f3-98c5-e50c89e1ce55"), "سراب دوره", 17 },
                    { 569, new Guid("4d1c51f4-7e6b-4978-ae89-9dac631e53f8"), "زاغه", 17 },
                    { 568, new Guid("3692bb53-c608-4927-8fea-4b7e19cde57d"), "دورود", 17 },
                    { 567, new Guid("7dd26c5d-338c-4636-8454-40ccaed05893"), "درب گنبد", 17 },
                    { 537, new Guid("f0ad5b89-a25d-4626-a45e-6cee11185bdf"), "آوج", 16 },
                    { 566, new Guid("4fe64116-28f6-4bf6-8ae5-ba63347f43e7"), "خرم آباد", 17 },
                    { 564, new Guid("c42d90a1-12ed-45e3-891d-a9bb4a365e15"), "بروجرد", 17 },
                    { 563, new Guid("69bd00a5-b290-440d-9440-859a3c6702e6"), "اليگودرز", 17 },
                    { 562, new Guid("25aafff4-3ea0-4f2d-9d63-b4f927b99f46"), "الشتر", 17 },
                    { 561, new Guid("0c16625d-0c2f-45ea-b2de-00cf9c9ce4f5"), "اشترينان", 17 },
                    { 560, new Guid("88d8e874-f8db-4e55-9268-441c2647f2bf"), "ازنا", 17 },
                    { 559, new Guid("8aa45d65-6ddc-488a-9420-faf291e7cb4b"), "کوهين", 16 },
                    { 558, new Guid("b9f5ea39-9e53-4564-ba12-3eb11e6c52d8"), "نرجه", 16 },
                    { 565, new Guid("c59c7fc7-3b5e-47d7-95b6-9abaed53c158"), "بيرانشهر", 17 },
                    { 460, new Guid("56a90b53-01a7-44aa-9c83-84b894ec9c3d"), "سرخنکلاته", 14 },
                    { 467, new Guid("61146864-686e-4e2f-9122-e3c53a314894"), "مزرعه", 14 },
                    { 458, new Guid("5bf58899-fd4f-49f2-8839-fca76edc23c6"), "دلند", 14 },
                    { 361, new Guid("f3f7ed3c-2068-4bf7-bc43-2aa65c6e2366"), "شوش", 11 },
                    { 360, new Guid("e2c62b49-1003-4577-acba-fc347ff600fa"), "شهر امام", 11 },
                    { 359, new Guid("fc098aa1-bc72-4459-9c11-1c23da084e54"), "شمس آباد", 11 },
                    { 358, new Guid("443ee4aa-638e-4bd3-a176-08fbdc725138"), "شرافت", 11 },
                    { 357, new Guid("ffdd227d-d4cb-4489-aa46-44d14e0976c3"), "شاوور", 11 },
                    { 356, new Guid("c6a7ddb3-8fde-48ad-99e7-0222f84fad90"), "شادگان", 11 },
                    { 355, new Guid("845e4969-23c3-4050-b557-6a54ad92e05d"), "سياه منصور", 11 },
                    { 354, new Guid("b9835d9b-463f-4c01-99af-f9e82d5d3276"), "سوسنگرد", 11 },
                    { 353, new Guid("44210945-6875-4134-9af2-5da337450194"), "سماله", 11 },
                    { 352, new Guid("8b7b97bf-fd9e-453a-83fe-fecd609c7966"), "سردشت", 11 },
                    { 351, new Guid("49677541-e6cd-4915-b9e1-88c0d553dc8f"), "سرداران", 11 },
                    { 350, new Guid("d266187a-9cd0-48a9-b32a-00cc81e8937d"), "سالند", 11 },
                    { 349, new Guid("6e44d8a3-60c9-4fbe-8c46-8da2cb932eb1"), "زهره", 11 },
                    { 348, new Guid("448c3160-ed74-46af-8d5b-4f129c614c5d"), "رفيع", 11 },
                    { 347, new Guid("4953cd63-e757-486b-8079-810e7cc38f2d"), "رامهرمز", 11 },
                    { 362, new Guid("5dc30918-136c-4b7e-9d18-f820ef2968fe"), "شوشتر", 11 },
                    { 346, new Guid("5fed3366-dd32-4cf4-8e58-b605c7b9b80c"), "رامشير", 11 },
                    { 363, new Guid("e8e9c9a8-a737-4dd9-93e2-f7e05e3a4c39"), "شيبان", 11 },
                    { 365, new Guid("d616c694-b9d3-4d0f-ae9b-8378dd370118"), "صفي آباد", 11 },
                    { 380, new Guid("a133d44b-4c90-4b51-94cd-a91e79ef8f1a"), "هنديجان", 11 },
                    { 379, new Guid("a4ffb384-125f-433a-9c50-eaefe5a17dc3"), "هفتگل", 11 },
                    { 378, new Guid("8af7966d-00c8-47ed-ae34-e790c67bb3b4"), "مينوشهر", 11 },
                    { 377, new Guid("43f474fe-9ef5-4d27-a876-fd9931e139d5"), "ميداود", 11 },
                    { 376, new Guid("7c8e3ca7-770f-4ca6-9b51-a380d50915bc"), "ميانرود", 11 },
                    { 459, new Guid("5d6650c6-81e0-4896-98e7-14c1f7c56c4f"), "راميان", 14 },
                    { 374, new Guid("5e8de061-3a53-4a4f-a918-ee5057311af3"), "ملاثاني", 11 },
                    { 373, new Guid("510f44ed-e0f3-4f5f-bf34-929c596330c6"), "مقاومت", 11 },
                    { 372, new Guid("aca86409-e477-43e3-9bbd-b1b1148682d7"), "مشراگه", 11 },
                    { 371, new Guid("292fd297-373a-49da-a3d2-a2ce1ecec6d5"), "مسجد سليمان", 11 },
                    { 370, new Guid("b3a743ab-d3f6-434d-962a-113266759696"), "لالي", 11 },
                    { 369, new Guid("f985506c-0a7f-46b6-89f4-e87c44dd9947"), "قلعه خواجه", 11 },
                    { 368, new Guid("eacefcfa-468c-4a41-89c5-ababce46133e"), "قلعه تل", 11 },
                    { 367, new Guid("a5110ce6-82f3-47f4-acd0-6e9557f72b90"), "فتح المبين", 11 },
                    { 366, new Guid("a0168921-f7a6-40a1-932d-e5e154110838"), "صيدون", 11 },
                    { 364, new Guid("553a6620-bb12-4765-aa0f-aebe26c375db"), "صالح شهر", 11 },
                    { 345, new Guid("5e67211a-312b-4949-9de6-ba656081f91d"), "دهدز", 11 },
                    { 344, new Guid("3da4f86d-8efa-49d4-9484-378d36199fc4"), "دزفول", 11 },
                    { 343, new Guid("5f0e0f54-4b0c-4720-87b4-376f0c1c24c8"), "دارخوين", 11 },
                    { 322, new Guid("133f614c-7958-4d0e-9bbe-a9dd378c4cdb"), "الوان", 11 },
                    { 321, new Guid("00e53bc1-8218-480a-bd04-7daac36fefd5"), "الهايي", 11 },
                    { 320, new Guid("9cc1aba4-6b8f-48b7-876c-0faca79657e5"), "اروند کنار", 11 },
                    { 319, new Guid("bbb726f3-d955-4b34-8a02-a934cbdd7f8d"), "ابوحميظه", 11 },
                    { 318, new Guid("f882bf1f-613a-4a90-bb35-7ba6e7b214b2"), "آغاجاري", 11 },
                    { 317, new Guid("341d661d-da77-4c74-8088-97f28c42bf64"), "آزادي", 11 },
                    { 316, new Guid("1fc6f510-140a-48f2-b705-f029c4cee493"), "آبژدان", 11 },
                    { 315, new Guid("8e13282a-6992-48d6-ae8e-04671f1496a3"), "آبادان", 11 },
                    { 314, new Guid("4c3c4047-5497-4e6a-b864-9400343fb651"), "گزيک", 10 },
                    { 313, new Guid("b21f69ee-c180-4ebc-a945-10ce5b86ee5d"), "نيمبلوک", 10 },
                    { 312, new Guid("a17fb2e6-a585-4428-a596-c7593eb9872a"), "نهبندان", 10 },
                    { 311, new Guid("b60632c1-a1f7-4162-870a-7c066f76db9c"), "مود", 10 },
                    { 310, new Guid("5702dde6-c1ee-47af-9c96-488fb97431c0"), "محمدشهر", 10 },
                    { 309, new Guid("a6fd16f9-ddf9-431d-814f-f3bea05b08ba"), "قهستان", 10 },
                    { 308, new Guid("3cc1e88e-ec3d-48ac-909d-ad3cfb34dfea"), "قائن", 10 },
                    { 323, new Guid("f46d0dae-fc2f-41fa-86be-ffe4a78c129f"), "اميديه", 11 },
                    { 324, new Guid("8e2321a9-813d-411a-ba1e-8cd1d6ca5d75"), "انديمشک", 11 },
                    { 325, new Guid("9c63dd18-4329-4fc9-b304-1868c7714fc0"), "اهواز", 11 },
                    { 326, new Guid("43b5434f-bc65-4423-8f90-b6f43fc132a5"), "ايذه", 11 },
                    { 342, new Guid("31775889-1822-48ea-85b7-1fec806d87c2"), "خنافره", 11 },
                    { 341, new Guid("b7697680-c96f-4f89-af14-9ed40738f3f9"), "خرمشهر", 11 },
                    { 340, new Guid("342cc289-41cc-412b-a105-1fd6177ed766"), "حميديه", 11 },
                    { 339, new Guid("e86ffe3c-721d-4cb4-9580-87d5f0f0b194"), "حمزه", 11 },
                    { 338, new Guid("0f9900c7-24b7-4b25-86b6-1083338210a3"), "حسينيه", 11 },
                    { 337, new Guid("a9ce4537-82fa-47b8-a88c-3c0dd6d368db"), "حر", 11 },
                    { 336, new Guid("2951d454-9ab6-4f5d-9e36-b33331505429"), "جنت مکان", 11 },
                    { 381, new Guid("9eaa41a1-4943-4af5-824d-e92f6a7547a1"), "هويزه", 11 },
                    { 335, new Guid("bf973dbd-6f62-4e37-aa43-e7a44a9a1f79"), "جايزان", 11 },
                    { 333, new Guid("6855dc5a-554e-489f-8eac-532d7acdb938"), "ترکالکي", 11 },
                    { 332, new Guid("1d3100a4-df5e-4bde-941d-1b91c536d9c8"), "بيدروبه", 11 },
                    { 331, new Guid("1c24e3b5-d745-4cb8-ba34-4e7b12ba42fa"), "بهبهان", 11 },
                    { 330, new Guid("cbae8428-6703-4882-821d-19dfa4a0fbcf"), "بندر ماهشهر", 11 },
                    { 329, new Guid("8c12abca-6bb6-41ec-bf1e-7fad3839c1a3"), "بندر امام خميني", 11 },
                    { 328, new Guid("683908ec-46b9-47d6-a062-c8ec60de5820"), "بستان", 11 },
                    { 327, new Guid("e3086ab3-4d07-45ae-a3df-cf25dfa49267"), "باغ ملک", 11 },
                    { 334, new Guid("e5ee2fd2-2cf1-4076-b740-8a1f7288e99d"), "تشان", 11 },
                    { 382, new Guid("4f7d8fb3-3ab6-4f0d-8445-0440b1418039"), "ويس", 11 },
                    { 375, new Guid("1ea7f7a4-ebd0-4591-a92b-ea852968cfc6"), "منصوريه", 11 },
                    { 384, new Guid("bbae09c0-ca9b-4012-8199-4690ac6454ba"), "چم گلک", 11 },
                    { 438, new Guid("f9c76711-84c1-40b0-8c40-da2d07f7e3f4"), "سلطانيه", 13 },
                    { 437, new Guid("c44489ee-1df8-4ce4-b775-8af21c0ff69c"), "سجاس", 13 },
                    { 436, new Guid("9b5705e8-51f3-4e18-95c4-687fcb1e7f2b"), "زنجان", 13 },
                    { 435, new Guid("fe83959d-845c-47f1-ba93-2e976cc9d17a"), "زرين رود", 13 },
                    { 434, new Guid("d08bca87-cb21-4bb4-a950-00c458deabae"), "زرين آباد", 13 },
                    { 433, new Guid("52327b2d-ec93-4795-af78-20ad3658d817"), "دندي", 13 },
                    { 432, new Guid("3d4c181c-8ce6-4907-9f27-dada1c2dbdb2"), "خرمدره", 13 },
                    { 431, new Guid("40fbcac5-d9d9-4a8d-8097-df91ff13861d"), "حلب", 13 },
                    { 430, new Guid("9905d965-c232-4d29-8494-05bc5ccf401d"), "ارمخانخانه", 13 },
                    { 383, new Guid("9bc16fe3-0c35-4c6f-90bb-31f3190ef997"), "چغاميش", 11 },
                    { 428, new Guid("ff8394fb-e041-490a-8376-adb6a8b2501d"), "آب بر", 13 },
                    { 427, new Guid("67ee6a25-7b43-4589-a63f-96361142584c"), "کلمه", 12 },
                    { 426, new Guid("eeb9ccfd-a44a-436b-a9b5-bf5721f3b014"), "کاکي", 12 },
                    { 425, new Guid("c54df592-5af8-4b09-9913-e7694d101fe2"), "چغادک", 12 },
                    { 424, new Guid("7c715d00-2cbd-4f1e-88d2-37ce49825df0"), "وحدتيه", 12 },
                    { 439, new Guid("d4e3fdc6-1f4c-449e-b72e-bdae276c125a"), "سهرورد", 13 },
                    { 423, new Guid("b38c36c4-f0fe-493e-b63c-30fa588ea319"), "نخل تقي", 12 },
                    { 440, new Guid("7b9991aa-63bf-4c56-83e2-a4b7c6176745"), "صائين قلعه", 13 },
                    { 442, new Guid("7661fed7-eb63-4adb-b9f4-5a967bed7ac6"), "ماه نشان", 13 },
                    { 457, new Guid("78a3cb4a-376b-45bf-b120-ecbe72205475"), "خان ببين", 14 },
                    { 456, new Guid("8ebdf5be-4792-47d0-b418-97f455297943"), "جلين", 14 },
                    { 455, new Guid("b1b73aba-bc5b-414a-8250-3b31eb94203e"), "تاتار عليا", 14 },
                    { 454, new Guid("2ef5b405-76df-4424-8cdc-7cbce8b5bb02"), "بندر گز", 14 },
                    { 453, new Guid("cabfbfdd-0e2e-4a42-ab7b-6571e88f59e6"), "بندر ترکمن", 14 },
                    { 452, new Guid("08446f42-fafa-4dd3-b823-c00899936365"), "اينچه برون", 14 },
                    { 451, new Guid("8c9bdac4-974a-47d1-875d-a9e6757041b3"), "انبار آلوم", 14 },
                    { 450, new Guid("fd19454c-88bc-4de5-9fa5-d87d5eb1a020"), "آق قلا", 14 },
                    { 449, new Guid("cb3c8ef7-d9a9-4c2c-bafa-02a727ac5456"), "آزاد شهر", 14 },
                    { 448, new Guid("42514bf7-194e-4a34-acef-787d52ed4fbf"), "گرماب", 13 },
                    { 447, new Guid("033ccb37-4769-4cdd-ab9f-ab469a83c855"), "کرسف", 13 },
                    { 446, new Guid("90ea9132-3189-4faf-9ae8-80b848047a52"), "چورزق", 13 },
                    { 445, new Guid("adc0e4ba-09df-4b9c-af26-abd282833fa5"), "هيدج", 13 },
                    { 444, new Guid("4ad1ba54-60e9-4005-85af-1ed501d3c885"), "نيک پي", 13 },
                    { 443, new Guid("c1b7b439-399e-434d-a0b6-e52aec943977"), "نوربهار", 13 },
                    { 441, new Guid("83c4f0fe-8927-494e-b7b8-0908d9a7a22c"), "قيدار", 13 },
                    { 422, new Guid("4f63a76c-3847-4394-998e-9cbe67ebcfcc"), "عسلويه", 12 },
                    { 429, new Guid("9a3ec2cb-2f62-44fc-bbe2-1c3428ce7cfc"), "ابهر", 13 },
                    { 420, new Guid("0b167940-53ec-429b-b697-877510e9a591"), "شبانکاره", 12 },
                    { 399, new Guid("9e4ffb37-35c7-4c65-9bbf-5501b2a4508a"), "برازجان", 12 },
                    { 398, new Guid("265f6305-6335-49b9-bdb0-b2fa99d799f2"), "بادوله", 12 },
                    { 397, new Guid("c81609b7-bb13-43a6-b21b-c15e1c9165b0"), "اهرم", 12 },
                    { 396, new Guid("f65c87b5-65ef-4320-a290-6b38ac98b0ec"), "انارستان", 12 },
                    { 395, new Guid("6d86e546-57e8-432c-8bc4-f641cff965b6"), "امام حسن", 12 },
                    { 421, new Guid("86ed3504-5dc6-4dd4-b270-a854435da558"), "شنبه", 12 },
                    { 393, new Guid("59c424e5-59b3-4170-a787-a62fe5926acf"), "آبدان", 12 },
                    { 392, new Guid("4bc25e69-a077-4591-b1fc-31cf187f1ea6"), "آباد", 12 },
                    { 391, new Guid("25bb0dc4-0f6e-4ff6-9303-247d154b2c6d"), "گوريه", 11 },
                    { 390, new Guid("e101e045-341d-402a-a5a1-e149d8d39eec"), "گلگير", 11 },
                    { 389, new Guid("9a8801b0-b96a-404f-9238-796ee431c86f"), "گتوند", 11 },
                    { 388, new Guid("736320d6-ed67-4f4f-bce1-7e3f8a961830"), "کوت عبدالله", 11 },
                    { 387, new Guid("d1cab23e-ed6f-4d39-a912-8b0857d7faaa"), "کوت سيدنعيم", 11 },
                    { 386, new Guid("916ae366-818f-4d41-9783-b057b4125820"), "چوئبده", 11 },
                    { 385, new Guid("ed0ec49e-5544-42b6-932a-5955db67e51d"), "چمران", 11 },
                    { 400, new Guid("1423d4f0-3ad4-471d-8375-158430f189ba"), "بردخون", 12 },
                    { 401, new Guid("582da34d-6289-4c17-98ca-f5b19b0be31c"), "بردستان", 12 },
                    { 394, new Guid("d8e96316-40cb-479c-a856-55da9fe6f32f"), "آبپخش", 12 },
                    { 403, new Guid("178f875b-3f16-4606-8952-bf1390513c53"), "بندر ديلم", 12 },
                    { 402, new Guid("e29bf1bf-dca4-4233-a64d-f825618d1bc8"), "بندر دير", 12 },
                    { 418, new Guid("04889b10-3163-4d06-a429-8e5d10558c35"), "سعد آباد", 12 },
                    { 417, new Guid("d4e8a481-98bf-4518-853f-9cd9fd684ace"), "ريز", 12 },
                    { 416, new Guid("95811db5-8d18-4b76-8516-02e9f08132e1"), "دوراهک", 12 },
                    { 415, new Guid("ea384b89-b961-4cbd-95a9-330efc131daf"), "دلوار", 12 },
                    { 414, new Guid("ea49fb1d-9c2b-47e7-8934-1277d7328ee6"), "دالکي", 12 },
                    { 413, new Guid("7a36da7e-41c6-4eb4-a19f-809f8734b9c5"), "خورموج", 12 },
                    { 412, new Guid("167e3589-bf38-4096-a799-69aff3dcd1e2"), "خارک", 12 },
                    { 419, new Guid("a3440917-f898-46bc-8922-a5a66cfa57fc"), "سيراف", 12 },
                    { 410, new Guid("b44455a2-2f73-41b2-94ea-26bcb66cc050"), "تنگ ارم", 12 },
                    { 409, new Guid("bb927cdc-fd60-424c-a56e-a7643a4a651c"), "بوشکان", 12 },
                    { 408, new Guid("2e96d48c-089a-49ec-ab54-349ac8e1ee96"), "بوشهر", 12 },
                    { 407, new Guid("c43d1a82-c11c-44d0-8d45-ec571f08e5b0"), "بنک", 12 },
                    { 406, new Guid("3823e08e-7200-445c-928b-36e714cab138"), "بندر گناوه", 12 },
                    { 405, new Guid("5f505f6f-1b7b-4d87-b330-d082e7566235"), "بندر کنگان", 12 },
                    { 404, new Guid("ac66a815-2b2d-4016-9878-13357f10c058"), "بندر ريگ", 12 },
                    { 411, new Guid("ac8428dc-d043-4b8f-8aee-2fe1097ecd40"), "جم", 12 }
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
                values: new object[] { 1, new DateTime(2020, 5, 27, 18, 47, 59, 548, DateTimeKind.Local).AddTicks(1254), "Kavenegar", 1, new Guid("f151ed31-c7e9-4236-8fce-82773ffc5031") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 5, new Guid("6084ba9c-1d41-4cce-bc97-dcbc174943f6"), "تاسیسات", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(490), 3, 1 },
                    { 31, new Guid("59d0a843-3f6f-4571-b4bc-c6b0c64e41c3"), "سرویس و تعمیر خودرو", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(727), 4, 3 },
                    { 30, new Guid("de6fb466-bdec-4fbd-9453-9df964340a3d"), "اجاره خودرو", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(717), 4, 2 },
                    { 29, new Guid("2e19b081-7585-46e1-aca7-bd8f20dc1042"), "اتوبار", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(707), 4, 1 },
                    { 21, new Guid("a918bd13-617c-4314-89f9-e2915263fe03"), "کار در ارتفاع", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(645), 3, 17 },
                    { 20, new Guid("6e5b3589-6161-40e5-a2cc-c425d41615c9"), "آسانسور و بالابر", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(636), 3, 16 },
                    { 19, new Guid("01836d98-0ecb-4e0e-93a8-bbfde5f65b41"), "نجاری", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(605), 3, 15 },
                    { 18, new Guid("9cfe624f-7199-428c-b01c-fc9a01d9f2fe"), "تعمیرات لوازم خانگی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(598), 3, 14 },
                    { 16, new Guid("1711980c-05d1-4129-8399-27ce4ca9daab"), "عایق کاری", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(583), 3, 12 },
                    { 15, new Guid("3e416d0f-fcab-44cd-bfa2-df4e95c9e294"), "عایق کاری", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(576), 3, 11 },
                    { 17, new Guid("b61e0a2e-6994-401f-a298-b6d5962b6eaf"), "نرده و حفاظ استیل", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(590), 3, 13 },
                    { 13, new Guid("d808aa93-b972-4c1f-a7d8-87e707d71a55"), "بنایی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(559), 3, 9 },
                    { 12, new Guid("01c82e94-4afe-4e01-a562-4979af57322d"), "دکوراسیون داخلی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(552), 3, 8 },
                    { 11, new Guid("7b8bccdd-2359-4810-99da-3fc0dc9a250b"), "کابینت سازی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(545), 3, 7 },
                    { 10, new Guid("9aa9bd95-a26e-454a-b7d7-fd923cc927e0"), "شیشه بری و قابسازی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(537), 3, 6 },
                    { 9, new Guid("e3762e43-d3ea-4aaf-a5e6-aaaf0a97196c"), "آلومینیوم سازی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(530), 3, 5 },
                    { 8, new Guid("8e04f0aa-4342-4ba5-be64-dab08d83a57a"), "مبلمان", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(523), 3, 4 },
                    { 7, new Guid("6836bbb2-2be3-4b9f-bf2f-0b0121f7c4a4"), "ایمنی و امنیت", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(515), 3, 3 },
                    { 6, new Guid("af8aedae-e5f6-4a02-9488-8f5961c25cd5"), "الکتریکی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(507), 3, 2 },
                    { 14, new Guid("0cce1b80-053d-499e-bbd1-2535e1dc3900"), "آهنگری", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(569), 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 27, 18, 47, 59, 548, DateTimeKind.Local).AddTicks(7235), "VerifyAccount", 1, new Guid("c0e83032-9bff-4c4c-b14e-4023eb76bd72") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "GenderCodeID", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 4, "white.luciferrr@gmail.com", "محمد", 8, true, true, "میرزایی", new DateTime(2020, 5, 27, 18, 47, 59, 551, DateTimeKind.Local).AddTicks(2122), "09147830093", new DateTime(2020, 5, 27, 18, 47, 59, 551, DateTimeKind.Local).AddTicks(2113), 2, new Guid("c857b70a-af45-4822-ae1a-d4cbb024f405") },
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", 8, true, true, "رودکی", new DateTime(2020, 5, 27, 18, 47, 59, 550, DateTimeKind.Local).AddTicks(8596), "09227204305", new DateTime(2020, 5, 27, 18, 47, 59, 550, DateTimeKind.Local).AddTicks(8047), 1, new Guid("e7cb0262-2a71-4302-835a-ee317b05151b") },
                    { 2, "roozbehshamekhi@hotmail.com", "روزبه", 8, true, true, "شامخی", new DateTime(2020, 5, 27, 18, 47, 59, 551, DateTimeKind.Local).AddTicks(1923), "09128277075", new DateTime(2020, 5, 27, 18, 47, 59, 551, DateTimeKind.Local).AddTicks(1880), 3, new Guid("22f4e73a-2941-46b0-9bc1-b569969d9c53") },
                    { 3, "dead.hh98@gmail.com", "حامد", 8, true, true, "حقیقیان", new DateTime(2020, 5, 27, 18, 47, 59, 551, DateTimeKind.Local).AddTicks(2092), "09108347428", new DateTime(2020, 5, 27, 18, 47, 59, 551, DateTimeKind.Local).AddTicks(2081), 2, new Guid("0b4b6ab3-9bbc-49ee-8477-3a2746af9cde") }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "AdminGUID", "IsDelete", "ModifiedDate", "UserID" },
                values: new object[] { 1, new Guid("42316767-08dc-488c-9f63-96277cb0ac44"), false, new DateTime(2020, 5, 27, 18, 47, 59, 551, DateTimeKind.Local).AddTicks(6382), 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 22, new Guid("d2b31d35-231c-4cc1-a4bf-a1d0b4f115fc"), "سرویس کولر آبی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(654), 5, 1 },
                    { 23, new Guid("2d7785d4-f6b6-4e2a-86bb-a3b6d680d816"), "نقاشی ساختمان", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(662), 5, 2 },
                    { 24, new Guid("ff380e69-5b6f-45e5-9a17-1ab1851dcb61"), "رنگ کاری مبل", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(670), 8, 1 },
                    { 25, new Guid("d5727791-f189-4674-9a24-12c5fecfa6ed"), "تعمیر صندلی اداری", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(677), 8, 2 },
                    { 26, new Guid("c1cd2afc-604b-4504-8137-fe559f200d29"), "ساخت مبلمان", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(684), 8, 3 },
                    { 27, new Guid("d07a8568-25e7-4531-87d7-68f2bfcedba3"), "دوخت کاور مبل", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(692), 8, 4 },
                    { 28, new Guid("9dd941bd-8e29-490d-ae70-a4a62937d603"), "تعمیر مبل", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(699), 8, 5 },
                    { 32, new Guid("743e9c65-f1a0-4ae3-8e4c-aec77200c8e1"), "وانت بار", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(734), 29, 1 },
                    { 33, new Guid("07233066-9772-4774-9223-4b31ad94fe75"), "باربری و اتوبار", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(741), 29, 2 },
                    { 34, new Guid("f32598a8-621a-4568-9474-f47679a5f504"), "کارگر اسباب کشی", new DateTime(2020, 5, 27, 18, 47, 59, 556, DateTimeKind.Local).AddTicks(748), 29, 3 }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "CityID", "ClientGUID", "ModifiedDate", "UserID" },
                values: new object[] { 1, 750, new Guid("0787a93b-50ff-4234-8bd4-2454d2542af3"), new DateTime(2020, 5, 27, 18, 47, 59, 552, DateTimeKind.Local).AddTicks(3184), 2 });

            migrationBuilder.InsertData(
                table: "Contractor",
                columns: new[] { "ContractorID", "BusinessTypeCodeID", "CityID", "ContractorGUID", "Credit", "Latitude", "Longitude", "ModifiedDate", "UserID" },
                values: new object[,]
                {
                    { 1, 4, 750, new Guid("18b847f8-fc5b-46cd-8583-707727a06ab8"), 0L, "1", "2", new DateTime(2020, 5, 27, 18, 47, 59, 553, DateTimeKind.Local).AddTicks(4357), 3 },
                    { 2, 4, 750, new Guid("0b69061c-9a66-4465-be40-8856eb67e75e"), 10000L, "1", "2", new DateTime(2020, 5, 27, 18, 47, 59, 553, DateTimeKind.Local).AddTicks(5208), 4 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderID", "CategoryID", "ClientID", "ContractorID", "DeadlineDate", "Description", "ModifiedDate", "OrderGUID", "StateCodeID", "Title" },
                values: new object[] { 1, 14, 1, null, null, "توضیح", new DateTime(2020, 5, 27, 18, 47, 59, 554, DateTimeKind.Local).AddTicks(948), new Guid("ebfd0049-a56a-484a-bf61-69f51e0f0314"), 9, "تیتر" });

            migrationBuilder.InsertData(
                table: "OrderRequest",
                columns: new[] { "OrderRequestID", "ContractorID", "IsAccept", "Message", "ModifiedDate", "OfferedPrice", "OrderID", "OrderRequestGUID" },
                values: new object[] { 1, 1, true, "پیام", new DateTime(2020, 5, 27, 18, 47, 59, 554, DateTimeKind.Local).AddTicks(8155), 250000L, 1, new Guid("6cd8c548-ed5e-49a4-b559-7a72a672c431") });

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
