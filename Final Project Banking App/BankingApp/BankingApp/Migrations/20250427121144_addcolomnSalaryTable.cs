using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApp.Migrations
{
    /// <inheritdoc />
    public partial class addcolomnSalaryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SalaryDisburesements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SalaryDisburesements");
        }
    }
}
