using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SunriseWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "AdmissionDate", "BirthDate", "BirthPlaceAR", "BirthPlaceEN", "CreatedBy", "CurrentClass", "CurrentGradeID", "DateCreated", "DateUpdated", "Gender", "IDNumber", "IDNumberEndDate", "NationalityEN", "NaturalityAR", "Passport", "PasswordEndDate", "PhoneNumber1", "PhoneNumber2", "PreviousSchoolAR", "PreviousSchoolEN", "StudentNameAR", "StudentNameEN", "StudentStatusFlag", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "" },
                    { 2, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "" },
                    { 3, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 3);
        }
    }
}
