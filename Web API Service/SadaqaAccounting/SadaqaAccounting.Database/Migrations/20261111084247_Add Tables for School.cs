using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SadaqaAccounting.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesforSchool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets",
                schema: "AssetManagement");

            migrationBuilder.DropTable(
                name: "BankLedgers",
                schema: "Cash&BankManagement");

            migrationBuilder.DropTable(
                name: "CashLedgers",
                schema: "Cash&BankManagement");

            migrationBuilder.DropTable(
                name: "Expenses",
                schema: "ExpenseManagement");

            migrationBuilder.DropTable(
                name: "Incomes",
                schema: "IncomeManagement");

            migrationBuilder.DropTable(
                name: "OpeningBalances",
                schema: "Cash&BankManagement");

            migrationBuilder.DropTable(
                name: "ExpenseCategories",
                schema: "ExpenseManagement");

            migrationBuilder.DropTable(
                name: "Donors",
                schema: "DonorManagement");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "MasterSettings");

            migrationBuilder.DropTable(
                name: "IncomeCategories",
                schema: "IncomeManagement");

            migrationBuilder.DropTable(
                name: "Banks",
                schema: "Cash&BankManagement");

            migrationBuilder.DropTable(
                name: "Cashes",
                schema: "Cash&BankManagement");

            migrationBuilder.CreateTable(
                name: "AdmissionClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthRegistrationNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionHolds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AdmissionClassId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionHolds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionHolds_AdmissionClasses_AdmissionClassId",
                        column: x => x.AdmissionClassId,
                        principalTable: "AdmissionClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionHolds_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionHolds_AdmissionClassId",
                table: "AdmissionHolds",
                column: "AdmissionClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionHolds_StudentId",
                table: "AdmissionHolds",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionHolds");

            migrationBuilder.DropTable(
                name: "AdmissionClasses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.EnsureSchema(
                name: "AssetManagement");

            migrationBuilder.EnsureSchema(
                name: "Cash&BankManagement");

            migrationBuilder.EnsureSchema(
                name: "DonorManagement");

            migrationBuilder.EnsureSchema(
                name: "ExpenseManagement");

            migrationBuilder.EnsureSchema(
                name: "IncomeManagement");

            migrationBuilder.CreateTable(
                name: "Assets",
                schema: "AssetManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AssetNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_EnumTypeCollections_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                schema: "Cash&BankManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 25, nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Banks_EnumTypeCollections_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cashes",
                schema: "Cash&BankManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cashes_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                schema: "DonorManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donors_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donors_EnumTypeCollections_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "MasterSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                schema: "ExpenseManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseCategories_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                schema: "IncomeManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDonorBased = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeCategories_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankLedgers",
                schema: "Cash&BankManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    SourceTypeId = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankLedgers_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankLedgers_Banks_BankId",
                        column: x => x.BankId,
                        principalSchema: "Cash&BankManagement",
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankLedgers_EnumTypeCollections_SourceTypeId",
                        column: x => x.SourceTypeId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankLedgers_EnumTypeCollections_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashLedgers",
                schema: "Cash&BankManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    CashId = table.Column<int>(type: "int", nullable: false),
                    SourceTypeId = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashLedgers_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashLedgers_Cashes_CashId",
                        column: x => x.CashId,
                        principalSchema: "Cash&BankManagement",
                        principalTable: "Cashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashLedgers_EnumTypeCollections_SourceTypeId",
                        column: x => x.SourceTypeId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashLedgers_EnumTypeCollections_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpeningBalances",
                schema: "Cash&BankManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    CashId = table.Column<int>(type: "int", nullable: true),
                    PaymentModeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningBalances_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpeningBalances_Banks_BankId",
                        column: x => x.BankId,
                        principalSchema: "Cash&BankManagement",
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpeningBalances_Cashes_CashId",
                        column: x => x.CashId,
                        principalSchema: "Cash&BankManagement",
                        principalTable: "Cashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpeningBalances_EnumTypeCollections_PaymentModeId",
                        column: x => x.PaymentModeId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                schema: "ExpenseManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    CashId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    ExpenseCategoryId = table.Column<int>(type: "int", nullable: false),
                    PaymentModeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Banks_BankId",
                        column: x => x.BankId,
                        principalSchema: "Cash&BankManagement",
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Cashes_CashId",
                        column: x => x.CashId,
                        principalSchema: "Cash&BankManagement",
                        principalTable: "Cashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_EnumTypeCollections_PaymentModeId",
                        column: x => x.PaymentModeId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "MasterSettings",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseCategories_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalSchema: "ExpenseManagement",
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                schema: "IncomeManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    CashId = table.Column<int>(type: "int", nullable: true),
                    DonorId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    IncomeCategoryId = table.Column<int>(type: "int", nullable: false),
                    MonthId = table.Column<int>(type: "int", nullable: true),
                    PaymentModeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptBookNo = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptNo = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalSchema: "MasterSettings",
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_Banks_BankId",
                        column: x => x.BankId,
                        principalSchema: "Cash&BankManagement",
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_Cashes_CashId",
                        column: x => x.CashId,
                        principalSchema: "Cash&BankManagement",
                        principalTable: "Cashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_Donors_DonorId",
                        column: x => x.DonorId,
                        principalSchema: "DonorManagement",
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_EnumTypeCollections_MonthId",
                        column: x => x.MonthId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_EnumTypeCollections_PaymentModeId",
                        column: x => x.PaymentModeId,
                        principalTable: "EnumTypeCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incomes_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "MasterSettings",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_IncomeCategories_IncomeCategoryId",
                        column: x => x.IncomeCategoryId,
                        principalSchema: "IncomeManagement",
                        principalTable: "IncomeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AccountUnitId",
                schema: "AssetManagement",
                table: "Assets",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_StatusId",
                schema: "AssetManagement",
                table: "Assets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BankLedgers_AccountUnitId",
                schema: "Cash&BankManagement",
                table: "BankLedgers",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BankLedgers_BankId",
                schema: "Cash&BankManagement",
                table: "BankLedgers",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankLedgers_SourceTypeId",
                schema: "Cash&BankManagement",
                table: "BankLedgers",
                column: "SourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankLedgers_TransactionTypeId",
                schema: "Cash&BankManagement",
                table: "BankLedgers",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_AccountUnitId",
                schema: "Cash&BankManagement",
                table: "Banks",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_StatusId",
                schema: "Cash&BankManagement",
                table: "Banks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cashes_AccountUnitId",
                schema: "Cash&BankManagement",
                table: "Cashes",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CashLedgers_AccountUnitId",
                schema: "Cash&BankManagement",
                table: "CashLedgers",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CashLedgers_CashId",
                schema: "Cash&BankManagement",
                table: "CashLedgers",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_CashLedgers_SourceTypeId",
                schema: "Cash&BankManagement",
                table: "CashLedgers",
                column: "SourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashLedgers_TransactionTypeId",
                schema: "Cash&BankManagement",
                table: "CashLedgers",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_AccountUnitId",
                schema: "DonorManagement",
                table: "Donors",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_StatusId",
                schema: "DonorManagement",
                table: "Donors",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AccountUnitId",
                schema: "MasterSettings",
                table: "Events",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_AccountUnitId",
                schema: "ExpenseManagement",
                table: "ExpenseCategories",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AccountUnitId",
                schema: "ExpenseManagement",
                table: "Expenses",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BankId",
                schema: "ExpenseManagement",
                table: "Expenses",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CashId",
                schema: "ExpenseManagement",
                table: "Expenses",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EventId",
                schema: "ExpenseManagement",
                table: "Expenses",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseCategoryId",
                schema: "ExpenseManagement",
                table: "Expenses",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaymentModeId",
                schema: "ExpenseManagement",
                table: "Expenses",
                column: "PaymentModeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategories_AccountUnitId",
                schema: "IncomeManagement",
                table: "IncomeCategories",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_AccountUnitId",
                schema: "IncomeManagement",
                table: "Incomes",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_BankId",
                schema: "IncomeManagement",
                table: "Incomes",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_CashId",
                schema: "IncomeManagement",
                table: "Incomes",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_DonorId",
                schema: "IncomeManagement",
                table: "Incomes",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_EventId",
                schema: "IncomeManagement",
                table: "Incomes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_IncomeCategoryId",
                schema: "IncomeManagement",
                table: "Incomes",
                column: "IncomeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_MonthId",
                schema: "IncomeManagement",
                table: "Incomes",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_PaymentModeId",
                schema: "IncomeManagement",
                table: "Incomes",
                column: "PaymentModeId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningBalances_AccountUnitId",
                schema: "Cash&BankManagement",
                table: "OpeningBalances",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningBalances_BankId",
                schema: "Cash&BankManagement",
                table: "OpeningBalances",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningBalances_CashId",
                schema: "Cash&BankManagement",
                table: "OpeningBalances",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningBalances_PaymentModeId",
                schema: "Cash&BankManagement",
                table: "OpeningBalances",
                column: "PaymentModeId");
        }
    }
}
