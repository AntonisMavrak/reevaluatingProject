using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADOPSEV1._1.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Anwserid",
                table: "questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_questions_Anwserid",
                table: "questions",
                column: "Anwserid");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_anwsers_Anwserid",
                table: "questions",
                column: "Anwserid",
                principalTable: "anwsers",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_anwsers_Anwserid",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_Anwserid",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Anwserid",
                table: "questions");
        }
    }
}
