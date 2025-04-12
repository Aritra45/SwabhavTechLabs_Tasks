using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactAppUsingWebApi.Migrations
{
    /// <inheritdoc />
    public partial class changeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Contacts_ContactId",
                table: "ContactDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails");

            migrationBuilder.RenameTable(
                name: "ContactDetails",
                newName: "ContactDetailss");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetails_ContactId",
                table: "ContactDetailss",
                newName: "IX_ContactDetailss_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactDetailss",
                table: "ContactDetailss",
                column: "ContactDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetailss_Contacts_ContactId",
                table: "ContactDetailss",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetailss_Contacts_ContactId",
                table: "ContactDetailss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactDetailss",
                table: "ContactDetailss");

            migrationBuilder.RenameTable(
                name: "ContactDetailss",
                newName: "ContactDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetailss_ContactId",
                table: "ContactDetails",
                newName: "IX_ContactDetails_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails",
                column: "ContactDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Contacts_ContactId",
                table: "ContactDetails",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
