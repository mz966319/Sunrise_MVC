using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SunriseWeb.Migrations
{
    /// <inheritdoc />
    public partial class addCountriesdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryNameAR", "CountryNameEN", "NationalityARFemale", "NationalityARMale", "NationalityEN" },
                values: new object[,]
                {
                    { 1, "معاذ", "Moaz", "12", "مصر", "Egypt" },
                    { 2, "معاذ2", "Moaz2", "122", "2مصر", "Egypt2" },
                    { 3, "معاذ3", "Moaz3", "123", "3مصر", "Egypt3" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5428), new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5445), new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5445) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5450), new DateTime(2024, 9, 23, 23, 6, 26, 52, DateTimeKind.Local).AddTicks(5451) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4743), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4759), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4760) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4764), new DateTime(2024, 9, 23, 18, 31, 16, 281, DateTimeKind.Local).AddTicks(4765) });
        }
    }
}
