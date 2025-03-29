using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Migrations
{
    /// <inheritdoc />
    public partial class addContactInContactDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_ContactDetails_ContactDetailsID",
                table: "Contact");

            migrationBuilder.RenameColumn(
                name: "ContactDetailsID",
                table: "Contact",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_ContactDetailsID",
                table: "Contact",
                newName: "IX_Contact_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "ContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactId",
                table: "ContactDetails",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_UserId",
                table: "Contact",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Contact_ContactId",
                table: "ContactDetails",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Contact_ContactId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_ContactId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "ContactDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contact",
                newName: "ContactDetailsID");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_UserId",
                table: "Contact",
                newName: "IX_Contact_ContactDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_ContactDetails_ContactDetailsID",
                table: "Contact",
                column: "ContactDetailsID",
                principalTable: "ContactDetails",
                principalColumn: "ContactDetailsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
