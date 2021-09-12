using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalCenter.Data.Migrations
{
    public partial class FillDatabaseWithSeedInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "ControlForm", "Description", "HoursCount", "Title" },
                values: new object[,]
                {
                    { 1, 1, "The mathematical study of continuous change", 150, "Calculus" },
                    { 2, 0, "The mathematical study of equations in which an unknown function appears under an integral sign", 100, "Integral equations" },
                    { 3, 1, "The branch of mathematics concerning linear equations", 200, "Linear algebra" },
                    { 4, 0, "The study about the history of Belarus in 20th century", 100, "The history of Belarus" },
                    { 5, 0, "The study about basics of the philosophy", 100, "Philosophy" },
                    { 6, 1, "English lessons", 400, "English" },
                    { 7, 1, "The branch of mathematics concerning with properties of space that are related with distance, shape, size, and relative position of figures.", 200, "Geometry" },
                    { 8, 1, "The study of mathematical structures that are fundamentally discrete rather than continuous.", 250, "Discrete Mathematics" },
                    { 9, 1, "The study of logic within mathematics", 200, "Mathematical Logic" },
                    { 10, 0, "The branch of mathematics dealing with the general properties of algorithms", 100, "Theory Of Algorithms" },
                    { 11, 1, "The branch of mathematics concerned with probability.", 240, "Probability theory" },
                    { 12, 0, "The application of probability theory, a branch of mathematics, to statistics, as opposed to techniques for collecting statistical data.", 150, "Mathematical statistics" },
                    { 13, 1, "The natural science that studies matter, its motion and behavior through space and time, and the related entities of energy and force.", 300, "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[] { 1, null, "English" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 28, "Political Science" },
                    { 27, "Pedagogical Education" },
                    { 26, "Global Processes" },
                    { 25, "Arts" },
                    { 24, "World Politics" },
                    { 23, "Public Administration" },
                    { 22, "Foreign Languages ​​and Regional Studies" },
                    { 21, "Sociology" },
                    { 20, "Psychology" },
                    { 19, "Journalism" },
                    { 18, "Law" },
                    { 17, "Economics" },
                    { 16, "Philosophy" },
                    { 15, "Philology" },
                    { 8, "Soil Science" },
                    { 13, "Space Research" },
                    { 12, "Biotechnology" },
                    { 11, "Fundamental Medicine" },
                    { 10, "Geography" },
                    { 9, "Geology" },
                    { 29, "Business" },
                    { 7, "Bioengineering and Bioinformatics" },
                    { 6, "Biology" },
                    { 5, "Materials Science" },
                    { 4, "Chemistry" },
                    { 3, "Physics" },
                    { 2, "Computational Mathematics and Cybernetics" },
                    { 1, "Mechanics and Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "History" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[] { 30, "Television" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { 16, 1, "Mathematical Statistics and Stochastic Processes" },
                    { 17, 1, "Theory of Functions and Functional Analysis" },
                    { 15, 1, "Number theory" },
                    { 14, 1, "Theory of Dynamical Systems" },
                    { 13, 1, "Probability Theory" },
                    { 12, 1, "Theoretical informatics" },
                    { 10, 1, "General topology and geometry" },
                    { 9, 1, "Mathematical Logic and Theory of Algorithms" },
                    { 11, 1, "General management challenges" },
                    { 7, 1, "Differential Geometry and Its Applications" },
                    { 6, 1, "Discrete Mathematics" },
                    { 5, 1, "Computational Mathematics" },
                    { 4, 1, "Geometry and Topology" },
                    { 3, 1, "Mathematical Analysis" },
                    { 2, 1, "Higher Algebra" },
                    { 8, 1, "Differential Equations" }
                });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "EndingYear", "FacultyId", "StartYear", "Title" },
                values: new object[,]
                {
                    { 21, 2026, 21, 2021, "21-21-1" },
                    { 17, 2026, 17, 2021, "21-17-1" },
                    { 18, 2026, 18, 2021, "21-18-1" },
                    { 19, 2026, 19, 2021, "21-19-1" },
                    { 20, 2026, 20, 2021, "21-20-1" },
                    { 22, 2026, 22, 2021, "21-22-1" },
                    { 7, 2026, 7, 2021, "21-7-1" },
                    { 24, 2026, 24, 2021, "21-24-1" },
                    { 25, 2026, 25, 2021, "21-25-1" },
                    { 26, 2026, 26, 2021, "21-26-1" },
                    { 27, 2026, 27, 2021, "21-27-1" },
                    { 28, 2026, 28, 2021, "21-28-1" },
                    { 16, 2026, 16, 2021, "21-16-1" },
                    { 23, 2026, 23, 2021, "21-23-1" },
                    { 15, 2026, 15, 2021, "21-15-1" },
                    { 30, 2026, 30, 2021, "21-30-1" },
                    { 13, 2026, 13, 2021, "21-13-1" },
                    { 12, 2026, 12, 2021, "21-12-1" },
                    { 11, 2026, 11, 2021, "21-11-1" },
                    { 10, 2026, 10, 2021, "21-10-1" },
                    { 9, 2026, 9, 2021, "21-9-1" },
                    { 8, 2026, 8, 2021, "21-8-1" },
                    { 29, 2026, 29, 2021, "21-29-1" },
                    { 6, 2026, 6, 2021, "21-6-1" },
                    { 5, 2026, 5, 2021, "21-5-1" },
                    { 4, 2026, 4, 2021, "21-4-1" }
                });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "EndingYear", "FacultyId", "StartYear", "Title" },
                values: new object[,]
                {
                    { 3, 2026, 3, 2021, "21-3-1" },
                    { 2, 2026, 2, 2021, "21-2-1" },
                    { 1, 2026, 1, 2021, "21-1-1" },
                    { 14, 2026, 14, 2021, "21-14-1" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Category", "DateOfBirth", "DepartmentId", "EMail", "Experience", "FirstName", "Formation", "LastName", "PhoneNumber", "Salary" },
                values: new object[] { 1, 1, new DateTime(1983, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "aleksey.suhorukov@gmail.com", 4, "Aleksey", 1, "Suhorukov", "80291700544", 1500 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "EMail", "FirstName", "GroupId", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 3, new DateTime(2002, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "aleksey.alekseev2002@gmail.com", "Aleksey", 1, "Alekseev", "80290876946" },
                    { 5, new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "viktor.baranov@gmail.com", "Viktor", 1, "Baranov", "80297555386" },
                    { 6, new DateTime(2001, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "vasili.belousov@gmail.com", "Vasili", 1, "Belousov", "80298898114" },
                    { 7, new DateTime(2001, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofiya.belousova@gmail.com", "Sofiya", 1, "Belousova", "80290179645" },
                    { 8, new DateTime(2002, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mikhail.borisov@mail.ru", "Mikhail", 1, "Borisov", "80292485857" },
                    { 9, new DateTime(2001, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mark.vasiliev@mail.ru", "Mark", 1, "Vasiliev", "80291314170" },
                    { 10, new DateTime(2002, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "valeriya.vasilieva@mail.ru", "Valeriya", 1, "Vasilieva", "80295986128" },
                    { 11, new DateTime(2003, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "valeriya.vasilieva@mail.ru", "Vitaliy", 1, "Vinokurov", "80292959451" },
                    { 12, new DateTime(2003, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alexander.vlasov@gmail.com", "Alexander", 1, "Vlasov", "80297387311" },
                    { 13, new DateTime(2003, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "arina.volkova@gmail.com", "Arina", 1, "Volkova", "80295752575" },
                    { 14, new DateTime(2002, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "taisia.voloshina@gmail.com", "Taisia", 1, "Voloshina", "80295752575" },
                    { 15, new DateTime(2002, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "oleg.prokopovich@gmail.com", "Oleg", 1, "Prokopovich", "80293840939" },
                    { 16, new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eva.galkina@gmail.com", "Eva", 1, "Galkina", "80292417030" },
                    { 17, new DateTime(2004, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "olga.gerasimova@gmail.com", "Olga", 1, "Gerasimova", "80296959163" },
                    { 18, new DateTime(2004, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "vladimir.ivanov@gmail.com", "Vladimir", 1, "Ivanov", "80293899049" },
                    { 19, new DateTime(2003, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "egor.kirillov@gmail.com", "Egor", 1, "Kirillov", "80293342034" },
                    { 4, new DateTime(2001, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "viktor.arhipov@gmail.com", "Viktor", 1, "Arhipov", "80290881237" },
                    { 20, new DateTime(2002, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.kruglova@gmail.com", "Anna", 1, "Kruglova", "80298668976" },
                    { 21, new DateTime(2003, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "veronika.lebedeva@mail.ru", "Veronika", 1, "Lebedeva", "80297158895" },
                    { 1, new DateTime(2003, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "masha4221@ya.ru", "Mariya", 1, "Akimova", "80299383772" },
                    { 2, new DateTime(2002, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "maxim.alekseev2002@gmail.com", "Maxim", 1, "Alekseev", "80292923022" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Category", "DateOfBirth", "DepartmentId", "EMail", "Experience", "FirstName", "Formation", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(1845, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "georg.cantor@gmail.com", 10, "Georg", 3, "Cantor", "80258438118", 5000 },
                    { 4, 3, new DateTime(1792, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "nikolay.lobachevskiy@gmail.com", 13, "Nikolay", 2, "Lobachevskiy", "80297304512", 4360 },
                    { 5, 3, new DateTime(1967, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "yuriy.vasilevskiy@gmail.com", 14, "Yuriy", 3, "Vasilevskiy", "80335936308", 5690 },
                    { 6, 3, new DateTime(1924, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "sergey.yablonskiy@gmail.com", 21, "Sergey", 3, "Yablonskiy", "80298602366", 8200 },
                    { 7, 2, new DateTime(1976, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "anatoliy.fomenko@gmail.com", 6, "Anatoliy", 1, "Fomenko", "80298989783", 3500 },
                    { 8, 2, new DateTime(1988, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "katenka489@mail.ru", 5, "Katerina", 1, "Lyutova", "80294041777", 2700 },
                    { 9, 3, new DateTime(1961, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "varvara1961@ya.ru", 25, "Varvara", 2, "Pivovarova", "80297213791", 7500 },
                    { 10, 2, new DateTime(1975, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "anton1314@mail.ru", 12, "Anton", 1, "Mazaev", "80294097837", 5100 },
                    { 12, 0, new DateTime(1997, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "lyudmila.yudashkina@yandex.ru", 1, "Lyudmila", 0, "Yudashkina", "80292512777", 1800 },
                    { 13, 2, new DateTime(1963, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "valentin2091@mail.ru", 23, "Valentin", 1, "Yurlov", "80291439863", 1800 },
                    { 14, 0, new DateTime(1996, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "nikolay16071996@mail.ru", 1, "Nikolay", 1, "Kuraev", "80299709082", 1950 },
                    { 15, 1, new DateTime(1984, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "fedot.parshikov@ya.ru", 4, "Fedot", 1, "Pershikov", "80298608842", 2300 },
                    { 16, 1, new DateTime(1984, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "fedot.parshikov@ya.ru", 4, "Fedot", 1, "Pershikov", "80298608842", 2300 },
                    { 17, 1, new DateTime(1984, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "fedot.parshikov@ya.ru", 4, "Fedot", 1, "Pershikov", "80298608842", 2300 },
                    { 11, 2, new DateTime(1970, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "anton14091970@gmail.com", 15, "Anton", 1, "Kasatkin", "80292323673", 5300 },
                    { 2, 3, new DateTime(1908, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "viktor.vagner@gmail.com", 15, "Viktor", 3, "Vagner", "80338690014", 3500 }
                });
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
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
