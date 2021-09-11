using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalCenter.Data.Migrations
{
    public partial class RemoveTeacherColumnInCourseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Courses");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "ControlForm", "Description", "HoursCount", "Title" },
                values: new object[,]
                {
                    { 1, 1, "The mathematical study of continuous change", 150, "Calculus" },
                    { 2, 0, "The mathematical study of equations in which an unknown function appears under an integral sign", 100, "Integral equations" },
                    { 3, 1, "The branch of mathematics concerning linear equations", 200, "Linear algebra" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Philology" },
                    { 2, "Algebras" },
                    { 3, "Calculus" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Applied Math" },
                    { 2, "Information technologies" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Category", "DateOfBirth", "DepartmentId", "EMail", "Experience", "FirstName", "Formation", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { 2, 3, new DateTime(1908, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "viktor.vagner@gmail.com", 15, "Viktor", 3, "Vagner", "2345678901", 3500 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Category", "DateOfBirth", "DepartmentId", "EMail", "Experience", "FirstName", "Formation", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { 1, 3, new DateTime(1845, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "georg.cantor@gmail.com", 10, "Georg", 3, "Cantor", "1234567890", 5000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
