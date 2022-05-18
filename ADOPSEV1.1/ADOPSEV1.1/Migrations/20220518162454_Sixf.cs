using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADOPSEV1._1.Migrations
{
    public partial class Sixf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_anwsers_Anwserid",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_questions_Questionid",
                table: "subjects");

            migrationBuilder.DropIndex(
                name: "IX_subjects_Questionid",
                table: "subjects");

            migrationBuilder.DropIndex(
                name: "IX_questions_Anwserid",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Questionid",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "Anwserid",
                table: "questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Questionid",
                table: "subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Anwserid",
                table: "questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subjects_Questionid",
                table: "subjects",
                column: "Questionid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_questions_Questionid",
                table: "subjects",
                column: "Questionid",
                principalTable: "questions",
                principalColumn: "id");
        }
    }
}
