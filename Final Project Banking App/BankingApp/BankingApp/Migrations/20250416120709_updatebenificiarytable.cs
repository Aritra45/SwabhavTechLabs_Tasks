using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApp.Migrations
{
    /// <inheritdoc />
    public partial class updatebenificiarytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Companies_CompanyEmail",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_CompanyEmail",
                table: "Beneficiaries");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Companies",
                newName: "PanFilePath");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Companies",
                newName: "AadharFilePath");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyEmail",
                table: "Beneficiaries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PanFilePath",
                table: "Companies",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "AadharFilePath",
                table: "Companies",
                newName: "FileName");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyEmail",
                table: "Beneficiaries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_CompanyEmail",
                table: "Beneficiaries",
                column: "CompanyEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Companies_CompanyEmail",
                table: "Beneficiaries",
                column: "CompanyEmail",
                principalTable: "Companies",
                principalColumn: "CompanyEmail",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
