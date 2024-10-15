using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunrise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _12179 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentControl",
                columns: table => new
                {
                    CurrentControlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearSemesterID = table.Column<int>(type: "int", nullable: false),
                    GradeID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    Quiz1 = table.Column<int>(type: "int", nullable: false),
                    Quiz2 = table.Column<int>(type: "int", nullable: false),
                    Quiz3 = table.Column<int>(type: "int", nullable: false),
                    ClassWork = table.Column<int>(type: "int", nullable: false),
                    HomeWork = table.Column<int>(type: "int", nullable: false),
                    Behaviour = table.Column<int>(type: "int", nullable: false),
                    Project = table.Column<int>(type: "int", nullable: false),
                    Practical = table.Column<int>(type: "int", nullable: false),
                    ExamMark = table.Column<int>(type: "int", nullable: false),
                    Absent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentControl", x => x.CurrentControlID);
                    table.ForeignKey(
                        name: "FK_CurrentControl_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentControl_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentControl_YearSemesters_YearSemesterID",
                        column: x => x.YearSemesterID,
                        principalTable: "YearSemesters",
                        principalColumn: "YearSemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CurrentControl",
                columns: new[] { "CurrentControlID", "Absent", "Behaviour", "ClassWork", "ExamMark", "GradeID", "HomeWork", "Practical", "Project", "Quiz1", "Quiz2", "Quiz3", "StudentID", "SubjectID", "YearSemesterID" },
                values: new object[] { 1, true, 5, 0, 0, 1, 3, 9, 7, 1, 2, 3, 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 15, 10, 43, 46, 571, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.CreateIndex(
                name: "IX_CurrentControl_StudentID",
                table: "CurrentControl",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentControl_SubjectID",
                table: "CurrentControl",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentControl_YearSemesterID",
                table: "CurrentControl",
                column: "YearSemesterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentControl");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 15, 9, 41, 56, 401, DateTimeKind.Local).AddTicks(4206));
        }
    }
}
