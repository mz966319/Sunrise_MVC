using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunriseWeb.Migrations
{
    /// <inheritdoc />
    public partial class addCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityARMale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityARFemale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4743), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4754), new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4759), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4760), new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "AdmissionDate", "BirthDate", "DateCreated", "DateUpdated", "IDEndDate", "PassportEndDate" },
                values: new object[] { new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4764), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4765), new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 23) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

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
    }
}
