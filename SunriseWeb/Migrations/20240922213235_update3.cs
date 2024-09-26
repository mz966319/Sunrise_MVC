using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunriseWeb.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "PassportEndDate",
                table: "Students",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "IDEndDate",
                table: "Students",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Students",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AdmissionDate",
                table: "Students",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 22), new DateOnly(2024, 9, 22), new DateTime(2024, 9, 23, 0, 32, 35, 208, DateTimeKind.Local).AddTicks(652), new DateTime(2024, 9, 23, 0, 32, 35, 208, DateTimeKind.Local).AddTicks(664), new DateOnly(2024, 9, 22), new DateOnly(2024, 9, 22) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 22), new DateOnly(2024, 9, 22), new DateTime(2024, 9, 23, 0, 32, 35, 208, DateTimeKind.Local).AddTicks(669), new DateTime(2024, 9, 23, 0, 32, 35, 208, DateTimeKind.Local).AddTicks(670), new DateOnly(2024, 9, 22), new DateOnly(2024, 9, 22) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 22), new DateOnly(2024, 9, 22), new DateTime(2024, 9, 23, 0, 32, 35, 208, DateTimeKind.Local).AddTicks(674), new DateTime(2024, 9, 23, 0, 32, 35, 208, DateTimeKind.Local).AddTicks(675), new DateOnly(2024, 9, 22), new DateOnly(2024, 9, 22) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PassportEndDate",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "IDEndDate",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "DateUpdated",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DateCreated",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "AdmissionDate",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { "2024-1-1", "", "", "", "2022", "2023" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { "", "", "", "", "2028", "2099" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { "", "", "", "", "2025-1-1", "" });
        }
    }
}
