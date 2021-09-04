using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalCenter.Data.Migrations
{
    public partial class AddFacultyAndCourseEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroup_Teacher_TeacherId",
                table: "StudentGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentGroup_GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "StudentGroup");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "StudentGroup",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGroup_TeacherId",
                table: "StudentGroup",
                newName: "IX_StudentGroup_FacultyId");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursCount = table.Column<int>(type: "int", nullable: false),
                    ControlForm = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculty_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherId",
                table: "Course",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_CourseId",
                table: "Faculty",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroup_Faculty_FacultyId",
                table: "StudentGroup",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentGroup_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "StudentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroup_Faculty_FacultyId",
                table: "StudentGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentGroup_GroupId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "StudentGroup",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGroup_FacultyId",
                table: "StudentGroup",
                newName: "IX_StudentGroup_TeacherId");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Faculty",
                table: "StudentGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroup_Teacher_TeacherId",
                table: "StudentGroup",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentGroup_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "StudentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
