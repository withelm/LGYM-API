using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lgym.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanDayExerciseReps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxReps",
                table: "PlanDayExercises",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinReps",
                table: "PlanDayExercises",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "PlanDayExercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxReps",
                table: "PlanDayExercises");

            migrationBuilder.DropColumn(
                name: "MinReps",
                table: "PlanDayExercises");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "PlanDayExercises");
        }
    }
}
