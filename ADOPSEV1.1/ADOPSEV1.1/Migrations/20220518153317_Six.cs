using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADOPSEV1._1.Migrations
{
    public partial class Six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Questionid",
                table: "subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subjects_Questionid",
                table: "subjects",
                column: "Questionid");

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_questions_Questionid",
                table: "subjects",
                column: "Questionid",
                principalTable: "questions",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subjects_questions_Questionid",
                table: "subjects");

            migrationBuilder.DropIndex(
                name: "IX_subjects_Questionid",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "Questionid",
                table: "subjects");
        }
    }
}
