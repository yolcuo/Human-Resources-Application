using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Project.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvanceTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 459, DateTimeKind.Local).AddTicks(2399)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 445, DateTimeKind.Local).AddTicks(9996)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CompanyTitle = table.Column<int>(type: "int", nullable: false),
                    MersisNo = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    TaxNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    LogoPath = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    TaxAdministration = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    YearOfEstablishment = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContactStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContactEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 459, DateTimeKind.Local).AddTicks(920)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(8928)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(7653)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    MaxDays = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(9319)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    District = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Neighbourhood = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Street = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Detail = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(7530)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    SecondName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Surname = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    SecondSurname = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Photo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BirthPlace = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    TC = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    DateOfStartWorking = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateOfStopWorking = table.Column<DateTime>(type: "datetime", nullable: true),
                    Title = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    Department = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,4)", maxLength: 20, nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(4650)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Advances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 459, DateTimeKind.Local).AddTicks(1491)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdvanceTypeID = table.Column<int>(type: "int", nullable: false),
                    CurrencyCode = table.Column<string>(type: "varchar(3)", nullable: false),
                    PersonnelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Advances_AdvanceTypes_AdvanceTypeID",
                        column: x => x.AdvanceTypeID,
                        principalTable: "AdvanceTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advances_AspNetUsers_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Advances_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReplyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DocumentPath = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: true),
                    ExpenseTypeID = table.Column<int>(type: "int", nullable: false),
                    CurrencyCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(6204)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PersonnelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseTypes_ExpenseTypeID",
                        column: x => x.ExpenseTypeID,
                        principalTable: "ExpenseTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(2196)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: true),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    PermissionTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Permissions_AspNetUsers_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionTypes_PermissionTypeID",
                        column: x => x.PermissionTypeID,
                        principalTable: "PermissionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "City", "CompanyID", "CreateDate", "DeleteDate", "Detail", "District", "ModifiedDate", "Neighbourhood", "Street" },
                values: new object[] { 1, "Istanbul", null, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(7304), null, "Bilge Adam Akademi Kadikoy Subesi", "Kadikoy", null, "Caferaga Mah.", "Muhurdar" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteDate", "ModifiedDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "4b1fb776-f3d7-47e9-81f0-f0896c651685", null, null, "Admin", "ADMIN" },
                    { 2, "9011e966-1da6-4769-a07c-8acc0d871c42", null, null, "User", "USER" },
                    { 3, "01343821-fcc0-42f2-ba31-1c5be0f4d72e", null, null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "ID", "CompanyName", "CompanyTitle", "ContactEndDate", "ContactStartDate", "DeleteDate", "EmailAddress", "LogoPath", "MersisNo", "ModifiedDate", "NumberOfEmployees", "PhoneNumber", "TaxAdministration", "TaxNumber", "YearOfEstablishment" },
                values: new object[] { 1, "Bilge Adam", 1, null, new DateTime(2023, 11, 2, 13, 32, 36, 459, DateTimeKind.Local).AddTicks(822), null, "bilgeadam@bilgeadam.com", "icardi.jpg", "123456789123456", null, 100, "1234567890", "Kadıköy", "1234567890", new DateTime(2023, 11, 2, 13, 32, 36, 459, DateTimeKind.Local).AddTicks(820) });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Code", "CreateDate", "DeleteDate", "ExchangeRate", "IsActive", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { "EUR", new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(8698), null, 30m, true, null, "EURO" },
                    { "JPY", new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(8700), null, 18m, true, null, "Japanese Yen" },
                    { "TL", new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(8694), null, 1m, true, null, "Turkish Lira" },
                    { "USD", new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(8696), null, 27m, true, null, "US Dollar" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "ID", "CreateDate", "DeleteDate", "IsActive", "MaxAmount", "MinAmount", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(7446), null, true, 5000m, 1000m, null, "Travel" },
                    { 2, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(7448), null, true, 3000m, 1000m, null, " Accommodation" },
                    { 3, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(7449), null, true, 500m, 300m, null, "Meals" },
                    { 4, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(7451), null, true, 5000m, 1000m, null, "Education" },
                    { 5, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(7452), null, true, 3000m, 1000m, null, "Fuel" },
                    { 6, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(7453), null, true, 5000m, 1000m, null, "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "ID", "CreateDate", "DeleteDate", "IsPaid", "MaxDays", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8705), null, false, null, null, "Doğum İzni" },
                    { 2, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8709), null, false, 5, null, "Babalık İzni" },
                    { 3, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8709), null, false, 10, null, "Hastalık İzni" },
                    { 4, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8710), null, false, 3, null, "Ölüm İzni" },
                    { 5, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8711), null, false, null, null, "Evlilik İzni" },
                    { 6, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8711), null, false, 40, null, "Evlat edinme İzni" },
                    { 7, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8712), null, false, null, null, "Refakat İzni" },
                    { 8, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8712), null, false, null, null, "Ücretsiz İzni" },
                    { 9, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8713), null, false, null, null, "Yeni iş arama İzni" },
                    { 10, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8713), null, false, null, null, "Gebelik Kontrol İzni" },
                    { 11, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(8713), null, false, null, null, "Süt İzni" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "City", "CompanyID", "CreateDate", "DeleteDate", "Detail", "District", "ModifiedDate", "Neighbourhood", "Street" },
                values: new object[] { 2, "Istanbul", 1, new DateTime(2023, 11, 2, 13, 32, 36, 457, DateTimeKind.Local).AddTicks(7306), null, "Menekşe Sk No:1", "Kartal", null, "ÇAvuşoğlu Mah.", "Muhurdar" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressID", "BirthDate", "BirthPlace", "CompanyID", "CompanyName", "ConcurrencyStamp", "DateOfStartWorking", "DateOfStopWorking", "DeleteDate", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "Surname", "TC", "Title", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, 1, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Istanbul", null, "Bilge Adam", "5d7a211b-245b-4bd4-933e-9dc3e1a1b98a", new DateTime(2023, 11, 2, 13, 32, 36, 446, DateTimeKind.Local).AddTicks(4003), null, null, "Software Development", "admin@bilgeadam.com", false, false, null, null, "Admin", "ADMİN@BİLGEADAM.COM", "ADMİN@BİLGEADAM.COM", "AQAAAAEAACcQAAAAEDC14fZ8TPyuLjGCK52gxQ/doqZVypuB8RlUkPoMyQ5TjtPgkINMtTO6VGeVSS0ECw==", "05555555555", null, false, "icardi.jpg", 35500m, null, null, "8f5f55b8-04ff-4d76-aabf-f71feeadc28a", "Admin", "11111111111", "Software Developer", false, "admin@bilgeadam.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressID", "BirthDate", "BirthPlace", "CompanyID", "CompanyName", "ConcurrencyStamp", "DateOfStartWorking", "DateOfStopWorking", "DeleteDate", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "Surname", "TC", "Title", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, 1, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Istanbul", null, "Bilge Adam", "f6ebc594-f39b-4e39-b37b-b5ddeef90c06", new DateTime(2023, 11, 2, 13, 32, 36, 451, DateTimeKind.Local).AddTicks(8929), null, null, "Software Development", "root@bilgeadamboost.com", false, false, null, null, "Root", "ROOT@BİLGEADAMBOOST.COM", "ROOT@BİLGEADAMBOOST.COM", "AQAAAAEAACcQAAAAEMXr9GqQybjvQns8qBTI0WsuhUw2opim370nBSS27CJ6S5/OHqmiFOl4nYapMC2Z0w==", "05555555555", null, false, "icardi.jpg", 27500m, null, null, "23917233-2f01-42bc-9d04-8c8649dde879", "Root", "22222222222", "Software Developer", false, "root@bilgeadamboost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "ID", "Amount", "ApprovalStatus", "CreateDate", "CurrencyCode", "DeleteDate", "DocumentPath", "ExpenseTypeID", "IsActive", "ModifiedDate", "PersonnelID", "ReplyDate", "RequestDate" },
                values: new object[] { 1, 1000m, "Pending", new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(6041), "TL", null, "deneme.jpg", 1, true, null, 1, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(6040), new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(6040) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "ID", "ApprovalStatus", "CreateDate", "DeleteDate", "ExpirationDate", "IsActive", "ModifiedDate", "NumberOfDays", "PermissionTypeID", "PersonnelID", "ReplyDate", "RequestDate", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(2039), null, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(2042), true, null, 1m, 1, 1, null, new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(2043), new DateTime(2023, 11, 2, 13, 32, 36, 458, DateTimeKind.Local).AddTicks(2041) });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyID",
                table: "Addresses",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Advances_AdvanceTypeID",
                table: "Advances",
                column: "AdvanceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Advances_CurrencyCode",
                table: "Advances",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Advances_PersonnelID",
                table: "Advances",
                column: "PersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressID",
                table: "AspNetUsers",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyID",
                table: "AspNetUsers",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CurrencyCode",
                table: "Expenses",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeID",
                table: "Expenses",
                column: "ExpenseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PersonnelID",
                table: "Expenses",
                column: "PersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionTypeID",
                table: "Permissions",
                column: "PermissionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PersonnelID",
                table: "Permissions",
                column: "PersonnelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advances");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "AdvanceTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PermissionTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
