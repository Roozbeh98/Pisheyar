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
                    GenderCodeID = table.Column<int>(nullable: false),
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
                    { 1, new Guid("607b839e-0bce-440e-9525-61d531e1c476"), "سایت اصلی", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(5372), null, 1 },
                    { 10, new Guid("ea75b502-cdb7-45d7-9362-7c8bdb8d1a7c"), "وبلاگ", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6604), null, 2 }
                });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "CodeGroupID", "CodeGroupGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("271f107f-a2cf-4a3c-8e41-111b443c44d0"), "نوع فایل", "FilepondType" },
                    { 2, new Guid("2d9c9e83-39eb-42d7-b71f-ef26002c8470"), "نوع کسب و کار", "BusinessType" },
                    { 3, new Guid("a76da3ba-d12a-42c4-b7e1-732d0990af70"), "جنسیت", "Gender" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("afc91d52-0e19-4412-8dd5-8968d569791e") },
                    { 20, "ايلام", new Guid("f0f250a6-f8ad-4dc7-86f0-732bf8871616") },
                    { 21, "تهران", new Guid("8927d6bf-9783-46fb-a20d-020695bd37fa") },
                    { 22, "آذربايجان شرقي", new Guid("9d81ce70-8c08-4ee0-9d38-74acc03bacbb") },
                    { 23, "فارس", new Guid("9cdb902a-6bdc-48ea-a030-29694243002f") },
                    { 24, "کرمانشاه", new Guid("2c4fee1c-265e-464f-a94d-08cccb4ff813") },
                    { 27, "گيلان", new Guid("f0ff0359-c004-43a3-bb1f-7bdb780c12ed") },
                    { 26, "مرکزي", new Guid("01d2e69e-9430-43c7-a099-68c20134875e") },
                    { 18, "اردبيل", new Guid("84a1cadb-3b67-430e-9348-b725cca52914") },
                    { 28, "همدان", new Guid("d56ed64d-04cc-45c7-bde0-3b56cee35ef0") },
                    { 29, "کرمان", new Guid("953d977e-f892-4254-8e98-de7b0ad4ce80") },
                    { 30, "سمنان", new Guid("f99bdbf7-78ff-494b-8fb0-05e32a40ba3b") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("e2dd228a-79ca-4e3e-bb25-578061716c2d") },
                    { 25, "هرمزگان", new Guid("3dfa0f81-3b9f-40f9-96aa-2cea8f09ad54") },
                    { 17, "لرستان", new Guid("39e1589c-3544-4c62-b209-5e5a42cc5cb0") },
                    { 15, "مازندران", new Guid("caadbf9e-5f2f-4de2-8d78-9d85dfd8da61") },
                    { 6, "کردستان", new Guid("1878be19-6f51-466d-bda6-822eaa6259b3") },
                    { 14, "گلستان", new Guid("5f2af818-041f-4a6b-8ceb-a2b9e5914e64") },
                    { 13, "زنجان", new Guid("d2b14078-58d3-4384-8ff3-7798c67a128c") },
                    { 12, "بوشهر", new Guid("4bbc3500-ad6e-46ec-894f-bc6e7eb8a397") },
                    { 11, "خوزستان", new Guid("18053a16-03bb-4687-9b6b-4b23cf160904") },
                    { 10, "خراسان جنوبي", new Guid("02f3af12-26e2-451a-b4a9-8dbecd8f7820") },
                    { 9, "سيستان و بلوچستان", new Guid("2a6d7416-d20b-48b2-b321-953600e0081f") },
                    { 8, "خراسان رضوي", new Guid("5c04e159-7c03-4441-ac9c-d63235984e3b") },
                    { 7, "آذربايجان غربي", new Guid("3bc22ccc-2740-42a3-9960-820139d3b6e7") },
                    { 16, "قزوين", new Guid("43ad83f5-7915-4d9f-95e8-fbbdc151fc2d") },
                    { 5, "قم", new Guid("5e4f8cb5-ffb2-40da-b119-2114bb81bc5f") },
                    { 4, "البرز", new Guid("8985f54f-9a01-4f63-b1f0-9cb7c9015e13") },
                    { 3, "خراسان شمالي", new Guid("65e46373-a071-4237-be7f-84fb77928f04") },
                    { 2, "چهار محال و بختياري", new Guid("bfecafa1-deec-4bd5-abd0-beda469b100b") },
                    { 1, "يزد", new Guid("d23f0241-ffe6-4550-be98-64dcb88e8ebc") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 2, "سرویس دهنده", new DateTime(2020, 5, 10, 23, 58, 47, 627, DateTimeKind.Local).AddTicks(8559), "Contractor", new Guid("67a3360e-eec8-4988-99a8-72ec5b6e0b2b") },
                    { 3, "سرویس گیرنده", new DateTime(2020, 5, 10, 23, 58, 47, 627, DateTimeKind.Local).AddTicks(8593), "Client", new Guid("81b8a987-bece-4686-9803-c43044a2ff78") },
                    { 1, "ادمین", new DateTime(2020, 5, 10, 23, 58, 47, 627, DateTimeKind.Local).AddTicks(7371), "Admin", new Guid("c06618bb-e0d9-4938-b72b-5aa9235cecab") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 5, 10, 23, 58, 47, 622, DateTimeKind.Local).AddTicks(8256), "ptcoptco", new Guid("50552491-f0f7-4dee-9a6d-08cdc8fd5e44"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 2, new Guid("c299365a-a2e3-49dd-b533-e695562ed792"), "ابزار و لوازم صنعتی", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6499), 1, 1 },
                    { 3, new Guid("e44af0c7-16e9-4c6d-a3fc-0c7be8ef7866"), "مصنوعات صنعتی", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6536), 1, 2 },
                    { 4, new Guid("cfeb5ca0-493e-455a-b643-f0ae17783b9e"), "کالا و خدمات صنعتی", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6546), 1, 3 },
                    { 5, new Guid("58593c44-c29a-4c03-aa63-0890b652361e"), "مواد شیمیایی", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6554), 1, 4 },
                    { 6, new Guid("b460dc7f-6e31-48a4-afa6-4289a0da106a"), "دستگاه و ماشین آلات", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6562), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 829, new Guid("c76d9404-7551-449d-aa92-caa97fdca4be"), "مرند", 22 },
                    { 828, new Guid("ba37826e-9b16-4c04-875e-ac1168c6fd42"), "مراغه", 22 },
                    { 827, new Guid("93068661-a56c-4a87-a03b-bc0cf1b78ba2"), "مبارک شهر", 22 },
                    { 826, new Guid("6c36d626-e9dd-4165-964f-b1717d53af46"), "ليلان", 22 },
                    { 825, new Guid("968fc1bf-9909-43ed-9874-6f4cabb519a4"), "قره آغاج", 22 },
                    { 824, new Guid("f446a82b-82d2-4568-9a2c-5c5b6dbeb913"), "عجب شير", 22 },
                    { 823, new Guid("c1366a79-bdfb-412f-8b31-80b23727388d"), "صوفيان", 22 },
                    { 820, new Guid("16f39801-1348-4145-9208-eaa2a176a8f0"), "شرفخانه", 22 },
                    { 821, new Guid("b3ad5261-ddef-49ff-98b0-3c76a1349861"), "شند آباد", 22 },
                    { 830, new Guid("fc867669-6464-4453-95f8-935bcd0c1a84"), "ملکان", 22 },
                    { 819, new Guid("acfdb4e2-8069-4419-92ed-7e2b45ed563f"), "شربيان", 22 },
                    { 818, new Guid("f7e232fb-c6de-4fd1-a7c0-ffa4a37a2332"), "شبستر", 22 },
                    { 817, new Guid("10b7dfe4-a755-405f-a3ba-3ba2dbdb8372"), "سيه رود", 22 },
                    { 816, new Guid("391efdde-373b-4230-a7a3-728d62718fd7"), "سيس", 22 },
                    { 815, new Guid("20554f28-937b-4e87-bd7b-02eeeaf58be8"), "سردرود", 22 },
                    { 822, new Guid("fa5cabb2-5146-4535-bd98-faefe2a57913"), "شهر جديد سهند", 22 },
                    { 831, new Guid("3ee7c2fe-c9a4-4c48-821c-e05ab1c80e98"), "ممقان", 22 },
                    { 834, new Guid("b838dcb1-59f7-438b-90c5-48ed9a42cd7d"), "نظرکهريزي", 22 },
                    { 833, new Guid("8e2bc0b1-249b-46d2-8c7c-3a9528fe21dc"), "ميانه", 22 },
                    { 849, new Guid("99a3a6cf-a842-4626-800a-2e90038d80ba"), "اردکان", 23 },
                    { 848, new Guid("484bd542-5139-48cb-84e8-bd9fcc6b89f1"), "آباده طشک", 23 },
                    { 847, new Guid("ad86e368-a035-4b00-95d8-a629a85609c2"), "آباده", 23 },
                    { 846, new Guid("94912548-1a7d-4fc6-99c1-324490308e31"), "گوگان", 22 },
                    { 845, new Guid("2a8eb929-126e-432b-a210-7aa39a655cd0"), "کوزه کنان", 22 },
                    { 844, new Guid("397013db-c197-4dc8-83e5-4efa5f05aa3d"), "کليبر", 22 },
                    { 843, new Guid("09fa2736-2963-4791-94ef-99de475f1fbf"), "کلوانق", 22 },
                    { 832, new Guid("61e6e90b-1e1f-434d-b55d-02bc9648bfea"), "مهربان", 22 },
                    { 842, new Guid("e0cec5f7-8710-4356-9609-f5fbcb0673c8"), "کشکسراي", 22 },
                    { 840, new Guid("25d624a0-5c4f-49f1-9dc9-330bd97ca4fd"), "ورزقان", 22 },
                    { 839, new Guid("7b8b3543-e8d1-46ae-a051-024403c4a5a5"), "وايقان", 22 },
                    { 838, new Guid("a44a1d4e-61e7-43d7-96fb-645c99ec8479"), "هوراند", 22 },
                    { 837, new Guid("07825269-998c-463e-9e0f-313dbc3a6d84"), "هشترود", 22 },
                    { 836, new Guid("f1fb0e99-597d-43a2-8e3c-341b3f1d1196"), "هريس", 22 },
                    { 835, new Guid("ba09f9e0-9d27-487e-8ff5-10daa1c2b382"), "هاديشهر", 22 },
                    { 814, new Guid("8466b017-5296-4b4d-95dc-f44e2825ed4f"), "سراب", 22 },
                    { 841, new Guid("7dd068ab-9d20-4053-8aa1-ff22ae5ecd00"), "يامچي", 22 },
                    { 813, new Guid("e08c4b3f-ebed-4fff-a647-d87fc9bc4f2f"), "زنوز", 22 },
                    { 811, new Guid("29d1586d-9c4e-4eeb-a4fa-baf426150f9f"), "دوزدوزان", 22 },
                    { 850, new Guid("27a34bc1-dc0f-4e5d-85ea-34d45ade0d39"), "ارسنجان", 23 },
                    { 790, new Guid("a0bfe179-d6e1-4429-a7c9-cb0d055efbd7"), "اهر", 22 },
                    { 789, new Guid("c1a9c686-431d-49cb-8504-38a4539ba25f"), "اسکو", 22 },
                    { 788, new Guid("793d9ac9-945d-44e2-89a7-04cd1ecea97a"), "آچاچي", 22 },
                    { 787, new Guid("5d17d764-1d6e-45f9-a6b1-417e46654936"), "آقکند", 22 },
                    { 786, new Guid("70a27a8e-1538-4ee1-ae84-846060018cc3"), "آذرشهر", 22 },
                    { 785, new Guid("acbb64dc-22f8-4dd0-b386-117c36bb9d2b"), "آبش احمد", 22 },
                    { 784, new Guid("ff87971e-d7a3-4351-9be0-38181e37db55"), "گلستان", 21 },
                    { 783, new Guid("d21bd2c6-c5c0-42bc-a698-bc24277fe161"), "کيلان", 21 },
                    { 782, new Guid("1d88c455-c2cc-420d-83b9-2a1ee569bb75"), "کهريزک", 21 },
                    { 781, new Guid("fb7d6cd3-4722-40cc-89ad-9e323bde4f6a"), "چهاردانگه", 21 },
                    { 780, new Guid("481f754a-e99f-4714-a645-0471aeceddeb"), "پيشوا", 21 },
                    { 779, new Guid("5fc3520b-312c-4822-8837-2499a07c03af"), "پرديس", 21 },
                    { 778, new Guid("3003013b-ec3d-44b4-a2c9-cbeb44012015"), "پاکدشت", 21 },
                    { 777, new Guid("c0106a4d-5598-44a8-88eb-d4fa0d8a6603"), "ورامين", 21 },
                    { 776, new Guid("d7edea6d-029f-4ead-989f-4a750e4fb45b"), "وحيديه", 21 },
                    { 791, new Guid("876d9382-e4d3-498d-af29-36e60b386479"), "ايلخچي", 22 },
                    { 792, new Guid("753fd497-2656-4a85-ae55-7e13cf685c03"), "باسمنج", 22 },
                    { 793, new Guid("6d34ef39-47aa-4655-8041-5ea33810727d"), "بخشايش", 22 },
                    { 794, new Guid("ef04e057-0784-41cf-a6f9-7e0204cdc54f"), "بستان آباد", 22 },
                    { 810, new Guid("9a132c42-4ae6-43f3-a47e-146496aecf55"), "خواجه", 22 },
                    { 809, new Guid("9a6b2226-97d9-4111-81cd-fbefdc12ae7e"), "خمارلو", 22 },
                    { 808, new Guid("20729a3d-556e-44f5-a727-080f18e0fa9a"), "خسروشاه", 22 },
                    { 807, new Guid("e08acd5f-3911-4082-920d-7e4bc4b8600c"), "خداجو", 22 },
                    { 806, new Guid("0508fd90-b269-47d1-8814-369243bf6dea"), "خامنه", 22 },
                    { 805, new Guid("57b56c5d-5ad0-4b3e-9d28-32ef254ceb77"), "خاروانا", 22 },
                    { 804, new Guid("5775bebe-f6e9-4919-ba4a-720989ae32f5"), "جوان قلعه", 22 },
                    { 812, new Guid("62dc7493-a5bc-406c-9108-695ab457736c"), "زرنق", 22 },
                    { 803, new Guid("cb3b776d-3076-46a8-bc36-9be296b1458c"), "جلفا", 22 },
                    { 801, new Guid("32df2451-e707-4a12-b266-8d45b3ffde7b"), "تيمورلو", 22 },
                    { 800, new Guid("e988e218-70f8-423d-8f4d-848304716f40"), "تسوج", 22 },
                    { 799, new Guid("cd3e3980-3b53-45f7-9db0-2555a1d94d51"), "ترکمانچاي", 22 },
                    { 798, new Guid("8f2989e0-da53-4f71-99b3-1b80c1dc3290"), "ترک", 22 },
                    { 797, new Guid("d9612feb-b587-4039-b8af-e2c251508115"), "تبريز", 22 },
                    { 796, new Guid("7fa1ebbb-5e9d-4611-9cbb-6e05e2879f5c"), "بناب مرند", 22 },
                    { 795, new Guid("f2c4ee69-132e-4e62-9133-e8008a69cef5"), "بناب", 22 },
                    { 802, new Guid("6aeee071-11d0-4ef2-a005-254f8c01dba7"), "تيکمه داش", 22 },
                    { 851, new Guid("657c1998-2205-4e1b-b93c-057907d417eb"), "استهبان", 23 },
                    { 853, new Guid("dafedb65-a3c5-4a6a-9207-b27c9269f772"), "اشکنان", 23 },
                    { 775, new Guid("01040e89-238a-4543-bcbd-63c9f4970491"), "نصيرشهر", 21 },
                    { 907, new Guid("83d7abc0-29da-4436-8219-810cfaf7919c"), "علامرودشت", 23 },
                    { 906, new Guid("a543f0f1-a24b-4e18-ab34-f372cf4c3dc5"), "صفا شهر", 23 },
                    { 905, new Guid("ceb92977-e98e-4f15-bf4b-eb7d7c957af1"), "صغاد", 23 },
                    { 904, new Guid("7cbae18d-ee7e-458a-92b1-62d5fade6c72"), "شيراز", 23 },
                    { 903, new Guid("fd670f71-feef-4b56-97d4-0fea2c4fb966"), "شهر پير", 23 },
                    { 902, new Guid("0bb9c45c-da2d-43a0-a039-68e761cf819f"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("d325e0bd-71e3-46d3-9a39-58111b24eb1d"), "ششده", 23 },
                    { 900, new Guid("ad4dc31a-55a6-46e3-9dab-5c97dbc1ff4d"), "سيدان", 23 },
                    { 899, new Guid("beb9b312-a409-4be8-a6d7-6afa0fc1397d"), "سورمق", 23 },
                    { 898, new Guid("0eb4b493-7e37-43d4-be56-50e58a527821"), "سلطان شهر", 23 },
                    { 897, new Guid("a2542773-f454-4eec-be29-896aa8184ce2"), "سعادت شهر", 23 },
                    { 896, new Guid("ec28a328-7fda-442b-9698-921f2c477272"), "سروستان", 23 },
                    { 895, new Guid("35133f10-a5f3-4910-b596-d78d9f9b0017"), "سده", 23 },
                    { 894, new Guid("8810d591-7e0a-4e84-a585-ae79904815fd"), "زرقان", 23 },
                    { 893, new Guid("543362ea-afa4-4dc6-8382-3ac5424165ff"), "زاهد شهر", 23 },
                    { 908, new Guid("fda8e275-65e3-421b-b682-2be15a7adc24"), "عماد ده", 23 },
                    { 909, new Guid("28e4ff52-bcfb-43e0-a0be-56ee9008098d"), "فدامي", 23 },
                    { 910, new Guid("c945ec6c-092c-4a34-80c2-6e71664cb1a7"), "فراشبند", 23 },
                    { 911, new Guid("4286715e-5cde-416d-a469-ba98b6af155c"), "فسا", 23 },
                    { 927, new Guid("b29f2d73-5dcd-4a7f-b865-973c781f7e19"), "مشکان", 23 },
                    { 926, new Guid("80f8bd62-0217-4d24-9876-10f63661a3cb"), "مزايجان", 23 },
                    { 925, new Guid("7f5fdeb7-032b-439a-8932-98cff446d942"), "مرودشت", 23 },
                    { 924, new Guid("60e6b803-9ec5-4975-94ed-4d68e5c7306f"), "مبارک آباد", 23 },
                    { 923, new Guid("0f4c3fc8-9d14-4a38-a491-a3a202652337"), "مادرسليمان", 23 },
                    { 922, new Guid("de1002bc-f060-4024-8234-42191b2644c4"), "لپوئي", 23 },
                    { 921, new Guid("08ef9408-4613-48eb-94ab-441ef49836be"), "لطيفي", 23 },
                    { 892, new Guid("4f53f752-2e45-4bca-b73a-7e6ef9180045"), "رونيز", 23 },
                    { 920, new Guid("16673ebb-583c-477e-8135-aecc09df160a"), "لامرد", 23 },
                    { 918, new Guid("d1853085-3573-4fba-923c-79a2e0ac225e"), "قير", 23 },
                    { 917, new Guid("6851ada2-2fa5-41a7-a6cc-c5d659de519e"), "قطرويه", 23 },
                    { 916, new Guid("69134a1b-b362-4f4c-8ee5-f51707504249"), "قطب آباد", 23 },
                    { 915, new Guid("2554fd9b-1bc2-4a59-9ae5-4854bf5d2823"), "قره بلاغ", 23 },
                    { 914, new Guid("32287da9-e52c-49c6-bdf9-a675e504fdfc"), "قادرآباد", 23 },
                    { 913, new Guid("9e0b0a4c-03e5-4b1e-962e-d1bee28ad3e5"), "قائميه", 23 },
                    { 912, new Guid("4c4b6f33-a4e7-4a72-8eee-77f354f14f4d"), "فيروزآباد", 23 },
                    { 919, new Guid("8d07b541-8b6e-4204-b676-28e7df68518f"), "لار", 23 },
                    { 852, new Guid("30b1b01c-e577-4c21-bc1f-5d382b8d18ec"), "اسير", 23 },
                    { 891, new Guid("d23d3f07-446d-4ccc-ba5a-e1e15a9dca35"), "رامجرد", 23 },
                    { 889, new Guid("0e6d0094-dee0-4813-ba01-7197d0e19e48"), "دوزه", 23 },
                    { 868, new Guid("2596b067-364b-4063-a670-a67ff32d8028"), "بيضا", 23 },
                    { 867, new Guid("6b8d6289-2b07-418c-a7f5-82647993b1d2"), "بيرم", 23 },
                    { 866, new Guid("1beb3d5d-9514-4e03-ae69-4375c3f0bc92"), "بوانات", 23 },
                    { 865, new Guid("9d9eacda-67f6-4f78-960a-954289de3fb6"), "بهمن", 23 },
                    { 864, new Guid("99db9eb3-2477-45e2-9e2c-f3e342b01a00"), "بنارويه", 23 },
                    { 863, new Guid("4743b140-b928-400d-82e6-a5b734e045ed"), "بالاده", 23 },
                    { 862, new Guid("5880a4b4-5b57-40b2-b72a-655a4f3a80cf"), "بابامنير", 23 },
                    { 861, new Guid("cb5d3b09-d942-4af5-84f8-c76ec1289839"), "باب انار", 23 },
                    { 860, new Guid("6e6574fd-7d50-42c1-b314-6202bb43f2de"), "ايزد خواست", 23 },
                    { 859, new Guid("5d14f478-d38b-4af9-a9f2-c429ff22e75d"), "ايج", 23 },
                    { 858, new Guid("9300f29f-bf1f-4027-9b57-ecb9f1e9cc51"), "اوز", 23 },
                    { 857, new Guid("cc80de7f-d2d1-4a69-9df4-c6c85ab22cf3"), "اهل", 23 },
                    { 856, new Guid("c25e3896-bbca-47e8-8e64-01bc06c5f61f"), "امام شهر", 23 },
                    { 855, new Guid("782d2316-a6a2-4526-85d9-bf0edbc63248"), "اقليد", 23 },
                    { 854, new Guid("d6b0ab83-a355-4589-b80c-981b251c38f1"), "افزر", 23 },
                    { 869, new Guid("efc3fed9-efc1-465d-9f1e-30dc54d04b1e"), "جنت شهر", 23 },
                    { 870, new Guid("e6959303-6b2f-4b70-a88b-650e8745de93"), "جهرم", 23 },
                    { 871, new Guid("f7ae370e-50a4-49eb-8cc2-5f1a26726a7c"), "جويم", 23 },
                    { 872, new Guid("f519025b-2e27-447d-ac48-9a681a2e7cf9"), "حاجي آباد", 23 },
                    { 888, new Guid("f30fe97a-e57f-4fa3-bf2d-7498fe34b659"), "دوبرجي", 23 },
                    { 887, new Guid("1b3f0b3b-fc24-49e3-8bfc-8d304e55cfe5"), "دهرم", 23 },
                    { 886, new Guid("a097e635-e6a6-4e05-95f0-57b0df306092"), "دبيران", 23 },
                    { 885, new Guid("47c14726-7c4b-4e4b-af3e-341934a74eb3"), "داريان", 23 },
                    { 884, new Guid("94d9000f-1c0f-4e90-a244-10da7a76ea92"), "داراب", 23 },
                    { 883, new Guid("5fc582ca-c724-4f00-aa68-826a6a0c67a4"), "خومه زار", 23 },
                    { 882, new Guid("25c50e31-05f7-45d8-b2c4-732ec487afb7"), "خوزي", 23 },
                    { 890, new Guid("86f1dd73-d5f0-4204-b688-2a0616ee8e3b"), "دژکرد", 23 },
                    { 881, new Guid("f04162a0-a14e-4f4e-a248-4265bfea5c8a"), "خور", 23 },
                    { 879, new Guid("e4e8e96b-159e-4f4c-88e5-4c37b443c5ea"), "خشت", 23 },
                    { 878, new Guid("aec04994-fe53-4645-93ef-8fa0e7810c10"), "خرامه", 23 },
                    { 877, new Guid("b9337ba4-d5c2-4901-aa86-3967b2dd54a9"), "خاوران", 23 },
                    { 876, new Guid("8a7f6a81-5853-4a76-ae3f-57616fe86b56"), "خانيمن", 23 },
                    { 875, new Guid("73419bc8-1c92-4bab-9e55-58df08dbab70"), "خانه زنيان", 23 },
                    { 874, new Guid("d0f614a2-6892-4d34-91d0-39a762605fb0"), "حسن آباد", 23 },
                    { 873, new Guid("03fe4652-44a7-4f2f-bfe9-5c019df31886"), "حسامي", 23 },
                    { 880, new Guid("90161524-cc4b-477d-85f3-93c313261af8"), "خنج", 23 },
                    { 774, new Guid("a03d58dd-1810-4413-b24c-6334298d997a"), "نسيم شهر", 21 },
                    { 771, new Guid("b713ee47-1e3c-40fc-9329-81b1fb00b2e7"), "قرچک", 21 },
                    { 772, new Guid("ed98f6b6-c0ad-4f90-b246-7f5a9bc5ffa6"), "لواسان", 21 },
                    { 672, new Guid("8a623310-4c2a-462d-85d3-ab147089163f"), "فريدونشهر", 19 },
                    { 671, new Guid("daeb2fbc-9cc1-4b0d-abef-54107f0718aa"), "فرخي", 19 },
                    { 670, new Guid("b7ea80d0-4086-4408-9101-d53b3d0080c1"), "علويچه", 19 },
                    { 669, new Guid("639d65e8-1524-45df-b75d-7425979b89a9"), "عسگران", 19 },
                    { 668, new Guid("02baa230-d1cd-46ad-9171-74254fc66a11"), "طرق رود", 19 },
                    { 667, new Guid("0fbd2329-0f49-4978-a6c1-868cdd81569e"), "طالخونچه", 19 },
                    { 666, new Guid("89d54e5e-7af5-4aae-a4f3-19bb166ab74c"), "شهرضا", 19 },
                    { 665, new Guid("d31d911a-b8bc-4a27-8b79-2aeb7efb2f8d"), "شاپورآباد", 19 },
                    { 664, new Guid("d13d2a55-e497-4816-b405-64eca4263ed9"), "شاهين شهر", 19 },
                    { 663, new Guid("fe8607a7-9805-408f-b2c8-c5d2e1c246ea"), "سگزي", 19 },
                    { 662, new Guid("0097d8e2-eb56-488f-9859-248a38cccc84"), "سين", 19 },
                    { 661, new Guid("219d2db4-9f22-48b1-a118-982ab472f5a3"), "سميرم", 19 },
                    { 660, new Guid("996e3891-4acc-4c34-a7d8-771ce223c013"), "سفيد شهر", 19 },
                    { 659, new Guid("02ee3302-25f8-421c-8582-75ee15f70c4a"), "سده لنجان", 19 },
                    { 658, new Guid("db5e6459-89e1-453a-b3d2-0e20ca04e18c"), "زيباشهر", 19 },
                    { 673, new Guid("db7e9cd0-8e61-4565-a3cd-1bfa84c934eb"), "فلاورجان", 19 },
                    { 674, new Guid("63102897-e687-4877-820b-3242edeb93d2"), "فولاد شهر", 19 },
                    { 675, new Guid("62ab0f56-9653-4066-a7b2-da411508290c"), "قمصر", 19 },
                    { 676, new Guid("af1c0988-59a3-40cf-ba51-79d04f837f0e"), "قهجاورستان", 19 },
                    { 692, new Guid("3672dbc5-77eb-411b-85ed-0ab8db0a143e"), "هرند", 19 },
                    { 691, new Guid("a4abc9b6-d597-497d-a2bc-6f58db74275c"), "نيک آباد", 19 },
                    { 690, new Guid("b5193a0c-ddaa-4a9d-8439-6ef3f7ed3980"), "نياسر", 19 },
                    { 689, new Guid("a9ef4cc1-c8b2-42fe-af37-fb4b7e7b8b51"), "نوش آباد", 19 },
                    { 688, new Guid("531b932c-c6eb-4acc-af94-72841158a308"), "نطنز", 19 },
                    { 687, new Guid("91adf10b-cd4b-43bc-9afd-63251c61ab11"), "نصرآباد", 19 },
                    { 686, new Guid("a10a88e2-2ed8-4d45-abe5-09ca0bc0b264"), "نجف آباد", 19 },
                    { 657, new Guid("c6bd1247-7409-4e86-9a07-72dfd0353152"), "زيار", 19 },
                    { 685, new Guid("d307db1e-2bf6-4802-8f27-3f53ed5aaec2"), "نائين", 19 },
                    { 683, new Guid("9e989169-671e-423d-b2f2-a4fd42d8dfc7"), "مهاباد", 19 },
                    { 682, new Guid("89e05c9f-c0b1-40dc-8bc6-1e0d76941919"), "منظريه", 19 },
                    { 681, new Guid("258130cb-5ef9-4956-a941-2cd668a107e2"), "مشکات", 19 },
                    { 680, new Guid("28b64afe-da56-4e40-88b0-4b3c52240d83"), "محمد آباد", 19 },
                    { 679, new Guid("2791c790-5b7f-4f59-9979-d27ab2dbe9bc"), "مبارکه", 19 },
                    { 678, new Guid("f67769fa-335f-415e-a07b-743cd86aa787"), "لاي بيد", 19 },
                    { 677, new Guid("eed2bd19-6738-4944-b198-36f0244bbc17"), "قهدريجان", 19 },
                    { 684, new Guid("a619ee90-49c8-4d38-9411-325b8919a74a"), "ميمه", 19 },
                    { 693, new Guid("bf5ab015-d5d1-4551-bc00-19acb775b2c5"), "ورزنه", 19 },
                    { 656, new Guid("1ebf708b-a0e0-4ff1-bccd-645e8cb1280b"), "زواره", 19 },
                    { 654, new Guid("81e774bd-1da8-410a-b9ee-1743a1f06530"), "زاينده رود", 19 },
                    { 633, new Guid("cf711e50-6e08-4228-aee4-c15eb8c487e1"), "جوزدان", 19 },
                    { 632, new Guid("1cdf8206-6314-4603-934f-872cdc8aa34d"), "جندق", 19 },
                    { 631, new Guid("e4920f5f-44fe-42e8-a683-35005705c364"), "تيران", 19 },
                    { 630, new Guid("d33d11e8-c5bf-4e5d-8339-57e0b9e4a61b"), "تودشک", 19 },
                    { 629, new Guid("f67cd7d9-4849-4fc0-bddb-20818397bcf1"), "بوئين مياندشت", 19 },
                    { 628, new Guid("b391d4c6-2059-4977-9858-f2b5e1f72903"), "بهارستان", 19 },
                    { 627, new Guid("ba196919-3db7-465f-869d-30bccb9eae73"), "بهاران شهر", 19 },
                    { 626, new Guid("1f9c1a16-d74f-40e3-872c-e4f99f792d63"), "برف انبار", 19 },
                    { 625, new Guid("7a22a817-243a-451f-9636-e3ea4ed444d5"), "برزک", 19 },
                    { 624, new Guid("5ce0f1c2-3ca4-49d9-a2be-53a0ecb6c13e"), "بافران", 19 },
                    { 623, new Guid("a477b30e-c373-4843-8878-38fb6e0d37c7"), "باغشاد", 19 },
                    { 622, new Guid("9d8450d7-d34b-4e1b-b0f9-c1ae13508077"), "باغ بهادران", 19 },
                    { 621, new Guid("7896bb6c-468f-45bf-abc5-15a8f913bc3f"), "بادرود", 19 },
                    { 620, new Guid("b930e141-390a-4bc4-8b5d-06e3e9b9d658"), "اژيه", 19 },
                    { 619, new Guid("266aeec0-a6c6-438a-aac4-2c4727f7282e"), "ايمانشهر", 19 },
                    { 634, new Guid("3332ab9f-c35f-474a-aaf9-968520a5347b"), "جوشقان قالي", 19 },
                    { 635, new Guid("57b33f29-dd00-48cb-b932-093655e6c6a4"), "حبيب آباد", 19 },
                    { 636, new Guid("90ad0c4a-3965-42f9-b50c-55b06b45c615"), "حسن آباد", 19 },
                    { 637, new Guid("1a07d6d6-0329-42a0-a668-17c21e45ed78"), "حنا", 19 },
                    { 653, new Guid("500ce0a1-5b07-45a3-ad30-b24d6c4ebcc9"), "زازران", 19 },
                    { 652, new Guid("0e8d848a-2c97-4db0-88e7-7f058a08a120"), "رضوانشهر", 19 },
                    { 651, new Guid("ea178764-6fa5-4d10-a808-8db2f0cbf613"), "رزوه", 19 },
                    { 650, new Guid("97295c23-b800-49c4-855c-e1619f485fe4"), "ديزيچه", 19 },
                    { 649, new Guid("6b8eea92-7b1f-4d91-8d23-68b11d8f915b"), "دولت آباد", 19 },
                    { 648, new Guid("a46dfc71-15f5-4dd2-901d-3ef39fef8710"), "دهق", 19 },
                    { 647, new Guid("4e266b5d-fd16-4072-9392-06bb447170f4"), "دهاقان", 19 },
                    { 655, new Guid("810c61f2-cab7-464b-ba89-0aaff5177ed7"), "زرين شهر", 19 },
                    { 646, new Guid("0ea28ec4-0d59-45d8-b02e-976b5d2820f3"), "دستگرد", 19 },
                    { 644, new Guid("0173d6b2-00dc-43d1-9804-fdef92d24a11"), "دامنه", 19 },
                    { 643, new Guid("aeff6878-9e95-4548-b198-6a5d341bc33e"), "داران", 19 },
                    { 642, new Guid("99228d7c-b8ac-4bf4-be3e-92a208129751"), "خورزوق", 19 },
                    { 641, new Guid("c41f5e7b-e3bb-40d3-94f1-c81efa302208"), "خور", 19 },
                    { 640, new Guid("3a0a67f9-b4b9-473f-9e3f-a00b83da7294"), "خوانسار", 19 },
                    { 639, new Guid("18ff8979-b317-4508-97e3-60d408113efd"), "خميني شهر", 19 },
                    { 638, new Guid("b533c3b7-4cb1-486e-9a84-b53a19e212bd"), "خالد آباد", 19 },
                    { 645, new Guid("a2696b55-03ae-46fe-98c4-96813484c226"), "درچه پياز", 19 },
                    { 694, new Guid("2d56f0fe-4e62-4217-8e3e-263fe8e4aa91"), "ورنامخواست", 19 },
                    { 695, new Guid("4d2b3dae-df04-4ea1-981f-0c2676c3586f"), "وزوان", 19 },
                    { 696, new Guid("57439cfd-10e0-47b0-8d53-a0befee3529c"), "ونک", 19 },
                    { 751, new Guid("46277273-e913-4274-ae23-4d8a41f68c6b"), "تهران", 21 },
                    { 750, new Guid("8cdc6109-600a-4d60-bb66-55ac940db73e"), "تجريش", 21 },
                    { 749, new Guid("f2adb36e-46db-4d71-b2a0-e7d95a7cc436"), "بومهن", 21 },
                    { 748, new Guid("dc0bc8d5-ea13-4f5e-a0b2-624faf9f8230"), "باقرشهر", 21 },
                    { 747, new Guid("b3686e90-849f-4973-934d-2ff51660ae1b"), "باغستان", 21 },
                    { 746, new Guid("a620fcff-0df2-42c2-bdb8-803c88dffa00"), "انديشه", 21 },
                    { 745, new Guid("4203e6f6-9aa4-487b-ac23-59d2218c452f"), "اسلامشهر", 21 },
                    { 744, new Guid("08147f6d-dc9d-4aec-9cea-f900de4c15c7"), "ارجمند", 21 },
                    { 743, new Guid("75c16b4d-6b06-4e25-9c5b-3816284fecdd"), "آبعلي", 21 },
                    { 742, new Guid("7bd1ee67-b1fa-4a88-8a56-86a32a65439c"), "آبسرد", 21 },
                    { 741, new Guid("96a9c0af-37d2-46e0-9656-5204f0cfc195"), "چوار", 20 },
                    { 740, new Guid("c38e5d01-c943-4187-9f3d-182f43dbf488"), "پهله", 20 },
                    { 739, new Guid("f7047373-8259-4f93-b0a8-b9c4eb025f61"), "ميمه", 20 },
                    { 738, new Guid("f899f040-fae2-4faf-b2ed-67057647655e"), "موسيان", 20 },
                    { 737, new Guid("5d37832f-031c-475b-afa1-82b7aee518be"), "مورموري", 20 },
                    { 752, new Guid("adfd199e-2bd9-4ff2-ac14-167b7fad633c"), "جواد آباد", 21 },
                    { 753, new Guid("3643d998-b6b4-4ce8-90e7-912e52f43314"), "حسن آباد", 21 },
                    { 754, new Guid("c4ea3bd5-414c-4b7a-a7d1-e15f871e4db3"), "دماوند", 21 },
                    { 755, new Guid("101d0155-2801-4e0c-a423-7553b232275a"), "رباط کريم", 21 },
                    { 928, new Guid("2145519b-783c-4183-953e-1592bb727ac3"), "مصيري", 23 },
                    { 770, new Guid("7fd41906-9188-40da-ac52-159d4a11fcdf"), "قدس", 21 },
                    { 769, new Guid("2207b0a3-5099-4ae7-ab25-03b60f37efdd"), "فيروزکوه", 21 },
                    { 768, new Guid("99f253b6-57d4-4fe3-863c-c19deca362d0"), "فشم", 21 },
                    { 767, new Guid("867af6ff-6923-4a71-89c0-642c88c5bbc3"), "فرون آباد", 21 },
                    { 766, new Guid("d8cfa905-621d-4bcc-a55c-d6d9bf6d66e0"), "فردوسيه", 21 },
                    { 765, new Guid("93a15208-015c-4804-8341-75df4a3b9d2e"), "صفادشت", 21 },
                    { 736, new Guid("3b43f2d3-d0ba-44c6-b245-1acc92cd9bef"), "مهران", 20 },
                    { 764, new Guid("c902556f-4033-4e3f-97e2-eb01dd9a1ba2"), "صبا شهر", 21 },
                    { 762, new Guid("72fa6018-9ffd-4b0c-a966-66a3b264feb9"), "شهريار", 21 },
                    { 761, new Guid("ae55d2a0-e596-47da-9b2e-f65892e6caa9"), "شهر جديد پرند", 21 },
                    { 760, new Guid("4b460628-b7bc-4f69-b86a-693acd523f4b"), "شمشک", 21 },
                    { 759, new Guid("e2906363-d69e-4fcd-8449-e79bc8f90462"), "شريف آباد", 21 },
                    { 758, new Guid("a75ec0da-013a-42e0-bf05-d3cb22245fdf"), "شاهدشهر", 21 },
                    { 757, new Guid("f4e08af0-4c7a-4a04-9e91-37d08378ab43"), "ري", 21 },
                    { 756, new Guid("a39f97b0-1c63-4aac-b193-b1e32a78db97"), "رودهن", 21 },
                    { 763, new Guid("3f229dd0-ba76-49a7-9d1a-a266acc61ce9"), "صالحيه", 21 },
                    { 735, new Guid("2d362d8e-6262-42db-bb35-f8b4a9f442a8"), "مهر", 20 },
                    { 734, new Guid("91fe986c-e978-453e-9ed7-5b7f0a018ae8"), "ماژين", 20 },
                    { 733, new Guid("b7f6ea4b-0a3f-4d0a-9ce7-9080b4384c3d"), "لومار", 20 },
                    { 712, new Guid("2bdfb511-3474-46c7-9d3f-b3b2990265a5"), "گلدشت", 19 },
                    { 711, new Guid("e32ac63e-9923-45dc-b5d8-035483d3b929"), "گز برخوار", 19 },
                    { 710, new Guid("e5d72893-9a98-4bab-b0dc-eac1aaf5e073"), "گرگاب", 19 },
                    { 709, new Guid("4b48cb08-b646-41cb-b0fd-a2800d55abe9"), "کوهپايه", 19 },
                    { 708, new Guid("003f6578-53e7-45de-bb47-e566b4157e54"), "کوشک", 19 },
                    { 707, new Guid("225020da-cbf2-40c1-bebc-53952063d10e"), "کهريزسنگ", 19 },
                    { 706, new Guid("4950ba92-0fa4-4c51-a2e0-32b2c477d2a2"), "کمه", 19 },
                    { 713, new Guid("70b75ade-7b14-4608-83f5-6fd9bc29a926"), "گلشن", 19 },
                    { 705, new Guid("738c05a6-8517-46db-9b30-ed66c8315e2d"), "کمشجه", 19 },
                    { 703, new Guid("c40b0fd2-0c1a-471a-8dc0-5d0b8d7f336a"), "کرکوند", 19 },
                    { 702, new Guid("dba774a9-c0fe-4cdb-a76b-69ceae5d146a"), "کامو و چوگان", 19 },
                    { 701, new Guid("aa20683d-d573-46aa-a804-be98bba2d6e0"), "کاشان", 19 },
                    { 700, new Guid("58d36869-fe12-48bc-827b-8e3abf7dd804"), "چمگردان", 19 },
                    { 699, new Guid("383876c8-5d1e-4a9a-a256-69d9d560e976"), "چرمهين", 19 },
                    { 698, new Guid("34e0103e-66eb-435b-a4ea-5c4efea37f7d"), "چادگان", 19 },
                    { 697, new Guid("effb8d11-d4c3-4cdb-b80c-aa11ba2a25da"), "پير بکران", 19 },
                    { 704, new Guid("163dd39f-2522-4213-b5d7-50745479b68e"), "کليشاد و سودرجان", 19 },
                    { 773, new Guid("5c57ce1d-ed86-4f3a-bb05-9bb75d460902"), "ملارد", 21 },
                    { 714, new Guid("f0c9290b-1fee-4691-95c7-eea1bf5bb610"), "گلشهر", 19 },
                    { 716, new Guid("87f50059-ba94-4cbe-8b78-bd4385ccf3f7"), "گوگد", 19 },
                    { 732, new Guid("fd3efd56-25a0-4250-8da2-27d7511a3c50"), "صالح آباد", 20 },
                    { 731, new Guid("0870f77b-b412-4817-ab06-54f600d7feed"), "شباب", 20 },
                    { 730, new Guid("ade92763-de1c-4679-bf66-e162d6243ecc"), "سرابله", 20 },
                    { 729, new Guid("585c0655-1b07-4632-9e98-7388ab3249b4"), "سراب باغ", 20 },
                    { 728, new Guid("3594e51a-4ac9-473f-b671-c65e3e7dc76d"), "زرنه", 20 },
                    { 727, new Guid("39dc53a7-ab0e-4eaf-b073-56526ac69f3b"), "دهلران", 20 },
                    { 726, new Guid("ce2b49df-89fe-43e6-b58f-5ae21989e340"), "دلگشا", 20 },
                    { 715, new Guid("52bbb007-8385-4700-9a10-941f369f419d"), "گلپايگان", 19 },
                    { 725, new Guid("85f89489-3d19-42cd-b09e-540c03359de9"), "دره شهر", 20 },
                    { 723, new Guid("86d531ce-4456-4e84-8007-460da58480e1"), "بلاوه", 20 },
                    { 722, new Guid("8ffd2e99-455d-408f-aa74-76636e6a31e5"), "بدره", 20 },
                    { 721, new Guid("1149c52f-ba40-411c-bf0e-be10932b935b"), "ايوان", 20 },
                    { 720, new Guid("795cfbeb-2cd3-4d8c-978d-6e2a26e1a592"), "ايلام", 20 },
                    { 719, new Guid("eb3ed62c-3822-43de-91f7-9268bcc51dcc"), "ارکواز", 20 },
                    { 718, new Guid("1aa74201-21e0-4027-9b25-ff119ef50623"), "آسمان آباد", 20 },
                    { 717, new Guid("46909657-2f10-4ef0-8561-37004a40b23a"), "آبدانان", 20 },
                    { 724, new Guid("64a18ecd-64b1-4f6b-bff3-9a2bbe013db8"), "توحيد", 20 },
                    { 929, new Guid("817867e5-1b4a-49ed-a65e-7bb6fa1c9177"), "مهر", 23 },
                    { 931, new Guid("4bfea515-bd0a-4eb6-8887-8138303a0c66"), "ميمند", 23 },
                    { 618, new Guid("1c32eb42-e366-4a0c-affe-8066fdce30a9"), "انارک", 19 },
                    { 1142, new Guid("447d2744-de5e-4873-8815-80a80198260a"), "بروات", 29 },
                    { 1141, new Guid("67fcac5c-2417-4eee-9063-1d5afb5ef49b"), "بردسير", 29 },
                    { 1140, new Guid("fc1f3166-d095-4de0-a461-5ecde548cca3"), "بافت", 29 },
                    { 1139, new Guid("e9ebfa21-d9d8-4391-84e2-0b3e8355c65c"), "باغين", 29 },
                    { 1138, new Guid("6090508c-c54c-4000-aa9e-17a9e5579581"), "اندوهجرد", 29 },
                    { 1137, new Guid("bebe83b7-b2bb-4eee-b838-68f38f2ac025"), "انار", 29 },
                    { 1136, new Guid("70a54ce0-7a1b-4b92-ad5e-4a97f02882d4"), "امين شهر", 29 },
                    { 1135, new Guid("06246cc0-9b57-4b13-9272-f5335e5563e5"), "ارزوئيه", 29 },
                    { 1134, new Guid("569ef053-6315-49ba-8932-98db4f70f861"), "اختيار آباد", 29 },
                    { 1133, new Guid("d091beb3-59f2-447d-85ab-d2c09d691d3b"), "گيان", 28 },
                    { 1132, new Guid("a4a70b0b-ffa8-4019-ba17-9427ff1191a2"), "گل تپه", 28 },
                    { 1131, new Guid("4a26a1c0-de81-415d-a1a8-2246ec9b67d6"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("f07adb98-5495-4e88-908d-d83783590b72"), "همدان", 28 },
                    { 1129, new Guid("ce59c7cf-e154-4dd9-8edb-98ed19295cc7"), "نهاوند", 28 },
                    { 1128, new Guid("2150fea6-e633-43d8-b316-338c2f0068db"), "مهاجران", 28 },
                    { 1143, new Guid("68d7e279-7d13-4a18-aab9-6245f1028727"), "بزنجان", 29 },
                    { 1144, new Guid("28b3bc96-7841-49c0-b93b-fd2d6efd41c3"), "بلورد", 29 },
                    { 1145, new Guid("a3a50fa3-c1b7-4696-a9ce-b90c9ab5132a"), "بلوک", 29 },
                    { 1146, new Guid("a96883da-4fac-473a-adb2-5a9c8a8ed626"), "بم", 29 },
                    { 1162, new Guid("3b063389-f1eb-4a28-a540-3724769c8a6f"), "راين", 29 },
                    { 1161, new Guid("4a6f9a5c-7fa6-40c0-b0e8-fa223592fcfc"), "راور", 29 },
                    { 1160, new Guid("152f87dd-59fa-428c-b6aa-51a608646d2e"), "رابر", 29 },
                    { 1159, new Guid("9ca17f22-0d8b-4c3f-8dee-1a5e0b5bb2ae"), "دوساري", 29 },
                    { 1158, new Guid("d0d77985-2bc0-4551-921d-24a787108818"), "دهج", 29 },
                    { 1157, new Guid("c312171d-2321-42fb-ba17-4b10c68c70b4"), "دشتکار", 29 },
                    { 1156, new Guid("a7dd57a9-8be7-428a-9aec-14dea53d3ab0"), "درب بهشت", 29 },
                    { 1127, new Guid("bdc749f1-652d-4510-b565-adf08d6e5811"), "ملاير", 28 },
                    { 1155, new Guid("a159f2af-cb65-4c84-8f29-97a8cc0d2894"), "خورسند", 29 },
                    { 1153, new Guid("61fcd172-9b5e-4fcd-b9a3-0556d9324483"), "خانوک", 29 },
                    { 1152, new Guid("cc160c3a-60aa-4456-9bd2-b72c5d4dca10"), "خاتون آباد", 29 },
                    { 1151, new Guid("235d4757-146c-4641-b2d2-0ef75b73543f"), "جيرفت", 29 },
                    { 1150, new Guid("fbd1a7fa-08b2-4859-ac26-2e62e0defe2a"), "جوپار", 29 },
                    { 1149, new Guid("f4af63d2-dd87-4162-b3e9-6d9a2a38aa4a"), "جوزم", 29 },
                    { 1148, new Guid("34a423d6-cf6f-417f-97df-c2b329a8b8ff"), "جبالبارز", 29 },
                    { 1147, new Guid("178312f0-d5a5-4ab0-bac3-5b89e76b1de2"), "بهرمان", 29 },
                    { 1154, new Guid("bfb6e909-8587-48db-8bb4-3708581829dc"), "خواجوشهر", 29 },
                    { 1163, new Guid("54ddd4f6-a6de-405d-98d0-4ff245f436fa"), "رفسنجان", 29 },
                    { 1126, new Guid("e0d8247b-2272-4741-8765-0e3e3ba536e7"), "مريانج", 28 },
                    { 1124, new Guid("f0808936-a0c2-4166-bd5d-4ec4c0f25e1a"), "قهاوند", 28 },
                    { 1103, new Guid("32969dca-23f2-4aaa-8fbc-552de18b8cdb"), "کياشهر", 27 },
                    { 1102, new Guid("52b7c25e-0f67-4f37-9759-6f255f66135c"), "کوچصفهان", 27 },
                    { 1101, new Guid("43baf133-30ac-4ae8-95f6-a9f21760efff"), "کومله", 27 },
                    { 1100, new Guid("4d146e09-290d-4832-a3fd-697421ed3045"), "کلاچاي", 27 },
                    { 1099, new Guid("01da6fe0-bbf5-4d81-8fd5-4ba0d2419f1a"), "چوبر", 27 },
                    { 1098, new Guid("096ad400-aa23-4447-9dc1-f91a1fa4fd47"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("fc71e0f2-74ba-4682-aec9-67760b15828c"), "چابکسر", 27 },
                    { 1096, new Guid("27054a97-f4df-4807-b552-1b39ed3d8cc9"), "پره سر", 27 },
                    { 1095, new Guid("f08f1c63-92dd-4a82-910a-403e05bf2252"), "واجارگاه", 27 },
                    { 1094, new Guid("4054fabd-e356-49c9-a73b-a1bf5dbdcfaa"), "هشتپر", 27 },
                    { 1093, new Guid("a7aac236-a088-47b0-afaf-3b36a6ebf04a"), "منجيل", 27 },
                    { 1092, new Guid("954fa27b-7d88-4886-b04c-6a05a6df817a"), "مرجقل", 27 },
                    { 1091, new Guid("39e75cb6-9ff9-4869-84a6-4fb0f53b5dfb"), "ماکلوان", 27 },
                    { 1090, new Guid("a0e13219-c79a-457e-b25e-23227473cd7d"), "ماسوله", 27 },
                    { 1089, new Guid("800d8ff0-b8c8-43d0-ba52-71b829af8d0e"), "ماسال", 27 },
                    { 1104, new Guid("a5f8fe9a-a1d1-4144-b851-f20f9b9fab8b"), "گوراب زرميخ", 27 },
                    { 1105, new Guid("d4462fc2-6ecd-4480-94e6-abbcd5aa963e"), "آجين", 28 },
                    { 1106, new Guid("a078395c-5f88-4d96-8c33-7b78166f1049"), "ازندريان", 28 },
                    { 1107, new Guid("a3c00031-1ccc-49b7-b988-59337a8a8552"), "اسد آباد", 28 },
                    { 1123, new Guid("45efade5-baf0-4936-bd03-b9a4bd548469"), "قروه در جزين", 28 },
                    { 1122, new Guid("9dbe032b-7250-44cd-a970-30699d8a9ac5"), "فيروزان", 28 },
                    { 1121, new Guid("bda9fd0a-62e1-46a4-8fcb-abebac2fcbf7"), "فرسفج", 28 },
                    { 1120, new Guid("40774f42-3a4c-4bc3-8094-67fcfdefd583"), "فامنين", 28 },
                    { 1119, new Guid("17f2b744-5349-4c26-9974-0db0f39e8f53"), "صالح آباد", 28 },
                    { 1118, new Guid("4a4b525f-d6b5-4614-8b02-86f6a49991dc"), "شيرين سو", 28 },
                    { 1117, new Guid("e3c1b999-4cdf-417a-bfaa-844799daba72"), "سرکان", 28 },
                    { 1125, new Guid("66835f55-0b65-4f52-9073-48dc50a04e0a"), "لالجين", 28 },
                    { 1116, new Guid("9ce97695-e67d-4f60-b5ca-15dba8b7b4bd"), "سامن", 28 },
                    { 1114, new Guid("ac6b5673-57e1-4919-b25b-ea8428849c33"), "رزن", 28 },
                    { 1113, new Guid("cf1c384c-dfff-440c-872a-523c988cf38a"), "دمق", 28 },
                    { 1112, new Guid("8a07d928-e21e-4f6b-9112-a00d996c46bc"), "جوکار", 28 },
                    { 1111, new Guid("a4649d1c-5d10-491c-b668-c6ab652903c2"), "جورقان", 28 },
                    { 1110, new Guid("0558a936-1526-4bd8-bc0e-3651932e2ad5"), "تويسرکان", 28 },
                    { 1109, new Guid("598f4b73-800f-4af3-b4cb-32f8147ed733"), "بهار", 28 },
                    { 1108, new Guid("deb851b1-048e-479c-907b-aa96b96de613"), "برزول", 28 },
                    { 1115, new Guid("18f7bab2-38c9-44aa-bd6a-1330ce12e76a"), "زنگنه", 28 },
                    { 1088, new Guid("b986fe5e-9191-451c-9234-f274239ed03b"), "ليسار", 27 },
                    { 1164, new Guid("bd767b38-2d65-4b66-a711-e2525c0d35fd"), "رودبار", 29 },
                    { 1166, new Guid("4c7b7e96-1fd4-4dbb-87c9-6d2e68ab6116"), "زرند", 29 },
                    { 1220, new Guid("4a17090b-25a7-4993-8708-55f32dc0a2df"), "ميامي", 30 },
                    { 1219, new Guid("09ddcc21-0831-4d27-93b2-a78e4744eebb"), "مهدي شهر", 30 },
                    { 1218, new Guid("834ff446-b1f5-4aa5-91cf-9d2e7e92e68f"), "مجن", 30 },
                    { 1217, new Guid("7032745f-39cb-4db5-aa3b-c8a75f0a5111"), "شهميرزاد", 30 },
                    { 1216, new Guid("8a484d2c-896a-48a1-b61a-174078ca7749"), "شاهرود", 30 },
                    { 1215, new Guid("ef718ef6-4da7-4a76-8585-588805b98518"), "سمنان", 30 },
                    { 1214, new Guid("6aeb0707-8925-4752-a869-dd865fb8b750"), "سرخه", 30 },
                    { 1213, new Guid("b937e57f-8277-4cf3-b14b-6ed960f0a90e"), "روديان", 30 },
                    { 1212, new Guid("8ce717ed-1901-4ece-b2f6-ab84a342365f"), "ديباج", 30 },
                    { 1211, new Guid("9bfa3711-7aa1-4226-bf70-a53018ec4fc5"), "درجزين", 30 },
                    { 1210, new Guid("b1d3bf9b-aaff-465e-af00-cdee46d89632"), "دامغان", 30 },
                    { 1209, new Guid("a9329bb2-db01-409f-9b3e-a70e57e01574"), "بيارجمند", 30 },
                    { 1208, new Guid("65844da4-346a-49ed-8161-c990c3bb07aa"), "بسطام", 30 },
                    { 1207, new Guid("8bd26997-aea9-4c0c-9824-3a360b79ec7c"), "ايوانکي", 30 },
                    { 1206, new Guid("73af5bd8-aa7a-4279-8411-99f7b31e1eed"), "اميريه", 30 },
                    { 1221, new Guid("fb6b73ab-3298-4483-9071-c654cd420884"), "کلاته", 30 },
                    { 1222, new Guid("5e580ca0-7c58-4124-8476-fbb433d06f63"), "کلاته خيج", 30 },
                    { 1223, new Guid("a3e23e93-b2d0-46e2-992b-dd5309711969"), "کهن آباد", 30 },
                    { 1224, new Guid("6039a5b7-e5c5-4550-ab46-84cf2de6db43"), "گرمسار", 30 },
                    { 1240, new Guid("9f0a6edc-af54-43cc-96fb-32581786336b"), "چيتاب", 31 },
                    { 1239, new Guid("ef2647dc-7191-40cb-972c-2e0c0af2adaf"), "چرام", 31 },
                    { 1238, new Guid("ca636f03-a4e0-4777-8022-9a16ae1a9827"), "پاتاوه", 31 },
                    { 1237, new Guid("2c275dc8-5975-457e-aaf8-030c20c2692b"), "ياسوج", 31 },
                    { 1236, new Guid("3adafea0-3979-43f0-9b83-5e4f1ec28817"), "مارگون", 31 },
                    { 1235, new Guid("ae40ee02-8162-44d1-95df-cecc3b3d2b5f"), "مادوان", 31 },
                    { 1234, new Guid("55d03f4b-680e-4622-9288-c8078a1e56a7"), "ليکک", 31 },
                    { 1205, new Guid("b3db1ac1-9917-4d90-be00-6f61bb19bb9a"), "آرادان", 30 },
                    { 1233, new Guid("76579b66-b171-493c-ad85-642ca8fe7018"), "لنده", 31 },
                    { 1231, new Guid("cb4b5ee8-fbe3-4139-a8f2-1db6768b72d3"), "سي سخت", 31 },
                    { 1230, new Guid("fbbc8d04-6deb-453a-ad87-d1ab2434d7ff"), "سوق", 31 },
                    { 1229, new Guid("eb3f9335-9fe6-46bb-af59-06d3859ee7a0"), "سرفارياب", 31 },
                    { 1228, new Guid("2c2905af-6c5f-4226-8559-24109a26fa14"), "ديشموک", 31 },
                    { 1227, new Guid("6b9c1d3a-eb82-459a-95bf-ae65d340af1c"), "دوگنبدان", 31 },
                    { 1226, new Guid("6872d35e-5d0b-40b2-92bd-246802d67863"), "دهدشت", 31 },
                    { 1225, new Guid("f4763d7a-8e04-4ece-b1a4-0ecb78ad489d"), "باشت", 31 },
                    { 1232, new Guid("142f091d-647a-49ab-a641-c60b5b29758b"), "قلعه رئيسي", 31 },
                    { 1165, new Guid("5e49c61f-eb2c-4c74-ba46-30ff51d4a5cd"), "ريحان", 29 },
                    { 1204, new Guid("d48e75d2-361d-4863-b855-3182ad0eec54"), "گنبکي", 29 },
                    { 1202, new Guid("bb1401a4-11e0-4bad-a25a-87863e34cf34"), "گلباف", 29 },
                    { 1181, new Guid("463b360d-720a-486a-b5e1-691d085d69e9"), "محي آباد", 29 },
                    { 1180, new Guid("07566bd3-c703-4b66-a1a9-d9602f3e4eee"), "محمد آباد", 29 },
                    { 1179, new Guid("4ea65258-5040-47ef-b9f5-ca16c392b488"), "ماهان", 29 },
                    { 1178, new Guid("5ec49725-d697-4bf4-b146-0329394a027a"), "لاله زار", 29 },
                    { 1177, new Guid("3eaea667-8cbd-4d6b-b5fe-e8e37118fc51"), "قلعه گنج", 29 },
                    { 1176, new Guid("bcf58be7-da1f-425a-907f-93205d7b6c79"), "فهرج", 29 },
                    { 1175, new Guid("02ebdc6a-be22-42d0-808b-e56abed59da9"), "فارياب", 29 },
                    { 1174, new Guid("6f67f78c-f165-4d7e-b81e-af5fae2f5651"), "عنبر آباد", 29 },
                    { 1173, new Guid("ad56b48e-a1e7-4a5f-bd5b-fa1cf5aaad60"), "صفائيه", 29 },
                    { 1172, new Guid("72f52a9c-71d3-45b8-bcb6-4bc806cc991c"), "شهر بابک", 29 },
                    { 1171, new Guid("3025a97e-0082-4b3f-8c1a-9656d2aca601"), "شهداد", 29 },
                    { 1170, new Guid("409b7223-f62e-4ca7-b008-14e48e55cb6e"), "سيرجان", 29 },
                    { 1169, new Guid("2e6d570e-112b-4a48-9c5f-88c61ad3e432"), "زيد آباد", 29 },
                    { 1168, new Guid("27664feb-698c-4b8c-8377-ec69c596ce67"), "زهکلوت", 29 },
                    { 1167, new Guid("c0975cce-5b0e-4dc0-92b0-f3f6ce5d7906"), "زنگي آباد", 29 },
                    { 1182, new Guid("043b7195-b30d-433a-9cdc-18014751df8c"), "مردهک", 29 },
                    { 1183, new Guid("f8cf5bef-a762-433b-9e1a-f5e32fee5cdc"), "مس سرچشمه", 29 },
                    { 1184, new Guid("e354ee70-c986-43c6-85d1-8a76bed1bbf0"), "منوجان", 29 },
                    { 1185, new Guid("317fa2f6-df3f-472f-97ac-3acd985804fa"), "نجف شهر", 29 },
                    { 1201, new Guid("84db2217-9699-474c-8390-72893e6b456e"), "کيانشهر", 29 },
                    { 1200, new Guid("8a6e6bdc-3d51-4191-a117-5f3c62d791f5"), "کوهبنان", 29 },
                    { 1199, new Guid("48d8c6ef-a21e-4cf5-bf87-606d0da187dd"), "کهنوج", 29 },
                    { 1198, new Guid("4dd802ad-656f-4ce3-8f77-88559370c21d"), "کشکوئيه", 29 },
                    { 1197, new Guid("2498c9d9-9181-4fdb-ba1d-58fb7f776eeb"), "کرمان", 29 },
                    { 1196, new Guid("278747af-1530-42a1-8f59-8416f7b07b5f"), "کاظم آباد", 29 },
                    { 1195, new Guid("48b81435-2845-47bd-b849-3275baa62e3f"), "چترود", 29 },
                    { 1203, new Guid("0675284a-a87f-42a9-bac3-c6813748d92b"), "گلزار", 29 },
                    { 1194, new Guid("5f611a56-7ad0-4d4c-b4b5-00c757c9e5d6"), "پاريز", 29 },
                    { 1192, new Guid("e830891c-991b-407a-9e6a-751d8b389bd1"), "هنزا", 29 },
                    { 1191, new Guid("2a366fdd-4ac8-4101-99c2-b664c43bf1be"), "هماشهر", 29 },
                    { 1190, new Guid("06d0e1ea-2f6c-4f34-b47a-b212c1e354be"), "هجدک", 29 },
                    { 1189, new Guid("f43517d6-f22b-4bb7-a4ed-74073b1534fc"), "نگار", 29 },
                    { 1188, new Guid("10b9d924-ec48-4637-80a5-487aba019e67"), "نودژ", 29 },
                    { 1187, new Guid("207b59db-7d74-4538-a86a-a2eec1e6d43c"), "نظام شهر", 29 },
                    { 1186, new Guid("bddd0857-ba07-417c-b371-33dae67168bb"), "نرماشير", 29 },
                    { 1193, new Guid("31f3589b-1105-4c9c-b58d-a7c29f9cae00"), "يزدان شهر", 29 },
                    { 1087, new Guid("a824d5b3-c555-4bdc-b9ef-31d04a52a26e"), "لوندويل", 27 },
                    { 1086, new Guid("00c85b9d-f6fb-46f7-aac6-bf980b062527"), "لولمان", 27 },
                    { 1085, new Guid("aba19817-72c3-42b5-a6fb-7abd10e2bfbe"), "لوشان", 27 },
                    { 985, new Guid("40d70023-cede-43c1-b90d-3418f8a5b19e"), "بندر لنگه", 25 },
                    { 984, new Guid("bcd58f1d-107f-4249-93a1-f643110de271"), "بندر عباس", 25 },
                    { 983, new Guid("d5c19b99-4f22-4274-ad54-e64b4e679c7d"), "بندر جاسک", 25 },
                    { 982, new Guid("90606777-2ea3-4342-9612-9afb7c2a4292"), "بستک", 25 },
                    { 981, new Guid("fbc2cdec-538b-4777-8552-a5f0adf3197d"), "ابوموسي", 25 },
                    { 980, new Guid("9c0f7478-3dbe-4e6d-b962-3104b6db21f3"), "گيلانغرب", 24 },
                    { 979, new Guid("b4edaa4d-6bec-47c8-8e42-1d37bbf476f0"), "گودين", 24 },
                    { 978, new Guid("03019d5c-d242-49d8-af90-3237599fc9bd"), "گهواره", 24 },
                    { 977, new Guid("5b158bef-c86e-478c-8bd8-2f5d1290ea61"), "کوزران", 24 },
                    { 976, new Guid("7d7f1069-84cb-414e-ad6b-a6d8ef86efa5"), "کنگاور", 24 },
                    { 975, new Guid("835866b7-4995-4e21-b255-6e8717be03aa"), "کرند غرب", 24 },
                    { 974, new Guid("d61ea920-ecc8-4a26-939b-6658a009fb47"), "کرمانشاه", 24 },
                    { 973, new Guid("89c8b0f0-35e2-491b-b1b8-e0488180e1fa"), "پاوه", 24 },
                    { 972, new Guid("36b2d9d6-1e60-42c1-826e-1fa4dff51a32"), "هلشي", 24 },
                    { 971, new Guid("d27c97e4-a6e7-4067-b641-e80a1987af8d"), "هرسين", 24 },
                    { 986, new Guid("982ea509-6d6a-4bf6-8d3c-fa9b8d99d303"), "بيکاه", 25 },
                    { 987, new Guid("1327971d-7cc8-41dd-bdd9-b98d60a9a3bf"), "تازيان پائين", 25 },
                    { 988, new Guid("528bb0c4-3fa2-45cd-900f-1264baadc3af"), "تخت", 25 },
                    { 989, new Guid("554c857e-51d1-470c-a5eb-27ccb2e22608"), "تيرور", 25 },
                    { 1005, new Guid("2757e491-a099-474d-b65d-b5358630332e"), "قشم", 25 },
                    { 1004, new Guid("df60abf4-9f79-43c8-a1fe-d0c8897bb17f"), "فين", 25 },
                    { 1003, new Guid("94a7f682-359e-4d67-ac7c-8cd3aaea19d5"), "فارغان", 25 },
                    { 1002, new Guid("61178c91-f3ca-47a9-af5d-1de7136af343"), "سيريک", 25 },
                    { 1001, new Guid("070a8730-78d1-47dc-8a24-c9142e9f7846"), "سوزا", 25 },
                    { 1000, new Guid("b6bcd246-076b-4b9d-a578-57e7ed2a3208"), "سندرک", 25 },
                    { 999, new Guid("fb88b4b4-431c-457d-8765-ba9db66b63ce"), "سرگز", 25 },
                    { 970, new Guid("3a23f9c2-ec24-4e3a-8f19-31ac708c8447"), "نوسود", 24 },
                    { 998, new Guid("4542bef8-a06c-4a8c-a386-12f556d4b0db"), "سردشت", 25 },
                    { 996, new Guid("e700ee58-9585-4323-b0c7-c4813b6a0254"), "رويدر", 25 },
                    { 995, new Guid("2cb7085e-d09d-4f68-8b7f-a49ef0c6e505"), "دهبارز", 25 },
                    { 994, new Guid("f8457048-5bd9-45e9-a7ab-53c805f3736d"), "دشتي", 25 },
                    { 993, new Guid("3067869e-ef4d-482b-9dce-db44e8fc4e24"), "درگهان", 25 },
                    { 992, new Guid("983af932-fbe7-4e4c-b4a2-073145bff71d"), "خمير", 25 },
                    { 991, new Guid("8b690458-758a-4dda-ab3b-4cb0aff41df2"), "حاجي آباد", 25 },
                    { 990, new Guid("0075cfe6-e7a0-4061-8c93-b2d7f1931eca"), "جناح", 25 },
                    { 997, new Guid("8b43ee0c-5a56-42d4-b9cb-dc463654dc36"), "زيارتعلي", 25 },
                    { 1006, new Guid("d9c3843e-9298-4049-81f3-105c1b142ac4"), "قلعه قاضي", 25 },
                    { 969, new Guid("f5b7b364-e389-44da-b165-55f44e827a2e"), "نودشه", 24 },
                    { 967, new Guid("19b561a7-0d0d-4d03-8d4e-ea2307003fdb"), "قصر شيرين", 24 },
                    { 946, new Guid("1fa50929-482a-437e-86c2-3dcf04c2cfe4"), "کوپن", 23 },
                    { 945, new Guid("78bfebb7-a71c-4aeb-a1da-5766ee323d23"), "کوهنجان", 23 },
                    { 944, new Guid("dd61a7f5-786d-4dfd-8e6e-2d32b25debfc"), "کوار", 23 },
                    { 943, new Guid("d4e642c4-b616-4d04-bdfc-c3d469c9e1b1"), "کنار تخته", 23 },
                    { 942, new Guid("ec4c5a7a-4bb4-424c-99f3-886054188014"), "کره اي", 23 },
                    { 941, new Guid("eca2590f-26f6-48aa-a721-ea34d7663cdc"), "کامفيروز", 23 },
                    { 940, new Guid("8d47e819-91f7-4334-8b93-b7906fb2e087"), "کازرون", 23 },
                    { 939, new Guid("f47131e8-13f7-4e7a-b7f3-229ffd1c26e1"), "کارزين", 23 },
                    { 938, new Guid("94e645d9-3a09-48ea-823b-659895f60992"), "وراوي", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 937, new Guid("c8c17e4a-3347-407f-86d2-bd77b53c4375"), "هماشهر", 23 },
                    { 936, new Guid("4966f58e-23c6-409c-bb0a-7ed5f10e9d71"), "ني ريز", 23 },
                    { 935, new Guid("7624d156-58de-4684-95a0-7c737d534447"), "نورآباد", 23 },
                    { 934, new Guid("6f4f94a1-5fb1-474d-b559-7386862977eb"), "نودان", 23 },
                    { 933, new Guid("c7ac7ea7-066b-404e-be73-3e29d4dcc993"), "نوجين", 23 },
                    { 932, new Guid("1f21b4ea-8a60-490d-b4fc-3cf09f31dfa7"), "نوبندگان", 23 },
                    { 947, new Guid("4709aec5-8f36-40f3-8c79-277cc0899d57"), "گراش", 23 },
                    { 948, new Guid("66390c30-83c8-4fd2-bb9b-d701cf58946c"), "گله دار", 23 },
                    { 949, new Guid("c4e58806-49b3-47c0-b1b6-2fd2604c95e3"), "ازگله", 24 },
                    { 950, new Guid("f648b4e8-0f8a-445a-84bb-3a25daa264d0"), "اسلام آباد غرب", 24 },
                    { 966, new Guid("f7a1da2c-ca00-4631-9505-4b841a47ae35"), "صحنه", 24 },
                    { 965, new Guid("a7abfe42-913a-42f1-86a2-0836fb4ba65f"), "شاهو", 24 },
                    { 964, new Guid("56e44de1-488a-4ccf-bc64-96bc7870db9a"), "سومار", 24 },
                    { 963, new Guid("511c04b6-8714-44c5-9c7b-5379c761f8e9"), "سنقر", 24 },
                    { 962, new Guid("fa6e04ff-0e8a-4468-ad8d-ba99432ea86d"), "سطر", 24 },
                    { 961, new Guid("0ecf6108-6591-4887-ad90-f77173f498d6"), "سرمست", 24 },
                    { 960, new Guid("8a9fe22e-4acc-41a0-b2be-6ce3aeef5fb1"), "سر پل ذهاب", 24 },
                    { 968, new Guid("da2ad715-1aeb-4701-8d5e-0bd7fb507022"), "ميان راهان", 24 },
                    { 959, new Guid("133164a3-8124-491e-9a01-95a4d6f59057"), "ريجاب", 24 },
                    { 957, new Guid("d302d894-ff7e-4884-a194-38c5b9ce1e85"), "رباط", 24 },
                    { 956, new Guid("5502e8f5-1d92-4e5e-8aea-8f803033dd41"), "حميل", 24 },
                    { 955, new Guid("4fed7a08-8642-4077-960e-030f72f2e06d"), "جوانرود", 24 },
                    { 954, new Guid("979ffd61-3975-4997-8776-0071763a82e2"), "تازه آباد", 24 },
                    { 953, new Guid("b8e510b1-bcb6-4390-8b36-cb800f3edf36"), "بيستون", 24 },
                    { 952, new Guid("fc43aa02-3b45-43f7-8679-ae0f0f3aa5ae"), "باينگان", 24 },
                    { 951, new Guid("d7ee19cd-7076-4b08-b042-25e7f826e243"), "بانوره", 24 },
                    { 958, new Guid("507844a8-6def-487a-80cf-c4d8d8b87482"), "روانسر", 24 },
                    { 1007, new Guid("02ee6f79-67c5-4df7-b5ab-654e19f7a420"), "لمزان", 25 },
                    { 1008, new Guid("68098aa0-fd52-465b-84eb-10dbd877218e"), "ميناب", 25 },
                    { 1009, new Guid("5de3a6b7-aca8-44f7-9ec3-001dc1a74bb1"), "هرمز", 25 },
                    { 1064, new Guid("756d70b5-eb86-4da7-8a55-e509f88edc33"), "حويق", 27 },
                    { 1063, new Guid("d12e2590-2809-4ea2-a0a7-63c1956f948f"), "جيرنده", 27 },
                    { 1062, new Guid("b8cd1dc8-48e1-451a-98b2-4688acc88d85"), "توتکابن", 27 },
                    { 1061, new Guid("9e9977bc-4258-49eb-9115-77a6d8aa5ab8"), "بندر انزلي", 27 },
                    { 1060, new Guid("42e021aa-87bd-44b2-8dd9-62fd04e904b4"), "بره سر", 27 },
                    { 1059, new Guid("6ec32637-81ad-43d2-95b2-8ca65fe42c18"), "بازار جمعه", 27 },
                    { 1058, new Guid("9d075376-b3a6-4973-be04-948a1d7b29c2"), "املش", 27 },
                    { 1057, new Guid("b3f51c1f-b98d-44f0-b5a0-bc0110e73779"), "اطاقور", 27 },
                    { 1056, new Guid("aca61395-5bb3-47bd-ae24-7560d096d2bf"), "اسالم", 27 },
                    { 1055, new Guid("07a2da12-005b-4016-a7e7-75ec558b1df0"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("a02ad192-dd6b-44f5-a549-bee752d6eb1f"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("17bcb9ae-85f8-474a-9414-622336027b2c"), "آستارا", 27 },
                    { 1052, new Guid("f534ebc1-9e7d-4d63-bcdc-0035728ec186"), "کميجان", 26 },
                    { 1051, new Guid("5d4bf126-bf7c-412c-9601-556cd72d5cbf"), "کارچان", 26 },
                    { 1050, new Guid("c20f2dd7-3e14-43e0-adff-9a335b10d820"), "پرندک", 26 },
                    { 1065, new Guid("9129010b-9914-422c-9545-1c42dc1c3085"), "خشکبيجار", 27 },
                    { 1066, new Guid("efad7be5-69cd-47fc-9894-c6e81ef0a6e8"), "خمام", 27 },
                    { 1067, new Guid("e90b24d1-f833-45fa-844f-2b79f86f9f06"), "ديلمان", 27 },
                    { 1068, new Guid("2c94ef2b-439a-4574-bb30-9d82a5dbcb90"), "رانکوه", 27 },
                    { 1084, new Guid("0d1db2f6-b130-47b2-a797-cf05a6145d4f"), "لنگرود", 27 },
                    { 1083, new Guid("cbc079aa-7880-4da9-ace8-6ce0474e8c57"), "لشت نشاء", 27 },
                    { 1082, new Guid("c14c2fe4-fe3b-4698-ad2f-acdffd210624"), "لاهيجان", 27 },
                    { 1081, new Guid("95ff992a-ef28-403c-b60d-c06304cfc52e"), "فومن", 27 },
                    { 1080, new Guid("4f166c0e-a0c9-4115-a422-1e76ccd97de0"), "صومعه سرا", 27 },
                    { 1079, new Guid("5271b536-eecc-4cc9-9c21-bcb3bbeb07fa"), "شلمان", 27 },
                    { 1078, new Guid("4efc469b-0b55-48ff-ab29-2f12dd38466f"), "شفت", 27 },
                    { 1049, new Guid("4a264c60-d62a-4925-b337-c5eda1fcecc8"), "هندودر", 26 },
                    { 1077, new Guid("43155156-d1d3-41b8-b75d-f10a9d3bffee"), "سياهکل", 27 },
                    { 1075, new Guid("a869ea57-f149-4c4c-9c82-a8ac4f1a93cb"), "رودسر", 27 },
                    { 1074, new Guid("4d4d0ae0-5458-45c8-a2d5-6d7614a4203f"), "رودبنه", 27 },
                    { 1073, new Guid("cc93a67f-2173-4ade-9e7e-e5802f418010"), "رودبار", 27 },
                    { 1072, new Guid("c93d727b-8713-477f-b96e-3410562f8abd"), "رضوانشهر", 27 },
                    { 1071, new Guid("5955d016-f60a-4f6e-ab30-eaa1612328e7"), "رشت", 27 },
                    { 1070, new Guid("b599a192-f0b6-47b0-89a1-ed978e5474f7"), "رستم آباد", 27 },
                    { 1069, new Guid("a767d6b5-3d3d-425a-87bf-05f294c033bd"), "رحيم آباد", 27 },
                    { 1076, new Guid("951a19a7-c8fe-410d-8bc6-f3e5435147fe"), "سنگر", 27 },
                    { 1048, new Guid("2358e714-4454-4849-9e23-f8d7ed33e73e"), "نيمور", 26 },
                    { 1047, new Guid("61df786a-45ba-42d0-b4ce-a0a4fd87e406"), "نوبران", 26 },
                    { 1046, new Guid("9b34c669-39cb-478c-9ff3-692ed2b9810a"), "نراق", 26 },
                    { 1025, new Guid("e578399c-0005-4e90-8b44-a7e1f15ab9a2"), "توره", 26 },
                    { 1024, new Guid("27e15eab-3b44-43d9-b046-246bd192f4f5"), "تفرش", 26 },
                    { 1023, new Guid("0d9fbc61-c18e-4013-a22b-24f1050dffb8"), "اراک", 26 },
                    { 1022, new Guid("6b5d30e6-3ab2-4969-a637-cce8e3fd6c4e"), "آوه", 26 },
                    { 1021, new Guid("7ff24cd4-5948-47bf-a236-22f3a2cd4f02"), "آشتيان", 26 },
                    { 1020, new Guid("c691bb04-3459-4a08-a150-a3cb11398d49"), "آستانه", 26 },
                    { 1019, new Guid("c90c97ca-5a74-49bb-ab9b-e08407e07bb5"), "گوهران", 25 },
                    { 1026, new Guid("1d8f0759-8bf7-4f51-a4c2-94daeb272dd1"), "جاورسيان", 26 },
                    { 1018, new Guid("11f6f207-d563-4d25-9263-0917baef533a"), "گروک", 25 },
                    { 1016, new Guid("9164bcd1-c035-4747-8cc8-dbd2a0b89c6d"), "کوهستک", 25 },
                    { 1015, new Guid("3b95c508-dcf3-4997-87d0-1049f9a99a91"), "کوشکنار", 25 },
                    { 1014, new Guid("6da586f6-7159-40f0-8920-fa85f658ef56"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("fa140800-471e-43e5-826b-18b093e2ebeb"), "کنگ", 25 },
                    { 1012, new Guid("4f0d9341-3fe1-41dc-8d83-16fc206f67a0"), "چارک", 25 },
                    { 1011, new Guid("3a486268-936a-4def-aa78-0cf54c3578ab"), "پارسيان", 25 },
                    { 1010, new Guid("6e564b6c-406b-455a-9df7-cc27d06cd839"), "هشتبندي", 25 },
                    { 1017, new Guid("f6373f69-5675-41a8-a4cd-fb32ce0d1445"), "کيش", 25 },
                    { 930, new Guid("597338cd-ff89-4b1e-abb0-9ec3f0a9e452"), "ميانشهر", 23 },
                    { 1027, new Guid("eefc2667-2e37-47f9-bb0b-664d57d9ff2d"), "خشکرود", 26 },
                    { 1029, new Guid("237ba15f-13d2-4695-ab14-7a129224701d"), "خنجين", 26 },
                    { 1045, new Guid("c2d24596-ae97-420e-a8d6-bb192447bfc2"), "ميلاجرد", 26 },
                    { 1044, new Guid("0038d156-a5f0-47f1-a27a-072b936c2430"), "محلات", 26 },
                    { 1043, new Guid("08a06abb-3e76-47df-824a-05d4df5668a8"), "مامونيه", 26 },
                    { 1042, new Guid("473d7258-0d93-490a-b216-905ae13e5525"), "قورچي باشي", 26 },
                    { 1041, new Guid("e9c75832-9b38-49b5-b0ea-20aa5610f74c"), "فرمهين", 26 },
                    { 1040, new Guid("2b2ee82a-2093-479e-a965-dd2db0d84eec"), "غرق آباد", 26 },
                    { 1039, new Guid("f1a066ce-575f-4999-89a0-e742a01b10a8"), "شهر جديد مهاجران", 26 },
                    { 1028, new Guid("691a0e6a-3ee7-4f91-8ce0-3a62fac2e05e"), "خمين", 26 },
                    { 1038, new Guid("4f60c38d-0b58-4670-9251-1ff9e62b3b64"), "شهباز", 26 },
                    { 1036, new Guid("7ef71f98-e7b7-4487-a82a-ccdc1d8a6809"), "ساوه", 26 },
                    { 1035, new Guid("ba5836c5-588b-4483-be53-2cf4525d3995"), "ساروق", 26 },
                    { 1034, new Guid("bcea299c-63e6-4f01-a3be-378348672a94"), "زاويه", 26 },
                    { 1033, new Guid("175809c6-bbf5-4bcf-b96e-7ade3409b46e"), "رازقان", 26 },
                    { 1032, new Guid("c51c2bf4-5cc1-44be-8740-baee6eec1da3"), "دليجان", 26 },
                    { 1031, new Guid("c86660d6-b3a7-465c-ba19-3c0384aa622e"), "داود آباد", 26 },
                    { 1030, new Guid("7f912538-329b-4c6f-bdd6-0a0d00e30338"), "خنداب", 26 },
                    { 1037, new Guid("46244183-cd57-4838-a82d-1097bb246e04"), "شازند", 26 },
                    { 617, new Guid("e17def96-d96b-4397-9692-138f54db8461"), "افوس", 19 },
                    { 615, new Guid("49316df4-4a8f-4f65-a71f-7eb594cdb4fd"), "اصغرآباد", 19 },
                    { 1241, new Guid("548d1ba4-29ff-4c1d-b5eb-60be6c0fa97a"), "گراب سفلي", 31 },
                    { 209, new Guid("4ba4fbe7-8b01-4970-9376-3988a57b0219"), "سنگان", 8 },
                    { 208, new Guid("9b131ef1-c026-410a-b19f-e34cd6b150cb"), "سلطان آباد", 8 },
                    { 207, new Guid("1cd5e3a8-589e-4607-91b5-9ef1f29452a2"), "سلامي", 8 },
                    { 206, new Guid("089e9ad1-c89d-4531-95fa-d19a4b344788"), "سفيد سنگ", 8 },
                    { 205, new Guid("3818fd7c-8c21-4998-aa53-ae6c2650d822"), "سرخس", 8 },
                    { 204, new Guid("37d32057-705e-419a-a079-c897db09b1cc"), "سبزوار", 8 },
                    { 203, new Guid("004769ef-ca78-4210-871a-165cc2204ff1"), "ريوش", 8 },
                    { 202, new Guid("fc6b573a-5a71-4027-8651-f18582c34933"), "روداب", 8 },
                    { 201, new Guid("8516d4a0-0010-465d-a59e-805c468d0cf0"), "رضويه", 8 },
                    { 200, new Guid("2c0904e5-61b6-4e17-b1c1-bccc8d6f6745"), "رشتخوار", 8 },
                    { 199, new Guid("4c84573f-b460-4405-98a8-819fde59ff05"), "رباط سنگ", 8 },
                    { 198, new Guid("4ec41267-6708-417d-a4b3-daf3e454573f"), "دولت آباد", 8 },
                    { 197, new Guid("0ba0d09c-5ac8-4a52-b695-3afe6133eb8d"), "درگز", 8 },
                    { 196, new Guid("2a73c0b4-52dd-4171-be2e-303bdc13d535"), "درود", 8 },
                    { 195, new Guid("e65eee6f-180e-459e-971f-1cc25b9074d9"), "داورزن", 8 },
                    { 210, new Guid("31df4efb-5ef3-4b6b-a4ee-58b1249f158d"), "شادمهر", 8 },
                    { 194, new Guid("5fa7c63b-2738-48c3-8845-0a10e3a0de94"), "خواف", 8 },
                    { 211, new Guid("840e0239-5a94-43b4-b3ae-93b158e62920"), "شانديز", 8 },
                    { 213, new Guid("906448e7-c559-41e0-80d7-ea3527d84d4b"), "شهر زو", 8 },
                    { 228, new Guid("0e029ec9-9339-4b1c-96f3-4d415592993e"), "مشهد", 8 },
                    { 227, new Guid("6770b3ec-0255-4d1f-8756-4e27fefc4d6f"), "مزدآوند", 8 },
                    { 226, new Guid("4a0741a9-b70c-4241-abba-fa18ce5b4963"), "لطف آباد", 8 },
                    { 225, new Guid("3e1bc84f-8f4f-493c-a06c-4126565fb9ef"), "قوچان", 8 },
                    { 224, new Guid("cf28c6d0-0b3d-431e-83ac-c1a3a38f27b8"), "قلندر آباد", 8 },
                    { 223, new Guid("5ce4e644-3e6f-4560-910d-b98aa67bcb3e"), "قدمگاه", 8 },
                    { 222, new Guid("3a73dfab-1989-46e4-87bf-f2b47b840288"), "قاسم آباد", 8 },
                    { 221, new Guid("8ccf9bf0-ff5d-438b-8c8f-ef01d141e1f0"), "فيض آباد", 8 },
                    { 220, new Guid("91cb42a4-75c4-4f8f-a32f-8e6b4c287f2b"), "فيروزه", 8 },
                    { 219, new Guid("114d66f9-4c54-4068-999d-b05b3a9ea000"), "فريمان", 8 },
                    { 218, new Guid("6deb2d9f-6b3b-4a00-96a8-048752a6428e"), "فرهاد گرد", 8 },
                    { 217, new Guid("71f71bec-f27d-4bd7-8baa-f8ac80316861"), "عشق آباد", 8 },
                    { 216, new Guid("17960bf2-557a-4c31-b03b-af8d6731dfc1"), "طرقبه", 8 },
                    { 215, new Guid("77764beb-e425-451a-8fb0-e0ce9f84ef41"), "صالح آباد", 8 },
                    { 214, new Guid("6bc61765-5522-4e22-9659-e693c97f303d"), "شهرآباد", 8 },
                    { 212, new Guid("f82aaf64-4a82-4ac0-9d34-a68ca8fe675a"), "ششتمد", 8 },
                    { 193, new Guid("aa2cfea8-89f4-4138-b4e7-daf518d4a7e3"), "خليل آباد", 8 },
                    { 192, new Guid("89e667c1-3615-4df9-b535-a85344b597c3"), "خرو", 8 },
                    { 191, new Guid("6c2716dd-6ddf-49f8-87d1-0207266d57d3"), "جنگل", 8 },
                    { 170, new Guid("9f8593da-ccad-45db-9785-18ca10283182"), "نالوس", 7 },
                    { 169, new Guid("b4088603-5fa9-410a-9e60-b44f6a0b9be2"), "نازک عليا", 7 },
                    { 168, new Guid("66021152-87a9-4288-ad1b-e3fa1ab7581d"), "ميرآباد", 7 },
                    { 167, new Guid("40fda74f-06bf-4ba0-8bc0-9e99c0cfe122"), "مياندوآب", 7 },
                    { 166, new Guid("2a011521-8eed-4627-980e-b167c4fa801e"), "مهاباد", 7 },
                    { 165, new Guid("1bc7f883-f86b-409d-8853-d377de5a74ea"), "مرگنلر", 7 },
                    { 164, new Guid("e4e89169-cc68-410e-aa6f-7f9042819be4"), "محمود آباد", 7 },
                    { 163, new Guid("f35f8b86-b7a4-4b99-9675-9cd2a367c5de"), "محمد يار", 7 },
                    { 162, new Guid("f19b05ff-67c2-43af-83cc-d9902dcc03ca"), "ماکو", 7 },
                    { 161, new Guid("ca876a7c-5fc5-4a88-aede-b306794fac76"), "قوشچي", 7 },
                    { 160, new Guid("5be8bd3d-4fad-4fff-bd7a-1782e8a2fc95"), "قطور", 7 },
                    { 159, new Guid("a33d0352-4e87-4116-824f-abe7fd6de8a7"), "قره ضياء الدين", 7 },
                    { 158, new Guid("1908007e-e645-47b0-b31c-bc481ce304e0"), "فيرورق", 7 },
                    { 157, new Guid("7b3cf460-cc25-4dc7-89f9-c154ae62418a"), "شوط", 7 },
                    { 156, new Guid("e79a9226-c148-4a85-8596-5a3f7ef25396"), "شاهين دژ", 7 },
                    { 171, new Guid("793045f1-098b-496c-8044-5875abf6ff06"), "نقده", 7 },
                    { 172, new Guid("2ffa1881-5af4-4089-ba72-2b3881403537"), "نوشين", 7 },
                    { 173, new Guid("49173f7f-514e-4f68-998a-3f40f7c2fedb"), "پلدشت", 7 },
                    { 174, new Guid("0b28a944-0444-4907-848d-41970e6a7736"), "پيرانشهر", 7 },
                    { 190, new Guid("c5f2087f-184b-4c22-9ef6-2c4d4dbfae2e"), "جغتاي", 8 },
                    { 189, new Guid("351a4bce-98ce-48bc-9e07-7b58911dcb10"), "تربت حيدريه", 8 },
                    { 188, new Guid("1735e8bf-bbf1-4234-b9bd-3cb6432bbfac"), "تربت جام", 8 },
                    { 187, new Guid("dfb9ccb0-da41-4d56-99e6-07a22ae785c3"), "تايباد", 8 },
                    { 186, new Guid("4d485c4b-040c-4160-8b4b-0a7922eb5c78"), "بيدخت", 8 },
                    { 185, new Guid("4ba7e2d2-1a48-4087-b9fa-82c145208f44"), "بردسکن", 8 },
                    { 184, new Guid("720f39f4-e904-4106-ad72-1a583b394770"), "بجستان", 8 },
                    { 229, new Guid("478d24df-213b-4774-8920-ffa2d92ab7a5"), "مشهدريزه", 8 },
                    { 183, new Guid("1dc6f554-12d7-41b4-83c0-1d00ac0049f3"), "بايک", 8 },
                    { 181, new Guid("3502f6f3-0914-4fca-81c5-23ff073a9942"), "باخرز", 8 },
                    { 180, new Guid("21190797-7df1-421f-b953-128a238dae23"), "باجگيران", 8 },
                    { 179, new Guid("db0d9098-30d9-4f74-a96b-8030c0baef29"), "انابد", 8 },
                    { 178, new Guid("e7625890-a1d4-4c57-88ec-3db40a36c7ca"), "احمدآباد صولت", 8 },
                    { 177, new Guid("0d162ff8-9c5f-44bf-ae88-6a09ebf4f3fb"), "گردکشانه", 7 },
                    { 176, new Guid("04928232-7f3f-4370-a3f3-2f1dfdb5666b"), "کشاورز", 7 },
                    { 175, new Guid("019b7784-1cc2-4ce4-8480-f8b396d263ab"), "چهار برج", 7 },
                    { 182, new Guid("986154a1-09f1-469d-8163-a2ceb170df19"), "بار", 8 },
                    { 155, new Guid("a6105b6e-3883-48ff-b224-36dcf4310b42"), "سيه چشمه", 7 },
                    { 230, new Guid("8f34f6dd-5b11-4ed3-a8d5-8c4d0f5b9174"), "ملک آباد", 8 },
                    { 232, new Guid("c8a4f153-931e-4de4-8422-6377710c7219"), "نصرآباد", 8 },
                    { 286, new Guid("91b5eb37-3a17-43aa-9f14-369ae1e90cfc"), "گلمورتي", 9 },
                    { 285, new Guid("f3dd403b-7a98-419d-ad05-471601741091"), "گشت", 9 },
                    { 284, new Guid("82ff0d0f-7027-4973-8214-c1ba989c5920"), "کنارک", 9 },
                    { 283, new Guid("ef8e899b-b985-4b21-bb78-decef0883569"), "چاه بهار", 9 },
                    { 282, new Guid("2d88b38f-f56e-46d6-bb76-e799f03f404e"), "پيشين", 9 },
                    { 281, new Guid("669f79e8-d111-498e-a9b8-c9ee68a6f829"), "هيدوچ", 9 },
                    { 280, new Guid("06648892-9363-4ad3-995c-fb423f1b66bf"), "نگور", 9 },
                    { 279, new Guid("2ab31426-3f63-41e8-ac5d-e7ac9c6a4315"), "نيک شهر", 9 },
                    { 278, new Guid("93db9ea7-faa2-4c37-a538-21049ed5b938"), "نوک آباد", 9 },
                    { 277, new Guid("703d65af-5621-4497-bce8-37f24b411b9b"), "نصرت آباد", 9 },
                    { 276, new Guid("f2accb7b-98d1-4cce-84b7-28515a80e0d1"), "ميرجاوه", 9 },
                    { 275, new Guid("9b38d1b9-8d8f-4c32-81a2-31f302860293"), "مهرستان", 9 },
                    { 274, new Guid("89fe1b61-3040-4676-b642-082c57d985a1"), "محمدي", 9 },
                    { 273, new Guid("d2af2932-c089-4266-b8d5-0e8ab276855b"), "محمدان", 9 },
                    { 272, new Guid("0fe4432a-215d-477d-98cc-40ab1455dd4c"), "محمد آباد", 9 },
                    { 287, new Guid("d510c689-1977-4835-822d-ef8c30958c6a"), "آرين شهر", 10 },
                    { 271, new Guid("9cb8a585-d19a-453d-a892-2a251d8f57ea"), "قصر قند", 9 },
                    { 288, new Guid("05f88d0a-a3c4-419f-8532-434f198bf16a"), "آيسک", 10 },
                    { 290, new Guid("087cf8be-9151-485c-9836-1abc1b9d4df3"), "اسديه", 10 },
                    { 305, new Guid("ed9eed30-f532-4104-adf8-245e3223249f"), "طبس مسينا", 10 },
                    { 304, new Guid("5b75f3af-cfae-4088-b674-ad0e64aa168c"), "طبس", 10 },
                    { 616, new Guid("79841e1a-a4eb-4cf1-8709-2fc9f09b9232"), "اصفهان", 19 },
                    { 302, new Guid("27c82d84-9b81-490c-9812-a84c3c786ae6"), "سه قلعه", 10 },
                    { 301, new Guid("2d2e8a68-d445-4676-91a1-23d75209a0b4"), "سربيشه", 10 },
                    { 300, new Guid("a6df72a8-ede0-4d7d-8014-0353e76610fa"), "سرايان", 10 },
                    { 299, new Guid("717bd996-0b1b-4391-94bf-f837b85fcb49"), "زهان", 10 },
                    { 298, new Guid("d7304efc-675f-467b-bc22-ae2a02dc6a2a"), "ديهوک", 10 },
                    { 297, new Guid("f7863d25-e14e-45b3-a239-2ec8fca0948e"), "خوسف", 10 },
                    { 296, new Guid("3fc72cf7-03f9-4cc5-910d-327c5583e42d"), "خضري دشت بياض", 10 },
                    { 295, new Guid("7b90cd45-eea3-4ef6-88bf-3b32e1eef829"), "حاجي آباد", 10 },
                    { 294, new Guid("261a549b-fca3-4194-a261-70b96a266f2c"), "بيرجند", 10 },
                    { 293, new Guid("a3028442-2c34-4458-b432-6cf729c0ac8e"), "بشرويه", 10 },
                    { 292, new Guid("d15988ca-4fad-4c8b-a7d6-9f44f7718cac"), "اسلاميه", 10 },
                    { 291, new Guid("181efcba-4b51-4d11-a280-77a06be553c3"), "اسفدن", 10 },
                    { 289, new Guid("68179059-94c9-4520-8d24-7363552896d1"), "ارسک", 10 },
                    { 270, new Guid("ae3ec27c-5206-407a-a65d-1aafbbffc333"), "فنوج", 9 },
                    { 269, new Guid("ae3dc292-e778-4f67-93ee-a80c794aaa39"), "علي اکبر", 9 },
                    { 268, new Guid("f6d69be5-29c1-41b6-8772-50bb14394ccb"), "سيرکان", 9 },
                    { 247, new Guid("70fff3cb-1913-46b9-ae68-ad13504b689c"), "کندر", 8 },
                    { 246, new Guid("ce2e0a7f-391a-434f-8f1d-fe6defa52fcb"), "کلات", 8 },
                    { 245, new Guid("849eed88-1dd2-4e1a-8650-4ad14c5beaa7"), "کدکن", 8 },
                    { 244, new Guid("1bdfb2e0-9f27-4f8e-9a8f-439e1d4fb6d3"), "کاشمر", 8 },
                    { 243, new Guid("3163a12a-0f8b-41a0-951d-4b0a4a3edea8"), "کاريز", 8 },
                    { 242, new Guid("e1c85277-5644-4c22-8a6d-2e5e1bfccf1e"), "کاخک", 8 },
                    { 241, new Guid("7b56934c-f904-4529-87ce-3c8f365f3682"), "چکنه", 8 },
                    { 240, new Guid("6a41b1ec-355a-4786-8266-4e06d0adff7c"), "چناران", 8 },
                    { 239, new Guid("aa7350a8-313c-4c4f-8ea4-b0a77c58d0c4"), "چاپشلو", 8 },
                    { 238, new Guid("0c93853c-eb71-4149-a6ae-5c617493d685"), "يونسي", 8 },
                    { 237, new Guid("f2f1c8c0-a0b2-4231-9130-abb142e36d41"), "همت آباد", 8 },
                    { 236, new Guid("4b6069e3-b9ae-48af-8cea-f56fe9f203d8"), "نيل شهر", 8 },
                    { 235, new Guid("eb778582-4627-4623-ae22-c8dcc00d971a"), "نيشابور", 8 },
                    { 234, new Guid("7d32a9bd-897f-4d6d-b2c9-3e7fa484b43e"), "نوخندان", 8 },
                    { 233, new Guid("33812650-4ae6-4643-8a95-4816bbf431bb"), "نقاب", 8 },
                    { 248, new Guid("3a93d606-18b9-4477-8f7e-3fe6ea8ff623"), "گلمکان", 8 },
                    { 249, new Guid("4164dbfa-b3b4-438d-aae6-ec97ba8c1d91"), "گناباد", 8 },
                    { 250, new Guid("3a605e50-284e-4678-8338-8c775f24f110"), "اديمي", 9 },
                    { 251, new Guid("bdbab8d7-3438-48f4-9d8a-f9b6b2307818"), "اسپکه", 9 },
                    { 267, new Guid("640d2e9b-1056-49ca-90e4-ea068e445b0b"), "سوران", 9 },
                    { 266, new Guid("469b9477-3b4d-455f-8bed-7ca6b2c47628"), "سرباز", 9 },
                    { 265, new Guid("fc9e16be-a250-4f75-b317-12be8809b7e8"), "سراوان", 9 },
                    { 264, new Guid("f9343de9-fbb6-4b2f-bbdc-717abbdf1122"), "زهک", 9 },
                    { 263, new Guid("18c605e5-9599-4fff-a3bb-2a55c77f0101"), "زرآباد", 9 },
                    { 262, new Guid("f763e214-07be-4323-8242-0d1cbae75d04"), "زاهدان", 9 },
                    { 261, new Guid("b9ac2bb9-53aa-4738-a7fe-f6a16d2d96ec"), "زابل", 9 },
                    { 231, new Guid("590f1143-d0f1-488c-80ec-73a2e3f9c4e4"), "نشتيفان", 8 },
                    { 260, new Guid("e88edb06-6dd0-4fa3-ba0f-8c89a93d1e2e"), "راسک", 9 },
                    { 258, new Guid("06212f71-7e01-4342-9c7f-dbbbf37be991"), "خاش", 9 },
                    { 257, new Guid("5d171bab-eb59-434e-9dcf-f9a2a521e3d8"), "جالق", 9 },
                    { 256, new Guid("91d22038-4542-4950-9321-f47846f275bd"), "بنجار", 9 },
                    { 255, new Guid("b3c5629c-ff3b-45cf-b039-b7a393b1c7d6"), "بنت", 9 },
                    { 254, new Guid("14bb303b-84a0-4188-9768-97e9053e7d37"), "بمپور", 9 },
                    { 253, new Guid("a5f9ecd0-00e3-47c5-acdb-623977ce6aca"), "بزمان", 9 },
                    { 252, new Guid("0d1fcc1e-df22-441a-a857-2c212f96e0f0"), "ايرانشهر", 9 },
                    { 259, new Guid("4ce4c652-ea38-43f1-a74e-c83e8e74354a"), "دوست محمد", 9 },
                    { 154, new Guid("e3e1714b-a307-470c-affb-e6a9729ee709"), "سيمينه", 7 },
                    { 153, new Guid("39cc748a-4cdd-437c-8183-cfb7b69258e0"), "سيلوانه", 7 },
                    { 152, new Guid("b4965593-89d9-4a36-bb07-69ccabbb6e62"), "سلماس", 7 },
                    { 54, new Guid("2a3b6c58-4805-42a1-bc88-9a02e1f4b542"), "پردنجان", 2 },
                    { 53, new Guid("352a304d-f89b-4daf-aa2a-138aa4e813e7"), "وردنجان", 2 },
                    { 52, new Guid("be6f19c8-e4be-4df9-a813-717b8e86cfae"), "هفشجان", 2 },
                    { 51, new Guid("a566c295-b566-4ba2-adcb-c30c7ffd5b08"), "هاروني", 2 },
                    { 50, new Guid("7b7d9cf8-1356-4d9b-9f67-dd6be3beb68d"), "نقنه", 2 },
                    { 49, new Guid("c1241462-26d0-4eb2-b48a-23b4f8631e9c"), "نافچ", 2 },
                    { 48, new Guid("ffaa865b-6236-41ce-9dcc-58cee8551187"), "ناغان", 2 },
                    { 47, new Guid("2eae75d8-3c94-47e6-89ae-97673023f388"), "منج", 2 },
                    { 46, new Guid("89caa158-1697-4302-a75e-2871d894aca7"), "مال خليفه", 2 },
                    { 45, new Guid("49a9c2b6-e2af-4b5d-b546-0b5ce9ae8b2a"), "لردگان", 2 },
                    { 44, new Guid("b7d528dc-1198-41f3-a16d-f74c6a0826cc"), "فرخ شهر", 2 },
                    { 43, new Guid("8f58a662-2932-46c8-8373-7ada0a679170"), "فرادنبه", 2 },
                    { 42, new Guid("7e0085bd-6397-4c44-a1e1-7d0f8985d068"), "فارسان", 2 },
                    { 41, new Guid("6cbdb4ae-d350-4bdc-888b-40b6015c7a6f"), "طاقانک", 2 },
                    { 40, new Guid("8d633e27-fb1a-414a-b265-9da301b15102"), "صمصامي", 2 },
                    { 55, new Guid("22b0b935-21b8-4af7-94b8-ac392ef7dcfa"), "چليچه", 2 },
                    { 39, new Guid("7eb05a4d-17eb-40c8-963e-21f8796c2e77"), "شهرکرد", 2 },
                    { 56, new Guid("0f7fc9d5-87d7-4d77-8b6b-a63765f0d4fc"), "چلگرد", 2 },
                    { 58, new Guid("193cd365-330e-444f-a622-eb4565edffd2"), "کيان", 2 },
                    { 73, new Guid("65b4da65-dc87-407b-b745-5ea1ccd3475f"), "سنخواست", 3 },
                    { 72, new Guid("cfeb69bd-d151-4898-bf65-3c032ca9a260"), "زيارت", 3 },
                    { 71, new Guid("d54d6c4f-dc3f-4f88-96f8-117f2b20f328"), "راز", 3 },
                    { 70, new Guid("f1bf761c-ca98-4d7a-9354-b94d1f601a12"), "درق", 3 },
                    { 69, new Guid("4f4b5b95-d6b1-4c72-809b-c21500aba193"), "حصارگرمخان", 3 },
                    { 68, new Guid("21d381dd-1cdc-4087-b938-e78a140bc892"), "جاجرم", 3 },
                    { 67, new Guid("712cdee3-3bd8-48da-9c39-275b8a36f576"), "تيتکانلو", 3 },
                    { 66, new Guid("07c0f691-734c-46c5-bfb0-1b874f105c90"), "بجنورد", 3 },
                    { 65, new Guid("4bdfcae4-cb8c-452b-9973-d9aacbb9dab0"), "ايور", 3 },
                    { 64, new Guid("3cfa42d6-d6b1-4fbc-b6ba-fee3fa355ba2"), "اسفراين", 3 },
                    { 63, new Guid("d138e4b3-c33d-4a6c-87e4-a765e06f746d"), "آوا", 3 },
                    { 62, new Guid("7c986005-d28c-4166-8523-7150afb5ae1d"), "آشخانه", 3 },
                    { 61, new Guid("2ff6b791-f7b2-44aa-9142-c67b05af88c2"), "گوجان", 2 },
                    { 60, new Guid("1d5a9890-d6d8-44a4-906a-be7033b9f890"), "گهرو", 2 },
                    { 59, new Guid("fec7105e-6e3d-4364-a3cd-190434208f2e"), "گندمان", 2 },
                    { 57, new Guid("dbeae43b-e4b0-4edf-bb19-1a559ceeedca"), "کاج", 2 },
                    { 38, new Guid("70043efc-7961-4af6-8922-04076ae012f3"), "شلمزار", 2 },
                    { 37, new Guid("272ad1a6-f457-42e4-b19b-9d9865cefa56"), "سورشجان", 2 },
                    { 36, new Guid("1b8e56ae-85d0-4a7c-8792-07386631a639"), "سودجان", 2 },
                    { 15, new Guid("980f3c0b-eb9a-40b6-b7de-ada54f78d16c"), "مهردشت", 1 },
                    { 14, new Guid("5c7e30ee-6bcb-4675-9fc8-530d90a28dcc"), "مروست", 1 },
                    { 13, new Guid("d18de106-2be3-451a-8ce1-a1140493a832"), "عقدا", 1 },
                    { 12, new Guid("46337300-2ad7-4b79-9051-65df72fdb778"), "شاهديه", 1 },
                    { 11, new Guid("bcd74a39-c96e-4b86-a9aa-fbe6ed91146c"), "زارچ", 1 },
                    { 10, new Guid("3103480a-df94-4cd5-ba41-7f797cebdd6d"), "خضر آباد", 1 },
                    { 9, new Guid("f5787fdc-06e5-44f5-b14e-5ff2f99d7117"), "حميديا", 1 },
                    { 8, new Guid("3e3160e8-3c75-49e1-9e26-341b57b36e83"), "تفت", 1 },
                    { 7, new Guid("2baef0da-7c25-44c2-b417-e2128d5865ac"), "بهاباد", 1 },
                    { 6, new Guid("8841fa74-7f97-4198-adf0-4ab5e969c1e0"), "بفروئيه", 1 },
                    { 5, new Guid("5b1847cc-0914-4065-8893-ca2864d0603d"), "بافق", 1 },
                    { 4, new Guid("609d33db-cdc7-414e-96b3-c655c89ca292"), "اشکذر", 1 },
                    { 3, new Guid("a5c75a04-d0bc-4944-a634-a6add15cc249"), "اردکان", 1 },
                    { 2, new Guid("561ec4d3-03af-45ec-bbd5-bfb72ff42f2d"), "احمد آباد", 1 },
                    { 1, new Guid("38cb27d9-3ab6-499e-8818-0941344214d7"), "ابرکوه", 1 },
                    { 16, new Guid("e825d718-b8bd-4f54-8527-59a5fa89f59f"), "مهريز", 1 },
                    { 17, new Guid("d23af703-5c4b-4085-85b6-4c6e71796154"), "ميبد", 1 },
                    { 18, new Guid("0d128a53-df9a-41c6-983d-896c6e4b2a21"), "ندوشن", 1 },
                    { 19, new Guid("aab6682f-cde5-49bf-96fc-12d866c0dd8a"), "نير", 1 },
                    { 35, new Guid("445c75cf-4e1d-4f30-8583-2bf5d0e24228"), "سفيد دشت", 2 },
                    { 34, new Guid("3148cd11-f85f-4ca3-90b1-b1fc0d5bf80f"), "سردشت لردگان", 2 },
                    { 33, new Guid("c95e5c52-03c8-495f-80fd-8da2eeec219e"), "سرخون", 2 },
                    { 32, new Guid("bd9c8db1-af95-4fdf-bd32-9c147280c81f"), "سامان", 2 },
                    { 31, new Guid("8d14fa3a-d8d5-4911-a53a-958620ed55b6"), "دشتک", 2 },
                    { 30, new Guid("b4e0b9cc-4416-46a3-874e-3bef3d0d2c19"), "دستناء", 2 },
                    { 29, new Guid("a1b37b33-45b3-4308-bd38-3f28234877d5"), "جونقان", 2 },
                    { 74, new Guid("cbb55873-689e-416f-80af-49b918023ad5"), "شوقان", 3 },
                    { 28, new Guid("da20b02e-f3f9-4dd4-a4eb-77fde318ba48"), "بن", 2 },
                    { 26, new Guid("69590b64-0f33-4bdb-b6e6-feac5faa57ed"), "بروجن", 2 },
                    { 25, new Guid("073cdf57-00a1-4505-aebd-cbd082af2497"), "بازفت", 2 },
                    { 24, new Guid("54a06393-b01a-4c0f-9017-b870d3487101"), "باباحيدر", 2 },
                    { 23, new Guid("8586cceb-a8ce-4e10-af55-8c218a549e37"), "اردل", 2 },
                    { 22, new Guid("f6a5d9d6-4f48-4b6a-9dfa-72cff7fe6660"), "آلوني", 2 },
                    { 21, new Guid("90b747b0-ded8-413d-adbc-67352ef17920"), "يزد", 1 },
                    { 20, new Guid("961591bc-cdc4-4c86-8060-dead34f0913e"), "هرات", 1 },
                    { 27, new Guid("867fe161-a363-46b0-93f4-3f3207fbf3ff"), "بلداجي", 2 },
                    { 75, new Guid("491445bf-cb80-48e5-9724-62c627051fd8"), "شيروان", 3 },
                    { 76, new Guid("6152d2f3-31c0-4c23-a7c2-f898e6c0da95"), "صفي آباد", 3 },
                    { 77, new Guid("564ba80c-2088-4034-9459-5a0416739fe2"), "فاروج", 3 },
                    { 131, new Guid("8e6c67fb-6591-4d84-aa74-6271f4de64bc"), "پيرتاج", 6 },
                    { 130, new Guid("c71dfe6f-f156-4596-a3cc-173a3e53c571"), "ياسوکند", 6 },
                    { 129, new Guid("bef0a5c2-c761-4828-a063-da18c56368bc"), "موچش", 6 },
                    { 128, new Guid("13d8f0d4-eae4-49a4-b4b8-93f7792a0e59"), "مريوان", 6 },
                    { 127, new Guid("74b1e76b-1e11-412c-b4e3-a4acb192b118"), "قروه", 6 },
                    { 126, new Guid("b8408a96-1f21-4204-a50a-c9e6a0d08394"), "صاحب", 6 },
                    { 125, new Guid("214c1c97-436d-426d-bac0-b594d2866592"), "شويشه", 6 },
                    { 124, new Guid("6b22000e-4a23-409b-916a-5fc614afe84d"), "سنندج", 6 },
                    { 123, new Guid("a917fcba-c927-464f-ba63-dcb15229704d"), "سقز", 6 },
                    { 122, new Guid("4175a504-bf5d-4204-ad66-9871ffe1d13b"), "سريش آباد", 6 },
                    { 121, new Guid("848972d8-4843-430f-be04-007f270fecec"), "سرو آباد", 6 },
                    { 120, new Guid("100572e4-f5e5-4cb9-b6a7-041fea842bca"), "زرينه", 6 },
                    { 119, new Guid("16172921-2559-46f3-a3e9-7e9bb40a1996"), "ديواندره", 6 },
                    { 118, new Guid("ccf2cd08-a6fe-404b-8e06-f25ad1dd5bfe"), "دهگلان", 6 },
                    { 117, new Guid("e755025f-d140-43eb-a2ca-c0abd3d44872"), "دلبران", 6 },
                    { 132, new Guid("87e5f482-3ec1-45a1-919f-874484714e85"), "چناره", 6 },
                    { 133, new Guid("f195dead-c18f-4fa0-ae3c-bc7d277305b7"), "کامياران", 6 },
                    { 134, new Guid("eb5c1a5a-09fd-47f6-8966-5baf1b99f7b3"), "کاني دينار", 6 },
                    { 135, new Guid("279d3f01-d422-401b-ab95-acbbf19fff4f"), "کاني سور", 6 },
                    { 151, new Guid("6a69e694-de16-427b-ae02-77e6a580b8d0"), "سرو", 7 },
                    { 150, new Guid("ef7a1994-96bd-4acf-acfa-dc4d38a7eaf4"), "سردشت", 7 },
                    { 149, new Guid("de856dde-a99f-4581-a0b6-a4aab7116fbf"), "زرآباد", 7 },
                    { 148, new Guid("cb8c6111-199f-44b2-a2e6-d949f12054d0"), "ربط", 7 },
                    { 147, new Guid("15b212a7-4de6-4595-b38c-36f2f83024a3"), "ديزج ديز", 7 },
                    { 146, new Guid("42f5aaf6-0238-4a13-86e8-1a481210c55f"), "خوي", 7 },
                    { 145, new Guid("57adcffe-38e8-4f19-8314-1db86b4cb934"), "خليفان", 7 },
                    { 116, new Guid("37f71c7e-baa6-4a05-8ea9-1691ced6070b"), "دزج", 6 },
                    { 144, new Guid("3fb49dcd-8b69-4e14-8c92-36fb577e0c87"), "تکاب", 7 },
                    { 142, new Guid("929c4d3b-07e1-4a12-a6fb-40e804588c21"), "بوکان", 7 },
                    { 141, new Guid("041071b9-b635-4d36-b9f3-c04ba9963ac9"), "بازرگان", 7 },
                    { 140, new Guid("4e47a32f-7586-4bad-968d-660211a8cb99"), "باروق", 7 },
                    { 139, new Guid("d1bc797a-eeb3-49f6-a836-709e8b7ae698"), "ايواوغلي", 7 },
                    { 138, new Guid("32d6ec05-04c9-46f0-a711-0c988192a4d2"), "اشنويه", 7 },
                    { 137, new Guid("63439e21-3fd6-4bfe-b287-f8e201bc89b8"), "اروميه", 7 },
                    { 136, new Guid("f693dc09-33c6-44c0-99a8-9be09368ec4c"), "آواجيق", 7 },
                    { 143, new Guid("8596265c-9329-4756-b1b1-8cdc4c28de78"), "تازه شهر", 7 },
                    { 306, new Guid("c6ccc627-c6d2-495b-aad4-c415b8e80e8c"), "عشق آباد", 10 },
                    { 115, new Guid("2187544d-cc10-4795-a240-54d3023d5ce3"), "توپ آغاج", 6 },
                    { 113, new Guid("36c49b2f-4c14-4ade-81e6-d77d752a17d8"), "بوئين سفلي", 6 },
                    { 92, new Guid("5a615174-2646-4a5e-b1d6-a4c059b018d2"), "مشکين دشت", 4 },
                    { 91, new Guid("7559dda7-6e8c-4d74-906d-c040585b4b74"), "محمد شهر", 4 },
                    { 90, new Guid("3edce66f-4cc8-42bf-ad91-6199544c311c"), "ماهدشت", 4 },
                    { 89, new Guid("48b12ade-9edb-4dcd-a190-c696c2db717b"), "فرديس", 4 },
                    { 88, new Guid("f9edb7b4-06cd-49bc-a6c5-42311489c6c0"), "طالقان", 4 },
                    { 87, new Guid("8057a14d-feb7-4dee-b018-357963040d27"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("ca43fc35-2557-43e7-8ec6-599a0f97ee7b"), "تنکمان", 4 },
                    { 85, new Guid("83091aee-d089-4e8b-a5d8-a469203395c7"), "اشتهارد", 4 },
                    { 84, new Guid("eb8ae926-f801-4729-a587-bd73f12218e8"), "آسارا", 4 },
                    { 83, new Guid("eeebf858-1a65-4f33-ab80-e763d9a2d700"), "گرمه", 3 },
                    { 82, new Guid("64d8674a-1ca2-4d41-97ca-cb8855b3557e"), "چناران شهر", 3 },
                    { 81, new Guid("435a7fb1-3c70-46ad-b6f9-4fae0d1c78b5"), "پيش قلعه", 3 },
                    { 80, new Guid("78025eae-3af8-4e05-b6f7-5a2c74c15787"), "لوجلي", 3 },
                    { 79, new Guid("2a069712-d81c-4a2f-9eb7-20e1676ddefd"), "قوشخانه", 3 },
                    { 78, new Guid("695a7d3f-e736-43e9-aa63-2652e99630d9"), "قاضي", 3 },
                    { 93, new Guid("468a145a-42eb-4f6a-bc1c-f923f2af099c"), "نظر آباد", 4 },
                    { 94, new Guid("192f1d31-0f8d-45d7-81e6-281324eed411"), "هشتگرد", 4 },
                    { 95, new Guid("1a6216b7-3443-4a7a-b523-314733859c44"), "چهارباغ", 4 },
                    { 96, new Guid("e645b61a-cc6b-4558-98ff-9831eba81010"), "کرج", 4 },
                    { 112, new Guid("690f8f8d-7e4a-4979-a8bd-084c286a8b08"), "بلبان آباد", 6 },
                    { 111, new Guid("ca061952-b8ae-4bd4-bdf2-c5fc42e1dd5a"), "برده رشه", 6 },
                    { 110, new Guid("a7a56344-ca95-454f-820a-49fc115b6688"), "بانه", 6 },
                    { 109, new Guid("a85e6d4c-5d82-4c37-bbd0-09dcbd451e87"), "بابارشاني", 6 },
                    { 108, new Guid("18a603dd-6a5d-4991-8e4b-bede81e46ee5"), "اورامان تخت", 6 },
                    { 107, new Guid("4cbe4bcc-6e19-408c-b33f-6fe970fb0ef5"), "آرمرده", 6 },
                    { 106, new Guid("fb00cf0e-743e-464a-a1f7-426f035048b2"), "کهک", 5 },
                    { 114, new Guid("921fdf2c-f424-4ff0-9bb5-15ecc73be621"), "بيجار", 6 },
                    { 105, new Guid("f4be7776-096d-407c-859d-52a4d3f30ac5"), "قنوات", 5 },
                    { 103, new Guid("405970f6-ef4d-4778-9711-113ac009d7fe"), "سلفچگان", 5 },
                    { 102, new Guid("352911ba-1e2d-41c5-818a-eeecd6091a83"), "دستجرد", 5 },
                    { 101, new Guid("81990e5a-8fe8-4fb0-acfb-42190932c311"), "جعفريه", 5 },
                    { 100, new Guid("d2f8935f-bd0e-418c-b7eb-6e5b57520708"), "گلسار", 4 },
                    { 99, new Guid("5c841ca1-8a5e-47ed-82e5-0b91ea9eb5ef"), "گرمدره", 4 },
                    { 98, new Guid("9ed5b2fa-0c7a-477a-ae39-9d8f33cf112a"), "کوهسار", 4 },
                    { 97, new Guid("6eab5efd-0c0e-494a-8247-43d814a1db14"), "کمال شهر", 4 },
                    { 104, new Guid("bea00209-830e-4f4d-9c3d-0ec42dc33c08"), "قم", 5 },
                    { 307, new Guid("b3998605-21e2-44a4-967b-aa96bcf78ea6"), "فردوس", 10 },
                    { 303, new Guid("30992687-e4c8-4a58-ae43-b6dccfd79c29"), "شوسف", 10 },
                    { 309, new Guid("4413706c-4334-4ccb-ae04-8cc0034034c5"), "قهستان", 10 },
                    { 518, new Guid("20499d4e-b9b2-445e-aa8a-f45ce2c3211e"), "هادي شهر", 15 },
                    { 517, new Guid("98a5c240-8f2b-4650-99bf-2d0fd41d11cc"), "نکا", 15 },
                    { 516, new Guid("3f4aaeb9-d6f3-4ce2-838a-3979053a8a4a"), "نوشهر", 15 },
                    { 515, new Guid("7011a782-7340-40b9-b650-66dde97ec9f0"), "نور", 15 },
                    { 514, new Guid("976f57e9-f6c1-4396-b848-863f0d86e2d6"), "نشتارود", 15 },
                    { 513, new Guid("672f8c75-29d4-470a-a115-073e6a79de27"), "مرزيکلا", 15 },
                    { 512, new Guid("b144ff52-02be-40aa-83ec-8fb9d0409a9f"), "مرزن آباد", 15 },
                    { 511, new Guid("2db9f6de-d899-4121-9946-b5e9c499f1c2"), "محمود آباد", 15 },
                    { 510, new Guid("4cd4911b-f763-4278-8530-87da2c442d5d"), "قائم شهر", 15 },
                    { 509, new Guid("71876c13-a575-40ea-9cab-f2fe37a49001"), "فريم", 15 },
                    { 508, new Guid("c4cadf62-4631-4942-b8d9-383d8c81c5b6"), "فريدونکنار", 15 },
                    { 507, new Guid("6ca703f2-ab84-491c-ab07-2e77e5c3095e"), "عباس آباد", 15 },
                    { 506, new Guid("f1e27b00-26f0-4ead-9ff6-6b8de88837ef"), "شيرگاه", 15 },
                    { 505, new Guid("771b671f-6fd2-4859-9c67-4d7f536dcadd"), "شيرود", 15 },
                    { 504, new Guid("4defaf7a-e2fd-42db-b16f-76191d4a6656"), "سورک", 15 },
                    { 519, new Guid("8f749177-b981-4aaa-aa20-44cecc609666"), "هچيرود", 15 },
                    { 503, new Guid("82d21f0b-7540-4be6-936f-b6c7103c74f1"), "سلمان شهر", 15 },
                    { 520, new Guid("90d90bcb-f80c-474b-94b4-30924cdc301c"), "پايين هولار", 15 },
                    { 522, new Guid("41d9b402-8f24-4b06-9c4d-6fc1c6291cec"), "پول", 15 },
                    { 537, new Guid("20cb0727-805e-4509-bf0c-886142d6ca20"), "آوج", 16 },
                    { 536, new Guid("4b199386-c3cf-4604-ba61-e3a1c8841e11"), "آبگرم", 16 },
                    { 535, new Guid("366c185e-d1b4-4d20-b0b2-2421273fd921"), "آبيک", 16 },
                    { 534, new Guid("c3c0c9c4-a096-4558-ad79-81cf63a85a1e"), "گلوگاه", 15 },
                    { 533, new Guid("90388111-cea1-4181-9e13-faa1c4e8992e"), "گزنک", 15 },
                    { 532, new Guid("f0e7f803-5abc-452c-82a6-6e3be3e40ef2"), "گتاب", 15 },
                    { 531, new Guid("5e15eece-1cb6-4a13-a412-c1a04d7f0a18"), "کياکلا", 15 },
                    { 530, new Guid("bd8d60a4-bc23-41d5-8a93-454920f64ad5"), "کياسر", 15 },
                    { 529, new Guid("45b69b60-9f3a-47fa-8a24-62a8879f14b4"), "کوهي خيل", 15 },
                    { 528, new Guid("c28078c8-01a5-43ac-a27c-3601216e4179"), "کلاردشت", 15 },
                    { 527, new Guid("0004dd75-2436-48f6-904c-15e90da4cf87"), "کلارآباد", 15 },
                    { 526, new Guid("de7b4615-9d76-4b51-94ee-750250ec0d5a"), "کجور", 15 },
                    { 525, new Guid("189e7706-ce45-41e2-9655-aed120e35a19"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("eafc28d7-5b31-4312-86f0-7eac1a4f58b9"), "چمستان", 15 },
                    { 523, new Guid("04d7ff50-33e2-4e63-a956-46c5b87475e6"), "چالوس", 15 },
                    { 521, new Guid("b88509b1-7c12-4698-95c4-6f3fb58e9c6b"), "پل سفيد", 15 },
                    { 502, new Guid("72603e39-e79a-4f66-951c-4801047a46f2"), "سرخرود", 15 },
                    { 501, new Guid("a4878264-8c74-4f1a-b8e6-7c6e63451d03"), "ساري", 15 },
                    { 500, new Guid("f8616599-e863-4528-aed3-988b2a51c78c"), "زيرآب", 15 },
                    { 479, new Guid("485a8ebc-6f7d-4e65-8f92-d7cd3361dd67"), "آمل", 15 },
                    { 478, new Guid("fe96990f-35d8-43da-9591-dfd0ea7edb08"), "آلاشت", 15 },
                    { 477, new Guid("ad5c4614-6e36-4944-b43f-aa28fdfb0d3c"), "گنبدکاووس", 14 },
                    { 476, new Guid("9994ae96-c074-48e9-b60e-64a42a18bebd"), "گميش تپه", 14 },
                    { 475, new Guid("c6cdae11-7e86-45ea-ac04-f063d83ff253"), "گرگان", 14 },
                    { 474, new Guid("10e5af56-dcdb-44f4-989f-3da71c5bb860"), "گاليکش", 14 },
                    { 473, new Guid("fe1d3b4e-9552-478d-8085-aca19cd04aa6"), "کلاله", 14 },
                    { 472, new Guid("0763e558-e26d-4aee-8255-abfb1651754d"), "کرد کوي", 14 },
                    { 471, new Guid("f9875718-bfd3-403b-a7ab-55a4daea85a9"), "نگين شهر", 14 },
                    { 470, new Guid("f35cda82-a813-426d-ac77-f51a7539a436"), "نوکنده", 14 },
                    { 469, new Guid("389f5850-0a47-45af-9195-5fd40103cd92"), "نوده خاندوز", 14 },
                    { 468, new Guid("b6b9d22f-6177-49c6-915d-80c9f90f5cf7"), "مينودشت", 14 },
                    { 467, new Guid("f867895e-4286-4214-a735-d6634ca704eb"), "مزرعه", 14 },
                    { 308, new Guid("b0868548-e8d2-4fa6-be76-4696d1189d37"), "قائن", 10 },
                    { 465, new Guid("c9ece94e-e6cd-4b38-a1ef-86a9b0c07e3e"), "فراغي", 14 },
                    { 480, new Guid("bee46528-1d35-4a91-bb3c-a0215a37941b"), "ارطه", 15 },
                    { 481, new Guid("19957450-bd3e-4314-b624-0a9dd666588a"), "امامزاده عبدالله", 15 },
                    { 482, new Guid("f1f3b00b-2889-468b-92de-0ba99d59e525"), "امير کلا", 15 },
                    { 483, new Guid("3bbdfd5e-c52c-40f3-958e-5eb0150d57da"), "ايزد شهر", 15 },
                    { 499, new Guid("b77a1665-1848-4740-874b-d48902745cb0"), "زرگر محله", 15 },
                    { 498, new Guid("125fffd6-2c18-4073-b209-e53e0e004653"), "رينه", 15 },
                    { 497, new Guid("d18c74f9-6487-44ea-b559-7b996d2aa2ca"), "رويان", 15 },
                    { 496, new Guid("a9365749-9a39-4917-85f2-7b02780c2900"), "رستمکلا", 15 },
                    { 495, new Guid("468018bb-842d-4011-8dd6-fa7b357b89d5"), "رامسر", 15 },
                    { 494, new Guid("b5fe86d5-9f5a-4aa5-8ddf-ade234659fc9"), "دابودشت", 15 },
                    { 493, new Guid("5659c7f8-65a4-43bc-836f-c5df545fe643"), "خوش رودپي", 15 },
                    { 538, new Guid("006c3b41-4655-4999-81ea-69073bcfc966"), "ارداق", 16 },
                    { 492, new Guid("35625bc1-bb23-4971-8d17-848d0e1ba47e"), "خليل شهر", 15 },
                    { 490, new Guid("858decd4-ced7-4414-944a-183a581af8c4"), "جويبار", 15 },
                    { 489, new Guid("515405b6-ed08-407a-aad8-d9556314e464"), "تنکابن", 15 },
                    { 488, new Guid("ae5f2a2e-522e-4442-9647-a2ad7c4a31f6"), "بهنمير", 15 },
                    { 487, new Guid("e8fe51e4-95bc-4a5b-ab28-a5b4b37545be"), "بهشهر", 15 },
                    { 486, new Guid("e8ffd8d6-b7b3-4c5b-b0bd-38e5b793f0de"), "بلده", 15 },
                    { 485, new Guid("3c006cf6-d28e-4e5c-aad3-3868f663c960"), "بابلسر", 15 },
                    { 484, new Guid("5e08165e-3309-4b0d-a8da-ad02e3f00ef3"), "بابل", 15 },
                    { 491, new Guid("1a0b386d-3a4f-41aa-92bb-1f4ebeb36fdf"), "خرم آباد", 15 },
                    { 464, new Guid("8c4a1052-056b-43d4-b10f-1742f09a27c5"), "فاضل آباد", 14 },
                    { 539, new Guid("7a249053-4e56-4337-a2a2-79811f463c06"), "اسفرورين", 16 },
                    { 541, new Guid("4abe4cd5-f66c-4932-9303-1b7fc81ed9c4"), "الوند", 16 },
                    { 595, new Guid("4a862ebf-7817-488d-94cb-34df9452756b"), "سرعين", 18 },
                    { 594, new Guid("ba2beb20-a31f-4a23-9e11-476b1d0b5110"), "رضي", 18 },
                    { 593, new Guid("4ef3a36b-6b4c-44bb-a5f9-b4a36c682f74"), "خلخال", 18 },
                    { 592, new Guid("db7c080b-6081-477f-a228-75b3412fe098"), "جعفر آباد", 18 },
                    { 591, new Guid("149ace76-5f87-4888-9319-1165d308baaf"), "تازه کند انگوت", 18 },
                    { 590, new Guid("77d2d0c4-8b04-4dde-817c-ef342dabaeae"), "تازه کند", 18 },
                    { 589, new Guid("1bd322c0-6f6e-4b1f-964f-85ab8caa7f4c"), "بيله سوار", 18 },
                    { 588, new Guid("3a74c52a-4b11-4854-9b16-234e64841fb3"), "اصلاندوز", 18 },
                    { 587, new Guid("18b386e6-c952-4ea6-8d11-16279c1ae2f0"), "اسلام آباد", 18 },
                    { 586, new Guid("65c41d4b-a2e2-43b1-b5cb-42bf6ac367c5"), "اردبيل", 18 },
                    { 585, new Guid("2eb6cf3c-bb26-4eb5-a966-e521ab77316a"), "آبي بيگلو", 18 },
                    { 584, new Guid("9957c727-2589-4488-a1a6-119553201e89"), "گراب", 17 },
                    { 583, new Guid("cdf74f1a-3fcb-4a34-9f1f-23e0c8152fd7"), "کوهناني", 17 },
                    { 582, new Guid("f6dea311-e9d1-4815-a171-88260f329f91"), "کوهدشت", 17 },
                    { 581, new Guid("c70d3430-726d-48ae-b818-d064e4b90d2f"), "چقابل", 17 },
                    { 596, new Guid("9beff37e-73f7-4a84-a3f2-1e1e13c61e56"), "عنبران", 18 },
                    { 580, new Guid("d7f5dcc6-d0cb-4ee3-8805-9b02aab8fb35"), "چالانچولان", 17 },
                    { 597, new Guid("30fcd81f-a58b-40ec-8491-f7ce334699ec"), "فخرآباد", 18 },
                    { 599, new Guid("dda03b66-938f-490e-9b83-ad6974aeeed9"), "لاهرود", 18 },
                    { 614, new Guid("3ce5e68e-d437-4298-9958-0a38574c80b4"), "اردستان", 19 },
                    { 613, new Guid("66feb046-3344-4565-91e1-b00872e3ea89"), "ابوزيد آباد", 19 },
                    { 612, new Guid("febccc3d-029e-4894-9310-6de5e2a711c1"), "ابريشم", 19 },
                    { 611, new Guid("355bd653-e8fe-4c8d-86ea-adcb3b8ae71e"), "آران و بيدگل", 19 },
                    { 610, new Guid("dff10f21-7df7-45a3-bb3c-f89001eee90a"), "گيوي", 18 },
                    { 609, new Guid("c653de67-f544-4336-9ab3-e0354f8ea729"), "گرمي", 18 },
                    { 608, new Guid("d884ccd8-5447-412d-8c2a-7b0a9d192262"), "کورائيم", 18 },
                    { 607, new Guid("3cc403a1-0be8-4b12-8731-c253fcf5beb7"), "کلور", 18 },
                    { 606, new Guid("1b52fb80-3b60-4fb7-a159-c5e41368408d"), "پارس آباد", 18 },
                    { 605, new Guid("d7fcf84c-41c7-4c4c-88ec-16b8d3f12f0e"), "هير", 18 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 604, new Guid("5ba4f9b6-441d-4817-9448-a75d8e42a01a"), "هشتجين", 18 },
                    { 603, new Guid("c5f1fa73-ac9f-477a-bedc-25c3e9de5fc4"), "نير", 18 },
                    { 602, new Guid("783d1319-dd5c-4ca2-85eb-db938b52ecc7"), "نمين", 18 },
                    { 601, new Guid("cdd23704-185e-40a8-80ff-a64e40e9133c"), "مشگين شهر", 18 },
                    { 600, new Guid("7c332002-6ccf-4750-8d6e-3a7010492b3f"), "مرادلو", 18 },
                    { 598, new Guid("30fefaee-8b5b-45a5-a8b4-eb699bd207e7"), "قصابه", 18 },
                    { 579, new Guid("19e32472-4c8d-4514-836d-6aa887574758"), "پلدختر", 17 },
                    { 578, new Guid("d28335c1-ae9d-4f1b-b4b3-4faf682f67d9"), "ويسيان", 17 },
                    { 577, new Guid("8c65275c-6864-4c43-aa82-8533e91520ec"), "هفت چشمه", 17 },
                    { 556, new Guid("f55aebf2-b2d9-475d-acef-8de8a03a3076"), "محمود آباد نمونه", 16 },
                    { 555, new Guid("327d0a48-7ccd-47d2-ac31-cb3088140c86"), "محمديه", 16 },
                    { 554, new Guid("497e45a5-45a4-4571-a837-5d78b0ef9ce8"), "قزوين", 16 },
                    { 553, new Guid("e393f5ad-29d0-4d0e-a62e-5a93a366d188"), "ضياء آباد", 16 },
                    { 552, new Guid("11217b80-29d1-46fc-9e3b-80c69ce90ffc"), "شريفيه", 16 },
                    { 551, new Guid("5b06236d-c605-4c46-b0d7-1bcd2d4d63ab"), "شال", 16 },
                    { 550, new Guid("12fab109-39af-4ccf-bdec-2b4a7a63f3b3"), "سگز آباد", 16 },
                    { 549, new Guid("16d84c91-fed6-4280-a111-a02c5f043916"), "سيردان", 16 },
                    { 548, new Guid("7290b844-cf9b-46c9-adc8-7bb2f5c01784"), "رازميان", 16 },
                    { 547, new Guid("54d9f007-2416-4924-a335-8197d864aa1d"), "دانسفهان", 16 },
                    { 546, new Guid("8ef5a4b7-fd92-4c59-9c5a-2b38cf714706"), "خرمدشت", 16 },
                    { 545, new Guid("c2abf2c7-b254-44a1-895f-95c0c98c7c37"), "خاکعلي", 16 },
                    { 544, new Guid("df8bbe7a-3aa0-46ea-ac86-e6fd54950b7e"), "تاکستان", 16 },
                    { 543, new Guid("8b72b3cd-96fa-4f77-9ada-c3ba803893db"), "بيدستان", 16 },
                    { 542, new Guid("e4929583-4f5e-4a65-94a8-f2508c8bdce4"), "بوئين زهرا", 16 },
                    { 557, new Guid("661ad797-3757-4e38-b777-2f30525e3b73"), "معلم کلايه", 16 },
                    { 558, new Guid("a5536088-cec6-418e-8e62-b5136cd44a59"), "نرجه", 16 },
                    { 559, new Guid("82454396-49f9-4255-a611-2978941125be"), "کوهين", 16 },
                    { 560, new Guid("804aa752-5bbd-4847-b0c6-bff359686e2c"), "ازنا", 17 },
                    { 576, new Guid("5fa74ded-9598-417b-8a34-0982a9fd2645"), "نورآباد", 17 },
                    { 575, new Guid("892ea746-a764-4dca-bca6-5843932852f6"), "مومن آباد", 17 },
                    { 574, new Guid("54eaca36-ea1f-48d2-a9b1-fbc46f8fea49"), "معمولان", 17 },
                    { 573, new Guid("36457c3e-edd5-4edd-8300-528c433288e7"), "فيروزآباد", 17 },
                    { 572, new Guid("f6866bf5-e1a6-426c-a0aa-cc83e479d319"), "شول آباد", 17 },
                    { 571, new Guid("2e4c8417-235c-49e1-af57-3c1c795fa171"), "سپيد دشت", 17 },
                    { 570, new Guid("9ea40322-8d6e-4f1b-ae82-3047a250e468"), "سراب دوره", 17 },
                    { 540, new Guid("1a93c2ef-7629-4699-8853-1ef761cfa9f2"), "اقباليه", 16 },
                    { 569, new Guid("4902e6bd-4db3-4bae-b45c-11ac933a3f24"), "زاغه", 17 },
                    { 567, new Guid("0ef12b8c-cc7f-4e6b-990f-12cb7c798fc0"), "درب گنبد", 17 },
                    { 566, new Guid("75d9c001-570f-450b-8821-c2b39984abad"), "خرم آباد", 17 },
                    { 565, new Guid("e02b3f45-8845-4ab2-b39e-79267d142114"), "بيرانشهر", 17 },
                    { 564, new Guid("c5df10c6-e5c1-4ebc-9990-9baa31b6a0f2"), "بروجرد", 17 },
                    { 563, new Guid("e3a452a1-f3a9-4426-abf7-e76cd5f4881a"), "اليگودرز", 17 },
                    { 562, new Guid("720aacef-0963-4437-b054-c51b7718454d"), "الشتر", 17 },
                    { 561, new Guid("fff82c46-dfd5-4a2f-9e9f-67663fd9d076"), "اشترينان", 17 },
                    { 568, new Guid("0cfa347f-61e7-4daa-8e91-95838635d0ec"), "دورود", 17 },
                    { 463, new Guid("333fc4cb-4677-47e2-b847-323c5b514f48"), "علي آباد", 14 },
                    { 466, new Guid("7328f670-af13-4b9d-a553-cf2727bc8bdf"), "مراوه تپه", 14 },
                    { 461, new Guid("ede8b40a-5f8a-4613-af1e-ced9e0e9ee1a"), "سنگدوين", 14 },
                    { 363, new Guid("94a3a25c-76f1-42ff-a2a5-83afa805860b"), "شيبان", 11 },
                    { 362, new Guid("0c5b6fe4-2f6c-4074-9ed6-18b429ad3952"), "شوشتر", 11 },
                    { 361, new Guid("cb25e417-23df-4fe0-a77c-81abe760435f"), "شوش", 11 },
                    { 360, new Guid("8917bee2-69ed-4aa2-b27c-c080498deb61"), "شهر امام", 11 },
                    { 359, new Guid("47956a80-d3ae-40a7-b226-ef2d4a833dd6"), "شمس آباد", 11 },
                    { 358, new Guid("414a6719-7e69-4cba-ac11-0b25467f564f"), "شرافت", 11 },
                    { 357, new Guid("14485cdc-ff96-4ff5-a6d2-e5bfce4081c6"), "شاوور", 11 },
                    { 356, new Guid("e2ff6004-ff44-4730-9048-9cf27ee196ee"), "شادگان", 11 },
                    { 355, new Guid("18cfc336-10e3-46b9-a70b-91101678f986"), "سياه منصور", 11 },
                    { 354, new Guid("9c7d72a2-4281-4cab-ab4a-96c18af4a434"), "سوسنگرد", 11 },
                    { 353, new Guid("20129d38-b2f3-46bb-b97c-e9d0b0cefd1a"), "سماله", 11 },
                    { 352, new Guid("e82432f3-8e14-4efc-b19b-3c4e3412f6fc"), "سردشت", 11 },
                    { 351, new Guid("32a7911c-ee2a-4576-a085-6a9d8a76461b"), "سرداران", 11 },
                    { 350, new Guid("e0617c89-32ae-49d1-9be9-181725874a5c"), "سالند", 11 },
                    { 349, new Guid("66f4dd6d-2930-4510-a85c-5f2c58e265b2"), "زهره", 11 },
                    { 364, new Guid("5ed60cd0-164d-467d-8234-d9fdfd092c9c"), "صالح شهر", 11 },
                    { 348, new Guid("4561d9b6-b723-43b5-9933-f72b4da3b45a"), "رفيع", 11 },
                    { 365, new Guid("0ecabd2e-45ec-43ce-a890-11807b2baf57"), "صفي آباد", 11 },
                    { 367, new Guid("78afad52-a9c8-4a2f-ab66-be7ab818c9d5"), "فتح المبين", 11 },
                    { 382, new Guid("73fb6ebf-7241-46a3-aa4f-2963d1faa198"), "ويس", 11 },
                    { 462, new Guid("2d37c5f3-b5aa-400e-89c1-a97e7e2b0f5e"), "سيمين شهر", 14 },
                    { 380, new Guid("2d340225-abfa-4f6d-b01b-1f6dba91468c"), "هنديجان", 11 },
                    { 379, new Guid("1153c721-80a7-4995-a29c-4084bb5f5241"), "هفتگل", 11 },
                    { 378, new Guid("e5a5a286-b0da-4400-815d-be0458cd3bd0"), "مينوشهر", 11 },
                    { 377, new Guid("bf97acae-4678-4465-bb1e-0b4b52a53b4a"), "ميداود", 11 },
                    { 376, new Guid("fdde2e9f-64d1-4f2b-9ef4-9565c9dd44d8"), "ميانرود", 11 },
                    { 375, new Guid("240857f2-6cc0-4a5b-a8ec-f01e6e0730c2"), "منصوريه", 11 },
                    { 374, new Guid("1b10bf0a-573d-4f05-ab32-aa8076da4e3c"), "ملاثاني", 11 },
                    { 373, new Guid("81b64f37-6556-4d7a-945c-53e03f82f6e2"), "مقاومت", 11 },
                    { 372, new Guid("5355b524-4ff2-4fb7-be9b-2b42bbbbf842"), "مشراگه", 11 },
                    { 371, new Guid("f691ca62-fedc-46c1-8618-95b33ce47317"), "مسجد سليمان", 11 },
                    { 370, new Guid("189f9d8c-96f9-425a-ba35-3edac8eecc2c"), "لالي", 11 },
                    { 369, new Guid("e18dee85-cfa8-4f27-9b08-5ccc6093f1b4"), "قلعه خواجه", 11 },
                    { 368, new Guid("be3ca170-9698-4050-98b9-af08999ed5fb"), "قلعه تل", 11 },
                    { 366, new Guid("97a327c3-89bd-4c15-9e80-52bc235d2261"), "صيدون", 11 },
                    { 347, new Guid("74538751-4581-4a40-89ac-2863b017546d"), "رامهرمز", 11 },
                    { 346, new Guid("1ccf2216-663a-41d8-b4f0-9da5005fab7d"), "رامشير", 11 },
                    { 345, new Guid("85a31db3-f97a-41c9-ae00-25fe83ed53b9"), "دهدز", 11 },
                    { 324, new Guid("08fce10d-7782-4ba3-98cc-79199788f721"), "انديمشک", 11 },
                    { 323, new Guid("177c8bc0-d6c1-4c6e-a471-5e789edfd318"), "اميديه", 11 },
                    { 322, new Guid("e023e500-ae68-44f0-a994-3b77d923f828"), "الوان", 11 },
                    { 321, new Guid("161052b7-dd0d-4584-ad90-0be49490132c"), "الهايي", 11 },
                    { 320, new Guid("fa3d49d4-b8b3-4fb9-85e9-b4b661a0878a"), "اروند کنار", 11 },
                    { 319, new Guid("68e0e130-368e-402a-9734-dfd4da9b09fc"), "ابوحميظه", 11 },
                    { 318, new Guid("95a627f6-09ff-4c69-924b-91a3f5971b50"), "آغاجاري", 11 },
                    { 317, new Guid("01431d93-9527-4fd7-93b6-a28a6406a3b3"), "آزادي", 11 },
                    { 316, new Guid("97635037-8745-4ec5-9846-21554e013d46"), "آبژدان", 11 },
                    { 315, new Guid("eea6e5df-757e-40af-a4da-f520e7e2dad7"), "آبادان", 11 },
                    { 314, new Guid("a61f7e74-2b4a-4ff7-a7e0-0f41ecf73d45"), "گزيک", 10 },
                    { 313, new Guid("c5a51508-ee3c-423b-b762-de06a965577d"), "نيمبلوک", 10 },
                    { 312, new Guid("d7651e7d-0707-46a7-b01f-6ec77dc049cd"), "نهبندان", 10 },
                    { 311, new Guid("bd5d6949-718d-477b-b8a5-d7492a726ccb"), "مود", 10 },
                    { 310, new Guid("efa3d774-ed9f-44d0-88c4-94fd2d8f3693"), "محمدشهر", 10 },
                    { 325, new Guid("c4fd3734-e412-4c0f-8abf-a79c22b0d37b"), "اهواز", 11 },
                    { 326, new Guid("74f76e8a-751d-479a-92ae-d70b6f1d4024"), "ايذه", 11 },
                    { 327, new Guid("c77eaa78-b190-4461-833b-75d325e2c9eb"), "باغ ملک", 11 },
                    { 328, new Guid("b25b8837-7d42-4028-8754-d8b424dfd7be"), "بستان", 11 },
                    { 344, new Guid("05e25c97-d508-4ddb-9eb5-6a24df70962b"), "دزفول", 11 },
                    { 343, new Guid("a4d159c3-bdd6-4b9d-8e39-9fdf7d50e696"), "دارخوين", 11 },
                    { 342, new Guid("4ae8e54e-eeb3-4701-9db6-a323fdd7bee0"), "خنافره", 11 },
                    { 341, new Guid("4e9a5741-fd65-4c77-804d-f74492ea38b9"), "خرمشهر", 11 },
                    { 340, new Guid("d5050cd4-d67f-42ec-a478-73caaa16d702"), "حميديه", 11 },
                    { 339, new Guid("aca96b34-157f-41d5-b1d0-30023926ece1"), "حمزه", 11 },
                    { 338, new Guid("e85d5e0a-fc78-49ac-a9cc-e2c86a46b6d1"), "حسينيه", 11 },
                    { 383, new Guid("d17a13d2-8a1e-4b98-8f53-c38ab82ec609"), "چغاميش", 11 },
                    { 337, new Guid("65f1d236-6b73-4555-a75e-2466293153ad"), "حر", 11 },
                    { 335, new Guid("b8934e81-39f3-428d-a527-b27c3cd931b2"), "جايزان", 11 },
                    { 334, new Guid("91b69df6-7da0-4a8a-b468-ee97f9c2d3a4"), "تشان", 11 },
                    { 333, new Guid("094ff28c-6461-46a4-947c-c455dbea6bce"), "ترکالکي", 11 },
                    { 332, new Guid("e9601189-245d-4f80-acd6-23723bb8c0e7"), "بيدروبه", 11 },
                    { 331, new Guid("1f958928-d900-4645-95c9-325272c4ecd4"), "بهبهان", 11 },
                    { 330, new Guid("a2a76708-7a1d-4ea3-bcf7-3b1423e9d512"), "بندر ماهشهر", 11 },
                    { 329, new Guid("4039ba93-9c01-4654-92c9-747ca61c0c27"), "بندر امام خميني", 11 },
                    { 336, new Guid("8aaf4aea-ceb8-40fe-aa8b-f8afecdc7209"), "جنت مکان", 11 },
                    { 384, new Guid("30e5c650-feb2-4133-b7e6-fb65413df87a"), "چم گلک", 11 },
                    { 381, new Guid("fab5df31-f0e1-4474-8289-b115a749a034"), "هويزه", 11 },
                    { 386, new Guid("c84a6270-f6e8-4e10-836f-49329a7ed016"), "چوئبده", 11 },
                    { 440, new Guid("2c968894-3db1-4faf-9662-e61cfcd06376"), "صائين قلعه", 13 },
                    { 439, new Guid("ccece272-a705-4cb5-a274-0ee7a1ed71b4"), "سهرورد", 13 },
                    { 438, new Guid("677ced24-b057-46e6-b1d6-4e53e027d07f"), "سلطانيه", 13 },
                    { 437, new Guid("7266a140-1c22-4482-8c87-200cfb1555b9"), "سجاس", 13 },
                    { 436, new Guid("65f01e68-4b82-4bee-abf0-cfaccbef2ff0"), "زنجان", 13 },
                    { 435, new Guid("c877b760-3e80-4f14-871e-b8c49be361d3"), "زرين رود", 13 },
                    { 434, new Guid("17f9e094-6915-4d0b-8312-0fa78281e37f"), "زرين آباد", 13 },
                    { 433, new Guid("8bc774b8-5350-4a15-a187-071c56535cab"), "دندي", 13 },
                    { 432, new Guid("698c2f55-8197-47da-833a-09f85b41716f"), "خرمدره", 13 },
                    { 431, new Guid("93f7d7b2-c6d3-4047-9dd9-106aa1720882"), "حلب", 13 },
                    { 430, new Guid("3b11a9ce-36ff-45cb-b1ee-d9449c85efc0"), "ارمخانخانه", 13 },
                    { 429, new Guid("8b68d869-147e-431e-9b1c-3e8ebb9a8ecf"), "ابهر", 13 },
                    { 385, new Guid("798f0e8f-bdec-4961-92ad-837bcc96b0e0"), "چمران", 11 },
                    { 427, new Guid("eff1ac44-d0c0-428b-8242-7f4856d63cee"), "کلمه", 12 },
                    { 426, new Guid("0475977b-6693-44b3-b3de-c715b89042ff"), "کاکي", 12 },
                    { 441, new Guid("4fc6fdff-65fd-4b59-93e0-fbcc177bce6e"), "قيدار", 13 },
                    { 442, new Guid("2e898e20-c550-40f5-b665-3b2166146b22"), "ماه نشان", 13 },
                    { 443, new Guid("9a6c6ef6-55a7-42e2-b04c-4a446a850ba3"), "نوربهار", 13 },
                    { 444, new Guid("6375cd0f-bb9d-4784-995a-f2af1ac37d9b"), "نيک پي", 13 },
                    { 460, new Guid("b7ee5794-f90d-4e50-8058-badb955469bb"), "سرخنکلاته", 14 },
                    { 459, new Guid("44d48d17-9322-46c4-b0fe-4b33750a667e"), "راميان", 14 },
                    { 458, new Guid("bbd4fbaa-39ec-47b7-ab80-4f7615c03e5a"), "دلند", 14 },
                    { 457, new Guid("3c61aedf-40fb-4e50-8265-a403d891c782"), "خان ببين", 14 },
                    { 456, new Guid("53ad3958-d9a8-4582-85f5-d3949b602c54"), "جلين", 14 },
                    { 455, new Guid("bca50377-e079-4602-b2fe-44c169a35086"), "تاتار عليا", 14 },
                    { 454, new Guid("dee2b4f0-6b73-4d29-96ee-7e731807e69e"), "بندر گز", 14 },
                    { 425, new Guid("20b40cfc-813d-4b78-865f-57b32a4664e9"), "چغادک", 12 },
                    { 453, new Guid("3d8da9cd-630d-43b8-b68d-b98e09fcc925"), "بندر ترکمن", 14 },
                    { 451, new Guid("f6eca5ac-a988-4d93-bd64-5d26da378a96"), "انبار آلوم", 14 },
                    { 450, new Guid("9ecc702a-d2cb-4c96-b2e1-a4ac618ca8f7"), "آق قلا", 14 },
                    { 449, new Guid("bd234fae-3d0b-4f9d-b4ba-26aec9d4b5bc"), "آزاد شهر", 14 },
                    { 448, new Guid("d58b1f7e-da98-4d0e-a55f-830d70ea8f34"), "گرماب", 13 },
                    { 447, new Guid("cf388b5f-7277-4c5e-9533-37fc84263839"), "کرسف", 13 },
                    { 446, new Guid("ab062adb-d04e-4075-9870-20a9ee01e241"), "چورزق", 13 },
                    { 445, new Guid("e76ffc30-1bb9-48ea-a8a0-8f85c96c2c42"), "هيدج", 13 },
                    { 452, new Guid("0bbaeb36-11d6-4726-94b1-46b66b993ead"), "اينچه برون", 14 },
                    { 424, new Guid("b600be5c-13a2-4a4e-8e43-75f0ffc0858e"), "وحدتيه", 12 },
                    { 428, new Guid("7ae636b9-5762-4a0b-8b07-c6e5880e3a00"), "آب بر", 13 },
                    { 422, new Guid("ba093d3f-c077-40d6-870d-814310daa898"), "عسلويه", 12 },
                    { 401, new Guid("82cb4a17-b8b2-4586-a899-7caf3dcc3876"), "بردستان", 12 },
                    { 423, new Guid("80f8560d-6b82-4994-8082-4b6d27454c6b"), "نخل تقي", 12 },
                    { 399, new Guid("46a42c38-bd0c-4b90-aa47-fbf0fedef5eb"), "برازجان", 12 },
                    { 398, new Guid("c057e2ca-a9d0-4909-905a-db9ccf3ed8db"), "بادوله", 12 },
                    { 397, new Guid("183f9c52-a79a-41f3-b887-28f31ce546f1"), "اهرم", 12 },
                    { 396, new Guid("92833d0f-e434-4651-b776-a05edc64dbd3"), "انارستان", 12 },
                    { 395, new Guid("270754ed-4221-498b-bddb-4a4af5488cbf"), "امام حسن", 12 },
                    { 394, new Guid("a114453f-ea84-45e6-8f52-33eb34160d25"), "آبپخش", 12 },
                    { 393, new Guid("86df383f-09c7-4511-904e-c321859be8b5"), "آبدان", 12 },
                    { 392, new Guid("7507cad2-16a0-421c-acd3-7bb1bc7ddba6"), "آباد", 12 },
                    { 391, new Guid("61ef5365-a2ea-4642-8873-1d128eb229c9"), "گوريه", 11 },
                    { 390, new Guid("5b487bd3-22a0-4a5b-8684-aca5f3d558f9"), "گلگير", 11 },
                    { 389, new Guid("7846d59f-f0b6-4090-a8d6-c777d5ecabf3"), "گتوند", 11 },
                    { 388, new Guid("1343883b-2efe-4a56-8fef-44593e2fcb09"), "کوت عبدالله", 11 },
                    { 387, new Guid("4a322f73-58ab-452a-a9a0-765300af1d37"), "کوت سيدنعيم", 11 },
                    { 402, new Guid("405015bb-226b-40b1-b138-3297f0117a2f"), "بندر دير", 12 },
                    { 403, new Guid("dcba1964-d27d-465a-837b-59508ade7921"), "بندر ديلم", 12 },
                    { 400, new Guid("ee59c095-d90a-4f9d-a0c9-504ae7d68ef8"), "بردخون", 12 },
                    { 405, new Guid("791a253c-8f1d-4541-a444-7d1244577fef"), "بندر کنگان", 12 },
                    { 421, new Guid("f5fb7ee4-343d-4aa8-ac60-07ae0aa25d28"), "شنبه", 12 },
                    { 420, new Guid("27acfa5c-25e1-4f50-81b7-0471570f6bd3"), "شبانکاره", 12 },
                    { 419, new Guid("00c0737c-55b6-4408-9512-3a7a8a62a234"), "سيراف", 12 },
                    { 404, new Guid("45a5c9f1-c2d9-4603-847c-24fd39120494"), "بندر ريگ", 12 },
                    { 417, new Guid("2ee03ec2-dea5-4fa6-8be7-8eb5414cc152"), "ريز", 12 },
                    { 416, new Guid("12b1aa66-cb47-4c8e-8470-3152f0973e2a"), "دوراهک", 12 },
                    { 415, new Guid("cd07c2cf-9dd8-4c17-b770-71bb32807595"), "دلوار", 12 },
                    { 414, new Guid("81c305b8-d998-4dd6-9218-c4e6171e19e8"), "دالکي", 12 },
                    { 418, new Guid("f27f3e14-147a-40a4-894e-81c5b94bd1c2"), "سعد آباد", 12 },
                    { 412, new Guid("bd506778-ccfc-4a17-af8f-e32895207375"), "خارک", 12 },
                    { 411, new Guid("55bb1c2b-56f5-4a17-ba27-f1c4e0f8625a"), "جم", 12 },
                    { 410, new Guid("fae9147f-8f37-4def-9d2a-d39fffa376ca"), "تنگ ارم", 12 },
                    { 409, new Guid("c9c2afb7-d0ac-4094-91ba-a6bc8947ceb7"), "بوشکان", 12 },
                    { 408, new Guid("a0230a4d-46b1-4bb5-bee5-51c909bdd7ee"), "بوشهر", 12 },
                    { 407, new Guid("df0a5a10-1580-4863-98ee-66bc9306cf88"), "بنک", 12 },
                    { 406, new Guid("ed6bf6d7-c164-4749-a124-4d1206ef1209"), "بندر گناوه", 12 },
                    { 413, new Guid("e932ed8a-d0be-470c-ae06-62fef88fb8bb"), "خورموج", 12 }
                });

            migrationBuilder.InsertData(
                table: "Code",
                columns: new[] { "CodeID", "CodeGroupID", "CodeGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, 1, new Guid("65d88436-a9dd-438a-8139-8628936aecc6"), "png", "image/png" },
                    { 2, 1, new Guid("ad6eabcc-2984-42e7-ae4d-6521f00af144"), "jpg", "image/jpg" },
                    { 3, 1, new Guid("4d0748fa-215f-432a-a887-82b7069b5b9a"), "jpeg", "image/jpeg" },
                    { 7, 3, new Guid("2b451e4c-c9b8-415a-bcb4-05da15447b89"), "زن", "Female" },
                    { 5, 2, new Guid("b8423ba3-43eb-4046-93a3-9a4b42452304"), "تست 2", "Test 2" },
                    { 6, 2, new Guid("cfaa4f65-f97d-40ea-9da7-aa67cec0b0a1"), "تست 3", "Test 3" },
                    { 8, 3, new Guid("6e48b657-2c83-4481-a9c5-009ffe10158b"), "مرد", "Male" },
                    { 4, 2, new Guid("23be1227-8dfc-4b86-b74c-de114cfcd3aa"), "تست 1", "Test 1" }
                });

            migrationBuilder.InsertData(
                table: "SMSSetting",
                columns: new[] { "SMSSettingID", "ModifiedDate", "Name", "SMSProviderConfigurationID", "SMSSettingGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 10, 23, 58, 47, 626, DateTimeKind.Local).AddTicks(6116), "Kavenegar", 1, new Guid("4fbf34bb-401d-4286-af75-b09e8977d502") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryGUID", "DisplayName", "ModifiedDate", "ParentCategoryID", "Sort" },
                values: new object[,]
                {
                    { 7, new Guid("aec3abab-e3f4-4b64-957d-d3a0aa102aac"), "جوشکار صنعتی", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6579), 2, 1 },
                    { 8, new Guid("9a2f55ba-bb09-4e1f-978a-ba80728a5f8f"), "اره و نجار", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6587), 2, 2 },
                    { 9, new Guid("2e232047-d619-4f7b-8a51-a4aa066352cd"), "ساختمان", new DateTime(2020, 5, 10, 23, 58, 47, 630, DateTimeKind.Local).AddTicks(6596), 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 5, 10, 23, 58, 47, 627, DateTimeKind.Local).AddTicks(1445), "VerifyAccount", 1, new Guid("964f348a-bbd9-44a0-b953-3ea665adcb58") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "GenderCodeID", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", 8, true, true, "رودکی", new DateTime(2020, 5, 10, 23, 58, 47, 629, DateTimeKind.Local).AddTicks(2170), "09227204305", new DateTime(2020, 5, 10, 23, 58, 47, 629, DateTimeKind.Local).AddTicks(1641), 1, new Guid("45e1abcc-a3a4-42e3-814c-c5809984a1f5") },
                    { 2, "mahdiih@ymail.com", "مهدی", 8, true, true, "حکمی زاده", new DateTime(2020, 5, 10, 23, 58, 47, 629, DateTimeKind.Local).AddTicks(4520), "09199390494", new DateTime(2020, 5, 10, 23, 58, 47, 629, DateTimeKind.Local).AddTicks(4498), 1, new Guid("81f808b6-7fd4-45f4-a0a7-b814d1252695") },
                    { 3, "roozbehshamekhi@hotmail.com", "روزبه", 8, true, true, "شامخی", new DateTime(2020, 5, 10, 23, 58, 47, 629, DateTimeKind.Local).AddTicks(4563), "09128277075", new DateTime(2020, 5, 10, 23, 58, 47, 629, DateTimeKind.Local).AddTicks(4559), 1, new Guid("142156ee-5d26-4dcb-b9ed-52306d390fe5") }
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
