using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalCenter.Data.Migrations
{
    public partial class RemoveEnrollmentYearColumnFromStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollmentYear",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnrollmentYear",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
