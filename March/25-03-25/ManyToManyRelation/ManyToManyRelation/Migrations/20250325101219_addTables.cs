using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToManyRelation.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AId);
                    table.ForeignKey(
                        name: "FK_Author_Author_AuthorAId",
                        column: x => x.AuthorAId,
                        principalTable: "Author",
                        principalColumn: "AId");
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BId);
                    table.ForeignKey(
                        name: "FK_Book_Book_BookBId",
                        column: x => x.BookBId,
                        principalTable: "Book",
                        principalColumn: "BId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_AuthorAId",
                table: "Author",
                column: "AuthorAId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookBId",
                table: "Book",
                column: "BookBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
