using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sunrise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Busses",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusNumber = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busses", x => x.BusID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityARMale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityARFemale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityID);
                });

            migrationBuilder.CreateTable(
                name: "PreviousSchools",
                columns: table => new
                {
                    PreviousSchoolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousSchoolNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousSchoolNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousSchools", x => x.PreviousSchoolID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoorID = table.Column<int>(type: "int", nullable: false),
                    StaticFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    YearID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddmissionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "GradeClasses",
                columns: table => new
                {
                    GradeClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeClasses", x => x.GradeClassID);
                    table.ForeignKey(
                        name: "FK_GradeClasses_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearManagers",
                columns: table => new
                {
                    YearManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolManagerEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolManagerAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlManagerEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlManagerAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeID = table.Column<int>(type: "int", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearManagers", x => x.YearManagerID);
                    table.ForeignKey(
                        name: "FK_YearManagers_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YearManagers_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearSemesters",
                columns: table => new
                {
                    YearSemesterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterNumber = table.Column<int>(type: "int", nullable: false),
                    SemesterNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SemesterNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalMark = table.Column<int>(type: "int", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearSemesters", x => x.YearSemesterID);
                    table.ForeignKey(
                        name: "FK_YearSemesters_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AdmissionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentActiveFlag = table.Column<int>(type: "int", nullable: false),
                    AuditorFlag = table.Column<bool>(type: "bit", nullable: false),
                    ParentPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentPhones2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatexStudentID = table.Column<int>(type: "int", nullable: true),
                    MatexParentID = table.Column<int>(type: "int", nullable: true),
                    BusFlag = table.Column<bool>(type: "bit", nullable: false),
                    BusSubscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityID = table.Column<int>(type: "int", nullable: false),
                    BirthPlaceID = table.Column<int>(type: "int", nullable: false),
                    PreviousSchoolID = table.Column<int>(type: "int", nullable: false),
                    CurrentClassID = table.Column<int>(type: "int", nullable: false),
                    BusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Busses_BusID",
                        column: x => x.BusID,
                        principalTable: "Busses",
                        principalColumn: "BusID");
                    table.ForeignKey(
                        name: "FK_Students_Countries_BirthPlaceID",
                        column: x => x.BirthPlaceID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_GradeClasses_CurrentClassID",
                        column: x => x.CurrentClassID,
                        principalTable: "GradeClasses",
                        principalColumn: "GradeClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Nationalities_NationalityID",
                        column: x => x.NationalityID,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_PreviousSchools_PreviousSchoolID",
                        column: x => x.PreviousSchoolID,
                        principalTable: "PreviousSchools",
                        principalColumn: "PreviousSchoolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Busses",
                columns: new[] { "BusID", "BusNumber", "BusPath", "BusPlate", "BusType", "DriverName", "DriverPhone" },
                values: new object[] { 1, 1, "Shemesi", "ABC", "Hilox", "Mo", "0500" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryNameAR", "CountryNameEN" },
                values: new object[] { 1, "معاذ", "Moaz" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "CertificateNameAR", "CertificateNameEN", "GradeLevel", "GradeName", "SchoolName" },
                values: new object[,]
                {
                    { 1, "روضة أول", "Kindergarten first grade", -1, "KG 1", "G" },
                    { 2, "روضة ثاني", "Kindergarten Seconde grade", -2, "KG 2", "G" },
                    { 3, "روضة ثالث", "Kindergarten Third grade", -3, "KG 3", "G" },
                    { 4, "الصف الأول الابتدائى", "Elementary first grade", 1, "Grad 1", "G" },
                    { 5, "الصف الثانى الابتدائى", "Elementary Seconde grade", 2, "Grad 2", "G" },
                    { 6, "الصف الثالث الابتدائى", "Elementary Third grade", 3, "Grad 3", "G" },
                    { 7, "الصف الرابع الابتدائى", "Elementary Fourth grade", 4, "Grad 4 B", "B" },
                    { 8, "الصف الرابع الابتدائي", "Elementary Fourth grade", 4, "Grad 4 G", "G" },
                    { 9, "الصف الخامس الابتدائى", "Elementary Fifth grade", 5, "Grad 5 B", "B" },
                    { 10, "الصف الخامس الابتدائى", "Elementary Fifth grade", 5, "Grad 5 G", "G" },
                    { 11, "الصف السادس الابتدائى", "Elementary Sixth grade", 6, "Grad 6 B", "B" },
                    { 12, "الصف السادس الابتدائى", "Elementary Sixth grade", 6, "Grad 6 G", "G" },
                    { 13, "الصف الأول المتوسط", "Intermediate First grade", 7, "Grad 7 B", "B" },
                    { 14, "الصف الأول المتوسط", "Intermediate First grade", 7, "Grad 7 G", "G" },
                    { 15, "الصف الثانى المتوسط", "Intermediate Second grade", 8, "Grad 8 B", "B" },
                    { 16, "الصف الثانى المتوسط", "Intermediate Second grade", 8, "Grad 8 G", "G" },
                    { 17, "الصف الثالث المتوسط", "Intermediate third grade", 9, "Grad 9 B", "B" },
                    { 18, "الصف الثالث المتوسط", "Intermediate third grade", 9, "Grad 9 G", "G" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityID", "NationalityARFemale", "NationalityARMale", "NationalityEN" },
                values: new object[] { 1, "12", "مصر", "Egypt" });

            migrationBuilder.InsertData(
                table: "PreviousSchools",
                columns: new[] { "PreviousSchoolID", "PreviousSchoolNameAR", "PreviousSchoolNameEN" },
                values: new object[] { 1, "مدارس شروق الشمس العالمية", "Sunrise International Schools" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectID", "NoorID", "NoorName", "StaticFlag", "SubjectNameAR", "SubjectNameEN" },
                values: new object[,]
                {
                    { 1, 291, "القرآن الكريم والدراسات الإسلامية", false, "الدراسات الإسلامية", "Islamic St." },
                    { 2, 157, "اللغة العربية", false, "اللغة العربية", "Arabic" },
                    { 3, 289, "الإجتماعيات", false, "الإجتماعيات", "Social Studies" },
                    { 4, 14, "اللغة الإنجليزية", false, "اللغة الإنجليزية", "English" },
                    { 5, 200548, "اللغة الفرنسية", false, "اللغة الفرنسية", "French" },
                    { 6, 74, "العلوم", false, "العلوم", "Science" },
                    { 11, 16, "الرياضيات", false, "الرياضيات", "Mathematics" },
                    { 12, 201110, "اجتماعيات باللغة الانجليزية", false, "الاجتماعيات (بالانجليزي)", "Social Studies (Eng)" },
                    { 14, 46, "الحاسب الآلي", false, "الحاسب الآلي", "Computer" },
                    { 15, 30, "التربية البدنية", true, "التربية البدنية", "Physical Education" },
                    { 16, 0, "السلوك", true, "السلوك", "Conduct" },
                    { 17, 0, "المواظبة", true, "المواظبة", "Attendance" }
                });

            migrationBuilder.InsertData(
                table: "Years",
                columns: new[] { "YearID", "ActiveFlag", "AddmissionDate", "YearAR", "YearEN" },
                values: new object[] { 1, true, new DateOnly(2024, 10, 12), "1444-1445", "2020-2021" });

            migrationBuilder.InsertData(
                table: "GradeClasses",
                columns: new[] { "GradeClassID", "ClassName", "GradeID" },
                values: new object[] { 1, "BA", 1 });

            migrationBuilder.InsertData(
                table: "YearManagers",
                columns: new[] { "YearManagerID", "ControlManagerAR", "ControlManagerEN", "GradeID", "SchoolManagerAR", "SchoolManagerEN", "YearID" },
                values: new object[] { 1, "اذ", "az", 1, "مع", "mo", 1 });

            migrationBuilder.InsertData(
                table: "YearSemesters",
                columns: new[] { "YearSemesterID", "ActiveFlag", "FinalMark", "SemesterNameAR", "SemesterNameEN", "SemesterNumber", "YearID" },
                values: new object[] { 1, true, 25, "الفصل الدراسي الأول", "First Semester", 1, 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "AdmissionDate", "AuditorFlag", "BirthDate", "BirthPlaceID", "BusFlag", "BusID", "BusSubscription", "CreatedBy", "CurrentClassID", "DateCreated", "DateUpdated", "Gender", "IDEndDate", "IDNumber", "MatexParentID", "MatexStudentID", "NationalityID", "ParentPhone1", "ParentPhones2", "Passport", "PassportEndDate", "PreviousSchoolID", "StudentActiveFlag", "StudentNameAR", "StudentNameEN", "StudentPhone", "UpdatedBy" },
                values: new object[] { 1, new DateOnly(2024, 10, 12), false, new DateOnly(2024, 10, 12), 1, false, 1, "ذهاب", "moaz", 1, new DateTime(2024, 10, 13, 0, 13, 15, 9, DateTimeKind.Local).AddTicks(576), null, "Male", new DateOnly(2024, 10, 12), "12", null, null, 1, "111", "222", "A12", new DateOnly(2024, 10, 12), 1, 0, "معاذ", "Moaz", "333", null });

            migrationBuilder.CreateIndex(
                name: "IX_GradeClasses_GradeID",
                table: "GradeClasses",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BirthPlaceID",
                table: "Students",
                column: "BirthPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BusID",
                table: "Students",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentClassID",
                table: "Students",
                column: "CurrentClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationalityID",
                table: "Students",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PreviousSchoolID",
                table: "Students",
                column: "PreviousSchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_YearManagers_GradeID",
                table: "YearManagers",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_YearManagers_YearID",
                table: "YearManagers",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_YearSemesters_YearID",
                table: "YearSemesters",
                column: "YearID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "YearManagers");

            migrationBuilder.DropTable(
                name: "YearSemesters");

            migrationBuilder.DropTable(
                name: "Busses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "GradeClasses");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "PreviousSchools");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
