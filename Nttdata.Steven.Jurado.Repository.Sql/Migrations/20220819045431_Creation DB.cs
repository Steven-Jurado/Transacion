namespace Nttdata.Steven.Jurado.Repository.Sql.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CreationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    IdBankAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    BankAccountType = table.Column<int>(type: "int", nullable: false),
                    BankAccountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankAccountStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.IdBankAccount);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Clients_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    IdTransaction = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBankAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.IdTransaction);
                    table.ForeignKey(
                        name: "FK_Transactions_BankAccounts_IdBankAccount",
                        column: x => x.IdBankAccount,
                        principalTable: "BankAccounts",
                        principalColumn: "IdBankAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_IdUsuario",
                table: "BankAccounts",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdBankAccount",
                table: "Transactions",
                column: "IdBankAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
