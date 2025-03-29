using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORMSample.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepertmentDeptID",
                table: "Employess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employess_DepertmentDeptID",
                table: "Employess",
                column: "DepertmentDeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employess_DepertMent_DepertmentDeptID",
                table: "Employess",
                column: "DepertmentDeptID",
                principalTable: "DepertMent",
                principalColumn: "DeptID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employess_DepertMent_DepertmentDeptID",
                table: "Employess");

            migrationBuilder.DropIndex(
                name: "IX_Employess_DepertmentDeptID",
                table: "Employess");

            migrationBuilder.DropColumn(
                name: "DepertmentDeptID",
                table: "Employess");
        }
    }
}
