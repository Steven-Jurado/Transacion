namespace Nttdata.Steven.Jurado.Repository.Sql.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddColumnBankAccountAvailableBalanceandDeleteTransactionBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionBalance",
                table: "Transactions");

            migrationBuilder.AddColumn<decimal>(
                name: "BankAccountAvailableBalance",
                table: "BankAccounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountAvailableBalance",
                table: "BankAccounts");

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionBalance",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
