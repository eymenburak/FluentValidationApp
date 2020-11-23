using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentValidationApp.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelephoneId",
                table: "Student",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Telephone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephone", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_TelephoneId",
                table: "Student",
                column: "TelephoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Telephone_TelephoneId",
                table: "Student",
                column: "TelephoneId",
                principalTable: "Telephone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Telephone_TelephoneId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Telephone");

            migrationBuilder.DropIndex(
                name: "IX_Student_TelephoneId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "TelephoneId",
                table: "Student");
        }
    }
}
