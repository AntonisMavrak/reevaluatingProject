using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADOPSEV1._1.Migrations
{
    public partial class Sixd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "users",
                newName: "branchId");

            migrationBuilder.AddColumn<int>(
                name: "madeBy",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "madeBy",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "branchId",
                table: "users",
                newName: "BranchId");
        }
    }
}
