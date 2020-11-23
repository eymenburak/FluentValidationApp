using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentValidationApp.Migrations
{
    public partial class addedCreditCardNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditCardNumber",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "Employees");
        }
    }
}
