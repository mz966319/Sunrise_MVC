using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunriseWeb.Migrations
{
    /// <inheritdoc />
    public partial class updateStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthPlaceAR",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthPlaceEN",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentClass",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalityAR",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalityEN",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentStatusFlag",
                table: "Students",
                newName: "StudentActiveFlag");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentGradeID",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AuditorFlag",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthPlaceID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentClassID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NationalityID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "AdmissionDate", "AuditorFlag", "BirthDate", "BirthPlaceID", "CurrentClassID", "CurrentGradeID", "DateCreated", "DateUpdated", "IDEndDate", "NationalityID", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 26), 0, new DateOnly(2024, 9, 26), 1, 1, 1, new DateTime(2024, 9, 26, 14, 34, 27, 328, DateTimeKind.Local).AddTicks(2120), new DateTime(2024, 9, 26, 14, 34, 27, 328, DateTimeKind.Local).AddTicks(2135), new DateOnly(2024, 9, 26), 1, new DateOnly(2024, 9, 26) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "AdmissionDate", "AuditorFlag", "BirthDate", "BirthPlaceID", "CurrentClassID", "CurrentGradeID", "DateCreated", "DateUpdated", "IDEndDate", "NationalityID", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 26), 0, new DateOnly(2024, 9, 26), 10, 1, 1, new DateTime(2024, 9, 26, 14, 34, 27, 328, DateTimeKind.Local).AddTicks(2140), new DateTime(2024, 9, 26, 14, 34, 27, 328, DateTimeKind.Local).AddTicks(2140), new DateOnly(2024, 9, 26), 10, new DateOnly(2024, 9, 26) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "AdmissionDate", "AuditorFlag", "BirthDate", "BirthPlaceID", "CurrentClassID", "CurrentGradeID", "DateCreated", "DateUpdated", "IDEndDate", "NationalityID", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 26), 0, new DateOnly(2024, 9, 26), 10, 1, 1, new DateTime(2024, 9, 26, 14, 34, 27, 328, DateTimeKind.Local).AddTicks(2145), new DateTime(2024, 9, 26, 14, 34, 27, 328, DateTimeKind.Local).AddTicks(2145), new DateOnly(2024, 9, 26), 10, new DateOnly(2024, 9, 26) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditorFlag",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthPlaceID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentClassID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalityID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentActiveFlag",
                table: "Students",
                newName: "StudentStatusFlag");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentGradeID",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BirthPlaceAR",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BirthPlaceEN",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentClass",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalityAR",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalityEN",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "AdmissionDate", "BirthDate", "BirthPlaceAR", "BirthPlaceEN", "CurrentClass", "CurrentGradeID", "DateCreated", "DateUpdated", "IDEndDate", "NationalityAR", "NationalityEN", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23), "", "مصر", "BA", "4", new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5428), new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5440), new DateOnly(2024, 9, 23), "مصر", "Egypt", new DateOnly(2024, 9, 23) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "AdmissionDate", "BirthDate", "BirthPlaceAR", "BirthPlaceEN", "CurrentClass", "CurrentGradeID", "DateCreated", "DateUpdated", "IDEndDate", "NationalityAR", "NationalityEN", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23), "كندا", "", "BA", "6", new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5445), new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5445), new DateOnly(2024, 9, 23), "كندا", "Canada", new DateOnly(2024, 9, 23) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "AdmissionDate", "BirthDate", "BirthPlaceAR", "BirthPlaceEN", "CurrentClass", "CurrentGradeID", "DateCreated", "DateUpdated", "IDEndDate", "NationalityAR", "NationalityEN", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23), "السعودية", "", "GB", "5", new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5450), new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5451), new DateOnly(2024, 9, 23), "السعودية", "Saudi", new DateOnly(2024, 9, 23) });
        }
    }
}
