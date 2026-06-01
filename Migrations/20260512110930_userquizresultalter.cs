using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prepify.Migrations
{
    /// <inheritdoc />
    public partial class userquizresultalter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Quizzes_QuizId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_QuizId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Results",
                newName: "total");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total",
                table: "Results",
                newName: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_QuizId",
                table: "Results",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Quizzes_QuizId",
                table: "Results",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
