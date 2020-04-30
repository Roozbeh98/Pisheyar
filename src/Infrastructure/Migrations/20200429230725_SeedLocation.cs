using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pisheyar.Infrastructure.Migrations
{
    public partial class SeedLocation : Migration
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
                    { 1, new Guid("ba87232a-7062-4bf0-a67d-dc3fd52ab16c"), "سایت اصلی", new DateTime(2020, 4, 30, 3, 37, 23, 462, DateTimeKind.Local).AddTicks(7466), null, 1 },
                    { 2, new Guid("c11235e6-86e1-4ad7-8e1d-1e423dec4cbd"), "وبلاگ", new DateTime(2020, 4, 30, 3, 37, 23, 462, DateTimeKind.Local).AddTicks(8836), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "CodeGroupID", "CodeGroupGUID", "DisplayName", "Name" },
                values: new object[] { 1, new Guid("5078d273-055d-4a7a-9ead-c93b79a4c6a7"), "نوع فایل", "FilepondType" });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("22123713-51c8-49bd-9a64-5cf74f548ec3") },
                    { 20, "ايلام", new Guid("5cc86bbf-e093-4f5b-9ced-6adb8cc464f5") },
                    { 21, "تهران", new Guid("ac6eabb4-4c53-4c3b-9812-f2eab80aaf1c") },
                    { 22, "آذربايجان شرقي", new Guid("056db98c-39d6-44d2-8e49-c7b4f79bd606") },
                    { 23, "فارس", new Guid("8fbb6711-7bc0-4b4a-bb35-faf8d488f161") },
                    { 24, "کرمانشاه", new Guid("8ea73f94-fd14-4316-b442-b636f7d021fb") },
                    { 26, "مرکزي", new Guid("b37003c9-8b82-4ef7-a8a9-0d6f2dd50a24") },
                    { 18, "اردبيل", new Guid("667741d6-9da6-4359-ae84-e695073322d2") },
                    { 27, "گيلان", new Guid("75e8559b-ed1b-4dc6-95cd-aebe4649bfe4") },
                    { 28, "همدان", new Guid("1c279223-339c-4c54-bb91-ee5db404fb86") },
                    { 29, "کرمان", new Guid("d3f79f1c-be6a-4460-ac18-5bcba2312e8d") },
                    { 30, "سمنان", new Guid("4a4c52f2-0c69-442f-8c67-8188c9967dc9") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("307225e8-1106-42e0-a84a-0af8939f20b6") },
                    { 25, "هرمزگان", new Guid("53a1699d-7815-4e87-9dd9-ccb01b79df94") },
                    { 17, "لرستان", new Guid("9f323ece-b54e-476c-9709-8649c6798b99") },
                    { 16, "قزوين", new Guid("cc225ec6-8a36-49cf-aaa8-13cf999c3bbd") },
                    { 15, "مازندران", new Guid("935ef457-abcb-41ba-ae49-9b3904dddf5c") },
                    { 1, "يزد", new Guid("d9b4e82b-62a0-453c-8f8b-7ead3034cc6a") },
                    { 2, "چهار محال و بختياري", new Guid("5cd3142c-94f5-4215-87ff-021bc381cf84") },
                    { 3, "خراسان شمالي", new Guid("ffc0f066-162b-43a6-9f64-ca28639c59e6") },
                    { 4, "البرز", new Guid("00968cfc-f7ac-4aea-b700-f5dfd82fe11e") },
                    { 5, "قم", new Guid("49a9deff-7e51-4912-a0da-b604f3fe69eb") },
                    { 6, "کردستان", new Guid("93f2fb8d-b725-4e0f-8752-9f26be291340") },
                    { 7, "آذربايجان غربي", new Guid("e49b2cf6-833f-41f0-8c2f-66da41c7d85d") },
                    { 9, "سيستان و بلوچستان", new Guid("1749253c-d96a-4f07-aedc-5b77efa51f61") },
                    { 10, "خراسان جنوبي", new Guid("c44b09a0-88ca-4247-b38f-2733354eecfc") },
                    { 11, "خوزستان", new Guid("59f6bd66-ff5e-4080-ac30-f03e922f15d7") },
                    { 12, "بوشهر", new Guid("3aa6ce5a-c6f8-4d43-b0b1-f9b957458f0e") },
                    { 13, "زنجان", new Guid("10a88fd5-3fa6-4959-a6f5-764eb190310b") },
                    { 14, "گلستان", new Guid("41d505d1-936c-4f6f-b2be-af593aeb66fc") },
                    { 8, "خراسان رضوي", new Guid("7bffc6a7-d313-47c3-9b1b-29983e8b076c") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 2, "ادمین", new DateTime(2020, 4, 30, 3, 37, 23, 459, DateTimeKind.Local).AddTicks(8594), "Admin", new Guid("26573da9-105e-4c27-9fe0-6321ea85f97e") },
                    { 1, "کاربر عادی", new DateTime(2020, 4, 30, 3, 37, 23, 459, DateTimeKind.Local).AddTicks(7003), "User", new Guid("43baa512-454d-4c27-bdec-957e24c8b648") }
                });

            migrationBuilder.InsertData(
                table: "SMSProviderConfiguration",
                columns: new[] { "SMSProviderConfigurationID", "APIKey", "ModifiedDate", "Password", "SMSProviderConfigurationGUID", "Username" },
                values: new object[] { 1, "61726634455053586E44464E413462574A76535677436B547236574B56386D6A6F6E4F326A374A4C7755773D", new DateTime(2020, 4, 30, 3, 37, 23, 452, DateTimeKind.Local).AddTicks(5516), "ptcoptco", new Guid("adeea912-2a77-45db-9661-f45be8d703bf"), "ptmgroupco@gmail.com" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 621, new Guid("fa76b27c-7bd8-4b2b-b90e-16e3a84e36b9"), "بادرود", 19 },
                    { 828, new Guid("0a2f9b0b-6a6b-4aa8-b5ab-7288f12570b2"), "مراغه", 22 },
                    { 827, new Guid("9d3ea2fd-8c0a-494d-bc3c-be46d95d23f9"), "مبارک شهر", 22 },
                    { 826, new Guid("3a4514fa-38d0-469a-9400-6f52433a3add"), "ليلان", 22 },
                    { 825, new Guid("649409e0-70d4-432c-b8cd-d78a2d5a2206"), "قره آغاج", 22 },
                    { 824, new Guid("6dc0bb59-2954-46e6-b8b6-8d3227aa281b"), "عجب شير", 22 },
                    { 823, new Guid("d593b5c7-3abb-42e4-86c7-a7c80920b0d1"), "صوفيان", 22 },
                    { 822, new Guid("4e138b54-91d1-4f8e-a379-e622b3fa3c32"), "شهر جديد سهند", 22 },
                    { 821, new Guid("bb4bf791-aa02-4358-8b63-a22d00457993"), "شند آباد", 22 },
                    { 820, new Guid("4c1ee524-35b5-410c-a8d1-7d8164ae4c98"), "شرفخانه", 22 },
                    { 819, new Guid("0b79ceac-f34b-40f0-904f-42a499f32a72"), "شربيان", 22 },
                    { 818, new Guid("23ba072b-8c9f-426b-8398-300c055ef89d"), "شبستر", 22 },
                    { 817, new Guid("30420c35-5437-4d90-b747-7f473bce2e1f"), "سيه رود", 22 },
                    { 816, new Guid("52d459b7-ec19-400d-ab30-7f5bc3ab2f69"), "سيس", 22 },
                    { 815, new Guid("8ac11aa4-1927-4f77-99af-dff8bd20f017"), "سردرود", 22 },
                    { 814, new Guid("577c3b81-0f57-4652-a1b7-632d7f96c999"), "سراب", 22 },
                    { 829, new Guid("6fae652d-ad34-4c97-a5b0-e03d908cf2a4"), "مرند", 22 },
                    { 813, new Guid("8ecb80a0-cbd7-40fe-8e86-4b594dd01610"), "زنوز", 22 },
                    { 830, new Guid("0ab031fd-7248-452b-bd5f-dbea3ca527a5"), "ملکان", 22 },
                    { 832, new Guid("1f980b83-52ed-4678-8233-11c417fdfc01"), "مهربان", 22 },
                    { 847, new Guid("49dc442b-ed31-4e87-9beb-a88ce7a2d4db"), "آباده", 23 },
                    { 846, new Guid("22ca2e70-dc42-4c4b-b136-ca0e04809b08"), "گوگان", 22 },
                    { 845, new Guid("7857dbc1-a7f1-4efe-8732-da38c7630374"), "کوزه کنان", 22 },
                    { 844, new Guid("5ffb8a3e-57d3-4bc3-a15c-22e8f76097cf"), "کليبر", 22 },
                    { 843, new Guid("b518de87-ef21-4aad-97b3-bbf6ac643f34"), "کلوانق", 22 },
                    { 842, new Guid("79d6931a-efee-4198-8a22-e71ac0341860"), "کشکسراي", 22 },
                    { 841, new Guid("e58b5423-fcf0-41fb-ac89-587b4865c88a"), "يامچي", 22 },
                    { 840, new Guid("ef75c499-5c56-44d6-ba01-714ca3252fe5"), "ورزقان", 22 },
                    { 839, new Guid("97e2089f-0e9a-4054-9c89-f458f71aa230"), "وايقان", 22 },
                    { 838, new Guid("576eef21-a27e-4ecb-a2da-db3d5f33e442"), "هوراند", 22 },
                    { 837, new Guid("5cbfe150-2f49-4e3f-9b04-ec0765a6e311"), "هشترود", 22 },
                    { 836, new Guid("f55f1257-028b-40ce-a1f6-c9911f88edb3"), "هريس", 22 },
                    { 835, new Guid("740db43a-9ca3-45e3-87b9-df48974a3324"), "هاديشهر", 22 },
                    { 834, new Guid("6e2a5b57-e1d3-414f-b8fa-85f60f08f081"), "نظرکهريزي", 22 },
                    { 833, new Guid("2122867c-5b11-4412-b7a0-676fb05e86b3"), "ميانه", 22 },
                    { 831, new Guid("07901723-6abd-4de0-9cb3-f506a2301804"), "ممقان", 22 },
                    { 812, new Guid("441412e4-aecc-4cc8-9db4-1c919a50f6b5"), "زرنق", 22 },
                    { 811, new Guid("afa604f7-600d-420a-bdfc-526c47509b94"), "دوزدوزان", 22 },
                    { 810, new Guid("68c1b6af-e948-44f0-a8e6-39a5ded9168c"), "خواجه", 22 },
                    { 789, new Guid("259b0338-4818-487c-947f-59ea8c029e43"), "اسکو", 22 },
                    { 788, new Guid("392d5cc9-e01a-4a4e-9425-f6b11404c45c"), "آچاچي", 22 },
                    { 787, new Guid("1b6d6480-5adb-40ea-8cf7-358d175acb0f"), "آقکند", 22 },
                    { 786, new Guid("5db07412-a052-4450-9219-505e3be80b97"), "آذرشهر", 22 },
                    { 785, new Guid("7fc6ffc6-d225-4696-bf6f-ccb1e424d993"), "آبش احمد", 22 },
                    { 784, new Guid("74268663-7f00-4032-8111-71967bf08b66"), "گلستان", 21 },
                    { 783, new Guid("3b9ecdc3-74bf-4024-8104-3f0f33de5e48"), "کيلان", 21 },
                    { 782, new Guid("2448e4e6-52fa-4711-95c7-2670b5bf624a"), "کهريزک", 21 },
                    { 781, new Guid("c6e73ec4-9bcd-44b1-958e-e601ea58a809"), "چهاردانگه", 21 },
                    { 780, new Guid("ba6bba10-18e9-47fd-98e5-2abd8b335f17"), "پيشوا", 21 },
                    { 779, new Guid("5dd1e086-0d20-42c8-8b10-3339536b442e"), "پرديس", 21 },
                    { 778, new Guid("b231c39b-6908-4f3a-beea-05641a830ef3"), "پاکدشت", 21 },
                    { 777, new Guid("1de23dd9-4722-4946-9641-638f8b5d2e33"), "ورامين", 21 },
                    { 776, new Guid("79e88552-e161-4cfc-834b-beb39962ba57"), "وحيديه", 21 },
                    { 775, new Guid("73449ff5-ec69-408f-9fa9-b2a0d1e731e0"), "نصيرشهر", 21 },
                    { 790, new Guid("54a29af4-270c-4939-bda8-ff12629eda95"), "اهر", 22 },
                    { 791, new Guid("a5896ae6-8d05-4a6f-82d3-8f302daa9550"), "ايلخچي", 22 },
                    { 792, new Guid("b03bad19-0736-4295-9282-76c504fa9012"), "باسمنج", 22 },
                    { 793, new Guid("145e3320-f3ff-445c-bd70-ff78fa0f4ae5"), "بخشايش", 22 },
                    { 809, new Guid("621540d6-2dd0-4ba9-83f4-921c15ddbe45"), "خمارلو", 22 },
                    { 808, new Guid("4e7889c0-23e7-4688-a03f-26c3ddffe847"), "خسروشاه", 22 },
                    { 807, new Guid("adcc55d6-4307-4cd2-a9b1-5bd3ef5c8183"), "خداجو", 22 },
                    { 806, new Guid("87a3d755-59ed-4cc3-9a11-e5fc3663eceb"), "خامنه", 22 },
                    { 805, new Guid("7a174f2e-2a14-46c3-9570-65dc99354e4d"), "خاروانا", 22 },
                    { 804, new Guid("9650b11c-0f1b-4090-a379-f49476889cd3"), "جوان قلعه", 22 },
                    { 803, new Guid("40316c62-0a2c-4b67-858f-a7e1657bd278"), "جلفا", 22 },
                    { 848, new Guid("402eccd4-3a9d-44ac-ac66-560a5ca4775b"), "آباده طشک", 23 },
                    { 802, new Guid("47eaa1fe-6b12-4757-b1f0-666783072c77"), "تيکمه داش", 22 },
                    { 800, new Guid("e9d1b33e-1778-4fe9-be78-cc1449394341"), "تسوج", 22 },
                    { 799, new Guid("7be9c7e5-d8f6-4cf7-b167-d4daa74bb03b"), "ترکمانچاي", 22 },
                    { 798, new Guid("a2ba88f1-756c-4437-9081-017b29c754a5"), "ترک", 22 },
                    { 797, new Guid("81f49d1f-a439-4ce0-81d8-db5e3657823d"), "تبريز", 22 },
                    { 796, new Guid("fedbebc2-2436-4312-83fa-b83b93176381"), "بناب مرند", 22 },
                    { 795, new Guid("2f92abdc-58c3-4137-a233-7d7b84230f93"), "بناب", 22 },
                    { 794, new Guid("e8c0a12a-126d-448c-bd74-bf1cc86e5743"), "بستان آباد", 22 },
                    { 801, new Guid("66380770-0671-43b0-95cc-273cfc726c1d"), "تيمورلو", 22 },
                    { 849, new Guid("5a6b0338-9d84-4992-95e6-908cd35fd43e"), "اردکان", 23 },
                    { 850, new Guid("a47049c2-94cd-479c-9943-e6f888ac6380"), "ارسنجان", 23 },
                    { 851, new Guid("4b95d494-874d-4ea6-84e8-ae7aa97ea66b"), "استهبان", 23 },
                    { 905, new Guid("83e00b68-ee61-454a-a751-dc5685f44654"), "صغاد", 23 },
                    { 904, new Guid("b0796ffa-3ee6-4b91-b3e3-bd3c82a1ec5b"), "شيراز", 23 },
                    { 903, new Guid("6f4a2465-9bf0-42d1-b374-aefd4d7162dc"), "شهر پير", 23 },
                    { 902, new Guid("08a1a9ec-78cc-4fa3-bd0b-f019c3178e1c"), "شهر جديد صدرا", 23 },
                    { 901, new Guid("9e68ae0e-715d-425a-a3b2-87619750bf24"), "ششده", 23 },
                    { 900, new Guid("b675753f-6fb3-426b-866e-20cf3c29340f"), "سيدان", 23 },
                    { 899, new Guid("63faf51d-1cc3-471a-a485-98fa70a2bd8c"), "سورمق", 23 },
                    { 898, new Guid("5c4c596b-5086-4bf5-b874-53332b3438fc"), "سلطان شهر", 23 },
                    { 897, new Guid("ba03942b-fe8c-4468-9396-197f75f7c41e"), "سعادت شهر", 23 },
                    { 896, new Guid("9ce5ef39-2154-42a2-b438-2a214bc1570a"), "سروستان", 23 },
                    { 895, new Guid("c439ce7e-013e-44b2-bb7a-17707a7d2616"), "سده", 23 },
                    { 894, new Guid("b84a97cb-1f98-4b50-a201-3a9e05ed1e39"), "زرقان", 23 },
                    { 893, new Guid("124a5fb2-aaf0-4255-8feb-ec800d29cac6"), "زاهد شهر", 23 },
                    { 892, new Guid("806c7e10-85bf-4c3a-a171-e58b0eb60ee3"), "رونيز", 23 },
                    { 891, new Guid("75a3186a-ffc3-4682-bbe7-d6fae8828a26"), "رامجرد", 23 },
                    { 906, new Guid("f52764e7-7df6-4bbd-96d6-3de8f53a82db"), "صفا شهر", 23 },
                    { 907, new Guid("e219fc1c-42be-4952-a398-d712d5ff7e3e"), "علامرودشت", 23 },
                    { 908, new Guid("710ef467-6997-483e-8060-6ff6e48fb11b"), "عماد ده", 23 },
                    { 909, new Guid("907e753a-590c-41a7-afb1-a33d7d58c0b1"), "فدامي", 23 },
                    { 925, new Guid("2989099d-2121-489c-857b-afcd7d3c1657"), "مرودشت", 23 },
                    { 924, new Guid("7ee4ed8b-f3a2-4859-bdd1-38c039d46678"), "مبارک آباد", 23 },
                    { 923, new Guid("968a4ca3-46f6-41df-aa0a-3b5e051111c8"), "مادرسليمان", 23 },
                    { 922, new Guid("dd438c25-e535-41ed-a7df-f1b1f8404ab8"), "لپوئي", 23 },
                    { 921, new Guid("6e675635-330f-402d-9717-8012dfd4116e"), "لطيفي", 23 },
                    { 920, new Guid("0761ddd3-e90c-49be-a6b2-5f4b7d39b539"), "لامرد", 23 },
                    { 919, new Guid("a9e60ea2-bf8f-4d52-8bcb-6cd545038fd1"), "لار", 23 },
                    { 890, new Guid("6db3e0dd-4456-48fe-ab0e-6380fcb55ed8"), "دژکرد", 23 },
                    { 918, new Guid("1088b1bc-28e1-4b52-bcbc-c78fdd8cfd29"), "قير", 23 },
                    { 916, new Guid("8c87adbd-4ffb-4b74-b49f-e0e997098f3e"), "قطب آباد", 23 },
                    { 915, new Guid("16856bfa-2a0b-480f-ac99-fe2bac295562"), "قره بلاغ", 23 },
                    { 914, new Guid("659f6efe-68e4-4c5e-a5fe-748ff430b194"), "قادرآباد", 23 },
                    { 913, new Guid("0dc81b33-ef9b-487a-90dd-14095cfc4456"), "قائميه", 23 },
                    { 912, new Guid("dcd4b5c6-a9ca-4b10-a5a4-dea725273f9b"), "فيروزآباد", 23 },
                    { 911, new Guid("131c94e7-9b3f-4706-acdf-cc4231f114b6"), "فسا", 23 },
                    { 910, new Guid("1f1dd755-b9b7-4834-9801-a92f7214c760"), "فراشبند", 23 },
                    { 917, new Guid("7a8befbb-1039-42de-8d88-0605d3146be7"), "قطرويه", 23 },
                    { 774, new Guid("b2312efd-5554-4ab4-b704-057b5b66dd83"), "نسيم شهر", 21 },
                    { 889, new Guid("75ad8923-d563-4237-bd29-f0c3bf80a412"), "دوزه", 23 },
                    { 887, new Guid("a218a719-65b8-4fcb-a81f-46624aea321b"), "دهرم", 23 },
                    { 866, new Guid("c1140a88-ed0b-474e-8b27-14726712e35e"), "بوانات", 23 },
                    { 865, new Guid("6b51f86f-23cc-403f-8529-02ff38b29ec4"), "بهمن", 23 },
                    { 864, new Guid("60f58e0d-ffff-4184-88b2-1266bba97842"), "بنارويه", 23 },
                    { 863, new Guid("9a1a6f44-3692-4c4d-9c91-ba093f3dd679"), "بالاده", 23 },
                    { 862, new Guid("d3c0a5d9-f5ca-4bd7-813c-25bcf48c3665"), "بابامنير", 23 },
                    { 861, new Guid("8f9d6d05-5cee-4912-820d-2df2fc681de6"), "باب انار", 23 },
                    { 860, new Guid("a80efc0a-7364-4d38-832a-16a365d00bbc"), "ايزد خواست", 23 },
                    { 859, new Guid("8256f0e8-c7c1-473b-b27b-ec8e08712786"), "ايج", 23 },
                    { 858, new Guid("fba67a09-9d46-42a8-9df7-f1a7376d5566"), "اوز", 23 },
                    { 857, new Guid("fd61bf59-3c1a-4afb-aa52-c144ba3aaff1"), "اهل", 23 },
                    { 856, new Guid("bebc2d2d-43ba-4e13-8b90-5a32163ef46c"), "امام شهر", 23 },
                    { 855, new Guid("4cb0a53a-fb63-4b7d-8deb-cccf83fe04ed"), "اقليد", 23 },
                    { 854, new Guid("c53bb9dc-d3cb-4af5-8cff-24b051438019"), "افزر", 23 },
                    { 853, new Guid("322c68ef-0055-4790-a58f-082a4daded73"), "اشکنان", 23 },
                    { 852, new Guid("58ef9555-cd7d-47b3-9769-e1d1320369e7"), "اسير", 23 },
                    { 867, new Guid("a8f35f82-bdb4-48fc-accf-1387ef4c23ae"), "بيرم", 23 },
                    { 868, new Guid("fc4c2cc0-aa33-4d07-b353-a64e7b6123e1"), "بيضا", 23 },
                    { 869, new Guid("a9e5e1d2-7a98-454b-908d-88fdccb1634e"), "جنت شهر", 23 },
                    { 870, new Guid("42147b86-7891-4e77-a5b0-180fdb50194e"), "جهرم", 23 },
                    { 886, new Guid("9051ae75-64b0-4cae-bcb4-1b0fc6c3acc5"), "دبيران", 23 },
                    { 885, new Guid("6fd017a8-eaa2-45ea-99d1-692ca2cf35e5"), "داريان", 23 },
                    { 884, new Guid("410deee0-92e6-4bb1-bf57-1e473b7f349b"), "داراب", 23 },
                    { 883, new Guid("668a2660-c00e-4cb5-9b21-22ef7a48eb20"), "خومه زار", 23 },
                    { 882, new Guid("d4e2f932-0d58-4d6b-bb77-1c6b4f7cb9ce"), "خوزي", 23 },
                    { 881, new Guid("4d3f3baf-5d9b-441c-bd4c-bda2bf4fcf71"), "خور", 23 },
                    { 880, new Guid("3e417053-32a8-4e59-8471-e66a08d7f8db"), "خنج", 23 },
                    { 888, new Guid("85201612-eaf0-457e-8da9-73cdaad90350"), "دوبرجي", 23 },
                    { 879, new Guid("0eabb224-a658-42fb-ba24-54b59888755c"), "خشت", 23 },
                    { 877, new Guid("3926b6d4-b462-40b7-b0e1-0bed3039783b"), "خاوران", 23 },
                    { 876, new Guid("8716a9ca-de5b-415c-9a11-143eb9890181"), "خانيمن", 23 },
                    { 875, new Guid("da06ea96-8895-4246-83f5-abc5f7a0ec09"), "خانه زنيان", 23 },
                    { 874, new Guid("0ad6a1c9-3827-43b6-8db0-1a9c339fa093"), "حسن آباد", 23 },
                    { 873, new Guid("aadb31de-2424-46ab-b401-642a706db150"), "حسامي", 23 },
                    { 872, new Guid("21548ee4-2c6f-408d-af51-cde00ef138e3"), "حاجي آباد", 23 },
                    { 871, new Guid("1ecfd405-3207-47c5-b360-ead55202a201"), "جويم", 23 },
                    { 878, new Guid("69c325f7-945c-41fc-bf15-e430eefe54e1"), "خرامه", 23 },
                    { 926, new Guid("cc31eca1-0cf8-4195-8dfb-9c24d0d03259"), "مزايجان", 23 },
                    { 773, new Guid("871e4b2f-abce-4ecc-aecf-a7c109828c8b"), "ملارد", 21 },
                    { 771, new Guid("aecd0867-b67a-453d-8b6a-448ce8be7e80"), "قرچک", 21 },
                    { 673, new Guid("145021de-50dd-4e40-a46d-5613acfb20fa"), "فلاورجان", 19 },
                    { 672, new Guid("b0878673-facb-4342-9bbb-aae484ea1876"), "فريدونشهر", 19 },
                    { 671, new Guid("590d7548-4766-4f6c-a5f7-31e19f68da70"), "فرخي", 19 },
                    { 670, new Guid("0184b0bd-05ab-40e3-b9f0-e59745c0d616"), "علويچه", 19 },
                    { 669, new Guid("61634f5d-b8b6-4713-b5a0-a3f34c8917d9"), "عسگران", 19 },
                    { 668, new Guid("8e36b4e0-32aa-46e8-8967-26a289f1d9ba"), "طرق رود", 19 },
                    { 667, new Guid("6c57c121-a168-4581-a905-f0a96545a20d"), "طالخونچه", 19 },
                    { 666, new Guid("f183fd41-c228-4813-b64b-52ca01ef2815"), "شهرضا", 19 },
                    { 665, new Guid("f5a32bf3-8091-4740-b71b-5d27861af023"), "شاپورآباد", 19 },
                    { 664, new Guid("7a808028-e4c7-4326-b15d-3bbd79328fe7"), "شاهين شهر", 19 },
                    { 663, new Guid("d8010411-57ac-494d-b1c4-b589581b209a"), "سگزي", 19 },
                    { 662, new Guid("e7239cbd-3744-44fc-b6ad-cfb5e801cad1"), "سين", 19 },
                    { 661, new Guid("21c72f48-1e29-4117-bd3b-9706acdf5c11"), "سميرم", 19 },
                    { 660, new Guid("bc7d6fcf-8584-4544-af65-42dcdf2a874c"), "سفيد شهر", 19 },
                    { 659, new Guid("550e4bff-3445-4193-ad5e-a0e49736269e"), "سده لنجان", 19 },
                    { 674, new Guid("58f4ce93-143e-4154-87f4-47766cfbd828"), "فولاد شهر", 19 },
                    { 658, new Guid("83b06119-f296-4856-ab86-1739f960a5ee"), "زيباشهر", 19 },
                    { 675, new Guid("790ba8e3-b4f7-43e3-a20b-643c38fd094a"), "قمصر", 19 },
                    { 677, new Guid("6c1af2da-010a-4bb3-93fc-4667268d1e42"), "قهدريجان", 19 },
                    { 692, new Guid("6cae021f-46ec-4811-bc84-2b4e8192e0b5"), "هرند", 19 },
                    { 691, new Guid("36cbca83-f365-4493-862b-228950f99ee9"), "نيک آباد", 19 },
                    { 690, new Guid("a231e99b-bd7e-45c0-9691-19db0b332076"), "نياسر", 19 },
                    { 689, new Guid("fa7f3c17-c2e7-4a7d-8f70-11d1e3009833"), "نوش آباد", 19 },
                    { 688, new Guid("44d4d931-71ba-4258-8313-a0d7f15c2236"), "نطنز", 19 },
                    { 687, new Guid("ac27d482-f2a9-4a21-8f7a-14ca158b0732"), "نصرآباد", 19 },
                    { 686, new Guid("cb10005d-1310-4906-b087-435ef3b29d50"), "نجف آباد", 19 },
                    { 685, new Guid("e45d6d25-e4b6-4986-92a1-d8ff0c2b8ebd"), "نائين", 19 },
                    { 684, new Guid("4e1e124f-7bf1-4cbf-8410-5aa2feb631c7"), "ميمه", 19 },
                    { 683, new Guid("b7878be7-7267-47a5-b2bf-8e31eced9dd8"), "مهاباد", 19 },
                    { 682, new Guid("9ad65c6e-ebde-495b-ac6d-c9a078654306"), "منظريه", 19 },
                    { 681, new Guid("7fe362e6-25f4-4ec7-af25-176da4dca081"), "مشکات", 19 },
                    { 680, new Guid("88ce62d4-0473-48ba-9ac3-80ed5c68df93"), "محمد آباد", 19 },
                    { 679, new Guid("68cb5b3a-9116-4178-b2d5-8f4d65a4d053"), "مبارکه", 19 },
                    { 678, new Guid("c841c856-43eb-4154-a97f-d8315fb8b73c"), "لاي بيد", 19 },
                    { 676, new Guid("65f42f52-3387-4d01-b358-80f0e0ef78ec"), "قهجاورستان", 19 },
                    { 657, new Guid("07b341f6-2d10-4ca5-af8d-16351c4a0904"), "زيار", 19 },
                    { 656, new Guid("d7240cc5-38cf-4c5f-a962-cc4a764560c7"), "زواره", 19 },
                    { 655, new Guid("d286a009-ad39-423a-aca3-30d8435851b0"), "زرين شهر", 19 },
                    { 634, new Guid("59fb04ca-04d2-4ef9-a929-ee85b01f7e8b"), "جوشقان قالي", 19 },
                    { 633, new Guid("f8ae4ba7-e078-4e2a-8dea-0c9454da9d3b"), "جوزدان", 19 },
                    { 632, new Guid("8fef2dd2-28a3-4525-9aaa-82270c0f6a64"), "جندق", 19 },
                    { 631, new Guid("47576ea0-2fdc-4f00-bf44-29b26e8138b7"), "تيران", 19 },
                    { 630, new Guid("73828fe3-cb06-4191-9176-a0203b3c3b83"), "تودشک", 19 },
                    { 629, new Guid("ae91939e-2a7f-446c-b303-30a1f11f3195"), "بوئين مياندشت", 19 },
                    { 628, new Guid("7d1fcc4e-96c8-48bf-afb2-6a3383853474"), "بهارستان", 19 },
                    { 627, new Guid("a2ee3201-0968-44f3-aea1-8a795412668f"), "بهاران شهر", 19 },
                    { 626, new Guid("b31f6865-f216-47b2-a546-82f71b19e591"), "برف انبار", 19 },
                    { 625, new Guid("045b17a9-38fe-46ba-9260-d8d8bc08fc38"), "برزک", 19 },
                    { 624, new Guid("bded242e-2a01-4696-82ab-6d4ed946fa49"), "بافران", 19 },
                    { 623, new Guid("b99a7f29-2fff-48a1-b7e7-08f42f4a9263"), "باغشاد", 19 },
                    { 622, new Guid("ab0bd81f-53b9-4ec6-916b-3f20c8334a1b"), "باغ بهادران", 19 },
                    { 1239, new Guid("1d797306-433d-434d-9503-73c5961da48e"), "چرام", 31 },
                    { 620, new Guid("32fa23b7-7408-4f88-82d6-07be04d5095a"), "اژيه", 19 },
                    { 635, new Guid("94597a95-e568-4308-9949-dff8b4283404"), "حبيب آباد", 19 },
                    { 636, new Guid("eadd6952-5611-485d-a405-3d77ac9bc8f8"), "حسن آباد", 19 },
                    { 637, new Guid("efc66930-351e-4a7a-8618-5929e2d0a095"), "حنا", 19 },
                    { 638, new Guid("0aa095dc-5853-4a28-a6f4-3e91aac73deb"), "خالد آباد", 19 },
                    { 654, new Guid("9da92e72-5253-4741-9d70-a4295ef6940f"), "زاينده رود", 19 },
                    { 653, new Guid("37321ae9-4f22-43ce-a8f1-dab2183d8526"), "زازران", 19 },
                    { 652, new Guid("ac7d58a9-3d43-4ac3-a44e-e736faa4b298"), "رضوانشهر", 19 },
                    { 651, new Guid("17ad5e18-48ef-42c6-a9b6-cc56609b1339"), "رزوه", 19 },
                    { 650, new Guid("ff5f1637-9cd0-4402-87af-3c15048c6ed2"), "ديزيچه", 19 },
                    { 649, new Guid("b1b30d12-6512-4944-8103-4ae65d192492"), "دولت آباد", 19 },
                    { 648, new Guid("d9f5f19d-2f83-4559-b346-c4f7555d2cc5"), "دهق", 19 },
                    { 693, new Guid("2e484014-4dde-41b2-9623-2fcf3d273a4b"), "ورزنه", 19 },
                    { 647, new Guid("fd1873ce-e59b-450a-a04f-fa570336e36d"), "دهاقان", 19 },
                    { 645, new Guid("1ba46a19-853c-4a4d-bb0f-c56d56a5ab5a"), "درچه پياز", 19 },
                    { 644, new Guid("de6a1612-7003-49c7-996c-42bcb83f4e0a"), "دامنه", 19 },
                    { 643, new Guid("48926773-d26d-45e4-a7af-72f5fa1516cc"), "داران", 19 },
                    { 642, new Guid("3905d67c-64e0-4e0a-8024-84638d9857c7"), "خورزوق", 19 },
                    { 641, new Guid("a0a9b330-5b10-4f2a-8a1f-b06992236d22"), "خور", 19 },
                    { 640, new Guid("7cca3433-e417-4f7c-8471-c16b72c6a0c4"), "خوانسار", 19 },
                    { 639, new Guid("7568bfeb-7e09-4876-827f-9ec3cb37fc4f"), "خميني شهر", 19 },
                    { 646, new Guid("b7d3ebfa-3724-4bc8-9fc4-6a66c7b3b1cd"), "دستگرد", 19 },
                    { 694, new Guid("6cf02f7e-3bc1-4795-882b-62b0b0f4836b"), "ورنامخواست", 19 },
                    { 695, new Guid("d5a83c3d-da63-47ec-8698-39a1cccd11b1"), "وزوان", 19 },
                    { 696, new Guid("19b77ab4-ec0a-4f6c-b212-b014ffe9134e"), "ونک", 19 },
                    { 750, new Guid("5978a104-e3b4-44db-945a-725dd22acae0"), "تجريش", 21 },
                    { 749, new Guid("a08f6df8-e807-4097-8383-bf9c24c1d802"), "بومهن", 21 },
                    { 748, new Guid("19fb8ba3-e759-4ec6-9f4d-2680f32cd372"), "باقرشهر", 21 },
                    { 747, new Guid("73326d7f-af12-49ac-8d6e-44b61c4931d6"), "باغستان", 21 },
                    { 746, new Guid("7cdf1b3a-a739-4be6-8629-71c2be992098"), "انديشه", 21 },
                    { 745, new Guid("6e119a1a-ea7a-46c8-b8c2-4017bfba768e"), "اسلامشهر", 21 },
                    { 744, new Guid("3e7ac765-4fce-4ec2-9290-d188e3f494b0"), "ارجمند", 21 },
                    { 743, new Guid("3ef04439-72da-476b-a75f-0f6e2bb3b44a"), "آبعلي", 21 },
                    { 742, new Guid("bf522d46-6d8c-4d2b-9fa6-46782dd85238"), "آبسرد", 21 },
                    { 741, new Guid("8a42a2dc-a6be-450e-81cb-2fe4357019e4"), "چوار", 20 },
                    { 740, new Guid("5585ad97-a31c-45ea-a705-e74c9227f462"), "پهله", 20 },
                    { 739, new Guid("fa19d922-8fba-4d9f-b2a8-c27cc7c7ca81"), "ميمه", 20 },
                    { 738, new Guid("eb43cbf6-573d-4357-85ab-1495d5948173"), "موسيان", 20 },
                    { 737, new Guid("60504101-aea9-4165-9c3e-ca019ade1109"), "مورموري", 20 },
                    { 736, new Guid("25244b5a-31a6-4207-b3bf-05a1154fa7ed"), "مهران", 20 },
                    { 751, new Guid("d9854e18-b577-4e64-86c5-6c0994ab266c"), "تهران", 21 },
                    { 752, new Guid("b93e0e2d-f59f-4296-b1ce-262df341e590"), "جواد آباد", 21 },
                    { 753, new Guid("bb4ec6fb-06c4-44c0-bcca-efe3a398f53a"), "حسن آباد", 21 },
                    { 754, new Guid("91aedac4-df3c-4988-b431-a8cd9d08ab04"), "دماوند", 21 },
                    { 770, new Guid("136fb9fd-3053-45f6-9942-f840734f7124"), "قدس", 21 },
                    { 769, new Guid("3c4bad8a-9643-4677-9604-b3a5b90270b9"), "فيروزکوه", 21 },
                    { 768, new Guid("591bca21-086e-4d7b-961e-eefec6e58d07"), "فشم", 21 },
                    { 767, new Guid("322b1fc8-6f96-475e-9c4d-1f3fdc7e20f2"), "فرون آباد", 21 },
                    { 766, new Guid("69828fb2-b637-49d3-abdc-6a65fc61e0e0"), "فردوسيه", 21 },
                    { 765, new Guid("f0417765-4ac1-4857-8e7e-de4fbb77590c"), "صفادشت", 21 },
                    { 764, new Guid("e3641d2e-720d-4e62-8d0f-d0566d1fb6e3"), "صبا شهر", 21 },
                    { 735, new Guid("857de6ed-e1dd-4c53-914e-19e74dd2b977"), "مهر", 20 },
                    { 763, new Guid("9c8ceea7-db85-40f9-b988-72f2171bc7fa"), "صالحيه", 21 },
                    { 761, new Guid("1b6ccb4d-8d92-4dec-8566-1553ca2cd6e3"), "شهر جديد پرند", 21 },
                    { 760, new Guid("1601b4d6-215b-4a0a-a6c0-dc7ec563e581"), "شمشک", 21 },
                    { 759, new Guid("8bc56de2-dc63-4592-9025-812ff8209d93"), "شريف آباد", 21 },
                    { 758, new Guid("2115862f-b821-4128-baba-a379de6f2c4e"), "شاهدشهر", 21 },
                    { 757, new Guid("93a6f642-a9f6-4c49-92bf-d92f533c9ecb"), "ري", 21 },
                    { 756, new Guid("3742f26f-f852-48c8-9ea1-ab20c85fb93a"), "رودهن", 21 },
                    { 755, new Guid("b97d9358-b13e-4a68-adc6-8f00f8ab7a1c"), "رباط کريم", 21 },
                    { 762, new Guid("4cac7e49-dcd5-4bab-bad1-6cc841b63712"), "شهريار", 21 },
                    { 772, new Guid("fac952bd-28e5-4c53-ba97-a5363142a984"), "لواسان", 21 },
                    { 734, new Guid("8a2c95d4-adef-452b-ac07-fc97ed60e86b"), "ماژين", 20 },
                    { 732, new Guid("142dd3fe-26e2-4f64-b2b6-40d81ed3f1a6"), "صالح آباد", 20 },
                    { 711, new Guid("19b9a87d-2147-469e-8374-5b64d726c269"), "گز برخوار", 19 },
                    { 710, new Guid("58614f9c-1b2a-4f18-bc8a-661289858c0b"), "گرگاب", 19 },
                    { 709, new Guid("b05920c0-c53e-4678-9637-3436ee270716"), "کوهپايه", 19 },
                    { 708, new Guid("d205b19d-2d64-4bcf-bbf9-ab82153d3984"), "کوشک", 19 },
                    { 707, new Guid("12a1d423-80ad-44d3-a1e7-e9b265745a2a"), "کهريزسنگ", 19 },
                    { 706, new Guid("3462c50f-1682-4fa0-9a84-f525c672af91"), "کمه", 19 },
                    { 705, new Guid("19843b17-9a64-4b3d-8a5c-e71b189488b0"), "کمشجه", 19 },
                    { 704, new Guid("1f1ec99b-df1c-45ec-ae22-0e9ef750bc81"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("14bba0ea-694d-40fc-963b-21a0be9e210a"), "کرکوند", 19 },
                    { 702, new Guid("803eb6ea-69c8-4394-8c7f-6c73c10e68f6"), "کامو و چوگان", 19 },
                    { 701, new Guid("f55e3df2-39e2-4f6a-9071-9477fba6614e"), "کاشان", 19 },
                    { 700, new Guid("6b0fc489-0bb5-4be3-8d00-5ae11a2a8d8a"), "چمگردان", 19 },
                    { 699, new Guid("eab97b86-aa3c-4b64-b648-f374ab5226d2"), "چرمهين", 19 },
                    { 698, new Guid("f861dc54-773c-450c-b3c5-e9985487ba7e"), "چادگان", 19 },
                    { 697, new Guid("17b83159-a76d-4502-8267-4434497cf587"), "پير بکران", 19 },
                    { 712, new Guid("58b940ec-bfc0-4631-843d-ef9130be8a80"), "گلدشت", 19 },
                    { 713, new Guid("ccf28128-71bd-4235-b1dd-3ac1fdbbda15"), "گلشن", 19 },
                    { 714, new Guid("c9fa5455-4870-4673-a5e9-e37018a68449"), "گلشهر", 19 },
                    { 715, new Guid("a904792d-dabb-4a7c-a47f-c6af4be3212b"), "گلپايگان", 19 },
                    { 731, new Guid("4224edc6-e735-4f7a-81a2-5e3174176693"), "شباب", 20 },
                    { 730, new Guid("637cf5db-45ed-4e4b-89d0-fb741e1aba49"), "سرابله", 20 },
                    { 729, new Guid("af827e45-7f2c-4c23-9018-c72408b9c710"), "سراب باغ", 20 },
                    { 728, new Guid("5626fb2f-63a6-44ab-b612-0a437fb922af"), "زرنه", 20 },
                    { 727, new Guid("cdcc6de2-7cd7-4253-babb-e0d04eb9ec67"), "دهلران", 20 },
                    { 726, new Guid("858ddf6c-0024-4bc2-a306-6a37dcb46b63"), "دلگشا", 20 },
                    { 725, new Guid("9abbbb3f-214c-40b5-ab60-2382a09059de"), "دره شهر", 20 },
                    { 733, new Guid("f1c877ca-22ff-4634-a2dc-3f8c002a29fd"), "لومار", 20 },
                    { 724, new Guid("c8768d39-55a6-42fa-8d49-4eda3e597fe8"), "توحيد", 20 },
                    { 722, new Guid("e7cb7377-bc56-463a-a213-c4d86b35fc2b"), "بدره", 20 },
                    { 721, new Guid("ee4a563f-6a0c-4d20-9ff6-8838fbcf6e89"), "ايوان", 20 },
                    { 720, new Guid("a641c962-545a-4726-af99-fe629498cdd2"), "ايلام", 20 },
                    { 719, new Guid("97a4008a-a012-4aac-9890-5a0b63508104"), "ارکواز", 20 },
                    { 718, new Guid("351c32b8-a2cb-4a35-b510-5da676e810ec"), "آسمان آباد", 20 },
                    { 717, new Guid("a17c9e4f-d5ab-4768-a279-66fdeb366ab2"), "آبدانان", 20 },
                    { 716, new Guid("c3123497-d37e-4549-9c7e-05b1dbbe9de2"), "گوگد", 19 },
                    { 723, new Guid("2033be88-3ec6-464d-bc41-6842839373c7"), "بلاوه", 20 },
                    { 927, new Guid("01da7aad-85a3-4fd4-8a2d-4f5a212af5b0"), "مشکان", 23 },
                    { 928, new Guid("ad263837-e44e-4e3c-bf39-2f6c80d1aced"), "مصيري", 23 },
                    { 929, new Guid("7094a5bd-e248-4bd0-9567-77547e49b384"), "مهر", 23 },
                    { 1139, new Guid("48cb443f-0ea9-438c-a212-2f70a67fc902"), "باغين", 29 },
                    { 1138, new Guid("67f9d1c8-fdca-4daa-9588-e227440ca847"), "اندوهجرد", 29 },
                    { 1137, new Guid("682ce384-063a-4f52-8b62-07e7250aa06e"), "انار", 29 },
                    { 1136, new Guid("5e9f581b-52e6-4d39-908f-820cad20798f"), "امين شهر", 29 },
                    { 1135, new Guid("679e8286-fbce-4568-a6aa-d17d3a426372"), "ارزوئيه", 29 },
                    { 1134, new Guid("18c2e712-0be5-4cd2-a750-c451c3d9ee96"), "اختيار آباد", 29 },
                    { 1133, new Guid("15e153fc-1f76-4f7d-9437-60d7eb623f3a"), "گيان", 28 },
                    { 1132, new Guid("859cec82-cd41-439b-85ae-0d1bab907b74"), "گل تپه", 28 },
                    { 1131, new Guid("92ceb07d-42cb-4d69-83ea-e93a0aee4666"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("c9401980-0125-499d-90aa-381cb15fbdf7"), "همدان", 28 },
                    { 1129, new Guid("776a27cf-8fd7-4509-a7f6-34fbd6e57908"), "نهاوند", 28 },
                    { 1128, new Guid("37684a4a-aa66-4701-a5ee-cb5ba6dd8079"), "مهاجران", 28 },
                    { 1127, new Guid("55f59116-cdcb-4102-be55-da3aaa1056b7"), "ملاير", 28 },
                    { 1126, new Guid("a5e673c1-67fb-474e-a3ad-dc195cfb5414"), "مريانج", 28 },
                    { 1125, new Guid("d4970fbd-ca99-40df-a42a-1314664c348a"), "لالجين", 28 },
                    { 1140, new Guid("3c474066-6683-4fe7-86a8-f6b172f54cc9"), "بافت", 29 },
                    { 1124, new Guid("f4694013-d5f7-4943-bfd2-19cb859459d5"), "قهاوند", 28 },
                    { 1141, new Guid("deaa2440-c573-4121-8b9c-c8a4ec147871"), "بردسير", 29 },
                    { 1143, new Guid("d1365519-9e9e-4171-b786-dddf0a3a4906"), "بزنجان", 29 },
                    { 1158, new Guid("f5bd1624-c29d-44ce-bc86-607e521ab6f4"), "دهج", 29 },
                    { 1157, new Guid("cbd3237b-3ad9-465b-a165-935379745d49"), "دشتکار", 29 },
                    { 1156, new Guid("b7e74b9e-104c-4250-93f0-541d65827aaf"), "درب بهشت", 29 },
                    { 1155, new Guid("75ae4147-399a-4470-91b4-dfed1550be7d"), "خورسند", 29 },
                    { 1154, new Guid("a4780f24-1a9e-45a3-be71-c05844e8a56f"), "خواجوشهر", 29 },
                    { 1153, new Guid("ad0f8e69-f14f-431a-8164-379816905896"), "خانوک", 29 },
                    { 1152, new Guid("c5141904-d11f-4ca7-b4ff-9534a648de86"), "خاتون آباد", 29 },
                    { 1151, new Guid("58aa7d95-12b2-4f91-8582-f766662195d5"), "جيرفت", 29 },
                    { 1150, new Guid("77ca1766-f577-4c6a-87a5-6ea7db075eb4"), "جوپار", 29 },
                    { 1149, new Guid("5f4a0812-46d1-4b6a-9925-aeef6c366f86"), "جوزم", 29 },
                    { 1148, new Guid("fdc7f5f8-1bc1-4def-9d68-81b315e13597"), "جبالبارز", 29 },
                    { 1147, new Guid("7e3fbf67-2f4d-4534-bff7-163397d35de0"), "بهرمان", 29 },
                    { 1146, new Guid("1b98c978-b3d3-4a77-9f81-49c413cfd19f"), "بم", 29 },
                    { 1145, new Guid("6c4c8468-b541-4ee2-8e1d-0a10ddefc23d"), "بلوک", 29 },
                    { 1144, new Guid("af0c616a-6ad6-4b88-ab6e-19953b531ed0"), "بلورد", 29 },
                    { 1142, new Guid("bc036f92-59eb-4cf2-bb14-c84f18a01371"), "بروات", 29 },
                    { 1123, new Guid("e8acbeed-d747-4b09-b3f0-267f89bce91f"), "قروه در جزين", 28 },
                    { 1122, new Guid("7de59ecd-1ed7-407a-9b54-290a4c4118ff"), "فيروزان", 28 },
                    { 1121, new Guid("d08f19ad-ff5d-4a98-a9be-e33513487e44"), "فرسفج", 28 },
                    { 1100, new Guid("96427476-65a8-4c7d-a44f-3e39d33111cd"), "کلاچاي", 27 },
                    { 1099, new Guid("ca029c34-bd98-40b4-b4fe-a59c72f747f4"), "چوبر", 27 },
                    { 1098, new Guid("9326c107-c2f6-4593-b47a-6cfdb4623910"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("62f2252a-9235-467c-b57d-63f7661aa694"), "چابکسر", 27 },
                    { 1096, new Guid("214d4af8-74df-4985-81e7-f6e23a0f1b08"), "پره سر", 27 },
                    { 1095, new Guid("8d942946-103f-481d-9a28-9be10c9ccbe0"), "واجارگاه", 27 },
                    { 1094, new Guid("bdd75ca9-af4b-4371-b7a9-dcdaf9c3edd2"), "هشتپر", 27 },
                    { 1093, new Guid("01a49d6b-e849-4462-8aec-61b286dfee7d"), "منجيل", 27 },
                    { 1092, new Guid("cc4e8fbe-9b5c-41a5-a185-671c53b5c282"), "مرجقل", 27 },
                    { 1091, new Guid("e3d94f8b-3ab0-4d65-be3f-ff0a35ab8733"), "ماکلوان", 27 },
                    { 1090, new Guid("25842369-d4a3-4d0a-9223-b09a55475fbd"), "ماسوله", 27 },
                    { 1089, new Guid("365c6c6b-b15a-4e4b-a323-acc21d46d117"), "ماسال", 27 },
                    { 1088, new Guid("1e8ae31b-c8ca-4a96-ace0-30758e2f3628"), "ليسار", 27 },
                    { 1087, new Guid("09b368bb-f594-4234-ba48-a0babd4c594e"), "لوندويل", 27 },
                    { 1086, new Guid("109a73bb-264e-44c8-9a99-052de8996e31"), "لولمان", 27 },
                    { 1101, new Guid("75dfb424-3b93-45a6-9485-0a1f30424e14"), "کومله", 27 },
                    { 1102, new Guid("b6034f57-8142-424c-bbaa-1917c97f5d59"), "کوچصفهان", 27 },
                    { 1103, new Guid("c8df2a6c-96c0-4b2d-bac2-3c81354633b0"), "کياشهر", 27 },
                    { 1104, new Guid("0658bd59-f8e7-439b-b696-71466edd790e"), "گوراب زرميخ", 27 },
                    { 1120, new Guid("665d6058-afab-45cb-b74c-7957ee5a9fad"), "فامنين", 28 },
                    { 1119, new Guid("d9dacdc8-2131-4a1f-96be-b2c9250e607e"), "صالح آباد", 28 },
                    { 1118, new Guid("28f218a3-0fed-41ed-b1a2-96361fd7f8f1"), "شيرين سو", 28 },
                    { 1117, new Guid("deb793d3-e76f-4203-bffc-fc5f24086e95"), "سرکان", 28 },
                    { 1116, new Guid("b14ceffe-3088-4359-af9c-e0f0dea43ca0"), "سامن", 28 },
                    { 1115, new Guid("ac33d217-27f9-4733-b9ac-523a71134160"), "زنگنه", 28 },
                    { 1114, new Guid("8ce8cf1e-30d7-4148-8f6b-2d798babe219"), "رزن", 28 },
                    { 1159, new Guid("c05f1118-830d-4659-ba28-8834ded80f73"), "دوساري", 29 },
                    { 1113, new Guid("673f012f-96a3-4598-8fdd-97edd18343fe"), "دمق", 28 },
                    { 1111, new Guid("42eeba8e-304e-474d-9c92-31e0ff222f34"), "جورقان", 28 },
                    { 1110, new Guid("c7683ba8-47fd-4644-b838-430796687b9b"), "تويسرکان", 28 },
                    { 1109, new Guid("63a85938-6c71-4a13-8374-4f09012939c8"), "بهار", 28 },
                    { 1108, new Guid("e9cb1890-4300-45c1-a6d8-256f0b81a117"), "برزول", 28 },
                    { 1107, new Guid("9bf12dc0-3308-4491-8966-3f19cbc626b9"), "اسد آباد", 28 },
                    { 1106, new Guid("ccffdd53-b645-4a68-92f8-6a38dc893b18"), "ازندريان", 28 },
                    { 1105, new Guid("5951a10a-0003-4073-8116-7b04e5c400ee"), "آجين", 28 },
                    { 1112, new Guid("07f49f5d-dc1f-4a92-b827-5136532a63e6"), "جوکار", 28 },
                    { 1160, new Guid("1178ab45-578c-45d3-827c-c76e2e853e56"), "رابر", 29 },
                    { 1161, new Guid("60981267-ac00-4388-bf33-a682d32c295e"), "راور", 29 },
                    { 1162, new Guid("4818d10e-a985-4eb3-9d9a-b7e0ab711ddc"), "راين", 29 },
                    { 1216, new Guid("aee40aeb-3556-4340-a30f-1dd6106f01d4"), "شاهرود", 30 },
                    { 1215, new Guid("e6210280-83fb-4a61-838d-dfd2014e898a"), "سمنان", 30 },
                    { 1214, new Guid("974731c2-9628-4bcf-af27-69e1246525a5"), "سرخه", 30 },
                    { 1213, new Guid("03203fea-af1e-40b8-b6b9-72750b1cc919"), "روديان", 30 },
                    { 1212, new Guid("2332eef5-c4a0-491b-af85-b651b9cd0dc8"), "ديباج", 30 },
                    { 1211, new Guid("30c10d8d-46f5-4b1f-b2a0-09a0cc283832"), "درجزين", 30 },
                    { 1210, new Guid("ebc67c0f-8f7e-42a3-8490-af6af3c3a517"), "دامغان", 30 },
                    { 1209, new Guid("1710417b-676d-4821-b172-3d9c8612cb01"), "بيارجمند", 30 },
                    { 1208, new Guid("cd188bcf-8ad3-4780-a9ee-04151915d97e"), "بسطام", 30 },
                    { 1207, new Guid("06769c32-9a37-4762-9f57-fb5e080ddd1c"), "ايوانکي", 30 },
                    { 1206, new Guid("b300c374-79ff-40da-99d8-60dacfca1d18"), "اميريه", 30 },
                    { 1205, new Guid("6b6b2058-49c8-41ce-ba74-446d3ca21f92"), "آرادان", 30 },
                    { 1204, new Guid("3bae9240-b5c8-4d28-bd3e-3fa5e0718f96"), "گنبکي", 29 },
                    { 1203, new Guid("c75ba5d1-7723-4d70-8ef7-fcbf971bb384"), "گلزار", 29 },
                    { 1202, new Guid("0654e2fa-6a59-4f9a-a55e-5398f2cbe2e5"), "گلباف", 29 },
                    { 1217, new Guid("7f31f8f6-8be2-4ea6-acc0-d6d57218e579"), "شهميرزاد", 30 },
                    { 1218, new Guid("a22775e5-2a3d-46ea-b176-f929d4b81095"), "مجن", 30 },
                    { 1219, new Guid("4bba18ef-c64e-4d1e-b2f8-2205bba41fa7"), "مهدي شهر", 30 },
                    { 1220, new Guid("86f6c1b3-a763-4e1c-a06d-2eb064864236"), "ميامي", 30 },
                    { 1236, new Guid("6100c4cd-3b0f-4cb6-8671-2a4b49ca5eb3"), "مارگون", 31 },
                    { 1235, new Guid("3c0df221-db91-4d40-8511-36899dca9333"), "مادوان", 31 },
                    { 1234, new Guid("b1302db4-39d2-4879-addf-e005ed30c044"), "ليکک", 31 },
                    { 1233, new Guid("924f2070-023a-41c5-ac14-a54cb3a923a2"), "لنده", 31 },
                    { 1232, new Guid("0eeb4dbb-8cd0-463d-8f4c-c46746051b9b"), "قلعه رئيسي", 31 },
                    { 1231, new Guid("454be303-6391-4d46-a05d-16ce952428db"), "سي سخت", 31 },
                    { 1230, new Guid("533d4774-5c36-4203-95d5-ae420222c333"), "سوق", 31 },
                    { 1201, new Guid("90d83066-c850-491d-b54d-c21a4a474357"), "کيانشهر", 29 },
                    { 1229, new Guid("460efdb1-8a2d-46a8-8dc2-d9cc53f8e887"), "سرفارياب", 31 },
                    { 1227, new Guid("b410bfc7-6e46-4a10-85b1-d21aa96b43a1"), "دوگنبدان", 31 },
                    { 1226, new Guid("8f2b7999-4a67-4e86-8364-993374d9debc"), "دهدشت", 31 },
                    { 1225, new Guid("65ea6cdc-c3de-4963-8af2-8e2721e3b086"), "باشت", 31 },
                    { 1224, new Guid("b9715ded-7da7-43e1-9c71-470b796b9f59"), "گرمسار", 30 },
                    { 1223, new Guid("f08a913c-b0d3-4895-857a-f228000bba2e"), "کهن آباد", 30 },
                    { 1222, new Guid("a18aabbb-b509-43d1-8080-2cf6ac16ab29"), "کلاته خيج", 30 },
                    { 1221, new Guid("9704975f-3e1c-4b42-9406-a8474406e7f0"), "کلاته", 30 },
                    { 1228, new Guid("c26e77fb-60fc-471d-9ef7-ecc48d4f3908"), "ديشموک", 31 },
                    { 1085, new Guid("210067aa-a9da-47e0-877a-fa8c8c009b5c"), "لوشان", 27 },
                    { 1200, new Guid("cfce8658-4737-4415-97a8-5f81c98c02c2"), "کوهبنان", 29 },
                    { 1198, new Guid("45aa398b-1e16-4e81-9819-2340f06db941"), "کشکوئيه", 29 },
                    { 1177, new Guid("455c12b7-8739-4af1-b107-4e5f1a265875"), "قلعه گنج", 29 },
                    { 1176, new Guid("3e3bacc2-1548-48a8-82b5-1da281d05edb"), "فهرج", 29 },
                    { 1175, new Guid("54c20757-6f43-4924-b8ab-5556487c66ac"), "فارياب", 29 },
                    { 1174, new Guid("17ef3c84-326b-4097-ba7a-ecb4fce2d9e5"), "عنبر آباد", 29 },
                    { 1173, new Guid("e271d4f2-ba2b-482a-a814-1c3c9512b835"), "صفائيه", 29 },
                    { 1172, new Guid("83abb069-fc05-4b8e-88a6-b833ce148039"), "شهر بابک", 29 },
                    { 1171, new Guid("7466642f-b2cb-4a30-8f7c-9b67c9c3049a"), "شهداد", 29 },
                    { 1170, new Guid("17518fbc-3232-4a91-93bb-884153971097"), "سيرجان", 29 },
                    { 1169, new Guid("ea18b128-b403-41e1-bb05-f76db26d6c63"), "زيد آباد", 29 },
                    { 1168, new Guid("b1482cc7-a9fc-41d5-afba-3f1a1a8f8128"), "زهکلوت", 29 },
                    { 1167, new Guid("919b54ca-f1c9-4761-9df9-78b59091685f"), "زنگي آباد", 29 },
                    { 1166, new Guid("ad2ee7b1-a3bb-4282-bd0d-3b65eb608e1c"), "زرند", 29 },
                    { 1165, new Guid("fbd136bb-2a46-4d40-9031-a4e8150e283e"), "ريحان", 29 },
                    { 1164, new Guid("88c1352f-2180-4dd1-b6cb-f577dc814ee0"), "رودبار", 29 },
                    { 1163, new Guid("1160a0d9-a7ed-4a1c-b279-ca8ad22416a0"), "رفسنجان", 29 },
                    { 1178, new Guid("11a9de8b-ab3b-476a-a607-50e2e19eb68b"), "لاله زار", 29 },
                    { 1179, new Guid("ff1e2775-c301-48fc-821e-e72b1b0fa172"), "ماهان", 29 },
                    { 1180, new Guid("856896cb-0918-4fbe-8e31-74800aa6e276"), "محمد آباد", 29 },
                    { 1181, new Guid("a5cb2838-5c9b-4770-adca-7f786f435dd3"), "محي آباد", 29 },
                    { 1197, new Guid("03c2bb25-ab00-4ffe-b6a7-4e72c8a19f03"), "کرمان", 29 },
                    { 1196, new Guid("ca2743ac-0436-489e-b8b8-e178e71b8131"), "کاظم آباد", 29 },
                    { 1195, new Guid("85a15976-0d99-44a9-a4b3-49842484678e"), "چترود", 29 },
                    { 1194, new Guid("9e77a41e-0562-408a-9c19-845663c4a0bf"), "پاريز", 29 },
                    { 1193, new Guid("11b4f81d-a4b2-4a9d-a708-0360b04d1497"), "يزدان شهر", 29 },
                    { 1192, new Guid("5afb2344-c751-4cf2-82a3-07f26c8b3f4e"), "هنزا", 29 },
                    { 1191, new Guid("fa1b1317-cfbe-406d-b168-b311ca9bbd38"), "هماشهر", 29 },
                    { 1199, new Guid("23045208-cfbb-4b67-b9f8-1f31e85587ca"), "کهنوج", 29 },
                    { 1190, new Guid("460e278f-0f25-4827-967d-42524be03d89"), "هجدک", 29 },
                    { 1188, new Guid("16a85f8b-d923-4eb2-ab49-aafb72591c9d"), "نودژ", 29 },
                    { 1187, new Guid("efe5e1bf-9469-4f9c-a8a0-d721993d6ab8"), "نظام شهر", 29 },
                    { 1186, new Guid("c1793b2f-961d-4688-9c5a-a7721a8b1c76"), "نرماشير", 29 },
                    { 1185, new Guid("c377d132-a33b-4164-8f07-29a14c4590b7"), "نجف شهر", 29 },
                    { 1184, new Guid("9a573328-fb82-40a2-bf07-2909fe5fd64e"), "منوجان", 29 },
                    { 1183, new Guid("2e63862c-fa85-42bc-ab9e-497ad168e6bd"), "مس سرچشمه", 29 },
                    { 1182, new Guid("432f9514-023a-44e3-a232-ce182176517f"), "مردهک", 29 },
                    { 1189, new Guid("57d6de22-4544-4cb1-9904-a7ffef8734b5"), "نگار", 29 },
                    { 1084, new Guid("a2c2e6bf-5588-46ad-8d2c-b434d6fce032"), "لنگرود", 27 },
                    { 1083, new Guid("bb77560a-3a9f-4770-a306-307bcb82c10e"), "لشت نشاء", 27 },
                    { 1082, new Guid("3b3092d8-612b-4795-b497-79c0bb724172"), "لاهيجان", 27 },
                    { 983, new Guid("3bcb7d83-8bd5-4a58-a8e5-d49a1e82a50a"), "بندر جاسک", 25 },
                    { 982, new Guid("6b7be08d-2f15-4a16-ac4b-5b3a1ccdf69d"), "بستک", 25 },
                    { 981, new Guid("6915b86c-af58-4c7b-bff0-1c1b998b2be8"), "ابوموسي", 25 },
                    { 980, new Guid("2ea532fb-af7d-41be-b950-89156571c85a"), "گيلانغرب", 24 },
                    { 979, new Guid("1879a02c-6264-4101-9fa6-0e8b49030edb"), "گودين", 24 },
                    { 978, new Guid("d6688691-f6b1-4343-9629-c0985a0985e7"), "گهواره", 24 },
                    { 977, new Guid("9d3403ee-f9f0-4846-b571-802df8254451"), "کوزران", 24 },
                    { 976, new Guid("f3f0d0a3-15c0-4219-abcc-a2ac655168ef"), "کنگاور", 24 },
                    { 975, new Guid("78ee61e0-a3c3-40cc-8777-3d8f1b1e53ce"), "کرند غرب", 24 },
                    { 974, new Guid("17c45c4a-3e80-4ec3-ab02-a2f6f28571be"), "کرمانشاه", 24 },
                    { 973, new Guid("49bc2f87-89c8-4bf0-84b1-1067cfab4250"), "پاوه", 24 },
                    { 972, new Guid("cd507d04-7a14-4b3d-b964-668b8aee021c"), "هلشي", 24 },
                    { 971, new Guid("c4dff925-0342-4c8a-9488-6cf12e49d326"), "هرسين", 24 },
                    { 970, new Guid("8cf75806-f979-4c8e-b50c-5bdcf87150ea"), "نوسود", 24 },
                    { 969, new Guid("629f4a53-c52d-472c-9543-f01cbbf23a25"), "نودشه", 24 },
                    { 984, new Guid("f6860c8c-8d95-4aeb-9a9d-657d700ece0d"), "بندر عباس", 25 },
                    { 985, new Guid("00517648-0abe-47c1-ad0a-c83594159db5"), "بندر لنگه", 25 },
                    { 986, new Guid("6fa25d9f-64d5-4981-ab6d-69971cb80024"), "بيکاه", 25 },
                    { 987, new Guid("22d0d270-99b8-4817-8402-3a0e5f0e36df"), "تازيان پائين", 25 },
                    { 1003, new Guid("f49d21ce-a758-4605-bc6a-bb01c1f4f567"), "فارغان", 25 },
                    { 1002, new Guid("6a2c232e-7a8f-49b3-af38-de849942a8a0"), "سيريک", 25 },
                    { 1001, new Guid("e3b4be02-df40-4467-874e-036b71011d02"), "سوزا", 25 },
                    { 1000, new Guid("c197400e-aa2c-4dfa-a994-cbd5cc890a41"), "سندرک", 25 },
                    { 999, new Guid("d21b70eb-6632-407d-bd5f-5cc1eb6b27fb"), "سرگز", 25 },
                    { 998, new Guid("87046aa7-41b6-4c56-87d4-b229cb1981e6"), "سردشت", 25 },
                    { 997, new Guid("2a73094e-e6ca-4cf0-873d-d1bc2837f81f"), "زيارتعلي", 25 },
                    { 968, new Guid("6cff423f-d783-4941-b27b-4f7e41983433"), "ميان راهان", 24 },
                    { 996, new Guid("bf7f1a6a-f7b6-4945-85fd-9c0c71c70a1b"), "رويدر", 25 },
                    { 994, new Guid("1a2d44b7-1ef5-40e1-9ad2-a74629176b75"), "دشتي", 25 },
                    { 993, new Guid("c220ad61-a77b-4ea4-b230-16313cbc5e9f"), "درگهان", 25 },
                    { 992, new Guid("7f55b7ad-e609-4c93-8a9e-9a093d14b09a"), "خمير", 25 },
                    { 991, new Guid("792e5f27-c583-4733-806c-ff3f657dd304"), "حاجي آباد", 25 },
                    { 990, new Guid("af72eb75-2614-4b75-a76b-d79ea173be76"), "جناح", 25 },
                    { 989, new Guid("37b10df3-fa13-4739-a29e-78e5d7b6c2d4"), "تيرور", 25 },
                    { 988, new Guid("d70736f6-f16b-442c-a268-992c9915277c"), "تخت", 25 },
                    { 995, new Guid("2967d5d1-a385-4c15-ad86-05a18a858b50"), "دهبارز", 25 },
                    { 1004, new Guid("5ea238f4-1ca1-4312-92c3-8d92207f0680"), "فين", 25 },
                    { 967, new Guid("b65d5bc8-663e-4ffb-a9c0-a14c9f67aad5"), "قصر شيرين", 24 },
                    { 965, new Guid("bdeb0ca3-8e19-4caf-a8ce-96c3e7b7c880"), "شاهو", 24 },
                    { 944, new Guid("f716e726-f42c-4eb1-af69-5629c8dd1c7a"), "کوار", 23 },
                    { 943, new Guid("c9bf83bd-f3d4-4934-a844-2f201cb3b815"), "کنار تخته", 23 },
                    { 942, new Guid("b19589c6-d70a-44ef-9418-4a5b5caa8348"), "کره اي", 23 },
                    { 941, new Guid("2198d272-d045-431e-acc3-68f6f0ac385c"), "کامفيروز", 23 },
                    { 940, new Guid("aeff04db-1119-4c98-9b3f-c5b30a590118"), "کازرون", 23 },
                    { 939, new Guid("18b241bf-f26b-4e7c-a935-62b1da99e15a"), "کارزين", 23 },
                    { 938, new Guid("941388d7-af5a-46de-b94c-6c1af236194b"), "وراوي", 23 },
                    { 937, new Guid("79f05e8b-0f5d-400f-b2e2-15832217e457"), "هماشهر", 23 },
                    { 936, new Guid("e4c922c5-187a-4804-bde6-d2ec6065f1e7"), "ني ريز", 23 },
                    { 935, new Guid("2635962e-b0b6-4589-ae08-55e8a5139bff"), "نورآباد", 23 },
                    { 934, new Guid("5356cb35-4c7d-4679-a3d8-ddc2fed98634"), "نودان", 23 },
                    { 933, new Guid("8a9fc247-f0f1-435a-a410-0704d8e56b93"), "نوجين", 23 },
                    { 932, new Guid("5bd2ead7-2bd3-40fc-81d5-0cbe54d41642"), "نوبندگان", 23 },
                    { 931, new Guid("9da984d4-08da-416e-8d02-27c9f8ba7f05"), "ميمند", 23 },
                    { 930, new Guid("ee8057ba-7bab-40fc-8e4e-550b69706a53"), "ميانشهر", 23 },
                    { 945, new Guid("6304b9da-291f-442e-a626-f97fa3e4e128"), "کوهنجان", 23 },
                    { 946, new Guid("95328471-0363-4494-adac-832b0ccdf546"), "کوپن", 23 },
                    { 947, new Guid("418cc503-8a33-49b5-92ed-2afb894b6d99"), "گراش", 23 },
                    { 948, new Guid("50212c76-3ee6-4cfb-a773-c4366ee1aeaf"), "گله دار", 23 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 964, new Guid("5dde3d33-f69f-40e1-971f-a0d2791693c0"), "سومار", 24 },
                    { 963, new Guid("80fd3be7-bdb6-4d81-bb1f-4aa279be0291"), "سنقر", 24 },
                    { 962, new Guid("52ff418c-a3ab-477a-b938-1b5a181d308c"), "سطر", 24 },
                    { 961, new Guid("431c7629-a5a5-427b-b826-3ea3e98afe81"), "سرمست", 24 },
                    { 960, new Guid("f7f9cd7f-9a17-4553-acba-bfc67a8ac882"), "سر پل ذهاب", 24 },
                    { 959, new Guid("5436ece4-73e7-41ed-98eb-1e8b14270348"), "ريجاب", 24 },
                    { 958, new Guid("8caf2e05-ba61-4218-bcf2-45e1b5b39745"), "روانسر", 24 },
                    { 966, new Guid("f152c13b-4104-4eae-9886-c23f1942500a"), "صحنه", 24 },
                    { 957, new Guid("97aa218d-74a9-491a-ab7d-38ff4e1bb6aa"), "رباط", 24 },
                    { 955, new Guid("1f86c1ef-7c94-45ad-abc3-d03126ed71d7"), "جوانرود", 24 },
                    { 954, new Guid("60e3e79d-3417-4f4c-a10b-79956194f82c"), "تازه آباد", 24 },
                    { 953, new Guid("2b878fb1-dddf-4ac6-8f9b-e937adec000f"), "بيستون", 24 },
                    { 952, new Guid("cebcee05-cac0-477b-9931-93b0977f6288"), "باينگان", 24 },
                    { 951, new Guid("1f786012-a617-42ed-9e08-1ce1550705c5"), "بانوره", 24 },
                    { 950, new Guid("24c4452c-161e-4003-9510-fd63c4f61978"), "اسلام آباد غرب", 24 },
                    { 949, new Guid("3b98977a-7a7f-455d-bba1-e6842094d0e5"), "ازگله", 24 },
                    { 956, new Guid("9b4ad07b-5344-46ab-a23e-f0c71cbeb8e0"), "حميل", 24 },
                    { 619, new Guid("e0b0b2be-6895-49c2-b5ad-6ad7cb9bc92f"), "ايمانشهر", 19 },
                    { 1005, new Guid("d8e3a049-d8ef-4c5a-bae8-8ffed7504b1a"), "قشم", 25 },
                    { 1007, new Guid("3bd9fbd7-3d72-45a0-9725-3c3bc6bf40ad"), "لمزان", 25 },
                    { 1061, new Guid("73150b3d-b161-473c-8105-c5b435a348ea"), "بندر انزلي", 27 },
                    { 1060, new Guid("004c8a65-3ac7-427b-9115-36fe9ea95c67"), "بره سر", 27 },
                    { 1059, new Guid("86ba1550-6415-4ac7-a7e7-d2ab8eef1b28"), "بازار جمعه", 27 },
                    { 1058, new Guid("9cc465a3-b143-4fe6-9201-31af9b3d7d25"), "املش", 27 },
                    { 1057, new Guid("c60c2326-8c15-43cb-84f6-1af7c09680ec"), "اطاقور", 27 },
                    { 1056, new Guid("5a43c5e1-86e9-43c2-81b0-0915113e1180"), "اسالم", 27 },
                    { 1055, new Guid("a2067187-2253-4ec5-afda-f633c9c3c27e"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("60fb362d-c07d-454d-b5df-fae32d2b5629"), "آستانه اشرفيه", 27 },
                    { 1053, new Guid("2dbfa4d7-0855-41e9-b3f9-1556ec6cd155"), "آستارا", 27 },
                    { 1052, new Guid("4cb5b361-023a-4973-a2ce-4cc927952031"), "کميجان", 26 },
                    { 1051, new Guid("c5bbbb3d-7dc9-4f0f-92d1-061c31ad0ee5"), "کارچان", 26 },
                    { 1050, new Guid("daee1270-d21a-43f5-81fb-0766547b2653"), "پرندک", 26 },
                    { 1049, new Guid("7375eb96-3295-4bd6-9d26-b416a58d2bcf"), "هندودر", 26 },
                    { 1048, new Guid("d8a0d2ec-3945-4d86-abba-c156e1e0d219"), "نيمور", 26 },
                    { 1047, new Guid("53bd90d5-8e68-4a15-81ea-39b55cfa8536"), "نوبران", 26 },
                    { 1062, new Guid("7487496d-74c6-4fa6-b8e4-15ba28ecf571"), "توتکابن", 27 },
                    { 1063, new Guid("8abdf2fe-e793-4a7d-bae1-912eb59bd01a"), "جيرنده", 27 },
                    { 1064, new Guid("94a7f232-896f-4915-b877-79c01745b6a0"), "حويق", 27 },
                    { 1065, new Guid("16d05f69-d85c-4699-a885-e490fa62889f"), "خشکبيجار", 27 },
                    { 1081, new Guid("9ecb868a-b681-4447-88c7-7ba53b4efdd7"), "فومن", 27 },
                    { 1080, new Guid("cc0dff69-e72f-4e9c-9675-14e21a15a2da"), "صومعه سرا", 27 },
                    { 1079, new Guid("3cb5ae0c-fff4-46b2-ad2e-b2c9051ee53b"), "شلمان", 27 },
                    { 1078, new Guid("c8de8f65-3b62-4c49-a1ad-ec315c7d38db"), "شفت", 27 },
                    { 1077, new Guid("b8283d7b-4196-4180-a46f-57e07a9d9906"), "سياهکل", 27 },
                    { 1076, new Guid("c56124a2-384a-43ce-871d-b6aed74d8551"), "سنگر", 27 },
                    { 1075, new Guid("d46887c3-8884-4431-a56c-38718d3b64c0"), "رودسر", 27 },
                    { 1046, new Guid("08ba650a-eb63-4863-a880-4077079d0994"), "نراق", 26 },
                    { 1074, new Guid("726c16ec-8376-4d5a-833b-5b2037839c42"), "رودبنه", 27 },
                    { 1072, new Guid("3e8d110d-bd62-45a8-b239-92cfad5a428a"), "رضوانشهر", 27 },
                    { 1071, new Guid("787d1f6d-2680-4264-b659-ffb5421c4650"), "رشت", 27 },
                    { 1070, new Guid("35287566-cf75-4568-8c91-a788b6a92a4a"), "رستم آباد", 27 },
                    { 1069, new Guid("2d9e3196-338d-4b48-a72a-0d7f63a197e7"), "رحيم آباد", 27 },
                    { 1068, new Guid("6c7ed2bf-3d91-4d4c-b299-2455d917a9e5"), "رانکوه", 27 },
                    { 1067, new Guid("431895f8-9d5d-49ca-97f7-d60d615a0d51"), "ديلمان", 27 },
                    { 1066, new Guid("a94c145a-8995-4a23-9258-f8c0e87d02bb"), "خمام", 27 },
                    { 1073, new Guid("dbde854f-d587-40e3-b8ab-315598435052"), "رودبار", 27 },
                    { 1006, new Guid("03741aeb-80a6-423a-b7a2-2f0bd26332d6"), "قلعه قاضي", 25 },
                    { 1045, new Guid("51fe3e98-9652-4663-ba73-32560ec1c422"), "ميلاجرد", 26 },
                    { 1043, new Guid("7e9b7e85-5e25-421f-a654-7842bcfd7431"), "مامونيه", 26 },
                    { 1022, new Guid("b78a242b-b6cf-4799-9e20-56d9abe5be8a"), "آوه", 26 },
                    { 1021, new Guid("13179116-3474-4439-90ec-89bbab344147"), "آشتيان", 26 },
                    { 1020, new Guid("6e70ebb7-4e97-400c-8aea-5acad443e9c9"), "آستانه", 26 },
                    { 1019, new Guid("38e07600-c81d-47cb-944f-48a5ef5f0c01"), "گوهران", 25 },
                    { 1018, new Guid("90c91480-da6f-416a-92ec-f83a7f7939b1"), "گروک", 25 },
                    { 1017, new Guid("e86540d7-217c-4d69-9807-97c7b229208a"), "کيش", 25 },
                    { 1016, new Guid("186b1a6e-ea9f-4d72-938f-c7c6a971802a"), "کوهستک", 25 },
                    { 1015, new Guid("50e2be68-f1a7-43f9-aca4-61f47ece1564"), "کوشکنار", 25 },
                    { 1014, new Guid("d7dd03b2-50aa-4dcb-b88e-9ca2268e361d"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("aa9b43ab-f05f-4be8-a411-19450d4b02db"), "کنگ", 25 },
                    { 1012, new Guid("e5b84e12-e5bd-414e-8285-2ca2e4afeabf"), "چارک", 25 },
                    { 1011, new Guid("3a3e59a9-1c7b-4dee-8900-92101ed1832a"), "پارسيان", 25 },
                    { 1010, new Guid("8e2025a8-5b30-4858-b49c-0cafd0a0f1bc"), "هشتبندي", 25 },
                    { 1009, new Guid("a1872aaa-b12e-4fca-898f-ae509f6f016c"), "هرمز", 25 },
                    { 1008, new Guid("1c6ca4b6-771a-4756-a374-ed93922aa414"), "ميناب", 25 },
                    { 1023, new Guid("2b4124f2-09f5-4128-8e39-83dc43498ee6"), "اراک", 26 },
                    { 1024, new Guid("6b2891a0-b2f0-40fc-b940-813a38d1e0a8"), "تفرش", 26 },
                    { 1025, new Guid("bd989f13-f8e7-4db0-b7bb-324191488df6"), "توره", 26 },
                    { 1026, new Guid("6b5fc7cb-4349-45b8-b915-71b060dae5de"), "جاورسيان", 26 },
                    { 1042, new Guid("380b5ceb-4a8d-4bb8-8d48-a2a959bf68c2"), "قورچي باشي", 26 },
                    { 1041, new Guid("18f58142-164a-4379-8313-996c36236952"), "فرمهين", 26 },
                    { 1040, new Guid("6e363916-56ca-4aca-ba24-7f7000f47b5e"), "غرق آباد", 26 },
                    { 1039, new Guid("1b63a016-987d-48db-a92b-21d6a7ac3a29"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("4368fdec-4671-48bd-a9a0-3faee1dce0f5"), "شهباز", 26 },
                    { 1037, new Guid("9471b03c-39aa-448c-9fd1-f9c15123f1d0"), "شازند", 26 },
                    { 1036, new Guid("618169b5-5dc9-4045-88c3-e77896708383"), "ساوه", 26 },
                    { 1044, new Guid("ca9ae4ca-72b2-4ea5-872d-8a65a80c0b54"), "محلات", 26 },
                    { 1035, new Guid("608582cb-a33c-4be4-9936-1b8733f1fa48"), "ساروق", 26 },
                    { 1033, new Guid("fc2e67a6-f5ef-46be-ad7c-e4cf2578f45b"), "رازقان", 26 },
                    { 1032, new Guid("3944455f-e29d-4f79-adbd-2c6a5fa300d3"), "دليجان", 26 },
                    { 1031, new Guid("d57f622c-b10b-4aef-bc36-41b5dfae6554"), "داود آباد", 26 },
                    { 1030, new Guid("aa2067c6-27ab-41bd-9edf-90dcd29e513a"), "خنداب", 26 },
                    { 1029, new Guid("23d7ea26-1e47-47b0-9b84-8f897b868f37"), "خنجين", 26 },
                    { 1028, new Guid("a93479d0-3bfb-4029-9949-e81c18a6947e"), "خمين", 26 },
                    { 1027, new Guid("4f953ed9-2897-4dbf-b59c-84bc59e8f96f"), "خشکرود", 26 },
                    { 1034, new Guid("d675feef-5868-415d-bc17-245eb9e34ee9"), "زاويه", 26 },
                    { 1237, new Guid("399e8633-71e4-498f-9638-e69150e06aea"), "ياسوج", 31 },
                    { 618, new Guid("e9512241-d0c1-4110-b99b-f2602d222d06"), "انارک", 19 },
                    { 616, new Guid("47b4d8d9-2236-4491-8883-f98ab494172d"), "اصفهان", 19 },
                    { 207, new Guid("5255d57c-d99a-4f30-a10f-1f15c6572787"), "سلامي", 8 },
                    { 206, new Guid("8f14b83d-db44-4e9d-9501-f8e4fbc7cf91"), "سفيد سنگ", 8 },
                    { 205, new Guid("87e1d426-3089-4440-9d02-75ef6bb3e187"), "سرخس", 8 },
                    { 204, new Guid("cf840de1-f740-4300-b4eb-f6c5724205e5"), "سبزوار", 8 },
                    { 203, new Guid("a99dc72a-1182-4fc7-a28d-c2c286943fd7"), "ريوش", 8 },
                    { 202, new Guid("cdafc583-7df9-4c95-bce3-901cef43aa86"), "روداب", 8 },
                    { 201, new Guid("20d026cd-0365-4b59-960a-52dccf118f6f"), "رضويه", 8 },
                    { 200, new Guid("87a52550-257d-4469-99c0-90d6852f8618"), "رشتخوار", 8 },
                    { 199, new Guid("69d43362-c204-4763-8388-90abd99c22ac"), "رباط سنگ", 8 },
                    { 198, new Guid("949ea67f-c657-41f5-bf51-6222c7a96141"), "دولت آباد", 8 },
                    { 197, new Guid("63f6f181-6706-49b0-8b35-b4a089c63765"), "درگز", 8 },
                    { 196, new Guid("b52773a4-9b61-4ec8-832d-d8074e42ad9a"), "درود", 8 },
                    { 195, new Guid("cfec8fbe-d4a6-4ce3-ac41-4624697fb833"), "داورزن", 8 },
                    { 194, new Guid("804d2e66-f82c-40c5-b21d-05dc6c557d55"), "خواف", 8 },
                    { 193, new Guid("7d7faf02-69fa-4c49-b131-91a5a50e99f3"), "خليل آباد", 8 },
                    { 208, new Guid("226de60d-9a23-4bc0-b6d6-fcacf4918de5"), "سلطان آباد", 8 },
                    { 192, new Guid("852d60b3-3d3b-4b88-a451-732b91423c8a"), "خرو", 8 },
                    { 209, new Guid("9eb33149-9349-40c5-9b23-b17a5c4fef4e"), "سنگان", 8 },
                    { 211, new Guid("e6275525-1311-491a-b876-9dadc76f4caa"), "شانديز", 8 },
                    { 226, new Guid("f42f00da-6840-4d9d-9e59-2118e9726c43"), "لطف آباد", 8 },
                    { 225, new Guid("70f979ed-4008-46e0-9755-d0461e74cd71"), "قوچان", 8 },
                    { 224, new Guid("aa8c759a-0626-4691-b78b-a12e7f643f54"), "قلندر آباد", 8 },
                    { 223, new Guid("da867d28-4641-4572-87e9-c732f01593de"), "قدمگاه", 8 },
                    { 222, new Guid("7c7aa3d6-04fc-431b-9ba6-eb91b5f41413"), "قاسم آباد", 8 },
                    { 221, new Guid("05c0d463-e34a-4ddc-86e9-a39659b680c8"), "فيض آباد", 8 },
                    { 220, new Guid("18e58eed-f969-4795-a319-0eb5b93c704c"), "فيروزه", 8 },
                    { 219, new Guid("2b6dea4e-d967-4ecf-ae27-aaf5876ffa82"), "فريمان", 8 },
                    { 218, new Guid("27ac83fa-652e-492d-8804-0a8dbffbff41"), "فرهاد گرد", 8 },
                    { 217, new Guid("e984ba4a-dd5c-4f3a-85bd-1c617e7ce16b"), "عشق آباد", 8 },
                    { 216, new Guid("e2409e70-dd65-4642-80ac-6dba1b001d02"), "طرقبه", 8 },
                    { 215, new Guid("1932bf58-e320-4922-9ee0-74570a923c93"), "صالح آباد", 8 },
                    { 214, new Guid("e3795b67-7dc0-4385-8ed5-d25bf40582bf"), "شهرآباد", 8 },
                    { 213, new Guid("071420d0-df9f-4a4a-982b-a8dd4d948def"), "شهر زو", 8 },
                    { 212, new Guid("863d6d5d-e52f-4c16-9518-3651a5cbb2ae"), "ششتمد", 8 },
                    { 210, new Guid("b1fdbcf0-2bad-4160-b5cc-953fddf6d3f6"), "شادمهر", 8 },
                    { 191, new Guid("1168467b-13d9-459e-bb0b-68b9f5668c10"), "جنگل", 8 },
                    { 190, new Guid("52d024e6-6af7-4074-ac68-a45be75d64ea"), "جغتاي", 8 },
                    { 189, new Guid("63e37a9c-016d-4053-acef-b7717fba38b2"), "تربت حيدريه", 8 },
                    { 168, new Guid("44fab946-020a-46b6-9984-081a97921940"), "ميرآباد", 7 },
                    { 167, new Guid("62bd85b7-5382-4282-85ba-d28a6e7f55ff"), "مياندوآب", 7 },
                    { 166, new Guid("630eb305-9a20-4d95-8985-a87895b72b29"), "مهاباد", 7 },
                    { 165, new Guid("763c231d-7b89-46c1-af68-22933cb0a2fe"), "مرگنلر", 7 },
                    { 164, new Guid("47fc2720-7e1b-47e6-ba6f-7e3762a2eaa7"), "محمود آباد", 7 },
                    { 163, new Guid("7d2dbe12-ab6d-4235-aa45-6cbd1ea08fe8"), "محمد يار", 7 },
                    { 162, new Guid("1eae990e-ff18-41a8-9d9c-8704acad1835"), "ماکو", 7 },
                    { 161, new Guid("e32947d7-605b-4540-826c-7b1c1c275ad2"), "قوشچي", 7 },
                    { 160, new Guid("fd6c7cf5-188e-429a-bead-3d8af70eefae"), "قطور", 7 },
                    { 159, new Guid("b27d67f0-93fe-4689-9c54-7b966cc30ea8"), "قره ضياء الدين", 7 },
                    { 158, new Guid("981d6493-9b6a-4eee-bade-02d7586586d1"), "فيرورق", 7 },
                    { 157, new Guid("81604ed6-62ce-400a-a3d0-d2ee205fe68f"), "شوط", 7 },
                    { 156, new Guid("ac9ee0c8-97f0-48ba-b3de-88fee85778c9"), "شاهين دژ", 7 },
                    { 155, new Guid("bde07b79-1bb9-46b4-aaaa-9928219c1b7e"), "سيه چشمه", 7 },
                    { 154, new Guid("2e1222c8-4126-42f1-8fa5-d4f337b9e415"), "سيمينه", 7 },
                    { 169, new Guid("f75007a0-a6c3-43b9-8778-02b94b94f354"), "نازک عليا", 7 },
                    { 170, new Guid("ec03ca9b-4ee2-4142-bc70-018e884f4bb0"), "نالوس", 7 },
                    { 171, new Guid("ae4a492b-f572-40a1-a8d7-498d27bd14a5"), "نقده", 7 },
                    { 172, new Guid("26f0c0c2-0e09-431d-be07-3a858a765d4f"), "نوشين", 7 },
                    { 188, new Guid("5f547c24-d3c6-4029-bd6c-0bc5b7f7b61e"), "تربت جام", 8 },
                    { 187, new Guid("37859d83-baaf-44a8-acbf-f0b00b427010"), "تايباد", 8 },
                    { 186, new Guid("d1aed4f4-d293-472c-a81c-e2378087a571"), "بيدخت", 8 },
                    { 185, new Guid("60019a1c-6f7f-4a92-9129-1d7ae4e60396"), "بردسکن", 8 },
                    { 184, new Guid("3c284dcf-aa29-4cdd-b556-13d5fad37d91"), "بجستان", 8 },
                    { 183, new Guid("93ffd4bf-0195-4803-b256-ba739c4ae6d3"), "بايک", 8 },
                    { 182, new Guid("947eb873-84e1-4a68-9959-d4588cd5acbf"), "بار", 8 },
                    { 227, new Guid("86c5ecbe-8b1c-4b2f-895b-d6c92558ed9b"), "مزدآوند", 8 },
                    { 181, new Guid("7ac0c059-1946-4080-8c27-3795291eb4e9"), "باخرز", 8 },
                    { 179, new Guid("b97ba89c-c94b-4271-9efb-4db9f94a8193"), "انابد", 8 },
                    { 178, new Guid("bdfb49c4-0d5c-4549-83a9-e011101b9546"), "احمدآباد صولت", 8 },
                    { 177, new Guid("b7961965-a687-4225-bcc5-26d78151a206"), "گردکشانه", 7 },
                    { 176, new Guid("6693ce2b-b917-4bdf-84c5-a64d77078d52"), "کشاورز", 7 },
                    { 175, new Guid("a51a1e3e-ebe6-4885-b995-c20f504f1496"), "چهار برج", 7 },
                    { 174, new Guid("1b54bd19-5a82-4bd5-8102-f4b1280e5962"), "پيرانشهر", 7 },
                    { 173, new Guid("045f4e73-a9dd-4615-9538-c44e559c6847"), "پلدشت", 7 },
                    { 180, new Guid("1dbf0429-067d-44ae-b959-b07e9247b7c2"), "باجگيران", 8 },
                    { 228, new Guid("4fea7a76-6810-45fd-9b40-46eb5c5d9d65"), "مشهد", 8 },
                    { 229, new Guid("a0f6658e-f386-4c38-ae18-2d4802308e36"), "مشهدريزه", 8 },
                    { 230, new Guid("74c4f37d-196f-49f6-8a17-3ca4193e8494"), "ملک آباد", 8 },
                    { 284, new Guid("3eb8da09-6689-43f3-8b53-a02139ac88fd"), "کنارک", 9 },
                    { 283, new Guid("654c0096-c37e-493a-9d28-a31466c4666b"), "چاه بهار", 9 },
                    { 282, new Guid("8020eee8-22ca-491b-890a-a404685c08f7"), "پيشين", 9 },
                    { 281, new Guid("961d1e4d-b476-4251-88e2-fa8583e45061"), "هيدوچ", 9 },
                    { 280, new Guid("e3a3aeae-a8b2-4cfd-b51d-399bc78bbb5f"), "نگور", 9 },
                    { 279, new Guid("a17d092c-6475-4382-804b-775fa6eb6ef7"), "نيک شهر", 9 },
                    { 278, new Guid("c3cc2289-17a3-473e-8fde-a74e724393dd"), "نوک آباد", 9 },
                    { 277, new Guid("e73b3bd4-81c2-42a3-b7f6-c8d75fe6f373"), "نصرت آباد", 9 },
                    { 276, new Guid("a8d520f8-4fff-4286-b3ce-2c5aa31f2f67"), "ميرجاوه", 9 },
                    { 275, new Guid("4e9e82d9-483a-4c7f-91c1-dd70d7ee208f"), "مهرستان", 9 },
                    { 274, new Guid("87dd1b79-78bd-45a0-a03c-bcd673ab2dfa"), "محمدي", 9 },
                    { 273, new Guid("e673eae4-028b-4fa4-b8bf-0887f2cef2c1"), "محمدان", 9 },
                    { 272, new Guid("3d7bc16b-ce0d-4394-aaba-1a70162078f5"), "محمد آباد", 9 },
                    { 271, new Guid("1f4c2df5-1c6d-44a0-b13a-4993978ff084"), "قصر قند", 9 },
                    { 270, new Guid("5c8c8325-4083-4c57-9407-977d926c5e37"), "فنوج", 9 },
                    { 285, new Guid("c1182801-8e2c-492c-bd23-79c3f816a167"), "گشت", 9 },
                    { 286, new Guid("78b014dd-dd0d-41aa-9ddb-d77ef7e837b1"), "گلمورتي", 9 },
                    { 287, new Guid("4f66edbd-5f38-4187-baa3-ba1428541663"), "آرين شهر", 10 },
                    { 288, new Guid("08a9aeac-0dfc-428d-8a24-dd5b44e9ad59"), "آيسک", 10 },
                    { 304, new Guid("06533ffd-4b2f-45cd-8369-672c1e0d4101"), "طبس", 10 },
                    { 303, new Guid("a9b3b026-8d71-4eef-84cd-fb8aabecdeb0"), "شوسف", 10 },
                    { 302, new Guid("df2593e9-3442-4b8f-b455-623dfb6dfe99"), "سه قلعه", 10 },
                    { 301, new Guid("d612933f-3c0f-48f9-9ca3-0f23595493fc"), "سربيشه", 10 },
                    { 300, new Guid("5810b85a-603b-4aa6-90d0-f8b762b1eb56"), "سرايان", 10 },
                    { 299, new Guid("5a9cea63-3d2a-4448-a562-f49c7a4296cd"), "زهان", 10 },
                    { 298, new Guid("d7bb5310-782b-49ba-80bd-d5809fb862e9"), "ديهوک", 10 },
                    { 269, new Guid("3467379f-591f-495f-91fc-bd510fbe0882"), "علي اکبر", 9 },
                    { 297, new Guid("6ba0388d-a77e-418e-a108-5665a774f2dd"), "خوسف", 10 },
                    { 295, new Guid("3684ac52-6f77-4171-90f2-96c0d45be070"), "حاجي آباد", 10 },
                    { 294, new Guid("4905ca7a-7526-4c6d-96c6-d001b2bdf8e6"), "بيرجند", 10 },
                    { 293, new Guid("ed146b20-ce35-42a0-b2fd-58b6ad1e81eb"), "بشرويه", 10 },
                    { 292, new Guid("0602b046-e375-4402-952a-1e67096e9fcd"), "اسلاميه", 10 },
                    { 291, new Guid("d2699a32-3727-4c06-96ba-0ddba08d8d14"), "اسفدن", 10 },
                    { 290, new Guid("fdf8168d-a6bc-448b-8462-04be4e597951"), "اسديه", 10 },
                    { 289, new Guid("1d2db923-1880-4b3d-9531-851f1d01e7ca"), "ارسک", 10 },
                    { 296, new Guid("9d6e178d-766d-4daf-9909-963839f18310"), "خضري دشت بياض", 10 },
                    { 153, new Guid("3ee5cb44-6e7e-49b7-a902-44ef36df80c7"), "سيلوانه", 7 },
                    { 268, new Guid("186bc738-5967-4570-a533-a71dd0a6f600"), "سيرکان", 9 },
                    { 266, new Guid("8fb3f682-f988-42c8-92e3-55dcfe36920b"), "سرباز", 9 },
                    { 245, new Guid("ca226dcc-7b0f-49e3-84cf-8a77a13dab7e"), "کدکن", 8 },
                    { 244, new Guid("1bb2a34c-542b-40ac-9a01-fb5ea60c10dd"), "کاشمر", 8 },
                    { 243, new Guid("5b1dc1c4-e562-4990-9751-ab51246a8a4c"), "کاريز", 8 },
                    { 242, new Guid("81a99b4e-251b-41b0-93a7-b2c28a6e7a26"), "کاخک", 8 },
                    { 241, new Guid("c2362e16-18a7-4852-8e60-45da10332acd"), "چکنه", 8 },
                    { 240, new Guid("b5242ef7-eeb9-4d19-b0a3-9cb2c4dc79e7"), "چناران", 8 },
                    { 239, new Guid("62dea856-7308-46da-a64b-edb79f1d945d"), "چاپشلو", 8 },
                    { 238, new Guid("c28b6097-6d98-432e-8fc0-776e18fbeca0"), "يونسي", 8 },
                    { 237, new Guid("f9bd4dcc-a048-4d4c-9f71-27ed0a11cab9"), "همت آباد", 8 },
                    { 236, new Guid("da4adaaa-fd52-4845-bd72-4b31050d4725"), "نيل شهر", 8 },
                    { 235, new Guid("fd119a4f-7638-432b-8f97-25d68d1a8615"), "نيشابور", 8 },
                    { 234, new Guid("79271976-ca19-49d1-a1e3-09ecd6f1c628"), "نوخندان", 8 },
                    { 233, new Guid("e658dfd7-dc85-4205-aab2-0ecab02fc317"), "نقاب", 8 },
                    { 232, new Guid("1eb22c6d-188f-4e68-abfa-2b364374ff01"), "نصرآباد", 8 },
                    { 231, new Guid("de13c36f-a5af-4882-ab04-4d94c868ae1d"), "نشتيفان", 8 },
                    { 246, new Guid("62f40770-6a0d-4056-a12f-998f0e1191ab"), "کلات", 8 },
                    { 247, new Guid("c18d40aa-6ca7-4c2c-8888-a0d4aec95c35"), "کندر", 8 },
                    { 248, new Guid("afb93dde-dbc4-4a6a-be42-4c128bce9d4d"), "گلمکان", 8 },
                    { 249, new Guid("a378093a-12f1-4d94-8230-9c010c349e13"), "گناباد", 8 },
                    { 265, new Guid("ec3f9cad-6f13-465d-965f-adaacfcb21c3"), "سراوان", 9 },
                    { 264, new Guid("1e2be99c-5649-41d5-a33e-46fcbaee4bb5"), "زهک", 9 },
                    { 263, new Guid("6542d1b2-54a7-4b50-9fcc-62d91f7771bb"), "زرآباد", 9 },
                    { 262, new Guid("ab2259bd-fc47-4ead-816f-17cc1d3beb7e"), "زاهدان", 9 },
                    { 261, new Guid("92a1f8a0-24d4-4200-bfff-2b3a410ebf49"), "زابل", 9 },
                    { 260, new Guid("e46f7dd6-4d47-4eaf-9164-8ca6621868ee"), "راسک", 9 },
                    { 259, new Guid("a9726d38-cf5b-4578-ab5d-8cf9e3a4475c"), "دوست محمد", 9 },
                    { 267, new Guid("b129c573-27c2-46b4-a800-41467c8cacbe"), "سوران", 9 },
                    { 258, new Guid("6ec2fd9c-9fd7-4864-87f6-ab95d3facee9"), "خاش", 9 },
                    { 256, new Guid("db77a9ae-374a-45d4-b470-4ad3e88d22c7"), "بنجار", 9 },
                    { 255, new Guid("579885fa-38b2-4048-bc15-269664d8ffc7"), "بنت", 9 },
                    { 254, new Guid("79081d4d-6424-4b8f-b471-249afc5acbba"), "بمپور", 9 },
                    { 253, new Guid("329dc803-5fc9-49a5-8a4a-4cb7cf78b9ff"), "بزمان", 9 },
                    { 252, new Guid("8a00eefb-a54f-46c2-8cd0-c3c39ee7cf7d"), "ايرانشهر", 9 },
                    { 251, new Guid("4621f30a-42c9-4f79-b53d-cd857ec627a3"), "اسپکه", 9 },
                    { 250, new Guid("78ac445a-d6eb-47e8-a26b-43b8daea6c9c"), "اديمي", 9 },
                    { 257, new Guid("67da12f0-efcb-4af1-bc64-12abfa43f4c5"), "جالق", 9 },
                    { 305, new Guid("2a616613-8c0a-40dd-915a-0533f6545903"), "طبس مسينا", 10 },
                    { 152, new Guid("5b45244b-a279-46ea-90e8-4f07fd4ff3bd"), "سلماس", 7 },
                    { 150, new Guid("e332b14c-2206-4c59-ba4e-7660d3d48b2e"), "سردشت", 7 },
                    { 52, new Guid("fb38aa66-2f9f-4073-9845-66e719254503"), "هفشجان", 2 },
                    { 51, new Guid("1611f168-7bc1-4e2a-a58b-25852c821806"), "هاروني", 2 },
                    { 50, new Guid("ad6c6537-ce73-447a-bfeb-95c630bca916"), "نقنه", 2 },
                    { 49, new Guid("69352b4b-603f-4df7-a809-a790a260b04a"), "نافچ", 2 },
                    { 48, new Guid("34a09076-7acd-4bad-84e1-4cf7d94bd5e3"), "ناغان", 2 },
                    { 47, new Guid("a7db028a-aedd-41dc-93ba-76500de31da5"), "منج", 2 },
                    { 46, new Guid("c24b00b3-33c0-4f23-a371-8fcb26d61cf5"), "مال خليفه", 2 },
                    { 45, new Guid("181f7fdf-5617-4e0a-a37c-13c903e046ed"), "لردگان", 2 },
                    { 44, new Guid("e4978d24-651a-4e04-9bde-4ccd96e78c06"), "فرخ شهر", 2 },
                    { 43, new Guid("e964f2b8-6a1e-45a7-aac2-d76b5f4d80aa"), "فرادنبه", 2 },
                    { 42, new Guid("f5577e82-19db-46d6-87ac-f8608d8991d0"), "فارسان", 2 },
                    { 41, new Guid("4e197373-07a5-4713-8cb1-99dbdeb034bd"), "طاقانک", 2 },
                    { 40, new Guid("8d8ef603-94ea-4c93-a59c-90aeb0f29eea"), "صمصامي", 2 },
                    { 39, new Guid("7735f5ec-af16-4fdc-afe5-f690422c7a56"), "شهرکرد", 2 },
                    { 38, new Guid("db9e51c5-fe58-42e3-879c-bd7e53bd182d"), "شلمزار", 2 },
                    { 53, new Guid("6b91ffba-c7c5-4309-8b8d-fce27f2dc8be"), "وردنجان", 2 },
                    { 37, new Guid("a4967e00-ab39-44a3-b9ae-55df65c18571"), "سورشجان", 2 },
                    { 54, new Guid("b3703fd5-e0d7-49b2-b935-75a9a02eafb2"), "پردنجان", 2 },
                    { 56, new Guid("d0e3f58b-abc0-4382-851c-edf51f8c0315"), "چلگرد", 2 },
                    { 71, new Guid("cd04f35e-2d8f-4f17-ae20-20ed2ba94a98"), "راز", 3 },
                    { 70, new Guid("74657062-0831-46c5-bfc6-71f975a1d81d"), "درق", 3 },
                    { 69, new Guid("4b050531-84d8-4853-9560-c20000f94daf"), "حصارگرمخان", 3 },
                    { 68, new Guid("e5840318-e3f2-4af9-8090-c428d495fdb8"), "جاجرم", 3 },
                    { 67, new Guid("fe724c59-567b-4805-9cb0-efcc8354606f"), "تيتکانلو", 3 },
                    { 66, new Guid("3f6532ac-f4aa-414c-9771-04e5471e62ff"), "بجنورد", 3 },
                    { 65, new Guid("55feb6c0-e2ac-407b-96e8-937d66c993ed"), "ايور", 3 },
                    { 64, new Guid("08e69045-8319-43de-ad7a-4ea9d673852b"), "اسفراين", 3 },
                    { 63, new Guid("0664b38d-6acd-4cda-ad5f-0d328d81dd78"), "آوا", 3 },
                    { 62, new Guid("8d0ba571-1a23-456c-8003-93aa9c7211f9"), "آشخانه", 3 },
                    { 61, new Guid("ae0df21a-004e-462c-b241-d03975f389ad"), "گوجان", 2 },
                    { 60, new Guid("b8b969a5-bb86-416b-9ac6-2823ec427810"), "گهرو", 2 },
                    { 59, new Guid("4f6b7498-681d-42da-a825-4b00390cc77f"), "گندمان", 2 },
                    { 58, new Guid("cc7dc5e1-af60-445e-a803-ee90c57d6e0d"), "کيان", 2 },
                    { 57, new Guid("cca3bd6d-58de-45fe-897d-7aafc27e2494"), "کاج", 2 },
                    { 55, new Guid("59b8cab2-732c-4222-b55f-8593ead8f207"), "چليچه", 2 },
                    { 36, new Guid("a2fe9787-8fbd-40a2-aade-1461af91da55"), "سودجان", 2 },
                    { 35, new Guid("312b99ce-6fdf-4312-94aa-599b079c5910"), "سفيد دشت", 2 },
                    { 34, new Guid("c8d33d1b-b60d-4eff-916a-519c720bd672"), "سردشت لردگان", 2 },
                    { 13, new Guid("2d8ee15e-1113-4c1d-a137-ebcadcf9c06c"), "عقدا", 1 },
                    { 12, new Guid("821a30a3-7e8c-49fc-96b9-c84092089e4e"), "شاهديه", 1 },
                    { 11, new Guid("fb7fc36c-2926-49dc-8d3f-4d3a2610c2f1"), "زارچ", 1 },
                    { 10, new Guid("326e64be-3809-43b3-99bc-93c8bc178700"), "خضر آباد", 1 },
                    { 9, new Guid("df9b9da9-679a-42b0-889a-661624677fae"), "حميديا", 1 },
                    { 8, new Guid("d009eeca-74a2-49bc-a567-46378fc45fd3"), "تفت", 1 },
                    { 7, new Guid("84be1070-e15e-48bd-a7ce-2b823bd15bb1"), "بهاباد", 1 },
                    { 6, new Guid("d0b31338-c293-4c2d-a333-68881256211e"), "بفروئيه", 1 },
                    { 5, new Guid("a616b41b-9075-46a7-9ce4-cc14f2768901"), "بافق", 1 },
                    { 4, new Guid("df3b902f-810d-4457-8ef7-077cb2129eab"), "اشکذر", 1 },
                    { 3, new Guid("49b16ef4-da7f-419b-8818-30700719474b"), "اردکان", 1 },
                    { 2, new Guid("ade49d07-525b-4565-b702-67ae10c0e1c5"), "احمد آباد", 1 },
                    { 1, new Guid("b8626578-f8eb-476c-827c-b81366f471eb"), "ابرکوه", 1 },
                    { 1240, new Guid("9d33ebd2-a322-49fe-bdf2-44198a484996"), "چيتاب", 31 },
                    { 1241, new Guid("2de05c6f-79e8-4f40-9857-cd3b3a84b128"), "گراب سفلي", 31 },
                    { 14, new Guid("d9c19e0d-800d-4678-bbcc-c76a8553471f"), "مروست", 1 },
                    { 15, new Guid("87a5f8f8-f861-45df-bf35-0c7749ee29f9"), "مهردشت", 1 },
                    { 16, new Guid("671e8de1-232b-42ea-ac51-1d2a1fba2990"), "مهريز", 1 },
                    { 17, new Guid("85845c5b-f3bb-4b6e-81c1-073655493369"), "ميبد", 1 },
                    { 33, new Guid("335cd6d3-05f8-496d-b746-7e9a26e38052"), "سرخون", 2 },
                    { 32, new Guid("ac571a9f-1a25-443e-991c-1e565f407bd9"), "سامان", 2 },
                    { 31, new Guid("a2a3bc06-2b7d-4cd0-a69c-e8ead3337f10"), "دشتک", 2 },
                    { 30, new Guid("62c473a8-5596-45da-846a-82868dbb7a7f"), "دستناء", 2 },
                    { 29, new Guid("0e3cb389-674c-473b-870a-2a7011584e41"), "جونقان", 2 },
                    { 28, new Guid("0ee3aea6-1fed-4c2e-b1d8-384d02ee2924"), "بن", 2 },
                    { 27, new Guid("b9750408-c57f-4c38-9316-f0879efbac0c"), "بلداجي", 2 },
                    { 72, new Guid("3e5831c5-3ba4-4957-89f3-e183ab123a33"), "زيارت", 3 },
                    { 26, new Guid("85eabac1-0a67-4c69-aef0-8351cf5bf41e"), "بروجن", 2 },
                    { 24, new Guid("60bf967a-2c89-4c52-92dc-99aaa912a5a0"), "باباحيدر", 2 },
                    { 23, new Guid("cfc82ea5-b081-4397-b107-614b25bb4242"), "اردل", 2 },
                    { 22, new Guid("0781178a-ee14-4655-b1a8-075b62391209"), "آلوني", 2 },
                    { 21, new Guid("caa57eb9-fd7c-4432-ab0c-95cc5ddaad9a"), "يزد", 1 },
                    { 20, new Guid("87d5a8bb-684e-481b-97d7-2e84d9b33a30"), "هرات", 1 },
                    { 19, new Guid("c59864ae-6f93-4fa8-8ddf-b2ad320093a2"), "نير", 1 },
                    { 18, new Guid("d1360a09-036d-4c51-8d90-052a7a92f11f"), "ندوشن", 1 },
                    { 25, new Guid("8fc7f012-54e9-41d4-8211-a48a69e76387"), "بازفت", 2 },
                    { 73, new Guid("72262224-291c-4860-8306-6519d174c00b"), "سنخواست", 3 },
                    { 74, new Guid("333bcc5b-4aac-48e4-99dd-3ae0ea6532ef"), "شوقان", 3 },
                    { 75, new Guid("57d002ad-84ad-46cf-b512-efc5e1940dea"), "شيروان", 3 },
                    { 129, new Guid("a17d971e-87da-49cd-ad70-85abb18394fd"), "موچش", 6 },
                    { 128, new Guid("0feaedbf-aa26-48e3-8a56-3c7d974f1060"), "مريوان", 6 },
                    { 127, new Guid("f9e5b648-f9e4-49af-9e6b-031ed40af981"), "قروه", 6 },
                    { 126, new Guid("2b8780d0-cd3f-40be-b12a-4843204ca070"), "صاحب", 6 },
                    { 125, new Guid("16e13844-61e6-435f-84f0-8e8dbee87779"), "شويشه", 6 },
                    { 124, new Guid("6975cec2-4887-43b0-ba94-95ff183b17eb"), "سنندج", 6 },
                    { 123, new Guid("1b014d4e-9cde-48ce-990c-47ac088ec534"), "سقز", 6 },
                    { 122, new Guid("12ee4e1a-477b-44b9-aa4b-a9420679324e"), "سريش آباد", 6 },
                    { 121, new Guid("91d6d4ec-0fb6-4db2-bfda-296ed46d25b3"), "سرو آباد", 6 },
                    { 120, new Guid("a1db74cf-f6aa-4ff8-a148-2b7ef928a967"), "زرينه", 6 },
                    { 119, new Guid("d532f9e1-3678-4dd4-a265-294a5e9742e5"), "ديواندره", 6 },
                    { 118, new Guid("47437722-fa47-4885-a8ae-8b85eb50a743"), "دهگلان", 6 },
                    { 117, new Guid("c911b744-a87b-40d9-8bca-8c119446a49d"), "دلبران", 6 },
                    { 116, new Guid("6a1f76f3-515c-4a60-ba96-2ab71ca73bc8"), "دزج", 6 },
                    { 115, new Guid("a6084e63-9caa-4581-a4ea-fa0a2f20c633"), "توپ آغاج", 6 },
                    { 130, new Guid("a03f34f5-a136-40a4-addd-defe93efcfb0"), "ياسوکند", 6 },
                    { 131, new Guid("dfd5fd0f-2286-410e-8bdd-5416d3b477de"), "پيرتاج", 6 },
                    { 132, new Guid("4f7bc144-bbfb-45a9-84eb-e33fdc990857"), "چناره", 6 },
                    { 133, new Guid("a762f3d0-f451-4567-9932-621d88d4c130"), "کامياران", 6 },
                    { 149, new Guid("2b01c1bb-2bab-4479-938a-75d09dc3113f"), "زرآباد", 7 },
                    { 148, new Guid("9348f85e-e92a-401a-9900-e05c56d52935"), "ربط", 7 },
                    { 147, new Guid("d8dd1dac-aa07-4546-a04d-a659df74c253"), "ديزج ديز", 7 },
                    { 146, new Guid("18fbd3e3-62ef-4b3e-9ee5-53a80f7d0023"), "خوي", 7 },
                    { 145, new Guid("5a5cfbc5-312e-4428-a471-ae03b43051e8"), "خليفان", 7 },
                    { 144, new Guid("2f917210-4e11-495e-a15e-4092f096e788"), "تکاب", 7 },
                    { 143, new Guid("5ff347d7-57ba-4407-9f05-6f1ecabf5308"), "تازه شهر", 7 },
                    { 114, new Guid("fec9c090-fe6f-41e6-b249-fbc2bcc5cc45"), "بيجار", 6 },
                    { 142, new Guid("e737e0f1-b7a1-417e-abe5-70f4e8bed146"), "بوکان", 7 },
                    { 140, new Guid("71b0f8ff-af2c-413f-a22e-91d0c9910b59"), "باروق", 7 },
                    { 139, new Guid("779301d9-4902-4fea-a5cd-a7394a5e2211"), "ايواوغلي", 7 },
                    { 138, new Guid("9542fa90-8987-4371-a199-a55e43ee3146"), "اشنويه", 7 },
                    { 137, new Guid("5bcf8db1-a33e-419e-99a2-7d866a5f2763"), "اروميه", 7 },
                    { 136, new Guid("7c8ec6c5-5200-4722-9168-9164638c164d"), "آواجيق", 7 },
                    { 135, new Guid("3a850ad4-de88-485c-9dfb-b2bcbfc26fa1"), "کاني سور", 6 },
                    { 134, new Guid("b9b337d7-3b63-4650-90eb-cc1f3f07116d"), "کاني دينار", 6 },
                    { 141, new Guid("ab7c763e-77ec-49c6-93cf-b5ba5692f52d"), "بازرگان", 7 },
                    { 151, new Guid("6929ae4e-2c3f-49a3-86fc-f5a4524770c5"), "سرو", 7 },
                    { 113, new Guid("81f21120-d04c-4b90-bc50-4518fd91417b"), "بوئين سفلي", 6 },
                    { 111, new Guid("75639808-35f7-4f62-bbc0-c7fe67fb2ac4"), "برده رشه", 6 },
                    { 90, new Guid("ed3c0343-774d-4c69-8da0-36a9831cb09d"), "ماهدشت", 4 },
                    { 89, new Guid("5cda8dd8-1ab6-41bb-9f6b-29b588ebe5a3"), "فرديس", 4 },
                    { 88, new Guid("e7d6867a-7130-4d09-bb91-bad75b92fe53"), "طالقان", 4 },
                    { 87, new Guid("7020f2b0-d622-404c-a44e-fd78f93d984d"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("36da7d23-c38b-4eb9-9a7c-a5c95c55d5b5"), "تنکمان", 4 },
                    { 85, new Guid("c7e7390e-e96d-4cea-b3b8-08e1fffd2b4b"), "اشتهارد", 4 },
                    { 84, new Guid("7152852a-729e-4428-b274-7f230c4ac346"), "آسارا", 4 },
                    { 83, new Guid("fb559db9-15df-436b-8076-2967a403655d"), "گرمه", 3 },
                    { 82, new Guid("4ae75433-8fdf-4174-b2c9-84b0bf2c6606"), "چناران شهر", 3 },
                    { 81, new Guid("e89c50da-0349-4425-9de4-fd96b3a755b9"), "پيش قلعه", 3 },
                    { 80, new Guid("a04fdd4a-11a3-450c-9e9a-c15db75b8c10"), "لوجلي", 3 },
                    { 79, new Guid("4e416533-c156-4585-a3c5-638c3bb0b975"), "قوشخانه", 3 },
                    { 78, new Guid("aeca17e0-6c3a-4c01-abb8-4b0ecc91cfa6"), "قاضي", 3 },
                    { 77, new Guid("a67468a0-8744-4a99-90ce-4293f6b6d5eb"), "فاروج", 3 },
                    { 76, new Guid("79ca8378-df04-461d-b5ad-71fe4f9e32cf"), "صفي آباد", 3 },
                    { 91, new Guid("ec914154-fd98-4bc7-a1c3-86d66194f00d"), "محمد شهر", 4 },
                    { 92, new Guid("b8e8113f-dc53-456e-8205-5e329de3dab0"), "مشکين دشت", 4 },
                    { 93, new Guid("861dec6b-f7bb-4f84-9da1-1ff77abfaefb"), "نظر آباد", 4 },
                    { 94, new Guid("28ed71ef-98e6-48a5-9210-8da81f3e1b0a"), "هشتگرد", 4 },
                    { 110, new Guid("81b756d8-275b-4094-bf0c-afba62d8b6e1"), "بانه", 6 },
                    { 109, new Guid("395b6f48-0770-495a-817d-db83f75ccf47"), "بابارشاني", 6 },
                    { 108, new Guid("7321a6fe-0d62-48cb-9ad5-79adadba3648"), "اورامان تخت", 6 },
                    { 107, new Guid("5604d1cc-df79-483d-8290-cc4c06812830"), "آرمرده", 6 },
                    { 106, new Guid("97b9400f-38e8-4226-8acb-866764fd4db0"), "کهک", 5 },
                    { 105, new Guid("8531cb42-40d6-4edc-a7a9-965177ad0f8e"), "قنوات", 5 },
                    { 104, new Guid("8a6da6ab-73b3-4f38-ad42-2c3aa187d651"), "قم", 5 },
                    { 112, new Guid("f0742e80-f723-429b-b1b2-1ad9abaedf02"), "بلبان آباد", 6 },
                    { 103, new Guid("adbc37cd-129d-40f3-84b3-424be0cd9c34"), "سلفچگان", 5 },
                    { 101, new Guid("2181c282-d457-4366-8b47-fa340286c735"), "جعفريه", 5 },
                    { 100, new Guid("23fee152-6f3b-4642-9a8e-66740f559b4a"), "گلسار", 4 },
                    { 99, new Guid("6fa9105e-b871-4539-9047-bcb4db7571b0"), "گرمدره", 4 },
                    { 98, new Guid("1677418a-3525-4b16-932c-be42e6c3b23c"), "کوهسار", 4 },
                    { 97, new Guid("82d57864-99df-4019-9d8a-4e49b9b37f2e"), "کمال شهر", 4 },
                    { 96, new Guid("4f281503-ed6b-4894-8f99-2256d81b3551"), "کرج", 4 },
                    { 95, new Guid("b4dcb7a5-f865-4d9d-bb9f-d1adbc23f62d"), "چهارباغ", 4 },
                    { 102, new Guid("36cb2ee1-65e5-4fc9-8686-dc65a65fdd1e"), "دستجرد", 5 },
                    { 306, new Guid("b402e108-53b4-498d-bd43-aac3300ca9de"), "عشق آباد", 10 },
                    { 307, new Guid("af3a50d0-eb64-4ee1-b1ed-33260dce4f8c"), "فردوس", 10 },
                    { 308, new Guid("728e1f1a-a8c3-489f-8b6f-a15efedd2e0d"), "قائن", 10 },
                    { 518, new Guid("93fdfd2a-3003-4743-a27d-16ffa30b5ef9"), "هادي شهر", 15 },
                    { 517, new Guid("1683d44d-8b77-4955-9b4a-90ccf38a36bb"), "نکا", 15 },
                    { 516, new Guid("651dc0f6-a916-489e-8861-eb4772243e00"), "نوشهر", 15 },
                    { 515, new Guid("73cd3af6-dfaf-40ac-9709-9e62d60a004e"), "نور", 15 },
                    { 514, new Guid("6199c8d2-8f12-4274-9090-35edee63feae"), "نشتارود", 15 },
                    { 513, new Guid("72a364f9-e73d-42a2-94a2-61e8f700767e"), "مرزيکلا", 15 },
                    { 512, new Guid("e45947dc-2b36-45eb-9870-ca9b4d95e920"), "مرزن آباد", 15 },
                    { 511, new Guid("2b610f5a-9cc5-4463-8074-adc24bd8feab"), "محمود آباد", 15 },
                    { 510, new Guid("9df2af43-1111-4dd7-a472-35c7352d1cd5"), "قائم شهر", 15 },
                    { 509, new Guid("a85bb58b-e273-4d67-a657-ca3442f761e8"), "فريم", 15 },
                    { 508, new Guid("82896285-3183-4c3b-bdda-c219dad20c47"), "فريدونکنار", 15 },
                    { 507, new Guid("46060f6e-892f-4906-a5ac-0dc82d4b2f20"), "عباس آباد", 15 },
                    { 506, new Guid("de1a0a2b-ff26-45d0-8b35-de96064602b4"), "شيرگاه", 15 },
                    { 505, new Guid("7531de0e-f037-47eb-8962-ff449cde983b"), "شيرود", 15 },
                    { 504, new Guid("c454b7fe-f91c-48c7-af91-09340c09bf46"), "سورک", 15 },
                    { 519, new Guid("e3d38afb-d50e-4555-a96b-fe7667f9d1ab"), "هچيرود", 15 },
                    { 503, new Guid("210fc35a-85b5-44da-84d7-2d253a1a95a3"), "سلمان شهر", 15 },
                    { 520, new Guid("378e5929-8a58-4133-9742-69f411088054"), "پايين هولار", 15 },
                    { 522, new Guid("9a65ff09-f34a-4776-a051-55890e874612"), "پول", 15 },
                    { 537, new Guid("e33510d1-c10b-484f-bf72-efca113f344b"), "آوج", 16 },
                    { 536, new Guid("94285e87-3c40-44f7-ba5b-be252f42865f"), "آبگرم", 16 },
                    { 535, new Guid("8dd7763a-e949-4e44-99a4-2ca82388f170"), "آبيک", 16 },
                    { 534, new Guid("f195824a-f124-4481-9378-7bfc54384952"), "گلوگاه", 15 },
                    { 533, new Guid("5933a16e-a18a-432b-a812-74c6e483ffc3"), "گزنک", 15 },
                    { 532, new Guid("38a79627-32e1-4e50-b4ec-22933227ecff"), "گتاب", 15 },
                    { 531, new Guid("43f792e3-c95b-4033-b988-35b72da24ec9"), "کياکلا", 15 },
                    { 530, new Guid("bc70b2d2-1f12-42df-954b-cb4ae098faad"), "کياسر", 15 },
                    { 529, new Guid("b8627608-7f00-438a-aa80-667ff0f6cf69"), "کوهي خيل", 15 },
                    { 528, new Guid("5c7e12e6-23b2-41a1-816f-44cd3fc73ee7"), "کلاردشت", 15 },
                    { 527, new Guid("b02d64fd-ded0-45ad-bdee-55fe4b094dde"), "کلارآباد", 15 },
                    { 526, new Guid("a1aafbb3-581d-4ad8-870d-ce28406b5c01"), "کجور", 15 },
                    { 525, new Guid("ec1c9353-5338-4504-8137-37c75abf5fd8"), "کتالم و سادات شهر", 15 },
                    { 524, new Guid("98f1d137-758c-4e82-b1dd-0debee531820"), "چمستان", 15 },
                    { 523, new Guid("7810840b-8238-48f5-a8bb-2a38085e8d70"), "چالوس", 15 },
                    { 521, new Guid("e4a7a182-ef16-4e5b-8f87-2006999e193e"), "پل سفيد", 15 },
                    { 502, new Guid("4849bd67-d5ec-45ff-9ed5-ddb9cfd7b530"), "سرخرود", 15 },
                    { 501, new Guid("9960f189-71b1-4be2-a300-8fa88a1de248"), "ساري", 15 },
                    { 500, new Guid("0b73420f-3969-462d-b4dc-c52c4aeec4a1"), "زيرآب", 15 },
                    { 479, new Guid("611b62ac-d19f-43ac-afd3-92425837bb43"), "آمل", 15 },
                    { 478, new Guid("3ac8f544-7cdd-491b-9865-47f68bf98d86"), "آلاشت", 15 },
                    { 477, new Guid("ffbbc12c-aa8c-4844-a976-41dbcbabcf69"), "گنبدکاووس", 14 },
                    { 476, new Guid("0a2dbc26-bb65-46af-8724-09bf28e785de"), "گميش تپه", 14 },
                    { 475, new Guid("adb38491-d63f-42da-8a12-257c6ece1b6b"), "گرگان", 14 },
                    { 474, new Guid("b994c526-08cf-45f8-8e40-dc21651c828b"), "گاليکش", 14 },
                    { 473, new Guid("3727d984-8cf4-4254-b1f5-8b113c154ae3"), "کلاله", 14 },
                    { 472, new Guid("4ec18ff9-4122-4c3f-9bed-63570283ae73"), "کرد کوي", 14 },
                    { 471, new Guid("f644ca9e-0309-4777-91f7-e529d6046849"), "نگين شهر", 14 },
                    { 470, new Guid("dab95a22-769c-4fc1-adbb-9d9e6b4be8f2"), "نوکنده", 14 },
                    { 469, new Guid("36342549-125f-4a85-94b8-4c826c6c4b43"), "نوده خاندوز", 14 },
                    { 468, new Guid("1d22c46c-76f0-4fad-a1ed-72f83969844c"), "مينودشت", 14 },
                    { 467, new Guid("e19297b9-e0cb-4972-a523-b55fd0138188"), "مزرعه", 14 },
                    { 466, new Guid("54613e24-a6a6-4680-87c2-13a47c580afc"), "مراوه تپه", 14 },
                    { 465, new Guid("84e833f5-b4f0-4d3c-a5f4-6b9b59b46348"), "فراغي", 14 },
                    { 480, new Guid("732347e5-f04a-428b-885f-71c0130529a8"), "ارطه", 15 },
                    { 481, new Guid("d991d561-9f4e-435d-ab9e-c7ecc772d0d5"), "امامزاده عبدالله", 15 },
                    { 482, new Guid("f514fc4d-56c0-4da2-bac6-15c2c7e8904c"), "امير کلا", 15 },
                    { 483, new Guid("d5142c11-90f5-4eb6-8dc7-cc2c18b19882"), "ايزد شهر", 15 },
                    { 499, new Guid("d08937b3-3b2d-4a1e-8807-1e6b4ca8e124"), "زرگر محله", 15 },
                    { 498, new Guid("8266767d-aea8-4687-b86e-f7eac960a2b3"), "رينه", 15 },
                    { 497, new Guid("c081304e-c207-417a-994f-04c49fcc02df"), "رويان", 15 },
                    { 496, new Guid("f44bfcf8-ffa0-4e83-b546-28f2fe278e4e"), "رستمکلا", 15 },
                    { 495, new Guid("7b2d968b-e4a1-47ed-92e9-77baf99385ff"), "رامسر", 15 },
                    { 494, new Guid("c6490d1c-cc0b-4768-9cc6-187b3c331dc7"), "دابودشت", 15 },
                    { 493, new Guid("1d9a2d41-180e-47c3-99f7-9f8f7726ab84"), "خوش رودپي", 15 },
                    { 538, new Guid("10c786ad-3cf5-416f-9712-e42f40495a51"), "ارداق", 16 },
                    { 492, new Guid("37be9005-8ceb-494c-88d8-b973e3877a73"), "خليل شهر", 15 },
                    { 490, new Guid("5d12693b-3fdb-4658-a9e2-6c566a679a33"), "جويبار", 15 },
                    { 489, new Guid("378dd914-bc8d-4189-98ec-dbbbe53e8417"), "تنکابن", 15 },
                    { 488, new Guid("d2815562-61cf-49e4-b404-62ef6b90b551"), "بهنمير", 15 },
                    { 487, new Guid("7689a042-bf42-42f5-9ac1-6794abf0db5f"), "بهشهر", 15 },
                    { 486, new Guid("eb153751-5f55-4d4e-9634-6424b3fc5aad"), "بلده", 15 },
                    { 485, new Guid("848d553b-3d84-4173-b3a4-bab0906d2861"), "بابلسر", 15 },
                    { 484, new Guid("7470d425-d39b-4f2a-ad43-48e372b26dbd"), "بابل", 15 },
                    { 491, new Guid("33cc388c-4718-443e-9914-f6460748c47c"), "خرم آباد", 15 },
                    { 539, new Guid("71a1921e-2c1b-4bbd-822c-ca8092fc529e"), "اسفرورين", 16 },
                    { 540, new Guid("f6b65623-f3bc-4df0-81d2-6cfd28b7c7d2"), "اقباليه", 16 },
                    { 541, new Guid("ab498781-e9ae-4aae-a6ef-d8ad28acaed8"), "الوند", 16 },
                    { 595, new Guid("8edd887b-dec5-4e68-96bf-17afc6b2f1ca"), "سرعين", 18 },
                    { 594, new Guid("d1f5dc29-588e-478c-ae30-12a598a6e0a7"), "رضي", 18 },
                    { 593, new Guid("5b0da3c0-ae22-480c-b1f2-ba94d1a30535"), "خلخال", 18 },
                    { 592, new Guid("55add2b2-a7f0-48cb-846c-a949b400eca5"), "جعفر آباد", 18 },
                    { 591, new Guid("44f97138-c382-451e-8fac-3a44af92fb25"), "تازه کند انگوت", 18 },
                    { 590, new Guid("e726678b-c44e-4f9e-b9a4-f6a9b0bf7e6d"), "تازه کند", 18 },
                    { 589, new Guid("176114a1-bd88-4d62-8d80-6d2fc27f5ece"), "بيله سوار", 18 },
                    { 588, new Guid("03e8364c-752f-49d7-a13b-55e3c28a35f0"), "اصلاندوز", 18 },
                    { 587, new Guid("4e4a5cb5-5fb5-401e-a63c-6350147ba140"), "اسلام آباد", 18 },
                    { 586, new Guid("7581de48-2479-481b-842f-ba5193d059d4"), "اردبيل", 18 },
                    { 585, new Guid("985c6680-2b72-42da-a7ac-c7678d15bf4e"), "آبي بيگلو", 18 },
                    { 584, new Guid("e331987d-2e60-43de-8fda-7d9976e92764"), "گراب", 17 },
                    { 583, new Guid("ee3c27fe-9687-47fc-a0d4-9f9ed3ea339c"), "کوهناني", 17 },
                    { 582, new Guid("0e043c56-ad73-4f05-b571-21ebeb7d0f02"), "کوهدشت", 17 },
                    { 581, new Guid("a57c49e6-3561-4d62-ba63-88f8982c81d3"), "چقابل", 17 },
                    { 596, new Guid("9a69e8d7-7071-47db-8339-1e9e8b93d855"), "عنبران", 18 },
                    { 597, new Guid("26ae353a-cef3-46da-b51a-35151fed69b0"), "فخرآباد", 18 },
                    { 598, new Guid("11580cb7-85d1-49cd-9631-7ead5c563919"), "قصابه", 18 },
                    { 599, new Guid("b7eef9ac-11d3-428d-be6a-cece506e86a2"), "لاهرود", 18 },
                    { 615, new Guid("16f19c98-90b6-4869-aee7-2c753f06f875"), "اصغرآباد", 19 },
                    { 614, new Guid("a9bee3c2-3d71-478d-bf70-d291d635187c"), "اردستان", 19 },
                    { 613, new Guid("7c5fc027-9780-401a-a8b9-d77e855b56aa"), "ابوزيد آباد", 19 },
                    { 612, new Guid("d5d6c726-c6f8-4697-9bda-bddbbec88910"), "ابريشم", 19 },
                    { 611, new Guid("008a3cfd-3f9b-4993-a692-fc2636529d02"), "آران و بيدگل", 19 },
                    { 610, new Guid("677af7be-89a3-45c4-9a30-e77fce0ea488"), "گيوي", 18 },
                    { 609, new Guid("04ba694e-2d3b-4a96-a800-acde3caff495"), "گرمي", 18 },
                    { 580, new Guid("2f4ca4c3-7968-4749-915d-4e2d7396721f"), "چالانچولان", 17 },
                    { 608, new Guid("b4bbc64f-ad5e-477e-bb11-57c560b75a4d"), "کورائيم", 18 },
                    { 606, new Guid("5f30619e-1eb6-49aa-8c8f-7919b1284152"), "پارس آباد", 18 },
                    { 605, new Guid("701f0639-0d1a-411d-820d-f479a1b586cd"), "هير", 18 },
                    { 604, new Guid("134ace97-7e44-44db-99fb-1503f3a4c7ba"), "هشتجين", 18 },
                    { 603, new Guid("33456935-b564-432e-91e4-9b2ee20b373b"), "نير", 18 },
                    { 602, new Guid("02dcb8de-60e4-4bba-a884-210e94f6dd1d"), "نمين", 18 },
                    { 601, new Guid("9007390a-928b-4403-80df-c53f5b1ddf0d"), "مشگين شهر", 18 },
                    { 600, new Guid("51d047df-51d2-44f6-9c9a-7c5baa293622"), "مرادلو", 18 },
                    { 607, new Guid("2a30449e-1220-47bd-8ca5-0c0a1d8bca24"), "کلور", 18 },
                    { 464, new Guid("d606122b-1763-494d-bba1-d6ea4573b8e3"), "فاضل آباد", 14 },
                    { 579, new Guid("e38751f6-0720-41fd-884e-5996ed6d6989"), "پلدختر", 17 },
                    { 577, new Guid("6b76f78b-008d-4fc9-ac2f-0dabe8dc56e6"), "هفت چشمه", 17 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 556, new Guid("161416b6-073f-4881-b6d3-c0a7e1042a43"), "محمود آباد نمونه", 16 },
                    { 555, new Guid("303d29dc-62f3-4cdd-af61-178f04dc080f"), "محمديه", 16 },
                    { 554, new Guid("653ab92d-79b6-403f-a298-6201d33d8744"), "قزوين", 16 },
                    { 553, new Guid("12112414-89e1-4332-924a-a903fd964022"), "ضياء آباد", 16 },
                    { 552, new Guid("b6f53d53-e5df-4286-ba86-2a508b41ec2c"), "شريفيه", 16 },
                    { 551, new Guid("45f28bbd-c711-4a31-9630-d6861beac5f5"), "شال", 16 },
                    { 550, new Guid("551f5dfd-5163-40ea-9f3f-4b9baa4fea70"), "سگز آباد", 16 },
                    { 549, new Guid("2a8b7c89-4bba-42fb-ab85-4c71007fd6c2"), "سيردان", 16 },
                    { 548, new Guid("a0c7e604-c731-43e5-af69-6c2a1fa9f385"), "رازميان", 16 },
                    { 547, new Guid("c2026bfc-528e-4a4d-86b7-6dca34efb171"), "دانسفهان", 16 },
                    { 546, new Guid("94c62200-2287-4d80-895d-c914832efe99"), "خرمدشت", 16 },
                    { 545, new Guid("f15660d6-6d41-4ba2-8ab5-a1c83024865b"), "خاکعلي", 16 },
                    { 544, new Guid("c177baea-f18a-4a9b-bda5-5039bcbe9883"), "تاکستان", 16 },
                    { 543, new Guid("51b9b0ea-9527-4972-93b3-4afbd2e4cf64"), "بيدستان", 16 },
                    { 542, new Guid("d7125a8d-4958-4ddc-b649-f698554569f8"), "بوئين زهرا", 16 },
                    { 557, new Guid("28a269d7-3d4a-4277-8da0-24d158bfc29e"), "معلم کلايه", 16 },
                    { 558, new Guid("99b1ae44-8c9c-4ad9-935e-52e3739082c0"), "نرجه", 16 },
                    { 559, new Guid("84a6b116-86c8-4ebc-bef7-5c366823361c"), "کوهين", 16 },
                    { 560, new Guid("c3e03b50-7ff4-4926-820a-33af916ed0cb"), "ازنا", 17 },
                    { 576, new Guid("0d2fedaf-2051-4179-a443-bb5814c4b9f4"), "نورآباد", 17 },
                    { 575, new Guid("9847d832-b99c-4b5e-a23b-d5098bb84c91"), "مومن آباد", 17 },
                    { 574, new Guid("9a5a282f-8375-421f-9598-5dc2f7db9e7f"), "معمولان", 17 },
                    { 573, new Guid("0fe64acb-53f8-49ff-8aa3-15f00d0e520f"), "فيروزآباد", 17 },
                    { 572, new Guid("0ff8dd72-d6bf-493b-b7c9-62950399f457"), "شول آباد", 17 },
                    { 571, new Guid("6b11f647-0fbd-4112-ba06-4ee410b1fa9a"), "سپيد دشت", 17 },
                    { 570, new Guid("f8443eac-35ef-45c9-a8d2-8cd9ce92ea66"), "سراب دوره", 17 },
                    { 578, new Guid("2a67d057-8db8-4c9d-b6b8-7844c867024f"), "ويسيان", 17 },
                    { 569, new Guid("49998902-8eb3-41ff-b3db-fe993f9740ce"), "زاغه", 17 },
                    { 567, new Guid("c6c0875e-cd8d-4f76-9c1e-750ff5e16eea"), "درب گنبد", 17 },
                    { 566, new Guid("09b15847-dc34-431f-aa61-4378bc0553c6"), "خرم آباد", 17 },
                    { 565, new Guid("24581973-41b2-48a6-99ac-c121866e9c3b"), "بيرانشهر", 17 },
                    { 564, new Guid("39ec316e-5ef7-4ab1-8343-feb8d0a290b9"), "بروجرد", 17 },
                    { 563, new Guid("f2cdd34c-bc21-4677-bbf4-ea7bbf3f234f"), "اليگودرز", 17 },
                    { 562, new Guid("7e337594-8007-4f29-be6a-a1a67d6d5e3b"), "الشتر", 17 },
                    { 561, new Guid("82135c2a-bb12-422e-a166-71369bef64ee"), "اشترينان", 17 },
                    { 568, new Guid("62f36fdb-1be4-45ba-9747-cd282c050d71"), "دورود", 17 },
                    { 463, new Guid("3ed6aa40-c76d-4351-b1a4-689c0646d55c"), "علي آباد", 14 },
                    { 462, new Guid("29604faf-0cb2-4db9-ace6-5f5d839b7881"), "سيمين شهر", 14 },
                    { 461, new Guid("2648dafa-652c-44a2-9cff-a55db11bb775"), "سنگدوين", 14 },
                    { 362, new Guid("0ebcf8fc-483d-4056-978c-9095ea3d7cb9"), "شوشتر", 11 },
                    { 361, new Guid("2d21f208-03b0-407c-b443-25a538e09eeb"), "شوش", 11 },
                    { 360, new Guid("78710032-edb2-4fe5-8662-ca6243ba4263"), "شهر امام", 11 },
                    { 359, new Guid("2b3f8455-6549-4aff-9886-763f1223a750"), "شمس آباد", 11 },
                    { 358, new Guid("2cf1ed31-15cc-4435-8fa7-bbd1b7851851"), "شرافت", 11 },
                    { 357, new Guid("bfd746ea-a9d0-4847-9506-c854b8fff6eb"), "شاوور", 11 },
                    { 356, new Guid("dbdfc77b-07c6-493f-aeb1-5a901c2b4f05"), "شادگان", 11 },
                    { 355, new Guid("658d681a-6321-4f9f-9839-f5341cdf6340"), "سياه منصور", 11 },
                    { 354, new Guid("c00e59ef-db82-4e79-abf7-1cbf066b6b01"), "سوسنگرد", 11 },
                    { 353, new Guid("ebd4adb9-cdb8-49b0-b556-ff42372eff7a"), "سماله", 11 },
                    { 352, new Guid("bff355df-30de-48f6-b4f6-b225ec2b33f8"), "سردشت", 11 },
                    { 351, new Guid("927907f9-8761-4228-a82a-50e752127776"), "سرداران", 11 },
                    { 350, new Guid("23c18ee0-dbab-4bb1-9e57-e89b4d8e1f07"), "سالند", 11 },
                    { 349, new Guid("182d5e6a-c921-46dc-8e9d-63bdb385a9ac"), "زهره", 11 },
                    { 348, new Guid("ad1d0eaf-046a-47c9-9099-1ff732b32e22"), "رفيع", 11 },
                    { 363, new Guid("ddc92cb9-86e3-4e5b-9499-c85b1af27e58"), "شيبان", 11 },
                    { 364, new Guid("6b92dc19-e715-4ae0-b188-6331d624f71d"), "صالح شهر", 11 },
                    { 365, new Guid("a34eb826-d042-43d2-9f3b-f226c4b723b5"), "صفي آباد", 11 },
                    { 366, new Guid("4c239517-af94-4974-a727-3c05ebeb51e9"), "صيدون", 11 },
                    { 382, new Guid("b2c808af-e4a2-470c-af1a-fd85049522ca"), "ويس", 11 },
                    { 381, new Guid("c120269c-d717-42bc-9b63-42c95d59ae30"), "هويزه", 11 },
                    { 380, new Guid("6cf598b8-ab0f-46eb-940c-e7db06b8bd63"), "هنديجان", 11 },
                    { 379, new Guid("ef41acc6-b666-49ae-8ac1-3d1cf1dbd36c"), "هفتگل", 11 },
                    { 378, new Guid("069a7a69-c5d2-45f3-92ad-949f45bf5ce3"), "مينوشهر", 11 },
                    { 377, new Guid("3762fbd2-88e6-4bfd-9d31-3a4c6298fc04"), "ميداود", 11 },
                    { 376, new Guid("363877cd-efec-41ec-9e8d-c300ce060c40"), "ميانرود", 11 },
                    { 347, new Guid("52f39174-beaf-4d62-bbab-f575e0cdbada"), "رامهرمز", 11 },
                    { 375, new Guid("3e9420d1-8c5c-48a5-9e47-075c3b5abbee"), "منصوريه", 11 },
                    { 373, new Guid("0c86819d-ddcd-4c59-a9be-f66ac7242d08"), "مقاومت", 11 },
                    { 372, new Guid("3a6bb8d4-1204-4821-ba85-7f97b47446ed"), "مشراگه", 11 },
                    { 371, new Guid("44a27574-4e34-416f-8a8b-d1b1aa9aa648"), "مسجد سليمان", 11 },
                    { 370, new Guid("91575da2-6d0c-4064-bc4d-df453c92c5b8"), "لالي", 11 },
                    { 369, new Guid("de218a42-76c2-40fa-8051-522d98331758"), "قلعه خواجه", 11 },
                    { 368, new Guid("dacaec8b-462f-4851-8b9e-0dfeae7daa30"), "قلعه تل", 11 },
                    { 367, new Guid("ca21120a-36d7-4a02-8933-0dae31a8950c"), "فتح المبين", 11 },
                    { 374, new Guid("2270d3aa-b618-409e-b168-3af170f76280"), "ملاثاني", 11 },
                    { 383, new Guid("5d4743cb-9c69-48f7-9e73-480949c3f9b4"), "چغاميش", 11 },
                    { 346, new Guid("0fda1fac-c8e7-4013-be87-c7d49c813503"), "رامشير", 11 },
                    { 344, new Guid("3191cf1b-1a9d-494f-8812-6541c942c1b9"), "دزفول", 11 },
                    { 323, new Guid("5379e087-b69d-433a-85ec-94f67a65d50e"), "اميديه", 11 },
                    { 322, new Guid("d19d5b4b-37ab-44ed-9f5a-59933030dd9b"), "الوان", 11 },
                    { 321, new Guid("2c744528-3b6d-4eae-959f-528ff60b9c9e"), "الهايي", 11 },
                    { 320, new Guid("3bff3ec3-9ae1-4ec6-b503-ffc3307b7c98"), "اروند کنار", 11 },
                    { 319, new Guid("8f61d7ab-3cbc-4030-a572-db93f88821b3"), "ابوحميظه", 11 },
                    { 318, new Guid("61ef276d-91b7-45d6-b1c3-49ad21a777d5"), "آغاجاري", 11 },
                    { 317, new Guid("5856022b-dc28-4c1e-b499-2cc668381b8b"), "آزادي", 11 },
                    { 316, new Guid("fc28ea79-a6d3-471d-8261-062beb5bb4c4"), "آبژدان", 11 },
                    { 315, new Guid("7c49595f-0e51-4fb2-9968-4f07f019e0ea"), "آبادان", 11 },
                    { 314, new Guid("9e2b18ec-b02f-42b4-aa66-95eface2e83f"), "گزيک", 10 },
                    { 313, new Guid("37a01d72-d2ee-4ecf-bfba-4d4ce98c2132"), "نيمبلوک", 10 },
                    { 312, new Guid("492b2d2a-1e17-4620-a958-24d91b28dfb8"), "نهبندان", 10 },
                    { 311, new Guid("df3e8cc0-02dd-4eec-a305-8ab8b3ef2d8c"), "مود", 10 },
                    { 310, new Guid("24d92153-ec62-4077-a13a-9ab232e7a0b3"), "محمدشهر", 10 },
                    { 309, new Guid("07e8253e-b19c-434b-9e84-3e7649fa7cc5"), "قهستان", 10 },
                    { 324, new Guid("13a04976-d6e6-4287-a8da-6bece77da47d"), "انديمشک", 11 },
                    { 325, new Guid("a069d830-507c-494f-8d13-0a927ad49d27"), "اهواز", 11 },
                    { 326, new Guid("f535df59-ed03-4c86-a7c6-de88eb8756f1"), "ايذه", 11 },
                    { 327, new Guid("34376cb7-af0b-412b-8035-126d740e50fc"), "باغ ملک", 11 },
                    { 343, new Guid("58733e6e-c42c-444e-b7c7-71ffc1b5a65f"), "دارخوين", 11 },
                    { 342, new Guid("d1703aa2-0e5e-42d7-9dfe-1ce43a092fd4"), "خنافره", 11 },
                    { 341, new Guid("80ca073c-ef30-4611-bf07-97b1165e668d"), "خرمشهر", 11 },
                    { 340, new Guid("1f324528-d1c6-4bd0-a48e-b7c91f2d55a0"), "حميديه", 11 },
                    { 339, new Guid("80d27b72-e763-478b-967e-760a5df79e85"), "حمزه", 11 },
                    { 338, new Guid("3107e0ee-7071-48ca-9b85-4f8b7857524c"), "حسينيه", 11 },
                    { 337, new Guid("5d2cef34-eaee-4325-8e28-d3065de7daaa"), "حر", 11 },
                    { 345, new Guid("043183d2-0fe4-4a6c-bdb6-a774ee07da6c"), "دهدز", 11 },
                    { 336, new Guid("c27d0429-843e-4e31-9b72-61421d0dec20"), "جنت مکان", 11 },
                    { 334, new Guid("50af6add-2686-489c-a1b0-9591e06f1065"), "تشان", 11 },
                    { 333, new Guid("783eed85-1e00-42d1-977e-95fb0e7695a0"), "ترکالکي", 11 },
                    { 332, new Guid("29a8a713-68fe-46d9-809f-487385597af6"), "بيدروبه", 11 },
                    { 331, new Guid("26420e17-69d5-4a0d-8ab2-c2563f33c319"), "بهبهان", 11 },
                    { 330, new Guid("e0aff2ec-d9c7-42fa-acaa-e975e25d03bc"), "بندر ماهشهر", 11 },
                    { 329, new Guid("7c55073c-861a-4ef0-9a0a-e63cd683c10f"), "بندر امام خميني", 11 },
                    { 328, new Guid("a364b913-eb60-4d03-876c-072a98e5f2a9"), "بستان", 11 },
                    { 335, new Guid("57e9628c-e834-42f4-be97-252e7ccd5049"), "جايزان", 11 },
                    { 617, new Guid("74ccb49c-dedd-49c9-b259-0faa70c3b2f2"), "افوس", 19 },
                    { 384, new Guid("ae6956ca-11b8-4cf6-a076-a2262a5e56bb"), "چم گلک", 11 },
                    { 386, new Guid("7dd2ba5a-5dc3-47bd-b215-3079b439d2a2"), "چوئبده", 11 },
                    { 440, new Guid("db1b87b7-8fcb-4b63-b9a7-97fd3cf33ab7"), "صائين قلعه", 13 },
                    { 439, new Guid("813eccbd-e87d-4392-9da2-eecebc44d015"), "سهرورد", 13 },
                    { 438, new Guid("67b0db01-8ba7-4136-946f-4bfe701b6db2"), "سلطانيه", 13 },
                    { 437, new Guid("eb305c2d-fbde-44d2-9efc-0438e266d452"), "سجاس", 13 },
                    { 436, new Guid("9a1ef4ad-99c6-446a-8368-1bd4f4047ed5"), "زنجان", 13 },
                    { 435, new Guid("cae825ce-ad39-4e25-a905-c7e3b1e8f6e1"), "زرين رود", 13 },
                    { 434, new Guid("4cd769f4-7be7-478b-aeb4-575cf2e8c178"), "زرين آباد", 13 },
                    { 433, new Guid("0a190f9a-fd4d-4485-88b3-f876d3d7242c"), "دندي", 13 },
                    { 432, new Guid("9cae29d9-7942-443e-912e-cc88287d09e6"), "خرمدره", 13 },
                    { 431, new Guid("547f3602-2bd9-49a6-869b-5e1f82d55c57"), "حلب", 13 },
                    { 430, new Guid("67ea66cc-ec90-40cf-b71b-38e4f7154df8"), "ارمخانخانه", 13 },
                    { 429, new Guid("da1e6a8e-9fdf-45a0-ad3f-7eb616122414"), "ابهر", 13 },
                    { 428, new Guid("c3d173f1-a817-4c1d-80ca-6bcc9932f78e"), "آب بر", 13 },
                    { 427, new Guid("207b8a42-cc40-4a80-8445-d50b12fe4bae"), "کلمه", 12 },
                    { 426, new Guid("8be97705-c176-495b-8500-e25f2d61e0ea"), "کاکي", 12 },
                    { 441, new Guid("4769a918-6ef3-48f4-8054-ba66a2e1f521"), "قيدار", 13 },
                    { 442, new Guid("54aa09a3-dd44-4a2f-9c77-f9b40565eb35"), "ماه نشان", 13 },
                    { 443, new Guid("5b93a6ac-0160-45d7-82d6-9a6b9c4c7caf"), "نوربهار", 13 },
                    { 444, new Guid("3414c9bd-dfff-48d6-b753-bc5a97875300"), "نيک پي", 13 },
                    { 460, new Guid("603802d1-944c-4e01-ba44-7e304255d0ab"), "سرخنکلاته", 14 },
                    { 459, new Guid("10d40af3-b66b-42c6-bc3b-e6b3c9932790"), "راميان", 14 },
                    { 458, new Guid("de84cdb9-842b-459c-ab2d-4e8096610dc0"), "دلند", 14 },
                    { 457, new Guid("4e16e824-ae3a-4529-9804-4c6c6c37b39a"), "خان ببين", 14 },
                    { 456, new Guid("1b907b04-5d90-4255-99e1-d6c7db81beff"), "جلين", 14 },
                    { 455, new Guid("5254d95a-dd24-4ad3-9cad-151986b65060"), "تاتار عليا", 14 },
                    { 454, new Guid("5d1b60b0-68dc-479a-a33f-a0dcafe00d6b"), "بندر گز", 14 },
                    { 425, new Guid("4f3df522-b0dc-46e8-8213-eb565cbc476b"), "چغادک", 12 },
                    { 453, new Guid("485e2f51-e28c-4175-acd2-52e0423d45ed"), "بندر ترکمن", 14 },
                    { 451, new Guid("70ff7d45-f900-4cc6-8498-03d9ad653531"), "انبار آلوم", 14 },
                    { 450, new Guid("2c9b8b08-544c-4d6a-9f40-c89bb3414a02"), "آق قلا", 14 },
                    { 449, new Guid("138d4e35-4fcb-4d69-aba5-20034ac651ad"), "آزاد شهر", 14 },
                    { 448, new Guid("5aac8da2-93b4-459a-bfa5-a48491f54ec7"), "گرماب", 13 },
                    { 447, new Guid("467722f1-74a2-444e-bea2-db11793aeb8c"), "کرسف", 13 },
                    { 446, new Guid("87561237-f47d-4041-b216-8ecf7486e2f2"), "چورزق", 13 },
                    { 445, new Guid("4c4f648b-d3bc-4146-848a-9b22630c40f0"), "هيدج", 13 },
                    { 452, new Guid("4a87601a-c279-4020-93df-65c01a183361"), "اينچه برون", 14 },
                    { 385, new Guid("e764d057-63fd-45f3-b826-86c2e0ae5be9"), "چمران", 11 },
                    { 424, new Guid("f777ef47-1a9d-468d-bc27-5ffe1eba4fff"), "وحدتيه", 12 },
                    { 422, new Guid("bc4b30ce-bbe6-4e2b-aa9a-36c3174f3920"), "عسلويه", 12 },
                    { 401, new Guid("e030d35f-3e5b-4d6d-93a2-720881853f3d"), "بردستان", 12 },
                    { 400, new Guid("0434a2eb-1183-465d-bf55-e05248423281"), "بردخون", 12 },
                    { 399, new Guid("9df30e81-f798-495c-af1c-78638d739db5"), "برازجان", 12 },
                    { 398, new Guid("8cdc25cb-1947-44ed-8c1d-f389cb6745b0"), "بادوله", 12 },
                    { 397, new Guid("d94c6466-9061-4dff-88da-86bc2281f532"), "اهرم", 12 },
                    { 396, new Guid("342ce2a0-b82b-4f74-8c98-2eb1aeeffbc1"), "انارستان", 12 },
                    { 395, new Guid("e50ff6db-3c3e-4378-8f92-f23e520572ac"), "امام حسن", 12 },
                    { 394, new Guid("6e3abba8-55db-42c7-a754-0a504a3fc326"), "آبپخش", 12 },
                    { 393, new Guid("83dd46ed-5a0d-4639-a29a-cc80d551cc28"), "آبدان", 12 },
                    { 392, new Guid("43cc6212-2e93-40e8-ae8e-eef72768b09b"), "آباد", 12 },
                    { 391, new Guid("838da77a-dc12-4587-878d-c8cc348db206"), "گوريه", 11 },
                    { 390, new Guid("d887e07e-8a5d-4bbe-8f4a-4bf386e38333"), "گلگير", 11 },
                    { 389, new Guid("12d2c215-e308-4598-a17b-bf6abc79cf2a"), "گتوند", 11 },
                    { 388, new Guid("3159b489-b6de-4a1a-85ec-7f35adf38674"), "کوت عبدالله", 11 },
                    { 387, new Guid("1b2de103-c903-496e-9075-c883c1c234a2"), "کوت سيدنعيم", 11 },
                    { 402, new Guid("75dc07b2-5d6a-4c08-a941-3b27299fd1c4"), "بندر دير", 12 },
                    { 403, new Guid("66ebf6f7-90fd-4ddb-a6a9-88d91658d4b4"), "بندر ديلم", 12 },
                    { 404, new Guid("ab7f5a6a-7d81-4b27-9e58-0c50571d7d4f"), "بندر ريگ", 12 },
                    { 405, new Guid("33e02558-9d31-48b9-8b56-a6f8ba2661eb"), "بندر کنگان", 12 },
                    { 421, new Guid("29798bcf-2d17-4118-afec-9959e67c4afb"), "شنبه", 12 },
                    { 420, new Guid("cebd04a0-db69-4482-9148-d87414560f73"), "شبانکاره", 12 },
                    { 419, new Guid("310a07a7-5305-4856-a862-2daed42e0de0"), "سيراف", 12 },
                    { 418, new Guid("a2a698f1-bcc4-4f56-8ebe-686da9030fb3"), "سعد آباد", 12 },
                    { 417, new Guid("463fac75-9028-483a-9425-320fc425c7be"), "ريز", 12 },
                    { 416, new Guid("1f952364-efe1-4673-a7f8-0e11b6d01143"), "دوراهک", 12 },
                    { 415, new Guid("31c1a73d-90fe-403a-bf4e-d90b0d8dd008"), "دلوار", 12 },
                    { 423, new Guid("d1545ed0-a22e-4bbc-8252-878fc8c436ff"), "نخل تقي", 12 },
                    { 414, new Guid("ae870689-ef68-4992-b3f3-671673dc4b5d"), "دالکي", 12 },
                    { 412, new Guid("99a3e929-a8b1-4ed5-9e59-c84066c9ccbd"), "خارک", 12 },
                    { 411, new Guid("7616ad20-f8f6-4e48-a372-a83cd6f69378"), "جم", 12 },
                    { 410, new Guid("d191c4af-6710-46ea-9136-cf62ebb29ce1"), "تنگ ارم", 12 },
                    { 409, new Guid("98ab0ba1-5a8d-4de0-9f09-1ff1d9b90c08"), "بوشکان", 12 },
                    { 408, new Guid("ab8e2fc4-c95c-4153-b9c6-3e9c7a1b5b17"), "بوشهر", 12 },
                    { 407, new Guid("c6e504f1-fc2d-4f38-8e7a-d99f91456bdc"), "بنک", 12 },
                    { 406, new Guid("685d1fbb-0f37-4116-be5d-341f23047ff5"), "بندر گناوه", 12 },
                    { 413, new Guid("19f31193-4ab7-47d7-869a-f734a54219b3"), "خورموج", 12 },
                    { 1238, new Guid("62d7712b-2afc-4415-a970-8f8b53ac38d0"), "پاتاوه", 31 }
                });

            migrationBuilder.InsertData(
                table: "Code",
                columns: new[] { "CodeID", "CodeGroupID", "CodeGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, 1, new Guid("48db4452-5483-4f21-8cf5-139a09a0cbdb"), "png", "image/png" },
                    { 3, 1, new Guid("c67769dd-7485-4f91-9b61-6e00468b58a0"), "jpeg", "image/jpeg" },
                    { 2, 1, new Guid("0d1ea00a-be87-4225-942a-3f49e4b9e973"), "jpg", "image/jpg" }
                });

            migrationBuilder.InsertData(
                table: "SMSSetting",
                columns: new[] { "SMSSettingID", "ModifiedDate", "Name", "SMSProviderConfigurationID", "SMSSettingGUID" },
                values: new object[] { 1, new DateTime(2020, 4, 30, 3, 37, 23, 458, DateTimeKind.Local).AddTicks(119), "Kavenegar", 1, new Guid("608ed63f-3cf6-4a02-b0de-801e691d7a69") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", true, true, "رودکی", new DateTime(2020, 4, 30, 3, 37, 23, 461, DateTimeKind.Local).AddTicks(4262), "09227204305", new DateTime(2020, 4, 30, 3, 37, 23, 461, DateTimeKind.Local).AddTicks(2533), 1, new Guid("4197f64f-9bb0-43c8-ae34-8e391c511227") },
                    { 2, "mahdiih@ymail.com", "مهدی", true, true, "حکمی زاده", new DateTime(2020, 4, 30, 3, 37, 23, 461, DateTimeKind.Local).AddTicks(7164), "09199390494", new DateTime(2020, 4, 30, 3, 37, 23, 461, DateTimeKind.Local).AddTicks(7134), 1, new Guid("ecad63ae-0945-4204-8fd4-aff9432a146d") },
                    { 3, "roozbehshamekhi@hotmail.com", "روزبه", true, true, "شامخی", new DateTime(2020, 4, 30, 3, 37, 23, 461, DateTimeKind.Local).AddTicks(7235), "09128277075", new DateTime(2020, 4, 30, 3, 37, 23, 461, DateTimeKind.Local).AddTicks(7231), 1, new Guid("8c70912a-2c11-486c-9217-ec80b5dbb19c") }
                });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "ModifiedDate", "Name", "SMSSettingID", "SMSTemplateGUID" },
                values: new object[] { 1, new DateTime(2020, 4, 30, 3, 37, 23, 458, DateTimeKind.Local).AddTicks(7856), "VerifyAccount", 1, new Guid("e435ffc6-fc18-4c33-b137-6cde2f969d9d") });

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
