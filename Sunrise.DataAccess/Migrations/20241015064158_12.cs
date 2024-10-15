using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunrise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizCount",
                table: "YearSemesters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "IDEndDate", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 10, 15), new DateOnly(2024, 10, 15), new DateTime(2024, 10, 15, 9, 41, 56, 401, DateTimeKind.Local).AddTicks(4206), new DateOnly(2024, 10, 15), new DateOnly(2024, 10, 15) });

            migrationBuilder.UpdateData(
                table: "YearSemesters",
                keyColumn: "YearSemesterID",
                keyValue: 1,
                column: "QuizCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Years",
                keyColumn: "YearID",
                keyValue: 1,
                column: "AddmissionDate",
                value: new DateOnly(2024, 10, 15));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizCount",
                table: "YearSemesters");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "IDEndDate", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 10, 12), new DateOnly(2024, 10, 12), new DateTime(2024, 10, 13, 0, 13, 15, 9, DateTimeKind.Local).AddTicks(576), new DateOnly(2024, 10, 12), new DateOnly(2024, 10, 12) });

            migrationBuilder.UpdateData(
                table: "Years",
                keyColumn: "YearID",
                keyValue: 1,
                column: "AddmissionDate",
                value: new DateOnly(2024, 10, 12));
        }
    }
}
