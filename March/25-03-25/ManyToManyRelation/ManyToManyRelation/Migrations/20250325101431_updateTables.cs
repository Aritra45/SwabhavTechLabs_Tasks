using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToManyRelation.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Author_AuthorAId",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Book_BookBId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookBId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Author_AuthorAId",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BookBId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorAId",
                table: "Author");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAId = table.Column<int>(type: "int", nullable: false),
                    BooksBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAId, x.BooksBId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_AuthorsAId",
                        column: x => x.AuthorsAId,
                        principalTable: "Author",
                        principalColumn: "AId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_BooksBId",
                        column: x => x.BooksBId,
                        principalTable: "Book",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksBId",
                table: "AuthorBook",
                column: "BooksBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.AddColumn<int>(
                name: "BookBId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorAId",
                table: "Author",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookBId",
                table: "Book",
                column: "BookBId");

            migrationBuilder.CreateIndex(
                name: "IX_Author_AuthorAId",
                table: "Author",
                column: "AuthorAId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Author_AuthorAId",
                table: "Author",
                column: "AuthorAId",
                principalTable: "Author",
                principalColumn: "AId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Book_BookBId",
                table: "Book",
                column: "BookBId",
                principalTable: "Book",
                principalColumn: "BId");
        }
    }
}
