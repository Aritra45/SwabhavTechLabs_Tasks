using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApp.Migrations
{
    /// <inheritdoc />
    public partial class updateNameBeneficiariesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beneficiaries_Companies_CompanyEmail1",
                table: "beneficiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_beneficiaries",
                table: "beneficiaries");

            migrationBuilder.RenameTable(
                name: "beneficiaries",
                newName: "Beneficiaries");

            migrationBuilder.RenameIndex(
                name: "IX_beneficiaries_CompanyEmail1",
                table: "Beneficiaries",
                newName: "IX_Beneficiaries_CompanyEmail1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beneficiaries",
                table: "Beneficiaries",
                column: "BeneficiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Companies_CompanyEmail1",
                table: "Beneficiaries",
                column: "CompanyEmail1",
                principalTable: "Companies",
                principalColumn: "CompanyEmail",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Companies_CompanyEmail1",
                table: "Beneficiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beneficiaries",
                table: "Beneficiaries");

            migrationBuilder.RenameTable(
                name: "Beneficiaries",
                newName: "beneficiaries");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiaries_CompanyEmail1",
                table: "beneficiaries",
                newName: "IX_beneficiaries_CompanyEmail1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_beneficiaries",
                table: "beneficiaries",
                column: "BeneficiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_beneficiaries_Companies_CompanyEmail1",
                table: "beneficiaries",
                column: "CompanyEmail1",
                principalTable: "Companies",
                principalColumn: "CompanyEmail",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
