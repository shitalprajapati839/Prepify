using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prepify.Migrations
{
    /// <inheritdoc />
    public partial class RenameAndAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Questions",
                newName: "QuestionId");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "QuizId");
        }
    }
}
